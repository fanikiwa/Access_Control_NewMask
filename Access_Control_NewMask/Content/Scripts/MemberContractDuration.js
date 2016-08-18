var levelCaption = "";
var isBack = false;
$(function () {
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        var editStatus = JSON.stringify(grdContractDurtaion.batchEditHelper.updatedValues) == "{}";
        if (editStatus == false && allowZUTEdit) {
            ConfirmSave();
        }
        else {
            var id = 0;
            var index = grdContractDurtaion.GetFocusedRowIndex();
            if (index >= 0) {
                var value = grdContractDurtaion.GetRowKey(index);
                if (parseInt(value) > 0) {
                    id = value;
                }
            }
            PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
        }

    });
    $("#btnsave").click(function (evt) {
        evt.preventDefault();
        grdContractDurtaion.UpdateEdit();
    });
    $("#btnnew").click(function (evt) {
        evt.preventDefault();

    });
    $("#btnapply").click(function (evt) {
        evt.preventDefault();
        var editStatus = JSON.stringify(grdContractDurtaion.batchEditHelper.updatedValues) == "{}";
        if (editStatus == false) {
            ConfirmSave();
        }
        else {
            var id = 0;
            var index = grdContractDurtaion.GetFocusedRowIndex();
            if (index >= 0) {
                var value = grdContractDurtaion.GetRowKey(index);
                if (parseInt(value) > 0) {
                    id = value;
                }
            }
            PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
        }
        //var id = 0;
        //var index = grdContractDurtaion.GetFocusedRowIndex();
        //if (index >= 0) {
        //    var value = grdContractDurtaion.GetRowKey(index);
        //    if (parseInt(value) > 0) {
        //        id = value;
        //    }
        //}
        //PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
    });
    $("#btnDelete").click(function (evt) {
        evt.preventDefault();
        ConfirmDelete();
    });
});
function _DeleteDuration(id) {
    PageMethods.DeleteDuration(id, OnDeleteDuration_CallBack)
}
function OnDeleteDuration_CallBack() {
    grdContractDurtaion.PerformCallback();
}
function OnCheckForRedirect_CallBack(url) {
    document.location.href = url;
}
function activeCheckedChanged(sender, evt) {
    var _senderGrd = grdContractDurtaion;
    var currentRowNum = -1;
    try { currentRowNum = $(sender.mainElement).parents("tr")[0].rowIndex - 1 } catch (e) { }
    var checkedClass = 'dxWeb_edtCheckBoxChecked_Office2003Blue'; var uncheckedClass = 'dxWeb_edtCheckBoxUnchecked_Office2003Blue';
    var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var uncheckUpdateValueText = '<span class="dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var checkLogicalCellNr = 3;

    for (var rowCount = 0;rowCount < _senderGrd.keys.length;rowCount++) {
        var checked = false;
        var chkNode = !_senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[2].childNodes[0] : _senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0];

        var chkClassName = chkNode.className;
        if (rowCount != currentRowNum) {
            _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, false, uncheckUpdateValueText);

            try {
                chkNode.className = chkClassName.replace(checkedClass, uncheckedClass);

            } catch (e) { }
        }
    }
}
//dialogs
//function ConfirmDelete() {
//    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
//    //var message = levelCaption;
//    var message = "Sind Sie sicher, dass Sie löschen möchten";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Delete_Confirmed()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function ConfirmDelete() {
    var message = "Sind Sie sicher das Sie das Vertragsdauer tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 30%; margin-right: 0px;"  onclick="Delete_Confirmed()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitContractDuratinDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelContractDurationDeletion");
    $('#btnCancel').text(levelCaption);
}

function CancelOnBackButton() {
    HideDialog();
}
function HideDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}
function No_OnBack() {
    HideDialog();
    var id = 0;
    var index = grdContractDurtaion.GetFocusedRowIndex();
    if (index >= 0) {
        var value = grdContractDurtaion.GetRowKey(index);
        if (parseInt(value) > 0) {
            id = value;
        }
    }
    PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
}
//end dialogs
function Delete_Confirmed() {
    HideDialog();
    var index = grdContractDurtaion.GetFocusedRowIndex();
    if (index >= 0) {
        var id = grdContractDurtaion.GetRowKey(index);
        if (parseInt(id) > 0) {
            _DeleteDuration(id);
        }
    }
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "MemberContractDuration.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
function ConfirmSave() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 35%;width: 133px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
    //getLocalizedText("cancel");
    //$('#btnCancel').text(levelCaption);
}
function SaveOnBack() {
    HideDialog();
    grdContractDurtaion.UpdateEdit();
    isBack = true;
    //setTimeout(function () {
    //    var id = 0;
    //    var index = grdContractDurtaion.GetFocusedRowIndex();
    //    if (index >= 0) {
    //        var value = grdContractDurtaion.GetRowKey(index);
    //        if (parseInt(value) > 0) {
    //            id = value;
    //        }
    //    }
    //    PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
    //}, 1000);
    //RedirectFunction();
}
function RedirectFunction() {
    var id = 0;
    var index = grdContractDurtaion.GetFocusedRowIndex();
    if (index >= 0) {
        var value = grdContractDurtaion.GetRowKey(index);
        if (parseInt(value) > 0) {
            id = value;
        }
    }
    PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
}
function grdContractDurtaionEndCallBack(s, e) {

    if (isBack === true) {
        var id = 0;
        var index = grdContractDurtaion.GetFocusedRowIndex();
        if (index >= 0) {
            var value = grdContractDurtaion.GetRowKey(index);
            if (parseInt(value) > 0) {
                id = value;
            }
        }
        PageMethods.RidirectUrl(id, OnCheckForRedirect_CallBack);
    }
}