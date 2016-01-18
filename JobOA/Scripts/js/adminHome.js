$(function () {
    $(".userstate li").children(".am-btn").hide();
    $(".userstate li").hover(
        function () {
            $(this).children(".am-btn").show();
        },
        function () {
            $(this).children(".am-btn").hide();
        }
        );
});