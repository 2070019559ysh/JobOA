$(function () {
    var ishide = 1;
    //点击用户信息下拉框，显示下拉内容
    $("#userMess").children("a").click(function () {
        $("#oa-dropdown-content").slideToggle(200, function () { ishide++; });
    });
    //点击其他部分，如果是打开下拉，表示现在放弃选择，则收去下拉
    $("#userMess").parents().siblings().click(function () {
        if ((ishide % 2)==false) {
            $("#oa-dropdown-content").slideUp(200, function () { ishide++; });
        }
    })
    //点击下拉内容的任一项，都隐藏下拉内容
    $("#oa-dropdown-content").children("li").click(function () {
        $("#oa-dropdown-content").slideUp(200, function () { ishide++; });
    });
    $("#goLogin").click(function () {
        var self = this;
        var $userName=$("#userName");
        var $password = $("#password");
        var $remember=$("#remember");
        var $loginMess = $("#loginMess");
        var remember="";
        if ($remember.attr("checked")) remember = "1";
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
                data: "userName=" + $userName.val() + "&password=" + $password.val() + "&remember=" + remember,
                beforeSend: function (xhr) {
                    $loginMess.text("");
                    $("#goLogin").val("登录中...");
                    $("#goLogin").addClass("am-disabled");
                },
                error: function (xhr, textStatus) {
                    $("#goLogin").val("登录");
                    $("#goLogin").removeClass("am-disabled");
                    $loginMess.text(xhr.status + ":请求登录失败," + textStatus);
                },
                success: function (data, textStatus) {
                    $("#goLogin").val("登录");
                    $("#goLogin").removeClass("am-disabled");
                    if (data.result) {
                        $loginMess.text("登录成功");
                        if ($("#loginAlert").length === 0) {
                            //当前页面没有登录框，则直接跳转首页
                            location.href = "/";
                            var modal = new Modal();
                            modal.loading("JobOA系统提示", "正在为您跳转到首页");
                        } else {
                            $("#loginAlert").hide(1000);
                            $("#loginAlert").css("top", "-600px");
                            $("#cover").fadeOut(500);
                            $("#loginBtn").hide();
                            var $aTag = $("#userMess").children(":eq(0)");
                            $aTag.find("img").attr("src", data.headPicture);
                            $aTag.find("span").text(data.name);
                            $("#userMess").show();
                        }
                    } else {
                        $loginMess.text("用户名或密码错误！请求登录失败,或未被HR审核通过");
                    }
                },
                async:true,
                dataType:"json"
            });
        }
    });
});