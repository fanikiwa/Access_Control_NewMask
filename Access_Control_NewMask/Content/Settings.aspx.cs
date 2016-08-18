using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.Content
{
    public partial class Settings : BasePage
    {
        #region Global Objects
        PermissionDto2 _PermissionDto = new PermissionDto2();
        ZUTMain mainCtl = new ZUTMain();
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            _PermissionDto = mainCtl.GetSessionPermissions();

            SettingsPermissionsCheck();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }

        protected void btnViscompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("VisitorCompany.aspx");
        }

        protected void btnCostCenter_Click(object sender, EventArgs e)
        {
            Response.Redirect("CostCenter_New.aspx");
        }

        protected void btnDept_Click(object sender, EventArgs e)
        {
            Response.Redirect("Department_New.aspx");
        }

        protected void btnLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("Locations.aspx");
        }

        protected void btnCars_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehicles.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardSettings.aspx");
        }

        protected void btnlanguage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Language.aspx");
        }
        protected void btnAccprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccessProfile.aspx");
        }

        protected void btnAcckalender_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccessKalendar.aspx");
        }

        protected void btnpasswoter_Click(object sender, EventArgs e)
        {
            Response.Redirect("RightsSettings.aspx");
        }

        #region Settings Permissions Check
        public void SettingsPermissionsCheck()
        {
            if (!(_PermissionDto.AllSettingsCheck()))
                mainCtl.RedirectToDashoard();

            AllSettingsCheck();
        }
        #endregion


        #region Settings Group Levels
        public void AllSettingsCheck()
        {
            AllPersSettingsCheck();
            AllAccessSettingsCheck();
            AllGeneralSettingsCheck();
            AllGroupSettingsCheck();
        }

        private void AllPersSettingsCheck()
        {
            btnInactivePersonal.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.PersInactiveRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.PersInactiveEdit;
            if (!btnInactivePersonal.Enabled)
                btnInactivePersonal.Style.Add("cursor", "not-allowed !important");

            btnInactiveMember.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.MembersInactiveRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.MembersInactiveEdit;
            if (!btnInactiveMember.Enabled)
                btnInactiveMember.Style.Add("cursor", "not-allowed !important");

            btnCompany.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.ClientsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.ClientsEdit;
            if (!btnCompany.Enabled)
                btnCompany.Style.Add("cursor", "not-allowed !important");

            btnLocation.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.LocationsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.LocationsEdit;
            if (!btnLocation.Enabled)
                btnLocation.Style.Add("cursor", "not-allowed !important");

            btnDepartment.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.DepartmentRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.DepartmentEdit;
            if (!btnDepartment.Enabled)
                btnDepartment.Style.Add("cursor", "not-allowed !important");

            btnCostCenter.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.CostCentersRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.CostCentersEdit;
            if (!btnCostCenter.Enabled)
                btnCostCenter.Style.Add("cursor", "not-allowed !important");

            btnVisitorCompany.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.VisitorFirmsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.VisitorFirmsEdit;
            if (!btnVisitorCompany.Enabled)
                btnVisitorCompany.Style.Add("cursor", "not-allowed !important");

            btnVehicles.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.VehiclesRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.VehiclesEdit;
            if (!btnVehicles.Enabled)
                btnVehicles.Style.Add("cursor", "not-allowed !important");

            btnMembersGroup.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.MembersGroupRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.MembersGroupEdit;
            if (!btnMembersGroup.Enabled)
                btnMembersGroup.Style.Add("cursor", "not-allowed !important");

            btnMembersContractDuration.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.MembersContractRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.MembersContractEdit;
            if (!btnMembersContractDuration.Enabled)
                btnMembersContractDuration.Style.Add("cursor", "not-allowed !important");
        }

        private void AllAccessSettingsCheck()
        {
            btnAccessProfile.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessProfileRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessProfileEdit;
            if (!btnAccessProfile.Enabled)
                btnAccessProfile.Style.Add("cursor", "not-allowed !important");

            btnAccessCalendar.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessCalenderRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessCalenderEdit;
            if (!btnAccessCalendar.Enabled)
                btnAccessCalendar.Style.Add("cursor", "not-allowed !important");

            btnSwitchProfile.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsSwitchProfileRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsSwitchProfileEdit;
            if (!btnSwitchProfile.Enabled)
                btnSwitchProfile.Style.Add("cursor", "not-allowed !important");

            btnSwitchCalender.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsSwitchProfileRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsSwitchProfileEdit;
            if (!btnSwitchCalender.Enabled)
                btnSwitchCalender.Style.Add("cursor", "not-allowed !important");

            btnHolidayCalender.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsHolidayCalenderRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsHolidayCalenderEdit;
            if (!btnHolidayCalender.Enabled)
                btnHolidayCalender.Style.Add("cursor", "not-allowed !important");

            btnHolidayplan.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsHolidayPlanRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsHolidayPlanEdit;
            if (!btnHolidayplan.Enabled)
                btnHolidayplan.Style.Add("cursor", "not-allowed !important");
        }

        private void AllGeneralSettingsCheck()
        {
            btnLanguage.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsLanguageRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsLanguageEdit;
            if (!btnLanguage.Enabled)
                btnLanguage.Style.Add("cursor", "not-allowed !important");

            btnRights.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsRightsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsRightsEdit;
            if (!btnRights.Enabled)
                btnRights.Style.Add("cursor", "not-allowed !important");

            btnAssignPassword.Enabled = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsPasswordProfileRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsPasswordProfileEdit;
            if (!btnAssignPassword.Enabled)
                btnAssignPassword.Style.Add("cursor", "not-allowed !important");
        }

        private void AllGroupSettingsCheck()
        {
            btnAccessProfileGroup.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessProfileGroupRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessProfileGroupEdit;
            if (!btnAccessProfileGroup.Enabled)
                btnAccessProfileGroup.Style.Add("cursor", "not-allowed !important");

            btnAccessPlanGroup.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessPlanGroupRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessPlanGroupEdit;
            if (!btnAccessPlanGroup.Enabled)
                btnAccessPlanGroup.Style.Add("cursor", "not-allowed !important");
        }
        #endregion
    }
}