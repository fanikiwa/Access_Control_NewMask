using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using System.Diagnostics;
using KruAll.Core.Repositories;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using DevExpress.Web;

namespace Access_Control_NewMask.Content
{
    public partial class AssignReader : BasePage
    {
        static List<View_TerminalReader> listTerminalReader;
        static List<TerminalReaderDto> listTerminalReader2;
        static List<TerminalReaderDto> listTerminalBuilding;
        static List<ReaderAssigned> selectedDoorReader;
        static long selected = 0;
        GlobalSettingsViewModel globalSettingViewModel = new GlobalSettingsViewModel();
        ZUTMain mainCtl = new ZUTMain();
        EncryptionCtl _encryptionCtl = new EncryptionCtl();
        string appURL = "";
        static List<ReaderUpdatedValuesDto> _UpdatedValues = new List<ReaderUpdatedValuesDto>();
        static long prevSelected = -999;

        static string culture;
        static CultureInfo cultureInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                BindTerminalControls();
                LoadSelectedTerminal();
                GetDoorDetails();
                var terminalId = Request.QueryString["id"];

                selected = Convert.ToInt64(ddlTerminalId.Value);
                if (Session["DoorId"] == null)
                {
                    //redirect

                }
            }

        }
        public void LoadTerminalReader(ref List<View_TerminalReader> listTerminalReader)
        {

            ViewTerminalReaderRepository terminalReader = new ViewTerminalReaderRepository();
            listTerminalReader.AddRange(terminalReader.GetAllTerminals());


        }
        //changes
        public void LoadTerminalReader2(ref List<TerminalReaderDto> listTerminalReader2)
        {
            listTerminalReader = new List<View_TerminalReader>();
            ViewTerminalReaderRepository terminalReader = new ViewTerminalReaderRepository();
            listTerminalReader.AddRange(terminalReader.GetAllTerminals());


            foreach (var item in listTerminalReader)
            {
                var locationName = "";
                var buildingName = "";
                var floorName = "";
                var roomName = "";
                var doorName = "";
                BuildingPlan plan = new BuildingPlan();
                BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
                if (item.BuildingPlanID > 0)
                {
                    plan = buildPlanViewModel.GetBuildingPlanByID(Convert.ToInt32(item.BuildingPlanID));
                    if (plan == null) return;

                    JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
                    Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
                    var nodeData = buildingPlan["model"]["nodeDataArray"];

                    List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
                    BuildingPlanDto node = new BuildingPlanDto();
                    if (item.ReaderAssigned == true)
                    {
                        // location name
                        node = nodeArray.Where(x => x.Key == Convert.ToString(item.LocationID)).FirstOrDefault();
                        locationName = node.text + " " + node.Address;
                        //building name
                        node = nodeArray.Where(x => x.Key == Convert.ToString(item.BuildingID)).FirstOrDefault();
                        buildingName = node.text + " " + node.Address;
                        //floor Name
                        node = nodeArray.Where(x => x.Key == Convert.ToString(item.FloorID)).FirstOrDefault();
                        floorName = node.text + " " + node.Address;
                        // room name
                        node = nodeArray.Where(x => x.Key == Convert.ToString(item.RoomID)).FirstOrDefault();
                        roomName = node.text + " " + node.Address;
                        // door name
                        node = nodeArray.Where(x => x.Key == Convert.ToString(item.DoorID)).FirstOrDefault();
                        doorName = node.text + " " + node.firstDescription;
                    }

                }
                var readerDirection = item.Direction;
                var _direction = "";
                switch (readerDirection)
                {
                    case 0:
                        _direction = GetLocalizedText("doorEntry"); ;
                        break;
                    case 1:
                        _direction = GetLocalizedText("doorExit"); ;
                        break;
                    default:
                        break;

                }
                var readerStatus = item.Status;
                var _status = "";
                switch (readerStatus)
                {
                    case 0:
                        _status = GetLocalizedText("statusInactive");
                        break;
                    case 1:
                        _status = GetLocalizedText("statusActive");
                        break;
                    default:
                        break;

                }

                TerminalReaderDto terminalDto = new TerminalReaderDto()
                {

                    ReaderId = item.ReaderId,
                    TerminalID = item.TerminalID,
                    TermID = item.TermID,
                    TerminalDescription = item.TerminalDescription,
                    ReaderNo = item.ReaderNo,
                    ReaderDirection = _direction,
                    Status = _status,
                    Direction = item.Direction,
                    ReaderDescription = item.ReaderDescription,
                    ReaderAssigned = item.ReaderAssigned,
                    BuildingName = buildingName,
                    FloorName = floorName,
                    RoomName = roomName,
                    DoorName = doorName,
                    DoorID = item.DoorID,
                    BuildingPlanID = item.BuildingPlanID

                };

                listTerminalReader2.Add(terminalDto);
            }


        }
        public void BindTerminalControls()
        {

            listTerminalReader = new List<View_TerminalReader>();
            listTerminalReader.Add(new View_TerminalReader() { TerminalID = 0, TermID = 0, TermType = "keine", TerminalDescription = "keine" });
            LoadTerminalReader(ref listTerminalReader);
            ddlTerminalId.DataSource = listTerminalReader.GroupBy(x => x.TerminalID).Select(grp => grp.First()).OrderBy(y => y.TermID);
            ddlTerminalId.DataBind();
            ddlTerminalControlUnit.DataSource = listTerminalReader.GroupBy(x => x.TerminalID).Select(grp => grp.First()).OrderBy(y => y.TermID);
            ddlTerminalControlUnit.DataBind();
            ddlTerminalDescription.DataSource = listTerminalReader.GroupBy(x => x.TerminalID).Select(grp => grp.First()).OrderBy(y => y.TermID);
            ddlTerminalDescription.DataBind();



        }
        // changes
        public void BindTerminalControls2()
        {

            listTerminalReader = new List<View_TerminalReader>();
            listTerminalReader.Add(new View_TerminalReader() { TerminalID = 0, TermID = 0, TermType = "keine", TerminalDescription = "keine" });
            LoadTerminalReader(ref listTerminalReader);
            ddlTerminalId.DataSource = listTerminalReader.GroupBy(x => x.TerminalID).Select(grp => grp.First()).OrderBy(y => y.TermID);
            ddlTerminalId.DataBind();
            ddlTerminalControlUnit.DataSource = listTerminalReader.GroupBy(x => x.TerminalID).Select(grp => grp.First()).OrderBy(y => y.TermID);
            ddlTerminalControlUnit.DataBind();
            ddlTerminalDescription.DataSource = listTerminalReader.GroupBy(x => x.TerminalID).Select(grp => grp.First()).OrderBy(y => y.TermID);
            ddlTerminalDescription.DataBind();



        }
        protected void ddlTerminalId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerminalControlUnit.Value = ddlTerminalId.Value;
            ddlTerminalDescription.Value = ddlTerminalId.Value;

            selected = Convert.ToInt64(ddlTerminalId.Value);
            BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            selected = Convert.ToInt64(ddlTerminalId.Value);
            Session["TerminalID"] = ddlTerminalId.Value;

            if (chkShowAll.Checked == true)
            {
                chkShowAll.Checked = false;
                btnTerminalInfo.Enabled = true;
            }

        }

        protected void ddlTerminalControlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerminalId.Value = ddlTerminalControlUnit.Value;
            ddlTerminalDescription.Value = ddlTerminalControlUnit.Value;
            selected = Convert.ToInt64(ddlTerminalControlUnit.Value);
            BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            Session["TerminalID"] = ddlTerminalControlUnit.Value;

            if (chkShowAll.Checked == true)
            {
                chkShowAll.Checked = false;
                btnTerminalInfo.Enabled = true;
            }

        }

        protected void ddlTerminalDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerminalId.Value = ddlTerminalDescription.Value;
            ddlTerminalControlUnit.Value = ddlTerminalDescription.Value;
            selected = Convert.ToInt64(ddlTerminalDescription.Value);
            BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            Session["TerminalID"] = ddlTerminalDescription.Value;

            if (chkShowAll.Checked == true)
            {
                chkShowAll.Checked = false;
                btnTerminalInfo.Enabled = true;
            }

        }
        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("/Content/Gebaudeplan.aspx");
        //}
        //protected void bindGridview()
        //{
        //    listTerminalReader = new List<View_TerminalReader>();
        //    LoadTerminalReader(ref listTerminalReader);
        //    grdReaders.DataSource = listTerminalReader;
        //    grdReaders.DataBind();


        //}
        protected void bindGridview2()
        {
            listTerminalReader2 = new List<TerminalReaderDto>();
            LoadTerminalReader2(ref listTerminalReader2);
            var readers = listTerminalReader2.OrderBy(x => x.TermID).ToList();
            grdReaders.DataSource = readers;
            grdReaders.DataBind();


        }
        protected void BindGridviewByTerninalID(int terminalID)
        {
            listTerminalReader = new List<View_TerminalReader>();
            LoadTerminalReader(ref listTerminalReader);
            grdReaders.DataSource = listTerminalReader.Where(x => x.TerminalID == terminalID);
            grdReaders.DataBind();



        }
        protected void BindGridviewByTerninalID2(long terminalID)
        {
            listTerminalReader2 = new List<TerminalReaderDto>();
            LoadTerminalReader2(ref listTerminalReader2);
            grdReaders.DataSource = listTerminalReader2.Where(x => x.TerminalID == terminalID);
            grdReaders.DataBind();



        }

        protected void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll.Checked == true)
            {
                txtSelectedTerminal.Text = " ";
                ddlTerminalId.Value = "0";
                ddlTerminalControlUnit.Value = "0";
                ddlTerminalDescription.Value = "0";
                btnTerminalInfo.Enabled = false;
                bindGridview2();
            }
            else
            {
                btnTerminalInfo.Enabled = true;
                grdReaders.DataSource = null;
                grdReaders.DataBind();
            }
        }
        protected void GetPassedData()
        {
            if (Session["PlanId"] != null)
            {
                string buildingPlanID = Session["PlanId"].ToString();

            }
            if (Session["DoorId"] != null)
            {
                string doorNodeKey = Session["DoorId"].ToString();

            }
        }
        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void btnTerminalNext_Click(object sender, EventArgs e)
        {
            chkShowAll.Checked = false;
            int maxmumIndex = ddlTerminalId.Items.Count;
            int seletcedIndex = ddlTerminalId.SelectedIndex;
            if (seletcedIndex < maxmumIndex - 1)
            {

                ddlTerminalId.SelectedIndex = ddlTerminalId.SelectedIndex + 1;
                ddlTerminalControlUnit.SelectedIndex = ddlTerminalControlUnit.SelectedIndex + 1;
                ddlTerminalDescription.SelectedIndex = ddlTerminalDescription.SelectedIndex + 1;
                txtSelectedTerminal.Text = ddlTerminalId.SelectedItem.Text;
                //BindGridviewByTerninalID(Convert.ToInt32(ddlTerminalId.SelectedValue));
                BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            }
        }

        protected void btnTerminalPrevious_Click(object sender, EventArgs e)
        {
            chkShowAll.Checked = false;
            int seletcedIndex = ddlTerminalId.SelectedIndex;
            if (seletcedIndex > 0)
            {
                ddlTerminalId.SelectedIndex = ddlTerminalId.SelectedIndex - 1;
                ddlTerminalControlUnit.SelectedIndex = ddlTerminalControlUnit.SelectedIndex - 1;
                ddlTerminalDescription.SelectedIndex = ddlTerminalDescription.SelectedIndex - 1;
                txtSelectedTerminal.Text = ddlTerminalId.SelectedItem.Text;
                //BindGridviewByTerninalID(Convert.ToInt32(ddlTerminalId.SelectedValue));
                BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            }
        }

        protected void grdReaders_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            if (Session["PlanId"] == null) return;
            if (Session["DoorId"] == null) return;
            if (Session["LocationId"] == null) return;
            if (Session["BuildingId"] == null) return;
            if (Session["FloorId"] == null) return;
            if (Session["RoomId"] == null) return;


            var updateValues = e.UpdateValues;


            foreach (var updateValue in updateValues)
            {
                try
                {
                    var keyValues = updateValue.Keys;
                    var newValues = updateValue.NewValues;
                    var oldValues = updateValue.OldValues;

                    var resourceId = Convert.ToInt32(keyValues["ReaderId"]);
                    AssignReaderRepository getValues = new AssignReaderRepository();
                    View_TerminalReader readersValues = new View_TerminalReader();
                    readersValues = listTerminalReader.Where(x => x.ReaderId == resourceId).FirstOrDefault();

                    var buildingPlanId = Convert.ToInt64(Session["PlanId"]);
                    var doorId = Convert.ToInt32(Session["DoorId"]);
                    var locationId = Convert.ToInt32(Session["LocationId"]);
                    var buildingId = Convert.ToInt32(Session["BuildingId"]);
                    var floorId = Convert.ToInt32(Session["FloorId"]);
                    var roomId = Convert.ToInt32(Session["RoomId"]);
                    var Id = readersValues.ID;
                    var terminalId = readersValues.TerminalID;
                    var readerId = readersValues.ReaderId;
                    //var connectionId = readersValues.TerminalConnectID;
                    //var accessPlanNr = readersValues.AccessPlanNr;
                    //var accessPlanStatus = readersValues.AccessPlanReaderStatus;
                    var readerAssigned = Convert.ToBoolean((newValues["ReaderAssigned"]));
                    bool active = false;
                    bool accessProfile = readersValues.AccessProfileActive;
                    bool switchProfile = readersValues.SwitchProfileActive;
                    bool manualOpening = readersValues.ManualOpeningActive;
                    if (readerAssigned == true)
                    {
                        active = readersValues.ReaderStatus;
                        //accessProfile = readersValues.AccessProfileActive;
                        //switchProfile = readersValues.SwitchProfileActive;
                        //manualOpening = readersValues.ManualOpeningActive;
                    }
                    else
                    {
                        active = false;
                        //accessProfile = false;
                        //switchProfile = false;
                        //manualOpening = false;
                    }


                    AssignReaderRepository assign = new AssignReaderRepository();
                    ReaderAssigned readers = new ReaderAssigned()
                    {

                        ID = Id,
                        BuildingPlanID = buildingPlanId,
                        DoorID = doorId,
                        LocationID = locationId,
                        BuildingID = buildingId,
                        FloorID = floorId,
                        RoomID = roomId,
                        TerminalID = terminalId,
                        ReaderID = readerId,
                        //ConnectionID = connectionId,
                        Assigned = readerAssigned,
                        Active = active,
                        SwitchProfileActive = switchProfile,
                        AccessProfileActive = accessProfile,
                        ManualOpeningActive = manualOpening,
                        //AccessPlanNr = accessPlanNr,
                        //AccessPlanReaderStatus = accessPlanStatus

                    };
                    if (Id == 0 && readerAssigned == true)
                    {
                        var exists = CheckIfReaderDoorExists(buildingPlanId, doorId);
                        if (exists == true)
                        {
                            UpdateDoorReader(buildingPlanId, doorId, locationId, buildingId, floorId, roomId, readerAssigned, terminalId, readerId);
                        }
                        else
                        {
                            assign.AssignReder(readers);
                        }

                    }
                    else if (Id > 0 && readerAssigned == false)
                    {

                        assign.DeleteReader(readers);

                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
            }
            e.Handled = true;
            if (chkShowAll.Checked == true)
            {
                bindGridview2();
            }
            else
            {
                //BindGridviewByTerninalID(Convert.ToInt32(ddlTerminalId.SelectedValue));
                BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            }
            //BindReaderGrid();
        }

        protected void btnTerminalInfo_Click(object sender, EventArgs e)
        {
            Session["TerminalID"] = ddlTerminalId.Value;
            Response.Redirect("BuildingPlanTermInfo.aspx");
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void GetTerminalID(int terminalNumber)
        {
            View_TerminalReader terminals = new View_TerminalReader();
            terminals = listTerminalReader.Where(x => x.TermID == terminalNumber).FirstOrDefault();

            HttpContext.Current.Session["TerminalID"] = terminals.TerminalID;

        }
        protected void LoadSelectedTerminal()
        {
            var terminalId = Request.QueryString["sTd"];
            if (terminalId != null)
            {
                if (Convert.ToInt32(terminalId) > 0)
                {
                    ddlTerminalId.Value = terminalId;
                    ddlTerminalControlUnit.Value = terminalId;
                    ddlTerminalDescription.Value = terminalId;
                    BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
                    txtSelectedTerminal.Text = ddlTerminalId.SelectedItem.Text;
                }
            }
            else if (Session["TerminalID"] != null)
            {

                string termknal_id = Session["TerminalID"].ToString();
                ddlTerminalId.Value = termknal_id;
                ddlTerminalControlUnit.Value = termknal_id;
                ddlTerminalDescription.Value = termknal_id;
                BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
                txtSelectedTerminal.Text = ddlTerminalId.SelectedItem.Text;
            }

        }
        protected void UpdateBuildingPlan(int id)
        {
            BuildingPlan plan = new BuildingPlan();
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            plan = buildPlanViewModel.GetBuildingPlanByID(id);
            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);


        }
        protected void BindEmptyList()
        {
            List<TerminalReaderDto> termReader = new List<TerminalReaderDto>();

            grdReaders.DataSource = termReader;
            grdReaders.DataBind();
        }
        protected List<TerminalReaderDto> BindTopGrid(int PlanId, int locationId, int buildingId, int floorId, int roomId, int doorId)
        {
            var locationName = "";
            var buildingName = "";
            var floorName = "";
            var roomName = "";
            var doorName = "";
            BuildingPlan plan = new BuildingPlan();
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();

            plan = buildPlanViewModel.GetBuildingPlanByID(PlanId);
            if (plan == null) return null;

            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
            Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
            var nodeData = buildingPlan["model"]["nodeDataArray"];

            List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());

            BuildingPlanDto node = new BuildingPlanDto();
            // location name
            node = nodeArray.Where(x => x.Key == Convert.ToString(locationId)).FirstOrDefault();
            locationName = node.text + " " + node.Address;
            //building name
            node = nodeArray.Where(x => x.Key == Convert.ToString(buildingId)).FirstOrDefault();
            buildingName = node.text + " " + node.Address;
            //floor Name
            node = nodeArray.Where(x => x.Key == Convert.ToString(floorId)).FirstOrDefault();
            floorName = node.text + " " + node.Address;
            // room name
            node = nodeArray.Where(x => x.Key == Convert.ToString(roomId)).FirstOrDefault();
            roomName = node.text + " " + node.Address;
            // door name
            node = nodeArray.Where(x => x.Key == Convert.ToString(doorId)).FirstOrDefault();
            doorName = node.text + " " + node.firstDescription;
            IEnumerable<View_TerminalReader> listReaderDoor = new List<View_TerminalReader>();
            listReaderDoor = listTerminalReader.Where(x => x.DoorID == Convert.ToInt32(doorId) && x.ReaderAssigned == true);
            listTerminalBuilding = new List<TerminalReaderDto>();
            View_TerminalReader reader = new View_TerminalReader();
            reader = listTerminalReader.FirstOrDefault();
            var switchProfile = "";
            var accessProfile = "";
            if (reader != null)
            {
                if (reader.SwitchProfileActive == true)
                {
                    switchProfile = "Aktiv";
                }
                else
                {
                    switchProfile = "Inaktiv";
                }
                if (reader.AccessProfileActive == true)
                {
                    accessProfile = "Aktiv";
                }
                else
                {
                    accessProfile = "Inaktiv";
                }
            }
            if (listReaderDoor.Count() > 0)
            {
                foreach (var item in listReaderDoor)
                {

                    TerminalReaderDto terminalDto = new TerminalReaderDto()
                    {

                        ReaderId = item.ReaderId,
                        TerminalID = item.TerminalID,
                        TermID = item.TermID,
                        TerminalDescription = item.TerminalDescription,
                        ReaderNo = item.ReaderNo,
                        Direction = item.Direction,
                        ReaderDescription = item.ReaderDescription,
                        ReaderAssigned = item.ReaderAssigned,
                        LocationName = locationName,
                        BuildingName = buildingName,
                        FloorName = floorName,
                        RoomName = roomName,
                        DoorName = doorName,
                        SwitchProfile = switchProfile,
                        AccessProfile = accessProfile

                    };
                    listTerminalBuilding.Add(terminalDto);
                }

            }
            else
            {
                TerminalReaderDto terminalDto = new TerminalReaderDto()
                {

                    ReaderId = 1,
                    TerminalID = null,
                    TermID = null,
                    TerminalDescription = null,
                    ReaderNo = null,
                    Direction = null,
                    ReaderDescription = null,
                    LocationName = locationName,
                    BuildingName = buildingName,
                    FloorName = floorName,
                    RoomName = roomName,
                    DoorName = doorName,
                    SwitchProfile = switchProfile,
                    AccessProfile = accessProfile


                };
                listTerminalBuilding.Add(terminalDto);

            }

            return listTerminalBuilding;


        }

        //protected void BindReaderGrid()
        //{
        //    var terminalId = Request.QueryString["id"];
        //    if (terminalId != null)
        //    {
        //        var LocationId = Convert.ToInt32(Request.QueryString["lId"]);
        //        var BuildingId = Convert.ToInt32(Request.QueryString["bId"]);
        //        var FloorId = Convert.ToInt32(Request.QueryString["fId"]);
        //        var RoomId = Convert.ToInt32(Request.QueryString["rId"]);
        //        var DoorId = Convert.ToInt32(Request.QueryString["dId"]);
        //        var PlanId = Convert.ToInt32(Request.QueryString["pId"]);
        //        grdDoorDetails.DataSource = BindTopGrid(PlanId, LocationId, BuildingId, FloorId, RoomId, DoorId);
        //        grdDoorDetails.DataBind();
        //    }
        //    else if(Session["PlanId"] != null)
        //    {

        //        var PlanId = Convert.ToInt32(Session["PlanId"]);
        //        var DoorId = Convert.ToInt32(Session["DoorId"]);
        //        var LocationId = Convert.ToInt32(Session["LocationId"]);
        //        var BuildingId = Convert.ToInt32(Session["BuildingId"]);
        //        var FloorId = Convert.ToInt32(Session["FloorId"]);
        //        var RoomId = Convert.ToInt32(Session["RoomId"]);
        //        grdDoorDetails.DataSource = BindTopGrid(PlanId, LocationId, BuildingId, FloorId, RoomId, DoorId);
        //        grdDoorDetails.DataBind();

        //    }

        //}
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void PassPageOrigin()
        {
            HttpContext.Current.Session["FromPage"] = "AssignReader.aspx";

        }
        protected string GetDoorName()
        {
            var doorName = "";
            if (Session["DoorId"] != null && Session["PlanId"] != null)
            {
                var planId = Convert.ToInt32(Session["PlanId"]);
                BuildingPlan plan = new BuildingPlan();
                BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
                plan = buildPlanViewModel.GetBuildingPlanByID(Convert.ToInt32(planId));
                if (plan == null) return "";
                JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
                Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
                var nodeData = buildingPlan["model"]["nodeDataArray"];
                List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
                BuildingPlanDto node = new BuildingPlanDto();
                var doorId = Convert.ToInt32(Session["DoorId"]);
                // door name
                node = nodeArray.Where(x => x.Key == Convert.ToString(doorId)).FirstOrDefault();
                doorName = node.text;
            }
            return doorName;
        }
        //protected void grdDoorDetails_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        //{
        //    string curDoorName = this.GetDoorName();
        //    string value = (string)e.GetValue("DoorName");
        //    try
        //    {
        //        //if (value == curDoorName)
        //        //{
        //        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFE3F6"); //option 1     
        //        //}

        //        if (e.CellValue.ToString() == "Eingang")
        //        {
        //            e.Cell.ForeColor = System.Drawing.Color.Green;
        //        }

        //        if (e.CellValue.ToString() == "Ausgang")
        //        {
        //            e.Cell.ForeColor = System.Drawing.Color.Red;
        //        }
        //        //if(e.Cell.ToolTip.ToString() == "doorPointer")
        //        //{
        //        //    e.Cell.Enabled = false;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}

        //protected void grdDoorDetails_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        //{
        //    //string curDoorName = this.GetDoorName();
        //    string curDoorId = Session["DoorId"].ToString();
        //    if (e.RowType != GridViewRowType.Data) return;
        //    //string value = (string)e.GetValue("DoorName");
        //    var value = e.GetValue("DoorID");
        //    if (value != null)
        //    {
        //        try
        //        {
        //            //if (value == curDoorName)
        //            //{
        //            //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFE3F6");
        //            //}
        //            //string doorName = value.ToString();

        //            //if (doorName == curDoorId)
        //            //{
        //            //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFE3F6");
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //        }
        //    }
        //}

        protected void grdReaders_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {

            var readerType = e.GetValue("Direction");

            try
            {
                if (Session["DoorId"] != null && Session["PlanId"] != null)
                {
                    string curDoorId = Session["DoorId"].ToString();
                    string curPlanId = Session["PlanId"].ToString();
                    var value = e.GetValue("DoorID");
                    var PlanValue = e.GetValue("BuildingPlanID");
                    if (value != null && PlanValue != null)
                    {
                        string doorName = value.ToString();
                        string planName = PlanValue.ToString();
                        if (doorName == curDoorId && planName == curPlanId)
                        {
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFE3F6");

                        }
                        //if (e.DataColumn.FieldName.Trim() == "ReaderAssigned")
                        //{
                        //    if (doorName == curDoorId && planName == curPlanId)
                        //    {
                        //        e.Cell.Attributes["disabled"] = "true";
                        //    }
                        //}  
                    }
                }
                if (e.DataColumn.FieldName.Trim() == "ReaderDirection")
                {
                    if (readerType != null)
                    {
                        var _readerType = Convert.ToInt32(readerType);
                        switch (_readerType)
                        {
                            case 0:
                                e.Cell.ForeColor = System.Drawing.Color.Green;
                                break;
                            case 1:
                                e.Cell.ForeColor = System.Drawing.Color.Red;
                                break;
                            default:
                                break;

                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        protected void grdReaders_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (Session["DoorId"] == null) return;
            if (Session["PlanId"] == null) return;
            string curDoorId = Session["DoorId"].ToString();
            string curPlanId = Session["PlanId"].ToString();
            if (e.RowType != GridViewRowType.Data) return;
            var value = e.GetValue("DoorID");
            var PlanValue = e.GetValue("BuildingPlanID");
            if (value != null && PlanValue != null)
            {
                try
                {
                    string doorName = value.ToString();
                    string planName = PlanValue.ToString();

                    if (doorName == curDoorId && planName == curPlanId)
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFE3F6");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string redirect_to_datafox(int terminalNumber) //Not In Use 29.10.2015
        {
            string url = "";
            View_TerminalReader terminals = new View_TerminalReader();
            terminals = listTerminalReader.Where(x => x.TermID == terminalNumber).FirstOrDefault();
            var terminalId = terminals.TerminalID;
            var terminalTypeId = terminals.TerminalTypeID;
            var selectedTerm = HttpContext.Current.Session["TerminalID"].ToString();
            var lId = HttpContext.Current.Session["LocationId"].ToString();
            var bId = HttpContext.Current.Session["BuildingId"].ToString();
            var fId = HttpContext.Current.Session["FloorId"].ToString();
            var rId = HttpContext.Current.Session["RoomId"].ToString();
            var dId = HttpContext.Current.Session["DoorId"].ToString();
            var pId = HttpContext.Current.Session["PlanId"].ToString();
            if (terminalTypeId == 13)
            {
                url = String.Format("http://5.189.190.209:150/Content/DatafoxNew.aspx?id={0}&tmId={1}&lId={2}&bId={3}&fId={4}&rId={5}&dId={6}&pId={7}&sTd={8}", terminalTypeId, terminalId, lId, bId, fId, rId, dId, pId, selectedTerm);
            }


            return url;
        }

        public bool CheckIfReaderDoorExists(long buildingPlanId, int doorID)
        {
            var i = false;
            ReaderAssigned assignedReaders = new ReaderAssigned();
            selectedDoorReader = new List<ReaderAssigned>();
            AssignReaderRepository assignnReaderRepo = new AssignReaderRepository();
            selectedDoorReader = assignnReaderRepo.GetAllAssignedReaders();
            selectedDoorReader = selectedDoorReader.Where(x => x.BuildingPlanID == buildingPlanId && x.DoorID == doorID).ToList();

            if (selectedDoorReader.Count() > 0)
            {
                i = true;

            }
            else { i = false; }
            return i;
        }
        protected void UpdateDoorReader(long buildingPlanId, int doorId, int locationId, int buildingId, int floorId, int roomId, bool isAssigned, long terminalId, long readerId)
        {
            AssignReaderRepository assign = new AssignReaderRepository();
            ReaderAssigned assignedReaders = new ReaderAssigned();
            assignedReaders = selectedDoorReader.FirstOrDefault();
            ReaderAssigned readers2 = new ReaderAssigned()
            {

                ID = assignedReaders.ID,
                BuildingPlanID = buildingPlanId,
                DoorID = doorId,
                LocationID = locationId,
                BuildingID = buildingId,
                FloorID = floorId,
                RoomID = roomId,
                TerminalID = terminalId,
                ReaderID = readerId,
                Assigned = isAssigned,
                Active = assignedReaders.Active,
                SwitchProfileActive = assignedReaders.SwitchProfileActive,
                AccessProfileActive = assignedReaders.AccessProfileActive,
                ManualOpeningActive = assignedReaders.ManualOpeningActive,
                //AccessPlanNr = assignedReaders.AccessPlanNr,
                //AccessPlanReaderStatus = assignedReaders.AccessPlanReaderStatus,
                PassBackNr = assignedReaders.PassBackNr,
                TA_Come = assignedReaders.TA_Come,
                TA_Go = assignedReaders.TA_Go

            };
            assign.EditAssignedReader(readers2);
        }
        public long CheckIfQueryStringExists(Object qString)
        {
            long sessionValue = 0;
            if (Session["TerminalID"] != null)
            {
                sessionValue = Convert.ToInt64(Session["TerminalID"]);
            }
            else
            {
                sessionValue = 0;
            }
            long i = 0;
            if (qString == null)
            {
                //i= 0;
                i = sessionValue;
            }
            else if (qString != null)
            {
                if (Convert.ToInt64(qString) > 0 || sessionValue > 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
            }
            return i;
        }
        public int CheckIfBuildingNameExists(Object buildingName)
        {
            int i = 0;
            if (buildingName == null)
            {
                i = 0;
            }
            else if (buildingName != null)
            {

                i = buildingName == DBNull.Value ? 0 : 1;
            }
            return i;
        }
        public long GetSelectedValue()
        {
            long i = 0;
            if (!IsPostBack)
            {
                if (Session["TerminalID"] != null)
                {
                    selected = Convert.ToInt64(Session["TerminalID"]);
                }

                i = selected;
            }

            return i;
        }

        protected void ImageButtonTermConfig_Click(object sender, ImageClickEventArgs e)
        {
            if (!mainCtl.allowTMKAppCheck()) return;
            GetGlobalSetting("TMK_URL");

            if (appURL.Trim() == "") return;

            TerminalRepository terminal = new TerminalRepository();
            if (Convert.ToInt64(ddlTerminalId.Value) < 1) return;
            var terminalID = Convert.ToInt64(ddlTerminalId.Value);
            View_TerminalReader terminals = new View_TerminalReader();
            terminals = listTerminalReader.Where(x => x.TerminalID == terminalID).FirstOrDefault();
            var terminalTypeId = terminals.TerminalTypeID;
            var terminalInstance = terminal.GetTerminalById(Convert.ToInt64(terminalTypeId));
            var terminalPage = terminalInstance.TerminalPage;
            var pageOrigin = 1;//AssignReader.aspx
            //Response.Redirect(String.Format("http://5.189.190.209:150/Content/{0}?id={1}&sTd={2}&ChildID={2}", terminalPage, terminalTypeId, terminalID));
            //Response.Redirect(String.Format("http://localhost:1495/Content/{0}?id={1}&sTd={2}&ChildID={2}", terminalPage, terminalTypeId, terminalID));

            string redirectLocation = String.Format("{0}?id={1}&sTd={2}&ChildID={2}&pageOrigin={3}", terminalPage, terminalTypeId, terminalID, pageOrigin);
            Response.Redirect(String.Format("http://{0}/Content/Login.aspx?user={1}&pass={2}&moveTo={3}", appURL,
                Session["Pers_LoginName"].ToString(), HttpUtility.UrlEncode(_encryptionCtl.Encrypt(Session["Pers_LoginPassword"].ToString())),
                HttpUtility.UrlEncode(_encryptionCtl.Encrypt(redirectLocation))));

        }

        protected void grdReaders_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            object id = e.KeyValue;
            if (id != null)
            {

                var value = grid.GetRowValuesByKeyValue(id, "DoorID");
                var planValue = grid.GetRowValuesByKeyValue(id, "BuildingPlanID");
                if (Session["DoorId"] == null) return;
                if (Session["PlanId"] == null) return;
                string curDoorId = Session["DoorId"].ToString();
                string curPlanId = Session["PlanId"].ToString();
                try
                {
                    if (value != null && planValue != null)
                    {
                        string doorName = value.ToString();
                        string planName = planValue.ToString();
                        if (doorName == curDoorId && planName == curPlanId)
                        {
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFE3F6");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void GetGlobalSetting(string settingName)
        {
            appURL = globalSettingViewModel.GetGetGlobalSettingByName(settingName);
        }
        protected int CompareTwoValues(string doorValue1, string doorvalue2)
        {
            int equal = 0;
            int door1 = Convert.ToInt32(doorValue1);
            int door2 = Convert.ToInt32(doorvalue2);
            if (door1 == door2)
            {
                equal = 0;
            }
            else { equal = 1; }
            return equal;
        }

        protected void grdReaders_DataBound(object sender, EventArgs e)
        {
            //for (var i = 0; i < grdReaders.VisibleRowCount; i++)
            //{
            //    var isSelected = Convert.ToBoolean(grdReaders.GetRowValues(i, "ReaderAssigned"));
            //    grdReaders.Selection.SetSelection(i, isSelected);
            //}
        }
        protected void grdReaders_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            //if (e.VisibleIndex == -1) return;

            //object fieldValue = grdReaders.GetRowValues(e.VisibleIndex, "ReaderAssigned");
            //object doorValue = grdReaders.GetRowValues(e.VisibleIndex, "DoorID");

            //if (e.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.Edit)
            //{
            //    string currentDoorId = Session["DoorId"].ToString();
            //    if (currentDoorId != null && doorValue != null)
            //    {
            //        var isCurrentDoor = CompareTwoValues(currentDoorId, doorValue.ToString());
            //        switch (isCurrentDoor)
            //        {
            //            case 0:
            //                e.Enabled = false;
            //                break;
            //            case 1:
            //                e.Enabled = true;
            //                break;
            //            default:
            //                break;

            //        }


            //    }
            //    //if (fieldValue == SOMETHING)
            //    //    e.Visible = true;
            //    //else
            //    //    e.Visible = false;
            //}
        }
        public bool IsEditable()
        {
            bool _isEditable = true;

            return _isEditable;
        }

        protected void chk_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;
            chk.ClientSideEvents.CheckedChanged = String.Format("function (s, e) {{ cb.PerformCallback('{0}|' + s.GetChecked()); }}", container.KeyValue);

        }
        //protected void cb_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        //{
        //    String[] p = e.Parameter.Split('|');
        //    ReaderUpdatedValuesDto updatedValue = new ReaderUpdatedValuesDto()
        //    {
        //        ReaderId = Convert.ToInt64(Convert.ToInt32(p[0])),
        //        IsChecked = Convert.ToBoolean(p[1])
        //    };

        //    _UpdatedValues.Add(updatedValue);
        //    var previousValue = prevSelected;
        //    prevSelected = Convert.ToInt64(Convert.ToInt32(p[0]));
        //    if (previousValue != -999)
        //    {
        //        int KeyIndex = grdReaders.FindVisibleIndexByKeyValue(previousValue);
        //        //ASPxCheckBox chkReader = grdReaders.FindRowCellTemplateControl(KeyIndex, grdReaders.Columns["ReaderAssigned"] as GridViewDataColumn, "chk") as ASPxCheckBox;
        //        //ASPxCheckBox chkReader = grdReaders.FindRowCellTemplateControl(KeyIndex, e.DataColumn, "ReaderAssigned") as ASPxCheckBox;
        //        ASPxCheckBox chkReader = grdReaders.FindRowCellTemplateControl(KeyIndex, (GridViewDataColumn)grdReaders.Columns["ReaderAssigned"], "chk") as ASPxCheckBox;
        //        chkReader.Checked = false;


        //    }


        //}
        protected void SaveReaders()
        {
            if (Session["PlanId"] == null) return;
            if (Session["DoorId"] == null) return;
            if (Session["LocationId"] == null) return;
            if (Session["BuildingId"] == null) return;
            if (Session["FloorId"] == null) return;
            if (Session["RoomId"] == null) return;
            var updateValues = _UpdatedValues;
            foreach (var updateValue in updateValues)
            {
                try
                {
                    //var keyValues = updateValue.Keys;
                    //var newValues = updateValue.NewValues;
                    //var oldValues = updateValue.OldValues;

                    //var resourceId = Convert.ToInt32(keyValues["ReaderId"]);
                    var resourceId = updateValue.ReaderId;
                    AssignReaderRepository getValues = new AssignReaderRepository();
                    View_TerminalReader readersValues = new View_TerminalReader();
                    readersValues = listTerminalReader.Where(x => x.ReaderId == resourceId).FirstOrDefault();

                    var buildingPlanId = Convert.ToInt64(Session["PlanId"]);
                    var doorId = Convert.ToInt32(Session["DoorId"]);
                    var locationId = Convert.ToInt32(Session["LocationId"]);
                    var buildingId = Convert.ToInt32(Session["BuildingId"]);
                    var floorId = Convert.ToInt32(Session["FloorId"]);
                    var roomId = Convert.ToInt32(Session["RoomId"]);
                    var Id = readersValues.ID;
                    var terminalId = readersValues.TerminalID;
                    var readerId = readersValues.ReaderId;
                    //var connectionId = readersValues.TerminalConnectID;
                    //var accessPlanNr = readersValues.AccessPlanNr;
                    //var accessPlanStatus = readersValues.AccessPlanReaderStatus;
                    //var readerAssigned = Convert.ToBoolean((newValues["ReaderAssigned"]));
                    var readerAssigned = updateValue.IsChecked;
                    bool active = false;
                    bool accessProfile = readersValues.AccessProfileActive;
                    bool switchProfile = readersValues.SwitchProfileActive;
                    bool manualOpening = readersValues.ManualOpeningActive;
                    if (readerAssigned == true)
                    {
                        active = readersValues.ReaderStatus;
                        //accessProfile = readersValues.AccessProfileActive;
                        //switchProfile = readersValues.SwitchProfileActive;
                        //manualOpening = readersValues.ManualOpeningActive;
                    }
                    else
                    {
                        active = false;
                        //accessProfile = false;
                        //switchProfile = false;
                        //manualOpening = false;
                    }


                    AssignReaderRepository assign = new AssignReaderRepository();
                    ReaderAssigned readers = new ReaderAssigned()
                    {

                        ID = Id,
                        BuildingPlanID = buildingPlanId,
                        DoorID = doorId,
                        LocationID = locationId,
                        BuildingID = buildingId,
                        FloorID = floorId,
                        RoomID = roomId,
                        TerminalID = terminalId,
                        ReaderID = readerId,
                        //ConnectionID = connectionId,
                        Assigned = readerAssigned,
                        Active = active,
                        SwitchProfileActive = switchProfile,
                        AccessProfileActive = accessProfile,
                        ManualOpeningActive = manualOpening,
                        //AccessPlanNr = accessPlanNr,
                        //AccessPlanReaderStatus = accessPlanStatus

                    };
                    if (Id == 0 && readerAssigned == true)
                    {
                        var exists = CheckIfReaderDoorExists(buildingPlanId, doorId);
                        if (exists == true)
                        {
                            UpdateDoorReader(buildingPlanId, doorId, locationId, buildingId, floorId, roomId, readerAssigned, terminalId, readerId);
                        }
                        else
                        {
                            assign.AssignReder(readers);
                        }

                    }
                    else if (Id > 0 && readerAssigned == false)
                    {

                        assign.DeleteReader(readers);

                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
            }

            if (chkShowAll.Checked == true)
            {
                bindGridview2();
            }
            else
            {
                //BindGridviewByTerninalID(Convert.ToInt32(ddlTerminalId.SelectedValue));
                BindGridviewByTerninalID2(Convert.ToInt32(ddlTerminalId.Value));
            }
            //BindReaderGrid();
        }

        protected void btnTake_Click(object sender, EventArgs e)
        {
            //SaveReaders();
        }
        protected void GetDoorDetails()
        {
            var terminalId = Request.QueryString["sTd"];
            if (terminalId != null)
            {
                //var LocationId = Convert.ToInt32(Request.QueryString["lId"]);
                //var BuildingId = Convert.ToInt32(Request.QueryString["bId"]);
                //var FloorId = Convert.ToInt32(Request.QueryString["fId"]);
                //var RoomId = Convert.ToInt32(Request.QueryString["rId"]);
                //var DoorId = Convert.ToInt32(Request.QueryString["dId"]);
                //var PlanId = Convert.ToInt32(Request.QueryString["pId"]);
                //var readerDetails = BindTopGrid(PlanId, LocationId, BuildingId, FloorId, RoomId, DoorId).FirstOrDefault();
                //lblLocation.Text = readerDetails.LocationName;
                //lblBuilding.Text = readerDetails.BuildingName;
                //lblFloor.Text = readerDetails.FloorName;
                //lblRoom.Text = readerDetails.RoomName;
                //lblDoor.Text = readerDetails.DoorName;
            }
            else if (Session["PlanId"] != null)
            {

                var PlanId = Convert.ToInt32(Session["PlanId"]);
                var DoorId = Convert.ToInt32(Session["DoorId"]);
                var LocationId = Convert.ToInt32(Session["LocationId"]);
                var BuildingId = Convert.ToInt32(Session["BuildingId"]);
                var FloorId = Convert.ToInt32(Session["FloorId"]);
                var RoomId = Convert.ToInt32(Session["RoomId"]);
                var readerDetails = BindTopGrid(PlanId, LocationId, BuildingId, FloorId, RoomId, DoorId).FirstOrDefault();
                lblLocation.Text = readerDetails.LocationName;
                lblBuilding.Text = readerDetails.BuildingName;
                lblFloor.Text = readerDetails.FloorName;
                lblRoom.Text = readerDetails.RoomName;
                lblDoor.Text = readerDetails.DoorName;


            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        protected void grdReaders_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var id = Convert.ToInt64(e.Parameters);
                if (id > 0)
                {
                    BindGridviewByTerninalID2(Convert.ToInt64(e.Parameters));
                    Session["TerminalID"] = e.Parameters;
                }
                else
                {
                    bindGridview2();
                    Session["TerminalID"] = null;
                }
            }
            else
            {
                grdReaders.DataSource = null;
                grdReaders.DataBind();
            }
        }
    }
}