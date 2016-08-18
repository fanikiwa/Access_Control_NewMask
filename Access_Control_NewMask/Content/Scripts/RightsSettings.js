var hiddenStatus = 0;
var __hasChanges = false;
var __allowDel = false;

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    $("#ContentAreaDiv").css("background-color", "#d0e4f7");

    $("#btnSearchEmpNr").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 1;

        $("#secWrapper").hide();
        $("#rightsSearch").hide();
        $("#searchPersonal").show();

    });

    $("#btnSearchRightNr").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 2;
        $("#secWrapper").hide();
        $("#searchPersonal").hide();
        $("#rightsSearch").show();

    });

    $("input").change(function (evt) {
        __hasChanges = true;
    });

    $("#btnBack").click(function (evt) {
        if (hiddenStatus == 0 && !allowZUTEdit) {
            evt.preventDefault();
            document.location.href = "/Content/Settings.aspx";
        }
        else if (hiddenStatus == 1) {
            evt.preventDefault();
            $("#secWrapper").show();
            $("#searchPersonal").hide();
            $("#rightsSearch").hide();

            hiddenStatus = 0;
        }
        else if (hiddenStatus == 2) {
            evt.preventDefault();
            $("#secWrapper").show();
            $("#searchPersonal").hide();
            $("#rightsSearch").hide();

            hiddenStatus = 0;
        } else {
            if (__hasChanges) {
                var pEvt = $.extend(true, {}, evt);
                evt.preventDefault();
                __promptSave(pEvt, "#btnSave", "click");
            }
        }
    });

    getPersProfileMapping();
});

function cmbRightNrIndexChanged() {
    cmbRightDescription.SetValue(cmbRightNr.GetValue());
    return false;
}

function cmbRightDescriptionIndexChanged() {
    cmbRightNr.SetValue(cmbRightDescription.GetValue());
    return false;
}

function cmbPrsNrrIndexChanged() {
    cmbEmployee.SetValue(cmbPrsNrr.GetValue());
    getPersProfileMapping();
    return false;
}

function cmbEmployeeIndexChanged() {
    cmbPrsNrr.SetValue(cmbEmployee.GetValue());
    getPersProfileMapping();
    return false;
}

function getPersProfileMapping() {
    var persNr = (isNaN(cmbPrsNrr.GetValue()) ? 0 : parseInt(cmbPrsNrr.GetValue()));
    if (persNr == 0) return;

    PageMethods.GetPersProfileMappingDto(persNr, getPersProfileMappingComplete);
}

function getPersProfileMappingComplete(data) {
    var profileId = data;

    try {
        cmbRightNr.SetValue(data.ProfileID);
        cmbRightDescription.SetValue(data.ProfileID);
        $("#chkUseAD").attr("checked", data.useAD);
        $("#txtADUsername").val(data.AD_Username);
        $("#txtADPath").val(data.AD_Path);
        $("#txtADController").val(data.AD_Controller);
    } catch (e) { }
}

function grdVwRightsNrSearchRowDblClick(s, e) {
    window.grdVwRightsNrSearch.GetRowValues(e.visibleIndex, "ID;ProfileNr;ProfileDescription", GetRowValues);

    $("#secWrapper").show();
    $("#searchPersonal").hide();
    $("#rightsSearch").hide();
}

function GetRowValues(values) {
    var rightsProfileID = values[0].toString();
    var rightsprofileNr = values[1].toString();
    var rightsProfileDescrptn = values[2].toString();


    cmbRightNr.SetValue(rightsProfileID);
    cmbRightDescription.SetValue(rightsProfileID);
}

function grdVwPersonalRowDblClick(s, e) {
    window.grdVwPersonal.GetRowValues(e.visibleIndex, "ID;Pers_Nr;IdentificationNr_string;LastName;FirstName;LocationName;DepartmentName;CostCenterName", GetPersonalRowValues);

    $("#secWrapper").show();
    $("#searchPersonal").hide();
    $("#rightsSearch").hide();
}

function GetPersonalRowValues(values) {
    var persID = values[0].toString();
    var personnelNr = values[1].toString();
    //var identificationNr = values[2].toString();
    //var lastName = values[3].toString();
    //var firstName = values[4].toString();
    //var locationName = values[5].toString();
    //var departmentName = values[6].toString();
    //var costCenterName = values[7].toString();

    cmbPrsNrr.SetValue(persID);
    cmbEmployee.SetValue(persID);
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