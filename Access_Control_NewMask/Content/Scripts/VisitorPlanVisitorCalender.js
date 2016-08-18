var levelCaption = "";
var deletemode = 0;
var accessProfileId = 0;
var backValue = 0;
var isDplClick = false;
var _isDelete = false;
var column_Index = [];
var row_Index = [];
$(function () {
    getLocalizedText("accessCalendar");
    $("#PageTitleLbl2").text(levelCaption);

    $('#btnSearchProfiles').prop('disabled', true);

    $(document).on("selectstart", false);

    $("#btnSearchProfiles").click(function (evt) {

        evt.preventDefault();



        if (dplAccessProfileNr.GetValue().trim() != "" && dplAccessProfileNr.GetValue().trim() != "0") {
            getLocalizedText("accessCalndrDlyProgDisplay");
            $("#PageTitleLbl2").text(levelCaption);
            $(".table").hide();
            $(".bottomsectiondivleft1aTop ").css({ height: "100%" });

            $("#btnNew").hide();
            $("#btnSave").hide();
            $("#btnCancelDel").hide();
            $(".topdiv").hide();
            $(".lblHeader2").hide();
            $(".bottomsectiondivleft1aTop").hide();

            $(".tblAccessProfiles").show();
            $(".bottomsectiondivNew ").css({ width: "100%" });
            $(".bottomsectiondivrightbBottom ").css("display", "none");
            $(".secCalendarSelection ").css("display", "none");
            $("#txtAccessProfileMemo").val($("#dplAccessProfileMemo option:selected").text());

            window.grdZuttritProfileTimeFrames.PerformCallback(ddlProfileId.GetText().trim());

            $("#btnBack").unbind("click");
            $("#btnBack").bind("click", function (evt) {
                evt.preventDefault();
                //  var mode = $("#hiddenFieldSearchValue").attr("value", 0);
                $(".tblAccessProfiles").hide();
                $("#PageTitleLbl2").text("Zutrittskalender");
                $(".table").show();
                $(".bottomsectiondivleft1aTop ").css({ height: "65%" });
                $("#btnNew").show();
                $("#btnSave").show();
                $("#btnCancelDel").show();
                $(".bottomsectiondivNew ").css({ width: "81%" });
                $(".bottomsectiondivrightbBottom ").css("display", "block");
                $(".secCalendarSelection ").css("display", "block");
                $("#btnBack").unbind("click");
                $(".topdiv").show();
                $(".lblHeader2").show();
                $(".bottomsectiondivleft1aTop").show();
                $("#btnBack").bind("click", function (evt) { defaultBackFx(evt) });
            });
        }
    });
    $("#btnInformation").click(function (evt) {
        evt.preventDefault();

    });

    $("#btnBack").click(function (evt) {
        defaultBackFx(evt);
    });
    $("#btnSearchAllCalendars").click(function (evt) {
        evt.preventDefault();
    });

    $("#btnSearchAccessProfile").click(function (evt) {
        evt.preventDefault();
        $("#hiddenFieldSearchValue").attr("value", 1);
        $("#btnNew").hide();
        $("#btnSave").hide();
        $("#btnCancelDel").hide();
        showAccessProfileSearchTable();
    });
    $("#btnSave").click(function (evt) {
        evt.preventDefault();
        SaveAccessPlan();
    });
    $("#btnNew").click(
        function (evt) {
            evt.preventDefault();
            window.grdAccessCalendar.PerformCallback(-999);
            ddlCalendarYear2.SetEnabled(true);
            dplCalendarName.SetValue(0);
            dplCalendarNr.SetValue(0);
            dplCalendarName.SetEnabled(false);
            dplCalendarNr.SetEnabled(false);
            $("#txtCalendarName").focus();
            $("#txtCalendarName").val("");
            setNextAccessKalendarNo();

            //0-None, 1-Display, 2-Create, 3-Edit
            $("#hiddenFieldFormMode").attr("value", "2");
            $("#hiddenFieldDetectChanges").attr("value", "1");
            resetSelections();
        });

    $("#txtCalendarNr").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

    });

    $("#txtCalendarName").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

    });

    $("#txtMemo").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

    });

    $("#btnWeek").click(function (e) {
        e.preventDefault();
        $("#chkMonday").prop("checked", "checked");
        $("#chkTuesday").prop("checked", "checked");
        $("#chkWednesday").prop("checked", "checked");
        $("#chkThursday").prop("checked", "checked");
        $("#chkFriday").prop("checked", "checked");
        $("#chkSaturday").prop("checked", "checked");
        $("#chkSunday").prop("checked", "checked");

    });
    $("#btnmonFri").click(function (e) {
        e.preventDefault();
        $("#chkMonday").prop("checked", "checked");
        $("#chkTuesday").prop("checked", "checked");
        $("#chkWednesday").prop("checked", "checked");
        $("#chkThursday").prop("checked", "checked");
        $("#chkFriday").prop("checked", "checked");
        $("#chkSaturday").removeAttr("checked");
        $("#chkSunday").removeAttr("checked");

    });
    $("#btnSattoSun").click(function (e) {
        e.preventDefault();
        $("#chkMonday").removeAttr("checked");
        $("#chkTuesday").removeAttr("checked");
        $("#chkWednesday").removeAttr("checked");
        $("#chkThursday").removeAttr("checked");
        $("#chkFriday").removeAttr("checked");
        $("#chkSaturday").prop("checked", "checked");
        $("#chkSunday").prop("checked", "checked");

    });

    $("#btnCancelDel").click(
       function (evt) {
           evt.preventDefault();

           var selectval = dplCalendarNr.GetValue();
           if (parseInt(selectval) > 0) {
               DeleteButtonConfirm();
           }
       });
    $("#btnApplySelectedCalender").click(
       function (evt) {
           evt.preventDefault();
           var detectedChanges = parseInt($("#hiddenFieldDetectChanges").attr("value"));
           if (detectedChanges === 1) {
               ApplyConfirmation();
           }
           else {
               var index = grdHolidayCalndr.GetFocusedRowIndex();
               var calendarId = grdHolidayCalndr.GetRowKey(index);

               if (parseInt(calendarId) > 0) {
                   dplCalendarNr.SetValue(calendarId);
                   dplCalendarName.SetValue(calendarId);
                   $("#txtCalendarNr").val(dplCalendarNr.GetText());
                   $("#txtCalendarName").val(dplCalendarName.GetText());
                   window.grdAccessCalendar.PerformCallback(calendarId);
               }
               else {
                   alert("Wählen Zutrittskalender");
               }
           }


       });

    $("#btnApply").click(
        function (evt) {
            evt.preventDefault();
            var formMode = $("#hiddenFieldFormMode").attr("value");

            getLocalizedText("daysOftheWeekSelectionWarning");
            var message = levelCaption;

            getLocalizedText("calendarSelectionWarning");
            var message2 = levelCaption;

            var calenderNr = dplCalendarNr.GetText();
            if (parseInt(formMode, 10) !== 2) {
                if ((calenderNr === undefined) || (calenderNr === null) || (calenderNr.trim().length === 0) || calenderNr === "0") {
                    dplCalendarNr.Focus();
                    alert(message2);
                    return;
                }
            }
            var atLeastOneIsChecked = $('input:checkbox').is(':checked');
            if (atLeastOneIsChecked === false) {
                alert(message);
                return;
            }
            $("#hiddenFieldDetectChanges").attr("value", "1");

            DisplayCalendarAccessProfiles();
            GetDailyScheduleValues();
        });

    $(document).keyup(function (e) {
        if (e.keyCode === 27) {//escape
            removeAllHighlighting();
        }
    });
    $("#btnDateFromPrevious").click(function (evt) {
        evt.preventDefault();
        var date = moment(datePickerDateFrom.GetDate()).isValid() ? moment(datePickerDateFrom.GetDate()) : null;
        if (date !== null) {
            datePickerDateFrom.SetDate(SubtractDay(date, 1));
            var dateTo = datePickerDateTo.GetDate();
            var dateFrom = datePickerDateFrom.GetDate();
            $("#hiddenFieldDateFrom").attr("value", dateFrom);
            highlightByDate(dateFrom, dateTo);
        }
    });
    $("#btnDateFromNext").click(function (evt) {
        evt.preventDefault();
        var date = moment(datePickerDateFrom.GetDate()).isValid() ? moment(datePickerDateFrom.GetDate()) : null;
        if (date !== null) {
            datePickerDateFrom.SetDate(AddDay(date, 1));
            var dateTo = datePickerDateTo.GetDate();
            var dateFrom = datePickerDateFrom.GetDate();
            $("#hiddenFieldDateFrom").attr("value", dateFrom);
            highlightByDate(dateFrom, dateTo);
        }
    });
    $("#btnDateToPrevious").click(function (evt) {
        evt.preventDefault();
        var date = moment(datePickerDateTo.GetDate()).isValid() ? moment(datePickerDateTo.GetDate()) : null;
        if (date !== null) {
            datePickerDateTo.SetDate(SubtractDay(date, 1));
            var dateFrom = datePickerDateFrom.GetDate();
            //var dateFrom = $("#hiddenFieldDateFrom").attr("value");
            var dateTo = datePickerDateTo.GetDate();
            highlightByDate(dateFrom, dateTo);
        }
    });
    $("#btnDateToNext").click(function (evt) {
        evt.preventDefault();
        var date = moment(datePickerDateTo.GetDate()).isValid() ? moment(datePickerDateTo.GetDate()) : null;
        if (date !== null) {
            datePickerDateTo.SetDate(AddDay(date, 1));
            var dateFrom = datePickerDateFrom.GetDate();
            //var dateFrom = $("#hiddenFieldDateFrom").attr("value");
            var dateTo = datePickerDateTo.GetDate();
            highlightByDate(dateFrom, dateTo);
        }
    });
    $("#btnTariffYearPrevious").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnTariffYearNext").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnCalendarYearPrevious").click(function (evt) {
        evt.preventDefault();
        if (parseInt(dplCalendarNr.GetValue()) < 1) {
            MoveToPreviousYear();
        }
    });
    $("#btnCalendarYearNext").click(function (evt) {
        evt.preventDefault();
        if (parseInt(dplCalendarNr.GetValue()) < 1) {
            MoveToNextYear();
        }
    });
});

function hideAccessProfileSearchTable() {
    $("#searchAccessProfile").hide();
    $(".secCalendarSelection").show();
    $("#accessGroupDiv").show();

    $("#hiddenFieldSearchValue").attr("value", 0);
}

function showAccessProfileSearchTable() {
    $("#accessGroupDiv").hide();
    $(".secCalendarSelection").hide();
    $("#searchAccessProfile").show();

    $("#btnBack").unbind("click");
    $("#btnBack").bind("click", function (evt) {
        evt.preventDefault();
        var mode = $("#hiddenFieldSearchValue").attr("value");
        if (mode === "1") {
            hideAccessProfileSearchTable();
            $("#btnNew").show();
            $("#btnSave").show();
            $("#btnCancelDel").show();
        } else {
            document.location.href = "VisitorPlanVisitorCalender.aspx";
        }
        $("#btnBack").unbind("click");
        $("#btnBack").bind("click", function (evt) { defaultBackFx(evt) });
    });
}

function SetProfileSelectedDxDrp(setVal) {
    dplAccessProfileName.SetValue(setVal);
    dplAccessProfileNr.SetValue(setVal);

    ddlProfileId.SetValue(setVal);
    $("#dplAccessProfileMemo").val(setVal);
    $('#btnSearchProfiles').prop('disabled', false);
}

function defaultBackFx(evt) {
    evt.preventDefault();
    //$("#btnBack").unbind("click");
    //0-None, 1-Display, 2-Create, 3-Edit
    var mode = $("#hiddenFieldFormMode").attr("value");

    var detectedChanges = allowZUTEdit ? $("#hiddenFieldDetectChanges").attr("value") : "0";

    //if (!allowZUTEdit)
    //    detectedChanges = "0";

    switch (detectedChanges) {
        case "0":

            document.location.href = "VisitorPlan.aspx";
            break;

        case "1":
            BackButtonConfirm();
            break;

        default:
            document.location.href = "VisitorPlan.aspx";
    }
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "VisitorPlanVisitorCalender.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function setNextAccessKalendarNo() {
    var maxNo = 0;
    var currNo = [];

    //$("#dplCalendarNr option").each(function () {
    //    currNo.push(this.text);
    //});
    for (var i = 0; i < dplCalendarNr.GetItemCount() ; i++) {
        currNo.push(dplCalendarNr.GetItem(i).text);
    }
    maxNo = Math.max.apply(Math, currNo);
    maxNo++;
    $("#txtCalendarNr").val(maxNo);
}

function DisplayCalendarAccessProfiles() {
    var accessProfileNr = ddlProfileId.GetText();
    getLocalizedText("accessProfileSelectionWarning");
    var message = levelCaption;

    if ((accessProfileNr === undefined) || (accessProfileNr === null) || (accessProfileNr.trim().length === 0) || accessProfileNr === "keine") {

        alert(message);

        ddlProfileId.Focus();

        return;
    }

    var calendarYear = Number($("#hiddenFieldCalendarYear").attr("value"));
    if ((calendarYear === NaN) || (calendarYear === 0)) {
        calendarYear = new Date().getFullYear();
    }

    if (calendarYear === 0) {
        calendarYear = new Date().getFullYear();
    }

    for (var rowIndex = 0; rowIndex <= 11; rowIndex++) {
        for (var columnIndex = 1; columnIndex <= 31; columnIndex++) {
            var cell = window.grdAccessCalendar.GetRow(rowIndex).cells[columnIndex];

            if ((cell.style.backgroundColor === "rgb(255, 246, 3)") || (cell.style.backgroundColor === "rgb(47, 181, 159)")) {//highlighted

                var daysDate = new Date(calendarYear, rowIndex, columnIndex);
                var dayOfWeek = daysDate.getDay();

                switch (dayOfWeek) {
                    case 0: //sunday
                        if (($("#chkSunday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            cell.childNodes[0].textContent = "So";
                        }
                        break;
                    case 1: //monday
                        if (($("#chkMonday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 2: //tuesday
                        if (($("#chkTuesday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 3: //wednesday
                        if (($("#chkWednesday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 4: //thursday
                        if (($("#chkThursday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 5: //friday
                        if (($("#chkFriday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 6: //saturday
                        if (($("#chkSaturday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            cell.childNodes[0].textContent = "Sa";
                        }
                        break;
                }
            }
        }
    }
}

var isMouseDown = false;
var cellStartIndex = 0;
var cellEndIndex = 0;

var rowStartIndex = -1;
var rowEndIndex = -1;

function OnMouseDown(cell, rowIndex) {
    var currentCellIndex = cell.cellIndex;
    if (currentCellIndex === 0) {//skip Month Column
        isMouseDown = false;

        return;
    }

    rowStartIndex = rowIndex;
    cellStartIndex = cell.cellIndex;
    isMouseDown = true;
}

function OnMouseUp(cell, rowIndex) {
    cellEndIndex = cell.cellIndex;
    rowEndIndex = rowIndex;
    isMouseDown = false;
    var _year = parseInt(ddlTariffYear2.GetText());
    CalculateStartDate(rowStartIndex, cellStartIndex, _year);
    CalculateEndDate(rowEndIndex, cellEndIndex, _year);
}

function OnMouseMove(cell, rowIndex) {
    var formMode = $("#hiddenFieldFormMode").attr("value");
    //if (formMode <= 1) {
    //    return;
    //}

    var currentCellIndex = cell.cellIndex;
    if (currentCellIndex === 0) {//skip Month Column
        return;
    }

    if (isMouseDown) {
        if (rowStartIndex === -1) {
            if (isValidDate(rowIndex, cell.cellIndex)) {
                if (isWeekend(rowIndex, cell.cellIndex)) {
                    cell.style.backgroundColor = "#2FB59F";
                } else {
                    cell.style.backgroundColor = "#FFF603";
                }
            } else {
                cell.style.backgroundColor = "black";
            }

            return;
        }

        for (var i = rowStartIndex; i <= rowIndex; i++) {
            var rowCells = window.grdAccessCalendar.GetRow(i).cells;

            for (var j = cellStartIndex; j <= currentCellIndex; j++) {
                var selectedCell = rowCells[j];

                if (isValidDate(i, j)) {
                    if (isWeekend(i, j)) {
                        selectedCell.style.backgroundColor = "#2FB59F";
                    } else {
                        selectedCell.style.backgroundColor = "#FFF603";
                    }
                } else {
                    cell.style.backgroundColor = "black";
                }
            }
        }
    }
}

function activateProfile(s, e) {

    //Zutrittskalender Tagesprofilanzeige

    if (s.valueChecked) {
        for (var rowNumber = 0; rowNumber < 10; rowNumber++) {
            try {
                grdZuttritProfileTimeFrames.GetRow(rowNumber).cells[0].childNodes[0].className === "dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys";
                grdZuttritProfileTimeFrames.GetRow(rowNumber).cells[0].childNodes[0].children[0].className === "dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys";
            } catch (e) {
            }
        }
    }
}

function OnCellClick(cell, rowIndex) {
    var fieldName = cell.attributes["celltype"].value;

    if (fieldName !== "MonthName") {
        removeAllHighlighting();
        var clickedCellVal = cell.textContent;
        if (clickedCellVal.length >= 1) {
            if ((clickedCellVal !== "Sa") && (clickedCellVal !== "So")) {
                getLocalizedText("accessCalndrDlyProgDisplay");
                $("#PageTitleLbl2").text(levelCaption);
                $(".table").hide();
                $(".bottomsectiondivNew ").css({ width: "100%" });
                $(".bottomsectiondivleft1aTop ").css({ height: "100%" });
                $(".bottomsectiondivrightbBottom ").css("display", "none");
                $(".secCalendarSelection ").css("display", "none");
                $(".tblAccessProfiles").show();
                $(".topdiv").hide();
                $(".lblHeader2").hide();
                $(".bottomsectiondivleft1aTop").hide();
                window.grdZuttritProfileTimeFrames.PerformCallback(clickedCellVal);

                $("#btnBack").unbind("click");
                $("#btnBack").bind("click", function (evt) {
                    evt.preventDefault();
                    //  var mode = $("#hiddenFieldSearchValue").attr("value", 0);
                    $(".tblAccessProfiles").hide();
                    $("#PageTitleLbl2").text("Zutrittskalender");
                    $(".table").show();
                    $(".bottomsectiondivNew ").css({ width: "81%" });
                    $(".bottomsectiondivleft1aTop ").css({ height: "65%" });
                    $(".bottomsectiondivrightbBottom ").css("display", "block");
                    $(".secCalendarSelection ").css("display", "block");
                    $(".topdiv").show();
                    $(".lblHeader2").push();
                    $(".bottomsectiondivleft1aTop").show();
                    $("#btnBack").unbind("click");
                    $("#btnBack").bind("click", function (evt) { defaultBackFx(evt) });
                });
            }
        }
    }
    else {

        var accessCalendarId = $("#hiddenFieldAccessCalendarId").attr("value");

        var calendarMonth = (rowIndex + 1);
        var data = { accessCalendarId: accessCalendarId, calendarMonth: calendarMonth };

        $.ajax({
            type: "POST",
            async: false,
            url: "VisitorPlanVisitorCalender.aspx/GetAccessProfilesByMonth",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function () {
                window.location.href = "AccessCalenderMonth.aspx";
            }
        });
    }
    //RebindBackButton();
}

function RebindBackButton() {
    $("#btnBack").unbind("click");
    $("#btnBack").bind("click", function (evt) {
        evt.preventDefault();
        var mode = $("#hiddenFieldSearchValue").attr("value");
        if (mode === "1") {
            hideAccessProfileSearchTable();
        } else {
            document.location.href = "VisitorPlanVisitorCalender.aspx";
        }
        $("#btnBack").unbind("click");
        $("#btnBack").bind("click", function (evt) { defaultBackFx(evt) });
    });
}

function removeAllHighlighting() {
    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        var rowCells = grdAccessCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1; currentCellIndex <= 31; currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (isValidDate(rowNumber, currentCellIndex)) {
                if (isWeekend(rowNumber, currentCellIndex)) {
                    cell.style.backgroundColor = "green";
                } else {
                    cell.style.backgroundColor = "white";
                }
            } else {
                cell.style.backgroundColor = "black";
            }
        }
    }
}

function isValidDate(rowIndex, columnIndex) {
    var month = Number(rowIndex) + 1;

    var calendarYear = new Date().getFullYear();
    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + columnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();

    return isValid;
}

function isWeekend(rowIndex, columnIndex) {
    var calendarYear = new Date().getFullYear();

    var daysDate = new Date(calendarYear, rowIndex, columnIndex);
    var dayOfWeek = daysDate.getDay();

    if ((dayOfWeek === 6) || (dayOfWeek === 0)) {
        return true;
    } else {
        return false;
    }
}

function GetDailyScheduleValues() {

    var jsonArray = [];

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        var rowCells = grdAccessCalendar.GetRow(rowNumber).cells;

        jsonArray.push({
            AccessCalendarID: dplCalendarNr.GetValue(),
            AccessCalendarMonthNr: rowNumber + 1,
            Day1AccessProfile: rowCells[1].childNodes[0].textContent,
            Day2AccessProfile: rowCells[2].childNodes[0].textContent,
            Day3AccessProfile: rowCells[3].childNodes[0].textContent,
            Day4AccessProfile: rowCells[4].childNodes[0].textContent,
            Day5AccessProfile: rowCells[5].childNodes[0].textContent,
            Day6AccessProfile: rowCells[6].childNodes[0].textContent,
            Day7AccessProfile: rowCells[7].childNodes[0].textContent,
            Day8AccessProfile: rowCells[8].childNodes[0].textContent,
            Day9AccessProfile: rowCells[9].childNodes[0].textContent,
            Day10AccessProfile: rowCells[10].childNodes[0].textContent,
            Day11AccessProfile: rowCells[11].childNodes[0].textContent,
            Day12AccessProfile: rowCells[12].childNodes[0].textContent,
            Day13AccessProfile: rowCells[13].childNodes[0].textContent,
            Day14AccessProfile: rowCells[14].childNodes[0].textContent,
            Day15AccessProfile: rowCells[15].childNodes[0].textContent,
            Day16AccessProfile: rowCells[16].childNodes[0].textContent,
            Day17AccessProfile: rowCells[17].childNodes[0].textContent,
            Day18AccessProfile: rowCells[18].childNodes[0].textContent,
            Day19AccessProfile: rowCells[19].childNodes[0].textContent,
            Day20AccessProfile: rowCells[20].childNodes[0].textContent,
            Day21AccessProfile: rowCells[21].childNodes[0].textContent,
            Day22AccessProfile: rowCells[22].childNodes[0].textContent,
            Day23AccessProfile: rowCells[23].childNodes[0].textContent,
            Day24AccessProfile: rowCells[24].childNodes[0].textContent,
            Day25AccessProfile: rowCells[25].childNodes[0].textContent,
            Day26AccessProfile: rowCells[26].childNodes[0].textContent,
            Day27AccessProfile: rowCells[27].childNodes[0].textContent,
            Day28AccessProfile: rowCells[28].childNodes[0].textContent,
            Day29AccessProfile: rowCells[29].childNodes[0].textContent,
            Day30AccessProfile: rowCells[30].childNodes[0].textContent,
            Day31AccessProfile: rowCells[31].childNodes[0].textContent
        });
    }

    var jsonString = JSON.stringify(jsonArray);

    var data = { jsonData: jsonString };

    $.ajax({
        type: "POST",
        url: "VisitorPlanVisitorCalender.aspx/UpdateAccessCalenderSchedule",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
        }
    });
}

function ValidateValueNumber(val) {
    if (isNaN(val) || val.trim() === "") {
        return 0;

    }
    else {

        $("#dplAccessProfileNr option").each(function () {
            //console.log(this.text +" "+ this.value);
            if ($(this).html() === val) {
                val = this.value;
            }
        });
        return val;
    }
}

function gridViewAccessProfileRowClick(s, e) {
    gridViewAccessProfileSearch.GetRowValues(e.visibleIndex, "ID;AccessProfileNo;AccessDescription", GetAccessProfileRowValues);
}

function GetAccessProfileRowValues(values) {
    var accessProfileId = values[0].toString();

    dplAccessProfileNr.SetValue(accessProfileId);
    dplAccessProfileName.SetValue(accessProfileId);
    ddlProfileId.SetValue(accessProfileId);

    $("#searchAccessProfile").hide();
    $(".secCalendarSelection").show();
    $("#accessGroupDiv").show();

    $("#hiddenFieldSearchValue").attr("value", 0);
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
});

function datePickerFromDateChanged(s, e) {
    var dateTo = window.datePickerDateTo.GetDate();
    var dateFrom = s.date;

    $("#hiddenFieldDateFrom").attr("value", dateFrom);

    highlightByDate(dateFrom, dateTo);
}

function datePickerToDateChanged(s, e) {
    var dateFrom = window.datePickerDateFrom.GetDate();
    //var dateFrom = $("#hiddenFieldDateFrom").attr("value");

    var dateTo = s.date;

    highlightByDate(dateFrom, dateTo);
}

function highlightByDate(dateFrom, dateTo) {
    removeAllHighlighting();

    if ((dateTo === null) || (dateTo === undefined)) {
        return;
    }

    if ((dateFrom === null) || (dateFrom === undefined)) {
        return;
    }

    while (dateFrom <= dateTo) {
        var workingDateFrom = dateFrom;
        var selectedDate = Number(workingDateFrom.getDate());
        var selectedMonth = Number(workingDateFrom.getMonth());

        var rowCells = window.grdAccessCalendar.GetRow(selectedMonth).cells;
        for (var currentDay = selectedDate; currentDay <= 31; currentDay++) {
            var calendarYear = new Date().getFullYear();

            var daysDate = new Date(calendarYear, selectedMonth, currentDay);

            if (daysDate > dateTo) {
                return;
            }

            var selectedCell = rowCells[currentDay];

            if (isValidDate(selectedMonth, currentDay)) {
                if (isWeekend(selectedMonth, currentDay)) {
                    selectedCell.style.backgroundColor = "#2FB59F";
                } else {
                    selectedCell.style.backgroundColor = "#FFF603";
                }
            } else {
                selectedCell.style.backgroundColor = "black";
            }
        }

        dateFrom.setTime(dateFrom.getTime() + 1 * 86400000);;
    }
}

function DeleteButtonConfirm() {
    var message = "Sind Sie sicher, dass Sie löschen möchten";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetImportantInfoDialogDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="DeleteAccessCalendarCustom()"></button><button id="btnCancel"  onclick="resetImportantInfoDialogDiv(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);

}

function DeleteAccessCalendarCustom() {
    document.getElementById("importantInfoDialog").innerHTML = "";
    var id = dplCalendarNr.GetValue();
    var visitorPlanId = $('#txtVisitorPlanId').val();
    PageMethods.DeleteAccessCalendar(id, visitorPlanId, OnDelete_CallBack);
}

function OnDelete_CallBack() {
    _isDelete = true;
    $("#chkMonday").removeAttr("checked");
    $("#chkTuesday").removeAttr("checked");
    $("#chkWednesday").removeAttr("checked");
    $("#chkThursday").removeAttr("checked");
    $("#chkFriday").removeAttr("checked");
    $("#chkSaturday").removeAttr("checked");
    $("#chkSunday").removeAttr("checked");
    dplAccessProfileNr.SetValue(0);
    dplAccessProfileName.SetValue(0);
    ddlProfileId.SetValue(0);
    dplCalendarNr.SetValue(0);
    dplCalendarName.SetValue(0);
    //dplCalendarNr.PerformCallback();
    //dplCalendarName.PerformCallback();
    $("#txtCalendarNr").val(0);
    $("#txtCalendarName").val("keine");
    $("#txtMemo").val("");
    grdAccessCalendar.PerformCallback(0);
    grdHolidayCalndr.PerformCallback(0);
}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();

    //0 - None, 1 - Display, 2 - Create, 3 - Edit
    //$("#hiddenFieldFormMode").attr("value", "1");
}

function resetImportantInfoDialogDiv() {
    document.getElementById("importantInfoDialog").innerHTML = "";
    //$("#dplCalendarNr").focus();
}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetImportantInfoDialogDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 45%;width: 100px; margin-right: 0px;"  onclick="SaveAccessCalendarOnBack()"></button><button id="btnNo"  onclick="NoOnBackButton()"></button><button id="btnCancel"  onclick="resetImportantInfoDialogDiv(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("saveButton");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnNo').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);
}

function SaveAccessCalendarOnBack() {
    document.getElementById("importantInfoDialog").innerHTML = "";
    var calendarNumber = $("#txtCalendarNr").val();
    PageMethods.CheckIfCalenderNrExists(calendarNumber, OnGetNumberBack_CallBack)

}

function OnGetNumberBack_CallBack(responce) {
    var accessCalenderNr = Number($("#txtCalendarNr").val());
    var accessPlanName = $("#txtCalendarName").val();
    var accessPlanId = Number(dplCalendarNr.GetValue());
    var calendarYear = Number(ddlTariffYear2.GetText());
    var visitorPlanId = $('#txtVisitorPlanId').val();
    if ((calendarYear === NaN) || (calendarYear === 0)) {
        calendarYear = new Date().getFullYear();
    }
    var calendarDate = new Date(calendarYear, 1, 1);
    if (accessCalenderNr < 1) {
        alert("Bitte wählen Sie das Kalander Nr.");
        return;
    }
    if (accessPlanId === 0) {
        var mode = 2;
        $("#hiddenFieldFormMode").attr("value", "2");
        if (responce === true) {
            alert("Zugangsplan-Nummer bereits vorhanden");
            return;
        }
        PageMethods.SaveAccessCalendar(mode, accessPlanId, accessCalenderNr, accessPlanName, calendarDate, $("#txtMemo").val(), visitorPlanId, OnSaveBack_CallBack);
    }
    else if (accessPlanId > 0) {
        $("#hiddenFieldFormMode").attr("value", "3");
        var mode = 3;
        PageMethods.SaveAccessCalendar(mode, accessPlanId, accessCalenderNr, accessPlanName, calendarDate, $("#txtMemo").val(), visitorPlanId, OnSaveBack_CallBack);
    }
}

function OnSaveBack_CallBack() {
    document.location.href = "VisitorPlan.aspx";
}

function SaveAccessCalendar() {
    var mode = Number($("#hiddenFieldFormMode").attr("value"));
    var calendarNumber = $("#txtCalendarNr").val();
    var calendarName = $("#txtCalendarName").val();

    if ((calendarNumber === undefined) || (calendarNumber === null) || (calendarNumber === "") || (calendarNumber.trim().length === 0)) {
        $("#txtCalendarNr").focus();

        return;
    }

    //if ((calendarName === undefined) || (calendarName === null) || (calendarName === "") || (calendarName.trim().length === 0)) {
    //    $("#txtCalendarName").focus();

    //    return;
    //}

    var calendarYear = Number($("#hiddenFieldCalendarYear").attr("value"));
    if ((calendarYear === NaN) || (calendarYear === 0)) {
        calendarYear = new Date().getFullYear();
    }

    var calendarDate = new Date(calendarYear, 1, 1);
    var memo = $("#txtMemo").val();

    var parameters = { formMode: mode, calendarNumber: calendarNumber, calendarName: calendarName, calendarDate: calendarDate, memo: memo };
    $.ajax({
        type: "POST",
        async: false,
        url: "VisitorPlanVisitorCalender.aspx/SaveAccessCalendar",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(parameters),
        complete: function (result) {
            var accessCalendar = result.d;
        }
    });

    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "999");
}

function NoOnBackButton() {
    resetImportantInfoDialogDiv();
    document.location.href = "/Content/VisitorPlan.aspx";
}

function CancelOnBackButton() {
    resetImportantInfoDialogDiv();
    //document.location.href = "/Content/VisitorPlanVisitorCalender.aspx";
}

function UnMap_AccessCalender() {
    PageMethods.UnMapAccessPlanCalendarCustom(OnUnMap_CallBack)
}

function OnUnMap_CallBack() {
    var _value = "0";
    dplCalendarNr.SetValue(_value);
    dplCalendarName.SetValue(_value);
    var calendarId = Number(dplCalendarNr.GetValue());
    if (calendarId === NaN) {
        calendarId = 0;
    }
    window.grdAccessCalendar.PerformCallback(-111);
}

function grdHolidayCalndrSingleClick(s, e) {

    //var index = grid.GetFocusedRowIndex();
    var calendarId = grdHolidayCalndr.GetRowKey(e.visibleIndex);

    if (parseInt(calendarId) == "undefined") {
        return;
    } else {
        if (parseInt(calendarId) < 1) return;
    }

    dplCalendarNr.SetValue(calendarId);
    dplCalendarName.SetValue(calendarId);
    $("#txtCalendarNr").val(dplCalendarNr.GetText());
    $("#txtCalendarName").val(dplCalendarName.GetText());
    window.grdAccessCalendar.PerformCallback(calendarId);

}

function resetSelections() {
    dplAccessProfileName.SetValue(0);
    dplAccessProfileNr.SetValue(0);
    ddlProfileId.SetValue(0);
    $('#chkMonday').prop('checked', false);
    $('#chkTuesday').prop('checked', false);
    $('#chkWednesday').prop('checked', false);
    $('#chkThursday').prop('checked', false);
    $('#chkFriday').prop('checked', false);
    $('#chkSaturday').prop('checked', false);
    $('#chkSunday').prop('checked', false);
}
function calendarSelectedChanged(s, e) {
    if (isDplClick === true) {
        dplCalendarNr.SetValue(s.GetValue());
        dplCalendarName.SetValue(s.GetValue());
        ddlProfileId.SetValue(s.GetValue());
        if (s.GetValue() !== "0") {
            $("#txtCalendarNr").val(dplCalendarNr.GetText());
            $("#txtCalendarName").val(dplCalendarName.GetText());
        }
        else {
            $("#txtCalendarNr").val("");
            $("#txtCalendarName").val("");
        }
        var calendarId = Number(s.GetValue());

        if (calendarId === NaN) {
            calendarId = 0;
        }

        window.grdAccessCalendar.PerformCallback(calendarId);
        grdHolidayCalndr.PerformCallback(calendarId);
        //0-None, 1-Display, 2-Create, 3-Edit
        $("#hiddenFieldFormMode").attr("value", "3");
        $("#hiddenFieldDetectChanges").attr("value", "1");
        resetSelections();
    }

}
function DropDownClick(s, e) {
    isDplClick = true;
}
function dplCalendarNrEndCallBack(s, e) {

}
function dplCalendarNameEndCallBack(s, e) {

}
function SaveAccessPlan() {
    resetImportantInfoDialogDiv();
    var calendarNumber = $("#txtCalendarNr").val();
    PageMethods.CheckIfCalenderNrExists(calendarNumber, OnGetNumberInsertEdit_CallBack);
}
function OnGetNumberInsertEdit_CallBack(responce) {
    isDplClick = false;
    var accessCalenderNr = Number($("#txtCalendarNr").val());
    var accessPlanName = $("#txtCalendarName").val();
    var accessPlanId = Number(dplCalendarNr.GetValue());
    var calendarYear = Number(ddlTariffYear2.GetText());
    var visitorPlanId = $('#txtVisitorPlanId').val();
    if ((calendarYear === NaN) || (calendarYear === 0)) {
        calendarYear = new Date().getFullYear();
    }
    var calendarDate = new Date(calendarYear, 1, 1);
    if (accessCalenderNr < 1) {
        alert("Bitte wählen Sie das Kalander Nr.");
        return;
    }
    if (accessPlanId === 0) {
        var mode = 2;
        $("#hiddenFieldFormMode").attr("value", "2");
        if (responce === true) {
            alert("Zugangsplan-Nummer bereits vorhanden");
            return;
        }
        PageMethods.SaveAccessCalendar(mode, accessPlanId, accessCalenderNr, accessPlanName, calendarDate, $("#txtMemo").val(), visitorPlanId, OnSaveCalendar_CallBack);
    }
    else if (accessPlanId > 0) {
        $("#hiddenFieldFormMode").attr("value", "3");
        var mode = 3;
        PageMethods.SaveAccessCalendar(mode, accessPlanId, accessCalenderNr, accessPlanName, calendarDate, $("#txtMemo").val(), visitorPlanId, OnSaveCalendar_CallBack);
    }
}
function OnSaveCalendar_CallBack(value) {
    $("#hiddenFieldFormMode").attr("value", "3");
    $("#hiddenFieldDetectChanges").attr("value", "0");
    EnableDrodowns();
    dplCalendarNr.PerformCallback(value);
    dplCalendarName.PerformCallback(value);
    grdAccessCalendar.PerformCallback(value);
    grdHolidayCalndr.PerformCallback(value);
    ddlCalendarYear2.SetEnabled(false);
}
function EnableDrodowns() {
    dplCalendarNr.SetEnabled(true);
    dplCalendarName.SetEnabled(true);
}
function grdAccessCalendarEndCallBack(s, e) {
    if (_isDelete === true) {
        _isDelete = false;
        dplCalendarNr.PerformCallback();
        dplCalendarName.PerformCallback();
    }

}

function ApplyConfirmation() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnApply(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 74%; margin-right: 0px; width:72px;"  onclick="SaveAccessPlan()"></button><button id="btnCancel"  onclick="NoOnApply(); return false;" style=" position: relative; width:44px;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("saveButton");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnCancel').text(levelCaption);

}
function CancelOnApply() {
    resetImportantInfoDialogDiv();
}
function NoOnApply() {
    resetImportantInfoDialogDiv();
    $("#hiddenFieldDetectChanges").attr("value", "0");
    EnableDrodowns();
    var index = grdHolidayCalndr.GetFocusedRowIndex();
    var calendarId = grdHolidayCalndr.GetRowKey(index);
    if (parseInt(calendarId) > 0) {
        dplCalendarNr.SetValue(calendarId);
        dplCalendarName.SetValue(calendarId);
        $("#txtCalendarNr").val(dplCalendarNr.GetText());
        $("#txtCalendarName").val(dplCalendarName.GetText());
        window.grdAccessCalendar.PerformCallback(calendarId);
    }
}

function AddDay(date, numberOfDaysToAdd) {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() + numberOfDaysToAdd);
    return newDate;
}
function SubtractDay(date, numberOfDaysToSubtract) {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() - numberOfDaysToSubtract);
    return newDate;
}
function MoveToPreviousYear() {
    var i = ((ddlCalendarYear2.GetSelectedIndex()) - 1);
    if (i < 0) return;
    ddlCalendarYear2.SetSelectedIndex(i);
    ddlTariffYear2.SetValue(ddlCalendarYear2.GetValue());
}
function MoveToNextYear() {
    var i = ((ddlCalendarYear2.GetSelectedIndex()) + 1);
    if (i > ((ddlCalendarYear2.GetItemCount()) - 1)) return;
    ddlCalendarYear2.SetSelectedIndex(i);
    ddlTariffYear2.SetValue(ddlCalendarYear2.GetValue());
}
function CalculateStartDate(startRowIndex, startColumnIndex, calendarYear) {
    var date = null;
    var month = Number(startRowIndex) + 1;


    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + startColumnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();
    if (isValid == true) {
        datePickerDateFrom.SetDate(moment(daysDate, "YYYY-MM-DD").toDate());
    }
}
function CalculateEndDate(EndRowIndex, EndColumnIndex, calendarYear) {
    var month = Number(EndRowIndex) + 1;
    var monthLastDay = ReturnEndDate(calendarYear, EndRowIndex);
    if (EndColumnIndex > monthLastDay) {
        EndColumnIndex = monthLastDay;
    }

    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + EndColumnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();
    if (isValid == true) {
        datePickerDateTo.SetDate(moment(daysDate, "YYYY-MM-DD").toDate());
    }
}
function ReturnEndDate(calendarYear, month) {
    var today = new Date(calendarYear, month, 1);
    var lastDayOfMonth = new Date(today.getFullYear(), today.getMonth() + 1, 0);
    return lastDayOfMonth.getDate();
}