$(function () {
    $("#goLogin").click(function () {
        var self = this;
        var $userName=$("#userName");
        var $password = $("#password");
        var $loginMess = $("#loginMess");
        var isPass = false;
        if (!$userName.val()) {
            $loginMess.text("用户名不能为空");
        }else if (!$password.val()) {
            $loginMess.text("密码不能为空");
        } else {
            isPass = true;
        }
        if (!isPass) {
            $(this).addClass("am-animation-shake");
            window.setTimeout(function () {
                $(self).removeClass("am-animation-shake");
            }, 300);
        } else {
            //验证通过，请求登录
            $.ajax({
                type:"POST",
                url: "/Account/Login",
                data: "userName="+$userName.val()+"&password="+$password.val(),
                beforeSend: function (xhr) {
                    $loginMess.text("");
                    $("#goLogin").val("登录中...");
                },
                error: function (xhr, textStatus) {
                    $("#goLogin").val("登录");
                    $loginMess.text(xhr.status + ":请求登录失败," + textStatus);
                },
                success: function (data, textStatus) {
                    $("#goLogin").val("登录");
                    if (data.result) {
                        $loginMess.text("登录成功");
                        $("#loginAlert").hide(1000);
                        $("#loginAlert").css("top", "-600px");
                        $("#cover").fadeOut(500);
                    } else {
                        $loginMess.text("用户名或密码错误！请求登录失败");
                    }
                },
                async:true,
                dataType:"json"
            });
        }
    });
});