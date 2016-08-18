$(document).ready(function () {

    //#########   Personal  #########


    $("#btnPersonalReports, #btnPersonalReportsTop").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalReport.aspx";
    });

    $("#btnPersonalAttendanceListTop, #btnPersonalAttendanceList").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsPersonalAttendanceList.aspx";
    });

    $("#btnReportsPersonalAttendancetimestop, #btnReportsPersonalAttendancetimes").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsPersonalAttendancetimes.aspx";
    });
    $("#btnReportsPersonalListTop, #btnReportsPersonalList").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsPersonalList.aspx";
    });

    $("#btnReportPersonalinfoCardTop, #btnReportPersonalinfoCard").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportPersonalCardInfo.aspx";
    });

    //#########   Visitors  #########

    $("#btnVisitorReports, #btnVisitorReportsTop").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/VisitorReports.aspx";
    });
    
    $("#btnReportsVisitorHistorytop, #btnReportsVisitorHistory").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsVisitorHistory.aspx";
    });

    $("#btnVisitorCompanyTop, #btnVisitorCompany").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsVisitorsAttendanceList.aspx";
    });

    $("#btnReportsVisitorsAttendanceListtop, #btnReportsVisitorsAttendanceList").click(function (evt) {
        evt.preventDefault();
         document.location.href = "/Content/ReportsVisitorList.aspx";
    });


    //#########   Members  #########


    $("#btnMembersReports, #btnMembersReportsTop").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/MemberReport.aspx";
    });

    $("#btnMembersAttendanceListsTop, #btnMembersAttendanceLists").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsMembersAttendaceList.aspx";
    });

    $("#btnMembersAttendancetimestop, #btnMembersAttendancetimes").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsMembersAttendancetimes.aspx";
    });
    
    $("#btnMembersListTop, #btnMembersList").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportsMembersList.aspx";
    });
    $("#btnMembersCardInfoTop, #btnMembersCardInfo").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/ReportMembersCardInfo.aspx";
    });
   
     
})
