var levelCaption = "";
var holidays = [];
var backValue = 0;
var dayOfWeekName;
var dayHasTimeFrames;
var holidayDates = [];
var accessProfiles = null;
var saveChanges = false;
var _isPlanClick = false;
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanHolidaySchedule.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

//$(function () {

//});

$(function () {
    getLocalizedText("holidayScheduleSubtitle");
    $('#PageTitleLbl2').text(levelCaption);
    var holidayPlanId = ddlHolidayPlanCalendarNumber.GetValue();
    getSelectedAccessPLans(holidayPlanId);
    var _accessProfiles = accessProfiles;
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    $(document).on("selectstart", false);

    $("#btnCalendarYearPrevious").click(function (evt) {
        evt.preventDefault();
        if (parseInt(ddlHolidayPlanCalendarNumber.GetValue()) < 1) {
            MoveToPreviousYear();
        }
    });
    $("#btnCalendarYearNext").click(function (evt) {
        evt.preventDefault();
        if (parseInt(ddlHolidayPlanCalendarNumber.GetValue()) < 1) {
            MoveToNextYear();
        }
    });

    $("#btnSaveHolidayPlan").click(function (evt) {
        evt.preventDefault();
        SaveHoliday_Schedule();
    });
    $("#btnDeleteHolidayPlan").click(function (evt) {
        evt.preventDefault();
        ConfirmDelete();
    });
    $("#btnInformation").click(function (evt) {
        evt.preventDefault();

    });

    $("#btnSelectAll").click(function (evt) {
        evt.preventDefault();

        var totalRows = window.gridViewHoliday.GetVisibleRowsOnPage();

        for (var holidayRow = 0; holidayRow <= totalRows - 1; holidayRow++) {
            window.gridViewHoliday.SelectRowOnPage(holidayRow, true);
        }
    });

    $("#btnDeselectAll").click(function (evt) {
        evt.preventDefault();

        var totalRows = window.gridViewHoliday.GetVisibleRowsOnPage();

        for (var holidayRow = 0; holidayRow <= totalRows - 1; holidayRow++) {
            window.gridViewHoliday.UnselectRowOnPage(holidayRow);
        }
    });

    $("#btnRemoveSelected").click(function (evt) {
        evt.preventDefault();
        gridViewHoliday.PerformCallback();
    });

    $("#btnApply").click(function (evt) {
        evt.preventDefault();
        var editStatus = JSON.stringify(gridViewHoliday.batchEditHelper.updatedValues) == "{}";
        if (editStatus === false) {
            FillSelectedAccessProfile(JSON.parse(getJSN()));
        }
        else {
            return;
        }

    });
    $("#chkAllowAccess").click(function () {
        if ($("#chkAllowAccess")[0].checked === true) {
            $("#chkDenyAccess")[0].checked = false;
        }
    });

    $("#chkDenyAccess").click(function () {
        if ($("#chkDenyAccess")[0].checked === true) {
            $("#chkAllowAccess")[0].checked = false;
        }
    });

    $("#txtHolidayPlanCalendarNumber").change(function (e) {
        e.preventDefault();
        saveChanges = true;
    });
    $("#txtHolidayPlanCalendarName").change(function (e) {
        e.preventDefault();
        saveChanges = true;
    });
    $("#txtMemo").change(function (e) {
        e.preventDefault();
        saveChanges = true;
    });
    $("#ddlHolidayCalendarNumber").change(function () {
        saveChanges = true;
    });
    $("#ddlHolidayCalendarName").change(function () {
        saveChanges = true;
    });

    $('#btnSearchProfiles').click(function (e) {
        e.preventDefault();
        if (ddlAccessProfileIdNumber.GetValue() !== "0") {
            $('.contentdivbottomlefttop').hide();

            $('#btnNewHolidayPlan').hide();
            $('#btnDeleteHolidayPlan').hide();
            $('#btnSaveHolidayPlan').hide();

            $('.contentdivbottomleftbottom').hide();
            $('.contentdivbottomright').hide();
            $('.contentdivbottomleft').hide();
            $('.tblAccessProfiles').show();
            $('.contentdivbottomNew').css({
                height: "86%",
                backgroundColor: "",
            });

            $('.contentdiv ').css({
                height: "99%",
                backgroundColor: "",
            });
            $('.contentdivbottom ').css({
                height: "91%",
            });
            backValue = 1;
            var selectedPlan = ddlAccessProfileIdNumber.GetText();
            $("#txtAccessProfileMemo").val($("#dplAccessProfileMemo option:selected").text());
            $('.topdivbtmnew9').hide();
            grdZuttritProfileTimeFrames.PerformCallback(selectedPlan);
        }
    });

    $("#btnSearchAccessProfile").click(function (evt) {
        evt.preventDefault();

        $('.contentdivbottomNew').hide();
        $('#ContentAreaDiv').css("background-color", "");
        $('.accssProfls').show();
        $('#btnNewHolidayPlan').hide();
        $('#btnDeleteHolidayPlan').hide();
        $('#btnSaveHolidayPlan').hide();
        $('.topdivbtmnew9').hide();
        backValue = 2;

    });


    $('#btnBack').click(function (e) {
        e.preventDefault();
        if (backValue === 0) {
            switch (saveChanges && allowZUTEdit) {
                case true:
                    //var planNr = $("#txtPlanNr").val().trim();
                    //if (planNr !== "0" && planNr !== "") {

                    //}
                    BackButtonConfirm();
                    break;
                case false:
                    document.location.href = "/Content/AccessPlan.aspx";
                    break;
                default:
                    document.location.href = "/Content/AccessPlan.aspx";
                    break;
            }
        }
        else if (backValue === 1) {
            $('.contentdivbottomlefttop').show();
            $('.contentdivbottomleftbottom').show();
            $('.contentdivbottomright').show();
            $('.contentdivbottomleft').show();
            $('#btnNewHolidayPlan').hide();
            $('#btnDeleteHolidayPlan').show();
            $('#btnSaveHolidayPlan').show();
            $('.tblAccessProfiles').hide();
            $('.contentdivbottomNew').css({
                height: "87%",
                backgroundColor: "",
            });

            $('.contentdiv ').css({
                height: "97%",
                backgroundColor: "",
            });
            $('.contentdivbottom ').css({
                height: "89%",
            });
            $('.topdivbtmnew9').show();
            backValue = 0;
        }
        else if (backValue === 2) {
            $('.accssProfls').hide();
            $('#ContentAreaDiv').css("background-color", "");
            $('.contentdivbottomNew').show();
            $('#btnNewHolidayPlan').show();
            $('#btnDeleteHolidayPlan').show();
            $('#btnSaveHolidayPlan').show();
            $('.topdivbtmnew9').show();
            backValue = 0;
        }
    });
});

function gridViewHolidaySelectionChanged(s, e) {
    holidays = [];
    holidayDates = [];
    s.GetSelectedFieldValues("HolidayDate", GetSelectedHolidays);

}

function GetSelectedHolidays(values) {
    for (var i = 0; i < values.length; i++) {
        var holidayDate = values[i][1];

        holidays.push({
            HolidayDate: holidayDate
        });
        var newDate = new Date(holidayDate).setHours(0, 0, 0, 0);
        var _holidayDate = new Date(newDate).getTime();
        holidayDates.push(_holidayDate);
    }

}

function IsNumber(e) {
    if (e.charCode > 31 && (e.charCode < 48 || e.charCode > 57)) {
        return false;
    }

    return true;
}

//check if day has time frames
function DayHasTimeFrames(accessProfileId) {
    var data = { accessProfileId: accessProfileId };

    $.ajax({
        type: "POST",
        async: false,
        url: "HolidaySchedule.aspx/DayHasTimeFrames",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            dayHasTimeFrames = result.d;
        }
    });
}

//highlighting and colouring stuff
function getDayOfWeekName(daysDate) {
    var data = { daysDate: daysDate };

    $.ajax({
        type: "POST",
        async: false,
        url: "SwitchCalender.aspx/GetDayOfWeekName",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            dayOfWeekName = result.d;
        }
    });
}

var isMouseDown = false;
var cellStartIndex = 0;
var cellEndIndex = 0;

var rowStartIndex = -1;

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

function OnMouseUp(cell) {
    cellEndIndex = cell.cellIndex;
    isMouseDown = false;
}

function OnMouseMove(cell, rowIndex) {
    return;

    var formMode = $("#hiddenFieldFormMode").attr("value");

    if (formMode <= 1) {
        return;
    }

    var currentCellIndex = cell.cellIndex;
    if (currentCellIndex === 0) {//skip Month Column
        return;
    }

    if (cell.childNodes[0].textContent === "FT") {//skip holidays
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
            var rowCells = window.gridViewHolidayPlanCalendar.GetRow(i).cells;

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

//function OnCellClick(cell, rowIndex) {

//    var fieldName = cell.attributes["celltype"].value;

//    if (fieldName !== "MonthName") {
//        //removeAllHighlighting();
//        return;
//    }
//}

function removeHolidayHighlighting() {
    var formMode = $("#hiddenFieldFormMode").attr("value");

    if (formMode <= 1) {
        return;
    }

    var calendarYear = Number($("#hiddenFieldCalendarYear").attr("value"));

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1; currentCellIndex <= 31; currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (isValidDate(rowNumber, currentCellIndex)) {
                if (isWeekend(rowNumber, currentCellIndex)) {
                    var daysDate = new Date(calendarYear, rowNumber, currentCellIndex);
                    cell.style.backgroundColor = "green";
                    cell.style.foreColor = "black";

                    getDayOfWeekName(daysDate);
                    cell.childNodes[0].textContent = dayOfWeekName;
                } else {
                    cell.style.backgroundColor = "white";
                    cell.style.foreColor = "black";
                    cell.childNodes[0].textContent = "";
                }
            } else {
                cell.style.backgroundColor = "black";
            }
        }
    }
}

function removeAllHighlighting() {
    return;
    var formMode = $("#hiddenFieldFormMode").attr("value");

    if (formMode <= 1) {
        return;
    }

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1; currentCellIndex <= 31; currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (cell.childNodes[0].textContent === "FT") {//skip holidays
                cell.style.backgroundColor = "#FF0";
                cell.style.foreColor = "#F00";
                continue;
            }

            if (isValidDate(rowNumber, currentCellIndex)) {
                if (isWeekend(rowNumber, currentCellIndex)) {
                    cell.style.backgroundColor = "green";
                } else {
                    cell.style.backgroundColor = "white";
                    cell.style.foreColor = "black";
                    cell.childNodes[0].textContent = "";
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

function IncrementIdNumber() {
    var maximumNumber = 0;
    var currentNumber = [];

    //$("#ddlHolidayPlanCalendarNumber option").each(function () {
    //    currentNumber.push(this.text);
    //});
    for (var i = 0; i < ddlHolidayPlanCalendarNumber.GetItemCount() ; i++) {
        currentNumber.push(ddlHolidayPlanCalendarNumber.GetItem(i).text);
    }

    maximumNumber = Math.max.apply(Math, currentNumber);
    maximumNumber++;

    $("#txtHolidayPlanCalendarNumber").val(maximumNumber);
    $("#txtHolidayPlanCalendarNumber").focus();
}

function CallDeleteConfirmBox() {
    if (confirm("Moechten Sie diesen Kalender wirklich loeschen")) {
        $("#hiddenFieldConfirmDialog").attr("value", "1");
        $("[id$=btnDeleteHolidayPlan]").click();
    } else {
        $("#hiddenFieldConfirmDialog").attr("value", "2");
        $("[id$=btnDeleteHolidayPlan]").click();
    }
}
function getSelectedOptions(s, e) {
    holidays = [];
    holidayDates = [];
    s.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);

}
function FillHolidays() {
    //var calendarYear = Number($("#ddlCalendarYear option:selected").val());
    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        $("#ddlCalendarYear2").focus();

        return;
    }

    removeHolidayText();

    for (var holidayGani in holidays) {
        if (holidays.hasOwnProperty(holidayGani)) {
            var holiday = holidays[holidayGani];

            var holidayDate = holiday.HolidayDate;
            //var holidayDate = Date.parse(moment(holidayDate, "DD.MM.YYYY")["_d"]);

            var holidayMonth = Number(new Date(holidayDate).getMonth());
            var holidayDay = Number(new Date(holidayDate).getDate());

            //display on calendar
            var calendarRowCells = window.gridViewHolidayPlanCalendar.GetRow(holidayMonth).cells;
            var holidayCell = calendarRowCells[holidayDay];

            holidayCell.childNodes[0].textContent = "FT";
            holidayCell.style.backgroundColor = "#FF0";
            holidayCell.style.foreColor = "#F00";
        }
    }
    //fill access plans
    for (var profile in accessProfiles) {
        if (accessProfiles.hasOwnProperty(profile)) {
            var holiday = accessProfiles[profile];

            var holidayDate = Date.parse(moment(holiday.AccessProfileDate, "DD.MM.YYYY")["_d"]);
            var profileId = holiday.AccessProfileId;

            var holidayMonth = Number(new Date(holidayDate).getMonth());
            var holidayDay = Number(new Date(holidayDate).getDate());

            //display on calendar
            var calendarRowCells = window.gridViewHolidayPlanCalendar.GetRow(holidayMonth).cells;
            var holidayCell = calendarRowCells[holidayDay];

            holidayCell.childNodes[0].textContent = profileId;
            holidayCell.style.backgroundColor = "#FF0";
            //holidayCell.style.foreColor = "#F00";
            holidayCell.style.color = "rgb(255, 0, 0)";
        }
    }
}
function removeHolidayText() {
    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1; currentCellIndex <= 31; currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (cell.childNodes[0].textContent === "FT") {
                cell.childNodes[0].textContent = "";

                if (isValidDate(rowNumber, currentCellIndex)) {
                    if (isWeekend(rowNumber, currentCellIndex)) {
                        cell.style.backgroundColor = "green";
                    } else {
                        cell.style.backgroundColor = "white";
                        cell.style.foreColor = "black";
                        cell.childNodes[0].textContent = "";
                    }
                } else {
                    cell.style.backgroundColor = "black";
                }
            }
        }
    }
}
function FillWorkHolidays(WorkHolidays, plan, planSelected) {

    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        $("#ddlCalendarYear2").focus();

        return;
    }
    for (var holidayGani in WorkHolidays) {
        if (WorkHolidays.hasOwnProperty(holidayGani)) {
            var holiday = WorkHolidays[holidayGani];

            var holidayDate = holiday.HolidayDate;
            var _IsChecked = holiday.IsChecked;
            //var holidayDate = holiday.HolidayDate;

            //var holidayMonth = Number(new Date(holiday).getMonth());
            //var holidayDay = Number(new Date(holiday).getDate());
            var holidayMonth = moment(holidayDate, "DD.MM.YYYY")["_d"].getMonth()
            var holidayDay = moment(holidayDate, "DD.MM.YYYY")["_d"].getDate();

            switch (_IsChecked) {
                case "true":
                    saveChanges = true;
                    //display on calendar
                    var calendarRowCells = window.gridViewHolidayPlanCalendar.GetRow(holidayMonth).cells;
                    var holidayCell = calendarRowCells[holidayDay];
                    if (planSelected === true) {
                        holidayCell.childNodes[0].textContent = plan;
                        holidayCell.style.backgroundColor = "#FF0";
                        holidayCell.style.color = "rgb(255, 0, 0)";
                    }
                    else if (planSelected === false) {
                        var calendarRowCells = window.gridViewHolidayPlanCalendar.GetRow(holidayMonth).cells;
                        var holidayCell = calendarRowCells[holidayDay];
                        holidayCell.childNodes[0].textContent = "FT";
                        holidayCell.style.backgroundColor = "#FF0";
                        holidayCell.style.color = "rgb(255, 0, 0)";
                    }
                    break;
                case "false":

                    break;
            }

        }
    }

    for (var rowIndex = 0; rowIndex <= 11; rowIndex++) {
        for (var columnIndex = 1; columnIndex <= 31; columnIndex++) {
            var cell = window.gridViewHolidayPlanCalendar.GetRow(rowIndex).cells[columnIndex];

            if ((cell.style.backgroundColor === "rgb(255, 246, 3)") || (cell.style.backgroundColor === "rgb(47, 181, 159)")) {//highlighted

                var daysDate = new Date(calendarYear, rowIndex, columnIndex);
                var dayOfWeek = daysDate.getDay();

                switch (dayOfWeek) {
                    case 0: //sunday
                    case 6: //saturday
                        //DayHasTimeFrames(accessProfileId);

                        //if (dayHasTimeFrames === true) {
                        //    if (accessProfileId.trim().length === 0) {
                        //        getDayOfWeekName(daysDate);
                        //        cell.childNodes[0].textContent = dayOfWeekName;
                        //    } else {
                        //        cell.childNodes[0].textContent = accessProfileId;
                        //    }
                        //} else {
                        //    getDayOfWeekName(daysDate);
                        //    cell.childNodes[0].textContent = dayOfWeekName;
                        //}

                        getDayOfWeekName(daysDate);
                        cell.childNodes[0].textContent = dayOfWeekName;

                        break;

                    default:
                        //cell.childNodes[0].textContent = accessProfileId;
                        break;
                }
            }
        }
    }

    var jsonArray = [];

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        jsonArray.push({
            Id: rowNumber + 1,
            Day1AccessProfileId: rowCells[1].childNodes[0].textContent,
            Day2AccessProfileId: rowCells[2].childNodes[0].textContent,
            Day3AccessProfileId: rowCells[3].childNodes[0].textContent,
            Day4AccessProfileId: rowCells[4].childNodes[0].textContent,
            Day5AccessProfileId: rowCells[5].childNodes[0].textContent,
            Day6AccessProfileId: rowCells[6].childNodes[0].textContent,
            Day7AccessProfileId: rowCells[7].childNodes[0].textContent,
            Day8AccessProfileId: rowCells[8].childNodes[0].textContent,
            Day9AccessProfileId: rowCells[9].childNodes[0].textContent,
            Day10AccessProfileId: rowCells[10].childNodes[0].textContent,
            Day11AccessProfileId: rowCells[11].childNodes[0].textContent,
            Day12AccessProfileId: rowCells[12].childNodes[0].textContent,
            Day13AccessProfileId: rowCells[13].childNodes[0].textContent,
            Day14AccessProfileId: rowCells[14].childNodes[0].textContent,
            Day15AccessProfileId: rowCells[15].childNodes[0].textContent,
            Day16AccessProfileId: rowCells[16].childNodes[0].textContent,
            Day17AccessProfileId: rowCells[17].childNodes[0].textContent,
            Day18AccessProfileId: rowCells[18].childNodes[0].textContent,
            Day19AccessProfileId: rowCells[19].childNodes[0].textContent,
            Day20AccessProfileId: rowCells[20].childNodes[0].textContent,
            Day21AccessProfileId: rowCells[21].childNodes[0].textContent,
            Day22AccessProfileId: rowCells[22].childNodes[0].textContent,
            Day23AccessProfileId: rowCells[23].childNodes[0].textContent,
            Day24AccessProfileId: rowCells[24].childNodes[0].textContent,
            Day25AccessProfileId: rowCells[25].childNodes[0].textContent,
            Day26AccessProfileId: rowCells[26].childNodes[0].textContent,
            Day27AccessProfileId: rowCells[27].childNodes[0].textContent,
            Day28AccessProfileId: rowCells[28].childNodes[0].textContent,
            Day29AccessProfileId: rowCells[29].childNodes[0].textContent,
            Day30AccessProfileId: rowCells[30].childNodes[0].textContent,
            Day31AccessProfileId: rowCells[31].childNodes[0].textContent
        });
    }

    //$("#btnSaveHolidayPlan").prop("disabled", false);

    var jsonString = JSON.stringify(jsonArray);
    var data = { jsonData: jsonString };

    $.ajax({
        type: "POST",
        url: "HolidaySchedule.aspx/UpdateHolidayPlanAccessProfileMonth",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
        }
    });
}
function DateFromChanged(s, e) {
    var dateFrom = s.date;
    var dateTo = window.datePickerDateTo.GetDate();
    if (dateTo === null) {
        datePickerDateTo.SetDate(dateFrom);
    }
    holidays = [];
    holidayDates = [];
    window.gridViewHoliday.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);
}
function DateToChaged(s, e) {
    var dateTo = s.date;
    var dateFrom = window.datePickerDateFrom.GetDate();
    if (dateFrom === null) {
        datePickerDateFrom.SetDate(dateTo);
    }
    holidays = [];
    holidayDates = [];
    window.gridViewHoliday.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);
}
function getSelectedDates(startDate, endDate) {
    var now = new Date(Date.now());
    var daysOfYear = [];
    for (var d = new Date(startDate) ; d <= endDate; d.setDate(d.getDate() + 1)) {
        daysOfYear.push(new Date(d));
    }
    return daysOfYear;
}
function isInHolidays(value, array) {
    return array.indexOf(value) > -1;
}
function getSelectedAccessPLans(planId) {
    var data = { holidayPlanId: planId };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanHolidaySchedule.aspx/AccessProfileList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            accessProfiles = result.d;
        }
    });
}
function FillSelectedAccessProfile(WorkHolidays) {
    var planSelected = false;
    var holidayPLan = ddlHolidayPlanCalendarNumber.GetValue();
    var selectedPlanValue = ddlAccessProfileIdNumber.GetValue();
    if (selectedPlanValue === "0" || selectedPlanValue === undefined) {
        planSelected = false;
    }
    else {
        planSelected = true;
    }
    var selectedPlan = ddlAccessProfileIdNumber.GetText();
    FillWorkHolidays(WorkHolidays, selectedPlan, planSelected);
}
function getJSN() {
    var strJsn = "", valuesJsn = "", valuesCount = 1;

    for (var rowCount = 0; rowCount < gridViewHoliday.keys.length; rowCount++) {
        if (gridViewHoliday.GetRow(rowCount).cells[3].childNodes[0].childNodes[0] != undefined) {
            var isChecked = gridViewHoliday.GetRow(rowCount).cells[3].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") != -1;
            //var selectedDate = gridViewHoliday.GetRow(rowCount).cells[3].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") != -1;
            var Id = gridViewHoliday.keys[rowCount];
            var selectedDate = gridViewHoliday.GetRow(rowCount).cells[1].childNodes[0].textContent;
            valuesJsn += String.format("\"{0}\":{{ \"ID\": {1}, \"HolidayDate\": \"{2}\", \"IsChecked\": \"{3}\" }} , ", valuesCount, Id, selectedDate, isChecked);
            valuesCount += 1;
        }

    }

    if (valuesJsn.trim() != "") {
        strJsn = String.format("{{ {0} }}", valuesJsn.trim().substring(0, valuesJsn.trim().length - 1));
    }

    return strJsn;
}
function gridViewHolidayRowDbClick(s, e) {

}
function SetProfileSelectedDxDrp(setVal) {
    ddlAccessProfileNumber.SetValue(setVal);
    ddlAccessProfileName.SetValue(setVal);
    ddlAccessProfileIdNumber.SetValue(setVal);
    $("#dplAccessProfileMemo").val(setVal);
}
function Reset_Default() {
    document.getElementById('importantDialog').innerHTML = "";
}

function saveHolidayCalendarBack() {
    Reset_Default();
    var planId = ddlHolidayPlanCalendarNumber.GetValue();
    var accessPlanId = $("#ddlAccessPlanName").val();
    var calendarId = ddlHolidayCalendarNumber.GetValue();
    var planNr = $("#txtHolidayPlanCalendarNumber").val();
    var planName = $("#txtHolidayPlanCalendarName").val();
    var memo = $("#txtMemo").val();
    var allowAccess = 0;
    if ($("#chkDenyAccess")[0].checked === true) {
        allowAccess = 0;
    }
    if ($("#chkAllowAccess")[0].checked === true) {
        allowAccess = 1;
    }
    if (parseInt(planNr) < 1) {
        alert("Geben Sie Plan Nr");
        return;
    }
    if (parseInt(calendarId) < 1) {
        alert("Wählen Sie Feiertagskalender");
        return;
    }
    PageMethods.SaveHolidaySchedule(planId, planNr, planName, memo, allowAccess, calendarId, accessPlanId, SaveHolidayScheduleOnBack_CallBack);
}
function SaveHolidayScheduleOnBack_CallBack() {
    document.location.href = "/Content/AccessPlan.aspx";
}
function BackButtonConfirm() {

    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%;width: 130px; margin-right: 0px;"  onclick="saveHolidayCalendarBack()"></button><button id="btnNo" style="margin-left: 10px;width: 160px;"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
function CancelOnBackButton() {
    Reset_Default();
}
//delete confirmation
function ConfirmDelete() {
    var message = "Sind Sie sicher, dass Sie löschen möchten";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOkDelete"  style="margin-left: 32%; margin-right: 10px;"  onclick="DeleteHolidaySchedule()"></button><button id="btnCancelDelete"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteHolidayPlan");
    $('#btnOkDelete').text(levelCaption);
    getLocalizedText("cancelDeleteHolidayPlan");
    $('#btnCancelDelete').text(levelCaption);
}
function No_OnBack() {
    Reset_Default();
    document.location.href = "/Content/AccessPlan.aspx";
}

function OnCellClick(cell, rowIndex) {
    var fieldName = cell.attributes["celltype"].value;

    if (fieldName !== "MonthName") {
        var clickedCellVal = cell.textContent.trim();

        if (clickedCellVal.length >= 1) {
            if ((clickedCellVal !== "Sa") && (clickedCellVal !== "So") && (clickedCellVal !== "FT")) {
                $('.contentdivbottomlefttop').hide();
                $('.contentdivbottomleftbottom').hide();
                $('.contentdivbottomright').hide();
                $('.contentdivbottomleft').hide();
                $('.tblAccessProfiles').show();
                $('.contentdivbottomNew').css({
                    height: "86%",
                    backgroundColor: "",
                });

                $('.contentdiv ').css({
                    height: "99%",
                    backgroundColor: "#d0e4f7",
                });
                $('.contentdivbottom ').css({
                    height: "91%",
                });
                backValue = 1;
                window.grdZuttritProfileTimeFrames.PerformCallback(clickedCellVal);

            }
        }
    }
}

function gridViewAccessProfileRowClick(s, e) {
    gridViewAccessProfileSearch.GetRowValues(e.visibleIndex, "ID;AccessProfileNo;AccessDescription", GetAccessProfileRowValues);
    $('.accssProfls').hide();
    $('#ContentAreaDiv').css("background-color", "");
    $('.contentdivbottomNew').show();
    $('.topdivbtmnew9').show();
}

function GetAccessProfileRowValues(values) {
    var accessProfileId = values[0].toString();

    ddlAccessProfileNumber.SetValue(accessProfileId);
    ddlAccessProfileName.SetValue(accessProfileId);
    ddlAccessProfileIdNumber.SetValue(accessProfileId);

}
function PlanNumberSelectedIndexChanged(s, e) {
    if (_isPlanClick === true) {
        ddlHolidayPlanCalendarName.SetValue(s.GetValue());
        $("#txtHolidayPlanCalendarNumber").val(s.GetText());
        $("#txtHolidayPlanCalendarName").val(ddlHolidayPlanCalendarName.GetText());
        PageMethods.GetHolidayPlan(s.GetValue(), GetHolidayPlan_CallBack);
    }

}
function PlanNameSelectedIndexChanged(s, e) {
    if (_isPlanClick === true) {
        ddlHolidayPlanCalendarNumber.SetValue(s.GetValue());
        $("#txtHolidayPlanCalendarNumber").val(ddlHolidayPlanCalendarNumber.GetText());
        $("#txtHolidayPlanCalendarName").val(s.GetText());
        PageMethods.GetHolidayPlan(s.GetValue(), GetHolidayPlan_CallBack);
    }

}
function dplPlanClicked(s, e) {
    _isPlanClick = true;
}
function HolidaySelectedChanged(s, e) {
    saveChanges = true;
    ddlHolidayCalendarNumber.SetValue(s.GetValue());
    ddlHolidayCalendarName.SetValue(s.GetValue());
    var _passValue = s.GetValue() + ';' + "2";
    gridViewHoliday.PerformCallback(_passValue);
    gridViewHolidayPlanCalendar.PerformCallback(_passValue);
}
function GetHolidayPlan_CallBack(result) {
    if (result !== null) {
        if (result.Id === 0) {
            ddlHolidayCalendarNumber.SetValue("0");
            ddlHolidayCalendarName.SetValue("0");
        }
        ddlCalendarYear2.SetValue(result.CalendarYear);
        $("#txtMemo").val(result.Memo);
        if (result.AllowAccess != null) {
            switch (result.AllowAccess) {
                case 0:
                    $("#chkDenyAccess")[0].checked = true;
                    break;
                case 1:
                    $("#chkAllowAccess")[0].checked = true;
                    break;
                default:
                    $("#chkDenyAccess")[0].checked = true;
                    break;
            }
        }
        else {
            $("#chkDenyAccess")[0].checked = false;
            $("#chkAllowAccess")[0].checked = false;
        }
        var _passValue = result.Id + ';' + "1";
        gridViewHoliday.PerformCallback(_passValue);
        gridViewHolidayPlanCalendar.PerformCallback(_passValue);
    }
}
function SetControlsOnNew() {
    ddlHolidayPlanCalendarNumber.SetValue = "0";
    ddlHolidayPlanCalendarName.SetValue = "0";
    ddlHolidayPlanCalendarNumber.SetEnabled(false);
    ddlHolidayPlanCalendarName.SetEnabled(false);
}
function SaveHoliday_Schedule() {
    var planId = ddlHolidayPlanCalendarNumber.GetValue();
    var accessPlanId = $("#ddlAccessPlanName").val();
    var calendarId = ddlHolidayCalendarNumber.GetValue();
    var planNr = $("#txtHolidayPlanCalendarNumber").val();
    var planName = $("#txtHolidayPlanCalendarName").val();
    var memo = $("#txtMemo").val();
    var allowAccess = 0;
    if ($("#chkDenyAccess")[0].checked === true) {
        allowAccess = 0;
    }
    if ($("#chkAllowAccess")[0].checked === true) {
        allowAccess = 1;
    }
    if (parseInt(planNr) < 1) {
        alert("Geben Sie Plan Nr");
        return;
    }
    if (parseInt(calendarId) < 1) {
        alert("Wählen Sie Feiertagskalender");
        return;
    }
    PageMethods.SaveHolidaySchedule(planId, planNr, planName, memo, allowAccess, calendarId, accessPlanId, OnSaveHolidaySchedule_CallBack);
}
function OnSaveHolidaySchedule_CallBack(id) {
    saveChanges = false;
    ddlHolidayPlanCalendarNumber.SetEnabled(true);
    ddlHolidayPlanCalendarName.SetEnabled(true);
    ddlHolidayPlanCalendarNumber.PerformCallback(id);
    ddlHolidayPlanCalendarName.PerformCallback(id);
}
function DeleteHolidaySchedule() {
    Reset_Default();
    var planId = ddlHolidayPlanCalendarNumber.GetValue();
    PageMethods.DeleteHolidayPlan(planId, OnDeleteHolidayPlan_CallBack);
}
function OnDeleteHolidayPlan_CallBack() {
    ddlHolidayCalendarNumber.SetValue("0");
    ddlHolidayCalendarName.SetValue("0");
    $("#txtHolidayPlanCalendarNumber").val("0");
    $("#txtHolidayPlanCalendarName").val("keine");
    ddlHolidayPlanCalendarNumber.PerformCallback();
    ddlHolidayPlanCalendarName.PerformCallback();
    var _passValue = "0" + ';' + "1";
    gridViewHoliday.PerformCallback(_passValue);
    gridViewHolidayPlanCalendar.PerformCallback(_passValue);
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