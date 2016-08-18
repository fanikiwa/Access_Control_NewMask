var levelCaption;
var deleteValue = 1;
var hiddenStatus = 0;
var saveChanges = false;

$(function () {
    //$('#PageTitleLbl2').text("Personalausweis");
    getLocalizedText("identitycard");
    $("#PageTitleLbl2").text(levelCaption);
    $("#btnlicense").css("background-color", "#24B59E");
    $("#btnidentity").css("background-color", "rgba(174, 202, 240, 1)");
    $("#btnguest").css("background-color", "#FDEC0A")
    $("#btnpassport").click(function (evt) {
        evt.preventDefault();
        DisplayPassport();
        deleteValue = 2;
    });
    //löschen
    getLocalizedText("passportData");
    $("#btnCancelDel").val(levelCaption);
    $("#btnlicense").click(function (evt) {
        evt.preventDefault();
        DisplayLicence();
        deleteValue = 3;
    });

    $("#btnidentity").click(function (evt) {
        evt.preventDefault();
        Identification();
        deleteValue = 1;
    });

    $("#btnguest").click(function (evt) {
        evt.preventDefault();
        DisplayGuest();
        deleteValue = 4;
    });

    $('.ListenForChange').on("change", function (e) {
        saveChanges = true;
        $("#hiddenFieldSaveChanges").attr("value", "1");
        e.preventDefault();
        //console.log(this.id);
    });

    $("#btnBack").bind("click", function (evt) {
        evt.preventDefault();
        var saveChangesState = $("#hiddenFieldSaveChanges").attr("value");

        if (saveChangesState === "1" && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {
            setTimeout(function (ev) {
                var rediretString = "Personal.aspx?0F88=" + $("#hiddenFieldPersonalNumber").attr("value");
                window.location.href = rediretString;
            }, 1000);
        }
    });

    $("#hiddenFieldSaveChanges").attr("value", "0");

    $("#btnNew").click(function (evt) {
        evt.preventDefault();
        if (deleteValue === 1) {
            clearPersonalControls();
        } else if (deleteValue === 2) {
            ClearFunctionPassPort();
        }
        else if (deleteValue === 3) {
            ClearDriversLicenseControls();
        }
        else if (deleteValue === 4) {
            ClearHealthCardDetails();
        }
    });

    $("#btnCancelDel").click(function (evt) {
        evt.preventDefault();
        var persNr = parseInt($("#hiddenFieldPersonalNumber").val());
        if (persNr > 0) {
            ConfirmDelete();
        }
    });
});

function redirectPageToOrigin(response) {
    document.location.href = response;
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
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

    $("#btnNew").css({ width: "116px" });
    $("#btnEntSave").css({ width: "140px" });
    $("#btnCancelDel").css({ width: "129px" });
    hiddenStatus = 1;
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
    getLocalizedText("savePassDataNew");
    $("#btnEntSave").val(levelCaption);
    getLocalizedText("passportData");
    $("#btnCancelDel").val(levelCaption);
    getLocalizedText("newPassData");
    $("#btnNew").val(levelCaption);

    $("#btnNew").css({ width: "151px" });
    $("#btnEntSave").css({ width: "177px" });
    $("#btnCancelDel").css({ width: "174px" });
}

//function BackButtonConfirm() {
//    //getLocalizedText("saveChangesConfirmation");
//    var message = "Änderungen speichern";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/infoblue2.png" alt="Stop" class="stopPic" height="50" width="50" align="middle"> <br/> <br/> <div id="dialogText">' + message + '</div> <br/> <button id="btnSave"  onclick="saveDocuments()"></button> <button id="btnNotSave"  onclick="cancelSave()"></button></div></div></div>';
//    document.getElementById('ImportantDialogBox').innerHTML = box_content;
//    //getLocalizedText("yes");
//    $('#btnSave').text('speichern');
//    $('#btnNotSave').text('nicht speichern');
//}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="cancelSaveReset(); return true;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="saveDocuments(); return true;"></button><button id="btnNo"  onclick="cancelSave(); return true;"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
    //getLocalizedText("cancel");
    //$('#btnCancel').text(levelCaption);
}

function cancelSaveReset() {
    document.getElementById('ImportantDialogBox').innerHTML = "";
}

function cancelSave() {
    document.getElementById('ImportantDialogBox').innerHTML = "";

    setTimeout(function (evt) {
        var rediretString = "Personal.aspx?0F88=" + $("#hiddenFieldPersonalNumber").attr("value");
        window.location.href = rediretString;

    }, 1000);
}

function saveDocuments() {
    document.getElementById('ImportantDialogBox').innerHTML = "";
    $("#hiddenFieldRedirectAfterSave").attr("value", 1);
    $("[id$=btnEntSave]").click();
    //setTimeout(function (ev) {
    //    var rediretString = "Personal.aspx?0F88=" + $("#hiddenFieldPersonalNumber").attr("value");
    //    window.location.href = rediretString;
    //}, 1000);
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "PersonalDocumente.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
function clearPersonalControls() {
    $("#txtIDCreatedIn").val("");
    $("#txtIDNumber").val("");
    $("#txtIDPlaceofBirth").val("");
    $("#txtIDAdditionalNumber").val("");
    $("#txtIDEyeColor").val("");
    $("#txtIDSize").val("");
    $("#txtIDAddress").val("");
    $("#txtIDIssuingAuthority").val("");
    $("#txtIDMemo").val("");
    dtIDExpiryDate.SetDate(moment().toDate());
    dtIDIssuedOn.SetDate(moment().toDate());

    $("#txtIDCreatedIn").focus();
}
function ClearFunctionPassPort() {
    $("#txtPPCreatedIn").val("");
    $("#txtPPNumber").val("");
    $("#txtPPGender").val("");
    $("#txtPPPlaceofBirth").val("");
    $("#txtPPEyeColor").val("");
    $("#txtPPSize").val("");
    $("#txtPPIssuingAuthority").val("");
    $("#txtPPMemo").val("");

    dtPPIssuedOn.SetDate(moment().toDate());
    dtPPExpiryDate.SetDate(moment().toDate());

    $("#txtPPCreatedIn").focus();
}
function ClearDriversLicenseControls() {
    $("#txtDLCreatedIn").val("");
    $("#txtDLNumber").val("");
    $("#txtDLPlaceofBirth").val("");
    $("#txtDLClass").val("");
    $("#txtDLIssuingAuthority").val("");
    $("#txtDLMemo").val("");

    dtDLIssuedOn.SetDate(moment().toDate());

    $("#txtDLCreatedIn").focus();
}
function ClearHealthCardDetails() {
    $("#txtHIBoxOffice").val("");
    $("#txtHICreatedIn").val("");
    $("#txtHIPersonalNumber").val("");
    $("#txtHISecurityNumber").val("");
    $("#txtHICardNumber").val("");
    $("#txtHIMemo").val("");

    dtHIExpirationDate.SetDate(moment().toDate());

    $("#txtHIBoxOffice").focus();
}
function DeleteDocument(value, persNr) {
    switch (value) {
        case 1:
            PageMethods.DeleteIdentityCard(persNr, OnDeleteIdentityCard_CallBack);
            break;
        case 2:
            PageMethods.DeletePassport(persNr, OnDeletePassport_CallBack);
            break;
        case 3:
            PageMethods.DeleteLicence(persNr, OnDeleteLicence_CallBack)
            break;
        case 4:
            PageMethods.DeleteHealthCard(persNr, OnDeleteHealthCard_CallBack);
            break;
    }
}
function OnDeleteIdentityCard_CallBack() {

    $("#txtIDCreatedIn").val("");
    $("#txtIDNumber").val("");
    $("#txtIDPlaceofBirth").val("");
    $("#txtIDAdditionalNumber").val("");
    $("#txtIDEyeColor").val("");
    $("#txtIDSize").val("");
    $("#txtIDAddress").val("");
    $("#txtIDIssuingAuthority").val("");
    $("#txtIDMemo").val("");
    dtIDIssuedOn.SetDate(null);
    dtIDExpiryDate.SetDate(null);
}
function OnDeletePassport_CallBack() {

    $("#txtPPCreatedIn").val("");
    $("#txtPPNumber").val("");
    $("#txtPPGender").val("");
    $("#txtPPPlaceofBirth").val("");
    $("#txtPPEyeColor").val("");
    $("#txtPPSize").val("");
    $("#txtPPIssuingAuthority").val("");
    $("#txtPPMemo").val("");
    dtPPIssuedOn.SetDate(null);
    dtPPExpiryDate.SetDate(null);

}
function OnDeleteLicence_CallBack() {

    $("#txtDLCreatedIn").val("");
    $("#txtDLNumber").val("");
    $("#txtDLPlaceofBirth").val("");
    $("#txtDLClass").val("");
    $("#txtDLIssuingAuthority").val("");
    $("#txtDLMemo").val("");

    dtDLIssuedOn.SetDate(null);
}
function OnDeleteHealthCard_CallBack() {

    $("#txtHIBoxOffice").val("");
    $("#txtHICreatedIn").val("");
    $("#txtHIPersonalNumber").val("");
    $("#txtHISecurityNumber").val("");
    $("#txtHICardNumber").val("");
    $("#txtHIMemo").val("");
    dtHIExpirationDate.SetDate(null);
}
function ConfirmDelete() {
    var message = "Sind Sie sicher, dass Sie löschen möchten";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="HideDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  margin-right: 0px;"  onclick="Delete_Confirmed()"></button><button id="btnCancel"  onclick="HideDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    if (deleteValue == 1) {
        getLocalizedText("permitIDCardDeletion");
        $('#btnOk').text(levelCaption);
        getLocalizedText("cancelIDDeletion");
        $('#btnCancel').text(levelCaption);
        $('#btnCancel').css({

            'width': '204px',
        });
        $('#btnOk').css({
            'margin-left': '21%',
            'width': '160px',
        });
    }
    if (deleteValue == 2) {
        getLocalizedText("permmitPassprotDeletion");
        $('#btnOk').text(levelCaption);
        getLocalizedText("cancelPassportDeletion");
        $('#btnCancel').text(levelCaption);

        $('#btnCancel').css({
            'width': '164px',
        });
        $('#btnOk').css({
            'margin-left': '38%',
            'width': '123px',
        });
    }
    if (deleteValue == 3) {
        getLocalizedText("permitDriverLDeletion");
        $('#btnOk').text(levelCaption);
        getLocalizedText("cancelDLDeletion");
        $('#btnCancel').text(levelCaption);

        $('#btnCancel').css({
            'width': '185px',
        });
        $('#btnOk').css({
            'margin-left': '33%',
            'width': '133px',
        });
    }
    if (deleteValue == 4) {
        getLocalizedText("permitHealthCardDeletion");
        $('#btnOk').text(levelCaption);
        getLocalizedText("cancelHealthCardDeletion");
        $('#btnCancel').text(levelCaption);

        $('#btnCancel').css({
            'width': '204px',
        });
        $('#btnOk').css({
            'margin-left': '23%',
            'width': '160px',
        });
    }
}
function CancelOnBackButton() {
    HideDialog();
}
function HideDialog() {
    document.getElementById('ImportantDialogBox').innerHTML = "";
}
function Delete_Confirmed() {
    HideDialog();
    var persNr = parseInt($("#hiddenFieldPersonalNumber").val());
    if (persNr > 0) {
        DeleteDocument(deleteValue, persNr);
    }
}