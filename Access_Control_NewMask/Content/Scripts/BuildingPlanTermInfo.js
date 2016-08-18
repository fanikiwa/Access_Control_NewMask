var levelCaption = "";
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "BuildingPlanTermInfo.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
//$(function () {
//    getLocalizedText("terminalInfo")
//    $('#PageTitleLbl2').text(levelCaption);
//});

function showProfilesInfo(s, e) {
    var rownum = e.visibleIndex;
    var buttonID = e.buttonID;
    if (buttonID == "accessProfileInfo" || "switchingProfileInfo") {

        $.ajax({
            type: "POST",
            async: false,
            url: "BuildingPlanTermInfo.aspx/PassPageOrigin",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                if (buttonID == "accessProfileInfo") {
                    window.location.href = "BuildingPlanTermInfoAccessProfile.aspx";
                }
                else if (buttonID == "switchingProfileInfo") {
                    window.location.href = "BuildingPlanTermInfoSwitchProfile.aspx";
                }
            }
        });
    }
    else {

    }
}