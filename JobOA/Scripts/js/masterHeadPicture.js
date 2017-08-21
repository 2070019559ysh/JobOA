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

});