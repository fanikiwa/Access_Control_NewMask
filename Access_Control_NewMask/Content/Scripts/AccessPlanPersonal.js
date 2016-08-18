var levelCaption;
var personals = [];
var _SelectedPersonals = [];
var initialPersonalsCount;
var _isPageLoad = true;
$(function () {
    //$("#PageTitleLbl2").text = "Personen Auswahl";
    getLocalizedText("peopleSelection");
    $("#PageTitleLbl2").text(levelCaption);
    $(document).on("selectstart", false);

    DisableEnableControls();

    $("#btnFilterEmployees").click(function (e) {
        e.preventDefault();

        var selectvalFrom = $("#ddlLocationFrom option:selected").val();

        //if ((selectvalFrom === null) || (selectvalFrom === "0") || (selectvalFrom === "-1")) {
        //    $("#ddlLocationFrom").focus();

        //    return;
        //}

        //0 - None, 1 - Display, 2 - Create, 3 - Edit
        $("#hiddenFieldFormMode").attr("value", "3");

        //window.gridViewEmployee.PerformCallback();
        var buttonCode = 1;
        window.gridViewEmployee.PerformCallback(buttonCode.toString());
    });

    $("#btnSelectAll").click(function (evt) {
        evt.preventDefault();

        $("#hiddenFieldDetectChanges").attr("value", "1");

        //window.gridViewEmployee.SelectRows();
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

    $("#btnSave").click(function (e) {
        e.preventDefault();
        $("#hiddenFieldDetectChanges").attr("value", "0");

        SaveAccessPlan_Personal();
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

function SaveAccessPlan_Personal() {
    var accessPlanNumber = $("#txtAccessProfileNumber").val();
    if (parseInt(accessPlanNumber) > 0) {
        var locationId = 0;
        personals = [];
        var values = gridViewEmployee.GetSelectedKeysOnPage();
        for (var i = 0; i < values.length; i++) {
            var perNr = values[i];
            personals.push({
                Pers_Nr: perNr
            });
        }
        PageMethods.SaveAccessPlanPersonal(accessPlanNumber, locationId, personals, OnSave_CallBack);
    }
};
function OnSave_CallBack() {
    $("#hiddenFieldDetectChanges").attr("value", "0");
    var buttonCode = 0;
    gridViewEmployee.PerformCallback(buttonCode.toString());
}

function SaveChanges() {
    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "0");

    SaveAccessPlan_Personal();
}

function gridViewEmployeeSelectionChanged(s, e) {
    $("#hiddenFieldDetectChanges").attr("value", "1");

    personals = [];
    //window.gridViewEmployee.GetSelectedFieldValues("ID", GetSelectedPersonals);
    window.gridViewEmployee.GetSelectedFieldValues("EmpNumber", GetSelectedPersonals);
}

function GetSelectedPersonals(values) {
    for (var i = 0; i < values.length; i++) {
        //var personalId = values[i];
        var perNr = values[i];

        personals.push({
            //ID: personalId
            Pers_Nr: perNr
        });
    }

    var initialPersonalsCount = $("#hiddenFieldInitialPersonalsCount").attr("value");
    //if (Number(initialPersonalsCount) === Number(values.length)) {
    //    $("#hiddenFieldDetectChanges").attr("value", "0");
    //} else {
    //    $("#hiddenFieldDetectChanges").attr("value", "1");
    //}
    if (_isPageLoad === true) {
        _isPageLoad = false;
        $("#hiddenFieldDetectChanges").attr("value", "0");
}

}
function GetSelectedPersonalsCheck(values) {
    for (var i = 0; i < values.length; i++) {
        //var personalId = values[i];
        var perNr = values[i];

        _SelectedPersonals.push({
            //ID: personalId
            Pers_Nr: perNr
        });
    }
    var accessPlanNumber = $("#txtAccessProfileNumber").val();

    //var locationId = $("#ddlLocationFrom option:selected").val();
    var locationId = 0;
    if (_SelectedPersonals.length > 0) {
        PageMethods.SaveAccessPlanPersonal(accessPlanNumber, locationId, personals, OnSave_CallBack);
    } else {
        alert("Bitte treffen Sie eine Auswahl.");
    }
}

function DisableEnableControls() {
    document.getElementById("btnReader").disabled = false;
    document.getElementById("btnPersonnel").disabled = true;
    document.getElementById("btnAccessProfile").disabled = false;

    //document.getElementById("ddlAccessGroupNumber").disabled = true;
    //document.getElementById("ddlAccessGroupName").disabled = true;
    //document.getElementById("ddlAccessProfileNumber").disabled = true;
    //document.getElementById("ddlAccessProfileName").disabled = true;

    document.getElementById("txtAccessGroupNumber").disabled = true;
    document.getElementById("txtAccessGroupName").disabled = true;
    document.getElementById("txtAccessProfileNumber").disabled = true;
    document.getElementById("txtAccessProfileName").disabled = true;
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    window.gridViewEmployee.GetSelectedFieldValues("ID", GetSelectedPersonals);
});

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%;width: 130px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo" style="margin-left: 10px; width: 160px;"   onclick="No_OnBack()"></button></div></div></div></div>';
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
            var perNr = values[i];
            personals.push({
                Pers_Nr: perNr
            });
        }
        PageMethods.SaveAccessPlanPersonal(accessPlanNumber, locationId, personals, OnSaveBack_CallBack);
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
        url: "AccessPlanPersonal.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
//start ActiveEmployee
function ddlActiveEmployeeFromSelectionChanged(s, e) {
    var selectvalFrom = s.GetValue();
    var selectvalTo = ddlActiveEmployeeTo.GetValue();

    if (selectvalTo === "0" && selectvalFrom !== "0") {
        ddlActiveEmployeeTo.SetValue(selectvalFrom);
    }
}
function ddlActiveEmployeeToSelectionChanged(s, e) {
    var selectvalFrom = ddlActiveEmployeeFrom.GetValue();
    var selectvalTo = s.GetValue();

    if (selectvalFrom === "0" && selectvalTo !== "0") {
        ddlActiveEmployeeFrom.SetValue(selectvalTo);
    }
}
//end ActiveEmployee

//start Location
function ddlLocationFromSelectionChanged(s, e) {
    var selectvalFrom = s.GetValue();
    var selectvalTo = ddlLocationTo.GetValue();
    if (selectvalTo === "0" && selectvalFrom !== "0") {
        ddlLocationTo.SetValue(selectvalFrom);
    }

}
function ddlLocationToSelectionChanged(s, e) {
    var selectvalFrom = ddlLocationFrom.GetValue();
    var selectvalTo = s.GetValue();
    if (selectvalFrom === "0" && selectvalTo !== "0") {
        ddlLocationFrom.SetValue(selectvalTo);
    }

}
//end Location

//start Department
function ddlDepartmentFromSelectionChanged(s, e) {
    var selectvalFrom = s.GetValue();
    var selectvalTo = ddlDepartmentTo.GetValue();

    if (selectvalTo === "0" && selectvalFrom !== "0") {
        ddlDepartmentTo.SetValue(selectvalFrom);
    }
}

function ddlDepartmentToSelectionChanged(s, e) {
    var selectvalFrom = ddlDepartmentFrom.GetValue();
    var selectvalTo = s.GetValue();

    if (selectvalFrom === "0" && selectvalTo !== "0") {
        ddlDepartmentFrom.SetValue(selectvalTo);
    }
}
//end Department

//start CostCentre
function ddlCostCentreFromSelectionChanged(s, e) {
    var selectvalFrom = s.GetValue();
    var selectvalTo = ddlCostCentreTo.GetValue();

    if (selectvalTo === "0" && selectvalFrom !== "0") {
        ddlCostCentreTo.SetValue(selectvalFrom);
    }
}
function ddlCostCentreToSelectionChanged(s, e) {
    var selectvalFrom = ddlCostCentreFrom.GetValue();
    var selectvalTo = s.GetValue();

    if (selectvalFrom === "0" && selectvalTo !== "0") {
        ddlCostCentreFrom.SetValue(selectvalTo);
    }
}
//end CostCentre
function gridViewEmployeeInit(s, e) {
    $("#hiddenFieldDetectChanges").attr("value", "0");
}