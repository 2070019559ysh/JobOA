$(document).ready(function () {
    //点击部门下拉，联动员工信息
    $(".department").children("select").change(function () {
        var departmentId = $(this).val();
        var $employeeEle = $(this).parent(".department").next().children("select");
        $.ajax({
            url: "/AdminTask/GetEmployeeInfo",
            data: "departmentId=" + departmentId,
            type: "POST",
            dataType: "json",
            async: true,
            beforeSend: function () {
                $employeeEle.empty();
            },
            success: function (data) {
                if (data && data.length > 0) {
                    for (var i in data) {
                        $employeeEle.append("<option value=\"" + data[i].Id + "\">" + data[i].RealName + "</option>");
                    }
                } else {
                    $employeeEle.append("<option value=\"\">无</option>");
                }
            },
            complete: function (xhr) {
                if (xhr.status != 200) {
                    $employeeEle.append("<option value=\"\">无</option>");
                }
            }
        });
    });
    //修改进度时显示进度
    $("input[name='Progress']").change(function () {
        $(this).parents("div:first").next().children().css("width", $(this).val() + "%").text($(this).val() + "%");
    });
    /* 实现文件上传 */
    var uploadFile = new UploadFile("#upload-file", "/AdminSubTask/UploadFile", true, {
        mime_types: [{
            title: '任务包压缩文件',
            extensions: '7z,zip,rar,iso'
        }],
        max_file_size: '4096mb',//不能大于4GB
        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
    });
    uploadFile.fileDialog();
});