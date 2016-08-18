var levelCaption;
var hiddenStatus = 0;
var saveChanges = false;
var deleteValue = 1;
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
    $("#btnNew").css({ width: "151px" });
    $("#btnEntSave").css({ width: "177px" });
    $("#btnCancelDel").css({ width: "169px" });
    $("#btnlicense").click(function (evt) {

        evt.preventDefault();
        DisplayLicence();
        deleteValue = 3;
    });
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (saveChanges === true && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {
            document.location.href = "/Content/MembersInactive.aspx?Id=" + $("#hiddenFieldMemberId").val();
        }

    });
    $("#btnidentity").click(function (evt) {
        evt.preventDefault();
        Identification();
        deleteValue = 1;
    });

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

    $("#btnguest").click(function (evt) {
        evt.preventDefault();
        DisplayGuest();
        deleteValue = 4;
    });
    $("#btnEntSave").click(function (evt) {
        evt.preventDefault();
        var memberId = parseInt($("#hiddenFieldMemberId").val());
        if (memberId > 0) {
            SaveDocumentDetails();
        }

    });
    $("#btnCancelDel").click(function (evt) {
        evt.preventDefault();
        var memberId = parseInt($("#hiddenFieldMemberId").val());
        if (memberId > 0) {
            ConfirmDelete();
        }

    });

    $("input, select").change(function () {
        saveChanges = true;
    });
    $('#txtIDMemo').change(function () { saveChanges = true; });
    $('#txtIDAddress').change(function () { saveChanges = true; });
    $('#txtPPMemo').change(function () { saveChanges = true; });
    $('#txtDLMemo').change(function () { saveChanges = true; });
    $('#txtHIMemo').change(function () { saveChanges = true; });

    $('#txtIDPlaceofBirth').change(function () { SetPlaceOfBirthText($("#txtIDPlaceofBirth").val()); });
    $('#txtPPPlaceofBirth').change(function () { SetPlaceOfBirthText($("#txtPPPlaceofBirth").val()); });
    $('#txtDLPlaceofBirth').change(function () { SetPlaceOfBirthText($("#txtDLPlaceofBirth").val()); });

    $('#txtMemberHeight').change(function () { setPersonHeight($("#txtMemberHeight").val()); });
    $('#txtPPSize').change(function () { setPersonHeight($("#txtPPSize").val()); });

    $('#txtIDEyeColor').change(function () { setEyeColor($("#txtIDEyeColor").val()); });
    $('#txtPPEyeColor').change(function () { setEyeColor($("#txtPPEyeColor").val()); });

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

function BackButtonConfirm() {

    //getLocalizedText("saveChangesConfirmation");
    var message = "Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/infoblue2.png" alt="Stop" class="stopPic" height="50" width="50" align="middle"> <br/> <br/> <div id="dialogText">' + message + '</div> <br/> <button id="btnSave"  onclick="saveDocuments()"></button> <button id="btnNotSave"  onclick="cancelSave()"></button></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    //getLocalizedText("yes");
    $('#btnSave').text('speichern');
    $('#btnNotSave').text('nicht speichern');

}

function cancelSave() {
    document.getElementById('ImportantDialogBox').innerHTML = "";



    setTimeout(function (ev) {
        var rediretString = "MembersInactive.aspx?0F88=" + $("#hiddenFieldPersonalNumber").attr("value");
        window.location.href = rediretString;
    }, 1);
}

function saveDocuments() {
    document.getElementById('ImportantDialogBox').innerHTML = "";
    $("[id$=btnEntSave]").click();
    setTimeout(function (ev) {
        var rediretString = "MembersInactive.aspx?0F88=" + $("#hiddenFieldPersonalNumber").attr("value");
        window.location.href = rediretString;
    }, 1);
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "MembersDocumenteInactive.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
function GetMembersDocumentsData() {
    var jsonArray = [];
    var memberId = parseInt($("#hiddenFieldMemberId").val());
    jsonArray.push({
        MemberID: memberId,
        IC_CreatedIn: $("#txtIDCreatedIn").val(),
        IC_IDNumber: $("#txtIDNumber").val(),
        IC_AdditionalNumber: $("#txtIDAdditionalNumber").val(),
        IC_DateOfIssue: moment(dtIDIssuedOn.GetDate()).isValid() ? moment(dtIDIssuedOn.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        IC_ExpiryDate: moment(dtIDExpiryDate.GetDate()).isValid() ? moment(dtIDExpiryDate.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        IC_Address: $("#txtIDAddress").val(),
        IC_IssuingAuthority: $("#txtIDIssuingAuthority").val(),
        IC_EyeColor: $("#txtIDEyeColor").val(),
        IC_Height: $("#txtMemberHeight").val(),
        IC_PlaceOfBirth: $("#txtIDPlaceofBirth").val(),
        IC_Memo: $("#txtIDMemo").val(),

        PP_CreatedIn: $("#txtPPCreatedIn").val(),
        PP_PPNumber: $("#txtPPNumber").val(),
        PP_Gender: $("#txtPPGender").val(),
        PP_DateOfIssue: moment(dtPPIssuedOn.GetDate()).isValid() ? moment(dtPPIssuedOn.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        PP_ExpiryDate: moment(dtPPExpiryDate.GetDate()).isValid() ? moment(dtPPExpiryDate.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        PP_IssuingAuthority: $("#txtPPIssuingAuthority").val(),
        PP_Memo: $("#txtPPMemo").val(),

        DL_CreatedIn: $("#txtDLCreatedIn").val(),
        DL_DLNumber: $("#txtDLNumber").val(),
        DL_DateOfIssue: moment(dtDLIssuedOn.GetDate()).isValid() ? moment(dtDLIssuedOn.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        DL_Class: $("#txtDLClass").val(),
        DL_IssuingAuthority: $("#txtDLIssuingAuthority").val(),
        DL_Memo: $("#txtDLMemo").val(),

        HC_BoxNumber: $("#txtHIBoxOffice").val(),
        HC_CreatedIn: $("#txtHICreatedIn").val(),
        HC_ItemNumber: $("#txtHIMemberNumber").val(),
        HC_SecurityNumber: $("#txtHISecurityNumber").val(),
        HC_CardNumber: $("#txtHICardNumber").val(),
        HC_ExpiryDate: moment(dtHIExpirationDate.GetDate()).isValid() ? moment(dtHIExpirationDate.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        HC_Memo: $("#txtHIMemo").val(),
    });

    return jsonArray;
}
function SaveDocumentDetails() {
    InitialPageLoadPanel.Show();
    var jsonString = JSON.stringify(GetMembersDocumentsData());
    PageMethods.SaveMemberDocuments(jsonString, OnSaveMemberDocuments_CallBack);
}
function OnSaveMemberDocuments_CallBack(document) {
    saveChanges = false;
    InitialPageLoadPanel.Hide();
}
function SaveDocumentDetailsOnBack() {
    InitialPageLoadPanel.Show();
    var jsonString = JSON.stringify(GetMembersDocumentsData());
    PageMethods.SaveMemberDocuments(jsonString, OnSaveMemberDocumentsOnBack_CallBack);
}
function OnSaveMemberDocumentsOnBack_CallBack() {
    InitialPageLoadPanel.Hide();
    document.location.href = "/Content/MembersInactive.aspx?Id=" + $("#hiddenFieldMemberId").val();
}
function DeleteDocument(value, memberId) {
    switch (value) {
        case 1:
            PageMethods.DeleteIdentityCard(memberId, OnDeleteIdentityCard_CallBack);
            break;
        case 2:
            PageMethods.DeletePassport(memberId, OnDeletePassport_CallBack);
            break;
        case 3:
            PageMethods.DeleteLicence(memberId, OnDeleteLicence_CallBack)
            break;
        case 4:
            PageMethods.DeleteHealthCard(memberId, OnDeleteHealthCard_CallBack);
            break;
    }
}
function OnDeleteIdentityCard_CallBack() {
    $("#txtIDCreatedIn").val("");
    $("#txtIDNumber").val("");
    $("#txtIDAdditionalNumber").val("");
    dtIDIssuedOn.SetDate(null);
    dtIDExpiryDate.SetDate(null);
    $("#txtIDAddress").val("");
    $("#txtIDIssuingAuthority").val("");
    $("#txtIDMemo").val("");
}
function OnDeletePassport_CallBack() {
    $("#txtPPCreatedIn").val("");
    $("#txtPPNumber").val("");
    $("#txtPPGender").val("");
    dtPPIssuedOn.SetDate(null);
    dtPPExpiryDate.SetDate(null);
    $("#txtPPIssuingAuthority").val("");
    $("#txtPPMemo").val("");
}
function OnDeleteLicence_CallBack() {
    $("#txtDLCreatedIn").val("");
    $("#txtDLNumber").val("");
    dtDLIssuedOn.SetDate(null);
    $("#txtDLClass").val("");
    $("#txtDLIssuingAuthority").val("");
    $("#txtDLMemo").val("");
}
function OnDeleteHealthCard_CallBack() {
    $("#txtHIBoxOffice").val("");
    $("#txtHICreatedIn").val("");
    $("#txtHIMemberNumber").val("");
    $("#txtHISecurityNumber").val("");
    $("#txtHICardNumber").val("");
    dtHIExpirationDate.SetDate(null);
    $("#txtHIMemo").val("");
}
//dialogs
//function ConfirmDelete() {
//    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
//    //var message = levelCaption;
//    var message = "Sind Sie sicher, dass Sie löschen möchten";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Delete_Confirmed()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function ConfirmDelete() {
    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
    //var message = levelCaption;
    var message = "Sind Sie sicher, dass Sie löschen möchten";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="HideDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  margin-right: 0px;"  onclick="Delete_Confirmed()"></button><button id="btnCancel"  onclick="HideDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
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
    document.getElementById('importantDialog').innerHTML = "";
}
function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 35%;width: 135px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
    //getLocalizedText("saveButton");
    //$('#btnOk').text(levelCaption);
    //getLocalizedText("no");
    //$('#btnNo').text(levelCaption);
    //getLocalizedText("cancel");
    //$('#btnCancel').text(levelCaption);
}
function No_OnBack() {
    HideDialog();
    document.location.href = "/Content/MembersInactive.aspx?Id=" + $("#hiddenFieldMemberId").val();
}
// end dialog
function Delete_Confirmed() {
    HideDialog();
    var memberId = parseInt($("#hiddenFieldMemberId").val());
    if (memberId > 0) {
        DeleteDocument(deleteValue, memberId);
    }
}
function SaveOnBack() {
    HideDialog();
    SaveDocumentDetailsOnBack();
}

function SetPlaceOfBirthText(tetx) {
    $("#txtIDPlaceofBirth").val(tetx);
    $("#txtPPPlaceofBirth").val(tetx);
    $("#txtDLPlaceofBirth").val(tetx);
    saveChanges = true;
}
function setPersonHeight(tetx) {
    $("#txtMemberHeight").val(tetx);
    $("#txtPPSize").val(tetx);
    saveChanges = true;
}
function setEyeColor(tetx) {
    $("#txtIDEyeColor").val(tetx);
    $("#txtPPEyeColor").val(tetx);
    saveChanges = true;
}

function clearPersonalControls() {
    $("#txtIDCreatedIn").val("");
    $("#txtIDNumber").val("");
    $("#txtIDPlaceofBirth").val("");
    $("#txtIDAdditionalNumber").val("");
    $("#txtIDEyeColor").val("");
    $("#txtMemberHeight").val("");
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
    $("#txtHIMemberNumber").val("");
    $("#txtHISecurityNumber").val("");
    $("#txtHICardNumber").val("");
    $("#txtHIMemo").val("");

    dtHIExpirationDate.SetDate(moment().toDate());

    $("#txtHIBoxOffice").focus();
}