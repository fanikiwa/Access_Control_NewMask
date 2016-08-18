var levelCaption = 0;
var SaveExitChanges = false;
var ConfirmDelete = false;
var message;

$(document).ready(function () {

    //text for delete prompt buttons and labels
    getLocalizedText("permitMandantenDeletion");
    $('#btnWarningPromptOk').val(message);

    getLocalizedText("cancelMandantenDeletion");
    $('#btnWarningPromptNo').val(message);

    $('#lblDeleteText').text("Sind Sie sicher das Sie das Mandanten tatsächlich löschen wollen? ");

    if ($('#saveChangesonNew').val() == 1) {
        SaveExitChanges = true;
        levelCaption = 1;
    }
    $("#btnDelete").click(function (evt) {
        if (!ConfirmDelete) {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptWarning(pEvt);
        }
    });

    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (levelCaption === 0 || !allowZUTEdit) {
            //document.location.href = "Settings.aspx";
            window.location.href = "Settings.aspx";
        }
        else if (levelCaption === 1 || ($('#saveChangesonNew').val()) === '1') {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptSave(pEvt, "#btnSave", "click");
        }
    });

    $("#btnNew").click(function (evt) {
        SaveExitChanges = true;
        levelCaption = 1;
    });

    $("input").change(function (evt) {
        SaveExitChanges = true;
        if (allowZUTEdit) $("#btnSave").removeAttr("disabled", "disabled");
        levelCaption = 1;
    });

    $("#txtMemo").change(function (evt) {
        SaveExitChanges = true;
        if (allowZUTEdit) $("#btnSave").removeAttr("disabled", "disabled");
        levelCaption = 1;
    });
})

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
        levelCaption = 0;
        ev.preventDefault(); __askToSaveBeforeLeaving(true, preventedEvent, triggerCtrlSelector, triggerEventName);
    });
    $("#btnSavePromptNo").click(function (ev) {
        levelCaption = 0;
        ev.preventDefault(); SaveExitChanges = false;
        __askToSaveBeforeLeaving(false, preventedEvent, "", "");
    });
    $("#btnSavePromptCancel").click(function (ev) {
        levelCaption === 1;
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


function cboCustomerNrSelectedIndexChanged(value) {
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
}

function cboClientName2SelectedIndexChanged(value) {
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
}


function SetValues(value) {
    PageMethods.GetCustomer(value, Setcontrols);
}

function Setcontrols(Responce) {
    try {
        if (Responce.ID !== null && Responce.ID !== 0) {
            cboCustomerNr.SetValue(Responce.ID.toString());
            cboClientName2.SetValue(Responce.ID.toString());

            $("#txtClientNr").val(Responce.Client_Nr);
            $("#txtClientName").val(Responce.Name);
            $("#txtPLZ").val(Responce.Plz);
            $("#txtOrt").val(Responce.Ort);
            $("#txtStreet").val(Responce.Street);
            $("#txtHouseNr").val(Responce.HouseNr);

            cboState.SetValue(Responce.State.toString());

            $("#txtName").val(Responce.PersonInCharge);
            $("#txtFunct").val(Responce.Function);
            $("#txtTel").val(Responce.Telephone);
            $("#txtMob").val(Responce.Mobile);
            $("#txtEmail").val(Responce.Email);

            $("#txtMemo").val(Responce.InfoText);
        } else {
            $("#txtClientNr").val("");
            $("#txtClientName").val("");
            $("#txtPLZ").val("");
            $("#txtOrt").val("");
            $("#txtStreet").val("");
            $("#txtHouseNr").val("");
            cboState.SetValue(0);
            $("#txtName").val("");
            $("#txtFunct").val("");
            $("#txtTel").val("");
            $("#txtMob").val("");
            $("#txtEmail").val("");
            $("#txtMemo").val("");
        }

    } catch (e) {
        console.log(e);
    }
}


function grdClientDetailsRowClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var id = grdClientDetails.GetRowKey(index);
        PageMethods.GetCustomerById(id, OngrdClientDetailsRowClick_CallBack);
    }
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
}


function OngrdClientDetailsRowClick_CallBack(result) {
    if (result !== null) {
        cboCustomerNr.SetValue(result.ID.toString());
        cboClientName2.SetValue(result.ID.toString());

        $("#txtClientNr").val(result.Client_Nr);
        $("#txtClientName").val(result.Name);
        $("#txtPLZ").val(result.Plz);
        $("#txtOrt").val(result.Ort);
        $("#txtStreet").val(result.Street);
        $("#txtHouseNr").val(result.HouseNr);

        cboState.SetValue(result.State);

        $("#txtName").val(result.PersonInCharge);
        $("#txtFunct").val(result.Function);
        $("#txtTel").val(result.Telephone);
        $("#txtMob").val(result.Mobile);
        $("#txtEmail").val(result.Email);

        $("#txtMemo").val(result.InfoText);
    } else {
        $("#txtClientNr").val("");
        $("#txtClientName").val("");
        $("#txtPLZ").val("");
        $("#txtOrt").val("");
        $("#txtStreet").val("");
        $("#txtHouseNr").val("");
        cboState.SetValue(0);
        $("#txtName").val("");
        $("#txtFunct").val("");
        $("#txtTel").val("");
        $("#txtMob").val("");
        $("#txtEmail").val("");
        $("#txtMemo").val("");
    }
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
}


function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "Customer.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            message = result.d;
        }
    });
}