$(function () {
    $('#regist').on('click', function () {
        $.ajax({
            url: '/Login/Login',
            method: 'post',
            type: 'json',
            data: $('form').serialize(),
            success: function (data) {
                if (data.IsSuccess)
                    alert('ok');
            }
        });
    });
});
