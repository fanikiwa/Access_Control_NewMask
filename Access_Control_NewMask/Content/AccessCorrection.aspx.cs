using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using System.Data;
using DevExpress.Web;
using System.Reflection;
using DevExpress.Web.Data;
using System.Web.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class AccessCorrection : BasePage
    {
        private static List<BookingsCorrection> userBbookingCorrections = null;
        private static long _personalNumberStatic = 0;
        private static int _logpersonalType = 0;
        private enum personalBookingStatus { bookingOK = 1, bookingError = 2, bookingCorrected = 3, noBooking = 4 }
        private enum bookingDirection { bookingNONE, bookingCOME, bookingGO }

        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Grader_PMode");
            }
            set
            {
                HttpContext.Current.Session["Grader_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Grader, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnEntEdit.Enabled = false; btnsave.Enabled = false; btnEntSave.Enabled = false; btnSaveGridSettings.Enabled = false;
                btnSelectAll.Enabled = false; btnUnSelectAll.Enabled = false; btnDeleteCorrection.Enabled = false; btnDeleteDayCorrection.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;
            if (!IsPostBack)
            {
                bool viewErrorBookingsOnly = false;
                bool viewVisitorBookingsOnly = false; //to get values from cookie
                _databindAccessLogGrid(DateTime.Today, DateTime.Today, 0, 0, 0, 0, 0, viewErrorBookingsOnly, viewVisitorBookingsOnly, false);
                _checkGridColumns();
                _bindVisibleCheckboxes();
                chkViewAllBookings.Checked = true;
                chkShowAllPeople.Checked = true;

                dtDateFrom.Value = DateTime.Today;
                dtDateTo.Value = DateTime.Today;
            }

            _bindAllFilterDropDoanLists();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Dashboard_Main.aspx");
        }

        private void _databindAccessLogGrid(DateTime dateFrom, DateTime dateTo, int clientID, long locationID, long departmentID, long costcenterID, long personalNumber, bool viewErrorBookingsOnly, bool viewVisitorBookingsOnly, bool includeWithoutBookings)
        {
            AccessControlProtocolViewModel accessControlProtocol = new AccessControlProtocolViewModel();

            List<AccessCorrectionLog> _dailyAccessLogsDto = new List<AccessCorrectionLog>();
            List<AccessCorrectionLog> accessLogsDto = new List<AccessCorrectionLog>();
            DateTime currentDate = new DateTime();

            for (currentDate = dateTo.Date; currentDate.Date >= dateFrom.Date; currentDate = currentDate.AddDays(-1))
            {
                _dailyAccessLogsDto = accessControlProtocol.getAccessControlprotocol(clientID, locationID, departmentID, costcenterID, personalNumber, currentDate, viewErrorBookingsOnly, viewVisitorBookingsOnly, includeWithoutBookings);

                _dailyAccessLogsDto = _dailyAccessLogsDto.OrderBy(x => x.Client).ThenBy(x => x.Name).ToList();
                accessLogsDto.AddRange(_dailyAccessLogsDto);
            }

            #region OldCode - Moved To accessControlProtocol

            //VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            //ClientsRepository clientRepo = new ClientsRepository();
            //LocationRepository locationRepo = new LocationRepository();
            //DepartmentRepository departmentRepo = new DepartmentRepository();
            //CostCenterRepository costcenterRepo = new CostCenterRepository();
            //List<VwPersonnelData> allPersonel = new List<VwPersonnelData>();

            //string clientName = string.Empty;
            //string locationName = string.Empty;
            //string departmentName = string.Empty;
            //string costcenterName = string.Empty;

            //if(clientID != 0)
            //{
            //    var client = clientRepo.GetClientsById(clientID);
            //    if(client != null)
            //    {
            //        clientName = client.Name;
            //    }
            //}
            //if (locationID != 0)
            //{
            //    var location = locationRepo.GetLocationById(locationID);
            //    if (location != null)
            //    {
            //        locationName = location.Name;
            //    }
            //}
            //if (departmentID != 0)
            //{
            //    var department = departmentRepo.GetDepartmentById(departmentID);
            //    if (department != null)
            //    {
            //        departmentName = department.Name;
            //    }
            //}
            //if (costcenterID != 0)
            //{
            //    var costcenter = costcenterRepo.GetCostCenterById(costcenterID);
            //    if (costcenter != null)
            //    {
            //        costcenterName = costcenter.Name;
            //    }
            //}

            //AccessCorrectionLog accessLogDto = null;
            //List<AccessCorrectionLog> accessLogsDto = new List<AccessCorrectionLog>();


            //if(viewVisitorBookingsOnly == false)
            //{
            //    if (personalNumber > 0)
            //    {
            //        allPersonel = visittorpresentLogRepo.GetAllVisitorWithoutLogs().Where(x => x.Active == true && x.Pers_Nr == personalNumber).ToList();
            //    }
            //    else
            //    {
            //        allPersonel = visittorpresentLogRepo.GetAllVisitorWithoutLogs().Where(x => x.Active == true).ToList();
            //    }

            //    if (clientName != string.Empty)
            //    {
            //        allPersonel = allPersonel.Where(x => x.ClientName == clientName).ToList(); ;
            //    }

            //    if (locationName != string.Empty)
            //    {
            //        allPersonel = allPersonel.Where(x => x.LocationName == locationName).ToList(); ;
            //    }

            //    if (departmentName != string.Empty)
            //    {
            //        allPersonel = allPersonel.Where(x => x.DepartmentName == departmentName).ToList(); ;
            //    }

            //    if (costcenterName != string.Empty)
            //    {
            //        allPersonel = allPersonel.Where(x => x.CostCenterName == costcenterName).ToList(); ;
            //    }
            //}

            //var alllogs = visittorpresentLogRepo.GetAllTodayVisitorLogs().OrderBy(x => x.BookingTime).Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1)).OrderBy(y => y.BookingTime).ToList();
            //var allVisitorLogs = visittorpresentLogRepo.GetAllTodayVisitorEntryLogs().OrderBy(x=> x.BookingTime).Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1)).OrderBy(y => y.BookingTime).ToList();

            //foreach (var personell in allPersonel)
            //{
            //    accessLogDto = null;
            //    var firstKommtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
            //    var lastGehtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

            //    if(firstKommtBooking != null)
            //    {
            //        accessLogDto = new AccessCorrectionLog();

            //        accessLogDto.ID = Convert.ToInt64(firstKommtBooking.ID);
            //        accessLogDto.LogPersType = 1;

            //        accessLogDto.Name = firstKommtBooking.LastName + " " + firstKommtBooking.FirstName;
            //        accessLogDto.PersonalNumber = firstKommtBooking.Pers_Nr;
            //        //visitorLogDto.CardNumber =
            //        accessLogDto.Date = firstKommtBooking.BookingTime;
            //        accessLogDto.Entry = firstKommtBooking.BookingTime;

            //        accessLogDto.Client = personell.ClientName;
            //        accessLogDto.Location = personell.LocationName;
            //        accessLogDto.Department = personell.DepartmentName;
            //        accessLogDto.CostCenter = personell.CostCenterName;
            //        accessLogDto.BookingStatus = 2;
            //    }

            //    if (lastGehtBooking != null)
            //    {
            //        //visitorLogDto = new AccessCorrectionLog();

            //        accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);

            //        accessLogDto.Name = lastGehtBooking.LastName + " " + lastGehtBooking.FirstName;
            //        accessLogDto.PersonalNumber = lastGehtBooking.Pers_Nr;
            //        //visitorLogDto.CardNumber =
            //        accessLogDto.Date = lastGehtBooking.BookingTime;
            //        accessLogDto.Exit = lastGehtBooking.BookingTime;

            //        accessLogDto.Client = personell.ClientName;
            //        accessLogDto.Location = personell.LocationName;
            //        accessLogDto.Department = personell.DepartmentName;
            //        accessLogDto.CostCenter = personell.CostCenterName;

            //        var duration = lastGehtBooking.BookingTime - firstKommtBooking.BookingTime;
            //        accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
            //    }


            //    if (accessLogDto != null)
            //    {
            //        _analyseBookingStatus(accessLogDto);
            //        accessLogsDto.Add(accessLogDto);
            //    }
            //}

            //if(viewErrorBookingsOnly)
            //{
            //    accessLogsDto = accessLogsDto.Where(x => x.BookingStatus == (int)personalBookingStatus.bookingOK).ToList();
            //}

            //List<AccessCorrectionLog> visitorLogsDto = new List<AccessCorrectionLog>();

            //VisitorRepository visitorRepo = new VisitorRepository();

            //var visitorIDS = allVisitorLogs.Select(x => x.VisitorID).Distinct();

            //foreach(long visitorID in visitorIDS)
            //{
            //    accessLogDto = null;
            //    var firstKommtBooking = allVisitorLogs.Where(x => x.VisitorID == visitorID && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
            //    var lastGehtBooking = allVisitorLogs.Where(x => x.VisitorID == visitorID && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

            //    var visitorData = visitorRepo.GetAllVisitors().Where(x => x.VisitorID == visitorID).FirstOrDefault();

            //    if (firstKommtBooking != null)
            //    {
            //        accessLogDto = new AccessCorrectionLog();

            //        accessLogDto.ID = accessLogsDto.Count() + visitorLogsDto.Count() + 1; // Convert.ToInt64(firstKommtBooking.ID);
            //        accessLogDto.LogPersType = 2;
            //        accessLogDto.Name = visitorData.SurName + " " + visitorData.Fullname;
            //        accessLogDto.PersonalNumber = firstKommtBooking.VisitorID;
            //        //accessLogDto.CardNumber =
            //        accessLogDto.Date = firstKommtBooking.BookingTime;
            //        accessLogDto.Entry = firstKommtBooking.BookingTime;

            //        //accessLogDto.Client = personell.ClientName;
            //        //accessLogDto.Location = personell.LocationName;
            //        //accessLogDto.Department = personell.DepartmentName;
            //        //accessLogDto.CostCenter = personell.CostCenterName;
            //        accessLogDto.BookingStatus = 2;
            //    }

            //    if (lastGehtBooking != null)
            //    {
            //        //visitorLogDto = new AccessCorrectionLog();

            //        //accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);

            //        accessLogDto.Name = visitorData.SurName + " " + visitorData.Fullname;
            //        accessLogDto.PersonalNumber = lastGehtBooking.VisitorID;
            //        //visitorLogDto.CardNumber =
            //        accessLogDto.Date = lastGehtBooking.BookingTime;
            //        accessLogDto.Exit = lastGehtBooking.BookingTime;

            //        //accessLogDto.Client = personell.ClientName;
            //        //accessLogDto.Location = personell.LocationName;
            //        //accessLogDto.Department = personell.DepartmentName;
            //        //accessLogDto.CostCenter = personell.CostCenterName;

            //        var duration = lastGehtBooking.BookingTime - firstKommtBooking.BookingTime;
            //        accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
            //    }

            //    if (accessLogDto != null)
            //    {
            //        _analyseVisitorBookingStatus(accessLogDto);
            //        visitorLogsDto.Add(accessLogDto);
            //    }
            //}
            #endregion

            int y = 0;
            foreach (var x in accessLogsDto)
            {
                y = ++y;
                x.ID = y;
            }

            grdAccessCorrection.DataSource = accessLogsDto;
            grdAccessCorrection.DataBind();

            if (accessLogsDto.Count < 24)
            {
                grdAccessCorrection.SettingsPager.Mode = GridViewPagerMode.ShowPager;
                grdAccessCorrection.SettingsPager.PageSize = 24;
            }
            else
            {
                grdAccessCorrection.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords; ;
                grdAccessCorrection.SettingsPager.PageSize = accessLogsDto.Count;
            }
        }

        private void _bindAllFilterDropDoanLists()
        {
            //Clients
            var clientsed = new ClientsRepository().GetClients();
            List<Client> Clients = new List<Client>();
            Client Client = new Client() { ID = 0, Client_Nr = 0, Name = "keine" };
            Client.Name = "Alle";
            Clients.Add(Client);
            //Client = new Client() { ID = -1, Client_Nr = 0, Name = "Alle" };
            //Clients.Add(Client);
            Clients.AddRange(clientsed);

            //Clients[0].Name

            dplClients.DataSource = Clients;
            dplClients.DataBind();
            //dplClients.SelectedIndex = 0;

            //Location
            LocationRepository _LocationRepository = new LocationRepository();

            var locList = _LocationRepository.GetLocations().Where(x => x.Name != "keine");


            List<Location> Locations = new List<Location>();
            Location Location = new Location() { ID = 0, Name = "keine" };
            Location.Name = "Alle";
            Locations.Add(Location);
            Locations.AddRange(locList);
            dplLocation.DataSource = Locations;
            dplLocation.DataBind();
            //dplLocation.SelectedIndex = 0;

            //Location = new Location() { ID = -1, Name = " Alle" };
            //Locations.Insert(1, Location);
            dplLocation.DataSource = Locations;
            dplLocation.DataBind();
            //dplLocation.SelectedIndex = 0;

            //Departments
            DepartmentRepository _DepartmentRepository = new DepartmentRepository();

            var departments = _DepartmentRepository.GetDepartments().Where(x => x.Name != "keine");

            List<Department> Departments = new List<Department>();
            Department Department = new Department() { ID = 0, Department_Nr = 0, Name = "keine" };
            Department.Name = "Alle";
            Departments.Add(Department);

            Departments.AddRange(departments);
            dplDepartment.DataSource = Departments;
            dplDepartment.DataBind();
            //dplDepartment.SelectedIndex = 0;

            //Department = new Department() { ID = -1, Department_Nr = 0, Name = "Alle" };
            //Departments.Insert(1, Department);
            dplDepartment.DataSource = Departments;
            dplDepartment.DataBind();
            //dplDepartment.SelectedIndex = 0;

            //CostCenters
            CostCenterRepository _CostCenterRepository = new CostCenterRepository();
            List<KruAll.Core.Models.CostCenter> listCostCenter = new List<KruAll.Core.Models.CostCenter>();
            var costCenters = _CostCenterRepository.GetCostCenters().Where(x => x.Name != "keine");
            KruAll.Core.Models.CostCenter _costCenter = new KruAll.Core.Models.CostCenter() { ID = 0, Name = "Keine", CostCenter_Nr = 0 };
            _costCenter.Name = "Alle";
            listCostCenter.Add(_costCenter);
            listCostCenter.AddRange(costCenters);
            //ddlCostCenter.DataSource = listCostCenter;
            ////ddlCostCenter.DataValueField = "ID";
            ////ddlCostCenter.DataTextField = "Name";
            //ddlCostCenter.DataBind();

            //ddlCostCenter.Items.Insert(0, new ListItem("keine", "0"));
            //ddlCostCenter.SelectedIndex = 0;

            dplCostCenter.DataSource = listCostCenter;
            dplCostCenter.DataBind();
            //dplCostCenter.SelectedIndex = 0;

            //Personal
            var persList = new PersonnelViewModel().GetALLPersonnel();

            List<PersonnelDto> Personnels = new List<PersonnelDto>();
            //PersonnelDto Personnel = new PersonnelDto() { Pers_Nr = 0, FirstName = "keine", LastName  = ""};
            //Personnels.Add(Personnel);
            Personnels.AddRange(persList);
            dplPersonalName.DataSource = Personnels;
            dplPersonalName.DataBind();
            dplPersonalNumber.DataSource = Personnels;
            dplPersonalNumber.DataBind();
            dplCardNumber.DataSource = Personnels;
            dplCardNumber.DataBind();

            if (!Page.IsPostBack)
            {
                dplClients.SelectedIndex = 0;
                dplLocation.SelectedIndex = 0;
                dplDepartment.SelectedIndex = 0;
                dplCostCenter.SelectedIndex = 0;

                dplPersonalName.SelectedIndex = 0;
                dplPersonalNumber.SelectedIndex = 0;
                dplCardNumber.SelectedIndex = 0;
            }
        }

        public DataTable BindStatus()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Status");
            dt.Columns.Add("StatusNr");

            DataRow dr = dt.NewRow();
            dr["Status"] = "K";
            dr["StatusNr"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Status"] = "G";
            dr["StatusNr"] = 2;
            dt.Rows.Add(dr);

            return dt;
        }

        //private void getAndFilllogsToTheGrid()
        //{
        //    List<MV_AccessControlLogs> accessControlLogs = null;
        //    List<AccessCorrectionLog> accessCorrectionLogs = new List<AccessCorrectionLog>();
        //    List<AccessControlEmployee> accessControlEmployees = new List<AccessControlEmployee>();
        //    List<AccessEmployeeLocation> employeeLocations = new List<AccessEmployeeLocation>();
        //    List<AccessEmployeeDepartment> employeeDepartments = new List<AccessEmployeeDepartment>();
        //    AccessEmployeeLocation employeeLocation = null;
        //    AccessEmployeeDepartment employeeDepartment = null;
        //    AccessCorrectionLog accessCorrectionLog = null;
        //    AccessControlEmployee accessControlEmployee = null;
        //    List<long> employeeNumbers = new List<long>();
        //    List<string> locationNames = new List<string>();
        //    List<string> departmentNames = new List<string>();

        //    List<string> BuildingLocations = new List<string>();
        //    List<string> Buildings = new List<string>();
        //    List<string> BuildingFloors = new List<string>();
        //    List<string> BuildingRooms = new List<string>();
        //    List<string> BuildingDoors = new List<string>();

        //    bool rebindDropdownLists = false;


        //    if (_accessControlCorrectionLogs == null)
        //    {
        //        rebindDropdownLists = true;
        //        _accessControlCorrectionLogs = accessControlViewModel.GetAllLogs();
        //        //_accessControlCorrectionLogs = accessControlLogs;

        //        accessControlEmployee = new AccessControlEmployee();
        //        accessControlEmployee.Name = "Keine";
        //        accessControlEmployee.CardNumber = "Keine";
        //        accessControlEmployee.EmployeeNumber = "Keine";
        //        accessControlEmployees.Add(accessControlEmployee);

        //        employeeLocation = new AccessEmployeeLocation();
        //        employeeDepartment = new AccessEmployeeDepartment();

        //        employeeLocation.LocationName = "Keine";
        //        employeeDepartment.DepartmentName = "Keine";

        //        employeeLocations.Add(employeeLocation);
        //        employeeDepartments.Add(employeeDepartment);

        //        BuildingLocations.Add("Keine");
        //        BuildingFloors.Add("Keine");
        //        BuildingRooms.Add("Keine");
        //        Buildings.Add("Keine");
        //    }


        //    foreach (MV_AccessControlLogs accessControlog in _accessControlCorrectionLogs)
        //    {
        //        accessCorrectionLog = new AccessCorrectionLog();
        //        accessControlEmployee = new AccessControlEmployee();



        //        accessCorrectionLog.Name = accessControlog.Name;
        //        accessCorrectionLog.PersonelNumber = Convert.ToInt64(accessControlog.Pers_Nr);
        //        accessCorrectionLog.CardNumber = accessControlog.Card_Nr;
        //        accessCorrectionLog.LatestBooking = accessControlog.AccessTime;
        //        accessCorrectionLog.Date = accessControlog.AccessTime;
        //        accessCorrectionLog.Time = accessControlog.AccessTime;

        //        accessControlEmployee.Name = accessControlog.Name;
        //        accessControlEmployee.CardNumber = Convert.ToString(accessControlog.Card_Nr);
        //        accessControlEmployee.EmployeeNumber = Convert.ToString(accessControlog.Pers_Nr);

        //        JObject jsonPlan = JObject.Parse(accessControlog.PlanDefinition);
        //        Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(accessControlog.PlanDefinition.ToString());
        //        var nodeData = buildingPlan["model"]["nodeDataArray"];

        //        List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
        //        BuildingPlanDto node = new BuildingPlanDto();

        //        // location name
        //        node = nodeArray.Where(x => x.Key == Convert.ToString(accessControlog.LocationID)).FirstOrDefault();
        //        accessCorrectionLog.Location = node.text;
        //        //building name
        //        node = nodeArray.Where(x => x.Key == Convert.ToString(accessControlog.BuildingID)).FirstOrDefault();
        //        accessCorrectionLog.Building = node.text;
        //        //floor Name
        //        node = nodeArray.Where(x => x.Key == Convert.ToString(accessControlog.FloorID)).FirstOrDefault();
        //        accessCorrectionLog.Floor = node.text;
        //        // room name
        //        node = nodeArray.Where(x => x.Key == Convert.ToString(accessControlog.RoomID)).FirstOrDefault();
        //        accessCorrectionLog.Room = node.text;
        //        // door name
        //        node = nodeArray.Where(x => x.Key == Convert.ToString(accessControlog.DoorID)).FirstOrDefault();
        //        accessCorrectionLog.Door = node.text;

        //        accessCorrectionLogs.Add(accessCorrectionLog);

        //        if (BuildingLocations.Contains(accessCorrectionLog.Location) == false)
        //        {
        //            BuildingLocations.Add(accessCorrectionLog.Location);
        //        }

        //        if (Buildings.Contains(accessCorrectionLog.Building) == false)
        //        {
        //            Buildings.Add(accessCorrectionLog.Building);
        //        }

        //        if (BuildingFloors.Contains(accessCorrectionLog.Floor) == false)
        //        {
        //            BuildingFloors.Add(accessCorrectionLog.Floor);
        //        }

        //        if (BuildingRooms.Contains(accessCorrectionLog.Room) == false)
        //        {
        //            BuildingRooms.Add(accessCorrectionLog.Room);
        //        }

        //        if (BuildingDoors.Contains(accessCorrectionLog.Door) == false)
        //        {
        //            BuildingDoors.Add(accessCorrectionLog.Door);
        //        }


        //        if (locationNames.Contains(accessControlog.LocationName) == false)
        //        {
        //            locationNames.Add(accessControlog.LocationName);
        //            employeeLocation = new AccessEmployeeLocation();
        //            employeeLocation.LocationName = accessControlog.LocationName;
        //            employeeLocations.Add(employeeLocation);
        //        }

        //        if (departmentNames.Contains(accessControlog.DepartmentName) == false)
        //        {
        //            departmentNames.Add(accessControlog.DepartmentName);
        //            employeeDepartment = new AccessEmployeeDepartment();
        //            employeeDepartment.DepartmentName = accessControlog.DepartmentName;
        //            employeeDepartments.Add(employeeDepartment);
        //        }

        //        if (employeeNumbers.Contains(accessControlog.Pers_Nr) == false)
        //        {
        //            employeeNumbers.Add(accessControlog.Pers_Nr);
        //            accessControlEmployees.Add(accessControlEmployee);
        //        }

        //    }

        //    ASPxGridView1.DataSource = accessCorrectionLogs;
        //    ASPxGridView1.DataBind();


        //    if (rebindDropdownLists)
        //    {
        //        ddlEmployeeName.DataSource = accessControlEmployees;
        //        ddlEmployeeName.DataBind();

        //        ddlEmployeeNumber.DataSource = accessControlEmployees;
        //        ddlEmployeeNumber.DataBind();

        //        ddlEmployeeCardNumber.DataSource = accessControlEmployees;
        //        ddlEmployeeCardNumber.DataBind();

        //        ddlEmployeeLocation.DataSource = employeeLocations;
        //        ddlEmployeeLocation.DataBind();

        //        ddlEmployeeDepartment.DataSource = employeeDepartments;
        //        ddlEmployeeDepartment.DataBind();


        //        ddlBuildingLocations.DataSource = BuildingLocations;
        //        ddlBuildingLocations.DataBind();

        //        ddlBuildings.DataSource = Buildings;
        //        ddlBuildings.DataBind();

        //        ddlBuildingFloors.DataSource = BuildingFloors;
        //        ddlBuildingFloors.DataBind();

        //        ddlBuildingRooms.DataSource = BuildingRooms;
        //        ddlBuildingRooms.DataBind();
        //    }
        //}

        protected void ddlEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlEmployeeName.SelectedValue;
            selectDropDownIndex(ddlEmployeeName.SelectedIndex);
            ///*getAndFilllogsToTheGrid*/();
            removeAllFilters();

            if (ddlEmployeeName.SelectedIndex > 0)
            {
                ((GridViewDataColumn)ASPxGridView1.Columns["Name"]).AutoFilterBy(selectedValue);
            }
        }

        protected void ddlEmployeeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlEmployeeNumber.SelectedValue;
            selectDropDownIndex(ddlEmployeeNumber.SelectedIndex);
            //getAndFilllogsToTheGrid();
            removeAllFilters();

            if (ddlEmployeeNumber.SelectedIndex > 0)
            {
                ((GridViewDataColumn)ASPxGridView1.Columns["PersonelNumber"]).AutoFilterBy(selectedValue);
            }
        }

        protected void ddlEmployeeCardNumber_SelectedIndexChanged(object sender, EventArgs e)
        {


            string selectedValue = ddlEmployeeCardNumber.SelectedValue;
            selectDropDownIndex(ddlEmployeeCardNumber.SelectedIndex);
            //getAndFilllogsToTheGrid();
            removeAllFilters();

            if (ddlEmployeeCardNumber.SelectedIndex > 0)
            {
                ((GridViewDataColumn)ASPxGridView1.Columns["CardNumber"]).AutoFilterBy(selectedValue);
            }
        }

        private void selectDropDownIndex(int currentIndex)
        {
            ddlEmployeeName.SelectedIndex = currentIndex;
            ddlEmployeeNumber.SelectedIndex = currentIndex;
            ddlEmployeeCardNumber.SelectedIndex = currentIndex;
        }

        protected void ddlEmployeeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEmployeeDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void removeAllFilters()
        {
            ((GridViewDataColumn)ASPxGridView1.Columns["Name"]).AutoFilterBy(string.Empty);
            ((GridViewDataColumn)ASPxGridView1.Columns["PersonelNumber"]).AutoFilterBy(string.Empty);
            ((GridViewDataColumn)ASPxGridView1.Columns["CardNumber"]).AutoFilterBy(string.Empty);
        }

        protected void grdAccessCorrection_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            int bookingStatusValue = 0;
            DateTime cellDate = DateTime.MaxValue;
            var bookingStatus = grdAccessCorrection.GetRowValues(e.VisibleIndex, "BookingStatus");

            if (bookingStatus == null)
            {
                return;
            }

            int.TryParse(bookingStatus.ToString(), out bookingStatusValue);

            switch (e.DataColumn.FieldName)
            {
                case "Exit":
                    DateTime.TryParse(e.CellValue.ToString(), out cellDate);
                    if (cellDate == DateTime.MinValue) { e.Cell.Text = ""; cellDate = DateTime.MaxValue; }
                    switch (bookingStatusValue)
                    {
                        case (int)personalBookingStatus.bookingOK:
                            break;
                        case (int)personalBookingStatus.bookingError:
                            e.Cell.ForeColor = System.Drawing.Color.Red;
                            e.Cell.Font.Underline = true;
                            e.Cell.Style.Add("cursor", "pointer");
                            e.Cell.Attributes.Add("onclick", String.Format("OnCellClick(this, \"{0}\", {1});", e.CellValue, e.VisibleIndex));
                            //e.Cell.Font.Bold = true;
                            break;
                        case (int)personalBookingStatus.bookingCorrected:
                            break;
                        case (int)personalBookingStatus.noBooking:
                            //e.Cell.ForeColor = System.Drawing.Color.Orange;
                            break;
                    }

                    break;
                case "Entry":
                    DateTime.TryParse(e.CellValue.ToString(), out cellDate);
                    if (cellDate == DateTime.MinValue) { e.Cell.Text = ""; cellDate = DateTime.MaxValue; }
                    switch (bookingStatusValue)
                    {
                        case (int)personalBookingStatus.bookingOK:
                            break;
                        case (int)personalBookingStatus.bookingError:
                            e.Cell.ForeColor = System.Drawing.Color.Red;
                            e.Cell.Font.Underline = true;
                            e.Cell.Style.Add("cursor", "pointer");
                            e.Cell.Attributes.Add("onclick", String.Format("OnCellClick(this, \"{0}\", {1});", e.CellValue, e.VisibleIndex));
                            //e.Cell.Font.Bold = true;
                            break;
                        case (int)personalBookingStatus.bookingCorrected:
                            break;
                        case (int)personalBookingStatus.noBooking:
                            //e.Cell.ForeColor = System.Drawing.Color.Orange;
                            break;
                    }
                    break;
                case "Memo":
                    switch (bookingStatusValue)
                    {
                        case (int)personalBookingStatus.bookingOK:
                            e.Cell.ForeColor = System.Drawing.Color.Green;
                            //e.Cell.Font.Bold = true;
                            break;
                        case (int)personalBookingStatus.bookingError:
                            e.Cell.ForeColor = System.Drawing.Color.Red;
                            //e.Cell.Font.Bold = true;
                            break;
                        case (int)personalBookingStatus.bookingCorrected:
                            e.Cell.ForeColor = System.Drawing.Color.RoyalBlue;
                            //e.Cell.Font.Bold = true;
                            break;
                        case (int)personalBookingStatus.noBooking:
                            //e.Cell.ForeColor = System.Drawing.Color.Orange;
                            e.Cell.Text = "Keine Buchungs";
                            break;
                    }
                    break;
                case "Correction2":
                    switch (bookingStatusValue)
                    {
                        case (int)personalBookingStatus.bookingOK:
                            e.Cell.Text = "";
                            //DateTime.TryParse(e.CellValue.ToString(), out cellDate);
                            //if (cellDate == DateTime.MinValue) { e.Cell.Text = ""; cellDate = DateTime.MaxValue; }
                            break;
                        case (int)personalBookingStatus.bookingError:
                            e.Cell.Text = "";
                            //DateTime.TryParse(e.CellValue.ToString(), out cellDate);
                            //if (cellDate == DateTime.MinValue) { e.Cell.Text = ""; cellDate = DateTime.MaxValue; }
                            break;
                        //case (int)personalBookingStatus.bookingCorrected:
                        //    e.Cell.ForeColor = System.Drawing.Color.RoyalBlue;
                        //    //e.Cell.Font.Bold = true;
                        //    break;
                        case (int)personalBookingStatus.noBooking:
                            break;
                    }
                    break;
            }

        }

        private void _analyseVisitorBookingStatus(AccessCorrectionLog personalAccessLog)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();

            if (personalAccessLog.PersonalNumber > 0)
            {

                bookingCorrections = _getVisitorBookingCorrections(personalAccessLog.PersonalNumber);


                personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingOK;
                personalAccessLog.Memo = "Buchung OK";

                foreach (var corretionBooking in bookingCorrections)
                {
                    if (corretionBooking.GehtBooking == null || corretionBooking.KommtBooking == null)
                    {
                        personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingError;
                        personalAccessLog.Memo = "Fehler";
                    }
                }

                if (bookingCorrections.Where(x => x.BookingStatus == 3).FirstOrDefault() != null && personalAccessLog.BookingStatus != (int)personalBookingStatus.bookingError)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingCorrected;
                    personalAccessLog.Memo = "Korrigiert";
                }


            }
        }

        private void _analyseBookingStatus(AccessCorrectionLog personalAccessLog)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();

            if (personalAccessLog.PersonalNumber > 0)
            {

                bookingCorrections = _getPersonalBookingCorrections(personalAccessLog.PersonalNumber);


                personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingOK;
                personalAccessLog.Memo = "Buchung OK";

                foreach (var corretionBooking in bookingCorrections)
                {
                    if (corretionBooking.GehtBooking == null || corretionBooking.KommtBooking == null)
                    {
                        personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingError;
                        personalAccessLog.Memo = "Fehler";
                    }
                }

                if (bookingCorrections.Where(x => x.BookingStatus == 3).FirstOrDefault() != null && personalAccessLog.BookingStatus != (int)personalBookingStatus.bookingError)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingCorrected;
                    personalAccessLog.Memo = "Korrigiert";
                }


            }
        }


        private static List<BookingsCorrection2> _getPersonalBookingCorrections(long personalNumber, DateTime bookingDate)
        {
            List<BookingsCorrection2> bookingCorrections = new List<BookingsCorrection2>();
            //BookingsCorrection correctinBooking = null;
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            //bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            //bookingDirection currentBookingStatus = bookingDirection.bookingNONE;

            //int bookingStatus = 0;

            for (int row = 1; row < 5; row++)
            {
                bookingCorrections.Add(new BookingsCorrection2(row));
            }

            if (personalNumber > 0)
            {
                var alllogs = visittorpresentLogRepo.GetAllTodayVisitorLogs().OrderBy(x => x.BookingTime).Where(x =>
                x.BookingTime >= bookingDate && x.BookingTime < bookingDate.AddDays(1) && x.Pers_Nr == personalNumber).OrderBy(y => y.BookingTime).ToList();


                if (alllogs != null && alllogs.Any())
                {
                    int _col = 0, _row = 0;
                    for (int i = 0; i < bookingCorrections.Count * 4; i++)
                    {
                        if (i < alllogs.Count)
                        {
                            _col = i % 4 == 0 ? 1 : ++_col;
                            if (i % 4 == 0 && i > 3) ++_row;
                            View_VisitorAccessLog _log = alllogs[i];
                            PropertyInfo pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Booking{0:0}Id", _col));
                            pi.SetValue(bookingCorrections[_row], _log.LogID);
                            pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Booking{0:0}", _col));
                            pi.SetValue(bookingCorrections[_row], _log.BookingTime);
                            pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Status{0:0}", _col));
                            pi.SetValue(bookingCorrections[_row], _log.TA_Come == 1 ? 1 : 2);
                            pi = bookingCorrections[_row].GetType().GetProperty("PersonalNumber");
                            pi.SetValue(bookingCorrections[_row], personalNumber);
                        }
                    }
                }
            }

            return bookingCorrections;
        }

        private static List<BookingsCorrection> _getPersonalBookingCorrections(long personalNumber)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            BookingsCorrection correctinBooking = null;
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            bookingDirection currentBookingStatus = bookingDirection.bookingNONE;

            int bookingStatus = 0;


            if (personalNumber > 0)
            {
                var alllogs = visittorpresentLogRepo.GetAllTodayVisitorLogs().OrderBy(x => x.BookingTime).Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1) && x.Pers_Nr == personalNumber).OrderBy(y => y.BookingTime).ToList();
                if (alllogs != null && alllogs.Any())
                {
                    int pairIndex = 0;
                    int maxCollectionIndex = alllogs.Count;
                    for (int i = 0; i < maxCollectionIndex; i++)
                    {
                        if (i > 0 && i == pairIndex) continue;
                        BookingsCorrection newBookingCorrectionPair = new BookingsCorrection { PersonalNumber = personalNumber };
                        newBookingCorrectionPair.ID = bookingCorrections.Count + 1;
                        var accLog = alllogs[i];
                        if (Convert.ToBoolean(accLog.TA_Come))
                        {
                            newBookingCorrectionPair.KommtBooking = accLog.BookingTime;
                            int nextIndex = i + 1;
                            if (nextIndex < maxCollectionIndex)
                            {
                                var nextAccLog = alllogs[nextIndex];
                                if (Convert.ToBoolean(nextAccLog.TA_Go))
                                {
                                    newBookingCorrectionPair.GehtBooking = nextAccLog.BookingTime;
                                    pairIndex = nextIndex;
                                }
                                else
                                {
                                    pairIndex++;
                                }
                            }
                            else
                            {
                                pairIndex++;
                            }

                        }
                        else if (Convert.ToBoolean(accLog.TA_Go))
                        {
                            newBookingCorrectionPair.GehtBooking = accLog.BookingTime;
                            pairIndex++;

                        }
                        else
                        {
                            pairIndex++;
                        }
                        bookingCorrections.Add(newBookingCorrectionPair);
                    }
                    return bookingCorrections;

                }

                foreach (var bookingLog in alllogs)
                {
                    if (bookingLog.BookingCorrection == 1)
                    {
                        bookingStatus = 3;
                    }
                    else
                    {
                        bookingStatus = 1;
                    }

                    currentBookingStatus = bookingDirection.bookingNONE;

                    if (Convert.ToBoolean(bookingLog.TA_Come))
                    {
                        currentBookingStatus = bookingDirection.bookingCOME;
                    }

                    if (Convert.ToBoolean(bookingLog.TA_Go))
                    {
                        currentBookingStatus = bookingDirection.bookingGO;
                    }

                    switch (lastBookingStatus)
                    {
                        case bookingDirection.bookingNONE:
                            correctinBooking = new BookingsCorrection();
                            correctinBooking.ID = bookingCorrections.Count + 1;
                            correctinBooking.PersonalNumber = personalNumber;
                            bookingCorrections.Add(correctinBooking);

                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    lastBookingStatus = bookingDirection.bookingCOME;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    lastBookingStatus = bookingDirection.bookingGO;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingCOME:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = personalNumber;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingGO:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = personalNumber;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = personalNumber;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                    }
                }
            }
            return bookingCorrections;
        }

        private static List<BookingsCorrection2> _getVisitorBookingCorrections(long visitorID, DateTime bookingDate)
        {
            List<BookingsCorrection2> bookingCorrections = new List<BookingsCorrection2>();
            //BookingsCorrection correctinBooking = null;
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            //bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            //bookingDirection currentBookingStatus = bookingDirection.bookingNONE;

            //int bookingStatus = 0;

            for (int row = 1; row < 5; row++)
            {
                bookingCorrections.Add(new BookingsCorrection2(row));
            }

            if (visitorID > 0)
            {
                var alllogs = visittorpresentLogRepo.GetAllTodayVisitorEntryLogs().OrderBy(x => x.BookingTime).Where(x =>
                x.BookingTime > bookingDate && x.BookingTime < bookingDate.AddDays(1) && x.VisitorID == visitorID).OrderBy(y => y.BookingTime).ToList();
                //var alllogs = visittorpresentLogRepo.GetAllTodayVisitorLogs().OrderBy(x => x.BookingTime).Where(x =>
                //x.BookingTime > bookingDate && x.BookingTime < bookingDate.AddDays(1) && x.Pers_Nr == personalNumber).OrderBy(y => y.BookingTime).ToList();


                if (alllogs != null && alllogs.Any())
                {
                    int _col = 0, _row = 0;
                    for (int i = 0; i < bookingCorrections.Count * 4; i++)
                    {
                        if (i < alllogs.Count)
                        {
                            _col = i % 4 == 0 ? 1 : ++_col;
                            if (i % 4 == 0 && i > 3) ++_row;
                            View_VisitorEntryLog _log = alllogs[i];
                            PropertyInfo pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Booking{0:0}Id", _col));
                            pi.SetValue(bookingCorrections[_row], _log.LogId);
                            pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Booking{0:0}", _col));
                            pi.SetValue(bookingCorrections[_row], _log.BookingTime);
                            pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Status{0:0}", _col));
                            pi.SetValue(bookingCorrections[_row], _log.TA_Come == 1 ? 1 : 2);
                            pi = bookingCorrections[_row].GetType().GetProperty("PersonalNumber");
                            pi.SetValue(bookingCorrections[_row], visitorID);
                        }
                    }
                }
            }

            return bookingCorrections;
        }

        private static List<BookingsCorrection2> _getMemberBookingCorrections(long memberNumber, DateTime bookingDate)
        {
            List<BookingsCorrection2> bookingCorrections = new List<BookingsCorrection2>();
            //BookingsCorrection correctinBooking = null;
            View_MemberAccessLogRepositoy memberAccessLogRepo = new View_MemberAccessLogRepositoy();
            //bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            //bookingDirection currentBookingStatus = bookingDirection.bookingNONE;

            //int bookingStatus = 0;

            for (int row = 1; row < 5; row++)
            {
                bookingCorrections.Add(new BookingsCorrection2(row));
            }

            if (memberNumber > 0)
            {
                var alllogs = memberAccessLogRepo.GetAllView_MemberAccessLog().OrderBy(x => x.BookingTime).Where(x =>
                x.BookingTime > bookingDate && x.BookingTime < bookingDate.AddDays(1) && x.MemberNumber == memberNumber).OrderBy(y => y.BookingTime).ToList();
                //var alllogs = visittorpresentLogRepo.GetAllTodayVisitorLogs().OrderBy(x => x.BookingTime).Where(x =>
                //x.BookingTime > bookingDate && x.BookingTime < bookingDate.AddDays(1) && x.Pers_Nr == personalNumber).OrderBy(y => y.BookingTime).ToList();


                if (alllogs != null && alllogs.Any())
                {
                    int _col = 0, _row = 0;
                    for (int i = 0; i < bookingCorrections.Count * 4; i++)
                    {
                        if (i < alllogs.Count)
                        {
                            _col = i % 4 == 0 ? 1 : ++_col;
                            if (i % 4 == 0 && i > 3) ++_row;
                            View_MemberAccessLog _log = alllogs[i];
                            PropertyInfo pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Booking{0:0}Id", _col));
                            pi.SetValue(bookingCorrections[_row], _log.LogID);
                            pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Booking{0:0}", _col));
                            pi.SetValue(bookingCorrections[_row], _log.BookingTime);
                            pi = bookingCorrections[_row].GetType().GetProperty(string.Format("Status{0:0}", _col));
                            pi.SetValue(bookingCorrections[_row], _log.TA_Come == 1 ? 1 : 2);
                            pi = bookingCorrections[_row].GetType().GetProperty("PersonalNumber");
                            pi.SetValue(bookingCorrections[_row], memberNumber);
                        }
                    }
                }
            }

            return bookingCorrections;
        }

        private static List<BookingsCorrection> _getVisitorBookingCorrections(long visitorID)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            BookingsCorrection correctinBooking = null;
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            bookingDirection currentBookingStatus = bookingDirection.bookingNONE;

            int bookingStatus = 0;


            if (visitorID > 0)
            {
                var alllogs = visittorpresentLogRepo.GetAllTodayVisitorEntryLogs().OrderBy(x => x.BookingTime).Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1) && x.VisitorID == visitorID).OrderBy(y => y.BookingTime).ToList();
                if (alllogs != null && alllogs.Any())
                {
                    int pairIndex = 0;
                    int maxCollectionIndex = alllogs.Count;
                    for (int i = 0; i < maxCollectionIndex; i++)
                    {
                        if (i > 0 && i == pairIndex) continue;
                        BookingsCorrection newBookingCorrectionPair = new BookingsCorrection { PersonalNumber = visitorID };
                        newBookingCorrectionPair.ID = bookingCorrections.Count + 1;
                        var accLog = alllogs[i];
                        if (Convert.ToBoolean(accLog.TA_Come))
                        {
                            newBookingCorrectionPair.KommtBooking = accLog.BookingTime;
                            int nextIndex = i + 1;
                            if (nextIndex < maxCollectionIndex)
                            {
                                var nextAccLog = alllogs[nextIndex];
                                if (Convert.ToBoolean(nextAccLog.TA_Go))
                                {
                                    newBookingCorrectionPair.GehtBooking = nextAccLog.BookingTime;
                                    pairIndex = nextIndex;
                                }
                                else
                                {
                                    pairIndex++;
                                }
                            }
                            else
                            {
                                pairIndex++;
                            }

                        }
                        else if (Convert.ToBoolean(accLog.TA_Go))
                        {
                            newBookingCorrectionPair.GehtBooking = accLog.BookingTime;
                            pairIndex++;

                        }
                        else
                        {
                            pairIndex++;
                        }
                        bookingCorrections.Add(newBookingCorrectionPair);
                    }
                    return bookingCorrections;

                }
                foreach (var bookingLog in alllogs)
                {
                    if (bookingLog.BookingCorrection == 1)
                    {
                        bookingStatus = 3;
                    }
                    else
                    {
                        bookingStatus = 1;
                    }

                    currentBookingStatus = bookingDirection.bookingNONE;

                    if (Convert.ToBoolean(bookingLog.TA_Come))
                    {
                        currentBookingStatus = bookingDirection.bookingCOME;
                    }

                    if (Convert.ToBoolean(bookingLog.TA_Go))
                    {
                        currentBookingStatus = bookingDirection.bookingGO;
                    }

                    switch (lastBookingStatus)
                    {
                        case bookingDirection.bookingNONE:
                            correctinBooking = new BookingsCorrection();
                            correctinBooking.ID = bookingCorrections.Count + 1;
                            correctinBooking.PersonalNumber = visitorID;
                            bookingCorrections.Add(correctinBooking);

                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    lastBookingStatus = bookingDirection.bookingCOME;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    lastBookingStatus = bookingDirection.bookingGO;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingCOME:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = visitorID;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingGO:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = visitorID;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = visitorID;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                    }
                }
            }
            return bookingCorrections;
        }

        //protected void grdBookingsCorrection_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        //{
        //    List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
        //    long personalNumber = 0;
        //    int logPersType = 0;

        //    long.TryParse(e.Parameters.Split(';')[0], out personalNumber);
        //    int.TryParse(e.Parameters.Split(';')[1], out logPersType);

        //    _logpersonalType = logPersType;
        //    if (personalNumber > 0 && logPersType == 1)
        //    {
        //        _personalNumberStatic = personalNumber;
        //        bookingCorrections = _getPersonalBookingCorrections(personalNumber);
        //    }

        //    if (personalNumber > 0 && logPersType == 2)
        //    {
        //        _personalNumberStatic = personalNumber;
        //        bookingCorrections = _getVisitorBookingCorrections(personalNumber);
        //    }
        //    //if(bookingCorrections.Count<6)
        //    //{
        //    //    int extras = 6 - bookingCorrections.Count;
        //    //    for(int i=0;i< extras;i++)
        //    //    {
        //    //        bookingCorrections.Add(new BookingsCorrection { ID = -1-i });
        //    //    }
        //    //}
        //    userBbookingCorrections = bookingCorrections;
        //    grdBookingsCorrection.DataSource = bookingCorrections;
        //    grdBookingsCorrection.DataBind();
        //    grdBookingsCorrection.Enabled = true;
        //}

        //protected void grdBookingsCorrection_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        //{
        //    List<ASPxDataUpdateValues> updateValues = e.UpdateValues;

        //    _makepersonalBookingCorrections(updateValues);
        //    e.Handled = true;
        //}

        protected void grdBookingsCorrection_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<BookingsCorrection2> bookingCorrections = new List<BookingsCorrection2>();
            long personalNumber = 0;
            int logPersType = 0;
            string logDate = "";

            long.TryParse(e.Parameters.Split(';')[0], out personalNumber);
            int.TryParse(e.Parameters.Split(';')[1], out logPersType);
            logDate = e.Parameters.Split(';')[2]; DateTime logDateTime;

            _logpersonalType = logPersType;
            if (personalNumber > 0 && logPersType == 1 && DateTime.TryParse(logDate, out logDateTime))
            {
                _personalNumberStatic = personalNumber;
                bookingCorrections = _getPersonalBookingCorrections(personalNumber, logDateTime);
            }

            if (personalNumber > 0 && logPersType == 2 && DateTime.TryParse(logDate, out logDateTime))
            {
                _personalNumberStatic = personalNumber;
                bookingCorrections = _getVisitorBookingCorrections(personalNumber, logDateTime);
            }

            if (personalNumber > 0 && logPersType == 3 && DateTime.TryParse(logDate, out logDateTime))
            {
                _personalNumberStatic = personalNumber;
                bookingCorrections = _getMemberBookingCorrections(personalNumber, logDateTime);
            }


            ////if(bookingCorrections.Count<6)
            ////{
            ////    int extras = 6 - bookingCorrections.Count;
            ////    for(int i=0;i< extras;i++)
            ////    {
            ////        bookingCorrections.Add(new BookingsCorrection { ID = -1-i });
            ////    }
            ////}

            //userBbookingCorrections = bookingCorrections;
            grdBookingsCorrection.DataSource = bookingCorrections;
            grdBookingsCorrection.DataBind();
        }

        private void _makepersonalBookingCorrections(List<ASPxDataUpdateValues> updateValues)
        {
            DateTime dtNewBookingTime = new DateTime();
            bookingDirection newBookingType = bookingDirection.bookingNONE;
            long personalNumber = 0;


            foreach (var updateValue in updateValues)
            {
                var oldValues = updateValue.OldValues;
                var newValues = updateValue.NewValues;

                if (oldValues["KommtBooking"] == null && newValues["KommtBooking"] != null)
                {
                    //personalNumber = Convert.ToInt64(newValues["PersonalNumber"]);
                    dtNewBookingTime = DateTime.Today + Convert.ToDateTime(newValues["KommtBooking"]).TimeOfDay;
                    newBookingType = bookingDirection.bookingCOME;
                    _createBookingInDatabase(personalNumber, dtNewBookingTime, newBookingType);
                }

                if (oldValues["GehtBooking"] == null && newValues["GehtBooking"] != null)
                {
                    //personalNumber = Convert.ToInt64(newValues["PersonalNumber"]);
                    dtNewBookingTime = DateTime.Today + Convert.ToDateTime(newValues["GehtBooking"]).TimeOfDay;
                    newBookingType = bookingDirection.bookingGO;
                    _createBookingInDatabase(personalNumber, dtNewBookingTime, newBookingType);
                }
            }
        }

        private static void _createBookingInDatabase(long personalNumber, DateTime bookingDateTime, bookingDirection bookingType)
        {
            AccessControlLog accesesLog = new AccessControlLog();
            AccessControlBookingRepository bookingsRepo = new AccessControlBookingRepository();



            if (_logpersonalType == 1)
            {
                accesesLog.Pers_Nr = _personalNumberStatic;
            }

            if (_logpersonalType == 2)
            {
                accesesLog.VisitorID = _personalNumberStatic;
            }

            if (_logpersonalType == 3)
            {
                accesesLog.MemberID = _personalNumberStatic;
            }

            accesesLog.AccessTime = bookingDateTime;
            accesesLog.TerminalSerial = "ACOR";
            accesesLog.Status = 0;

            switch (bookingType)
            {
                case bookingDirection.bookingCOME:
                    accesesLog.ReaderID = "2";
                    break;
                case bookingDirection.bookingGO:
                    accesesLog.ReaderID = "1";
                    break;
            }

            bookingsRepo.NewAccessControlBooking(accesesLog);
        }

        protected void grdAccessCorrection_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            long personalNumber = 0;
            int clientID = 0;
            long locationID = 0;
            long departmentID = 0;
            long costcenterID = 0;
            bool viewErrorBookingsOnly = false;
            bool viewVisitorBookingsOnly = false;
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();
            bool includeWithoutBookings = false;


            if (e.Parameters == string.Empty)
            {
                _checkGridColumns();
                _databindAccessLogGrid(DateTime.Today, DateTime.Today, 0, 0, 0, 0, 0, viewErrorBookingsOnly, viewVisitorBookingsOnly, includeWithoutBookings);
            }
            else
            {
                int.TryParse(e.Parameters.Split(';')[0], out clientID);
                long.TryParse(e.Parameters.Split(';')[1], out locationID);
                long.TryParse(e.Parameters.Split(';')[2], out departmentID);
                long.TryParse(e.Parameters.Split(';')[3], out costcenterID);
                long.TryParse(e.Parameters.Split(';')[4], out personalNumber);

                if (e.Parameters.Split(';')[5] != null)
                {
                    viewErrorBookingsOnly = Convert.ToBoolean(e.Parameters.Split(';')[5]);
                }

                if (e.Parameters.Split(';')[6] != null)
                {
                    viewVisitorBookingsOnly = Convert.ToBoolean(e.Parameters.Split(';')[6]);
                }

                if (e.Parameters.Split(';')[7] != null)
                {
                    dateFrom = Convert.ToDateTime(e.Parameters.Split(';')[7]);
                }

                if (e.Parameters.Split(';')[8] != null)
                {
                    dateTo = Convert.ToDateTime(e.Parameters.Split(';')[8]);
                }

                if (e.Parameters.Split(';')[9] != null)
                {
                    includeWithoutBookings = Convert.ToBoolean(e.Parameters.Split(';')[9]);
                }




                _checkGridColumns();
                _databindAccessLogGrid(dateFrom, dateTo, clientID, locationID, departmentID, costcenterID, personalNumber, viewErrorBookingsOnly, viewVisitorBookingsOnly, includeWithoutBookings);
            }

        }



        [WebMethod]
        public static void CorrectBookingsAuomatically(List<long> personalNumbers, string bookingCorrectionTime)
        {
            DateTime dtBookingTime = DateTime.Today;
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            bool errorBookingsFound = false;



            dtBookingTime = Convert.ToDateTime(bookingCorrectionTime);
            dtBookingTime = DateTime.Today + dtBookingTime.TimeOfDay;

            if (dtBookingTime.TimeOfDay == DateTime.Today.TimeOfDay)
            {
                return;
            }

            foreach (long personalNumber in personalNumbers)
            {
                errorBookingsFound = false;
                bookingCorrections = _getPersonalBookingCorrections(personalNumber);

                errorBookingsFound = bookingCorrections.Where(x => x.GehtBooking == null).FirstOrDefault() != null;

                if (errorBookingsFound)
                {
                    _personalNumberStatic = personalNumber;
                    _createBookingInDatabase(personalNumber, dtBookingTime, bookingDirection.bookingGO);
                }
            }
        }

        [WebMethod]
        public static void SaveBookingsCorrections(string PersNr, string JSNString)
        {
            JObject _JSNObj = GetJSONObject(JSNString);
            DateTime logsDate = DateTime.MinValue; long persNr = 0, logID = 0;
            Int64.TryParse(PersNr, out persNr);
            List<AccessControlLog> AccessControlLogsList = new List<AccessControlLog>();
            AccessControlBookingRepository AccessControlBookingRepo = new AccessControlBookingRepository();

            foreach (JProperty correctionDays in _JSNObj.AsQueryable())
            {
                string keyDate = correctionDays.Name;
                DateTime.TryParse(keyDate, out logsDate);

                if (logsDate != DateTime.MinValue && persNr != 0)
                    AccessControlLogsList = AccessControlBookingRepo.GetAllByPersNrAndDate(persNr, logsDate);

                var oldValues = correctionDays.Children()["OldValues"].Children().ToList();
                var newValues = correctionDays.Children()["NewValues"].Children().ToList();

                foreach (JProperty corrections in oldValues)
                {
                    string rowKey = corrections.Name;
                    int currBookingCol = 1, currStatusCol = 2;

                    for (int _col = 0; _col < 4; _col++)
                    {
                        string bookingId = rowKey.Split('#')[_col + 2];
                        Int64.TryParse(bookingId, out logID);
                        string oldBookingTime = corrections.FirstOrDefault()[currBookingCol.ToString()].ToString();
                        string oldBookingStatus = corrections.FirstOrDefault()[currStatusCol.ToString()].ToString();
                        string newBookingTime = _JSNObj[keyDate]["NewValues"][rowKey][currBookingCol.ToString()].ToString();
                        string newBookingStatus = _JSNObj[keyDate]["NewValues"][rowKey][currStatusCol.ToString()].ToString();

                        if ((oldBookingTime != newBookingTime) || (oldBookingStatus != newBookingStatus))
                        {
                            DateTime oldBookingDateTime = DateTime.MinValue, newBookingDateTime = DateTime.MinValue;
                            int oldBookingStatusVal = 0, newBookingStatusVal = 0;
                            DateTime.TryParse(oldBookingTime, out oldBookingDateTime);
                            Int32.TryParse(oldBookingStatus, out oldBookingStatusVal);
                            DateTime.TryParse(newBookingTime, out newBookingDateTime);
                            Int32.TryParse(newBookingStatus, out newBookingStatusVal);
                            if (oldBookingTime.Trim() == "")
                            {
                                if (logsDate != DateTime.MinValue)
                                    CreateNewBooking(persNr, logsDate, newBookingDateTime,
                                        newBookingStatusVal == 1 ? bookingDirection.bookingCOME : bookingDirection.bookingGO);
                            }
                            else if (oldBookingTime.Trim() != "" && newBookingTime.Trim() == "")
                            {
                                if (logsDate != DateTime.MinValue)
                                    DeleteBooking(logID, AccessControlLogsList, ref AccessControlBookingRepo);
                            }
                            else
                            {
                                if (logID != 0)
                                    EditBooking(persNr, logID, AccessControlLogsList, newBookingDateTime,
                                        newBookingStatusVal == 1 ? bookingDirection.bookingCOME : bookingDirection.bookingGO);
                            }
                        }

                        currBookingCol = currBookingCol + 2;
                        currStatusCol = currStatusCol + 2;
                    }
                }
            }
        }

        private static void CreateNewBooking(long personalNumber, DateTime bookingDate, DateTime bookingDateTime, bookingDirection bookingType)
        {
            AccessControlLog accesesLog = new AccessControlLog();

            if (_logpersonalType == 1)
            {
                accesesLog.Pers_Nr = _personalNumberStatic;
            }

            if (_logpersonalType == 2)
            {
                accesesLog.VisitorID = _personalNumberStatic;
            }

            accesesLog.AccessTime = bookingDate.Date.AddHours(bookingDateTime.TimeOfDay.TotalHours);
            accesesLog.TerminalSerial = "ACOR";
            accesesLog.Status = 0;

            switch (bookingType)
            {
                case bookingDirection.bookingCOME:
                    accesesLog.ReaderID = "2";
                    break;
                case bookingDirection.bookingGO:
                    accesesLog.ReaderID = "1";
                    break;
            }

            new AccessControlBookingRepository().NewAccessControlBooking(accesesLog);
        }

        private static void EditBooking(long personalNumber, long bookingId, List<AccessControlLog> accessControlLogsList, DateTime newBooking, bookingDirection bookingType)
        {
            if (accessControlLogsList.Any(x => x.ID == bookingId))
            {
                AccessControlLog accesesLog = accessControlLogsList.FirstOrDefault(x => x.ID == bookingId);

                if (_logpersonalType == 1)
                {
                    accesesLog.Pers_Nr = _personalNumberStatic;
                }

                if (_logpersonalType == 2)
                {
                    accesesLog.VisitorID = _personalNumberStatic;
                }

                accesesLog.AccessTime = newBooking;
                accesesLog.TerminalSerial = "ACOR";
                accesesLog.Status = 0;

                switch (bookingType)
                {
                    case bookingDirection.bookingCOME:
                        accesesLog.ReaderID = "2";
                        break;
                    case bookingDirection.bookingGO:
                        accesesLog.ReaderID = "1";
                        break;
                }

                new AccessControlBookingRepository().EditAccessControlBooking(accesesLog);
            }
        }

        private static void DeleteBooking(long bookingId, List<AccessControlLog> accessControlLogsList, ref AccessControlBookingRepository AccessControlBookingRepo)
        {
            if (accessControlLogsList.Any(x => x.ID == bookingId))
            {
                AccessControlLog accesesLog = accessControlLogsList.FirstOrDefault(x => x.ID == bookingId);
                AccessControlBookingRepo.DeleteAccessControlBooking(accesesLog);
            }
        }

        public static JObject GetJSONObject(string JSONString)
        {
            JObject _JSONObject = new JObject();
            try
            {
                _JSONObject = (JObject)JsonConvert.DeserializeObject(JSONString);
            }
            catch (Exception)
            { return _JSONObject; }

            return _JSONObject;
        }

        private void _bindVisibleCheckboxes()
        {
            bool Client = true, loc = true, dept = true, cost = true, idNo = true, CardNo = true;
            HttpCookie SavedChanges = Request.Cookies["AccessCorrectionColumns"];
            if (SavedChanges != null)
            {
                string valueJSNString = HttpUtility.UrlDecode(SavedChanges.Value);
                dynamic item = JsonConvert.DeserializeObject(valueJSNString);

                Client = Convert.ToBoolean(item[0]["Client"].ToString());
                loc = Convert.ToBoolean(item[0]["Location"].ToString());
                dept = Convert.ToBoolean(item[0]["Depaterment"].ToString());
                cost = Convert.ToBoolean(item[0]["CostCenter"].ToString());
                idNo = Convert.ToBoolean(item[0]["PersonalID"].ToString());
                CardNo = Convert.ToBoolean(item[0]["CardNumber"].ToString());
            }

            chkClient.Checked = Client;
            chkLocation.Checked = loc;
            chkDepartment.Checked = dept;
            chkCostCenter.Checked = cost;
            chkPersonalID.Checked = idNo;
            chkCardNumber.Checked = CardNo;
        }

        private void _checkGridColumns()
        {
            bool Client = true, loc = true, dept = true, cost = true, idNo = true, CardNo = true, Pesronal = true;
            HttpCookie SavedChanges = Request.Cookies["AccessCorrectionColumns"];
            if (SavedChanges != null)
            {
                string valueJSNString = HttpUtility.UrlDecode(SavedChanges.Value);
                dynamic item = JsonConvert.DeserializeObject(valueJSNString);

                Client = Convert.ToBoolean(item[0]["Client"].ToString());
                loc = Convert.ToBoolean(item[0]["Location"].ToString());
                dept = Convert.ToBoolean(item[0]["Depaterment"].ToString());
                cost = Convert.ToBoolean(item[0]["CostCenter"].ToString());
                idNo = Convert.ToBoolean(item[0]["PersonalID"].ToString());
                CardNo = Convert.ToBoolean(item[0]["CardNumber"].ToString());
            }

            grdAccessCorrection.Columns[0].Visible = Client;
            grdAccessCorrection.Columns[1].Visible = loc;
            grdAccessCorrection.Columns[2].Visible = dept;
            grdAccessCorrection.Columns[3].Visible = cost;
            grdAccessCorrection.Columns[5].Visible = idNo;
            grdAccessCorrection.Columns[6].Visible = CardNo;
        }
    }
}