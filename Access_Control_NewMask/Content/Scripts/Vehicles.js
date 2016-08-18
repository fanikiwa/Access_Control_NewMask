var isInsertEdit = 0;
var levelCaption = "";
var saveManufChanges = false;
var saveModelChanges = false;
$(document).ready(function () {
    $("#btnNewManufacturer").click(function (evt) {
        evt.preventDefault();
        $("#txtManufacturerId").val("0");
        $("#txtManufacturer").removeAttr("disabled");
        if (allowZUTEdit) $("#btnSaveManufacturer").removeAttr("disabled");
        $("#txtManufacturer").focus();
        $("#btnNewModel").attr("disabled", "disabled");
        $("#btnSaveModel").attr("disabled", "disabled");
        $("#btnDeleteModel").attr("disabled", "disabled");
        $("#txtVehicleModelId").val("");
        $("#txtVehicleModel").val("");
        $("#txtVehicleModel").attr("disabled", "disabled");
    });
    $("#btnSaveManufacturer").click(function (evt) {
        evt.preventDefault();
        SaveVehicleManufacturer();
    });
    $("#imgArrow").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnDeleteManufacturer").click(function (evt) {
        evt.preventDefault();
        //DeleteManufacturer();
        ConfirmDeleteManufacturer();

    });
    $("#btnNewModel").click(function (evt) {
        evt.preventDefault();
        $("#txtVehicleModel").removeAttr("disabled");
        if (allowZUTEdit) $("#btnSaveModel").removeAttr("disabled");
        $("#txtVehicleModel").focus();
        $("#txtVehicleModelId").val("");
        $("#btnNewManufacturer").attr("disabled", "disabled");
        $("#btnSaveManufacturer").attr("disabled", "disabled");
        $("#btnDeleteManufacturer").attr("disabled", "disabled");
        $("#txtManufacturer").val("");
        $("#txtManufacturer").attr("disabled", "disabled");
    });
    $("#btnSaveModel").click(function (evt) {
        evt.preventDefault();
        SaveVehicleModel();
    });
    $("#btnDeleteModel").click(function (evt) {
        evt.preventDefault();
        //DeleteVehicleModel();
        ConfirmDeleteVehicleType();
    });
    $("#txtManufacturer").change(function (e) {
        e.preventDefault();
        saveManufChanges = true;
    });
    $("#txtVehicleModel").change(function (e) {
        e.preventDefault();
        saveModelChanges = true;
    });
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (saveManufChanges === true && allowZUTEdit) {
            BackButtonConfirmManufacturer();
        }
        else if (saveModelChanges === true && allowZUTEdit) {
            BackButtonConfirmModel();
        }
        else if (!allowZUTEdit || (saveManufChanges === false && saveModelChanges === false)) {
            document.location.href = "Settings.aspx";
        }

    });
    DisableTexbox();
});
function cboVehicleTypesSelectionChanged(s, e) {
    $("#lblVehicleManu").text(s.GetText());
    grdManufacturer.PerformCallback(s.GetSelectedIndex());
    grdVehicleModel.PerformCallback(s.GetText());
}
function grdManufacturerRowClick(s, e) {
    window.grdManufacturer.GetRowValues(e.visibleIndex, "ID;Name", GetManufacturerName);
}
function grdVehicleModelRowClick(s, e) {
    window.grdVehicleModel.GetRowValues(e.visibleIndex, "ID;Type", GetModelName);

}
function GetManufacturerName(value) {
    cboVehicleTypes.SetValue(value[0]);
    $("#txtManufacturer").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSaveManufacturer").removeAttr("disabled");
    $("#txtManufacturerId").val(value[0]);
    $("#lblVehicleManu").text(value[1]);
    $("#txtManufacturer").val(value[1]);
    $("#txtVehicleModelId").val("");
    $("#txtVehicleModel").val("");
    $("#txtVehicleModel").attr("disabled", "disabled");
    grdVehicleModel.PerformCallback(value[1]);
}
function GetModelName(value) {
    $("#txtVehicleModel").removeAttr("disabled");
    $("#txtVehicleModelId").val(value[0]);
    $("#txtVehicleModel").val(value[1]);
    if (allowZUTEdit) $("#btnSaveModel").removeAttr("disabled");
    $("#txtManufacturerId").val("");
    $("#txtManufacturer").val("");
    $("#txtManufacturer").attr("disabled", "disabled");
}
function SaveVehicleManufacturer() {
    if ($("#txtManufacturer").val().trim() === "") return;
    if (allowZUTEdit) $("#btnNewModel").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSaveModel").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDeleteModel").removeAttr("disabled");
    var id = 0;
    if (isNaN(parseInt($("#txtManufacturerId").val()))) {
        id = 0;
    }
    else {
        id = parseInt($("#txtManufacturerId").val());
    }
    var manufacturer = $("#txtManufacturer").val();
    var holder = cboVehicleTypes.GetText();
    PageMethods.SaveManufacturer(id, manufacturer, holder, OnSaveManufacturer_CallBack);
}
function OnSaveManufacturer_CallBack(result) {
    $("#txtManufacturer").val("");
    $("#txtManufacturer").attr("disabled", "disabled");
    saveManufChanges = false;
    cboVehicleTypes.PerformCallback(result);
}
function SaveVehicleModel() {
    if ($("#txtVehicleModel").val().trim() === "") return;
    if (allowZUTEdit) $("#btnNewManufacturer").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSaveManufacturer").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDeleteManufacturer").removeAttr("disabled");
    var id = 0;
    if (isNaN(parseInt($("#txtVehicleModelId").val()))) {
        id = 0;
    }
    else {
        id = parseInt($("#txtVehicleModelId").val());
    }
    var manufacturer = cboVehicleTypes.GetText();
    var model = $("#txtVehicleModel").val();
    PageMethods.SaveVehicleModel(id, manufacturer, model, OnSaveVehicleModel_CallBack);
}
function OnSaveVehicleModel_CallBack(result) {
    $("#txtVehicleModelId").val("");
    $("#txtVehicleModel").val("");
    $("#txtVehicleModel").attr("disabled", "disabled");
    saveModelChanges = false;
    grdVehicleModel.PerformCallback(cboVehicleTypes.GetText());
}
function DisableTexbox() {
    $("#txtManufacturer").attr("disabled", "disabled");
    $("#txtVehicleModel").attr("disabled", "disabled");
}
function grdManufacturerEndCallBack(s, e) {

}

function DeleteManufacturer() {
    window.grdManufacturer.GetRowValues(grdManufacturer.GetFocusedRowIndex(), "ID;Name", GetManufacturerRow);
}
function GetManufacturerRow(value) {
    if (value[1].trim() === "") return;
    PageMethods.DeleteManufacturer(value[1], OnDeleteManufacturer_CallBack);
}
function OnDeleteManufacturer_CallBack() {
    $("#txtManufacturer").val("");
    $("#txtManufacturer").attr("disabled", "disabled");
    cboVehicleTypes.PerformCallback();
}
function DeleteVehicleModel() {
    var id = grdVehicleModel.GetRowKey(grdVehicleModel.GetFocusedRowIndex());
    if (isNaN(parseInt(id))) return;
    PageMethods.DeleteModel(id, OnDeleteModel_CallBack);
}
function OnDeleteModel_CallBack() {
    $("#txtVehicleModel").val("");
    $("#txtVehicleModel").attr("disabled", "disabled");
    grdVehicleModel.PerformCallback(cboVehicleTypes.GetText());
}
function cboVehicleTypesEndCallBack(s, e) {

}
function SaveAlert(message) {
    //getLocalizedText("buildingPlanDeleteWarning");
    //var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="saveAlertBox">  <img src="../../Images/FormImages/save50px.png" alt="Stop" class="stopPic" height="50" width="50" align="right"> <br/>' + message + '<br/> <button id="btnOkAlert"  onclick="SaveAlertOnClick()"></button></div></div></div>';
    document.getElementById('saveAlert').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOkAlert').text(levelCaption);
}
function SaveAlertOnClick() {
    document.getElementById('saveAlert').innerHTML = "";
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "Vehicles.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
//delete dialog
function ConfirmDeleteManufacturer() {
    var message = "Sind Sie sicher das Sie das Hersteller tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 15%; margin-right: 0px; width:210px;"  onclick="DeleteManuConfirmed()"></button><button id="btnCancel" style="margin-left: 1px; width:160px;"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteManufacturer");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelDeleteManufacturer");
    $('#btnCancel').text(levelCaption);
}
function ConfirmDeleteVehicleType() {
    var message = "Sind Sie sicher das Sie das Fahrzeugtyp tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%; margin-right: 0px; width:125px;"  onclick="DeleteTypeConfirmed()"></button><button id="btnCancel" style="margin-left: 1px; width:168px;"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteVehicleType");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelDeleteVehicleType");
    $('#btnCancel').text(levelCaption);
}
function DeleteManuConfirmed() {
    ResetDialog();
    DeleteManufacturer();
}
function DeleteTypeConfirmed() {
    ResetDialog();
    DeleteVehicleModel();
}
function ResetDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}
//end delete dialog


//back dialog
function SaveVehicleModelOnBack() {
    ResetDialog();
    if ($("#txtVehicleModel").val().trim() === "") {
        document.location.href = "Settings.aspx";
    }
    if (allowZUTEdit) $("#btnNewManufacturer").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSaveManufacturer").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDeleteManufacturer").removeAttr("disabled");
    var id = 0;
    if (isNaN(parseInt($("#txtVehicleModelId").val()))) {
        id = 0;
    }
    else {
        id = parseInt($("#txtVehicleModelId").val());
    }
    var manufacturer = cboVehicleTypes.GetText();
    var model = $("#txtVehicleModel").val();
    PageMethods.SaveVehicleModel(id, manufacturer, model, OnSaveVehicleModelOnBack_CallBack);
}
function OnSaveVehicleModelOnBack_CallBack() {
    document.location.href = "Settings.aspx";
}
function BackButtonConfirmModel() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveVehicleModelOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
function No_OnBack() {
    ResetDialog();
    document.location.href = "Settings.aspx";
}
function SaveVehicleManufacturerOnBack() {
    ResetDialog();
    if ($("#txtManufacturer").val().trim() === "") {
        document.location.href = "Settings.aspx";
    }
    if (allowZUTEdit) $("#btnNewModel").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSaveModel").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDeleteModel").removeAttr("disabled");
    var id = 0;
    if (isNaN(parseInt($("#txtManufacturerId").val()))) {
        id = 0;
    }
    else {
        id = parseInt($("#txtManufacturerId").val());
    }
    var manufacturer = $("#txtManufacturer").val();
    var holder = cboVehicleTypes.GetText();
    PageMethods.SaveManufacturer(id, manufacturer, holder, OnSaveManufacturerOnBack_CallBack);
}
function OnSaveManufacturerOnBack_CallBack() {
    ResetDialog();
    document.location.href = "Settings.aspx";
}
function BackButtonConfirmManufacturer() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveVehicleManufacturerOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
//end back dialog