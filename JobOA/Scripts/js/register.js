//加载完马上绑定头像按钮事件，触发真实的文件上传按钮选中

//设置用户选中的roleId值拼接在一起进行提交
var setRoleIds = function () {
    var roleIds = "";
    $(document.getElementsByName("roleId")).each(function () {
        if ($(this).attr("checked")) {
            if (roleIds == "") {
                roleIds = $(this).val();
            } else {
                roleIds += ","+$(this).val();
            }
        }
    });
    $("input[name='roleIds']").val(roleIds);
}

var type;//标志验证类型
var self;//当前获取验证码按钮
//发送验证码前，要进行操作验证
var check = function () {
    var inputModal = new Modal("输入验证提示", "numCheck");
    self = this;
    if ($(this).attr("id").search("Phone") >= 0) {
        //手机验证码
        type = "phone";
        var num = $("#phoneNum").val();
        var phoneNumTip = $("#phoneNum").next().children().text();//号码验证的提示内容
        if (phoneNumTip.search("被注册过") > -1) return;
        if (!(/^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$/).test(num)) {
            inputModal.alert("您的手机号码格式有误！");
            return;
        }
    } else {
        //邮箱验证码
        type = "email";
        var email = $("#Email").val();
        if (!(/^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$/).test(email)) {
            inputModal.alert("您的邮箱格式有误！");
            return;
        }
    }
    var checkModal = new Modal("请求验证码前的验证提示", "checkModal");
    var confirmFun = function (e) {
        e.data = $("#checkModal").find(".am-modal-prompt-input").val();
        //请求服务器验证验证码是否正确
        $.post("CheckVerificationCode", { 'vaildCode': e.data }, function (data) {
            var imgTag = $("#checkModal").find(".am-modal-bd img");
            if (!data.result) {
                var insertElement = '<span class="am-inline-block am-text-danger" style="margin:0px 10px;">验证码错误</span>';
                if (imgTag.next("span").length > 0) {
                    imgTag.next("span").replaceWith(insertElement);
                } else {
                    imgTag.after(insertElement);
                }
            } else {
                if (imgTag.next("span").length > 0) {
                    imgTag.next("span").replaceWith('<span class="am-inline-block am-text-success" style="margin:0px 10px;">验证通过</span>');
                } else {
                    imgTag.after('<span class="am-inline-block am-text-success" style="margin:0px 10px;">验证通过</span>');
                }
                window.setTimeout(function () {
                    $("#checkModal").modal('close');
                }, 300);
                GetVerificationCode(self,type);
            }
        }, "json");
    }
    checkModal.prompt('请输入验证码：<img src="GetVerificationImg" onclick="this.src=this.src+\'?\'"/>', "",false,confirmFun);
}

//获取验证码
function GetVerificationCode(btnObj,type) {
    var num;//号码
    var replaceElement;//标签
    if (type === "phone") {
        num = $("#phoneNum").val();
        replaceElement = '<input type="text" name="phoneCheck" id="phoneCheck" placeholder="请输入手机短信里的验证码" require/>';
    } else {
        num = $("#Email").val();
        replaceElement = '<input type="text" name="emailCheck" id="emailCheck" placeholder="请输入邮箱里的验证码" require/>';
    }
    //点击后替换为输入框，同时请求服务器发验证码
    $.post("GetVerificationCode", { 'num': num, 'type': type }, function (data) {
        $(btnObj).removeClass("am-disabled");
        if (data.result) {
            $(btnObj).replaceWith(replaceElement);
        } else {
            $(btnObj).text("失败！重新获取验证码");
        }
    }, "json");
    $(btnObj).addClass("am-disabled");
    $(btnObj).text("正在发送验证码");
}

$(document).ready(function () {
    var isPass = true;
    var hasCheckUserName = false;
    //验证重复密码
    var rpasswordValid = function () {
        if ($("#rpassword").val() !== $("#password").val()) {
            $("#rpassword").css("border-color", "red");
            $("#rpassword").next().children().text("重复密码和原密码不一致");
            isPass = false;
        } else {
            $("#rpassword").css("border-color", "");
            $("#rpassword").next().children().text("");
            isPass = true;
        }
    }
    //检查必须项是否为空
    var checkRequired = function () {
        isPass = false;
        if (!$("[id$='honeCheck']").val()) {
            $("[id$='honeCheck']").next().children().text("手机号有效性确认不通过");
        } else if (!$("#password").val()) {
            $("#password").next().children().text("密码不能为空");
        } else if (!$("#trueName").val()) {
            $("#trueName").next().children().text("真实姓名不能为空");
        } else {
            isPass = true;
        }
    }
    //点击按钮选则上传的图片
    $("#photo button").click(function () {
        $("#headPictureFile").click();
    });
    $("#headPictureFile").change(function () {
        var path = $(this).val();
        $("#coverFile input").val(path);
        var fileName = path.substring(path.lastIndexOf("\\") + 1);
        //对图片名中的中文转拼音
        fileName=pinyin.getFullChars(fileName);
        $("#headPicture").val(fileName);
    });

    //验证用户名是否唯一
    function checkUserName() {
        isPass = false;
        hasCheckUserName = true;
        var value = $(this).val();//输入的值
        var spanTag = $(this).next().children("span")
        if (!value) {
            spanTag.text("账号不能为空，*标注的都不能为空");
        } else {
            $.ajax({
                url: "CheckUserNameUnique",
                type: "POST",
                data: "userName=" + value,
                beforeSend: function () {
                    spanTag.text("开始验证账号（手机号）是否可注册");
                },
                error: function (xhr, textStatus) {
                    spanTag.text("请求验证出错，http状态码：" + xhr.status + "，请求结果：" + textStatus);
                },
                success: function (data) {
                    if (data.isUnique) {
                        spanTag.text("可进行注册");
                        isPass = true;
                    } else {
                        spanTag.text("已被注册过，请更换账号（手机号）");
                    }
                },
                dataType: "json",
                asyn: true
            });
        }
    }
    
    //账号输入失去焦点时，验证是否唯一
    $("#phoneNum").blur(checkUserName);

    //失去焦点时验证重复密码
    $("#rpassword").blur(rpasswordValid);

    $("#form-with-tooltip").submit(function () {
        rpasswordValid();
        checkRequired();
        if (!hasCheckUserName) {
            //还没有验证用户名，要触发验证
            $("#phoneNum").trigger("blur");
        }
        if (!isPass) {
            $("#submitBtn").addClass("am-animation-shake");
            window.setTimeout(function () {
                $("#submitBtn").removeClass("am-animation-shake");
            },300);
            return false;
        } else {
            return true;
        }
    });
    //点击获取手机验证码
    $("#getPhoneCheck").click(check);
    //点击获取邮箱验证码
    $("#getEmailCheck").click(check);

    //去登录按钮绑定
    $("#goLogin").bind('click', function () {
        window.location.href = "Login";
    });
});