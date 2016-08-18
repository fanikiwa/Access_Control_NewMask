$(document).ready(function () {
    $("#HiddenField1BackValue").val("0");
    display_ct();
    display_cd();
    $('#btnBack').on("click", function (e) {
        e.preventDefault();
        if ($("#HiddenField1BackValue").val() === "0") {
            var saveChanges = $('#hiddenFieldSaveChanges').val();
            if (saveChanges === "1") {
            }
            else {
                window.location.href = "/Content/AccReports.aspx";
            }
        }
        else if ($("#HiddenField1BackValue").val() === "1") {
            HideTodaysReport();
            $("#HiddenField1BackValue").val("0");
        }
        else if ($("#HiddenField1BackValue").val() === "2") {
            HideAllReports();
            $("#HiddenField1BackValue").val("0");
        }
        else if ($("#HiddenField1BackValue").val() === "3") {
            HideAllReportsPrint();
            $("#HiddenField1BackValue").val("2");
        }
    });
    $('#btnPrintSelection').click(function (e) {
        e.preventDefault();
        DisReports();
    });
    $("#btnPrintReport").click(function (evt) {
        evt.preventDefault();
        DispReportToday();
    });
    $("#imgPotrait").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLand").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgPotraiB").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLandB").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgPotraitC").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLandC").click(function (evt) {
        evt.preventDefault();
    });
    $("#chkPortrait").click(function () {
        if ($("#chkPortrait")[0].checked === true) {
            $("#chkLandScape")[0].checked = false;

        }
        else if ($("#chkPortrait")[0].checked === false) {
            $("#chkLandScape")[0].checked = true;
        }
    });
    $("#chkLandScape").click(function () {
        if ($("#chkLandScape")[0].checked === true) {
            $("#chkPortrait")[0].checked = false;

        }
        else if ($("#chkLandScape")[0].checked === false) {
            $("#chkPortrait")[0].checked = true;

        }
    });

    $("#chkVarientBPotrait").click(function () {
        if ($("#chkVarientBPotrait")[0].checked === true) {
            $("#chkVarientBLand")[0].checked = false;

        }
        else if ($("#chkVarientBPotrait")[0].checked === false) {
            $("#chkVarientBLand")[0].checked = true;
        }
    });
    $("#chkVarientBLand").click(function () {
        if ($("#chkVarientBLand")[0].checked === true) {
            $("#chkVarientBPotrait")[0].checked = false;

        }
        else if ($("#chkVarientBLand")[0].checked === false) {
            $("#chkVarientBPotrait")[0].checked = true;

        }
    });

    $("#chkVarCPotait").click(function () {
        if ($("#chkVarCPotait")[0].checked === true) {
            $("#chkVarCLand")[0].checked = false;

        }
        else if ($("#chkVarCPotait")[0].checked === false) {
            $("#chkVarCLand")[0].checked = true;
        }
    });
    $("#chkVarCLand").click(function () {
        if ($("#chkVarCLand")[0].checked === true) {
            $("#chkVarCPotait")[0].checked = false;

        }
        else if ($("#chkVarCLand")[0].checked === false) {
            $("#chkVarCPotait")[0].checked = true;

        }
    });
    $('.chkAccssDataarea').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataarea").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#chkname")[0].checked = true;
            $("#chkcostcenter")[0].checked = false;
            $("#chkcompany")[0].checked = false;
            $("#chklocation")[0].checked = false;
            $("#chkdepartment")[0].checked = false;
            $("#chkaust")[0].checked = false;
            $("#chkenstri")[0].checked = false;

        });
    });

    $("#chkPersonalDate").click(function () {
        if ($("#chkPersonalDate")[0].checked === true) {
            $("#chkname")[0].checked = false;
        }
        else if ($("#chkPersonalDate")[0].checked === false) {
            SetCheckAll();
        }
    });
    $("#chkname").click(function () {
        if ($("#chkname")[0].checked === true) {
            $("#chkPersonalDate")[0].checked = false;
        }
        else if ($("#chkname")[0].checked === false) {
            SetCheckAll();
        }
    });
    $('.chkAccssDataareaB').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaB").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#chkname")[0].checked = false;
            $("#chkcostcenter")[0].checked = true;
            $("#chkPersonalDate")[0].checked = false;
            $("#chkname")[0].checked = false;
            $("#chkcompany")[0].checked = false;
            $("#chkaust")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        });

    });
    $("#chkcostcenter").click(function () {
        if ($("#chkcostcenter")[0].checked === true) {
            $("#chkdepartment")[0].checked = false;
            $("#chklocation")[0].checked = false;
        }
        else if ($("#chkcostcenter")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $("#chkdepartment").click(function () {
        if ($("#chkdepartment")[0].checked === true) {
            $("#chkcostcenter")[0].checked = false;
            $("#chklocation")[0].checked = false;
        }
        else if ($("#chkdepartment")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $("#chklocation").click(function () {
        if ($("#chklocation")[0].checked === true) {
            $("#chkdepartment")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
        }
        else if ($("#chklocation")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $('.chkAccssDataareaClast').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaClast").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#chkcompany")[0].checked = true;
            $("#chkname")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
            $("#chklocation")[0].checked = false;
            $("#chkdepartment")[0].checked = false;
            $("#chkname")[0].checked = false;
            $("#chkPersonalDate")[0].checked = false;
        });

    });
    $("#chkcompany").click(function () {
        if ($("#chkcompany")[0].checked === true) {
            $("#chkaust")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        }
        else if ($("#chkcompany")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkaust").click(function () {
        if ($("#chkaust")[0].checked === true) {
            $("#chkcompany")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        }
        else if ($("#chkaust")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkenstri").click(function () {
        if ($("#chkenstri")[0].checked === true) {
            $("#chkcompany")[0].checked = false;
            $("#chkaust")[0].checked = false;
        }
        else if ($("#chkenstri")[0].checked === false) {
            SetCheckAllC();
        }
    });
})
function SetCheckAll() {
    if ($("#chkname")[0].checked === false && $("#chkPersonalDate")[0].checked === false) {
    }
}
function SetCheckAllB() {
    if ($("#chkcostcenter")[0].checked === false && $("#chkdepartment")[0].checked === false && $("#chklocation")[0].checked === false) {
    }
}
function SetCheckAllC() {
    if ($("#chkcompany")[0].checked === false && $("#chkaust")[0].checked === false && $("#chkenstri")[0].checked === false) {
    }
}
function DisReports() {

    if (($('#chkVariableA').is(':checked'))) {
        $(".showReports").show();
    }

    if (($('#chkVaribleB').is(':checked'))) {
        $(".showReportsVarB").show();
    }

    if (($('#chkVaribleC').is(':checked'))) {
        $(".showReportsVarC").show();
    }
    $(".showReportsDocViewer").hide();
    $(".ContentAreaDiv").hide();
    //$(".showReports").show();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").show();
    $("#HiddenField1BackValue").val("1");

    $("#txtClientFrom").val(cboClientName.GetText());
    $("#txtClientTo").val(cboClientNameto.GetText());
    $("#txtClientBFrom").val(cboClientName.GetText());
    $("#txtClientBTo").val(cboClientNameto.GetText());
    $("#txtClientCFrom").val(cboClientName.GetText());
    $("#txtClientCTo").val(cboClientNameto.GetText());
    $("#txtLocFrom").val(cbolocationPersonalFrm.GetText());
    $("#txtLocTo").val(cbolocationPersonalTo.GetText());
    $("#txtLocationBFrom").val(cbolocationPersonalFrm.GetText());
    $("#txtLocationBTo").val(cbolocationPersonalTo.GetText());
    $("#txtLocationCFrom").val(cbolocationPersonalFrm.GetText());
    $("#txtLocationCTo").val(cbolocationPersonalTo.GetText());
    $("#txtDeptBFrom").val(cboDeptName.GetText());
    $("#txtDeptBTo").val(cboDeptNameTo.GetText());
    $("#txtDept").val(cboDeptName.GetText());
    $("#txtDeptTo").val(cboDeptNameTo.GetText());
    $("#txtDeptCFrom").val(cboDeptName.GetText());
    $("#txtDeptCTo").val(cboDeptNameTo.GetText());
    $("#txtCostCenterFrom").val(cboCostCenterName.GetText());
    $("#txtCostCenterTo").val(cboCostCenterNameTo.GetText());
    $("#txtCostBFrom").val(cboCostCenterName.GetText());
    $("#txtCostBTo").val(cboCostCenterNameTo.GetText());
    $("#txtCostCFrom").val(cboCostCenterName.GetText());
    $("#txtCoastCTo").val(cboCostCenterNameTo.GetText());
    $("#txtDateFrom").val(dtpFrom.GetText());
    $("#txtDateTo").val(dtpTo.GetText());
    $("#txtDateBFrom").val(dtpFrom.GetText());
    $("#txtDateBTo").val(dtpTo.GetText());
    $("#txtDateCFrom").val(dtpFrom.GetText());
    $("#txtDateCTo").val(dtpTo.GetText());

    _sendReportSettingsToDocumentViewer();
}
function display_cd() {

    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtdateTime").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtTodayDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtTodayDateC").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}

function display_ct() {

    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTodayTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTodayTimeC").val(moment().format("HH") + ":" + moment().format("mm"));
}

function HideAllReports() {
    $(".showReports").hide();
    $(".showReportsVarB").hide();
    $(".showReportsVarC").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    reportType = "printReport";
}
function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".showReportsVarB").hide();
    $(".showReportsVarC").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").hide();
    OneTodayCallbackPanel.PerformCallback()
    $("#HiddenField1BackValue").val("3");

}
function HideAllReportsPrint() {
    if (($('#chkVariableA').is(':checked'))) {
        $(".showReports").show();
    }

    if (($('#chkVaribleB').is(':checked'))) {
        $(".showReportsVarB").show();
    }

    if (($('#chkVaribleC').is(':checked'))) {
        $(".showReportsVarC").show();
    }
    $(".ContentAreaDiv").hide();
    $("#btnPrintReport").show();
    $("#btnPrintSelection").hide();
    $(".showReportsDocViewer").hide();
}
function HideTodaysReport() {
    $(".showReportsDocViewer").hide();
    $(".showReports").hide();
    $(".showReportsVarB").hide();
    $(".showReportsVarC").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    $("#HiddenField1BackValue").val("0");
}

function cboClientNamePersonal(s, e) {
    var locFrom = cboClientName.GetValue();
    var locTo = cboClientNameto.GetValue();
    cboClientNameto.SetValue(locFrom);

}
function cboDeptNamePersonal(s, e) {
    var locFrom = cboDeptName.GetValue();
    var locTo = cboDeptNameTo.GetValue();
    cboDeptNameTo.SetValue(locFrom);


}
function cboCostCenterNamePersonal(s, e) {
    var locFrom = cboCostCenterName.GetValue();
    var locTo = cboCostCenterNameTo.GetValue();
    cboCostCenterNameTo.SetValue(locFrom);


}
function cmbPersNamePersonal(s, e) {
    var locFrom = cmbPersName.GetValue();
    var locTo = cmbPersNameTo.GetValue();
    cmbPersNameTo.SetValue(locFrom);


}
function cboLongTransponderePersonal(s, e) {
    var CardFrom = cboLongTransponder.GetValue();
    var CardTo = cboLongTransponderTo.GetValue();
    cboLongTransponderTo.SetValue(CardFrom);


}
function cbolocationPersonal(s, e) {
    var locFrom = cbolocationPersonalFrm.GetValue();
    var locTo = cbolocationPersonalTo.GetValue();
    cbolocationPersonalTo.SetValue(locFrom);
}
function cboPersonalIDSelected(s, e) {
    var PerIDFrom = cboPersonalID.GetValue();
    var PersIDTo = cmbIDNrTo.GetValue();
    cmbIDNrTo.SetValue(PerIDFrom);
}
function drpPlanDateFromChanged(s, e, _target) {
    var setDate = moment(s.GetDate());
    var targetDate = moment(_target.GetDate());

    if (setDate.isValid() && !targetDate.isValid()) {
        _target.SetDate(setDate.toDate());
    }
    else if (setDate.isValid() && targetDate < setDate.toDate()) {
        _target.SetDate(setDate.toDate());
    }
}
function drpPlanDateToChanged(s, e) {
    var setDate = moment(s.GetDate());
    var targetDate = moment(dtpFrom.GetDate());

    if (setDate.isValid() && !targetDate.isValid()) {
        dtpFrom.SetDate(setDate.toDate());
    }
    else if (setDate.isValid() && targetDate > setDate.toDate()) {
        dtpFrom.SetDate(setDate.toDate());
    } else {
        return;
    }
}

function _sendReportSettingsToDocumentViewer() {
    var jsonArray = _getValuesFromControls();
    var jsonString = JSON.stringify(jsonArray);
    if (($('#chkVariableA').is(':checked'))) {
        grdShowReport.PerformCallback(jsonString);
    }

    if (($('#chkVaribleB').is(':checked'))) {
        grdVarialeB.PerformCallback(jsonString);
    }
    if (($('#chkVaribleC').is(':checked'))) {
        grdVaribleC.PerformCallback(jsonString);
    }

}


function _getValuesFromControls() {

    var jsonArray = [];

    var dateFrom = moment(dtpFrom.GetDate()).isValid() ? moment(dtpFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var dateTo = moment(dtpTo.GetDate()).isValid() ? moment(dtpTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var printSelection = 0;
    var displayClientCheckBoxKey = '';
    var displayLocationCheckBoxKey = '';
    var displayDepartmentCheckBoxKey = '';
    var displayCostCenterCheckBoxKey = '';
    var displayLongTermCardCheckBoxKey = '';
    var displayPersonalIdCheckBoxKey = '';
    if (($('#chkVariableA').is(':checked'))) {
        printSelection = 0;
        displayClientCheckBoxKey = 'chkPersonalDate';
        displayLocationCheckBoxKey = 'chkcostcenter';
        displayDepartmentCheckBoxKey = 'chkdepartment';
        displayCostCenterCheckBoxKey = 'chklocation';
        displayPersonalIdCheckBoxKey = 'chkaust';
        displayLongTermCardCheckBoxKey = 'chkenstri';


    }

    if (($('#chkVaribleB').is(':checked'))) {
        printSelection = 1;
        displayClientCheckBoxKey = 'chkPersonalDate';
        displayLocationCheckBoxKey = 'chkcostcenter';
        displayDepartmentCheckBoxKey = 'chkdepartment';
        displayCostCenterCheckBoxKey = 'chklocation';
        displayPersonalIdCheckBoxKey = 'chkaust';
        displayLongTermCardCheckBoxKey = 'chkenstri';


    }
    if (($('#chkVaribleC').is(':checked'))) {
        printSelection = 2;
        displayClientCheckBoxKey = 'chkPersonalDate';
        displayLocationCheckBoxKey = 'chkcostcenter';
        displayDepartmentCheckBoxKey = 'chkdepartment';
        displayCostCenterCheckBoxKey = 'chklocation';
        displayPersonalIdCheckBoxKey = 'chkaust';
        displayLongTermCardCheckBoxKey = 'chkenstri';


    }
    jsonArray.push({
        ID: 0,
        Nr: 0,
        Name: '',
        Type: printSelection,
        StartDate: dateFrom,
        EndDate: dateTo,
        StartClient: cboClientName.GetValue(),
        EndClient: cboClientNameto.GetValue(),
        StartLocation: cbolocationPersonalFrm.GetValue(),
        EndLocation: cbolocationPersonalTo.GetValue(),
        StartDept: cboDeptName.GetValue(),
        EndDept: cboDeptNameTo.GetValue(),
        StartCostCenter: cboCostCenterName.GetValue(),
        EndCostCenter: cboCostCenterNameTo.GetValue(),
        StartPersonal: cmbPersName.GetValue(),
        EndPersonal: cmbPersNameTo.GetValue(),
        StartLongTranspoder: cboLongTransponder.GetValue(),
        EndLongTransponder: cboLongTransponderTo.GetValue(),
        DisplayClient: $("#" + displayClientCheckBoxKey)[0].checked,
        DisplayLocation: $("#" + displayLocationCheckBoxKey)[0].checked,
        DisplayDepartment: $("#" + displayDepartmentCheckBoxKey)[0].checked,
        DisplayCostCenter: $("#" + displayCostCenterCheckBoxKey)[0].checked,
        DisplayLongTermCard: $("#" + displayLongTermCardCheckBoxKey)[0].checked,
        DisplayPersonalID: $("#" + displayPersonalIdCheckBoxKey)[0].checked,
    });

    return jsonArray;
}