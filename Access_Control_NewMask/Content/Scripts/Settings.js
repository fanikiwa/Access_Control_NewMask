$(document).ready(function () {

    $("#btnInactivePersonal").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalInactive.aspx";
    });

    $("#btnInactiveMember").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/MembersInactive.aspx";
    });

    $("#btnCompany").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Customer.aspx";
    });

    $("#btnLocation").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Locations.aspx";
    });

    $("#btnDepartment").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Department_New.aspx";
    });

    $("#btnCostCenter").click(function (evt) {
        evt.preventDefault();
        window.location = "/Content/CostCenter_New.aspx";
    });

    $("#btnVisitorCompany").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/VisitorCompany.aspx";
    });

    $("#btnVehicles").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Vehicles.aspx";
    });

    $("#btnMembersGroup").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/MembersGroup.aspx";
    });

    $("#btnMembersContractDuration").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/MemberContractDuration.aspx";
    });

    $("#btnAccessProfileGroup").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/AccessProfileGroup.aspx";
    });

    $("#btnAccessPlanGroup").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/AccessPlanAccessGroup.aspx";
    });

    $("#btnAccessProfile").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/AccessProfile.aspx";
    });

    $("#btnDashBoardSettings").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/DashboardSettings.aspx";
    });

    $("#btnLanguage").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Language.aspx";
    });

    $("#btnAssignPassword").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/RightsSettings.aspx";
    });

    $("#btnAccessCalendar").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/AccessKalendar.aspx";
    });

    $("#btnHolidayCalender").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/HolidayCalender.aspx";
    });

    $("#btnHolidayplan").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Holidayplan.aspx";
    });

    $("#btnSwitchProfile").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/Switchprofile.aspx";
    });
    $("#btnRights").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/RightsAssignment.aspx";
    });

    $("#btnSwitchCalender").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/SwitchCalender.aspx";
    });

    $("#btnBuildPlanGroup").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/BuildingPlanGroup.aspx";
    });

    //$("#btnVisitorList").click(function (evt) {
    //    evt.preventDefault();
    //    //document.location.href = "/Content/.aspx";
    //});

    //$("#btnOtherLists").click(function (evt) {
    //    evt.preventDefault();
    //    //document.location.href = "/Content/.aspx";
    //});

})
