var holidayId = 0;
var holiday = {};
var holidays = [];
var holidaysInCalendar = [];
var levelCaption;
var dayOfWeekName;
var inCalendarSelectedRow = -1;
var deleteConfirm = 0;
var hasEdit = false;
var isCobClick = false;
var backValue = 0;
$(function () {
    hasEdit = $("#HolCRHiddenField").val();
    $(document).on("selectstart", false);

    //$("#btnHolidayDelete").attr("disabled", "disabled");
    //if (hasEdit == false) {
    //    $("input[type=text]").attr("ReadOnly", "ReadOnly");
    //    $("#txtMemo").attr("ReadOnly", "ReadOnly");
    //}
    $("#btnInternet").click(function (e) {
        e.preventDefault();
        $("#MasterPage").css("position", "relative");
        $("#internetWrapper").css("display", "block");

    });
    $("#btnCancelDownload").click(function (e) {
        e.preventDefault();
        HIdeDownloadDialog();
    });
    $("#btnDeleteHolidays").click(function (e) {
        e.preventDefault();
        HIdeDownloadDialog();
    });
    $("#btnHelp").click(function (e) {
        e.preventDefault();
    });
    $("#btnApplySelectedHoliday").click(function (e) {
        e.preventDefault();
        var index = gridViewHolidayCalendarSerch.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var id = gridViewHolidayCalendarSerch.GetRowKey(index);
            if (parseInt(id) > 0) {
                ddlHolidayCalendarNumber.SetValue(id);
                ddlHolidayCalendarName.SetValue(id);
                $("#txtHolidayCalendarNumber").val(ddlHolidayCalendarNumber.GetText());
                $("#txtHolidayCalendarName").val(ddlHolidayCalendarName.GetText());
                $(".contentdivbottomsearch").hide();
                $(".contentdivbottom").show();
                $("#btnCalendarSave").show();
                $("#btnCalendarNew").show();
                $("#btnCalendarDelete").show();
                $("#btnCopyCalendar").show();
                showAssignedHolidays();
                backValue = 0;
                PageMethods.GetCalendarById(id, GetHolidayByID_CallBack);
            }
        }
    });
    $("#btnCalendarNew").click(function (e) {
        e.preventDefault();
        PageMethods.SetControlsOnNew(SetControlsOnNew_CallBack);
    });
    $("#btnCalendarSave").click(function (e) {
        e.preventDefault();
        SaveCurrentHolidayCalendar();
    });
    $("#btnSearchAllEmp").click(function (evt) {
        evt.preventDefault();
        $(".contentdivbottomsearch").show();
        $(".contentdivbottom").hide();
        $("#btnCalendarSave").hide();
        $("#btnCalendarNew").hide();
        $("#btnCalendarDelete").hide();
        $("#btnCopyCalendar").hide();
        backValue = 1;

    })

    $("#btnAssigned").css("background-color", "#ffe7a2");
    $("#btnAssigned").attr("disabled", "disabled");

    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    function showAssigned() {
        $(".gridSectionTop").show();
        $(".sectionAll").hide();
        if (allowZUTEdit) $("#btnAll").removeAttr("disabled", "disabled");

        $("#btnAssigned").attr("disabled", "disabled");
        if (allowZUTEdit) $("#btnHolidayDelete").removeAttr("disabled", "disabled");
        $("#btnAssigned").css("background-color", "#ffe7a2");
        $("#btnAll").css("background-color", "");

        $("#hiddenFieldCalendarType").attr("value", "ASS");
    }

    function showAll() {
        $(".gridSectionTop").hide();
        $(".sectionAll").show();
        $("#btnAll").attr("disabled", "disabled");
        if (allowZUTEdit) $("#btnHolidayDelete").removeAttr("disabled", "disabled");
        if (allowZUTEdit) $("#btnAssigned").removeAttr("disabled", "disabled");

        $("#btnAll").css("background-color", "#ffe7a2");
        $("#btnAssigned").css("background-color", "");

        $("#hiddenFieldCalendarType").attr("value", "ALL");
    }
    switch (mode) {
        case "0":

        case "1":

        case "2":

            break;
        case "3":

            break;
        default:

            break;
    }


    var formMode = $("#hiddenFieldFormMode").attr("value");
    switch (formMode) {
        case "3":
            showAssigned();
            break;

        case "0":
        case "1":
        case "2":
        case undefined:
            showAll();
            break;
    }

    var mode = $("#hiddenFieldHolidayModeValue").attr("value");


    $("#btnBack").click(
        function (evt) {
            evt.preventDefault();
            if (backValue === 0) {
                var changeType = $("#hiddenFieldChangeType").attr("value");
                var detectedChanges = allowZUTEdit ? $("#hiddenFieldDetectChanges").attr("value") : "0";
                switch (detectedChanges) {
                    case "0":
                        document.location.href = "Settings.aspx";
                        break;

                    case "1":
                        //BackButtonConfirm(changeType);
                        ConfirmSaveChanges();
                        break;
                    default:
                        document.location.href = "Settings.aspx";
                }
            }
            else if (backValue === 1) {
                $(".contentdivbottomsearch").hide();
                $(".contentdivbottom").show();
                $("#btnCalendarSave").show();
                $("#btnCalendarNew").show();
                $("#btnCalendarDelete").show();
                $("#btnCopyCalendar").show();
            }



        });

    $("#btnDownloadHolidays").click(
        function (evt) {
            evt.preventDefault();
            HIdeDownloadDialog();
            downloadHolidaysAndSaveInDatabase();
        });

    $("#txtHolidayCalendarNumber").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

        $("#hiddenFieldChangeType").attr("value", "CALENDAR");
    });

    $("#txtHolidayCalendarName").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

        $("#hiddenFieldChangeType").attr("value", "CALENDAR");
    });

    $("#txtMemo").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

        $("#hiddenFieldChangeType").attr("value", "CALENDAR");
    });

    $("#txtHolidayName").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");

        $("#hiddenFieldChangeType").attr("value", "HOLIDAY");
    });

    $("#btnCopyCalendar").click(function (e) {
        e.preventDefault();

        getLocalizedText("copyCalendarWarning");

        //ConfirmCopyCalendar(levelCaption);
    });

    $("#btnHolidayNew").click(function (e) {
        e.preventDefault();

        //0-None, 1-Display, 2-Create, 3-Edit
        $("#hiddenFieldHolidayModeValue").attr("value", "2");
        //$("#hiddenFieldMaintainState").attr("value", "2");
        setCreateModeHoliday();
        $("#txtHolidayName").val("");
        $("#txtHolidayName").focus();
        showAll();
    });

    $("#btnHolidaySave").click(function (e) {
        e.preventDefault();
        //$(".sectionAll").css("height", "97%");
        //$("#sectionHolidayEdit").show();
        $("#hiddenFieldDetectChanges").attr("value", "0");
        saveHoliday();
        var buttonStateAssigned = $("#btnAssigned").is(":disabled");
        var buttonStateAll = $("#btnAll").is(":disabled");
        if (buttonStateAssigned === true) {
            showAssigned();
        }
        else if (buttonStateAll === true) {
            showAll();
        }

    });

    $("#btnHolidayDelete").click(function (e) {
        e.preventDefault();
        //DeleteButtonConfirm(holidayId, "HOLIDAY");
        if (parseInt(holidayId) > 0) {
            ConfirmDeleteHoliday();
        }
        if (parseInt(inCalendarSelectedRow) > 0) {
            ConfirmDeleteHoliday();
        }
        //0-None, 1-Display, 2-Create, 3-Edit
        $("#hiddenFieldHolidayModeValue").attr("value", "1");
        setDisplayModeHoliday();
        //var mode = $("#hiddenFieldMaintainState").attr("value");
        //switch (mode) {
        //    case "1":
        //        showAssigned();
        //        break;
        //    case "2":
        //        showAll();
        //        break;
        //    default:
        //        setDisplayModeHoliday();
        //        break;
        //}
        var buttonStateAssigned = $("#btnAssigned").is(":disabled");
        var buttonStateAll = $("#btnAll").is(":disabled");
        if (buttonStateAssigned === true) {
            showAssigned();
        }
        else if (buttonStateAll === true) {
            showAll();
        }

    });

    $("#btnCalendarDelete").click(
       function (evt) {
           evt.preventDefault();
           if (parseInt(ddlHolidayCalendarNumber.GetValue()) > 0) {
               ConfirmDeleteHolidayCalendar();
           }
           ////var holidayCalendarId = $("#ddlHolidayCalendarNumber").val();
           //var holidayCalendarId = ddlHolidayCalendarNumber.GetValue();
           //DeleteButtonConfirm(holidayCalendarId, "CALENDAR");
       });

    $("#btnApply").click(function (e) {
        e.preventDefault();
        GetSelectedHolidaysCustom();
        $("#hiddenFieldDetectChanges").attr("value", "1");
        //CalenderLoadingPanel.Show();
        //removeAllHighlighting();
        //ddlCalendarYear2Old.SetEnabled(false);
        $("#btnCalendarYearPrevious").attr("disabled", "disabled");
        $("#btnCalendarYearNext").attr("disabled", "disabled");
        //ApplyHolidayToCalendarCustom(holidays);
    });

    //$("#btnCalendarYearPrevious").click(function (e) {
    //    e.preventDefault();

    //    var selectedIndex = $("#ddlCalendarYear option:selected").index();

    //    if (selectedIndex === 0) {
    //        return;
    //    }

    //    $("#ddlCalendarYear").prop("selectedIndex", (selectedIndex - 1));
    //    $("#ddlTariffYear").prop("selectedIndex", (selectedIndex - 1));

    //    var calendarYear = $("#ddlCalendarYear option:selected").val();
    //    getHolidayCalendarByYear(calendarYear);
    //});

    //$("#btnCalendarYearNext").click(function (e) {
    //    e.preventDefault();

    //    var calendarYears = [];

    //    $("#ddlCalendarYear option").each(function () {
    //        calendarYears.push(this.text);
    //    });

    //    var calendarYearsCount = calendarYears.length;
    //    var selectedIndex = $("#ddlCalendarYear option:selected").index();
    //    selectedIndex += 1;

    //    if (selectedIndex === calendarYearsCount) {
    //        return;
    //    }

    //    $("#ddlCalendarYear").prop("selectedIndex", (selectedIndex));
    //    $("#ddlTariffYear").prop("selectedIndex", (selectedIndex));

    //    var calendarYear = $("#ddlCalendarYear option:selected").val();
    //    getHolidayCalendarByYear(calendarYear);
    //});

    $("#ddlCalendarYear").change(function (e) {
        e.preventDefault();

        var selectedIndex = $("#ddlCalendarYear option:selected").index();

        $("#ddlTariffYear").prop("selectedIndex", (selectedIndex));

        var calendarYear = $("#ddlCalendarYear option:selected").val();
        getHolidayCalendarByYear(calendarYear);
    });

    //buttons for grid toggling
    $("#btnAssigned").click(function (e) {
        e.preventDefault();
        $(".sectionAll").css("height", "96%");
        $(".gridSectionTop").css("height", "96%");
        $("#sectionHolidayEdit").show();
        showAssigned();
        //$("#hiddenFieldMaintainState").attr("value", "1");
    });

    $("#btnAll").click(function (e) {
        e.preventDefault();

        showAll();
        //$("#hiddenFieldMaintainState").attr("value", "2");
    });

    var _state = $("#hiddenFieldMaintainState").val();
    switch (_state) {
        case "1":
            showAssignedHolidays();
            $("#hiddenFieldMaintainState").attr("value", "0");
            break;

        case "2":
            showAll_Copy();
            $("#hiddenFieldMaintainState").attr("value", "0");
            break;
    }
});

$(document).ready(function () {
    window.gridViewHoliday.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);
    window.gridViewHolidaysInCalendar.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidaysInCalendar);

    $("#hiddenFieldCalendarType").attr("value", "ASS");
});

function datePickerHolidayDateChanged(s, e) {
    $("#hiddenFieldDetectChanges").attr("value", "1");

    $("#hiddenFieldChangeType").attr("value", "HOLIDAY");
}

function setInitialModeHoliday() {
    //$("#btnHolidaySave").attr("disabled", "disabled");
    //if (hasEdit == true) {
    //    $("#btnHolidayDelete").removeAttr("disabled");
    //}
}

function setDisplayModeHoliday() {
    //if (hasEdit == true) {
    //    $("#btnHolidayNew").removeAttr("disabled");
    //}
    $("#btnHolidaySave").attr("disabled", "disabled");

    $("#sectionHolidayEdit").show();
}

function setCreateModeHoliday() {
    //if (hasEdit == true) {
    //    $("#btnHolidaySave").removeAttr("disabled");
    //}
    $("#sectionHolidayEdit").show();
    $(".sectionAll").css("height", "91%");
    $("#txtHolidayName").val("");

    var holidayYear = Number(new Date().getFullYear());
    var holidayMonth = Number(new Date().getMonth() + 1);
    var holidayDay = Number(new Date().getDate());

    var holidayDateProperty = String("00" + holidayDay).slice(-2) + "/" + String("00" + holidayMonth).slice(-2) + "/" + holidayYear;

    $("#txtHolidayName").val(holiday.HolidayName);
    window.datePickerHolidayDate.SetText(holidayDateProperty);
    $("#txtHolidayName").focus();
}

function setEditModeHoliday() {
    //if (hasEdit == true) {
    //    $("#btnHolidayNew").removeAttr("disabled");
    //    $("#btnHolidaySave").removeAttr("disabled");
    //    $("#btnHolidayDelete").removeAttr("disabled");
    //}

    $("#sectionHolidayEdit").show();
}

function saveHolidayCalendar() {
    var mode = Number($("#hiddenFieldFormMode").attr("value"));
    var holidayCalendarNumber = $("#txtHolidayCalendarNumber").val();
    var holidayCalendarName = $("#txtHolidayCalendarName").val();

    if ((holidayCalendarNumber === undefined) || (holidayCalendarNumber === null) || (holidayCalendarNumber === "") || (holidayCalendarNumber.trim().length === 0)) {
        $("#txtHolidayCalendarNumber").focus();

        return;
    }

    if ((holidayCalendarName === undefined) || (holidayCalendarName === null) || (holidayCalendarName === "") || (holidayCalendarName.trim().length === 0)) {
        $("#txtHolidayCalendarName").focus();

        return;
    }

    var calendarYear = Number($("#hiddenFieldCalendarYear").attr("value"));
    if ((calendarYear === NaN) || (calendarYear === 0)) {
        calendarYear = new Date().getFullYear();
    }

    var memo = $("#txtMemo").val();

    //0-None, 1-Display, 2-Create, 3-Edit
    $("#hiddenFieldFormMode").attr("value", "1");

    var parameters = { formMode: mode, calendarYear: calendarYear, holidayCalendarNumber: holidayCalendarNumber, holidayCalendarName: holidayCalendarName, memo: memo };
    $.ajax({
        type: "POST",
        async: false,
        url: "HolidayCalender.aspx/SaveHolidayCalendar",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(parameters),
        complete: function () {
            window.gridViewHolidayCalendar.PerformCallback();
        }
    });

    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "999");
}

function saveHoliday() {
    var holidayName = $("#txtHolidayName").val();
    var holidayDate = window.datePickerHolidayDate.GetDate();

    if ((holidayName === undefined) || (holidayName === null) || (holidayName === "") || (holidayName.trim().length === 0)) {
        $("#txtHolidayName").focus();

        return;
    }

    var holidayYear = Number(new Date(holidayDate).getFullYear());
    var holidayMonth = Number(new Date(holidayDate).getMonth()) + 1;
    var holidayDay = Number(new Date(holidayDate).getDate());

    var isValid = moment(holidayYear + "-" + String("00" + holidayMonth).slice(-2) + "-" + String("00" + holidayDay).slice(-2), "YYYY-MM-DD", true).isValid();

    if (isValid === false) {
        $("#datePickerHolidayDate").focus();

        return;
    }

    holiday.HolidayName = holidayName;
    holiday.HolidayDate = moment(holidayDate).format("YYYY-MM-DD");

    var data = { holiday: holiday };

    var webServiceUrl = "";

    var editMode = $("#hiddenFieldHolidayModeValue").attr("value");
    switch (editMode) {
        case "2":
            webServiceUrl = "HolidayCalender.aspx/CreateHoliday";
            break;
        case "3":
            webServiceUrl = "HolidayCalender.aspx/UpdateHoliday";
            break;
    }

    //0-None, 1-Display, 2-Create, 3-Edit
    $("#hiddenFieldHolidayModeValue").attr("value", "0");
    setInitialModeHoliday();

    var calendarType = $("#hiddenFieldCalendarType").attr("value");

    $.ajax({
        type: "POST",
        async: false,
        url: webServiceUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            window.gridViewHoliday.PerformCallback(calendarType);
            $("#hiddenFieldDetectChanges").attr("value", "0");
            $("#txtHolidayName").val("");
            datePickerHolidayDate.SetDate(null);
        }
    });
}

function gridViewHolidaysInCalendarRowClick(s, e) {
    window.gridViewHolidaysInCalendar.GetRowValues(e.visibleIndex, "Id;HolidayName;HolidayDate", GetHolidayRowValues);

    var totalRows = window.gridViewHolidaysInCalendar.GetVisibleRowsOnPage();

    for (var holidayRow = 0; holidayRow <= totalRows - 1; holidayRow++) {
        s.GetRow(holidayRow).style.backgroundColor = "#FFFFFF";
    }

    s.GetRow(e.visibleIndex).style.backgroundColor = "#CFE3F6";

    $("#hiddenFieldCalendarType").attr("value", "ASS");

    //0-None, 1-Display, 2-Create, 3-Edit
    $("#hiddenFieldHolidayModeValue").attr("value", "3");
    inCalendarSelectedRow = e.visibleIndex;
    setEditModeHoliday();
}

function gridViewHolidayRowClick(s, e) {
    window.gridViewHoliday.GetRowValues(e.visibleIndex, "Id;HolidayName;HolidayDate", GetHolidayRowValues);

    var totalRows = window.gridViewHoliday.GetVisibleRowsOnPage();

    for (var holidayRow = 0; holidayRow <= totalRows - 1; holidayRow++) {
        s.GetRow(holidayRow).style.backgroundColor = "#FFFFFF";
    }

    s.GetRow(e.visibleIndex).style.backgroundColor = "#CFE3F6";

    $("#hiddenFieldCalendarType").attr("value", "ALL");

    //0-None, 1-Display, 2-Create, 3-Edit
    $("#hiddenFieldHolidayModeValue").attr("value", "3");
    setEditModeHoliday();
}

function GetHolidayRowValues(values) {
    if (values.length === 0) {
        return;
    }

    holidayId = values[0].toString();

    var holidayName = values[1].toString();
    var holidayDate = values[2].toString();

    var holidayYear = Number(new Date(holidayDate).getFullYear());
    var holidayMonth = Number(new Date(holidayDate).getMonth() + 1);
    var holidayDay = Number(new Date(holidayDate).getDate());

    var holidayDateProperty = String("00" + holidayDay).slice(-2) + "/" + String("00" + holidayMonth).slice(-2) + "/" + holidayYear;

    holiday = { Id: holidayId, HolidayName: holidayName, HolidayDate: holidayDate }

    $("#txtHolidayName").val(holiday.HolidayName);
    window.datePickerHolidayDate.SetText(holidayDateProperty);
}

function getHolidayCalendarByYear(calendarYear) {
    var mode = $("#hiddenFieldFormMode").attr("value");
    if (mode > 1) {
        return;
    }

    var data = { calendarYear: calendarYear };

    $.ajax({
        type: "POST",
        url: "HolidayCalender.aspx/GetHolidayCalendarByYear",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            window.location.href = "HolidayCalender.aspx";
        }
    });
}

function IsNumber(e) {
    if (e.charCode > 31 && (e.charCode < 48 || e.charCode > 57)) {
        return false;
    }

    return true;
}

function gridViewHolidaysInCalendarSelectionChanged(s, e) {
    //$("#hiddenFieldDetectChanges").attr("value", "1");

    //0-None, 1-Display, 2-Create, 3-Edit
    $("#hiddenFieldFormMode").attr("value", "3");
    $("#hiddenFieldChangeType").attr("value", "CALENDAR");

    holidays = [];
    holidaysInCalendar = [];
    s.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidaysInCalendar);

    //removeAllHighlighting();
    //ApplyHolidayToCalendar(holidaysInCalendar);
}

function GetSelectedHolidaysInCalendar(values) {
    for (var i = 0; i < values.length; i++) {
        var id = values[i][0];
        var holidayDate = values[i][1];

        holidays.push({
            Id: id,
            HolidayDate: holidayDate
        });

        holidaysInCalendar.push({
            Id: id,
            HolidayDate: holidayDate
        });
    }
    //removeAllHighlighting();
    //ApplyHolidayToCalendar(holidays);
}

function gridViewHolidaySelectionChanged(s, e) {
    //$("#hiddenFieldDetectChanges").attr("value", "1");

    //0-None, 1-Display, 2-Create, 3-Edit
    $("#hiddenFieldFormMode").attr("value", "3");
    $("#hiddenFieldChangeType").attr("value", "CALENDAR");

    holidays = [];
    s.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidays);
}

function GetSelectedHolidays(values) {
    for (var i = 0; i < values.length; i++) {
        var id = values[i][0];
        var holidayDate = values[i][1];

        holidays.push({
            Id: id,
            HolidayDate: holidayDate
        });
    }
}

function ResetHolidays() {
    //var calendarMode = $("#hiddenFieldFormMode").attr("value");
    //if (calendarMode === "2") {
    window.gridViewHoliday.UnselectAllRowsOnPage();
    //}
}

function removeAllHighlighting() {

    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        $("#ddlCalendarYear").focus();

        return;
    }

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        if (window.gridViewHolidayCalendar.GetRow === undefined) {
            return;
        }

        var rowCells = window.gridViewHolidayCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1; currentCellIndex <= 31; currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (isValidDate(rowNumber, currentCellIndex)) {
                if (isWeekend(rowNumber, currentCellIndex)) {
                    var daysDate = new Date(calendarYear, rowNumber, currentCellIndex);

                    cell.style.backgroundColor = "green";
                    cell.style.color = "rgb(0, 0, 0)";

                    getDayOfWeekName(daysDate);
                    cell.childNodes[0].textContent = dayOfWeekName;

                } else {
                    cell.style.backgroundColor = "white";
                    cell.style.color = "rgb(0, 0, 0)";
                    cell.childNodes[0].textContent = "";
                }
            } else {
                cell.style.backgroundColor = "black";
            }
        }
    }
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

function isValidDate(rowIndex, columnIndex) {
    var month = Number(rowIndex) + 1;

    var calendarYear = new Date().getFullYear();
    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + columnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();

    return isValid;
}
function isValidDateMoment(_month, _date) {
    //var month = Number(rowIndex) + 1;

    var calendarYear = new Date().getFullYear();
    var daysDate = calendarYear + "-" + String("00" + _month).slice(-2) + "-" + String("00" + _date).slice(-2);

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
function isWeekendMoment(_month, _day) {
    var calendarYear = new Date().getFullYear();

    //var daysDate = new Date(calendarYear, rowIndex, columnIndex);
    var daysDate = moment({ y: calendarYear, m: _month, d: _day })["_d"];

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

    $("#ddlHolidayCalendarNumber option").each(function () {
        currentNumber.push(this.text);
    });

    maximumNumber = Math.max.apply(Math, currentNumber);
    maximumNumber++;

    $("#txtHolidayCalendarNumber").val(maximumNumber);
    $("#txtHolidayCalendarNumber").focus();
}

//CopyCalendar confirmation
function ConfirmCopyCalendar(message) {
    var boxContent = "<div id=\"overlay\"><div id=\"box_flame\"><div id=\"dialogBox\">  <img src=\"../../Images/FormImages/Stop_100x100.png\" alt=\"Stop\" class=\"stopPic\" height=\"150\" width=\"150\" align=\"middle\"> <br/>" + message + "<br/> <button id=\"btnOk\"  onclick=\"CopyCalendar()\"></button><button id=\"btnNo\"  onclick=\"resetImportantInfoDialogDiv()\"></button><button id=\"btnCancel\"  onclick=\"resetConfirmCopyCalendarDiv()\"></button></div></div></div>";
    document.getElementById("importantInfoDialog").innerHTML = boxContent;
    getLocalizedText("yes");
    $("#btnOk").text(levelCaption);
    getLocalizedText("no");
    $("#btnNo").text(levelCaption);
    getLocalizedText("cancel");
    $("#btnCancel").text(levelCaption);
}

function CopyCalendar() {
    var resultStatus;

    $.ajax({
        type: "POST",
        async: false,
        url: "HolidayCalender.aspx/CopyCalendar",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            resultStatus = result.d;
        }
    });
}

function resetImportantInfoDialogDiv() {
    document.getElementById("importantInfoDialog").innerHTML = "";
}

function BackButtonConfirm(entity) {
    getLocalizedText("saveChangesConfirmation");
    var message = levelCaption;
    var boxContent = "<div id=\"overlayBack\"><div id=\"box_flameBack\"><div id=\"dialogBoxBack\">  " +
        "<img src=\"../../Images/FormImages/stop-save2-02.png\" alt=\"Stop\" class=\"stopPicBack\" height=\"150\" width=\"150\" align=\"middle\"> <br/>" + message + "<br/> " +
        "<button id=\"btnOkBack\"  onclick=\"SaveChanges('" + entity + "')\"></button><button id=\"btnNoBack\"  onclick=\"NoOnBackButton()\"></button>" +
        "<button id=\"btnCancelBack\"  onclick=\"CancelOnBackButton(); return false\"></button></div></div></div>";
    document.getElementById("importantInfoDialog").innerHTML = boxContent;
    getLocalizedText("yes");
    $("#btnOkBack").text(levelCaption);
    getLocalizedText("no");
    $("#btnNoBack").text(levelCaption);
    getLocalizedText("cancel");
    $("#btnCancelBack").text(levelCaption);
}

function SaveChanges(entity) {
    resetImportantInfoDialogDiv();
    $("#hiddenFieldRedirect").attr("value", "1");
    switch (entity) {
        case "HOLIDAY":
            saveHoliday();
            break;

        case "CALENDAR":
            //removeAllHighlighting();
            //setTimeout(function () {

            //}, 1000);
            ApplyHolidayToCalendar(holidays);
            //saveHolidayCalendar();
            setTimeout(function () { window.location.href = "Settings.aspx" }, 1000);
            //window.location.href = "Settings.aspx";
            break;
    }

    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "999");
}

function CancelOnBackButton() {
    resetImportantInfoDialogDiv();
    $("#hiddenFieldDetectChanges").attr("value", "1");

    //window.gridViewHolidayCalendar.PerformCallback(999);
}

function NoOnBackButton() {
    resetImportantInfoDialogDiv();

    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "999");

    document.location.href = "/Content/Settings.aspx";
}

function DeleteButtonConfirm(id, entityToDelete) {
    switch (entityToDelete) {
        case "HOLIDAY":
            getLocalizedText("holidayDeleteWarning");
            break;
        case "CALENDAR":
            getLocalizedText("holidayCalendarDeleteWarning");
            break;
    }

    var message = levelCaption;
    var boxContent = "<div id=\"overlayDelete\"><div id=\"box_flameDelete\"><div id=\"dialogBoxDelete\">  " +
        "<img src=\"../../Images/FormImages/stop-save1-01.png\" alt=\"Stop\" class=\"stopPicDelete\" height=\"150\" width=\"150\" align=\"middle\"> <br/>" + message + "<br/> " +
        "<button id=\"btnOkDelete\"  onclick=\"DeleteConfirmed(" + id + ", '" + entityToDelete + "')\" type=\"button\"></button><button id=\"btnNoDelete\"  onclick=\"CancelOnDeleteButton()\" ></button>" +
        "<button id=\"btnCancelDelete\"  onclick=\"resetImportantInfoDialogDiv()\"></button></div></div></div>";
    document.getElementById("importantInfoDialog").innerHTML = boxContent;
    getLocalizedText("yes");
    $("#btnOkDelete").text(levelCaption);
    getLocalizedText("no");
    $("#btnNoDelete").text(levelCaption);
    getLocalizedText("cancel");
    $("#btnCancelDelete").text(levelCaption);
}

function DeleteConfirmed(id, entityToDelete) {
    switch (entityToDelete) {
        case "HOLIDAY":
            //var state = $("#hiddenFieldMaintainState").attr("value");

            //if (state === "1") {
            //    //return;
            //    showAssigned();
            //} else {
            //    DeleteHoliday(id);
            //    showAll();
            //}
            var buttonStateAssigned = $("#btnAssigned").is(":disabled");
            var buttonStateAll = $("#btnAll").is(":disabled");
            if (buttonStateAssigned === true) {
                deleteConfirm = 1;

                $("#hiddenFieldMaintainState").attr("value", "1");
                RemoveSelectedHoliday()
                showAssignedHolidays();
            }
            else if (buttonStateAll === true) {
                DeleteHoliday(id);
                showAll_Copy();
                $("#hiddenFieldMaintainState").attr("value", "2");
            }
            break;

        case "CALENDAR":
            DeleteHolidayCalendar(id);
            break;
    }
    resetImportantInfoDialogDiv();
    return false;
}

function DeleteHoliday(holidayId, holidaySelection) {
    var data = { holidayId: holidayId, holidaySelection: holidaySelection };

    $.ajax({
        type: "POST",
        async: false,
        url: "HolidayCalender.aspx/DeleteHoliday",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            window.gridViewHoliday.PerformCallback(0);
            //window.gridViewHolidayCalendar.PerformCallback();
            gridViewHolidaysInCalendar.PerformCallback();
            $("#txtHolidayName").val("");
            datePickerHolidayDate.SetDate(null);
            holidayId = 0;
            inCalendarSelectedRow = -1;
        }
    });

}


function DeleteHolidayCalendar(holidayCalendarId) {
    $("#hiddenFieldFormMode").attr("value", "4");
    PageMethods.DeleteHolidayCalendarCustom(holidayCalendarId, onDelete_CallBack)
}
function onDelete_CallBack() {

    ddlHolidayCalendarNumber.PerformCallback("0");
    ddlHolidayCalendarName.PerformCallback("0");
    $('#txtHolidayCalendarNumber').val("0");
    $('#txtHolidayCalendarName').val("keine");
    $('#txtMemo').val("");
    gridViewHolidayCalendar.PerformCallback("0");

}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();

    //0 - None, 1 - Display, 2 - Create, 3 - Edit
    $("#hiddenFieldFormMode").attr("value", "1");
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "HolidayCalender.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function ShowNewHolidayInCalendar(holidays) {
    var calendarType = $("#hiddenFieldCalendarType").attr("value");
    switch (calendarType) {
        case "ASS":
            //$("#hiddenFieldDetectChanges").attr("value", "1");
            $("#hiddenFieldChangeType").attr("value", "CALENDAR");

            //removeAllHighlighting();
            //ApplyHolidayToCalendar(holidays);

            break;

        case "ALL":
            break;
        default:
    }
}
function ApplyHolidayToCalendar(holidaysToApply) {
    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        $("#ddlCalendarYear").focus();

        return;
    }

    for (var holidayGani in holidaysToApply) {
        if (holidaysToApply.hasOwnProperty(holidayGani)) {
            var holiday = holidaysToApply[holidayGani];

            var holidayDate = holiday.HolidayDate;

            var holidayMonth = Number(new Date(holidayDate).getMonth());
            var holidayDay = Number(new Date(holidayDate).getDate());

            //display on calendar
            var calendarRowCells = window.gridViewHolidayCalendar.GetRow(holidayMonth).cells;
            var holidayCell = calendarRowCells[holidayDay];

            holidayCell.childNodes[0].textContent = "FT";
            holidayCell.style.backgroundColor = "#FF0";
            holidayCell.style.color = "rgb(255, 0, 0)";
        }
    }

    var jsonArray = [];

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        if (window.gridViewHolidayCalendar.GetRow === undefined) {
            return;
        }

        var currentRowCells = window.gridViewHolidayCalendar.GetRow(rowNumber).cells;

        jsonArray.push({
            Id: rowNumber + 1,
            Day1Holiday: currentRowCells[1].childNodes[0].textContent,
            Day2Holiday: currentRowCells[2].childNodes[0].textContent,
            Day3Holiday: currentRowCells[3].childNodes[0].textContent,
            Day4Holiday: currentRowCells[4].childNodes[0].textContent,
            Day5Holiday: currentRowCells[5].childNodes[0].textContent,
            Day6Holiday: currentRowCells[6].childNodes[0].textContent,
            Day7Holiday: currentRowCells[7].childNodes[0].textContent,
            Day8Holiday: currentRowCells[8].childNodes[0].textContent,
            Day9Holiday: currentRowCells[9].childNodes[0].textContent,
            Day10Holiday: currentRowCells[10].childNodes[0].textContent,
            Day11Holiday: currentRowCells[11].childNodes[0].textContent,
            Day12Holiday: currentRowCells[12].childNodes[0].textContent,
            Day13Holiday: currentRowCells[13].childNodes[0].textContent,
            Day14Holiday: currentRowCells[14].childNodes[0].textContent,
            Day15Holiday: currentRowCells[15].childNodes[0].textContent,
            Day16Holiday: currentRowCells[16].childNodes[0].textContent,
            Day17Holiday: currentRowCells[17].childNodes[0].textContent,
            Day18Holiday: currentRowCells[18].childNodes[0].textContent,
            Day19Holiday: currentRowCells[19].childNodes[0].textContent,
            Day20Holiday: currentRowCells[20].childNodes[0].textContent,
            Day21Holiday: currentRowCells[21].childNodes[0].textContent,
            Day22Holiday: currentRowCells[22].childNodes[0].textContent,
            Day23Holiday: currentRowCells[23].childNodes[0].textContent,
            Day24Holiday: currentRowCells[24].childNodes[0].textContent,
            Day25Holiday: currentRowCells[25].childNodes[0].textContent,
            Day26Holiday: currentRowCells[26].childNodes[0].textContent,
            Day27Holiday: currentRowCells[27].childNodes[0].textContent,
            Day28Holiday: currentRowCells[28].childNodes[0].textContent,
            Day29Holiday: currentRowCells[29].childNodes[0].textContent,
            Day30Holiday: currentRowCells[30].childNodes[0].textContent,
            Day31Holiday: currentRowCells[31].childNodes[0].textContent
        });
    }
    //if (hasEdit == true) {
    //    $("#btnCalenderSave").removeAttr("disabled");
    //}
    var jsonString = JSON.stringify(jsonArray);
    var data = { jsonData: jsonString, calendarYear: calendarYear, holidays: holidays };

    $.ajax({
        type: "POST",
        url: "HolidayCalender.aspx/UpdateHolidayCalenderSchedule",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            saveHolidayCalendar();
        }
    });
    //PageMethods.UpdateHolidayCalenderSchedule(jsonString,calendarYear,holidays, OnBackSave_Callback)
}
function OnBackSave_Callback() {
    saveHolidayCalendar();
}
function ApplyHolidayToCalendarCustom(holidaysToApply) {
    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        $("#ddlCalendarYear").focus();

        return;
    }

    for (var holidayGani in holidaysToApply) {
        if (holidaysToApply.hasOwnProperty(holidayGani)) {
            var holiday = holidaysToApply[holidayGani];

            var holidayDate = holiday.HolidayDate;

            var holidayMonth = Number(new Date(holidayDate).getMonth());
            var holidayDay = Number(new Date(holidayDate).getDate());

            //display on calendar
            var calendarRowCells = window.gridViewHolidayCalendar.GetRow(holidayMonth).cells;
            var holidayCell = calendarRowCells[holidayDay];

            holidayCell.childNodes[0].textContent = "FT";
            holidayCell.style.backgroundColor = "#FF0";
            holidayCell.style.color = "rgb(255, 0, 0)";
        }
    }

    var jsonArray = [];

    for (var rowNumber = 0; rowNumber <= 11; rowNumber++) {
        if (window.gridViewHolidayCalendar.GetRow === undefined) {
            return;
        }

        var currentRowCells = window.gridViewHolidayCalendar.GetRow(rowNumber).cells;

        jsonArray.push({
            Id: rowNumber + 1,
            Day1Holiday: currentRowCells[1].childNodes[0].textContent,
            Day2Holiday: currentRowCells[2].childNodes[0].textContent,
            Day3Holiday: currentRowCells[3].childNodes[0].textContent,
            Day4Holiday: currentRowCells[4].childNodes[0].textContent,
            Day5Holiday: currentRowCells[5].childNodes[0].textContent,
            Day6Holiday: currentRowCells[6].childNodes[0].textContent,
            Day7Holiday: currentRowCells[7].childNodes[0].textContent,
            Day8Holiday: currentRowCells[8].childNodes[0].textContent,
            Day9Holiday: currentRowCells[9].childNodes[0].textContent,
            Day10Holiday: currentRowCells[10].childNodes[0].textContent,
            Day11Holiday: currentRowCells[11].childNodes[0].textContent,
            Day12Holiday: currentRowCells[12].childNodes[0].textContent,
            Day13Holiday: currentRowCells[13].childNodes[0].textContent,
            Day14Holiday: currentRowCells[14].childNodes[0].textContent,
            Day15Holiday: currentRowCells[15].childNodes[0].textContent,
            Day16Holiday: currentRowCells[16].childNodes[0].textContent,
            Day17Holiday: currentRowCells[17].childNodes[0].textContent,
            Day18Holiday: currentRowCells[18].childNodes[0].textContent,
            Day19Holiday: currentRowCells[19].childNodes[0].textContent,
            Day20Holiday: currentRowCells[20].childNodes[0].textContent,
            Day21Holiday: currentRowCells[21].childNodes[0].textContent,
            Day22Holiday: currentRowCells[22].childNodes[0].textContent,
            Day23Holiday: currentRowCells[23].childNodes[0].textContent,
            Day24Holiday: currentRowCells[24].childNodes[0].textContent,
            Day25Holiday: currentRowCells[25].childNodes[0].textContent,
            Day26Holiday: currentRowCells[26].childNodes[0].textContent,
            Day27Holiday: currentRowCells[27].childNodes[0].textContent,
            Day28Holiday: currentRowCells[28].childNodes[0].textContent,
            Day29Holiday: currentRowCells[29].childNodes[0].textContent,
            Day30Holiday: currentRowCells[30].childNodes[0].textContent,
            Day31Holiday: currentRowCells[31].childNodes[0].textContent
        });
    }
    //if (hasEdit == true) {
    //    $("#btnCalenderSave").removeAttr("disabled");
    //}
    var jsonString = JSON.stringify(jsonArray);
    PageMethods.UpdateHolidayCalenderSchedule(jsonString, calendarYear, holidays, OnUpdateHolidayCalenderSchedule_CallBack);
}
function OnUpdateHolidayCalenderSchedule_CallBack() {
    //var data = "-1";
    //gridViewHolidayCalendar.PerformCallback(data);
}
function clearHoliday(selectedDate) {
    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    if (calendarYear === 0) {
        $("#ddlCalendarYear").focus();

        return;
    }
    var holidayDate = Date.parse(moment(selectedDate, "DD.MM.YYYY")["_d"]);

    var _Month = parseInt(moment(selectedDate, "DD.MM.YYYY").format("MM"));
    //var holidayDay = parseInt(moment(selectedDate, "DD.MM.YYYY").format("DD"));
    var holidayMonth = Number(new Date(holidayDate).getMonth());
    var holidayDay = Number(new Date(holidayDate).getDate());

    //display on calendar
    var calendarRowCells = window.gridViewHolidayCalendar.GetRow(holidayMonth).cells;
    var holidayCell = calendarRowCells[holidayDay];

    //holidayCell.childNodes[0].textContent = "FT";
    //holidayCell.style.backgroundColor = "#FF0";
    //holidayCell.style.color = "rgb(255, 0, 0)";

    if (isValidDateMoment(_Month, holidayDay)) {
        if (isWeekendMoment(_Month, holidayDay)) {
            //var daysDate = new Date(calendarYear, holidayMonth, holidayDay);

            var daysDate = moment({ y: calendarYear, m: _Month, d: holidayDay })["_d"];

            holidayCell.style.backgroundColor = "green";
            holidayCell.style.color = "rgb(0, 0, 0)";

            getDayOfWeekName(daysDate);
            holidayCell.childNodes[0].textContent = dayOfWeekName;

        } else {
            holidayCell.style.backgroundColor = "white";
            holidayCell.style.color = "rgb(0, 0, 0)";
            holidayCell.childNodes[0].textContent = "";
        }
    } else {
        holidayCell.style.backgroundColor = "black";
    }
}
function showAssignedHolidays() {
    $(".gridSectionTop").show();
    $(".sectionAll").hide();
    if (allowZUTEdit) $("#btnAll").removeAttr("disabled", "disabled");
    $("#btnAssigned").attr("disabled", "disabled");
    $("#btnAssigned").css("background-color", "#ffe7a2");
    $("#btnAll").css("background-color", "");

    $("#hiddenFieldCalendarType").attr("value", "ASS");
}
function removeAssignedHoliday() {
    var _holidayDate = gridViewHolidaysInCalendar.GetRow(inCalendarSelectedRow).cells[1].childNodes[0].textContent.trim();
    clearHoliday(_holidayDate);
    showAssignedHolidays();
}
function removeAssignedHolidayCustom() {
    var _holidayDate = gridViewHolidaysInCalendar.GetRow(inCalendarSelectedRow).cells[1].childNodes[0].textContent.trim();
    if (_holidayDate !== undefined || _holidayDate !== null || _holidayDate !== "") {
        clearHoliday(_holidayDate);
    }


}
function RemoveSelectedHoliday() {
    //$("#hiddenFieldDetectChanges").attr("value", "1");
    selectedIndex = inCalendarSelectedRow;
    window.gridViewHolidaysInCalendar.UnselectRowOnPage(selectedIndex);
    DeleteAssignedHoliday();
    //window.gridViewHolidaysInCalendar.GetSelectedFieldValues("Id;HolidayDate", GetSelectedHolidaysInCalendarDelete);
}
function saveHolidayCalendar() {
    var formMode = 0;
    //var holidayCalendarNr = parseInt($("#ddlHolidayCalendarNumber option:selected").val());
    var holidayCalendarNr = parseInt(ddlHolidayCalendarNumber.GetValue());
    if (holidayCalendarNr === 0) {
        formMode = 2
    }
    else if (holidayCalendarNr > 0) {
        formMode = 3
    }
    var holidayCalendarNumber = $("#txtHolidayCalendarNumber").val().trim();
    var holidayCalendarName = $("#txtHolidayCalendarName").val().trim();
    var calendarYear = window.ddlCalendarYear2.GetSelectedItem().value;
    var memo = $("#txtMemo").val().trim();
    var data = { formMode: formMode, holidayCalendarNumber: holidayCalendarNumber, holidayCalendarName: holidayCalendarName, calendarYear: calendarYear, memo: memo };
    $.ajax({
        type: "POST",
        url: "HolidayCalender.aspx/SaveHolidayCalendar",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
        }
    });

    //PageMethods.SaveHolidayCalendar(formMode, holidayCalendarNumber, holidayCalendarName, calendarYear, memo);
}

function GetSelectedHolidaysInCalendarDelete(values) {
    for (var i = 0; i < values.length; i++) {
        var id = values[i][0];
        var holidayDate = values[i][1];

        holidays.push({
            Id: id,
            HolidayDate: holidayDate
        });

        holidaysInCalendar.push({
            Id: id,
            HolidayDate: holidayDate
        });
    }
    $("#hiddenFieldRedirect").attr("value", "0");
    var _trH = holidays;
    //removeAllHighlighting();
    removeAssignedHolidayCustom();
    ApplyHolidayToCalendar(holidays);
    //saveHolidayCalendar();
    gridViewHolidaysInCalendar.PerformCallback();
    window.gridViewHoliday.PerformCallback(0);
}
function getGetInCalendarSelectedValues() {

}

function showAll_Copy() {
    $(".gridSectionTop").hide();
    $(".sectionAll").show();
    $("#btnAll").attr("disabled", "disabled");
    if (allowZUTEdit) $("#btnAssigned").removeAttr("disabled", "disabled");
    $("#btnAll").css("background-color", "#ffe7a2");
    $("#btnAssigned").css("background-color", "");

    $("#hiddenFieldCalendarType").attr("value", "ALL");
}
function ResetGrid() {
    var data = "-1";
    gridViewHolidayCalendar.PerformCallback(data);
}
function delayFunction() {

}
function resetSaveField() {
    $("#hiddenFieldDetectChanges").attr("value", "0");
}


function downloadHolidaysAndSaveInDatabase() {
    var regiodID = $("#drpCountry").val();
    var selectedYear = $("#ddlYear_I").val();

    PageMethods.DownloadHolidaysAndSaveInDatabase(regiodID, selectedYear, doTaskAfterDownloadHolidays);
}

function doTaskAfterDownloadHolidays() {
    gridViewHoliday.PerformCallback();
}
function CalendarNumberSelectionChanged(s, e) {
    if (isCobClick === true) {
        isCobClick = false;
        $("#hiddenFieldCalendarType").attr("value", "ASS");
        ddlHolidayCalendarName.SetValue(s.GetValue());
        $("#txtHolidayCalendarNumber").val(s.GetText());
        $("#txtHolidayCalendarName").val(ddlHolidayCalendarName.GetText());
        PageMethods.GetCalendarById(s.GetValue(), GetHolidayByID_CallBack);
        showAssignedHolidays();
    }
}
function CalendarNameSelectionChanged(s, e) {
    if (isCobClick === true) {
        isCobClick = false;
        $("#hiddenFieldCalendarType").attr("value", "ASS");
        ddlHolidayCalendarNumber.SetValue(s.GetValue());
        $("#txtHolidayCalendarNumber").val(ddlHolidayCalendarNumber.GetText());
        $("#txtHolidayCalendarName").val(s.GetText());
        PageMethods.GetCalendarById(s.GetValue(), GetHolidayByID_CallBack);
        showAssignedHolidays();
    }
}
function isDropDownClick(s, e) {
    isCobClick = true;
}
function showAssignedHolidays() {
    $(".gridSectionTop").show();
    $(".sectionAll").hide();
    if (allowZUTEdit) $("#btnAll").removeAttr("disabled", "disabled");
    $("#btnAssigned").attr("disabled", "disabled");
    if (allowZUTEdit) $("#btnHolidayDelete").removeAttr("disabled", "disabled");
    $("#btnAssigned").css("background-color", "#ffe7a2");
    $("#btnAll").css("background-color", "");
    $("#hiddenFieldCalendarType").attr("value", "ASS");
}
function SetControlsOnNew(number) {
    ddlHolidayCalendarNumber.SetValue("0");
    ddlHolidayCalendarName.SetValue("0");
    ddlHolidayCalendarNumber.SetEnabled(false);
    ddlHolidayCalendarName.SetEnabled(false);
    ddlCalendarYear2Old.SetEnabled(true);
    $("#txtHolidayCalendarNumber").val(number);
    $("#txtHolidayCalendarName").val("");
    $("#txtHolidayCalendarName").focus();
    gridViewHolidayCalendar.PerformCallback("0");
    ResetHolidays();
}
function SetControlsOnNew_CallBack(number) {
    SetControlsOnNew(number);
}
function SaveCurrentHolidayCalendar() {
    var calendarId = ddlHolidayCalendarNumber.GetValue();
    var calendarNumber = $("#txtHolidayCalendarNumber").val();
    var calendarName = $("#txtHolidayCalendarName").val();
    var memo = $("#txtMemo").val();
    var calendarYear = ddlCalendarYear2Old.GetValue();
    if (parseInt(calendarNumber) > 0) {
        PageMethods.SaveHolidayCalendarCustom(calendarId, calendarNumber, calendarName, calendarYear, memo, SaveHolidayCalendarCustom_CallBack);
    }
    else {
        alert("Bitte wählen Sie das Feiertagskalender Nr.");
        return;
    }

}

function SaveHolidayCalendarCustom_CallBack(id) {
    ddlHolidayCalendarNumber.SetEnabled(true);
    ddlHolidayCalendarName.SetEnabled(true);
    ddlCalendarYear2Old.SetEnabled(false);
    ddlHolidayCalendarNumber.PerformCallback(id);
    ddlHolidayCalendarName.PerformCallback(id);
    gridViewHolidayCalendarSerch.PerformCallback();
    gridViewHolidayCalendar.PerformCallback(id);
    showAssignedHolidays();
    $("#hiddenFieldDetectChanges").attr("value", "0");
}
function ddlRegionIDSelectionChanged(s, e) {
    gridViewHoliday.PerformCallback();
    showAll_Copy();
}
function gridViewHolidayCalendarEndCallBack(s, e) {
    gridViewHolidaysInCalendar.PerformCallback();
    gridViewHoliday.PerformCallback();

}
function calendarSearchRowDbClick(s, e) {
    var id = s.GetRowKey(e.visibleIndex);
    ddlHolidayCalendarNumber.SetValue(id);
    ddlHolidayCalendarName.SetValue(id);
    $("#txtHolidayCalendarNumber").val(ddlHolidayCalendarNumber.GetText());
    $("#txtHolidayCalendarName").val(ddlHolidayCalendarName.GetText());
    $(".contentdivbottomsearch").hide();
    $(".contentdivbottom").show();
    $("#btnCalendarSave").show();
    $("#btnCalendarNew").show();
    $("#btnCalendarDelete").show();
    $("#btnCopyCalendar").show();
    showAssignedHolidays();
    backValue = 0;
    PageMethods.GetCalendarById(id, GetHolidayByID_CallBack);
}
function GetHolidayByID_CallBack(result) {
    $("#txtMemo").val(result.memo);
    ddlCalendarYear2Old.SetValue(result.CalendarYear);
    ddlCalendarYear2.SetValue(result.CalendarYear);
    gridViewHolidayCalendar.PerformCallback(result.ID);
}
function HIdeDownloadDialog() {
    $("#MasterPage").css("display", "none");
    $("#internetWrapper").css("display", "none");
}
//delete dialog
function ConfirmDeleteHolidayCalendar() {
    getLocalizedText("deleteHolidayCalendarConfirm");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Personaleinsatzplanung</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnNo"  onclick="ResetDialog(); return false;" style="position: relative;  margin-right: 0px;   margin-left: 20%;  color: #005d81 !important; width: 184px;"></button><button id="btnOk"  style=" margin-left: 0%;  margin-right: 0px; width: 170px;"  onclick="DeleteCalendar()"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("permitHolidayCalendarDelete");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelHolidayCalendarDelete");
    $('#btnNo').text(levelCaption);
}
function DeleteCalendar() {
    ResetDialog();
    var id = ddlHolidayCalendarNumber.GetValue();
    DeleteHolidayCalendar(id);
}
function ResetDialog() {
    document.getElementById("importantInfoDialog").innerHTML = "";
}
function No_OnBack() {
    ResetDialog();
    document.location.href = "/Content/Settings.aspx";
}

function ConfirmDeleteHoliday() {
    getLocalizedText("deleteHolidayMessage");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Personaleinsatzplanung</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnNo"  onclick="ResetDialog(); return false;" style="position: relative;  margin-right: 0px;   margin-left: 40%;  color: #005d81 !important; width: 165px;"></button><button id="btnOk"  style=" margin-left: 0%;  margin-right: 0px; width: 105px;"  onclick="DeleteHolidayConfirmed()"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteHoliday");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelDeleteHoliday");
    $('#btnNo').text(levelCaption);
}
function DeleteHolidayConfirmed() {
    ResetDialog();
    var holidaySelection = ddlRegionID.GetValue();
    var buttonStateAssigned = $("#btnAssigned").is(":disabled");
    var buttonStateAll = $("#btnAll").is(":disabled");
    if (buttonStateAssigned === true) {
        deleteConfirm = 1;

        $("#hiddenFieldMaintainState").attr("value", "1");
        RemoveSelectedHoliday()
        showAssignedHolidays();
    }
    else if (buttonStateAll === true) {
        DeleteHoliday(holidayId, holidaySelection);
        showAll_Copy();
        $("#hiddenFieldMaintainState").attr("value", "2");
    }
}
// end delete dialog
//back dialog
function ConfirmSaveChanges() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"> <div id="box_flame"> <div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Personaleinsatzplanung</label><button id="promptbtnclose" onclick="ResetDialog()" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + ' </div><button id="btnOk" style="margin-left:34%; color:forestgreen !important; width:123px;"  onclick="SaveChangesOnBack()">  </button><button id="btnNo" style="width:160px;" onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("savePromptchanges");
    $('#btnOk').text(levelCaption);
    getLocalizedText("dontsavePrompt");
    $('#btnNo').text(levelCaption);

}
function SaveChangesOnBack() {
    ResetDialog();
    var entity = $("#hiddenFieldChangeType").attr("value");
    $("#hiddenFieldRedirect").attr("value", "1");
    switch (entity) {
        case "HOLIDAY":
            saveHoliday();
            break;

        case "CALENDAR":

            ApplyHolidayToCalendar(holidays);
            //saveHolidayCalendar();
            setTimeout(function () { window.location.href = "Settings.aspx" }, 1000);
            //window.location.href = "Settings.aspx";
            break;
    }

    //exit on postback
    $("#hiddenFieldDetectChanges").attr("value", "999");
}
//end back dialog

function GetSelectedHolidaysCustom() {
    var values = [];
    values = gridViewHoliday.GetSelectedKeysOnPage();
    for (var i = 0; i < values.length; i++) {
        var index = gridViewHoliday.keys.indexOf(values[i]);
        //gridViewHoliday.GetRowValues(index, "Id;HolidayDate", OngrdHolidayRowValues);
        var id = values[i]
        var holidayDate = moment(gridViewHoliday.GetRow(index).cells[1].childNodes[0].textContent, "DD.MM.YYYY").toDate();
        holidays.push({
            Id: id,
            HolidayDate: holidayDate
        });
    }
    ApplyHolidayToCalendarCustom(holidays);
}
function DeleteAssignedHoliday() {

    $("#hiddenFieldRedirect").attr("value", "0");
    var _trH = holidays;
    //removeAllHighlighting();
    removeAssignedHolidayCustom();
    GetAssignedHolidaysCustom();
    //ApplyHolidayToCalendar(holidays);
    //saveHolidayCalendar();
    gridViewHolidaysInCalendar.PerformCallback();
    window.gridViewHoliday.PerformCallback(0);
    inCalendarSelectedRow = -1;
    holidayId = 0;
}
function GetAssignedHolidaysCustom() {
    var values = [];
    values = gridViewHolidaysInCalendar.GetSelectedKeysOnPage();
    for (var i = 0; i < values.length; i++) {
        var index = gridViewHolidaysInCalendar.keys.indexOf(values[i]);
        //gridViewHoliday.GetRowValues(index, "Id;HolidayDate", OngrdHolidayRowValues);
        var id = values[i]
        var holidayDate = moment(gridViewHolidaysInCalendar.GetRow(index).cells[1].childNodes[0].textContent, "DD.MM.YYYY").toDate();
        holidays.push({
            Id: id,
            HolidayDate: holidayDate
        });
    }
    ApplyHolidayToCalendarCustom(holidays);
}

function CalendarYearSelectionChanged(s, e) {
    ddlCalendarYear2.SetValue(s.GetValue());
}