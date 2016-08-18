using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using DevExpress.Web;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsMembersAttendancetimes : BasePage
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
            //AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReportC());
            _initializeReportViewer();
            if (!IsPostBack)
            {
                dtpFrom.Date = DateTime.Now;
                dtpTo.Date = DateTime.Now;
                BindPersonnelList();
                BingGroups();
                BindPersTransponder();
                LoadMembers();
                loadChecks();
                chkLandScape.Checked = true;
                chkVarA.Checked = true;
                chkenstri.Checked = true;
                //BindReportsGrind();
            }
        }
        private void _initializeReportViewer()
        {
            if (chkVarA.Checked)
            {
                if (chkLandScape.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReport());
                }
                else if (chkPortrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReportPotait());
                }
            }

            if (chkVarB.Checked)
            {
                if (chkLandScape.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReportB());
                }
                else if (chkPortrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReportBPotait());
                }
            }
            if (chkVarC.Checked)
            {
                if (chkLandScape.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReportC());
                }
                else if (chkPortrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new MembersAttendancetimesReportCPotait());
                }
            }
        }
        protected void loadChecks()
        {
            //chkenstri.Checked = true;
            //chkdepartment.Checked = true;
        }
        protected void BindReportsGrind()
        {
            AccessReportsViewModel _accessreportsViewModel = new AccessReportsViewModel();
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();

            accessLogsReport = _accessreportsViewModel.GetPersonalAccessLogs();

            grdShowReport.DataSource = accessLogsReport;
            grdShowReport.DataBind();
            grdShowReportB.DataSource = accessLogsReport;
            grdShowReportB.DataBind();
            grdShowReportC.DataSource = accessLogsReport;
            grdShowReportC.DataBind();
            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccReports.aspx");
        }
        public void BindPersonnelList()
        {
            var memberList = new MembersDataRepository().GetAllMembersData();

            List<MembersData> members = new List<MembersData>();

            members.AddRange(memberList);
            cmbPersName.DataSource = members;
            cmbPersName.DataBind();
            cmbPersNameTo.DataSource = members;
            cmbPersNameTo.DataBind();

        }
        protected void LoadMembers()
        {
            var members = new MembersViewModel().MemberDetails();
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine Auswahl", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            cobMemberNr.DataSource = memberList;
            cobMemberNr.DataBind();
            cobMemberNrTo.DataSource = memberList;
            cobMemberNrTo.DataBind();
            if (members.Count > 0)
            {
                cobMemberNr.SelectedIndex = 0;
                cobMemberNrTo.SelectedIndex = 0;
            }
            else
            {
                cobMemberNr.SelectedIndex = 0;
                cobMemberNrTo.SelectedIndex = 0;
            }

        }
        protected void BingGroups()
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

            cboClientName.DataSource = _members;
            cboClientName.DataBind();

            cboClientNameto.DataSource = _members;
            cboClientNameto.DataBind();
        }
        protected void BindPersTransponder()
        {


            MembersTransponder _Pers_Transponders = new MembersTransponder()
            {
                ID = 0,
                TransponderNr = 0,
                TransponderType = 0,
            };

            var Transponders = new MembersTranspondersRepository().GetAllMemberTransponders();

            var transpondersType1 = new MembersTranspondersRepository().GetAllMemberTransponders().Where(x => x.TransponderType == 1);


            List<MembersTransponder> TranspondersList = new List<MembersTransponder>();
            TranspondersList.Add(_Pers_Transponders);
            TranspondersList.AddRange(Transponders);
            List<MembersTransponder> TranspondersListFilter = TranspondersList.Where(k => k.TransponderType == 1).ToList();
            List<MembersTransponder> TranspondersListFilter2 = TranspondersList.Where(k => k.TransponderType == 2).ToList();
            cboLongTransponder.DataSource = TranspondersListFilter;
            cboLongTransponder.DataBind();
            cboLongTransponderTo.DataSource = TranspondersListFilter;
            cboLongTransponderTo.DataBind();

            cboShortTransponder.DataSource = TranspondersListFilter2;
            cboShortTransponder.DataBind();
            cboShortTransponderTo.DataSource = TranspondersListFilter2;
            cboShortTransponderTo.DataBind();



        }
        protected void OneTodayCallbackPanel_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void grdShowReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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

            const int OBJECT_PRINT_TYPE = 0;
            const int VARB_PRINT_TYPE = 1;
            const int VARC_PRINT_TYPE = 2;

            DateTime currentReportDate = new DateTime();
            DateTime startDate = Convert.ToDateTime(acReport.StartDate);
            DateTime endDate = Convert.ToDateTime(acReport.EndDate);

            for (currentReportDate = startDate.Date; currentReportDate.Date <= endDate.Date; currentReportDate = currentReportDate.AddDays(1))
            {
                acReport.StartDate = currentReportDate.Date;
                acReport.EndDate = currentReportDate.Date;
                accessLogsReport.AddRange(_accessreportsViewModel.GetMemberAttendanceLogs(false, acReport));
            }

            double totalMinutes = accessLogsReport.Select(x => x.DurationTimespan.TotalMinutes).Sum();
            TimeSpan totalDuration = TimeSpan.FromMinutes(totalMinutes);
            accessLogsReport.Add(new AccessLogReportsDto { ID = 9999, ExitTimeText = "Gesamtstunden", DurationText = Convert.ToInt32(totalDuration.TotalHours).ToString("00") + "," + totalDuration.Minutes.ToString("00") });

            switch (acReport.Type)
            {
                case OBJECT_PRINT_TYPE:
                    //grdShowReport.Columns["MemberGroup"].Visible = acReport.DisplayMemberGroup;
                    //grdShowReport.Columns["ID_Nr"].Visible = acReport.DisplayMemberNo;
                    //grdShowReport.Columns["CardNumber"].Visible = acReport.DisplayLongTermCard;
                    //grdShowReport.Columns["CardNumbershort"].Visible = acReport.DisplayShortTermCard;
                    grdShowReport.DataSource = accessLogsReport;
                    grdShowReport.DataBind();

                    if (accessLogsReport.Count() > 32)
                    {
                        grdShowReport.SettingsPager.PageSize = accessLogsReport.Count();
                    }
                    else
                    {
                        grdShowReport.SettingsPager.PageSize = 32;
                    }
                    break;
                case VARB_PRINT_TYPE:
                    //grdShowReportB.Columns["MemberGroup"].Visible = acReport.DisplayMemberGroup;
                    //grdShowReportB.Columns["ID_Nr"].Visible = acReport.DisplayMemberNo;
                    //grdShowReportB.Columns["CardNumber"].Visible = acReport.DisplayLongTermCard;
                    //grdShowReportB.Columns["CardNumbershort"].Visible = acReport.DisplayShortTermCard;
                    grdShowReportB.DataSource = accessLogsReport;
                    grdShowReportB.DataBind();

                    if (accessLogsReport.Count() > 32)
                    {
                        grdShowReportB.SettingsPager.PageSize = accessLogsReport.Count();
                    }
                    else
                    {
                        grdShowReportB.SettingsPager.PageSize = 32;
                    }
                    break;
                case VARC_PRINT_TYPE:
                    //grdShowReportC.Columns["MemberGroup"].Visible = acReport.DisplayMemberGroup;
                    //grdShowReportC.Columns["ID_Nr"].Visible = acReport.DisplayMemberNo;
                    //grdShowReportC.Columns["CardNumber"].Visible = acReport.DisplayLongTermCard;
                    //grdShowReportC.Columns["CardNumbershort"].Visible = acReport.DisplayShortTermCard;
                    grdShowReportC.DataSource = accessLogsReport;
                    grdShowReportC.DataBind();

                    if (accessLogsReport.Count() > 32)
                    {
                        grdShowReportC.SettingsPager.PageSize = accessLogsReport.Count();
                    }
                    else
                    {
                        grdShowReportC.SettingsPager.PageSize = 32;
                    }
                    break;
            }

            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
            HttpContext.Current.Session["acReport"] = acReport;
        }

        protected void grdShowReportB_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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

        protected void grdShowReportC_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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

        protected void grdShowReport_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            string totalText = Convert.ToString(grdShowReport.GetRowValues(e.VisibleIndex, "ExitTimeText"));

            if (totalText != "Gesamtstunden")
            {
                return;
            }

            switch (e.DataColumn.FieldName)
            {
                case "ExitTimeText":
                    e.Cell.Font.Bold = true;
                    break;
                case "DurationText":
                    e.Cell.Font.Bold = true;
                    break;
            }
        }

        protected void grdShowReportB_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            string totalText = Convert.ToString(grdShowReportB.GetRowValues(e.VisibleIndex, "ExitTimeText"));

            if (totalText != "Gesamtstunden")
            {
                return;
            }

            switch (e.DataColumn.FieldName)
            {
                case "ExitTimeText":
                    e.Cell.Font.Bold = true;
                    break;
                case "DurationText":
                    e.Cell.Font.Bold = true;
                    break;
            }
        }

        protected void grdShowReportC_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            string totalText = Convert.ToString(grdShowReportC.GetRowValues(e.VisibleIndex, "ExitTimeText"));

            if (totalText != "Gesamtstunden")
            {
                return;
            }

            switch (e.DataColumn.FieldName)
            {
                case "ExitTimeText":
                    e.Cell.Font.Bold = true;
                    break;
                case "DurationText":
                    e.Cell.Font.Bold = true;
                    break;
            }
        }
    }
}