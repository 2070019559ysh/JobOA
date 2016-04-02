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
                        if (data.Email === null) data.Email = "";
                        $("#Email").val(data.Email);
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
    messLookUpEvent();
    
});
//绑定点击查看消息事件
function messLookUpEvent() {
    $(".oamess-row").unbind("click");
    //点击查看消息
    $(".oamess-row").click(function () {
        var fromHtml = $(this).find("span:eq(1)").html();
        var modal = new Modal("查看消息", "show-oamess");
        var html = "<section class=\"am-g\" style=\"text-align:left\">" +
            "<div class=\"am-u-sm-12\"><label>发消息人：</label>" +
            fromHtml + "</div>" +
            "<div class=\"am-u-sm-12\"><label>标题：</label>" +
            $(this).find("span:eq(2)").text() + "</div>" +
            "<div class=\"am-u-sm-12\"><label>内容：</label></div>" +
            "<div class=\"am-u-sm-12\">" + $(this).find("span:eq(3)").text() + "</div>" +
            "<div class=\"am-u-sm-12 am-u-md-4\"><label>接收时间：</label></div>" +
            "<div class=\"am-u-sm-12 am-u-md-8\">" + $(this).find("span:eq(4)").text() + "</div>" +
            "</section>";
        modal.alert(html);
        var id = $(this).parent("div").find("input:checkbox").val();
        var _this = this;
        //告知服务器此消息已被查看
        if ($(_this).children("span:first").children("i").attr("class") === "am-icon-envelope") {
            $.post("/PersonalInfo/RemarkLookUp", "id=" + id, function (data, textStatus, xhr) {
                if (data) {
                    $(_this).children("span:first").children("i").removeClass().addClass("am-icon-envelope-o").attr("title", "已查看");
                }
            }, "json");
        }
    });
    $("input:checkbox[name='Id']").unbind("click");
    //复选框的全选全不选效果
    $("input:checkbox[name='Id']").click(function () {
        if ($(this).attr("value") === "all") {
            if ($(this).attr("checked")) {
                $("input:checkbox[name='Id']").attr("checked", true);
            } else {
                $("input:checkbox[name='Id']").attr("checked", false);
            }
        } else {
            var $subCheckbox = $("input:checkbox[name='Id']:not([value='all'])");
            var allChecked = true;
            $subCheckbox.each(function (index) {
                if (!$(this).attr("checked")) {
                    allChecked = false;
                    return false;
                }
            });
            if (allChecked) {
                $(":checkbox[value='all']").attr("checked", true);
            } else {
                $(":checkbox[value='all']").attr("checked", false);
            }
        }
    });
}

//重新输入收件人账号
var reEnterUserName = function () {
    $("#to-emp").show();
    $("#to-emp").next("section[class^='am-badge']").hide();
    $("#to-emp").focus();
}

//提交按钮的摇头效果
var shakeHead = function (id) {
    $("#"+id).addClass("am-animation-shake");
    window.setTimeout(function () {
        $("#" + id).removeClass("am-animation-shake");
    }, 300);
}

//点击提交发送按钮
var sendMess = function () {
    var toEmployeeId = $("#ToEmployeeId").val();//发送目标员工Id
    var toUserName = $("#to-emp").val();//发送目标账号
    var toEmail = $("#Email").val();//发送目标邮箱
    var title = $("#Title").val();//消息标题
    var extraMess = window.document.getElementById("extra-message").value;//消息额外内容
    var messType = $("input[name='messtype']:checked").val();//消息发送方式
    toUserName = toUserName.replace(/\s+/g, "");
    if (!toUserName) {
        $("#to-emp").focus();
        shakeHead("submit-mess");
        return;
    }
    if (title.replace(/\s+/g, "") === "") {
        $("#valid-title").text("消息标题不能为空");
        $("#Title").focus();
        shakeHead("submit-mess");
        return;
    } else {
        $("#valid-title").text("");
    }
    if (extraMess.replace(/\s+/g, "") === "") {
        $("#valid-extramess").text("消息内容不能为空");
        $("#ExtraMessage").focus();
        shakeHead("submit-mess");
        return;
    } else {
        $("#valid-extramess").text("");
    }
    $("#submit-mess").attr("disabled", true);
    $.ajax({
        url: "/PersonalInfo/SendMess",
        data: {
            "OaMess.ToEmployeeId": toEmployeeId,
            "OaMess.Title": title,
            "OaMess.ExtraMessage": extraMess,
            "Email": toEmail,
            "UserName": toUserName,
            "MessType": messType
        },
        type: "POST",
        success: function (data, textStatus, xhr) {
            var modal = new Modal("提交消息结果", "oa-alert-mess");
            if (data) {
                modal.alert(data);
            } else {
                modal.alert("请求服务器没有响应结果");
            }
            $("#submit-mess").attr("disabled", false);
        },
        error: function (xhr, textStatus, errorthrown) {
            var modal = new Modal("提交消息结果", "oa-alert-mess");
            modal.alert("提交发送消息出错：" + xhr.status + " " + textStatus + " " + errorthrown);
            $("#submit-mess").attr("disabled", false);
        },
        dataType: "json",
        async: true
    });
}

/**
* 消息页，跳转到指定页码
* @param pageIndex {Number} 页码
*/
function gotoPage(pageIndex) {
    $.ajax({
        url: "/PersonalInfo/GetOaMess",
        data: {
            "pageIndex": pageIndex,
        },
        type: "POST",
        success: function (data, textStatus, xhr) {
            console.log(data);
            if (typeof data === "object") {
                $("#messages form").next().text("");
                $("#messages form").empty();
                if (data.mess.length < 1) {
                    $("#messages form").append("<div>没有记录</div>");
                }
                data.mess.forEach(function (oamess, index) {
                    var $messhtml = $("<div>" +
                                "<span class=\"am-badge am-u-sm-2 am-u-md-1\"><input type=\"checkbox\" name=\"Id\" value=\"\"></span>" +
                                "<a class=\"oamess-row\" href=\"javascript:;\" title=\"点击查看\">" +
                                "<span class=\"am-badge am-u-sm-2 am-u-md-1\"><i class=\"am-icon-envelope\" title=\"未查看\"></i></span>" +
                                    "<span class=\"am-badge am-u-sm-3 am-u-md-2\">" +
                                        "<img src=\"/Content/images/oaui/default.jpg\" alt=\"发件人头像\" width=\"20\" height=\"20\" style=\"margin-right:5px\">" +
                                    "</span>" +
                                    "<span class=\"am-badge am-u-sm-5 am-u-md-3\">任务提交</span>" +
                                    "<span class=\"am-badge am-hide-sm-only am-u-md-3\">任务已经完成，请于2016-4-5前进行审核，并提交审核结果。谢谢！</span>" +
                                    "<span class=\"am-badge am-hide-sm-only am-u-md-2\">2016/4/2 10:36:41</span>" +
                                "</a>" +
                            "</div>");
                    $messhtml.find("span:eq(0)").children("input").val(oamess.Id);
                    var eq1span = $messhtml.find("span:eq(1)").children("i");
                    if (oamess.IsLookUp) {
                        eq1span.removeClass().addClass("am-icon-envelope-o");
                        eq1span.attr("title", "已查看");
                    }
                    $messhtml.find("span:eq(2)").children("img").attr("src", oamess.FromEmployee.HeadPicture).after(oamess.FromEmployee.RealName);
                    $messhtml.find("span:eq(3)").text(oamess.Title);
                    $messhtml.find("span:eq(4)").text(oamess.ExtraMessage);
                    oamess.SendDateTime = oamess.SendDateTime.replace(/(\/Date\()|(\)\/)/g, "");
                    oamess.SendDateTime = new Date(window.parseInt(oamess.SendDateTime));
                    var yyyy = oamess.SendDateTime.getFullYear();
                    var y = oamess.SendDateTime.getMonth() + 1;
                    var d = oamess.SendDateTime.getDate();
                    var h = oamess.SendDateTime.getHours();
                    var m = oamess.SendDateTime.getMinutes();
                    var s = oamess.SendDateTime.getSeconds();
                    $messhtml.find("span:eq(5)").text(yyyy + "/" + y + "/" + d + " " + h + ":" + m + ":" + s);
                    $("#messages form").append($messhtml);
                });
                $(".total-record").text(data.pager.Total);
                $(".index-page").text(data.pager.PageIndex);
                $(".all-page").text(data.pager.PageCount);
                $("#page-number").val(data.pager.PageIndex);
                if (data.pager.HasPrev) {
                    $("#previous-page").removeClass("am-disabled");
                } else {
                    $("#previous-page").addClass("am-disabled");
                }
                if (data.pager.HasNext) {
                    $("#next-page").removeClass("am-disabled");
                } else {
                    $("#next-page").addClass("am-disabled");
                }
                messLookUpEvent();
            } else if(data){
                $("#messages form").next().text("您的权限不足"+data);
            } else {
                $("#messages form").next().text("请求到没有数据");
            }
        },
        error: function (xhr, textStatus, errorthrown) {
            $("#messages form").next().text("请求页面数据出错："+xhr.status+"  "+textStatus+"  "+errorthrown);
        },
        dataType: "json",
        async: true
    });
}
//点击上一页
function perviousPage() {
    var nowPage = $(".index-page").text();
    nowPage = Number(nowPage);
    gotoPage(nowPage-1);
}
//点击下一页
function nextPage() {
    var nowPage = $(".index-page").text();
    nowPage = Number(nowPage);
    gotoPage(nowPage + 1);
}
//点击跳页
function jumpPage() {
    var pageNum = $("#page-number").val();
    var nowPage = $(".index-page").first().text();
    if ((/^\d+$/).test(pageNum)) {
        gotoPage(pageNum);
    } else {
        $("#page-number").val(nowPage);
    }
}