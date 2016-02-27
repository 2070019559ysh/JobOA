$(document).ready(function () {
    var uploadFile = new UploadFile(".oa-upload", "/PersonalInfo/UploadImg", true, {
        mime_types: [{
            title: 'image files',
            extensions: 'gif,png,jpg,ico'
        }],
        max_file_size: '4096kb',//不能大于4mb
        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
    });
    uploadFile.fileDialog();
});