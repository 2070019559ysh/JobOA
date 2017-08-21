$(document).ready(function () {
    //点击部门下拉，联动员工信息
    $(".department").children("select").change(function () {
        var departmentId = $(this).val();
        var $employeeEle = $(this).parent(".department").next().children("select");
        $.ajax({
            url: "GetEmployeeInfo",
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
    $("form").submit(function () {
        var isValid=true;
        $(".am-text-danger").each(function(){
            if($(this).text()){
                isValid = false;
                return false;
            }
        });
        if (!isValid) {
            return false;
        }
        var taskName = (document.getElementsByName("Name"))[0].value;
        var arrangePersonId = (document.getElementsByName("ArrangePersonId"))[0].value;
        var exePersonId = (document.getElementsByName("ExePersonId"))[0].value;
        var checkPersonId = (document.getElementsByName("CheckPersonId"))[0].value;
        var participator = (document.getElementsByName("Participator"))[0].value;
        var startTime = (document.getElementsByName("StartTime"))[0].value;
        var completeTime = (document.getElementsByName("CompleteTime"))[0].value;
        var state = (document.getElementsByName("State"))[0].value;
        var projectId = (document.getElementsByName("ProjectId"))[0].value;
        var secrecyEle = (document.getElementsByName("IsSecrecy"))[0];
        var isSecrecy=false;
        if (secrecyEle.checked) {
            isSecrecy = true;
        }
        var $submitBtn = $("button[type='submit']");
        var modal = new Modal();
        $.ajax({
            url: "AddMajorTask",
            data: {
                "Id": $("#Id").val(),
                "CreateTime":$("#CreateTime").val(),
                "Name": taskName,
                "ArrangePersonId": arrangePersonId,
                "ExePersonId": exePersonId,
                "CheckPersonId": checkPersonId,
                "Participator": participator,
                "StartTime": startTime,
                "CompleteTime": completeTime,
                "State": state,
                "ProjectId": projectId,
                "IsSecrecy":isSecrecy
            },
            type: "POST",
            dataType: "json",
            async: true,
            beforeSend: function () {
                $submitBtn.addClass("am-disabled");
                $submitBtn.text("开始创建主任务");
            },
            success: function (data) {
                if (data.result) {
                    modal.alert(data.text, function () {
                        window.location.href = "/AdminTask";
                    });
                } else {
                    modal.alert(data.text);
                }
            },
            complete: function (xhr,textStatus) {
                if (xhr.status != 200) {
                    modal.alert("请求失败！" + xhr.status + "," +textStatus );
                }
                $submitBtn.removeClass("am-disabled");
                $submitBtn.text("创建主任务");
            }
        });
        return false;//阻止默认的提交
    });
});