var levelCaption="";
var cancelCreateNew;
var hiddenStatus = 0;
var saveChanges = false;
var isNewMode = false;
var accessProfileClick = false;
$(function () {
     $(".InfoHeaderFloatRight").show();
     $(".InfoHeaderFloatRightnew").hide();

     $("#btnEntNew").click(
       function (evt) {
           evt.preventDefault();
           if (parseInt(ddlAccessGroupNumber.GetValue()) > 0) {
               CalculateNextNr();
               SetControlsOnNew();
           }
           else {
               isNewMode = true;
               alert("Ausgewählte Gruppe.");
               return false;
           }

       });
     $("#btnEntSave").click(
      function (evt) {
          evt.preventDefault();
          SaveAccessPlan();
      });
     $("#btnCancelDel").click(
      function (evt) {
          evt.preventDefault();
          if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
              ConfirmDeletePLan();
          }
      });
     $("#btnPersonnel").click(
           function (evt) {
               evt.preventDefault();
               if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                   SetSessionRedirect("AccessPlanPersonal.aspx");
               }
           });
     $("#imageBtnPersonen").click(
           function (evt) {
               evt.preventDefault();
               if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                   SetSessionRedirect("AccessPlanPersonal.aspx");
               }

           });
     $("#btnMembers").click(
                function (evt) {
                    evt.preventDefault();
                    if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                        SetSessionRedirect("AccessPlanMembers.aspx");
                    }
                });
     $("#btnImagemembers").click(
                function (evt) {
                    evt.preventDefault();
                    if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                        SetSessionRedirect("AccessPlanMembers.aspx");
                    }

                });
     $("#btnReader").click(
               function (evt) {
                   evt.preventDefault();
                   if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                       SetSessionRedirect("AccessPlanReader.aspx");
                   }
               });
     $("#imageBtnReader").click(
                function (evt) {
                    evt.preventDefault();
                    if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                        SetSessionRedirect("AccessPlanReader.aspx");
                    }

                });
     $("#btnAccessProfile").click(
               function (evt) {
                   evt.preventDefault();
                   if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                       SetSessionRedirect("AccessPlanAccessCalender.aspx");
                   }
               });
     $("#imageBtnAccessCalender").click(
               function (evt) {
                   evt.preventDefault();
                   if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                       SetSessionRedirect("AccessPlanAccessCalender.aspx");
                   }

               });

     $("#btnHoliday").click(
               function (evt) {
                   evt.preventDefault();
                   if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                       SetSessionRedirect("AccessPlanHolidaySchedule.aspx");
                   }
               });
     $("#imageBtnHolidayCalender").click(
               function (evt) {
                   evt.preventDefault();
                   if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
                       SetSessionRedirect("AccessPlanHolidaySchedule.aspx");
                   }

               });
    $("#btnPersonen").click(
      function (evt) {
          evt.preventDefault();
          if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
              SetSessionRedirect("AccessPlanPersonal.aspx");
          }
      });

    $("#btnMember").click(
      function (evt) {
          evt.preventDefault();
          if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
              SetSessionRedirect("AccessPlanMembers.aspx");
          }
      });

    $("#btnReaderHeader").click(
      function (evt) {
          evt.preventDefault();
          if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
              SetSessionRedirect("AccessPlanReader.aspx");
          }
      });

    $("#btnAccessCalederHeader").click(
      function (evt) {
          evt.preventDefault();
          if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
              SetSessionRedirect("AccessPlanAccessCalender.aspx");
          }
      });

    $("#btnHolidayCalenderHeader").click(
      function (evt) {
          evt.preventDefault();
          if (parseInt(ddlAccessProfileNumber.GetValue()) > 0) {
              SetSessionRedirect("AccessPlanHolidaySchedule.aspx");
          }
      });

    $("#btnSearch").click(function (evt) {
        evt.preventDefault();
        $(".ControlSecarea1new2ab").hide();
        $(".wrapperaccess1newab").hide();
        $("#btnEntNew").hide();
        $("#btnEntSave").hide();
        $("#btnCancelDel").hide();
        $(".ControlGrid").show();
        hiddenStatus = 1;
    });
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (hiddenStatus === 0) {
            //document.location.href = "/Index.aspx";
            switch (saveChanges && allowZUTEdit) {
                case true:
                    BackButtonConfirm();
                    break;
                case false:
                    window.location.href = "/Index.aspx";
                    break;
                default:
                    window.location.href = "/Index.aspx";
                    break;
            }
        }
        else if (hiddenStatus === 1) {
            $(".ControlSecarea1new2ab").show();
            $(".wrapperaccess1newab").show();
            $("#btnEntNew").show();
            $("#btnEntSave").show();
            $("#btnCancelDel").show();
            $(".ControlGrid").hide();
            hiddenStatus = 0;
        }
    });

    $("#txtAccessProfileNumber").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");
        saveChanges = true;
    });

    $("#txtAccessProfileName").change(function () {
        $("#hiddenFieldDetectChanges").attr("value", "1");
        saveChanges = true;
    });

});

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlan.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function LoadProfiles(s, e) {

}
function SaveAccessPlan() {
    var ID = 0;
    var groupId = 0;
    var planNr =  $("#txtAccessProfileNumber").val();
    var planName =  $("#txtAccessProfileName").val();
    if (!isNaN(parseInt(ddlAccessProfileNumber.GetValue()))) {
        ID = ddlAccessProfileNumber.GetValue();
    }
    if (!isNaN(parseInt(ddlAccessGroupNumber.GetValue()))) {
        groupId = ddlAccessGroupNumber.GetValue();
    }
    if (parseInt(groupId) < 1) {
        alert("Wählen Sie Gruppe");
        return;
    }
    if (parseInt(planNr) < 1) {
        alert("Plan-Zugangsnummer eingeben");
        return;
    }
    saveChanges = false;
    PageMethods.SaveAccessPlan(ID, planNr, planName, groupId, OnSaveAccessPlan_CallBack);
}
function OnSaveAccessPlan_CallBack(id) {
    accessProfileClick = false;
    EnableDropdowns();
    var _passValue = id + ';' + ddlAccessGroupName.GetValue() + ';' + "0";
    ddlAccessProfileNumber.PerformCallback(_passValue);
    ddlAccessProfileName.PerformCallback(_passValue);
    grdAccessProfileList.PerformCallback();
}
function SaveAccessPlanOnBack() {
    HideDialog();
    var ID = 0;
    var groupId = 0;
    var planNr = $("#txtAccessProfileNumber").val();
    var planName = $("#txtAccessProfileName").val();
    if (!isNaN(parseInt(ddlAccessProfileNumber.GetValue()))) {
        ID = ddlAccessProfileNumber.GetValue();
    }
    if (!isNaN(parseInt(ddlAccessGroupNumber.GetValue()))) {
        groupId = ddlAccessGroupNumber.GetValue();
    }
    if (parseInt(groupId) < 1) {
        alert("Wählen Sie Gruppe");
        return;
    }
    if (parseInt(planNr) < 1) {
        alert("Plan-Zugangsnummer eingeben");
        return;
    }
    PageMethods.SaveAccessPlan(ID, planNr, planName, groupId, OnSaveAccessPlanOnBack_CallBack);
}
function OnSaveAccessPlanOnBack_CallBack() {
    window.location.href = "/Index.aspx";
}
function groupNumberSelectedIndexChanged(s, e) {
    ddlAccessGroupName.SetValue(s.GetValue());
    $("#txtAccessGroupNumber").val(s.GetText());
    $("#txtAccessGroupName").val(ddlAccessGroupName.GetText());
    if (isNewMode === true) {
        isNewMode = false;
        CalculateNextNr();
        SetControlsOnNew();
    }
    else {
        var _passValue = "0" + ';' + ddlAccessGroupName.GetValue() + ';' + "1";
        ddlAccessProfileNumber.PerformCallback(_passValue);
        ddlAccessProfileName.PerformCallback(_passValue);
    }

}
function groupNameSelectedIndexChanged(s, e) {
    ddlAccessGroupNumber.SetValue(s.GetValue());
    $("#txtAccessGroupNumber").val(ddlAccessGroupNumber.GetText());
    $("#txtAccessGroupName").val(s.GetText());
    if (isNewMode === true) {
        isNewMode = false;
        CalculateNextNr();
        SetControlsOnNew();
    }
    else {
        var _passValue = "0" + ';' + ddlAccessGroupName.GetValue() + ';' + "1";
        ddlAccessProfileNumber.PerformCallback(_passValue);
        ddlAccessProfileName.PerformCallback(_passValue);
    }

}
function profileNameSelectedIndexChanged(s, e) {
    if (accessProfileClick === true) {
        ddlAccessProfileNumber.SetValue(s.GetValue());
        $("#txtAccessProfileNumber").val(ddlAccessProfileNumber.GetText());
        $("#txtAccessProfileName").val(s.GetText());
        SetButtonMode(s.GetValue());
        PageMethods.ReturnGroupId(s.GetValue(), OnReturnGroupId_CallBack);
    }
}
function profileNumberSelectedIndexChanged(s, e) {
    if (accessProfileClick === true) {
        ddlAccessProfileName.SetValue(s.GetValue());
        $("#txtAccessProfileNumber").val(s.GetText());
        $("#txtAccessProfileName").val(ddlAccessProfileName.GetText());
        SetButtonMode(s.GetValue());
        PageMethods.ReturnGroupId(s.GetValue(), OnReturnGroupId_CallBack);
    }

}
function EnableButtons() {
    $("#btnPersonnel").prop("disabled", false);
    $("#btnReader").prop("disabled", false);
    $("#btnAccessProfile").prop("disabled", false);
    $("#btnHoliday").prop("disabled", false);
    $("#btnMembers").prop("disabled", false);

    $("#btnPersonen").prop("disabled", false);
    $("#btnMember").prop("disabled", false);
    $("#btnReaderHeader").prop("disabled", false);
    $("#btnAccessCalederHeader").prop("disabled", false);
    $("#btnHolidayCalenderHeader").prop("disabled", false);

    $("#imageBtnPersonen").css('cursor', 'pointer');
    $("#btnImagemembers").css('cursor', 'pointer');
    $("#imageBtnReader").css('cursor', 'pointer');
    $("#imageBtnAccessCalender").css('cursor', 'pointer');
    $("#imageBtnHolidayCalender").css('cursor', 'pointer');
}
function DisableButtons() {
    $("#btnPersonnel").prop("disabled", true);
    $("#btnReader").prop("disabled", true);
    $("#btnAccessProfile").prop("disabled", true);
    $("#btnHoliday").prop("disabled", true);
    $("#btnMembers").prop("disabled", true);

    $("#btnPersonen").prop("disabled", true);
    $("#btnMember").prop("disabled", true);
    $("#btnReaderHeader").prop("disabled", true);
    $("#btnAccessCalederHeader").prop("disabled", true);
    $("#btnHolidayCalenderHeader").prop("disabled", true);

    $("#imageBtnPersonen").css('cursor', 'default');
    $("#btnImagemembers").css('cursor', 'default');
    $("#imageBtnReader").css('cursor', 'default');
    $("#imageBtnAccessCalender").css('cursor', 'default');
    $("#imageBtnHolidayCalender").css('cursor', 'default');
}
function SetButtonMode(value) {
    if (parseInt(value) > 0) {
        EnableButtons();
    }
    else {
        DisableButtons();
    }
}
function CalculateNextNr() {
    PageMethods.GetNextPlanNr(OnGetNextPlanNr_CallBack);
}
function OnGetNextPlanNr_CallBack(value) {
    $("#txtAccessProfileNumber").val(value);
    $("#txtAccessProfileName").focus();
}
function dplAccessProfileClick(s, e) {
    accessProfileClick = true;
}
function profileNumberEndCallBack(s, e) {
    $("#txtAccessProfileNumber").val(s.GetText());
    SetButtonMode(s.GetValue());
}
function profileNameEndCallBack(s, e) {
    $("#txtAccessProfileName").val(s.GetText());
}
function OnReturnGroupId_CallBack(value) {
    ddlAccessGroupNumber.SetValue(value);
    ddlAccessGroupName.SetValue(value);
    $("#txtAccessGroupNumber").val(ddlAccessGroupNumber.GetText());
    $("#txtAccessGroupName").val(ddlAccessGroupName.GetText());
}
function SetControlsOnNew() {
    ddlAccessProfileNumber.SetValue("0");
    ddlAccessProfileName.SetValue("0");
    ddlAccessProfileNumber.SetEnabled(false);
    ddlAccessProfileName.SetEnabled(false)
    $("#txtAccessProfileName").val("");
}
function EnableDropdowns() {
    ddlAccessProfileNumber.SetEnabled(true);
    ddlAccessProfileName.SetEnabled(true);
}
function DeleteAccessPlan() {
    HideDialog();
    var id = ddlAccessProfileNumber.GetValue();
    PageMethods.DeleteAccessPlan(id, OnDeleteAccessPlan_CallBack);
}
function OnDeleteAccessPlan_CallBack() {
    accessProfileClick = false;
    ddlAccessGroupNumber.SetValue("0");
    ddlAccessGroupName.SetValue("0");
    $("#txtAccessGroupNumber").val(ddlAccessGroupNumber.GetText());
    $("#txtAccessGroupName").val(ddlAccessGroupName.GetText());
    var _passValue = "0" + ';' + ddlAccessGroupName.GetValue() + ';' + "0";
    ddlAccessProfileNumber.PerformCallback(_passValue);
    ddlAccessProfileName.PerformCallback(_passValue);
}
// dialogs
function ConfirmDeletePLan() {
    //getLocalizedText("Sind Sie sicher, dass Sie löschen möchten");
    //var message = levelCaption;
    var message = "Sind Sie sicher, dass Sie löschen möchten?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnDeleteOk"  style="margin-left: 30%; margin-right: 0px;"  onclick="DeleteAccessPlan()"></button><button id="btnCancelDelete"  onclick="CancelOnBackButton(); return false;" style=" position: relative;margin-left: 10px"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteAccessPlan");
    $('#btnDeleteOk').text(levelCaption);
    getLocalizedText("cancelDeleteAccessPlan");
    $('#btnCancelDelete').text(levelCaption);
}
function CancelOnBackButton() {
    HideDialog();
}
function HideDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}
function No_OnBack() {
    HideDialog();
    window.location.href = "/Index.aspx";
}
function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%;width: 130px; margin-right: 0px;"  onclick="SaveAccessPlanOnBack()"></button><button id="btnNo" style="margin-left: 10px;width: 155px;"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
    //getLocalizedText("cancel");
    //$('#btnCancel').text(levelCaption);
}
//end dialogs
function grdProfilesRowDbClick(s, e) {
    accessProfileClick = false;
    var id = s.GetRowKey(e.visibleIndex);
    var _passValue = id + ';' + "0" + ';' + "0";
    PageMethods.ReturnGroupId(id, OnReturnGroupId_CallBack);
    ddlAccessProfileNumber.PerformCallback(_passValue);
    ddlAccessProfileName.PerformCallback(_passValue);
    HideSearchGrid();
}
function HideSearchGrid() {
    $(".ControlSecarea1new2ab").show();
    $(".wrapperaccess1newab").show();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $(".ControlGrid").hide();
    hiddenStatus = 0;
}
function SetSessionRedirect(url) {
    var groupId = ddlAccessGroupNumber.GetValue();
    var groupNr = ddlAccessGroupNumber.GetText();
    var groupName = ddlAccessGroupName.GetText();
    var planId = ddlAccessProfileNumber.GetValue();
    var planNr = ddlAccessProfileNumber.GetText();
    var planName = ddlAccessProfileName.GetText();
    if (parseInt(planId) < 1) return;
    PageMethods.SetSessionValues(groupId, groupNr, groupName, planId, planNr, planName, url, OnSetSessionValues_CallBack);
}
function OnSetSessionValues_CallBack(url) {
    window.location.href = url;
}