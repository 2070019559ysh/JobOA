$(function () {
    var mess=$("#mess").val();
    if (mess) {
        var modal = new Modal("删除主任务提示", "delete-majortask");
        modal.alert(mess);
        $("#mess").val("");
    }
    $("#project").change(function () {
        var projectId=$(this).val();
        var departmentId=$("#department").val();
        var searchText = $("#search-text").val();
        searchText.replace(/(^\s+)|(\s+$)/g, "");
        window.location.href = "/AdminTask/Index?search="+projectId+","+departmentId+","+searchText;
    });
    $("#department").change(function () {
        var projectId = $("#project").val();
        var departmentId = $("#department").val();
        var searchText = $("#search-text").val();
        searchText.replace(/(^\s+)|(\s+$)/g, "");
        window.location.href = "/AdminTask/Index?search=" + projectId + "," + departmentId + "," + searchText;
    });
    $(".update-record").click(function () {
        var id = $(this).parents("li:first").find(".majortask-id").text();
        window.location.href = "/AdminTask/UpdateMajorTask/" + id;
    });
    $(".del-record").click(function () {
        var id = $(this).parents("li:first").find(".majortask-id").text();
        var name = $(this).parents("li:first").children("h4").text();
        var modal = new Modal();
        var text = "<span class=\"am-icon-warning am-icon-lg\"></span><span>确认要删除“" + name + "”主任务吗？</span>";
        var confirmFun = function () {
            window.location.href = "/AdminTask/DelMajorTask/" + id;
        }
        modal.confirm(text, true, confirmFun);
    });
    $("#search-btn").click(function () {
        var searchText = $("#search-text").val();
        var projectId = $("#project").val();
        var departmentId = $("#department").val();
        window.location.href = "Index?search=" + projectId + "," + departmentId + "," + searchText;
    });
    $("#search-text").bind("keyup change", function () {
        var searchText = $("#search-text").val();
        var projectId = $("#project").val();
        var departmentId = $("#department").val();
        $(".am-pagination a").each(function () {
            var aHref = $(this).attr("href");
            aHref = aHref.replace(/search=.*/, "search=" + projectId + "," + departmentId + "," + searchText)
            $(this).attr("href", aHref);
        });
    });
    $(".lookup-subtask").click(function () {
        var id = $(this).parents("li:first").find(".majortask-id").text();
        window.location.href = "/AdminSubTask/Index/" + id;
    });
});