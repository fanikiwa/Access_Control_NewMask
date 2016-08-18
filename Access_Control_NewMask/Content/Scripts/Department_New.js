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
    $('#btnWarningPromptOk').val("Abteilung löschen");
    $('#btnWarningPromptNo').val("Abteilung nicht löschen");

    $('#lblDeleteText').text("Sind Sie sicher das Sie das Abteilung tatsächlich löschen wollen? ");

    $('#btnWarningPromptOk').css({
        "margin-left": "36%",
        "margin-right": "6px",
    });

    $('#btnWarningPromptNo').css({
        "width": "155px",
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
        else if (levelCaption === 1  || ($('#saveChangesonNew').val()) === '1') {
            var pEvt = $.extend(true, {}, evt);
            evt.preventDefault();
            __promptSave(pEvt, "#btnSave", "click");
        }
    });

    $("#btnSave").click(function (evt) {
        if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
        //grdDepartments.UnselectRows();
        //cboDeptNr.PerformCallback();
        //var value = cboDeptNr.GetValue();
        //setTimeout(function () { PageMethods.GetDepartmentById(value, OnGetDepartmentById_CallBack); }, 200)
    });
    $("#btnNew").click(function (evt) {
        SaveExitChanges = true;
        levelCaption = 1;

        // grdDepartments.UnselectRows();
        // cboDeptNr.PerformCallback();
        //var value = cboDeptNr.GetValue();
        //setTimeout(function () { PageMethods.GetDepartmentById(value, OnGetDepartmentById_CallBack); }, 200)
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

function cboDeptNrSelectedIndexChanged(value) {
    //cboDeptNr.SetValue(value);
    //cboDeptName.SetValue(value);
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    //grdDepartments.PerformCallback(-1);
}

function cboDeptNameSelectedIndexChanged(value) {
    //cboDeptNr.SetValue(value);
    //cboDeptName.SetValue(value);
    SetValues(value);
    if (allowZUTEdit) $("#btnDelete").attr("disabled", false);
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
    //grdDepartments.PerformCallback(-1);

}

function SetValues(value) {
    PageMethods.GetDepartment(value, Setcontrols);
}

function Setcontrols(Responce) {
    try {
        if (Responce.ID !== null && Responce.ID !== 0) {
            cboDeptNr.SetValue(Responce.ID.toString());
            cboDeptName.SetValue(Responce.ID.toString());

            $("#txtdeptNo").val(Responce.Department_Nr);
            $("#txtdeptName").val(Responce.Name);
            $("#txtPLZ").val(Responce.ZipCode);
            $("#txtOrt").val(Responce.Place);
            $("#txtStreet").val(Responce.Street);
            $("#txthseNumber").val(Responce.HouseNumber);

            $("#txtName").val(Responce.LocationHeadName);
            $("#txtFunct").val(Responce.LocationHeadFunction);
            $("#txtTel").val(Responce.LocationHeadPhone);
            $("#txtMob").val(Responce.LocationHeadMobile);
            $("#txtEmail").val(Responce.LocationHeadEmail);

            $("#txtMemo").val(Responce.InfoText);
            grdDepartments.SetFocusedRowIndex(Responce.ID);
            // grdDepartments.PerformCallback(Responce.CompanyNr);
        } else {
            $("#txtdeptNo").val("");
            $("#txtdeptName").val("");
            $("#txtPLZ").val("");
            $("#txtOrt").val("");
            $("#txtStreet").val("");
            $("#txthseNumber").val("");

            $("#txtName").val("");
            $("#txtFunct").val("");
            $("#txtTel").val("");
            $("#txtMob").val("");
            $("#txtEmail").val("");
            //  grdDepartments.PerformCallback(-1);

        }

    } catch (e) {
        console.log(e);
    }
}

function grdDepartmentsRowClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var id = grdDepartments.GetRowKey(index);
        PageMethods.GetDepartmentById(id, OngrdDepartmentsRowClick_CallBack);
    }
    if (allowZUTEdit) $("#btnSave").attr("disabled", false);
}

function OngrdDepartmentsRowClick_CallBack(result) {
    if (result !== null) {
        cboDeptNr.SetValue(result.ID.toString());
        cboDeptName.SetValue(result.ID.toString());

        $("#txtdeptNo").val(result.Department_Nr);
        $("#txtdeptName").val(result.Name);
        $("#txtPLZ").val(result.ZipCode);
        $("#txtOrt").val(result.Place);
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

function OnGetDepartmentById_CallBack(result) {
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

