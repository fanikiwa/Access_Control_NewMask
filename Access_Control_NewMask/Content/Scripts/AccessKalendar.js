
var levelCaption = "";
var deletemode = 0;
var accessProfileId = 0;
var backValue = 0;
var isDplClick = false;

$(function () {
    $('#btnSearchProfiles').prop('disabled', true);

    $(document).on("selectstart", false);
    var mode = $("#hiddenFieldFormMode").attr("value");

    $("#btnSearchAccessProfile").click(function (evt) {
        evt.preventDefault();
        backValue = 1;
        $("#btnNew").hide();
        $("#btnSave").hide();
        $("#btnCancelDel").hide();
        showAccessProfileSearchTable();
    });
    $("#btnActHelp").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnApplyAccessProfile").click(function (evt) {
        evt.preventDefault();
        var index = gridViewAccessProfileSearch.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            gridViewAccessProfileSearch.GetRowValues(index, "ID;AccessProfileNo;AccessDescription", GetAccessProfileRowValues);
        }
    });

    $("#btnSave").click(
        function (evt) {
            evt.preventDefault();
            if ($("#txtCalendarNr").val().trim() === "" || $("#txtCalendarNr").val().trim() === "0") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            }
            else {
                $("#btnCancelDel").removeAttr("disabled");
                save();
                //SetDisplayMode();
            }
        });
    $("#btnBack").click(
        function (evt) {
            evt.preventDefault();
            var saveChanges =  allowZUTEdit ? parseInt($("#hiddenFieldSaveChanges").val()) : 0;
            if (backValue === 0) {
                switch (saveChanges) {
                    case 1:
                        BackButtonSaveChanges();
                        break;
                    case 0:
                        document.location.href = "/Content/Settings.aspx";
                        break;
                    default:
                        document.location.href = "/Content/Settings.aspx";
                        break;
                }
            }
            else if (backValue === 1) {
                hideAccessProfileSearchTable();
                backValue = 0;
            }
            else if (backValue === 2) {
                HideAccessProfiles();
                backValue = 0;
            }
        });

    //$("#btnNew").click(
    //    function (evt) {
    //        evt.preventDefault();
    //        grdAccessCalendar.PerformCallback(-999);


    //        $("#dplCalendarName").val(0);
    //        $("#dplCalendarNr").val(0);
    //        $("#txtCalendarNr").focus();
    //        $("#txtCalendarName").val();
    //        setNextAccessKalendarNo();
    //        $("#dplCalendarNr").attr("disabled", "disabled");
    //        $("#dplCalendarName").attr("disabled", "disabled");
    //        $("#btnCancelDel").attr("disabled", "disabled");
    //        //SetNewMode();
    //    });

    $("#btnEdit").click(
        function (evt) {
            evt.preventDefault();
            if ($("#txtCalendarNr").val().trim() === "" || $("#txtCalendarNr").val().trim() === "0") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            } else if ($("#txtCalendarName").val().trim() === "" || $("#txtCalendarName").val().trim() === "keine") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            } else {
                //0 - None, 1 - Display, 2 - Create, 3 - Edit
                $("#hiddenFieldFormMode").attr("value", "3");

                $("#sectionAccessProfile").removeAttr("disabled");

                grdAccessCalendar.PerformCallback(-888);
                //SetEditMode();
            }
        });


    $("#btnWeek").click(function (e) {
        e.preventDefault();
        $("#chkMonday").prop("checked", "checked");
        $("#chkTuesday").prop("checked", "checked");
        $("#chkWednesday").prop("checked", "checked");
        $("#chkThursday").prop("checked", "checked");
        $("#chkFriday").prop("checked", "checked");
        $("#chkSaturday").prop("checked", "checked");
        $("#chkSunday").prop("checked", "checked");

    });

    $("#btnmonFri").click(function (e) {
        e.preventDefault();
        $("#chkMonday").prop("checked", "checked");
        $("#chkTuesday").prop("checked", "checked");
        $("#chkWednesday").prop("checked", "checked");
        $("#chkThursday").prop("checked", "checked");
        $("#chkFriday").prop("checked", "checked");
        $("#chkSaturday").removeAttr("checked");
        $("#chkSunday").removeAttr("checked");

    });

    $("#btnSattoSun").click(function (e) {
        e.preventDefault();
        $("#chkMonday").removeAttr("checked");
        $("#chkTuesday").removeAttr("checked");
        $("#chkWednesday").removeAttr("checked");
        $("#chkThursday").removeAttr("checked");
        $("#chkFriday").removeAttr("checked");
        $("#chkSaturday").prop("checked", "checked");
        $("#chkSunday").prop("checked", "checked");

    });

    $("#btnCancelDel").click(
       function (evt) {
           evt.preventDefault();

           if ($("#txtCalendarNr").val().trim() === "" || $("#txtCalendarNr").val().trim() === "0") {

               getLocalizedText("noSelection");

               alert(levelCaption);
           }
               //else if ($("#txtCalendarName").val().trim() === "" || $("#txtCalendarName").val().trim() === "keine") {

               //    getLocalizedText("noSelection");

               //    alert(levelCaption);
               //}
           else {

               var selectval = dplCalendarNr.GetValue();
               if (parseInt(selectval) > 0) {
                   DeleteButtonConfirm();
               }



           }
       });
    $("#txtCalendarNr").change(function (e) {
        e.preventDefault();

        $("#hiddenFieldSaveChanges").attr("value", "1");
    });
    $("#txtCalendarName").change(function (e) {
        e.preventDefault();

        $("#hiddenFieldSaveChanges").attr("value", "1");
    });

    $("#btnApply").click(
        function (evt) {
            evt.preventDefault();

            getLocalizedText("daysOftheWeekSelectionWarning");
            var message = levelCaption;

            var atLeastOneIsChecked = $('input:checkbox').is(':checked');
            if (atLeastOneIsChecked === false) {
                alert(message);
                return;
            }
            var accessProfileNr = ddlProfileId.GetText();
            getLocalizedText("accessProfileSelectionWarning");
            var message = levelCaption;

            if ((accessProfileNr === undefined) || (accessProfileNr === null) || (accessProfileNr.trim().length === 0) || accessProfileNr === "keine") {

                alert(message);

                //$("#ddlProfileId").focus();

                return;
            }

            $("#hiddenFieldSaveChanges").attr("value", "1");
            SetgrdCalendarAccessprofile();

            $("#btnSave").removeAttr("disabled");
        });

    $("#btnApplySelectedCalender").click(
      function (evt) {
          evt.preventDefault();
          var saveChanges = parseInt($("#hiddenFieldSaveChanges").val());
          if (saveChanges === 1) {
              ApplyConfirmation();
          }
          else {
              var index = grdHolidayCalndr.GetFocusedRowIndex();
              var calendarId = grdHolidayCalndr.GetRowKey(index);

              if (parseInt(calendarId) > 0) {
                  dplCalendarNr.SetValue(calendarId);
                  dplCalendarName.SetValue(calendarId);
                  $("#txtCalendarNr").val(dplCalendarNr.GetText());
                  $("#txtCalendarName").val(dplCalendarName.GetText());
                  window.grdAccessCalendar.PerformCallback(calendarId);
              }
          }


      });

    //$("#btnCalendarYearPrevious").click(function (e) {
    //    var selectedIndex = $("#ddlCalendarYear option:selected").index();
    //    if (selectedIndex === 0) {
    //        return;
    //    }
    //    $("#ddlCalendarYear").prop("selectedIndex", (selectedIndex - 1));
    //});
    //$("#btnCalendarYearNext").click(function (e) {
    //    var calendarYears = [];
    //    $("#ddlCalendarYear option").each(function () {
    //        calendarYears.push(this.text);
    //    });
    //    var calendarYearsCount = calendarYears.length;
    //    var selectedIndex = $("#ddlCalendarYear option:selected").index();
    //    selectedIndex += 1;
    //    if (selectedIndex === calendarYearsCount) {
    //        return;
    //    }
    //    $("#ddlCalendarYear").prop("selectedIndex", (selectedIndex));
    //});

    $("#btnTariffYearPrevious").click(function (e) {
        e.preventDefault();

        var selectedIndex = $("#ddlTariffYear option:selected").index();

        if (selectedIndex === 0) {
            return;
        }

        $("#ddlTariffYear").prop("selectedIndex", (selectedIndex - 1));
    });

    $("#btnTariffYearNext").click(function (e) {
        e.preventDefault();

        var tariffYears = [];

        $("#ddlTariffYear option").each(function () {
            tariffYears.push(this.text);
        });

        var tariffYearsCount = tariffYears.length;
        var selectedIndex = $("#ddlTariffYear option:selected").index();
        selectedIndex += 1;

        if (selectedIndex === tariffYearsCount) {
            return;
        }

        $("#ddlTariffYear").prop("selectedIndex", (selectedIndex));
    });

    $(document).keyup(function (e) {
        if (e.keyCode === 27) {//escape
            removeAllHighlighting();
        }
    });

    $("#btnSearchProfiles").click(function (evt) {
        evt.preventDefault();
        if (dplAccessProfileNr.GetValue().trim() != "" && dplAccessProfileNr.GetValue().trim() != "0") {
            backValue = 2;
            getLocalizedText("accssCalendarSttngs");
            $("#PageTitleLbl2").text(levelCaption);
            getLocalizedText("viewaccesscalenderprofile");
            $("#pagenamelbl").text(levelCaption);
            $(".table").hide();
            $(".tblAccessProfiles").show();
            $(".bottomsectiondivleft1aTop").hide();
            $("#btnNew").hide();
            $("#btnSave").hide();
            $("#btnCancelDel").hide();
            $(".bottomsectiondivrightbBottom").hide();
            $(".bottomsectiondivNew ").css({ width: "100%" });
            $(".bottomsectiondivrightbBottom ").css("display", "none");
            $(".secCalendarSelection ").css("display", "none");
            $("#txtAccessProfileMemo").val($("#dplAccessProfileMemo option:selected").text());

            window.grdZuttritProfileTimeFrames.PerformCallback(ddlProfileId.GetText().trim());

        }

    });

    $("#btnCalendarYearPrevious").click(function (evt) {
        evt.preventDefault();
        if (parseInt(dplCalendarNr.GetValue()) < 1) {
            MoveToPreviousYear();
        }
    });
    $("#btnCalendarYearNext").click(function (evt) {
        evt.preventDefault();
        if (parseInt(dplCalendarNr.GetValue()) < 1) {
            MoveToNextYear();
        }
    });
    $("#btnSearchAllEmp").click(function (evt) {
        evt.preventDefault();

    });
    $("#btnTariffYearPrevious").click(function (evt) {
        evt.preventDefault();

    });
    $("#btnTariffYearNext").click(function (evt) {
        evt.preventDefault();

    });
    $("#btnNewAccessProfile").click(function (evt) {
        evt.preventDefault();
        var formMode = 2;
        if (parseInt(dplCalendarNr.GetValue()) > 0) {
            formMode = 3;
        }
        var saveChanges = parseInt($("#hiddenFieldSaveChanges").val());
        if (saveChanges === 1) {
            RedirectConfirmation();
        }
        else {
            PageMethods.ReturnUrl(formMode, ReturnUrl_CallBack);
        }
    });
});
function ReturnUrl_CallBack(url) {
    window.location.href = url;
}
function hideAccessProfileSearchTable() {
    $("#searchAccessProfile").hide();
    $("#accessGroupDiv").show();
    $("#btnNew").show();
    $("#btnSave").show();
    $("#btnCancelDel").show();

}
function showAccessProfileSearchTable() {
    $("#accessGroupDiv").hide();
    $("#searchAccessProfile").show();
}
function HideAccessProfiles() {
    $(".tblAccessProfiles").hide();
    $(".bottomsectiondivrightbBottom").show();
    $(".bottomsectiondivleft1aTop").show();
    $("#btnNew").show();
    $("#btnSave").show();
    $("#btnCancelDel").show();
    $("#PageTitleLbl2").text('');
    getLocalizedText("accessCalendar");
    $("#pagenamelbl").text(levelCaption);
    $(".table").show();
    $(".bottomsectiondivNew ").css({ width: "81%" });
    $(".bottomsectiondivrightbBottom ").css("display", "block");
    $(".secCalendarSelection ").css("display", "block");
}

function DeleteCalender_Callback(response) {
    $("#chkMonday").removeAttr("checked");
    $("#chkTuesday").removeAttr("checked");
    $("#chkWednesday").removeAttr("checked");
    $("#chkThursday").removeAttr("checked");
    $("#chkFriday").removeAttr("checked");
    $("#chkSaturday").removeAttr("checked");
    $("#chkSunday").removeAttr("checked");
    dplAccessProfileNr.SetValue(0);
    dplAccessProfileName.SetValue(0);
    ddlProfileId.SetValue(0);

    dplCalendarNr.PerformCallback();
    dplCalendarName.PerformCallback();
    $("#txtCalendarNr").val(0);
    $("#txtCalendarName").val("keine");
    $("#txtMemo").val("");
    grdAccessCalendar.PerformCallback(0);
    grdHolidayCalndr.PerformCallback(0);
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessKalendar.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

function SetInitialMode() {
    //$("#dplCalendarNr").prop("disabled", "disabled");
    //$("#dplCalendarName").attr("disabled", "disabled");
    dplCalendarNr.SetEnabled(true);
    dplCalendarName.SetEnabled(true);

    $("#txtCalendarNr").attr("disabled", "disabled");
    $("#txtCalendarName").attr("disabled", "disabled");
    $("#txtMemo").attr("disabled", "disabled");
    $("#ddlTariffYear").attr("disabled", "disabled");
    $("#panelWorkdays").attr("disabled", "disabled");
    $("#sectionAccessProfile").attr("disabled", "disabled");
    $("#btnWeek").attr("disabled", "disabled");
    $("#btnmonFri").attr("disabled", "disabled");
    $("#btnSattoSun").attr("disabled", "disabled");

    $("#btnSave").attr("disabled", "disabled");
    $("#btnEdit").attr("disabled", "disabled");
    $("#btnCancelDel").attr("disabled", "disabled");
    $("#btnApply").attr("disabled", "disabled");

    //$("#txtCalendarNr").val($("#dplCalendarNr option:selected").text());
    //$("#txtCalendarName").val($("#dplCalendarName option:selected").text());
    $("#txtCalendarNr").val(dplCalendarNr.GetText());
    $("#txtCalendarName").val(dplCalendarName.GetText());

    getLocalizedText("deleteButton");
    $("#btnCancelDel").val(levelCaption);

    $("#btnCancelDel").data("mode", "Löschen");

    $("#btnNew").removeAttr("disabled");

    $("#btnDateFromPrevious").attr("disabled", "disabled");
    $("#btnDateFromNext").attr("disabled", "disabled");

    $("#btnDateToPrevious").attr("disabled", "disabled");
    $("#btnDateToNext").attr("disabled", "disabled");

    window.datePickerDateFrom.SetEnabled(false);
    window.datePickerDateTo.SetEnabled(false);

    //0 - None, 1 - Display, 2 - Create, 3 - Edit
    $("#hiddenFieldFormMode").attr("value", "0");
}

function SetInitialModeAfterDelete() {
    dplCalendarNr.SetEnabled(true);
    dplCalendarName.SetEnabled(true);


    $("#txtCalendarNr").attr("disabled", "disabled");
    $("#txtCalendarName").attr("disabled", "disabled");
    $("#txtMemo").attr("disabled", "disabled");
    $("#ddlTariffYear").attr("disabled", "disabled");
    $("#panelWorkdays").attr("disabled", "disabled");
    $("#sectionAccessProfile").attr("disabled", "disabled");
    $("#btnWeek").attr("disabled", "disabled");
    $("#btnmonFri").attr("disabled", "disabled");
    $("#btnSattoSun").attr("disabled", "disabled");

    $("#btnSave").attr("disabled", "disabled");
    $("#btnEdit").attr("disabled", "disabled");
    $("#btnCancelDel").attr("disabled", "disabled");
    $("#btnApply").attr("disabled", "disabled");

    //$("#txtCalendarNr").val($("#dplCalendarNr option:selected").text());
    //$("#txtCalendarName").val($("#dplCalendarName option:selected").text());
    $("#txtCalendarNr").val(dplCalendarNr.GetText());
    $("#txtCalendarName").val(dplCalendarName.GetText());

    getLocalizedText("deleteButton");
    $("#btnCancelDel").val(levelCaption);
    $("#btnCancelDel").removeAttr("disabled");
    $("#btnCancelDel").data("mode", "Löschen");


    $("#btnNew").removeAttr("disabled");
    $("#btnEdit").removeAttr("disabled");
    $("#btnCancelDel").removeAttr("disabled");

    $("#btnDateFromPrevious").attr("disabled", "disabled");
    $("#btnDateFromNext").attr("disabled", "disabled");

    $("#btnDateToPrevious").attr("disabled", "disabled");
    $("#btnDateToNext").attr("disabled", "disabled");

    window.datePickerDateFrom.SetEnabled(false);
    window.datePickerDateTo.SetEnabled(false);

    //0 - None, 1 - Display, 2 - Create, 3 - Edit
    $("#hiddenFieldFormMode").attr("value", "0");
}

function SetEditMode() {
    //$("#txtCalendarNr").removeAttr("disabled");
    //$("#txtCalendarName").removeAttr("disabled");
    //$("#txtMemo").removeAttr("disabled");

    //$("#btnSave").removeAttr("disabled");
    //$("#btnApply").removeAttr("disabled");
    //$("#btnWeek").removeAttr("disabled");
    //$("#btnmonFri").removeAttr("disabled");
    //$("#btnSattoSun").removeAttr("disabled");

    //$("#btnNew").attr("disabled", "disabled");
    //$("#btnEdit").attr("disabled", "disabled");

    //getLocalizedText("cancel");
    //$("#btnCancelDel").val(levelCaption);

    //$("#btnCancelDel").data("mode", "Abbrechen");

    //$("#txtMemo").removeAttr("disabled");
    //$("#ddlTariffYear").removeAttr("disabled");
    //$("#panelWorkdays").removeAttr("disabled");
    //$("#sectionAccessProfile").removeAttr("disabled");
    //$("#sectionWeekButtons").removeAttr("disabled");

    //$("#btnDateFromPrevious").removeAttr("disabled");
    //$("#btnDateFromNext").removeAttr("disabled");

    //$("#btnDateToPrevious").removeAttr("disabled");
    //$("#btnDateToNext").removeAttr("disabled");

    //window.datePickerDateFrom.SetEnabled(true);
    //window.datePickerDateTo.SetEnabled(true);
}

function SetNewMode() {
    $("#txtCalendarNr").removeAttr("disabled");
    $("#txtCalendarName").removeAttr("disabled");
    $("#txtMemo").removeAttr("disabled");

    //$("#txtCalendarNr").val("");
    $("#txtCalendarName").val("");
    $("#txtMemo").val("");

    $("#btnApply").removeAttr("disabled");
    $("#btnWeek").removeAttr("disabled");
    $("#btnmonFri").removeAttr("disabled");
    $("#btnSattoSun").removeAttr("disabled");

    $("#btnWeek").removeAttr("disabled");
    $("#btnmonFri").removeAttr("disabled");
    $("#btnSattoSun").removeAttr("disabled");

    $("#ddlTariffYear").removeAttr("disabled");
    $("#panelWorkdays").removeAttr("disabled");
    $("#sectionAccessProfile").removeAttr("disabled");
    $("#sectionWeekButtons").attr("disabled");

    //$("#dplCalendarNr").attr("disabled", "disabled");
    //$("#dplCalendarName").attr("disabled", "disabled");
    dplCalendarNr.SetEnabled(false);
    dplCalendarName.SetEnabled(false);

    $("#btnNew").attr("disabled", "disabled");
    $("#btnEdit").attr("disabled", "disabled");
    $("#btnSave").attr("disabled", "disabled");
    $("#txtCalendarDate").val(moment().format("DD.MM.YYYY"));
    getLocalizedText("cancel");
    //$("#btnCancelDel").val(levelCaption);
    $("#btnCancelDel").attr("disabled", "disabled");
    $("#btnCancelDel").data("mode", "Abbrechen");

    $("#btnDateFromPrevious").removeAttr("disabled");
    $("#btnDateFromNext").removeAttr("disabled");

    $("#btnDateToPrevious").removeAttr("disabled");
    $("#btnDateToNext").removeAttr("disabled");

    window.datePickerDateFrom.SetEnabled(true);
    window.datePickerDateTo.SetEnabled(true);

    //0 - None, 1 - Display, 2 - Create, 3 - Edit
    $("#hiddenFieldFormMode").attr("value", "2");
}

function SetDisplayMode() {
    //$("#dplCalendarNr").prop("disabled", "disabled");
    //$("#dplCalendarName").attr("disabled", "disabled");
    dplCalendarNr.SetEnabled(true);
    dplCalendarName.SetEnabled(true);

    $("#txtCalendarNr").attr("disabled", "disabled");
    $("#txtCalendarName").attr("disabled", "disabled");
    $("#txtMemo").attr("disabled", "disabled");
    $("#ddlTariffYear").attr("disabled", "disabled");
    $("#panelWorkdays").attr("disabled", "disabled");
    $("#sectionAccessProfile").attr("disabled", "disabled");
    $("#sectionWeekButtons").attr("disabled", "disabled");

    $("#btnSave").attr("disabled", "disabled");
    $("#btnApply").attr("disabled", "disabled");

    //$("#txtCalendarNr").val($("#dplCalendarNr option:selected").text());
    //$("#txtCalendarName").val($("#dplCalendarName option:selected").text());
    $("#txtCalendarNr").val(dplCalendarNr.GetText());
    $("#txtCalendarName").val(dplCalendarName.GetText());

    getLocalizedText("deleteButton");
    $("#btnCancelDel").val(levelCaption);

    $("#btnCancelDel").data("mode", "Löschen");

    $("#btnNew").removeAttr("disabled");
    $("#btnCancelDel").removeAttr("disabled");
    $("#btnEdit").removeAttr("disabled");

    $("#btnDateFromPrevious").attr("disabled", "disabled");
    $("#btnDateFromNext").attr("disabled", "disabled");

    $("#btnDateToPrevious").attr("disabled", "disabled");
    $("#btnDateToNext").attr("disabled", "disabled");

    window.datePickerDateFrom.SetEnabled(false);
    window.datePickerDateTo.SetEnabled(false);

    //0 - None, 1 - Display, 2 - Create, 3 - Edit
    $("#hiddenFieldFormMode").attr("value", "1");
}

function setNextAccessKalendarNo() {
    var maxNo = 0;
    var currNo = [];

    //$("#dplCalendarNr option").each(function () {
    //    currNo.push(this.text);
    //});
    for (var i = 0;i < dplCalendarNr.GetItemCount() ;i++) {
        currNo.push(dplCalendarNr.GetItem(i).text);
    }
    maxNo = Math.max.apply(Math, currNo);
    maxNo++;
    $("#txtCalendarNr").val(maxNo);
}

function save() {
    resetImportantInfoDialogDiv();
    if (dplCalendarNr.GetValue() === "0") {
        PageMethods.CreateAccessCalendar($("#txtCalendarNr").val(), $("#txtCalendarName").val(), $("#txtMemo").val(), dplAccessProfileNr.GetValue(), $("#chkMonday")[0].checked, $("#chkTuesday")[0].checked, $("#chkWednesday")[0].checked, $("#chkThursday")[0].checked, $("#chkFriday")[0].checked, $("#chkSaturday")[0].checked, $("#chkSunday")[0].checked, GetDailyScheduleValues(), OnSave_Callback);
    } else {
        PageMethods.UpdateAccessCalendar(dplCalendarNr.GetValue(), $("#txtCalendarNr").val(), $("#txtCalendarName").val(), $("#txtMemo").val(), dplAccessProfileNr.GetValue(), $("#chkMonday")[0].checked, $("#chkTuesday")[0].checked, $("#chkWednesday")[0].checked, $("#chkThursday")[0].checked, $("#chkFriday")[0].checked, $("#chkSaturday")[0].checked, $("#chkSunday")[0].checked, GetDailyScheduleValues(), OnEdit_Callback);
    }
}
function saveOnBack() {

    if (dplCalendarNr.GetValue() === "0") {
        PageMethods.CreateAccessCalendar($("#txtCalendarNr").val(), $("#txtCalendarName").val(), $("#txtMemo").val(), dplAccessProfileNr.GetValue(), $("#chkMonday")[0].checked, $("#chkTuesday")[0].checked, $("#chkWednesday")[0].checked, $("#chkThursday")[0].checked, $("#chkFriday")[0].checked, $("#chkSaturday")[0].checked, $("#chkSunday")[0].checked, GetDailyScheduleValues(), saveOnBack_Callback);
    } else {
        PageMethods.UpdateAccessCalendar(dplCalendarNr.GetValue(), $("#txtCalendarNr").val(), $("#txtCalendarName").val(), $("#txtMemo").val(), dplAccessProfileNr.GetValue(), $("#chkMonday")[0].checked, $("#chkTuesday")[0].checked, $("#chkWednesday")[0].checked, $("#chkThursday")[0].checked, $("#chkFriday")[0].checked, $("#chkSaturday")[0].checked, $("#chkSunday")[0].checked, GetDailyScheduleValues(), saveOnBack_Callback);
    }
}
function saveOnBack_Callback() {
    document.location.href = "/Content/Settings.aspx";
}

function SetgrdCalendarAccessprofile() {
    var accessProfileNr = ddlProfileId.GetText();
    getLocalizedText("accessProfileSelectionWarning");
    var message = levelCaption;

    if ((accessProfileNr === undefined) || (accessProfileNr === null) || (accessProfileNr.trim().length === 0)) {

        alert(message);

        //$("#ddlProfileId").focus();

        return;
    }

    //var calendarYear = Number($("#ddlCalendarYear option:selected").val());
    var calendarYear = Number(window.ddlCalendarYear2.GetSelectedItem().value);
    if (calendarYear === 0) {
        $("#ddlCalendarYear").focus();

        return;
    }

    for (var rowIndex = 0;rowIndex <= 11;rowIndex++) {
        for (var columnIndex = 1;columnIndex <= 31;columnIndex++) {
            var cell = grdAccessCalendar.GetRow(rowIndex).cells[columnIndex];

            if ((cell.style.backgroundColor === "rgb(255, 246, 3)") || (cell.style.backgroundColor === "rgb(47, 181, 159)")) {//highlighted

                var daysDate = new Date(calendarYear, rowIndex, columnIndex);
                var dayOfWeek = daysDate.getDay();

                switch (dayOfWeek) {
                    case 0: //sunday
                        if (($("#chkSunday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            cell.childNodes[0].textContent = "So";
                        }
                        break;
                    case 1: //monday
                        if (($("#chkMonday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 2: //tuesday
                        if (($("#chkTuesday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 3: //wednesday
                        if (($("#chkWednesday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 4: //thursday
                        if (($("#chkThursday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 5: //friday
                        if (($("#chkFriday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            //cell.childNodes[0].textContent = "";
                        }
                        break;
                    case 6: //saturday
                        if (($("#chkSaturday").is(":checked"))) {
                            cell.childNodes[0].textContent = accessProfileNr;
                        } else {
                            cell.childNodes[0].textContent = "Sa";
                        }
                        break;
                }
            }
        }
    }
}

function OnSave_Callback(response) {
    dplCalendarNr.SetEnabled(true);
    dplCalendarName.SetEnabled(true);
    ddlCalendarYear2.SetEnabled(false);

    $("#txtCalendarNr").val(response.Calendar_Nr);
    $("#txtCalendarName").val(response.Calendar_Name);
    $("#txtCalendarDate").val(moment(response.CalendarDate).format("DD.MM.YYYY"));
    $("#btnCancelDel").removeAttr("disabled");
    $("#btnNew").removeAttr("disabled");
    $("#hiddenFieldSaveChanges").attr("value", "0");
    dplCalendarNr.PerformCallback(response.ID);
    dplCalendarName.PerformCallback(response.ID);
    SetCheckboxesandprofileonselection(response);
    grdAccessCalendar.PerformCallback(response.ID);
    grdHolidayCalndr.PerformCallback(response.ID);
}

function OnEdit_Callback(response) {

    ddlCalendarYear2.SetEnabled(false);
    $("#txtCalendarNr").val(response.Calendar_Nr);
    $("#txtCalendarName").val(response.Calendar_Name);
    $("#txtCalendarDate").val(moment(response.CalendarDate).format("DD.MM.YYYY"));
    $("#hiddenFieldSaveChanges").attr("value", "0");
    dplCalendarNr.PerformCallback(response.ID);
    dplCalendarName.PerformCallback(response.ID);
    SetCheckboxesandprofileonselection(response);
    grdAccessCalendar.PerformCallback(response.ID);
    grdHolidayCalndr.PerformCallback(response.ID);
}

function GetAccessCalendar_Callback(response) {
    $("#txtCalendarNr").val(response.Calendar_Nr);
    $("#txtCalendarName").val(response.Calendar_Name);
    SetCheckboxesandprofileonselection(response);
    grdAccessCalendar.PerformCallback(response.ID);
    grdHolidayCalndr.PerformCallback(response.ID);
}
function GetAccessCalendarSelection_Callback(response) {
    $("#txtCalendarNr").val(response.Calendar_Nr);
    $("#txtCalendarName").val(response.Calendar_Name);
    SetCheckboxesandprofileonselection(response);
    grdAccessCalendar.PerformCallback(response.ID);
}

function SetCheckboxesandprofileonselection(response) {
    if (response.CheckMon === true) {
        $("#chkMonday").prop("checked", "checked");
    } else {

        $("#chkMonday").removeAttr("checked");
    }
    if (response.CheckTue === true) {
        $("#chkTuesday").prop("checked", "checked");

    } else {

        $("#chkTuesday").removeAttr("checked");
    }
    if (response.CheckWed === true) {
        $("#chkWednesday").prop("checked", "checked");

    } else {

        $("#chkWednesday").removeAttr("checked");
    }
    if (response.CheckThur === true) {
        $("#chkThursday").prop("checked", "checked");

    } else {

        $("#chkThursday").removeAttr("checked");
    }
    if (response.CheckFri === true) {
        $("#chkFriday").prop("checked", "checked");

    } else {

        $("#chkFriday").removeAttr("checked");
    }
    if (response.CheckSat === true) {
        $("#chkSaturday").prop("checked", "checked");

    } else {

        $("#chkSaturday").removeAttr("checked");
    }
    if (response.CheckSun === true) {
        $("#chkSunday").prop("checked", "checked");

    } else {

        $("#chkSunday").removeAttr("checked");
    }

    dplAccessProfileNr.SetValue(response.AccessProfileID);
    dplAccessProfileName.SetValue(response.AccessProfileID);
    ddlProfileId.SetValue(response.AccessProfileID);
    $("#txtMemo").val(response.Memo);

    $("#txtCalendarDate").val(moment(response.CalendarDate).format("DD.MM.YYYY"));
}

var isMouseDown = false;
var cellStartIndex = 0;
var cellEndIndex = 0;

var rowStartIndex = -1;
var rowEndIndex = -1;
function OnMouseDown(cell, rowIndex) {
    var currentCellIndex = cell.cellIndex;
    if (currentCellIndex === 0) {//skip Month Column
        isMouseDown = false;

        return;
    }

    rowStartIndex = rowIndex;
    cellStartIndex = cell.cellIndex;
    isMouseDown = true;
}

function OnMouseUp(cell, rowIndex) {
    cellEndIndex = cell.cellIndex;
    rowEndIndex = rowIndex;
    isMouseDown = false;
    var _year = parseInt(ddlTariffYear2.GetText());
    CalculateStartDate(rowStartIndex, cellStartIndex, _year);
    CalculateEndDate(rowEndIndex, cellEndIndex, _year);
}

function OnMouseMove(cell, rowIndex) {
    var formMode = $("#hiddenFieldFormMode").attr("value");

    //if (formMode <= 1) {
    //    return;
    //}

    var currentCellIndex = cell.cellIndex;
    if (currentCellIndex === 0) {//skip Month Column
        return;
    }

    if (isMouseDown) {
        if (rowStartIndex === -1) {
            if (isValidDate(rowIndex, cell.cellIndex)) {
                if (isWeekend(rowIndex, cell.cellIndex)) {
                    cell.style.backgroundColor = "#2FB59F";
                } else {
                    cell.style.backgroundColor = "#FFF603";
                }
            } else {
                cell.style.backgroundColor = "black";
            }

            return;
        }

        for (var i = rowStartIndex;i <= rowIndex;i++) {
            var rowCells = grdAccessCalendar.GetRow(i).cells;

            for (var j = cellStartIndex;j <= currentCellIndex;j++) {
                var selectedCell = rowCells[j];

                if (isValidDate(i, j)) {
                    if (isWeekend(i, j)) {
                        selectedCell.style.backgroundColor = "#2FB59F";
                    } else {
                        selectedCell.style.backgroundColor = "#FFF603";
                    }
                } else {
                    cell.style.backgroundColor = "black";
                }
            }
        }
    }
}

function activateProfile(s, e) {
    if (s.valueChecked) {
        for (var rowNumber = 0;rowNumber < 10;rowNumber++) {
            try {
                grdZuttritProfileTimeFrames.GetRow(rowNumber).cells[0].childNodes[0].className === "dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys";
                grdZuttritProfileTimeFrames.GetRow(rowNumber).cells[0].childNodes[0].children[0].className === "dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys";
            } catch (e) {
            }
        }
    }
}

function OnCellClick(cell, rowIndex) {
    var fieldName = cell.attributes["celltype"].value;

    if (fieldName !== "MonthName") {
        removeAllHighlighting();
        var clickedCellVal = cell.textContent;

        if (clickedCellVal.length >= 1) {
            if ((clickedCellVal !== "Sa") && (clickedCellVal !== "So")) {

                backValue = 2;

                getLocalizedText("accssCalendarSttngs");
                $("#PageTitleLbl2").text(levelCaption);
                $(".table").hide();
                $(".tblAccessProfiles").show();
                $(".bottomsectiondivleft1aTop").hide();
                $("#btnNew").hide();
                $("#btnSave").hide();
                $("#btnCancelDel").hide();
                $(".bottomsectiondivrightbBottom").hide();
                $(".bottomsectiondivNew ").css({ width: "100%" });
                $(".bottomsectiondivrightbBottom ").css("display", "none");
                $(".secCalendarSelection ").css("display", "none");
                window.grdZuttritProfileTimeFrames.PerformCallback(clickedCellVal);


                //}
            }
        }
    }
    else {
        var accessCalendarId = dplCalendarNr.GetValue();
        var calendarMonth = (rowIndex + 1);
        var data = { accessCalendarId: accessCalendarId, calendarMonth: calendarMonth };

        $.ajax({
            type: "POST",
            async: false,
            url: "AccessKalendar.aspx/GetAccessProfilesByMonth",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function () {
                window.location.href = "AccessCalenderMonth.aspx";
            }
        });
    }
    RebindBackButton();
}

function RebindBackButton() {
    //$("#btnBack").unbind("click");
    //$("#btnBack").bind("click", function (evt) {
    //    evt.preventDefault();
    //    var mode = $("#hiddenFieldSearchValue").attr("value");
    //    if (mode === "1") {
    //        hideAccessProfileSearchTable();
    //    } else {
    //        document.location.href = "AccessKalendar.aspx";
    //    }
    //});
}

function removeAllHighlighting() {
    for (var rowNumber = 0;rowNumber <= 11;rowNumber++) {
        var rowCells = grdAccessCalendar.GetRow(rowNumber).cells;

        for (var currentCellIndex = 1;currentCellIndex <= 31;currentCellIndex++) {
            var cell = rowCells[currentCellIndex];

            if (isValidDate(rowNumber, currentCellIndex)) {
                if (isWeekend(rowNumber, currentCellIndex)) {
                    cell.style.backgroundColor = "green";
                } else {
                    cell.style.backgroundColor = "white";
                }
            } else {
                cell.style.backgroundColor = "black";
            }
        }
    }
}

function isValidDate(rowIndex, columnIndex) {
    var month = Number(rowIndex) + 1;

    var calendarYear = new Date().getFullYear();
    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + columnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();

    return isValid;
}

function isWeekend(rowIndex, columnIndex) {
    var calendarYear = new Date().getFullYear();

    var daysDate = new Date(calendarYear, rowIndex, columnIndex);
    var dayOfWeek = daysDate.getDay();

    if ((dayOfWeek === 6) || (dayOfWeek === 0)) {
        return true;
    } else {
        return false;
    }
}

function GetDailyScheduleValues() {

    var jsonArray = [];

    for (var rowNumber = 0;rowNumber <= 11;rowNumber++) {
        var rowCells = grdAccessCalendar.GetRow(rowNumber).cells;

        jsonArray.push({
            AccessCalendarID: dplCalendarNr.GetValue(),
            AccessCalendarMonthNr: rowNumber + 1,
            Day1AccessProfile: rowCells[1].childNodes[0].textContent,
            Day2AccessProfile: rowCells[2].childNodes[0].textContent,
            Day3AccessProfile: rowCells[3].childNodes[0].textContent,
            Day4AccessProfile: rowCells[4].childNodes[0].textContent,
            Day5AccessProfile: rowCells[5].childNodes[0].textContent,
            Day6AccessProfile: rowCells[6].childNodes[0].textContent,
            Day7AccessProfile: rowCells[7].childNodes[0].textContent,
            Day8AccessProfile: rowCells[8].childNodes[0].textContent,
            Day9AccessProfile: rowCells[9].childNodes[0].textContent,
            Day10AccessProfile: rowCells[10].childNodes[0].textContent,
            Day11AccessProfile: rowCells[11].childNodes[0].textContent,
            Day12AccessProfile: rowCells[12].childNodes[0].textContent,
            Day13AccessProfile: rowCells[13].childNodes[0].textContent,
            Day14AccessProfile: rowCells[14].childNodes[0].textContent,
            Day15AccessProfile: rowCells[15].childNodes[0].textContent,
            Day16AccessProfile: rowCells[16].childNodes[0].textContent,
            Day17AccessProfile: rowCells[17].childNodes[0].textContent,
            Day18AccessProfile: rowCells[18].childNodes[0].textContent,
            Day19AccessProfile: rowCells[19].childNodes[0].textContent,
            Day20AccessProfile: rowCells[20].childNodes[0].textContent,
            Day21AccessProfile: rowCells[21].childNodes[0].textContent,
            Day22AccessProfile: rowCells[22].childNodes[0].textContent,
            Day23AccessProfile: rowCells[23].childNodes[0].textContent,
            Day24AccessProfile: rowCells[24].childNodes[0].textContent,
            Day25AccessProfile: rowCells[25].childNodes[0].textContent,
            Day26AccessProfile: rowCells[26].childNodes[0].textContent,
            Day27AccessProfile: rowCells[27].childNodes[0].textContent,
            Day28AccessProfile: rowCells[28].childNodes[0].textContent,
            Day29AccessProfile: rowCells[29].childNodes[0].textContent,
            Day30AccessProfile: rowCells[30].childNodes[0].textContent,
            Day31AccessProfile: rowCells[31].childNodes[0].textContent
        });
    }

    var jsonString = JSON.stringify(jsonArray);
    return jsonString;
}

function ValidateValueNumber(val) {
    if (isNaN(val) || val.trim() === "") {
        return 0;
    }
    else {

        $("#dplAccessProfileNr option").each(function () {
            //console.log(this.text +" "+ this.value);
            if ($(this).html() === val) {
                val = this.value;
            }
        });

        return val;
    }
}

function gridViewAccessProfileRowClick(s, e) {
    gridViewAccessProfileSearch.GetRowValues(e.visibleIndex, "ID;AccessProfileNo;AccessDescription", GetAccessProfileRowValues);
}

function GetAccessProfileRowValues(values) {
    var accessProfileId = values[0].toString();

    dplAccessProfileNr.SetValue(accessProfileId);
    dplAccessProfileName.SetValue(accessProfileId);
    ddlProfileId.SetValue(accessProfileId);

    $("#searchAccessProfile").hide();
    $("#accessGroupDiv").show();
    $("#btnNew").show();
    $("#btnSave").show();
    $("#btnCancelDel").show();
    $('#btnSearchProfiles').prop('disabled', false);
    backValue = 0;
}

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
});


function datePickerFromDateChanged(s, e) {
    var dateTo = window.datePickerDateTo.GetDate();
    var dateFrom = s.date;

    $("#hiddenFieldDateFrom").attr("value", dateFrom);

    highlightByDate(dateFrom, dateTo);
}

function datePickerToDateChanged(s, e) {
    var dateFrom = window.datePickerDateFrom.GetDate();

    var dateTo = s.date;

    highlightByDate(dateFrom, dateTo);
}

function highlightByDate(dateFrom, dateTo) {
    removeAllHighlighting();

    if ((dateTo === null) || (dateTo === undefined)) {
        return;
    }

    if ((dateFrom === null) || (dateFrom === undefined)) {
        return;
    }

    while (dateFrom <= dateTo) {
        var workingDateFrom = dateFrom;
        var selectedDate = Number(workingDateFrom.getDate());
        var selectedMonth = Number(workingDateFrom.getMonth());

        var rowCells = window.grdAccessCalendar.GetRow(selectedMonth).cells;
        for (var currentDay = selectedDate;currentDay <= 31;currentDay++) {
            var calendarYear = new Date().getFullYear();

            var daysDate = new Date(calendarYear, selectedMonth, currentDay);

            if (daysDate > dateTo) {
                return;
            }

            var selectedCell = rowCells[currentDay];

            if (isValidDate(selectedMonth, currentDay)) {
                if (isWeekend(selectedMonth, currentDay)) {
                    selectedCell.style.backgroundColor = "#2FB59F";
                } else {
                    selectedCell.style.backgroundColor = "#FFF603";
                }
            } else {
                selectedCell.style.backgroundColor = "black";
            }
        }

        dateFrom.setTime(dateFrom.getTime() + 1 * 86400000);
    }
}

function SetControlsOnNewCustom() {
    dplCalendarName.SetValue("0");
    dplCalendarNr.SetValue("0");
    $("#txtCalendarNr").focus();
    setNextAccessKalendarNo();
    SetNewMode();
}

//function DeleteButtonConfirm() {
//    var message = "Sind Sie sicher, dass Sie löschen möchten";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnDeleteButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="DeleteAccessCalendar()"></button><button id="btnCancel"  onclick="CancelOnDeleteButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantInfoDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function DeleteButtonConfirm() {
    var message = "Sind Sie sicher das Sie das Zutrittskalender tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetImportantInfoDialogDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 27%;color: red !important; margin-right: 0px;"  onclick="DeleteAccessCalendar()"></button><button id="btnCancel"  onclick="CancelOnDeleteButton(); return false;" style="color: forestgreen !important; position: relative;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("permitCalenderDeletion");
    $('#btnOk').text(levelCaption);
    getLocalizedText("cancelCalenderDeletion");
    $('#btnCancel').text(levelCaption);

}

function DeleteAccessCalendar() {
    resetImportantInfoDialogDiv();
    var selectval = dplCalendarNr.GetValue();
    PageMethods.DeleteAccessCalendar(selectval, DeleteCalender_Callback);

}

function CancelOnDeleteButton() {
    resetImportantInfoDialogDiv();

}

function resetImportantInfoDialogDiv() {
    document.getElementById("importantInfoDialog").innerHTML = "";

}

function grdHolidayCalndrSingleClick(s, e) {

    //var index = grid.GetFocusedRowIndex();
    var calendarId = grdHolidayCalndr.GetRowKey(e.visibleIndex);

    if (parseInt(calendarId) == "undefined") {
        return;
    } else {
        if (parseInt(calendarId) < 1) return;
    }

    dplCalendarNr.SetValue(calendarId.toString());
    dplCalendarName.SetValue(calendarId.toString());
    PageMethods.GetAccessCalendar(calendarId, GetAccessCalendarSelection_Callback);
}

function SetProfileSelectedDxDrp(setVal) {
    dplAccessProfileName.SetValue(setVal);
    dplAccessProfileNr.SetValue(setVal);
    ddlProfileId.SetValue(setVal);
    $("#dplAccessProfileMemo").val(setVal);
    $('#btnSearchProfiles').prop('disabled', false);

}
//function BackButtonSaveChanges() {

//    var message = "Willst du die Änderungen speichern";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="Reset_Default(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 45%;width: 100px; margin-right: 0px;"  onclick="ConfirmSaveChanges()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button><button id="btnCancel"  onclick="Reset_Default(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantInfoDialogCustom').innerHTML = box_content;
//    getLocalizedText("saveButton");
//    $('#btnOk').text(levelCaption);
//    getLocalizedText("no");
//    $('#btnNo').text(levelCaption);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(levelCaption);
//}

function BackButtonSaveChanges() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="Reset_Default(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 21%;width: 203px; margin-right: 5px;"  onclick="ConfirmSaveChanges()"></button><button id="btnNo"  onclick="CancelOnBackButton()"></button></div></div></div></div>';
    document.getElementById('importantInfoDialogCustom').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}


function ConfirmSaveChanges() {
    document.getElementById('importantInfoDialogCustom').innerHTML = "";
    if ($("#txtCalendarNr").val().trim() === "" || $("#txtCalendarNr").val().trim() === "0") {

        getLocalizedText("noSelection");

        alert(levelCaption);
    }
    else {

        saveOnBack();
    }
}
function CancelOnBackButton() {
    document.getElementById("importantInfoDialogCustom").innerHTML = "";
    document.location.href = "/Content/Settings.aspx";
}
function Reset_Default() {
    document.getElementById("importantInfoDialogCustom").innerHTML = "";
}
function calendarSelectedChanged(s, e) {
    if (isDplClick === true) {
        isDplClick = false;
        dplCalendarNr.SetValue(s.GetValue());
        dplCalendarName.SetValue(s.GetValue());
        if ($("#txtCalendarNr").val().trim() !== "" || $("#txtCalendarNr").val().trim() !== "0") {
            PageMethods.GetAccessCalendar(dplCalendarNr.GetValue(), GetAccessCalendar_Callback);

        } else {

        }
    }

}
function DropDownClick(s, e) {
    isDplClick = true;
}
function dplCalendarNrEndCallBack(s, e) {

}
function dplCalendarNameEndCallBack(s, e) {

}
function AddDay(date, numberOfDaysToAdd) {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() + numberOfDaysToAdd);
    return newDate;
}
function SubtractDay(date, numberOfDaysToSubtract) {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() - numberOfDaysToSubtract);
    return newDate;
}
function MoveToPreviousYear() {
    var i = ((ddlCalendarYear2.GetSelectedIndex()) - 1);
    if (i < 0) return;
    ddlCalendarYear2.SetSelectedIndex(i);
    ddlTariffYear2.SetValue(ddlCalendarYear2.GetValue());
}
function MoveToNextYear() {
    var i = ((ddlCalendarYear2.GetSelectedIndex()) + 1);
    if (i > ((ddlCalendarYear2.GetItemCount()) - 1)) return;
    ddlCalendarYear2.SetSelectedIndex(i);
    ddlTariffYear2.SetValue(ddlCalendarYear2.GetValue());
}
function CalculateStartDate(startRowIndex, startColumnIndex, calendarYear) {
    var date = null;
    var month = Number(startRowIndex) + 1;


    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + startColumnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();
    if (isValid == true) {
        datePickerDateFrom.SetDate(moment(daysDate, "YYYY-MM-DD").toDate());
    }
}
function CalculateEndDate(EndRowIndex, EndColumnIndex, calendarYear) {
    var month = Number(EndRowIndex) + 1;
    var monthLastDay = ReturnEndDate(calendarYear, EndRowIndex);
    if (EndColumnIndex > monthLastDay) {
        EndColumnIndex = monthLastDay;
    }

    var daysDate = calendarYear + "-" + String("00" + month).slice(-2) + "-" + String("00" + EndColumnIndex).slice(-2);

    var isValid = moment(daysDate, "YYYY-MM-DD", true).isValid();
    if (isValid == true) {
        datePickerDateTo.SetDate(moment(daysDate, "YYYY-MM-DD").toDate());
    }
}
function ReturnEndDate(calendarYear, month) {
    var today = new Date(calendarYear, month, 1);
    var lastDayOfMonth = new Date(today.getFullYear(), today.getMonth() + 1, 0);
    return lastDayOfMonth.getDate();
}
function ApplyConfirmation() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnApply(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 74%; margin-right: 0px; width:72px;"  onclick="save()"></button><button id="btnCancel"  onclick="NoOnApply(); return false;" style=" position: relative; width:44px;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("saveButton");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnCancel').text(levelCaption);

}
function NoOnApply() {
    resetImportantInfoDialogDiv();
    $("#hiddenFieldSaveChanges").attr("value", "0");
    EnableDrodowns();
    var index = grdHolidayCalndr.GetFocusedRowIndex();
    var calendarId = grdHolidayCalndr.GetRowKey(index);
    if (parseInt(calendarId) > 0) {
        dplCalendarNr.SetValue(calendarId);
        dplCalendarName.SetValue(calendarId);
        $("#txtCalendarNr").val(dplCalendarNr.GetText());
        $("#txtCalendarName").val(dplCalendarName.GetText());
        window.grdAccessCalendar.PerformCallback(calendarId);
    }
}
function EnableDrodowns() {
    dplCalendarNr.SetEnabled(true);
    dplCalendarName.SetEnabled(true);
    var index = grdHolidayCalndr.GetFocusedRowIndex();
    var calendarId = grdHolidayCalndr.GetRowKey(index);
    if (parseInt(calendarId) > 0) {
        dplCalendarNr.SetValue(calendarId);
        dplCalendarName.SetValue(calendarId);
        $("#txtCalendarNr").val(dplCalendarNr.GetText());
        $("#txtCalendarName").val(dplCalendarName.GetText());
        window.grdAccessCalendar.PerformCallback(calendarId);
    }
}
function CancelOnApply() {
    resetImportantInfoDialogDiv();
}
function RedirectConfirmation() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnApply(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 74%; margin-right: 0px; width:72px;"  onclick="SaveOnRedirect()"></button><button id="btnCancel"  onclick="NoOnRedirect(); return false;" style=" position: relative; width:44px;"></button></div></div></div></div>';
    document.getElementById('importantInfoDialog').innerHTML = box_content;
    getLocalizedText("saveButton");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnCancel').text(levelCaption);

}
function SaveOnRedirect() {
    resetImportantInfoDialogDiv();
    if (dplCalendarNr.GetValue() === "0") {
        PageMethods.CreateAccessCalendar($("#txtCalendarNr").val(), $("#txtCalendarName").val(), $("#txtMemo").val(), dplAccessProfileNr.GetValue(), $("#chkMonday")[0].checked, $("#chkTuesday")[0].checked, $("#chkWednesday")[0].checked, $("#chkThursday")[0].checked, $("#chkFriday")[0].checked, $("#chkSaturday")[0].checked, $("#chkSunday")[0].checked, GetDailyScheduleValues(), OnSaveRedirect_Callback);
    } else {
        PageMethods.UpdateAccessCalendar(dplCalendarNr.GetValue(), $("#txtCalendarNr").val(), $("#txtCalendarName").val(), $("#txtMemo").val(), dplAccessProfileNr.GetValue(), $("#chkMonday")[0].checked, $("#chkTuesday")[0].checked, $("#chkWednesday")[0].checked, $("#chkThursday")[0].checked, $("#chkFriday")[0].checked, $("#chkSaturday")[0].checked, $("#chkSunday")[0].checked, GetDailyScheduleValues(), OnSaveRedirect_Callback);
    }
}
function OnSaveRedirect_Callback() {
    var formMode = 2;
    if (parseInt(dplCalendarNr.GetValue()) > 0) {
        formMode = 3;
    }
    PageMethods.ReturnUrl(formMode, ReturnUrl_CallBack);
}
function NoOnRedirect() {
    resetImportantInfoDialogDiv();
    var formMode = 2;
    if (parseInt(dplCalendarNr.GetValue()) > 0) {
        formMode = 3;
    }
    PageMethods.ReturnUrl(formMode, ReturnUrl_CallBack);
}