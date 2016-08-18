var variableType = 0;
var memberType = 0;
var levelCaption = "";

var isDplClick = false;

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

    $("#chkpotraitD").click(function () {
        if ($("#chkpotraitD")[0].checked === true) {
            $("#chkLandD")[0].checked = false;

        }
        else if ($("#chkpotraitD")[0].checked === false) {
            $("#chkLandD")[0].checked = true;
        }
    });

    $("#chkLandD").click(function () {
        if ($("#chkLandD")[0].checked === true) {
            $("#chkpotraitD")[0].checked = false;

        }
        else if ($("#chkLandD")[0].checked === false) {
            $("#chkpotraitD")[0].checked = true;
        }
    });
    $('#chkVariableA').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            //check mandant checkbox
            $("#chkStudioGroup")[0].checked = true;

            $("#chkMemberName")[0].checked = false;
            $("#chkPlace")[0].checked = false;
            $("#chkPostalCode")[0].checked = false;
            this.checked = true;
        }
        else {
            this.checked == false;
            $("#chkStudioGroup")[0].checked = false;
        }

    });
    $('#chkVariableB').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;
            $("#chkMemberName")[0].checked = true;
            $("#chkStudioGroup")[0].checked = false;
            $("#chkPlace")[0].checked = false;
            $("#chkPostalCode")[0].checked = false;
        } else {
            this.checked = false;
            $("#chkMemberName")[0].checked = false;
        }
    });

    $('#chkVariableC').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;
            $("#chkPlace")[0].checked = true;

            $("#chkStudioGroup")[0].checked = false;
            $("#chkMemberName")[0].checked = false;
            $("#chkPostalCode")[0].checked = false;
        } else {
            this.checked = false;
            $("#chkPlace")[0].checked = false;
        }
    });

    $('#chkVariableD').change(function (evt) {
        if (this.checked) {
            $(".chkAllvar").each(function (ev) {
                this.childNodes[0].checked = false;

            });
            this.checked = true;
            $("#chkPostalCode")[0].checked = true;

            $("#chkStudioGroup")[0].checked = false;
            $("#chkMemberName")[0].checked = false;
            $("#chkPlace")[0].checked = false;
        } else {
            this.checked = false;
            $("#chkPostalCode")[0].checked = false;
        }
    });

    $('#chkActiveMember').change(function (evt) {
        if (this.checked) {
            $(".chkPersTyp").each(function (ev) {
                this.childNodes[0].checked = false;
            });
            this.checked = true;

        } else {
            this.checked = false;
        }
    });

    $('#chkInactiveMember').change(function (evt) {
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
        var memberListNr = $("#txtMemberNumber").val();

        if (parseInt(memberListNr) < 1 || isNaN($("#txtMemberNumber").val())) {

            return;
        }
        else {
            cobMemberNumber.SetEnabled(true);
            cobMemberName.SetEnabled(true);
            if (cobMemberNumber.GetValue() == 0) {
                PageMethods.CheckIfListNrExists(memberListNr, OnCheckExists_CallBack);
            } else {
                PageMethods.Isnewrecord(memberListNr, SavePersonalList());
            }
        }
    });

    $('#btnCancelDel').click(function (e) {
        e.preventDefault();
        if (parseInt(cobMemberNumber.GetValue()) > 0) {
            ConfirmDeletePersonalList();
        }
    });
    $("input, select").change(function () {
        setSaveChanges();
    });


});


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

    //SeatText  Fro var A
    $("#txtClientFrom").val(cobStudioGroupFrom.GetText());
    $("#txtClientTo").val(cobStudioGroupTo.GetText());
    $("#txtLocFrom").val(cobMemberNameFrom.GetText());
    $("#txtLocTo").val(cobMemberNameTo.GetText());
    $("#txtDept").val(cobMemberPlaceFrom.GetText());
    $("#txtDeptTo").val(cobMemberPlaceTo.GetText());

    //SeatText  Fro var B
    $("#txtClientBFrom").val(cobStudioGroupFrom.GetText());
    $("#txtClientBTo").val(cobStudioGroupTo.GetText());
    $("#txtLocationBFrom").val(cobMemberNameFrom.GetText());
    $("#txtLocationBTo").val(cobMemberNameTo.GetText());
    $("#txtDeptBFrom").val(cobMemberPlaceFrom.GetText());
    $("#txtDeptBTo").val(cobMemberPlaceTo.GetText());



    //SeatText  Fro var C
    $("#txtClientCFrom").val(cobStudioGroupFrom.GetText());
    $("#txtClientCTo").val(cobStudioGroupTo.GetText());
    $("#txtLocationCFrom").val(cobMemberNameFrom.GetText());
    $("#txtLocationCTo").val(cobMemberNameTo.GetText());
    $("#txtDeptCFrom").val(cobMemberPlaceFrom.GetText());
    $("#txtDeptCTo").val(cobMemberPlaceTo.GetText());

    //SeatText  Fro var D
    $("#txtVarDClientFrom").val(cobStudioGroupFrom.GetText());
    $("#txtVarDClientTo").val(cobStudioGroupTo.GetText());
    $("#txtVarDLocationFrom").val(cobMemberNameFrom.GetText());
    $("#txtVarDLocationTo").val(cobMemberNameTo.GetText());
    $("#txtVarDDepartmentFrom").val(cobMemberPlaceFrom.GetText());
    $("#txtVarDDepartmentTo").val(cobMemberPlaceTo.GetText());

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
function cobStudioGroupFromIndexChanged(s, e) {
    var CboFrom = cobStudioGroupFrom.GetValue();
    var CboTo = cobStudioGroupTo.GetValue();
    cobStudioGroupTo.SetValue(CboFrom);

}
function cobMemberNameFromIndexChanged(s, e) {
    var CbomeberFrom = cobMemberNameFrom.GetValue();
    var CboMemberTo = cobMemberNameTo.GetValue();
    cobMemberNameTo.SetValue(CbomeberFrom);

}
function cobMemberNumberFromIndexChanged(s, e) {
    var CbomeberNoFrom = cobMemberNumberFrom.GetValue();
    var CboMemberNoTo = cobMemberNumberTo.GetValue();
    cobMemberNumberTo.SetValue(CbomeberNoFrom);

}
function cobMemberPlaceFromIndexChanged(s, e) {
    var CbomeberPlaceFrom = cobMemberPlaceFrom.GetValue();
    var CboPlaceTo = cobMemberPlaceTo.GetValue();
    cobMemberPlaceTo.SetValue(CbomeberPlaceFrom);

}
function cobMemberPostalCodeFromIndexChanged(s, e) {
    var cboPostalCodeFrom = cobMemberPostalCodeFrom.GetValue();
    var CboPostalCodeTo = cobMemberPostalCodeTo.GetValue();
    cobMemberPostalCodeTo.SetValue(cboPostalCodeFrom);

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
    //$(".showReports").show();
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
        grdVariableA.PerformCallback(jsonString);
    }
    if (($('#chkVariableB').is(':checked'))) {
        //grdMainPersInfo.PerformCallback(jsonString); 
        grdVariableB.PerformCallback(jsonString);
    }
    if (($('#chkVariableC').is(':checked'))) {
        //grdVaribleC.PerformCallback(jsonString);
        grdVariableC.PerformCallback(jsonString);
    }
    if (($('#chkVariableD').is(':checked'))) {
        //grdVaribleD.PerformCallback(jsonString);
        grdVariableD.PerformCallback(jsonString);
    }
}

function _getValuesFromControls() {
    var jsonArray = [];
    var groupBy = "";
    if ($('#chkVariableA')[0].checked === true) {
        groupBy = "A";
    }
    if ($('#chkVariableB')[0].checked === true) {
        groupBy = "B";
    }
    if ($('#chkVariableC')[0].checked === true) {
        groupBy = "C";
    }
    if ($('#chkVariableD')[0].checked === true) {
        groupBy = "D";
    }
    jsonArray.push({
        GroupFrom: cobStudioGroupFrom.GetSelectedItem().texts[0],
        GroupTo: cobStudioGroupTo.GetSelectedItem().texts[0],
        NameNrFrom: cobMemberNameFrom.GetSelectedItem().texts[0],
        NameNrTo: cobMemberNameTo.GetSelectedItem().texts[0],
        PlaceIdFrom: cobMemberPlaceFrom.GetValue(),
        PlaceIdTo: cobMemberPlaceTo.GetValue(),
        PlaceNameFrom: cobMemberPlaceFrom.GetText(),
        PlaceNameTo: cobMemberPlaceTo.GetText(),
        MemberNumberFrom: cobMemberNumberFrom.GetText(),
        MemberNumberTo: cobMemberNumberTo.GetText(),
        PostalCodeFrom: cobMemberPostalCodeFrom.GetText(),
        PostalCodeTo: cobMemberPostalCodeTo.GetText(),
        AciveMembers: $('#chkActiveMember')[0].checked,
        InAaciveMembers: $('#chkInactiveMember')[0].checked,
        GroupBy: groupBy,
    });

    return jsonArray;
}









// #region saving

function clearcontrols() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
    cobMemberNumber.SetValue("0");
    cobMemberName.SetValue("0");


    cobStudioGroupFrom.SetValue("0");
    cobStudioGroupTo.SetValue("0");

    cobMemberNameFrom.SetValue("0");
    cobMemberNameTo.SetValue("0");

    cobMemberNumberFrom.SetValue("0");
    cobMemberNumberTo.SetValue("0");

    cobMemberPlaceFrom.SetValue("0");
    cobMemberPlaceTo.SetValue("0");

    cobMemberPostalCodeFrom.SetValue("0");
    cobMemberPostalCodeTo.SetValue("0");

    $("#chkStudioGroup")[0].checked = false;
    $("#chkMemberName")[0].checked = false;
    $("#chkMemberNumber")[0].checked = false;
    $("#chkPlace")[0].checked = false;
    $("#chkPostalCode")[0].checked = false;
    $("#chkSalutation")[0].checked = false;
    $("#chkStreetNumber")[0].checked = false;
    $("#chkContractNumber")[0].checked = false;
    $("#chkDateOfBirth")[0].checked = false;
    $("#chkNationality")[0].checked = false;
    $("#chkProfession")[0].checked = false;
    $("#chkTelephone")[0].checked = false;
    $("#chkMobile")[0].checked = false;
    $("#chkEmail")[0].checked = false;
    $("#chkStartDate")[0].checked = false;
    $("#chkEndDate")[0].checked = false;
    $("#chkLongtermCard")[0].checked = false;
    $("#chkShortTermCard")[0].checked = false;
    $("#chkAccessFromTo")[0].checked = false;
    $("#chkAccessPlanNr")[0].checked = false;
    $("#chkAccessPlanName")[0].checked = false;

    $("#chkVariableA")[0].checked = false;
    $("#chkVariableB")[0].checked = false;
    $("#chkVariableC")[0].checked = false;
    $("#chkVariableD")[0].checked = true;

    document.getElementById('txtMemberName').value = "";

    grdSavedMemberList.PerformCallback("-1");

    PageMethods.CalculateNextNr(CalculateNextNr_callback)
}

function CalculateNextNr_callback(succ) {

    document.getElementById('txtMemberNumber').value = succ;

    cobMemberNumber.SetEnabled(false);
    cobMemberName.SetEnabled(false);
    $("#txtMemberName").focus();
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

        //$("#txtMemberNumber").focus();
        //$("#txtMemberNumber").addClass('focusOnError');

        NumberExistWarning();

        return;
    }
    else {
        var memberListNr = $("#txtMemberNumber").val();
        PageMethods.Isnewrecord(memberListNr, SavePersonalList());
    }
}

function SavePersonalList() {
    $("#txtMemberNumber").addClass('removeBorderOnError');

    var id = cobMemberNumber.GetValue();

    if (id == null || id == undefined || id == "0") {

        var jsonArray = GetMemberDataFromControls();
        var jsonString = JSON.stringify(jsonArray);
        PageMethods.CreateMemberListInDatabase(jsonString, OnCreateEditPersonalList_CallBack);
    }
    else {
        var jsonArray = GetMemberDataFromControls();
        var jsonString = JSON.stringify(jsonArray);
        PageMethods.EditMemberListInDatabase(jsonString, OnCreateEditPersonalList_CallBack);
    }
}

function GetMemberDataFromControls() {

    var jsonArray = [];
    var memberType = 0;
    var varType = 4;
    if (($('#chkActiveMember').is(':checked'))) {
        memberType = 1;
    }
    if (($('#chkInactiveMember').is(':checked'))) {
        memberType = 2;
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

        ID: cobMemberNumber.GetValue(),
        ListNr: $("#txtMemberNumber").val(),
        ListDescription: $("#txtMemberName").val(),
        MemberType: memberType,
        StartStudioGroup: cobStudioGroupFrom.GetValue(),
        EndStudioGroup: cobStudioGroupTo.GetValue(),
        StartName: cobMemberNameFrom.GetValue(),
        EndName: cobMemberNameTo.GetValue(),
        StartIdNr: cobMemberNumberFrom.GetValue(),
        EndIdNr: cobMemberNumberTo.GetValue(),
        StartPlace: cobMemberPlaceFrom.GetValue(),
        EndPlace: cobMemberPlaceTo.GetValue(),
        StartPostalCode: cobMemberPostalCodeFrom.GetValue(),
        EndPostalCode: cobMemberPostalCodeTo.GetValue(),
        VariableType: varType,

        ShowMemberGroup: $("#chkStudioGroup")[0].checked,
        ShowName: $("#chkMemberName")[0].checked,
        ShowIDNr: $("#chkMemberNumber")[0].checked,
        ShowPlace: $("#chkPlace")[0].checked,
        ShowPostalCode: $("#chkPostalCode")[0].checked,
        ShowSalutation: $("#chkSalutation")[0].checked,
        ShowStreetAndNr: $("#chkStreetNumber")[0].checked,
        ShowContractNr: $("#chkContractNumber")[0].checked,
        ShowDOB: $("#chkDateOfBirth")[0].checked,
        ShowNationality: $("#chkNationality")[0].checked,
        ShowProfession: $("#chkProfession")[0].checked,
        ShowCompanyTelephone: $("#chkTelephone")[0].checked,
        ShowCompanyMobile: $("#chkMobile")[0].checked,
        ShowEmail: $("#chkEmail")[0].checked,
        ShowEntryDate: $("#chkStartDate")[0].checked,
        ShowExitDate: $("#chkEndDate")[0].checked,
        ShowLongTermCard: $("#chkLongtermCard")[0].checked,
        ShowShortTermCard: $("#chkShortTermCard")[0].checked,
        ShowAccessFromTo: $("#chkAccessFromTo")[0].checked,
        ShowAccessPlanNr: $("#chkAccessPlanNr")[0].checked,
        ShowAccessPlanDesc: $("#chkAccessPlanName")[0].checked,

    });
    return jsonArray;
}

function OnCreateEditPersonalList_CallBack(Id) {
    resetSaveChanges();
    isDplClick = false;
    if (parseInt(Id) > 0) {
        cobMemberNumber.PerformCallback(Id);
        cobMemberName.PerformCallback(Id);
        cobMemberNumber.SetValue(Id);
        cobMemberName.SetValue(Id);

        grdSavedMemberList.PerformCallback(Id);
    }
}

// #endregion

// #region SelectionChangedEvents

function cobMemberNumberSelectedIndexChanged(value) {
    if (isDplClick === true) {
        cobMemberNumber.SetValue(value);
        cobMemberName.SetValue(value);
        SetValues(value);
        saveChanges = false;
    }
}

function cboMemberListDescSelectedIndexChanged(value) {
    if (isDplClick === true) {
        cobMemberNumber.SetValue(value);
        cobMemberName.SetValue(value);
        SetValues(value);
        saveChanges = false;
    }
}

function SetValues(value) {
    PageMethods.GetMemberReportlList(value, Setcontrols);
}

function Setcontrols(Responce) {
    if (Responce.ID !== null && Responce.ID !== 0) {
        isDplClick = false;
        cobMemberNumber.SetValue(Responce.ID);
        cobMemberName.SetValue(Responce.ID);

        $("#txtMemberNumber").val(Responce.ListNr);
        $("#txtMemberName").val(Responce.ListDescription);

        cobStudioGroupFrom.SetValue(Responce.StartStudioGroup);
        cobStudioGroupTo.SetValue(Responce.EndStudioGroup);

        cobMemberNameFrom.SetValue(Responce.StartName);
        cobMemberNameTo.SetValue(Responce.EndName);

        cobMemberNumberFrom.SetValue(Responce.StartIdNr);
        cobMemberNumberTo.SetValue(Responce.EndIdNr);

        cobMemberPlaceFrom.SetValue(Responce.StartPlace);
        cobMemberPlaceTo.SetValue(Responce.EndPlace);

        cobMemberPostalCodeFrom.SetValue(Responce.StartPostalCode);
        cobMemberPostalCodeTo.SetValue(Responce.EndPostalCode);

        variableType = (Responce.VariableType);

        switch (variableType) {
            case 1:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableA")[0].checked = true;
                ("#chkMemberName")[0].checked = false;
                $("#chkStudioGroup")[0].checked = true;
                $("#chkPlace")[0].checked = false;
                $("#chkPostalCode")[0].checked = false;
                break;
            case 2:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableB")[0].checked = true;
                $("#chkMemberName")[0].checked = true;
                $("#chkStudioGroup")[0].checked = false;
                $("#chkPlace")[0].checked = false;
                $("#chkPostalCode")[0].checked = false;
                break;
            case 3:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableC")[0].checked = true;
                $("#chkMemberName")[0].checked = false;
                $("#chkStudioGroup")[0].checked = false;
                $("#chkPlace")[0].checked = true;
                $("#chkPostalCode")[0].checked = false;
                break;
            case 4:
                $(".chkAllvar").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkVariableD")[0].checked = true;
                ("#chkMemberName")[0].checked = false;
                $("#chkStudioGroup")[0].checked = false;
                $("#chkPlace")[0].checked = false;
                $("#chkPostalCode")[0].checked = true;
                break;
        }

        memberType = (Responce.PersonType);
        switch (memberType) {
            case 1:
                $(".chkPersTyp").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkActiveMember")[0].checked = true;
                break;
            case 2:
                $(".chkPersTyp").each(function (ev) {
                    this.childNodes[0].checked = false;
                });
                $("#chkInactiveMember")[0].checked = true;
                break;

        }

        if (Responce.ID != 0 || Responce.ID != null) {
            var checkId = Responce.ID;
            PageMethods.GetMemberListCheckbyid(checkId, setCheckBoxes);
        }
        grdSavedMemberList.PerformCallback(Responce.ID);

    } else {
        $("#txtMemberNumber").val("");
        $("#txtMemberName").val("");

        cobStudioGroupFrom.SetValue(0);
        cobStudioGroupTo.SetValue(0);

        cobMemberNameFrom.SetValue(0);
        cobMemberNameTo.SetValue(0);

        cobMemberNumberFrom.SetValue(0);
        cobMemberNumberTo.SetValue(0);

        cobMemberPlaceFrom.SetValue(0);
        cobMemberPlaceTo.SetValue(0);

        cobMemberPostalCodeFrom.SetValue(0);
        cobMemberPostalCodeTo.SetValue(0);

    }
}


function grdSavedMemberListDblClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var ID = grdSavedMemberList.GetRowKey(index);
        PageMethods.GetMemberReportlList(ID, Setcontrols);
    }
}


function setCheckBoxes(Responce) {
    $("#chkStudioGroup")[0].checked = (Responce.ShowMemberGroup);
    $("#chkMemberName")[0].checked = (Responce.ShowName);
    $("#chkMemberNumber")[0].checked = (Responce.ShowIDNr);
    $("#chkPlace")[0].checked = (Responce.ShowPlace);
    $("#chkPostalCode")[0].checked = (Responce.ShowPostalCode);
    $("#chkSalutation")[0].checked = (Responce.ShowSalutation);
    $("#chkStreetNumber")[0].checked = (Responce.ShowStreetAndNr);
    $("#chkContractNumber")[0].checked = (Responce.ShowContractNr);
    $("#chkDateOfBirth")[0].checked = (Responce.ShowDOB);
    $("#chkNationality")[0].checked = (Responce.ShowNationality);
    $("#chkProfession")[0].checked = (Responce.ShowProfession);
    $("#chkTelephone")[0].checked = (Responce.ShowCompanyTelephone);
    $("#chkMobile")[0].checked = (Responce.ShowCompanyMobile);
    $("#chkEmail")[0].checked = (Responce.ShowEmail);
    $("#chkStartDate")[0].checked = (Responce.ShowEntryDate);
    $("#chkEndDate")[0].checked = (Responce.ShowExitDate);
    $("#chkLongtermCard")[0].checked = (Responce.ShowLongTermCard);
    $("#chkShortTermCard")[0].checked = (Responce.ShowShortTermCard);
    $("#chkAccessFromTo")[0].checked = (Responce.ShowAccessFromTo);
    $("#chkAccessPlanNr")[0].checked = (Responce.ShowAccessPlanNr);
    $("#chkAccessPlanName")[0].checked = (Responce.ShowAccessPlanDesc);

}

// #endregion

function ConfirmDeletePersonalList() {
    var message = "Sind Sie sicher das Sie das  Mitgliederlisten tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 13%; margin-right: 0px;"  onclick="DeleteReportPersonalList()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    //   getLocalizedText("deleteAccessProtocole");
    $('#btnOk').text("Mitgliederlisten löschen");
    //  getLocalizedText("cancelAccessProtocole");
    $('#btnCancel').text("Mitgliederlisten nicht löschen");
}

function DeleteReportPersonalList() {
    resetDefault();
    var grp = cobMemberNumber.GetValue();
    if (grp != 0) {
        PageMethods.DeleteMemberReportList(grp, ReloadPage);
    }
}
function resetDefault() {
    document.getElementById('importantDialog').innerHTML = "";
}

function ReloadPage(res) {
    ClearControlAfterDelete();
}

function ClearControlAfterDelete() {
    $("#txtMemberNumber").val("");
    $("#txtMemberName").val("");
    cobStudioGroupFrom.SetValue(0);
    cobStudioGroupTo.SetValue(0);

    cobMemberNameFrom.SetValue(0);
    cobMemberNameTo.SetValue(0);

    cobMemberNumberFrom.SetValue(0);
    cobMemberNumberTo.SetValue(0);

    cobMemberPlaceFrom.SetValue(0);
    cobMemberPlaceTo.SetValue(0);

    cobMemberPostalCodeFrom.SetValue(0);
    cobMemberPostalCodeTo.SetValue(0);


    $("#chkStudioGroup")[0].checked = false;
    $("#chkMemberName")[0].checked = false;
    $("#chkMemberNumber")[0].checked = false;
    $("#chkPlace")[0].checked = false;
    $("#chkPostalCode")[0].checked = false;
    $("#chkSalutation")[0].checked = false;
    $("#chkStreetNumber")[0].checked = false;
    $("#chkContractNumber")[0].checked = false;
    $("#chkDateOfBirth")[0].checked = false;
    $("#chkNationality")[0].checked = false;
    $("#chkProfession")[0].checked = false;
    $("#chkTelephone")[0].checked = false;
    $("#chkMobile")[0].checked = false;
    $("#chkEmail")[0].checked = false;
    $("#chkStartDate")[0].checked = false;
    $("#chkEndDate")[0].checked = false;
    $("#chkLongtermCard")[0].checked = false;
    $("#chkShortTermCard")[0].checked = false;
    $("#chkAccessFromTo")[0].checked = false;
    $("#chkAccessPlanNr")[0].checked = false;
    $("#chkAccessPlanName")[0].checked = false;

    cobMemberNumber.PerformCallback("0");
    cobMemberName.PerformCallback("0");
    grdSavedMemberList.PerformCallback();

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
    var listNr = $("#txtMemberNumber").val();
    if ((cobMemberNumber.GetValue() != 0)) {
        var currentId = cobMemberNumber.GetValue();
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
    var message = "Mitgliederlisten Nr. existiert bereits";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/popupinfo.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div><button id="btnErrorOk"  style="margin-left: 35%; float:right; width: 135px; margin-right: 25px;"  onclick="SetFocus()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    //  getLocalizedText("newSaveWarning");
    $('#btnErrorOk').text("Ok");
}
function SetFocus() {
    resetDefault();

    $("#txtMemberNumber").focus();
    $("#txtMemberNumber").addClass('focusOnError');
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "ReportsMembersList.aspx/GetLocalizedText",
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
