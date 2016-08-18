using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsMembersAttendaceList : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Reports_PMode");
            }
            set
            {
                HttpContext.Current.Session["Reports_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Reports, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ASPxDocumentViewerMemberAttendanceReport
            _initializeReportViewer();
            //ASPxDocumentViewerMemberAttendanceReport.OpenReport(new MembersAttendanceReport());

            if (!IsPostBack)
            {
                BindGroups();
                LoadDefaultChecks();
                 

                string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
                string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

                lblUser.Text = String.Format("{0} {1}", firstName, lastName);
                chkLandScape.Checked = true;
            }
        }
        private void _initializeReportViewer()
        {
            if (chkLandScape.Checked)
            {
                ASPxDocumentViewerMemberAttendanceReport.OpenReport(new MembersAttendanceReport());
            }
            else if (chkPortrait.Checked)
            {
                ASPxDocumentViewerMemberAttendanceReport.OpenReport(new MembersAttendanceReportPotrait());
            }
        }
        protected void LoadDefaultChecks()
        {
            chkMemberDate.Checked = true;
            //  chkStudioGroup.Checked = true;
            chkMemberName.Checked = true;

            //default print Type allBookings check
            chkAllBookings.Checked = true;
        }

        protected void BindGroups()
        {
            MemberGroup _AC_Reports = new MemberGroup()
            {
                Id = 0,
                GroupNr = 0,
                GroupName = "keine Auswahl",
            };
            var allMembers = new MemberGroupsRepositories().GetAllMemberGroups();

            List<MemberGroup> _members = new List<MemberGroup>();
            _members.Add(_AC_Reports);
            _members.AddRange(allMembers);

            cboStudioGroupFrom.DataSource = _members;
            cboStudioGroupFrom.DataBind();

            cboStudioGroupTo.DataSource = _members;
            cboStudioGroupTo.DataBind();
        }

        protected void grdMembersAttendanceList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void grdDisplayMemberAttendance_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            AccessReportsRepository _AccessReportsRepository = new AccessReportsRepository();
            AccessReportSettings_DTO _AC_Reports = new AccessReportSettings_DTO();


            List<AccessReportSettings_DTO> acReports = JsonConvert.DeserializeObject<List<AccessReportSettings_DTO>>(e.Parameters);

            if (acReports.Count > 0)
            {
                _AC_Reports = acReports[0];
                _displayGridOverFilterselection(_AC_Reports);
            }
        }


        private void _displayGridOverFilterselection(AccessReportSettings_DTO acReport)
        {
            AccessReportsViewModel _accessreportsViewModel = new AccessReportsViewModel();
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();


            DateTime currentReportDate = new DateTime();
            DateTime startDate = Convert.ToDateTime(acReport.StartDate);
            DateTime endDate = Convert.ToDateTime(acReport.EndDate);

            for (currentReportDate = startDate.Date; currentReportDate.Date <= endDate.Date; currentReportDate = currentReportDate.AddDays(1))
            {
                acReport.StartDate = currentReportDate.Date;
                acReport.EndDate = currentReportDate.Date;
                accessLogsReport.AddRange(_accessreportsViewModel.GetMemberAttendanceLogs(true, acReport));
            }

            //accessLogsReport = _accessreportsViewModel.GetMemberAttendanceLogs(acReport);

            grdDisplayMemberAttendance.Columns["BookingDate"].Visible = acReport.DisplayMemberDate;
            grdDisplayMemberAttendance.Columns["MemberGroup"].Visible = acReport.DisplayMemberGroup;
            grdDisplayMemberAttendance.Columns["Name"].Visible = acReport.DisplayMemberName;
            grdDisplayMemberAttendance.Columns["ID_Nr"].Visible = acReport.DisplayMemberId;
            grdDisplayMemberAttendance.Columns["AgreementNr"].Visible = acReport.DisplayMemberContractNr;
            grdDisplayMemberAttendance.Columns["CardNumber"].Visible = acReport.DisplayMemberCardNr;
            grdDisplayMemberAttendance.Columns["ExpiryDate"].Visible = acReport.DisplayExpiryDate;
            grdDisplayMemberAttendance.Columns["EntryDate"].Visible = acReport.DisplayMemberEntry;
            grdDisplayMemberAttendance.Columns["ExitDate"].Visible = acReport.DisplayMemberExit;

            grdDisplayMemberAttendance.DataSource = accessLogsReport;
            grdDisplayMemberAttendance.DataBind();

            if (accessLogsReport.Count() > 32)
            {
                grdDisplayMemberAttendance.SettingsPager.PageSize = accessLogsReport.Count();
            }
            else
            {
                grdDisplayMemberAttendance.SettingsPager.PageSize = 32;
            }


            string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
            string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

            var logedInUser = String.Format("{0} {1}", firstName, lastName);

            accessLogsReport.Select(c => { c.LogedInUser = logedInUser; return c; }).ToList();



            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
            HttpContext.Current.Session["acReport"] = acReport;
        }

        protected void MemberAttendanceCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
    }
}