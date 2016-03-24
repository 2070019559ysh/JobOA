$(function () {
    $("#to-emp").blur(function () {
        var userName = $(this).val();
        userName=userName.replace(/\s+/g,"");//去除所有空格字符
        if (userName) {
            $.ajax({
                url: "/PersonalInfo/EmployeeMess",
                data: "id=" + userName,
                type:"POST",
                success: function (data,textStatus,xhr) {
                    if (data && (typeof data)==="object") {
                        var toempInfo = $("#to-emp").next("section[class^='am-badge']");
                        $("#ToEmployeeId").val(data.Id);
                        toempInfo.children("img:first").attr("src", data.HeadPicture);
                        toempInfo.children("span:first").text(data.UserName);
                        toempInfo.children("span:eq(1)").text(data.RealName);
                        $("#to-emp").hide();
                        toempInfo.show();
                        $("#valid-username").text("");
                        //确认是否可通过邮件发送消息
                        if (data.Email !== null) {
                            $("#messtype3").attr("disabled", false);
                        } else {
                            $("#messtype3").attr("disabled", true);
                        }
                    } else {
                        $("#valid-username").text("员工账号无效或无权限获取员工资料");
                    }
                },
                error:function(xhr,textStatus,errorthrown){
                    $("#valid-username").text("员工账号检查出错："+xhr.status+" "+textStatus+" "+errorthrown);
                },
                dataType: "json",
                async:true
            });
        } else {
            $("#valid-username").text("员工账号不能为空");
        }
    });
    
});

//重新输入收件人账号
var reEnterUserName = function () {
    $("#to-emp").show();
    $("#to-emp").next("section[class^='am-badge']").hide();
    $("#to-emp").focus();
}

//点击提交发送按钮
var sendMess = function () {
    var toUserName = $("#ToEmployeeId").val();//发送目标账号
    var title = $("#Title").val();//消息标题
    var extraMess = window.document.getElementById("extra-message").value;//消息额外内容
    var messType = $("input[name='messtype']:checked").val();//消息发送方式
    $.ajax({
        url: "/PersonalInfo/SendMess",
        data: { "ToEmployeeId": toUserName, "Title": title, "ExtraMessage": extraMess, "messtype": messType },
        type: "POST",
        success: function (data, textStatus, xhr) {
            if (data && (typeof data) === "object") {
            } else {
            }
        },
        error: function (xhr, textStatus, errorthrown) {
        },
        dataType: "json",
        async: true
    });
}