var levelCaption = 0;
var SaveExitChanges = false;
var ConfirmDelete = false;

$(function () {

    //getLocalizedText("permitMandantenDeletion");
    //  $('#btnWarningPromptOk').val(message);

    //getLocalizedText("cancelMandantenDeletion");
    //  $('#btnWarningPromptNo').val(message);
    if ($('#saveChangesonNew').val() == 1) {
        SaveExitChanges = true;
        levelCaption = 1;
    }
    $('#btnWarningPromptOk').val("Besucherfirma löschen");
    $('#btnWarningPromptNo').val("Besucherfirma nicht löschen");

    $('#lblDeleteText').text("Sind Sie sicher das Sie das Besucherfirma tatsächlich löschen wollen? ");

    $('#btnWarningPromptOk').css({
        "margin-left": "30%",
        "margin-right": "6px",
    });

    $('#btnWarningPromptNo').css({
        "width": "180px",
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
        if (levelCaption === 0 || !allowZUTEdit) {
            window.location.href = "Settings.aspx";
        }
        else if (levelCaption === 1 || ($('#saveChangesonNew').val()) === '1') {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptSave(pEvt, "#btnSave", "click");
        }
    });

    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    $("#btnSave").click(function (evt) {
        if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
        grdVisitorCompany.UnselectRows();
        cboCustomerNr.PerformCallback();
        var value = cboCustomerNr.GetValue();
        setTimeout(function () { PageMethods.GetVisitorCompanyById(value, OnGetVisitorCompanyByNr_CallBack); }, 200)
    });
    $("#btnNew").click(function (evt) {
        SaveExitChanges = true;
        levelCaption = 1;

        grdVisitorCompany.UnselectRows();
        cboCustomerNr.PerformCallback();
        var value = cboCustomerNr.GetValue();
        setTimeout(function () { PageMethods.GetVisitorCompanyById(value, OnGetVisitorCompanyByNr_CallBack); }, 200)
        if (allowZUTEdit) $("#btnSave").attr("disabled", false);
        if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
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

//back save changes warning prompt
function __askToSaveBeforeLeaving(trigger, preventedEvent, triggerCtrlSelector, triggerEventName) {
    if (trigger) {
        __hidePromptSave();
        PageMethods.SetPromptRedirectPage("/Index.aspx", function () { $(triggerCtrlSelector).trigger(triggerEventName); });
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

//Delete warning prompt
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
    cboCustomerNr.SetValue(value);
    cboClientName.SetValue(value);
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    grdVisitorCompany.PerformCallback(-1);
}

function cboClientNameSelectedIndexChanged(value) {
    cboCustomerNr.SetValue(value);
    cboClientName.SetValue(value);
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    grdVisitorCompany.PerformCallback(-1);

}

function SetValues(value) {
    PageMethods.GetVisitorCompany(value, Setcontrols);
}

function Setcontrols(Responce) {
    try {
        if (Responce.CompanyNr !== null && Responce.CompanyNr !== 0) {
            cboClientName.SetValue(Responce.ID.toString());
            cboCustomerNr.SetValue(Responce.ID.toString());
            cboState.SetValue(Responce.CompanyNr.toString());

            $("#txtClientNr").val(Responce.CompanyNr);
            $("#txtClientName").val(Responce.CompanyName);
            $("#txtPLZ").val(Responce.ZipCode);
            $("#txtOrt").val(Responce.Place);
            $("#txtName").val(Responce.Name);
            $("#txtStreet").val(Responce.Street);
            $("#txtTel").val(Responce.Telephone);
            $("#txtMob").val(Responce.Mobile);
            $("#txtMemo").val(Responce.Memo);
            $("#txtHouseNr").val(Responce.HouseNr);
            $("#txtFunct").val(Responce.PersFunction);
            $("#txtEmail").val(Responce.Email);
            grdAbsences.PerformCallback(Responce.CompanyNr);
        } else {
            $("#txtClientNr").val("");
            $("#txtClientName").val("");
            $("#txtPLZ").val("");
            $("#txtOrt").val("");
            $("#txtName").val("");
            $("#txtStreet").val("");
            $("#txtTel").val("");
            $("#txtMob").val("");
            $("#txtMemo").val("");
            $("#txtHouseNr").val("");
            $("#txtFunct").val("");
            $("#txtEmail").val("");
            grdVisitorCompany.PerformCallback(-1);
        }
    } catch (e) { console.log(e); }

}

function grdVisitorCompanyRowClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var id = grdVisitorCompany.GetRowKey(index);
        PageMethods.GetVisitorCompanyById(id, OngrdVisitorCompanyRowClick_CallBack);
    }
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
}

function OngrdVisitorCompanyRowClick_CallBack(result) {
    if (result !== null) {
        cboClientName.SetValue(result.ID.toString());
        cboCustomerNr.SetValue(result.ID.toString());
        cboState.SetValue(result.CompanyNr.toString());

        $("#txtClientNr").val(result.CompanyNr);
        $("#txtClientName").val(result.CompanyName);
        $("#txtPLZ").val(result.ZipCode);
        $("#txtOrt").val(result.Place);
        $("#txtName").val(result.Name);
        $("#txtStreet").val(result.Street);
        $("#txtTel").val(result.Telephone);
        $("#txtMob").val(result.Mobile);
        $("#txtMemo").val(result.Memo);
        $("#txtHouseNr").val(result.HouseNr);
        $("#txtFunct").val(result.PersFunction);
        $("#txtEmail").val(result.Email);
    }
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
}

function OnGetVisitorCompanyByNr_CallBack(result) {
    if (result !== null) {
        $("#txtClientNr").val(result.CompanyNr);
        $("#txtClientName").val(result.CompanyName);
        $("#txtPLZ").val(result.ZipCode);
        $("#txtOrt").val(result.Place);
        $("#txtName").val(result.Name);
        $("#txtStreet").val(result.Street);
        $("#txtTel").val(result.Telephone);
        $("#txtMob").val(result.Mobile);
        $("#txtMemo").val(result.Memo);
        $("#txtHouseNr").val(result.HouseNr);
        $("#txtFunct").val(result.PersFunction);
        $("#txtEmail").val(result.Email);
        grdVisitorCompany.PerformCallback(result.CompanyNr);
    }
    else {
        $("#txtClientNr").val("");
        $("#txtClientName").val("");
        $("#txtPLZ").val("");
        $("#txtOrt").val("");
        $("#txtName").val("");
        $("#txtStreet").val("");
        $("#txtTel").val("");
        $("#txtMob").val("");
        $("#txtMemo").val("");
        $("#txtHouseNr").val("");
        $("#txtFunct").val("");
        $("#txtEmail").val("");
        grdVisitorCompany.PerformCallback(-1);
    }
}

