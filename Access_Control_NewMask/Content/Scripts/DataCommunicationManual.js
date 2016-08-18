
var BackValue = 0;

var terminals = [];
var actionTermianls = [];

var SEND_MASTER_DATA_ACTION_KEY = 1;
var GET_BOOKINGS_ACTION_KEY = 2;
var SEND_SYSTEM_TIME_ACTION_KEY = 3;
var TEST_CONNETION_ACTION_KEY = 4;

var saveChanges = false;
var selectionChanged = false;

$(document).ready(function () {
    $('#PageTitleLbl2').text("manuell");
    $('#btnDelete').click(
       function (evt) {
           evt.preventDefault();
           //getLocalizedText("buildingPlanDeleteWarning");
           var message = "Sind Sie sicher, um die Gruppe zu löschen möchten";
           ConfirmDelete(message);
       });

    $('#btnBack').click(
      function (evt) {
          evt.preventDefault();
          if (saveChanges === true && allowZUTEdit) {
              var message = "Möchten Sie das änderungen speichern möchten?";
              CallSaveDialog(message);
          }
          else {
              window.location.href = "/Index.aspx";
          }
      });

    $("#btnApplyTermGrp").click(function (evt) {
        evt.preventDefault();

        $('.contMid,.contFooter,.rightDvns').show();
        $('.searchTerminals').hide();

    });

    $('#btnUmapTerminalInstance').click(
       function (evt) {
           evt.preventDefault();
           //getLocalizedText("buildingPlanDeleteWarning");
           var message = "Sind Sie sicher, dass Sie das Terminal aus der Gruppe entfernen wollen?";
           ConfirmUnmapTerminal(message);
       });
    $('#btnMapTerminals').click(
      function (evt) {
          evt.preventDefault();
          var groupId = ddlTerminalGrpNr.GetValue();

          if (parseInt(groupId) === 0 && $("#txtTerminalGrpNr").val().length < 1) {
              alert("Wählen Sie eine Gruppe");
              return;
          }
          if (parseInt(groupId) === 0 && $("#txtTerminalGrpNr").val().length > 0) {

              var groupNr = $("#txtTerminalGrpNr").val();

              PageMethods.GroupNrExists(groupNr, OnNewMapping_CallBack);
              //var groupId = $("#ddlTerminalGrpNr option:selected").val();
              //var groupNr = $("#txtTerminalGrpNr").val();
              //var groupDescritption = $("#txtGroupDescription").val();
              //PageMethods.SaveTerminalGroup(groupId, groupNr, groupDescritption, terminals, OnSaveNewMap_CallBack)
              //grdMappedTerminals.PerformCallback($("#ddlTerminalGrpNr").val());
          }
          else if (parseInt(groupId) > 0 && $("#txtTerminalGrpNr").val().length > 0) {
              PageMethods.MapTerminalsToGroups(groupId, terminals, OnMapping_CallBack);
          }

      });
    //$("#ddlTerminalGrpNr").change(function (evt) {
    //    evt.preventDefault();
    //    selectionChanged = true;
    //    saveChanges = false;
    //    if (ddlTerminalGrpNr.GetValue() !== "0") {
    //        $("#ddlTerminalDescription").val(ddlTerminalGrpNr.GetValue());
    //        $("#txtTerminalGrpNr").val(ddlTerminalGrpNr.GetText());
    //        $("#txtGroupDescription").val($("#ddlTerminalDescription option:selected").text());
    //    }
    //    else {
    //        $("#ddlTerminalDescription").val(ddlTerminalGrpNr.GetValue());
    //        $("#txtTerminalGrpNr").val("");
    //        $("#txtGroupDescription").val("");
    //    }
    //    var groupId = Number(ddlTerminalGrpNr.GetValue());

    //    if (groupId === NaN) {
    //        groupId = 0;
    //    }

    //    grdMappedTerminals.PerformCallback(groupId);
    //    grdTerminalInstances.PerformCallback();

    //});
    //$("#ddlTerminalDescription").change(function (evt) {
    //    evt.preventDefault();
    //    selectionChanged = true;
    //    saveChanges = false;
    //    if ($("#ddlTerminalDescription option:selected").val() !== "0") {
    //        ddlTerminalGrpNr.SetValue($("#ddlTerminalDescription option:selected").val());
    //        $("#txtTerminalGrpNr").val(ddlTerminalGrpNr.GetText());
    //        $("#txtGroupDescription").val($("#ddlTerminalDescription option:selected").text());
    //    }
    //    else {
    //        ddlTerminalGrpNr.SetValue($("#ddlTerminalDescription option:selected").val());
    //        $("#txtTerminalGrpNr").val("");
    //        $("#txtGroupDescription").val("");
    //    }
    //    var groupId = Number($("#ddlTerminalDescription option:selected").val());

    //    if (groupId === NaN) {
    //        groupId = 0;
    //    }

    //    grdMappedTerminals.PerformCallback(groupId);
    //    grdTerminalInstances.PerformCallback();

    //});

    $('#btnSendRefferenceData').click(
       function (evt) {
           evt.preventDefault();
           showLoadingPanel('Stammdaten werden gesendet...');
           PageMethods.DoActiononSelectedTerminals(SEND_MASTER_DATA_ACTION_KEY, actionTermianls, OnTerminalAction_CallBack);
       });

    $('#btnGetBookings').click(
       function (evt) {
           evt.preventDefault();
           showLoadingPanel('Buchungen werden abgeholt...');
           PageMethods.DoActiononSelectedTerminals(GET_BOOKINGS_ACTION_KEY, actionTermianls, OnTerminalAction_CallBack);
       });

    $('#btnSendSystemTime').click(
       function (evt) {
           evt.preventDefault();
           showLoadingPanel('Datum und Uhrzeit stellen ..');
           PageMethods.DoActiononSelectedTerminals(SEND_SYSTEM_TIME_ACTION_KEY, actionTermianls, OnTerminalAction_CallBack);
       });

    $('#btnTestConnection').click(
       function (evt) {
           evt.preventDefault();

           showLoadingPanel('Testverbindung ...');
           PageMethods.DoActiononSelectedTerminals(TEST_CONNETION_ACTION_KEY, actionTermianls, OnTerminalAction_CallBack);

       });
    $("#txtTerminalGrpNr").change(function () {
        saveChanges = true;
    });
    $("#txtGroupDescription").change(function () {
        saveChanges = true;
    });


    $("#btnSearchTerminals").click(function (evt) {
        evt.preventDefault();
        showAllTerminals();
        BackValue = 1;

        $('#btnBack').unbind('click');
        $('#btnBack').click(
function (evt) {
    evt.preventDefault();
    if (BackValue === 0) {
        document.location.href = "/Index.aspx";
    }
    else if (BackValue === 1) {
        $('.contMid,.contFooter,.rightDvns').show();
        $('.searchTerminals').hide();
    }
    BackValue = 0;
});
    });

});
function OnTerminalAction_CallBack() {
    grdMappedTerminals.PerformCallback(-99);
    LoadingPanel.Hide();
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "DataCommunicationManual.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
function grdTerminalInstancesRowChanged(s, e) {

    if (selectionChanged === false) {
        saveChanges = true;
    }
    selectionChanged = false;
    terminals = [];
    window.grdTerminalInstances.GetSelectedFieldValues("ID", GetSelectedTerminals);
}
function GetSelectedTerminals(values) {
    for (var i = 0; i < values.length; i++) {
        var terminalId = values[i];

        terminals.push({
            ID: terminalId

        });
    }
}

function grdMappedTerminalsRowChanged(s, e) {

    actionTermianls = [];
    //window.grdMappedTerminals.GetSelectedFieldValues("TermID", "TermType", "Description", "SerialNumber", "IpAddress", "Port", GetSelectedActionTerminals);
    //window.grdMappedTerminals.GetSelectedFieldValues("ID;TermType;Description;SerialNumber;IpAddress;Port", GetSelectedActionTerminals);
    window.grdMappedTerminals.GetSelectedFieldValues("ID", GetSelectedActionTerminals);
}

function GetSelectedActionTerminals(selectedRows) {

    for (var i = 0; i < selectedRows.length; i++) {
        //selectedRow = selectedRows[i];

        terminalID = selectedRows[i];
        //terminalType = selectedRow[1];
        //terminalDescription = selectedRow[2];
        //terminalSerialNumber = selectedRow[3];
        //terminalIpAddress = selectedRow[4];
        //terminalPort = selectedRow[5];

        actionTermianls.push({

            ID: terminalID,
            //TermType: terminalType,
            //Description: terminalDescription,
            //SerialNumber: terminalSerialNumber,
            //IpAddress: terminalIpAddress,
            //Port: terminalPort
        });
    }
}

function OnMapping_CallBack() {
    var groupId = Number(ddlTerminalGrpNr.GetValue());
    if (groupId === NaN) {
        groupId = 0;
    }
    grdMappedTerminals.PerformCallback(groupId);
    if (allowZUTEdit) $("#btnNew").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDelete").removeAttr("disabled");
}
function AssignTerminalToGroup(values) {
    var groupId = ddlTerminalGrpNr.GetValue();
    if (parseInt(groupId) === 0 || parseInt(groupId) < 1) {
        alert("Ausgewählte Gruppe");
        return;
    }
    else {

    }
}
function OnNewMapping_CallBack(result) {
    if (result === true) {
        alert("Gruppennummer alredy vorhanden");
        return
    }
    else {
        var groupId = ddlTerminalGrpNr.GetValue();
        var groupNr = $("#txtTerminalGrpNr").val();
        var groupDescritption = $("#txtGroupDescription").val();
        PageMethods.SaveTerminalGroup(groupId, groupNr, groupDescritption, terminals, OnSaveNewMap_CallBack)

    }
}
function OnSaveNewMap_CallBack(response) {
    var id = response.ID;
    //setTimeout(function () {
    //    $("#ddlTerminalGrpNr").append($('<option></option>').val(response.ID).html(response.GroupNr));
    //    $("#ddlTerminalDescription").append($('<option></option>').val(response.ID).html(response.GroupDescription));

    //    $("#ddlTerminalGrpNr").val(response.ID);
    //    $("#ddlTerminalDescription").val(response.ID);

    //    $("#txtTerminalGrpNr").val(response.GroupNr);
    //    $("#txtGroupDescription").val(response.GroupDescription);
    //}, 500)

    ddlTerminalGrpNr.PerformCallback(id);
    ddlTerminalDescription.PerformCallback(id);
    grdMappedTerminals.PerformCallback(id);
    if (allowZUTEdit) $("#btnNew").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDelete").removeAttr("disabled");
}

//delete confirmation
function ConfirmDelete(message) {
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk" type="button"  onclick="DeleteTerminalGroup(); return false;"></button><button id="btnNo" type="button"  onclick="resetDefault()"></button><button id="btnCancel" type="button"  onclick="resetDefault()"></button></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnNo').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);

}
function resetDefault() {
    document.getElementById('importantDialog').innerHTML = "";

}
function DeleteTerminalGroup() {
    resetDefault();
    var groupId = ddlTerminalGrpNr.GetValue();
    PageMethods.DeleteGroup(groupId, Delete_CallBack);
    //$("#ddlTerminalGrpNr option:selected").remove();
    //$('#ddlTerminalDescription option:selected').remove();
    //$("#ddlTerminalGrpNr").val(0);
    //$("#ddlTerminalDescription").val(0);
    var id = "0";
    ddlTerminalGrpNr.PerformCallback(id);
    ddlTerminalDescription.PerformCallback(id);
    $("#txtTerminalGrpNr").val("");
    $("#txtGroupDescription").val("");
}
function Delete_CallBack() {
    grdMappedTerminals.PerformCallback(0);
    grdTerminalInstances.PerformCallback();
}
function ConfirmUnmapTerminal(message) {
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk" type="button"  onclick=" RemoveMappedTerminal()"></button><button id="btnNo" type="button"  onclick="resetDefault()"></button></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnNo').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);

}
function RemoveMappedTerminal() {
    document.getElementById('importantDialog').innerHTML = "";
    var index = grdMappedTerminals.GetFocusedRowIndex();
    var terminalInstanceId = grdMappedTerminals.GetRowKey(index);
    var groupId = ddlTerminalGrpNr.GetValue();
    if (parseInt(groupId) === 0) {
        return;
    }
    PageMethods.UnMapSeletedTerminal(groupId, terminalInstanceId, OnDeleteUmap_CallBack)

}
function OnDeleteUmap_CallBack() {
    var groupId = ddlTerminalGrpNr.GetValue();
    grdMappedTerminals.PerformCallback(groupId);
    grdTerminalInstances.PerformCallback();
}
function CallSaveDialog(message) {
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk" type="button"  onclick="SaveChangesOnBack()"></button><button id="btnNo" type="button"  onclick="RedirectToIndex()"></button><button id="btnCancel" type="button"  onclick="resetDefault()"></button></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnNo').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);
}
function SaveChangesOnBack() {
    document.getElementById('importantDialog').innerHTML = "";

    var groupId = ddlTerminalGrpNr.GetValue();

    if (parseInt(groupId) === 0 && $("#txtTerminalGrpNr").val().length < 1) {
        alert("Wählen Sie eine Gruppe");
        return;
    }
    if (parseInt(groupId) === 0 && $("#txtTerminalGrpNr").val().length > 0) {

        var groupNr = $("#txtTerminalGrpNr").val();

        PageMethods.GroupNrExists(groupNr, OnNewBackMapping_CallBack);

    }
    else if (parseInt(groupId) > 0 && $("#txtTerminalGrpNr").val().length > 0) {
        var groupId = ddlTerminalGrpNr.GetValue();
        var groupNr = $("#txtTerminalGrpNr").val();
        var groupDescritption = $("#txtGroupDescription").val();
        PageMethods.SaveTerminalGroup(groupId, groupNr, groupDescritption, terminals, OnSaveNewEditBackMap_CallBack);
    }
}
function RedirectToIndex() {
    document.getElementById('importantDialog').innerHTML = "";
    window.location.href = "/Index.aspx";
}
function OnNewBackMapping_CallBack(result) {
    if (result === true) {
        alert("Gruppennummer alredy vorhanden");
        return
    }
    else {
        var groupId = ddlTerminalGrpNr.GetValue();
        var groupNr = $("#txtTerminalGrpNr").val();
        var groupDescritption = $("#txtGroupDescription").val();
        PageMethods.SaveTerminalGroup(groupId, groupNr, groupDescritption, terminals, OnSaveNewEditBackMap_CallBack)

    }
}
function OnSaveNewEditBackMap_CallBack() {
    window.location.href = "/Index.aspx";
}
function OnBackMapping_CallBack() {
    window.location.href = "/Index.aspx";
}

function showAllTerminals() {

    $('.contMid,.contFooter,.rightDvns').hide();
    $('.searchTerminals').show();
}

function grdSearchTerminalsRowDblClick(s, e) {
    window.grdSearchTerminals.GetRowValues(e.visibleIndex, "ID;GroupNr;GroupDescription", GetSelectedTeminal);

    $('.contMid,.contFooter,.rightDvns').show();
    $('.searchTerminals').hide();

}

function GetSelectedTeminal(values) {
    var termID = values[0].toString();
    var termGroupNr = values[1].toString();
    var termDescription = values[2].toString();

    ddlTerminalGrpNr.SetValue(termID);
    ddlTerminalDescription.SetValue(termID);
    $("#txtTerminalGrpNr").val(termGroupNr);
    $("#txtGroupDescription").val(termDescription);

    grdMappedTerminals.PerformCallback(termID);
    grdTerminalInstances.PerformCallback(termID);

}
function ddlTerminalGrpNr_SelectedIndexChanged() {
    selectionChanged = true;
    saveChanges = false;
    if (ddlTerminalGrpNr.GetValue() !== "0") {
        ddlTerminalDescription.SetValue(ddlTerminalGrpNr.GetValue());
        $("#txtTerminalGrpNr").val(ddlTerminalGrpNr.GetText());
        $("#txtGroupDescription").val(ddlTerminalDescription.GetText());
    }
    else {
        ddlTerminalDescription.SetValue(ddlTerminalGrpNr.GetValue());
        $("#txtTerminalGrpNr").val("");
        $("#txtGroupDescription").val("");
    }
    var groupId = Number(ddlTerminalGrpNr.GetValue());

    if (groupId === NaN) {
        groupId = 0;
    }

    grdMappedTerminals.PerformCallback(groupId);
    grdTerminalInstances.PerformCallback();
    if (allowZUTEdit) $("#btnNew").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSave").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDelete").removeAttr("disabled");
}
function ddlTerminalDescription_SelectedIndexChanged() {
    selectionChanged = true;
    saveChanges = false;
    if (ddlTerminalDescription.GetValue() !== "0") {
        ddlTerminalGrpNr.SetValue(ddlTerminalDescription.GetValue());
        $("#txtTerminalGrpNr").val(ddlTerminalGrpNr.GetText());
        $("#txtGroupDescription").val(ddlTerminalDescription.GetText());
    }
    else {
        ddlTerminalGrpNr.SetValue(ddlTerminalDescription.GetValue());
        $("#txtTerminalGrpNr").val("");
        $("#txtGroupDescription").val("");
    }
    var groupId = Number(ddlTerminalDescription.GetValue());

    if (groupId === NaN) {
        groupId = 0;
    }

    grdMappedTerminals.PerformCallback(groupId);
    grdTerminalInstances.PerformCallback();
    if (allowZUTEdit) $("#btnNew").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSave").removeAttr("disabled");
    if (allowZUTEdit) $("#btnDelete").removeAttr("disabled");
}

function showLoadingPanel(messageText) {
    LoadingPanel.SetText(messageText);
    LoadingPanel.Show();
}