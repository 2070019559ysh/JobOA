$(function () {
    $("#add-project").click(function () {
        window.location.href = "AddProject";
    });
    $(".update-project").click(function () {
        var projectId=$(this).parents("tr:first").children("td:first").text();
        window.location.href = "UpdateProject?projectId=" + projectId;
    }); 
    $(".del-project").click(function () {
        var projectId = $(this).parents("tr:first").children("td:first").text();
        var projectName = $(this).parents("tr:first").children("td:eq(1)").text();
        var modal = new Modal();
        var text = "<span class=\"am-icon-warning am-icon-lg\"></span><span>确认要删除“" + projectName + "”项目吗？</span>";
        var confirmFun=function(){
            window.location.href = "DelProject?projectId=" + projectId;
        }
        modal.confirm(text, true, confirmFun);
    });
    $("#search-btn").click(function () {
        var projectName = $("#search-text").val();
        window.location.href = "Index?search=" + projectName;
    });
    $("#search-text").bind("keyup change", function () {
        var projectName = $("#search-text").val();
        $(".am-pagination a").each(function () {
            var aHref = $(this).attr("href");
            aHref=aHref.replace(/search=.*/,"search="+projectName)
            $(this).attr("href", aHref);
        });
    });
});