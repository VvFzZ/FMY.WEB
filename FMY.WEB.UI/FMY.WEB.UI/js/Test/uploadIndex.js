layui.use('upload', function () {
    var upload = layui.upload;

    //执行实例
    var uploadInst = upload.render({
        elem: '#test1' //绑定元素    
        , url: '/upload/UpLoad/' //上传接口
        , accept: 'images'
        , exts: 'jpg'//jpg|png|gif|bmp|jpeg
        //, acceptMime: 'image/jpg'//'image/*' 2.26新增
        , auto: false
        , bindAction: '#upload-btn'
        , done: function (res) {
            layer.msg(res.IsSuccess);
            //上传完毕回调
        }
        , error: function () {
            //请求异常回调
        }
    });
});