var trainer = "";
var LastMemberValue = -1;
var MemberGroupIndex = -1;
var levelCaption;

var inputChanged = false;

$(document).ready(function () {

    $("#btnSearchEmp").click(function (evt) {
        evt.preventDefault();
        SearchOne();
        trainer = "personHead";
    });
    $("#btnTrainerOne").click(function (evt) {
        evt.preventDefault();
        SearchOne();
        trainer = "trainerOne";
    });
    $("#btnTrainerTwo").click(function (evt) {
        evt.preventDefault();
        SearchOne();
        trainer = "trainerTwo";
    });
    $("#btnTrainerThree").click(function (evt) {
        evt.preventDefault();
        SearchOne();
        trainer = "trainerThree";
    });
    $("#btnTrainerFour").click(function (evt) {
        evt.preventDefault();
        SearchOne();
        trainer = "trainerFour";
    });
    $("#btnTrainerFive").click(function (evt) {
        evt.preventDefault();
        SearchOne();
        trainer = "trainerFive";
    });

    $("#btnApplyPers").click(function (evt) {
        evt.preventDefault();

        var index = grdPersonal.GetFocusedRowIndex();
        if (index > -1) {
            var id = grdPersonal.GetRowKey(index);
            PageMethods.GetPersonalByID(id, OnPersonal_CallBack);
        }
        //var id = grdPersonal.GetRowKey(grdPersonal.GetFocusedRowIndex());
        // window.grdPersonal.GetRowValues(id, "ID;Pers_Nr;FirstName;LastName", GetRowValues2);
        //PageMethods.GetPersonalByID(id, OngrdgrdGroups_CallBack);
        HideAllSearches();
    });

    $("#btnAcceptGroup").click(function (evt) {
        evt.preventDefault();
        var index = grdGroups.GetFocusedRowIndex();
        if (index > -1) {
            var id = grdGroups.GetRowKey(index);
            PageMethods.Getpersonal(id, OngrdgrdGroups_CallBack);
        }
    });

    $("#HiddenField1BackValue").val("0");
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if ($("#HiddenField1BackValue").val() === "0") {
            var saveChanges = $('#hiddenFieldSaveChanges').val();
            if (saveChanges === "1" && allowZUTEdit) {
                BackButtonConfirm();
            }
            else {
                PageMethods.CheckForRedirect(OnCheckForRedirect_CallBack);

            }
        } else if ($("#HiddenField1BackValue").val() === "1") {
            HideAllSearches();
            $("#HiddenField1BackValue").val("0");
        }
    });
    $('#btnNew').on("click", function (e) {
        e.preventDefault();
        clearcontrols();
        setSaveChanges();
    });
    $('#btnSave').on("click", function (e) {
        e.preventDefault();
        var groupNr = $("#txtGroupNr").val();

        if (parseInt(groupNr) < 1 || isNaN($("#txtGroupNr").val())) {
            // alert("Gruppen Nr ist erforderlich!");
            return;
        }
        else {
            cboGroupNr.SetEnabled(true);
            cboGroupDescrptn.SetEnabled(true);
            if (cboGroupNr.GetValue() == 0) {
                PageMethods.CheckIfGroupNrExists(groupNr, OnCheckExists_CallBack);
            } else {
                PageMethods.Isnewrecord(groupNr, SaveMemberGroup());
            }
            inputChanged = false;
            //PageMethods.Isnewrecord(groupNr, SaveMemberGroup());
        }
    });

    $('#btnDelete').on("click", function (e) {
        e.preventDefault();
        if (parseInt(cboGroupNr.GetValue()) > 0) {
            ConfirmDelete();
        }
    });

    $("input, select").change(function () {
        if (cboGroupNr.GetValue() > 0 || cboGroupDescrptn.GetValue() > 0) {
            setSaveChanges();
            inputChanged = true;
        }
    });
});
function ReloadPage(res) {
    ClearControlAfterDelete();
}

function SearchOne() {
    HideDefaultPage();
    $(".searchTwo").hide();
    $(".searchThree").hide();
    $(".searchFour").hide();
    $(".searchFive").hide();
    $(".searchSix").hide();
    $(".searchOne").show();
    if (cboGroupNr.GetValue() > 0 || cboGroupDescrptn.GetValue() > 0 && inputChanged == true) {
        setSaveChanges();
    }

    $("#HiddenField1BackValue").val("1");
}

function HideAllSearches() {
    $(".searchOne").hide();

    DisplayDefaultPage();
    $("#HiddenField1BackValue").val("0");
}

function DisplayDefaultPage() {
    $(".dvnBttm").show();
}

function HideDefaultPage() {
    $(".dvnBttm").hide();
}

function clearcontrols() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
    cboGroupNr.SetValue("0");
    cboGroupDescrptn.SetValue("0");

    document.getElementById('txtGroupDescription').value = "";
    document.getElementById('txtPersonHead').value = "";
    document.getElementById('txtTrainerOne').value = "";
    document.getElementById('txtTrainerTwo').value = "";
    document.getElementById('txtTrainerThree').value = "";
    document.getElementById('txtTrainerFour').value = "";
    document.getElementById('txtTrainerFive').value = "";

    PageMethods.CalculateNextNr(CalculateNextNr_callback)
}

function ClearControlAfterDelete() {

    //cboGroupNr.SetValue("0");
    //cboGroupDescrptn.SetValue("0");
    //cboGroupNr.SetSelectedIndex("0");
    //cboGroupDescrptn.SetSelectedIndex("0");

    $("#txtGroupNr").val("");
    $("#txtGroupDescription").val("");
    $("#txtPersonHead").val("");
    $("#txtTrainerOne").val("");
    $("#txtTrainerTwo").val("");
    $("#txtTrainerThree").val("");
    $("#txtTrainerFour").val("");
    $("#txtTrainerFive").val("");

    cboGroupNr.PerformCallback();
    cboGroupDescrptn.PerformCallback();
    grdGroups.PerformCallback();

}

function CalculateNextNr_callback(succ) {

    document.getElementById('txtGroupNr').value = succ;

    cboGroupNr.SetEnabled(false);
    cboGroupDescrptn.SetEnabled(false);
    $("#txtGroupDescription").focus();

}

function grdPersonalRowDblClick(s, e) {
    MemberGroupIndex = e.MemberGroupIndex;
    window.grdPersonal.GetRowValues(e.visibleIndex, "ID;Pers_Nr;FirstName;LastName", GetRowValues);
    HideAllSearches();

}

function GetRowValues(values) {
    var id = values[0].toString();
    var persNr = values[1].toString();

    var name = values[2] + " " + values[3];
    switch (trainer) {
        case "personHead":
            $("#txtPersonHead").val(name);
            break;
        case "trainerOne":
            $("#txtTrainerOne").val(name);
            break;
        case "trainerTwo":
            $("#txtTrainerTwo").val(name);
            break;
        case "trainerThree":
            $("#txtTrainerThree").val(name);
            break;
        case "trainerFour":
            $("#txtTrainerFour").val(name);
            break;
        case "trainerFive":
            $("#txtTrainerFive").val(name);
            break;
    }
}

function OnPersonal_CallBack(result) {
    if (result.ID !== null && result.ID !== 0) {
        var name = result.FirstName + " " + result.LastName;

        switch (trainer) {
            case "personHead":
                $("#txtPersonHead").val(String.format(name));
                break;
            case "trainerOne":
                $("#txtTrainerOne").val(String.format(name));
                break;
            case "trainerTwo":
                $("#txtTrainerTwo").val(String.format(name));
                break;
            case "trainerThree":
                $("#txtTrainerThree").val(String.format(name));
                break;
            case "trainerFour":
                $("#txtTrainerFour").val(String.format(name));
                break;
            case "trainerFive":
                $("#txtTrainerFive").val(String.format(name));
                break;
        }
    } else {

    }
}

function GetRowValues2(values) {
    var id = values[0].toString();
    var persNr = values[1].toString();
    var name = values[2] + " " + values[3];

    switch (trainer) {
        case "personHead":
            $("#txtPersonHead").val(String.format(name));
            break;
        case "trainerOne":
            $("#txtTrainerOne").val(String.format(name));
            break;
        case "trainerTwo":
            $("#txtTrainerTwo").val(String.format(name));
            break;
        case "trainerThree":
            $("#txtTrainerThree").val(String.format(name));
            break;
        case "trainerFour":
            $("#txtTrainerFour").val(String.format(name));
            break;
        case "trainerFive":
            $("#txtTrainerFive").val(String.format(name));
            break;
    }
}

function OnGetGroup_CallBack(result) {
    if (result !== null) {
        $("#txtGroupNr").val(result.GroupNr);
        $("#txtGroupDescription").val(result.GroupName);
        $("#txtPersonHead").val(result.PersonHead);
        $("#txtTrainerOne").val(result.TrainerOne);
        $("#txtTrainerTwo").val(result.TrainerTwo);
        $("#txtTrainerThree").val(result.TrainerThree);
        $("#txtTrainerFour").val(result.TrainerFour);
        $("#txtTrainerFive").val(result.TrainerFive);
    }
    else {
        $("#txtGroupNr").val("");
        $("#txtGroupDescription").val("");
        $("#txtPersonHead").val("");
        $("#txtTrainerOne").val("");
        $("#txtTrainerTwo").val("");
        $("#txtTrainerThree").val("");
        $("#txtTrainerFour").val("");
        $("#txtTrainerFive").val("");
    }
}


function SetValues(value) {
    PageMethods.Getpersonal(value, Setcontrols);
}

function Setcontrols(Responce) {
    if (Responce.Id !== null && Responce.Id !== 0) {
        cboGroupNr.SetValue(Responce.Id);
        cboGroupDescrptn.SetValue(Responce.Id);

        $("#txtGroupNr").val(Responce.GroupNr);
        $("#txtGroupDescription").val(Responce.GroupName);
        $("#txtPersonHead").val(Responce.PersonHead);
        $("#txtTrainerOne").val(Responce.TrainerOne);
        $("#txtTrainerTwo").val(Responce.TrainerTwo);
        $("#txtTrainerThree").val(Responce.TrainerThree);
        $("#txtTrainerFour").val(Responce.TrainerFour);
        $("#txtTrainerFive").val(Responce.TrainerFive);

    } else {
        $("#txtGroupNr").val("");
        $("#txtGroupDescription").val("");
        $("#txtPersonHead").val("");
        $("#txtTrainerOne").val("");
        $("#txtTrainerTwo").val("");
        $("#txtTrainerThree").val("");
        $("#txtTrainerFour").val("");
        $("#txtTrainerFive").val("");
    }
}


function GetMemberDataFromControls() {
    var jsonArray = [];
    jsonArray.push({
        Id: cboGroupNr.GetValue(),
        GroupNr: $("#txtGroupNr").val(),
        GroupName: $("#txtGroupDescription").val(),
        PersonHead: $("#txtPersonHead").val(),
        TrainerOne: $("#txtTrainerOne").val(),
        TrainerTwo: $("#txtTrainerTwo").val(),
        TrainerThree: $("#txtTrainerThree").val(),
        TrainerFour: $("#txtTrainerFour").val(),
        TrainerFive: $("#txtTrainerFive").val(),
    });
    return jsonArray;
}

function SaveMemberGroup() {
    //removeBorderOnError
    $("#txtGroupNr").addClass('removeBorderOnError');

    var id = cboGroupNr.GetValue();
    var GroupNr = $("#txtGroupNr").val();
    var GroupName = $("#txtGroupDescription").val();
    var PersonHead = $("#txtPersonHead").val();
    var TrainerOne = $("#txtTrainerOne").val();
    var TrainerTwo = $("#txtTrainerTwo").val();
    var TrainerThree = $("#txtTrainerThree").val();
    var TrainerFour = $("#txtTrainerFour").val();
    var TrainerFive = $("#txtTrainerFive").val();
    if (id == null || id == undefined || id == "0") {
        PageMethods.CreateEditMemberGroup(id, GroupNr, GroupName, PersonHead, TrainerOne, TrainerTwo, TrainerThree, TrainerFour, TrainerFive, OnCreateEditMemberGroup_CallBack);
    }
    else {
        var jsonArray = GetMemberDataFromControls();
        var jsonString = JSON.stringify(jsonArray);
        PageMethods.EditMemberGroupInDatabase(jsonString, OnEditMemberGroupInDatabase_CallBack);
    }
}
function OnCheckExists_CallBack(value) {
    if (value === true) {
        // alert("Gruppen Nr. existiert");
        $("#txtGroupNr").focus();
        $("#txtGroupNr").addClass('focusOnError');

        return;
    }
    else {
        var groupNr = $("#txtGroupNr").val();
        PageMethods.Isnewrecord(groupNr, SaveMemberGroup());
    }
}
function OnEditMemberGroupInDatabase_CallBack(response) {
    //cboGroupNr.PerformCallback(response.Id);
    //cboGroupDescrptn.PerformCallback(response.Id);

    resetSaveChanges();
    if (response.Id != null || response.Id != "0") {
        cboGroupNr.PerformCallback(response.Id);
        cboGroupDescrptn.PerformCallback(response.Id);
        cboGroupNr.SetValue(response.Id);
        cboGroupDescrptn.SetValue(response.Id);

        grdGroups.PerformCallback(response.Id);
    }
}

function OnCreateEditMemberGroup_CallBack(result) {
    resetSaveChanges();
    fgt = result.Id;
    fgt1 = result.Id;
    //cboGroupNr.PerformCallback(result.Id);
    //cboGroupDescrptn.PerformCallback(result.Id);

    if (result.Id != null || result.Id != "0") {
        cboGroupNr.PerformCallback(result.Id);
        cboGroupDescrptn.PerformCallback(result.Id);
        cboGroupNr.SetValue(result.Id);
        cboGroupDescrptn.SetValue(result.Id);

        grdGroups.PerformCallback(result.Id);
    }

}

function cboGroupNrSelectedIndexChanged(value) {
    cboGroupNr.SetValue(value);
    cboGroupDescrptn.SetValue(value);
    SetValues(value);
    saveChanges = false;
}

function cboGroupDescrptnSelectedIndexChanged(value) {
    cboGroupNr.SetValue(value);
    cboGroupDescrptn.SetValue(value);
    SetValues(value);
    saveChanges = false;
}

//function BackButtonConfirm() {
//    var message = "Willst du die Änderungen speichern";
//    var box_content = '<div id="overlay"> <div id="box_flame"> <div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose" onclick="resetDefault()" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + ' </div><button id="btnOk" style="margin-left:59%;"  onclick="BacksaveMemberGroup()">  </button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="resetDefault()"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("no");
//    $('#btnNo').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}


function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 15%;width: 210px; margin-right: 0px;"  onclick="BacksaveMemberGroup()"></button><button id="btnNo"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}



function No_OnBack() {
    resetDefault();
    //document.location.href = "/Content/Settings.aspx";
    PageMethods.CheckForRedirect(OnCheckForRedirect_CallBack);
}
function CancelOnBackButton() {
    resetDefault();
    // window.location.href = "/Content/MembersGroup.aspx";
}
function setSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "1");
    saveChanges = true;
}

function BacksaveMemberGroup() {
    resetDefault();
    $("[id$=btnSave]").click();
    //document.location.href = "/Content/Settings.aspx";
    PageMethods.CheckForRedirect(OnCheckForRedirect_CallBack);
}
function resetDefault() {
    document.getElementById('importantDialog').innerHTML = "";
}

function resetSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "MembersGroup.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}


//function ConfirmDelete() {
//    getLocalizedText("deleteSportsGroupWarning");
//    var message = levelCaption;
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Delete_MemberGroup()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function ConfirmDelete() {
    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
    //var message = levelCaption;
    var message = "Sind Sie sicher das Sie das Studio Gruppen tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 27%; margin-right: 0px;"  onclick="Delete_MemberGroup()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitGroupDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelStudioGroupDeletion");
    $('#btnCancel').text(levelCaption);
}

function Delete_MemberGroup() {
    resetDefault();
    var grp = cboGroupNr.GetValue();
    if (grp != 0) {
        PageMethods.DeleteMemberGroup(grp, ReloadPage);

    }

}
var fgt = undefined;
function cboGroupNrEndCallback() {
    if (fgt != undefined) {
        setTimeout(function () {
            cboGroupNr.SetValue(fgt);
            fgt = undefined;
        }, 500);

    }

}
var fgt1 = undefined;
function cboGroupDescriptionEndCallback() {
    if (fgt1 != undefined) {
        setTimeout(function () {
            cboGroupDescrptn.SetValue(fgt1);
            fgt1 = undefined;
        }, 500);

    }
}
function OnCheckForRedirect_CallBack(url) {
    document.location.href = url;
}


function grdGroupsDblClick(s, e) {
    var index = e.visibleIndex;
    if (index > -1) {
        var id = grdGroups.GetRowKey(index);
        PageMethods.Getpersonal(id, OngrdgrdGroups_CallBack);
    }
}

function OngrdgrdGroups_CallBack(result) {
    if (result.GroupNr !== null && result.GroupNr !== 0) {
        cboGroupNr.SetValue(result.Id);
        cboGroupDescrptn.SetValue(result.Id);

        $("#txtGroupNr").val(result.GroupNr);
        $("#txtGroupDescription").val(result.GroupName);
        $("#txtPersonHead").val(result.PersonHead);
        $("#txtTrainerOne").val(result.TrainerOne);
        $("#txtTrainerTwo").val(result.TrainerTwo);
        $("#txtTrainerThree").val(result.TrainerThree);
        $("#txtTrainerFour").val(result.TrainerFour);
        $("#txtTrainerFive").val(result.TrainerFive);

    } else {
        $("#txtGroupNr").val("");
        $("#txtGroupDescription").val("");
        $("#txtPersonHead").val("");
        $("#txtTrainerOne").val("");
        $("#txtTrainerTwo").val("");
        $("#txtTrainerThree").val("");
        $("#txtTrainerFour").val("");
        $("#txtTrainerFive").val("");
    }
}
