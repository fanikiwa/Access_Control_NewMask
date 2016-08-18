var _isProfileChange = true;
var _isSave = false;
var _message = "";
var saveChanges = false;
$(document).ready(function () {
    $("#btnSearchPlans").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnReader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlVisitorProfileNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/VisitorPlanReader.aspx?profileId={0}", planId);
        }
    });
    $("#btnAccessProfile").click(function (evt) {
        evt.preventDefault();
        var planId = ddlVisitorProfileNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", planId);
        }
    });

    $("#btnReaderHeader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlVisitorProfileNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/VisitorPlanReader.aspx?profileId={0}", planId);
        }
    });
    $("#btnAccessCalederHeader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlVisitorProfileNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", planId);
        }
    });
    $("#imageBtnReader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlVisitorProfileNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/VisitorPlanReader.aspx?profileId={0}", planId);
        }
    });
    $("#imageBtnAccessCalender").click(function (evt) {
        evt.preventDefault();
        var planId = ddlVisitorProfileNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", planId);
        }
    });
    $("#btnEntNew").click(function (evt) {
        evt.preventDefault();
        SetContolsOnNew();
        CalculateNxtPlanNr();
    });
    $("#btnEntSave").click(function (evt) {
        evt.preventDefault();
        SaveCurrentVisitorPlan();
    });
    $("#btnCancelDel").click(function (evt) {
        evt.preventDefault();
        if (parseInt(ddlVisitorProfileNumber.GetValue()) > 0) {
            Confirm_Delete();
        }
    });
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (saveChanges === true && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {
            document.location.href = "/Index.aspx";
        }

    });
    $('input').change(function () {
        saveChanges = true;
    });
})
function profileSelectedChanged(s, e) {
    if (_isProfileChange === true) {
        _isProfileChange = false;
        ddlVisitorProfileNumber.SetValue(s.GetValue());
        ddlVisitorProfileName.SetValue(s.GetValue());
        $("#txtVisitorProfileNumber").val(ddlVisitorProfileNumber.GetText());
        $("#txtVisitorProfileName").val(ddlVisitorProfileName.GetText());
        if ((parseInt(s.GetValue()) > 0)) {
            EnableButtons();
        }
        else {
            DisableButtons();
        }
    }
}
function profileDropDown(s, e) {
    _isProfileChange = true;
}
function SetContolsOnNew() {
    ddlVisitorProfileNumber.SetValue("0");
    ddlVisitorProfileName.SetValue("0");
    ddlVisitorProfileNumber.SetEnabled(false);
    ddlVisitorProfileName.SetEnabled(false);
    $("#txtVisitorProfileNumber").val("");
    $("#txtVisitorProfileName").val("");
    DisableButtons();
}
function CalculateNxtPlanNr() {
    PageMethods.GetNextPlanNr(OnGetNextPlanNr_CallBack);
}
function OnGetNextPlanNr_CallBack(value) {
    $("#txtVisitorProfileNumber").val(value);
    $("#txtVisitorProfileName").focus();
}
function SaveCurrentVisitorPlan() {
    var planId = ddlVisitorProfileNumber.GetValue();
    var planNr = $("#txtVisitorProfileNumber").val();
    var planName = $("#txtVisitorProfileName").val();
    if (parseInt(planId) > 0) {
        PageMethods.SaveVisitorPlan(planId, planNr, planName, OnSaveVisitorPlan_CallBack);
    }
    else if (parseInt(planId) == 0) {
        PageMethods.CheckIfPlanNrExistsOnNew(planNr, CheckIfPlanNrExistsOnNew_CallBack);
    }
}

function OnSaveVisitorPlan_CallBack(result) {
    _isProfileChange = false;
    saveChanges = false;
    ddlVisitorProfileNumber.SetEnabled(true);
    ddlVisitorProfileName.SetEnabled(true);
    $("#txtVisitorProfileNumber").val(result.planNr);
    $("#txtVisitorProfileName").val(result.planName);
    ddlVisitorProfileNumber.PerformCallback(result.ID);
    ddlVisitorProfileName.PerformCallback(result.ID);
    EnableButtons();
}
function CheckIfPlanNrExistsOnNew_CallBack(value) {
    if (value === true) {
        alert("Besucherpläne Nr existiert");
        return;
    }
    else {
        var planId = ddlVisitorProfileNumber.GetValue();
        var planNr = $("#txtVisitorProfileNumber").val();
        var planName = $("#txtVisitorProfileName").val();
        PageMethods.SaveVisitorPlan(planId, planNr, planName, OnSaveVisitorPlan_CallBack);
    }
}
function DeleteVisitor_Plan() {
    ResetDialog();
    var planId = ddlVisitorProfileNumber.GetValue();
    PageMethods.DeleteVisitorPlan(planId, DeleteVisitorPlan_CallBack);
}
function DeleteVisitorPlan_CallBack() {
    $("#txtVisitorProfileNumber").val("");
    $("#txtVisitorProfileName").val("");
    var id = "0";
    ddlVisitorProfileNumber.PerformCallback(id);
    ddlVisitorProfileName.PerformCallback(id);
}
function Confirm_Delete() {
    var message = "Sind Sie sicher das Sie das Besucherpläne tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnDeleteOk"  style="margin-left: 26%; margin-right: 0px;"  onclick="DeleteVisitor_Plan()"></button><button id="btnDeleteCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitVisitorPlanDeletion");
    $('#btnDeleteOk').text(_message);
    getLocalizedText("cancelVisitorPlanDeletion");
    $('#btnDeleteCancel').text(_message);
}
function ResetDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "Visitors.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            _message = result.d;
        }
    });
}
// back dialog
function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(_message);
    getLocalizedText("newNoText");
    $('#btnNo').text(_message);
}

function SaveOnBack() {
    SaveCurrentVisitorPlanOnBack();
}
function SaveCurrentVisitorPlanOnBack() {
    ResetDialog();
    var planId = ddlVisitorProfileNumber.GetValue();
    var planNr = $("#txtVisitorProfileNumber").val();
    var planName = $("#txtVisitorProfileName").val();
    if (parseInt(planId) > 0) {
        PageMethods.SaveVisitorPlan(planId, planNr, planName, OnSaveVisitorPlanOnBack_CallBack);
    }
    else if (parseInt(planId) == 0) {
        PageMethods.CheckIfPlanNrExistsOnNew(planNr, CheckIfPlanNrExistsOnNewBack_CallBack);
    }
}

function OnSaveVisitorPlanOnBack_CallBack(result) {
    document.location.href = "/Index.aspx";
}
function CheckIfPlanNrExistsOnNewBack_CallBack(value) {
    if (value === true) {
        alert("Besucherpläne Nr existiert");
        return;
    }
    else {
        var planId = ddlVisitorProfileNumber.GetValue();
        var planNr = $("#txtVisitorProfileNumber").val();
        var planName = $("#txtVisitorProfileName").val();
        PageMethods.SaveVisitorPlan(planId, planNr, planName, OnSaveVisitorPlanOnBack_CallBack);
    }
}
function No_OnBack() {
    ResetDialog();
    document.location.href = "/Index.aspx";
}
function EnableButtons() {
    $("#btnAccessCalederHeader").prop("disabled", false);
    $("#imageBtnAccessCalender").prop("disabled", false);
    $("#btnReaderHeader").prop("disabled", false);
    $("#btnReader").prop("disabled", false);
    $("#btnAccessProfile").prop("disabled", false);
    $("#btnAccessCalederHeader").css('cursor', 'pointer');
    $("#imageBtnAccessCalender").css('cursor', 'pointer');
    $("#btnReaderHeader").css('cursor', 'pointer');
    $("#imageBtnReader").css('cursor', 'pointer');
}
function DisableButtons() {
    $("#btnAccessCalederHeader").prop("disabled", true);
    $("#imageBtnAccessCalender").prop("disabled", true);
    $("#btnReaderHeader").prop("disabled", true);
    $("#btnReader").prop("disabled", true);
    $("#btnAccessProfile").prop("disabled", true);
    $("#btnAccessCalederHeader").css('cursor', 'default');
    $("#imageBtnAccessCalender").css('cursor', 'default');
    $("#btnReaderHeader").css('cursor', 'default');
    $("#imageBtnReader").css('cursor', 'default');
}