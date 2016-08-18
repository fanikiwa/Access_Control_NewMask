using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Dtos;
using System.Web.Services;
using DevExpress.Web;
using Access_Control_NewMask.Controllers;
using Newtonsoft.Json;

namespace Access_Control_NewMask.Content
{
    public partial class VisitorReports : BasePage
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
                btnEntSave.Enabled = false; btnNew.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalReport());

            this.Form.DefaultButton = this.btnEntSave.UniqueID;
            _initializeReportViewer();
            RebindGrids();
            if (!IsPostBack)
            {
                loadChecks();
                //  LoadlocationDetails();
                chkLandScape.Checked = true;
                chkPersonalLand.Checked = true;
                LoadlocationtDetails();
                BindSelectionDeptControls();
                BindCoastCenterControls();
                BindPersonnelList();
                BindPersTransponder();
                bindGrind();
                BindVisitors(0);
                BindTransponders();
                LoadClientDetails();
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblLoggedInUser.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
            }
        }

        private void _initializeReportViewer()
        {
            if (chkoject.Checked)
            {
                //VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalReport());
                if (chkLandScape.Checked)
                {
                    VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalReport());
                }
                else if (chkPortrait.Checked)
                {
                    VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalReportPotrait());
                }
            }

            if (chkPersonal.Checked)
            {
                //VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalPersonalReport());
                if (chkPersonalLand.Checked)
                {
                    VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalPersonalReport());
                }
                else if (chKPersonalPotraint.Checked)
                {
                    VisitorLocalASPxDocumentViewer.OpenReport(new VisitorProtocalPersonalReportPotrait());
                }
            }
        }

        protected void loadChecks()
        {
            chkObjDate.Checked = true;
            chkPersonalDate.Checked = true;
            chkObjTime.Checked = true;
            chkPersTime.Checked = true;
            chkObjDoor.Checked = true;
            chkReaderDoor.Checked = true;
            chkObjShortTermCard.Checked = true;
            chkPersShortTermCard.Checked = true;
            chkoject.Checked = true;
            lblObjectschks.Style.Add("background-color", "#FEF1C7");
        }
        protected void RebindGrids()
        {
            if (Session["AccessLogReportsDto"] != null)
            {
                List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();

                accessLogsReport = (List<AccessLogReportsDto>)Session["AccessLogReportsDto"];

                grdPersonalAccessReport.DataSource = accessLogsReport;
                grdPersonalAccessReport.DataBind();
                grdShoewReport.DataSource = accessLogsReport;
                grdShoewReport.DataBind();

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
            LoadBuildingPlanDrp(locationList);
        }


        protected void LoadBuildingPlanDrp(List<BuildingPlanModelRptDto> buildingPlanModelsRpt)
        {
            cbolocation.DataSource = buildingPlanModelsRpt.GroupBy(x => x.LocationID).Select(x => x.FirstOrDefault()).ToList();
            cbolocation.DataBind();
            cbolocation.SelectedIndex = 0;
            cbolocationto.DataSource = buildingPlanModelsRpt.GroupBy(x => x.LocationID).Select(x => x.FirstOrDefault()).ToList();
            cbolocationto.DataBind();
            cbolocationto.SelectedIndex = 0;
            cboBuilding.DataSource = (buildingPlanModelsRpt.Where(w => w.BuildingKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.BuildingID).Select(x => x.FirstOrDefault()).ToList();
            cboBuilding.DataBind();
            cboBuilding.SelectedIndex = 0;
            cboBuildingTo.DataSource = (buildingPlanModelsRpt.Where(w => w.BuildingKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.BuildingID).Select(x => x.FirstOrDefault()).ToList();
            cboBuildingTo.DataBind();
            cboBuildingTo.SelectedIndex = 0;
            cboLevels.DataSource = (buildingPlanModelsRpt.Where(w => w.LevelKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.LevelID).Select(x => x.FirstOrDefault()).ToList();
            cboLevels.DataBind();
            cboLevels.SelectedIndex = 0;
            cboLevelsTo.DataSource = (buildingPlanModelsRpt.Where(w => w.LevelKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.LevelID).Select(x => x.FirstOrDefault()).ToList();
            cboLevelsTo.DataBind();
            cboLevelsTo.SelectedIndex = 0;
            cboRooms.DataSource = (buildingPlanModelsRpt.Where(w => w.RoomKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.RoomID).Select(x => x.FirstOrDefault()).ToList();
            cboRooms.DataBind();
            cboRooms.SelectedIndex = 0;
            cboRoomsTo.DataSource = (buildingPlanModelsRpt.Where(w => w.RoomKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.RoomID).Select(x => x.FirstOrDefault()).ToList();
            cboRoomsTo.DataBind();
            cboRoomsTo.SelectedIndex = 0;
            cboDoors.DataSource = (buildingPlanModelsRpt.Where(w => w.DoorKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.DoorID).Select(x => x.FirstOrDefault()).ToList();
            cboDoors.DataBind();
            cboDoors.SelectedIndex = 0;
            cboDoorTo.DataSource = (buildingPlanModelsRpt.Where(w => w.DoorKey == -1) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.DoorID).Select(x => x.FirstOrDefault()).ToList();
            cboDoorTo.DataBind();
            cboDoorTo.SelectedIndex = 0;
        }

        protected void LoadlocationDetails()
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
            cbolocation.DataSource = locationList.GroupBy(x => x.LocationID).Select(x => x.FirstOrDefault()).ToList();
            cbolocation.DataBind();
            cbolocation.SelectedIndex = 0;
            cbolocationto.DataSource = locationList.GroupBy(x => x.LocationID).Select(x => x.FirstOrDefault()).ToList();
            cbolocationto.DataBind();
            cbolocationto.SelectedIndex = 0;
            cboBuilding.DataSource = (locationList.Where(w => w.BuildingKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.BuildingID).Select(x => x.FirstOrDefault()).ToList();
            cboBuilding.DataBind();
            cboBuildingTo.DataSource = (locationList.Where(w => w.BuildingKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.BuildingID).Select(x => x.FirstOrDefault()).ToList();
            cboBuildingTo.DataBind();
            cboLevels.DataSource = (locationList.Where(w => w.LevelKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.LevelID).Select(x => x.FirstOrDefault()).ToList();
            cboLevels.DataBind();
            cboLevelsTo.DataSource = (locationList.Where(w => w.LevelKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.LevelID).Select(x => x.FirstOrDefault()).ToList();
            cboLevelsTo.DataBind();
            cboRooms.DataSource = (locationList.Where(w => w.RoomKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.RoomID).Select(x => x.FirstOrDefault()).ToList();
            cboRooms.DataBind();
            cboRoomsTo.DataSource = (locationList.Where(w => w.RoomKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.RoomID).Select(x => x.FirstOrDefault()).ToList();
            cboRoomsTo.DataBind();
            cboDoors.DataSource = (locationList.Where(w => w.DoorKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.DoorID).Select(x => x.FirstOrDefault()).ToList();
            cboDoors.DataBind();
            cboDoorTo.DataSource = (locationList.Where(w => w.DoorKey != 0) ?? new List<BuildingPlanModelRptDto>()).GroupBy(x => x.DoorID).Select(x => x.FirstOrDefault()).ToList();
            cboDoorTo.DataBind();
        }
        protected void BindReportsGrind()
        {
            AccessReportsViewModel _accessreportsViewModel = new AccessReportsViewModel();
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();

            accessLogsReport = _accessreportsViewModel.GetPersonalAccessLogs();

            grdShoewReport.DataSource = accessLogsReport;
            grdShoewReport.DataBind();
            HttpContext.Current.Session["AccessLogReportsDto"] = accessLogsReport;
        }
        protected void LoadClientDetails()
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

            //cboDeptName.DataSource = DepartmentsList;
            //cboDeptName.DataBind();
            //cboDeptNameTo.DataSource = DepartmentsList;
            //cboDeptNameTo.DataBind();



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


            //cboCostCenterName.DataSource = CostCentersList;
            //cboCostCenterName.DataBind();
            //cboCostCenterNameTo.DataSource = CostCentersList;
            //cboCostCenterNameTo.DataBind();



        }
        public void BindPersonnelList()
        {
            var persList = new PersonnelViewModel().GetALLPersonnel();

            List<PersonnelDto> Personnels = new List<PersonnelDto>();

            Personnels.AddRange(persList);
            cmbPersName.DataSource = Personnels;
            cmbPersName.DataBind();
            //cmbPersNameTo.DataSource = Personnels;
            //cmbPersNameTo.DataBind();

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
                    cmbPersName.DataSource = listVisitors;
                    cmbPersName.DataBind();
                    cmbPersNameTo.DataSource = listVisitors;
                    cmbPersNameTo.DataBind();

                    break;
                case 1:
                    cmbPersName.DataSource = listVisitors;
                    cmbPersName.DataBind();
                    cmbPersNameTo.DataSource = listVisitors;
                    cmbPersNameTo.DataBind();
                    break;

            }
        }
        protected void BindPersTransponder()
        {

            //VisitorTransponder visitor_Transponders = new VisitorTransponder()
            //{
            //    ID = 0,
            //    TransponderNr = 0,
            //    TransponderType = 0,
            //};

            //var Transponders = new PersTranspondersRepository().GetAllPersTransponders();

            //List<Pers_Transponders> TranspondersList = new List<Pers_Transponders>();
            //TranspondersList.Add(_Pers_Transponders);
            //TranspondersList.AddRange(Transponders);
            //List<Pers_Transponders> TranspondersListFilter = TranspondersList.Where(k => k.TransponderType == 1).ToList();
            //List<Pers_Transponders> TranspondersListFilter2 = TranspondersList.Where(k => k.TransponderType == 2).ToList();
            //cboLongTransponder.DataSource = TranspondersListFilter;
            //cboLongTransponder.DataBind();
            //cboLongTransponderTo.DataSource = TranspondersListFilter;
            //cboLongTransponderTo.DataBind();
            //cboShortTransponder.DataSource = TranspondersListFilter2;
            //cboShortTransponder.DataBind();
            //cboShortTransponderTo.DataSource = TranspondersListFilter2;
            //cboShortTransponderTo.DataBind();
        }
        protected void bindGrind()
        {


            AC_Reports _AC_Reports = new AC_Reports()
            {
                ID = 0,
                Nr = 0,
                Name = "keine Auswahl",
            };
            var AllAccessReports = new AccessVisitorReportsRepository().GetAccessVisitorReports();

            List<AC_Reports> aC_Reports = new List<AC_Reports>();
            aC_Reports.Add(_AC_Reports);
            aC_Reports.AddRange(AllAccessReports);

            cboAccesReportNo.DataSource = aC_Reports;
            cboAccesReportNo.DataBind();

            cboAccesReportDesc.DataSource = aC_Reports;
            cboAccesReportDesc.DataBind();

            grdReport.DataSource = AllAccessReports;
            grdReport.DataBind();
            grdReport.FocusedRowIndex = -1;

        }

        protected void cboAccesReportNo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            AccessVisitorReportsRepository _AccessReportsRepositoryy = new AccessVisitorReportsRepository();
            var AccessReportlist = _AccessReportsRepositoryy.GetAccessVisitorReports().ToList();
            cboAccesReportNo.DataSource = AccessReportlist;
            cboAccesReportNo.DataBind();
        }

        protected void cboAccesReportDesc_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            AccessVisitorReportsRepository _AccessReportsRepositoryy = new AccessVisitorReportsRepository();
            var AccessReportlist = _AccessReportsRepositoryy.GetAccessVisitorReports().ToList();
            cboAccesReportDesc.DataSource = AccessReportlist;
            cboAccesReportDesc.DataBind();
        }


        [WebMethod]
        public static AC_Reports GetAccessVisitorReportbyid(long id)
        {
            AccessVisitorReportsRepository _AccessReportsRepository = new AccessVisitorReportsRepository();
            AC_Reports _AC_Reports = new AC_Reports();

            var aCReports = _AccessReportsRepository.GetAccessVisitorReportById(id);
            if (aCReports == null)
            {
                return null;
            }
            if (aCReports != null)
            {
                _AC_Reports.ID = aCReports.ID;
                _AC_Reports.Nr = aCReports.Nr;
                _AC_Reports.Name = aCReports.Name;
                _AC_Reports.StartLocationB = aCReports.StartLocationB;
                _AC_Reports.EndLocationB = aCReports.EndLocationB;
                _AC_Reports.StartBuilding = aCReports.StartBuilding;
                _AC_Reports.EndBuilding = aCReports.EndBuilding;
                _AC_Reports.StartLevel = aCReports.StartLevel;
                _AC_Reports.EndLevel = aCReports.EndLevel;
                _AC_Reports.StartRoom = aCReports.StartRoom;
                _AC_Reports.EndRoom = aCReports.EndRoom;
                _AC_Reports.StartDoor = aCReports.StartDoor;
                _AC_Reports.EndDoor = aCReports.EndDoor;
                _AC_Reports.EndLocation = aCReports.EndLocation;
                _AC_Reports.StartClient = aCReports.StartClient;
                _AC_Reports.EndClient = aCReports.EndClient;
                _AC_Reports.StartLocation = aCReports.StartLocation;
                _AC_Reports.StartCostCenter = aCReports.StartCostCenter;
                _AC_Reports.EndCostCenter = aCReports.EndCostCenter;
                _AC_Reports.StartDept = aCReports.StartDept;
                _AC_Reports.EndDept = aCReports.EndDept;
                _AC_Reports.StartPersonal = aCReports.StartPersonal;
                _AC_Reports.EndPersonal = aCReports.EndPersonal;
                _AC_Reports.StartShortTransponder = aCReports.StartShortTransponder;
                _AC_Reports.EndShortTranspoder = aCReports.EndShortTranspoder;
                _AC_Reports.StartLongTranspoder = aCReports.StartLongTranspoder;
                _AC_Reports.EndLongTransponder = aCReports.EndLongTransponder;

                _AC_Reports.StartDate = aCReports.StartDate;
                _AC_Reports.EndDate = aCReports.EndDate;

                _AC_Reports.StartTime = aCReports.StartTime;
                _AC_Reports.EndTime = aCReports.EndTime;

            };
            return _AC_Reports;
        }

        [WebMethod]
        public static AC_Reports CreateEditAccessReports(string id, string AccessNr, string AccessName, string rederLocFrom, string rederLocTo, string rederBuildingFrom, string rederBuildingTo, string rederLevelFom, string rederLevelTo, string rederRoomFrom, string rederRoomTo, string rederDoorFom, string rederDoorTo, string perClientNameFrom, string perClientNameTo, string perPersonalFrom, string perPersonalTo, string perShortTrannspoderFrom, string stringperShortTrannspoderTo, DateTime dateFrom, DateTime dateTo, string printSelection, string date, string time, string location, string building, string level, string room, string door, string studioGroup, string persName, string persCardNrShort, DateTime timeFrom, DateTime timeTo)
        {
            var AccessReport = new AC_Reports();
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                AC_ReportSettings _AC_ShowReports = new AC_ReportSettings()
                {
                    PrintSelection = Convert.ToInt32(printSelection),
                    ShowDate = Convert.ToBoolean(Convert.ToInt32(date)),
                    ShowTime = Convert.ToBoolean(Convert.ToInt32(time)),
                    ShowBuildingLocation = Convert.ToBoolean(Convert.ToInt32(location)),
                    ShowBuilding = Convert.ToBoolean(Convert.ToInt32(building)),
                    ShowFloor = Convert.ToBoolean(Convert.ToInt32(level)),
                    ShowRoom = Convert.ToBoolean(Convert.ToInt32(room)),
                    ShowReader = Convert.ToBoolean(Convert.ToInt32(door)),
                    ShowCompany = Convert.ToBoolean(Convert.ToInt32(studioGroup)),
                    ShowPersName = Convert.ToBoolean(Convert.ToInt32(persName)),
                    ShowPersCardNrShort = Convert.ToBoolean(Convert.ToInt32(persCardNrShort)),
                };

                AC_Reports _AC_Reports = new AC_Reports()
                {
                    Nr = Convert.ToInt64(AccessNr),
                    Name = AccessName,
                    StartLocationB = rederLocFrom,
                    EndLocationB = rederLocTo,
                    StartBuilding = rederBuildingFrom,
                    EndBuilding = rederBuildingTo,

                    EndLevel = rederLevelTo,

                    StartRoom = rederRoomFrom,
                    EndRoom = rederRoomTo,

                    StartDoor = rederDoorFom,
                    EndDoor = rederDoorTo,

                    StartClient = Convert.ToInt32(perClientNameFrom),
                    EndClient = Convert.ToInt32(perClientNameTo),
                    StartPersonal = Convert.ToInt32(perPersonalFrom),
                    EndPersonal = Convert.ToInt32(perPersonalTo),
                    StartShortTransponder = Convert.ToInt32(perShortTrannspoderFrom),
                    EndShortTranspoder = Convert.ToInt32(stringperShortTrannspoderTo),
                    StartDate = dateFrom,
                    EndDate = dateTo,
                    StartTime = timeFrom,
                    EndTime = timeTo,
                    StartLevel = rederLevelFom,
                };
                new AccessVisitorReportsRepository().NewAccessVisitorReport(_AC_Reports);
                AccessReport = _AC_Reports;

                _AC_ShowReports.ReportID = _AC_Reports.ID;
                new AccessReportsChecks().NewVisitorAccessCheck(_AC_ShowReports);

                return AccessReport;
            }
            else
            {
                var accessReport = new AccessVisitorReportsRepository().GetAccessVisitorReportById(Convert.ToInt64(id));
                if (id != null || id != "0")
                {
                    AC_ReportSettings _AC_ShowReports = new AC_ReportSettings()
                    {
                        PrintSelection = Convert.ToInt32(printSelection),
                        ShowDate = Convert.ToBoolean(Convert.ToInt32(date)),
                        ShowTime = Convert.ToBoolean(Convert.ToInt32(time)),
                        ShowBuildingLocation = Convert.ToBoolean(Convert.ToInt32(location)),
                        ShowBuilding = Convert.ToBoolean(Convert.ToInt32(building)),
                        ShowFloor = Convert.ToBoolean(Convert.ToInt32(level)),
                        ShowRoom = Convert.ToBoolean(Convert.ToInt32(room)),
                        ShowReader = Convert.ToBoolean(Convert.ToInt32(door)),
                        ShowCompany = Convert.ToBoolean(Convert.ToInt32(studioGroup)),
                        ShowPersName = Convert.ToBoolean(Convert.ToInt32(persName)),
                        ShowPersCardNrShort = Convert.ToBoolean(Convert.ToInt32(persCardNrShort)),
                    };
                    AC_Reports _AC_Reports = new AC_Reports()
                    {
                        ID = Convert.ToInt64(id),
                        Nr = Convert.ToInt64(AccessNr),
                        Name = AccessName,
                        StartLocationB = rederLocFrom,
                        EndLocationB = rederLocTo,
                        StartBuilding = rederBuildingFrom,
                        EndBuilding = rederBuildingTo,

                        EndLevel = rederLevelTo,

                        StartRoom = rederRoomFrom,
                        EndRoom = rederRoomTo,

                        StartDoor = rederDoorFom,
                        EndDoor = rederDoorTo,

                        StartClient = Convert.ToInt32(perClientNameFrom),
                        EndClient = Convert.ToInt32(perClientNameTo),
                        StartPersonal = Convert.ToInt32(perPersonalFrom),
                        EndPersonal = Convert.ToInt32(perPersonalTo),
                        StartShortTransponder = Convert.ToInt32(perShortTrannspoderFrom),
                        EndShortTranspoder = Convert.ToInt32(stringperShortTrannspoderTo),
                        StartDate = dateFrom,
                        EndDate = dateTo,
                        StartTime = timeFrom,
                        EndTime = timeTo,
                        StartLevel = rederLevelFom,
                    };
                    new AccessVisitorReportsRepository().EditAccessVisitorReport(_AC_Reports);
                    //accessReport = _AC_Reports;
                    //_AC_ShowReports.ReportID = _AC_Reports.ID;
                    //new AccessReportsChecks().EditVisitorAccessCheck(_AC_ShowReports);

                    accessReport = _AC_Reports;

                    var reportID = _AC_Reports.ID;

                    var accessCheckReport = new AccessReportsChecks().GetVisitorCheckByReportId(Convert.ToInt64(reportID));
                    if (accessCheckReport != null)
                    {
                        _AC_ShowReports.ID = accessCheckReport.ID;
                        _AC_ShowReports.ReportID = reportID;
                        accessCheckReport = _AC_ShowReports;
                        new AccessReportsChecks().EditVisitorAccessCheck(_AC_ShowReports);
                    }

                }
                return accessReport;
            }
        }


        [WebMethod]
        public static AC_ReportSettings GetAccessCheckbyid(long id)
        {
            AccessReportsChecks _AccessReportsChecks = new AccessReportsChecks();

            AC_ReportSettings _AC_ReportSettings = new AC_ReportSettings();

            var ReportSetting = _AccessReportsChecks.GetVisitorCheckByReportId(id);
            if (ReportSetting == null)
            {
                return null;
            }

            if (ReportSetting != null)
            {
                _AC_ReportSettings.ID = ReportSetting.ID;
                _AC_ReportSettings.ReportID = ReportSetting.ReportID;
                _AC_ReportSettings.ShowDate = ReportSetting.ShowDate;
                _AC_ReportSettings.ShowTime = ReportSetting.ShowTime;
                _AC_ReportSettings.ShowBuildingLocation = ReportSetting.ShowBuildingLocation;
                _AC_ReportSettings.ShowBuilding = ReportSetting.ShowBuilding;
                _AC_ReportSettings.ShowFloor = ReportSetting.ShowFloor;
                _AC_ReportSettings.ShowRoom = ReportSetting.ShowRoom;
                _AC_ReportSettings.ShowReader = ReportSetting.ShowReader;
                _AC_ReportSettings.ShowCompany = ReportSetting.ShowCompany;
                _AC_ReportSettings.ShowPersLocation = ReportSetting.ShowPersLocation;
                _AC_ReportSettings.ShowPersDepartment = ReportSetting.ShowPersDepartment;
                _AC_ReportSettings.ShowPersCC = ReportSetting.ShowPersCC;
                _AC_ReportSettings.ShowPersName = ReportSetting.ShowPersName;
                _AC_ReportSettings.ShowPersCardNrLong = ReportSetting.ShowPersCardNrLong;
                _AC_ReportSettings.ShowPersCardNrShort = ReportSetting.ShowPersCardNrShort;
                _AC_ReportSettings.PrintSelection = ReportSetting.PrintSelection;
            };
            return _AC_ReportSettings;
        }

        protected void grdReport_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            AccessVisitorReportsRepository _AccessReportsRepositoryy = new AccessVisitorReportsRepository();
            var AccessReportlist = _AccessReportsRepositoryy.GetAccessVisitorReports().ToList();
            grdReport.DataSource = AccessReportlist;
            grdReport.DataBind();

        }

        [WebMethod]
        public static long CalculateNextNr()
        {
            var acceReport = new AccessVisitorReportsRepository().GetAccessVisitorReports();
            long LastAccessReport = 0;
            if (acceReport.Count > 0)
            {
                LastAccessReport = acceReport.Max(x => x.Nr);
            }
            return LastAccessReport + 1;

        }
        [WebMethod()]
        public static string GetResourceText(string key)
        {
            return BasePage.GetLocalizedText(key);
        }

        [WebMethod]
        public static bool DeleteAccessReport(long Id)
        {
            AccessVisitorReportsRepository persRep = new AccessVisitorReportsRepository();

            var accessreport = persRep.GetAccessVisitorReportById(Convert.ToInt32(Id));
            if (accessreport != null)
            {
                new AccessVisitorReportsRepository().DeleteAccessVisitorReport(accessreport);
            }
            return persRep.GetAccessVisitorReportByNr(Convert.ToInt32(Id)) == null;
        }

        protected void LoadBuildingDrp(ASPxComboBox sender)
        {
            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();

            List<BuildingPlanModelRptDto> _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();

            string locationValueFrom = Convert.ToString(cbolocation.Value ?? "").Trim();
            string locationValueTo = Convert.ToString(cbolocationto.Value ?? "").Trim();

            FilterLocations(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, locationValueFrom, locationValueTo);

            sender.DataSource = (_buildingPlanModelsRpt.Where(w => w.BuildingKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.BuildingID).Select(x => x.FirstOrDefault()).ToList();
            sender.DataBind();
        }

        private static void FilterLocations(List<BuildingPlanModelRptDto> buildingPlanModelsRpt, ref List<BuildingPlanModelRptDto> _buildingPlanModelsRpt, string locationValueFrom, string locationValueTo)
        {
            BuildingPlanModelRptDto buildingPlanModelRptFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.LocationID == locationValueFrom) ??
                            new BuildingPlanModelRptDto() { BuildingPlanId = -1 };
            BuildingPlanModelRptDto buildingPlanModelRptTo = buildingPlanModelsRpt.FirstOrDefault(x => x.LocationID == locationValueTo) ??
                new BuildingPlanModelRptDto() { BuildingPlanId = -1 };

            _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();
            _buildingPlanModelsRpt.Add(new BuildingPlanModelRptDto()
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
            });

            if (buildingPlanModelRptFrom.BuildingPlanId != buildingPlanModelRptTo.BuildingPlanId &&
                buildingPlanModelRptFrom.BuildingPlanId != -1 && buildingPlanModelRptTo.BuildingPlanId != -1)
            {
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId > buildingPlanModelRptFrom.BuildingPlanId &&
                    x.BuildingPlanId < buildingPlanModelRptTo.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptTo.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
            }
            //else if (buildingPlanModelRptFrom.BuildingPlanId == -1 && buildingPlanModelRptTo.BuildingPlanId == -1)
            //{
            //    _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt);
            //}
            else
            {
                _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>());
            }
        }

        protected void LoadFloorDrp(ASPxComboBox sender)
        {
            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();

            List<BuildingPlanModelRptDto> _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();

            string buildingValueFrom = Convert.ToString(cboBuilding.Value ?? "").Trim();
            string buildingValueTo = Convert.ToString(cboBuildingTo.Value ?? "").Trim();

            FilterBuildings(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, buildingValueFrom, buildingValueTo);

            sender.DataSource = (_buildingPlanModelsRpt.Where(w => w.LevelKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.LevelID).Select(x => x.FirstOrDefault()).ToList();
            sender.DataBind();
        }

        private static void FilterBuildings(List<BuildingPlanModelRptDto> buildingPlanModelsRpt, ref List<BuildingPlanModelRptDto> _buildingPlanModelsRpt, string buildingValueFrom, string buildingValueTo)
        {
            BuildingPlanModelRptDto buildingPlanModelRptFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.BuildingID == buildingValueFrom) ??
                            new BuildingPlanModelRptDto() { BuildingPlanId = -1 };
            BuildingPlanModelRptDto buildingPlanModelRptTo = buildingPlanModelsRpt.FirstOrDefault(x => x.BuildingID == buildingValueTo) ??
                new BuildingPlanModelRptDto() { BuildingPlanId = -1 };

            _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();
            _buildingPlanModelsRpt.Add(new BuildingPlanModelRptDto()
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
            });

            if (buildingPlanModelRptFrom.BuildingPlanId != buildingPlanModelRptTo.BuildingPlanId &&
                buildingPlanModelRptFrom.BuildingPlanId != -1 && buildingPlanModelRptTo.BuildingPlanId != -1)
            {
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId &&
                    x.BuildingKey >= buildingPlanModelRptFrom.BuildingKey).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId > buildingPlanModelRptFrom.BuildingPlanId &&
                    x.BuildingPlanId < buildingPlanModelRptTo.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptTo.BuildingPlanId &&
                    x.BuildingKey <= buildingPlanModelRptTo.BuildingKey).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
            }
            //else if (buildingPlanModelRptFrom.BuildingPlanId == -1 && buildingPlanModelRptTo.BuildingPlanId == -1)
            //{
            //    _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt);
            //}
            else
            {
                _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId
                    && x.BuildingKey >= buildingPlanModelRptFrom.BuildingKey && x.BuildingKey <= buildingPlanModelRptTo.BuildingKey).ToList() ??
                    new List<BuildingPlanModelRptDto>());
            }
        }

        protected void LoadRoomDrp(ASPxComboBox sender)
        {
            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();

            List<BuildingPlanModelRptDto> _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();

            string floorValueFrom = Convert.ToString(cboLevels.Value ?? "").Trim();
            string floorValueTo = Convert.ToString(cboLevelsTo.Value ?? "").Trim();

            FilterFloors(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, floorValueFrom, floorValueTo);

            sender.DataSource = (_buildingPlanModelsRpt.Where(w => w.RoomKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.RoomID).Select(x => x.FirstOrDefault()).ToList();
            sender.DataBind();
        }

        private static void FilterFloors(List<BuildingPlanModelRptDto> buildingPlanModelsRpt, ref List<BuildingPlanModelRptDto> _buildingPlanModelsRpt, string floorValueFrom, string floorValueTo)
        {
            BuildingPlanModelRptDto buildingPlanModelRptFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.LevelID == floorValueFrom) ??
                            new BuildingPlanModelRptDto() { BuildingPlanId = -1 };
            BuildingPlanModelRptDto buildingPlanModelRptTo = buildingPlanModelsRpt.FirstOrDefault(x => x.LevelID == floorValueTo) ??
                new BuildingPlanModelRptDto() { BuildingPlanId = -1 };

            _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();
            _buildingPlanModelsRpt.Add(new BuildingPlanModelRptDto()
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
            });

            if (buildingPlanModelRptFrom.BuildingID != buildingPlanModelRptTo.BuildingID &&
                buildingPlanModelRptFrom.BuildingPlanId != -1 && buildingPlanModelRptTo.BuildingPlanId != -1)
            {
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId &&
                    x.BuildingID == buildingPlanModelRptFrom.BuildingID && x.LevelKey >= buildingPlanModelRptFrom.LevelKey).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId > buildingPlanModelRptFrom.BuildingPlanId &&
                    x.BuildingPlanId < buildingPlanModelRptTo.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptTo.BuildingPlanId &&
                    x.BuildingID == buildingPlanModelRptTo.BuildingID && x.LevelKey <= buildingPlanModelRptTo.LevelKey).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
            }
            //else if (buildingPlanModelRptFrom.BuildingPlanId == -1 && buildingPlanModelRptTo.BuildingPlanId == -1)
            //{
            //    _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt);
            //}
            else
            {
                _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId
                    && x.LevelKey >= buildingPlanModelRptFrom.LevelKey && x.LevelKey <= buildingPlanModelRptTo.LevelKey).ToList() ??
                    new List<BuildingPlanModelRptDto>());
            }
        }

        protected void LoadDoorDrp(ASPxComboBox sender)
        {
            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();

            List<BuildingPlanModelRptDto> _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();

            string roomValueFrom = Convert.ToString(cboRooms.Value ?? "").Trim();
            string roomValueTo = Convert.ToString(cboRoomsTo.Value ?? "").Trim();

            FilterRooms(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, roomValueFrom, roomValueTo);

            sender.DataSource = (_buildingPlanModelsRpt.Where(w => w.DoorKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.DoorID).Select(x => x.FirstOrDefault()).ToList();
            sender.DataBind();
        }

        private static void FilterRooms(List<BuildingPlanModelRptDto> buildingPlanModelsRpt, ref List<BuildingPlanModelRptDto> _buildingPlanModelsRpt, string roomValueFrom, string roomValueTo)
        {
            BuildingPlanModelRptDto buildingPlanModelRptFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.RoomID == roomValueFrom) ??
                            new BuildingPlanModelRptDto() { BuildingPlanId = -1 };
            BuildingPlanModelRptDto buildingPlanModelRptTo = buildingPlanModelsRpt.FirstOrDefault(x => x.RoomID == roomValueTo) ??
                new BuildingPlanModelRptDto() { BuildingPlanId = -1 };

            _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();
            _buildingPlanModelsRpt.Add(new BuildingPlanModelRptDto()
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
            });

            if (buildingPlanModelRptFrom.BuildingPlanId != -1 && buildingPlanModelRptTo.BuildingPlanId != -1)
            {
                //_buildingPlanModelsRpt.AddRange(
                //    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId &&
                //    x.LevelID == buildingPlanModelRptFrom.LevelID && x.RoomKey >= buildingPlanModelRptFrom.RoomKey).ToList() ??
                //    new List<BuildingPlanModelRptDto>()
                //    );
                _buildingPlanModelsRpt.AddRange(
                    buildingPlanModelsRpt.Where(x => x.BuildingPlanId >= buildingPlanModelRptFrom.BuildingPlanId &&
                    x.BuildingPlanId <= buildingPlanModelRptTo.BuildingPlanId).ToList() ??
                    new List<BuildingPlanModelRptDto>()
                    );
                _buildingPlanModelsRpt.RemoveAll(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId && x.LevelKey != -1 &&
                    ((x.LevelID == buildingPlanModelRptFrom.LevelID && x.RoomKey < buildingPlanModelRptFrom.RoomKey) || x.LevelKey < buildingPlanModelRptFrom.LevelKey));
                _buildingPlanModelsRpt.RemoveAll(x => x.BuildingPlanId == buildingPlanModelRptTo.BuildingPlanId && x.LevelKey != -1 &&
                    ((x.LevelID == buildingPlanModelRptTo.LevelID && x.RoomKey > buildingPlanModelRptTo.RoomKey || x.LevelKey > buildingPlanModelRptTo.LevelKey)));
                //_buildingPlanModelsRpt.AddRange(
                //    buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptTo.BuildingPlanId &&
                //    x.LevelID == buildingPlanModelRptTo.LevelID && x.RoomKey <= buildingPlanModelRptTo.RoomKey).ToList() ??
                //    new List<BuildingPlanModelRptDto>()
                //    );
            }
            //else if (buildingPlanModelRptFrom.BuildingPlanId == -1 && buildingPlanModelRptTo.BuildingPlanId == -1)
            //{
            //    _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt);
            //}
            else
            {
                //_buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId
                //    && x.BuildingKey >= buildingPlanModelRptFrom.BuildingKey && x.BuildingKey <= buildingPlanModelRptTo.BuildingKey
                //    && x.LevelKey >= buildingPlanModelRptFrom.LevelKey && x.LevelKey <= buildingPlanModelRptTo.LevelKey
                //    && x.RoomKey >= buildingPlanModelRptFrom.RoomKey && x.RoomKey <= buildingPlanModelRptTo.RoomKey).ToList() ??
                //    new List<BuildingPlanModelRptDto>());
                _buildingPlanModelsRpt.AddRange(buildingPlanModelsRpt.Where(x => x.BuildingPlanId == buildingPlanModelRptFrom.BuildingPlanId
                    && x.RoomKey >= buildingPlanModelRptFrom.RoomKey && x.RoomKey <= buildingPlanModelRptTo.RoomKey).ToList() ??
                    new List<BuildingPlanModelRptDto>());
            }
        }

        protected void cboBuilding_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            LoadBuildingDrp(cboBuilding);
        }

        protected void cboBuildingTo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            LoadBuildingDrp(cboBuildingTo);
        }

        protected void cboLevels_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadFloorDrp(cboLevels);

        }

        protected void cboLevelsTo_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadFloorDrp(cboLevelsTo);

        }

        protected void cboRooms_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadRoomDrp(cboRooms);

        }

        protected void cboRoomsTo_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadRoomDrp(cboRoomsTo);

        }

        protected void cboDoors_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadDoorDrp(cboDoors);

        }

        protected void cboDoorsTo_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadDoorDrp(cboDoorTo);

        }

        protected void OneTodayCallbackPanel_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void grdShoewReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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
        protected void grdPersonalAccessReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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
            const int PERSONAL_PRINT_TYPE = 1;

            accessLogsReport = _accessreportsViewModel.GetVisitorAccessLogs(true, acReport);
            switch (acReport.Type)
            {
                case OBJECT_PRINT_TYPE:

                    grdShoewReport.Columns["BPLocation"].Visible = acReport.DisplayBPLocation;
                    grdShoewReport.Columns["BPBuilding"].Visible = acReport.DisplayBPBuilding;
                    grdShoewReport.Columns["BPLevel"].Visible = acReport.DisplayBPFloor;
                    grdShoewReport.Columns["BPRoom"].Visible = acReport.DisplayBPRoom;
                    grdShoewReport.Columns["PersClient"].Visible = true;
                    grdShoewReport.Columns["Name"].Visible = true;
                    grdShoewReport.Columns["BookingDate"].Visible = acReport.DisplayDate;
                    grdShoewReport.Columns["BookingTime"].Visible = acReport.DisplayTime;
                    grdShoewReport.Columns["BPDoor"].Visible = acReport.DisplayBPDoor;
                    grdShoewReport.Columns["CardNumbershort"].Visible = acReport.DisplayShortTermCard;
                    grdShoewReport.DataSource = accessLogsReport;
                    grdShoewReport.DataBind();

                    if (accessLogsReport.Count() > 32)
                    {
                        grdShoewReport.SettingsPager.PageSize = accessLogsReport.Count();
                    }
                    else
                    {
                        grdShoewReport.SettingsPager.PageSize = 32;
                    }
                    break;
                case PERSONAL_PRINT_TYPE:
                    grdPersonalAccessReport.Columns["BPLocation"].Visible = acReport.DisplayBPLocation;
                    grdPersonalAccessReport.Columns["BPBuilding"].Visible = acReport.DisplayBPBuilding;
                    grdPersonalAccessReport.Columns["BPLevel"].Visible = acReport.DisplayBPFloor;
                    grdPersonalAccessReport.Columns["BPRoom"].Visible = acReport.DisplayBPRoom;
                    grdPersonalAccessReport.Columns["PersClient"].Visible = true;
                    grdPersonalAccessReport.Columns["Name"].Visible = true;
                    grdPersonalAccessReport.Columns["BookingDate"].Visible = acReport.DisplayDate;
                    grdPersonalAccessReport.Columns["BookingTime"].Visible = acReport.DisplayTime;
                    grdPersonalAccessReport.Columns["BPDoor"].Visible = acReport.DisplayBPDoor;
                    grdPersonalAccessReport.Columns["CardNumbershort"].Visible = acReport.DisplayShortTermCard;
                    grdPersonalAccessReport.DataSource = accessLogsReport;
                    grdPersonalAccessReport.DataBind();
                    if (accessLogsReport.Count() > 32)
                    {
                        grdPersonalAccessReport.SettingsPager.PageSize = accessLogsReport.Count();
                    }
                    else
                    {
                        grdPersonalAccessReport.SettingsPager.PageSize = 32;
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

        //protected void BindTransponders()
        //{
        //    long visitorNr = 0;
        //    var transpondersType1 = new VisitorTransponderViewModels().TransPonders(visitorNr, 1);
        //    var transpondersType2 = new VisitorTransponderViewModels().TransPonders(visitorNr, 2);

        //    try
        //    {
        //        cboShortTransponder.DataSource = transpondersType2;
        //        cboShortTransponder.DataBind();
        //        cboShortTransponderTo.DataSource = transpondersType2;
        //        cboShortTransponderTo.DataBind();
        //    }
        //    catch (Exception)
        //    { }

        //}
        protected void BindTransponders()
        {
            VisitorTransponder _VisitorTransponder = new VisitorTransponder()
            {
                ID = 0,
                TransponderNr = 0,
                TransponderType = 2,
            };


            var Transponders = new VisitorTranspondersRepository().GetAllVisitorTransponders();

            var transpondersType1 = new VisitorTranspondersRepository().GetAllVisitorTransponders().Where(x => x.TransponderType == 1);


            List<VisitorTransponder> TranspondersList = new List<VisitorTransponder>();
            TranspondersList.Add(_VisitorTransponder);
            TranspondersList.AddRange(Transponders);
            List<VisitorTransponder> TranspondersListFilter = TranspondersList.Where(k => k.TransponderType == 1).ToList();
            List<VisitorTransponder> TranspondersListFilter2 = TranspondersList.Where(k => k.TransponderType == 2).ToList();


            cboShortTransponder.DataSource = TranspondersListFilter2;
            cboShortTransponder.DataBind();
            cboShortTransponderTo.DataSource = TranspondersListFilter2;
            cboShortTransponderTo.DataBind();

        }

        [WebMethod]
        public static Dictionary<string, List<BuildingPlanModelRptDto>> GetBuildingPlanDetails(string locationValueFrom, string locationValueTo, string buildingValueFrom, string buildingValueTo,
            string floorValueFrom, string floorValueTo, string roomValueFrom, string roomValueTo)
        {
            Dictionary<string, List<BuildingPlanModelRptDto>> buildinPlanDetails = new Dictionary<string, List<BuildingPlanModelRptDto>>();


            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();

            List<BuildingPlanModelRptDto> _buildingPlanModelsRpt = new List<BuildingPlanModelRptDto>();

            FilterLocations(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, locationValueFrom, locationValueTo);
            _buildingPlanModelsRpt = _buildingPlanModelsRpt.OrderBy(d => d.BuildingKey).ToList();
            buildinPlanDetails.Add("buildings", (_buildingPlanModelsRpt.Where(w => w.BuildingKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.BuildingID).Select(x => x.FirstOrDefault()).ToList());
            _buildingPlanModelsRpt.Clear();

            FilterBuildings(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, buildingValueFrom, buildingValueTo);
            _buildingPlanModelsRpt = _buildingPlanModelsRpt.OrderBy(d => d.BuildingKey).ToList();
            buildinPlanDetails.Add("floors", (_buildingPlanModelsRpt.Where(w => w.LevelKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.LevelID).Select(x => x.FirstOrDefault()).ToList());
            _buildingPlanModelsRpt.Clear();

            FilterFloors(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, floorValueFrom, floorValueTo);
            _buildingPlanModelsRpt = _buildingPlanModelsRpt.OrderBy(d => d.BuildingKey).ToList();
            buildinPlanDetails.Add("rooms", (_buildingPlanModelsRpt.Where(w => w.RoomKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.RoomID).Select(x => x.FirstOrDefault()).ToList());
            _buildingPlanModelsRpt.Clear();

            FilterRooms(buildingPlanModelsRpt, ref _buildingPlanModelsRpt, roomValueFrom, roomValueTo);
            _buildingPlanModelsRpt = _buildingPlanModelsRpt.OrderBy(d => d.BuildingKey).ToList();
            buildinPlanDetails.Add("doors", (_buildingPlanModelsRpt.Where(w => w.DoorKey != 0) ?? new List<BuildingPlanModelRptDto>()).
                GroupBy(x => x.DoorID).Select(x => x.FirstOrDefault()).ToList());
            _buildingPlanModelsRpt.Clear();

            return buildinPlanDetails;
        }
    }
}