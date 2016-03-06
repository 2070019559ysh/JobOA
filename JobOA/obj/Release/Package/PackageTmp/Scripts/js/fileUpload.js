/*
* 实例化上传文件功能类的构造方法
* @param {String} 触发打开上传功能界面的选择器
* @param {String} 上传的服务器地址
* @param {Object} 上传文件过滤配置对象
* @return UploadFile对象
*/
var UploadFile = function (selector, url,multiSelect, filters) {
    //定义对象的属性
    Object.defineProperties(this, {
        url: {
            set: function (value) {
                if (!value) {
                    throw new Error("Object of UploadFile 's url is not null.");
                } else {
                    url = value;
                }
            },
            get: function () { return url; }
        },
        selector: {
            set: function (value) {
                if (!value) {
                    throw new Error("Object of UploadFile 's selector is not null.");
                } else {
                    selector = value;
                }
            },
            get: function () { return selector; }
        },
        filters: {
            set:function(value){
                if (!value) {
                    value = {
                        mime_types: [{
                            title: 'image files',
                            extensions: 'gif,png,jpg,ico'
                        },
                        {
                            title: '压缩文件',
                            extensions: 'zip,iso'
                        }],
                        max_file_size: '4096mb',//不能大于4G
                        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
                    };
                }
                filters = value;
            },
            get: function () { return filters; }
        },
        multiSelect: {
            set: function(value){
                if (!value) {
                    value = true;
                }
                multiSelect = value;
            },
            get: function () { return multiSelect;}
        }
    });
    this.selector = selector;
    this.url = url;
    this.filters = filters;
    //给失去事件的元素添加事件
    var bindEvent = function (uploader) {
        //移除按钮的显示隐藏
        $("#files tr").hover(function () {
            $(this).find("span[class*='am-badge']").show();
        }, function () {
            $(this).find("span[class*='am-badge']").hide();
        });
        $("#files .remove").click(uploader, function (event) {
            uploader = event.data;
            var fileId = $(this).parents("tr:first").find("td:first input").attr("id");
            uploader.removeFile(uploader.getFile(fileId));
        });
    }
    //显示文件上传总进度
    var totalUploadProgress = function (uploader) {
        $("#joboa-modal").find(".state").text(stateTxt(uploader.state));
        $("#joboa-modal").find(".size").text(sizeTxt(uploader.total.size));
        $("#joboa-modal").find(".loaded").text(sizeTxt(uploader.total.loaded));
        $("#joboa-modal").find(".uploaded").text(uploader.total.uploaded);
        $("#joboa-modal").find(".failed").text(uploader.total.failed);
        $("#joboa-modal").find(".total").text(uploader.total.uploaded + uploader.total.failed + uploader.total.queued);
        $("#joboa-modal").find(".perSec").text(sizeTxt(uploader.total.bytesPerSec));
        $("#joboa-modal").find(".percent").css("width", uploader.total.percent + "%").text(uploader.total.percent + "%");
    }
    //对文件或进度值处理后返回合适的单位值
    var sizeTxt = function (value) {
        var measure;
        var i = 0;
        for (; i < 3; i++) {
            if (value / 1024 >= 1) {
                value = value / 1024;
            } else {
                break;
            }
            switch (i) {
                case 0: measure = "KB";
                    break;
                case 1: measure = "MB";
                    break;
                case 2: measure = "GB";
                    break;
            }
        }
        if (i == 0)
            measure = "B";
        return (value.toFixed(2)+measure);
    }
    //根据文件状态返回文字描述信息
    var fileStatus = function (fileStatus) {
        if (fileStatus === plupload.QUEUED) {
            return "排队等待";
        }
        if (fileStatus === plupload.UPLOADING) {
            return "正在上传";
        }
        if (fileStatus === plupload.FAILED) {
            return "上传失败";
        }
        if (fileStatus === plupload.DONE) {
            return "上传成功";
        }
    }
    //根据总进度状态码返回进度文字信息
    var stateTxt = function (state) {
        switch (state) {
            case plupload.STOPPED:
                return "已停止上传";
            case plupload.STARTED:
                return "正在上传";
            case plupload.QUEUED:
                return "文件队列等待上传";
        }
    }
    //根据错误码返回错误文字信息
    var errorTxt = function (code) {
        switch (code) {
            case plupload.GENERIC_ERROR:
                return "发生通用错误";
            case plupload.HTTP_ERROR:
                return "Http请求错误";
            case plupload.IO_ERROR:
                return "磁盘读写错误";
            case plupload.SECURITY_ERROR:
                return "因安全问题而产生错误";
            case plupload.INIT_ERROR:
                return "初始化时发生错误";
            case plupload.FILE_SIZE_ERROR:
                return "选择的文件太大";
            case plupload.FILE_EXTENSION_ERROR:
                return "选择的文件类型不符合要求";
            case plupload.FILE_DUPLICATE_ERROR:
                return "不允许选择重复文件";
            case plupload.IMAGE_FORMAT_ERROR:
                return "图片格式错误";
            case plupload.IMAGE_MEMORY_ERROR:
                return "发生内存错误";
            case plupload.IMAGE_DIMENSIONS_ERROR:
                return "文件过大错误";
        }
    }
    var self = this;
    if (typeof UploadFile._initMethod == "undefined") {
        //给按钮绑定打开文件上传对话框事件，completeFunc是上传完一个文件时执行的回调函数
        UploadFile.prototype.fileDialog = function (completeFunc) {
            var uploadFileObj = function () {
                //创建文件上传功能的对象
                var uploader = new plupload.Uploader({
                    browse_button: "browseFile",
                    url: self.url,
                    filters: self.filters,
                    multipart: true, //使用multipart/form-data上传
                    multipart_params: {}, //额外参数
                    chunk_size: 0, //切割每个文件上传的大小，0表示不切割,可是'200kb'
                    resize: {
                        crop: false, //不切割和按原宽度
                        quality: 100,
                        preserve_headers: true //保留元数据
                    },
                    drop_element: "joboa-modal",
                    multi_selection: true,
                    unique_names: false,
                    file_data_name:"file",
                    flash_swf_url: "../plUpload/Moxie.swf",
                    sliverlight_xap_url: "../plUpload/Moxie.xap"
                });
                uploader.init();
                bindEvent(uploader);//绑定事件
                //文件上传按钮事件
                $("#start").bind("click", function () {
                    uploader.start();
                });
                $("#stop").bind("click", function () {
                    uploader.stop();
                })
                //文件停止上传按钮事件
                //某文件开始上传前触发
                uploader.bind("BeforeUpload", function (uploader,file) {

                });
                //某文件开始上传后触发
                uploader.bind("UploadFile", function (uploader, file) {
                });
                //上传文件队列发生变化后触发,优先于FileAdded/FileRemoved触发
                uploader.bind("QueueChanged", function (uploader) {
                    //显示文件队列
                    var $tbody = $("#files").find("tbody");
                    $tbody.empty();
                    uploader.files.forEach(function (file, index, files) {
                        var tr="<tr>"+
                    "<td><input id=\""+file.id+"\" style=\"border:none;\" type=\"text\" class=\"fileName\" value=\""+file.name+"\" readonly/></td>"+
                    "<td>"+file.type+"</td>"+
                    "<td style =\"position:relative;\">"+
                    "<section class=\"am-g\">"+
                    "<div class=\"am-u-md-6\"><small class=\"file-loaded\">" + sizeTxt(file.loaded) + "</small>/<small class=\"file-size\">" + sizeTxt(file.size) + "</small></div>" +
                            "<div class=\"am-u-md-6\"><small class=\"file-status\">" + fileStatus(file.status) + "</small></div>" +
                            "<div class=\"am-u-md-12\">"+
                                "<div class=\"am-progress am-progress-striped  am-margin-0\">"+
                                    "<div class=\"am-progress-bar am-progress-bar-secondary\" style=\"width: "+file.percent+"%\">"+
                                        file.percent+"%"+
                                    "</div>"+
                                "</div>"+
                            "</div>"+
                        "</section>"+
                        "<span style=\"display:none;position:absolute;top:0;right:0;cursor:pointer\" title=\"移除\" class=\"am-badge am-badge-danger remove\">－</span>" +
                    "</td>"+
                "</tr>";
                        $tbody.append(tr);
                    });
                    totalUploadProgress(uploader);//显示总进度
                    bindEvent(uploader);//重新绑定事件
                });
                //上传队列文件状态发生改变后触发
                uploader.bind("StateChanged", function (uploader) {
                });
                //上传文件实时进度
                uploader.bind("UploadProgress", function (uploader,file) {
                    totalUploadProgress(uploader);//显示总进度
                    var $tr = $("#" + file.id).parents("tr:first");
                    $tr.find(".file-loaded").text(sizeTxt(file.loaded));
                    $tr.find(".file-size").text(sizeTxt(file.size));
                    $tr.find(".am-progress-bar").text(file.percent+"%").css("width", file.percent + "%");
                    $tr.find(".file-status").text(fileStatus(file.status));
                });
                //文件被添加到上传队列前触发，可进行文件过滤
                uploader.bind("FileFiltered", function (uploader,file) {
                });
                //文件添加到队列后触发
                uploader.bind("FilesAdded", function (uploader, files) {
                });
                //文件从队列中移除后触发
                uploader.bind("FilesRemoved", function (uploader, files) {
                });
                //某文件上传完成后触发
                uploader.bind("FileUploaded", function (uploader, file,responseObj) {
                    var $tr = $("#" + file.id).parents("tr:first");
                    if(file.percent===100)
                        $tr.find(".am-progress-bar").text("完成");
                    completeFunc();
                });
                //每一小片文件上传完成后触发
                uploader.bind("ChunkUploaded", function (uploader, file, responseObj) {
                });
                //队列中所有文件上传完成后触发
                uploader.bind("UploadCompleted", function (uploader, files) {
                });
                //发生错误时触发
                uploader.bind("Error", function (uploader, errObj) {
                    window.alert("发生错误：\n" + errorTxt(errObj.code) + " " + errObj.message +
                        "\n"+errObj.file.name+"文件处理错误");
                });

            }
            var modal = new Modal("文件上传");
            var first = true;
            //绑定打开文件上传窗口事件
            $(this.selector).click(function () {
                var $html;
                if (first) {
                    var html = [
                       "<div class=\"am-center am-btn-group-xs am-margin-bottom-xs\">",
               "<button id=\"browseFile\" class=\"am-btn am-btn-success am-margin-right-xs\">选择文件</button>",
               "<button id=\"start\" class=\"am-btn am-btn-primary am-margin-right-xs\">开始上传</button>",
               "<button id=\"stop\" class=\"am-btn am-btn-danger\">停止上传</button>",
               "</div>",
                       "<table class=\"am-table am-table-bordered  am-table-compact\">",
           "    <tr>",
           "        <td class=\"am-hide-sm-only\" rowspan=\"2\">总进度</td>",
           "        <td><section><small>文件大小进度：</small><span class=\"loaded\">0.00B</span>/<span class=\"size\">0.00B</span></section>",
           "        <section><small>文件数量进度：</small>成功<span class=\"uploaded\">0</span>个/共<span class=\"total\">0</span>个</section>",
           "        <section><span class=\"am-icon-warning\"></span><small>上传失败文件数量：</small><span class=\"failed\">0</span>个</section>",
           "        <section><small>上传速度：</small><span class=\"perSec\">0.00B</span>/s&nbsp;&nbsp;<samll class=\"state\">已停止上传</small></section></td>",
           "    </tr>",
           "    <tr>",
           "        <td>",
           "            <div class=\"am-progress am-progress-striped am-margin-0\">",
           "                <div class=\"percent am-progress-bar am-progress-bar-secondary\" style=\"width:0%\">0%</div>",
           "            </div>",
           "        </td>",
           "    </tr>",
           "</table>",
           "<div style=\"height:100px;overflow-y:scroll\">",
           "    <table id=\"files\" class=\"am-table am-table-bordered  am-table-compact\">",
           "        <caption>文件队列</caption>",
           "        <thead><tr>",
           "            <th width=\"100px\">文件名</th>",
           "            <th>文件类型</th>",
           "            <th>上传进度</th>",
           "        </tr></thead>",
           "        <tbody></tbody>",
           "    </table>",
           "</div>"].join("");
                    $html = $(html);
                    first = false;
                    modal.alert($html);
                    window.setTimeout(uploadFileObj, 500);
                } else {
                    modal.alert();
                }
            });
        }
        UploadFile._initMethod = true;
    }
}