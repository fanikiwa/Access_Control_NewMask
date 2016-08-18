var suppressReadPairEv = false;
var suppressEditPairEv = false;
var __hasChanges = false;
var __allowDel = false;

$(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    $("#btnSearch").click(function (evt) {
        evt.preventDefault();
        $(".grdSec").show();
        $(".tableSec, #btnDel, #btnNew, #btnSave").hide();

        $("#btnBack").unbind("click");
        $("#btnBack").bind("click", function (ev) {
            ev.preventDefault();
            $(".grdSec").hide();
            $(".tableSec, #btnDel, #btnNew, #btnSave").show();
            $("#btnBack").unbind("click");
        });
    });

    $("#btnDel").click(function (evt) {
        if (!__allowDel) {
            var pEvt = $.extend(true, {}, evt);
            //evt.preventDefault();
            //__promptWarning(pEvt);
        }
    });

    $("#chkTMKRead").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }
        if (allChecked) { checkTmkEdit(!allChecked); }
    });

    $("#chkTMKEdit").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }
        if (allChecked) { checkTmkRead(!allChecked); }
    });

    $("#chkZUTRead").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }

        $.each($(".zutChkRead"), function () {
            this.childNodes[0].checked = allChecked;
        });

        //this.checked = allChecked;
        if (allChecked) { checkZutEdit(!allChecked); }
    });

    $("#chkZUTEdit").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }

        $.each($(".zutChkEdit"), function () {
            this.childNodes[0].checked = allChecked;
        });

        //this.checked = allChecked;
        if (allChecked) { checkZutRead(!allChecked); }
    });

    $(".zutChkRead > input").change(function () {
        if (!this.checked) {
            $("#chkZUTRead")[0].checked = false;
        } else {
            checkParentControl("#chkZUTRead", ".zutChkRead");
        }

        suppressEditPairEv = true;
        checkForReadPairs(this);
        suppressEditPairEv = false;
    });

    $(".zutChkEdit > input").change(function () {
        if (!this.checked) {
            $("#chkZUTEdit")[0].checked = false;
        } else {
            checkParentControl("#chkZUTEdit", ".zutChkEdit");
        }

        suppressReadPairEv = true;
        checkForEditPairs(this);
        suppressReadPairEv = false;
    });

    /*Settings -> Einstellingen*/
    $("#chkSettingsRead").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }

        $.each($(".zutSettingsRead"), function () {
            this.childNodes[0].checked = allChecked;
        });

        checkSettingsReadParents();
    });

    $("#chkSettingsEdit").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }

        $.each($(".zutSettingsEdit"), function () {
            this.childNodes[0].checked = allChecked;
        });

        checkSettingsEditParents();
    });

    $(".zutSettingsRead > input").change(function () {
        checkSettingsReadParents();
    });

    $(".zutSettingsEdit > input").change(function () {
        checkSettingsEditParents();
    });


    /*Gate Monitor -> Gate Monitor*/
    $("#chkGateMonitorRead").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }

        $.each($(".gateMonitorRead"), function () {
            this.childNodes[0].checked = allChecked;
        });

        checkGateMonitorReadParents();
    });

    $("#chkGateMonitorEdit").change(function () {
        var allChecked = false;
        if (this.checked) { allChecked = true; }

        $.each($(".gateMonitorEdit"), function () {
            this.childNodes[0].checked = allChecked;
        });

        checkGateMonitorEditParents();
    });

    $(".gateMonitorRead > input").change(function () {
        checkGateMonitorReadParents();
    });

    $(".gateMonitorEdit > input").change(function () {
        checkGateMonitorEditParents();
    });

    $("input").change(function (evt) {
        __hasChanges = true;
    });

    $("#btnBack").click(function (evt) {
        if (__hasChanges) {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptSave(pEvt, "#btnSave", "click");
        }
    });

    $("#btnDel").click(function (evt) {
        if (!__allowDel) {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptWarning(pEvt);
        }
    });
});

function checkParentControl(parentCheckId, childrenClass) {
    var allChecked = true;
    $.each($(childrenClass), function () {
        if (!this.childNodes[0].checked) {
            allChecked = false;
        }

        if (!allChecked) {
            $(parentCheckId)[0].checked = false;
            return;
        }
        $(parentCheckId)[0].checked = allChecked;
    });
}

function checkSettingsReadParents() {
    checkParentControl("#chkSettingsRead", ".zutSettingsRead");
    checkParentControl("#chkZUTRead", ".zutChkRead");
}

function checkSettingsEditParents() {
    checkParentControl("#chkSettingsEdit", ".zutSettingsEdit");
    checkParentControl("#chkZUTEdit", ".zutChkEdit");
}

function checkGateMonitorReadParents() {
    checkParentControl("#chkGateMonitorRead", ".gateMonitorRead");
    checkParentControl("#chkZUTRead", ".zutChkRead");
}

function checkGateMonitorEditParents() {
    checkParentControl("#chkGateMonitorEdit", ".gateMonitorEdit");
    checkParentControl("#chkZUTEdit", ".zutChkEdit");
}

function checkZutRead(allChecked) {
    $.each($(".zutChkRead"), function () {
        this.childNodes[0].checked = allChecked;
    });
    $("#chkZUTRead")[0].checked = allChecked;
}

function checkZutEdit(allChecked) {
    $.each($(".zutChkEdit"), function () {
        this.childNodes[0].checked = allChecked;
    });
    $("#chkZUTEdit")[0].checked = allChecked;
}

function checkTmkRead(allChecked) {
    $("#chkTMKRead")[0].checked = allChecked;
}

function checkTmkEdit(allChecked) {
    $("#chkTMKEdit")[0].checked = allChecked;
}

function checkForReadPairs(sender) {
    try {
        if (suppressReadPairEv) { return; }
        var rIndex = $(sender).parent().parent().parent()[0].rowIndex;
        var cIndex = $(sender).parent().parent()[0].cellIndex;

        var chkSpan = $(".mainTbl")[0].rows[rIndex].cells[cIndex + 1].childNodes[0];
        var isPairChecked = chkSpan.childNodes[0].checked;
        if (isPairChecked) {
            $(chkSpan.childNodes[0]).click();
        } else {
            chkSpan.childNodes[0].checked = true;
            $(chkSpan.childNodes[0]).click();
        }

    } catch (e) { }
}

function checkForEditPairs(sender) {
    try {
        if (suppressEditPairEv) { return; }
        var rIndex = $(sender).parent().parent().parent()[0].rowIndex;
        var cIndex = $(sender).parent().parent()[0].cellIndex;

        var chkSpan = $(".mainTbl")[0].rows[rIndex].cells[cIndex - 1].childNodes[0];
        var isPairChecked = chkSpan.childNodes[0].checked;
        if (isPairChecked) {
            $(chkSpan.childNodes[0]).click();
        } else {
            chkSpan.childNodes[0].checked = true;
            $(chkSpan.childNodes[0]).click();
        }
    } catch (e) { }
}

function __askToSaveBeforeLeaving(trigger, preventedEvent, triggerCtrlSelector, triggerEventName) {
    if (trigger) {
        __hidePromptSave();
        PageMethods.SetPromptRedirectPage("/Content/Settings.aspx", function () { $(triggerCtrlSelector).trigger(triggerEventName); });
    } else {
        __hidePromptSave();
        $(preventedEvent.target).trigger(preventedEvent);
    }
}

function __promptSave(preventedEvent, triggerCtrlSelector, triggerEventName) {
    $("#promptsPlaceHolder, #__SavePrompt").show();
    $("#btnSavePromptOk, #btnSavePromptNo, #btnSavePromptCancel").unbind("click");

    $("#btnSavePromptOk").click(function (ev) {
        ev.preventDefault(); __askToSaveBeforeLeaving(true, preventedEvent, triggerCtrlSelector, triggerEventName);
    });
    $("#btnSavePromptNo").click(function (ev) {
        ev.preventDefault(); __hasChanges = false;
        __askToSaveBeforeLeaving(false, preventedEvent, "", "");
    });
    $("#btnSavePromptCancel").click(function (ev) {
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
        __allowDel = true;
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