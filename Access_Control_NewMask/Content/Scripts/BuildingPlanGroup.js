var levelCaption;

$(function () {
    $("#txtGroupNo").change(function () {
        $("#hiddenFieldDetectChanges").val("1");
    });

    $("#txtGroupName").change(function () {
        $("#hiddenFieldDetectChanges").val("1");
    });

    $("#txtMemo").change(function () {
        $("#hiddenFieldDetectChanges").val("1");
    });

    //$('#btnDelete').on("click", function (e) {
    //    e.preventDefault();
    //    if (parseInt(cboGroupNr.GetValue()) > 0) {
    //        ConfirmDelete();
    //    }
    //});
    $('.numbersOnly').keyup(function () {
        this.value = this.value.replace(/[^0-9\.]/g, '');
    });
});

function ImportantInfoDialogPrompt(title, message) {
    var boxContent = "<div id=\"overlay\"><div id=\"box_flame\">" +
        "<div id=\"dialogBox\">  " + "<br/> " +
        title + "<img src=\"../../Images/FormImages/greeninfo-01.png\" alt=\"Stop\" class=\"greeninfo\" height=\"50\" width=\"50\"  align=\"right\"> <br/>" +
        "<div id=\"dialogBox2\">  " + "<br/> <br/> <br/> <br/>" +
     message + "<br/> " +
        "<button id=\"btnOk\"  onclick=\"resetImportantInfoDialogDiv()\"></button>" +
        "</div></div></div>";
    document.getElementById("importantInfoDialog").innerHTML = boxContent;
    getLocalizedText("yes");
    $("#btnOk").text(levelCaption);
}

function resetImportantInfoDialogDiv() {
    document.getElementById("importantInfoDialog").innerHTML = "";
    $("#cboGroupNo").focus();
    cboGroupNo.PerformCallback();
    cboGroupDescription.PerformCallback();
}
function ResetDialogue() {
    document.getElementById("importantInfoDialog").innerHTML = "";
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "BuildingPlanGroup.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function DeleteBuildingPlanGroup() {
    var id = cboGroupNo.GetValue();
    var parameters = { id: id };
    $.ajax({
        type: "POST",
        async: false,
        url: "BuildingPlanGroup.aspx/DeleteBuildingPlanGroup",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(parameters),
        success: function (result) {
            var accessPlan = result.d;
        }
    });
    // $("#hiddenFieldFormMode").attr("value", "4");
    $("#hiddenFieldFormMode").val("4");
    window.location.replace = "BuildingPlanGroup.aspx";
}

function DeleteButtonConfirm() {
    var message = "Sind Sie sicher das Sie das Gebäudeplan-Gruppe tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialogue(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 12%; margin-right: 0px;"  onclick="DeleteBuildingPlanGroup()"></button><button id="btnCancel"  onclick="ResetDialogue(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("permitBuildingPlanGroupDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelBuildingPlanGroupDeletion");
    $('#btnCancel').text(levelCaption);
}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();
    //cboGroupNo.PerformCallback();
    //cboGroupDescription.PerformCallback();
}

function BackButtonConfirm() {
    // var message = "Willst du die Änderungen speichern";
    getLocalizedText("saveWarning");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialogue(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 30%;width: 155px; margin-right: 8px;"  onclick="SaveBuildingPlanGroup()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}

function SaveBuildingPlanGroup() {
    // var id = cboGroupNo.GetValue(); 
    var accessGroupNumber = $("#txtGroupNo").val();
    var accessGroupName = $("#txtGroupName").val();
    var accessGroupMemo = $("#txtMemo").val();
    var id = 0;
    if (!isNaN(parseInt(cboGroupNo.GetValue()))) {
        id = parseInt(cboGroupNo.GetValue());
    }
    var parameters = "";
    var postUrl = "";

    var mode = $("#hiddenFieldDetectChanges").val();
    if (id === "" || id === 0) {
        postUrl = "BuildingPlanGroup.aspx/CreateBuildingPlanGroup";
        parameters = { accessGroupNumber: accessGroupNumber, accessGroupName: accessGroupName, accessGroupMemo: accessGroupMemo };
    } else {
        postUrl = "BuildingPlanGroup.aspx/EditBuildingPlanGroup";
        parameters = { Id: id, accessGroupNumber: accessGroupNumber, accessGroupName: accessGroupName, accessGroupMemo: accessGroupMemo };
    }
    //  $("#hiddenFieldFormMode").attr("value", "4");
    $("#hiddenFieldFormMode").val("4");
    $.ajax({
        type: "POST",
        async: false,
        url: postUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(parameters),
        success: function (result) {
            var accessPlan = result.d;
            $("#hiddenFieldDetectChanges").val("0");
        }
    });
    // window.location.href = "Settings.aspx";
    CancelOnBackButton();
}

function CancelOnBackButton() {
    resetImportantInfoDialogDiv();
    window.location.href = "Settings.aspx";
}
$(function () {
    getLocalizedText("group");
    $("#PageTitleLbl2").text(levelCaption);
})

function BuildingPlanGroupNumberSelectionChange(value) {
    cboGroupDescription.SetValue(value);
    SetControlValues(value);
}


function BuildingPlanGroupDescriptionSelectionChange(value) {
    cboGroupNo.SetValue(value);
    SetControlValues(value);
}

function DirectToSettings() {
    window.location.href = "Settings.aspx";
}

function SetControlValues(value) {
    PageMethods.GetBuildingPlandGroupById(value, Setcontrols);
}
function Setcontrols(Responce) {
    if (Responce.Id !== null && Responce.Id !== 0) {
        cboGroupNo.SetValue(Responce.Id);
        cboGroupDescription.SetValue(Responce.Id);

        $("#txtGroupNo").val(Responce.AccessGroupNumber);
        $("#txtGroupName").val(Responce.AccessGroupName);
        $("#txtMemo").val(Responce.Memo);
    } else {
        $("#txtGroupNo").val("");
        $("#txtGroupName").val("");
        $("#txtMemo").val("");
    }
}


//function ConfirmDelete() {
//    getLocalizedText("deleteSportsGroupWarning");
//    var message = levelCaption;
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Delete_BuildingPlanGroup()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantInfoDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

//function Delete_BuildingPlanGroup() {
//    resetDefault();
//    var grp = cboGroupNo.GetValue();
//    if (grp != 0) {
//        PageMethods.DeleteBuildingPlandGroup(grp, ReloadPage); 
//    } 
//}

//function resetDefault() {
//    document.getElementById('importantInfoDialog').innerHTML = "";
//}