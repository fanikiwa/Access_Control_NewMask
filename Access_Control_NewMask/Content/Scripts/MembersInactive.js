﻿var hiddenStatus = 0;
var _memberClick = false;
var grdTranspondersRowNum = -1;
var grdTranspondersSTRowNum = -1;
var saveTransponders = false;
var histUpdate = null;
var groupClick = false;
var levelCaption = "";
var isRedirect = false;
var groupId = "0";
var isEvent = "0";
var isSave = false;
var isbackLongTerm = false;
var isbackShortTerm = false;
var noBatchUpdate = false;
var _applyPhoto = false;
var isDelete = false;
var isCallBackLongTerm = false;
var isCallBackShortTerm = false;
var _URL = window.URL || window.webkitURL;

$(document).ready(function () {

    $("#img").load(function () {
    setImgMargins(this.width, this.height);
});

    var imageurl = $("#img").attr("Src");
    $("#img").attr("Src", imageurl);

    $("#btnMembers").click(function (ev) {
        ev.preventDefault();
    });

    $("#btnHelp").click(function (ev) {
        ev.preventDefault();
    });

    $("#chkWeekpass").click(function () {
        if ($("#chkWeekpass")[0].checked === true) {
            $("#chkDaypass")[0].checked = false;

        }
        else if ($("#chkWeekpass")[0].checked === false) {

        }
    });

    $("#chkDaypass").click(function () {
        if ($("#chkDaypass")[0].checked === true) {
            $("#chkWeekpass")[0].checked = false;

        }
        else if ($("#chkDaypass")[0].checked === false) {

        }
    });

    $("#btnMemberForm").click(function (ev) {
        ev.preventDefault();
        var memberId = parseInt(cobMemberNr.GetValue());
        if (memberId > 0) {
            document.location.href = "/Content/MembersformInactive.aspx?Id=" + cobMemberNr.GetValue();
        } else {
            document.location.href = "/Content/MembersformInactive.aspx?Id=" + 0;
        }
    });

    $("#btnMemberDocs").click(function (ev) {
        ev.preventDefault();
        var memberId = parseInt(cobMemberNr.GetValue());
        if (memberId > 0) {
            document.location.href = "/Content/MembersDocumenteInactive.aspx?Id=" + cobMemberNr.GetValue();
        } else {
            document.location.href = "/Content/MembersDocumenteInactive.aspx?Id=" + 0;
        }
    });

    $("#btnCompany").click(function (evt) {
        evt.preventDefault();
        RedirectMembersGroup();
    });

    $("#btnApplyMember").click(function (evt) {
        evt.preventDefault();
        BindSerchValues();
    });

    $("#btnSearchAllMembers").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 6;
        $("#rightdiv1").hide();
        $("#btnNew").hide();
        $("#btnSave").hide();
        $("#btnDelete").hide();
        $("#searchgrid").show();

    });

    $("#fvNavPrev").click(function (evt) {
        evt.preventDefault();
        var currentIndex = parseInt(cobMemberNr.GetSelectedIndex());
        var nxtIndex = currentIndex - 1;
        if (nxtIndex === 0) return;
        cobMemberNr.SetSelectedIndex(nxtIndex);
        cobMemberName.SetSelectedIndex(nxtIndex);
        //$("#txtFvCurrentEntry").val(nxtIndex);
        PageMethods.GetMemberByID(cobMemberNr.GetValue(), OnGetMemberByID_CallBack);

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
            PageMethods.GetMemberByID(cobMemberNr.GetValue(), OnGetMemberByID_CallBack);
        }

        //var Current = cobMemberNr.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);
        //var count = parseInt(cobMemberNr.GetItemCount()) - 1;
        //$("#txtFvTotalEntries").val(count);
        CountPersonal();
    });

    $("#btnContractDuration").click(function (evt) {
        evt.preventDefault();
        RedirectContactDuration();
    });

    $("#btnTriggerFileUpload").click(function (evt) {
        evt.preventDefault();
        triggerFileUpload();

    });

    $("#btnTakeWebcamPicture").click(function (evt) {
        evt.preventDefault();
        WebcamMode();
        hiddenStatus = 9;
    });

    $("#btnRemovePhoto").click(function (evt) {
        evt.preventDefault();
        //HideWebCam();
        //RemovePhoto();
        ConfirmRemovePhoto();
    });

    $("#btnCancelPhoto").click(function (evt) {
        evt.preventDefault();
        if (hiddenStatus !== 9) {
            HideWebCam();
            hiddenStatus = 0;
        }
    });

    $("#btnTakePhoto").click(function (evt) {
        evt.preventDefault();
        FreezeWebcam();
        _applyPhoto = true;
    });

    $("#btnAccept").click(function (evt) {
        evt.preventDefault();
        AcceptPhoto();
        _applyPhoto = false;
        setSaveChanges();
        if (hiddenStatus !== 9) {
            HideWebCam();
            hiddenStatus = 0;
        }
    });

    $("#btnClearPhoto").click(function (evt) {
        evt.preventDefault();
        //UnFreezeWebcam();
        ConfirmClearPhoto();
    });

    $("#btnSearch").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 3;
        $("#btnNew").hide();
        $("#btnSave").hide();
        $("#btnDelete").hide();
        ShowAccessPlanGrid();
    });

    $("#imgidentity").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 4;
        displaylongtermgrid();
        HideButtons();
    });

    $("#imgSelection").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 5;
        displayshorttimegrid();
        HideButtons();
    });

    $("#btnNewAusweis").click(function (ev) {
        ev.preventDefault();
    });

    $("#btnDeleteAusweis").click(function (ev) {
        ev.preventDefault();
        ConfirmDeleteCard();
    });

    $("#btnNew").click(function (ev) {
        ev.preventDefault();
        SetControlsOnNew();
        setSaveChanges();
        $("#txtSurName").focus();
    });

    $("#btnDelete").click(function (ev) {
        ev.preventDefault();
        ConfirmDelete();

    });

    $("#btnApplyAccessPlan").click(function (ev) {
        ev.preventDefault();
        $("#rightdiv1").show();
        $("#btnNew").show();
        $("#btnSave").show();
        $("#btnDelete").show();
        $("#searchgrid").hide();
        hiddenStatus = 0;
        var index = grdAccessPlan.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            //var id = grdAccessPlan.GetRowKey(index);
            var persID = $("#dpllPersName").val();
            var grpNr = grdAccessPlan.GetRow(index).cells[0].childNodes[0].textContent;
            var groupDescription = grdAccessPlan.GetRow(index).cells[1].childNodes[0].textContent;
            var planNr = grdAccessPlan.GetRow(index).cells[2].childNodes[0].textContent;
            var planDescription = grdAccessPlan.GetRow(index).cells[3].childNodes[0].textContent;
            var persData = { PersID: persID, PlanNo: planNr, PlanDescription: planDescription };
            persData = JSON.stringify(persData);
            $("#txtAccessPlanNr").val(planNr);
            $("#txtAccessPlanName").val(planDescription);
            HideAccessPlanGrid();
            setSaveChanges();
        }
    });

    $("#btnBackToSettings").click(function (evt) {

        evt.preventDefault();
        //$("#transponderInactiveHist").hide();
        if (hiddenStatus !== 0) {

            var editStatus1 = JSON.stringify(grdTransponders.batchEditHelper.updatedValues) !== "{}";
            if (editStatus1 !== false) {
                setSaveChanges();
                isbackLongTerm = true;
            }
            var editStatus2 = JSON.stringify(grdTranspondersShortTerm.batchEditHelper.updatedValues) !== "{}";
            if (editStatus2 !== false) {
                setSaveChanges();
                isbackShortTerm = true;
            }
            if (editStatus1 === true && editStatus2 === true) {
                noBatchUpdate = true;
            }
            var saveChanges = $('#hiddenFieldSaveChanges').val();
            if (parseInt(saveChanges) === 1 && allowZUTEdit) {
                BackButtonConfirm();
            }
            else {
                //window.location.href = "/Index.aspx"
                redirectPageBackToSettings();
            }
            var initdto = JSON.parse(sessionStorage.getItem("memberinactivedto"));
            var currdto = RetrieveDataFromClient();

            //console.log(initdto);
            //console.log(currdto);

            var areObjectsEqual = _.isEqual(initdto, currdto);

            //console.log(areObjectsEqual);

            if (!areObjectsEqual && allowZUTEdit) {
                CornfirmSaveDialog();
            } else {
                redirectPageBackToSettings();
            }
        }
            //else if (hiddenStatus !== 1) {
            //    HideAccessPlanGrid();
            //    hiddenStatus = 0;
            //}
            //else if (hiddenStatus !== 2) {
            //    $("#rightdiv1").show();
            //    $("#rightdiv2").hide();
            //    $("#rightdiv3").hide();
            //    $("#gridSearch").hide();
            //    $("#searchPersData").hide();
            //    hiddenStatus = 0;
            //}
        else if (hiddenStatus !== 3) {
            $("#rightdiv1").show();
            $("#btnNew").show();
            $("#btnSave").show();
            $("#btnDelete").show();
            $("#gridSearch").hide();
            hiddenStatus = 0;
        }
        else if (hiddenStatus !== 4) {
            hidelongtermgrid();
            ShowButtons();
            hiddenStatus = 0;
            setTimeout(function () { GetActiveTransponderNr(); }, 5);
            setTimeout(function () { GetActiveSTTransponderNr(); }, 10);
        }
        else if (hiddenStatus !== 5) {
            hideshorttimegrid();
            ShowButtons();
            hiddenStatus = 0;
            setTimeout(function () { GetActiveTransponderNr(); }, 5);
            setTimeout(function () { GetActiveSTTransponderNr(); }, 10);
        }
        else if (hiddenStatus !== 6) {
            $("#rightdiv1").show();
            $("#btnNew").show();
            $("#btnSave").show();
            $("#btnDelete").show();
            $("#searchgrid").hide();
            hiddenStatus = 0;
        }
        else if (hiddenStatus !== 9) {
            if (_applyPhoto === true) {
                ConfirmApplyPhoto();
            }
            else {
                HideWebCam();
                hiddenStatus = 0;
            }
        }
    });

    $("input, select").change(function () {
        setSaveChanges();
    });

    $('#txtMemo').change(function () { setSaveChanges(); });
    $(":not(#transponderInactiveHist>*)").click(function (ev) {
        if (typeof ev.originalEvent !== 'undefined') {
            if ($(this).is(ev.originalEvent.target)) {
                if (!($(this).parents("#transponderInactiveHist").length > 0) && !($(this)[0].className.indexOf("lnkTransponders") >= 0)) {
                    $("#transponderInactiveHist").hide();
                }
            }
        }
    });

    $('#btnActivateMember').on("click", function (e) {
        e.preventDefault();
        if ($("#txtMemberNr").val().trim() === "" || $("#txtMemberNr").val().trim() === "0") {
            getLocalizedText("noSelection");
            alert(levelCaption);
        } else {
            resetConfirmationDiv();
            save();
            setTimeout(function () { ClearControls(); }, 1);
        }
    });

    $('#btnBackToSettings').click(function (evt) {
        evt.preventDefault();


    });

    StoreDataFromClientInSSession();

    window.setTimeout(function i() {
        RebindMemberInfoCombosOnLoad();
        CountPersonal();
    }, 1);


    $("#btnTriggerFileUpload").hide();
    $("#btnTakeWebcamPicture").hide();
    $("#btnRemovePhoto").hide();

});

function CountPersonal() {
    try {
        var persCount = cobMemberNr.GetItemCount();
        var hasKeine = cobMemberNr.FindItemByValue(0) !== null;
        persCount = persCount - (hasKeine ? 1 : 0) > 0 ? persCount - (hasKeine ? 1 : 0) : 0;
        $("#txtFvTotalEntries").val(persCount);
        var selectedPers = cobMemberNr.GetSelectedIndex();
        selectedPers = selectedPers !== -1 ? (hasKeine ? selectedPers : selectedPers + 1) : 0;
        $("#txtFvCurrentEntry").val(selectedPers);
    } catch (e) { console.log(e); }
}

function save() {

    if (document.getElementById("txtMemberNr").value.length < 1) { return; }

    var dto = new Object();
    var passportData = '';
    var personPhotoInBinary = '';
    dto.MemberNumber = $("#txtMemberNr").val();
    dto.Active = document.getElementById("chkActivateMember").checked;

    var hasimg = document.getElementById("img").hasAttribute("Src");

    if (hasimg) {

        if ($("#img").attr("Src").indexOf('data:image/') > -1) {
            personPhotoInBinary = $("#img").attr("Src").split(",")[1];
        }
        else {
            passportData = $("#img").attr("Src")
        }
    }

    dto.MemberPhoto = passportData;
    dto.PersonPhotoInBinary = personPhotoInBinary;

    StoreDataFromClientInSSession();

    var MemberNoVar = 0;

    try {
        if (!isNaN(parseInt(cobMemberNr.GetValue()))) {
            MemberNoVar = parseInt(cobMemberNr.GetValue());
        }
    } catch (err) {
        console.log(err);
    }

    $("#btnCancel").removeAttr("disabled", "disabled");
    if (MemberNoVar === 0) {
        getLocalizedText("noSelection");
        alert(levelCaption);
    } else {
        PageMethods.UpdateMemberInactiveStatus(dto, function (err) { console.log(err) });
        PageMethods.GetMemberByNr(dto.MemberNumber, SettingComboCallBacks);
    }
}

function SettingComboCallBacks(response) {
    if (response !== null) {
        if (response.ID !== null && response.ID !== 0) {
            isEvent = "1";
            groupId = cobMemberGroupNr.GetValue();
            var _passValue = "0" + ';' + groupId + ';' + isEvent;
            cobMemberNr.PerformCallback(_passValue);
            cobMemberName.PerformCallback(_passValue);
            $("#img").attr("Src", response.MemberPhoto);
        }
    }

    isEvent = "1";
    var groupId = cobMemberGroupNr.GetValue();
    var _passValue = "0" + ';' + groupId + ';' + isEvent;
    cobMemberNr.PerformCallback(_passValue);
    cobMemberName.PerformCallback(_passValue);
    CountPersonal();
}

function RebindMemberInfoCombosOnLoad() {
    isEvent = "1";
    var groupId = cobMemberGroupNr.GetValue();
    var _passValue = "0" + ';' + groupId + ';' + isEvent;
    cobMemberNr.PerformCallback(_passValue);
    cobMemberName.PerformCallback(_passValue);
}

function redirectPageBackToSettings() {
    window.location.href = "/Content/Settings.aspx";
}

function RetrieveDataFromClient() {

    var dto = new Object();
    dto.MemberNumber = $("#txtMemberNr").val();
    dto.Active = document.getElementById("chkActivateMember").checked;

    return dto;
}

function StoreDataFromClientInSSession() {

    var dto = new Object();
    dto.MemberNumber = $("#txtMemberNr").val();
    dto.Active = document.getElementById("chkActivateMember").checked;

    sessionStorage.setItem("memberinactivedto", JSON.stringify(dto));

    var sessiondto = JSON.parse(sessionStorage.getItem("memberinactivedto"));
    //console.log(sessiondto);

    return dto;
}

function resetConfirmationDiv() {
    document.getElementById('confirmDelete').innerHTML = "";
}

function CornfirmSaveDialog() {
    getLocalizedText("saveChangesConfirmation");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"><div id="prompttopclose"><label id="lbltitletop">Zeiterfassung</label><button id="promptbtnclose" onclick="resetConfirmationDiv()" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div><button id="promptButtonok" style="margin-left: 32%; color: forestgreen !important;" onclick="SaveOnBackButton()"></button><button id="btnNo" onclick="CancelOnBackButton()" style="margin-top: 1px; width: 196px;" ></button><button id="btnCancel"  onclick="resetConfirmationDiv()"></button></div></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("save_dialong");
    $('#promptButtonok').text(levelCaption);
    getLocalizedText("no_new");
    $('#btnNo').text(levelCaption);
}

function ConfirmDeleteDialog(message) {
    getLocalizedText("deletepromptpersonal");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"><div id="prompttopclose"><label id="lbltitletop">Zeiterfassung</label><button id="promptbtnclose" onclick="CancelOnDeleteButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div><button id="btnOk" style="margin-left: 33%; margin-right: 0px; color: red !important;" onclick="Delete()"></button><button id="btnCancel" onclick="CancelOnDeleteButton(); return false;" style="position: relative; color: forestgreen !important;"></button></div></div></div></div>';
    document.getElementById("importantInfoDialog").innerHTML = box_content;
    getLocalizedText("acceptdeletepersonal");
    $("#btnOk").text(levelCaption);
    getLocalizedText("no");
    $("#btnNoDelete").text(levelCaption);
    getLocalizedText("canceldeletepersonal");
    $("#btnCancel").text(levelCaption);
}

function SaveOnBackButton() {
    resetConfirmationDiv();
    save();
    redirectPageBackToSettings();
}

function CancelOnBackButton() {
    resetConfirmationDiv();
    redirectPageBackToSettings();
}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();
}

function PopulateControls(response) {
    try {

        ClearControlsNoRecord();

        if (response !== null) {

            if (response.ID !== null && response.ID !== 0) {

                cobMemberNr.SetValue(response.ID.toString());
                cobMemberName.SetValue(response.ID.toString());

                if (response.MemberGroupId !== null) {
                    cobMemberGroup.SetValue(response.MemberGroupId.toString());
                    window.setTimeout(function i() {
                        ResetMemberGroupComboValueFromCallback(response.MemberGroupId.toString());
                    }, 1);
                } else { cobMemberGroup.SelectIndex(0); }
                if (response.Salutation !== null) { cobSalutation.SetValue(response.Salutation.toString()); } else { cobSalutation.SelectIndex(0); }
                if (response.ContractDuration !== null) { cobDuration.SetValue(response.ContractDuration.toString()); } else { cobDuration.SelectIndex(0); }

                $("#txtSurName").val(response.SurName);
                $("#txtFirstName").val(response.FirstName);
                $("#txtStreet").val(response.Street);
                $("#txtStreetNr").val(response.StreetNumber);
                $("#txtPostalCode").val(response.PostalCode);
                $("#txtPhysicalAddress").val(response.Place);
                $("#txtMemberNr").val(response.MemberNumber);
                $("#txtNationality").val(response.Nationality);
                $("#txtProfession").val(response.Profession);
                $("#txtTelephone").val(response.Telephone);
                $("#txtMobileNo").val(response.MobilePhone);
                $("#txtEmail").val(response.Email);
                $("#txtMemo").val(response.Memo);
                $("#txtAccessPlanNr").val(response.AccessPlanNr);
                $("#txtAccessPlanName").val(response.AccessPlanName);
                $("#img").attr("Src", response.MemberPhoto);
                $("#txtAgreementNr").val(response.AgreementNr);
                document.getElementById("chkActivateMember").checked = response.Active;

                if (response.ActiveCard !== null) {
                    switch (response.ActiveCard) {
                        case 0:
                            $("#chkWeekpass")[0].checked = false;
                            $("#chkDaypass")[0].checked = false;
                            break;
                        case 1:
                            $("#chkWeekpass")[0].checked = true;
                            break;
                        case 3:
                            $("#chkDaypass")[0].checked = true;
                            break;
                    }
                }
                else {
                    $("#chkWeekpass")[0].checked = false;
                    $("#chkDaypass")[0].checked = false;
                }

                dpDateOfBirth.SetDate(response.DateOfBirth);
                dpEntryDate.SetDate(response.EntryDate);
                dpExitDate.SetDate(response.ExitDate);
                dpAccessPlanDateFrom.SetDate(response.AccessPLanStartDate);
                dpAccessPlanDateTo.SetDate(response.AccessPLanEndDate);

            }
        }

        StoreDataFromClientInSSession();

    } catch (e) {
        console.log(e);
    }
}

function ClearControlsNoRecord() {

    cobMemberNr.SetValue("0");
    cobMemberName.SetValue("0");
    cobMemberGroupNr.SetValue("0");
    cobMemberGroupName.SetValue("0");

    cobMemberGroup.SetValue("0");
    cobSalutation.SetValue("0");
    cobDuration.SetValue("0");

    dpDateOfBirth.SetDate(null);
    dpEntryDate.SetDate(null);
    dpExitDate.SetDate(null);
    dpAccessPlanDateFrom.SetDate(null);
    dpAccessPlanDateTo.SetDate(null);
    $("#chkWeekpass")[0].checked = false;
    $("#chkDaypass")[0].checked = false;

    document.getElementById('txtSurName').value = "";
    document.getElementById('txtFirstName').value = "";
    document.getElementById('txtStreet').value = "";
    document.getElementById('txtStreetNr').value = "";
    document.getElementById('txtPostalCode').value = "";
    document.getElementById('txtPhysicalAddress').value = "";
    document.getElementById('txtMemberNr').value = "";
    document.getElementById('txtNationality').value = "";
    document.getElementById('txtProfession').value = "";
    document.getElementById('txtTelephone').value = "";
    document.getElementById('txtMobileNo').value = "";
    document.getElementById('txtEmail').value = "";
    document.getElementById('txtMemo').value = "";
    document.getElementById('txtLongTermCardNr').value = "";
    document.getElementById('txtShortTermCardNr').value = "";
    document.getElementById('txtAccessPlanNr').value = "";
    document.getElementById('txtAccessPlanName').value = "";
    document.getElementById('txtAgreementNr').value = "";
    document.getElementById("chkActivateMember").checked = false;

    StoreDataFromClientInSSession();

}

function cobMemberNrIndexChanged(s, e) {
    var id = s.GetValue();
    cobMemberName.SetValue(id);
    PageMethods.GetMemberByID(id, PopulateControls);

    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    CountPersonal();
}

function cobMemberNameIndexChanged(s, e) {
    var id = s.GetValue();
    cobMemberNr.SetValue(id);
    PageMethods.GetMemberByID(id, PopulateControls);

    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    CountPersonal();
}

//function cobMemberNrIndexChanged(s, e) {
//    if (_memberClick === true) {
//        _memberClick = false;
//        var id = s.GetValue();
//        cobMemberName.SetValue(id);
//        var Current = s.GetSelectedIndex();
//        $("#txtFvCurrentEntry").val(Current);
//        PageMethods.GetMemberByID(id, OnGetMemberByID_CallBack);
//    }
//}

//function cobMemberNameIndexChanged(s, e) {
//    if (_memberClick === true) {
//        _memberClick = false;
//        var id = s.GetValue();
//        cobMemberNr.SetValue(id);
//        var Current = s.GetSelectedIndex();
//        $("#txtFvCurrentEntry").val(Current);
//        PageMethods.GetMemberByID(id, OnGetMemberByID_CallBack);
//    }
//}

//function cobMemberGroupNrIndexChanged(s, e) {
//    if (groupClick === true) {
//        isEvent = "1";
//        groupId = s.GetValue();
//        cobMemberGroupName.SetValue(s.GetValue());
//        var _passValue = "0" + ';' + s.GetValue() + ';' + isEvent;
//        cobMemberNr.PerformCallback(_passValue);
//cobMemberName.PerformCallback(_passValue);
//    }
//}

//function cobMemberGroupNameIndexChanged(s, e) {
//    if (groupClick === true) {
//        isEvent = "1";
//        groupId = s.GetValue();
//        cobMemberGroupNr.SetValue(s.GetValue());
//        var _passValue = "0" + ';' + s.GetValue() + ';' + isEvent;
//        cobMemberNr.PerformCallback(_passValue);
//cobMemberName.PerformCallback(_passValue);
//    }
//}

function cobMemberGroupNrIndexChanged(s, e) {
    isEvent = "1";
    groupId = s.GetValue();
    cobMemberGroupName.SetValue(s.GetValue());
    var _passValue = "0" + ';' + s.GetValue() + ';' + isEvent;
    cobMemberNr.PerformCallback(_passValue);
    cobMemberName.PerformCallback(_passValue);
    window.setTimeout(function i() {
        ResetMemberGroupComboValueFromCallback(groupId);
    }, 1);
}

function cobMemberGroupNameIndexChanged(s, e) {
    isEvent = "1";
    groupId = s.GetValue();
    cobMemberGroupNr.SetValue(s.GetValue());
    var _passValue = "0" + ';' + s.GetValue() + ';' + isEvent;
    cobMemberNr.PerformCallback(_passValue);
    cobMemberName.PerformCallback(_passValue);
    window.setTimeout(function i() {
        ResetMemberGroupComboValueFromCallback(groupId);
    }, 1);
}

function ResetMemberGroupComboValueFromCallback(groupId) {
    cobMemberGroupName.SetValue(groupId);
    cobMemberGroupNr.SetValue(groupId);
    cobMemberGroup.SetValue(groupId);
    CountPersonal();
}

function displaylongtermgrid() {
    $("#UpperDiv").hide();
    $("#middiv").hide();
    $('#btnBack').addClass('btnClosenew');
    $('#btnBack').removeClass('btnClose');
    $('#btnHelp').addClass('btnHelpnew');
    $('#btnHelp').removeClass('btnHelp');
    $("#gridSearch").hide();
    $("#searchPersData").hide();
    $(".surchpersonalinfomation").show();
    $('#PageTitleLbl2').text("Ausweisverwaltung");
    $(".BottomFooterBtnsLeft").hide();
    $(".btndata").hide();
    $(".BottomFooterBtnsLeft").hide();
    $(".btndata").hide();
    $(".btnAuswesSave").show();
    $(".btnAuswesDelete").show();
}

function hidelongtermgrid() {
    $("#UpperDiv").show();
    $("#middiv").show()
    $('#btnBack').addClass('btnClose');
    $('#btnBack').removeClass('btnClosenew');
    $('#btnHelp').addClass('btnHelp');
    $('#btnHelp').removeClass('btnHelpnew');
    $(".surchpersonalinfomation").hide();
    $('#PageTitleLbl2').text("");
    $(".btnAuswesNew").hide();
    $(".btnAuswesSave").hide();
    $(".btnAuswesDelete").hide();
    $(".BottomFooterBtnsLeft").show();
    $(".btndata").show();
}

function displayshorttimegrid() {
    $("#UpperDiv").hide();
    $("#middiv").hide();
    $("#gridSearch").hide();
    $("#searchPersData").hide();
    $(".surchpersonalinfomation").hide();
    $(".Dailystatement").show();
    $('#PageTitleLbl2').text("");
    $(".BottomFooterBtnsLeft").hide();
    $(".btndata").hide();
    $(".btnAuswesSave").show();
    $(".btnAuswesDelete").show();
    $('#btnBack').addClass('btnClosenew');
    $('#btnBack').removeClass('btnClose');
    $('#btnHelp').addClass('btnHelpnew');
    $('#btnHelp').removeClass('btnHelp');
}

function hideshorttimegrid() {

    $("#UpperDiv").show();
    $("#middiv").show()
    $(".surchpersonalinfomation").hide();
    $(".Dailystatement").hide();
    $('#PageTitleLbl2').text("");
    $("#rightdiv4").hide;
    $(".btnAuswesNew").hide();
    $(".btnAuswesSave").hide();
    $(".btnAuswesDelete").hide();
    $(".BottomFooterBtnsLeft").show();
    $(".btndata").show();
    $('#btnBack').addClass('btnClose');
    $('#btnBack').removeClass('btnClosenew');
    $('#btnHelp').addClass('btnHelp');
    $('#btnHelp').removeClass('btnHelpnew');
}
function cobMemberGroupSelectedIndexChanged(s, e) {
    setSaveChanges();
}
function GetMembersData() {
    var jsonArray = [];
    var passportData = '';
    var memberGroupId = 0;
    var salutationID = 0;
    var durationID = 0;
    var memberId = 0;
    var passportData = '';
    var personPhotoInBinary = '';

    var activeCard = 0;
    try {
        //if ($("#img").attr("Src").indexOf('data:image/') > -1) {
        //    passportData = $("#img").attr("Src").split(",")[1];
        //}


        var hasimg = document.getElementById("img").hasAttribute("Src");

        if (hasimg) {

            if ($("#img").attr("Src").indexOf('data:image/') > -1) {
                personPhotoInBinary = $("#img").attr("Src").split(",")[1];
            }
            else {
                passportData = $("#img").attr("Src")
            }
        }

    }
    catch (err) { }
    if (!isNaN(parseInt(cobMemberGroup.GetValue()))) {
        memberGroupId = parseInt(cobMemberGroup.GetValue());
    }
    if (!isNaN(parseInt(cobSalutation.GetValue()))) {
        salutationID = parseInt(cobSalutation.GetValue());
    }
    if (!isNaN(parseInt(cobDuration.GetValue()))) {
        durationID = parseInt(cobDuration.GetValue());
    }
    if (!isNaN(parseInt(cobMemberNr.GetValue()))) {
        memberId = parseInt(cobMemberNr.GetValue());
    }
    if ($("#chkWeekpass")[0].checked === true) {
        activeCard = 1;
    }
    else if ($("#chkDaypass")[0].checked === true) {
        activeCard = 2;
    }
    jsonArray.push({
        ID: memberId,
        SurName: $("#txtSurName").val(),
        FirstName: $("#txtFirstName").val(),
        MemberGroupId: memberGroupId,
        Salutation: salutationID,
        Street: $("#txtStreet").val(),
        StreetNumber: $("#txtStreetNr").val(),
        PostalCode: $("#txtPostalCode").val(),
        Place: $("#txtPhysicalAddress").val(),
        MemberNumber: $("#txtMemberNr").val(),
        ContractDuration: durationID,
        DateOfBirth: moment(dpDateOfBirth.GetDate()).isValid() ? moment(dpDateOfBirth.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        Nationality: $("#txtNationality").val(),
        Profession: $("#txtProfession").val(),
        Telephone: $("#txtTelephone").val(),
        MobilePhone: $("#txtMobileNo").val(),
        Email: $("#txtEmail").val(),
        MemberPhoto: passportData,
        Memo: $("#txtMemo").val(),
        EntryDate: moment(dpEntryDate.GetDate()).isValid() ? moment(dpEntryDate.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        ExitDate: moment(dpExitDate.GetDate()).isValid() ? moment(dpExitDate.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        LongTermCardNr: $("#txtLongTermCardNr").val(),
        ShortTermCardNr: $("#txtShortTermCardNr").val(),
        AccessPlanNr: $("#txtAccessPlanNr").val(),
        AgreementNr: $("#txtAgreementNr").val(),
        AccessPLanStartDate: moment(dpAccessPlanDateFrom.GetDate()).isValid() ? moment(dpAccessPlanDateFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        AccessPLanEndDate: moment(dpAccessPlanDateTo.GetDate()).isValid() ? moment(dpAccessPlanDateTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        ActiveCard: activeCard,
        PersonPhotoInBinary: personPhotoInBinary,
    });

    return jsonArray;
}
function SaveMemberData() {
    InitialPageLoadPanel.Show();
    var jsonString = JSON.stringify(GetMembersData());
    PageMethods.SaveMemberDetails(jsonString, OnSaveMemberDetails_CallBack);
}

function SaveMemberDataONBack() {
    InitialPageLoadPanel.Show();
    var jsonString = JSON.stringify(GetMembersData());
    PageMethods.SaveMemberDetails(jsonString, OnSaveMemberONBackDetails_CallBack);
}
function OnCheckExistsOnBack_CallBack(value) {
    if (value === true) {
        alert("Mitgliedsnummer existiert");
        return;
    }
    else {
        SaveMemberDataONBack();
    }
}

function OnSaveMemberDetails_CallBack(id) {
    saveTransponders = true;
    isSave = true;
    resetSaveChanges();
    $("#txtMemberNr").attr("disabled", "disabled");
    $("#hfdHistUpdate").val(JSON.stringify(histUpdate));
    cobMemberNr.SetEnabled(true);
    cobMemberName.SetEnabled(true);
    cobMemberGroupNr.SetEnabled(true);
    cobMemberGroupName.SetEnabled(true);
    if (parseInt(cobMemberGroupNr.GetValue()) > 0) {
        groupId = cobMemberGroupNr.GetValue();
        var _passValue = id + ';' + groupId + ';' + "0";
        cobMemberNr.PerformCallback(_passValue);
        cobMemberName.PerformCallback(_passValue);
        cobMemberGroupNr.PerformCallback(groupId);
        cobMemberGroupName.PerformCallback(groupId);
    }
    else {
        var _passValue = id + ';' + "0" + ';' + "0";
        cobMemberNr.PerformCallback(_passValue);
        cobMemberName.PerformCallback(_passValue);
        cobMemberGroupNr.PerformCallback();
        cobMemberGroupName.PerformCallback();
    }
}

function OnSaveMemberONBackDetails_CallBack(id) {
    saveTransponders = true;
    isRedirect = true;
    $("#hfdHistUpdate").val(JSON.stringify(histUpdate));
    if (saveTransponders === true) {
        saveTransponders = false;
        grdTransponders.UpdateEdit();
        grdTranspondersShortTerm.UpdateEdit();
    }
    if (noBatchUpdate === true) {
        noBatchUpdate = false;
        window.location.href = "/Index.aspx";
    }
}
function GoToIndex() {
    window.location.href = "/Index.aspx";
}
function cobMemberNrEndCallBack(s, e) {
    if (parseInt(isEvent) === 1) {
        PageMethods.GetMemberByID(s.GetValue(), OnGetMemberByID_CallBack);
        //var count = parseInt(s.GetItemCount()) - 1;
        //$("#txtFvTotalEntries").val(count);
        //var Current = s.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);

        CountPersonal();
    }
    if (isSave === true) {
        isSave = false;
        //var count = parseInt(s.GetItemCount()) - 1;
        //$("#txtFvTotalEntries").val(count);
        //var Current = s.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);
        CountPersonal();
    }
    if (isDelete === true) {
        isDelete = false;
        //var count = parseInt(s.GetItemCount()) - 1;
        //$("#txtFvTotalEntries").val(count);
        //var Current = s.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);
        CountPersonal();
    }
    var _passValue = s.GetValue() + ';' + groupId + ';' + isEvent;
    cobMemberName.PerformCallback(_passValue);
    groupId = "0";
    isEvent = "0";
}

function cobMemberNameEndCallBack(s, e) {
    var editStatus1 = JSON.stringify(grdTransponders.batchEditHelper.updatedValues) !== "{}";
    if (editStatus1 === false) {
        isCallBackLongTerm = true;
    }
    var editStatus2 = JSON.stringify(grdTranspondersShortTerm.batchEditHelper.updatedValues) !== "{}";
    if (editStatus2 === false) {
        isCallBackShortTerm = true;
    }
    if (saveTransponders === true) {
        saveTransponders = false;
        setTimeout(function (ev) { grdTransponders.UpdateEdit() }, 1);
        setTimeout(function (ev) { grdTranspondersShortTerm.UpdateEdit() }, 1);
    }
    if (isCallBackLongTerm === false && isCallBackShortTerm === false) {
        grdSearchMember.PerformCallback(cobMemberGroupNr.GetValue());
    }
    InitialPageLoadPanel.Hide();
}

function OnCheckExists_CallBack(value) {
    if (value === true) {
        alert("Mitgliedsnummer existiert");
        return;
    }
    else {
        SaveMemberData();
    }
}

function dpMemberClick(s, e) {
    _memberClick = true;
}

function OnGetMemberByID_CallBack(member) {
    if (member !== null) {
        if (member.MemberGroupId !== null) {
            cobMemberGroup.SetValue(member.MemberGroupId.toString());
            window.setTimeout(function i() {
                ResetMemberGroupComboValueFromCallback(member.MemberGroupId.toString());
            }, 1);
        }
        else {
            cobMemberGroup.SelectIndex(0);
        }
        if (member.Salutation !== null) {
            cobSalutation.SetValue(member.Salutation.toString());
        }
        else {
            cobSalutation.SelectIndex(0);
        }
        $("#txtSurName").val(member.SurName);
        $("#txtFirstName").val(member.FirstName);
        $("#txtStreet").val(member.Street);
        $("#txtStreetNr").val(member.StreetNumber);
        $("#txtPostalCode").val(member.PostalCode);
        $("#txtPhysicalAddress").val(member.Place);
        $("#txtMemberNr").val(member.MemberNumber);
        $("#txtNationality").val(member.Nationality);
        $("#txtProfession").val(member.Profession);
        $("#txtTelephone").val(member.Telephone);
        $("#txtMobileNo").val(member.MobilePhone);
        $("#txtEmail").val(member.Email);
        $("#txtMemo").val(member.Memo);
        $("#txtAccessPlanNr").val(member.AccessPlanNr);
        $("#txtAccessPlanName").val(member.AccessPlanName);
        $("#img").attr("Src", member.MemberPhoto);
        $("#txtAgreementNr").val(member.AgreementNr);
        if (member.ContractDuration !== null) {
            cobDuration.SetValue(member.ContractDuration.toString());
        }
        else {
            cobDuration.SelectIndex(0);
        }
        if (member.ActiveCard !== null) {
            switch (member.ActiveCard) {
                case 0:
                    $("#chkWeekpass")[0].checked = false;
                    $("#chkDaypass")[0].checked = false;
                    break;
                case 1:
                    $("#chkWeekpass")[0].checked = true;
                    break;
                case 3:
                    $("#chkDaypass")[0].checked = true;
                    break;
            }
        }
        else {
            $("#chkWeekpass")[0].checked = false;
            $("#chkDaypass")[0].checked = false;
        }
        dpDateOfBirth.SetDate(member.DateOfBirth);
        dpEntryDate.SetDate(member.EntryDate);
        dpExitDate.SetDate(member.ExitDate);
        dpAccessPlanDateFrom.SetDate(member.AccessPLanStartDate);
        dpAccessPlanDateTo.SetDate(member.AccessPLanEndDate);
        grdTransponders.PerformCallback(member.ID);
        grdTranspondersShortTerm.PerformCallback(member.ID);
    }
    else {
        ClearControls();
        //grdTransponders.PerformCallback(0);
        //grdTranspondersShortTerm.PerformCallback(0);
    }
}

function ClearControls() {
    cobMemberGroup.SelectIndex(0);
    cobSalutation.SelectIndex(0);
    $("#txtSurName").val("");
    $("#txtFirstName").val("");
    $("#txtStreet").val("");
    $("#txtStreetNr").val("");
    $("#txtPostalCode").val("");
    $("#txtPhysicalAddress").val("");
    $("#txtMemberNr").val("");
    $("#txtNationality").val("");
    $("#txtProfession").val("");
    $("#txtTelephone").val("");
    $("#txtMobileNo").val("");
    $("#txtEmail").val("");
    $("#txtMemo").val("");
    $("#txtLongTermCardNr").val("");
    $("#txtShortTermCardNr").val("");
    $("#txtAccessPlanNr").val("");
    $("#txtAccessPlanName").val("");
    $("#txtAgreementNr").val("");
    cobDuration.SelectIndex(0);
    dpDateOfBirth.SetDate(null);
    dpEntryDate.SetDate(null);
    dpExitDate.SetDate(null);
    dpAccessPlanDateFrom.SetDate(null);
    dpAccessPlanDateTo.SetDate(null);
    $("#chkWeekpass")[0].checked = false;
    $("#chkDaypass")[0].checked = false;
    RemovePhoto();
    $("#img").attr("Src","");
    StoreDataFromClientInSSession();

}

function setNextMemberNo() {
    InitialPageLoadPanel.Show();
    PageMethods.GetNextMemberNr(OnGetNextMemberNr_CallBack)
}

function OnGetNextMemberNr_CallBack(value) {
    $("#txtMemberNr").val(value);
    InitialPageLoadPanel.Hide();
}

function SetControlsOnNew() {
    cobMemberNr.SetValue(0);
    cobMemberName.SetValue(0);
    cobMemberGroupNr.SetValue(0);
    cobMemberGroupName.SetValue(0);
    cobMemberNr.SetEnabled(false);
    cobMemberName.SetEnabled(false);
    cobMemberGroupNr.SetEnabled(false);
    cobMemberGroupName.SetEnabled(false);
    ClearControls();
    setNextMemberNo();
    $("#txtMemberNr").removeAttr("disabled");
    grdTransponders.PerformCallback(0);
    grdTranspondersShortTerm.PerformCallback(0);
}

function ShowAccessPlanGrid() {
    $("#rightdiv1").hide();
    $("#gridSearch").show();
}

function AddEditPersonnelToPlan(s, e) {
    var persID = $("#dpllPersName").val();
    var grpNr = grdAccessPlan.GetRow(e.visibleIndex).cells[0].childNodes[0].textContent;
    var groupDescription = grdAccessPlan.GetRow(e.visibleIndex).cells[1].childNodes[0].textContent;
    var planNr = grdAccessPlan.GetRow(e.visibleIndex).cells[2].childNodes[0].textContent;
    var planDescription = grdAccessPlan.GetRow(e.visibleIndex).cells[3].childNodes[0].textContent;
    var persData = { PersID: persID, PlanNo: planNr, PlanDescription: planDescription };
    persData = JSON.stringify(persData);
    $("#txtAccessPlanNr").val(planNr);
    $("#txtAccessPlanName").val(planDescription);
    HideAccessPlanGrid();
}

function HideAccessPlanGrid() {
    hiddenStatus = 0;
    $("#rightdiv1").show();
    $("#gridSearch").hide();
}

function HideButtons() {
    $("#btnNew").hide();
    $("#btnSave").hide();
    $("#btnDelete").hide();
}

function ShowButtons() {
    $("#btnNew").show();
    $("#btnSave").show();
    $("#btnDelete").show();
}

function OnDeleteMember_CallBack(value) {
    if (value === true) {
        ClearControls();
        isDelete = true;
        cobMemberNr.PerformCallback();
        cobMemberName.PerformCallback();
        grdTransponders.PerformCallback(0);
        grdTranspondersShortTerm.PerformCallback(0);
    }
}

function RedirectContactDuration() {
    var id = 0;
    if (!isNaN(parseInt(cobMemberNr.GetValue()))) {
        id = cobMemberNr.GetValue();
    }
    var isNew = !cobMemberNr.enabled;
    var pageFrom = "/Content/MembersInactive.aspx";
    PageMethods.RedirectDuration(id, isNew, pageFrom, OnRedirectDuration_CallBack);
}

function RedirectMembersGroup() {
    var id = 0;
    if (!isNaN(parseInt(cobMemberNr.GetValue()))) {
        id = cobMemberNr.GetValue();
    }
    var isNew = !cobMemberNr.enabled;
    var pageFrom = "/Content/MembersInactive.aspx";
    PageMethods.RedirectMemberGroup(id, isNew, pageFrom, OnRedirectMemberGroup_CallBack);
}

function OnRedirectDuration_CallBack() {
    document.location.href = "/Content/MemberContractDuration.aspx";
}

function OnRedirectMemberGroup_CallBack() {
    document.location.href = "/Content/MembersGroup.aspx";
}

function setSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "1");
}
function SaveChangesTrue() {

}
function resetSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
}

function GetActiveTransponderNr() {
    if (isbackLongTerm === true && isbackShortTerm === false && isRedirect === true) {
        window.location.href = "/Index.aspx";
    }
    $("#txtLongTermCardNr").val("");
    setTimeout(function (ev) { GetTransponderAusweisCount() }, 1);

    for (var rowCount = 0; rowCount < grdTransponders.keys.length; rowCount++) {
        var checked = false;
        if (grdTransponders.GetRow(rowCount).cells[2].childNodes[0].childNodes.length > 0) {
            checked = grdTransponders.GetRow(rowCount).cells[2].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        } else {
            checked = grdTransponders.GetRow(rowCount).cells[2].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        }

        if (checked) {
            $("#txtLongTermCardNr").val(grdTransponders.GetRow(rowCount).cells[1].childNodes[0].textContent);
            return;
        }
    }
}

function SetGrdRowNum(sender, evt) {
    switch (sender.name) {
        case "grdTransponders":
            grdTranspondersRowNum = evt.visibleIndex;
            try {
                if (typeof grdTransponders.batchEditHelper.updatedValues[grdTransponders.keys[grdTranspondersRowNum]] === "undefined") {
                    var lnkText = ". . .";
                    if (grdTransponders.batchEditHelper.pageServerValues[grdTransponders.keys[grdTranspondersRowNum]][6] !== null) {
                        lnkText = moment(grdTransponders.batchEditHelper.pageServerValues[grdTransponders.keys[grdTranspondersRowNum]][6]).format("DD.MM.YYYY");
                    }
                    var lnkNode = typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1] !== 'undefined' ?
                        grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1] : grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1];
                    if (typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1] !== 'undefined') {
                        lnkNode = grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1];
                    }
                    window[lnkNode.id].SetText(lnkText);
                } else {
                    var lnkText = ". . .";
                    if (typeof grdTransponders.batchEditHelper.updatedValues[grdTransponders.keys[grdTranspondersRowNum]][6] !== 'undefined') {
                        lnkText = grdTransponders.batchEditHelper.updatedValues[grdTransponders.keys[grdTranspondersRowNum]][6][1];
                    }
                    var lnkNode = typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1] === 'undefined' ?
                        grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1] : grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1];
                    if (typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1] !== 'undefined') {
                        lnkNode = grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1];
                    }
                    window[lnkNode.id].SetText(lnkText);
                }
            } catch (e) { console.log(e); }
            break;
        case "grdTranspondersShortTerm":
            grdTranspondersSTRowNum = evt.visibleIndex;
            break;
    }
}

function ausweisChanged(sender, evt, senderNr) {
    var _senderGrd = senderNr !== 1 ? grdTransponders : grdTranspondersShortTerm;
    var currentRowNum = senderNr !== 1 ? grdTranspondersRowNum : grdTranspondersSTRowNum;
    var checkedClass = 'dxWeb_edtCheckBoxChecked_Office2003Blue'; var uncheckedClass = 'dxWeb_edtCheckBoxUnchecked_Office2003Blue';
    var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var uncheckUpdateValueText = '<span class="dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var checkLogicalCellNr = 3; var inactiveCheckLogicalCellNr = 7; var inactiveDateLogicalCellNr = 8;

    for (var rowCount = 0; rowCount < _senderGrd.keys.length; rowCount++) {
        var checked = false;
        var nextRowIndex = rowCount + 1 < _senderGrd.keys.length ? rowCount + 1 : rowCount;
        var chkNode = !_senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[2].childNodes[0] : _senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0];
        if (senderNr === 1) {
            var inactiveChkNode = !_senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[6].childNodes[0] : _senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0];
            var inactiveDateNode = !_senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[7].childNodes[0] : _senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0];
        }
        var chkClassName = chkNode.className;

        if (nextRowIndex !== rowCount) {
            var nextAusweisText = _senderGrd.GetRow(nextRowIndex).cells[1].childNodes[0].textContent;
            var ausweisText = _senderGrd.GetRow(rowCount).cells[1].childNodes[0].textContent;

            if (chkClassName.indexOf(checkedClass) !== -1 || rowCount <= currentRowNum) {
                if (rowCount === currentRowNum) {
                    _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, true, checkUpdateValueText);
                    try {
                        chkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                        chkActive.SetChecked(true);
                        if (senderNr === 1) {
                            inactiveChkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                            _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, false, uncheckUpdateValueText);
                            chkInactive.SetChecked(false);
                            inactiveDateNode.textContent = "";
                            drpGrdInactiveDate.SetDate(null);
                            _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, null, "");
                        }
                    } catch (e) { }

                } else if (nextAusweisText.trim() !== "" || rowCount < currentRowNum || ausweisText.trim !== "") {
                    _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, false, uncheckUpdateValueText);
                    if (senderNr === 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, true, checkUpdateValueText);
                    if (senderNr === 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, moment().toDate(), moment().format("DD.MM.YYYY"));
                    try {
                        chkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                        if (senderNr !== 1) {
                            inactiveChkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                            inactiveDateNode.textContent = moment().format("DD.MM.YYYY");
                        }
                    } catch (e) { }
                }
            }
        }
    }

    $("#chkWeekpass")[0].checked = senderNr !== 1;
    $("#chkDaypass")[0].checked = senderNr !== 1;
    inActivateOtherTransponderGrd(senderNr);
}

function SetActive(sender, evt, checkCtrl) {
    try { grdTranspondersRowNum = grdTranspondersRowNum < 0 ? $(sender.GetMainElement()).parents("tr")[0].rowIndex - 1 : grdTranspondersRowNum } catch (e) { }
    if (grdTranspondersRowNum >= 0) {
        var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
        var checkLogicalCellNr = -1;
        if (checkCtrl) {
            if (sender.GetChecked()) {
                checkLogicalCellNr = 7;
                chkInactive.SetChecked(false);
                grdTransponders.batchEditHelper.SetCellValue(grdTranspondersRowNum, checkLogicalCellNr, false, checkUpdateValueText);
                try {
                    var chkClassName = grdTransponders.GetRow(0).cells[6].childNodes[0].childNodes[0].className.replace('dxWeb_edtCheckBoxChecked_Office2003Blue', 'dxWeb_edtCheckBoxUnchecked_Office2003Blue');
                    grdTransponders.GetRow(0).cells[6].childNodes[0].childNodes[0].className = chkClassName;
                } catch (e) { }
                activeCheckedChanged(sender, evt, 1);
            }
        } else {
            if (sender.GetChecked()) {
                checkLogicalCellNr = 3;
                chkActive.SetChecked(false);
                grdTransponders.batchEditHelper.SetCellValue(grdTranspondersRowNum, checkLogicalCellNr, false, checkUpdateValueText);
                try {
                    var chkClassName = grdTransponders.GetRow(0).cells[2].childNodes[0].childNodes[0].className.replace('dxWeb_edtCheckBoxChecked_Office2003Blue', 'dxWeb_edtCheckBoxUnchecked_Office2003Blue');
                    grdTransponders.GetRow(0).cells[2].childNodes[0].childNodes[0].className = chkClassName;
                } catch (e) { }
            }
            if ($(sender.GetMainElement()).parents("table[id='grdTransponders']").length > 0) {
                SetInactiveDate(sender);
            }
        }
    }
}

function SetInactiveDate(sender) {
    if (sender.GetChecked()) {
        drpGrdInactiveDate.SetDate(moment().toDate());
    } else {
        drpGrdInactiveDate.SetDate(null);
    }
}

function GetActiveSTTransponderNr() {
    $("#txtShortTermCardNr").val("");
    setTimeout(function (ev) { GetTransponderSTAusweisCount() }, 1);

    for (var rowCount = 0; rowCount < grdTranspondersShortTerm.keys.length; rowCount++) {
        var checked = false;
        if (grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].childNodes.length > 0) {
            checked = grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        } else {
            checked = grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        }

        if (checked) {
            $("#txtShortTermCardNr").val(grdTranspondersShortTerm.GetRow(rowCount).cells[1].childNodes[0].textContent);
            return;
        }
    }
}

function activeCheckedChanged(sender, evt, senderNr) {
    var _senderGrd = senderNr !== 1 ? grdTransponders : grdTranspondersShortTerm;
    var currentRowNum = senderNr !== 1 ? grdTranspondersRowNum : grdTranspondersSTRowNum;
    try { currentRowNum = $(sender.mainElement).parents("tr")[0].rowIndex - 1 } catch (e) { }
    var checkedClass = 'dxWeb_edtCheckBoxChecked_Office2003Blue'; var uncheckedClass = 'dxWeb_edtCheckBoxUnchecked_Office2003Blue';
    var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var uncheckUpdateValueText = '<span class="dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var checkLogicalCellNr = 3; var inactiveCheckLogicalCellNr = 7; var inactiveDateLogicalCellNr = 8;

    for (var rowCount = 0; rowCount < _senderGrd.keys.length; rowCount++) {
        var checked = false;
        var chkNode = !_senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[2].childNodes[0] : _senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0];
        if (senderNr === 1) {
            var inactiveChkNode = !_senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[6].childNodes[0] : _senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0];
            var inactiveDateNode = !_senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[7].childNodes[0] : _senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0];
        }
        var chkClassName = chkNode.className;
        var ausweisText = _senderGrd.GetRow(rowCount).cells[1].childNodes[0].textContent;

        if (ausweisText.trim() !== "") {
            if (rowCount !== currentRowNum) {
                _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, false, uncheckUpdateValueText);
                if (senderNr === 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, true, checkUpdateValueText);
                if (senderNr === 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, moment().toDate(), moment().format("DD.MM.YYYY"));
                try {
                    chkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                    if (senderNr === 1) {
                        inactiveChkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                        inactiveDateNode.textContent = moment().format("DD.MM.YYYY");
                    }
                } catch (e) { }
            } else {
                if (senderNr === 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, false, uncheckUpdateValueText);
                try {
                    if (senderNr === 1) {
                        inactiveChkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                        inactiveDateNode.textContent = "";
                        drpGrdInactiveDate.SetDate(null);
                        _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, null, "");
                    }
                } catch (e) { }
            }
        }
    }
    $("#chkWeekpass")[0].checked = senderNr !== 1;
    $("#chkDaypass")[0].checked = senderNr !== 1;
    inActivateOtherTransponderGrd(senderNr);
}

function inActivateOtherTransponderGrd(senderNr) {
    var sender = senderNr !== 1 ? grdTranspondersShortTerm : grdTransponders;

    try {
        for (var x = 0; x < sender.keys.length; x++) {
            var activeCheckNode = sender.GetRow(x).cells[2].childNodes[0];
            if (sender.GetRow(x).cells[2].childNodes[0].childNodes.length !== 0) {
                activeCheckNode = sender.GetRow(x).cells[2].childNodes[0].childNodes[0];
            }

            if (activeCheckNode.className.toString().indexOf("edtCheckBoxChecked") !== -1) {
                setTimeout((function (checkNode) {
                    $(checkNode).click();
                })(activeCheckNode), 1);

                if (senderNr !== 1) {
                    var inActiveCheckNode = grdTransponders.GetRow(x).cells[6].childNodes[0];
                    if (grdTransponders.GetRow(x).cells[6].childNodes[0].childNodes.length !== 0) {
                        inActiveCheckNode = grdTransponders.GetRow(x).cells[6].childNodes[0].childNodes[0];
                    }

                    setTimeout((function (checkNode) {
                        $(checkNode).click();
                    })(inActiveCheckNode), 1);
                }
            }
        }
    } catch (e) { console.log(e); }

    sender.batchEditHelper.EndEdit()
}

function CheckTransponderInactiveDate(sender, evt) {
    try {
        var currentRowIndex = evt.visibleIndex;
        var transponderId = grdTransponderInactiveHist.keys[currentRowIndex];

        if (parseInt(transponderId) > 0) {
            drpGrdHistInactiveDate.SetEnabled(false);
        } else {
            drpGrdHistInactiveDate.SetEnabled(true);
        }
    } catch (e) { }
}

function SetTransponderInactiveDate(sender, evt) {
    try {
        var currentRowIndex = $(sender.GetMainElement()).parents("tr")[0].rowIndex - 1;
        var transponderId = grdTransponderInactiveHist.keys[currentRowIndex];

        if (parseInt(transponderId) < 0) {
            grdTransponders.batchEditHelper.SetCellValue(grdTranspondersRowNum, 6, drpGrdHistInactiveDate.GetDate(), moment(drpGrdHistInactiveDate.GetDate()).format("DD.MM.YYYY"));
            window[grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1].id].SetText(moment(drpGrdHistInactiveDate.GetDate()).format("DD.MM.YYYY"));
            try {
                window[grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1].id].SetText(moment(drpGrdHistInactiveDate.GetDate()).format("DD.MM.YYYY"));
            } catch (e) { }
            UpdateHistoryUpdateObject(grdTranspondersRowNum, moment(drpGrdHistInactiveDate.GetDate()).format("YYYY-MM-DDT00:00:00.000"));
        }
    } catch (e) { console.log(e); }
}

function ShowEndingDates(sender, evt) {
    try {

    } catch (e) { }
    var top = parseFloat($(sender.GetMainElement()).position()["top"]) + parseFloat($(sender.GetMainElement()).height());
    var left = parseFloat($(sender.GetMainElement()).position()["left"]);
    var width = parseFloat($(sender.GetMainElement()).width());
    var currentRowIndex = $(sender.GetMainElement()).parents("tr")[0].rowIndex - 1;
    var transponderId = grdTransponders.keys[currentRowIndex];
    var transponderNr = grdTransponders.GetRow(currentRowIndex).cells[1].childNodes[0].textContent;

    if (!isNaN(parseInt(transponderId)) && parseInt(transponderId) > 0) {
        transponderNr = parseInt(transponderNr); transponderNr = isNaN(transponderNr) || transponderNr < 0 ? 0 : transponderNr;
    } else {
        transponderNr = 0;
    }

    $("#transponderInactiveHist").css({
        "position": "absolute", "top": top + "px", "left": left + "px", "width": width < 140 ? 140 : width + "px"
    }).toggle();
    grdTransponderInactiveHist.PerformCallback(String.format('{{"memberId": "{0}", "transponderNr": "{1}"}}', cobMemberNr.GetValue(), transponderNr));

}
function GetTransponderSTAusweisCount() {
    var ausweisCount = 0;
    for (var rowCount = 0; rowCount < grdTranspondersShortTerm.keys.length; rowCount++) {
        var rowKey = grdTranspondersShortTerm.keys[rowCount];
        if (parseInt(rowKey) > 0 && !(isNaN(parseInt(rowKey)))) {
            ausweisCount = ausweisCount + 1;
        }
    }
    $("#lblAusweisCount").text(ausweisCount);
}

function GetTransponderAusweisCount() {
    var ausweisCount = 0, actionCount = 0;
    for (var rowCount = 0; rowCount < grdTransponders.keys.length; rowCount++) {
        var rowKey = grdTransponders.keys[rowCount];
        if (parseInt(rowKey) > 0 && !(isNaN(parseInt(rowKey)))) {
            ausweisCount = ausweisCount + 1;
            var rowActionCount = grdTransponders.GetRow(rowCount).cells[8].childNodes[0].textContent;
            if (parseInt(rowActionCount) > 0 && !(isNaN(parseInt(rowActionCount)))) {
                actionCount = actionCount + parseInt(rowActionCount);
            }
        }
    }
    $("#lblCardCount").text(ausweisCount);
    $("#lblActionCount").text(actionCount);
}
function UpdateHistoryUpdateObject(rowIndex, rowValue) {
    try {
        if (histUpdate === null) CreateHistoryUpdateObject();
        histUpdate[0][grdTransponders.keys[grdTranspondersRowNum]] = rowValue;
    } catch (e) { }
    grdTransponderInactiveHist.batchEditHelper.EndEdit();
}
function CreateHistoryUpdateObject() {
    try {
        histUpdate = [{}];
    } catch (e) { }
}

function _DeleteCard() {
    HideDialog();
    if (hiddenStatus === 4) {
        if (!isNaN(parseInt(grdTransponders.GetSelectedKeysOnPage()[0]))) {
            var id = parseInt(grdTransponders.GetSelectedKeysOnPage()[0]);
            if (id > 0) {
                var type = 1;
                var memberId = cobMemberNr.GetValue();
                if (parseInt(memberId) > 0) {
                    InitialPageLoadPanel.Show();
                    PageMethods.DeleteCard(id, memberId, type, OnDeleteCard_CallBack);
                }

            }
        }
    }
    else if (hiddenStatus === 5) {
        if (!isNaN(parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]))) {
            var id = parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]);
            if (id > 0) {
                var type = 2;
                var memberId = cobMemberNr.GetValue();
                if (parseInt(memberId) > 0) {
                    InitialPageLoadPanel.Show();
                    PageMethods.DeleteCard(id, memberId, type, OnDeleteCard_CallBack);
                }

            }
        }
    }
}

function OnDeleteCard_CallBack(type) {
    switch (type) {
        case 1:
            grdTransponders.PerformCallback(cobMemberNr.GetValue());
            break;
        case 2:
            grdTranspondersShortTerm.PerformCallback(cobMemberNr.GetValue());
            break;
    }
    InitialPageLoadPanel.Hide();
}

function triggerFileUpload() {
    document.getElementById("UploadPhoto").click();
}

function WebcamMode() {
    $(".sectionAccessData").hide();
    $(".sectionFoto").hide();
    $(".accessreadergrp").hide();
    $(".webCamMode").show();
    hiddenStatus = 9;
    AttachWebcam();
}

function HideWebCam() {
    StopWebcam();
    $(".webCamMode").hide();
    $(".sectionAccessData").show();
    $(".accessreadergrp").show();
    $(".sectionFoto").show();
}

function dplGroupClick(s, e) {
    groupClick = true;
}

function ConfirmDelete() {
    var message = "Sind Sie sicher das Sie das Mitglieder tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 40%; margin-right: 0px;"  onclick="DeleteSelectedMember()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitMemberDelete");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelMemberDelete");
    $('#btnCancel').text(levelCaption);
}

function CancelOnBackButton() {
    HideDialog();
}

function DeleteSelectedMember() {
    HideDialog();
    var _memberId = 0;
    if (!isNaN(parseInt(cobMemberNr.GetValue()))) {
        _memberId = parseInt(cobMemberNr.GetValue());
    }
    if (_memberId === 0) {
        alert("Wählen Sie Mitglied");
        return;
    }
    else {
        PageMethods.DeleteMember(_memberId, OnDeleteMember_CallBack);
    }
}

function HideDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}

function SaveOnBack() {
    HideDialog();
    grdTransponders.batchEditHelper.EndEdit();
    grdTranspondersShortTerm.batchEditHelper.EndEdit();

    var _memberId = 0;
    if (parseInt($("#txtMemberNr").val()) < 1 || isNaN($("#txtMemberNr").val())) {
        alert("Mitgliedsnummer ist erforderlich!");
        return;
    }
    if (!isNaN(parseInt(cobMemberNr.GetValue()))) {
        _memberId = parseInt(cobMemberNr.GetValue());
    }
    if (_memberId > 0) {
        SaveMemberDataONBack();
    }
    else {
        PageMethods.CheckIfMemberNrExists($("#txtMemberNr").val(), OnCheckExistsOnBack_CallBack);
    }
}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}

function No_OnBack() {
    HideDialog();
    window.location.href = "/Index.aspx";
}

function ConfirmDeleteCard() {
    var message = "Sind Sie sicher das Sie das Ausweis tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 40%; margin-right: 0px;"  onclick="_DeleteCard()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitCardDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelCardDeletion");
    $('#btnCancel').text(levelCaption);
}

function getLocalizedText(key) {
    var data = { key: key };
    $.ajax({
        type: "POST",
        async: false,
        url: "MembersInactive.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

$(function () {
    $("#UploadPhoto").on("change", function () {
        var files = !!this.files ? this.files : [];
        if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

        if (/^image/.test(files[0].type)) { // only image file
            var reader = new FileReader(); // instance of the FileReader
            reader.readAsDataURL(files[0]); // read the local file

            reader.onloadend = function () { // set image data as background of div

                $("#img").attr('src', this.result);

                GetImageURl();

                photo = this.result;
            }

            var file, imgTemp;
            if ((file = this.files[0])) {
                imgTemp = new Image();
                imgTemp.onload = function () {
                    //alert(this.width + " " + this.height);
                    setImgMargins(this.width, this.height);
                    //alert(this.width + " " + this.height);
                };
                imgTemp.src = _URL.createObjectURL(file);
            }
        }
    });
});



function GetImageURl() {
    var hasimg = document.getElementById("img").hasAttribute("Src");
    //console.log(hasimg);
    var personPhotoInBinary = "";

    if (hasimg) {

        if ($("#img").attr("Src").indexOf('data:image/') > -1) {
            personPhotoInBinary = $("#img").attr("Src").split(",")[1];
            PageMethods.ConvertImageBytesToURL(personPhotoInBinary, cobMemberName.GetValue(), cobMemberName.GetText(), SetImageUrl);
            personPhotoInBinary = "";
        }
    }
}

function SetImageUrl(imageUrl) {
    if (imageUrl.length > 0) {
        //$("#img").attr("Src", "");
        $("#img").attr("Src", imageUrl);
        //setImgMargins();
        photo = "";
    }
}

function grdTransShortTermEndCallBack(s, e) {
    if (isbackShortTerm === true && isRedirect === true) {
        window.location.href = "/Index.aspx";
    }
    if (saveTransponders === true) {
        saveTransponders = false;
    }
    GetActiveSTTransponderNr();
    if (isCallBackShortTerm === true) {
        isCallBackShortTerm = false;
        isCallBackLongTerm = false;
        grdSearchMember.PerformCallback(cobMemberGroupNr.GetValue());
    }

}

function cobSalutationSelectedChanged(s, e) {
    setSaveChanges();
}

function cobDurationSelectedChanged(s, e) {
    setSaveChanges();
}

function dpDateOfBirthDateChanged(s, e) {
    setSaveChanges();
}

function dpEntryDateDateChanged(s, e) {
    setSaveChanges();
}

function dpExitDateDateChanged(s, e) {
    setSaveChanges();
}

function grdSearchMemberRowDbClick(s, e) {
    var index = e.visibleIndex;
    var id = s.GetRowKey(index);
    if (parseInt(id) > 0) {
        cobMemberNr.SetValue(id);
        cobMemberName.SetValue(id);
        HideSearchGrid();
        //$("#txtFvCurrentEntry").val(cobMemberNr.GetSelectedIndex());
        PageMethods.GetMemberByID(id, OnGetMemberByID_CallBack);
        CountPersonal();
    }
}

function HideSearchGrid() {
    $("#rightdiv1").show();
    $("#searchgrid").hide();
    hiddenStatus = 0;
}

function BindSerchValues() {
    var index = grdSearchMember.GetFocusedRowIndex();
    var id = grdSearchMember.GetRowKey(index);
    if (parseInt(id) > 0) {
        cobMemberNr.SetValue(id);
        cobMemberName.SetValue(id);
        HideSearchGrid();
        //$("#txtFvCurrentEntry").val(cobMemberNr.GetSelectedIndex());
        PageMethods.GetMemberByID(id, OnGetMemberByID_CallBack);
        CountPersonal();
    }
}

function ConfirmRemovePhoto() {
    var message = "Sind Sie sicher das Sie das Foto tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 43%; margin-right: 0px;"  onclick="Remove_Photo()"></button><button id="btnCancel" style="width: 134px;"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitPhotoDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelPhotoDelete");
    $('#btnCancel').text(levelCaption);
}

function Remove_Photo() {
    HideDialog();
    HideWebCam();
    RemovePhoto();
    setSaveChanges();
}

function ConfirmClearPhoto() {
    var message = "Sind Sie sicher, dass Sie löschen möchten";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Clear_Photo()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);
}

function Clear_Photo() {
    HideDialog();
    UnFreezeWebcam();
}

function cboMemberNameSearchSelectionChanged(s, e) {
    if (!isNaN(parseInt(s.GetValue()))) {
        var id = s.GetValue();
        cobMemberName.SetValue(id);
        cobMemberNr.SetValue(id);
        //var Current = cobMemberNr.GetSelectedIndex();
        //$("#txtFvCurrentEntry").val(Current);
        PageMethods.GetMemberByID(id, OnGetMemberByID_CallBack);

    }
    CountPersonal();
}

function ConfirmApplyPhoto() {
    var message = "Übernehmen Foto?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="HideDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%; width:130px; color: forestgreen !important; margin-right: 0px;"  onclick="ApplyPhoto()"></button><button id="btnCancel" style="width: 175px; color: red !important; margin-left: 0px;" onclick=" CancelApplyPhoto(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnCancel').text(levelCaption);
}

function CancelApplyPhoto() {
    HideDialog();
    HideWebCam();
    hiddenStatus = 0;
}

function ApplyPhoto() {
    HideDialog();
    AcceptPhoto();
    setSaveChanges();
    if (hiddenStatus === 9) {
        HideWebCam();
        hiddenStatus = 0;
    }
}

function grdLongTermEndCallBack(s, e) {
    GetActiveTransponderNr();
    if (isCallBackLongTerm === true && isCallBackShortTerm === false) {
        isCallBackLongTerm = false;
        grdSearchMember.PerformCallback(cobMemberGroupNr.GetValue());
    }
}


function setImgMargins(width, height) {
    var img = $get('img');
    var holderHeight = $('#Photoholder').height();
    var holderWidth = $('#Photoholder').width();
    if (img != null) {
        //var width = img.clientWidth;
        //var height = img.clientHeight;

        if (height <= holderHeight) {
            var marginTopBottom = Math.floor(((holderHeight - height) / 2));
            $("#img").attr("margin-top", marginTopBottom + "px");
            $("#img").attr("margin-bottom", marginTopBottom + "px");
        }
        else {
            $("#img").attr("max-height", holderHeight + "px");
            $("#img").attr("width", "100%");
            $("#img").attr("height", "auto");
        }

        if (width <= holderWidth) {
            var marginLeftRight = Math.floor(((holderWidth - width) / 2));
            $("#img").attr("margin-left", marginLeftRight);
            $("#img").attr("margin-right", marginLeftRight);
        }
        else {
            $("#img").attr("max-width", holderWidth + "px");
            $("#img").attr("width", "100%");
            $("#img").attr("height", "auto");
        }
    }
}

