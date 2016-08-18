var levelCaption;
var hiddenStatus = 0;
var saveChanges = false;
var deleteValue = 1;

$(document).ready(function () {

    $("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    $("#btnguest").css("background-color", "#FDEC0A")

    $("#btnguest").click(function (evt) {
        evt.preventDefault();
        DisplayGuest();
        deleteValue = 4;
    });

    $("#btnidentity").click(function (evt) {
        evt.preventDefault();
        Identification();
        deleteValue = 1;
    });

    $("#btnlicense").click(function (evt) {

        evt.preventDefault();
        DisplayLicence();
        deleteValue = 3;
    });

    $("#btnpassport").click(function (evt) {
        evt.preventDefault();
        DisplayPassport();
        deleteValue = 2;
    });


    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (saveChanges === true && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {

            //PageMethods.RedirectToShift(OnRedirectToShift_CallBack);
            //if ($("#hiddenFieldMemberId").val() == 1) {

            //    document.location.href = "/Content/GateMembers.aspx?Id=" + $("#hiddenFieldMemberId").val();

            //} else if ($("#hiddenFieldMemberId").val() == 2) {

            //    document.location.href = "/Content/GateMembers.aspx?Id=" + $("#hiddenFieldMemberId").val();

            //}
            document.location.href = "/Content/GateMembers.aspx?Id=" + $("#hiddenFieldMemberId").val();
        }

    });

})


function DisplayGuest() {
    $("#hiddenFieldType").attr("value", "4");
    getLocalizedText("healthCard");
    $("#PageTitleLbl2").text(levelCaption);
    $("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    $("#btnguest").css("background-color", "")
    $("#btnpassport").css("background-color", "")
    $("#btnidentity").prop("disabled", false);
    $("#btnlicense").prop("disabled", false);
    $("#btnguest").prop("disabled", true);
    $("#btnpassport").prop("disabled", false);
    $('.perscenter').hide();
    $('.perscenterpass').hide();
    $('.perscenterfuh').hide();
    $('.perscenterges').show();
    getLocalizedText("saveHealthInsuranceData");
    $("#btnEntSave").val(levelCaption);
    getLocalizedText("healthCardData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("newHealthCard");
    $("#btnNew").val(levelCaption);

    $("#btnNew").css({ width: "149px" });
    $("#btnEntSave").css({ width: "183px" });
    $("#btnCancelDel").css({ width: "171px" });
}

function DisplayLicence() {
    $("#hiddenFieldType").attr("value", "3");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    $("#btnguest").css("background-color", "#FDEC0A")
    $("#btnlicense").css("background-color", "")
    $("#btnidentity").prop("disabled", false);
    $("#btnlicense").prop("disabled", true);
    $("#btnguest").prop("disabled", false);
    $("#btnpassport").prop("disabled", false);
    $('.perscenter').hide();
    $('.perscenterpass').hide();
    $('.perscenterfuh').show();
    $('.perscenterges').hide();
    getLocalizedText("saveLicenseData");
    $("#btnEntSave").val(levelCaption);
    getLocalizedText("drivingLicenseData");
    $("#btnCancelDel").val(levelCaption);
    hiddenStatus = 1;
    getLocalizedText("driverLicense");
    $("#PageTitleLbl2").text(levelCaption);
    getLocalizedText("newDriversLincence");
    $("#btnNew").val(levelCaption);

    $("#btnNew").css({ width: "122px" });
    $("#btnEntSave").css({ width: "155px" });
    $("#btnCancelDel").css({ width: "146px" });
}

function DisplayPassport() {
    $("#hiddenFieldType").attr("value", "2");
    $("#btnpassport").css("background-color", "");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    $("#btnguest").css("background-color", "#FDEC0A")
    $("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").prop("disabled", false);
    $("#btnlicense").prop("disabled", false);
    $("#btnguest").prop("disabled", false);
    $("#btnpassport").prop("disabled", true);
    //$('#PageTitleLbl2').text("Reisepass");
    getLocalizedText("passport");
    $("#PageTitleLbl2").text(levelCaption);
    $('.perscenter').hide();
    $('.perscenterpass').show();
    $('.perscenterfuh').hide();
    $('.perscenterges').hide();
    getLocalizedText("savePassportData");
    $("#btnEntSave").val(levelCaption);
    getLocalizedText("passportDetailsData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("newPassPort");
    $("#btnNew").val(levelCaption);
    hiddenStatus = 1;

    $("#btnNew").css({ width: "116px" });
    $("#btnEntSave").css({ width: "140px" });
    $("#btnCancelDel").css({ width: "129px" });
}

function Identification() {
    $("#hiddenFieldType").attr("value", "1");
    getLocalizedText("identitycard");
    $("#PageTitleLbl2").text(levelCaption);
    $("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").css("background-color", "");
    $("#btnguest").css("background-color", "#FDEC0A")
    $("#btnpassport").css("background-color", "")
    $("#btnidentity").prop("disabled", true);
    $("#btnlicense").prop("disabled", false);
    $("#btnguest").prop("disabled", false);
    $("#btnpassport").prop("disabled", false);
    $('.perscenter').show();
    $('.perscenterpass').hide();
    $('.perscenterfuh').hide();
    $('.perscenterges').hide();
    getLocalizedText("savePassData");
    $("#btnEntSave").val(levelCaption);
    getLocalizedText("passportData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("newPassData");
    $("#btnNew").val(levelCaption);

    $("#btnNew").css({ width: "151px" });
    $("#btnEntSave").css({ width: "177px" });
    $("#btnCancelDel").css({ width: "169px" });
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "GateMembersDocumente.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}


function OnRedirectToShift_CallBack(url) {
    if (url.trim() === "") {
        window.location.href = "/Content/GateMembers.aspx";
    }
    else {
        window.location.href = url;
    }
}