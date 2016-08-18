$(function () {
    $("#btnDashboard").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Index.aspx";
    });

    $("#btnPersonalCheck").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/GatePersonal.aspx";
    });

    $("#btnGateMembers").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/GateMembers.aspx";
    });

    $("#btnGateVisitor").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/GateVisitors.aspx";
    });

    $("#btnDisplayPanel").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/GateDisplaypanel.aspx";
    });

    $("#btnInfo").click(function (evt) {
        evt.preventDefault();
        //document.location.href = "/Content/.aspx";
    });
    $("#btnGate").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/GateMonitor.aspx";
    });
})

