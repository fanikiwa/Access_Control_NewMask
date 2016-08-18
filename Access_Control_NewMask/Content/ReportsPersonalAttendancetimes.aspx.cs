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
using DevExpress.Web;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsPersonalAttendancetimes : BasePage
    {
        private LocationViewModel _locationViewModel = new LocationViewModel();
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
            _initializeReportViewer();
            //AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReport());
            RebindGrids();
            if (!IsPostBack)
            {
                dtpFrom.Date = DateTime.Now;
                dtpTo.Date = DateTime.Now;
                LoadlocationtDetails();
                LoadClientDetails();
                BindSelectionDeptControls();
                BindCoastCenterControls();
                BindPersonnelList();
                BindPersTransponder();
                loadChecks();
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblLoggedInUser.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblLoggedInUserPers.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                chkVariableA.Checked = true;
                chkLandScape.Checked = true;
                chkVarientBLand.Checked = true;
                chkVarCLand.Checked = true;
                chkname.Checked = true;
                //BindReportsGrind();
            }
        }
        private void _initializeReportViewer()
        {
            if (chkVariableA.Checked)
            {
                //AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReport());
                if (chkLandScape.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReport());
                }
                else if (chkPortrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportPotrait());
                }
            }

            if (chkVaribleB.Checked)
            {
                //AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportB());
                if (chkVarientBLand.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportB());
                }
                else if (chkVarientBPotrait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportBPotrait());
                }
            }
            if (chkVaribleC.Checked)
            {
                //AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportC());
                if (chkVarCLand.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportC());
                }
                else if (chkVarCPotait.Checked)
                {
                    AttendanceLocalASPxDocumentViewer.OpenReport(new AttendanceTimesReportCPotrait());
                }
            }
        }
        protected void loadChecks()
        {
            //chkname.Checked = true;
            //chkcompany.Checked = true;
            //chkVariableA.Checked = true;
            //chkPersonalDate.Checked = true;
            //chkcostcenter.Checked = true;
            //chkdepartment.Checked = true;
            //chklocation.Checked = true;
            //chkaust.Checked = true;
            //chkenstri.Checked = true;
        }
        protected void BindReportsGrind()
        {
            AccessReportsViewModel _accessreportsViewModel = new AccessReportsViewModel();
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();

            accessLogsReport = _accessreportsViewModel.GetPersonalAccessLogs();

            grdShowReport.DataSource = accessLogsReport;
            grdShowReport.DataBind();
            grdVarialeB.DataSource = accessLogsReport;
            grdVarialeB.DataBind();
            grdVaribleC.DataSource = accessLogsReport;
            grdVaribleC.DataBind();
            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
            Session["grdreportsSession"] = accessLogsReport;
        }

        protected void RebindGrids()
        {
            if (Session["AccessLogReportsDto"] != null)
            {
                List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();

                accessLogsReport = (List<AccessLogReportsDto>)Session["AccessLogReportsDto"];

                grdShowReport.DataSource = accessLogsReport;
                grdShowReport.DataBind();
                grdVarialeB.DataSource = accessLogsReport;
                grdVarialeB.DataBind();
                grdVaribleC.DataSource = accessLogsReport;
                grdVaribleC.DataBind();

            }

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

            var locList = new AccessPlanGroupReaderViewModel().BuildingPlanLocationsPersonal2();
            BuildingPlanModelRptDto locDto = new BuildingPlanModelRptDto()
            {
                BuildingPlanId = -1,
                BuildingPlanName = "keine Auswahl",
                LocationKey = -1,
                LocationName = "keine Auswahl",
                BuildingKey = -1,
                BuildingName = "keine Auswahl",
                LevelKey = -1,
                Level = "keine Auswahl",
                RoomKey = -1,
                Room = "keine Auswahl",
                DoorKey = -1,
                Door = "keine Auswahl",
            };

            List<BuildingPlanModelRptDto> locationList = new List<BuildingPlanModelRptDto>();
            locationList.Add(locDto);
            locationList.AddRange(locList);
            HttpContext.Current.Session["PersRpt_BuildingPlanModelsRpt"] = locationList;
            //LoadBuildingPlanDrp(locationList);
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

            cboClientName.DataSource = clients;
            cboClientName.DataBind();
            cboClientNameto.DataSource = clients;
            cboClientNameto.DataBind();

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

            cboDeptName.DataSource = DepartmentsList;
            cboDeptName.DataBind();
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
        public void BindPersonnelList()
        {
            var persList = new PersonnelViewModel().GetALLPersonnel();

            List<PersonnelDto> Personnels = new List<PersonnelDto>();

            Personnels.AddRange(persList);
            cmbPersName.DataSource = Personnels;
            cmbPersName.DataBind();
            cmbPersNameTo.DataSource = Personnels;
            cmbPersNameTo.DataBind();
            cboPersonalID.DataSource = Personnels;
            cboPersonalID.DataBind();
            cmbIDNrTo.DataSource = Personnels;
            cmbIDNrTo.DataBind();

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

            TranspondersListFilter.Insert(0, new Pers_Transponders { ID = 0, TransponderNr = 0 });
            TranspondersListFilter2.Insert(0, new Pers_Transponders { ID = 0, TransponderNr = 0 });

            cboLongTransponder.DataSource = TranspondersList;
            cboLongTransponder.DataBind();
            cboLongTransponderTo.DataSource = TranspondersList;
            cboLongTransponderTo.DataBind();
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

                accessLogsReport.AddRange(_accessreportsViewModel.GetPersonalAttendanceLogs(false,acReport));
            }

            accessLogsReport = accessLogsReport.Select(c => { c.BookingDateFrom = startDate; return c; }).ToList();
            accessLogsReport = accessLogsReport.Select(c => { c.BookingDateTo = endDate; return c; }).ToList();

            double totalMinutes = accessLogsReport.Select(x => x.DurationTimespan.TotalMinutes).Sum();
            TimeSpan totalDuration = TimeSpan.FromMinutes(totalMinutes);
            accessLogsReport.Add(new AccessLogReportsDto { ID = 9999, ExitTimeText="Gesamtstunden", DurationText = Convert.ToInt32(totalDuration.TotalHours).ToString("00") + "," + totalDuration.Minutes.ToString("00") });

            switch (acReport.Type)
            {
                case OBJECT_PRINT_TYPE:
                    //grdShowReport.Columns["PersClient"].Visible = acReport.DisplayClient;
                    //grdShowReport.Columns["PersLocation"].Visible = acReport.DisplayLocation;
                    //grdShowReport.Columns["PersDepartement"].Visible = acReport.DisplayDepartment;
                    //grdShowReport.Columns["CardNumber"].Visible = acReport.DisplayLongTermCard;
                    //grdShowReport.Columns["PersCostCenter"].Visible = acReport.DisplayCostCenter;
                    //grdShowReport.Columns["PersonID"].Visible = acReport.DisplayPersonalID;
                    grdShowReport.DataSource = accessLogsReport;
                    grdShowReport.DataBind();
                    //Session["grdreportsSession"] = accessLogsReport;
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
                    //grdVarialeB.Columns["PersClient"].Visible = acReport.DisplayClient;
                    //grdVarialeB.Columns["PersLocation"].Visible = acReport.DisplayLocation;
                    //grdVarialeB.Columns["PersDepartement"].Visible = acReport.DisplayDepartment;
                    //grdVarialeB.Columns["CardNumber"].Visible = acReport.DisplayLongTermCard;
                    //grdVarialeB.Columns["PersCostCenter"].Visible = acReport.DisplayCostCenter;
                    //grdVarialeB.Columns["PersonID"].Visible = acReport.DisplayPersonalID;
                    grdVarialeB.DataSource = accessLogsReport;
                    grdVarialeB.DataBind();
                    //Session["grdreportsSession"] = accessLogsReport;
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
                    //grdVaribleC.Columns["PersClient"].Visible = acReport.DisplayClient;
                    //grdVaribleC.Columns["PersLocation"].Visible = acReport.DisplayLocation;
                    //grdVaribleC.Columns["PersDepartement"].Visible = acReport.DisplayDepartment;
                    //grdVaribleC.Columns["CardNumber"].Visible = acReport.DisplayLongTermCard;
                    //grdVaribleC.Columns["PersCostCenter"].Visible = acReport.DisplayCostCenter;
                    //grdVaribleC.Columns["PersonID"].Visible = acReport.DisplayPersonalID;
                    grdVaribleC.DataSource = accessLogsReport;
                    grdVaribleC.DataBind();
                    //Session["grdreportsSession"] = accessLogsReport;
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

            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
            HttpContext.Current.Session["acReport"] = acReport;


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

        protected void grdVaribleC_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            string totalText = Convert.ToString(grdVaribleC.GetRowValues(e.VisibleIndex, "ExitTimeText"));

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

        protected void grdVarialeB_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            string totalText = Convert.ToString(grdVaribleC.GetRowValues(e.VisibleIndex, "ExitTimeText"));

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