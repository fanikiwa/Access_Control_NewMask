var holidays = [];
var dayOfWeekName;
var dayHasTimeFrames;
var holidayDates = [];
var selectedHolidays = null;
var HolidaySelected = [];
var saveChanges = false;
var backValue = 0;
var _isPlanClick = false;
var levelCaption;
$(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
    //if ($("#ddlHolidayPlanCalendarNumber option:selected").val() !== "0") {
    //  //  var holidayPlanId = $("#ddlHolidayPlanCalendarNumber option:selected").val();
    //    //getSelectedAccessPLans(holidayPlanId);
    //    //var _accessProfiles = accessProfiles;
    //}
    //else {
    //    //removeHolidayText();
    //}

    var holidayPlanId = ddlHolidayPlanCalendarNumber.GetValue();
    getSelectedHolidays(holidayPlanId);
    var _seletedHolidays = selectedHolidays;
    $(document).on("selectstart", false);

    $("#btnSelectAll").click(function (evt) {
        evt.preventDefault();

        var totalRows = window.gridViewHoliday.GetVisibleRowsOnPage();

        for (var holidayRow = 0;holidayRow <= totalRows - 1;holidayRow++) {
            window.gridViewHoliday.SelectRowOnPage(holidayRow, true);
        }
    });

    $("#btnDeselectAll").click(function (evt) {
        evt.preventDefault();

        var totalRows = window.gridViewHoliday.GetVisibleRowsOnPage();

        for (var holidayRow = 0;holidayRow <= totalRows - 1;holidayRow++) {
            window.gridViewHoliday.UnselectRowOnPage(holidayRow);
        }
    });

    $("#btnRemoveSelected").click(function (evt) {
        evt.preventDefault();
        gridViewHoliday.PerformCallback();
    });

    $("#btnApply").click(function (evt) {
        evt.preventDefault();
        //var _dateFrom = window.datePickerDateFrom.GetDate();
        //var _dateTo = window.datePickerDateTo.GetDate();
        //if (_dateFrom === null) return;
        //if (_dateTo === null) return;
        //var selectedDates = new Array();
        //selectedDates = getSelectedDates(_dateFrom, _dateTo);
        //PageMethods.SelectedHolidays(OnSelectedHolidays_CallBack);
        //FillWorkHolidays(HolidaySelected, selectedPlan);
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
            saveChanges = true
        }
    });

    $("#chkDenyAccess").click(function () {
        if ($("#chkDenyAccess")[0].checked === true) {
            $("#chkAllowAccess")[0].checked = false;
            saveChanges = true
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
    //$("#ddlHolidayCalendarNumber").change(function () {
    //    saveChanges = true;
    //});
    //$("#ddlHolidayCalendarName").change(function () {
    //    saveChanges = true;
    //});


    //$("#ddlHolidayCalendarNumber").change(function () {
    //    $("#ddlHolidayCalendarName").val($("#ddlHolidayCalendarNumber option:selected").val());

    //    if (window.gridViewHoliday.PerformCallback === undefined) {
    //        return;
    //    }

    //    var holidayCalendarId = $("#ddlHolidayCalendarNumber option:selected").val();

    //    window.gridViewHoliday.PerformCallback(holidayCalendarId);

    //});

    //$("#ddlHolidayCalendarName").change(function () {
    //    $("#ddlHolidayCalendarNumber").val($("#ddlHolidayCalendarName option:selected").val());

    //    if (window.gridViewHoliday.PerformCallback === undefined) {
    //        return;
    //    }

    //    var holidayCalendarId = $("#ddlHolidayCalendarName option:selected").val();

    //    window.gridViewHoliday.PerformCallback(holidayCalendarId);
    //});

    //$("#ddlAccessProfileNumber").change(function () {
    //    $("#ddlAccessProfileName").val($("#ddlAccessProfileNumber option:selected").val());
    //    $("#ddlAccessProfileIdNumber").val($("#ddlAccessProfileNumber option:selected").val());
    //});

    //$("#ddlAccessProfileName").change(function () {
    //    $("#ddlAccessProfileNumber").val($("#ddlAccessProfileName option:selected").val());
    //    $("#ddlAccessProfileIdNumber").val($("#ddlAccessProfileName option:selected").val());
    //});

    //$("#ddlAccessProfileIdNumber").change(function () {
    //    //$("#ddlAccessProfileNumber").val($("#ddlAccessProfileIdNumber option:selected").val());
    //    //$("#ddlAccessProfileName").val($("#ddlAccessProfileIdNumber option:selected").val());
    //    SetProfileSelectedDxDrp(ddlAccessProfileIdNumber.GetValue());
    //});


    $('#btnSearchProfiles').click(function (e) {
        e.preventDefault();
        if (ddlAccessProfileIdNumber.GetValue() !== "0") {
            $('.contentdivbottomlefttop').hide();
            $('.contentdivbottomleftbottom').hide();
            $('.contentdivbottomright').hide();

            $('#btnSaveHolidayPlan').hide();
            $('#btnNewHolidayPlan').hide();
            $('#btnDeleteHolidayPlan').hide();

            $('.tblAccessProfiles').show();
            $('.contentdivbottomleft').css({
                width: "100%",
                height: "100%",
                backgroundColor: "",
            });
            $('.contentdivbottom ').css({
                height: "89%",
            });
            backValue = 1;
            var selectedPlan = ddlAccessProfileIdNumber.GetText();
            $("#txtAccessProfileMemo").val($("#dplAccessProfileMemo option:selected").text());
            window.grdZuttritProfileTimeFrames.PerformCallback(selectedPlan);
        }

    });


    $('#btnBack').click(function (e) {
        e.preventDefault();
        if (backValue === 0) {
            var _change = isNaN(parseInt($("#hiddenFieldSaveChanges").val())) ? 0 : $("#hiddenFieldSaveChanges").val();
            if (_change === "1") {
                saveChanges = true;
            }
            switch (saveChanges && allowZUTEdit) {
                case true:
                    //var planNr = $("#txtPlanNr").val().trim();
                    //if (planNr !== "0" && planNr !== "") {

                    //}
                    BackButtonConfirm();
                    break;
                case false:
                    document.location.href = "/Content/Settings.aspx";
                    break;
                default:
                    document.location.href = "/Content/Settings.aspx";
                    break;
            }
        }
        else if (backValue === 1) {

            $('.contentdivbottomlefttop').show();
            $('.contentdivbottomleftbottom').show();
            $('.contentdivbottomright').show();

            $('#btnSaveHolidayPlan').show();
            $('#btnNewHolidayPlan').show();
            $('#btnDeleteHolidayPlan').show();
            $('.tblAccessProfiles').hide();
            $('.contentdivbottomleft').css({
                width: "74%",
                height: "99%",
                backgroundColor: "",
            });
            $('.contentdivbottom ').css({
                height: "89%",
            });
            backValue = 0;
        }
        else if (backValue === 2) {
            $('.searchAccessProfileCss').hide();
            $('#ContentAreaDiv').css({
                backgroundColor: "",
            });
            $('.contentdivbottom').show();
            backValue = 0;
        }

    });

    $('#btnSearchAccessProfile').click(function (e) {
        e.preventDefault();
        $('.contentdivbottom').hide();
        $('#ContentAreaDiv').css({
            backgroundColor: "#d0e4f7",
        });
        $('.searchAccessProfileCss').show();

        backValue = 2;
    });

    $('#btnDeleteHolidayPlan').on("click", function (e) {
        e.preventDefault();
        if (parseInt(ddlHolidayPlanCalendarNumber.GetValue()) > 0) {
            ConfirmDelete();
        }
    });


    $('#btnCalendarYearPrevious').on("click", function (e) {
        e.preventDefault();
        if (parseInt(ddlHolidayPlanCalendarNumber.GetValue()) < 1) {
            MoveToPreviousYear();
        }
    });
    $('#btnCalendarYearNext').on("click", function (e) {
        e.preventDefault();
        if (parseInt(ddlHolidayPlanCalendarNumber.GetValue()) < 1) {
            MoveToNextYear();
        }
    });
    $('#btnSearchAllEmp').on("click", function (e) {
        e.preventDefault();
    });

});


function gridViewHolidaySelectionChanged(s, e) {
    holidays = [];
    holidayDates = [];
    s.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);
}

function GetSelectedHolidays(values) {
    for (var i = 0;i < values.length;i++) {
        var id = values[i][0];
        var holidayDate = values[i][1];

        holidays.push({
            Id: id,
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
        url: "Holidayplan.aspx/DayHasTimeFrames",
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
        url: "Holidayplan.aspx/GetDayOfWeekName",
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

        for (var i = rowStartIndex;i <= rowIndex;i++) {
            var rowCells = window.gridViewHolidayPlanCalendar.GetRow(i).cells;

            for (var j = cellStartIndex;j <= currentCellIndex;j++) {
                var selectedCell = rowCells[j];

                if (isValidDate(i, j)) {
                    if (isWeekend(i, j)) {
                        selectedCell.style.backgroundColor = "#2FB59F";
                    } else {
                        if (selectedCell.childNodes[0].textContent === "FT") {//skip holidays
                            selectedCell.style.backgroundColor = "#FF0";
                            selectedCell.style.foreColor = "#F00";
                        } else {
                            selectedCell.style.backgroundColor = "#FFF603";
                        }
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
//        removeAllHighlighting();
//        return;
//    }
//}

function removeAllHighlighting() {
    return;
    for (var rowNumber = 0;rowNumber <= 11;rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1;currentCellIndex <= 31;currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (cell.childNodes[0].textContent === "FT") {//skip holidays
                cell.style.backgroundColor = "#FF0";
                cell.style.foreColor = "#F00";
            } else {
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

function removeHolidayText() {
    for (var rowNumber = 0;rowNumber <= 11;rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1;currentCellIndex <= 31;currentCellIndex++) {
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

    var maxNo = 0;
    var currNo = [];

    for (var i = 0;i < ddlHolidayPlanCalendarNumber.GetItemCount() ;i++) {
        currNo.push(ddlHolidayPlanCalendarNumber.GetItem(i).text);
    }
    maxNo = Math.max.apply(Math, currNo);
    maxNo++;
    $("#txtHolidayPlanCalendarNumber").val(maxNo);


    //var maximumNumber = 0;
    //var currentNumber = [];

    //for (var i = 0;i < ddlHolidayPlanCalendarNumber.GetItemCount() ;i++) {
    //    currentNumber.push(ddlHolidayPlanCalendarNumber.GetItem(i).text);
    //}

    //maximumNumber = Math.max.apply(Math, currentNumber);
    //maximumNumber++;

    //$("#txtHolidayPlanCalendarNumber").val(maximumNumber);
    //$("#txtHolidayPlanCalendarNumber").focus();
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

function DeselectAll() {
    var totalRows = window.gridViewHoliday.GetVisibleRowsOnPage();

    for (var holidayRow = 0;holidayRow <= totalRows - 1;holidayRow++) {
        window.gridViewHoliday.UnselectRowOnPage(holidayRow);
    }
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

            var holidayMonth = Number(new Date(holidayDate).getMonth());
            var holidayDay = Number(new Date(holidayDate).getDate());

            //display on calendar
            var calendarRowCells = window.gridViewHolidayPlanCalendar.GetRow(holidayMonth).cells;
            var holidayCell = calendarRowCells[holidayDay];

            holidayCell.childNodes[0].textContent = "FT";
            holidayCell.style.backgroundColor = "#FF0";
            //holidayCell.style.foreColor = "#F00";
            holidayCell.style.color = "rgb(255, 0, 0)";
        }
    }
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

    for (var rowIndex = 0;rowIndex <= 11;rowIndex++) {
        for (var columnIndex = 1;columnIndex <= 31;columnIndex++) {
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

    for (var rowNumber = 0;rowNumber <= 11;rowNumber++) {
        var rowCells = window.gridViewHolidayPlanCalendar.GetRow(rowNumber).cells;

        jsonArray.push({
            Id: rowNumber + 1,
            Day1ProfileHoliday: rowCells[1].childNodes[0].textContent,
            Day2ProfileHoliday: rowCells[2].childNodes[0].textContent,
            Day3ProfileHoliday: rowCells[3].childNodes[0].textContent,
            Day4ProfileHoliday: rowCells[4].childNodes[0].textContent,
            Day5ProfileHoliday: rowCells[5].childNodes[0].textContent,
            Day6ProfileHoliday: rowCells[6].childNodes[0].textContent,
            Day7ProfileHoliday: rowCells[7].childNodes[0].textContent,
            Day8ProfileHoliday: rowCells[8].childNodes[0].textContent,
            Day9ProfileHoliday: rowCells[9].childNodes[0].textContent,
            Day10ProfileHoliday: rowCells[10].childNodes[0].textContent,
            Day11ProfileHoliday: rowCells[11].childNodes[0].textContent,
            Day12ProfileHoliday: rowCells[12].childNodes[0].textContent,
            Day13ProfileHoliday: rowCells[13].childNodes[0].textContent,
            Day14ProfileHoliday: rowCells[14].childNodes[0].textContent,
            Day15ProfileHoliday: rowCells[15].childNodes[0].textContent,
            Day16ProfileHoliday: rowCells[16].childNodes[0].textContent,
            Day17ProfileHoliday: rowCells[17].childNodes[0].textContent,
            Day18ProfileHoliday: rowCells[18].childNodes[0].textContent,
            Day19ProfileHoliday: rowCells[19].childNodes[0].textContent,
            Day20ProfileHoliday: rowCells[20].childNodes[0].textContent,
            Day21ProfileHoliday: rowCells[21].childNodes[0].textContent,
            Day22ProfileHoliday: rowCells[22].childNodes[0].textContent,
            Day23ProfileHoliday: rowCells[23].childNodes[0].textContent,
            Day24ProfileHoliday: rowCells[24].childNodes[0].textContent,
            Day25ProfileHoliday: rowCells[25].childNodes[0].textContent,
            Day26ProfileHoliday: rowCells[26].childNodes[0].textContent,
            Day27ProfileHoliday: rowCells[27].childNodes[0].textContent,
            Day28ProfileHoliday: rowCells[28].childNodes[0].textContent,
            Day29ProfileHoliday: rowCells[29].childNodes[0].textContent,
            Day30ProfileHoliday: rowCells[30].childNodes[0].textContent,
            Day31ProfileHoliday: rowCells[31].childNodes[0].textContent
        });
    }

    //$("#btnSaveHolidayPlan").prop("disabled", false);

    var jsonString = JSON.stringify(jsonArray);
    var data = { jsonData: jsonString, calendarYear: calendarYear, holidays: holidays };

    $.ajax({
        type: "POST",
        url: "Holidayplan.aspx/UpdateHolidayPlanCalenderSchedule",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
        }
    });
}

function getSelectedOptions(s, e) {
    holidays = [];
    holidayDates = [];
    s.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);
}

function GetSelectedRowValues(values) {
    for (var i = 0;i < values.length;i++) {
        var id = values[0];
        var holidayDate = values[1];

        holidays.push({
            Id: id,
            HolidayDate: holidayDate
        });
        var newDate = new Date(holidayDate).setHours(0, 0, 0, 0);
        var _holidayDate = new Date(newDate).getTime();
        holidayDates.push(_holidayDate);
    }
}

function FillWorkHolidays(WorkHolidays, plan, planSelected) {

    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        // $("#ddlCalendarYear2").focus();
        ddlCalendarYear2.Focus();
        return;
    }
    for (var holidayGani in WorkHolidays) {
        if (WorkHolidays.hasOwnProperty(holidayGani)) {
            var holiday = WorkHolidays[holidayGani];

            var holidayDate = holiday.HolidayDate;
            var _IsChecked = holiday.IsChecked;
            //var holidayMonth = Number(new Date(moment(holidayDate, "DD.MM.YYYY")["_d"]).getMonth());
            //var holidayDay = Number(new Date(moment(holidayDate, "DD.MM.YYYY")["_d"]).getDate());
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
                    //display on calendar
                    //var calendarRowCells = window.gridViewHolidayPlanCalendar.GetRow(holidayMonth).cells;
                    //var holidayCell = calendarRowCells[holidayDay];
                    //    holidayCell.childNodes[0].textContent = "FT";
                    //    holidayCell.style.backgroundColor = "#FF0";
                    //    holidayCell.style.color = "rgb(255, 0, 0)";

                    break;
            }

        }
    }

    for (var rowIndex = 0;rowIndex <= 11;rowIndex++) {
        for (var columnIndex = 1;columnIndex <= 31;columnIndex++) {
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

    for (var rowNumber = 0;rowNumber <= 11;rowNumber++) {
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
        url: "Holidayplan.aspx/UpdateHolidayPlanAccessProfileMonth",
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
    for (var d = new Date(startDate) ;d <= endDate;d.setDate(d.getDate() + 1)) {
        daysOfYear.push(new Date(d));
    }
    return daysOfYear;
}
function isInHolidays(value, array) {
    return array.indexOf(value) > -1;
}
//function getSelectedAccessPLans() {
//    $.ajax({
//        type: "POST",
//        url: "HolidaySchedule.aspx/AccessProfileList",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function(result) {
//            accessProfiles = result.d;
//        }
//    });
//}
function getSelectedHolidays(planId) {
    var data = { holidayPlanId: planId };
    //var PlanId = plan;
    $.ajax({
        type: "POST",
        async: false,
        url: "Holidayplan.aspx/AccessProfileList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            selectedHolidays = result.d;
        }
    });
}
function SetProfileSelectedDxDrp(setVal) {
    ddlAccessProfileNumber.SetValue(setVal);
    ddlAccessProfileName.SetValue(setVal);
    //dplAccessProfileMemo.SetValue(setVal);
    ddlAccessProfileIdNumber.SetValue(setVal);
    $("#dplAccessProfileMemo").val(setVal);
    //$("#ddlAccessProfileIdNumber").val(setVal);
}
function gridViewHolidayRowChanged(s, e) {

    HolidaySelected = [];

    s.GetSelectedFieldValues("Id;HolidayDate", GetHolidaysSelected);
}

function GetHolidaysSelected(values) {

    for (var i = 0;i < values.length;i++) {
        var id = values[i][0];
        var holidayDate = values[i][1];

        HolidaySelected.push({
            Id: id,
            HolidayDate: holidayDate
        });
    }
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

    for (var rowCount = 0;rowCount < gridViewHoliday.keys.length;rowCount++) {
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
function saveHolidayCalender() {
    Reset_Default();
    if ($("#txtHolidayPlanCalendarNumber").val().trim() === "" || $("#txtHolidayPlanCalendarNumber").val().trim() === "0") {
        //getLocalizedText("noSelection");
        alert("Geben Sie Plan Nr");
        return;
    }
    if (ddlHolidayCalendarNumber.GetValue().trim() === "" || ddlHolidayCalendarNumber.GetValue().trim() === "0") {
        //getLocalizedText("noSelection");
        alert("Wählen Sie Feiertagskalender");
        return;
    }
    var calenderId = ddlHolidayCalendarNumber.GetValue();
    var holidayPlanNr = $("#txtHolidayPlanCalendarNumber").val();
    var holidayPlanName = $("#txtHolidayPlanCalendarName").val();
    var memo = $("#txtMemo").val();
    var holidayPlanId = ddlHolidayPlanCalendarNumber.GetValue();
    var allowAccess = 0
    if ($("#chkAllowAccess")[0].checked === true) {
        allowAccess = 1;
    }
    if ($("#chkDenyAccess")[0].checked === true) {
        allowAccess = 0;
    }
    PageMethods.SaveHolidayScheduleOnBack(calenderId, holidayPlanNr, holidayPlanName, memo, holidayPlanId, allowAccess, SaveHolidayScheduleOnBack_CallBack);
}
function SaveHolidayScheduleOnBack_CallBack() {
    document.location.href = "/Content/Settings.aspx";
}

//function BackButtonConfirm() {
//    getLocalizedText("saveChanges");
//    var message = levelCaption;
//    var box_content = '<div id="overlay"> <div id="box_flame"> <div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose" onclick="resetDefault()" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + ' </div><button id="btnOk" style="margin-left:59%;"  onclick="saveHolidayCalender()">  </button><button id="btnNo"  onclick="CancelOnBackButton()"></button><button id="btnCancel"  onclick="Reset_Default()"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("no");
//    $('#btnNo').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function BackButtonConfirm() {
    getLocalizedText("saveWarning");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="Reset_Default(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 35%;width: 135px; margin-right: 8px;"  onclick="saveHolidayCalender()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}


function Reset_Default() {
    document.getElementById('importantDialog').innerHTML = "";
}
function CancelOnBackButton() {
    Reset_Default();
    document.location.href = "/Content/Settings.aspx";
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "Holidayplan.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
//delete confirmation
//function ConfirmDelete() {
//    getLocalizedText("deleteHolidaySchedule");
//    var message = levelCaption;
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk"  onclick="DeleteHolidaySchedule()"></button><button id="btnNo"  onclick="CancelHSDelete()"></button><button id="btnCancel"  onclick="CancelHSDelete()"></button></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("no");
//    $('#btnNo').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}



//function ConfirmDelete() {
//    getLocalizedText("deleteHolidaySchedule");
//    var message = levelCaption;
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="Reset_Default(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Delete_HolidayPlan()"></button><button id="btnCancel"  onclick="Reset_Default(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function ConfirmDelete() {
    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
    //var message = levelCaption;
    var message = "Sind Sie sicher das Sie das Feiertagsplan tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="Reset_Default(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 30%; margin-right: 0px;"  onclick="Delete_HolidayPlan()"></button><button id="btnCancel"  onclick="Reset_Default(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitHolidayPlanDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelHolidayPlanDeletion");
    $('#btnCancel').text(levelCaption);
}


function DeleteHolidaySchedule() {
    Reset_Default();
    $("#hiddenFieldConfirmDialog").attr("value", "1");
    //$("[id$=btnDeleteHolidayPlan]").click();
    Delete_HolidayPlan();
    //ddlHolidayCalendarNumber.PerformCallback();
    //ddlHolidayCalendarName.PerformCallback();
}
function Delete_HolidayPlan() {
    Reset_Default();
    var grp = ddlHolidayPlanCalendarNumber.GetValue();
    if (grp != 0) {
        PageMethods.DeletePlan(grp, ReloadPage);
    }
    //ddlHolidayCalendarNumber.PerformCallback();
    //ddlHolidayCalendarName.PerformCallback();
}

function ReloadPage(res) {
    RebindControlsAfterDelete();
}


function RebindControlsAfterDelete() {
    ddlHolidayCalendarNumber.PerformCallback();
    ddlHolidayCalendarName.PerformCallback();

    ddlHolidayPlanCalendarNumber.PerformCallback();
    ddlHolidayPlanCalendarName.PerformCallback();
}

function CancelHSDelete() {
    Reset_Default();
    $("#hiddenFieldConfirmDialog").attr("value", "2");
    $("[id$=btnDeleteHolidayPlan]").click();
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
                $('.tblAccessProfiles').show();
                $('.contentdivbottomleft').css({
                    width: "100%",
                    height: "100%",
                    backgroundColor: "#d0e4f7",
                });
                $('.contentdivbottom ').css({
                    height: "91%",
                });
                $('#btnSaveHolidayPlan').hide();
                $('#btnNewHolidayPlan').hide();
                $('#btnDeleteHolidayPlan').hide();

                backValue = 1;
                window.grdZuttritProfileTimeFrames.PerformCallback(clickedCellVal);

            }
        }
    }
}

//function gridViewAccessProfileSearchRowClick(s, e) {
//    window.gridViewAccessProfileSearch.GetRowValues(e.visibleIndex, "ID;AccessProfileNo;AccessProfileID;AccessDescription", GetValues);

//    $('.contentdivbottom').show();
//    $('.searchAccessProfileCss').hide();
//}

//function GetValues(values) {
//    var accssID = values[0].toString();
//    //var acccssProfNr = values[1].toString();
//    //var accssProfID = values[2].toString();
//    //var accssDesc = values[3].toString();

//    $('#ddlAccessProfileNumber').val(accssID);
//    $('#ddlAccessProfileIdNumber').val(accssID);
//    $('#ddlAccessProfileName').val(accssID);
//}


function gridViewAccessProfileSearchRowClick(s, e) {
    gridViewAccessProfileSearch.GetRowValues(e.visibleIndex, "ID;AccessProfileNo;AccessDescription", GetValues);
    $('.contentdivbottom').show();
    $('.searchAccessProfileCss').hide();
}

function GetValues(values) {
    var accessProfileId = values[0].toString();

    ddlAccessProfileNumber.SetValue(accessProfileId);
    ddlAccessProfileName.SetValue(accessProfileId);
    ddlAccessProfileIdNumber.SetValue(accessProfileId);

    $('.contentdivbottom').show();
    $('.searchAccessProfileCss').hide();
}

function PlanNumberSelectedIndexChanged(s, e) {
    if (_isPlanClick === true) {
        ddlHolidayPlanCalendarName.SetValue(s.GetValue());
        ddlHolidayCalendarNumber.SetValue(s.GetValue());
        //ddlHolidayCalendarName.PerformCallback();
        // ddlHolidayCalendarNumber.PerformCallback();
        $("#txtHolidayPlanCalendarNumber").val(s.GetText());
        $("#txtHolidayPlanCalendarName").val(ddlHolidayPlanCalendarName.GetText());
        //var _passValue = s.GetValue() + ';' + "1";
        //gridViewHoliday.PerformCallback(_passValue);
        //gridViewHolidayPlanCalendar.PerformCallback(_passValue);
        PageMethods.GetHolidayPlan(s.GetValue(), GetHolidayPlan_CallBack);

        if (allowZUTEdit) $('#btnDeleteHolidayPlan').prop('disabled', false);
    }
}

function PlanNameSelectedIndexChanged(s, e) {
    if (_isPlanClick === true) {
        ddlHolidayPlanCalendarNumber.SetValue(s.GetValue());
        ddlHolidayCalendarNumber.SetValue(s.GetValue());
        //ddlHolidayCalendarName.PerformCallback();
        // ddlHolidayCalendarNumber.PerformCallback();
        $("#txtHolidayPlanCalendarNumber").val(ddlHolidayPlanCalendarNumber.GetText());
        $("#txtHolidayPlanCalendarName").val(s.GetText());
        //var _passValue = s.GetValue() + ';' + "1";
        //gridViewHoliday.PerformCallback(_passValue);
        //gridViewHolidayPlanCalendar.PerformCallback(_passValue);
        PageMethods.GetHolidayPlan(s.GetValue(), GetHolidayPlan_CallBack);
        if (allowZUTEdit) $('#btnDeleteHolidayPlan').prop('disabled', false);
    }

}

function dplPlanClicked(s, e) {
    _isPlanClick = true;
}

function GetHolidayPlan_CallBack(result) {
    if (result != null) {
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
        ddlHolidayCalendarName.PerformCallback();
        gridViewHoliday.PerformCallback(_passValue);
        gridViewHolidayPlanCalendar.PerformCallback(_passValue);
    }
}

function HolidaySelectedChanged(s, e) {
    ddlHolidayCalendarNumber.SetValue(s.GetValue());
    ddlHolidayCalendarName.SetValue(s.GetValue());
    var _passValue = s.GetValue() + ';' + "2";
    gridViewHoliday.PerformCallback(_passValue);
    gridViewHolidayPlanCalendar.PerformCallback(_passValue);
}

function ddlHolidayCalendarNumberEndCallBack(s, e) {
    ddlHolidayPlanCalendarNumber.SetValue(s.GetValue());
    ddlHolidayPlanCalendarName.SetValue(s.GetValue());
    //var _passValue = s.GetValue() + ';' + "2";
    //gridViewHoliday.PerformCallback(_passValue);
    //gridViewHolidayPlanCalendar.PerformCallback(_passValue);
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