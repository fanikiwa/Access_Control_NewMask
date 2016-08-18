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
    $('.chkAccssDataareaA').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaA").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#chkname ")[0].checked = true;
            $("#chkaus ")[0].checked = false;
            $("#chkPersonalDate ")[0].checked = false;
        });
    });

    $("#chkname").click(function () {
        if ($("#chkname")[0].checked === true) {
            $("#chkid ")[0].checked = false;
        }
        else if ($("#chkname")[0].checked === false) {
            SetCheckAll();
        }
    });
    $("#chkid").click(function () {
        if ($("#chkid")[0].checked === true) {
            $("#chkname")[0].checked = false;
        }
        else if ($("#chkid")[0].checked === false) {
            SetCheckAll();
        }
    });
    $('.chkAccssDataareaB').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaB").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#chkname ")[0].checked = false;
            $("#chkaus ")[0].checked = true;
            $("#chkPersonalDate ")[0].checked = false;
        });

    });
    $("#chkaus").click(function () {
        if ($("#chkaus")[0].checked === true) {
            $("#chkgul")[0].checked = false;
            $("#chkenstri2")[0].checked = false;
            $("#chkenstri3")[0].checked = false;
        }
        else if ($("#chkaus")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $("#chkgul").click(function () {
        if ($("#chkgul")[0].checked === true) {
            $("#chkaus")[0].checked = false;
            $("#chkenstri2")[0].checked = false;
            $("#chkenstri3")[0].checked = false;

        }
        else if ($("#chkgul")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $("#chkenstri2").click(function () {
        if ($("#chkenstri2")[0].checked === true) {
            $("#chkaus")[0].checked = false;
            $("#chkgul")[0].checked = false;
            $("#chkenstri3")[0].checked = false;
        }
        else if ($("#chkenstri2")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $("#chkenstri3").click(function () {
        if ($("#chkenstri3")[0].checked === true) {
            $("#chkaus")[0].checked = false;
            $("#chkgul")[0].checked = false;
            $("#chkenstri2")[0].checked = false;
        }
        else if ($("#chkenstri3")[0].checked === false) {
            SetCheckAllB();
        }
    });
    $('.chkAccssDataareaClast').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaClast").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#chkname ")[0].checked = false;
            $("#chkaus ")[0].checked = false;
            $("#chkPersonalDate ")[0].checked = true;
        });

    });
    $("#chkPersonalDate").click(function () {
        if ($("#chkPersonalDate")[0].checked === true) {
            $("#chkcostcenter")[0].checked = false;
            $("#chkdepartment")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        }
        else if ($("#chkPersonalDate")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkcostcenter").click(function () {
        if ($("#chkcostcenter")[0].checked === true) {
            $("#chkPersonalDate")[0].checked = false;
            $("#chkdepartment")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        }
        else if ($("#chkcostcenter")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkdepartment").click(function () {
        if ($("#chkdepartment")[0].checked === true) {
            $("#chkPersonalDate")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        }
        else if ($("#chkdepartment")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkenstri").click(function () {
        if ($("#chkenstri")[0].checked === true) {
            $("#chkPersonalDate")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
            $("#chkenstri")[0].checked = false;
        }
        else if ($("#chkdepartment")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#btnPrintReport").click(function (evt) {
        evt.preventDefault();
        DispReportToday();
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
})
function SetCheckAll() {
    if ($("#chkid ")[0].checked === false && $("#chkname ")[0].checked === false) {
    }
}
function SetCheckAllB() {
    if ($("#chkaus")[0].checked === false && $("#chkgul")[0].checked === false && $("#chkenstri2")[0].checked === false && $("#chkenstri3")[0].checked === false) {
    }
}
function SetCheckAllC() {
    if ($("#chkdepartment")[0].checked === false && $("#chkPersonalDate")[0].checked === false && $("#chkcostcenter")[0].checked === false && $("#chkenstri")[0].checked === false) {
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

    $("#txtClientFrom").val(cboClientFrom.GetText());
    $("#txtClientTo").val(cboClientTo.GetText());
    $("#txtClientBFrom").val(cboClientFrom.GetText());
    $("#txtClientBTo").val(cboClientTo.GetText());
    $("#txtClientCFrom").val(cboClientFrom.GetText());
    $("#txtClientCTo").val(cboClientTo.GetText());

    $("#txtLocFrom").val(cboClientName.GetText());
    $("#txtLocTo").val(cboClientNameto.GetText());
    $("#txtLocationBFrom").val(cboClientName.GetText());
    $("#txtLocationBTo").val(cboClientNameto.GetText());
    $("#txtLocationCFrom").val(cboClientName.GetText());
    $("#txtLocationCTo").val(cboClientNameto.GetText());

    $("#txtLocFrom").val(cboLocatiomFrom.GetText());
    $("#txtLocTo").val(cboLocationTo.GetText());
    $("#txtLocationBFrom").val(cboLocatiomFrom.GetText());
    $("#txtLocationBTo").val(cboLocationTo.GetText());
    $("#txtLocationCFrom").val(cboLocatiomFrom.GetText());
    $("#txtLocationCTo").val(cboLocationTo.GetText());
    $("#txtDeptBFrom").val(cboDeptFrom.GetText());
    $("#txtDeptBTo").val(cboDeptTo.GetText());
    $("#txtDept").val(cboDeptFrom.GetText());
    $("#txtDeptTo").val(cboDeptTo.GetText());
    $("#txtDeptCFrom").val(cboDeptFrom.GetText());
    $("#txtDeptCTo").val(cboDeptTo.GetText());
    $("#txtCostCenterFrom").val(cboCostCenterFrom.GetText());
    $("#txtCostCenterTo").val(cboCoastCenterTo.GetText());
    $("#txtCostBFrom").val(cboCostCenterFrom.GetText());
    $("#txtCostBTo").val(cboCoastCenterTo.GetText());
    $("#txtCostCFrom").val(cboCostCenterFrom.GetText());
    $("#txtCoastCTo").val(cboCoastCenterTo.GetText());
    $("#txtDateFrom").val(dtpFrom.GetText());
    $("#txtDateTo").val(dtpTo.GetText());
    $("#txtDateBFrom").val(dtpFrom.GetText());
    $("#txtDateBTo").val(dtpTo.GetText());
    $("#txtDateCFrom").val(dtpFrom.GetText());
    $("#txtDateCTo").val(dtpTo.GetText());

    $("#txtLocFrom").val(cboClientName.GetText());
    $("#txtLocTo").val(cboClientNameto.GetText());

    $("#txtLocationBFrom").val(cboClientName.GetText());
    $("#txtLocationBTo").val(cboClientNameto.GetText());

    $("#txtLocationCFrom").val(cboClientName.GetText());
    $("#txtLocationCTo").val(cboClientNameto.GetText());
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
function cboClientFromSelectedIndex(s, e) {
    var locFrom = cboClientFrom.GetValue();
    var locTo = cboClientTo.GetValue();
    cboClientTo.SetValue(locFrom);

}
function cboDeptNamePersonal(s, e) {
    var locFrom = cboDeptFrom.GetValue();
    var locTo = cboDeptTo.GetValue();
    cboDeptTo.SetValue(locFrom);


}
function cboCostCenterNamePersonal(s, e) {
    var locFrom = cboCostCenterFrom.GetValue();
    var locTo = cboCoastCenterTo.GetValue();
    cboCoastCenterTo.SetValue(locFrom);


}
function cmbPersNamesSelectedIndex(s, e) {
    var locFrom = cmbPersName.GetValue();
    var locTo = cboPersNameTo.GetValue();
    cboPersNameTo.SetValue(locFrom);


}
function cboClientNamePersonal(s, e) {
    var clientFrom = cboClientName.GetValue();
    var clientTo = cboClientNameto.GetValue();
    cboClientNameto.SetValue(clientFrom);


}
function cboShortTransponderPersonal(s, e) {
    var CardFrom = cboShortTransponder.GetValue();
    var CardTo = cboShortTransponderTo.GetValue();
    cboShortTransponderTo.SetValue(CardFrom);


}
function cbolocationPersonal(s, e) {
    var locFrom = cboLocatiomFrom.GetValue();
    var locTo = cboLocationTo.GetValue();
    cboLocationTo.SetValue(locFrom);
}
function cboVisitorIDFromSelected(s, e) {
    var PerIDFrom = cboVisitorIDFrom.GetValue();
    var PersIDTo = cboVisitorIDTO.GetValue();
    cboVisitorIDTO.SetValue(PerIDFrom);
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
    var timeFrom = moment(TimeFrom.GetDate()).isValid() ? moment(TimeFrom.GetDate()).format("YYYY-MM-DDTHH:mm:00.000"): null;
    var timeTo = moment(TimeTo.GetDate()).isValid() ? moment(TimeTo.GetDate()).format("YYYY-MM-DDTHH:mm:00.000") : null;

    var displayClientCheckBoxKey = '';
    var displayLocationCheckBoxKey = '';
    var displayDepartmentCheckBoxKey = '';
    var displayCostCenterCheckBoxKey = '';
    var displayLongTermCardCheckBoxKey = '';
    var displayPersonalIdCheckBoxKey = '';
    if (($('#chkVariableA').is(':checked'))) {
        printSelection = 0;
        displayClientCheckBoxKey = 'chkname';
        displayLocationCheckBoxKey = 'chkid ';
        displayDepartmentCheckBoxKey = 'chkaus     ';
        displayCostCenterCheckBoxKey = 'chkgul';
        displayPersonalIdCheckBoxKey = 'chkenstri2';
        displayLongTermCardCheckBoxKey = 'chkenstri3';


    }

    if (($('#chkVaribleB').is(':checked'))) {
        printSelection = 1;
        displayClientCheckBoxKey = 'chkname';
        displayLocationCheckBoxKey = 'chkid ';
        displayDepartmentCheckBoxKey = 'chkaus     ';
        displayCostCenterCheckBoxKey = 'chkgul';
        displayPersonalIdCheckBoxKey = 'chkenstri2';
        displayLongTermCardCheckBoxKey = 'chkenstri3';


    }
    if (($('#chkVaribleC').is(':checked'))) {
        printSelection = 2;
        displayClientCheckBoxKey = 'chkname';
        displayLocationCheckBoxKey = 'chkid ';
        displayDepartmentCheckBoxKey = 'chkaus     ';
        displayCostCenterCheckBoxKey = 'chkgul';
        displayPersonalIdCheckBoxKey = 'chkenstri2';
        displayLongTermCardCheckBoxKey = 'chkenstri3';


    }
    jsonArray.push({
        ID: 0,
        Nr: 0,
        Name: '',
        Type: printSelection,
        StartDate: dateFrom,
        EndDate: dateTo,
        StartTime: timeFrom,
        EndTime: timeTo,
        StartClient: cboClientFrom.GetValue(),
        EndClient: cboClientTo.GetValue(),
        StartLocation: cboLocatiomFrom.GetValue(),
        EndLocation: cboLocationTo.GetValue(),
        StartDept: cboDeptFrom.GetValue(),
        EndDept: cboDeptTo.GetValue(),
        StartCostCenter: cboCostCenterFrom.GetValue(),
        EndCostCenter: cboCoastCenterTo.GetValue(),
        StartPersonal: cmbPersName.GetValue(),
        EndPersonal: cboPersNameTo.GetValue(),
        StartLongTranspoder: cboShortTransponder.GetValue(),
        EndLongTransponder: cboShortTransponderTo.GetValue(),
        DisplayClient: $("#" + displayClientCheckBoxKey)[0].checked,
        DisplayLocation: $("#" + displayLocationCheckBoxKey)[0].checked,
        DisplayDepartment: $("#" + displayDepartmentCheckBoxKey)[0].checked,
        DisplayCostCenter: $("#" + displayCostCenterCheckBoxKey)[0].checked,
        DisplayLongTermCard: $("#" + displayLongTermCardCheckBoxKey)[0].checked,
        DisplayPersonalID: $("#" + displayPersonalIdCheckBoxKey)[0].checked,
    });

    return jsonArray;
}