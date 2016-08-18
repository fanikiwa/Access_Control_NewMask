
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
    $("#imgPotrait").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgLand").click(function (evt) {
        evt.preventDefault();
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
function grdMembersCardInfoEndCallback(s, e) {

}


function DisReports() {
    $(".showReports").show();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").show();
    $("#HiddenField1BackValue").attr('value', "1");
    $("#txtGroupFrom").val(cobStudioGroupFrom.GetText());
    $("#txtGroupTo").val(cobStudioGroupTo.GetText());
    $("#txtMemberNameFrom").val(cobMemberNameFrom.GetText());
    $("#txtMemberNameTo").val(cobMemberNameTo.GetText());
    $("#txtMemberNrFrom").val(cobMemberNrFrom.GetText());
    $("#txtMemberNrTo").val(cobMemberNrTo.GetText());
    $("#txtCardNrFrom").val(cobCardNrFrom.GetText());
    $("#txtCardNrTo").val(cobCardNrTo.GetText());
    $("#txtDateFrom").val(datePickerFrom.GetText());
    $("#txtDateTo").val(datePickerTo.GetText());

    //_sendReportSettingsToDocumentViewer();
}


function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").hide();
    MembersCardPanel.PerformCallback();
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
    var groupFrom = cobStudioGroupFrom.GetSelectedItem().texts[0];
    var groupTo = cobStudioGroupTo.GetSelectedItem().texts[0];
    var memberNameFrom = cobMemberNameFrom.GetSelectedItem().texts[0];
    var memberNameTo = cobMemberNameTo.GetSelectedItem().texts[0];
    var memberNrFrom = cobMemberNrFrom.GetText();
    var memberNrTo = cobMemberNrTo.GetText();
    var cardNrFrom = cobCardNrFrom.GetText();
    var cardNrTo = cobCardNrTo.GetText();
    var activeCard = $("#chkActiveCards")[0].checked;
    var extendedCard = $("#chkExtendedCards")[0].checked;
    var inActiveCard = $("#chkInactiveCards")[0].checked;
    var allCards = $("#chkAllCards")[0].checked;
    var dateFrom = datePickerFrom.GetDate() !== null ? moment(datePickerFrom.GetDate()).format("YYYY-MM-DD") : "";
    var dateTo = datePickerTo.GetDate() !== null ? moment(datePickerTo.GetDate()).format("YYYY-MM-DD") : "";
    var filterParam = groupFrom + ";" + groupTo + ";" + memberNameFrom + ";" + memberNameTo + ";" + memberNrFrom +
         ";" + memberNrTo + ";" + cardNrFrom + ";" + cardNrTo + ";" + activeCard + ";" + extendedCard + ";" + inActiveCard + ";" + allCards + ";" + dateFrom + ";" + dateTo;

    grdMembersCardInfo.PerformCallback(filterParam);
}
function SetPrintDate() {
    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
}
function SetCheckAll() {
    if ($("#chkActiveCards")[0].checked === false && $("#chkExtendedCards")[0].checked === false && $("#chkInactiveCards")[0].checked === false) {
        $("#chkAllCards")[0].checked = true;
    }
}
function cobStudioGroupFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cobStudioGroupTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cobStudioGroupTo.SetValue(s.GetValue());
    }
}
function cobStudioGroupToIndexChanged(s, e) {
    var nrFrom = Number(cobStudioGroupFrom.GetSelectedItem().texts[0]);
    var nrTO = Number(s.GetSelectedItem().texts[0]);
    if (nrFrom === 0 || nrFrom > nrTO) {
        cobStudioGroupFrom.SetValue(s.GetValue());
    }
}
function cobMemberNameFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetSelectedItem().texts[0]);
    var nrTO = Number(cobMemberNameTo.GetSelectedItem().texts[0]);
    if (nrTO < nrFrom) {
        cobMemberNameTo.SetValue(s.GetValue());
    }
}
function cobMemberNameToIndexChanged(s, e) {
    var nrFrom = Number(cobMemberNameFrom.GetSelectedItem().texts[0]);
    var nrTO = Number(s.GetSelectedItem().texts[0]);
    if (nrFrom === 0 || nrFrom > nrTO) {
        cobMemberNameFrom.SetValue(s.GetValue());
    }
}
function cobMemberNrFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetText());
    var nrTO = Number(cobMemberNrTo.GetText());
    if (nrTO < nrFrom) {
        cobMemberNrTo.SetValue(s.GetValue());
    }
}
function cobMemberNrToIndexChanged(s, e) {
    var nrFrom = Number(cobMemberNrFrom.GetText());
    var nrTO = Number(s.GetText());
    if (nrFrom === 0 || nrFrom > nrTO) {
        cobMemberNrFrom.SetValue(s.GetValue());
    }
}
function cobCardNrFromIndexChanged(s, e) {
    var nrFrom = Number(s.GetText());
    var nrTO = Number(cobCardNrTo.GetText());
    if (nrTO < nrFrom) {
        cobCardNrTo.SetValue(s.GetValue());
    }
}
function cobCardNrToIndexChanged(s, e) {
    var nrFrom = Number(cobCardNrFrom.GetText());
    var nrTO = Number(s.GetText());
    if (nrFrom === 0 || nrFrom > nrTO) {
        cobCardNrFrom.SetValue(s.GetValue());
    }
}