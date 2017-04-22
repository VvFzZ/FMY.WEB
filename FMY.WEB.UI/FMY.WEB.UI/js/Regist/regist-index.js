$(function () {
    
    jQuery.validator.addMethod("username", function (value, element) {
        var length = value.length;
        var mobile = /^[A-Za-z0-9_\u554A-\u9C52]+$/;//匹配只包含汉字、数字、字母、下划线；    
        return mobile.test(value);
    }, "手机号码格式错误");
    jQuery.validator.addMethod("mobile", function (value, element) {
        var length = value.length;
        var mobile = /^(1[34578]\d{9})$/;
        return mobile.test(value);
    }, "手机号码格式错误");
    $("#regist-form").validate({
        rules: {
            debug: true,
            Name: {
                required: true,
                username: true,
                rangelength: [2, 10]
            },
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                rangelength: [5, 20]
            },
            InsurePassword: {
                required: true,
                equalTo: "#Password"
            }
        },
        messages: {
            Name: {
                required: "请您输入用户名",
                username: "请您输入汉字、数字、字母、下划线",
                rangelength: "请您输入2-10个汉字"
            },
            Email: {
                required: "请您输入正确的邮箱地址",
                email: "请您输入正确的邮箱地址"
            },
            Password: {
                required: "请您输入密码",
                rangelength: "密码长度须为5-20个字符"
            },
            InsurePassword: {
                required: "请您确认密码",
                equalTo: "您两次输入的密码不同"
            }
        },
        submitHandler: function (form) {
            $.post('/Regist/Regist/', $('#regist-form').serialize(), function (data) {
                if (data.IsSuccess) {
                    $('.err_span').text('我们已经将激活邮件发送至您的邮箱，您激活该帐号后才能正常使用，感谢您的注册!');;
                } else {
                    $('.err_span').text(data.Data);
                }
            });
        }

    });

});
