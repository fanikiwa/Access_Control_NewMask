$(function () {
    //$(".secOption>input").unbind("click");
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    $(".secOption>input").bind("click", function () {
        /*$(".secOption>input").attr("checked", "checked");*/
        $(".secOption>input").removeAttr("checked"); //Remove any checked checkboxes
        $(this).prop("checked", true); //Check the clicked item

        $("#btnSave").click(function (event) {
            var languageSelection = $(".secOption>input:checked").attr("id");

            try {
                setLanguage(languageSelection)
            } catch (e) {
                //Error
            }
        });
    });
});
function setLanguage(_languageSelection) {
    switch (_languageSelection) {
        case "ListSprache_0":       //German
            _aspxSetCookie("AC_Culture", "de-DE", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
            break;

        case "ListSprache_1":       //English
            _aspxSetCookie("AC_Culture", "en-GB", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
            break;

        default:
            break;
    }
}
//$(document).ready(function () {
//    $(".InfoHeaderFloatRight").show();
//    $(".InfoHeaderFloatRightnew").hide();
//})