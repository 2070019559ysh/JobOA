$(function () {
    $("#add-record").click(function () {
        var path = window.location.pathname;
        var end=path.indexOf("/",1);
        if(end===-1){
            end=path.length;
        }
        path = path.substring(0, end);
        window.location.href = path+"/AddRecord";
    });
    $(".update-record").click(function () {
        var recordId=$(this).parents("tr:first").children("td:first").text();
        window.location.href = "UpdateRecord/" + recordId;
    }); 
    $(".del-record").click(function () {
        var recordId = $(this).parents("tr:first").children("td:first").text();
        var recordName = $(this).parents("tr:first").children("td:eq(1)").text();
        var modal = new Modal();
        var text = "<span class=\"am-icon-warning am-icon-lg\"></span><span>确认要删除“" + recordName + "”项目吗？</span>";
        var confirmFun=function(){
            window.location.href = "DelRecord/" + recordId;
        }
        modal.confirm(text, true, confirmFun);
    });
    $("#search-btn").click(function () {
        var recordName = $("#search-text").val();
        window.location.href = "Index?search=" + recordName;
    });
    $("#search-text").bind("keyup change", function () {
        var recordName = $("#search-text").val();
        $(".am-pagination a").each(function () {
            var aHref = $(this).attr("href");
            aHref=aHref.replace(/search=.*/,"search="+recordName)
            $(this).attr("href", aHref);
        });
    });
});