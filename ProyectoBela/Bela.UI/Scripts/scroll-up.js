$(document).ready(function () {

    $('#sc').click(function () {
        $('body, html').animate({
            scrollTop: '0px'
        }, 300);
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 0) {
            $('#sc').slideDown(300);
        } else {
            $('#sc').slideUp(300);
        }
    });

});