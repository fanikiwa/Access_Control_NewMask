﻿var levelCaption = "";
var hiddenStatus = 0;
var TempID = 0;
var grdTranspondersRowNum = -1;
var grdTranspondersSTRowNum = -1;
var LastPersValue = -1;
var saveTransponders = false;
var ClientID = 0;
var ddlCompanyval = ""
var selectedPersType = "0";
var isDelete = false;
var noBatchUpdate = false;
var applyPhoto = false;
var histUpdate = null;
var _URL = window.URL || window.webkitURL;

$(function () {
    $("#txtPersonalNr").attr("disabled", "disabled");

    $("#img").load(function () {
        setImgMargins(this.width, this.height);
    });

    var imageurl = $("#img").attr("Src");
    $("#img").attr("Src", imageurl);

    $("#btnPersType").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 7;
        showPersTypeGrid();
    });
    $("#btnCompany").click(function (evt) {
        evt.preventDefault();
        ddlCompanyval = dplCompanyName.GetText();
        showCompanyGrid();
    });

    $("#ImageButton1").click(function (evt) {
        evt.preventDefault();
    });

    $("#ImageButton2").click(function (evt) {
        evt.preventDefault();
    });

    function __promptWarning(text) {
        if (text.trim() !== "") $("#__WarningPrompt > .secPromptMsg").text(text);
        $("#promptsPlaceHolder, #__WarningPrompt").show();
    }

    function __hidePromptWarning() {
        $("#promptsPlaceHolder, #__WarningPrompt").hide();
    }

    function ReloadPage(res) {
        if (res) {
            window.location = window.location;
        }
    }

    $("#btnSearchAllEmp").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 2;
        $("#rightdiv1").hide();
        $("#rightdiv2").hide();
        $("#rightdiv3").hide();
        $("#gridSearch").hide();
        $("#searchPersData").show();
    });

    $("#imgidentity").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 4;
        displaylongtermgrid();
    });

    $("#imgSelection").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 5;
        displayshorttimegrid();
    });

    $("#btnTakeWebcamPicture").click(function (evt) {
        evt.preventDefault();
        WebcamMode();
    });

    $("#btnCardReaderData").click(function (evt) {
        evt.preventDefault();
        displaycarddata();
    });

    $("#btnCardReaderData2").click(function (evt) {
        evt.preventDefault();
        displaycarddata();
    });

    $("#btnPersonalForm").click(function (evt) {
        evt.preventDefault();

        redirectToAdditionalInfo();
    });

    $("#btnNewPersType").click(function (evt) {
        ASPxClientUtils.DeleteCookie("persTypeCookie");
        ASPxClientUtils.SetCookie("persTypeCookie", "2", (moment(Date(Date.now)).add('day', 1))["_d"]);
    });

    $("#btnEditPersType").click(function (evt) {
        ASPxClientUtils.DeleteCookie("persTypeCookie");
        ASPxClientUtils.SetCookie("persTypeCookie", "3", (moment(Date(Date.now)).add('day', 1))["_d"]);
    });

    $("#btnCarType").click(function (evt) {
        evt.preventDefault();
        ShowCarTypeGrid();
        hiddenStatus = 6;
    });

    $("#btnSearch").click(function (evt) {
        evt.preventDefault();
        hiddenStatus = 3;
        ShowAccessPlanGrid();
    });

    $("#btnNewCarType").click(function (evt) {
        ASPxClientUtils.DeleteCookie("VehicleTypeCookie");
        ASPxClientUtils.SetCookie("VehicleTypeCookie", "2", (moment(Date(Date.now)).add('day', 1))["_d"]);
    });

    $("#btnEditCarType").click(function (evt) {
        ASPxClientUtils.DeleteCookie("VehicleTypeCookie");
        ASPxClientUtils.SetCookie("VehicleTypeCookie", "3", (moment(Date(Date.now)).add('day', 1))["_d"]);
    });

    function grdVehicleTypesdblRowClick(s, e) {
        ASPxClientUtils.DeleteCookie("VehicleTypeCookie");
        ASPxClientUtils.SetCookie("VehicleTypeCookie", "3", (moment(Date(Date.now)).add('day', 1))["_d"]);
    }

    function grdPersTypesdblRowClick(s, e) {
        ASPxClientUtils.DeleteCookie("persTypeCookie");
        ASPxClientUtils.SetCookie("persTypeCookie", "3", (moment(Date(Date.now)).add('day', 1))["_d"]);
    }

    $("#btnCompanyBack").click(function (evt) {
        evt.preventDefault();
        ReloaddplCompanyName();
        HideCompanyGrid();
    });

    $("#btnRemovePhoto").click(function (evt) {
        evt.preventDefault();
        ConfirmRemovePhoto();
    });

    $("#btnAccept").click(function (evt) {
        evt.preventDefault();
        AcceptPhoto();
        applyPhoto = true;
        if (hiddenStatus === 9) {
            HideWebCam();
            hiddenStatus = 0;
        }
    });

    $("#btnCancelPhoto").click(function (evt) {
        evt.preventDefault();
        if (hiddenStatus === 9) {
            HideWebCam();
            hiddenStatus = 0;
        }
    });

    $("#btnTakePhoto").click(function (evt) {
        evt.preventDefault();
        FreezeWebcam();
        applyPhoto = true;
    });

    $("#btnClearPhoto").click(function (evt) {
        evt.preventDefault();
        UnFreezeWebcam();
    });

    $("#btnNewPersType").click(function (evt) {
        evt.preventDefault();
        $("#txtPersType").val("");
        $("#txtPersTypeMemo").val("");
        $("#txtPersTypeId").val("");
        $("#txtPersType").focus();
        dbPersTypeColor.SetColor();

    });

    $("#btnSavePersType").click(function (evt) {
        evt.preventDefault();
        SavePersType();
        selectedPersType = ddlPersType.GetValue() !== null ? ddlPersType.GetValue() : "0";
    });

    $("#btnDeletePersType").click(function (evt) {
        evt.preventDefault();
        selectedPersType = ddlPersType.GetValue() !== null ? ddlPersType.GetValue() : "0";
        Delete_PersType();
    });

    $("#btnPersTypeBack").click(function (evt) {
        evt.preventDefault();
        hidePersTypeGrid();
        hiddenStatus = 0;
    });

    $("#btnTriggerFileUpload").click(function (evt) {
        evt.preventDefault();
        triggerFileUpload();
    });

    $("input, select").change(function () {
        setSaveChanges();
    });

    $("#btnHelp").click(function (evt) {
        evt.preventDefault();

        $("#hiddenFieldSaveChanges").attr("value", "0");
    });

    $("#chkDaypass").change(function (ev) {
        if (this.checked === true) {
            $("#chkWeekpass")[0].checked = false;
            $("#chkIdentificationActive")[0].checked = false;
        }
    });

    $("#chkWeekpass").change(function (ev) {
        if (this.checked === true) {
            $("#chkDaypass")[0].checked = false;
            $("#chkIdentificationActive")[0].checked = false;
        }
    });

    $("#chkIdentificationActive").change(function (ev) {
        if (this.checked === true) {
            $("#chkWeekpass")[0].checked = false;
            $("#chkDaypass")[0].checked = false;
            $("#chkNurPincodeActive")[0].checked = false;
        }
    });

    $("#chkPincodeActive").change(function (ev) {
        if (this.checked === true) {
            $("#chkNurPincodeActive")[0].checked = false;
        }
    });

    $("#chkNurPincodeActive").change(function (ev) {
        if (this.checked === true) {
            $("#chkPincodeActive")[0].checked = false;
            $("#chkMenaceActive")[0].checked = false;
        }
    });

    $("#btnNewAusweis").click(function (ev) {
        ev.preventDefault();

    });

    $("#btnDeleteAusweis").click(function (ev) {
        ev.preventDefault();
        ConfirmDeleteCard();
    });

    $("#fvNavPrev").click(function (ev) {
        ev.preventDefault();
        navigatePersonal(-1);
    });

    $("#fvNavNext").click(function (ev) {
        ev.preventDefault();
        navigatePersonal(1);
    });

    //$("#fvNavPrev").click(function (evt) {
    //    evt.preventDefault();
    //    var currentIndex = parseInt(cmbIDNr.GetSelectedIndex());
    //    var nxtIndex = currentIndex - 1;
    //    if (nxtIndex === 0) return;
    //    cmbIDNr.SetSelectedIndex(nxtIndex);
    //    cmbPersName.SetSelectedIndex(nxtIndex);
    //    cmbAusweisNr.SetSelectedIndex(nxtIndex);
    //    //$("#txtFvCurrentEntry").val(nxtIndex);
    //    PageMethods.GetPersonnelByNr(cmbIDNr.GetValue(), SetControls);

    //    //var Current = cmbIDNr.GetSelectedIndex();
    //    //$("#txtFvCurrentEntry").val(Current);
    //    //var count = parseInt(cmbIDNr.GetItemCount()) - 1;
    //    //$("#txtFvTotalEntries").val(count);

    //    CountPersonal();
    //});

    //$("#fvNavNext").click(function (evt) {
    //    evt.preventDefault();
    //    var maxIndex = parseInt(cmbIDNr.GetItemCount());
    //    var currentIndex = parseInt(cmbIDNr.GetSelectedIndex());
    //    var nxtIndex = currentIndex + 1;
    //    if (nxtIndex <= (maxIndex - 1)) {
    //        cmbIDNr.SetSelectedIndex(nxtIndex);
    //        cmbPersName.SetSelectedIndex(nxtIndex);
    //        cmbAusweisNr.SetSelectedIndex(nxtIndex);
    //        //$("#txtFvCurrentEntry").val(nxtIndex);
    //        PageMethods.GetPersonnelByNr(cmbIDNr.GetValue(), SetControls);
    //    }

    //    //var Current = cmbIDNr.GetSelectedIndex();
    //    //$("#txtFvCurrentEntry").val(Current);
    //    //var count = parseInt(cmbIDNr.GetItemCount()) - 1;
    //    //$("#txtFvTotalEntries").val(count);
    //    CountPersonal();
    //});

    $("#hiddenFieldSaveChanges").val("");
    $("#hiddenFieldIsNewPersonal").val("0");
    if ($("#photVal").val() !== undefined && $("#photVal").val() !== "") {
        $("#img").attr("Src", $("#photVal").val());
        $("#photVal").val("");
    }
    FetchQueryString();

    $('#btnActivatePersonal').on("click", function (e) {
        e.preventDefault();
        if ($("#txtPersonalNr").val().trim() === "" || $("#txtPersonalNr").val().trim() === "0") {
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

        $("#transponderInactiveHist").hide();
        if (hiddenStatus === 0) {

            var editStatus1 = JSON.stringify(grdTransponders.batchEditHelper.updatedValues) === "{}";
            if (editStatus1 === false) {
                setSaveChanges();
                isbackLongTerm = true;
            }
            var editStatus2 = JSON.stringify(grdTranspondersShortTerm.batchEditHelper.updatedValues) === "{}";
            if (editStatus2 === false) {
                setSaveChanges();
                isbackShortTerm = true;
            }
            if (editStatus1 === true && editStatus2 === true) {
                noBatchUpdate = true;
            }

            var saveChanges = $('#hiddenFieldSaveChanges').val();
            if (saveChanges === "1" && allowZUTEdit) {
                //BackButtonConfirm();
                PromptSaveChanges();
            }
            else {
                //window.location.href = "/Index.aspx"
                redirectPageBackToSettings();
            }
            if (allowZUTEdit) PromptSaveChanges();
        }
        else if (hiddenStatus === 1) {
            HideAccessPlanGrid();
            hiddenStatus = 0;
        }
        else if (hiddenStatus === 2) {
            $("#rightdiv1").show();
            $("#btnNew").show();
            $("#btnSave").show();
            $("#btnDelete").show();
            $("#rightdiv2").hide();
            $("#rightdiv3").hide();
            $("#gridSearch").hide();
            $("#searchPersData").hide();
            hiddenStatus = 0;
        }
        else if (hiddenStatus === 3) {
            $("#rightdiv1").show();
            $("#btnNew").show();
            $("#btnSave").show();
            $("#btnDelete").show();
            $("#gridSearch").hide();
            hiddenStatus = 0;
        }
        else if (hiddenStatus === 4) {
            hidelongtermgrid();

            hiddenStatus = 0;
            setTimeout(function () { GetActiveTransponderNr(); }, 1);
            setTimeout(function () { GetActiveSTTransponderNr(); }, 1);
        }
        else if (hiddenStatus === 5) {
            hideshorttimegrid();

            hiddenStatus = 0;
            setTimeout(function () { GetActiveTransponderNr(); }, 1);
            setTimeout(function () { GetActiveSTTransponderNr(); }, 1);
        }
        else if (hiddenStatus === 6) {
            hideCarTypeGrid();

            hiddenStatus = 0;
        }
        else if (hiddenStatus === 7) {
            hidePersTypeGrid();
            hiddenStatus = 0;
        }
        else if (hiddenStatus === 9) {

            if (applyPhoto === true) {
                ConfirmApplyPhoto();
            }
            else {
                HideWebCam();
                hiddenStatus = 0;
            }
        }

        else if (hiddenStatus === 8) {
            HideCompanyGrid();
            hiddenStatus = 0;
        }

        else if (hiddenStatus === 10) {
            hidecarddata();
            hiddenStatus = 0;
        }


    });

    StoreDataFromClientInSSession();

    window.setTimeout(function i() {
        //RebindMemberInfoCombosOnLoad();
        CountPersonal();
    }, 1);


    $("#btnTriggerFileUpload").hide();
    $("#btnTakeWebcamPicture").hide();
    $("#btnRemovePhoto").hide();


});

function PromptSaveChanges() {
    var initdto = JSON.parse(sessionStorage.getItem("personalinactivedto"));
    var currdto = RetrieveDataFromClient();

    //console.log(initdto);
    //console.log(currdto);

    var areObjectsEqual = _.isEqual(initdto, currdto);

    //console.log(areObjectsEqual);

    if (!areObjectsEqual) {
        CornfirmSaveDialog();
    } else {
        redirectPageBackToSettings();
    }
}

function save() {

    if (document.getElementById("txtPersonalNr").value.length < 1) { return; }

    var dto = new Object();
    dto.Pers_Nr = $("#txtPersonalNr").val();
    dto.Active = document.getElementById("chkActivatePersonal").checked;

    StoreDataFromClientInSSession();

    var PersonalNoVar = 0;

    try {
        if (!isNaN(parseInt(cmbIDNr.GetValue()))) {
            PersonalNoVar = parseInt(cmbIDNr.GetValue());
        }
    } catch (err) {
        console.log(err);
    }

    $("#btnCancel").removeAttr("disabled", "disabled");
    if (PersonalNoVar === 0) {
        getLocalizedText("noSelection");
        alert(levelCaption);
    } else {
        PageMethods.UpdatePersonalInactiveStatus(dto, function (err) { console.log(err) });
        //PageMethods.GetPersonnelByNr(dto.Pers_Nr, SettingComboCallBacks);
        PageMethods.Getpersonal(dto.Pers_Nr, SettingComboCallBacks);
    }
}

function CountPersonal() {
    try {
        var persCount = cmbIDNr.GetItemCount();
        var hasKeine = cmbIDNr.FindItemByValue(0) !== null;
        persCount = persCount - (hasKeine ? 1 : 0) > 0 ? persCount - (hasKeine ? 1 : 0) : 0;
        $("#txtFvTotalEntries").val(persCount);
        var selectedPers = cmbIDNr.GetSelectedIndex();
        selectedPers = selectedPers !== -1 ? (hasKeine ? selectedPers : selectedPers + 1) : 0;
        $("#txtFvCurrentEntry").val(selectedPers);
    } catch (e) { console.log(e); }
}

function cmbPersNameSelectedIndexChanged(s, e) {
    var value = s.GetValue();
    cmbAusweisNr.SetValue(value);
    cmbIDNr.SetValue(value);
    SetValues(value);

    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    CountPersonal();
}
function cmbAusweisNrSelectedIndexChanged(s, e) {
    var value = s.GetValue();
    cmbPersName.SetValue(value);
    cmbIDNr.SetValue(value);
    SetValues(value);

    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    CountPersonal();
}
function cmbIDNrSelectedIndexChanged(s, e) {
    var value = s.GetValue();
    cmbPersName.SetValue(value);
    cmbAusweisNr.SetValue(value);
    SetValues(value);

    //var Current = s.GetSelectedIndex();
    //$("#txtFvCurrentEntry").val(Current);
    //var count = parseInt(s.GetItemCount()) - 1;
    //$("#txtFvTotalEntries").val(count);
    CountPersonal();
}

function cmbClientsNameSelectedIndexChanged(s, e) {
    var value = s.GetValue();
    var pass = value + ";" + "1";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);
    window.setTimeout(function i() {
        ResetClientsNameComboValueFromCallback(value);
        CountPersonal();
    }, 1);
    CountPersonal();
}

function cmbLocationNameSelectedIndexChanged(s, e) {
    var value = s.GetValue();
    var pass = value + ";" + "2";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);
    window.setTimeout(function i() {
        ResetLocationNameComboValueFromCallback(value);
        CountPersonal();
    }, 1);
    CountPersonal();
}

function cmbDepartmentSelectedIndexChanged(s, e) {
    var value = s.GetValue();
    var pass = value + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);
    window.setTimeout(function i() {
        ResetDepartmentComboValueFromCallback(value);
        CountPersonal();
    }, 1);
    CountPersonal();
}

function ResetClientsNameComboValueFromCallback(value) {
    cmbClientsName.SetValue(value);
    ResetPersonalInfoComboValueFromCallback();
    CountPersonal();
}

function ResetLocationNameComboValueFromCallback(value) {
    cmbLocation.SetValue(value);
    ResetPersonalInfoComboValueFromCallback();
    CountPersonal();
}

function ResetDepartmentComboValueFromCallback(value) {
    cmbDepartment.SetValue(value);
    ResetPersonalInfoComboValueFromCallback();
    CountPersonal();
}

function ResetPersonalInfoComboValueFromCallback() {
    cmbPersName.SetValue("0");
    cmbIDNr.SetValue("0");
    cmbAusweisNr.SetValue("0");
    CountPersonal();
}

function SetValues(value) {
    if (value !== null && value !== undefined) {
        //PageMethods.GetPersonnelByNr(value, SetControls);
        PageMethods.Getpersonal(value, SetControls);
        CountPersonal();
    }
}

function RebindMemberInfoCombosOnLoad() {
    var clientid = cmbClientsName.GetValue();
    var pass = clientid + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);

    var locationid = cmbLocation.GetValue();
    pass = locationid + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);

    var departmentid = cmbDepartment.GetValue();
    pass = departmentid + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);

    CountPersonal();
}

function SettingComboCallBacks(response) {
    var clientid = cmbClientsName.GetValue();
    var pass = clientid + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);

    var locationid = cmbLocation.GetValue();
    pass = locationid + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);

    var departmentid = cmbDepartment.GetValue();
    pass = departmentid + ";" + "3";
    cmbPersName.PerformCallback(pass);
    cmbIDNr.PerformCallback(pass);
    cmbAusweisNr.PerformCallback(pass);

    CountPersonal();
}

function redirectPageBackToSettings() {
    window.location.href = "/Content/Settings.aspx";
}

function RetrieveDataFromClient() {

    var dto = new Object();
    dto.Pers_Nr = $("#txtPersonalNr").val();
    dto.Active = document.getElementById("chkActivatePersonal").checked;

    return dto;
}

function StoreDataFromClientInSSession() {

    var dto = new Object();
    dto.Pers_Nr = $("#txtPersonalNr").val();
    dto.Active = document.getElementById("chkActivatePersonal").checked;

    sessionStorage.setItem("personalinactivedto", JSON.stringify(dto));

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

    CountPersonal();
    redirectPageBackToSettings();
}

function CancelOnBackButton() {
    resetConfirmationDiv();
    redirectPageBackToSettings();
}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();
}

function redirectToAdditionalInfo() {
    var saveChanges = $('#hiddenFieldSaveChanges').val();

    if (saveChanges === "1") {
        return;
    }
    else {
        setTimeout(function (ev) {
            window.location.href = "PersonalFormInactive.aspx?ClientNo=" + cmbClients.GetValue() + "&ClientName=" + cmbClientsName.GetValue() + "&Location=" + cmbLocation.GetValue() + "&Department=" + cmbDepartment.GetValue() + "&PersName=" + cmbPersName.GetValue() + "&PersIDNr=" + cmbPersName.GetValue() + "&ID=" + cmbIDNr.GetValue();
        }, 1);
    }
}


function grdPersDataRowDblClick(s, e) {
    $("#rightdiv1").show();
    $("#rightdiv2").hide();
    $("#rightdiv3").hide();
    $("#gridSearch").hide();
    $("#searchPersData").hide();
}
function GetRowValues(values) {

}

function hidePersTypeGrid() {
    $("#UpperDiv").show();
    $("middiv").show;
    $("middivTitle").show;
    $("bottomdiv").show;
    $("#middiv").css("display", "block");
    $("#rightdiv2").hide();
    $("#rightdiv1").show();
    $("#rightdiv4").hide;

}

function showNewPtypeControls() {
    $("#fvSec2").show();
    $("#btnPersTypeBack").unbind("click");
}

function showNewCarTypeControlsa() {
    $("#fvSec3").show();
    $("#btnCarTypeBack").unbind("click");
}

function showPersTypeGrid() {
    $("#UpperDiv").hide();
    $("middiv").hide;
    $("middivTitle").hide;
    $("bottomdiv").hide;
    $("#rightdiv1").hide();
    $("#rightdiv2").show();
    $("#middiv").css("display", "none");
}

function showCompanyGrid() {
    $("#rightdiv1").hide();
    $("#rightdiv2").hide();
    $("#rightdiv3").hide();
    $("#rightdiv5").show();
    hiddenStatus = 8;
}

function HideCompanyGrid() {
    $("#rightdiv2").hide();
    $("#rightdiv3").hide();
    $("#rightdiv5").hide();
    $("#rightdiv1").show();
}

function LoadPersonnelDetails(s, e) {
    showNewPtypeControls();
    var persName = grdPersType.GetRow(e.visibleIndex).cells[0].childNodes[0].textContent;
    var persMemo = grdPersType.GetRow(e.visibleIndex).cells[1].childNodes[0].textContent;
    $("#txtPersName").val(persName);
    $("#txtPersMemo").val(persMemo);
}

function ShowCarTypeGrid() {
    $("#UpperDiv").hide();
    $("middiv").hide;
    $("middivTitle").hide;
    $("bottomdiv").hide;
    $("#rightdiv1").hide();
    $("#rightdiv3").show();
    $("#middiv").css("display", "none");
}

function enterCarSelection() {
    ShowCarTypeGrid();
    $("#btnCarTypeBack").unbind("click");
    $("#btnCarTypeBack").bind("click", function (evt) {
        evt.preventDefault();
        seletionForCar();
    });
}

function hideCarTypeGrid() {
    $("#UpperDiv").show();
    $("middiv").show;
    $("middivTitle").show;
    $("bottomdiv").show;
    $("#middiv").css("display", "block");
    $("#rightdiv3").hide();
    $("#rightdiv1").show();
    $("#rightdiv4").hide;
}

function seletionForCar() {
    ASPxClientUtils.DeleteCookie("VehicleTypeCookie");
    ASPxClientUtils.SetCookie("VehicleTypeCookie", "1", (moment(Date(Date.now)).add('day', 1))["_d"]);
    hideCarTypeGrid();
    $("#btnCarTypeBack").unbind("click");
}

function getLocalizedText(key) {
    var data = { key: key };
    $.ajax({
        type: "POST",
        async: false,
        url: "PersonalInactive.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function ShowAccessPlanGrid() {
    $("#rightdiv1").hide();
    $("#gridSearch").show();
}

function HideAccessPlanGrid() {
    hiddenStatus = 1;
    $('#PageTitleLbl2').text("");
    $("#rightdiv1").show();
    $("#gridSearch").hide();
    $("#hiddenFieldSearchValue").attr("value", 0);
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
})

function AddEditPersonnelToPlan(s, e) {
    var persID = $("#cmbPersName").val();
    var grpNr = grdChangePlan.GetRow(e.visibleIndex).cells[0].childNodes[0].textContent;
    var groupDescription = grdChangePlan.GetRow(e.visibleIndex).cells[1].childNodes[0].textContent;
    var planNr = grdChangePlan.GetRow(e.visibleIndex).cells[2].childNodes[0].textContent;
    var planDescription = grdChangePlan.GetRow(e.visibleIndex).cells[3].childNodes[0].textContent;
    var persData = { PersID: persID, PlanNo: planNr, PlanDescription: planDescription };
    persData = JSON.stringify(persData);
    $("#txtZuttritsplanNr").val(planNr);
    $("#txtZuttritsBezeichnung").val(planDescription);
    $("#txtdateEdited").val(planDescription);
    HideAccessPlanGrid();
    $("#hiddenFieldSearchValue").attr("value", 0);
    $("#hiddenFieldSaveChanges").val(1);
    window.grdChangePlan.PerformCallback(persData);
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

function triggerFileUpload() {
    document.getElementById("UploadPhoto").click();
}

function BindSelectedPers(value) {
    HideEmpSerchGrid();
    cmbPersName.SetValue(value);
    cmbAusweisNr.SetValue(value);
    cmbIDNr.SetValue(value);
    SetValues(value);
    CountPersonal();
}

function GetLastPersNr(drpCtrl) {
    LastPersValue = drpCtrl.lastChangedValue;
}

function SetLastPersNr(drpCtrl) {
    var itemCount = drpCtrl.GetItemCount();
    drpCtrl.SetSelectedIndex(itemCount > 1 ? 1 : 0);
}

function navigatePersonal(navDirection) {
    var nextIndex = cmbPersName.GetSelectedIndex() + navDirection;
    if (nextIndex > 0 && nextIndex < cmbPersName.GetItemCount()) {
        var nextValue = cmbPersName.GetItem(nextIndex).value;
        if (!isNaN(nextValue)) {
            cmbPersName.SetValue(nextValue);
            cmbAusweisNr.SetValue(nextValue);
            cmbIDNr.SetValue(nextValue);
            //PageMethods.GetPersonnelByNr(nextValue, SetControls);
            PageMethods.Getpersonal(nextValue, SetControls);
        }
    }
    CountPersonal();
}

function resetDefault() {
    document.getElementById('ImportantDialogBox').innerHTML = "";
}

function ConfirmDelete() {
    var message = "Sind Sie sicher das Sie das Personal tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div><button id="btnOk"  style="margin-left: 40%; margin-right: 0px;"  onclick="DeletePersonal();return false;"></button><button id="btnCancel"  onclick="resetDefault();" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    getLocalizedText("permitDelete");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelDelete");
    $('#btnCancel').text(levelCaption);
}

function CancelDelete() {
    HideDialog();
}

function DeletePersonal() {
    resetDefault();
    $("#hiddenFieldConfirmDialog").attr("value", "1");
    var pers = 0;
    if (!isNaN(parseInt(cmbPersName.GetValue()))) {
        pers = parseInt(cmbPersName.GetValue());
    }
    if (pers === 0) {
        alert("Wählen Sie Personal");
        return;
    }
    else {
        PageMethods.DeletePersonalDetails(pers, OnDeletePersonal_CallBack);
    }
}

function OnDeletePersonal_CallBack(value) {
    if (value === true) {
        ClearControls();
        cmbPersName.PerformCallback();
        cmbIDNr.PerformCallback();
        cmbAusweisNr.PerformCallback();
        grdTransponders.PerformCallback(0);
        grdTranspondersShortTerm.PerformCallback(0);
    }
}

function ReloadPage(res) {
    ClearControlAfterDelete();
    CountPersonal();
}
function HideDialog() {
    document.getElementById('ImportantDialogBox').innerHTML = "";
}

function setSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "1");
}

function resetSaveChanges() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetDefault(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}

function SaveOnBack() {
    HideDialog();
    grdTransponders.batchEditHelper.EndEdit();
    grdTranspondersShortTerm.batchEditHelper.EndEdit();
    var persNr = 0;
    if (parseInt($("#txtPersonalNr").val()) < 1 || isNaN($("#txtPersonalNr").val())) {
        alert("Mitgliedsnummer ist erforderlich!");
        return;
    }
    if (!isNaN(parseInt(cmbIDNr.GetValue()))) {
        persNr = parseInt(cmbIDNr.GetValue());
    }
    if (persNr > 0) {
        SavePersonalDataONBack();
    }
    else {
        PageMethods.CheckIfPersNrExists($("#txtPersonalNr").val(), OnCheckExistsOnBack_CallBack);
    }
    CancelOnBackButton();
    CountPersonal();
}

function SavePersonalDataONBack() {
    InitialPageLoadPanel.Show();
    var jsonString = JSON.stringify(GetPersonalDataFromControls());
    PageMethods.EditPersonalInDatabase(jsonString, OnEditPersonalInDatabase_CallBack);
    CountPersonal();
}
function OnCheckExistsOnBack_CallBack(value) {
    if (value === true) {
        alert("Personalnummer existiert");
        return;
    }
    else {
        SavePersonalDataONBack();
    }
}


function DocumentButtonConfirm() {
    var message = "Bitte erst Datensatz speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/infoblue2.png" alt="Stop" class="stopPic" height="50" width="50" align="middle"> <br/>  <br/> <div id="dialogText">' + message + '</div><br/> <button id="btnOk"  onclick="resetDefault()"></button></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    $('#btnOk').text('Zurück');
}

//function CancelOnBackButton() {
//    resetDefault();
//    window.location.href = "/Index.aspx";
//}

function savePersonal() {
    CancelOnBackButton();
    $("#hiddenFieldSavePersonal").attr("value", "1");
    $("[id$=btnSave]").click();
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

function HideEmpSerchGrid() {
    $("#rightdiv1").show();
    $("#rightdiv2").hide();
    $("#rightdiv3").hide();
    $("#gridSearch").hide();
    $("#searchPersData").hide();
}

function dplCompanyNameSelectedIndexChanged(s, e) {
    selectionChanged = true;
    saveChanges = false;
    ddlCompanyval = s.GetSelectedItem().texts[0].toString() + "-" + s.GetSelectedItem().texts[1].toString();
    var companyNo = s.GetSelectedItem().texts[0];
    var companyName = s.GetSelectedItem().texts[1];
    $("#txtCompanyName").val(companyName);
    PageMethods.GetCompanyNo(companyNo);
}

function ReloaddplCompanyName(response) {
    dplCompanyName.PerformCallback();
    dplCompanyName.SetValue(ddlCompanyval);
}

function SavepersonalDetialsInDatabase(succ) {
    if ($("#txtPersonalNr").is(":enabled") && succ === 2) {
        return;
        $("#txtPersonalNr").focus();
    }
    InitialPageLoadPanel.Show();
    $("#txtPersonalNr").attr("disabled", "disabled");
    $("#hiddenFieldIsNewPersonal").attr("value", succ);
    var jsonArray = GetPersonalDataFromControls();
    var jsonString = JSON.stringify(jsonArray);
    PageMethods.EditPersonalInDatabase(jsonString, OnEditPersonalInDatabase_CallBack);// OnEditPersonalInDatabase_CallBack
}

function ImportantInfoDialog(title, message) {
    var boxContent = "<div id=\"overlayPersonal\"><div id=\"box_flamePersonal\">" +
        "<div id=\"dialogBoxPersonal\">  " + "<br/> " +
        title + "<img src=\"../../Images/FormImages/greeninfo-01.png\" alt=\"Stop\" class=\"greeninfo\"  align=\"right\"> <br/>" +
        "<div id=\"dialogBox2Personal\">  " + "<br/> <br/> <br/> <br/>" +
     message + "<br/> " +
        "<button id=\"btnOk\"  onclick=\"resetImportantInfoDialogDiv()\"></button>" +
        "</div></div></div>";
    document.getElementById("ImportantDialogBox").innerHTML = boxContent;
    $("#btnOk").text("Zurück");
    $("#hiddenFieldIncreament").attr("value", "1");
}

function resetImportantInfoDialogDiv() {
    document.getElementById("ImportantDialogBox").innerHTML = "";
    $("#txtPersonalNr").focus();
}

function OnEditPersonalInDatabase_CallBack(response) {
    var string = response.PersonalNumber + ";" + "0";
    LastPersValue = response.PersonalNumber;
    $("#hiddenFieldSaveChanges").attr("value", "0");
    $("#hfdHistUpdate").val(JSON.stringify(histUpdate));


    //if (string !== null)
    //{
    //    cmbPersName.PerformCallback(string);
    //    cmbIDNr.PerformCallback(string);
    //    cmbAusweisNr.PerformCallback(string);
    //}
    if (saveTransponders) {
        try {
            cmbPersName.SetValue(LastPersValue);
            cmbAusweisNr.SetValue(LastPersValue);
            cmbIDNr.SetValue(LastPersValue);
        } catch (e) { }
        setTimeout(function (ev) { grdTransponders.UpdateEdit() }, 1);
        if (JSON.stringify(grdTranspondersShortTerm.batchEditHelper.updatedValues) === "{}") {

            setTimeout(function (ev) { grdTranspondersShortTerm.PerformCallback(cmbIDNr.GetValue()); }, 1);
        } else {

            setTimeout(function (ev) { grdTranspondersShortTerm.UpdateEdit() }, 1);
        }
        setTimeout(function (ev) {
            PageMethods.SavePersAccessGroups(LastPersValue, JSON.stringify(GetAccessGroupUpdate()),
                function (resp) {
                    setTimeout(function (ev) { grdAccessGroups.PerformCallback(LastPersValue) }, 1);
                },
                function (err) {
                    console.log(err);
                });
        }, 1);
    }
    if (noBatchUpdate === true) {
        noBatchUpdate = false;
        window.location.href = "/Content/Settings.aspx";
    }
    InitialPageLoadPanel.Hide();
}

function GetPersonalDataFromControls() {
    var jsonArray = [];
    var passportData = '';
    var personPhotoInBinary = '';
    var cardselection = 0;
    try {
        //if ($("#img").attr("Src").indexOf('data:image/') > -1) {
        //    passportData = $("#img").attr("Src").split(",")[1];
        //}

        var hasimg = document.getElementById("img").hasAttribute("Src");
        //console.log(hasimg);

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
    var locationID = 0;
    var departmentID = 0;
    var costCenterID = 0;
    var PersType = 0;
    var companyNo = dplCompanyName.GetSelectedItem().texts[0];
    var companyNm = dplCompanyName.GetSelectedItem().texts[1];
    if (!isNaN(parseInt(cmbLocations.GetValue()))) {
        locationID = parseInt(cmbLocations.GetValue());
    }
    if (!isNaN(parseInt(cmbDepartments.GetValue()))) {
        departmentID = parseInt(cmbDepartments.GetValue());
    }
    if (!isNaN(parseInt(cmbCostCenters.GetValue()))) {
        costCenterID = parseInt(cmbCostCenters.GetValue());
    }
    if (!isNaN(parseInt(ddlPersType.GetValue()))) {
        PersType = parseInt(ddlPersType.GetValue());
    }
    if (!isNaN(parseInt($("#ddlCarType").val()))) {
        CarTyp = parseInt($("#ddlCarType").val());
    }
    if (!isNaN(parseInt($("#cmbLocations").val()))) {
        cmbLocations = parseInt($("#cmbLocations").val());
    }
    if ($("#chkIdentificationActive")[0].checked === true) {
        cardselection = 1;
    }
    if ($("#chkDaypass")[0].checked === true) {
        cardselection = 2;
    }
    if ($("#chkWeekpass")[0].checked === true) {
        cardselection = 3;
    }
    jsonArray.push({
        LastName: $("#txtLastName").val(),
        FirstName: $("#txtFirstName").val(),
        Company: $("#txtCompany").val(),
        Street: $("#txtStreet").val(),
        StreetNr: $("#txtStreetNr").val(),
        PostalCode: $("#txtPostalCode").val(),
        PhysicalAddress: $("#txtPhysicalAddress").val(),
        PersonalNumber: $("#txtPersonalNr").val(),
        PersType: PersType,
        selectlocation: companyNo,
        CarRegnumber: $("#txtCarRegNo").val(),
        LocationID: locationID,
        DepartmentID: departmentID,
        CostCenterID: costCenterID,
        Memo: $("#txtMemo").val(),
        companyName: companyNm,
        companyNumber: companyNo,
        companyID: dplCompanyName.GetValue(),
        DateOfBirth: moment(DoBpicker.GetDate()).isValid() ? moment(DoBpicker.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        DateOfEntry: moment(DofEntry.GetDate()).isValid() ? moment(DofEntry.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        DateOfExit: moment(DofExit.GetDate()).isValid() ? moment(DofExit.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        Position: $("#txtPosition").val(),
        Nationality: $("#txtNationality").val(),
        CompTel: $("#txtCompTel").val(),
        CompMobile: $("#txtCompMobile").val(),
        PrivTel: $("#txtPrivTel").val(),
        PrivMobile: $("#txtPrivMobile").val(),
        CompanyEmail: $("#txtCompanyEmail").val(),
        PrivateEmail: $("#txtPrivateEmail").val(),
        CardNumber1a: $("#txtAccsDatanew").val(),
        CardNumber2a: $("#txtAccsDatanew2").val(),
        AccsDatanew: $("#txtAccsDatanew").val(),
        AccsDatanew2: $("#txtAccsDatanew2").val(),
        AusweisNr: $("#txtAusweisNr").val(),
        NurPincodeStr: $("#txtNurPincode").val(),
        SicherheitsPincodeStr: $("#txtSicherheitsPincode").val(),
        AutomaticLogout: $("#txtAutomaticLogout").val(),
        AccessPlanDateFrom: moment(dpAccessPlanDateFrom.GetDate()).isValid() ? moment(dpAccessPlanDateFrom.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        AccessPlanDateTo: moment(dpAccessPlanDateTo.GetDate()).isValid() ? moment(dpAccessPlanDateTo.GetDate()).format("YYYY-MM-DDT00:00:00.000") : null,
        ZuttritsplanNr: $("#txtZuttritsplanNr").val(),
        dateEdited: $("#txtdateEdited").val(),
        AccsDatanew: $("#chkIdentificationActive").val(),
        AusweisPincodeStr: $("#txtAusweisPincode").val(),
        IdentificationActive: $("#chkIdentificationActive")[0].checked,
        DayPass: $("#chkDaypass")[0].checked,
        WeekPass: $("#chkWeekpass")[0].checked,
        PincodeActives: $("#chkPincodeActive")[0].checked,
        NurPincodeActive: $("#chkNurPincodeActive")[0].checked,
        MenaceActive: $("#chkMenaceActive")[0].checked,
        PassPhoto: passportData,
        ActiveCardType: getActiveCardType(),
        PersonPhotoInBinary: personPhotoInBinary
    });

    return jsonArray;
}

function getActiveCardType() {
    var activeCardType = 0;
    if ($("#chkWeekpass")[0].checked) {
        activeCardType = 1;
    }
    if ($("#chkDaypass")[0].checked) {
        activeCardType = 2;
    }
    return activeCardType;
}

function SetControls(response) {

    ClearControlsNoRecord();

    if (response !== null) {


        if (response.Pers_Nr !== null && response.Pers_Nr !== 0) {
            try {
                cmbPersName.SetValue(response.Pers_Nr.toString());
                cmbIDNr.SetValue(response.Pers_Nr.toString());
                cmbAusweisNr.SetValue(response.Pers_Nr.toString());
                if (response.ClientID !== null) {
                    dplCompanyName.SetValue(response.ClientID.toString());
                    $("#txtCompanyName").val(response.CompanyName);
                } else {
                    dplCompanyName.SetValue("0");
                    $("#txtCompanyName").val("keine");
                }
                $("#chkIdentificationActive")[0].checked = response.CardActive;
                $("#chkImported")[0].checked = response.Imported;
                $("#chkPincodeActive")[0].checked = response.PinCodeStatus;
                if (response.LocationID !== null) {
                    cmbLocations.SetValue(response.LocationID);
                }
                else {
                    cmbLocations.SetValue(0);
                }
                if (response.DepartmentID !== null) {
                    cmbDepartments.SetValue(response.DepartmentID);
                }
                else {
                    cmbDepartments.SetValue(0);
                }
                if (response.CostCenterID !== null) {
                    cmbCostCenters.SetValue(response.CostCenterID);
                }
                else {
                    cmbCostCenters.SetValue(0);
                }
                if (response.PersType !== null) {
                    ddlPersType.SetValue(response.PersType);
                }
                else {
                    ddlPersType.SetValue("0");
                }
                DoBpicker.SetDate(response.DOBStr === null ? null : new Date(response.DOBStr));
                DofEntry.SetDate(response.EntryDateStr === null ? null : new Date(response.EntryDateStr));
                DofExit.SetDate(response.ExitDateStr === null ? null : new Date(response.ExitDateStr));
                dpAccessPlanDateFrom.SetDate(response.DateOfEntryStr === null ? null : new Date(response.DateOfEntryStr));
                dpAccessPlanDateTo.SetDate(response.DateOfExitStr === null ? null : new Date(response.DateOfExitStr));
                $("#txtLastName").val(response.LastName);
                $("#txtFirstName").val(response.FirstName);
                $("#txtCompany").val(response.companyName);
                $("#txtStreet").val(response.Street);
                $("#txtStreetNr").val(response.StreetNr);
                $("#txtPostalCode").val(response.PostalCode);
                $("#txtPhysicalAddress").val(response.PhysicalAddress);
                $("#txtPersonalNr").val(response.Pers_Nr);
                $("#txtCarRegNo").val(response.CarRegnumber),
                $("#txtMemo").val(response.Memo);
                $("#txtPosition").val(response.Position);
                $("#txtNationality").val(response.Nationality);
                $("#txtCompTel").val(response.CompTel);
                $("#txtCompMobile").val(response.CompanyMobile);
                $("#txtPrivTel").val(response.PrivTel);
                $("#txtPrivMobile").val(response.PrivateMobile);
                $("#txtCompanyEmail").val(response.CompanyEmail);
                $("#txtPrivateEmail").val(response.PrivateEmail);
                $("#txtAusweisNr").val(response.Card_Nr);
                $("#txtNurPincode").val(response.PinCode);
                $("#img").attr("Src", response.PassPhoto);
                $("#txtZuttritsplanNr").val(response.AccessPlanNr);
                $("#txtdateEdited").val(response.AccessPlanDescription);
                if (response.Imported === true) {
                }
                if (response.Imported === false) {
                }
                $("#txtAusweisPincode").val(response.AusweisPincode);
                $("#txtSicherheitsPincode").val(response.SicherheitsPincode);
                $("#chkPincodeActive")[0].checked = response.PincodeActives;
                $("#chkNurPincodeActive")[0].checked = response.NurPincodeActive;
                $("#chkMenaceActive")[0].checked = response.MenaceActive;

                switch (response.ActiveCardType) {
                    case 1:
                        $("#chkWeekpass")[0].checked = true;
                        $("#chkDaypass")[0].checked = false;
                        break;
                    case 2:
                        $("#chkWeekpass")[0].checked = false;
                        $("#chkDaypass")[0].checked = true;
                        break;
                    default:
                        $("#chkWeekpass")[0].checked = false;
                        $("#chkDaypass")[0].checked = false;
                        break;
                }

                if (response.Pers_Nr !== null && response.Pers_Nr !== 0) {
                    LastPersValue = response.Pers_Nr;
                    setTimeout(function (ev) { grdTransponders.PerformCallback(LastPersValue) }, 1);
                    setTimeout(function (ev) { grdTranspondersShortTerm.PerformCallback(LastPersValue) }, 1);
                }
                else if (response.Pers_Nr === 0) {
                    LastPersValue = response.Pers_Nr
                    setTimeout(function (ev) { grdTransponders.PerformCallback(LastPersValue) }, 1);
                    setTimeout(function (ev) { grdTranspondersShortTerm.PerformCallback(LastPersValue) }, 1);
                }

                StoreDataFromClientInSSession();

            } catch (e) {
                console.log(e);
            }
        }
    }
}

function ClearControls() {

    cmbClients.SetValue("0");
    cmbClientsName.SetValue("0");
    cmbLocation.SetValue("0");
    cmbDepartment.SetValue("0");
    cmbPersName.SetValue("0");
    cmbIDNr.SetValue("0");
    cmbAusweisNr.SetValue("0");
    dplCompanyName.SetValue("0");
    cmbLocations.SetValue("0");
    ddlPersType.SetValue("0");
    cmbDepartments.SetValue("0");
    cmbCostCenters.SetValue("0");
    dbPersTypeColor.SetValue(null);
    dpAccessPlanDateFrom.SetDate(null);
    DoBpicker.SetDate(null);
    DofEntry.SetDate(null);
    DofExit.SetDate(null);

    document.getElementById('txtPersonalNr').value = "";
    document.getElementById('txtFirstName').value = "";
    document.getElementById('txtLastName').value = "";
    document.getElementById('txtStreet').value = "";
    document.getElementById('txtStreetNr').value = "";
    document.getElementById('txtPostalCode').value = "";
    document.getElementById('txtPhysicalAddress').value = "";
    document.getElementById('chkActivatePersonal').checked = false;
    document.getElementById('txtMemo').value = "";
    document.getElementById('txtAusweisPincode').value = "";
    document.getElementById('txtAccsDatanew').value = "";
    document.getElementById('txtAccsDatanew2').value = "";
    document.getElementById('chkPincodeActive').checked = false;
    document.getElementById('txtNurPincode').value = "";
    document.getElementById('chkNurPincodeActive').checked = false;
    document.getElementById('txtSicherheitsPincode').value = "";
    document.getElementById('chkMenaceActive').checked = false;
    document.getElementById('txtAutomaticLogout').value = "";
    document.getElementById('txtZuttritsplanNr').value = "";
    document.getElementById('txtdateEdited').value = "";
    document.getElementById('txtZuttritsBezeichnung').value = "";
    document.getElementById('txtPosition').value = "";
    document.getElementById('txtNationality').value = "";
    document.getElementById('txtCompTel').value = "";
    document.getElementById('txtCompMobile').value = "";
    document.getElementById('txtPrivTel').value = "";
    document.getElementById('txtPrivMobile').value = "";
    document.getElementById('txtCompanyEmail').value = "";
    document.getElementById('txtPrivateEmail').value = "";
    document.getElementById('txtPersType').value = "";
    document.getElementById('txtPersTypeMemo').value = "";
    document.getElementById('txtClientNr').value = "";
    document.getElementById('txtClientName').value = "";

    StoreDataFromClientInSSession();

}

function ClearOtherControls() {
    $("#hiddenFieldSaveChanges").attr("value", "0");
    document.getElementById("cmbPersName").selectedIndex = 0;
    document.getElementById("cmbIDNr").selectedIndex = 0;
    document.getElementById("cmbAusweisNr").selectedIndex = 0;
    document.getElementById("cmbLocations").selectedIndex = 0;
    document.getElementById("cmbDepartment").selectedIndex = 0;
    ddlPersType.SetValue("0");
    document.getElementById("ddlCarType").selectedIndex = 0;
    cmbLocations.SetValue("0");
    cmbDepartments.SetValue("0");
    cmbCostCenters.SetValue("0");
    $("#chkIdentificationActive")[0].checked = false;
    $("#chkPincodeActive")[0].checked = false;
    $("#chkNurPincodeActive")[0].checked = false;
    $("#chkMenaceActive")[0].checked = false;
    dpAccessPlanDateFrom.SetDate(moment().toDate());
    dpAccessPlanDateTo.SetDate(moment().toDate());
    DoBpicker.SetDate(null);
    DofEntry.SetDate(null);
    DofExit.SetDate(null);
    document.getElementById('txtLastName').value = "";
    document.getElementById('txtFirstName').value = "";
    document.getElementById('txtCompany').value = "";
    document.getElementById('txtStreet').value = "";
    document.getElementById('txtStreetNr').value = "";
    document.getElementById('txtPostalCode').value = "";
    document.getElementById('txtPhysicalAddress').value = "";
    document.getElementById('txtPersonalNr').value = "";
    document.getElementById('txtCarRegNo').value = "";
    document.getElementById('txtMemo').value = "";
    document.getElementById('txtAusweisNr').value = "";
    document.getElementById('txtAusweisPincode').value = "";
    document.getElementById('txtAccsDatanew').value = "";
    document.getElementById('txtAccsDatanew2').value = "";
    document.getElementById('txtNurPincode').value = "";
    document.getElementById('txtSicherheitsPincode').value = "";
    document.getElementById('txtZuttritsplanNr').value = "";
    document.getElementById('txtdateEdited').value = "";
    document.getElementById('txtZuttritsBezeichnung').value = "";
    document.getElementById('txtAutomaticLogout').value = "";
    document.getElementById('txtPosition').value = "";
    document.getElementById('txtNationality').value = "";
    document.getElementById('txtCompTel').value = "";
    document.getElementById('txtCompMobile').value = "";
    document.getElementById('txtPrivTel').value = "";
    document.getElementById('txtPrivMobile').value = "";
    document.getElementById('txtCompanyEmail').value = "";
    document.getElementById('txtPrivateEmail').value = "";
    $("#img").attr("src", "");

    PageMethods.CalculateNextNr(CalculateNextNr_callback)

    StoreDataFromClientInSSession();

}

function ClearControlsNoRecord() {

    cmbClients.SetValue("0");
    cmbClientsName.SetValue("0");
    cmbLocation.SetValue("0");
    cmbDepartment.SetValue("0");
    cmbPersName.SetValue("0");
    cmbIDNr.SetValue("0");
    cmbAusweisNr.SetValue("0");
    dplCompanyName.SetValue("0");
    cmbLocations.SetValue("0");
    ddlPersType.SetValue("0");
    cmbDepartments.SetValue("0");
    cmbCostCenters.SetValue("0");
    dbPersTypeColor.SetValue(null);
    dpAccessPlanDateFrom.SetDate(null);
    DoBpicker.SetDate(null);
    DofEntry.SetDate(null);
    DofExit.SetDate(null);
    document.getElementById('txtPersonalNr').value = "";
    document.getElementById('txtFirstName').value = "";
    document.getElementById('txtLastName').value = "";
    document.getElementById('txtStreet').value = "";
    document.getElementById('txtStreetNr').value = "";
    document.getElementById('txtPostalCode').value = "";
    document.getElementById('txtPhysicalAddress').value = "";
    document.getElementById('chkActivatePersonal').value = "";
    document.getElementById('txtMemo').value = "";
    document.getElementById('txtAusweisPincode').value = "";
    document.getElementById('chkPincodeActive').value = "";
    document.getElementById('txtNurPincode').value = "";
    document.getElementById('chkNurPincodeActive').value = "";
    document.getElementById('txtSicherheitsPincode').value = "";
    document.getElementById('chkMenaceActive').value = "";
    document.getElementById('txtAutomaticLogout').value = "";
    document.getElementById('txtZuttritsplanNr').value = "";
    document.getElementById('txtdateEdited').value = "";
    document.getElementById('txtZuttritsBezeichnung').value = "";
    document.getElementById('txtPosition').value = "";
    document.getElementById('txtNationality').value = "";
    document.getElementById('txtCompTel').value = "";
    document.getElementById('txtCompMobile').value = "";
    document.getElementById('txtPrivTel').value = "";
    document.getElementById('txtPrivMobile').value = "";
    document.getElementById('txtCompanyEmail').value = "";
    document.getElementById('txtPrivateEmail').value = "";
    document.getElementById('txtPersType').value = "";
    document.getElementById('txtPersTypeMemo').value = "";
    document.getElementById('txtClientNr').value = "";
    document.getElementById('txtClientName').value = "";
    document.getElementById("cmbPersName").selectedIndex = 0;
    document.getElementById("cmbIDNr").selectedIndex = 0;
    document.getElementById("cmbAusweisNr").selectedIndex = 0;
    document.getElementById("cmbLocations").selectedIndex = 0;
    document.getElementById("cmbDepartment").selectedIndex = 0;
    ddlPersType.SetValue("0");
    document.getElementById("ddlCarType").selectedIndex = 0;
    cmbLocations.SetValue("0");
    cmbDepartments.SetValue("0");
    cmbCostCenters.SetValue("0");
    $("#chkIdentificationActive")[0].checked = false;
    $("#chkPincodeActive")[0].checked = false;
    $("#chkNurPincodeActive")[0].checked = false;
    $("#chkMenaceActive")[0].checked = false;
    dpAccessPlanDateFrom.SetDate(moment().toDate());
    dpAccessPlanDateTo.SetDate(moment().toDate());
    DoBpicker.SetDate(null);
    DofEntry.SetDate(null);
    DofExit.SetDate(null);
    document.getElementById('txtLastName').value = "";
    document.getElementById('txtFirstName').value = "";
    document.getElementById('txtCompany').value = "";
    document.getElementById('txtStreet').value = "";
    document.getElementById('txtStreetNr').value = "";
    document.getElementById('txtPostalCode').value = "";
    document.getElementById('txtPhysicalAddress').value = "";
    document.getElementById('txtPersonalNr').value = "";
    document.getElementById('txtCarRegNo').value = "";
    document.getElementById('txtMemo').value = "";
    document.getElementById('txtAusweisNr').value = "";
    document.getElementById('txtAusweisPincode').value = "";
    document.getElementById('txtNurPincode').value = "";
    document.getElementById('txtSicherheitsPincode').value = "";
    document.getElementById('txtZuttritsplanNr').value = "";
    document.getElementById('txtdateEdited').value = "";
    document.getElementById('txtZuttritsBezeichnung').value = "";
    document.getElementById('txtAutomaticLogout').value = "";
    document.getElementById('txtPosition').value = "";
    document.getElementById('txtNationality').value = "";
    document.getElementById('txtCompTel').value = "";
    document.getElementById('txtCompMobile').value = "";
    document.getElementById('txtPrivTel').value = "";
    document.getElementById('txtPrivMobile').value = "";
    document.getElementById('txtCompanyEmail').value = "";
    document.getElementById('txtPrivateEmail').value = "";
    $("#img").attr("src", "");
}

function CalculateNextNr_callback(succ) {
    document.getElementById('txtPersonalNr').value = succ;
    document.getElementById("cmbPersName").disabled = true;
    document.getElementById("cmbIDNr").disabled = true;
    document.getElementById("cmbAusweisNr").disabled = true;
    document.getElementById("cmbLocations").disabled = true;
    document.getElementById("cmbDepartment").disabled = true;
    dplCompanyName.SetValue("0");
    $("#txtCompanyName").val("keine");
    cmbPersName.SetEnabled(false);
    cmbIDNr.SetEnabled(false);
    cmbAusweisNr.SetEnabled(false);
    $("#txtFirstName").focus();
}

function FetchQueryString() {
    var qrStr = window.location.search;
    var spQrStr = qrStr.substring(1);
    var arrQrStr = new Array();
    var arr = spQrStr.split("&");
    for (var i = 0; i < arr.length; i++) {
        var index = arr[i].indexOf("=");
        var key = arr[i].substring(0, index);
        var val = arr[i].substring(index + 1);
        arrQrStr[key] = val;
    }
    if (arrQrStr["0F88"] !== null) {
        TempID = arrQrStr["0F88"];
        SetValues(TempID);
        setTimeout(CountPersonal, 1);
    }
    if (arrQrStr["ID"] !== null) {
        TempID = arrQrStr["ID"];
        SetValues(TempID);
        setTimeout(CountPersonal, 1);
    }
    if (arrQrStr.length === 0) {

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

                    var lnkNode = typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1] === 'undefined' ?
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

function GetActiveTransponderNr() {
    $("#txtAccsDatanew").val("");
    setTimeout(function (ev) { GetTransponderAusweisCount() }, 1);

    for (var rowCount = 0; rowCount < grdTransponders.keys.length; rowCount++) {
        var checked = false;
        if (grdTransponders.GetRow(rowCount).cells[2].childNodes[0].childNodes.length > 0) {
            checked = grdTransponders.GetRow(rowCount).cells[2].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        } else {
            checked = grdTransponders.GetRow(rowCount).cells[2].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        }

        if (checked) {
            $("#txtAccsDatanew").val(grdTransponders.GetRow(rowCount).cells[1].childNodes[0].textContent);
            return;
        }
    }
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

    $("#Label56").text(ausweisCount);
    $("#Label62").text(actionCount);
}

function GetActiveSTTransponderNr() {
    $("#txtAccsDatanew2").val("");
    setTimeout(function (ev) { GetTransponderSTAusweisCount() }, 1);

    for (var rowCount = 0; rowCount < grdTranspondersShortTerm.keys.length; rowCount++) {
        var checked = false;
        if (grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].childNodes.length > 0) {
            checked = grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        } else {
            checked = grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].className.toString().indexOf("CheckBoxChecked") !== -1;
        }

        if (checked) {
            $("#txtAccsDatanew2").val(grdTranspondersShortTerm.GetRow(rowCount).cells[1].childNodes[0].textContent);
            return;
        }
    }
}

function GetTransponderSTAusweisCount() {
    var ausweisCount = 0;
    for (var rowCount = 0; rowCount < grdTranspondersShortTerm.keys.length; rowCount++) {
        var rowKey = grdTranspondersShortTerm.keys[rowCount];
        if (parseInt(rowKey) > 0 && !(isNaN(parseInt(rowKey)))) {
            ausweisCount = ausweisCount + 1;
        }
    }

    $("#Label66").text(ausweisCount);
}

function ausweisChanged(sender, evt, senderNr) {
    var _senderGrd = senderNr === 1 ? grdTransponders : grdTranspondersShortTerm;
    var currentRowNum = senderNr === 1 ? grdTranspondersRowNum : grdTranspondersSTRowNum;
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
                        if (senderNr === 1) {
                            inactiveChkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                            inactiveDateNode.textContent = moment().format("DD.MM.YYYY");
                        }
                    } catch (e) { }
                }
            }
        }
    }
    $("#chkWeekpass")[0].checked = senderNr === 1;
    $("#chkDaypass")[0].checked = senderNr !== 1;
    inActivateOtherTransponderGrd(senderNr);
}

function activeCheckedChanged(sender, evt, senderNr) {
    var _senderGrd = senderNr === 1 ? grdTransponders : grdTranspondersShortTerm;
    var currentRowNum = senderNr === 1 ? grdTranspondersRowNum : grdTranspondersSTRowNum;
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

    $("#chkWeekpass")[0].checked = senderNr === 1;
    $("#chkDaypass")[0].checked = senderNr !== 1;
    inActivateOtherTransponderGrd(senderNr);
}

function inActivateOtherTransponderGrd(senderNr) {
    var sender = senderNr === 1 ? grdTranspondersShortTerm : grdTransponders;

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
    grdTransponderInactiveHist.PerformCallback(String.format('{{"persNr": "{0}", "transponderNr": "{1}"}}', cmbPersName.GetValue(), transponderNr));

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

function CreateHistoryUpdateObject() {
    try {
        histUpdate = [{}];
    } catch (e) { }
}

function UpdateHistoryUpdateObject(rowIndex, rowValue) {
    try {
        if (histUpdate === null) CreateHistoryUpdateObject();
        histUpdate[0][grdTransponders.keys[grdTranspondersRowNum]] = rowValue;
    } catch (e) { }
    grdTransponderInactiveHist.batchEditHelper.EndEdit();
}

function displaycarddata() {
    $(".sectionAccessData").hide();
    $(".sectionFoto").hide();
    $(".webCamMode").hide();
    $(".readergrid").show();
    hiddenStatus = 10;
}
function hidecarddata() {
    $(".sectionAccessData").show();
    $(".sectionFoto").show();
    $(".webCamMode").hide();
    $(".readergrid").hide();
}
function WebcamMode() {
    $(".sectionAccessData").hide();
    $(".sectionFoto").hide();
    $(".webCamMode").show();
    hiddenStatus = 9;
    AttachWebcam();
}
function HideWebCam() {
    StopWebcam();
    $(".webCamMode").hide();
    $(".sectionAccessData").show();
    $(".sectionFoto").show();
}

$(document).on('keydown', function (e) {
    if (e.keyCode === 27) {
        HideWebCam();
    }
});

function ClearControlsOnNew() {
    dplCompanyName.SelectIndex(0);
    $("#txtClientName").val("");
    $("#txtClientName").focus();
    CountPersonal();
}

function grdvwgrdClientsRowClick(s, e) {
    window.grdClients.GetRowValues(e.visibleIndex, "ID;Client_Nr;Name", GetRowValues);
}
function loadGridAfterUpdate(response) {
    grdClients.PerformCallback();

}

function grdClientsClientsRowDblClick(s, e) {
    window.grdClients.GetRowValues(e.visibleIndex, "ID;Client_Nr;Name", FillControls);
    HideCompanyGrid();
}
function FillControls() {
    var index = grdClients.GetFocusedRowIndex();
    var ID = grdClients.GetRowKey(index);
    dplCompanyName.SetValue(ID);
}

function FilltxtClientNr(response) {
    document.getElementById('txtClientNr').value = response;
    $("#txtClientName").focus();
}

function GetRowValues(values) {
    var vtemrID = values[0].toString();
    var VtermGrpNr = values[1].toString();
    var VtermName = values[2].toString();
    document.getElementById('txtClientNr').value = VtermGrpNr;
    document.getElementById('txtClientName').value = VtermName;
    ClientID = values[0].toString();
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
    getLocalizedText("personal");
    $('#pagenamelbl').text("Landzeitausweise");
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
    getLocalizedText("personal");
    $('#pagenamelbl').text(levelCaption);
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
    getLocalizedText("personal");
    $('#pagenamelbl').text("Kurzzeitausweise");
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
    getLocalizedText("personal");
    $('#pagenamelbl').text(levelCaption);
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
function SavePersType() {
    var id = $("#txtPersTypeId").val();
    var persType = $("#txtPersType").val();
    var persMemo = $("#txtPersTypeMemo").val();
    var persTypeColor = dbPersTypeColor.GetColor() !== undefined ? dbPersTypeColor.GetColor() : "";
    PageMethods.CreateEditPersType(id, persType, persMemo, persTypeColor, OnCreateEditPersType_CallBack);
}
function OnCreateEditPersType_CallBack(result) {
    $("#txtPersTypeId").val(result.ID);
    grdPersType.PerformCallback();
    ddlPersType.PerformCallback();
}
function grdPersTypeRowClick(s, e) {
    window.grdPersType.GetRowValues(e.visibleIndex, "ID;Name;Memo;PersTypeColor", GetRowValuesPersType);
}
function GetRowValuesPersType(values) {
    $("#txtPersTypeId").val(values[0]);
    $("#txtPersType").val(values[1]);
    $("#txtPersTypeMemo").val(values[2]);
    dbPersTypeColor.SetColor(values[3]);
}
function grdPersTypeRowDbClick(s, e) {
    var id = grdPersType.GetRowKey(e.visibleIndex);
    ddlPersType.SetValue(id);
    hidePersTypeGrid();
    hiddenStatus = 0;
}
function ddlPersTypeEndCallback(s, e) {
    if (isDelete === true) {
        if (ddlPersType.FindItemByValue(selectedPersType) !== null) {
            ddlPersType.SetValue(selectedPersType);
        }
        else {
            ddlPersType.SetValue("0");
        }
        isDelete = false;
    }
    else {
        ddlPersType.SetValue(selectedPersType);
    }

}
function Delete_PersType() {
    var id = $("#txtPersTypeId").val();
    PageMethods.DeletePersType(id, OnDeletePersType_CallBack)
}
function OnDeletePersType_CallBack(id) {
    isDelete = true;
    $("#txtPersTypeId").val("");
    $("#txtPersType").val("");
    $("#txtPersTypeMemo").val("");
    dbPersTypeColor.SetColor();
    grdPersType.PerformCallback();
    ddlPersType.PerformCallback();
}
function GetPass(pass) {
    var persNr = cmbAusweisNr.GetValue();
    if (persNr !== undefined && persNr !== "" && parseInt(persNr) !== 0 && (parseInt(pass) === 1 || parseInt(pass) === 2))
        window.open('CardPrint.aspx?Passtype=' + pass + '&Id=' + persNr, 'popup_window', 'width=300,height=400,left=600,top=100,resizable=no');
}

function DPass() {

}

function cboPersonNameSearchSelectionChanged(s, e) {
    if (!isNaN(parseInt(s.GetValue()))) {
        var id = s.GetValue();
        //console.log("id: " + id);
        cmbPersName.SetValue(id);
        cmbIDNr.SetValue(id);
        cmbAusweisNr.SetValue(id);
        //var Current = cmbAusweisNr.GetSelectedIndex();
        //console.log("Current: " + Current);
        //$("#txtFvCurrentEntry").val(Current);
        //PageMethods.GetPersonnelByNr(id, SetControls);
        PageMethods.Getpersonal(id, SetControls);
    }
    CountPersonal();

}

function ConfirmDeleteCard() {
    var message = "Sind Sie sicher das Sie das Ausweis tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelDelete(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 40%; margin-right: 0px;"  onclick="_DeleteCard(); return false;"></button><button id="btnCancel"  onclick="CancelDelete(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    getLocalizedText("permitCardDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelCardDeletion");
    $('#btnCancel').text(levelCaption);
}

function _DeleteCard() {
    HideDialog();
    if (hiddenStatus === 4) {
        if (!isNaN(parseInt(grdTransponders.GetSelectedKeysOnPage()[0]))) {
            var id = parseInt(grdTransponders.GetSelectedKeysOnPage()[0]);
            if (id > 0) {
                var type = 1;
                var persNr = cmbIDNr.GetValue();
                if (parseInt(persNr) > 0) {
                    InitialPageLoadPanel.Show();
                    PageMethods.DeleteCard(id, persNr, type, OnDeleteCard_CallBack);
                }

            }
        }
    }
    else if (hiddenStatus === 5) {
        if (!isNaN(parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]))) {
            var id = parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]);
            if (id > 0) {
                var type = 2;
                var persNr = cmbIDNr.GetValue();
                if (parseInt(persNr) > 0) {
                    InitialPageLoadPanel.Show();
                    PageMethods.DeleteCard(id, persNr, type, OnDeleteCard_CallBack);
                }

            }
        }
    }
}
function OnDeleteCard_CallBack(type) {
    switch (type) {
        case 1:
            grdTransponders.PerformCallback(cmbIDNr.GetValue());
            break;
        case 2:
            grdTranspondersShortTerm.PerformCallback(cmbIDNr.GetValue());
            break;
    }
    InitialPageLoadPanel.Hide();
}

function ConfirmRemovePhoto() {
    var message = "Sind Sie sicher das Sie das Foto tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelDelete(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 49%; margin-right: 0px;"  onclick="Remove_Photo()"></button><button id="btnCancel" style="width: 128px;"  onclick="CancelDelete(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
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

function ConfirmApplyPhoto() {
    var message = "Übernehmen Foto?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="HideDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%; width:130px; color: forestgreen !important; margin-right: 0px;"  onclick="ApplyPhotoM()"></button><button id="btnCancel" style="width: 175px; color: red !important; margin-left: 0px;" onclick=" CancelApplyPhoto(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('ImportantDialogBox').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnCancel').text(levelCaption);
}
function ApplyPhotoM() {
    $("#hiddenFieldSaveChanges").attr("value", "1");
    applyPhoto = false;
    HideDialog();
    AcceptPhoto();
    if (hiddenStatus === 9) {
        HideWebCam();
        hiddenStatus = 0;
    }
}

function CancelApplyPhoto() {
    HideDialog();
    HideWebCam();
    hiddenStatus = 0;
}

function OnClient_CallBack(result) {
    if (result.ID !== null && result.ID !== 0) {
        dplCompanyName.SetValue(result.ID);
    }
}

function AccessGroupIndexChanged(sender, evt) {

    var selectedItem = sender.GetSelectedItem();
    var selectedValue = sender.GetValue();
    var selectedNr = selectedItem.texts[0];
    var selectedName = selectedItem.texts[1];
    var currentRow = $(sender.GetMainElement()).parents("tr")[0];
    var otherAccessGroupDrp = sender === cmbPersAccessGroupNr ? cmbPersAccessGroupName : cmbPersAccessGroupNr;
    otherAccessGroupDrp.SetValue(selectedValue);
    grdAccessGroups.batchEditApi.SetCellValue(currentRow.rowIndex - 1, 1, selectedValue, selectedNr);
    grdAccessGroups.batchEditApi.SetCellValue(currentRow.rowIndex - 1, 2, selectedValue, selectedName);
}

function AccessGroupFocused(sender, evt) {
    var currentRow = $(sender.GetMainElement()).parents("tr")[0];
    var rowIndex = currentRow.rowIndex - 1;
    var rowId = parseInt(grdAccessGroups.keys[rowIndex]);

    if (typeof grdAccessGroups.batchEditHelper.updatedValues[(rowId).toString()] !== "undefined") {
        for (var y = 1; y < 3; y++) {
            if (typeof grdAccessGroups.batchEditHelper.updatedValues[(rowId).toString()][y] !== "undefined") {
                if (typeof grdAccessGroups.batchEditHelper.updatedValues[(rowId).toString()][y][0] !== "undefined") {
                    var updatedAccessGroupId = parseInt(grdAccessGroups.batchEditHelper.updatedValues[(rowId).toString()][y][0]);

                    if (!isNaN(updatedAccessGroupId)) {
                        sender.SetValue(updatedAccessGroupId);
                        var otherAccessGroupDrp = sender === cmbPersAccessGroupNr ? cmbPersAccessGroupName : cmbPersAccessGroupNr;
                        otherAccessGroupDrp.SetValue(updatedAccessGroupId);
                    }
                }
            }
        }
    } else {
        if (typeof grdAccessGroups.batchEditPageValues[rowId] !== "undefined") {
            var serverdAccessGroupId = parseInt(grdAccessGroups.batchEditPageValues[rowId][1]);

            if (!isNaN(serverdAccessGroupId)) {
                sender.SetValue(serverdAccessGroupId);
                var otherAccessGroupDrp = sender === cmbPersAccessGroupNr ? cmbPersAccessGroupName : cmbPersAccessGroupNr;
                otherAccessGroupDrp.SetValue(serverdAccessGroupId);
            }
        }
    }
}



