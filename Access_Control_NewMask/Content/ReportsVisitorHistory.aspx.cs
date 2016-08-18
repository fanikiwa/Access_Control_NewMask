using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json;
using DevExpress.Web;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsVisitorHistory : BasePage
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
            //AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReport());
            _initializeReportViewer();
            if (!IsPostBack)
            {
                chkVariableA.Checked = true;
                chkname.Checked = true;
                chkLandScape.Checked = true;
                chkVarientBLand.Checked = true;
                chkVarCLand.Checked = true;
                dtpFrom.Date = DateTime.Now;
                dtpTo.Date = DateTime.Now;
                LoadlocationtDetails();
                LoadClientDetails();
                BindSelectionDeptControls();
                BindCoastCenterControls();
                BindVisitors(0);
                LoadClientNameDetails();
                BindPersTransponder();
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblLoggedInUser.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblLoggedInUserC.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
            }
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

            cboClientFrom.DataSource = clients;
            cboClientFrom.DataBind();
            cboClientTo.DataSource = clients;
            cboClientTo.DataBind();

        }
        private void _initializeReportViewer()
        {
            if (chkVariableA.Checked)
            {
                if (chkLandScape.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReport());
                }
                else if (chkPortrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReportPotrait());
                }
            }

            if (chkVaribleB.Checked)
            {
                if (chkVarientBLand.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReportB());
                }
                else if (chkVarientBPotrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReportVarBPotrait());
                }
            }
            if (chkVaribleC.Checked)
            {
                //AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReportC());
                if (chkVarCLand.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReportC());
                }
                else if (chkVarCPotait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new VisitorHistoryReportVarCPotrait());
                }
            }
        }
        protected void LoadlocationtDetails()
        {
            Location _Location = new Location()
            {
                ID = 0,
                Location_Nr = 0,
                Name = "keine Auswahl ",
            };
            var AllLocation = new LocationRepository().GetLocations();

            List<Location> Location = new List<Location>();

            Location.Add(_Location);
            Location.AddRange(AllLocation);

            cboLocatiomFrom.DataSource = Location;
            cboLocatiomFrom.DataBind();
            cboLocationTo.DataSource = Location;
            cboLocationTo.DataBind();
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

            cboDeptFrom.DataSource = DepartmentsList;
            cboDeptFrom.DataBind();
            cboDeptTo.DataSource = DepartmentsList;
            cboDeptTo.DataBind();

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


            cboCostCenterFrom.DataSource = CostCentersList;
            cboCostCenterFrom.DataBind();
            cboCoastCenterTo.DataSource = CostCentersList;
            cboCoastCenterTo.DataBind();



        }
        protected void BindVisitors(int value)
        {
            var visitors = new VisitorRepository().GetAllVisitors();
            VisitorsDto visitorDtoKeine = new VisitorsDto()
            {
                ID = 0,
                VisitorID = 0,
                Name = "keine Auswahl",
                Location = "keine Auswahl",
                Company = "keine Auswahl",
                PostalCode = "keine Auswahl"
            };
            List<VisitorsDto> listVisitors = new List<VisitorsDto>();
            listVisitors.Add(visitorDtoKeine);
            foreach (var visitor in visitors)
            {

                VisitorsDto visitorDto = new VisitorsDto()
                {
                    ID = visitor.ID,
                    VisitorID = visitor.VisitorID,
                    Name = visitor.SurName + " " + visitor.Fullname,
                    Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "keine Auswahl",
                    PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "keine Auswahl",
                    CompanyID = visitor.Company,
                    Company = visitor.Company != null ? visitor.VisitorCompanyTb.Name : "keine Auswahl",

                };
                listVisitors.Add(visitorDto);
            }
            switch (value)
            {
            case 0:
                cmbPersName.DataSource = listVisitors.OrderBy(x => x.Name == "keine Auswahl" ? 0 : 1).ThenBy(x => x.Name);
                cmbPersName.DataBind();
                cboPersNameTo.DataSource = listVisitors.OrderBy(x => x.Name == "keine Auswahl" ? 0 : 1).ThenBy(x => x.Name);
                cboPersNameTo.DataBind();
                cboVisitorIDFrom.DataSource = listVisitors.OrderBy(x => x.ID == 0 ? 0 : 1).ThenBy(x => x.ID);
                cboVisitorIDFrom.DataBind();
                cboVisitorIDTO.DataSource = listVisitors.OrderBy(x => x.ID == 0 ? 0 : 1).ThenBy(x => x.ID);
                cboVisitorIDTO.DataBind();
                break;
            case 1:
                cmbPersName.DataSource = listVisitors.OrderBy(x => x.Name == "keine Auswahl" ? 0 : 1).ThenBy(x => x.Name);
                cmbPersName.DataBind();
                cboPersNameTo.DataSource = listVisitors.OrderBy(x => x.Name == "keine Auswahl" ? 0 : 1).ThenBy(x => x.Name);
                cboPersNameTo.DataBind();
                cboVisitorIDFrom.DataSource = listVisitors.OrderBy(x => x.ID == 0 ? 0 : 1).ThenBy(x => x.ID);
                cboVisitorIDFrom.DataBind();
                cboVisitorIDTO.DataSource = listVisitors.OrderBy(x => x.ID == 0 ? 0 : 1).ThenBy(x => x.ID);
                cboVisitorIDTO.DataBind();
                break;

            }
        }
        protected void BindPersTransponder()
        {

            Pers_Transponders _Pers_Transponders = new Pers_Transponders()
            {
                ID = 0,
                TransponderNr = 0,
                TransponderType = 0,
            };

            var Transponders = new PersTranspondersRepository().GetAllPersTransponders();

            List<Pers_Transponders> TranspondersList = new List<Pers_Transponders>();
            TranspondersList.Add(_Pers_Transponders);
            TranspondersList.AddRange(Transponders);
            List<Pers_Transponders> TranspondersListFilter = TranspondersList.Where(k => k.TransponderType == 1).ToList();
            List<Pers_Transponders> TranspondersListFilter2 = TranspondersList.Where(k => k.TransponderType == 2).ToList();
            cboShortTransponder.DataSource = TranspondersListFilter;
            cboShortTransponder.DataBind();
            cboShortTransponderTo.DataSource = TranspondersListFilter;
            cboShortTransponderTo.DataBind();
        }
        protected void LoadClientNameDetails()
        {
            VisitorCompanyTb _Client = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "keine Auswahl",
            };
            var AllClients = new VisitorCompanyRepository().GetAllVisitorCompanies();
            List<VisitorCompanyTb> clients = new List<VisitorCompanyTb>();
            clients.Add(_Client);
            clients.AddRange(AllClients);

            cboClientName.DataSource = clients;
            cboClientName.DataBind();
            cboClientNameto.DataSource = clients;
            cboClientNameto.DataBind();

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
            var today = DateTime.Now;
            DateTime dafultTime = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            DateTime currentReportDate = new DateTime();
            DateTime startTime = acReport.StartTime != null ? Convert.ToDateTime(acReport.StartTime) : dafultTime;
            DateTime endTime = acReport.EndTime != null ? Convert.ToDateTime(acReport.EndTime) : dafultTime;
            DateTime startDate = Convert.ToDateTime(acReport.StartDate).Add(startTime.TimeOfDay);
            DateTime endDate = Convert.ToDateTime(acReport.EndDate).Add(endTime.TimeOfDay);

            for (currentReportDate = startDate.Date; currentReportDate.Date <= endDate.Date; currentReportDate = currentReportDate.AddDays(1))
            {
                acReport.StartDate = currentReportDate.Date;
                acReport.EndDate = currentReportDate.Date;

                accessLogsReport.AddRange(_accessreportsViewModel.GetVisitorAttendanceLogs(false, acReport));
            }

            switch (acReport.Type)
            {
            case OBJECT_PRINT_TYPE:
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
                grdVarialeB.DataSource = accessLogsReport;
                grdVarialeB.DataBind();
                if (accessLogsReport.Count() > 32)
                {
                    grdVarialeB.SettingsPager.PageSize = accessLogsReport.Count();
                }
                else
                {
                    grdVarialeB.SettingsPager.PageSize = 32;
                }
                break;
            case VARC_PRINT_TYPE:

                grdVaribleC.DataSource = accessLogsReport;
                grdVaribleC.DataBind();
                if (accessLogsReport.Count() > 32)
                {
                    grdVaribleC.SettingsPager.PageSize = accessLogsReport.Count();
                }
                else
                {
                    grdVaribleC.SettingsPager.PageSize = 32;
                }
                break;

            }

            string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
            string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

            var logedInUser = String.Format("{0} {1}", firstName, lastName);

            accessLogsReport.Select(c => { c.LogedInUser = logedInUser; return c; }).ToList();

            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
            HttpContext.Current.Session["acReport"] = acReport;
        }

        protected void grdVarialeB_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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

        protected void grdVaribleC_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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
    }
}