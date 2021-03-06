﻿var reportType = "";
var ConfirmDelete = false;
var SetChangeSelectionEvent = false;
var BuildingPlanFilterLevels = 0;
var isDplClick = false;
$(function () {
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
    $("#btnPrintReport").click(function (evt) {
        evt.preventDefault();
        DispReportToday();
    });

    $("#btnPrintSelection").click(function (evt) {
        evt.preventDefault();
        DisReports();
    });

    $("#imgPotraitPrint").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLandPrint").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgPotraint").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLanda").click(function (evt) {
        evt.preventDefault();
    });

    $('#btnNew').on("click", function (e) {
        e.preventDefault();
        clearcontrols();
        setSaveChanges();
    });

    $("input, select").change(function () {
        setSaveChanges();
    });

    $("#btnEntSave").click(function (e) {
        e.preventDefault();

        var protokollNr = $("#txtAccessReportNo").val();

        if (parseInt(protokollNr) < 1 || isNaN($("#txtAccessReportNo").val()) || protokollNr == "") {

            return;
        }
        else {

            if (cboAccesReportNo.GetValue() == 0) {
                PageMethods.CheckIfProtokollNrExists(protokollNr, OnCheckExists_CallBack);
            }
            else if ((cboAccesReportNo.GetValue() != 0)) {
                var currentId = cboAccesReportNo.GetValue();
                PageMethods.CheckIfProtokollNrExistsOnEdit(protokollNr, currentId, OnCheckExists_CallBack);
            }
            //else {
            //    savePersonalReport();
            //}

        }

        ////savePersonalReport();

    });
    $('#btnCancelDel').click(function (e) {
        e.preventDefault();
        if (parseInt(cboAccesReportNo.GetValue()) > 0) {
            ConfirmDeleteP();
        }
    });

    $("#chkObjDate").change(function () {
        if ($("#chkObjDate")[0].checked == false) {
            $("#chkObjDate")[0].checked = true;
        }
    });

    $("#chkPersonalDate").change(function () {
        if ($("#chkPersonalDate")[0].checked == false) {
            $("#chkPersonalDate")[0].checked = true;
        }
    });

    $("#chkObjTime").change(function () {
        if ($("#chkObjTime")[0].checked == false) {
            $("#chkObjTime")[0].checked = true;
        }
    });

    $("#chkPersTime").change(function () {
        if ($("#chkPersTime")[0].checked == false) {
            $("#chkPersTime")[0].checked = true;
        }
    });

    $("#chkObjDoor").change(function () {
        if ($("#chkObjDoor")[0].checked == false) {
            $("#chkObjDoor")[0].checked = true;
        }
    });

    $("#chkPersReaderDoor").change(function () {
        if ($("#chkPersReaderDoor")[0].checked == false) {
            $("#chkPersReaderDoor")[0].checked = true;
        }
    });

    $("#chkObjPersName").change(function () {
        if ($("#chkObjPersName")[0].checked == false) {
            $("#chkObjPersName")[0].checked = true;
        }
    });

    $("#chkPersonalPersName").change(function () {
        if ($("#chkPersonalPersName")[0].checked == false) {
            $("#chkPersonalPersName")[0].checked = true;
        }
    });

    $('.chkObjects').change(function (evt) {
        $(".chkobjpers").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblPersonal").css('color', "");
            $("#lblPersonalchecks").css('background-color', "");

            disablePersChecks();
            enableObjChecks();
        });

        $(".chkObjects").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblObjectschks").css('background-color', "#FEF1C7");
        });
    });

    $('.chkpersonal').change(function (evt) {
        var sender = this;
        $(".chkobjpers").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblObjectschks").css('color', "");
            $("#lblObjectschks").css('background-color', "");

            disableObjChecks();
            enablePersChecks();
        });
        $(".chkpersonal").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblPersonalchecks").css('background-color', "#FEF1C7");
        });
    });

    $('.chkToday').change(function (evt) {
        $(".chkAll").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblTimePrintType").text("");

        });

        $(".chkToday").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblTimePrintType").text("  Heute");
            $("#lblPersonalPrintType").text("Heute");
            //DisReports();
        });

    });

    $('.chkPreviousDay').change(function (evt) {
        var sender = this;
        $(".chkAll").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblTimePrintType").text("");

            $("#lblPersonalPrintType").text(" ");
            //DisReports();

        });
        $(".chkPreviousDay").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblTimePrintType").text("   Gestern");

            $("#lblPersonalPrintType").text("Gestern");

        });
    });
    $('.chkThisWk').change(function (evt) {
        var sender = this;
        $(".chkAll").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblTimePrintType").text(" ");
            $("#lblPersonalPrintType").text(" ");
            //DisReports();

        });
        $(".chkThisWk").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblTimePrintType").text(" Diese Woche");
            $("#lblPersonalPrintType").text("Diese Woche");
        });
    });
    $('.chkLastWk').change(function (evt) {
        var sender = this;
        $(".chkAll").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblTimePrintType").text("");
            $("#lblPersonalPrintType").text(" ");
            //DisReports();

        });
        $(".chkLastWk").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblTimePrintType").text(" Letze Woche");
            $("#lblPersonalPrintType").text("Letze Woche");

        });
    });
    $('.chkThisMonth').change(function (evt) {
        var sender = this;
        $(".chkAll").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblTimePrintType").text("");
            $("#lblPersonalPrintType").text(" ");
            //DisReports();

        });
        $(".chkThisMonth").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblTimePrintType").text("  Dieser Monat");
            $("#lblPersonalPrintType").text("Dieser Monat");

        });
    });
    $('.chkLastmonth').change(function (evt) {
        var sender = this;
        $(".chkAll").each(function (ev) {
            this.childNodes[0].checked = false;
            $("#lblTimePrintType").text("");
            $("#lblPersonalPrintType").text(" ");
            //DisReports();

        });
        $(".chkLastmonth").each(function (ev) {
            this.childNodes[0].checked = true;
            $("#lblTimePrintType").text(" Letzer Monat ");
            $("#lblPersonalPrintType").text("Letzer Monat");
        });
    });

    $(".chkAll").change(SetDates);

    $('#chkPersShortTermCard, #chkObjShortTermCard, #chkPersLongTermCard, #chkObjLongTermCard, #chkPersonalPersName, #chkObjPersName, #chkPersonalPersCC, #chkObjPersCC, #chkObjCompany, #chkPersCompany, #chkObjPersonalPersLoc, #chkPersonalPersLoc, #chkObjPersDept, #chkPersonalPersDept #chkObjLocation, #chkReaderPersLoc, #chkObjBuilding, #chkPersReaderBuiding, #chkObjLevel, #chkPersReaderLevel, #chkObjRoom, #chkReaderRoom, #chkObjDoor, #chkPersReaderDoor').change(function () {
        if (SetChangeSelectionEvent == true) {
            setSaveChanges();
        } else {
            $('#hiddenFieldSaveChanges').val("0");
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
    $("#chKPersonalPotraint").click(function () {
        if ($("#chKPersonalPotraint")[0].checked === true) {
            $("#chkPersonalLand")[0].checked = false;

        }
        else if ($("#chKPersonalPotraint")[0].checked === false) {
            $("#chkPersonalLand")[0].checked = true;
        }
    });
    $("#chkPersonalLand").click(function () {
        if ($("#chkPersonalLand")[0].checked === true) {
            $("#chKPersonalPotraint")[0].checked = false;

        }
        else if ($("#chkPersonalLand")[0].checked === false) {
            $("#chKPersonalPotraint")[0].checked = true;

        }
    });
})
function DisplayCurrentDate() {
    $("#lblDate").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}

function clearcontrols() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
    cboAccesReportNo.SetValue("0");
    cboAccesReportDesc.SetValue("0");

    $('#chkoject')[0].checked = true;
    if ($('#chkPersonal')[0].checked == true) {
        $('#chkPersonal')[0].checked = false;
    }
    $('#chkObjDate')[0].checked = true;
    $('#chkPersonalDate')[0].checked = true;

    $('#chkObjTime')[0].checked = true;
    $('#chkObjTime')[0].checked = true;

    $('#chkObjDoor')[0].checked = true;
    $('#chkPersReaderDoor')[0].checked = true;

    $('#chkObjPersName')[0].checked = true;
    $('#chkPersonalPersName')[0].checked = true;

    $("#txtAccessReportNo").val('');
    $("#txtAccessReportDesc").val('');

    $('#chkObjLocation')[0].checked = false;
    $('#chkObjBuilding')[0].checked = false;
    $('#chkObjLevel')[0].checked = false;
    $('#chkObjRoom')[0].checked = false;
    $('#chkObjCompany')[0].checked = false;
    $('#chkObjPersonalPersLoc')[0].checked = false;
    $('#chkObjPersDept')[0].checked = false;
    $('#chkObjPersCC')[0].checked = false;
    $('#chkObjLongTermCard')[0].checked = false;
    $('#chkObjShortTermCard')[0].checked = false;


    $('#chkReaderPersLoc')[0].checked = false
    $('#chkPersReaderBuiding')[0].checked = false
    $('#chkPersReaderLevel')[0].checked = false
    $('#chkReaderRoom')[0].checked = false
    $('#chkPersCompany')[0].checked = false
    $('#chkPersonalPersLoc')[0].checked = false
    $('#chkPersonalPersDept')[0].checked = false
    $('#chkPersonalPersCC')[0].checked = false
    $('#chkPersLongTermCard')[0].checked = false
    // $('#chkPersShortTermCard')[0].checked = false


    cboLocation.SetValue("-1#-1");
    cboBuilding.SetValue("-1#-1#-1");
    cboLevels.SetValue("-1#-1#-1#-1");
    cboRooms.SetValue("-1#-1#-1#-1#-1");
    cboDoors.SetValue("-1#-1#-1#-1#-1#-1");
    cboClientName.SetValue(0);
    cbolocationPersonalFrm.SetValue(0);
    cboDeptName.SetValue(0);
    cboCostCenterName.SetValue(0);
    cmbPersName.SetValue(0);
    cboLongTransponder.SetValue(0);
    cboShortTransponder.SetValue(0);

    cboLocation.SetValue("-1#-1");
    cboBuildingTo.SetValue("-1#-1#-1");
    cboLevelsTo.SetValue("-1#-1#-1#-1");
    cboRoomsTo.SetValue("-1#-1#-1#-1#-1");
    cboDoorsTo.SetValue("-1#-1#-1#-1#-1#-1");
    cboClientNameto.SetValue(0);
    cbolocationPersonalTo.SetValue(0);
    cboDeptNameTo.SetValue(0);
    cboCostCenterNameTo.SetValue(0);
    cmbPersNameTo.SetValue(0);
    cboLongTransponderTo.SetValue(0);
    cboShortTransponderTo.SetValue(0);

    dtpFrom.SetDate(moment().toDate());
    dtpTo.SetDate(moment().toDate());

    TimeFrom.SetDate(moment().toDate());
    TimeTo.SetDate(moment().toDate());

    PageMethods.CalculateNextNr(CalculateNextNr_callback)

}

function savePersonalReport() {

    var id = cboAccesReportNo.GetValue();
    var AccessNr = $("#txtAccessReportNo").val();
    var AccessName = $("#txtAccessReportDesc").val();
    var rederLocFrom = cboLocation.GetValue();
    var rederLocTo = cboLocation.GetValue();
    var rederBuildingFrom = cboBuilding.GetValue();
    var rederBuildingTo = cboBuildingTo.GetValue();
    var rederLevelFom = cboLevels.GetValue();
    var rederLevelTo = cboLevelsTo.GetValue();
    var rederRoomFrom = cboRooms.GetValue();
    var rederRoomTo = cboRoomsTo.GetValue();
    var rederDoorFom = cboDoors.GetValue();
    var rederDoorTo = cboDoorsTo.GetValue();

    var perClientNameFrom = cboClientName.GetValue();
    var perClientNameTo = cboClientNameto.GetValue();
    var perLocationFrom = cbolocationPersonalFrm.GetValue();
    var perLocationTo = cbolocationPersonalTo.GetValue();
    var perDeptFrom = cboDeptName.GetValue();
    var perDeptTo = cboDeptNameTo.GetValue();
    var perCoastCenterFrom = cboCostCenterName.GetValue();
    var perCoastCenterTo = cboCostCenterNameTo.GetValue();
    var perPersonalFrom = cmbPersName.GetValue();
    var perPersonalTo = cmbPersNameTo.GetValue();
    var perlongTrannspoderFrom = cboLongTransponder.GetValue();
    var perlongTrannspoderTo = cboLongTransponderTo.GetValue();
    var perShortTrannspoderFrom = cboShortTransponder.GetValue();
    var perShortTrannspoderTo = cboShortTransponderTo.GetValue();
    var dateFrom = moment(dtpFrom.GetDate()).isValid() ? moment(dtpFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var dateTo = moment(dtpTo.GetDate()).isValid() ? moment(dtpTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null; //dtpTo.GetDate();
    var timeFrom = moment(TimeFrom.GetDate()).isValid() ? moment(TimeFrom.GetDate()).format("YYYY-MM-DDTHH:mm:00.000") : null; //TimeFrom.GetDate();
    var timeTo = moment(TimeTo.GetDate()).isValid() ? moment(TimeTo.GetDate()).format("YYYY-MM-DDTHH:mm:00.000") : null; //TimeTo.GetDate();

    var printSelection = 0, date = 0, time = 0, location = 0, building = 0, level = 0, room = 0, door = 0, company = 0, persLocation = 0, persDept = 0, PersCC = 0, persName = 0, persCardnrLng = 0, persCardNrShort = 0;

    if (($('#chkoject').is(':checked'))) {
        printSelection = 0;

    } else if (($('#chkPersonal').is(':checked'))) {
        printSelection = 1;
    }

    if (($('#chkObjDate').is(':checked'))) {
        date = 1;
    } else if (($('#chkPersonalDate').is(':checked'))) {
        date = 1;
    }
    if (($('#chkObjTime').is(':checked'))) {
        time = 1;
    } else if (($('#chkPersTime').is(':checked'))) {
        time = 1;
    }
    if (($('#chkObjLocation').is(':checked'))) {
        location = 1;
    } else if (($('#chkReaderPersLoc').is(':checked'))) {
        location = 1;
    }
    if (($('#chkObjBuilding').is(':checked'))) {
        building = 1;
        //rename chkObjBuilding
    } else if (($('#chkPersReaderBuiding').is(':checked'))) {
        building = 1;
    }
    if (($('#chkObjLevel').is(':checked'))) {
        level = 1;
        //rename chkObjLevel
    } else if (($('#chkPersReaderLevel').is(':checked'))) {
        level = 1;
    }
    if (($('#chkObjRoom').is(':checked'))) {
        room = 1;
        //rename chkObjRoom
    } else if (($('#chkReaderRoom').is(':checked'))) {
        room = 1;
    }
    if (($('#chkObjDoor').is(':checked'))) {
        door = 1;
        //rename chkObjDoor
    } else if (($('#chkReaderDoor').is(':checked'))) {
        door = 1;
    }
    if (($('#chkObjCompany').is(':checked'))) {
        company = 1;
        //rename chkObjCompany
    } else if (($('#chkPersCompany').is(':checked'))) {
        company = 1;
    }
    if (($('#chkObjPersonalPersLoc').is(':checked'))) {
        persLocation = 1;
        //rename chkObjPersLoc
    } else if (($('#chkPersonalPersLoc').is(':checked'))) {
        persLocation = 1;
    }
    if (($('#chkObjPersDept').is(':checked'))) {
        persDept = 1;
        //rename chkObjPersDept
    } else if (($('#chkPersonalPersDept').is(':checked'))) {
        persDept = 1;
    }
    if (($('#chkObjPersCC').is(':checked'))) {
        PersCC = 1;
        //rename chkObjPersCC
    } else if (($('#chkPersonalPersCC').is(':checked'))) {
        PersCC = 1;
    }
    if (($('#chkObjPersName').is(':checked'))) {
        persName = 1;
        //rename chkObjPersCC
    } else if (($('#chkPersonalPersName').is(':checked'))) {
        persName = 1;
    }
    if (($('#chkObjLongTermCard').is(':checked'))) {
        persCardnrLng = 1;
    } else if (($('#chkPersLongTermCard').is(':checked'))) {
        persCardnrLng = 1;
    }
    if (($('#chkObjShortTermCard').is(':checked'))) {
        persCardNrShort = 1;
    } else if (($('#chkPersShortTermCard').is(':checked'))) {
        persCardNrShort = 1;
    }

    if (id == 0) {

        PageMethods.CreateEditAccessReports(id, AccessNr, AccessName, rederLocFrom, rederLocTo, rederBuildingFrom, rederBuildingTo, rederLevelFom, rederLevelTo, rederRoomFrom, rederRoomTo, rederDoorFom, rederDoorTo,
        perClientNameFrom, perClientNameTo, perLocationFrom, perLocationTo, perDeptFrom, perDeptTo, perCoastCenterFrom, perCoastCenterTo, perPersonalFrom, perPersonalTo, perlongTrannspoderFrom, perlongTrannspoderTo,
        perShortTrannspoderFrom, perShortTrannspoderTo, dateFrom, dateTo, printSelection, date, time, location, building, level, room, door, company, persLocation, persDept, PersCC, persName, persCardnrLng, persCardNrShort, timeFrom, timeTo, SetValuesNew);
    } else {

        PageMethods.CreateEditAccessReports(id, AccessNr, AccessName, rederLocFrom, rederLocTo, rederBuildingFrom, rederBuildingTo, rederLevelFom, rederLevelTo, rederRoomFrom, rederRoomTo, rederDoorFom, rederDoorTo,
        perClientNameFrom, perClientNameTo, perLocationFrom, perLocationTo, perDeptFrom, perDeptTo, perCoastCenterFrom, perCoastCenterTo, perPersonalFrom, perPersonalTo, perlongTrannspoderFrom, perlongTrannspoderTo,
        perShortTrannspoderFrom, perShortTrannspoderTo, dateFrom, dateTo, printSelection, date, time, location, building, level, room, door, company, persLocation, persDept, PersCC, persName, persCardnrLng, persCardNrShort, timeFrom, timeTo, SetValuesOnEdit);
    }

}
function resetSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
}
function SetValuesNew(response) {
    if (response.AccessNr != 0) {
        resetSaveChanges();
        isDplClick = false;
        $("#txtAccessReportNo").addClass('removeBorderOnError');

        $("#txtAccessReportNo").val(response.Nr);
        $("#txtAccessReportDesc").val(response.Name);

        cboLocation.SetValue(response.StartLocationB);
        cboLocation.SetValue(response.EndLocationB);
        cboBuilding.SetValue(response.StartBuilding);
        cboBuildingTo.SetValue(response.EndBuilding);
        cboLevels.SetValue(response.StartLevel);
        cboLevelsTo.SetValue(response.EndLevel);
        cboRooms.SetValue(response.StartRoom);
        cboRoomsTo.SetValue(response.EndRoom);
        cboDoors.SetValue(response.StartDoor);
        cboDoorsTo.SetValue(response.EndDoor);
        cboClientName.SetValue(response.StartClient);
        cboClientNameto.SetValue(response.EndClient);
        cbolocationPersonalFrm.SetValue(response.StartLocation);
        cbolocationPersonalTo.SetValue(response.EndLocation);
        cboDeptName.SetValue(response.StartDept);
        cboDeptNameTo.SetValue(response.EndDept);
        cboCostCenterName.SetValue(response.StartCostCenter);
        cboCostCenterNameTo.SetValue(response.EndCostCenter);
        cmbPersName.SetValue(response.StartPersonal);
        cmbPersNameTo.SetValue(response.EndPersonal);
        cboLongTransponder.SetValue(response.StartLongTranspoder);
        cboLongTransponderTo.SetValue(response.EndLongTransponder);
        cboShortTransponder.SetValue(response.StartShortTransponder);
        cboShortTransponderTo.SetValue(response.EndShortTranspoder);
        cboAccesReportNo.SetEnabled(true);
        cboAccesReportDesc.SetEnabled(true);
        cboAccesReportNo.PerformCallback(response.ID);
        cboAccesReportDesc.PerformCallback(response.ID);
        //cboAccesReportNo.SetValue(response.Nr.toString());
        //cboAccesReportDesc.SetValue(response.Name);

        dtpFrom.SetDate(response.StartDate == null ? null : new Date(response.StartDate));
        dtpTo.SetDate(response.EndDate == null ? null : new Date(response.EndDate));

        TimeFrom.SetDate(response.StartTime == null ? null : new Date(response.StartTime));
        TimeTo.SetDate(response.EndTime == null ? null : new Date(response.EndTime));

        if (response.PrintSelection == 0) {
            $('#chkoject')[0].checked = true;
            $('#chkPersonal')[0].checked = false;

            // $('#chkObjDate')[0].checked = (response.ShowDate);
            //   $('#chkObjTime')[0].checked = (response.ShowTime);
            $('#chkObjLocation')[0].checked = (response.ShowBuildingLocation);
            $('#chkObjBuilding')[0].checked = (response.ShowBuilding);
            $('#chkObjLevel')[0].checked = (response.ShowFloor);
            $('#chkObjRoom')[0].checked = (response.ShowRoom);
            //  $('#chkObjDoor')[0].checked = (response.ShowReader);
            $('#chkObjCompany')[0].checked = (response.ShowCompany);
            $('#chkObjPersonalPersLoc')[0].checked = (response.ShowPersLocation);
            $('#chkObjPersDept')[0].checked = (response.ShowPersDepartment);
            $('#chkObjPersCC')[0].checked = (response.ShowPersCC);
            //  $('#chkObjPersName')[0].checked = (response.ShowPersName);
            $('#chkObjLongTermCard')[0].checked = (response.ShowPersCardNrLong);
            $('#chkObjShortTermCard')[0].checked = (response.ShowPersCardNrShort);

        }
        else if (response.PrintSelection == 1) {
            $('#chkPersonal')[0].checked = true;
            $('#chkoject')[0].checked = false;

            // $('#chkPersonalDate')[0].checked = (response.ShowDate);
            //  $('#chkObjTime')[0].checked = (response.ShowTime);
            $('#chkReaderPersLoc')[0].checked = (response.ShowBuildingLocation);
            $('#chkPersReaderBuiding')[0].checked = (response.ShowBuilding);
            $('#chkPersReaderLevel')[0].checked = (response.ShowFloor);
            $('#chkReaderRoom')[0].checked = (response.ShowRoom);
            // $('#chkPersReaderDoor')[0].checked = (response.ShowReader);
            $('#chkPersCompany')[0].checked = (response.ShowCompany);
            $('#chkPersonalPersLoc')[0].checked = (response.ShowPersLocation);
            $('#chkPersonalPersDept')[0].checked = (response.ShowPersDepartment);
            $('#chkPersonalPersCC')[0].checked = (response.ShowPersCC);
            //  $('#chkPersonalPersName')[0].checked = (response.ShowPersName);
            $('#chkPersLongTermCard')[0].checked = (response.ShowPersCardNrLong);
            // $('#chkPersShortTermCard')[0].checked = (response.ShowPersCardNrShort);
        }



        grdReport.PerformCallback();

    } else {
        $("#txtAccessReportNo").val();
        $("#txtAccessReportDesc").val();
    }


}


function SetValuesOnEdit(response) {
    if (response.AccessNr != 0) {
        resetSaveChanges();
        isDplClick = false;
        $("#txtAccessReportNo").addClass('removeBorderOnError');
        $("#txtAccessReportNo").val(response.Nr);
        $("#txtAccessReportDesc").val(response.Name);

        cboLocation.SetValue(response.StartLocationB);
        cboLocationTo.SetValue(response.EndLocationB);
        cboBuilding.SetValue(response.StartBuilding);
        cboBuildingTo.SetValue(response.EndBuilding);
        cboLevels.SetValue(response.StartLevel);
        cboLevelsTo.SetValue(response.EndLevel);
        cboRooms.SetValue(response.StartRoom);
        cboRoomsTo.SetValue(response.EndRoom);
        cboDoors.SetValue(response.StartDoor);
        cboDoorsTo.SetValue(response.EndDoor);
        cboClientName.SetValue(response.StartClient);
        cboClientNameto.SetValue(response.EndClient);
        cbolocationPersonalFrm.SetValue(response.StartLocation);
        cbolocationPersonalTo.SetValue(response.EndLocation);
        cboDeptName.SetValue(response.StartDept);
        cboDeptNameTo.SetValue(response.EndDept);
        cboCostCenterName.SetValue(response.StartCostCenter);
        cboCostCenterNameTo.SetValue(response.EndCostCenter);
        cmbPersName.SetValue(response.StartPersonal);
        cmbPersNameTo.SetValue(response.EndPersonal);
        cboLongTransponder.SetValue(response.StartLongTranspoder);
        cboLongTransponderTo.SetValue(response.EndLongTransponder);
        cboShortTransponder.SetValue(response.StartShortTransponder);
        cboShortTransponderTo.SetValue(response.EndShortTranspoder);
        cboAccesReportNo.SetEnabled(true);
        cboAccesReportDesc.SetEnabled(true);
        cboAccesReportNo.PerformCallback(response.ID);
        cboAccesReportDesc.PerformCallback(response.ID);
        //cboAccesReportNo.SetValue();
        //cboAccesReportDesc.SetValue();

        dtpFrom.SetDate(response.StartDate == null ? null : new Date(response.StartDate));
        dtpTo.SetDate(response.EndDate == null ? null : new Date(response.EndDate));

        TimeFrom.SetDate(response.StartTime == null ? null : new Date(response.StartTime));
        TimeTo.SetDate(response.EndTime == null ? null : new Date(response.EndTime));

        if (response.PrintSelection == 0) {
            $('#chkoject')[0].checked = true;
            $('#chkPersonal')[0].checked = false;

            //  $('#chkObjDate')[0].checked = (response.ShowDate);
            //  $('#chkObjTime')[0].checked = (response.ShowTime);
            $('#chkObjLocation')[0].checked = (response.ShowBuildingLocation);
            $('#chkObjBuilding')[0].checked = (response.ShowBuilding);
            $('#chkObjLevel')[0].checked = (response.ShowFloor);
            $('#chkObjRoom')[0].checked = (response.ShowRoom);
            // $('#chkObjDoor')[0].checked = (response.ShowReader);
            $('#chkObjCompany')[0].checked = (response.ShowCompany);
            $('#chkObjPersonalPersLoc')[0].checked = (response.ShowPersLocation);
            $('#chkObjPersDept')[0].checked = (response.ShowPersDepartment);
            $('#chkObjPersCC')[0].checked = (response.ShowPersCC);
            // $('#chkObjPersName')[0].checked = (response.ShowPersName);
            $('#chkObjLongTermCard')[0].checked = (response.ShowPersCardNrLong);
            $('#chkObjShortTermCard')[0].checked = (response.ShowPersCardNrShort);

        }
        else if (response.PrintSelection == 1) {
            $('#chkPersonal')[0].checked = true;
            $('#chkoject')[0].checked = false;

            //   $('#chkPersonalDate')[0].checked = (response.ShowDate);
            //  $('#chkObjTime')[0].checked = (response.ShowTime);
            $('#chkReaderPersLoc')[0].checked = (response.ShowBuildingLocation);
            $('#chkPersReaderBuiding')[0].checked = (response.ShowBuilding);
            $('#chkPersReaderLevel')[0].checked = (response.ShowFloor);
            $('#chkReaderRoom')[0].checked = (response.ShowRoom);
            // $('#chkPersReaderDoor')[0].checked = (response.ShowReader);
            $('#chkPersCompany')[0].checked = (response.ShowCompany);
            $('#chkPersonalPersLoc')[0].checked = (response.ShowPersLocation);
            $('#chkPersonalPersDept')[0].checked = (response.ShowPersDepartment);
            $('#chkPersonalPersCC')[0].checked = (response.ShowPersCC);
            //  $('#chkPersonalPersName')[0].checked = (response.ShowPersName);
            $('#chkPersLongTermCard')[0].checked = (response.ShowPersCardNrLong);
            //   $('#chkPersShortTermCard')[0].checked = (response.ShowPersCardNrShort);
        }



        grdReport.PerformCallback();

    } else {
        $("#txtAccessReportNo").val();
        $("#txtAccessReportDesc").val();


        cboLocation.SetValue(0);
        cboLocation.SetValue(0);
        cboBuilding.SetValue(0);
        cboBuildingTo.SetValue(0);
        cboLevels.SetValue(0);
        cboLevelsTo.SetValue(0);
        cboRooms.SetValue(0);
        cboRoomsTo.SetValue(0);
        cboDoors.SetValue(0);
        cboDoorsTo.SetValue(0);
        cboClientName.SetValue(0);
        cboClientNameto.SetValue(0);
        cbolocationPersonalFrm.SetValue(0);
        cbolocationPersonalTo.SetValue(0);
        cboDeptName.SetValue(0);
        cboDeptNameTo.SetValue(0);
        cboCostCenterName.SetValue(0);
        cboCostCenterNameTo.SetValue(0);
        cmbPersName.SetValue(0);
        cmbPersNameTo.SetValue(0);
        cboLongTransponder.SetValue(0);
        cboLongTransponderTo.SetValue(0);
        cboShortTransponder.SetValue(0);
        cboShortTransponderTo.SetValue(0);
        cboAccesReportNo.SetValue(0);
        cboAccesReportDesc.SetValue(0);

        //dtpFrom.SetDate(response.StartDate == null ? null : new Date(response.StartDate));
        //dtpTo.SetDate(response.EndDate == null ? null : new Date(response.EndDate));

        //TimeFrom.SetDate(response.StartTime == null ? null : new Date(response.StartTime));
        //TimeTo.SetDate(response.EndTime == null ? null : new Date(response.EndTime));
    }
}


function CalculateNextNr_callback(succ) {

    document.getElementById('txtAccessReportNo').value = succ;

    cboAccesReportNo.SetEnabled(false);
    cboAccesReportDesc.SetEnabled(false);
    $("#txtAccessReportDesc").focus();
}

function cboAccesReportNoAcces(value) {
    if (isDplClick === true) {
        cboAccesReportNo.SetValue(value);
        cboAccesReportDesc.SetValue(value);
        SetValues(value);
        SetChangeSelectionEvent = true;
    }

}
function SetValues(value) {
    PageMethods.GetAcceeReportbyid(value, ReloadDropDowns);
}
function cboAccesReportDescAcces(value) {
    if (isDplClick === true) {
        cboAccesReportNo.SetValue(value);
        cboAccesReportDesc.SetValue(value);
        SetValues(value);
        SetChangeSelectionEvent = true;
    }

}

function LocationIndexChanged(sender, evt) {
    var keineValue = "-1#-1";
    var cboOther = sender == cboLocation ? cboLocationTo : cboLocation;

    if (cboOther.GetValue() == keineValue) cboOther.SetValue(sender.GetValue());

    //LoadBuildings();
    if (SetChangeSelectionEvent == true) {
        setSaveChanges();
    }

    setTimeout(function () { GetBuildingPlanDetails(1); }, 4);
}

function BuildingsIndexChanged(sender, evt) {
    var keineValue = "-1#-1#-1";
    var cboOther = sender == cboBuilding ? cboBuildingTo : cboBuilding;

    if (cboOther.GetValue() == keineValue) cboOther.SetValue(sender.GetValue());

    //LoadLevels();
    if (SetChangeSelectionEvent == true) {
        setSaveChanges();
    }

    setTimeout(function () { GetBuildingPlanDetails(2); }, 4);
}

function LevelsIndexChanged(sender, evt) {
    var keineValue = "-1#-1#-1#-1";
    var cboOther = sender == cboLevels ? cboLevelsTo : cboLevels;

    if (cboOther.GetValue() == keineValue) cboOther.SetValue(sender.GetValue());

    //LoadRooms();
    if (SetChangeSelectionEvent == true) {
        setSaveChanges();
    }

    setTimeout(function () { GetBuildingPlanDetails(3); }, 4);
}

function RoomsIndexChanged(sender, evt) {
    var keineValue = "-1#-1#-1#-1#-1";
    var cboOther = sender == cboRooms ? cboRoomsTo : cboRooms;

    if (cboOther.GetValue() == keineValue) cboOther.SetValue(sender.GetValue());

    //LoadDoors();
    if (SetChangeSelectionEvent == true) {
        setSaveChanges();
    }

    setTimeout(function () { GetBuildingPlanDetails(4); }, 4);
}

function DoorsIndexChanged(sender, evt) {
    var keineValue = "-1#-1#-1#-1#-1#-1";
    var cboOther = sender == cboDoors ? cboDoorsTo : cboDoors;

    if (cboOther.GetValue() == keineValue) cboOther.SetValue(sender.GetValue());
    if (SetChangeSelectionEvent == true) {
        setSaveChanges();
    }

    //setTimeout(function () { GetBuildingPlanDetails(); }, 4);
}

function LoadBuildings() {
    setTimeout(function () { cboBuilding.PerformCallback() }, 100);
    setTimeout(function () { cboBuildingTo.PerformCallback() }, 200);
}

function LoadLevels() {
    setTimeout(function () { cboLevels.PerformCallback() }, 100);
    setTimeout(function () { cboLevelsTo.PerformCallback() }, 200);
}

function LoadRooms() {
    setTimeout(function () { cboRooms.PerformCallback() }, 100);
    setTimeout(function () { cboRoomsTo.PerformCallback() }, 200);
}

function LoadDoors() {
    setTimeout(function () { cboDoors.PerformCallback() }, 100);
    setTimeout(function () { cboDoorsTo.PerformCallback() }, 200);
}

function EndCallbackBuildings(sender, evt) {
    cboBuilding.SetValue("-1#-1#-1");
    cboBuildingTo.SetValue("-1#-1#-1");
}
function EndCallbackFloors(sender, evt) {
    cboLevels.SetValue("-1#-1#-1#-1");
    cboLevelsTo.SetValue("-1#-1#-1#-1");
}
function EndCallbackRooms(sender, evt) {
    cboRooms.SetValue("-1#-1#-1#-1#-1");
    cboRoomsTo.SetValue("-1#-1#-1#-1#-1");
}
function EndCallbackDoors(sender, evt) {
    cboDoors.SetValue("-1#-1#-1#-1#-1#-1");
    cboDoorsTo.SetValue("-1#-1#-1#-1#-1#-1");
}

function populatecontrolls(response) {
    if (response.ID != null && response.ID != 0) {
        cboAccesReportNo.SetValue(response.ID);
        cboAccesReportDesc.SetValue(response.ID);
        $("#txtAccessReportNo").val(response.Nr);
        $("#txtAccessReportDesc").val(response.Name);

        cboLocation.SetValue(response.StartLocationB);
        cboLocationTo.SetValue(response.EndLocationB);
        cboBuilding.SetValue(response.StartBuilding);
        cboBuildingTo.SetValue(response.EndBuilding);
        cboLevels.SetValue(response.StartLevel);
        cboLevelsTo.SetValue(response.EndLevel);
        cboRooms.SetValue(response.StartRoom);
        cboRoomsTo.SetValue(response.EndRoom);
        cboDoors.SetValue(response.StartDoor); //cboDoors.SetText("");
        cboDoorsTo.SetValue(response.EndDoor); //cboDoorsTo.SetText("");

        setTimeout(function () {
            GetBuildingPlanDetailsFromGrd(response.StartLocationB, response.EndLocationB, response.StartBuilding, response.EndBuilding, response.StartLevel, response.EndLevel,
                response.StartRoom, response.EndRoom);
        }, 4);

        cboClientName.SetValue(response.StartClient);
        cboClientNameto.SetValue(response.EndClient);
        cbolocationPersonalFrm.SetValue(response.StartLocation);
        cbolocationPersonalTo.SetValue(response.EndLocation);
        cboDeptName.SetValue(response.StartDept);
        cboDeptNameTo.SetValue(response.EndDept);
        cboCostCenterName.SetValue(response.StartCostCenter);
        cboCostCenterNameTo.SetValue(response.EndCostCenter);
        cmbPersName.SetValue(response.StartPersonal);
        cmbPersNameTo.SetValue(response.EndPersonal);
        cboLongTransponder.SetValue(response.StartLongTranspoder);
        cboLongTransponderTo.SetValue(response.EndLongTransponder);
        cboShortTransponder.SetValue(response.StartShortTransponder);
        cboShortTransponderTo.SetValue(response.EndShortTranspoder);

        dtpFrom.SetDate(response.StartDate == null ? null : new Date(response.StartDate));
        dtpTo.SetDate(response.EndDate == null ? null : new Date(response.EndDate));

        TimeFrom.SetDate(response.StartTime == null ? null : new Date(response.StartTime));
        TimeTo.SetDate(response.EndTime == null ? null : new Date(response.EndTime));

        //  GetAccessCheckbyid
        if (response.ID != 0 || response.ID != null) {
            var checkId = response.ID;
            PageMethods.GetAccessCheckbyid(checkId, setCheckBoxes);
        }

        enableObjChecks();
        enablePersChecks();
    }
    else {
        $("#txtAccessReportNo").val();
        $("#txtAccessReportDesc").val();
    }

}

function setCheckBoxes(response) {
    //if (response.PrintSelection == 0) {

    //    $("#lblObjectschks ").css("background-color", "#FEF1C7");
    //    $("#lblPersonalchecks").css("background-color", "");

    //    $('#chkoject')[0].checked = true;
    //    $('#chkPersonal')[0].checked = false;
    //    //$('#chkObjDate')[0].checked = (response.ShowDate);
    //    // $('#chkObjTime')[0].checked = (response.ShowTime);
    //    $('#chkObjLocation')[0].checked = (response.ShowBuildingLocation);
    //    $('#chkObjBuilding')[0].checked = (response.ShowBuilding);
    //    $('#chkObjLevel')[0].checked = (response.ShowFloor);
    //    $('#chkObjRoom')[0].checked = (response.ShowRoom);
    //    // $('#chkObjDoor')[0].checked = (response.ShowReader);
    //    $('#chkObjCompany')[0].checked = (response.ShowCompany);
    //    $('#chkObjPersonalPersLoc')[0].checked = (response.ShowPersLocation);
    //    $('#chkObjPersDept')[0].checked = (response.ShowPersDepartment);
    //    $('#chkObjPersCC')[0].checked = (response.ShowPersCC);
    //    // $('#chkObjPersName')[0].checked = (response.ShowPersName);
    //    $('#chkObjLongTermCard')[0].checked = (response.ShowPersCardNrLong);
    //    $('#chkObjShortTermCard')[0].checked = (response.ShowPersCardNrShort);

    //    //   $('#chkPersonalDate')[0].checked = false;
    //    $('#chkReaderPersLoc')[0].checked = false;
    //    $('#chkPersReaderBuiding')[0].checked = false;
    //    $('#chkPersReaderLevel')[0].checked = false;
    //    $('#chkReaderRoom')[0].checked = false;
    //    //   $('#chkPersReaderDoor')[0].checked = false;
    //    $('#chkPersCompany')[0].checked = false;
    //    $('#chkPersonalPersLoc')[0].checked = false;
    //    $('#chkPersonalPersDept')[0].checked = false;
    //    $('#chkPersonalPersCC')[0].checked = false;
    //    // $('#chkPersonalPersName')[0].checked = false;
    //    $('#chkPersLongTermCard')[0].checked = false;
    //  //  $('#chkPersShortTermCard')[0].checked = false;

    //}
    //else if (response.PrintSelection == 1) {

    //    $("#lblPersonalchecks").css("background-color", "#FEF1C7");
    //    $("#lblObjectschks").css("background-color", "");

    //    $('#chkPersonal')[0].checked = true;
    //    $('#chkoject')[0].checked = false;

    //    $('#chkReaderPersLoc')[0].checked = (response.ShowBuildingLocation);
    //    $('#chkPersReaderBuiding')[0].checked = (response.ShowBuilding);
    //    $('#chkPersReaderLevel')[0].checked = (response.ShowFloor);
    //    $('#chkReaderRoom')[0].checked = (response.ShowRoom);
    //    $('#chkPersCompany')[0].checked = (response.ShowCompany);
    //    $('#chkPersonalPersLoc')[0].checked = (response.ShowPersLocation);
    //    $('#chkPersonalPersDept')[0].checked = (response.ShowPersDepartment);
    //    $('#chkPersonalPersCC')[0].checked = (response.ShowPersCC);
    //    $('#chkPersLongTermCard')[0].checked = (response.ShowPersCardNrLong);

    //    $('#chkObjLocation')[0].checked = false;
    //    $('#chkObjBuilding')[0].checked = false;
    //    $('#chkObjLevel')[0].checked = false;
    //    $('#chkObjRoom')[0].checked = false;
    //    $('#chkObjCompany')[0].checked = false;
    //    $('#chkObjPersonalPersLoc')[0].checked = false;
    //    $('#chkObjPersDept')[0].checked = false;
    //    $('#chkObjPersCC')[0].checked = false;
    //    $('#chkObjLongTermCard')[0].checked = false;
    //    $('#chkObjShortTermCard')[0].checked = false;
    //}



    if (response.PrintSelection == 0) {
        $('#chkoject')[0].checked = true;
        $('#chkPersonal')[0].checked = false;

        $('#chkObjLocation')[0].checked = (response.ShowBuildingLocation);
        $('#chkObjBuilding')[0].checked = (response.ShowBuilding);
        $('#chkObjLevel')[0].checked = (response.ShowFloor);
        $('#chkObjRoom')[0].checked = (response.ShowRoom);
        $('#chkObjCompany')[0].checked = (response.ShowCompany);
        $('#chkObjPersonalPersLoc')[0].checked = (response.ShowPersLocation);
        $('#chkObjPersDept')[0].checked = (response.ShowPersDepartment);
        $('#chkObjPersCC')[0].checked = (response.ShowPersCC);
        $('#chkObjLongTermCard')[0].checked = (response.ShowPersCardNrLong);
        $('#chkObjShortTermCard')[0].checked = (response.ShowPersCardNrShort);

    }
    else if (response.PrintSelection == 1) {
        $('#chkPersonal')[0].checked = true;
        $('#chkoject')[0].checked = false;

        $('#chkReaderPersLoc')[0].checked = (response.ShowBuildingLocation);
        $('#chkPersReaderBuiding')[0].checked = (response.ShowBuilding);
        $('#chkPersReaderLevel')[0].checked = (response.ShowFloor);
        $('#chkReaderRoom')[0].checked = (response.ShowRoom);
        $('#chkPersCompany')[0].checked = (response.ShowCompany);
        $('#chkPersonalPersLoc')[0].checked = (response.ShowPersLocation);
        $('#chkPersonalPersDept')[0].checked = (response.ShowPersDepartment);
        $('#chkPersonalPersCC')[0].checked = (response.ShowPersCC);
        $('#chkPersLongTermCard')[0].checked = (response.ShowPersCardNrLong);
    }


}
function ReloadDropDowns(response) {
    if (response == null) {

        $("#txtAccessReportNo").val("");
        $("#txtAccessReportDesc").val("");
        cboLocation.SetValue("-1#-1");
        cboBuilding.SetValue("-1#-1#-1");
        cboLevels.SetValue("-1#-1#-1#-1");
        cboRooms.SetValue("-1#-1#-1#-1#-1");
        cboDoors.SetValue("-1#-1#-1#-1#-1#-1");
        cboBuildingTo.SetValue("-1#-1#-1");
        cboLevelsTo.SetValue("-1#-1#-1#-1");
        cboRoomsTo.SetValue("-1#-1#-1#-1#-1");
        cboDoorsTo.SetValue("-1#-1#-1#-1#-1#-1");
        cboClientName.SetValue(0);
        cboClientNameto.SetValue(0);
        cbolocationPersonalFrm.SetValue(0);
        cbolocationPersonalTo.SetValue(0);
        cboDeptName.SetValue(0);
        cboDeptNameTo.SetValue(0);
        cboCostCenterName.SetValue(0);
        cboCostCenterNameTo.SetValue(0);
        cmbPersName.SetValue(0);
        cmbPersNameTo.SetValue(0);
        cboLongTransponder.SetValue(0);
        cboLongTransponderTo.SetValue(0);
        cboShortTransponder.SetValue(0);
        cboShortTransponderTo.SetValue(0);
        cboAccesReportNo.SetValue(0);
        cboAccesReportDesc.SetValue(0);
    } else {
        if (response.ID != null || response.ID != 0) {
            cboAccesReportNo.SetValue(response.ID);
            cboAccesReportDesc.SetValue(response.Name);
            $("#txtAccessReportNo").val(response.Nr);
            $("#txtAccessReportDesc").val(response.Name);

            cboLocation.SetValue(response.StartLocationB);
            cboLocationTo.SetValue(response.EndLocationB);
            cboBuilding.SetValue(response.StartBuilding);
            cboBuildingTo.SetValue(response.EndBuilding);
            cboLevels.SetValue(response.StartLevel);
            cboLevelsTo.SetValue(response.EndLevel);
            cboRooms.SetValue(response.StartRoom);
            cboRoomsTo.SetValue(response.EndRoom);
            cboDoors.SetValue(response.StartDoor);
            cboDoorsTo.SetValue(response.EndDoor);

            setTimeout(function () {
                GetBuildingPlanDetailsFromGrd(response.StartLocationB, response.EndLocationB, response.StartBuilding, response.EndBuilding, response.StartLevel, response.EndLevel,
                    response.StartRoom, response.EndRoom);
            }, 4);

            cboClientName.SetValue(response.StartClient);
            cboClientNameto.SetValue(response.EndClient);
            cbolocationPersonalFrm.SetValue(response.StartLocation);
            cbolocationPersonalTo.SetValue(response.EndLocation);
            cboDeptName.SetValue(response.StartDept);
            cboDeptNameTo.SetValue(response.EndDept);
            cboCostCenterName.SetValue(response.StartCostCenter);
            cboCostCenterNameTo.SetValue(response.EndCostCenter);
            cmbPersName.SetValue(response.StartPersonal);
            cmbPersNameTo.SetValue(response.EndPersonal);
            cboLongTransponder.SetValue(response.StartLongTranspoder);
            cboLongTransponderTo.SetValue(response.EndLongTransponder);
            cboShortTransponder.SetValue(response.StartShortTransponder);
            cboShortTransponderTo.SetValue(response.EndShortTranspoder);

            dtpFrom.SetDate(response.StartDate == null ? null : new Date(response.StartDate));
            dtpTo.SetDate(response.EndDate == null ? null : new Date(response.EndDate));

            TimeFrom.SetDate(response.StartTime == null ? null : new Date(response.StartTime));
            TimeTo.SetDate(response.EndTime == null ? null : new Date(response.EndTime));



            if (response.ID != 0 || response.ID != null) {
                var checkId = response.ID;
                PageMethods.GetAccessCheckbyid(checkId, setCheckBoxes);
            }

            //if (response.PrintSelection == 0) {
            //    $('#chkoject')[0].checked = true;
            //    $('#chkPersonal')[0].checked = false;

            //    // $('#chkObjDate')[0].checked = (response.ShowDate);
            //    // $('#chkObjTime')[0].checked = (response.ShowTime);
            //    $('#chkObjLocation')[0].checked = (response.ShowBuildingLocation);
            //    $('#chkObjBuilding')[0].checked = (response.ShowBuilding);
            //    $('#chkObjLevel')[0].checked = (response.ShowFloor);
            //    $('#chkObjRoom')[0].checked = (response.ShowRoom);
            //    // $('#chkObjDoor')[0].checked = (response.ShowReader);
            //    $('#chkObjCompany')[0].checked = (response.ShowCompany);
            //    $('#chkObjPersonalPersLoc')[0].checked = (response.ShowPersLocation);
            //    $('#chkObjPersDept')[0].checked = (response.ShowPersDepartment);
            //    $('#chkObjPersCC')[0].checked = (response.ShowPersCC);
            //    //   $('#chkObjPersName')[0].checked = (response.ShowPersName);
            //    $('#chkObjLongTermCard')[0].checked = (response.ShowPersCardNrLong);
            //    $('#chkObjShortTermCard')[0].checked = (response.ShowPersCardNrShort);

            //}
            //else if (response.PrintSelection == 1) {
            //    $('#chkPersonal')[0].checked = true;
            //    $('#chkoject')[0].checked = false;

            //    // $('#chkPersonalDate')[0].checked = (response.ShowDate);
            //    //$('#chkObjTime')[0].checked = (response.ShowTime);
            //    $('#chkReaderPersLoc')[0].checked = (response.ShowBuildingLocation);
            //    $('#chkPersReaderBuiding')[0].checked = (response.ShowBuilding);
            //    $('#chkPersReaderLevel')[0].checked = (response.ShowFloor);
            //    $('#chkReaderRoom')[0].checked = (response.ShowRoom);
            //    //  $('#chkPersReaderDoor')[0].checked = (response.ShowReader);
            //    $('#chkPersCompany')[0].checked = (response.ShowCompany);
            //    $('#chkPersonalPersLoc')[0].checked = (response.ShowPersLocation);
            //    $('#chkPersonalPersDept')[0].checked = (response.ShowPersDepartment);
            //    $('#chkPersonalPersCC')[0].checked = (response.ShowPersCC);
            //    // $('#chkPersonalPersName')[0].checked = (response.ShowPersName);
            //    $('#chkPersLongTermCard')[0].checked = (response.ShowPersCardNrLong);
            //  //  $('#chkPersShortTermCard')[0].checked = (response.ShowPersCardNrShort);
            //}

            // grdReport.SetFocusedRowIndex(response.Nr);
        }
        else {
            $("#txtAccessReportNo").val("");
            $("#txtAccessReportDesc").val("");
            cboLocation.SetValue(0);
            cboLocation.SetValue(0);
            cboBuilding.SetValue(0);
            cboBuildingTo.SetValue(0);
            cboLevels.SetValue(0);
            cboLevelsTo.SetValue(0);
            cboRooms.SetValue(0);
            cboRoomsTo.SetValue(0);
            cboDoors.SetValue(0);
            cboDoorsTo.SetValue(0);
            cboClientName.SetValue(0);
            cboClientNameto.SetValue(0);
            cbolocationPersonalFrm.SetValue(0);
            cbolocationPersonalTo.SetValue(0);
            cboDeptName.SetValue(0);
            cboDeptNameTo.SetValue(0);
            cboCostCenterName.SetValue(0);
            cboCostCenterNameTo.SetValue(0);
            cmbPersName.SetValue(0);
            cmbPersNameTo.SetValue(0);
            cboLongTransponder.SetValue(0);
            cboLongTransponderTo.SetValue(0);
            cboShortTransponder.SetValue(0);
            cboShortTransponderTo.SetValue(0);
            cboAccesReportNo.SetValue(0);
            cboAccesReportDesc.SetValue(0);

        }
    }



}


function cboBuildingselct(s, e) {
    var buildFrom = cboBuilding.GetValue();
    var buidTo = cboBuildingTo.GetValue();
    cboBuildingTo.SetValue(buildFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cboClientName.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());

}
function cboLevelselct(s, e) {
    var LevelFrom = cboLevels.GetValue();
    var levelTo = cboLevelsTo.GetValue();
    cboLevelsTo.SetValue(LevelFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cboClientName.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());
}
function Roomsselct(s, e) {
    var RoomFrom = cboRooms.GetValue();
    var RoomTo = cboRoomsTo.GetValue();
    cboRoomsTo.SetValue(RoomFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cboClientName.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());
}
function cboDoorsselct(s, e) {
    var DoorFrom = cboDoors.GetValue();
    var DoorTo = cboDoorsTo.GetValue();
    cboDoorsTo.SetValue(DoorFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cboClientName.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
}

function cbolocationPersonal(s, e) {
    var locFrom = cbolocationPersonalFrm.GetValue();
    var locTo = cbolocationPersonalTo.GetValue();
    cbolocationPersonalTo.SetValue(locFrom);
    setSaveChanges();
    //var zero = 0;
    //cboLocation.SetValue(zero.toString());
    //cboClientName.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());
}
function cboClientNamePersonal(s, e) {
    var locFrom = cboClientName.GetValue();
    var locTo = cboClientNameto.GetValue();
    cboClientNameto.SetValue(locFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    // cboDoorsTo.SetValue(zero.toString());
}
function cboDeptNamePersonal(s, e) {
    var locFrom = cboDeptName.GetValue();
    var locTo = cboDeptNameTo.GetValue();
    cboDeptNameTo.SetValue(locFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());

}
function cboCostCenterNamePersonal(s, e) {
    var locFrom = cboCostCenterName.GetValue();
    var locTo = cboCostCenterNameTo.GetValue();
    cboCostCenterNameTo.SetValue(locFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cmbPersName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cmbPersNameTo.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());

}

function cmbPersNamePersonal(s, e) {
    var locFrom = cmbPersName.GetValue();
    var locTo = cmbPersNameTo.GetValue();
    cmbPersNameTo.SetValue(locFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());
    //cboDoors.SetValue(zero.toString());
    //cboDoorsTo.SetValue(zero.toString());

}
function cboLongTransponderePersonal(s, e) {
    var CardFrom = cboLongTransponder.GetValue();
    var CardTo = cboLongTransponderTo.GetValue();
    cboLongTransponderTo.SetValue(CardFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());

}
function cboShortTransponderPersonal(s, e) {
    var CardshortFrom = cboShortTransponder.GetValue();
    var CardshortTo = cboShortTransponderTo.GetValue();
    cboShortTransponderTo.SetValue(CardshortFrom);
    setSaveChanges();
    //var zero = 0;
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptName.SetValue(zero.toString());
    //cboCostCenterName.SetValue(zero.toString());
    //cboLocation.SetValue(zero.toString());
    //cboClientNameto.SetValue(zero.toString());
    //cboDeptNameTo.SetValue(zero.toString());
    //cboCostCenterNameTo.SetValue(zero.toString());
    //cbolocationPersonalFrm.SetValue(zero.toString());
    //cbolocationPersonalTo.SetValue(zero.toString());
    //cboBuilding.SetValue(zero.toString());
    //cboBuildingTo.SetValue(zero.toString());
    //cboLevels.SetValue(zero.toString());
    //cboLevelsTo.SetValue(zero.toString());
    //cboRooms.SetValue(zero.toString());
    //cboRoomsTo.SetValue(zero.toString());

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
    var protokollNr = $("#txtAccessReportNo").val();
    if ((cboAccesReportNo.GetValue() != 0)) {
        var currentId = cboAccesReportNo.GetValue();
        PageMethods.CheckIfProtokollNrExistsOnEdit(protokollNr, currentId, checkBackNumberExistCallBack);
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

function No_OnBack() {
    resetDefault();
    window.location.href = "/Content/AccReports.aspx";
}
function ConfirmDeleteP() {
    var message = "Sind Sie sicher das Sie das Zutrintsprotokolle tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 13%; margin-right: 0px;"  onclick="DeleteAccessReport()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("deleteAccessProtocole");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelAccessProtocole");
    $('#btnCancel').text(levelCaption);
}
function DeleteAccessReport() {
    resetDefault();
    var grp = cboAccesReportNo.GetValue();
    if (grp != 0) {
        PageMethods.DeleteAccessReport(grp, ReloadPage);

    }

}
function ReloadPage(res) {
    ClearControlAfterDelete();
}

function ClearControlAfterDelete() {

    cboAccesReportNo.SetValue(0);
    cboAccesReportDesc.SetValue(0);

    $("#txtAccessReportNo").val("");
    $("#txtAccessReportDesc").val("");
    cboLocation.SetValue("-1#-1");
    cboBuilding.SetValue("-1#-1#-1");
    cboLevels.SetValue("-1#-1#-1#-1");
    cboRooms.SetValue("-1#-1#-1#-1#-1");
    cboDoors.SetValue("-1#-1#-1#-1#-1#-1");
    cboBuildingTo.SetValue("-1#-1#-1");
    cboLevelsTo.SetValue("-1#-1#-1#-1");
    cboRoomsTo.SetValue("-1#-1#-1#-1#-1");
    cboDoorsTo.SetValue("-1#-1#-1#-1#-1#-1");
    cboClientName.SetValue(0);
    cboClientNameto.SetValue(0);
    cbolocationPersonalFrm.SetValue(0);
    cbolocationPersonalTo.SetValue(0);
    cboDeptName.SetValue(0);
    cboDeptNameTo.SetValue(0);
    cboCostCenterName.SetValue(0);
    cboCostCenterNameTo.SetValue(0);
    cmbPersName.SetValue(0);
    cmbPersNameTo.SetValue(0);
    cboLongTransponder.SetValue(0);
    cboLongTransponderTo.SetValue(0);
    cboShortTransponder.SetValue(0);
    cboShortTransponderTo.SetValue(0);
    cboAccesReportNo.SetValue(0);
    cboAccesReportDesc.SetValue(0);

    cboAccesReportNo.PerformCallback();
    cboAccesReportDesc.PerformCallback();
    grdReport.PerformCallback();

}

function grdReportRowClick(s, e) {
    var AccessNr = grdReport.GetRow(RowNum).cells[1].childNodes[0].textContent;
    var id = grdReport.keys[e.visibleIndex];
    PageMethods.GetAcceeReportbyid(id, populatecontrolls);

    SetChangeSelectionEvent = true;
}
function SetVisibleIndex(s, e) {
    RowNum = e.visibleIndex;

}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "MembersGroup.aspx/GetLocalizedText",
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
function resetDefault() {
    document.getElementById('importantDialog').innerHTML = "";
}
function resetSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
}
function setSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "1");
    saveChanges = true;
}
function DisReports() {

    if (($('#chkoject').is(':checked'))) {
        $(".showReports").show();
    }

    if (($('#chkPersonal').is(':checked'))) {
        $(".showReportsPersonal").show();
    }

    $(".ContentAreaDiv").hide();
    $("#btnNew").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").show();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $(".showReportsDocViewer").hide();
    $("#txtLocFrom").val(cboLocation.GetText());
    $("#txtLocTo").val(cboLocationTo.GetText());
    $("#txtBuildingFrom").val(cboBuilding.GetText());
    $("#txtClientFrom").val(cboClientName.GetText());
    $("#txtBuildingTo").val(cboBuildingTo.GetText());
    $("#txtClientTo").val(cboClientNameto.GetText());
    $("#txtTimeFrom").val(TimeFrom.GetText());
    $("#txtTo").val(TimeTo.GetText());
    $("#txtDateFrom").val(dtpFrom.GetText());
    $("#txtDateTo").val(dtpTo.GetText());
    $("#txtLocationFrom").val(cboLocation.GetText());
    $("#txtLocationTo").val(cboLocationTo.GetText());
    $("#txtDisplayBuildingFrom").val(cboBuilding.GetText());
    $("#txtDisplayClientFrom").val(cboClientName.GetText());
    $("#txtblngTo").val(cboBuildingTo.GetText());
    $("#txtCliento").val(cboClientNameto.GetText());
    //$("#txtdateTime").val(TimeFrom.GetText());
    //$("#txtTime").val(TimeTo.GetText());
    $("#txtDisplayDateFrom").val(dtpFrom.GetText());
    $("#txtDisplayDateTo").val(dtpTo.GetText());
    $("#TxtDisplayTimeFrom").val(TimeFrom.GetText());
    $("#txtDisplayTimeTo").val(TimeTo.GetText());
    $("#HiddenField1BackValue").val("1");
    _sendReportSettingsToDocumentViewer();
}

function HideAllReports() {
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    $("#btnCancelDel").show();
    reportType = "printReport";
}

function HideAllReportsPrint() {

    if (($('#chkoject').is(':checked'))) {
        $(".showReports").show();
    }

    if (($('#chkPersonal').is(':checked'))) {
        $(".showReportsPersonal").show();
    }
    $(".ContentAreaDiv").hide();
    $("#btnNew").hide();
    $("#btnEntSave").hide();
    $("#btnPrintReport").show();
    $("#btnPrintSelection").hide();
    $("#btnCancelDel").hide();
    reportType = "printReport";
    $(".showReportsDocViewer").hide();
}
function HideAllReportsObjkt() {
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnPrintReport").hide();
    $("#btnPrintSelection").show();
    $("#btnCancelDel").show();
    reportType = "printReport";

    $("#HiddenField1BackValue").val("1");
}
function display_cd() {

    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtdateTime").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}

function display_ct() {

    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
    $("#txtTime").val(moment().format("HH") + ":" + moment().format("mm"));
}
function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").hide();
    OneTodayCallbackPanel.PerformCallback()
    //TodayLocalASPxDocumentViewer;
    $("#HiddenField1BackValue").val("3");

}

function HideTodaysReport() {
    $(".showReportsDocViewer").hide();
    $(".showReports").hide();
    $(".showReportsPersonal").hide();
    $(".ContentAreaDiv").show();
    $("#btnNew").show();
    $("#btnEntSave").show();
    $("#btnPrintReport").hide();
    $("#btnCancelDel").show();
    $("#btnPrintSelection").show();
    $("#HiddenField1BackValue").val("0");
}

function disablePersChecks() {
    $('#chkPersonalDate').attr("disabled", true);
    $('#chkObjTime').attr("disabled", true);
    $('#chkReaderPersLoc').attr("disabled", true);
    $('#chkPersReaderBuiding').attr("disabled", true);
    $('#chkPersReaderLevel').attr("disabled", true);
    $('#chkReaderRoom').attr("disabled", true);
    $('#chkPersReaderDoor').attr("disabled", true);
    $('#chkPersCompany').attr("disabled", true);
    $('#chkPersonalPersLoc').attr("disabled", true);
    $('#chkPersonalPersDept').attr("disabled", true);
    $('#chkPersonalPersCC').attr("disabled", true);
    $('#chkPersonalPersName').attr("disabled", true);
    $('#chkPersLongTermCard').attr("disabled", true);
    $('#chkPersShortTermCard').attr("disabled", true);
}

function disableObjChecks() {
    $('#chkObjDate').attr("disabled", true);
    $('#chkObjTime').attr("disabled", true);
    $('#chkObjLocation').attr("disabled", true);
    $('#chkObjBuilding').attr("disabled", true);
    $('#chkObjLevel').attr("disabled", true);
    $('#chkObjRoom').attr("disabled", true);
    $('#chkObjDoor').attr("disabled", true);
    $('#chkObjCompany').attr("disabled", true);
    $('#chkObjPersonalPersLoc').attr("disabled", true);
    $('#chkObjPersDept').attr("disabled", true);
    $('#chkObjPersCC').attr("disabled", true);
    $('#chkObjPersName').attr("disabled", true);
    $('#chkObjLongTermCard').attr("disabled", true);
    $('#chkObjShortTermCard').attr("disabled", true);
}

function enablePersChecks() {
    // $('#chkPersonalDate').attr("disabled", false);
    // $('#chkObjTime').attr("disabled", false);
    $('#chkReaderPersLoc').attr("disabled", false);
    $('#chkPersReaderBuiding').attr("disabled", false);
    $('#chkPersReaderLevel').attr("disabled", false);
    $('#chkReaderRoom').attr("disabled", false);
    //   $('#chkPersReaderDoor').attr("disabled", false);
    $('#chkPersCompany').attr("disabled", false);
    $('#chkPersonalPersLoc').attr("disabled", false);
    $('#chkPersonalPersDept').attr("disabled", false);
    $('#chkPersonalPersCC').attr("disabled", false);
    // $('#chkPersonalPersName').attr("disabled", false);
    $('#chkPersLongTermCard').attr("disabled", false);
    //  $('#chkPersShortTermCard').attr("disabled", false);
}

function enableObjChecks() {
    // $('#chkObjDate').attr("disabled", false);
    //  $('#chkObjTime').attr("disabled", false);
    $('#chkObjLocation').attr("disabled", false);
    $('#chkObjBuilding').attr("disabled", false);
    $('#chkObjLevel').attr("disabled", false);
    $('#chkObjRoom').attr("disabled", false);
    // $('#chkObjDoor').attr("disabled", false);
    $('#chkObjCompany').attr("disabled", false);
    $('#chkObjPersonalPersLoc').attr("disabled", false);
    $('#chkObjPersDept').attr("disabled", false);
    $('#chkObjPersCC').attr("disabled", false);
    //   $('#chkObjPersName').attr("disabled", false);
    $('#chkObjLongTermCard').attr("disabled", false);
    $('#chkObjShortTermCard').attr("disabled", false);
}

function _sendReportSettingsToDocumentViewer() {
    var jsonArray = _getValuesFromControls();
    var jsonString = JSON.stringify(jsonArray);

    if (($('#chkoject').is(':checked'))) {
        grdShoeReport.PerformCallback(jsonString);
    }

    if (($('#chkPersonal').is(':checked'))) {
        grdPersonalAccessReport.PerformCallback(jsonString);
    }
}

function _getValuesFromControls() {

    var jsonArray = [];

    var dateFrom = moment(dtpFrom.GetDate()).isValid() ? moment(dtpFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null;
    var dateTo = moment(dtpTo.GetDate()).isValid() ? moment(dtpTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null; //dtpTo.GetDate();
    var timeFrom = moment(TimeFrom.GetDate()).isValid() ? moment(TimeFrom.GetDate()).format("YYYY-MM-DDTHH:mm:00.000") : null; //TimeFrom.GetDate();
    var timeTo = moment(TimeTo.GetDate()).isValid() ? moment(TimeTo.GetDate()).format("YYYY-MM-DDTHH:mm:00.000") : null; //TimeTo.GetDate();

    var displayDateCheckBoxKey = '';
    var displayTimeCheckBoxKey = '';
    var displayBPLocationCheckBoxKey = '';
    var displayBPBuildingCheckBoxKey = '';
    var displayBPFloorCheckBoxKey = '';
    var displayBPRoomCheckBoxKey = '';
    var displayBPDoorCheckBoxKey = '';
    var displayClientCheckBoxKey = '';
    var displayLocationCheckBoxKey = '';
    var displayDepartmentCheckBoxKey = '';
    var displayCostCenterCheckBoxKey = '';
    var displayNameCheckBoxKey = '';
    var displayLongTermCardCheckBoxKey = '';
    var displayShortTermCardCheckBoxKey = '';

    if (($('#chkoject').is(':checked'))) {
        printSelection = 0;
        displayDateCheckBoxKey = 'chkObjDate';
        //  displayTimeCheckBoxKey = 'chkObjTime';
        displayBPLocationCheckBoxKey = 'chkObjLocation';
        displayBPBuildingCheckBoxKey = 'chkObjBuilding';
        displayBPFloorCheckBoxKey = 'chkObjLevel';
        displayBPRoomCheckBoxKey = 'chkObjRoom';
        // displayBPDoorCheckBoxKey = 'chkObjDoor';
        displayClientCheckBoxKey = 'chkObjCompany';
        displayLocationCheckBoxKey = 'chkObjPersonalPersLoc';
        displayDepartmentCheckBoxKey = 'chkObjPersDept';
        displayCostCenterCheckBoxKey = 'chkObjPersCC';
        //  displayNameCheckBoxKey = 'chkObjPersName';
        displayLongTermCardCheckBoxKey = 'chkObjLongTermCard';
        displayShortTermCardCheckBoxKey = 'chkObjShortTermCard';

    }

    if (($('#chkPersonal').is(':checked'))) {
        printSelection = 1;
        //   displayDateCheckBoxKey = 'chkPersonalDate';
        //   displayTimeCheckBoxKey = 'chkPersTime';
        displayBPLocationCheckBoxKey = 'chkReaderPersLoc';
        displayBPBuildingCheckBoxKey = 'chkPersReaderBuiding';
        displayBPFloorCheckBoxKey = 'chkPersReaderLevel';
        displayBPRoomCheckBoxKey = 'chkReaderRoom';
        // displayBPDoorCheckBoxKey = 'chkPersReaderDoor';
        displayClientCheckBoxKey = 'chkPersCompany';
        displayLocationCheckBoxKey = 'chkPersonalPersLoc';
        displayDepartmentCheckBoxKey = 'chkPersonalPersDept';
        displayCostCenterCheckBoxKey = 'chkPersonalPersCC';
        //   displayNameCheckBoxKey = 'chkPersonalPersName';
        displayLongTermCardCheckBoxKey = 'chkPersLongTermCard';
        //  displayShortTermCardCheckBoxKey = 'chkPersShortTermCard';
    }

    var durationSelection = '';

    if (($('#chkToday').is(':checked'))) {
        durationSelection = 'Heute';
    }
    if (($('#chkPreviousDay').is(':checked'))) {
        durationSelection = 'Gestern';
    }
    if (($('#chkThisWk').is(':checked'))) {
        durationSelection = 'Diese Woche';
    }
    if (($('#chkLastWk').is(':checked'))) {
        durationSelection = 'Letze Woche';
    }
    if (($('#chkThisMonth').is(':checked'))) {
        durationSelection = 'Dieser Monat';
    }
    if (($('#chkLastmonth').is(':checked'))) {
        durationSelection = 'Letzer Monat';
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
        StartLocationB: cboLocation.GetValue(),
        EndLocationB: cboLocationTo.GetValue(),
        StartBuilding: cboBuilding.GetValue(),
        EndBuilding: cboBuildingTo.GetValue(),
        StartLevel: cboLevels.GetValue(),
        EndLevel: cboLevelsTo.GetValue(),
        StartRoom: cboRooms.GetValue(),
        EndRoom: cboRoomsTo.GetValue(),
        StartDoor: cboDoors.GetValue(),
        EndDoor: cboDoorsTo.GetValue(),
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
        StartShortTransponder: cboShortTransponder.GetValue(),
        EndShortTranspoder: cboShortTransponderTo.GetValue(),
        StartLongTranspoder: cboLongTransponder.GetValue(),
        EndLongTransponder: cboLongTransponderTo.GetValue(),
        // DisplayDate: $("#" + displayDateCheckBoxKey)[0].checked,
        // DisplayTime: $("#" + displayTimeCheckBoxKey)[0].checked,
        DisplayBPLocation: $("#" + displayBPLocationCheckBoxKey)[0].checked,
        DisplayBPBuilding: $("#" + displayBPBuildingCheckBoxKey)[0].checked,
        DisplayBPFloor: $("#" + displayBPFloorCheckBoxKey)[0].checked,
        DisplayBPRoom: $("#" + displayBPRoomCheckBoxKey)[0].checked,
        // DisplayBPDoor: $("#" + displayBPDoorCheckBoxKey)[0].checked,
        DisplayClient: $("#" + displayClientCheckBoxKey)[0].checked,
        DisplayLocation: $("#" + displayLocationCheckBoxKey)[0].checked,
        DisplayDepartment: $("#" + displayDepartmentCheckBoxKey)[0].checked,
        DisplayCostCenter: $("#" + displayCostCenterCheckBoxKey)[0].checked,
        //  DisplayName: $("#" + displayNameCheckBoxKey)[0].checked,
        DisplayLongTermCard: $("#" + displayLongTermCardCheckBoxKey)[0].checked,
        // DisplayShortTermCard: $("#" + displayShortTermCardCheckBoxKey)[0].checked,
        DurationSelection: durationSelection,
    });

    return jsonArray;
}
function SetDates() {
    var dates = GetCheckDates();
    if (dates.StartDate != undefined && dates.EndDate != undefined) {
        dtpFrom.SetDate(dates.StartDate);
        dtpTo.SetDate(dates.EndDate);
    }
}
function GetCheckDates() {
    var startDate, endDate = undefined;

    var chk = undefined;
    var now = new Date();
    var today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
    $(".chkAll").each(function () { if (this.childNodes[0].checked) { chk = this.childNodes[0].id; } });
    if (chk == "chkToday") {
        startDate = today;
        endDate = today;
    }
    else if (chk == "chkPreviousDay") {
        today = moment(today).add(-1, "day").toDate();
        startDate = today;
        endDate = today;
    }
    else if (chk == "chkThisWk") {
        var day = today.getDay();
        var daysToAdd = day == 0 ? -6 : 1 - day;
        today = moment(today).add(daysToAdd, 'day').toDate();
        startDate = today;
        endDate = moment(today).add(6, 'day').toDate();
    }
    else if (chk == "chkLastWk") {
        var day = today.getDay();
        var daysToAdd = day == 0 ? -6 : 1 - day;
        today = moment(today).add(daysToAdd - 7, 'day').toDate();
        startDate = today;
        endDate = moment(today).add(6, 'day').toDate();
    }
    else if (chk == "chkThisMonth") {
        today = new Date(now.getFullYear(), now.getMonth(), 1);
        startDate = today;
        endDate = moment(today).add(1, 'month').add(-1, 'day').toDate();
    }
    else if (chk == "chkLastmonth") {
        today = moment(new Date(now.getFullYear(), now.getMonth(), 1)).add(-1, "month").toDate();
        startDate = today;
        endDate = moment(today).add(1, 'month').add(-1, 'day').toDate();
    }
    return { StartDate: startDate, EndDate: endDate };
}
function DatesFrom(s, e) {
    var dates = GetCheckDates();
    if (dates.StartDate != undefined && dates.EndDate != undefined) {
        DisabledDatesMin(s, e, dates.StartDate, dates.EndDate);
    }
}
function DatesTo(s, e) {
    var dates = GetCheckDates();
    if (dates.StartDate != undefined && dates.EndDate != undefined) {
        DisabledDatesMin(s, e, dates.StartDate, dates.EndDate);
    }
}
function DisabledDatesMin(s, e, min, max) {
    if (max == undefined) max = new Date(8640000000000000);
    if (min != undefined) {
        if (e.date < min || e.date > max) {
            e.isDisabled = true;
        }
    }
    else {
        e.isDisabled = true;
    }
}

function GetBuildingPlanDetailsFromGrd(locationValueFrom, locationValueTo, buildingValueFrom, buildingValueTo, floorValueFrom, floorValueTo, roomValueFrom, roomValueTo) {
    PageMethods.GetBuildingPlanDetails(locationValueFrom, locationValueTo, buildingValueFrom, buildingValueTo, floorValueFrom, floorValueTo, roomValueFrom, roomValueTo,
        GetBuildingPlanDetailsFromGrdComplete, function (err) {
            console.log(err);
        });
}

function GetBuildingPlanDetailsFromGrdComplete(results) {
    if (typeof results != 'undefined') {
        var _bindBuildings = BuildingPlanFilterLevels == 1;
        var _bindFloors = BuildingPlanFilterLevels >= 1 && BuildingPlanFilterLevels <= 2;
        var _bindRooms = BuildingPlanFilterLevels >= 1 && BuildingPlanFilterLevels <= 3;
        var _bindDoors = BuildingPlanFilterLevels >= 1 && BuildingPlanFilterLevels <= 4;

        //if (_bindBuildings)
        setTimeout(function () {
            var _buildingValue = cboBuilding.GetValue();
            var _buildingValueTo = cboBuildingTo.GetValue();
            BindBuildings(results["buildings"], false);
            if (_buildingValue != null) {
                cboBuilding.SetValue(_buildingValue);
                cboBuildingTo.SetValue(_buildingValueTo);
            }
        }, 2);
        //if (_bindFloors)
        setTimeout(function () {
            var _floorValue = cboLevels.GetValue();
            var _floorValueTo = cboLevelsTo.GetValue();
            BindFloors(results["floors"], false);
            if (_floorValue != null) {
                cboLevels.SetValue(_floorValue);
                cboLevelsTo.SetValue(_floorValueTo);
            }
        }, 8);
        //if (_bindRooms)
        setTimeout(function () {
            var _roomValue = cboRooms.GetValue();
            var _roomValueTo = cboRoomsTo.GetValue();
            BindRooms(results["rooms"], false);
            if (_roomValue != null) {
                cboRooms.SetValue(_roomValue);
                cboRoomsTo.SetValue(_roomValueTo);
            }
        }, 14);
        //if (_bindDoors)
        setTimeout(function () {
            var _doorValue = cboDoors.GetValue();
            var _doorValueTo = cboDoorsTo.GetValue();
            BindDoors(results["doors"], false);
            if (_doorValue != null) {
                cboDoors.SetValue(_doorValue);
                cboDoorsTo.SetValue(_doorValueTo);
            }
        }, 20);

        //BuildingPlanFilterLevels = 0;
    }
}

function GetBuildingPlanDetails(_BuildingPlanFilterLevels) {
    BuildingPlanFilterLevels = _BuildingPlanFilterLevels;

    var locationValueFrom = cboLocation.GetValue() == null ? "" : cboLocation.GetValue(), locationValueTo = cboLocationTo.GetValue() == null ? "" : cboLocationTo.GetValue();

    var buildingValueFrom = cboBuilding.GetValue() == null ? "" : cboBuilding.GetValue(), buildingValueTo = cboBuildingTo.GetValue() == null ? "" : cboBuildingTo.GetValue();

    var floorValueFrom = cboLevels.GetValue() == null ? "" : cboLevels.GetValue(), floorValueTo = cboLevelsTo.GetValue() == null ? "" : cboLevelsTo.GetValue();

    var roomValueFrom = cboRooms.GetValue() == null ? "" : cboRooms.GetValue(), roomValueTo = cboRoomsTo.GetValue() == null ? "" : cboRoomsTo.GetValue();

    PageMethods.GetBuildingPlanDetails(locationValueFrom, locationValueTo, buildingValueFrom, buildingValueTo, floorValueFrom, floorValueTo, roomValueFrom, roomValueTo,
        GetBuildingPlanDetailsComplete, function (err) {
            console.log(err);
        });
}

function GetBuildingPlanDetailsComplete(results) {
    if (typeof results != 'undefined') {
        var _bindBuildings = BuildingPlanFilterLevels == 1;
        var _bindFloors = BuildingPlanFilterLevels >= 1 && BuildingPlanFilterLevels <= 2;
        var _bindRooms = BuildingPlanFilterLevels >= 1 && BuildingPlanFilterLevels <= 3;
        var _bindDoors = BuildingPlanFilterLevels >= 1 && BuildingPlanFilterLevels <= 4;

        if (_bindBuildings)
            setTimeout(function () { BindBuildings(results["buildings"], true); }, 2);
        if (_bindFloors)
            setTimeout(function () { BindFloors(results["floors"], true); }, 8);
        if (_bindRooms)
            setTimeout(function () { BindRooms(results["rooms"], true); }, 14);
        if (_bindDoors)
            setTimeout(function () { BindDoors(results["doors"], true); }, 20);

        BuildingPlanFilterLevels = 0;
    }
}

function BindBuildings(buildingsArr, setIndex) {
    if (buildingsArr.length > 0) {
        cboBuilding.ClearItems();
        for (i = 0;i < buildingsArr.length;i++) {
            var doorColumns = [buildingsArr[i].LocationName, buildingsArr[i].BuildingName];
            var doorId = buildingsArr[i].BuildingID;

            cboBuilding.AddItem(doorColumns, doorId);
            if (setIndex) cboBuilding.SetSelectedIndex(0);
        }

        cboBuildingTo.ClearItems();
        for (i = 0;i < buildingsArr.length;i++) {
            var doorColumns = [buildingsArr[i].LocationName, buildingsArr[i].BuildingName];
            var doorId = buildingsArr[i].BuildingID;

            cboBuildingTo.AddItem(doorColumns, doorId);
            if (setIndex) cboBuildingTo.SetSelectedIndex(0);
        }
    }
}

function BindFloors(floorsArr, setIndex) {
    if (floorsArr.length > 0) {
        cboLevels.ClearItems();
        for (i = 0;i < floorsArr.length;i++) {
            var doorColumns = [floorsArr[i].LocationName, floorsArr[i].BuildingName, floorsArr[i].Level];
            var doorId = floorsArr[i].LevelID;

            cboLevels.AddItem(doorColumns, doorId);
            if (setIndex) cboLevels.SetSelectedIndex(0);
        }

        cboLevelsTo.ClearItems();
        for (i = 0;i < floorsArr.length;i++) {
            var doorColumns = [floorsArr[i].LocationName, floorsArr[i].BuildingName, floorsArr[i].Level];
            var doorId = floorsArr[i].LevelID;

            cboLevelsTo.AddItem(doorColumns, doorId);
            if (setIndex) cboLevelsTo.SetSelectedIndex(0);
        }
    }
}

function BindRooms(roomsArr, setIndex) {
    if (roomsArr.length > 0) {
        cboRooms.ClearItems();
        for (i = 0;i < roomsArr.length;i++) {
            var doorColumns = [roomsArr[i].LocationName, roomsArr[i].BuildingName, roomsArr[i].Level, roomsArr[i].Room];
            var doorId = roomsArr[i].RoomID;

            cboRooms.AddItem(doorColumns, doorId);
            if (setIndex) cboRooms.SetSelectedIndex(0);
        }

        cboRoomsTo.ClearItems();
        for (i = 0;i < roomsArr.length;i++) {
            var doorColumns = [roomsArr[i].LocationName, roomsArr[i].BuildingName, roomsArr[i].Level, roomsArr[i].Room];
            var doorId = roomsArr[i].RoomID;

            cboRoomsTo.AddItem(doorColumns, doorId);
            if (setIndex) cboRoomsTo.SetSelectedIndex(0);
        }
    }
}

function BindDoors(doorsArr, setIndex) {
    if (doorsArr.length > 0) {
        cboDoors.ClearItems();
        for (i = 0;i < doorsArr.length;i++) {
            var doorColumns = [doorsArr[i].LocationName, doorsArr[i].BuildingName, doorsArr[i].Level, doorsArr[i].Room, doorsArr[i].Door];
            var doorId = doorsArr[i].DoorID;

            cboDoors.AddItem(doorColumns, doorId);
            if (setIndex) cboDoors.SetSelectedIndex(0);
        }

        cboDoorsTo.ClearItems();
        for (i = 0;i < doorsArr.length;i++) {
            var doorColumns = [doorsArr[i].LocationName, doorsArr[i].BuildingName, doorsArr[i].Level, doorsArr[i].Room, doorsArr[i].Door];
            var doorId = doorsArr[i].DoorID;

            cboDoorsTo.AddItem(doorColumns, doorId);
            if (setIndex) cboDoorsTo.SetSelectedIndex(0);
        }
    }
}

function OnCheckExists_CallBack(value) {
    if (value === true) {
        NumberExistWarning();
    }
    else {
        savePersonalReport();
    }
}


function NumberExistWarning() {
    var message = "Protokollnummer existiert bereits";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/popupinfo.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div><button id="btnErrorOk"  style="margin-left: 35%; float:right; width: 135px; margin-right: 25px;"  onclick="SetFocus()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    //  getLocalizedText("newSaveWarning");
    $('#btnErrorOk').text("Ok");
}

function SetFocus() {
    resetDefault();

    $("#txtAccessReportNo").focus();
    $("#txtAccessReportNo").addClass('focusOnError');
}
function dplClicked(s, e) {
    isDplClick = true;
}
