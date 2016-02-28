$(document).ready(function () {
    /* 实现文件上传 */
    var uploadFile = new UploadFile(".oa-upload", "/PersonalInfo/UploadImg", true, {
        mime_types: [{
            title: 'image files',
            extensions: 'gif,png,jpg,ico'
        }],
        max_file_size: '4096kb',//不能大于4mb
        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
    });
    //绑定事件：点击头像图片，左键应用此图片，右键删除此图片（删除前要提示确认）
    var imgSelect = $(".am-text-nowrap").get(0);
    imgSelect.oncontextmenu = function () {
        return false;
    }
    //给图片绑定左右键点击事件
    var eventFunc = function () {
        $(".am-text-nowrap img").mouseup(function (e) {
            var src = $(this).attr("src");
            var en = window.event || e;
            var value = en.button;
            if (value === 2 || value === 3) {
                //点击右键
                var isSucre = window.confirm("确定要删除服务器的图片吗？\n" + src);
                var self = this;
                if (isSucre) {
                    $.ajax({
                        url: "DelHeadPicture",
                        data: "src="+src,
                        type:"POST",
                        dataType: "json",
                        //beforeSend: function (xhr) {},
                        success: function (data,textStatus) {
                            if (data) {
                                $(self).remove();//移除指定图片，应用最后一张图片
                                var lastSrc = $(".am-text-nowrap img").last().attr("src");
                                $("#headPicture").attr("src", lastSrc);
                                $("#head-picture").attr("src", lastSrc);
                            }
                        },
                        complete: function (xhr,textStatus) {
                            if (xhr.status !== 200) {
                                alert("请求删除您指定的头像失败：" + textStatus+"\nHTTP状态码："+xhr.status);
                            }
                        },
                        async:true
                    });
                }
            } else {
                //点击左键
                $("#headPicture").attr("src", src);
            }
        });
    }
    eventFunc();
    //每上传完一个图片就重新请求图片进行显示出来
    var callbackFunc = function () {
        $.ajax({
            url: "GetHeadPicture",
            type: "POST",
            dataType: "json",
            //beforeSend: function (xhr) {},
            success: function (data, textStatus) {
                if (data) {
                    $(".am-text-nowrap").empty();//移除指定图片，应用最后一张图片
                    var html="";
                    data.forEach(function (headImg,index,data) {
                        html+="<img class=\"am-img-thumbnail\" src=\""+headImg+"\" alt=\"头像\" title=\"点击左键应用，右键删除\" />";
                    });
                    $(".am-text-nowrap").html(html);
                    eventFunc();
                }
            },
            async: true
        });
    }
    uploadFile.fileDialog(callbackFunc);
    
    /* 实现获取验证码 */
    //根据手机号和邮箱确认要发送的验证码类型，发送前验证输入是否正确，并进行验证码输入处理

    /* 实现提交修改信息 */
    //表单提交验证，然后保存员工信息
});