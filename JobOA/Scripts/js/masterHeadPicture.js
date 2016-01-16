$(function () {
    $.ajax({
        url: "/Account/EmployeeMess",
        type: "POST",
        complete: function (xhr) {
            if (xhr.status !== 200) {
                $("#head-picture").after(xhr.status);
            }
        },
        success: function (data) {
            $("#head-picture").attr("src", data.HeadPicture);
            $("#head-picture").after(data.RealName);
        },
        async: true,
        dataType:"json"
    });
});