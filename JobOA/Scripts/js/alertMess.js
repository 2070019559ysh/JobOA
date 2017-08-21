$(function () {
    var mess = $("#mess").val();
    if (mess) {
        var modal = new Modal();
        var confirmFun = null;
        var pathName = window.location.pathname.toLowerCase();
        var isIndex = pathName.indexOf("index") > -1;
        if (!isIndex&&mess.search(/(success)|(成功)/) > -1) {
            confirmFun = function () {
                var pathName = window.location.pathname;
                var controller=pathName.substring(0,pathName.indexOf("/",1));
                window.location.href = controller+"/Index";
            }
        }
        modal.alert(mess, confirmFun);
        $("#mess").val("");
    }
});