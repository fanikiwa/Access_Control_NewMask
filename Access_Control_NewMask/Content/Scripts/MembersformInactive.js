var levelCaption = "";
var _memberClick = false;
var groupClick = false;
var saveChanges = false;
var backSatus = 0;

$(function () {
    $('#btnSave').on("click", function (e) {
        e.preventDefault();
        var memberId = parseInt(cobMemberNr.GetValue());
        if (memberId > 0) {
            SaveMemberDynamicInfo();
        }
    });
    $('#btnDelete').on("click", function (e) {
        e.preventDefault();
        ConfirmDelete();
    });
    $('#btnNew').on("click", function (e) {
        e.preventDefault();
        ClearControls();
    });
    $('#btnSearchAllEmp').on("click", function (e) {
        e.preventDefault();
        $("#tabcontroldiv").hide();
        $("#uppersec").hide();
        $("#searchgrid").show();
        backSatus = 1;
    });
    $("#btnApplyMember").click(function (evt) {
        evt.preventDefault();
        BindSerchValues();
    });
    $("#fvNavPrev").click(function (evt) {
        evt.preventDefault();
        var currentIndex = parseInt(cobMemberNr.GetSelectedIndex());
        var nxtIndex = currentIndex - 1;
        if (nxtIndex === 0) return;
        cobMemberNr.SetSelectedIndex(nxtIndex);
        cobMemberName.SetSelectedIndex(nxtIndex);
        //$("#txtFvCurrentEntry").val(nxtIndex);
        PageMethods.GetMemberDynamicFields(cobMemberNr.GetValue(), DisplayDynamicFieldValues);

        //var Current = cobMemberNr.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);
        //var count = parseInt(cobMemberNr.GetItemCount()) - 1;
        //$("#txtFvTotalEntries").val(count);
        CountPersonal();

    });

    $("#fvNavNext").click(function (evt) {
        evt.preventDefault();
        var maxIndex = parseInt(cobMemberNr.GetItemCount());
        var currentIndex = parseInt(cobMemberNr.GetSelectedIndex());
        var nxtIndex = currentIndex + 1;
        if (nxtIndex <= (maxIndex - 1)) {
            cobMemberNr.SetSelectedIndex(nxtIndex);
            cobMemberName.SetSelectedIndex(nxtIndex);
            //$("#txtFvCurrentEntry").val(nxtIndex);
            PageMethods.GetMemberDynamicFields(cobMemberNr.GetValue(), DisplayDynamicFieldValues);
        }

        //var Current = cobMemberNr.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);
        //var count = parseInt(cobMemberNr.GetItemCount()) - 1;
        //$("#txtFvTotalEntries").val(count);
        CountPersonal();
    });

    $('#btnPERSDOC').on("click", function (e) {
        e.preventDefault();
        var memberId = parseInt(cobMemberNr.GetValue());
        if (memberId > 0) {
            document.location.href = "/Content/MembersDocumenteInactive.aspx?Id=" + cobMemberNr.GetValue();
        } else {
            document.location.href = "/Content/MembersDocumenteInactive.aspx?Id=" + 0;
        }

    });

    $('#btnPersonalStamm').on("click", function (e) {
        e.preventDefault();
        var memberId = parseInt(cobMemberNr.GetValue());
        document.location.href = "/Content/MembersInactive.aspx?Id=" + cobMemberNr.GetValue();
    });

    $('#btnBack').on("click", function (e) {
        e.preventDefault();
        if (backSatus === 1) {
            $("#tabcontroldiv").show();
            $("#uppersec").show();
            $("#searchgrid").hide();
            backSatus = 0;
        }
        else {
            if (saveChanges === true && allowZUTEdit) {
                BackButtonConfirm();
            }
            else {
                var memberId = parseInt(cobMemberNr.GetValue());
                document.location.href = "/Content/MembersInactive.aspx?Id=" + cobMemberNr.GetValue();
            }
        }
    });

    $("input, select").change(function () {
        saveChanges = true;
    });

});

function CountPersonal() {
    try {
        var persCount = cobMemberNr.GetItemCount();
        var hasKeine = cobMemberNr.FindItemByValue(0) != null;
        persCount = persCount - (hasKeine ? 1 : 0) > 0 ? persCount - (hasKeine ? 1 : 0) : 0;
        $("#txtFvTotalEntries").val(persCount);
        var selectedPers = cobMemberNr.GetSelectedIndex();
        selectedPers = selectedPers != -1 ? (hasKeine ? selectedPers : selectedPers + 1) : 0;
        $("#txtFvCurrentEntry").val(selectedPers);
    } catch (e) { console.log(e); }
}

function cobMemberGroupNrIndexChanged(s, e) {
    cobMemberGroupName.SetValue(s.GetValue());
    cobMemberNr.PerformCallback(s.GetValue());
    cobMemberName.PerformCallback(s.GetValue());
    window.setTimeout(function i() {
        ResetMemberGroupComboValueFromCallback(s.GetValue());
    }, 1);
    CountPersonal();
}

function cobMemberGroupNameIndexChanged(s, e) {
    cobMemberGroupNr.SetValue(s.GetValue());
    cobMemberNr.PerformCallback(s.GetValue());
    cobMemberName.PerformCallback(s.GetValue());
    window.setTimeout(function i() {
        ResetMemberGroupComboValueFromCallback(s.GetValue());
    }, 1);
    CountPersonal();
}

function ResetMemberGroupComboValueFromCallback(groupId) {
    cobMemberGroupName.SetValue(groupId);
    cobMemberGroupNr.SetValue(groupId);
    CountPersonal();
}

function cobMemberNameIndexChanged(s, e) {
    cobMemberNr.SetValue(s.GetValue());
    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    PageMethods.GetMemberDynamicFields(s.GetValue(), DisplayDynamicFieldValues);
    CountPersonal();
}

function cobMemberNrIndexChanged(s, e) {
    cobMemberName.SetValue(s.GetValue());
    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    PageMethods.GetMemberDynamicFields(s.GetValue(), DisplayDynamicFieldValues);
    CountPersonal();
}

function redirectPageBackToSettings() {
    window.location.href = "/Content/Settings.aspx";
}

function getDynamicFieldsData() {
    var jsonArray = [];
    var DYNAMIC_FIELD_COUNT = 42

    for (fieldIndex = 1; fieldIndex <= DYNAMIC_FIELD_COUNT; fieldIndex = fieldIndex + 1) {
        jsonArray.push({
            MemberID: cobMemberNr.GetValue(),
            FieldIndex: fieldIndex,
            FieldText: $("#lblF" + fieldIndex).text(),
            FieldValue: $("#txtFF" + fieldIndex).val(),
        });
    }

    return jsonArray;
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "MembersformInactive.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
function SaveMemberDynamicInfo() {
    InitialPageLoadPanel.Show();
    var jsonArrayDynamic = getDynamicFieldsData();
    var jsonStringDynamic = JSON.stringify(jsonArrayDynamic);
    PageMethods.SaveMemberDynamicData(jsonStringDynamic, OnSaveMemberDynamicData_CallBack);
}
function OnSaveMemberDynamicData_CallBack() {
    saveChanges = false;
    InitialPageLoadPanel.Hide();
}
function SaveMemberDynamicInfoOnBack() {
    HideDialog();
    var memberId = parseInt(cobMemberNr.GetValue());
    if (memberId > 0) {
        InitialPageLoadPanel.Show();
        var jsonArrayDynamic = getDynamicFieldsData();
        var jsonStringDynamic = JSON.stringify(jsonArrayDynamic);
        PageMethods.SaveMemberDynamicData(jsonStringDynamic, OnSaveMemberDynamicDataOnBack_CallBack);
    }
    else {
        document.location.href = "/Content/MembersInactive.aspx?Id=" + cobMemberNr.GetValue();
    }

}
function OnSaveMemberDynamicDataOnBack_CallBack() {
    InitialPageLoadPanel.Hide();
    document.location.href = "/Content/MembersInactive.aspx?Id=" + cobMemberNr.GetValue();
}
function DisplayDynamicFieldValues(response) {
    var DYNAMIC_FIELD_COUNT = 42

    for (fieldIndex = 1; fieldIndex <= DYNAMIC_FIELD_COUNT; fieldIndex = fieldIndex + 1) {

        if (response.length >= fieldIndex) {
            var dynamicField = response[fieldIndex - 1];
            $("#lblF" + dynamicField.FieldIndex).text(dynamicField.FieldText);
            $("#txtFF" + dynamicField.FieldIndex).val(dynamicField.FieldValue)
        }
        else {
            $("#lblF" + fieldIndex).text('F' + fieldIndex + '..');
            $("#txtFF" + fieldIndex).val('')
        }
    }
}
function DisplayDataOnLoad(id) {
    PageMethods.GetMemberDynamicFields(id, DisplayDynamicFieldValues);
}

function dpMemberClick(s, e) {
    _memberClick = true;
}
function cobMemberNrEndCallBack(s, e) {
    //$("#txtFvTotalEntries").val(s.GetItemCount() - 1);
    PageMethods.GetMemberDynamicFields(s.GetValue(), DisplayDynamicFieldValues);
    CountPersonal();
}
function cobMemberNameEndCallBack(s, e) {

}

function dplGroupClick(s, e) {
    groupClick = true;
}

function ClearControls() {
    var DYNAMIC_FIELD_COUNT = 42

    for (fieldIndex = 1; fieldIndex <= DYNAMIC_FIELD_COUNT; fieldIndex = fieldIndex + 1) {

        $("#txtFF" + fieldIndex).val('');
    }

}
function ClearDynamicFields() {
    HideDialog();
    ClearControls();
    var memberId = parseInt(cobMemberNr.GetValue());
    if (memberId > 0) {
        SaveMemberDynamicInfo();
    }
}
//dialogs
//function ConfirmDelete() {
//    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
//    //var message = levelCaption;
//    var message = "Sind Sie sicher, dass Sie löschen möchten";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="ClearDynamicFields()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function ConfirmDelete() {
    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
    //var message = levelCaption;
    var message = "Sind Sie sicher das Sie das Zusatzbogen tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 30%; margin-right: 0px;"  onclick="ClearDynamicFields()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitSheetDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelSheetDeletion");
    $('#btnCancel').text(levelCaption);
}

function CancelOnBackButton() {
    HideDialog();
}
function HideDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 35%;width: 135px; margin-right: 0px;"  onclick="SaveMemberDynamicInfoOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
    //getLocalizedText("saveButton");
    //$('#btnOk').text(levelCaption);
    //getLocalizedText("no");
    //$('#btnNo').text(levelCaption);
    //getLocalizedText("cancel");
    //$('#btnCancel').text(levelCaption);
}


//function BackButtonConfirm() {
//    var message = "Willst du die Änderungen speichern";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 45%;width: 100px; margin-right: 0px;"  onclick="SaveMemberDynamicInfoOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("newSaveWarning");
//    $('#btnBackOk').text(levelCaption);
//    getLocalizedText("newNoText");
//    $('#btnNo').text(levelCaption);
//    //getLocalizedText("cancel");
//    //$('#btnCancel').text(levelCaption);
//}
function No_OnBack() {
    HideDialog();
    document.location.href = "/Content/MembersInactive.aspx?Id=" + cobMemberNr.GetValue();
}
//end dialogs
function BindSerchValues() {
    var index = grdSearchMember.GetFocusedRowIndex();
    var id = grdSearchMember.GetRowKey(index);
    if (parseInt(id) > 0) {
        cobMemberNr.SetValue(id);
        cobMemberName.SetValue(id);
        HideSearchGrid();
        //$("#txtFvCurrentEntry").val(cobMemberNr.GetSelectedIndex());
        PageMethods.GetMemberDynamicFields(id, DisplayDynamicFieldValues);
    }
    CountPersonal();
}
function HideSearchGrid() {
    $("#tabcontroldiv").show();
    $("#uppersec").show();
    $("#searchgrid").hide();
    backSatus = 0;
}
function grdSearchMemberRowDbClick(s, e) {
    var index = e.visibleIndex;
    var id = s.GetRowKey(index);
    if (parseInt(id) > 0) {
        cobMemberNr.SetValue(id);
        cobMemberName.SetValue(id);
        HideSearchGrid();
        //$("#txtFvCurrentEntry").val(cobMemberNr.GetSelectedIndex());
        PageMethods.GetMemberDynamicFields(id, DisplayDynamicFieldValues);
    }
    CountPersonal();
}