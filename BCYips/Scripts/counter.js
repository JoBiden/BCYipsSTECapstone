$(document).ready(function () {

    $('textarea[maxlength]').keyup(function () {
        var limit = parseInt($(this).attr('maxlength'));
        var text = $(this).val();
        var chars = text.length;
        if (chars > limit) {
            var newText = text.substr(0, limit);
            $(this).val(newText);
        }
        $('#char-count').text(limit - $(this).val().length);
    });

});