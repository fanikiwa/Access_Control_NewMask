
var levelCaption = "";
var terminalId = 0;
var url1 = "";
var isDdlClick = false;
//var _updatedValue;
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AssignReader.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

$(function () {
    getLocalizedText("readerAssignment");
    $('#PageTitleLbl2').text(levelCaption);

    $("#btnTake").click(function (evt) {
        evt.preventDefault();
        grdReaders.UpdateEdit();
    });
    $("#ImageButtonTermConfig").click(function (evt) {
        evt.preventDefault();
       
    });
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        var editStatus = JSON.stringify(grdReaders.batchEditHelper.updatedValues) == "{}";
        if (editStatus == false) {
            ConfirmSave();
        }
        else {
            window.location.href = "/Content/Gebaudeplan.aspx";
        }

    });
    $("#chkShowAll").click(function () {
        if ($("#chkShowAll")[0].checked === true) {
            var id = "0";
            ddlTerminalId.SetValue(id);
            ddlTerminalDescription.SetValue(id);
            ddlTerminalControlUnit.SetValue(id);
            grdReaders.PerformCallback(id);
            $("#btnTerminalInfo").attr("disabled", "disabled");
        }
        else if ($("#chkShowAll")[0].checked === false) {
            grdReaders.PerformCallback(id);
        }
    });
    $("#btnTerminalPrevious").click(function (evt) {
        evt.preventDefault();
        var seletcedIndex = ddlTerminalId.GetSelectedIndex();
        $("#chkShowAll")[0].checked = false;
        if (seletcedIndex > 0) {
            ddlTerminalId.SetSelectedIndex(seletcedIndex - 1);
            ddlTerminalControlUnit.SetSelectedIndex(seletcedIndex - 1);
            ddlTerminalDescription.SetSelectedIndex(seletcedIndex - 1);
            $("#txtSelectedTerminal").val(ddlTerminalId.GetText());
            grdReaders.PerformCallback(ddlTerminalId.GetValue());
        }
    });
    $("#btnTerminalNext").click(function (evt) {
        evt.preventDefault();
        var maxmumIndex = ddlTerminalId.GetItemCount();
        var seletcedIndex = ddlTerminalId.GetSelectedIndex();
        $("#chkShowAll")[0].checked = false;
        if (seletcedIndex < maxmumIndex - 1) {
            ddlTerminalId.SetSelectedIndex(seletcedIndex + 1);
            ddlTerminalControlUnit.SetSelectedIndex(seletcedIndex + 1);
            ddlTerminalDescription.SetSelectedIndex(seletcedIndex + 1);
            $("#txtSelectedTerminal").val(ddlTerminalId.GetText());
            grdReaders.PerformCallback(ddlTerminalId.GetValue());
        }
    });
});


function showTerminalInfo(s, e) {
    var rownum = e.visibleIndex;
    var btnID = e.buttonID;
    if (btnID == "terminalInfo") {
        var terminalNumber = grdReaders.GetRow(rownum).cells[0].textContent;
        var data = { terminalNumber: terminalNumber };

        $.ajax({
            type: "POST",
            async: false,
            url: "AssignReader.aspx/GetTerminalID",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function () {
                window.location.href = "BuildingPlanTermInfo.aspx";
            }
        });
    }
    else {

    }

}

function showTerminalInfoDoor(s, e) {
    var rownum = e.visibleIndex;
    var btnID = e.buttonID;
    if (btnID == "terminalInfoGrdDoorDetails") {
        var terminalNumber = grdDoorDetails.GetRow(rownum).cells[0].textContent;
        var data = { terminalNumber: terminalNumber };

        $.ajax({
            type: "POST",
            async: false,
            url: "AssignReader.aspx/redirect_to_datafox",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function (result) {
                url1 = result.d;
                window.location = result.d;
                //url1 = result.d;
                //window.location.href = "http://192.168.98.222:150/Content/Datafox.aspx?id=10";
                //window.location.href = "http://192.168.98.222:150/Content/Datafox.aspx";
            }
        });
    }

}


$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
})
function showDoorProfilesInfo(s, e) {
    var i = 6;
    var rownum = e.visibleIndex;
    var buttonID = e.buttonID;
    if (buttonID == "doorPointer") return;
    GetTerminalId(rownum);
    $.ajax({
        type: "POST",
        async: false,
        url: "AssignReader.aspx/PassPageOrigin",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            if (buttonID == "AccessProfileInfo") {

                window.location.href = "BuildingPlanTermInfoAccessProfile.aspx";
            }
            else if (buttonID == "SwitchProfileInfo") {
                window.location.href = "BuildingPlanTermInfoSwitchProfile.aspx";
            }
        }
    });

}
function GetTerminalId(rowNumber) {
    var rownum = rowNumber;
    var terminalNumber = grdDoorDetails.GetRow(rownum).cells[0].textContent;
    var terminalID = 0;
    if (terminalNumber > 0) {
        terminalID = terminalNumber;
    }
    else {
        terminalID = 0;
    }
    var data = { terminalNumber: terminalID };

    $.ajax({
        type: "POST",
        async: false,
        url: "AssignReader.aspx/GetTerminalID",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            terminalId = result.d;
        }
    });

}
function ConfirmSave() {
    getLocalizedText("saveChangesConfirmation");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk"  onclick="SaveChangesRedirect()"></button><button id="btnNo"  onclick="BackToBuildingPlan()"></button><button id="btnCancel"  onclick="resetAssignReder()"></button></div></div></div>';
    document.getElementById('confirmSave').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnNo').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);

}
function BackToBuildingPlan() {
    resetAssignReder();
    window.location.href = "/Content/Gebaudeplan.aspx";
}
function SaveChangesRedirect() {
    resetAssignReder();
    grdReaders.UpdateEdit();
    setTimeout(function () { window.location.href = "/Content/Gebaudeplan.aspx" }, 500);
    window.location.href = "/Content/Gebaudeplan.aspx";
}
function resetAssignReder() {
    document.getElementById('confirmSave').innerHTML = "";

}
function ExpandOrCollapseDetailsRow(s, e) {
    ExpandOrCollapseDetailsRowProcedure(s, e);
}
function OnSelectionChanged(s, e) {
    ExpandOrCollapseDetailsRowProcedure(s, e);
}
function ExpandOrCollapseDetailsRowProcedure(s, e) {
    var expanded = !!s.cpVisibleDetails[e.visibleIndex];
    if (expanded == true)
        s.CollapseDetailRow(e.visibleIndex);
    else
        s.ExpandDetailRow(e.visibleIndex);
}
function terminalSelectedChanged(s, e) {
    if (isDdlClick === true) {
        isDdlClick = false;
        var id = s.GetValue();
        ddlTerminalId.SetValue(id);
        ddlTerminalDescription.SetValue(id);
        ddlTerminalControlUnit.SetValue(id);
        grdReaders.PerformCallback(id);
        $("#chkShowAll")[0].checked = false;
        $("#btnTerminalInfo").removeAttr("disabled");
    }
   
}
function dropdownClicked(s, e) {
    isDdlClick = true;
}