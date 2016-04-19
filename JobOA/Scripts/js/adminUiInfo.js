$(function () {
    $("#add-oaui").click(function () {
        var path = window.location.pathname;
        var end = path.indexOf("/", 1);
        if (end === -1) {
            end = path.length;
        }
        path = path.substring(0, end);
        window.location.href = path + "/AddOaui";
    });
    $(".update-oaui").click(function () {
        var oauiId = $(this).parents("tr:first").children("td:first").text();
        window.location.href = "/AdminUiInfo/UpdateOaui/" + oauiId;
    });
    $(".del-oaui").click(function () {
        var $nowTr = $(this).parents("tr:first");
        var oauiId = $nowTr.children("td:first").text();
        var oauiName = $nowTr.children("td:eq(1)").text();
        if ($nowTr.children("td:eq(2)").text()) {
            oauiName += "："+$nowTr.children("td:eq(2)").text();
        }
        var modal = new Modal();
        var text = "<span class=\"am-icon-warning am-icon-lg\"></span><span>确认要删除“" + oauiName + "”系统信息吗？</span>";
        var confirmFun = function () {
            window.location.href = "/AdminUiInfo/DelOaui/" + oauiId;
        }
        modal.confirm(text, true, confirmFun);
    });
    $("#search-btn").click(function () {
        var oauiName = $("#search-text").val();
        window.location.href = "/AdminUiInfo/Index?search=" + oauiName;
    });
    $("#search-text").bind("keyup change", function () {
        var oauiName = $("#search-text").val();
        $(".am-pagination a").each(function () {
            var aHref = $(this).attr("href");
            aHref = aHref.replace(/search=.*/, "search=" + oauiName)
            $(this).attr("href", aHref);
        });
    });
});