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
using System.Web.Services;
using System.Globalization;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlanGroupReader : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        static string culture;
        static CultureInfo cultureInfo;

        public int  GetJSVersion
        {
            get { return 1; }
        }

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("AccessGroup_PMode");
            }
            set
            {
                HttpContext.Current.Session["AccessGroup_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.AccessGroup, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSaveSelectionDiagram.Enabled = false; btnSaveSelectionGrid.Enabled = false;

                btnSelectAllDiagram.Enabled = false; btnSelectAllGrid.Enabled = false;

                btnDeleteSeldctionDiagram.Enabled = false; btnDeleteSeldctionGrid.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Form.DefaultButton = this.btnSaveSelectionDiagram.UniqueID;

            if (!IsPostBack)
            {
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                LoadAccessPlanGroups();
                DisableTopControls();
                LoadBuildinPlanLocations();
                LoadExistinBuildingPLan(Convert.ToInt64(cobAccessGroupNr.Value));
                LoadBuildingPlanGrid(0, 0);
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
        protected void LoadAccessPlanGroups()
        {
            List<TbAccessPlanGroup> listPlanGroups = new List<TbAccessPlanGroup>();
            TbAccessPlanGroup accessPlanGroup = new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = "keine" };
            listPlanGroups.Add(accessPlanGroup);
            var visitorPlans = new AccessPlanGroupRepository().GetAllAccessPlanGroups();
            listPlanGroups.AddRange(visitorPlans);
            cobAccessGroupName.DataSource = visitorPlans;
            cobAccessGroupName.DataBind();
            cobAccessGroupNr.DataSource = visitorPlans;
            cobAccessGroupNr.DataBind();
            LoadSelectedGroup();
        }
        protected void LoadBuildinPlanLocations()
        {
            var locList = new AccessPlanGroupReaderViewModel().BuildingPlanLocations().GroupBy(x => x.LocationName).Select(g => g.First());
            BuildingPlanLocationDto locDto = new BuildingPlanLocationDto()
            {
                ID = 0,
                Nr = 0,
                LocationName = "keine",
            };
            List<BuildingPlanLocationDto> locationList = new List<BuildingPlanLocationDto>();
            locationList.Add(locDto);
            //locList = locList.OrderBy(x => x.Nr);
            locationList.AddRange(locList);
            cobBuildingPlanLocation.DataSource = locationList.OrderBy(x => x.Nr);
            cobBuildingPlanLocation.DataBind();
            cobBuildingPlanLocation.SelectedIndex = 0;

        }
        protected void LoadSelectedGroup()
        {
            if (string.IsNullOrEmpty(Request.QueryString["profileId"]))
            {
                Response.Redirect("~/Content/AccessPlanGroup.aspx");
            }
            else
            {
                var id = Convert.ToInt64(Request.QueryString["profileId"]);
                cobAccessGroupNr.Value = id.ToString();
                cobAccessGroupName.Value = id.ToString();
                txtAccessGroupNr.Text = cobAccessGroupNr.Text;
                txtAccessGroupName.Text = cobAccessGroupName.Text;
                Session["_AccessPlanGroupId"] = Convert.ToInt64(id);
            }
        }
        protected void LoadExistinBuildingPLan(long groupId)
        {
            var accessGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(groupId);
            if (accessGroup != null)
            {
                if (accessGroup.BuildingPlanID != null)
                {
                    cobBuildingPlanLocation.Value = accessGroup.BuildingPlanID.ToString();
                }
            }
        }

        private void LoadBuildingPlanGrid(long groupdId, long buildingPlanId)
        {
            List<BuildingPlanModelRptDto> buildingPlansDtoView = new List<BuildingPlanModelRptDto>();

            if (buildingPlanId > 0)
                buildingPlansDtoView = new AccessPlanGroupReaderViewModel().BuildingPlanModelForAccessGroup(groupdId, buildingPlanId);

            grdBuildingPlanGrid.DataSource = buildingPlansDtoView;
            grdBuildingPlanGrid.DataBind();
        }

        private void LoadBuildingPlanGrid(long groupdId, long buildingPlanId, long filterKey, long filterLevel)
        {
            List<BuildingPlanModelRptDto> buildingPlansDtoView = new List<BuildingPlanModelRptDto>();

            if (buildingPlanId > 0)
                buildingPlansDtoView = new AccessPlanGroupReaderViewModel().BuildingPlanModelForAccessGroup(groupdId, buildingPlanId, filterKey, filterLevel);

            grdBuildingPlanGrid.DataSource = buildingPlansDtoView;
            grdBuildingPlanGrid.DataBind();
        }

        protected void DisableTopControls()
        {
            cobAccessGroupNr.ClientEnabled = false;
            cobAccessGroupName.ClientEnabled = false;
            txtAccessGroupNr.Enabled = false;
            txtAccessGroupName.Enabled = false;
        }
        [System.Web.Services.WebMethod]
        //public static BuildingPlan GetBuildingPlans(long groupId, long Id)
        //{
        public static Dictionary<string, object> GetBuildingPlans(long groupId, long Id)
        {
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();
            BuildingPlan buildingPlan = new BuildingPlan();
            buildingPlan = new BuildingPlanViewModel().GetBuildingPlanByID(Id);
            BuildingPlan buildingPlan2 = new BuildingPlan()
            {
                ID = buildingPlan.ID,
                PlanNr = buildingPlan.PlanNr,
                PlanName = buildingPlan.PlanName,
                PlanDefinition = buildingPlan.PlanDefinition,
                Memo = buildingPlan.Memo,
                LastNodeKey = buildingPlan.LastNodeKey

            };

            var doorsList = GetDoorsListUsingBuildingPlanId(buildingPlan.ID);
            var doorsAssignedList = GetDoorsAssignedReaderUsingBuildingPlanId(buildingPlan.ID);
            var doorAssignedGroup = GetDoorsAssignedGroupUsingGroupIdAndBuildingPlanId(groupId, buildingPlan.ID);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("doorList", doorsList);
            dictionary.Add("doorAssignedReader", doorsAssignedList);
            dictionary.Add("doorAssignedGroup", doorAssignedGroup);
            dictionary.Add("BuildingPlan", buildingPlan2);

            return dictionary;
            //return buildingPlan2
        }
        //get doors list to access the key
        [WebMethod]
        public static IEnumerable<BuildingPlanDto> GetDoorsList(long buildingPlanId)
        {
            return GetDoorsListUsingBuildingPlanId(buildingPlanId);
        }

        private static IEnumerable<BuildingPlanDto> GetDoorsListUsingBuildingPlanId(long buildingPlanId)
        {
            string level = "5";
            var plan = new BuildingPlanViewModel().GetBuildingPlanByID(buildingPlanId);
            var nodeArray = new AccessPlanGroupReaderViewModel().DeserializeBuildingPlan(plan);
            IEnumerable<BuildingPlanDto> doorsList = new List<BuildingPlanDto>();
            doorsList = nodeArray.Where(x => x.level == level);
            return doorsList;
        }

        //get doors list with assigned reader
        [WebMethod]
        public static IEnumerable<AssignedReaderDto> GetDoorsAssignedReader(long buildingPlanId)
        {
            return GetDoorsAssignedReaderUsingBuildingPlanId(buildingPlanId);
        }

        private static IEnumerable<AssignedReaderDto> GetDoorsAssignedReaderUsingBuildingPlanId(long buildingPlanId)
        {
            View_TerminalReader readers = new View_TerminalReader();
            IEnumerable<View_TerminalReader> doorListReader = new List<View_TerminalReader>();
            doorListReader = new ViewTerminalReaderRepository().GetAllTerminals();
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

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        [WebMethod]
        public static void MapAccessPlanGroupDoor(long groupId, long buildingPlanId, List<BuildingPlanNodesDto> buildingPlanNodes)
        {
            var mappedPlans = new AccessPlanGroupDoorMappingRepository().GetMappedGroupByAccessGroupId(groupId);
            foreach (var mappedPlan in mappedPlans)
            {
                new AccessPlanGroupDoorMappingRepository().DeleteMappedAccessPlanGroup(mappedPlan);
            }
            var accessPlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(groupId);
            if (accessPlanGroup == null) return;
            TbAccessPlanGroup group = new TbAccessPlanGroup()
            {
                ID = accessPlanGroup.ID,
                AccessPlanGroupNr = accessPlanGroup.AccessPlanGroupNr,
                AccessPlanGroupName = accessPlanGroup.AccessPlanGroupName,
                BuildingPlanID = buildingPlanId,
                AccessCalendarId = accessPlanGroup.AccessCalendarId
            };
            new AccessPlanGroupRepository().EditAccessPlanGroup(group);

            if ((buildingPlanNodes == null) || !(buildingPlanNodes.Any())) return;
            foreach (var doors in buildingPlanNodes)
            {
                AccessPlanGroupDoorMapping mapped = new AccessPlanGroupDoorMapping()
                {
                    AccessPlanGroupID = groupId,
                    BuildingPlanID = buildingPlanId,
                    LocationID = doors.LocationId,
                    BuildingID = doors.BuildingId,
                    FloorID = doors.FloorId,
                    RoomID = doors.RoomId,
                    DoorID = doors.DoorId
                };
                new AccessPlanGroupDoorMappingRepository().NewMappedAccessPlanGroup(mapped);
            }
        }
        //get doors list with assigned group
        [WebMethod]
        public static IEnumerable<BuildingPlanNodesDto> GetDoorsAssignedGroup(long groupId, long buildingPlanId)
        {
            return GetDoorsAssignedGroupUsingGroupIdAndBuildingPlanId(groupId, buildingPlanId);

        }

        private static IEnumerable<BuildingPlanNodesDto> GetDoorsAssignedGroupUsingGroupIdAndBuildingPlanId(long groupId, long buildingPlanId)
        {
            List<BuildingPlanNodesDto> doorList = new List<BuildingPlanNodesDto>();
            var assignedDoors = new AccessPlanGroupDoorMappingRepository().GetMappedGroupIdBuildingPlanId(groupId, buildingPlanId);
            foreach (var door in assignedDoors)
            {
                BuildingPlanNodesDto nodeDto = new BuildingPlanNodesDto()
                {
                    DoorId = Convert.ToInt64(door.DoorID)
                };
                doorList.Add(nodeDto);
            }
            return doorList;
        }

        protected void grdBuildingPlanGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            long buildingPlanId = 0, groupId = 0;
            Int64.TryParse(Convert.ToString(cobBuildingPlanLocation.Value), out buildingPlanId);
            Int64.TryParse(Convert.ToString(cobAccessGroupNr.Value), out groupId);

            if (e.Parameters.Trim().Split('#').Length == 2)
            {
                string[] parametersArr = e.Parameters.Trim().Split('#');
                long filterKey = 0, filterlevel = 0;
                Int64.TryParse(parametersArr[0], out filterKey);
                Int64.TryParse(parametersArr[1], out filterlevel);

                LoadBuildingPlanGrid(groupId, buildingPlanId, filterKey, filterlevel);
            }
            else
            {
                LoadBuildingPlanGrid(groupId, buildingPlanId);
            }
        }

        [WebMethod]
        public static void SaveAccessGroupGrid(string updateString, long groupId)
        {
            List<String> updateIDs = new List<string>();
            try
            {
                updateIDs = JsonConvert.DeserializeObject<List<string>>(updateString);
            }
            catch (Exception) { }

            var mappedPlans = new AccessPlanGroupDoorMappingRepository().GetMappedGroupByAccessGroupId(groupId);
            foreach (var mappedPlan in mappedPlans)
            {
                new AccessPlanGroupDoorMappingRepository().DeleteMappedAccessPlanGroup(mappedPlan);
            }

            foreach (string updateID in updateIDs)
            {
                string[] updateIDArr = updateID.Split('#');

                if (updateIDArr.Length == 6)
                {
                    long buildingPlanId = 0, locationId = 0, buildingId = 0, floorId = 0, roomId = 0, doorId = 0;
                    Int64.TryParse(updateIDArr[0], out buildingPlanId);
                    Int64.TryParse(updateIDArr[1], out locationId);
                    Int64.TryParse(updateIDArr[2], out buildingId);
                    Int64.TryParse(updateIDArr[3], out floorId);
                    Int64.TryParse(updateIDArr[4], out roomId);
                    Int64.TryParse(updateIDArr[5], out doorId);

                    if (buildingPlanId > 0 && doorId > 0)
                    {
                        AccessPlanGroupDoorMapping mapped = new AccessPlanGroupDoorMapping()
                        {
                            AccessPlanGroupID = groupId,
                            BuildingPlanID = buildingPlanId,
                            LocationID = locationId,
                            BuildingID = buildingId,
                            FloorID = floorId,
                            RoomID = roomId,
                            DoorID = doorId
                        };
                        new AccessPlanGroupDoorMappingRepository().NewMappedAccessPlanGroup(mapped);
                    }
                }
            }
        }

        protected void grdBuildingPlanGrid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "DoorSelected")
            {
                string[] keyArr = (e.KeyValue ?? "").ToString().Split('#');

                if (keyArr.Length == 6)
                {
                    long doorID = 0;
                    Int64.TryParse(keyArr[5], out doorID);
                    if (doorID <= 0)
                        e.Cell.Style.Add("visibility", "hidden !important");
                }
            }
        }
    }
}