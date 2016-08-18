$(function (ev) {
    $("#btnyes").click(function (ev) {
        setTimeout(function () {
            ASPxClientUtils.DeleteCookie("ZUT_AUTH");
        }, 2);
    });
});

