$(document).ready(function () {
    DisplayCurrentDate();
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
})
function DispReportToday() {
    $(".showReportsDocViewer").show();
    $(".showReports").hide();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").hide();
    ReportsVisitorListPanel.PerformCallback();
    $("#HiddenField1BackValue").attr('value', "2");
}
function DisplayCurrentDate() {
    $("#lblDate").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
}
function DisReports() {
    $(".showReports").show();
    $(".ContentAreaDiv").hide();
    $("#btnPrintSelection").hide();
    $("#btnPrintReport").show();
    $("#HiddenField1BackValue").attr('value', "1");
    $("#txtCompanyFrom").val(cobCompanyFrom.GetText());
    $("#txtCompanyTo").val(cobCompanyTo.GetText());
    $("#txtNameFrom").val(cobNameFrom.GetText());
    $("#txtNameTo").val(cobNameTo.GetText());
    $("#txtVisitorIDFrom").val(cobVisitorIdFrom.GetText());
    $("#txtVisitorIDTo").val(cobVisitorIdTo.GetText());

    $("#txtDept").val(cobVisitorIdFrom.GetText());
    $("#txtDeptTo").val(cobVisitorIdTo.GetText());
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
    var visitorNameFrom = cobNameFrom.GetSelectedItem().texts[0];
    var visitorNameTo = cobNameTo.GetSelectedItem().texts[0];
    var visitorIdFrom = cobVisitorIdFrom.GetText();
    var visitorIdTo = cobVisitorIdTo.GetText();
    
    var filterParam = companyFrom + ";" + companyTo + ";" + visitorNameFrom + ";" + visitorNameTo + ";" + visitorIdFrom +
         ";" + visitorIdTo;

    grdVisitorList.PerformCallback(filterParam);
}
function SetPrintDate() {
    $("#txtPrintDate").val(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
    $("#txtPrintTime").val(moment().format("HH") + ":" + moment().format("mm"));
}
function cobCompanyFromIndexChanged(s, e) {
    var CboFrom = cobCompanyFrom.GetValue();
    var CboTo = cobCompanyTo.GetValue();
    cobCompanyTo.SetValue(CboFrom);

}
function cobNameFromIndexChanged(s, e) {
    var NameFrom = cobNameFrom.GetValue();
    var NameTo = cobCompanyTo.GetValue();
    cobNameTo.SetValue(NameFrom);

}
function cobVisitorIdFromIndexChanged(s, e) {
    var idFrom = cobVisitorIdFrom.GetValue();
    var VisitorIDTo = cobVisitorIdTo.GetValue();
    cobVisitorIdTo.SetValue(idFrom);

}