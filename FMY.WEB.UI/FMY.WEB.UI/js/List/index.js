$(function () {
    $(function () {
        $('.logout').on('click', function () {
            $.ajax({
                url: '/Login/Logout',
                method: 'post',
                type: 'json',
                //data: $('form').serialize(),
                success: function (data) {
                    if (data.IsSuccess)
                        alert('ok');
                }
            });
        });
    });

});