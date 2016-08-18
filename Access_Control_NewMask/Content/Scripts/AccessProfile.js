var edit_mode = false;
var levelCaption = "";
var zuruck = 0;
var groupID;
var profileID;
var curGroupNo;
var curGroupDescription;
var _isPageLoad = true;

$(function () {
    $('.maxlength4').keyup(function () {
        if (parseInt($(".maxlength4").attr('maxlength')) > 4) {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        }
    });
    $(".maxlength4").attr('maxlength', '4');
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());
    //$("#txtGroupProfileNo1").val(ddlGroupProfileNo1.GetText());
    $("#txtGroupProfileDescription1").val(ddlGroupProfileDescription1.GetText());
    checkDisplayStatus();
    $("#chkDisplayProfiles").change(function () {
        if (this.checked) {
            SetgridRows(false);
        }
        else {
            SetgridRows(true);
        }
    });
    $(document).on("selectstart", false);

    $('#btnEntSave').click(
      function (evt) {
          evt.preventDefault();

          document.getElementById("txtAccessProfileID").style.border = "";
          $("#hiddenFieldFormMode").attr("value", "AddMode");

          if ($("#txtAccessProfileNo").val().trim() === "" || $("#txtAccessProfileNo").val().trim() === "0") {
              getLocalizedText("noSelection");
              alert(levelCaption);
          }
          else {
              save();
              SetControlsOnLoad();
              zuruck = 0;
          }
      });

    $('#btnEntNew').click(
    function (evt) {
        evt.preventDefault();
        if ($("#txtGroupProfileNo1").val().trim() === "0" || $("#txtGroupProfileDescription1").val() === "keine" || $("#txtGroupProfileDescription1").val() === "None" || $("#txtGroupProfileDescription1").val() === "") {
            getLocalizedText("accessProfileGroupNumberWarning");
            alert(levelCaption);

            $("#ddlGroupProfileNo1").focus();

            $("#hiddenFieldFormMode").attr("value", "AddMode");

            return;
        }
        else {
            zuruck = 1;
            SetControlsOnNew();
            ddlAccessProfileNo.SetValue("");
            ddlAccessProfileID.SetValue("");
            ddlAccessDescription.SetValue("");
            $("#txtAccessProfileID").val("");
            $("#txtMemoNotes").val("");
            $('#chkDisplayProfiles')[0].checked = false;
            $("#txtAccessProfileNo").focus();
            $("#grdZuttritProfileTimeFrames").prop("disabled", false);
            setNextAccessProfileNo();
            grdZuttritProfileTimeFrames.PerformCallback(0);
            SetgridRows(true);
        }
    });


    $('#btnEntEdit').click(
        function (evt) {
            evt.preventDefault();
            zuruck = 1;
            if ($("#txtAccessProfileNo").val().trim() === "" || $("#txtAccessProfileNo").val().trim() === "0") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            } else if (ddlAccessProfileDescription.GetValue() === "" || ddlAccessProfileDescription.GetValue() === "keine" || ddlAccessProfileDescription.GetValue() === "None") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            } else {
                SetControlsOnEdit();

            }

        });

    $('#btnCancelDel').click(
          function (evt) {
              evt.preventDefault();
              if ($("#txtAccessProfileNo").val().trim() === "" || $("#txtAccessProfileNo").val().trim() === "0") {
                  getLocalizedText("noSelection");
                  alert(levelCaption);
              } //else if ($("#txtAccessDescription").val() === "" || $("#txtAccessDescription").val() === "keine" || $("#txtAccessDescription").val() === "None") {
                  //    getLocalizedText("noSelection");
                  //    alert(levelCaption);}
              else {
                  getLocalizedText("TerminalInstanceDeleteWarning");
                  ConfirmDelete(levelCaption);
              }
          });


    $("#txtAccessProfileID").change(function (e) {
        e.preventDefault();
        edit_mode = true;
    });
    $("#txtAccessDescription").change(function (e) {
        e.preventDefault();
        edit_mode = true;
    });
    $("#txtAccessProfileNo").change(function (e) {
        e.preventDefault();
        edit_mode = true;
    });
    $("#txtGroupProfileNo1").change(function (e) {
        e.preventDefault();
        edit_mode = true;
    });
    $("#txtGroupProfileDescription1").change(function (e) {
        e.preventDefault();
        edit_mode = true;
    });
    $("#grdZuttritProfileTimeFrames").change(function (e) {
        e.preventDefault();
        //grdZuttritProfileTimeFrames.PerformCallback();
        edit_mode = true;
    });

    $("#txtMemoNotes").change(function (e) {
        e.preventDefault();
        edit_mode = true;
    });

    $('#btnBack').click(
      function (evt) {
          evt.preventDefault();
          if (edit_mode && allowZUTEdit) {
              BackButtonConfirm();
          }
          else {
              redirectPageBackToSettings();
          }
      });

    $('#btnSearchProfiles').click(function (evt) {
        evt.preventDefault();
        $(".sectionBottom").hide();
        $(".secSearchProfiles").show();
        zuruck = 2;
        $("#btnBack").unbind("click");
        $("#btnBack").bind("click", function (evt) {
            evt.preventDefault();
            if (zuruck === "0") {
                document.location.href = "/Dashboard_Main.aspx";
            } else if (zuruck === 2) {
                $(".sectionBottom").show();
                $(".secSearchProfiles").hide();
            }
        });
    });

});
function setFormModeToAddModeAftergroupSelection() {
    zuruck = 1;
    SetControlsOnNew();
    $("#ddlAccessProfileNo").val("");
    $("#ddlAccessProfileID").val("");
    $("#ddlAccessDescription").val("");
    $("#txtAccessProfileID").val("");
    $("#txtMemoNotes").val("");
    $('#chkDisplayProfiles')[0].checked = false;
    ASPxColorEditForeColor.val = "";
    ASPxColorEditBackColor.val = "";
    $("#grdZuttritProfileTimeFrames").prop("disabled", false);
    setNextAccessProfileNo();
    grdZuttritProfileTimeFrames.PerformCallback(0);
    SetgridRows(true);

    document.getElementById("txtAccessProfileID").style.border = "1px solid red";
    $("#txtAccessProfileID").focus();

}
function BindGroupForSelectedProfile(response) {
    $("#ddlGroupProfileNo1").val(response);
    $("#ddlGroupProfileDescription1").val(response);
}

//function BackButtonConfirm() {
//    getLocalizedText("saveChangesConfirmation");
//    var message = levelCaption;
//    //var box_content = '<div id="overlayAC"><div id="box_flameAC"><div id="dialogBoxAC">  <img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOkAC"  onclick=" SaveOnBackButton()"></button><button id="btnNoAC"  onclick="CancelOnBackButton()"></button><button id="btnCancelAC"  onclick="resetConfirmationDiv()"></button></div></div></div>';
//    var box_content = '<div id="overlay"> <div id="box_flame"> <div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutrittsprofile</label><button id="promptbtnclose" onclick="resetConfirmationDiv()" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + ' </div><button id="promptButtonok" style="margin-left:49%;"  onclick="SaveOnBackButton()">  </button><button id="btnNo"  onclick="CancelOnBackButton()"></button><button id="btnCancel"  onclick="resetConfirmationDiv()"></button></div></div></div></div>';
//    document.getElementById('confirmDelete').innerHTML = box_content;
//    getLocalizedText("save_dialong");
//    $('#promptButtonok').text(levelCaption);
//    getLocalizedText("no");
//    $('#btnNo').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetConfirmationDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveOnBackButton()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button></div></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}

function SaveOnBackButton() {
    resetConfirmationDiv();
    save();
    redirectPageBackToSettings();
}
function redirectPageBackToSettings() {
    var pageOrigin = getParameterByName('ent');
    var profileId = getParameterByName('profileId');
    var hostServerAddress = ''
    var redirectURL = ''

    if (pageOrigin == "") {
        window.location.href = "/Content/Settings.aspx";
    }
    else {
        PageMethods.Redirect_to_AccessControl(pageOrigin, profileId, OnAccessControlRedirect_Callback);
    }
}
function OnAccessControlRedirect_Callback(data) {
    window.location.replace(data);
}
function CancelOnBackButton() {
    resetConfirmationDiv();
    window.location.href = "/Content/Settings.aspx";
}
function resetConfirmationDiv() {
    document.getElementById('confirmDelete').innerHTML = "";
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
function checkDisplayStatus() {
    if ($("#chkDisplayProfiles").is(':checked')) {
        SetgridRows(false);
    } else {
        SetgridRows(true);
    }
    //edit_mode = false;
}

function SetgridRows(hiddenstatus) {
    for (var i = 5;i < grdZuttritProfileTimeFrames.pageRowCount;i++) {

        grdZuttritProfileTimeFrames.GetRow(i).hidden = hiddenstatus;
    }
}
function SetControlsToDefaultEmpty() {
    ddlAccessProfileNo.SetValue("");
    ddlAccessProfileID.SetValue("");
    ddlAccessDescription.SetValue("");

    $("#txtAccessProfileNo").val("");
    $("#txtAccessProfileID").val("");
    $("#txtAccessDescription").val("");
    $("#txtMemoNotes").val("");
    $('#chkDisplayProfiles')[0].checked = false;
}

function UnbindAccessProfileDropdowns() {
    ddlAccessProfileNo.SetValue("");
    ddlAccessProfileID.SetValue("");
    ddlAccessDescription.SetValue("");

}

function SetControlsOnNew() {
    $("#txtGroupProfileNo").val();
    $("#txtGroupProfileDescription").val();
    $("#txtMemoNotes").val();
    $("#txtAccessProfileNo").val("");
    $("#txtAccessProfileID").val("");
    $("#txtAccessDescription").val("");
    //$("#ASPxColorEditForeColor").val("");
    //$("#ASPxColorEditBackColor").val("");


    ASPxColorEditForeColor.Clear();
    ASPxColorEditBackColor.Clear();
    //getLocalizedText("cancel");
    //$("#btnCancelDel").val(levelCaption);
    $("#btnCancelDel").data("mode", "Abbrechen");

    $("#txtAccessProfileID").css('color', "");
    $("#txtAccessProfileID").css('background-color', "");

}

function setNextAccessProfileNo() {
    var maxNo = 0;
    var currNo = [];
    var dummyVariable = "";
    $("#btnCancelDel").attr("disabled", "disabled");
    PageMethods.GetLatestProfileNo(dummyVariable, GetLatestProfileNo_Callback);
}

function GetLatestProfileNo_Callback(response) {
    var maxNo = response.AccessProfileNo;
    $("#txtAccessProfileNo").val(maxNo);
    $("#txtAccessProfileID").focus();
}

function save() {
    var txtAccessProfileNo = $("#txtAccessProfileNo").val();
    var txtAccessProfileID = $("#txtAccessProfileID").val();
    var aspbackcolour = ASPxColorEditBackColor.color;
    var aspforecolour = ASPxColorEditForeColor.color;
    var txtAccessDescription = $("#txtAccessDescription").val();
    var chkDisplayProfiles = $('#chkDisplayProfiles')[0].checked;
    var txtMemoNotes = $("#txtMemoNotes").val();
    var currentGroupID = ddlGroupProfileNo1.GetValue();
    var AccessProfileNoVar = 0;
    if (!isNaN(parseInt(ddlAccessProfileNo.GetValue()))) {
        AccessProfileNoVar = parseInt(ddlAccessProfileNo.GetValue());
    }
    // var ddlAccessProfileNo = ddlAccessProfileNo.GetValue();

    $("#btnCancelDel").removeAttr("disabled", "disabled");
    if (AccessProfileNoVar === 0) {
        PageMethods.CreateAccessProfile(currentGroupID, txtAccessProfileNo, txtAccessProfileID, txtAccessDescription, chkDisplayProfiles, txtMemoNotes, GetZuttritProfileTimeFramesValues(), aspbackcolour, aspforecolour, OnSave_Callback, function (err) { console.log(err) });
    } else {
        PageMethods.UpdateAccessProfile(AccessProfileNoVar, txtAccessProfileNo, txtAccessProfileID, txtAccessDescription, chkDisplayProfiles, txtMemoNotes, GetZuttritProfileTimeFramesValues(), aspbackcolour, aspforecolour, OnEdit_Callback);
    }
    edit_mode = false;
}

function SetgrdAccessprofile() {
    var accessProfileNr = ddlAccessProfileNo.GetValue();
    if ((accessProfileNr === undefined) || (accessProfileNr === null) || (accessProfileNr.trim().length === 0)) {
        $("#ddlAccessProfileNo").focus();
        return;
    }
}

function OnEdit_Callback(response) {
    ddlAccessProfileNo.GetValue();
    ddlAccessProfileID.GetValue();
    ddlAccessDescription.GetValue();
    $("#txtAccessProfileNo").val(response.AccessProfileNo);
    $("#txtAccessProfileID").val(response.AccessProfileID);
    //ASPxColorEditBackColor.GetValue(response.back);
    //$("#ASPxColorEditForeColor").val(response.fore);
    $("#txtAccessDescription").val(response.AccessDescription);
    $("#txtMemoNotes").val(response.Memo);
    grdZuttritProfileTimeFrames.PerformCallback(response.ID);
    SetAccessProfileonselection(response);
    setTimeout(function () {
        grdAccessProfileList.PerformCallback();
        grdSearchProfiles.PerformCallback();
    }, 1300);
    groupID = ddlGroupProfileNo1.GetValue();
    setTimeout(function (ev) { ddlAccessProfileNo.PerformCallback(groupID) }, 10);
    setTimeout(function (ev) { ddlAccessDescription.PerformCallback(groupID) }, 12);
    setTimeout(function (ev) { ddlAccessProfileID.PerformCallback(groupID) }, 14);
}

function GetZuttritProfileTimeFramesValues() {
    var jsonArray = [];
    var accessProfID = ddlAccessProfileNo.GetValue();
    for (var rowNumber = 0;rowNumber < 10;rowNumber++) {
        var rowCells = grdZuttritProfileTimeFrames.GetRow(rowNumber).cells;

        jsonArray.push({
            ID: rowNumber + 1,
            AccessProfID: accessProfID,
            ProfilAktiv: getCheckedGridCell(rowCells[0].childNodes[0]),
            MonFrom: (rowCells[1].childNodes[0].textContent),
            MonTo: (rowCells[2].childNodes[0].textContent),
            TueFrom: (rowCells[3].childNodes[0].textContent),
            TueTo: (rowCells[4].childNodes[0].textContent),
            WedFrom: (rowCells[5].childNodes[0].textContent),
            WedTo: (rowCells[6].childNodes[0].textContent),
            ThurFrom: (rowCells[7].childNodes[0].textContent),
            ThurTo: (rowCells[8].childNodes[0].textContent),
            FriFrom: (rowCells[9].childNodes[0].textContent),
            FriTo: (rowCells[10].childNodes[0].textContent),
            SatFrom: (rowCells[11].childNodes[0].textContent),
            SatTo: (rowCells[12].childNodes[0].textContent),
            SunFrom: (rowCells[13].childNodes[0].textContent),
            SunTo: (rowCells[14].childNodes[0].textContent),
        });
    }
    var jsonString = JSON.stringify(jsonArray);
    return jsonString;
}

function getCheckedGridCell(childnodeval) {
    var ischecked = false;
    try {
        if (childnodeval.children[0].className === "dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys") {
            ischecked = true;
        }
    } catch (e) {
        try {
            if (childnodeval.className === "dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys") {
                ischecked = true;
            }
        } catch (e) { }
    }
    return ischecked;
}


function OnSave_Callback(response) {
    ddlAccessProfileNo.GetValue();
    ddlAccessProfileID.GetValue();
    ddlAccessDescription.GetValue();
    $("#ddlAccessProfileNo").val(response.ID);
    $("#ddlAccessProfileID").val(response.ID);
    $("#ddlAccessDescription").val(response.ID);
    $("#txtAccessProfileNo").val(response.AccessProfileNo);
    $("#txtAccessProfileID").val(response.AccessProfileID);
    $("#txtAccessDescription").val(response.AccessDescription);
    $("#txtMemoNotes").val(response.Memo);

    SetAccessProfileonselection(response);
    grdZuttritProfileTimeFrames.PerformCallback(response.ID);
    setTimeout(function () {
        grdAccessProfileList.PerformCallback();
        grdSearchProfiles.PerformCallback();
    }, 1300);
    groupID = ddlGroupProfileNo1.GetValue();
    setTimeout(function (ev) { ddlAccessProfileNo.PerformCallback(groupID) }, 10);
    setTimeout(function (ev) { ddlAccessDescription.PerformCallback(groupID) }, 12);
    setTimeout(function (ev) { ddlAccessProfileID.PerformCallback(groupID) }, 14);
}

function GetGroupIDFromProfileID_Callback(response) {
    $("#ddlGroupProfileNo1").val(response.ID);
    $("#ddlGroupProfileDescription1").val(response.ID);
    $("#txtGroupProfileNo1").val(response.GroupProfileNo);
    $("#txtGroupProfileDescription1").val(response.GroupProfileDescription);
}

function SetControlsOnLoad() {
    $("#txtGroupProfileNo1").val(ddlGroupProfileNo1.GetText());
    $("#txtGroupProfileDescription1").val(ddlGroupProfileDescription1.GetText());
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());
    getLocalizedText("deleteButton");
    $("#btnCancelDel").val(levelCaption);
    $("#btnCancelDel").data("mode", "Löschen");
    checkDisplayStatus();
}

function SetControlsOnEdit() {
    getLocalizedText("cancel");
    $("#btnCancelDel").val(levelCaption);
    $("#btnCancelDel").data("mode", "Abbrechen");
    checkDisplayStatus();
}

function GetAccessProfile_Callback(response) {
    $("#txtMemoNotes").val(response.Memo);
    grdZuttritProfileTimeFrames.PerformCallback(response.ID);
    SetAccessProfileonselection(response);

    ASPxColorEditForeColor.SetValue(response.ForeColour);
    ASPxColorEditBackColor.SetValue(response.BackColour);

    if (response != null) {
        ASPxColorEditForeColor.SetValue(response.ForeColour);
        ASPxColorEditBackColor.SetValue(response.BackColour);
        $("#txtAccessProfileID").css('color', response.ForeColour);
        $("#txtAccessProfileID").css('background-color', response.BackColour);


    } else {
        ASPxColorEditForeColor.Clear();
        ASPxColorEditBackColor.Clear();
        $("#txtAccessProfileID").css('color', "");
        $("#txtAccessProfileID").css('background-color', "#FFFFFF");
        $('#txtSampleText').css('color', "");

    }

}

function OnFailGetAccessProfile_Callback(response) {
    grdZuttritProfileTimeFrames.PerformCallback(0);
    SetControlsOnLoad();
    checkDisplayStatus();
}

function GetFilteredAccessGroupProfile_Callback(response) {

    $("#txtMemoNotes").val(response.Memo);

    if (response.length == 0) {
        grdZuttritProfileTimeFrames.PerformCallback(-15);
        return;
    }
    else {
        $(response).each(function (index, element) {
            $("#chkDisplayProfiles")[0].checked = element.DisplayProfiles;
            $("#txtMemoNotes").val = element.Memo;
        });
        $("#txtMemoNotes").val(response[0].Memo);
    }
}

function SetAccessProfileonselection(response) {
    if (response.DisplayProfiles === true) {
        $('#chkDisplayProfiles').prop('checked', true);
        checkDisplayStatus();
    } else {
        $('#chkDisplayProfiles').prop('checked', false);
        checkDisplayStatus();
    }
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessProfile.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });

}

var profNr;
var grpId;
function LoadProfileTimeFrames(s, e) {

    var grpNr = grdAccessProfileList.GetRow(e.visibleIndex).cells[0].childNodes[0].textContent;
    var groupName = grdAccessProfileList.GetRow(e.visibleIndex).cells[1].childNodes[0].textContent;
    profNr = grdAccessProfileList.GetRow(e.visibleIndex).cells[2].childNodes[0].textContent;
    var profName = grdAccessProfileList.GetRow(e.visibleIndex).cells[3].childNodes[0].textContent;
    var _grpId = 0; _profileId = 0;

    try { _grpId = ddlGroupProfileNo1.FindItemByText(grpNr).value; } catch (e) { }
    try { _profileId = ddlAccessProfileNo.FindItemByText(profNr).value; } catch (e) { }

    PageMethods.GetAccessProfile(ddlAccessProfileNo.GetValue(), GetAccessProfile_Callback, OnFailGetAccessProfile_Callback);
    ddlGroupProfileNo1.SetValue(_grpId);
    ddlGroupProfileDescription1.SetValue(_grpId);
    ddlAccessProfileNo.SetValue(_profileId);
    ddlAccessDescription.SetValue(_profileId);
    ddlAccessProfileID.SetValue(_profileId);


    $("#txtGroupProfileNo1").val(ddlGroupProfileNo1.GetText());
    $("#txtGroupProfileDescription1").val(ddlGroupProfileDescription1.GetText());
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    ddlAccessProfileNo.PerformCallback(ddlGroupProfileNo1.GetValue());
    ddlAccessProfileID.PerformCallback(ddlGroupProfileNo1.GetValue());
    ddlAccessDescription.PerformCallback(ddlGroupProfileNo1.GetValue());
}

function SetGridAccessProfile_Callback(response) {
    ddlAccessProfileNo.SetValue(response.AccessProfileNo);
    ddlAccessProfileID.SetValue(response.ID);
    ddlAccessDescription.SetValue(response.AccessDescription);
    $("#txtAccessProfileNo").val(response.AccessProfileNo);
    $("#txtAccessProfileID").val(response.AccessProfileID);
    $("#txtAccessDescription").val(response.AccessDescription);
    $("#txtMemoNotes").val(response.Memo);

    if (response.length == 0) {

    }
    else {
        $(response).each(function (index, element) {
            ddlAccessProfileNo.GetValue(element.ID).html(element.AccessProfileNo);
            ddlAccessProfileID.GetValue(element.ID).html(element.AccessProfileID);
            ddlAccessDescription.GetValue(element.ID).html(element.AccessDescription);
        });
    }
    PageMethods.GetUserSelectedGridAccessProfile(profNr, grpId, GetUserSelectedGridAccessProfile_Callback);
}

function GetUserSelectedGridAccessProfile_Callback(response) {
    SetAccessProfileonselection(response);
    grdZuttritProfileTimeFrames.PerformCallback(response.ID);
    profNr = "";
    grpId = "";
}

function activateProfile(s, e) {
    if (s.valueChecked) {
        for (var rowNumber = 0;rowNumber < 10;rowNumber++) {
            try {
                grdZuttritProfileTimeFrames.GetRow(rowNumber).cells[0].childNodes[0].className === "dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys";
                grdZuttritProfileTimeFrames.GetRow(rowNumber).cells[0].childNodes[0].children[0].className === "dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys";
            } catch (e) {
            }
        }
    }
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
})

//function ConfirmDelete(message) {
//    getLocalizedText("accessProfileDeleteWarning");
//    var message = levelCaption;
//    //var boxContent = "<div id=\"overlayDelete\"><div id=\"box_flameDelete\"><div id=\"dialogBoxDelete\">  " +
//    //"<img src=\"../../Images/FormImages/stop-save1-01.png\" alt=\"Stop\" class=\"stopPicDelete\" height=\"150\" width=\"150\" align=\"middle\"> <br/>" + message + "<br/> " +
//    //"<button id=\"btnOkDelete\"  onclick=\"DeleteAccessProfile(); return false;\"></button><button id=\"btnNoDelete\"  onclick=\"CancelOnDeleteButton()\"></button>" +
//    //"<button id=\"btnCancelDelete\"  onclick=\"resetImportantInfoDialogDiv()\"></button></div></div></div>";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutrittsprofile</label><button id="promptbtnclose"  onclick="CancelOnDeleteButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="DeleteAccessProfile()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById("importantInfoDialog").innerHTML = box_content;
//    getLocalizedText("yes");
//    $("#btnOk").text(levelCaption);
//    getLocalizedText("no");
//    $("#btnNoDelete").text(levelCaption);
//    getLocalizedText("cancel");
//    $("#btnCancel").text(levelCaption);
//}


function ConfirmDelete(message) {
    getLocalizedText("accessProfileDeleteWarning");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutrittsprofile</label><button id="promptbtnclose"  onclick=" resetImportantInfoDialogDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="text-align: right; padding-right: 1px; margin-left: 34%; margin-right: 0px;"  onclick="DeleteAccessProfile()"></button><button id="btnCancel"  onclick="resetImportantInfoDialogDiv(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById("importantInfoDialog").innerHTML = box_content;
    getLocalizedText("permitProfileDeletion");
    $("#btnOk").text(levelCaption);
    getLocalizedText("cancelProfileDeletion");
    $("#btnCancel").text(levelCaption);
}

var curGroupIdToDeleteFrom;
function DeleteAccessProfile() {
    var selectval = ddlAccessProfileNo.GetValue();
    curGroupIdToDeleteFrom = ddlGroupProfileNo1.GetValue();
    if (selectval != 0) {
        PageMethods.DeleteSelectedAccessProfile(selectval, curGroupIdToDeleteFrom, ReloadPage);
    }
}

function ReloadPage(res) {
    if (res) {
        window.location = window.location;
    }
}

function DeleteAccessProfile_Callback(response) {
    if (response == undefined || response == null || response.length == 0) {
        $("#txtAccessProfileNo").val(0);
        $("#txtAccessProfileID").val("keine");
        $("#txtAccessDescription").val("keine");
        $("#txtMemoNotes").val("");
        $('#chkDisplayProfiles')[0].checked = false
        resetImportantInfoDialogDiv();
        grdZuttritProfileTimeFrames.PerformCallback(0);
        grdAccessProfileList.PerformCallback();
        grdSearchProfiles.PerformCallback();
    }
    else {
        $(response).each(function (index, element) {
            $("#txtAccessProfileNo").val($("#ddlAccessProfileNo option:selected").text());
            $("#txtAccessProfileID").val($("#ddlAccessProfileID option:selected").text());
            $("#txtAccessDescription").val($("#ddlAccessDescription option:selected").text());
            $("#chkDisplayProfiles")[0].checked = element.DisplayProfiles;
            $("#txtMemoNotes").val = element.Memo;
        });
        $("#txtAccessProfileNo").val(response[0].AccessProfileNo);
        $("#txtAccessProfileID").val(response[0].AccessProfileID);
        $("#txtAccessDescription").val(response[0].AccessDescription);
        $("#txtMemoNotes").val(response[0].Memo);
        $('#chkDisplayProfiles')[0].checked = response[0].DisplayProfiles;
        resetImportantInfoDialogDiv();
        grdZuttritProfileTimeFrames.PerformCallback(response[0].ID);
        grdAccessProfileList.PerformCallback();
        grdSearchProfiles.PerformCallback();

    }
}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();
}

function resetImportantInfoDialogDiv() {
    document.getElementById("importantInfoDialog").innerHTML = "";
    $("#ddlAccessProfileNo").focus();
}

function ColorChangedHandler(s, e) {
    var fcolor = $('#ASPxColorEditForeColor div:first').css("background-color");
    var bColor = $('#ASPxColorEditBackColor div:first').css("background-color");
    $('#ASPxColorEditBackColor').css('background-color', '#FFFFFF');
    $('#txtAccessProfileID').css('background-color', bColor);
    $('#txtSampleText').css('background-color', bColor);

    $('#ASPxColorEditForeColor').css('background-color', '#FFFFFF');
    $('#txtAccessProfileID').css('color', fcolor);
    $('#txtSampleText').css('color', fcolor);

}

function grdSearchProfilesRowClick(s, e) {

    $(".sectionBottom").show();
    $(".secSearchProfiles").hide();
}
function ddlGroupProfileNoSelectedIndexChanged(value) {
    ddlGroupProfileDescription1.SetValue(ddlGroupProfileNo1.GetValue());
    $("#txtGroupProfileNo1").val(ddlGroupProfileNo1.GetText());
    $("#txtGroupProfileDescription1").val(ddlGroupProfileDescription1.GetText());
    var fcolor = $('#ASPxColorEditForeColor div:first').css("background-color");
    var bColor = $('#ASPxColorEditBackColor div:first').css("background-color");
    $('#ASPxColorEditBackColor').css('background-color', '#FFFFFF');
    $('#txtAccessProfileID').css('background-color', "");
    $('#txtSampleText').css('background-color', "");

    $('#ASPxColorEditForeColor').css('background-color', '#FFFFFF');
    $('#txtAccessProfileID').css('color', "");
    $('#txtSampleText').css('color', "");

    var formMode = document.getElementById('hiddenFieldFormMode').value;

    if (formMode == "AddMode") {
        setFormModeToAddModeAftergroupSelection();
    }
    else {
        if (ddlGroupProfileNo1.GetValue() == "0") {
            PageMethods.GetAllAccessGroupProfile(GetFilteredAccessGroupProfile_Callback)
            grdZuttritProfileTimeFrames.PerformCallback(-15);
            return;
        }
        if ($("#txtAccessProfileNo").val().trim() !== "" || $("#txtAccessProfileNo").val().trim() !== "0") {
            PageMethods.GetFilteredAccessGroupProfile(ddlGroupProfileNo1.GetValue(), GetFilteredAccessGroupProfile_Callback);

        } else {
        }

    }

    if (formMode == "AddMode") {
    }
    else {
        groupID = value;
        setTimeout(function (ev) {
            ddlAccessProfileNo.PerformCallback(groupID);
        }, 10);
        setTimeout(function (ev) {
            ddlAccessDescription.PerformCallback(groupID);
        }, 12);
        setTimeout(function (ev) {
            ddlAccessProfileID.PerformCallback(groupID);
        }, 14);
    }
    $("#txtAccessProfileNo").val("");
    $("#txtAccessProfileID").val("");
    $("#txtAccessDescription").val("");
    //ASPxColorEditForeColor.SetValue(value.color);
    //ASPxColorEditBackColor.SetValue(value.color);
    SetControlsToDefaultEmpty();
}
function ddlGroupProfileDescription1SelectedIndexChanged(value) {
    ddlGroupProfileNo1.SetValue(ddlGroupProfileDescription1.GetValue());
    $("#txtGroupProfileNo1").val(ddlGroupProfileNo1.GetText());
    $("#txtGroupProfileDescription1").val(ddlGroupProfileDescription1.GetText());


    var formMode = document.getElementById('hiddenFieldFormMode').value;

    if (formMode == "AddMode") {
        setFormModeToAddModeAftergroupSelection();
    }
    else {
        if (ddlGroupProfileDescription1.GetValue() == "0") {
            PageMethods.GetAllAccessGroupProfile(GetFilteredAccessGroupProfile_Callback)
            grdZuttritProfileTimeFrames.PerformCallback(-15);
            return;
        }
        if ($("#txtAccessProfileNo").val().trim() !== "" || $("#txtAccessProfileNo").val().trim() !== "0") {
            PageMethods.GetFilteredAccessGroupProfile(ddlGroupProfileNo1.GetValue(), GetFilteredAccessGroupProfile_Callback);

        } else {
        }

    }

    if (formMode == "AddMode") {
    }
    else {
        groupID = value;
        setTimeout(function (ev) {
            ddlAccessProfileNo.PerformCallback(groupID);
        }, 10);
        setTimeout(function (ev) {
            ddlAccessDescription.PerformCallback(groupID);
        }, 12);
        setTimeout(function (ev) {
            ddlAccessProfileID.PerformCallback(groupID);
        }, 14);
    }
    $("#txtAccessProfileNo").val("");
    $("#txtAccessProfileID").val("");
    $("#txtAccessDescription").val("");
    SetControlsToDefaultEmpty();
}
function ddlAccessProfileNoSelectedIndexChanged(value) {
    ddlAccessDescription.SetValue(ddlAccessProfileNo.GetValue());
    ddlAccessProfileID.SetValue(ddlAccessProfileNo.GetValue());
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());

    if (ddlAccessProfileNo.GetValue() == "0") {
        ddlGroupProfileNo1.GetValue("0");
        ddlGroupProfileDescription1.GetValue("0");

    }
    //else {
    //    PageMethods.GetSelectedProfileGroup(ddlAccessProfileNo.GetValue(), BindGroupForSelectedProfile);
    //}


    if ($("#txtAccessProfileNo").val().trim() !== "" || $("#txtAccessProfileNo").val().trim() !== "0") {
        PageMethods.GetAccessProfile(ddlAccessProfileNo.GetValue(), GetAccessProfile_Callback, OnFailGetAccessProfile_Callback);

    } else {

    }

}
function ddlAccessProfileNoEndCallback(s, e) {
    if (s.GetSelectedItem() != null) $("#txtAccessProfileNo").val(s.GetSelectedItem().text);

    var formMode = document.getElementById('hiddenFieldFormMode').value;

    if (formMode != "AddMode") {
        //setFormModeToAddModeAftergroupSelection();
        if (s.GetSelectedItem() != null) $("#txtAccessProfileNo").val(s.GetSelectedItem().text);
    }

}
function ddlAccessProfileIDSelectedIndexChanged(value) {
    ddlAccessProfileNo.SetValue(ddlAccessProfileID.GetValue());
    ddlAccessDescription.SetValue(ddlAccessProfileID.GetValue());
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());

    if (ddlAccessProfileNo.GetValue() == "0") {
        ddlGroupProfileNo1.GetValue("0");
        ddlGroupProfileDescription1.GetValue("0");
    }
    //else {
    //    PageMethods.GetSelectedProfileGroup(ddlAccessProfileNo.GetValue(), BindGroupForSelectedProfile);
    //}

    if ($("#txtAccessProfileID").val().trim() !== "" || $("#txtAccessProfileID").val().trim() !== "0") {
        PageMethods.GetAccessProfile(ddlAccessProfileID.GetValue(), GetAccessProfile_Callback, OnFailGetAccessProfile_Callback);

    } else {
    }
}
function ddlAccessProfileIDEndCallBack(s, e) {
    if (s.GetSelectedItem() != null) $("#txtAccessProfileID").val(s.GetSelectedItem().text);

    var formMode = document.getElementById('hiddenFieldFormMode').value;

    if (formMode != "AddMode") {
        //setFormModeToAddModeAftergroupSelection();
        if (s.GetSelectedItem() != null) $("#txtAccessProfileID").val(s.GetSelectedItem().text);
    }


}
function ddlAccessDescriptionSelectedIndexChanged(value) {
    ddlAccessProfileNo.SetValue(ddlAccessDescription.GetValue());
    ddlAccessProfileID.SetValue(ddlAccessDescription.GetValue());
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());

    if (ddlAccessProfileNo.GetValue() == "0") {
        ddlGroupProfileNo1.GetValue("0");
        ddlGroupProfileDescription1.GetValue("0");
    }
    //else {
    //    PageMethods.GetSelectedProfileGroup(ddlAccessProfileNo.GetValue(), BindGroupForSelectedProfile);
    //}

    if ($("#txtAccessProfileNo").val().trim() !== "" || $("#txtAccessProfileNo").val().trim() !== "0") {
        PageMethods.GetAccessProfile(ddlAccessDescription.GetValue(), GetAccessProfile_Callback, OnFailGetAccessProfile_Callback);

    } else {
    }
}
function ddlAccessDescriptionEndCallBack(s, e) {
    if (s.GetSelectedItem() != null) $("#txtAccessDescription").val(s.GetSelectedItem().text);

}
function SetValues(value) {
    PageMethods.GetAllAccessGroupProfile(value, Setcontrols);
}

function Setcontrols(Responce) {
    $("#txtGroupProfileNo1").val(ddlGroupProfileNo1.GetText());
    $("#txtGroupProfileDescription1").val(ddlGroupProfileDescription1.GetText());
    $("#txtAccessProfileNo").val(ddlAccessProfileNo.GetText());
    $("#txtAccessProfileID").val(ddlAccessProfileID.GetText());
    $("#txtAccessDescription").val(ddlAccessDescription.GetText());

}
function timeFramesChanged(sender, evt) {
    //var _rowNum = 0, _colIndex = 0;
    //    try { _rowNum = $(sender.mainElement).parents("tr")[0].rowIndex - 1 } catch (e) { }
    //    _colIndex = evt.visibleIndex;

    //    var colHasUpdate = grdZuttritProfileTimeFrames.batchEditHelper.HasChanges(_rowNum, _colIndex);

    //if (colHasUpdate) {
    edit_mode = true;
    //    $("#zuruck").attr("value", "0");
    //}
}
