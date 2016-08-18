var levelCaption = 0;
var bookingsCorrected = 0;
var selectedPersonal = [];
var grdCorrectionsRowNum = null;
var grdCorrectionsColNum = null;
var bookingsCorrectionPersNr = null;
var bookingsCorrectionLogType = null;
var bookingsCorrectionDate = null;

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
    $(".holiday3").hide();
    $(".holiday2").hide();

    $("#btnView").click(function (evt) {
        evt.preventDefault();
        $(".infoBoard").show();
        $(".contentareabottom").hide();
        $("#btnEntSave").hide();
        $("#btnEntEdit").hide();
        $("#Label19").hide();
        $("#teBookingTime").hide();
        $("#btnsave").hide();
        $(".correctbookings").hide();
        levelCaption = 1;
    });

    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (levelCaption == 0) {
            {
                document.location.href = "/Index.aspx";
            }

        } else if (levelCaption == 1) {
            $(".contentareabottom").show();
            $(".infoBoard").hide();
            $("#btnEntSave").show();
            $("#btnEntEdit").show();
            $("#Label19").show();
            $("#teBookingTime").show();
            $("#btnsave").show();
            levelCaption = 0;
        } else if (levelCaption == 2) {
            $(".contentareabottom").show();
            $(".correctbookings").hide();
            levelCaption = 0;
            setTimeout(function (ev) {
                filterAccesslogsOverSelection();
            }, 20);
        }
    });

    $("#btnEntSave").click(function (evt) {
        evt.preventDefault();

        if (levelCaption == 2) {
            bookingsCorrected = 1;
            _saveCorrectedBookings();
        }
    });

    $("#chkViewAllBookings").change(function () {
        if ($("#chkViewAllBookings")[0].checked) {
            $("#chkViewErrorBookingsOnly")[0].checked = false;
        } else {
            $("#chkViewErrorBookingsOnly")[0].checked = true;
        }

        //filterAccesslogsOverSelection()
    });

    $("#chkViewErrorBookingsOnly").change(function () {
        if ($("#chkViewErrorBookingsOnly")[0].checked) {
            $("#chkViewAllBookings")[0].checked = false;
        }
        else {
            $("#chkViewAllBookings")[0].checked = true;
        }

        //filterAccesslogsOverSelection()
    });

    $("#chkIncludeAbsentPersonal").change(function () {
        if ($("#chkIncludeAbsentPersonal")[0].checked) {
            $("#chkViewErrorBookingsOnly")[0].checked = false;
        }
    });

    $("#chkViewErrorBookingsOnly").change(function () {
        if ($("#chkViewErrorBookingsOnly")[0].checked) {
            $("#chkIncludeAbsentPersonal")[0].checked = false;
        }
    });

    $("#btnEntEdit").click(function (evt) {
        evt.preventDefault();
    });

    $("#btnSaveGridSettings").click(function (evt) {
        evt.preventDefault();
        SaveAndCloseGridSettings();
    });

    $("#btnCloseGridSettings").click(function (evt) {
        evt.preventDefault();
        SaveAndCloseGridSettings();
    });

    $("#btnRefresh").click(function (evt) {
        evt.preventDefault();
        filterAccesslogsOverSelection();
    });

    $("#btnsave").click(function (evt) {
        evt.preventDefault();
        PageMethods.CorrectBookingsAuomatically(selectedPersonal, moment(teBookingTime.GetValue()).toISOString(), doTaskAfterMultipleCorrection);
    });

    $("#chkClient").change(function () {
        setPersInfoCookie();
        filterAccesslogsOverSelection();
    });

    $("#chkShowAllPeople").change(function () {
        if ($("#chkShowAllPeople").prop('checked')) {
            resetAllDropDowns();
        }
        AllPersonenSelected();
    });

    $("#chkLocation").change(function () {
        setPersInfoCookie();
        filterAccesslogsOverSelection();
    });

    $("#chkDepartment").change(function () {
        setPersInfoCookie();
        filterAccesslogsOverSelection();
    });

    $("#chkVisitorLogsOnly").change(function () {
        //filterAccesslogsOverSelection();
    });

    $("#chkCostCenter").change(function () {
        setPersInfoCookie();
        filterAccesslogsOverSelection();
    });

    $("#chkPersonalID").change(function () {
        setPersInfoCookie();
        filterAccesslogsOverSelection();
    });

    $("#chkCardNumber").change(function () {
        setPersInfoCookie();
        filterAccesslogsOverSelection();
    });

    $("#btnDeleteDayCorrection").click(function (ev) {
        ev.preventDefault();
        if (confirm("Sind Sie sicher, dass Sie alle Buchungen löschen möchten?")) {
            DeleteDayCorrections();
        }
    });

    $("#btnPrevDayCorrections").click(function (ev) {
        ev.preventDefault();

        if (bookingsCorrectionDate != null && moment(bookingsCorrectionDate).isValid()) {
            bookingsCorrectionDate.add(-1, 'day');
            $("#txtDateCorrections").val("Mit. " + bookingsCorrectionDate.format("DD.MM.YYYY"));
            grdBookingsCorrection.PerformCallback(bookingsCorrectionPersNr + ';' + bookingsCorrectionLogType + ';' + bookingsCorrectionDate.format("YYYY-MM-DDT00:00"));
        }
    });

    $("#btnNextDayCorrections").click(function (ev) {
        ev.preventDefault();

        if (bookingsCorrectionDate != null && moment(bookingsCorrectionDate).isValid()) {
            bookingsCorrectionDate.add(1, 'day');
            $("#txtDateCorrections").val("Mit. " + bookingsCorrectionDate.format("DD.MM.YYYY"));
            grdBookingsCorrection.PerformCallback(bookingsCorrectionPersNr + ';' + bookingsCorrectionLogType + ';' + bookingsCorrectionDate.format("YYYY-MM-DDT00:00"));
        }
    });

    $("#btnDeleteCorrection").click(function (ev) {
        ev.preventDefault();
        if (confirm("Sind Sie sicher, dass Sie die Buchung löschen möchten?")) {
            DeleteCorrection();
        }
    });
});

function doTaskAfterMultipleCorrection() {
    setTimeout(function (ev) { grdAccessCorrection.PerformCallback(''); }, 1000);
}

function SaveAndCloseGridSettings() {
    $(".contentareabottom").show();
    $(".infoBoard").hide();
    $("#btnEntSave").show();
    $("#btnEntEdit").show();
    $("#Label19").show();
    $("#teBookingTime").show();
    $("#btnsave").show();
}


function _saveCorrectedBookings() {
    grdBookingsCorrection.batchEditHelper.EndEdit();
    //setTimeout(function (ev) { grdBookingsCorrection.UpdateEdit() }, 1000);
    if (typeof grdBookingsCorrection.keys[0] != "undefined") {
        if (grdBookingsCorrection.keys[0].split("#").length > 2) {
            var persNr = grdBookingsCorrection.keys[0].split("#")[1];
            PageMethods.SaveBookingsCorrections(persNr, JSON.stringify(getBookingsCorrectionJSN()), function (resp) {
                setTimeout(function (ev) {
                    $("#txtCorrectionsMemo").val("");
                    if (bookingsCorrectionDate != null)
                        grdBookingsCorrection.PerformCallback(bookingsCorrectionPersNr + ';' + bookingsCorrectionLogType + ';' +
                                                            bookingsCorrectionDate.format("YYYY-MM-DDT00:00"));
                }, 10);
            }, function (err) {
                console.log(err);
            })
        }
    }
}

function UpdateCorrectionStatus(sender, evt, status) {
    var modifiedClassName = "dxgvBatchEditModifiedCell_Office2003Blue dxgv";
    var senderCol = 0;
    var statusName = status == 1 ? "K" : "G";
    try { grdCorrectionsRowNum = $(sender.GetMainElement()).parents("tr")[0].rowIndex - 2 } catch (e) { }
    try { grdCorrectionsColNum = sender.dxgvColumnIndex } catch (e) { }

    sender.SetValue(status);
    sender.SetText(statusName);
    grdBookingsCorrection.GetRow(grdCorrectionsRowNum).cells[grdCorrectionsColNum - 1].childNodes[0].textContent = statusName;
    grdBookingsCorrection.batchEditApi.SetCellValue(grdCorrectionsRowNum, grdCorrectionsColNum, status, statusName);
    grdBookingsCorrection.GetRow(grdCorrectionsRowNum).cells[grdCorrectionsColNum - 1].className = modifiedClassName;
}

function GetFocusedCell(sender, evt) {
    try { grdCorrectionsRowNum = $(sender.GetMainElement()).parents("tr")[0].rowIndex - 2 } catch (e) { }
    try { grdCorrectionsColNum = sender.dxgvColumnIndex } catch (e) { }
}

function DeleteCorrection() {
    var modifiedClassName = "dxgvBatchEditModifiedCell_Office2003Blue dxgv";

    if (grdCorrectionsRowNum != null && grdCorrectionsColNum != null) {
        var timeCol = grdCorrectionsColNum % 2 == 1 ? grdCorrectionsColNum : grdCorrectionsColNum - 1;
        var statusCol = grdCorrectionsColNum % 2 == 0 ? grdCorrectionsColNum : grdCorrectionsColNum + 1;

        grdBookingsCorrection.GetRow(grdCorrectionsRowNum).cells[timeCol - 1].childNodes[0].textContent = "X";
        grdBookingsCorrection.batchEditApi.SetCellValue(grdCorrectionsRowNum, timeCol, null, "X");
        grdBookingsCorrection.GetRow(grdCorrectionsRowNum).cells[timeCol - 1].className = modifiedClassName;

        grdBookingsCorrection.GetRow(grdCorrectionsRowNum).cells[statusCol - 1].childNodes[0].textContent = "X";
        grdBookingsCorrection.batchEditApi.SetCellValue(grdCorrectionsRowNum, statusCol, null, "X");
        grdBookingsCorrection.GetRow(grdCorrectionsRowNum).cells[statusCol - 1].className = modifiedClassName;
    }
}

function DeleteDayCorrections() {
    var timeCols = [1, 3, 5, 7];
    var modifiedClassName = "dxgvBatchEditModifiedCell_Office2003Blue dxgv";

    for (var _row = 0; _row < 4; _row++) {
        for (var _col = 0; _col < timeCols.length; _col++) {
            var timeCol = timeCols[_col] % 2 == 1 ? timeCols[_col] : timeCols[_col] - 1;
            var statusCol = timeCols[_col] % 2 == 0 ? timeCols[_col] : timeCols[_col] + 1;

            grdBookingsCorrection.GetRow(_row).cells[timeCol - 1].childNodes[0].textContent = "X";
            grdBookingsCorrection.batchEditApi.SetCellValue(_row, timeCol, null, "X");
            grdBookingsCorrection.GetRow(_row).cells[timeCol - 1].className = modifiedClassName;

            grdBookingsCorrection.GetRow(_row).cells[statusCol - 1].childNodes[0].textContent = "X";
            grdBookingsCorrection.batchEditApi.SetCellValue(_row, statusCol, null, "X");
            grdBookingsCorrection.GetRow(_row).cells[statusCol - 1].className = modifiedClassName;
        }
    }
}

function grdAccessCorrection_RowClick(sender, evt) {
    //$(".correctbookings").show();
    //$(".contentareabottom").hide();
    //levelCaption = 2;
    bookingsCorrectionDate = null; bookingsCorrectionPersNr = null; bookingsCorrectionLogType = null;
    grdAccessCorrection.GetRowValues(evt.visibleIndex, 'PersonalNumber;LogPersType;Date', OnGetRowValues);
}

function OnCellClick(cell, value, visibleIndex) {
    //$(".correctbookings").show();
    //$(".contentareabottom").hide();
    //levelCaption = 2;
    bookingsCorrectionDate = null; bookingsCorrectionPersNr = null; bookingsCorrectionLogType = null;
    grdAccessCorrection.GetRowValues(visibleIndex, 'PersonalNumber;LogPersType;Date', OnGetRowValues);
}

function OnGetRowValues(values) {
    grdBookingsCorrection.UnselectRows();
    bookingsCorrectionPersNr = values[0];
    bookingsCorrectionLogType = values[1];
    if (moment(values[2]).isValid()) bookingsCorrectionDate = moment(values[2]);

    setTimeout(function (value) {
        if (bookingsCorrectionDate != null)
            grdBookingsCorrection.PerformCallback(bookingsCorrectionPersNr + ';' + bookingsCorrectionLogType + ';' + bookingsCorrectionDate.format("YYYY-MM-DDT00:00"));
    }, 10);

    setTimeout(function (value) {
        $(".correctbookings").show();
        $(".contentareabottom").hide();
        $("#txtDateCorrections").val("Mit. " + bookingsCorrectionDate.format("DD.MM.YYYY"));
        levelCaption = 2;
    }, 200);
}

function grdAccessCorrectionRowChanged(s, e) {
    selectedPersonal = [];
    window.grdAccessCorrection.GetSelectedFieldValues("PersonalNumber", GetSelectedPersonal);
}

function GetSelectedPersonal(values) {
    for (var i = 0; i < values.length; i++) {
        var personalNumber = values[i];
        selectedPersonal.push(personalNumber);
    }
}

function reloadAccessLogsGrid() {
    if (bookingsCorrected == 1) {
        bookingsCorrected = 0;
        setTimeout(function (ev) { grdAccessCorrection.PerformCallback(''); }, 1000);

        if (levelCaption == 2) {
            $(".contentareabottom").show();
            $(".correctbookings").hide();
            levelCaption = 0;
        }
    }
}

function cmbClientsSelectedIndexChanged(value) {

    resetAllDropDowns();
    dplClients.SetValue(value);
    AllPersonenSelected();
    //filterAccesslogsOverSelection();
}

function cmbLocationNameSelectedIndexChanged(value) {
    resetAllDropDowns();
    dplLocation.SetValue(value);
    AllPersonenSelected();
    //filterAccesslogsOverSelection();
}

function cmbDepartmentSelectedIndexChanged(value) {
    resetAllDropDowns();
    dplDepartment.SetValue(value);
    AllPersonenSelected();
    //filterAccesslogsOverSelection();
}

function cmbCostCenterSelectedIndexChanged(value) {
    resetAllDropDowns();
    dplCostCenter.SetValue(value);
    AllPersonenSelected();
    //filterAccesslogsOverSelection();
}

function cmbPersNameSelectedIndexChanged(value) {
    dplPersonalNumber.SetValue(value);
    dplCardNumber.SetValue(value);
    //filterAccesslogsOverSelection();
}

function cmbIDNrSelectedIndexChanged(value) {

    dplPersonalName.SetValue(value);
    dplCardNumber.SetValue(value);
    //filterAccesslogsOverSelection();
}

function cmbAusweisNrSelectedIndexChanged(value) {

    dplPersonalName.SetValue(value);
    dplPersonalNumber.SetValue(value);
    //filterAccesslogsOverSelection();
}

function resetAllDropDowns() {
    dplClients.SetValue(0);
    dplLocation.SetValue(0);
    dplDepartment.SetValue(0);
    dplCostCenter.SetValue(0);

    dplPersonalName.SetValue(0);
    dplPersonalNumber.SetValue(0);
    dplCardNumber.SetValue(0);
}

function filterAccesslogsOverSelection() {
    var clientID = dplClients.GetValue();
    var locationID = dplLocation.GetValue();
    var departmentID = dplDepartment.GetValue();
    var costcenterID = dplCostCenter.GetValue();
    var personalNumber = dplPersonalNumber.GetValue();
    var chkShowAllPeople = $("#chkShowAllPeople")[0].checked;
    var includeAbsentPersonal = $("#chkIncludeAbsentPersonal")[0].checked;
    var dateFrom = moment(dtDateFrom.GetValue()).toISOString();
    var dateTo = moment(dtDateTo.GetValue()).toISOString();

    if (chkShowAllPeople) {
        var clientID = 0;
        var locationID = 0;
        var departmentID = 0;
        var costcenterID = 0;
        var personalNumber = 0;
    }
    var viewAllBookings = $("#chkViewAllBookings")[0].checked;
    var viewErrorBookings = $("#chkViewErrorBookingsOnly")[0].checked;
    var viewVisitorLogOnly = $("#chkVisitorLogsOnly")[0].checked;

    var gridFilterString = clientID + ';' + locationID + ';' + departmentID + ';' + costcenterID + ';' + personalNumber + ';' + viewErrorBookings + ';' + viewVisitorLogOnly + ';' + dateFrom + ';' + dateTo + ';' + includeAbsentPersonal;

    setTimeout(function (ev) { grdAccessCorrection.PerformCallback(gridFilterString); }, 1000);
}
function AllPersonenSelected() {
    var clientID = dplClients.GetValue();
    var locationID = dplLocation.GetValue();
    var departmentID = dplDepartment.GetValue();
    var costcenterID = dplCostCenter.GetValue();
    if (clientID == 0 && locationID == 0 && departmentID == 0 && costcenterID == 0) {
        $("#chkShowAllPeople").prop('checked', true)
    }
    else {
        $("#chkShowAllPeople").prop('checked', false)
    }
}

function setPersInfoCookie() {

    var checksPersInfo = [{
        "Client": true, "Location": true, "Depaterment": true, "CostCenter": true, "PersonalID": true, "CardNumber": true
    }];

    checksPersInfo[0]["Client"] = $("#chkClient")[0].checked;
    checksPersInfo[0]["Location"] = $("#chkLocation")[0].checked;
    checksPersInfo[0]["Depaterment"] = $("#chkDepartment")[0].checked;
    checksPersInfo[0]["CostCenter"] = $("#chkCostCenter")[0].checked;
    checksPersInfo[0]["PersonalID"] = $("#chkPersonalID")[0].checked;
    checksPersInfo[0]["CardNumber"] = $("#chkCardNumber")[0].checked;
    ASPxClientUtils.DeleteCookie("AccessCorrectionColumns");
    ASPxClientUtils.SetCookie("AccessCorrectionColumns", JSON.stringify(checksPersInfo), (moment(Date(Date.now)).add(1, 'year'))["_d"]);
}

function getBookingsCorrectionJSN() {
    var updateValues = {}, oldValues = {}, newValues = {};
    updateValues[bookingsCorrectionDate.format("YYYY-MM-DD")] = {};

    for (var x = 0; x < grdBookingsCorrection.keys.length; x++) {
        var _key = grdBookingsCorrection.keys[x];
        var _pageServerValues = $.extend(true, {}, grdBookingsCorrection.batchEditHelper.pageServerValues);
        oldValues[_key] = _pageServerValues[_key];

        oldValues[_key][1] = moment(oldValues[_key][1]).isValid() ? moment(oldValues[_key][1]).format("YYYY-MM-DDTHH:mm") : oldValues[_key][1];
        oldValues[_key][3] = moment(oldValues[_key][3]).isValid() ? moment(oldValues[_key][3]).format("YYYY-MM-DDTHH:mm") : oldValues[_key][3];
        oldValues[_key][5] = moment(oldValues[_key][5]).isValid() ? moment(oldValues[_key][5]).format("YYYY-MM-DDTHH:mm") : oldValues[_key][5];
        oldValues[_key][7] = moment(oldValues[_key][7]).isValid() ? moment(oldValues[_key][7]).format("YYYY-MM-DDTHH:mm") : oldValues[_key][7];
    }

    newValues = $.extend(true, {}, oldValues);

    updateValues[bookingsCorrectionDate.format("YYYY-MM-DD")]["OldValues"] = oldValues;
    updateValues[bookingsCorrectionDate.format("YYYY-MM-DD")]["NewValues"] = newValues;
    //updateValues[bookingsCorrectionDate.format("YYYY-MM-DD")]["Memo"] = $("#txtCorrectionsMemo").val();

    for (var x = 0; x < grdBookingsCorrection.keys.length; x++) {
        var _key = grdBookingsCorrection.keys[x];

        if (typeof grdBookingsCorrection.batchEditHelper.updatedValues[_key] != "undefined") {
            for (var y = 1; y < 9; y++) {
                if (typeof grdBookingsCorrection.batchEditHelper.updatedValues[_key][y] != "undefined") {
                    if (typeof grdBookingsCorrection.batchEditHelper.updatedValues[_key][y][0] != "undefined") {
                        newValues[_key][y] = grdBookingsCorrection.batchEditHelper.updatedValues[_key][y][0];

                        if (y % 2 != 0)
                            newValues[_key][y] = moment(newValues[_key][y]).isValid() ?
                                moment(newValues[_key][y]).format(bookingsCorrectionDate.format("YYYY-MM-DD") + "THH:mm") : newValues[_key][y];
                    }
                }
            }
        }
    }

    return updateValues;
}
