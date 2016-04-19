$(document).ready(function () {
    
    /* 实现文件上传 */
    var uploadFile = new UploadFile(".oaui-upload", "/AdminUiInfo/UploadSystemImg", false, {
        mime_types: [{
            title: '图片文件',
            extensions: 'gif,png,jpg,ico,jpeg'
        }],
        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
    });
    
    //每上传完一个图片就给UiImg表单绑定图片名准备保存记录
    var callbackFunc = function (responseObj) {
        var data = $.parseJSON(responseObj.response);
        if (data) {
            if (data.result) {
                $("#UiImg").val(data.fileName);
            } else {
                alert("文件已上传完成，但服务器拒绝保存。原因：" + data.reason);
            }
        }
    }
    //图片上传前预览
    var previewImageCallBack = function (src) {
        $(".oaui-upload").next("img").remove();
        $(".oaui-upload").after("<img style=\"margin:5px;height:150px\" src='"+src+"'/>");
    }
    uploadFile.fileDialog("browseFile", previewImageCallBack, callbackFunc);
    $("form").submit(function () {
        var imgName = $("#UiImg").val();
        if (!imgName&&!$("#uploadimg-tip").text()) {
            $("#uploadimg-tip").text("提示：您的图片未上传，如果确认不修改图片请再次提交");
            return false;
        } else {
            $("#uploadimg-tip").text("");
            return true;
        }
    });
});