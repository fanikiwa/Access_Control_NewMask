using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsPersonalAttendanceList : BasePage
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
            //ASPxDocumentViewerPersonalAttendanceReport.OpenReport(new PersonalAttendanceReport());
            _initializeReportViewer();
            RebindGrids();
            if (!IsPostBack)
            {
                LoadDefaultChecks();
                BindSelectionDeptControls();
                LoadlocationtDetails();
                BindCoastCenterControls();
                LoadClientDetails();
                chkLandScape.Checked = true;
                string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
                string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

                var logedInUser = String.Format("{0} {1}", firstName, lastName);

                lblLoggedInUser.Text = logedInUser;
            }
        }
        private void _initializeReportViewer()
        {
            if (chkLandScape.Checked)
            {
                ASPxDocumentViewerPersonalAttendanceReport.OpenReport(new PersonalAttendanceReport());
            }
            else if (chkPortrait.Checked)
            {
                ASPxDocumentViewerPersonalAttendanceReport.OpenReport(new PersonalAttendanceReportPotrait());
            }
        }
        protected void RebindGrids()
        {
            if (Session["AccessLogReportsDto"] != null)
            {
                List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();

                accessLogsReport = (List<AccessLogReportsDto>)Session["AccessLogReportsDto"];

                grdDisplayPersonalAttendance.DataSource = accessLogsReport;
                grdDisplayPersonalAttendance.DataBind();

            }

        }
        protected void LoadDefaultChecks()
        {
            chkPersonalDate.Checked = true;
            chkname.Checked = true;
            chkAllBookings.Checked = true;
        }
        protected void LoadlocationtDetails()
        {
            Location _Location = new Location()
            {
                ID = 0,
                Location_Nr = 0,
                Name = "keine Auswahl",
            };
            var AllLocation = new LocationRepository().GetLocations();

            List<Location> Location = new List<Location>();

            Location.Add(_Location);
            Location.AddRange(AllLocation);

            cbolocationPersonalFrm.DataSource = Location;
            cbolocationPersonalFrm.DataBind();
            cbolocationPersonalTo.DataSource = Location;
            cbolocationPersonalTo.DataBind();
        }
        void BindSelectionDeptControls()
        {
            Department _Department = new Department()
            {
                ID = 0,
                Department_Nr = 0,
                Name = "keine Auswahl",
            };

            var Departments = new DepartmentRepository().GetDepartments();

            List<Department> DepartmentsList = new List<Department>();
            DepartmentsList.Add(_Department);
            DepartmentsList.AddRange(Departments);

            cboDeptNameFrom.DataSource = DepartmentsList;
            cboDeptNameFrom.DataBind();
            cboDeptNameTo.DataSource = DepartmentsList;
            cboDeptNameTo.DataBind();

        }

        void BindCoastCenterControls()
        {
            CostCenter _CostCenter = new CostCenter()
            {
                ID = 0,
                CostCenter_Nr = 0,
                Name = "keine Auswahl",
            };

            var CostCenters = new CostCenterRepository().GetCostCenters();

            List<CostCenter> CostCentersList = new List<CostCenter>();
            CostCentersList.Add(_CostCenter);
            CostCentersList.AddRange(CostCenters);

            cboCostCenterName.DataSource = CostCentersList;
            cboCostCenterName.DataBind();
            cboCostCenterNameTo.DataSource = CostCentersList;
            cboCostCenterNameTo.DataBind();
        }
        protected void LoadClientDetails()
        {
            Client _Client = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "keine Auswahl",
            };
            var AllClients = new ClientsRepository().GetClients();
            List<Client> clients = new List<Client>();
            clients.Add(_Client);
            clients.AddRange(AllClients);

            cboClientNameFrom.DataSource = clients;
            cboClientNameFrom.DataBind();
            cboClientNameto.DataSource = clients;
            cboClientNameto.DataBind();
        }

        protected void grdDisplayPersonalAttendance_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
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
                accessLogsReport.AddRange(_accessreportsViewModel.GetPersonalAttendanceLogs(true, acReport));
            }

            //accessLogsReport = _accessreportsViewModel.GetMemberAttendanceLogs(acReport);

            grdDisplayPersonalAttendance.Columns["BookingDate"].Visible = acReport.DisplayDate;
            grdDisplayPersonalAttendance.Columns["PersClient"].Visible = acReport.DisplayClient;
            grdDisplayPersonalAttendance.Columns["PersLocation"].Visible = acReport.DisplayLocation;
            grdDisplayPersonalAttendance.Columns["PersDepartement"].Visible = acReport.DisplayDepartment;
            grdDisplayPersonalAttendance.Columns["PersCostCenter"].Visible = acReport.DisplayCostCenter;
            grdDisplayPersonalAttendance.Columns["Name"].Visible = acReport.DisplayName;
            grdDisplayPersonalAttendance.Columns["PersonID"].Visible = acReport.DisplayPersonalID;
            grdDisplayPersonalAttendance.Columns["CardNumber"].Visible = acReport.DisplayMemberCardNr;
            grdDisplayPersonalAttendance.Columns["ExpiryDate"].Visible = acReport.DisplayExpiryDate;
            grdDisplayPersonalAttendance.Columns["EntryDate"].Visible = acReport.DisplayMemberEntry;
            grdDisplayPersonalAttendance.Columns["ExitDate"].Visible = acReport.DisplayMemberExit;

            grdDisplayPersonalAttendance.DataSource = accessLogsReport;
            grdDisplayPersonalAttendance.DataBind();

            if (accessLogsReport.Count() > 32)
            {
                grdDisplayPersonalAttendance.SettingsPager.PageSize = accessLogsReport.Count();
            }
            else
            {
                grdDisplayPersonalAttendance.SettingsPager.PageSize = 32;
            }
             
            //lblLoggedInUser
            string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
            string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

            var logedInUser = String.Format("{0} {1}", firstName, lastName);

            accessLogsReport.Select(c => { c.LogedInUser = logedInUser; return c; }).ToList();
             
            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
            HttpContext.Current.Session["acReport"] = acReport;
        }
        protected void PersonalAttendanceCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
    }
}