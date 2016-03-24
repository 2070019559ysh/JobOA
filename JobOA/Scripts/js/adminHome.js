$(function () {
    //控制员工在线信息右侧的按钮的显示和隐藏
    function btnHover() {
        $(".userstate li").children(".am-btn").hide();
        $(".userstate li").hover(
            function () {
                $(this).children(".am-btn").show();
            },
            function () {
                $(this).children(".am-btn").hide();
            }
            );
    }
    btnHover();
    //记录请求到的在线和离线的员工信息
    var onlineEmp = [],offlineEmp=[];
    //请求员工在线信息
    function requestEmp() {
        $.ajax({
            url: "/AdminHome/GetOnlineState",
            type: "POST",
            beforeSend: function (xhr) {
                $("#online-user").html("<li><i class=\"am-icon-spinner am-icon-pulse\"></i>加载中...</li>");
                $("#offline-user").html("<li><i class=\"am-icon-spinner am-icon-pulse\"></i>加载中...</li>");
            },
            success: function (data) {
                onlineEmp = data.online;
                offlineEmp = data.offline;
                $("#online-user").empty();
                onlineEmp.forEach(function (emp, index) {
                    if (emp.Introduction === null) {
                        emp.Introduction = "";
                    }
                    var html = '<li class="am-text-truncate"><a href="/PersonalInfo/Inbox/'+emp.Id+'" class="am-btn am-btn-danger">发送消息</a><img src="' + emp.HeadPicture + '" height="20" width="20" alt="头像" /><span>'+emp.UserName+'</span><span>' + emp.RealName + '</span><span title="' + emp.Introduction + '">' + emp.Introduction + '</span></li>';
                    $("#online-user").append(html);
                });
                $("#offline-user").empty();
                offlineEmp.forEach(function (emp, index) {
                    if (emp.Introduction === null) {
                        emp.Introduction = "";
                    }
                    var html = '<li class="am-text-truncate"><a href="/PersonalInfo/Inbox/'+emp.Id+'" class="am-btn am-btn-default">发送消息</a><img src="' + emp.HeadPicture + '" height="20" width="20" alt="头像" /><span>' + emp.UserName + '</span><span>' + emp.RealName + '</span><span title="' + emp.Introduction + '">' + emp.Introduction + '</span></li>';
                    $("#offline-user").append(html);
                });
                btnHover();
            },
            complete: function (xhr, textStatus) {
                if (xhr.status !== 200) {
                    $("#online-user").html("<li class=\"am-text-danger\">对不起，加载失败</li>");
                    $("#offline-user").html("<li class=\"am-text-danger\">对不起，加载失败</li>");
                }
            },
            dataType: "json"
        });
    }
    requestEmp();
    //点击刷新员工在线状态
    $("#refresh-emp").click(requestEmp);

    
    //记录上一次查询值
    var offlineSearchVal, onlineSearchVal;
    //根据员工名模糊查找在线员工
    function searchOnline() {
        $("#online-user").empty();
        var empName = $("#online-emp").val();
        var empNameChar = empName.split("");
        onlineEmp.forEach(function (emp, index) {
            var isContain = false;
            if (empName) {
                empNameChar.forEach(function (ch, index) {
                    if (emp.RealName.search(ch) > -1) {
                        isContain = true;
                        return false;
                    }
                });
            } else {
                isContain = true;
            }
            if (isContain) {
                var html = '<li class="am-text-truncate"><a href="/PersonalInfo/Inbox/'+emp.Id+'" class="am-btn am-btn-danger">发送消息</a><img src="' + emp.HeadPicture + '" height="20" width="20" alt="头像" /><span>' + emp.UserName + '</span><span>' + emp.RealName + '</span><span title="' + emp.Introduction + '">' + emp.Introduction + '</span></li>';
                $("#online-user").append(html);
            }
        });
        btnHover();
    }
    //点击查询离线员工
    $("#search-online").click(searchOnline);
    //按键查询离线员工
    $("#online-emp").keyup(function (event) {
        var e = event || window.event;
        var empName = $("#online-emp").val();
        if (e && e.keyCode === 13 && empName !== onlineSearchVal) {
            onlineSearchVal = empName;
            searchOnline();
        }
    });

    //根据员工名模糊查找离线员工
    function searchOffline() {
        $("#offline-user").empty();
        var empName = $("#offline-emp").val();
        var empNameChar = empName.split("");
        offlineEmp.forEach(function (emp, index) {
            var isContain = false;
            if (empName) {
                empNameChar.forEach(function (ch, index) {
                    if (emp.RealName.search(ch) > -1) {
                        isContain = true;
                        return false;
                    }
                });
            } else {
                isContain = true;
            }
            if (isContain) {
                var html = '<li class="am-text-truncate"><a href="/PersonalInfo/Inbox/'+emp.Id+'" class="am-btn am-btn-default">发送消息</a><img src="' + emp.HeadPicture + '" height="20" width="20" alt="头像" /><span>' + emp.UserName + '</span><span>' + emp.RealName + '</span><span title="' + emp.Introduction + '">' + emp.Introduction + '</span></li>';
                $("#offline-user").append(html);
            }
        });
        btnHover();
    }
    //点击查询离线员工
    $("#search-offline").click(searchOffline);
    //按键查询离线员工
    $("#offline-emp").keyup(function (event) {
        var e = event || window.event;
        var empName = $("#offline-emp").val();
        if (e && e.keyCode === 13&&empName!==offlineSearchVal) {
            offlineSearchVal = empName;
            searchOffline();
        }
    });
});