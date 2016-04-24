$(function () {
    //检查到没有头像则用ajax去请求头像
    if (!$("#head-picture").get(0)) {
        $.ajax({
            url: "/Account/EmployeeMess",
            type: "POST",
            complete: function (xhr) {
                if (xhr.status !== 200) {
                    $("#head-picture").after(xhr.status);
                }
            },
            success: function (data) {
                $("#head-picture").attr("src", data.HeadPicture);
                $("#head-picture").after(data.RealName);
            },
            async: true,
            dataType: "json"
        });
    }

    //加载公告信息
    $.ajax({
        url: "/AdminHome/LoadRemark",
        type: "GET",
        error: function (xhr,statusText,thrown) {
            if (xhr.status !== 200) {
                $("#head-picture").append("<div class=\"am-panel am-panel-default admin-sidebar-panel\"><div class=\"am-panel-bd\"><p><span class=\"am-icon-bookmark\"></span> &nbsp;公告</p><p>加载公告信息失败" + xhr.status + " " + statusText + " " + thrown + "</p></div></div>");
            }
        },
        success: function (data) {
            $("#admin-offcanvas .am-offcanvas-bar").append(data);
        },
        async: true,
        dataType: "html"
    });

    //使用本地存储记录当前选择的菜单
    var liMenuIndex = window.localStorage.getItem("liIndex");
    var openMenuId = window.localStorage.getItem("amIn");
    if (window.location.href.indexOf("/AdminHome/Index") > 0) {
        $("#admin-offcanvas").find("li:eq(0)").css("background-color", "#3bb4f2");

    }else if (liMenuIndex) {
        $("#admin-offcanvas").find("li:eq(" + liMenuIndex + ")").css("background-color", "#3bb4f2");
    } else {
        $("#admin-offcanvas").find("li:eq(0)").css("background-color", "#3bb4f2");
    }
    if (openMenuId) {
        $("#" + openMenuId).addClass("am-in");
    }

    //点击导航菜单时记录点击的菜单项到本地存储
    $("#admin-offcanvas").find("li a[href^='/']").click(function () {
        var liIndex = $("#admin-offcanvas").find("li").index($(this).parent("li"));
        window.localStorage.setItem("liIndex", liIndex);
        $("ul[id^='collapse-nav']").each(function(){
            if($(this).attr("class").indexOf("am-in")>-1){
                var amInId = $(this).attr("id");//有打开状态的标签的id
                window.localStorage.setItem("amIn", amInId);
                return false;
            }
        });
    });
});