
var levelCaption = 0;
$(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (levelCaption == 0) {
            document.location.href = "/Index.aspx";
        }
        else if (levelCaption == 1) {
            $('#MainContdiv').show();
            $('#searchpersonnel').hide();
            $('#searchcarsection').hide();
            levelCaption = 0;
        }
        else if (levelCaption == 2) {
            $('#MainContdiv').show();
            $('#searchpersonnel').hide();
            $('.searchVisitors').hide();
            levelCaption = 0;
        }
        else if (levelCaption == 3) {
            $('#MainContdiv').show();
            $('#searchpersonnel').hide();
            $('.searchclint').hide();
            levelCaption = 0;
        }
    });
    $('#btnApply').click(function (e) {
        e.preventDefault();
        var index = grdVisitors.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var visitorID = grdVisitors.GetRowKey(index);
            if (parseInt(visitorID) > 0) {
                document.location.href = "/Content/Visitors.aspx?visitorNr=" + visitorID;
            }
        }
       
    });
    $('#btnSearchPersonnal').click(function (e) {
        e.preventDefault();
        $('#MainContdiv').hide();
        //$('.secgrid').show();
        $('#searchpersonnel').show();
    });
    $("#btnClint").click(function (evt) {
        evt.preventDefault();
        $('#MainContdiv').hide();
        $('#searchpersonnel').hide();
        $('.searchclint').show();
        levelCaption = 3;

    });
    $("#btnSearchVisitors").click(function (evt) {
        evt.preventDefault();
        $('#MainContdiv').hide();
        $('#searchpersonnel').hide();
        $('.searchVisitors').show();
        levelCaption = 2;
    });
    $('#btnCarType').click(function (e) {
        e.preventDefault();
        $('#MainContdiv').hide();
        $('#searchpersonnel').hide();
        $('#searchcarsection').show();
        displaycartype();
        levelCaption = 1;
    });
    $('#btnCancelDel').click(function (e) {
        if (!ConfirmDelete) {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptWarning(pEvt);
        }

    });

    $("#btnTakeWebcamPicture").click(function (evt) {
        evt.preventDefault();
        WebcamMode();
    });
});
function WebcamMode() {
    $(".secwrapperright").hide();
    $(".webCamMode").show();

}
function displaycartype() {
    $('#MainContdiv').hide();
    $('#searchpersonnel').hide();
    $('#searchcarsection').show();

}
function grdcartypeClick(s, e) {
    window.grdCarSearch.GetRowValues(e.visibleIndex, "ID;Name;Type", searchCartypeRowValues1)

    $('#MainContdiv').show();
    $('#searchpersonnel').show();
    $('#searchcarsection').hide();
}
function searchCartypeRowValues1(values) {
    var CarID = values[0].toString();
    var carName = values[1].toString();
    var carType = values[2].toString();

    $("#txtVehicleModel").val(String.format('{0}-{1}', Name, Type));
}
//$(document).ready(function () {
//    $(".InfoHeaderFloatRight").show();
//    $(".InfoHeaderFloatRightnew").hide();
//})
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
function __warnBeforeDeleting(continueEvent, preventedEvent) {
    if (continueEvent) {
        __hidePromptWarning();
        ConfirmDelete = true;
        $('#hiddenFieldVisitorId').val($('#txtVisitorID').val());
        $(preventedEvent.target).trigger(preventedEvent);

    }
}
function grdVisitorsRowDbClick(s, e) {
    var visitorID = grdVisitors.GetRowKey(e.visibleIndex);
    document.location.href = "/Content/Visitors.aspx?visitorNr=" + visitorID;
}