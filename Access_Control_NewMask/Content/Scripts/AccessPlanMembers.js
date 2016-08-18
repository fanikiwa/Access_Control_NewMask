var levelCaption = "";
var members = [];
var _SelectedPersonals = [];
var initialPersonalsCount;
var _isPageLoad = true;

$(function () {

    getLocalizedText("peopleSelection");

    $("#PageTitleLbl2").text(levelCaption);

    $(document).on("selectstart", false);

    DisableEnableControls();

    $("#btnFilterEmployees").click(function (e) {
        e.preventDefault();

        var selectvalFrom = $("#ddlLocationFrom option:selected").val();

        //0 - None, 1 - Display, 2 - Create, 3 - Edit
        $("#hiddenFieldFormMode").attr("value", "3");

        window.gridViewEmployee.PerformCallback();
        var buttonCode = 1;
        window.gridViewEmployee.PerformCallback(buttonCode.toString());

    });

    $("#btnSelectAll").click(function (evt) {
        evt.preventDefault();

        $("#hiddenFieldDetectChanges").attr("value", "1");

        gridViewEmployee.SelectAllRowsOnPage();
    });

    $("#btnDeselectAll").click(function (evt) {
        evt.preventDefault();

        $("#hiddenFieldDetectChanges").attr("value", "1");

        window.gridViewEmployee.UnselectRows();
    });

    $("#btnEdit").click(function (e) {
        //0 - None, 1 - Display, 2 - Create, 3 - Edit
        $("#hiddenFieldFormMode").attr("value", "3");
    });

    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        var saveChanges = $("#hiddenFieldDetectChanges").attr("value");
        if (parseInt(saveChanges) === 1 && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {
            document.location.href = "/Content/AccessPlan.aspx";
        }
    });

    $("#btnInformation").click(function (evt) {
        evt.preventDefault();

    });

});

function SaveAccessPlan_Member() {
    var accessPlanNumber = $("#txtAccessProfileNumber").val();
    if (parseInt(accessPlanNumber) > 0) {
        var locationId = 0;
        PageMethods.SaveAccessPlanMember(accessPlanNumber, locationId, members, OnSave_CallBack, OnFailSave_CallBack);
    }
};

function OnSave_CallBack() {
    var buttonCode = 0;
    gridViewEmployee.PerformCallback(buttonCode.toString());
}

function OnFailSave_CallBack(error) {
    alert(error);
}

function SaveChanges() {
    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "999");

    SaveAccessPlan_Member();
}

function gridViewEmployeeSelectionChanged(s, e) {
    $("#hiddenFieldDetectChanges").attr("value", "1");

    members = [];

    window.gridViewEmployee.GetSelectedFieldValues("ID", GetSelectedMembers);
}

function GetSelectedMembers(values) {
    for (var i = 0; i < values.length; i++) {
        var ID = values[i];

        members.push({
            ID: ID
        });
    }

    var initialPersonalsCount = $("#hiddenFieldInitialPersonalsCount").attr("value");

    if (_isPageLoad === true) {
        _isPageLoad = false;
        $("#hiddenFieldDetectChanges").attr("value", "0");
    }

}

function GetSelectedMembersCheck(values) {
    for (var i = 0; i < values.length; i++) {
        var ID = values[i];

        _SelectedPersonals.push({
            ID: ID
        });
    }
    var accessPlanNumber = $("#txtAccessProfileNumber").val();

    var locationId = 0;
    if (_SelectedPersonals.length > 0) {
        PageMethods.SaveAccessPlanMember(accessPlanNumber, locationId, members, OnSave_CallBack);
    } else {
        alert("Bitte treffen Sie eine Auswahl.");
    }
}

function DisableEnableControls() {

    document.getElementById("btnReader").disabled = false;
    document.getElementById("btnMembers").disabled = true;
    document.getElementById("btnAccessProfile").disabled = false;

    document.getElementById("txtAccessGroupNumber").disabled = true;
    document.getElementById("txtAccessGroupName").disabled = true;
    document.getElementById("txtAccessProfileNumber").disabled = true;
    document.getElementById("txtAccessProfileName").disabled = true;
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    window.gridViewEmployee.GetSelectedFieldValues("ID", GetSelectedMembers);

    $("#btnSave").click(function (e) {
        e.preventDefault();
        $("#hiddenFieldDetectChanges").attr("value", "0");

        SaveAccessPlan_Member();
    });

});

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%;width: 130px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo" style="margin-left: 10px;width: 160px;"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
function CancelOnBackButton() {
    HideDialog();
}

function No_OnBack() {
    HideDialog();
    document.location.href = "/Content/AccessPlan.aspx";
}

function HideDialog() {
    document.getElementById("importantDialog").innerHTML = "";
}

function SaveOnBack() {

    HideDialog();

    var accessPlanNumber = $("#txtAccessProfileNumber").val();

    if (parseInt(accessPlanNumber) > 0) {

        var locationId = 0;

        personals = [];

        var values = gridViewEmployee.GetSelectedKeysOnPage();

        for (var i = 0; i < values.length; i++) {
            var ID = values[i];
            members.push({
                ID: ID
            });
        }

        PageMethods.SaveAccessPlanMember(accessPlanNumber, locationId, members, OnSaveBack_CallBack);
    }

}

function OnSaveBack_CallBack() {
    document.location.href = "/Content/AccessPlan.aspx";
}

function getLocalizedText(key) {
    var data = { key: key };
    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanMembers.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

//start MemberGroup
function ddlMemberGroupFromSelectionChanged(s, e) {

    var selectvalFrom = s.GetValue();
    var selectvalTo = ddlMemberGroupTo.GetValue();

    if (selectvalTo === "0" && selectvalFrom !== "0") {
        ddlMemberGroupTo.SetValue(selectvalFrom);
    }
}

function ddlMemberGroupToSelectionChanged(s, e) {

    var selectvalFrom = ddlbMemberGroupFrom.GetValue();
    var selectvalTo = s.GetValue();

    if (selectvalFrom === "0" && selectvalTo !== "0") {
        ddlbMemberGroupFrom.SetValue(selectvalTo);
    }
}

//end MemberGroup

//start Member
function ddlMemberFromSelectionChanged(s, e) {

    var selectvalFrom = s.GetValue();
    var selectvalTo = ddlMemberTo.GetValue();

    if (selectvalTo === "0" && selectvalFrom !== "0") {
        ddlMemberTo.SetValue(selectvalFrom);
    }

}

function ddlMemberToSelectionChanged(s, e) {

    var selectvalFrom = ddlMemberFrom.GetValue();
    var selectvalTo = s.GetValue();

    if (selectvalFrom === "0" && selectvalTo !== "0") {
        ddlMemberFrom.SetValue(selectvalTo);
    }

}

//end Member

function gridViewEmployeeInit(s, e) {
    $("#hiddenFieldDetectChanges").attr("value", "0");
}