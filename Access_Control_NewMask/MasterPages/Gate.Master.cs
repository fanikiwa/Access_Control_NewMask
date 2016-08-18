using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.MasterPages
{
    public partial class Gate : System.Web.UI.MasterPage
    {
        #region Global Objects
        PermissionDto2 _PermissionDto = new PermissionDto2();
        ZUTMain mainCtl = new ZUTMain();
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            _PermissionDto = mainCtl.GetSessionPermissions();

            GateMonitorPermissionsCheck();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Page.Title) && this.Page.Master.FindControl("pagenamelbl") != null)
            {
                Label _pagenamelbl = (Label)(this.Page.Master.FindControl("pagenamelbl"));
                _pagenamelbl.Text = this.Page.Title;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Logout.aspx");
        }


        #region Settings Permissions Check
        public void GateMonitorPermissionsCheck()
        {
            if (!(_PermissionDto.AllGateMonitorCheck()))
                mainCtl.RedirectToDashoard();

            AllGateMonitorCheck();
        }
        #endregion


        #region Gate Monitor Group Levels
        public void AllGateMonitorCheck()
        {
            btnPersonalCheck.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorPersonnelRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorPersonnelEdit;
            if (!btnPersonalCheck.Enabled)
                btnPersonalCheck.Style.Add("cursor", "not-allowed !important");

            btnGateMembers.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorMembersRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorMembersEdit;
            if (!btnGateMembers.Enabled)
                btnGateMembers.Style.Add("cursor", "not-allowed !important");

            btnGateVisitor.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorVisitorsRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorVisitorsEdit;
            if (!btnGateVisitor.Enabled)
                btnGateVisitor.Style.Add("cursor", "not-allowed !important");

            btnDisplayPanel.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorDisplayPanelRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorDisplayPanelEdit;
            if (!btnDisplayPanel.Enabled)
                btnDisplayPanel.Style.Add("cursor", "not-allowed !important");

            btnInfo.Enabled = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorInfoRead
            || _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorInfoEdit;
            if (!btnInfo.Enabled)
                btnInfo.Style.Add("cursor", "not-allowed !important");
        }
        #endregion

    }
}