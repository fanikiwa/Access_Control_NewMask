var levelCaption;

$(function () {
    $("#txtGroupNo").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");
    });

    $("#txtGroupName").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");
    });

    $("#txtMemo").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");
    });
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

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessProfileGroup.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function DeleteAccessProfileGroup() {
    var id = cboGroupNo.GetValue();
    var parameters = { id: id };
    $.ajax({
        type: "POST",
        async: false,
        url: "AccessProfileGroup.aspx/DeleteAccessProfileGroup",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(parameters),
        success: function (result) {
            var accessPlan = result.d;
        }
    });
    $("#hiddenFieldFormMode").attr("value", "4");
    cboGroupNo.SelectIndex(0);
    cboGroupDescription.SelectIndex(0);
    window.location.replace = "AccessProfileGroup.aspx";
}

//function DeleteButtonConfirm() {
//    getLocalizedText("accessProfileDeleteWarning");
//    var message = levelCaption;
//    var boxContent = "<div id=\"overlayDelete\"><div id=\"box_flameDelete\"><div id=\"dialogBoxDelete\">  " +
//        "<img src=\"../../Images/FormImages/stop-save1-01.png\" alt=\"Stop\" class=\"stopPicDelete\" height=\"150\" width=\"150\" align=\"middle\"> <br/>" + message + "<br/> " +
//        "<button id=\"btnOkDelete\"  onclick=\"DeleteAccessProfileGroup()\"></button><button id=\"btnNoDelete\"  onclick=\"CancelOnDeleteButton()\"></button>" +
//        "<button id=\"btnCancelDelete\"  onclick=\"resetImportantInfoDialogDiv()\"></button></div></div></div>";
//    document.getElementById("importantInfoDialog").innerHTML = boxContent;
//    getLocalizedText("yes");
//    $("#btnOkDelete").text(levelCaption);
//    getLocalizedText("no");
//    $("#btnNoDelete").text(levelCaption);
//    getLocalizedText("cancel");
//    $("#btnCancelDelete").text(levelCaption);
//}

function DeleteButtonConfirm() {
    var message = "Sind Sie sicher das Sie das Zutrittsprofil Gruppen tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialogue(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 15%; margin-right: 0px;"  onclick="DeleteAccessProfileGroup()"></button><button id="btnCancel"  onclick="ResetDialogue(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("permitAccesPrfGroupDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelAccPlanGroupDeletion");
    $('#btnCancel').text(levelCaption);
}
 
function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();
}
 
function BackButtonConfirm() {
    getLocalizedText("saveWarning");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialogue(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 30%;width: 155px; margin-right: 8px;"  onclick="SaveAccessProfileGroup()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}


function ResetDialogue() {
    document.getElementById("importantInfoDialog").innerHTML = "";

}
function SaveAccessProfileGroup() {
    //  var id = cboGroupNo.GetValue();
    var accessGroupNumber = $("#txtGroupNo").val();
    var accessGroupName = $("#txtGroupName").val();
    var accessGroupMemo = $("#txtMemo").val();

    var id = 0;
    if (!isNaN(parseInt(cboGroupNo.GetValue()))) {
        id = parseInt(cboGroupNo.GetValue());
    }

    var parameters = "";
    var postUrl = "";
    var mode = $("#hiddenFieldDetectChanges").attr("value");
    if (id == "" || id == "0") {
        postUrl = "AccessProfileGroup.aspx/CreateAccessProfileGroup";
        parameters = { accessGroupNumber: accessGroupNumber, accessGroupName: accessGroupName, accessGroupMemo: accessGroupMemo };
    } else {
        postUrl = "AccessProfileGroup.aspx/EditAccessProfileGroup";
        parameters = { Id: id, accessGroupNumber: accessGroupNumber, accessGroupName: accessGroupName, accessGroupMemo: accessGroupMemo };
    }
    $("#hiddenFieldFormMode").attr("value", "4");

    $.ajax({
        type: "POST",
        async: false,
        url: postUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(parameters),
        success: function (result) {
            var accessPlan = result.d;
            ("#hiddenFieldDetectChanges").attr("value", "0");
        }
    });
    window.location.href = "AccessProfileGroup.aspx";
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





function GroupNumberSelectionChange(value) {
    cboGroupDescription.SetValue(value);
    SetControlValues(value);
}


function GroupDescriptionSelectionChange(value) {
    cboGroupNo.SetValue(value);
    SetControlValues(value);
}

function SetControlValues(value) {
    PageMethods.GetAccessProfileGroupById(value, Setcontrols);
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

