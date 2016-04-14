$(document).ready(function () {
    
    /* 实现文件上传 */
    var uploadFile = new UploadFile(".oaui-upload", "/AdminUiInfo/UploadSystemImg", false, {
        mime_types: [{
            title: '图片文件',
            extensions: 'gif,png,jpg,ico,jpeg'
        }],
        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
    });
    
    //每上传完一个图片就重新请求图片进行显示出来
    var callbackFunc = function () {
    }
    var previewImageCallBack = function (src) {
        $(".oaui-upload").after("<img src='"+src+"' height='50' width='50'/>");
    }
    uploadFile.fileDialog(previewImageCallBack, callbackFunc);
});