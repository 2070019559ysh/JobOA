$(function () {
    $("#project").change(function () {
        var projectId=$(this).val();
        var departmentId=$("#department").val();
        var searchText = $("#search-text").val();
        searchText.replace(/(^\s+)|(\s+$)/g, "");
        window.location.href = "/AdminTask/Index?search="+projectId+","+departmentId+","+searchText;
    });
    $("#department").change(function () {
        var projectId = $(this).val();
        var departmentId = $("#department").val();
        var searchText = $("#search-text").val();
        searchText.replace(/(^\s+)|(\s+$)/g, "");
        window.location.href = "/AdminTask/Index?search=" + projectId + "," + departmentId + "," + searchText;
    });
});