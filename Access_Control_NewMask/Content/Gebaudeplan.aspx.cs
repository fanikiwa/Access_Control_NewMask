using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class Gebaudeplan : BasePage
    {
        static List<BuildingPlan> listBuildingPlan;
        static List<View_TerminalReader> listTerminalReader;
        static List<TbAccessPlan> listAccessProfile;
        static List<KruAll.Core.Models.SwitchPlan> listSwitchProfile;
        static List<ReaderAssigned> listReaders;
        ZUTMain mainCtl = new ZUTMain();

        static string culture;
        static CultureInfo cultureInfo;

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("BuildingPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["BuildingPlan_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.BuildingPlan, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnNew.Enabled = false; btnSave.Enabled = false; btnCancelDel.Enabled = false;

                btnAddBuilding.Enabled = false; btnAddLocation.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;
            if (!IsPostBack)
            {
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                BindControls();
                LoadTerminalReader();
                BindEmptyDataRow();
                LoadAccessProfile();
                LoadSwitchProfile();
                LoadReaders();
            }
            this.Form.DefaultButton = this.btnSave.UniqueID;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
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
            dplPlanName.DataSource = listBuildingPlan;
            dplPlanName.DataBind();
            dpllPlanNr.SelectedIndex = 0;
            dplPlanName.SelectedIndex = 0;
        }
        public void LoadExistingBuildingPlan(ref List<BuildingPlan> listBuildingPlan)
        {
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            listBuildingPlan.AddRange(buildPlanViewModel.BuildingPlans());
        }

        [System.Web.Services.WebMethod]
        //public static BuildingPlan GetBuildingPlan(long Id)
        //{
        public static Dictionary<string, object> GetBuildingPlan(long Id)
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

            long buildingPlanId = buildingPlan2.ID;

            var accessCalendar = CheckIfAccessCalendarAssignedUsingBuildingPlanId(buildingPlanId);

            var switchCalendar = CheckIfSwitchCalendarAssignedUsingBuildingPlanId(buildingPlanId);

            var doorsList = GetDoorsListUsingBuildingPlanId(buildingPlanId);

            var assignedDoorsList = GetDoorsAssignedReaderUsingBuildingPlanId(buildingPlanId);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("accessCalendar", accessCalendar);
            dictionary.Add("switchCalendar", switchCalendar);
            dictionary.Add("doorsList", doorsList);
            dictionary.Add("assignedDoorsList", assignedDoorsList);
            dictionary.Add("BuildingPlan", buildingPlan2);

            //return buildingPlan2;
            return dictionary;
        }
        [System.Web.Services.WebMethod]
        public static void DeleteBuildingPlan(int ID)
        {
            try
            {
                BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
                BuildingPlan buildingPlan = new BuildingPlan() { ID = ID };
                buildPlanViewModel.DeleteBuildingPlan(buildingPlan);
                listBuildingPlan.RemoveAll(x => x.ID == ID);
            }
            catch (Exception ex)
            {

            }

        }

        [System.Web.Services.WebMethod]
        public static BuildingPlan UpdateBuildingPlan(int Id, int planNr, string planName, string planDefinition, int lastNodeKey)
        {
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            BuildingPlan buildingPlan = new BuildingPlan() { ID = Id, PlanNr = planNr, PlanName = planName, PlanDefinition = planDefinition, LastNodeKey = lastNodeKey };
            buildPlanViewModel.UpdateBuildingPlan(buildingPlan);
            listBuildingPlan.RemoveAll(x => x.ID == Id);
            listBuildingPlan.Add(buildingPlan);
            return buildingPlan;
        }

        public void LoadTerminalReader(ref List<View_TerminalReader> listTerminalReader)
        {
            ViewTerminalReaderRepository terminalReader = new ViewTerminalReaderRepository();
            listTerminalReader.AddRange(terminalReader.GetAllTerminals());
        }
        public void BindTerminalControls()
        {
            listTerminalReader = new List<View_TerminalReader>();
            listTerminalReader.Add(new View_TerminalReader() { TerminalID = 0, TermID = 0, TermType = "keine", TerminalDescription = "keine" });
            LoadTerminalReader(ref listTerminalReader);
            ddlTerminalId.DataSource = listTerminalReader;
            ddlTerminalId.DataBind();
            ddlTerminalControlUnit.DataSource = listTerminalReader;
            ddlTerminalControlUnit.DataBind();
            ddlTerminalDescription.DataSource = listTerminalReader;
            ddlTerminalDescription.DataBind();
        }
        protected void LoadTerminalReader()
        {
            listTerminalReader = new List<View_TerminalReader>();
            LoadTerminalReader(ref listTerminalReader);
        }

        protected void ddlTerminalId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerminalControlUnit.Value = ddlTerminalId.Value;
            ddlTerminalDescription.Value = ddlTerminalId.Value;

        }

        protected void ddlTerminalControlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerminalId.Value = ddlTerminalControlUnit.Value;
            ddlTerminalDescription.Value = ddlTerminalControlUnit.Value;

        }

        protected void ddlTerminalDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerminalId.Value = ddlTerminalDescription.Value;
            ddlTerminalControlUnit.Value = ddlTerminalDescription.Value;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void PassVariables(int BuildingPlanId, int DoorNodeKey, int LocationId, int BuildingId, int FloorId, int RoomId)
        {
            HttpContext.Current.Session["PlanId"] = BuildingPlanId;
            HttpContext.Current.Session["DoorId"] = DoorNodeKey;
            HttpContext.Current.Session["LocationId"] = LocationId;
            HttpContext.Current.Session["BuildingId"] = BuildingId;
            HttpContext.Current.Session["FloorId"] = FloorId;
            HttpContext.Current.Session["RoomId"] = RoomId;

            View_TerminalReader terminalInfo = new View_TerminalReader();
            terminalInfo = listTerminalReader.Where(x => x.BuildingPlanID == BuildingPlanId && x.DoorID == DoorNodeKey).FirstOrDefault();
            if (terminalInfo != null)
            {
                HttpContext.Current.Session["TerminalID"] = terminalInfo.TerminalID;
            }
            else
            {
                HttpContext.Current.Session["TerminalID"] = 0;
            }

        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void PassVariablesInfo(int BuildingPlanId, int DoorNodeKey)
        {
            HttpContext.Current.Session["PlanId"] = BuildingPlanId;
            HttpContext.Current.Session["DoorId"] = DoorNodeKey;


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

        protected void BindEmptyDataRow()
        {
            List<GridClass> listGrid = new List<GridClass>();
            listGrid.Add(new GridClass() { LocationID = " ", BuildingID = " ", FloorID = " ", RoomID = " ", DoorID = " " });
            BuildingPlanDetais.DataSource = listGrid;
            BuildingPlanDetais.DataBind();
        }
        public class GridClass
        {
            public string LocationID { get; set; }
            public string BuildingID { get; set; }
            public string FloorID { get; set; }
            public string RoomID { get; set; }
            public string DoorID { get; set; }

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
        //get doors list with assigned reader
        [System.Web.Services.WebMethod]
        public static IEnumerable<AssignedReaderDto> GetDoorsAssignedReader(long buildingPlanId)
        {
            return GetDoorsAssignedReaderUsingBuildingPlanId(buildingPlanId);
        }

        private static IEnumerable<AssignedReaderDto> GetDoorsAssignedReaderUsingBuildingPlanId(long buildingPlanId)
        {
            View_TerminalReader readers = new View_TerminalReader();
            IEnumerable<View_TerminalReader> doorListReader = new List<View_TerminalReader>();
            doorListReader = listTerminalReader;
            doorListReader = doorListReader.Where(x => x.BuildingPlanID == buildingPlanId).ToList();
            var doorListReader2 = doorListReader.GroupBy(x => x.DoorID).Select(grp => grp.First()).ToList();
            List<AssignedReaderDto> doorsList = new List<AssignedReaderDto>();
            foreach (var item in doorListReader2)
            {
                AssignedReaderDto terminalDto = new AssignedReaderDto()
                {
                    doorId = Convert.ToInt32(item.DoorID),
                    readerType = item.ReaderType,
                    readerStatus = item.ReaderStatus,
                    readerDirection = item.Direction,
                    readerAssigned = item.ReaderAssigned,
                    accessProfileActive = item.AccessProfileActive,
                    switchProfileActive = item.SwitchProfileActive,
                    manualOpeningActive = item.ManualOpeningActive

                };
                doorsList.Add(terminalDto);
            }
            return doorsList;
        }

        [System.Web.Services.WebMethod]
        protected static void UpdateAssignedReader(int buildingPlanId)
        {
            BuildingPlan plan = new BuildingPlan();
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            plan = buildPlanViewModel.GetBuildingPlanByID(Convert.ToInt32(buildingPlanId));
            if (plan == null) return;
            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
            Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
            var nodeData = buildingPlan["model"]["nodeDataArray"];

            List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
            BuildingPlanDto node = new BuildingPlanDto();

            var assignedDoors = GetDoorsAssignedReader(buildingPlanId);
            foreach (var item in assignedDoors)
            {
                var doorId = item.doorId;
                var readerActive = false;
                node = nodeArray.Where(x => x.Key == Convert.ToString(doorId)).FirstOrDefault();
                if (node != null)
                {
                    readerActive = Convert.ToBoolean((node.laserChoice));
                    var resourceId = Convert.ToInt32(doorId);
                    AssignReaderRepository getValues = new AssignReaderRepository();
                    View_TerminalReader readersValues = new View_TerminalReader();
                    readersValues = listTerminalReader.Where(x => x.DoorID == resourceId).FirstOrDefault();
                    AssignReaderRepository assign = new AssignReaderRepository();
                    ReaderAssigned readers = new ReaderAssigned()
                    {

                        ID = readersValues.ID,
                        BuildingPlanID = readersValues.BuildingPlanID,
                        DoorID = Convert.ToInt32(readersValues.DoorID),
                        LocationID = readersValues.LocationID,
                        BuildingID = readersValues.BuildingID,
                        FloorID = readersValues.FloorID,
                        RoomID = readersValues.RoomID,
                        TerminalID = readersValues.TerminalID,
                        ReaderID = readersValues.ReaderId,
                        Assigned = readersValues.ReaderAssigned,
                        Active = readerActive,
                        SwitchProfileActive = readersValues.SwitchProfileActive,
                        AccessProfileActive = readersValues.AccessProfileActive,
                        ManualOpeningActive = readersValues.ManualOpeningActive,
                        PassBackNr = readersValues.PassBackNr,
                        //AccessPlanNr = readersValues.AccessPlanNr,
                        //AccessPlanReaderStatus = readersValues.AccessPlanReaderStatus,
                        TA_Come = readersValues.TA_Come,
                        TA_Go = readersValues.TA_Go

                    };
                    assign.EditAssignedReader(readers);
                }
            }
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
            //AssignReaderRepository terminalReader = new AssignReaderRepository();
            //listReaders.AddRange(terminalReader.GetAllAssignedReaders());
            LoadReaders();
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
        public static void DeleteReaderAssigned(long buildingPlanId, int doorID)
        {
            ReaderAssigned readers = new ReaderAssigned();
            AssignReaderRepository readerRepo = new AssignReaderRepository();
            var readerList = readerRepo.GetReadersByDoorId(buildingPlanId, doorID);
            foreach (var _reader in readerList)
            {
                readerRepo.DeleteAssignedReader(_reader);
            }
        }
        [System.Web.Services.WebMethod]
        public static bool CheckIfPlanNrExists(int number)
        {
            bool exists = false;
            BuildingPlan buildingPlan = new BuildingPlan();
            BuildingPlanViewModel planViewModel = new BuildingPlanViewModel();
            buildingPlan = planViewModel.GetBuildingPlanByNr(number);
            if (buildingPlan != null)
            {
                exists = true;
            }
            else
            {
                exists = false;
            }

            return exists;
        }
        [System.Web.Services.WebMethod]
        protected static void RedirectTotermConfig()
        {
            EncryptionCtl _encryptionCtl = new EncryptionCtl();
            ZUTMain mainCtl = new ZUTMain();
            string appURL = "";

            if (!mainCtl.allowTMKAppCheck()) return;
            //GetGlobalSetting("TMK_URL");
            GlobalSettingsViewModel globalSettingViewModel = new GlobalSettingsViewModel();
            appURL = globalSettingViewModel.GetGetGlobalSettingByName("TMK_URL");

            if (appURL.Trim() == "") return;
            HttpContext.Current.Response.Redirect(String.Format("http://{0}/Content/Login.aspx?user={1}&pass={2}", appURL,
           HttpContext.Current.Session["Pers_LoginName"].ToString(), HttpUtility.UrlEncode(_encryptionCtl.Encrypt(HttpContext.Current.Session["Pers_LoginPassword"].ToString()))));
        }

        protected void dpllPlanNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                listBuildingPlan = new List<BuildingPlan>();
                listBuildingPlan.Add(new BuildingPlan() { ID = 0, PlanNr = 0, PlanName = "keine" });
                LoadExistingBuildingPlan(ref listBuildingPlan);
                dpllPlanNr.DataSource = listBuildingPlan;
                dpllPlanNr.DataBind();
                dpllPlanNr.Value = e.Parameter;
            }
            else
            {
                listBuildingPlan = new List<BuildingPlan>();
                listBuildingPlan.Add(new BuildingPlan() { ID = 0, PlanNr = 0, PlanName = "keine" });
                LoadExistingBuildingPlan(ref listBuildingPlan);
                dpllPlanNr.DataSource = listBuildingPlan;
                dpllPlanNr.DataBind();
                dpllPlanNr.SelectedIndex = 0;

            }
        }

        protected void dplPlanName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                listBuildingPlan = new List<BuildingPlan>();
                listBuildingPlan.Add(new BuildingPlan() { ID = 0, PlanNr = 0, PlanName = "keine" });
                LoadExistingBuildingPlan(ref listBuildingPlan);
                dplPlanName.DataSource = listBuildingPlan;
                dplPlanName.DataBind();
                dplPlanName.Value = e.Parameter;
            }
            else
            {
                listBuildingPlan = new List<BuildingPlan>();
                listBuildingPlan.Add(new BuildingPlan() { ID = 0, PlanNr = 0, PlanName = "keine" });
                LoadExistingBuildingPlan(ref listBuildingPlan);
                dplPlanName.DataSource = listBuildingPlan;
                dplPlanName.DataBind();
                dplPlanName.SelectedIndex = 0;

            }
        }
    }
}