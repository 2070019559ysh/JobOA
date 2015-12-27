
/*
调用amaze ui的Modal模态窗台，进行信息提示
利用var modal=new Modal();modal.alert();可以像window.alert()进行信息显示
*/
//动态原型方法
function Modal(title,id) {
    if (typeof id === "undefined" || id === "") {
        id = "joboa-modal";
    }
    if (typeof title === "undefined" || title === "") {
        title = "JobOA-系统提示";
    }

    var template = '<div class="am-modal am-modal-confirm" tabindex="-1" id="'+id+'">' +
                '<div class="am-modal-dialog">' +
                    '<div class="am-modal-hd">JobOA</div>' +
                    '<div class="am-modal-bd">' +
                      '你，确定要删除这条记录吗？' +
                    '</div>' +
                    '<div class="am-modal-footer">' +
                      '<span class="am-modal-btn" data-am-modal-cancel>取消</span>' +
                      '<span class="am-modal-btn" data-am-modal-confirm>确定</span>' +
                    '</div>' +
                  '</div>' +
               '</div>';
    //往body里面添加模板html标签
    if ($("body").find("#"+id).length < 1) {
        $(document.body).append(template);
    }
    this.id = id;//标题
    this.footerBtn = $('#' + this.id).find(".am-modal-footer");
    this.modalTitle = $("#" + this.id).find(".am-modal-hd");
    this.modalContent = $("#" + this.id).find(".am-modal-bd");

    //标题的get ,set访问器
    Object.defineProperty(this, "title", {
        get: function () {
            return this.modalTitle.text();
        },
        set: function (value) {
            this.modalTitle.text(value);//设置标题
        }
    });
    this.title = title;//标题
    //创建多个对象都只需第一次创建对象时创建其方法函数
    if (typeof Modal._initMethod == "undefined") {
        
        /*模拟alert
         content是内容支持html格式
         confirmFun是点击确定后执行的函数
         title（可选）重新指定标题
        */
        Modal.prototype.alert = function (content,confirmFun,title) {
            if (this.footerBtn.children().length > 1) {
                this.footerBtn.children("[data-am-modal-cancel]").remove();
            }
            if (typeof title !== "undefined" && title !== "") {
                //当要重新设置标题时，重置标题
                this.modalTitle.text(title);
            }
            this.modalContent.html(content);//设置内容支持html格式
            $('#'+this.id).modal({
                relatedTarget: this,
                onConfirm: confirmFun
            });
        }
        /*模拟confirm
         content是内容支持html格式
         isClose点击确定后是否关闭，默认关闭
         confirmFun是点击确定后执行的函数
         cancelFun是点击取消后执行的函数
         title（可选）重新指定标题
         */
        Modal.prototype.confirm = function (content,isClose, confirmFun, cancelFun, title) {
            if (this.footerBtn.children().length < 2) {
                this.footerBtn.prepend('<span class="am-modal-btn" data-am-modal-cancel>取消</span>');
            }
            if (typeof title !== "undefined" && title !== "") {
                //当要重新设置标题时，重置标题
                this.modalTitle.text(title);
            }
            if (typeof isClose === "undefined" && isClose === "") {
                isClose = true;
            }
            this.modalContent.html(content);//设置内容支持html格式
            $('#'+this.id).modal({
                relatedTarget: this,
                onConfirm: confirmFun,
                closeOnConfirm: isClose,
                onCancel: cancelFun
            });
        }
        /*模拟prompt
         content是提示内容支持html格式
         defaultVal是输入框中的默认值
         isClose点击确定后是否关闭，默认关闭
         confirmFun是点击确定后执行的函数
         cancelFun是点击取消后执行的函数
         title（可选）重新指定标题
         */
        Modal.prototype.prompt = function (content, defaultVal,isClose, confirmFun, cancelFun, title) {
            var inputContent = content + '<input type="text" class="am-modal-prompt-input" value="'+defaultVal+'">';
            this.confirm(inputContent,isClose, confirmFun, cancelFun, title);
        }
        /*启动加载界面
         title（可选）重新指定标题
         content是提示内容支持html格式
         */
        Modal.prototype.loading = function (title, content) {
            var loadingTemp = '<div class="am-modal am-modal-loading am-modal-no-btn" tabindex="-1" id="joboa-loading">' +
                              '<div class="am-modal-dialog">' +
                                '<div class="am-modal-hd">正在加载...</div>' +
                                '<div class="am-modal-bd">' +
                                  '<span class="am-icon-spinner am-icon-spin"></span>' +
                                '</div>' +
                              '</div>' +
                            '</div>';
            if ($("body").find("#joboa-loading").length < 1)
                $("body").append(loadingTemp);
            if (typeof title !== "undefined" && title !== "") {
                //当要重新设置标题时，重置标题
                $("#joboa-loading").find(".am-modal-hd").text(title);
            }
            if (typeof content !== "undefined" && content !== "") {
                //当要设置内容时，添加内容
                $("#joboa-loading").find(".am-modal-bd").html(content + '<span class="am-icon-spinner am-icon-spin"></span>');
            }
            $('#joboa-loading').modal({
                relatedTarget: this,
            });
        }
        //关闭加载界面
        Modal.prototype.loaded = function () {
            $('#joboa-loading').modal({
                relatedTarget: this,
            });
        }
        //标志已经初始化了函数
        Modal._initMethod = true;
    }
}