var levelCaption = 0;
var SaveExitChanges = false;
var ConfirmDelete = false;

$(document).ready(function () {


    //getLocalizedText("permitMandantenDeletion");
    //  $('#btnWarningPromptOk').val(message);

    //getLocalizedText("cancelMandantenDeletion");
    //  $('#btnWarningPromptNo').val(message);
    if ($('#saveChangesonNew').val() == 1) {
        SaveExitChanges = true;
        levelCaption = 1;
    }
    $('#btnWarningPromptOk').val("Kostenstelle löschen");
    $('#btnWarningPromptNo').val("Kostenstelle nicht löschen");

    $('#lblDeleteText').text("Sind Sie sicher das Sie das Kostenstelle tatsächlich löschen wollen? ");

    $('#btnWarningPromptOk').css({
        "margin-left": "33%",
        "margin-right": "6px",
    });

    $('#btnWarningPromptNo').css({
        "width": "170px",
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
    //$("#btnSave").attr("disabled", true);
    $("#btnSave").click(function (evt) {
        if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
        // grdCostcenter.UnselectRows();
        //  cboCostCnterNr.PerformCallback();
        //var value = cboCostCnterNr.GetValue();
        //setTimeout(function () { PageMethods.GetCostCenterById(value, OnGetCostCenterById_CallBack); }, 200)
    });
    $("#btnNew").click(function (evt) {
        SaveExitChanges = true;
        levelCaption = 1;
        //grdCostcenter.UnselectRows();
        // cboCostCnterNr.PerformCallback();
        //var value = cboCostCnterNr.GetValue();
        //setTimeout(function () { PageMethods.GetCostCenterById(value, OnGetCostCenterById_CallBack); }, 200)
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

function cboCostCnterNrSelectedIndexChanged(value) {
    //cboCostCnterNr.SetValue(value);
    //cboCostCenterName.SetValue(value);
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    //grdCostcenter.PerformCallback(-1);
}

function cboCostCenterNameSelectedIndexChanged(value) {
    //cboCostCnterNr.SetValue(value);
    //cboCostCenterName.SetValue(value);
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    //grdVisitorCompany.PerformCallback(-1);

}

function SetValues(value) {
    PageMethods.GetCostCenters(value, Setcontrols);
}

function Setcontrols(Responce) {
    try {
        if (Responce.ID !== null && Responce.ID !== 0) {
            cboCostCnterNr.SetValue(Responce.ID.toString());
            cboCostCenterName.SetValue(Responce.ID.toString());

            $("#txtcostcntrno").val(Responce.CostCenter_Nr);
            $("#txtCostCenterName").val(Responce.Name);
            $("#txtPLZ").val(Responce.ZipCode);
            $("#txtOrt").val(Responce.State);
            $("#txtStreet").val(Responce.Street);
            $("#txthseNumber").val(Responce.HouseNumber);

            $("#txtName").val(Responce.LocationHeadName);
            $("#txtFunct").val(Responce.LocationHeadFunction);
            $("#txtTel").val(Responce.LocationHeadPhone);
            $("#txtMob").val(Responce.LocationHeadMobile);
            $("#txtEmail").val(Responce.LocationHeadEmail);

            $("#txtMemo").val(Responce.InfoText);
            grdCostcenter.SetFocusedRowIndex(Responce.ID);
            // grdCostcenter.PerformCallback(Responce.CompanyNr);
        } else {
            $("#txtcostcntrno").val("");
            $("#txtCostCenterName").val("");
            $("#txtPLZ").val("");
            $("#txtOrt").val("");
            $("#txtStreet").val("");
            $("#txthseNumber").val("");

            $("#txtName").val("");
            $("#txtFunct").val("");
            $("#txtTel").val("");
            $("#txtMob").val("");
            $("#txtEmail").val("");
            //  grdCostcenter.PerformCallback(-1);

        }

    } catch (e) {
        console.log(e);
    }
}

function grdCostcenterRowClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var id = grdCostcenter.GetRowKey(index);
        PageMethods.GetCostCenterById(id, OngrdCostcenterRowClick_CallBack);
    }
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
}

function OngrdCostcenterRowClick_CallBack(result) {
    if (result !== null) {
        cboCostCnterNr.SetValue(result.ID.toString());
        cboCostCenterName.SetValue(result.ID.toString());

        $("#txtcostcntrno").val(result.CostCenter_Nr);
        $("#txtCostCenterName").val(result.Name);
        $("#txtPLZ").val(result.ZipCode);
        $("#txtOrt").val(result.State);
        $("#txtStreet").val(result.Street);
        $("#txthseNumber").val(result.HouseNumber);

        $("#txtName").val(result.LocationHeadName);
        $("#txtFunct").val(result.LocationHeadFunction);
        $("#txtTel").val(result.LocationHeadPhone);
        $("#txtMob").val(result.LocationHeadMobile);
        $("#txtEmail").val(result.LocationHeadEmail);

        $("#txtMemo").val(result.InfoText);
    }
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
}

function OnGetCostCenterById_CallBack(result) {
    if (result !== null) {
        $("#txtClientNr").val(result.CompanyNr);
        $("#txtClientName").val(result.CompanyName);
        $("#txtPLZ").val(result.ZipCode);
        $("#txtOrt").val(result.State);
        $("#txtName").val(result.Name);
        $("#txtStreet").val(result.Street);
        $("#txtTel").val(result.Telephone);
        $("#txtMob").val(result.Mobile);
        $("#txtMemo").val(result.Memo);
        $("#txtHouseNr").val(result.HouseNr);
        $("#txtFunct").val(result.PersFunction);
        $("#txtEmail").val(result.Email);
        // grdVisitorCompany.PerformCallback(result.CompanyNr);
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
        //  grdVisitorCompany.PerformCallback(-1);
    }
}