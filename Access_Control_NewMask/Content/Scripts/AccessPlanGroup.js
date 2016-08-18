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
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessPlanGroupReader.aspx?profileId={0}", planId);
        }
    });
    $("#btnAccessProfile").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessPlanGroupCalender.aspx?profileId={0}", planId);
        }
    });
    $("#btnHoliday").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessGroupHolidaySchedule.aspx?profileId={0}", planId);
        }
    });

    $("#btnReaderHeader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessPlanGroupReader.aspx?profileId={0}", planId);
        }
    });
    $("#btnAccessCalederHeader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessPlanGroupCalender.aspx?profileId={0}", planId);
        }
    });
    $("#btnHolidayCalenderHeader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessGroupHolidaySchedule.aspx?profileId={0}", planId);
        }
    });
    $("#imageBtnReader").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessPlanGroupReader.aspx?profileId={0}", planId);
        }
    });
    $("#imageBtnAccessCalender").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessPlanGroupCalender.aspx?profileId={0}", planId);
        }
    });
    $("#imageBtnHolidayCalender").click(function (evt) {
        evt.preventDefault();
        var planId = ddlAccessGroupNumber.GetValue();
        if (parseInt(planId) > 0) {
            document.location.href = String.format("/Content/AccessGroupHolidaySchedule.aspx?profileId={0}", planId);
        }
    });
    $("#btnEntNew").click(function (evt) {
        evt.preventDefault();
        SetContolsOnNew();
        CalculateNxtPlanNr();
        saveChanges = true;
    });
    $("#btnEntSave").click(function (evt) {
        evt.preventDefault();
        SaveCurrentVisitorPlan();
    });
    $("#btnCancelDel").click(function (evt) {
        evt.preventDefault();
        if (parseInt(ddlAccessGroupNumber.GetValue()) > 0) {
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
function planGroupSelectedChanged(s, e) {
    if (_isProfileChange === true) {
        _isProfileChange = false;
        ddlAccessGroupNumber.SetValue(s.GetValue());
        ddlAccessGroupName.SetValue(s.GetValue());
        $("#txtAccessGroupNumber").val(ddlAccessGroupNumber.GetText());
        $("#txtAccessGroupName").val(ddlAccessGroupName.GetText());
        if ((parseInt(s.GetValue()) > 0)) {
            EnableButtons();
        }
        else {
            DisableButtons();
        }
    }
}
function planGroupDropDown(s, e) {
    _isProfileChange = true;
}
function SetContolsOnNew() {
    ddlAccessGroupNumber.SetValue("0");
    ddlAccessGroupName.SetValue("0");
    ddlAccessGroupNumber.SetEnabled(false);
    ddlAccessGroupName.SetEnabled(false);
    $("#txtAccessGroupNumber").val("");
    $("#txtAccessGroupName").val("");
}
function CalculateNxtPlanNr() {
    PageMethods.GetNextPlanNr(OnGetNextPlanNr_CallBack);
}
function OnGetNextPlanNr_CallBack(value) {
    $("#txtAccessGroupNumber").val(value);
    $("#txtAccessGroupName").focus();
}
function SaveCurrentVisitorPlan() {
    var planId = ddlAccessGroupNumber.GetValue();
    var planNr = $("#txtAccessGroupNumber").val();
    var planName = $("#txtAccessGroupName").val();
    if (parseInt(planId) > 0) {
        PageMethods.SaveAccessPlanGroup(planId, planNr, planName, OnSaveVisitorPlan_CallBack);
    }
    else if (parseInt(planId) == 0) {
        PageMethods.CheckIfPlanNrExistsOnNew(planNr, CheckIfPlanNrExistsOnNew_CallBack);
    }
}

function OnSaveVisitorPlan_CallBack(result) {
    _isProfileChange = false;
    ddlAccessGroupNumber.SetEnabled(true);
    ddlAccessGroupName.SetEnabled(true);
    $("#txtAccessGroupNumber").val(result.planNr);
    $("#txtAccessGroupName").val(result.planName);
    ddlAccessGroupNumber.PerformCallback(result.ID);
    ddlAccessGroupName.PerformCallback(result.ID);
    EnableButtons();
    saveChanges = false;
}
function CheckIfPlanNrExistsOnNew_CallBack(value) {
    if (value === true) {
        alert("Besucherpläne Nr existiert");
        return;
    }
    else {
        var planId = ddlAccessGroupNumber.GetValue();
        var planNr = $("#txtAccessGroupNumber").val();
        var planName = $("#txtAccessGroupName").val();
        PageMethods.SaveAccessPlanGroup(planId, planNr, planName, OnSaveVisitorPlan_CallBack);
    }
}
function DeleteVisitor_Plan() {
    ResetDialog();
    var planId = ddlAccessGroupNumber.GetValue();
    PageMethods.DeleteAccessPlanGroup(planId, DeleteVisitorPlan_CallBack);
}
function DeleteVisitorPlan_CallBack() {
    $("#txtAccessGroupNumber").val("");
    $("#txtAccessGroupName").val("");
    var id = "0";
    ddlAccessGroupNumber.PerformCallback(id);
    ddlAccessGroupName.PerformCallback(id);
    DisableButtons();
}
function Confirm_Delete() {
    var message = "Sind Sie sicher, dass Sie diese Zutrittsgruppe löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Achtung</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnDeleteOk"  style="margin-left: 26%; margin-right: 0px;"  onclick="DeleteVisitor_Plan()"></button><button id="btnDeleteCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteAccessGroup");
    $('#btnDeleteOk').text(_message);
    getLocalizedText("cancelAccessGroupDeletion");
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
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 15%;width: 210px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
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
    var planId = ddlAccessGroupNumber.GetValue();
    var planNr = $("#txtAccessGroupNumber").val();
    var planName = $("#txtAccessGroupName").val();
    if (parseInt(planId) > 0) {
        PageMethods.SaveAccessPlanGroup(planId, planNr, planName, OnSaveVisitorPlanOnBack_CallBack);
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
        var planId = ddlAccessGroupNumber.GetValue();
        var planNr = $("#txtAccessGroupNumber").val();
        var planName = $("#txtAccessGroupName").val();
        PageMethods.SaveAccessPlanGroup(planId, planNr, planName, OnSaveVisitorPlanOnBack_CallBack);
    }
}
function No_OnBack() {
    ResetDialog();
    document.location.href = "/Index.aspx";
}
function EnableButtons() {
    $("#btnReader").prop("disabled", false);
    $("#btnAccessProfile").prop("disabled", false);
    $("#btnHoliday").prop("disabled", false);
    $("#btnReaderHeader").prop("disabled", false);
    $("#btnAccessCalederHeader").prop("disabled", false);
    $("#btnHolidayCalenderHeader").prop("disabled", false);
    $("#imageBtnAccessCalender").css('cursor', 'pointer');
    $("#btnAccessCalederHeader").css('cursor', 'pointer');
    $("#btnReaderHeader").css('cursor', 'pointer');
    $("#imageBtnReader").css('cursor', 'pointer');
    $("#imageBtnHolidayCalender").css('cursor', 'pointer');
    $("#btnHolidayCalenderHeader").css('cursor', 'pointer');
}
function DisableButtons() {
    $("#btnHolidayCalenderHeader").prop("disabled", true);
    $("#btnReader").prop("disabled", true);
    $("#btnAccessProfile").prop("disabled", true);
    $("#btnHoliday").prop("disabled", true);
    $("#btnReaderHeader").prop("disabled", true);
    $("#btnReaderHeader").css('cursor', 'default');
    $("#btnAccessCalederHeader").prop("disabled", true);
    $("#btnAccessCalederHeader").css('cursor', 'default');
    $("#imageBtnReader").css('cursor', 'default');
    $("#imageBtnAccessCalender").css('cursor', 'default');
    $("#imageBtnHolidayCalender").css('cursor', 'default');
    $("#btnHolidayCalenderHeader").css('cursor', 'default');
}