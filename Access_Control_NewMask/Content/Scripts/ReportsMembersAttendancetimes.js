$(function () {
    display_ct();
    display_cd();
    $("#HiddenField1BackValue").val("0");
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
    $("#chkenstri").change(function () {
        if ($("#chkenstri")[0].checked == false) {
            $("#chkenstri")[0].checked = true;
        }
    });
    $("#chkdepartment").change(function () {
        if ($("#chkdepartment")[0].checked == false) {
            $("#chkdepartment")[0].checked = true;
        }
    });
    $('.chkAccssDataarea').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataarea").each(function (ev) {
            this.childNodes[0].checked = true;
        });
        $("#chkenstri")[0].checked = true;
        $("#chklocation")[0].checked = false;
        $("#chkcompany")[0].checked = false;
    });
    $('.chkAccssDataareaB').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaB").each(function (ev) {
            this.childNodes[0].checked = true;
        });
        $("#chkcompany")[0].checked = true;
        $("#chkenstri")[0].checked = false;
        $("#chklocation")[0].checked = false;

    });
    $('.chkAccssDataareaC').change(function (evt) {
        $(".chkAllvar").each(function (ev) {
            this.childNodes[0].checked = false;

        });

        $(".chkAccssDataareaC").each(function (ev) {
            this.childNodes[0].checked = true;
        });
        $("#chklocation")[0].checked = true;
        $("#chkcompany")[0].checked = false;
        $("#chkenstri")[0].checked = false;

    });

    $("#chklocation").click(function () {
        if ($("#chklocation")[0].checked === true) {
            $("#chkdepartment")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
            $("#chkPersonalDate")[0].checked = false;
        }
        else if ($("#chklocation")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkdepartment").click(function () {
        if ($("#chkdepartment")[0].checked === true) {
            $("#chklocation")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
            $("#chkPersonalDate")[0].checked = false;
        }
        else if ($("#chkdepartment")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkcostcenter").click(function () {
        if ($("#chkcostcenter")[0].checked === true) {
            $("#chklocation")[0].checked = false;
            $("#chkdepartment")[0].checked = false;
            $("#chkPersonalDate")[0].checked = false;
        }
        else if ($("#chkcostcenter")[0].checked === false) {
            SetCheckAllC();
        }
    });
    $("#chkPersonalDate").click(function () {
        if ($("#chkPersonalDate")[0].checked === true) {
            $("#chklocation")[0].checked = false;
            $("#chkdepartment")[0].checked = false;
            $("#chkcostcenter")[0].checked = false;
        }
        else if ($("#chkPersonalDate")[0].checked === false) {
            SetCheckAllC();
        }
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
})
function SetCheckAllC() {
    if ($("#chklocation")[0].checked === false && $("#chkdepartment")[0].checked === false && $("#chkcostcenter")[0].checked === false && $("#chkPersonalDate")[0].checked === false) {
    }
}
function DisReports() {

    if (($('#chkVarA').is(':checked'))) {
        $(".mainBodybtm").show();
    }

    if (($('#chkVarB').is(':checked'))) {
        $(".mainBodybtmB").show();
    }

    if (($('#chkVarC').is(':checked'))) {
        $(".mainBodybtmC").show();
    }
    $(".showReportsDocViewer").hide();
    $(".ContentAreaDiv").hide();
    $(".mainBodyTop").show();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").show();
    $("#txtClientFrom").val(cboClientName.GetText());
    $("#txtClientTo").val(cboClientNameto.GetText());
    $("#txtDateFrom").val(dtpFrom.GetText());
    $("#txtDateTo").val(dtpTo.GetText());
    $("#HiddenField1BackValue").val("1");

    _sendReportSettingsToDocumentViewer();
}

function _sendReportSettingsToDocumentViewer() {
    var jsonArray = _getValuesFromControls();
    var jsonString = JSON.stringify(jsonArray);
    grdShowReport.PerformCallback(jsonString);

}
function display_cd() {

    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtdateTime").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}

function display_ct() {

    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTime").val(moment().format("HH") + ":" + moment().format("mm"));
}

function HideAllReports() {
    $(".mainBodybtmC").hide();
    $(".mainBodybtm").hide();
    $(".mainBodybtmB").hide();
    $(".mainBodyTop").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    reportType = "printReport";
}
function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".mainBodybtmC").hide();
    $(".mainBodybtm").hide();
    $(".mainBodybtmB").hide();
    $(".mainBodyTop").hide();
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").hide();
    OneTodayCallbackPanel.PerformCallback()
    $("#HiddenField1BackValue").val("3");

}
function HideAllReportsPrint() {
    if (($('#chkVarA').is(':checked'))) {
        $(".mainBodybtm").show();
    }

    if (($('#chkVarB').is(':checked'))) {
        $(".mainBodybtmB").show();
    }

    if (($('#chkVarC').is(':checked'))) {
        $(".mainBodybtmC").show();
    }
    $(".ContentAreaDiv").hide();
    $(".showReports").show();
    $(".mainBodyTop").show();
    $("#btnPrintReport").show();
    $("#btnPrintSelection").hide();
    $(".showReportsDocViewer").hide();
}
function HideTodaysReport() {
    $(".showReportsDocViewer").hide();
    $(".mainBodybtmC").hide();
    $(".mainBodybtmB").hide();
    $(".mainBodybtm").hide();
    $(".mainBodyTop").hide();
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
function cboShortTransponderPersonal(s, e) {
    var CardshortFrom = cboShortTransponder.GetValue();
    var CardshortTo = cboShortTransponderTo.GetValue();
    cboShortTransponderTo.SetValue(CardshortFrom);
}
function cboMemberGroupNr(s, e) {
    var MemberGroupFrom = cobMemberNr.GetValue();
    var MemberGroupTo = cobMemberNrTo.GetValue();
    cobMemberNrTo.SetValue(MemberGroupFrom);
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
    if (($('#chkVarA').is(':checked'))) {
        grdShowReport.PerformCallback(jsonString);
    }

    if (($('#chkVarB').is(':checked'))) {
        grdShowReportB.PerformCallback(jsonString);
    }
    if (($('#chkVarC').is(':checked'))) {
        grdShowReportC.PerformCallback(jsonString);
    }
}


function _getValuesFromControls() {

    var jsonArray = [];

    var dateFrom = moment(dtpFrom.GetDate()).isValid() ? moment(dtpFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var dateTo = moment(dtpTo.GetDate()).isValid() ? moment(dtpTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;

    var displayStudioGroupeCheckBoxKey = '';
    var displayMemberNoCheckBoxKey = '';
    var displayShortCardCheckBoxKey = '';
    var displayLongCardCheckBoxKey = '';
    if (($('#chkVarA').is(':checked'))) {
        printSelection = 0;
        displayStudioGroupeCheckBoxKey = 'chkcompany';
        displayMemberNoCheckBoxKey = 'chklocation';
        displayShortCardCheckBoxKey = 'chkcostcenter';
        displayLongCardCheckBoxKey = 'chkPersonalDate';

    }
    if (($('#chkVarB').is(':checked'))) {
        printSelection = 1;
        displayStudioGroupeCheckBoxKey = 'chkcompany';
        displayMemberNoCheckBoxKey = 'chklocation';
        displayShortCardCheckBoxKey = 'chkcostcenter';
        displayLongCardCheckBoxKey = 'chkPersonalDate';

    }
    if (($('#chkVarC').is(':checked'))) {
        printSelection = 2;
        displayStudioGroupeCheckBoxKey = 'chkcompany';
        displayMemberNoCheckBoxKey = 'chklocation';
        displayShortCardCheckBoxKey = 'chkcostcenter';
        displayLongCardCheckBoxKey = 'chkPersonalDate';

    }




    jsonArray.push({
        ID: 0,
        Nr: 0,
        Name: '',
        Type: printSelection,
        StartDate: dateFrom,
        EndDate: dateTo,
        StartMemberNo: cboClientName.GetValue(),
        EndMemberNo: cboClientNameto.GetValue(),
        StartMemberGroup: cobMemberNr.GetValue(),
        EndMemberGroup: cobMemberNrTo.GetValue(),
        StartPersonal: cmbPersName.GetValue(),
        EndPersonal: cmbPersNameTo.GetValue(),
        StartLongTranspoder: cboLongTransponder.GetValue(),
        EndLongTransponder: cboLongTransponderTo.GetValue(),
        StartShortTransponder: cboShortTransponder.GetValue(),
        EndShortTranspoder: cboShortTransponderTo.GetValue(),
        DisplayMemberGroup: $("#" + displayStudioGroupeCheckBoxKey)[0].checked,
        DisplayMemberNo: $("#" + displayMemberNoCheckBoxKey)[0].checked,
        DisplayShortTermCard: $("#" + displayShortCardCheckBoxKey)[0].checked,
        DisplayLongTermCard: $("#" + displayLongCardCheckBoxKey)[0].checked,
        StartLocationB: '',
        EndLocationB: '',
        StartBuilding: '',
        EndBuilding: '',
        StartLevel: '',
        EndLevel: '',
        StartRoom: '',
        EndRoom: '',
        StartDoor: '',
        EndDoor: '',
    });

    return jsonArray;
}