
var levelCaption = 0;
var SaveExitChanges = false;
var ConfirmDelete = false;

$(document).ready(function () {
    //$('#saveChangesonNew').val('0');
    $(document).on("selectstart", false);
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    //getLocalizedText("permitMandantenDeletion");
    //  $('#btnWarningPromptOk').val(message);

    //getLocalizedText("cancelMandantenDeletion");
    //  $('#btnWarningPromptNo').val(message);

    if ($('#saveChangesonNew').val() == 1) {
        SaveExitChanges = true;
        levelCaption = 2;
    }

    $('#btnWarningPromptOk').val("Standort löschen");
    $('#btnWarningPromptNo').val("Standort nicht löschen");

    $('#lblDeleteText').text("Sind Sie sicher das Sie das Standort tatsächlich löschen wollen? ");

    $('#btnWarningPromptOk').css({
        "margin-left": "37%",
    });

    $('#btnWarningPromptNo').css({
        "width": "155px",
    });


    $("#imgCalenderGrid").click(function (evt) {
        evt.preventDefault();
        showHolidays();
        levelCaption = 1;
    });

    $("#btnDelete").click(function (evt) {
        if (!ConfirmDelete) {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptWarning(pEvt);
        }
    });

    $("#btnBack").click(function (evt) {
        evt.preventDefault();

        //if (levelCaption === 2 && !allowZUTEdit) levelCaption = 0;

        if (levelCaption === 0 || (!allowZUTEdit && levelCaption != 1)) {
            document.location.href = "/Content/Settings.aspx";
        }
        else if (levelCaption === 1) {
            $(".secLeftMid2").show();
            $(".secCalendar").hide();
            $(".FooterFloatLeft").show();
            $("#ddlocation").prop("disabled", false);
            $("#ddlocno").prop("disabled", false);
            levelCaption = 0;
        }
        else if (levelCaption === 2 || ($('#saveChangesonNew').val()) === '1') {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptSave(pEvt, "#btnSave", "click");
            levelCaption = 0;
        }
    });

    $("#btnNew").click(function (evt) {
        $("#btnDelete").prop('disabled', true);
        levelCaption = 2;
    });

    $("#txtMemo").change(function (evt) {
        levelCaption = 2;
    });

    $("#txtlocno1").change(function (evt) {
        SaveExitChanges = true;

    });
    $("#ddlState").change(function (evt) {
        levelCaption = 2;
    });

    $("#ddlHolidayCalendar").change(function (evt) {
        levelCaption = 2;
    });

    $("input").change(function (evt) {
        SaveExitChanges = true;

        if (allowZUTEdit) $("#btnSave").removeAttr("disabled", "disabled");
        levelCaption = 2;
    });
})

function GetHolidayCalendar_Callback(response) {
    if (response.HolidayCalendarNumber === 0) {
        $('#txtHolidayCalendarNumber').val("");
    }
    else {
        $('#txtHolidayCalendarNumber').val(response.HolidayCalendarNumber);
    }
    $('#txtHolidayCalendarName').val(response.HolidayCalendarName);
}

function grdLocRowClick(s, e) {

    var _grdLoc = ASPxClientGridView.Cast(s);
    var grdLoc = s.GetRow(e.visibleIndex);
    var locnum = s.GetRowKey(e.visibleIndex);
    var locname = grdLoc.cells[1].textContent;
    var locstate = grdLoc.cells[2].textContent;
    var locstr = grdLoc.cells[3].textContent;




    PageMethods.populatecontrols(locnum, populateLowerControls);
}
function cbolocnSelectedIndexChanged(value) {


    SetValues(value);
}
function cbolocationSelectedIndexChanged(value) {


    SetValues(value);
}
function SetValues(value) {

    PageMethods.populatecontrols(value, populateLowerControls);
}
function populateLowerControls(response) {
    if (response != null) {
        cbolocno.SetValue(response.ID.toString());
        cbolocation.SetValue(response.ID.toString());

        $("#txtlocno1").val(response.Location_Nr);
        $("#txtName").val(response.LocationHeadName);
        $("#txtloc").val(response.Name);
        $("#txtStreet").val(response.Street);
        $("#txtOrt").val(response.Place);
        $("#txtPLZ").val(response.ZipCode);
        $("#txtMob").val(response.LocationHeadMobile);
        $("#txthseNumber").val(response.HouseNumber);
        $("#txtFunct").val(response.LocationHeadFunction);
        $("#txtTel").val(response.LocationHeadPhone);
        $("#txtEmail").val(response.LocationHeadEmail);
        $("#txtMemo").val(response.InfoText);

        if (response.State != null) { cboState.SetValue(response.State.toString()); } else { cboState.SetValue("Keine") }
        if (response.HolidayCalendarId != null) { ddlHolidayCalendar.SetValue(response.HolidayCalendarId.toString()); } else { ddlHolidayCalendar.SetValue("Keine") }

    } else {
        $("#txtlocno1").val("");
        $("#txtName").val("");
        $("#txtloc").val("");
        $("#txtStreet").val("");
        $("#txtOrt").val("");
        $("#txtPLZ").val("");
        $("#txtMob").val("");
        $("#txthseNumber").val("");
        $("#txtFunct").val("");
        $("#txtTel").val("");
        $("#txtEmail").val("");
        $("#txtMemo").val("");
    }

}

function showHolidays() {
    $(".secLeftMid2").hide();
    $(".secCalendar").show();

    $(".FooterFloatLeft").hide();

    $('#txtHolidayCalendarNumber').prop("disabled", "disabled");
    $('#txtHolidayCalendarName').prop("disabled", "disabled");

    window.gridViewHolidayCalendar.PerformCallback();
}


function __askToSaveBeforeLeaving(trigger, preventedEvent, triggerCtrlSelector, triggerEventName) {
    if (trigger) {
        __hidePromptSave();
        PageMethods.SetPromptRedirectPage("/Content/Settings.aspx", function () { $(triggerCtrlSelector).trigger(triggerEventName); });

        //document.location.href = "/Content/Settings.aspx";
    }
    else {
        __hidePromptSave();
        $(preventedEvent.target).trigger(preventedEvent);
    }
}

function __promptSave(preventedEvent, triggerCtrlSelector, triggerEventName) {
    $("#promptsPlaceHolder, #__SavePrompt").show();
    $("#btnSavePromptOk, #btnSavePromptNo, #btnSavePromptCancel").unbind("click");

    $("#btnSavePromptOk").click(function (ev) { 
        ev.preventDefault();
        __askToSaveBeforeLeaving(true, preventedEvent, triggerCtrlSelector, triggerEventName);
        levelCaption = 0;
    });
    $("#btnSavePromptNo").click(function (ev) {
        ev.preventDefault(); SaveExitChanges = false;
        // levelCaption = 0;
        __askToSaveBeforeLeaving(false, preventedEvent, "", "");
    });
    $("#btnSavePromptCancel").click(function (ev) {
        levelCaption === 2;
        ev.preventDefault(); __hidePromptSave();
    });
}

function __hidePromptSave() {
    $("#promptsPlaceHolder, #__SavePrompt").hide();
}


//delete warning confirmation
function __warnBeforeDeleting(continueEvent, preventedEvent) {
    if (continueEvent) {
        __hidePromptWarning();
        ConfirmDelete = true;
        $(preventedEvent.target).trigger(preventedEvent);
    }
}

function __promptWarning(preventedEvent) {
    $("#promptsPlaceHolder, #__WarningPrompt").show();
    $("#btnWarningPromptOk, #btnWarningPromptNo, #btnWarningPromptCancel").unbind("click");

    $("#btnWarningPromptOk").click(function (ev) {
        ev.preventDefault(); __warnBeforeDeleting(true, preventedEvent);
    });
    $("#btnWarningPromptNo").click(function (ev) {
        ev.preventDefault(); __hidePromptWarning();
    });
    $("#btnWarningPromptCancel").click(function (ev) {
        ev.preventDefault(); __hidePromptWarning();
    });
}

function __hidePromptWarning() {
    $("#promptsPlaceHolder, #__WarningPrompt").hide();
}
function gridViewHolidayCalendarEndCallback(s, e) {
    window.PageMethods.GetHolidayCalendar(GetHolidayCalendar_Callback);
}