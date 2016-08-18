using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using DevExpress.Web;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.Content
{
    public partial class BuildingPlanTermInfo : BasePage
    {
        static List<View_TeminalInformation> listTerminals;
        static IEnumerable<View_TeminalInformation> terminalDetails;
        static List<TerminalReaderDto> listTerminalReader2;
        GlobalSettingsViewModel globalSettingViewModel = new GlobalSettingsViewModel();
        ZUTMain mainCtl = new ZUTMain();
        EncryptionCtl _encryptionCtl = new EncryptionCtl();
        string appURL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTerminalDetails();
                LoadTerminalByID();
                DisableControls();
                AccessProfilesNumber();
                SchaltProfilesNumber();
                HolidayPlanNumber();
                AccessProfileNo();

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/AssignReader.aspx");
        }
        protected void LoadTerminalDetails()
        {
            listTerminals = new List<View_TeminalInformation>();
            View_TeminalInformation terminalInfo = new View_TeminalInformation();
            ViewTerminalInfoRepository terminal = new ViewTerminalInfoRepository();
            listTerminals = terminal.GetAllTerminals();

        }
        protected IEnumerable<View_TeminalInformation> GetTerminalReadersById(int Id)
        {
            return listTerminals.Where(x => x.TerminalID == Id);
        }
        protected void LoadTerminalByID()
        {
            if (Session["TerminalID"] == null) return;

            int terminalID = Convert.ToInt32(Session["TerminalID"]);

            terminalDetails = new List<View_TeminalInformation>();
            terminalDetails = GetTerminalReadersById(terminalID);
            listTerminalReader2 = new List<TerminalReaderDto>();
            foreach (var item in terminalDetails)
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
                    if (item.ReaderAssigned == true)
                    {
                        List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
                        BuildingPlanDto node = new BuildingPlanDto();
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
                var switchProfile = "";
                var accessProfile = "";
                if (item.SwitchProfileActive == true)
                {
                    switchProfile = GetLocalizedText("statusAktiv");
                }
                else
                {
                    switchProfile = GetLocalizedText("statusInaktiv");
                }
                if (item.AccessProfileActive == true)
                {
                    accessProfile = GetLocalizedText("statusAktiv");
                }
                else
                {
                    accessProfile = GetLocalizedText("statusInaktiv");
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
                    ReaderType = item.ReaderType,
                    TerminalDescription = item.TerminalDescription,
                    ReaderNo = item.ReaderNo,
                    Direction = item.Direction,
                    ReaderDirection = _direction,
                    Status = _status,
                    ReaderDescription = item.ReaderDescription,
                    ReaderAssigned = item.ReaderAssigned,
                    RelayTime = item.RelayTime,
                    BuildingName = buildingName,
                    FloorName = floorName,
                    RoomName = roomName,
                    DoorName = doorName,
                    SwitchProfile = switchProfile,
                    AccessProfile = accessProfile
                };

                listTerminalReader2.Add(terminalDto);
            }
            //grvTerminalInfo.DataSource = terminalDetails;
            grvTerminalInfo.DataSource = listTerminalReader2;
            grvTerminalInfo.DataBind();

            View_TeminalInformation terminalInfo = new View_TeminalInformation();
            terminalInfo = terminalDetails.FirstOrDefault();
            if (terminalInfo == null) return;
            txtTerminalId.Text = terminalInfo.TermID.ToString();
            txtTerminalDescription.Text = terminalInfo.TerminalDescription.ToString();
            txtAccessTerminal.Text = terminalInfo.TermType.ToString();

        }
        protected void AccessProfilesNumber()
        {
            if (!string.IsNullOrEmpty(txtTerminalId.Text))
            {
                int terminalId = Convert.ToInt32(txtTerminalId.Text.Trim());
                IEnumerable<RV_AccessProfilesPerTerminal> profilesNumber = new List<RV_AccessProfilesPerTerminal>();
                vwAccessProfileRepository profiles = new vwAccessProfileRepository();
                profilesNumber = profiles.GetvwAccessProfiles().Where(x => x.TermID == terminalId);

                var grpProfilesNumber = profilesNumber.GroupBy(x => x.AccessProfileNo);
                //select first item from the group
                var distinctProfileNumbers = grpProfilesNumber.Select(grp => grp.OrderBy(item => item.AccessProfileNo).First());

                int profileNo = distinctProfileNumbers.Count();
                lblAccessProfiles.Text = profileNo.ToString();
            }
        }

        protected void SchaltProfilesNumber()
        {
            if (!string.IsNullOrEmpty(txtTerminalId.Text))
            {
                int terminalId = Convert.ToInt32(txtTerminalId.Text.Trim());
                IEnumerable<RV_SwitchProfileGroupedPerTerminal> SchaltProfilesNumber = new List<RV_SwitchProfileGroupedPerTerminal>();
                vwSwitchProfileRepository switchProfiles = new vwSwitchProfileRepository();
                SchaltProfilesNumber = switchProfiles.GetvwSwitchProfile().Where(x => x.TermID == terminalId);

                var grpSchlatProfilesNumber = SchaltProfilesNumber.GroupBy(x => x.Profile_Nr);
                //select first item from the group
                var distinctSchaltProfileNumbers = grpSchlatProfilesNumber.Select(grp => grp.OrderBy(item => item.Profile_Nr).First());

                int profileCount = distinctSchaltProfileNumbers.Count();
                lblSchaltProfiles.Text = profileCount.ToString();
            }
        }
        protected void HolidayPlanNumber()
        {
            if (!string.IsNullOrEmpty(txtTerminalId.Text))
            {
                int terminalId = Convert.ToInt32(txtTerminalId.Text.Trim());
                IEnumerable<RV_HolidayPlanPerTerminal> HolidayPlanNumber = new List<RV_HolidayPlanPerTerminal>();
                VwHolidayCalendeRepository2 HolidayPlan = new VwHolidayCalendeRepository2();
                HolidayPlanNumber = HolidayPlan.GetVwHolidayCalende().Where(x => x.TermID == terminalId);
                var grpHolidayPlanNumbers = HolidayPlanNumber.GroupBy(x => x.AccessPlanNumber);
                var distinctHolidayPlanNumbers = grpHolidayPlanNumbers.Select(grp => grp.OrderBy(Item => Item.AccessPlanNumber).First());
                int HolidayPlanNumbersCount = distinctHolidayPlanNumbers.Count();
                lblHolidaySchedule.Text = HolidayPlanNumbersCount.ToString();
            }
        }
        protected void AccessProfileNo()
        {
            if (!string.IsNullOrEmpty(txtTerminalId.Text))
            {
                int terminalId = Convert.ToInt32(txtTerminalId.Text.Trim());
                IEnumerable<RV_AccessProfilesPerTerminal> AccessProfileNo = new List<RV_AccessProfilesPerTerminal>();
                RV_AccessProfilesPerTerminalRepository AccessProfile = new RV_AccessProfilesPerTerminalRepository();
                AccessProfileNo = AccessProfile.GetRV_AccessProfilesPerTerminal().Where(x => x.TermID == terminalId);
                var grpAccessProfileNos = AccessProfileNo.GroupBy(x => x.AccessProfileNo);
                var distictAccessProfileNo = grpAccessProfileNos.Select(grp => grp.OrderBy(Item => Item.AccessProfileNo).First());
                int AccessProfileNoCount = distictAccessProfileNo.Count();
                lblAccessProfileHolidays.Text = AccessProfileNoCount.ToString();
            }
        }
        protected void DisableControls()
        {
            txtAccessTerminal.Enabled = false;
            txtTerminalDescription.Enabled = false;
            txtTerminalId.Enabled = false;
        }
        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void PassPageOrigin()
        {
            HttpContext.Current.Session["FromPage"] = "BuildingPlanTermInfo.aspx";

        }

        protected void btnAccess_Profile_Click(object sender, EventArgs e)
        {
            Session["FromPage"] = "BuildingPlanTermInfo.aspx";
            Response.Redirect("/Content/BuildingPlanTermInfoAccessProfile.aspx");
        }

        protected void btnSwitch_Profile_Click(object sender, EventArgs e)
        {
            Session["FromPage"] = "BuildingPlanTermInfo.aspx";
            Response.Redirect("/Content/BuildingPlanTermInfoSwitchProfile.aspx");
        }

        protected void grvTerminalInfo_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            var readerType = e.GetValue("Direction");
            try
            {


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
                //Debug.WriteLine(ex.Message);
            }
        }

        protected void BuildingPlanHolidayPlanAccessProfilesPerTerminal_Click(object sender, EventArgs e)
        {
            Session["FromPage"] = "BuildingPlanTermInfo.aspx";
            Response.Redirect("/Content/BuildingPlanHolidayPlanAccessProfilesPerTerminal.aspx");
        }

        protected void BuildingPlanHolidayPlanSwitchProfilesPerTerminal_Click(object sender, EventArgs e)
        {
            Session["FromPage"] = "BuildingPlanTermInfo.aspx";
            Response.Redirect("/Content/BuildingPlanHolidayPlanSwitchProfilesPerTerminal.aspx");
        }

        public IEnumerable<RV_HolidayPlanAccessProfilesPerTerminal> AccessProfileNos { get; set; }

        protected void ImageButtonTermConfig_Click(object sender, ImageClickEventArgs e)
        {
            if (!mainCtl.allowTMKAppCheck()) return;
            GetGlobalSetting("TMK_URL");

            if (appURL.Trim() == "") return;

            TerminalRepository terminalRepo = new TerminalRepository();
            if (string.IsNullOrEmpty(txtTerminalId.Text)) return;
            var termID = Convert.ToInt64(txtTerminalId.Text.Trim());
            View_TeminalInformation terminal = new View_TeminalInformation();
            terminal = listTerminals.Where(x => x.TermID == termID).FirstOrDefault();
            var terminalID = terminal.TerminalID;
            var terminalTypeId = terminal.TerminalTypeID;
            var terminalInstance = terminalRepo.GetTerminalById(Convert.ToInt64(terminalTypeId));
            var terminalPage = terminalInstance.TerminalPage;
            var pageOrigin = 4;//BuildingPlanTermInfo.aspx

            string redirectLocation = String.Format("{0}?id={1}&sTd={2}&ChildID={2}&pageOrigin={3}", terminalPage, terminalTypeId, terminalID, pageOrigin);
            Response.Redirect(String.Format("http://{0}/Content/Login.aspx?user={1}&pass={2}&moveTo={3}", appURL,
                Session["Pers_LoginName"].ToString(), HttpUtility.UrlEncode(_encryptionCtl.Encrypt(Session["Pers_LoginPassword"].ToString())),
                HttpUtility.UrlEncode(_encryptionCtl.Encrypt(redirectLocation))));
        }
        public void GetGlobalSetting(string settingName)
        {
            appURL = globalSettingViewModel.GetGetGlobalSettingByName(settingName);
        }
    }
}