
$(document).ready(function () {
    $("#btnPrintReport").click(function (evt) {
        evt.preventDefault();
        DispReportToday();
    });
    $("#btnPrintSelection").click(function (evt) {
        evt.preventDefault();
        DisReports();
        SetPrintDate();
        FilterGrid();

    });

    $("#lblCardType").text("Alle Ausweise");

    $("#chkActiveCards").click(function () {
        if ($("#chkActiveCards")[0].checked === true) {
            $("#chkAllCards")[0].checked = false;
            $("#chkExtendedCards")[0].checked = false;
            $("#chkInactiveCards")[0].checked = false;

            $("#lblCardType").text("Aktive Ausweise");

        }
        else if ($("#chkActiveCards")[0].checked === false) {
            SetCheckAll();
        }
    });
    $("#chkExtendedCards").click(function () {
        if ($("#chkExtendedCards")[0].checked === true) {
            $("#chkAllCards")[0].checked = false;
            $("#chkActiveCards")[0].checked = false;
            $("#chkInactiveCards")[0].checked = false;

            $("#lblCardType").text(" Verlängerte Ausweise");
        }
        else if ($("#chkExtendedCards")[0].checked === false) {
            SetCheckAll();

        }
    });
    $("#chkInactiveCards").click(function () {
        if ($("#chkInactiveCards")[0].checked === true) {
            $("#chkAllCards")[0].checked = false;
            $("#chkActiveCards")[0].checked = false;
            $("#chkExtendedCards")[0].checked = false;

            $("#lblCardType").text(" Inaktive Ausweise");

        }
        else if ($("#chkInactiveCards")[0].checked === false) {
            SetCheckAll();
        }
    });
    $("#chkAllCards").click(function () {
        if ($("#chkAllCards")[0].checked === true) {
            $("#chkActiveCards")[0].checked = false;
            $("#chkExtendedCards")[0].checked = false;
            $("#chkInactiveCards")[0].checked = false;
            $("#lblCardType").text("Alle Ausweise");
        }
        else if ($("#chkAllCards")[0].checked === false) {
            $("#chkAllCards")[0].checked = true;
        }
    });
    $("#chkPortrait").click(function () {
        if ($("#chkPortrait")[0].checked === true) {
            $("#chkLandScape")[0].checked = false;

        }
        else if ($("#chkPortrait")[0].checked === false) {
            $("#chkLandScape")[0].checked = true;
        }
    });
    $("#chkLandScape").click(function () {
        if ($("#chkLandScape")[0].checked === true) {
            $("#chkPortrait")[0].checked = false;

        }
        else if ($("#chkLandScape")[0].checked === false) {
            $("#chkPortrait")[0].checked = true;

        }
    });
    $("#imgPotrait").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLand").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        var backValue = isNaN(parseInt($("#HiddenField1BackValue").val())) ? 0 : parseInt($("#HiddenField1BackValue").val());
        switch (backValue) {
            case 0:
                window.location = "/Content/AccReports.aspx";
                break;
            case 1:
                HideGrid();
                break;
            case 2:
                $(".showReportsDocViewer").hide();
                DisReports();
                break;
        }

    });
})
function DisReports() {
    $(".showReports").show();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").show();
    $("#HiddenField1BackValue").attr('value', "1");
    $("#txtCompanyFrom").val(cobCompanyFrom.GetText());
    $("#txtCompanyTo").val(cobCompanyTo.GetText());
    $("#txtLocationFrom").val(cobLocationFrom.GetText());
    $("#txtLocationTo").val(cobLocationTo.GetText());
    $("#txtDepartmentFrom").val(cobDepartmentFrom.GetText());
    $("#txtDepartmentTo").val(cobDepartmentTo.GetText());
    $("#txtPersNameFrom").val(cobNameFrom.GetText());
    $("#txtPersNameTo").val(cobNameTo.GetText());
    $("#txtDateFrom").val(datePickerFrom.GetText());
    $("#txtDateTo").val(datePickerTo.GetText());
    $("#txtCardNrFrom").val(cobCardNrFrom.GetText());
    $("#txtCardNrTo").val(cobCardNrTo.GetText());
    //_sendReportSettingsToDocumentViewer();
}


function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").hide();
    PersonnelCardPanel.PerformCallback();
    $("#HiddenField1BackValue").attr('value', "2");
}
function HideGrid() {
    $(".showReports").hide();
    $(".ContentAreaDiv").show();
    $("#btnPrintSelection").show();
    $("#btnPrintReport").hide();
    $("#HiddenField1BackValue").attr('value', "0");
}
function FilterGrid() {
    var companyFrom = cobCompanyFrom.GetSelectedItem().texts[0];
    var companyTo = cobCompanyTo.GetSelectedItem().texts[0];
    var locationFrom = cobLocationFrom.GetSelectedItem().texts[0];
    var locationTo = cobLocationTo.GetSelectedItem().texts[0];
    var departmentFrom = cobDepartmentFrom.GetSelectedItem().texts[0];
    var departmentTo = cobDepartmentTo.GetSelectedItem().texts[0];
    var persNameFrom = cobNameFrom.GetSelectedItem().texts[0];
    var persNameTo = cobNameTo.GetSelectedItem().texts[0];
    var persNrFrom = cobPersNrFrom.GetText();
    var persNrTo = cobPersNrTo.GetText();
    var cardNrFrom = cobCardNrFrom.GetText();
    var cardNrTo = cobCardNrTo.GetText();
    var activeCard = $("#chkActiveCards")[0].checked;
    var extendedCard = $("#chkExtendedCards")[0].checked;
    var inActiveCard = $("#chkInactiveCards")[0].checked;
    var allCards = $("#chkAllCards")[0].checked;
    var dateFrom = datePickerFrom.GetDate() !== null ? moment(datePickerFrom.GetDate()).format("YYYY-MM-DD") : "";
    var dateTo = datePickerTo.GetDate() !== null ? moment(datePickerTo.GetDate()).format("YYYY-MM-DD") : "";
    var filterParam = companyFrom + ";" + companyTo + ";" + locationFrom + ";" + locationTo + ";" + departmentFrom + ";" + departmentTo + ";" + persNameFrom + ";" + persNameTo + ";" + persNrFrom +
         ";" + persNrTo + ";" + cardNrFrom + ";" + cardNrTo + ";" + activeCard + ";" + extendedCard + ";" + inActiveCard + ";" + allCards + ";" + dateFrom + ";" + dateTo;

    grdPersonnelCardInfo.PerformCallback(filterParam);
}
function SetPrintDate() {
    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
}
function grdPersonnelCardInfoEndCallback(s, e) {

}
function cobCompanyFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cobCompanyTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cobCompanyTo.SetValue(s.GetValue());
    }
}
function cobCompanyToIndexChanged(s, e) {
    //var nrFrom = Number(cobCompanyFrom.GetSelectedItem().texts[0]);
    //var nrTO = Number(s.GetSelectedItem().texts[0]);
    //if (nrFrom === 0 || nrFrom > nrTO) {
    //    cobCompanyFrom.SetValue(s.GetValue());
    //}
}
function cobLocationFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cobLocationTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cobLocationTo.SetValue(s.GetValue());
    }
}
function cobLocationToIndexChanged(s, e) {
    //var nrFrom = Number(cobLocationFrom.GetSelectedItem().texts[0]);
    //var nrTO = Number(s.GetSelectedItem().texts[0]);
    //if (nrFrom === 0 || nrFrom > nrTO) {
    //    cobLocationFrom.SetValue(s.GetValue());
    //}
}
function cobDepartmentFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cobDepartmentTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cobDepartmentTo.SetValue(s.GetValue());
    }
}
function cobDepartmentToIndexChanged(s, e) {
    //var nrFrom = Number(cobDepartmentFrom.GetSelectedItem().texts[0]);
    //var nrTO = Number(s.GetSelectedItem().texts[0]);
    //if (nrFrom === 0 || nrFrom > nrTO) {
    //    cobDepartmentFrom.SetValue(s.GetValue());
    //}
}
function cobNameFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cobNameTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cobNameTo.SetValue(s.GetValue());
    }
}
function cobNameToIndexChanged(s, e) {
    //var nrFrom = Number(cobNameFrom.GetSelectedItem().texts[0]);
    //var nrTO = Number(s.GetSelectedItem().texts[0]);
    //if (nrFrom === 0 || nrFrom > nrTO) {
    //    cobNameFrom.SetValue(s.GetValue());
    //}
}
function cobPersNrFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetText());
    var nrTO = Number(cobPersNrTo.GetText());
    if (nrTO < nrFrom) {
        cobPersNrTo.SetValue(s.GetValue());
    }
}
function cobPersNrToIndexChanged(s, e) {
    //var nrFrom = Number(s.GetText());
    //var nrTO = Number(cobPersNrFrom.GetText());
    //if (nrTO < nrFrom) {
    //    cobPersNrFrom.SetValue(s.GetValue());
    //}
}
function cobCardNrFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetText());
    var nrTO = Number(cobCardNrTo.GetText());
    if (nrTO < nrFrom) {
        cobCardNrTo.SetValue(s.GetValue());
    }
}
function cobCardNrToIndexChanged(s, e) {
    //var nrFrom = Number(s.GetText());
    //var nrTO = Number(cobCardNrFrom.GetText());
    //if (nrTO < nrFrom) {
    //    cobCardNrFrom.SetValue(s.GetValue());
    //}
}

function dateFromChanged(s, e) {
    if (!moment(datePickerTo.GetDate()).isValid()) {
        datePickerTo.SetDate(s.GetDate())
    }
}

function dateToChanged(s, e) {
    //if (!moment(datePickerFrom.GetDate()).isValid()) {
    //    datePickerFrom.SetDate(s.GetDate())
    //}
}

function SetCheckAll() {
    if ($("#chkActiveCards")[0].checked === false && $("#chkExtendedCards")[0].checked === false && $("#chkInactiveCards")[0].checked === false) {
        $("#chkAllCards")[0].checked = true;
    }
}