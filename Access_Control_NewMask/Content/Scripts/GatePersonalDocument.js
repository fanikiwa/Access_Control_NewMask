var hiddenStatus = 0;
var levelCaption;

$(function () {
    $("#btnDocument").click(function (evt) {
        evt.preventDefault();
        window.location.href = "/Content/GatePersonalDocument.aspx";
    });

    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        // document.location.href = "/Content/GatePersonal.aspx";         

        setTimeout(function (ev) {
            //  var persNr = $("#hiddenFieldPersonalNumber").val();
            if ($("#hiddenFieldPersonalNumber").val() != '') {
                var rediretString = "GatePersonal.aspx?0F88=" + $("#hiddenFieldPersonalNumber").attr("value");
                window.location.href = rediretString;
            }
            else {
                window.location.href = "/Content/GatePersonal.aspx";

            }
        }, 1000);
    });

    getLocalizedText("identitycard");
    $("#pagenamelbl").text(levelCaption);
    //$("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    //$("#btnguest").css("background-color", "#FDEC0A")

    $("#btnpassport").click(function (evt) {
        evt.preventDefault();
        DisplayPassport();

    });

    $("#btnlicense").click(function (evt) {

        evt.preventDefault();
        DisplayLicence();
    });

    $("#btnIndentification").click(function (evt) {
        evt.preventDefault();
        Identification();
    });

    $("#btnguest").click(function (evt) {
        evt.preventDefault();
        DisplayGuest();
    });
})

function DisplayGuest() {
    $("#hiddenFieldType").attr("value", "4");
    getLocalizedText("healthCard");
    $("#pagenamelbl").text(levelCaption);
    //$("#btnlicense").css("background-color", "#24B59E");
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
    getLocalizedText("healthCardData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("saveHealthInsuranceData");
    $("#btnEntSave").val(levelCaption);
}

function DisplayLicence() {
    $("#hiddenFieldType").attr("value", "3");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    //$("#btnguest").css("background-color", "#FDEC0A")
    $("#btnlicense").css("background-color", "")
    $("#btnidentity").prop("disabled", false);
    $("#btnlicense").prop("disabled", true);
    $("#btnguest").prop("disabled", false);
    $("#btnpassport").prop("disabled", false);
    $('.perscenter').hide();
    $('.perscenterpass').hide();
    $('.perscenterfuh').show();
    $('.perscenterges').hide();
    getLocalizedText("drivingLicenseData");
    $("#btnCancelDel").val(levelCaption);
    hiddenStatus = 1;
    getLocalizedText("driverLicense");
    $("#pagenamelbl").text(levelCaption);
    getLocalizedText("saveLicenseData");
    $("#btnEntSave").val(levelCaption);
}

function DisplayPassport() {
    $("#hiddenFieldType").attr("value", "2");
    $("#btnpassport").css("background-color", "");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    //$("#btnguest").css("background-color", "#FDEC0A")
    //$("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").prop("disabled", false);
    $("#btnlicense").prop("disabled", false);
    $("#btnguest").prop("disabled", false);
    $("#btnpassport").prop("disabled", true);
    //$('#pagenamelbl').text("Reisepass");
    getLocalizedText("passport");
    $("#pagenamelbl").text(levelCaption);
    $('.perscenter').hide();
    $('.perscenterpass').show();
    $('.perscenterfuh').hide();
    $('.perscenterges').hide();
    getLocalizedText("passportDetailsData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("savePassportData");
    $("#btnEntSave").val(levelCaption);
    hiddenStatus = 1;
}

function Identification() {
    $("#hiddenFieldType").attr("value", "1");
    getLocalizedText("identitycard");
    $("#pagenamelbl").text(levelCaption);
    //$("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").css("background-color", "");
    //$("#btnguest").css("background-color", "#FDEC0A")
    $("#btnpassport").css("background-color", "")
    $("#btnidentity").prop("disabled", true);
    $("#btnlicense").prop("disabled", false);
    $("#btnguest").prop("disabled", false);
    $("#btnpassport").prop("disabled", false);
    $('.perscenter').show();
    $('.perscenterpass').hide();
    $('.perscenterfuh').hide();
    $('.perscenterges').hide();
    getLocalizedText("passportData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("savePassDataNew");
    $("#btnEntSave").val(levelCaption);
}

function getLocalizedText(key) {
    var data = { key: key };
    $.ajax({
        type: "POST",
        async: false,
        url: "GatePersonalDocument.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}