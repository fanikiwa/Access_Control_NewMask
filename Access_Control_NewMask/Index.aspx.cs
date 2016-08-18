using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;

namespace Access_Control_NewMask
{
    public partial class Index : BasePage
    {
        #region Global Objects
        EncryptionCtl encryptionCtl = new EncryptionCtl();
        PermissionDto2 _PermissionDto = new PermissionDto2();
        ZUTMain mainCtl = new ZUTMain();

        string appURL = "";
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            _PermissionDto = mainCtl.GetSessionPermissions();

            DashboardPermissionsCheck();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null)
            {
                mainCtl.RedirectToLoginPage();
            }
            else
            {
                string userName = Convert.ToString(HttpContext.Current.Session["Pers_LoginName"] ?? "");
                string password = Convert.ToString(HttpContext.Current.Session["Pers_LoginPassword"] ?? "");
                string cryptPassword = encryptionCtl.Encrypt(password);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ZUT_AUTH",
                  "setTimeout(function() { setZUT_AUTH('" + userName + "', '" + HttpUtility.UrlEncode(cryptPassword) + "') }, 500);",
                  true);
            }
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Settings.aspx");
        }

        protected void btnTermKonfig_Click(object sender, EventArgs e)
        {
            if (!mainCtl.allowTMKAppCheck()) return;
            GetGlobalSetting("TMK_URL");

            if (appURL.Trim() == "") return;

            Response.Redirect(String.Format("http://{0}/Content/Login_New.aspx?user={1}&pass={2}", appURL,
                Session["Pers_LoginName"].ToString(), HttpUtility.UrlEncode(encryptionCtl.Encrypt(Session["Pers_LoginPassword"].ToString()))));
        }

        protected void btnVisitors_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://192.168.1.222:165/");

            Response.Redirect("http://www.allkrucloud.com:170/");
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Gebaudeplan.aspx");
        }

        protected void btnpersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Personal.aspx");
        }

        public void GetGlobalSetting(string settingName)
        {
            appURL = new GlobalSettingsViewModel().GetGetGlobalSettingByName(settingName);
        }

        //#region  Super Users
        //public void AllAccessControlCheck()
        //{
        //    chkTMKRead.Checked = _PermissionDto.AllServiceStudioRead;
        //    chkTMKEdit.Checked = _PermissionDto.AllServiceStudioEdit;

        //    chkZUTRead.Checked = _PermissionDto.AllAccessControlRead;
        //    chkZUTEdit.Checked = _PermissionDto.AllAccessControlEdit;
        //}
        //#endregion


        //#region GroupLevel Super Users
        //public void AllGroupLevelCheck()
        //{
        //    chkSettingsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead;
        //    chkSettingsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit;

        //    chkGateMonitorRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead;
        //    chkGateMonitorEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit;
        //}
        //#endregion

        #region Dashboard Permissions Check
        public void DashboardPermissionsCheck()
        {
            ServiceStudioCheck();
            AllSettingsCheck();
            AllGateMonitorCheck();
            AllMasterDataCheck();
            AllVisitorMasterCheck();
            AllSafetyAndCorrectionsCheck();
            AllReportsCheck();
            AllCommunicationsCheck();
        }
        #endregion

        #region TMK App
        public void ServiceStudioCheck()
        {
            btnTermKonfig.Enabled = _PermissionDto.AllServiceStudioRead || _PermissionDto.AllServiceStudioEdit;
            if (!btnTermKonfig.Enabled)
                btnTermKonfig.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Settings Group Levels
        public void AllSettingsCheck()
        {
            btnSettings.Enabled = _PermissionDto.AllSettingsCheck();
            if (!btnSettings.Enabled)
                btnSettings.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Gate Monitor Group Levels
        public void AllGateMonitorCheck()
        {
            btnGateMonitor.Enabled = _PermissionDto.AllGateMonitorCheck();
            if (!btnGateMonitor.Enabled)
                btnGateMonitor.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Master Data Group Levels
        public void AllMasterDataCheck()
        {
            btnPersonal.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.PersActiveRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.PersActiveEdit;
            if (!btnPersonal.Enabled)
                btnPersonal.Style.Add("cursor", "not-allowed !important");

            btnMembers.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.MembersActiveRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.MembersActiveEdit;
            if (!btnMembers.Enabled)
                btnMembers.Style.Add("cursor", "not-allowed !important");

            btnBuildingPlan.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.BuildingPlanRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.BuildingPlanEdit;
            if (!btnBuildingPlan.Enabled)
                btnBuildingPlan.Style.Add("cursor", "not-allowed !important");

            btnAccessGroup.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.AccessGroupRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.AccessGroupEdit;
            if (!btnAccessGroup.Enabled)
                btnAccessGroup.Style.Add("cursor", "not-allowed !important");

            btnAccessPlan.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.AccessPlanRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.AccessPlanEdit;
            if (!btnAccessPlan.Enabled)
                btnAccessPlan.Style.Add("cursor", "not-allowed !important");

            btnSwitchPlan.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.SwitchPlanRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.SwitchPlanEdit;
            if (!btnSwitchPlan.Enabled)
                btnSwitchPlan.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Visitor Master Data Group Levels
        public void AllVisitorMasterCheck()
        {
            btnVisitorData.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.VisitorsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.VisitorsEdit;
            if (!btnVisitorData.Enabled)
                btnVisitorData.Style.Add("cursor", "not-allowed !important");

            btnVisitApplications.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.VisitorApplicationsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.VisitorApplicationsEdit;
            if (!btnVisitApplications.Enabled)
                btnVisitApplications.Style.Add("cursor", "not-allowed !important");

            btnVisitorPlan.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.VisitorPlanRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.VisitorPlanEdit;
            if (!btnVisitorPlan.Enabled)
                btnVisitorPlan.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Safety and Corrections Group Levels
        public void AllSafetyAndCorrectionsCheck()
        {
            btnAccessCorrections.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.GraderRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.GraderEdit;
            if (!btnAccessCorrections.Enabled)
                btnAccessCorrections.Style.Add("cursor", "not-allowed !important");

            btnDisplayPanel.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.DisplayPanelRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.DisplayPanelEdit;
            if (!btnDisplayPanel.Enabled)
                btnDisplayPanel.Style.Add("cursor", "not-allowed !important");

            btnAlarmFunction.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.AlarmOpenRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.AlarmOpenEdit;
            if (!btnAlarmFunction.Enabled)
                btnAlarmFunction.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Reports Group Levels
        public void AllReportsCheck()
        {
            btnProtocollist.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.ReportsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.ReportsEdit;
            if (!btnProtocollist.Enabled)
                btnProtocollist.Style.Add("cursor", "not-allowed !important");

            btnListProtocol.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.ReportsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.ReportsEdit;
            if (!btnListProtocol.Enabled)
                btnListProtocol.Style.Add("cursor", "not-allowed !important");
        }
        #endregion


        #region Communications Group Levels
        public void AllCommunicationsCheck()
        {
            btnGetBookings.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.CommunicationGETRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.CommunicationGETEdit;
            if (!btnGetBookings.Enabled)
                btnGetBookings.Style.Add("cursor", "not-allowed !important");

            btnSendData.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.CommunicationSENDRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.CommunicationSENDEdit;
            if (!btnSendData.Enabled)
                btnSendData.Style.Add("cursor", "not-allowed !important");

            btndatacommmanual.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.CommunicationManualRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.CommunicationManualEdit;
            if (!btndatacommmanual.Enabled)
                btndatacommmanual.Style.Add("cursor", "not-allowed !important");
        }
        #endregion
    }
}