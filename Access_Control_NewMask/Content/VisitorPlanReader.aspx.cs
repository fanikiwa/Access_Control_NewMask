using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using Access_Control_NewMask.ViewModels;
using System.Globalization;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Services;

namespace Access_Control_NewMask.Content
{
    public partial class VisitorPlanReader : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        static accessControlPermissionModes accessControlPermissionMode = accessControlPermissionModes.Read;
        static List<BuildingPlan> listBuildingPlan;
        static List<AccessGroup> listAccessGroups;
        static List<TbAccessPlan> listAccessPlans;
        static List<TbVisitorPlan> listVisitorPlans;
        static List<ReaderAssigned> listReaders;
        static List<TbAccessPlan> listAccessProfile;
        static List<KruAll.Core.Models.SwitchPlan> listSwitchProfile;
        static List<View_TerminalReader> listTerminalReader;
        static List<ReaderVisitorPlan> listReaderVisitorPLan;
        static string culture;
        static CultureInfo cultureInfo;

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("VisitorPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["VisitorPlan_PMode"] = value;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.VisitorPlan, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {

                btnSave.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                DisableControls();
                GetPassedData();
                BindControls();
                LoadReaders();
                LoadAccessProfile();
                LoadSwitchProfile();
                LoadTerminalReader();
                GetReadersVisitorPlan();
                if (string.IsNullOrEmpty(Request.QueryString["profileId"]))
                {
                    Response.Redirect("~/Content/VisitorPlan.aspx");
                }
                else
                {
                    GetBuildinPlanDetails(Convert.ToInt64(Request.QueryString["profileId"]));
                }
            }
            this.Form.DefaultButton = this.btnSave.UniqueID;
        }
        [System.Web.Services.WebMethod]
        public static BuildingPlan CreateBuildingPlan(int planNr, string planName, string planDefinition, int lastNodeKey)
        {
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            BuildingPlan buildingPlan = new BuildingPlan() { PlanNr = planNr, PlanName = planName, PlanDefinition = planDefinition, LastNodeKey = lastNodeKey };
            buildPlanViewModel.CreateBuildingPlan(buildingPlan);
            buildingPlan = buildPlanViewModel.GetBuildingPlanByNr(planNr);
            listBuildingPlan.Add(buildingPlan);
            return buildingPlan;
        }

        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        public void BindControls()
        {
            listBuildingPlan = new List<BuildingPlan>();
            listBuildingPlan.Add(new BuildingPlan() { ID = 0, PlanNr = 0, PlanName = "keine" });
            LoadExistingBuildingPlan(ref listBuildingPlan);
            dpllPlanNr.DataSource = listBuildingPlan;
            dpllPlanNr.DataBind();
            dpllPlanNr.SelectedIndex = 0;
            dplPlanName.DataSource = listBuildingPlan;
            dplPlanName.DataBind();
            dplPlanName.SelectedIndex = 0;
        }
        public void LoadExistingBuildingPlan(ref List<BuildingPlan> listBuildingPlan)
        {
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            listBuildingPlan.AddRange(buildPlanViewModel.BuildingPlans());
        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, object> GetBuildingPlan(long Id, long visitorPlanNr)
        {
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            BuildingPlan buildingPlan = new BuildingPlan();
            buildingPlan = listBuildingPlan.Where(plan => plan.ID == Id).FirstOrDefault();
            BuildingPlan buildingPlan2 = new BuildingPlan()
            {
                ID = buildingPlan.ID,
                PlanNr = buildingPlan.PlanNr,
                PlanName = buildingPlan.PlanName,
                PlanDefinition = buildingPlan.PlanDefinition,
                Memo = buildingPlan.Memo,
                LastNodeKey = buildingPlan.LastNodeKey

            };
            var accessCalendar = CheckIfAccessCalendarAssignedUsingBuildingPlanId(buildingPlan2.ID);
            var switchCalendar = CheckIfSwitchCalendarAssignedUsingBuildingPlanId(buildingPlan2.ID);
            var doorsList = GetDoorsListUsingBuildingPlanId(buildingPlan2.ID);
            var doorAssignedReader = GetDoorsAssignedReaderUsingBuildingPlanId(buildingPlan2.ID,visitorPlanNr);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("accessCalendar", accessCalendar);
            dictionary.Add("switchCalendar", switchCalendar);
            dictionary.Add("doorsList", doorsList);
            dictionary.Add("doorsAssignedList", doorAssignedReader);
            dictionary.Add("BuildingPlan", buildingPlan2);

            return dictionary;

            //return buildingPlan2;
        }

        #region get passed data
        protected void GetPassedData()
        {
            var profileId = Request.QueryString["profileId"];
            if (profileId == null) return;
            //if (profileNr == 0) return;
            TbVisitorPlan visitorPlan = new TbVisitorPlan();
            VisitorPlanViewModels planViewModel = new VisitorPlanViewModels();
            visitorPlan = planViewModel.GetVisitorPlanByID(Convert.ToInt64(profileId));
            txtVisitorProfileNumber.Text = visitorPlan.VisitorPlanNr.ToString();
            txtVisitorProfileName.Text = visitorPlan.VisitorPlanDescription;
            txtProfileId.Text = visitorPlan.ID.ToString();
            Session["visitorProfileId"] = profileId;
        }

        public void LoadExistingGroups(ref List<AccessGroup> listAccessGroups)
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            listAccessGroups.AddRange(accessGroups.GetAllAccessProfileGroups().Where(x => x.AccessGroupType == 1));
        }
        public void LoadAccessPlansByGroupID(ref List<TbAccessPlan> listAccessPlans)
        {

            //long groupId = Convert.ToInt32(ddlAccessGroupNumber.SelectedValue);
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
            //listAccessPlans.AddRange(accessPlans.GetAllAccessPlans().Where(x => x.AccessGroupID == groupId));

        }

        #endregion passed data

        [System.Web.Services.WebMethod]
        public static TbAccessPlan GetAccessPlanByID(long Id)
        {
            TbAccessPlan accessPlans = new TbAccessPlan();
            return listAccessPlans.Find(accessplan => accessplan.ID == Id);
        }

        [System.Web.Services.WebMethod]
        public static TbVisitorPlan VisitorPlan(long id)
        {
            VisitorPlanRepository visitorPlanRep = new VisitorPlanRepository();
            TbVisitorPlan visitorPlan = new TbVisitorPlan();
            TbVisitorPlan visitorPlan2 = new TbVisitorPlan();
            visitorPlan = visitorPlanRep.GetVisitorPlanById(id);
            //accessPlan = GetAccessPlanByID(id);
            visitorPlan2.ID = visitorPlan.ID;
            visitorPlan2.VisitorPlanNr = visitorPlan.VisitorPlanNr;
            visitorPlan2.VisitorPlanDescription = visitorPlan.VisitorPlanDescription;
            visitorPlan2.AccessCalendarId = visitorPlan.AccessCalendarId;
            visitorPlan2.BuildingPlanID = visitorPlan.BuildingPlanID;
            visitorPlan2.HolidayPlanCalendarId = visitorPlan.HolidayPlanCalendarId;

            return visitorPlan2;
        }
        [System.Web.Services.WebMethod]
        public static TbAccessPlan EditAccessPlan(int Id, long buildingPlanID)
        {
            AccessPlanRepository accessPlanRep = new AccessPlanRepository();
            TbAccessPlan accessPlan2 = new TbAccessPlan();
            accessPlan2 = accessPlanRep.GetAccessPlanById(Id);

            AccessPlanViewModel accessPlanViewModel = new AccessPlanViewModel();
            TbAccessPlan accessPlan = new TbAccessPlan() { ID = Id, AccessPlanNr = accessPlan2.AccessPlanNr, AccessPlanDescription = accessPlan2.AccessPlanDescription, AccessGroupID = accessPlan2.AccessGroupID, AccessCalendarId = accessPlan2.AccessCalendarId, BuildingPlanID = buildingPlanID, HolidayPlanCalendarId = accessPlan2.HolidayPlanCalendarId };
            accessPlanViewModel.UpdateAccessPlan(accessPlan);
            listAccessPlans.RemoveAll(x => x.ID == Id);
            listAccessPlans.Add(accessPlan);

            return accessPlan;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void PassVariables(int BuildingPlanId, int DoorNodeKey)
        {

            HttpContext.Current.Session["PlanId"] = BuildingPlanId;
            HttpContext.Current.Session["DoorId"] = DoorNodeKey;
            HttpContext.Current.Session["PageOrigin"] = "VisitorPlanReader";

        }
        [System.Web.Services.WebMethod]
        public static void ActivateDeactivateReaders(int buildingPlanId, int doorID, bool active)
        {
            //ReaderAssigned readers = new ReaderAssigned();
            IEnumerable<ReaderAssigned> readerList = new List<ReaderAssigned>();
            AssignReaderRepository repReaders = new AssignReaderRepository();
            readerList = repReaders.GetAllAssignedReaders().Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID);

            AssignReaderRepository assign = new AssignReaderRepository();
            foreach (var item in readerList)
            {
                ReaderAssigned readers = new ReaderAssigned()
                {

                    ID = item.ID,
                    BuildingPlanID = item.BuildingPlanID,
                    DoorID = item.DoorID,
                    LocationID = item.LocationID,
                    BuildingID = item.BuildingID,
                    FloorID = item.FloorID,
                    RoomID = item.RoomID,
                    TerminalID = item.TerminalID,
                    ReaderID = item.ReaderID,
                    Assigned = item.Assigned,
                    Active = active,
                    AccessProfileActive = item.AccessProfileActive,
                    SwitchProfileActive = item.SwitchProfileActive,
                    ManualOpeningActive = item.ManualOpeningActive,
                    PassBackNr = item.PassBackNr,
                    //AccessPlanNr = item.AccessPlanNr,
                    //AccessPlanReaderStatus = item.AccessPlanReaderStatus,
                    TA_Come = item.TA_Come,
                    TA_Go = item.TA_Go


                };

                assign.EditAssignedReader(readers);
            }

        }
        public static void GetReaders(ref List<ReaderAssigned> listReaders)
        {
            AssignReaderRepository terminalReader = new AssignReaderRepository();
            listReaders.AddRange(terminalReader.GetAllAssignedReaders());
        }
        public static void LoadReaders()
        {
            listReaders = new List<ReaderAssigned>();

            GetReaders(ref listReaders);

        }
        public static void GetReadersVisitorPlan()
        {
            listReaderVisitorPLan = new List<ReaderVisitorPlan>();
            listReaderVisitorPLan = new ReaderVisitorPlanRepository().GetReaderVisitorPLans();
        }


        [System.Web.Services.WebMethod]
        public static int CheckIfReaderAssigned(int buildingPlanId, int doorID)
        {
            int i = 0;
            ReaderAssigned assignedReaders = new ReaderAssigned();
            IEnumerable<ReaderAssigned> readerList = new List<ReaderAssigned>();
            readerList = listReaders.Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID);


            if (readerList.Count() > 0)
            {
                i = 1;

            }
            else { i = 0; }
            return i;
        }
        [System.Web.Services.WebMethod]
        public static bool CheckIfReaderActive(int buildingPlanId, int doorID)
        {
            var readerStatus = false;
            ReaderAssigned assignedReaders = new ReaderAssigned();
            IEnumerable<ReaderAssigned> readerList = new List<ReaderAssigned>();
            readerList = listReaders.Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID);


            if (readerList.Count() > 0)
            {
                assignedReaders = readerList.FirstOrDefault();
                readerStatus = Convert.ToBoolean(assignedReaders.Active);

            }
            else { readerStatus = false; }
            return readerStatus;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static int GetPlanID()
        {
            int planID = 0;
            if (HttpContext.Current.Session["PlanId"] != null)
            {
                planID = Convert.ToInt32(HttpContext.Current.Session["PlanId"]);
            }
            return planID;
        }

        // check if access calendar is assigned to building plan
        [System.Web.Services.WebMethod]
        public static bool CheckIfAccessCalendarAssigned(long buildingPlanId)
        {
            return CheckIfAccessCalendarAssignedUsingBuildingPlanId(buildingPlanId);
        }

        private static bool CheckIfAccessCalendarAssignedUsingBuildingPlanId(long buildingPlanId)
        {
            bool accessCalendar = false;
            TbAccessPlan accessPlan = new TbAccessPlan();
            IEnumerable<TbAccessPlan> planList = new List<TbAccessPlan>();
            planList = listAccessProfile.Where(x => x.BuildingPlanID == buildingPlanId);
            planList = planList.Where(x => x.AccessCalendarId != null);
            accessPlan = planList.FirstOrDefault();
            TbAccessPlan accessPlan2 = new TbAccessPlan();
            if (planList.Count() > 0)
            {
                accessPlan2.AccessCalendarId = accessPlan.AccessCalendarId;
                if (accessPlan2.AccessCalendarId != null && accessPlan2.AccessCalendarId > 0)
                {
                    accessCalendar = true;
                }
                else
                {
                    accessCalendar = false;
                }


            }
            else { accessCalendar = false; }
            return accessCalendar;
        }

        // check if switch calendar is assigned to building plan
        [System.Web.Services.WebMethod]
        public static bool CheckIfSwitchCalendarAssigned(long buildingPlanId)
        {
            return CheckIfSwitchCalendarAssignedUsingBuildingPlanId(buildingPlanId);
        }

        private static bool CheckIfSwitchCalendarAssignedUsingBuildingPlanId(long buildingPlanId)
        {
            bool switchCalendar = false;
            KruAll.Core.Models.SwitchPlan switchPlan = new KruAll.Core.Models.SwitchPlan();
            IEnumerable<KruAll.Core.Models.SwitchPlan> planList = new List<KruAll.Core.Models.SwitchPlan>();
            planList = listSwitchProfile.Where(x => x.BuidingPlanID == buildingPlanId);
            planList = planList.Where(x => x.SwitchCalendarId != null);
            switchPlan = planList.FirstOrDefault();
            KruAll.Core.Models.SwitchPlan switchPlan2 = new KruAll.Core.Models.SwitchPlan();
            if (planList.Count() > 0)
            {
                switchPlan2.SwitchCalendarId = switchPlan.SwitchCalendarId;
                if (switchPlan2.SwitchCalendarId != null && switchPlan2.SwitchCalendarId > 0)
                {
                    switchCalendar = true;
                }
                else
                {
                    switchCalendar = false;
                }


            }
            else { switchCalendar = false; }
            return switchCalendar;
        }

        //get doors list to access the key
        [System.Web.Services.WebMethod]
        public static IEnumerable<BuildingPlanDto> GetDoorsList(long buildingPlanId)
        {
            return GetDoorsListUsingBuildingPlanId(buildingPlanId);
        }

        private static IEnumerable<BuildingPlanDto> GetDoorsListUsingBuildingPlanId(long buildingPlanId)
        {
            string level = "5";
            BuildingPlan plan = new BuildingPlan();
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            IEnumerable<BuildingPlan> buildingPLan = new List<BuildingPlan>();
            buildingPLan = listBuildingPlan.Where(x => x.ID == buildingPlanId);
            plan = buildingPLan.FirstOrDefault();
            //if (plan == null) return;

            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
            Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
            var nodeData = buildingPlan["model"]["nodeDataArray"];

            List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
            IEnumerable<BuildingPlanDto> doorsList = new List<BuildingPlanDto>();
            doorsList = nodeArray.Where(x => x.level == level);
            return doorsList;
        }

        public void GetAccessProfile(ref List<TbAccessPlan> listAccessProfile)
        {
            AccessPlanViewModel accessPlan = new AccessPlanViewModel();
            listAccessProfile.AddRange(accessPlan.AccessPlans());
        }
        public void LoadAccessProfile()
        {
            listAccessProfile = new List<TbAccessPlan>();

            GetAccessProfile(ref listAccessProfile);

        }
        public void GetSwitchProfile(ref List<KruAll.Core.Models.SwitchPlan> listSwitchProfile)
        {
            SwitchPlanViewModel switchPlan = new SwitchPlanViewModel();
            listSwitchProfile.AddRange(switchPlan.GetSwitchPlans());
        }
        public void LoadSwitchProfile()
        {
            listSwitchProfile = new List<KruAll.Core.Models.SwitchPlan>();

            GetSwitchProfile(ref listSwitchProfile);

        }
        protected void LoadTerminalReader()
        {
            listTerminalReader = new List<View_TerminalReader>();
            LoadTerminalReader(ref listTerminalReader);
        }
        public void LoadTerminalReader(ref List<View_TerminalReader> listTerminalReader)
        {
            ViewTerminalReaderRepository terminalReader = new ViewTerminalReaderRepository();
            listTerminalReader.AddRange(terminalReader.GetAllTerminals());
        }
        //get doors list with assigned reader
        [System.Web.Services.WebMethod]
        public static IEnumerable<AssignedReaderDto> GetDoorsAssignedReader(long buildingPlanId, long visitorPlanNr)
        {
            return GetDoorsAssignedReaderUsingBuildingPlanId(buildingPlanId, visitorPlanNr);
        }

        private static IEnumerable<AssignedReaderDto> GetDoorsAssignedReaderUsingBuildingPlanId(long buildingPlanId, long visitorPlanNr)
        {
            var visitorPlan = new VisitorPlanRepository().GetVisitorPlanByNumber(visitorPlanNr);

            View_TerminalReader readers = new View_TerminalReader();
            IEnumerable<View_TerminalReader> doorListReader = new List<View_TerminalReader>();
            doorListReader = listTerminalReader;
            doorListReader = doorListReader.Where(x => x.BuildingPlanID == buildingPlanId).ToList();
            var doorListReader2 = doorListReader.GroupBy(x => x.DoorID).Select(grp => grp.First()).ToList();
            List<AssignedReaderDto> doorsList = new List<AssignedReaderDto>();
            foreach (var item in doorListReader2)
            {
                bool AccessPlanReaderStatus = false;
                var readerPLan = listReaderVisitorPLan.Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == item.DoorID && x.VisitorPlanId == visitorPlan.ID).FirstOrDefault();
                if (readerPLan != null)
                {
                    AccessPlanReaderStatus = Convert.ToBoolean(readerPLan.AccessPlanReaderStatus);
                }
                AssignedReaderDto terminalDto = new AssignedReaderDto()
                {
                    doorId = Convert.ToInt32(item.DoorID),
                    readerType = item.ReaderType,
                    readerStatus = item.ReaderStatus,
                    readerDirection = item.Direction,
                    readerAssigned = item.ReaderAssigned,
                    accessProfileActive = item.AccessProfileActive,
                    switchProfileActive = item.SwitchProfileActive,
                    manualOpeningActive = item.ManualOpeningActive,
                    accessPlanReaderStatus = AccessPlanReaderStatus,
                    passBackNr = item.PassBackNr
                };
                doorsList.Add(terminalDto);
            }
            return doorsList;
        }

        [System.Web.Services.WebMethod]
        public static void ActivateDeactivateAccessProfile(int buildingPlanId, int doorID, long visitorPlanNr, bool PlanActive)
        {
            //ReaderAssigned readers = new ReaderAssigned();
            var visitorPlan = new VisitorPlanRepository().GetVisitorPlanByNumber(visitorPlanNr);
            if (visitorPlan == null) return;
            ReaderAssigned reader = new ReaderAssigned();
            AssignReaderRepository repReaders = new AssignReaderRepository();
            reader = repReaders.GetAllAssignedReaders().Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID).FirstOrDefault();
            if (reader == null) return;
            var readerPLan = listReaderVisitorPLan.Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID && x.VisitorPlanId == visitorPlan.ID).FirstOrDefault();

            if (readerPLan != null)
            {
                ReaderVisitorPlan reader_plan = new ReaderVisitorPlan()
                {
                    ID = readerPLan.ID,
                    ReaderId = readerPLan.ReaderId,
                    VisitorPlanId = readerPLan.VisitorPlanId,
                    AccessPlanReaderStatus = PlanActive,
                    BuildingPlanID = readerPLan.BuildingPlanID,
                    DoorID = readerPLan.DoorID
                };
                new ReaderVisitorPlanRepository().EditReaderVisitorPlan(reader_plan);
            }
            else
            {
                ReaderVisitorPlan reader_plan = new ReaderVisitorPlan()
                {

                    ReaderId = reader.ReaderID,
                    VisitorPlanId = visitorPlan.ID,
                    AccessPlanReaderStatus = PlanActive,
                    BuildingPlanID = buildingPlanId,
                    DoorID = doorID
                };
                new ReaderVisitorPlanRepository().NewReaderVisitorPlan(reader_plan);
            }
            GetReadersVisitorPlan();
        }
        [System.Web.Services.WebMethod]
        public static bool CheckIfAccessPlanActive(long buildingPlanId, int doorID, long visitorPlanNr)
        {
            var visitorPlan = new VisitorPlanRepository().GetVisitorPlanByNumber(visitorPlanNr);
            if (visitorPlan == null) return false;
            var readerStatus = false;
            ReaderVisitorPlan assignedReaders = new ReaderVisitorPlan();
            IEnumerable<ReaderVisitorPlan> readerList = new List<ReaderVisitorPlan>();
            readerList = listReaderVisitorPLan.Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID && x.VisitorPlanId == visitorPlan.ID);


            if (readerList.Count() > 0)
            {
                assignedReaders = readerList.FirstOrDefault();
                readerStatus = Convert.ToBoolean(assignedReaders.AccessPlanReaderStatus);

            }
            else { readerStatus = false; }
            return readerStatus;
        }
        [System.Web.Services.WebMethod]
        public static void AssignPassBackNr(int buildingPlanId, int doorID, int passBackNr)
        {
            //ReaderAssigned readers = new ReaderAssigned();
            IEnumerable<ReaderAssigned> readerList = new List<ReaderAssigned>();
            AssignReaderRepository repReaders = new AssignReaderRepository();
            readerList = repReaders.GetAllAssignedReaders().Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID);

            AssignReaderRepository assign = new AssignReaderRepository();
            foreach (var item in readerList)
            {
                ReaderAssigned readers = new ReaderAssigned()
                {

                    ID = item.ID,
                    BuildingPlanID = item.BuildingPlanID,
                    DoorID = item.DoorID,
                    LocationID = item.LocationID,
                    BuildingID = item.BuildingID,
                    FloorID = item.FloorID,
                    RoomID = item.RoomID,
                    TerminalID = item.TerminalID,
                    ReaderID = item.ReaderID,
                    Assigned = item.Assigned,
                    Active = item.Active,
                    AccessProfileActive = item.AccessProfileActive,
                    SwitchProfileActive = item.SwitchProfileActive,
                    ManualOpeningActive = item.ManualOpeningActive,
                    PassBackNr = passBackNr,
                    //AccessPlanNr = item.AccessPlanNr,
                    //AccessPlanReaderStatus = item.AccessPlanReaderStatus,
                    TA_Come = item.TA_Come,
                    TA_Go = item.TA_Go


                };

                assign.EditAssignedReader(readers);
            }

        }
        [System.Web.Services.WebMethod]
        public static int CheckPassBackNr(int buildingPlanId, int doorID)
        {
            var passBackNr = 0;
            ViewTerminalReaderRepository readerRepo = new ViewTerminalReaderRepository();
            View_TerminalReader assignedReaders = new View_TerminalReader();
            List<View_TerminalReader> readerList = new List<View_TerminalReader>();
            readerList = readerRepo.GetAllTerminals().Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID).ToList();

            if (readerList.Count() > 0)
            {
                assignedReaders = readerList.FirstOrDefault();
                passBackNr = Convert.ToInt32(assignedReaders.Lock);

            }
            else
            {
                //reader not assigned
                passBackNr = 3;
            }
            return passBackNr;
        }
        [System.Web.Services.WebMethod]
        public static int CheckAssignedPassBackNr(int buildingPlanId, int doorID)
        {
            var passBackNr = 0;
            ViewTerminalReaderRepository readerRepo = new ViewTerminalReaderRepository();
            View_TerminalReader assignedReaders = new View_TerminalReader();
            List<View_TerminalReader> readerList = new List<View_TerminalReader>();
            readerList = readerRepo.GetAllTerminals().Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID).ToList();

            if (readerList.Count() > 0)
            {
                assignedReaders = readerList.FirstOrDefault();
                passBackNr = assignedReaders.PassBackNr != null ? Convert.ToInt32(assignedReaders.PassBackNr) : 0;

            }
            else
            {
                //reader not assigned
                passBackNr = 3;
            }
            return passBackNr;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string alertMessage;
            if (Convert.ToInt64(dpllPlanNr.Value) < 1)
            {
                alertMessage = "Bitte wählen Sie das Gebäudeplan Nr.";
                ClientScript.RegisterStartupScript(GetType(), "AlertMessage", "alert('" + alertMessage + "');", true);
                return;
            }

        }
        [WebMethod]
        public static void EditVisitorPlan(long buildingPlanId, long profileId)
        {

            var visitorPlanId = Convert.ToInt64(profileId);
            VisitorPlanViewModels selectVisitor = new VisitorPlanViewModels();
            TbVisitorPlan currentVisitorPlan = new TbVisitorPlan();
            currentVisitorPlan = selectVisitor.GetVisitorPlanByID(visitorPlanId);
            if (currentVisitorPlan == null) return;
            try
            {
                TbVisitorPlan visitorPlan = new TbVisitorPlan()
                {
                    ID = currentVisitorPlan.ID,
                    VisitorPlanNr = currentVisitorPlan.VisitorPlanNr,
                    VisitorPlanDescription = currentVisitorPlan.VisitorPlanDescription,
                    AccessCalendarId = currentVisitorPlan.AccessCalendarId,
                    BuildingPlanID = buildingPlanId,
                    HolidayPlanCalendarId = currentVisitorPlan.HolidayPlanCalendarId
                };
                VisitorPlanViewModels Visitor = new VisitorPlanViewModels();
                Visitor.UpdateVisitorPlan(visitorPlan);
            }
            catch (Exception ex)
            {

            }

        }
        protected void DisableControls()
        {
            txtVisitorGroupNumber.Enabled = false;
            txtVisitorGroupName.Enabled = false;
            txtVisitorProfileNumber.Enabled = false;
            txtVisitorProfileName.Enabled = false;
        }

        protected void btnPersonnel_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["profileId"];
            var url = HttpContext.Current.Request.Url.Authority;
            Response.Redirect(String.Format("/Content/VisitorPlanVisitor.aspx?profileId={0}", profileId));
        }

        protected void btnReader_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["profileId"];
            var url = HttpContext.Current.Request.Url.Authority;
            Response.Redirect(String.Format("/Content/VisitorPlanReader.aspx?profileId={0}", profileId));
        }

        protected void btnAccessProfile_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["profileId"];
            var url = HttpContext.Current.Request.Url.Authority;
            Response.Redirect(String.Format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", profileId));
        }

        protected void btnHoliday_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["profileId"];
            var url = HttpContext.Current.Request.Url.Authority;
            Response.Redirect(String.Format("/Content/VisitorPlanVisitorSchedule.aspx?profileId={0}", profileId));
        }

        public void GetBuildinPlanDetails(long profileId)
        {


            var currentVisitorPlan = new VisitorPlanViewModels().GetVisitorPlanByID(Convert.ToInt64(profileId));
            if (currentVisitorPlan != null)
            {
                if (currentVisitorPlan.BuildingPlanID != null)
                {
                    dpllPlanNr.Value = currentVisitorPlan.BuildingPlanID.ToString();
                    dplPlanName.Value = currentVisitorPlan.BuildingPlanID.ToString();
                    txtPlanNr.Text = dpllPlanNr.Text;
                    txtPlanName.Text = dplPlanName.Text;
                }
            }

        }
    }
}