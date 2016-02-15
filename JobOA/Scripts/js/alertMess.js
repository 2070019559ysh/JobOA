$(function () {
    var mess = $("#mess").val();
    if (mess) {
        var modal = new Modal();
        var confirmFun = function () {
            window.location.href = "Index";
        }
        modal.alert(mess, confirmFun);
        $("#mess").val("");
    }
});