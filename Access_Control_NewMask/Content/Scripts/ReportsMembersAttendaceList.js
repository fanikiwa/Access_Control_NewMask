
$(document).ready(function () {
    $("#HiddenField1BackValue").val("0");

    $("#chkMemberDate").attr("disabled", true);
    $("#chkMemberName").attr("disabled", true);

    $('#chkAbsencesOnly').change(function (ev) {
        if (this.checked) {
            $(".chkSwitch").each(function (ev) {
                this.childNodes[0].checked = false;
            });

            //printType
            this.checked = true;
        }
        else {
            $("#chkAbsencesOnly").each(function (ev) {
                this.childNodes[0].checked = true;

            });
            this.checked = true;
        }
    });

    $('#chkPresentOnly').change(function (ev) {
        if (this.checked) {
            $(".chkSwitch").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;

        }
        else {
            $("#chkPresentOnly").each(function (ev) {
                this.childNodes[0].checked = true;

            });
        }
    });

    $('#chkAllBookings').change(function (ev) {
        if (this.checked) {
            $(".chkSwitch").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;
        }
        else {
            $("#chkAllBookings").each(function (ev) {
                this.childNodes[0].checked = true;

            });
        }
    });

    $("#btnPrintAttendance").click(function (evt) {
        evt.preventDefault();
        DisReports();
    });

    $("#imgPotrait").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLand").click(function (evt) {
        evt.preventDefault();
    });

    $("#btnPrintReport").click(function (evt) {
        evt.preventDefault();
        DispReportToday();
    });

    $('#btnBack').on("click", function (e) {
        e.preventDefault();
        if ($("#HiddenField1BackValue").val() === "0") {
            window.location.href = "/Content/AccReports.aspx";
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

    $("#btnQuickPrint").click(function (evt) {
        evt.preventDefault();
        DisplayQuickPrintReport();
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

    display_cd();
    display_ct();
})

function cboStudioGroupSelectionChanged(s, e) {
    var grpFrom = cboStudioGroupFrom.GetValue();
    var grpTo = cboStudioGroupTo.GetValue();
    cboStudioGroupTo.SetValue(grpFrom);
}

//chkSwitch

function DisReports() {

    $(".ContentAreaDiv").hide();
    $(".showReports").show();

    $("#btnNew").hide();
    $("#btnPrintAttendance").hide();
    $("#btnPrintReport").show();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();

    $("#txtMemberGroupFrom").val(cboStudioGroupFrom.GetText());
    $("#txtMemberGroupTo").val(cboStudioGroupTo.GetText());

    $("#txtPrintDateFrom").val(dtPrintDateFrom.GetText());
    $("#txtPrintDateTo").val(dtPrintDateTo.GetText());

    $("#HiddenField1BackValue").val("1");
    _sendReportSettingsToDocumentViewer();
}

function DisplayQuickPrintReport() {

    $(".ContentAreaDiv").hide();
    $(".showReports").show();

    $("#btnNew").hide();
    $("#btnPrintAttendance").hide();
    $("#btnPrintReport").show();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();

    $("#txtMemberGroupFrom").val(cboStudioGroupFrom.GetText());
    $("#txtMemberGroupTo").val(cboStudioGroupTo.GetText());

    $("#txtPrintDateFrom").val(dtPrintDateMain.GetText());
    $("#txtPrintDateTo").val(dtPrintDateMain.GetText());

    $("#HiddenField1BackValue").val("1");
    _sendReportSettingsToDocumentViewerForQuickPrint();
}

function _sendReportSettingsToDocumentViewer() {
    var jsonArray = _getValuesFromControls();
    var jsonString = JSON.stringify(jsonArray);

    grdDisplayMemberAttendance.PerformCallback(jsonString);
}

function _sendReportSettingsToDocumentViewerForQuickPrint() {
    var jsonArray = _getValuesFromControlsForQuickPrint();
    var jsonString = JSON.stringify(jsonArray);

    grdDisplayMemberAttendance.PerformCallback(jsonString);
}

function _getValuesFromControls() {

    var jsonArray = [];

    var memberDataReportType = 0;

    if ($("#chkPresentOnly")[0].checked == true) {
        memberDataReportType = 1;
    }

    if ($("#chkAbsencesOnly")[0].checked == true) {
        memberDataReportType = 2;
    }

    if ($("#chkAllBookings")[0].checked == true) {
        memberDataReportType = 3;
    }

    var dateFrom = moment(dtPrintDateFrom.GetDate()).isValid() ? moment(dtPrintDateFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var dateTo = moment(dtPrintDateTo.GetDate()).isValid() ? moment(dtPrintDateTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null; //dtpTo.GetDate();

    jsonArray.push({
        ID: 0,
        Nr: 0,
        Name: '',
        StartDate: dateFrom,
        EndDate: dateTo,
        DisplayMemberDate: $("#chkMemberDate")[0].checked,
        DisplayMemberGroup: $("#chkStudioGroup")[0].checked,
        DisplayMemberName: $("#chkMemberName")[0].checked,
        DisplayMemberId: $("#chkMemberId")[0].checked,
        DisplayMemberContractNr: $("#chkMemberContractNr")[0].checked,
        DisplayMemberCardNr: $("#chkMemberCardNr")[0].checked,
        DisplayExpiryDate: $("#chkExpiryDate")[0].checked,
        DisplayMemberEntry: $("#chkEntry")[0].checked,
        DisplayMemberExit: $("#chkExit")[0].checked,
        MemberDataReportType: memberDataReportType,
        MemberGroupFrom: cboStudioGroupFrom.GetValue(),
        MemberGroupTo: cboStudioGroupTo.GetValue(),

    });

    return jsonArray;
}

function _getValuesFromControlsForQuickPrint() {

    var jsonArray = [];

    var memberDataReportType = 0;

    if ($("#chkPresentOnly")[0].checked == true) {
        memberDataReportType = 1;
    }

    if ($("#chkAbsencesOnly")[0].checked == true) {
        memberDataReportType = 2;
    }

    if ($("#chkAllBookings")[0].checked == true) {
        memberDataReportType = 3;
    }

    var dateFrom = moment(dtPrintDateMain.GetDate()).isValid() ? moment(dtPrintDateMain.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var dateTo = moment(dtPrintDateMain.GetDate()).isValid() ? moment(dtPrintDateMain.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null; //dtpTo.GetDate();

    jsonArray.push({
        ID: 0,
        Nr: 0,
        Name: '',
        StartDate: dateFrom,
        EndDate: dateTo,
        DisplayMemberDate: false,
        DisplayMemberGroup: true,
        DisplayMemberName: true,
        DisplayMemberId: true,
        DisplayMemberContractNr: true,
        DisplayMemberCardNr: true,
        DisplayExpiryDate: true,
        DisplayMemberEntry: true,
        DisplayMemberExit: true,
        MemberDataReportType: memberDataReportType,
        MemberGroupFrom: cboStudioGroupFrom.GetValue(),
        MemberGroupTo: cboStudioGroupTo.GetValue(),
    });

    return jsonArray;
}

function HideAllReportsPrint() {
    $(".showReports").show();
    $(".ContentAreaDiv").hide();
    $("#btnNew").hide();
    $("#btnEntSave").hide();
    $("#btnPrintReport").show();
    $("#btnPrintAttendance").hide();
    $("#btnCancelDel").hide();
    reportType = "printReport";
    $(".showReportsDocViewer").hide();
}

function HideTodaysReport() {
    $(".showReportsDocViewer").hide();
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#btnPrintAttendance").show();
    $("#btnPrintReport").hide();
    $("#HiddenField1BackValue").val("0");
}

function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintAttendance").hide();
    $("#btnPrintReport").hide();
    MemberAttendanceCallbackPanel.PerformCallback()
    $("#HiddenField1BackValue").val("3");

}

function HideAllReports() {
    $(".showReports").hide();
    $(".ContentAreaDiv").show();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnPrintReport").hide();
    $("#btnPrintAttendance").show();
    $("#btnCancelDel").show();
}

function display_cd() {
    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));

    dtPrintDateMain.SetDate(moment().toDate());

    dtPrintDateFrom.SetDate(moment().toDate());
    dtPrintDateTo.SetDate(moment().toDate());
}

function display_ct() {
    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
}
