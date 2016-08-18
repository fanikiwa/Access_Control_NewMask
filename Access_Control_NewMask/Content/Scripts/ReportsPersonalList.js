var variableType = 0;
var PersType = 0;
var levelCaption = "";
var isDplClick = false;
var SetChangeSelectionEvent = false;
$(document).ready(function () {

    display_ct();
    display_cd();

    DisplayCurrentDate();
    $("#HiddenField1BackValue").val("0");
    $('#btnBack').on("click", function (e) {
        e.preventDefault();
        if ($("#HiddenField1BackValue").val() === "0") {
            var saveChanges = $('#hiddenFieldSaveChanges').val();
            if (saveChanges === "1") {

                BackButtonConfirm();

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

    $('#chkVariableA').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            //check mandant checkbox
            $("#chkCompany")[0].checked = true;

            $("#chkLocation")[0].checked = false;
            $("#chkDepartment")[0].checked = false;
            $("#chkPersName")[0].checked = false;
            this.checked = true;
        }
        else {
            this.checked == false;
            $("#chkCompany")[0].checked = false;
        }

    });

    $('#chkVariableB').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;
            $("#chkLocation")[0].checked = true;
            $("#chkCompany")[0].checked = false;
            $("#chkDepartment")[0].checked = false;
            $("#chkPersName")[0].checked = false;
        } else {
            this.checked = false;
            $("#chkLocation")[0].checked = false;
        }
    });

    $('#chkVariableC').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;
            $("#chkDepartment")[0].checked = true;

            $("#chkCompany")[0].checked = false;
            $("#chkLocation")[0].checked = false;
            $("#chkPersName")[0].checked = false;
        } else {
            this.checked = false;
            $("#chkDepartment")[0].checked = false;
        }
    });

    $('#chkVariableD').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;

            });
            this.checked = true;
            $("#chkPersName")[0].checked = true;

            $("#chkCompany")[0].checked = false;
            $("#chkLocation")[0].checked = false;
            $("#chkDepartment")[0].checked = false;
        } else {
            this.checked = false;
            $("#chkPersName")[0].checked = false;
        }
    });

    $('#chkActivePersonal').change(function (evt) {
        if (this.checked) {
            $(".chkPersTyp").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;

        } else {
            this.checked = false;
        }
    });

    $('#chkInactivePersonal').change(function (evt) {
        if (this.checked) {
            $(".chkPersTyp").each(function (ev) {
                this.childNodes[0].checked = false;

            });
            this.checked = true;

        } else {
            this.checked = false;
        }
    });

    $('#btnNew').on("click", function (e) {
        e.preventDefault();
        clearcontrols();
        setSaveChanges();
    });

    $('#btnEntSave').on("click", function (e) {
        e.preventDefault();
        var personalListNr = $("#txtPersonalListNr").val();

        if (parseInt(personalListNr) < 1 || isNaN($("#txtPersonalListNr").val())) {

            return;
        }
        else {
            cboPersonalListNr.SetEnabled(true);
            cboPersonalListDescription.SetEnabled(true);
            if (cboPersonalListNr.GetValue() == 0) {
                PageMethods.CheckIfListNrExists(personalListNr, OnCheckExists_CallBack);
            } else {
                PageMethods.Isnewrecord(personalListNr, SavePersonalList());
            }
        }
    });

    $('#btnCancelDel').click(function (e) {
        e.preventDefault();
        if (parseInt(cboPersonalListNr.GetValue()) > 0) {
            ConfirmDeletePersonalList();
        }
    });

    $("input, select").change(function () {
        setSaveChanges();
    });


    //checks for PaperSize Print Format

    //checks for Variable A//
    $("#chkPotraitA").click(function () {
        if ($("#chkPotraitA")[0].checked === true) {
            $("#chkLandScapeA")[0].checked = false;
        }
        else if ($("#chkPotraitA")[0].checked === false) {
            $("#chkLandScapeA")[0].checked = true;
        }
    });
    $("#chkLandScapeA").click(function () {
        if ($("#chkLandScapeA")[0].checked === true) {
            $("#chkPotraitA")[0].checked = false;
        }
        else if ($("#chkLandScapeA")[0].checked === false) {
            $("#chkPotraitA")[0].checked = true;
        }
    });

    //checks for Variable B
    $("#chkPotraitB").click(function () {
        if ($("#chkPotraitB")[0].checked === true) {
            $("#chkLandScapeB")[0].checked = false;
        }
        else if ($("#chkPotraitB")[0].checked === false) {
            $("#chkLandScapeB")[0].checked = true;
        }
    });
    $("#chkLandScapeB").click(function () {
        if ($("#chkLandScapeB")[0].checked === true) {
            $("#chkPotraitB")[0].checked = false;
        }
        else if ($("#chkLandScapeB")[0].checked === false) {
            $("#chkPotraitB")[0].checked = true;
        }
    });
    //checks for Variable C  
    $("#chkPotraitC").click(function () {
        if ($("#chkPotraitC")[0].checked === true) {
            $("#chkLandScapeC")[0].checked = false;
        }
        else if ($("#chkPotraitC")[0].checked === false) {
            $("#chkLandScapeC")[0].checked = true;
        }
    });
    $("#chkLandScapeC").click(function () {
        if ($("#chkLandScapeC")[0].checked === true) {
            $("#chkPotraitC")[0].checked = false;
        }
        else if ($("#chkLandScapeC")[0].checked === false) {
            $("#chkPotraitC")[0].checked = true;
        }
    });
    //checks for Variable D  
    $("#chkPotraitD").click(function () {
        if ($("#chkPotraitD")[0].checked === true) {
            $("#chkLandScapeD")[0].checked = false;
        }
        else if ($("#chkPotraitD")[0].checked === false) {
            $("#chkLandScapeD")[0].checked = true;
        }
    });
    $("#chkLandScapeD").click(function () {
        if ($("#chkLandScapeD")[0].checked === true) {
            $("#chkPotraitD")[0].checked = false;
        }
        else if ($("#chkLandScapeD")[0].checked === false) {
            $("#chkPotraitD")[0].checked = true;
        }
    });
});

function cobCompanyFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cboCompanyTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cboCompanyTo.SetValue(s.GetValue());
    }
}

function cobCompanyToIndexChanged(s, e) {
    var nrFrom = Number(cboCompanyFrom.GetSelectedItem().texts[0]);
    var nrTO = Number(s.GetSelectedItem().texts[0]);
    if (nrFrom === 0 || nrFrom > nrTO) {
        cboCompanyFrom.SetValue(s.GetValue());
    }
}

function cobLocationFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cboLocationTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cboLocationTo.SetValue(s.GetValue());
    }
}

function cobLocationToIndexChanged(s, e) {
    var nrFrom = Number(cboLocationFrom.GetSelectedItem().texts[0]);
    var nrTO = Number(s.GetSelectedItem().texts[0]);
    if (nrFrom === 0 || nrFrom > nrTO) {
        cboLocationFrom.SetValue(s.GetValue());
    }
}

function cobDepartmentFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cboDepartmentTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cboDepartmentTo.SetValue(s.GetValue());
    }
}

function cobDepartmentToIndexChanged(s, e) {
    var nrFrom = Number(cboDepartmentFrom.GetSelectedItem().texts[0]);
    var nrTO = Number(s.GetSelectedItem().texts[0]);
    if (nrFrom === 0 || nrFrom > nrTO) {
        cboDepartmentFrom.SetValue(s.GetValue());
    }
}

function cobNameFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cbopersNameTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cbopersNameTo.SetValue(s.GetValue());
    }
}

function cobNameToIndexChanged(s, e) {
    var nrFrom = Number(cboPersNameFrom.GetSelectedItem().texts[0]);
    var nrTO = Number(s.GetSelectedItem().texts[0]);
    if (nrFrom === 0 || nrFrom > nrTO) {
        cboPersNameFrom.SetValue(s.GetValue());
    }
}

function cobPersNrFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetText());
    var nrTO = Number(cboPersIdTo.GetText());
    if (nrTO < nrFrom) {
        cboPersIdTo.SetValue(s.GetValue());
    }
}

function cobPersNrToIndexChanged(s, e) {
    var nrFrom = Number(s.GetText());
    var nrTO = Number(cboPersIdFrom.GetText());
    if (nrTO < nrFrom) {
        cboPersIdFrom.SetValue(s.GetValue());
    }
}

function DisplayCurrentDate() {
    $("#lblDate").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}

function display_cd() {

    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtdateTime").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));

    $("#txtVarDPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtTodayDateC").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtTodayDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}

function display_ct() {

    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTime").val(moment().format("HH") + ":" + moment().format("mm"));

    $("#txtVarDPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTodayTimeC").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTodayTime").val(moment().format("HH") + ":" + moment().format("mm"));
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
    PersonalAttendanceCallbackPanel.PerformCallback()
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

function DisReports() {

    if (($('#chkVariableA').is(':checked'))) {
        $("#lblVariableA").text("Variante A");
        $(".showReports").show();
    }
    if (($('#chkVariableB').is(':checked'))) {
        $("#lblVariableB").text("Variante B");
        $(".showReportsVarB").show();
    }
    if (($('#chkVariableC').is(':checked'))) {
        $("#lblVariableC").text("Variante C");
        $(".showReportsVarC").show();
    }
    if (($('#chkVariableD').is(':checked'))) {
        $("#lblVariableD").text("Variante D");
        $(".showReportsVarD").show();
    }
    $(".showReportsDocViewer").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnNew").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $("#btnPrintReport").show();
    $("#HiddenField1BackValue").val("1");

    //variable d text boxes//
    $("#txtVarDClientFrom").val(cboCompanyFrom.GetText());
    $("#txtVarDLocationFrom").val(cboLocationFrom.GetText());
    $("#txtVarDDepartmentFrom").val(cboDepartmentFrom.GetText());

    $("#txtVarDClientTo").val(cboCompanyTo.GetText());
    $("#txtVarDLocationTo").val(cboLocationTo.GetText());
    $("#txtVarDDepartmentTo").val(cboDepartmentTo.GetText());

    $("#txtClientFrom").val(cboCompanyFrom.GetText());
    $("#txtClientTo").val(cboCompanyTo.GetText());
    $("#txtClientBFrom").val(cboCompanyFrom.GetText());
    $("#txtClientBTo").val(cboCompanyTo.GetText());
    $("#txtClientCFrom").val(cboCompanyFrom.GetText());
    $("#txtClientCTo").val(cboCompanyTo.GetText());

    $("#txtLocFrom").val(cboLocationFrom.GetText());
    $("#txtLocTo").val(cboLocationTo.GetText());
    $("#txtLocationBFrom").val(cboLocationFrom.GetText());
    $("#txtLocationBTo").val(cboLocationTo.GetText());
    $("#txtLocationCFrom").val(cboLocationFrom.GetText());
    $("#txtLocationCTo").val(cboLocationTo.GetText());

    $("#txtDeptBFrom").val(cboDepartmentFrom.GetText());
    $("#txtDeptBTo").val(cboDepartmentTo.GetText());
    $("#txtDept").val(cboDepartmentFrom.GetText());
    $("#txtDeptTo").val(cboDepartmentTo.GetText());
    $("#txtDeptCFrom").val(cboDepartmentFrom.GetText());
    $("#txtDeptCTo").val(cboDepartmentTo.GetText());

    _sendReportSettingsToDocumentViewer();
}

function HideAllReports() {
    $(".showReports").hide();
    $(".showReportsVarB").hide();
    $(".showReportsVarC").hide();
    $(".showReportsVarD").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    reportType = "printReport";
}

function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".showReportsVarB").hide();
    $(".showReportsVarC").hide();
    $(".showReportsVarD").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnNew").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $("#btnPrintReport").hide();


    $("#btnNew").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();

    OneTodayCallbackPanel.PerformCallback()
    $("#HiddenField1BackValue").val("3");

}

function HideAllReportsPrint() {
    if (($('#chkVariableA').is(':checked'))) {
        $(".showReports").show();
    }

    if (($('#chkVariableB').is(':checked'))) {
        $(".showReportsVarB").show();
    }
    if (($('#chkVariableC').is(':checked'))) {
        $(".showReportsVarC").show();
    }

    if (($('#chkVariableD').is(':checked'))) {
        $(".showReportsVarD").show();
    }



    $(".ContentAreaDiv").hide();
    $("#btnPrintReport").show();
    $("#btnPrintSelection").hide();
    $("#btnNew").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $(".showReportsDocViewer").hide();
}

function HideTodaysReport() {
    $(".showReportsDocViewer").hide();
    $(".showReports").hide();
    $(".showReportsVarB").hide();
    $(".showReportsVarC").hide();
    $(".showReportsVarD").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#HiddenField1BackValue").val("0");
}

function _sendReportSettingsToDocumentViewer() {
    var jsonArray = _getValuesFromControls();
    var jsonString = JSON.stringify(jsonArray);

    if (($('#chkVariableA').is(':checked'))) {
        grdShowReport.PerformCallback(jsonString);
    }
    if (($('#chkVariableB').is(':checked'))) {
        grdMainPersInfo.PerformCallback(jsonString);
    }
    if (($('#chkVariableC').is(':checked'))) {
        grdVaribleC.PerformCallback(jsonString);
    }
    if (($('#chkVariableD').is(':checked'))) {
        grdVaribleD.PerformCallback(jsonString);
    }
}

function _getValuesFromControls() {
    var jsonArray = [];

    var printSelection = 0;
    var variableTypeText = "Variante D";

    if (($('#chkVariableA').is(':checked'))) {
        printSelection = 0;
        variableTypeText = "Variante A";

    }
    if (($('#chkVariableB').is(':checked'))) {
        printSelection = 1;
        variableTypeText = "Variante B";
    }
    if (($('#chkVariableC').is(':checked'))) {
        printSelection = 2;
        variableTypeText = "Variante C";
    }
    if (($('#chkVariableD').is(':checked'))) {
        printSelection = 3;
        variableTypeText = "Variante D";
    }
    if (($('#chkActivePersonal').is(':checked'))) {
        PersonalType = 1;
    }
    if (($('#chkInactivePersonal').is(':checked'))) {
        PersonalType = 2;
    }
    jsonArray.push({
        ReportType: printSelection,
        StartClient: cboCompanyFrom.GetValue(),
        EndClient: cboCompanyTo.GetValue(),
        StartLocation: cboLocationFrom.GetValue(),
        EndLocation: cboLocationTo.GetValue(),
        StartDept: cboDepartmentFrom.GetValue(),
        EndDept: cboDepartmentTo.GetValue(),
        StartPersonal: cboPersNameFrom.GetValue(),
        EndPersonal: cbopersNameTo.GetValue(),
        StartPersID: cboPersIdFrom.GetValue(),
        EndPersID: cboPersIdTo.GetValue(),
        VariableText: variableTypeText,
        PersonalType: PersonalType,
        DisplayClient: $('#chkCompany').is(':checked'),
        DisplayLocation: $('#chkLocation').is(':checked'),
        DisplayDepartment: $('#chkDepartment').is(':checked'),
        DisplayPlace: $('#chkPlace').is(':checked'),
        DisplayName: $('#chkPersName').is(':checked'),
        DisplayPersonalID: $('#chkPersId').is(':checked'),
        DisplayPostalCode: $('#chkPostalCode').is(':checked'),
        DisplayStreetAndNr: $('#chkStreetNrAdnName').is(':checked'),
        DisplayDateOfBirth: $('#chkDateOfBirth').is(':checked'),
        DisplayEnrtyDate: $('#chkEnrtyDate').is(':checked'),
        DisplayExitDate: $('#chkExitDate').is(':checked'),
        DisplayEmployedAs: $('#chkEmployedAs').is(':checked'),
        DisplayNationality: $('#chknationality').is(':checked'),
        DisplayCompanyTelephone: $('#chkCompanyTelephone').is(':checked'),
        DisplayCompanyMobile: $('#chkCompanyMobile').is(':checked'),
        DisplayPrivateTelephone: $('#chkPrivateTelephone').is(':checked'),
        DisplayPrivateMobile: $('#chkPrivateMobile').is(':checked'),
        DisplayLongTermCard: $('#chkLongTermCard').is(':checked'),
        DisplayShortTermCard: $('#chkShortTermCard').is(':checked'),
        DisplayAccessAuthorization: $('#chkAccessAuthorization').is(':checked'),
        DisplayAccessPlanNr: $('#chkAccessPlanNr').is(':checked'),
        DisplayAccessPlanDescription: $('#chkAccessPlanDescription').is(':checked'),
    });

    return jsonArray;
}

// #region saving

function clearcontrols() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
    cboPersonalListNr.SetValue("0");
    cboPersonalListDescription.SetValue("0");


    cboCompanyFrom.SetValue("0");
    cboCompanyTo.SetValue("0");

    cboLocationFrom.SetValue("0");
    cboLocationTo.SetValue("0");

    cboDepartmentFrom.SetValue("0");
    cboDepartmentTo.SetValue("0");

    cboPersNameFrom.SetValue("0");
    cbopersNameTo.SetValue("0");

    cboPersIdFrom.SetValue("0");
    cboPersIdTo.SetValue("0");

    $("#chkCompany")[0].checked = false;
    $("#chkLocation")[0].checked = false;
    $("#chkDepartment")[0].checked = false;
    $("#chkPersName")[0].checked = true;
    $("#chkPersId")[0].checked = false;
    $("#chkPlace")[0].checked = false;
    $("#chkPostalCode")[0].checked = false;
    $("#chkStreetNrAdnName")[0].checked = false;
    $("#chkDateOfBirth")[0].checked = false;
    $("#chkEnrtyDate")[0].checked = false;
    $("#chkExitDate")[0].checked = false;
    $("#chkEmployedAs")[0].checked = false;
    $("#chknationality")[0].checked = false;
    $("#chkCompanyTelephone")[0].checked = false;
    $("#chkCompanyMobile")[0].checked = false;
    $("#chkPrivateTelephone")[0].checked = false;
    $("#chkPrivateMobile")[0].checked = false;
    $("#chkLongTermCard")[0].checked = false;
    $("#chkShortTermCard")[0].checked = false;
    $("#chkAccessAuthorization")[0].checked = false;
    $("#chkAccessPlanNr")[0].checked = false;
    $("#chkAccessPlanDescription")[0].checked = false;

    $("#chkVariableA")[0].checked = false;
    $("#chkVariableB")[0].checked = false;
    $("#chkVariableC")[0].checked = false;
    $("#chkVariableD")[0].checked = true;

    grdSavedPersonalList.PerformCallback("-1");

    document.getElementById('txtPersonalListDescription').value = "";

    PageMethods.CalculateNextNr(CalculateNextNr_callback)
}
function CalculateNextNr_callback(succ) {

    document.getElementById('txtPersonalListNr').value = succ;

    cboPersonalListNr.SetEnabled(false);
    cboPersonalListDescription.SetEnabled(false);
    $("#txtPersonalListDescription").focus();
}

function setSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "1");
    saveChanges = true;
}

function resetSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
}
function OnCheckExists_CallBack(value) {
    if (value === true) {

        //$("#txtPersonalListNr").focus();
        //$("#txtPersonalListNr").addClass('focusOnError');

        NumberExistWarning();

        return;
    }
    else {
        var personalListNr = $("#txtPersonalListNr").val();
        PageMethods.Isnewrecord(personalListNr, SavePersonalList());
    }
}



function SavePersonalList() {
    $("#txtPersonalListNr").addClass('removeBorderOnError');

    var id = cboPersonalListNr.GetValue();

    if (id == null || id == undefined || id == "0") {

        var jsonArray = GetMemberDataFromControls();
        var jsonString = JSON.stringify(jsonArray);
        PageMethods.CreatePersonalListInDatabase(jsonString, OnCreateEditPersonalList_CallBack);
    }
    else {
        var jsonArray = GetMemberDataFromControls();
        var jsonString = JSON.stringify(jsonArray);
        PageMethods.EditPersonalListInDatabase(jsonString, OnCreateEditPersonalList_CallBack);
    }
}

function GetMemberDataFromControls() {

    var jsonArray = [];
    var persType = 0;
    var varType = 4;
    if (($('#chkActivePersonal').is(':checked'))) {
        persType = 1;
    }
    if (($('#chkInactivePersonal').is(':checked'))) {
        persType = 2;
    }
    if (($('#chkVariableA').is(':checked'))) {
        varType = 1;
    }
    if (($('#chkVariableB').is(':checked'))) {
        varType = 2;
    }
    if (($('#chkVariableC').is(':checked'))) {
        varType = 3;
    }
    if (($('#chkVariableD').is(':checked'))) {
        varType = 4;
    }

    jsonArray.push({

        ID: cboPersonalListNr.GetValue(),
        ListNr: $("#txtPersonalListNr").val(),
        ListDescription: $("#txtPersonalListDescription").val(),
        PersonType: persType,
        StartClient: cboCompanyFrom.GetValue(),
        EndClient: cboCompanyTo.GetValue(),
        StartLocation: cboLocationFrom.GetValue(),
        EndLocation: cboLocationTo.GetValue(),
        StartDepartmet: cboDepartmentFrom.GetValue(),
        EndDepartment: cboDepartmentTo.GetValue(),
        StartName: cboPersNameFrom.GetValue(),
        EndName: cbopersNameTo.GetValue(),
        StartIdNr: cboPersIdFrom.GetValue(),
        EndIdNr: cboPersIdTo.GetValue(),
        VariableType: varType,

        ShowClientCompany: $("#chkCompany")[0].checked,
        ShowLocation: $("#chkLocation")[0].checked,
        ShowDepartment: $("#chkDepartment")[0].checked,
        ShowName: $("#chkPersName")[0].checked,
        ShowIDNr: $("#chkPersId")[0].checked,
        ShowPlace: $("#chkPlace")[0].checked,
        ShowPostalCode: $("#chkPostalCode")[0].checked,
        ShowStreetAndNr: $("#chkStreetNrAdnName")[0].checked,
        ShowDOB: $("#chkDateOfBirth")[0].checked,
        ShowEntryDate: $("#chkEnrtyDate")[0].checked,
        ShowExitDate: $("#chkExitDate")[0].checked,
        ShowEmploymentPosition: $("#chkEmployedAs")[0].checked,
        ShowNationality: $("#chknationality")[0].checked,
        ShowCompanyTelephone: $("#chkCompanyTelephone")[0].checked,
        ShowCompanyMobile: $("#chkCompanyMobile")[0].checked,
        ShowPrivateTelephone: $("#chkPrivateTelephone")[0].checked,
        ShowPrivateMobile: $("#chkPrivateMobile")[0].checked,
        ShowLongTermCard: $("#chkLongTermCard")[0].checked,
        ShowShortTermCard: $("#chkShortTermCard")[0].checked,
        ShowAccessFromTo: $("#chkAccessAuthorization")[0].checked,
        ShowAccessPlanNr: $("#chkAccessPlanNr")[0].checked,
        ShowAccessPlanDesc: $("#chkAccessPlanDescription")[0].checked,

    });
    if (SetChangeSelectionEvent == true) {
        setSaveChanges();
    } else {
        $('#hiddenFieldSaveChanges').val("0");
    }
    return jsonArray;

}

function OnCreateEditPersonalList_CallBack(Id) {
    resetSaveChanges();

    if (parseInt(Id) > 0) {
        cboPersonalListNr.PerformCallback(Id);
        cboPersonalListDescription.PerformCallback(Id);
        cboPersonalListNr.SetValue(Id);
        cboPersonalListDescription.SetValue(Id);

        grdSavedPersonalList.PerformCallback(Id);
    }
}


// #endregion

// #region SelectionChangedEvents

function cboPersonalListNrSelectedIndexChanged(value) {
    if (isDplClick === true) {
        cboPersonalListNr.SetValue(value);
        cboPersonalListDescription.SetValue(value);
        SetValues(value);
        saveChanges = false;
    }
}

function cboPersonalListDescSelectedIndexChanged(value) {
    if (isDplClick === true) {
        cboPersonalListNr.SetValue(value);
        cboPersonalListDescription.SetValue(value);
        SetValues(value);
        saveChanges = false;
    }
}

function SetValues(value) {
    PageMethods.GetPersonaReportlList(value, Setcontrols);
}

function Setcontrols(Responce) {
    if (Responce.ID !== null && Responce.ID !== 0) {

        isDplClick = false;
        cboPersonalListNr.SetValue(Responce.ID);
        cboPersonalListDescription.SetValue(Responce.ID);

        $("#txtPersonalListNr").val(Responce.ListNr);
        $("#txtPersonalListDescription").val(Responce.ListDescription);

        cboCompanyFrom.SetValue(Responce.StartClient);
        cboCompanyTo.SetValue(Responce.EndClient);

        cboLocationFrom.SetValue(Responce.StartLocation);
        cboLocationTo.SetValue(Responce.EndLocation);

        cboDepartmentFrom.SetValue(Responce.StartDepartmet);
        cboDepartmentTo.SetValue(Responce.EndDepartment);

        cboPersNameFrom.SetValue(Responce.StartName);
        cbopersNameTo.SetValue(Responce.EndName);

        cboPersIdFrom.SetValue(Responce.StartIdNr);
        cboPersIdTo.SetValue(Responce.EndIdNr);

        variableType = (Responce.VariableType);

        switch (variableType) {
            case 1:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableA")[0].checked = true;
                break;
            case 2:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableB")[0].checked = true;
                break;
            case 3:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableC")[0].checked = true;
                break;
            case 4:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableD")[0].checked = true;
                break;
        }

        PersType = (Responce.PersonType);
        switch (PersType) {
            case 1:
                $(".chkPersTyp").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkActivePersonal")[0].checked = true;
                break;
            case 2:
                $(".chkPersTyp").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkInactivePersonal")[0].checked = true;
                break;
        }

        if (Responce.ID != 0 || Responce.ID != null) {
            var checkId = Responce.ID;
            PageMethods.GetPersonalListCheckbyid(checkId, setCheckBoxes);
        }
        grdSavedPersonalList.PerformCallback(Responce.ID);

    } else {
        $("#txtPersonalListNr").val("");
        $("#txtPersonalListDescription").val("");

        cboCompanyFrom.SetValue(0);
        cboCompanyTo.SetValue(0);

        cboLocationFrom.SetValue(0);
        cboLocationTo.SetValue(0);

        cboDepartmentFrom.SetValue(0);
        cboDepartmentTo.SetValue(0);

        cboPersNameFrom.SetValue(0);
        cbopersNameTo.SetValue(0);

        cboPersIdFrom.SetValue(0);
        cboPersIdTo.SetValue(0);

    }
}


function grdSavedPersonalListDblClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var ID = grdSavedPersonalList.GetRowKey(index);
        PageMethods.GetPersonaReportlList(ID, Setcontrols);
    }
}


function setCheckBoxes(Responce) {
    $("#chkCompany")[0].checked = (Responce.ShowClientCompany);
    $("#chkLocation")[0].checked = (Responce.ShowLocation);
    $("#chkDepartment")[0].checked = (Responce.ShowDepartment);
    $("#chkPersName")[0].checked = (Responce.ShowName);
    $("#chkPersId")[0].checked = (Responce.ShowIDNr);
    $("#chkPlace")[0].checked = (Responce.ShowPlace);
    $("#chkPostalCode")[0].checked = (Responce.ShowPostalCode);
    $("#chkStreetNrAdnName")[0].checked = (Responce.ShowStreetAndNr);
    $("#chkDateOfBirth")[0].checked = (Responce.ShowDOB);
    $("#chkEnrtyDate")[0].checked = (Responce.ShowEntryDate);
    $("#chkExitDate")[0].checked = (Responce.ShowExitDate);
    $("#chkEmployedAs")[0].checked = (Responce.ShowEmploymentPosition);
    $("#chknationality")[0].checked = (Responce.ShowNationality);
    $("#chkCompanyTelephone")[0].checked = (Responce.ShowCompanyTelephone);
    $("#chkCompanyMobile")[0].checked = (Responce.ShowCompanyMobile);
    $("#chkPrivateTelephone")[0].checked = (Responce.ShowPrivateTelephone);
    $("#chkPrivateMobile")[0].checked = (Responce.ShowPrivateMobile);
    $("#chkLongTermCard")[0].checked = (Responce.ShowLongTermCard);
    $("#chkShortTermCard")[0].checked = (Responce.ShowShortTermCard);
    $("#chkAccessAuthorization")[0].checked = (Responce.ShowAccessFromTo);
    $("#chkAccessPlanNr")[0].checked = (Responce.ShowAccessPlanNr);
    $("#chkAccessPlanDescription")[0].checked = (Responce.ShowAccessPlanDesc);

}

// #endregion

function ConfirmDeletePersonalList() {
    var message = "Sind Sie sicher das Sie das  Personallisten tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 13%; margin-right: 0px;"  onclick="DeleteReportPersonalList()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    //   getLocalizedText("deleteAccessProtocole");
    $('#btnOk').text("Personalliste löschen");
    //  getLocalizedText("cancelAccessProtocole");
    $('#btnCancel').text("Personalliste nicht löschen");
}

function DeleteReportPersonalList() {
    resetDefault();
    var grp = cboPersonalListNr.GetValue();
    if (grp != 0) {
        PageMethods.DeletePersonalReportList(grp, ReloadPage);
    }
}

function resetDefault() {
    document.getElementById('importantDialog').innerHTML = "";
}

function ReloadPage(res) {
    ClearControlAfterDelete();
}

function ClearControlAfterDelete() {
    isDplClick = false;
    //cboPersonalListNr.SetValue(0);
    //cboPersonalListDescription.SetValue(0);

    $("#txtPersonalListNr").val("");
    $("#txtPersonalListDescription").val("");
    cboCompanyFrom.SetValue(0);
    cboCompanyTo.SetValue(0);

    cboLocationFrom.SetValue(0);
    cboLocationTo.SetValue(0);

    cboDepartmentFrom.SetValue(0);
    cboDepartmentTo.SetValue(0);

    cboPersNameFrom.SetValue(0);
    cbopersNameTo.SetValue(0);

    cboPersIdFrom.SetValue(0);
    cboPersIdTo.SetValue(0);


    $("#chkCompany")[0].checked = false;
    $("#chkLocation")[0].checked = false;
    $("#chkDepartment")[0].checked = false;
    $("#chkPersName")[0].checked = false;
    $("#chkPersId")[0].checked = false;
    $("#chkPlace")[0].checked = false;
    $("#chkPostalCode")[0].checked = false;
    $("#chkStreetNrAdnName")[0].checked = false;
    $("#chkDateOfBirth")[0].checked = false;
    $("#chkEnrtyDate")[0].checked = false;
    $("#chkExitDate")[0].checked = false;
    $("#chkEmployedAs")[0].checked = false;
    $("#chknationality")[0].checked = false;
    $("#chkCompanyTelephone")[0].checked = false;
    $("#chkCompanyMobile")[0].checked = false;
    $("#chkPrivateTelephone")[0].checked = false;
    $("#chkPrivateMobile")[0].checked = false;
    $("#chkLongTermCard")[0].checked = false;
    $("#chkShortTermCard")[0].checked = false;
    $("#chkAccessAuthorization")[0].checked = false;
    $("#chkAccessPlanNr")[0].checked = false;
    $("#chkAccessPlanDescription")[0].checked = false;

    cboPersonalListNr.PerformCallback("0");
    cboPersonalListDescription.PerformCallback("0");
    grdSavedPersonalList.PerformCallback();

}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 35%;width: 135px; margin-right: 0px;"  onclick="BacksavePersonalReport()"></button><button id="btnNo"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}

function BacksavePersonalReport() {
    resetDefault();
    var listNr = $("#txtPersonalListNr").val();
    if ((cboPersonalListNr.GetValue() != 0)) {
        var currentId = cboPersonalListNr.GetValue();
        PageMethods.CheckIfListNrExistsOnEdit(listNr, currentId, checkBackNumberExistCallBack);
    } else {
        resetDefault();
        $("[id$=btnEntSave]").click();
        window.location.href = "/Content/AccReports.aspx";
    }
}

function checkBackNumberExistCallBack(value) {
    if (value === true) {
        NumberExistWarning();
    }
    else {
        resetDefault();
        $("[id$=btnEntSave]").click();
        window.location.href = "/Content/AccReports.aspx";
    }
}

function NumberExistWarning() {
    var message = "Personallisten Nr. existiert bereits";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/popupinfo.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div><button id="btnErrorOk"  style="margin-left: 35%; float:right; width: 135px; margin-right: 25px;"  onclick="SetFocus()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    //  getLocalizedText("newSaveWarning");
    $('#btnErrorOk').text("Ok");
}

function SetFocus() {
    resetDefault();

    $("#txtPersonalListNr").focus();
    $("#txtPersonalListNr").addClass('focusOnError');
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "ReportsPersonalList.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function CancelOnBackButton() {
    resetDefault();
}

function dplClicked(s, e) {
    isDplClick = true;
}
