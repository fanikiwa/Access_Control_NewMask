using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.ViewModels;
using DevExpress.Web;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System.Globalization;
using System.Diagnostics;
using Newtonsoft.Json;
using Access_Control_NewMask.Dtos;
using System.Web.Services;

namespace Access_Control_NewMask.Content
{
    public partial class AccessProfile : BasePage
    {
        #region properties

        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsAccessProfile_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsAccessProfile_PMode"] = value;
            }
        }
        private ZuttritProfileViewModel _zuttritProfileViewModel = new ZuttritProfileViewModel();
        ZuttritProfile _zuttritProfile = new ZuttritProfile();
        ZuttritProfilesTimeFrame _zuttritProfilesTimeFrame = new ZuttritProfilesTimeFrame();
        AccessGroup _accessGroup = new AccessGroup();
        static List<AccessGroup> listAccessGroup;
        static List<ZuttritProfile> listZuttritProfile;
        static List<ZuttritProfilesTimeFrame> listZuttritProfilesTimeFrame;
        static List<ZuttritProfile> listZuttritProfileGroupFiltered;

        #endregion
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsAccessProfile, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnEntSave.Enabled = false; btnEntNew.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;

            RebindGrids();
            this.Form.DefaultButton = this.btnEntSave.UniqueID;

            if (!IsPostBack)
            {
                //load empty rows
                BindControls();
                loadgrdAccessProfileList();

                //SearchAllProfileGroups();

                hiddenFieldFormMode.Value = "Normal";

                if (Session["AccessPlanAction"] != null)
                {
                    if (Session["AccessPlanAction"].ToString() == "New")
                    {
                        changeFormModeToAddMode();
                    }
                }
            }
        }

        private void changeFormModeToAddMode()
        {
            hiddenFieldFormMode.Value = "AddMode";
            Session["AccessPlanAction"] = "";

            btnEntNew.Enabled = false;
            ddlGroupProfileNo1.Focus();
        }
        protected void RebindGrids()
        {
            if (Session["grdAccessProfilet"] != null)
            {
                var ProfileList = (List<GroupProfileDto>)Session["grdAccessProfilet"];
                grdAccessProfileList.DataSource = ProfileList;
                grdAccessProfileList.DataBind();

            }

        }
        public void BindControls()
        {
            listAccessGroup = new List<AccessGroup>();
            LoadExistingAccessGroups(ref listAccessGroup);

            if (listAccessGroup.Count > 0)
            {
                ddlGroupProfileNo1.DataSource = listAccessGroup;
                ddlGroupProfileNo1.DataBind();
                ddlGroupProfileDescription1.DataSource = listAccessGroup;
                ddlGroupProfileDescription1.DataBind();
            }

            if (listAccessGroup.Count == 0)
            {
                listAccessGroup.Add(new AccessGroup() { Id = 0, AccessGroupNumber = 0, AccessGroupName = Resources.LocalizedText.None });
                ddlGroupProfileNo1.DataSource = listAccessGroup;
                ddlGroupProfileNo1.DataBind();
                ddlGroupProfileDescription1.DataSource = listAccessGroup;
                ddlGroupProfileDescription1.DataBind();
            }


            listZuttritProfile = new List<ZuttritProfile>();
            listZuttritProfileGroupFiltered = new List<ZuttritProfile>();
            LoadExistingAccessProfiles(ref listZuttritProfile);
            if (listZuttritProfile.Count > 0)
            {
                listZuttritProfile.Insert(0, new ZuttritProfile() { ID = 0, AccessProfileNo = 0, AccessProfileID = Resources.LocalizedText.None, AccessDescription = Resources.LocalizedText.None });
                ddlAccessProfileNo.DataSource = listZuttritProfile;
                ddlAccessProfileNo.DataBind();
                ddlAccessProfileID.DataSource = listZuttritProfile;
                ddlAccessProfileID.DataBind();
                ddlAccessDescription.DataSource = listZuttritProfile;
                ddlAccessDescription.DataBind();
                chkDisplayProfiles.Checked = false;
                LoadZuttritProfileTimeFrames(0);

                listZuttritProfilesTimeFrame = new List<ZuttritProfilesTimeFrame>();
                if (listZuttritProfilesTimeFrame.Count == 0)
                {
                    listZuttritProfilesTimeFrame.Add(new ZuttritProfilesTimeFrame() { ID = 0 });
                }
            }
        }

        public void LoadExistingAccessGroups(ref List<AccessGroup> listAccessGroup)
        {
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            listAccessGroup.Add(new AccessGroup() { Id = 0, AccessGroupNumber = 0, AccessGroupName = Resources.LocalizedText.None });
            listAccessGroup.AddRange(accessGroupRepository.GetAllAccessProfileGroups().Where(x => x.AccessGroupType == 1));


        }

        public void LoadExistingAccessProfiles(ref List<ZuttritProfile> listAccessProfiles)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            listAccessProfiles.AddRange(zuttritProfileViewModel.ZuttritProfiles());
        }


        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static ZuttritProfile GetLatestProfileNo(string dummyVar)
        {
            String Dummy = dummyVar;
            int nextProfId;
            ZuttritProfileRepository zuttritProfilesRepository = new ZuttritProfileRepository();
            List<ZuttritProfile> listZuttritProfiles = new List<ZuttritProfile>();
            ZuttritProfile zuttritProfile = new ZuttritProfile();
            ZuttritProfile zuttritProfile2 = new ZuttritProfile();
            try
            {
                listZuttritProfiles = zuttritProfilesRepository.GetAllZuttritProfiles();
                if (listZuttritProfiles.Count == 0)
                {
                    zuttritProfile.AccessProfileNo = 1;
                    zuttritProfile2.AccessProfileNo = zuttritProfile.AccessProfileNo;
                }
                else
                {
                    zuttritProfile = listZuttritProfiles.OrderByDescending(i => i.AccessProfileNo).FirstOrDefault();
                    nextProfId = zuttritProfile.AccessProfileNo;
                    nextProfId++;
                    zuttritProfile2.AccessProfileNo = nextProfId;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return zuttritProfile2;
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static ZuttritProfile CreateAccessProfile(int groupID, int accessProfileNo, string accessProfileID, string accessDescription, bool displayProfiles, string memonotes, string timeFrames, string ASPxColorEditBackColor, string ASPxColorEditForeColor)
        {
            List<ZuttritProfile> listZuttritProfile = new List<ZuttritProfile>();
            ZuttritProfile zuttritProfile = new ZuttritProfile() { };
            ZuttritProfile zuttritProfile2 = new ZuttritProfile();
            try
            {
                var TimeFramesObject = JsonConvert.DeserializeObject<List<ZuttritProfilesTimeFrame>>(timeFrames);
                int level = 1;
                foreach (var timeFrame in TimeFramesObject)
                {
                    timeFrame.Level = level;
                    level++;
                }
                ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
                zuttritProfile = new ZuttritProfile() { GroupID = groupID, AccessProfileNo = accessProfileNo, AccessProfileID = accessProfileID, AccessDescription = accessDescription, DisplayProfiles = displayProfiles, Memo = memonotes, ZuttritProfilesTimeFrames = TimeFramesObject, ForeColour = ASPxColorEditForeColor, BackColour = ASPxColorEditBackColor };
                zuttritProfileViewModel.CreateZuttritProfile(zuttritProfile);
                zuttritProfile = zuttritProfileViewModel.GetZuttritProfileByAccessProfileNo(accessProfileNo);
                listZuttritProfile.Add(zuttritProfile);
                zuttritProfile2.ID = zuttritProfile.ID;
                zuttritProfile2.GroupID = zuttritProfile.GroupID;
                zuttritProfile2.AccessProfileNo = zuttritProfile.AccessProfileNo;
                zuttritProfile2.AccessProfileID = zuttritProfile.AccessProfileID;
                zuttritProfile2.AccessDescription = zuttritProfile.AccessDescription;
                zuttritProfile2.DisplayProfiles = zuttritProfile.DisplayProfiles;
                zuttritProfile2.Memo = zuttritProfile.Memo;
                zuttritProfile2.BackColour = zuttritProfile.BackColour;
                zuttritProfile2.ForeColour = zuttritProfile.ForeColour;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            HttpContext.Current.Session["AccessProfile"] = zuttritProfile2;

            return zuttritProfile2;
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static ZuttritProfile UpdateAccessProfile(int Id, int accessProfileNo, string accessProfileID, string accessDescription, bool displayProfiles, string memonotes, string strTimeFrames, string ASPxColorEditBackColor, string ASPxColorEditForeColor)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            listZuttritProfile = zuttritProfileViewModel.ZuttritProfiles();
            var zuttritProfile = zuttritProfileViewModel.GetZuttritProfileByID(Id);
            var TimeFramesObject = JsonConvert.DeserializeObject<List<ZuttritProfilesTimeFrame>>(strTimeFrames);
            int level = 1;
            foreach (var timeFrame in TimeFramesObject)
            {
                timeFrame.Level = level;
                level++;
            }

            zuttritProfile.AccessProfileNo = accessProfileNo;
            zuttritProfile.AccessProfileID = accessProfileID;
            zuttritProfile.AccessDescription = accessDescription;
            zuttritProfile.DisplayProfiles = displayProfiles;
            zuttritProfile.Memo = memonotes;
            zuttritProfile.BackColour = ASPxColorEditBackColor;
            zuttritProfile.ForeColour = ASPxColorEditForeColor;
            zuttritProfile.ZuttritProfilesTimeFrames = TimeFramesObject;// JsonConvert.DeserializeObject<List<ZuttritProfilesTimeFrame>>(strTimeFrames);
            zuttritProfileViewModel.UpdateZuttritProfile(zuttritProfile);

            //remove initial list from memory then add the new one
            listZuttritProfile.RemoveAll(x => x.ID == Id);
            listZuttritProfile.Add(zuttritProfile);

            //return updated entity to client
            ZuttritProfile zuttritProfile1 = new ZuttritProfile();
            zuttritProfile1.ID = zuttritProfile.ID;
            zuttritProfile1.AccessProfileNo = zuttritProfile.AccessProfileNo;
            zuttritProfile1.AccessProfileID = zuttritProfile.AccessProfileID;
            zuttritProfile1.AccessDescription = zuttritProfile.AccessDescription;
            zuttritProfile1.DisplayProfiles = zuttritProfile.DisplayProfiles;
            zuttritProfile1.Memo = zuttritProfile.Memo;
            return zuttritProfile1;
        }

        [System.Web.Services.WebMethod]
        public static List<ZuttritProfile> GetFilteredAccessGroupProfile(long groupID)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            ZuttritProfile zuttritProfile2 = null;
            List<ZuttritProfile> listZuttritProfile = new List<ZuttritProfile>();
            List<ZuttritProfile> listZuttritProfile2 = new List<ZuttritProfile>();
            try
            {
                listZuttritProfile = zuttritProfileViewModel.ZuttritProfiles().FindAll(x => x.GroupID == groupID);

                foreach (ZuttritProfile zpf in listZuttritProfile)
                {
                    zuttritProfile2 = new ZuttritProfile();
                    zuttritProfile2.ID = zpf.ID;
                    zuttritProfile2.GroupID = zpf.GroupID;
                    zuttritProfile2.AccessProfileNo = zpf.AccessProfileNo;
                    zuttritProfile2.AccessProfileID = zpf.AccessProfileID;
                    zuttritProfile2.AccessDescription = zpf.AccessDescription;
                    zuttritProfile2.DisplayProfiles = zpf.DisplayProfiles;
                    zuttritProfile2.Memo = zpf.Memo;
                    listZuttritProfile2.Add(zuttritProfile2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return listZuttritProfile2;
        }

        [System.Web.Services.WebMethod]
        public static List<ZuttritProfile> GetAllAccessGroupProfile(int Setcontrols)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            ZuttritProfile zuttritProfile2 = null;
            List<ZuttritProfile> listZuttritProfile = new List<ZuttritProfile>();
            List<ZuttritProfile> listZuttritProfile2 = new List<ZuttritProfile>();
            try
            {
                listZuttritProfile = zuttritProfileViewModel.ZuttritProfiles();

                foreach (ZuttritProfile zpf in listZuttritProfile)
                {
                    zuttritProfile2 = new ZuttritProfile();
                    zuttritProfile2.ID = zpf.ID;
                    zuttritProfile2.GroupID = zpf.GroupID;
                    zuttritProfile2.AccessProfileNo = zpf.AccessProfileNo;
                    zuttritProfile2.AccessProfileID = zpf.AccessProfileID;
                    zuttritProfile2.AccessDescription = zpf.AccessDescription;
                    zuttritProfile2.DisplayProfiles = zpf.DisplayProfiles;
                    zuttritProfile2.Memo = zpf.Memo;
                    listZuttritProfile2.Add(zuttritProfile2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            listZuttritProfile2.Insert(0, new ZuttritProfile() { ID = 0, AccessProfileNo = 0, AccessProfileID = "keine", AccessDescription = "keine" });
            return listZuttritProfile2;
        }

        [WebMethod]
        public static object GetProfilesById(int id)
        {
            var _ZuttritProfileRepository = new ZuttritProfileRepository().GetZuttritProfileByAccessProfileNo(id);
            if (_ZuttritProfileRepository != null)
                return new
                {


                    _ZuttritProfileRepository.ID,
                    _ZuttritProfileRepository.GroupID,
                    _ZuttritProfileRepository.AccessProfileNo,
                    _ZuttritProfileRepository.AccessProfileID,
                    _ZuttritProfileRepository.AccessDescription,
                    _ZuttritProfileRepository.Memo,
                };
            return null;
        }

        [System.Web.Services.WebMethod]
        public static string GetSelectedProfileGroup(string accessProfileID)
        {
            AccessGroup selectedGroup = new AccessGroup();
            ZuttritProfile accessProfile = null;
            AccessGroupViewModel accessGroupViewModel = new AccessGroupViewModel();
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();


            accessProfile = zuttritProfileViewModel.GetZuttritProfileByID(Convert.ToInt32(accessProfileID));

            if (accessProfile != null)
            {
                selectedGroup = accessGroupViewModel.GetGroupByGroupID(Convert.ToInt64(accessProfile.GroupID));
            }

            return selectedGroup.Id.ToString();
        }

        [System.Web.Services.WebMethod]

        public static ZuttritProfile GetAccessProfile(int Id)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            ZuttritProfile zuttritProfile2 = new ZuttritProfile();
            List<ZuttritProfile> listZuttritProfile = new List<ZuttritProfile>();
            listZuttritProfile = zuttritProfileViewModel.ZuttritProfiles();
            try
            {
                zuttritProfile2.ID = listZuttritProfile.Find(x => x.ID == Id).ID;
                zuttritProfile2.GroupID = listZuttritProfile.Find(x => x.ID == Id).GroupID;
                zuttritProfile2.AccessProfileNo = listZuttritProfile.Find(x => x.ID == Id).AccessProfileNo;
                zuttritProfile2.AccessProfileID = listZuttritProfile.Find(x => x.ID == Id).AccessProfileID;
                zuttritProfile2.AccessDescription = listZuttritProfile.Find(x => x.ID == Id).AccessDescription;
                zuttritProfile2.DisplayProfiles = listZuttritProfile.Find(x => x.ID == Id).DisplayProfiles;
                zuttritProfile2.Memo = listZuttritProfile.Find(x => x.ID == Id).Memo;
                zuttritProfile2.ForeColour = listZuttritProfile.Find(x => x.ID == Id).ForeColour;
                zuttritProfile2.BackColour = listZuttritProfile.Find(x => x.ID == Id).BackColour;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return zuttritProfile2;
        }

        [System.Web.Services.WebMethod]
        public static List<ZuttritProfile> DeleteSelectedAccessProfile(int ID, long GroupID)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            ZuttritProfileRepository zuttritProfileRepo = new ZuttritProfileRepository();
            List<ZuttritProfile> lstProfiles2 = new List<ZuttritProfile>(); ;
            ZuttritProfile zuttritProfile = new ZuttritProfile();
            ZuttritProfile zuttritProfile2 = null;
            HttpContext.Current.Session["CurrentGroupInDeletion"] = GroupID;
            try
            {
                zuttritProfile = zuttritProfileViewModel.GetZuttritProfileByID(ID);
                zuttritProfileViewModel.DeleteZuttritProfile(zuttritProfile);

                List<ZuttritProfile> lstProfiles1 = new List<ZuttritProfile>();
                lstProfiles1 = zuttritProfileRepo.GetProfilesByGroupId(GroupID);

                foreach (ZuttritProfile zpf in lstProfiles1)
                {
                    zuttritProfile2 = new ZuttritProfile();
                    zuttritProfile2.ID = zpf.ID;
                    zuttritProfile2.GroupID = zpf.GroupID;
                    zuttritProfile2.AccessProfileNo = zpf.AccessProfileNo;
                    zuttritProfile2.AccessProfileID = zpf.AccessProfileID;
                    zuttritProfile2.AccessDescription = zpf.AccessDescription;
                    zuttritProfile2.DisplayProfiles = zpf.DisplayProfiles;
                    zuttritProfile2.Memo = zpf.Memo;
                    lstProfiles2.Add(zuttritProfile2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            HttpContext.Current.Session["ProfileListAfterDeletion"] = 1;
            return lstProfiles2;
        }
        public void LoadZuttritProfileTimeFrames(int accessProfID)
        {
            ZuttritProfilesTimeFrameViewModel zuttritProfilesTimeFrameViewModel = new ZuttritProfilesTimeFrameViewModel();
            List<ZuttritProfilesTimeFrame> listZuttritProfilesTimeFrame = new List<ZuttritProfilesTimeFrame>();
            ZuttritProfileRepository zuttritProfilesRepository = new ZuttritProfileRepository();
            List<ZuttritProfile> listZuttritProfiles = new List<ZuttritProfile>();
            listZuttritProfiles = zuttritProfilesRepository.GetAllZuttritProfiles();
            ZuttritProfile zuttritProfile = new ZuttritProfile();
            zuttritProfile = listZuttritProfiles.Find(x => x.ID == accessProfID);
            if (accessProfID == 0)
            {
                listZuttritProfilesTimeFrame = zuttritProfilesTimeFrameViewModel.GetZuttritProfileTimeFrames();
            }
            if (accessProfID == -15)
            {
                listZuttritProfilesTimeFrame = zuttritProfilesTimeFrameViewModel.GetNewZuttritProfileTimeFrames();
            }
            else
            {
                listZuttritProfilesTimeFrame = zuttritProfilesTimeFrameViewModel.GetZuttritProfilesTimeFramesByAccessProfID(accessProfID);

                if (listZuttritProfilesTimeFrame.Count < 10)
                {
                    int curr = listZuttritProfilesTimeFrame.Count;
                    int i = -10;
                    for (i = -10; i < (0 - curr); i++)
                    {
                        var zuttritProfileTimeFrame = new ZuttritProfilesTimeFrame
                        {
                            AccessProfID = 0,
                            ProfilAktiv = false,
                            MonFrom = Convert.ToDateTime(null),
                            MonTo = Convert.ToDateTime(null),
                            TueFrom = Convert.ToDateTime(null),
                            TueTo = Convert.ToDateTime(null),
                            WedFrom = Convert.ToDateTime(null),
                            WedTo = Convert.ToDateTime(null),
                            ThurFrom = Convert.ToDateTime(null),
                            ThurTo = Convert.ToDateTime(null),
                            FriFrom = Convert.ToDateTime(null),
                            FriTo = Convert.ToDateTime(null),
                            SatFrom = Convert.ToDateTime(null),
                            SatTo = Convert.ToDateTime(null),
                            SunFrom = Convert.ToDateTime(null),
                            SunTo = Convert.ToDateTime(null),
                            ZuttritProfile = null
                        };
                        zuttritProfileTimeFrame.ID = i;
                        listZuttritProfilesTimeFrame.Add(zuttritProfileTimeFrame);
                    }
                }
            }
            bool emptyGrid = false;
            foreach (ZuttritProfilesTimeFrame timeframe in listZuttritProfilesTimeFrame)
            {
                if (timeframe.ID > 0)
                {
                    emptyGrid = false;
                    break;
                }
            }
            foreach (ZuttritProfilesTimeFrame timeframe in listZuttritProfilesTimeFrame)
            {
                if ((timeframe.ID >= -30) && (timeframe.ID <= -20))
                {
                    emptyGrid = true;
                    break;
                }
            }
            if (emptyGrid == true)
            {
                grdZuttritProfileTimeFrames.DataSource = new List<ZuttritProfilesTimeFrame>();
                grdZuttritProfileTimeFrames.DataBind();
            }
            else if (emptyGrid == false)
            {
                grdZuttritProfileTimeFrames.DataSource = listZuttritProfilesTimeFrame;
                grdZuttritProfileTimeFrames.DataBind();
            }
        }

        protected void loadgrdAccessProfileList()
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            List<ZuttritProfile> lst = new List<ZuttritProfile>();
            ZuttritProfile zuttritProfile = new ZuttritProfile();
            List<GroupProfileDto> dtolist = new List<GroupProfileDto>();
            GroupProfileDto groupProfileDto = null;
            lst = zuttritProfileViewModel.ZuttritProfiles().FindAll(x => x.ID > 0);

            foreach (ZuttritProfile zpf in lst)
            {
                groupProfileDto = new GroupProfileDto();
                groupProfileDto.GroupNo = Convert.ToInt64(zpf.AccessGroup.AccessGroupNumber);
                groupProfileDto.AccessProfileNo = zpf.AccessProfileNo;
                groupProfileDto.AccessProfileID = zpf.AccessProfileID;
                groupProfileDto.AccessDescription = zpf.AccessDescription;
                groupProfileDto.GroupDescription = zpf.AccessGroup.AccessGroupName;
                dtolist.Add(groupProfileDto);
            }
            grdAccessProfileList.DataSource = dtolist;
            grdAccessProfileList.DataBind();
            grdSearchProfiles.DataSource = dtolist;
            grdSearchProfiles.DataBind();

            Session["grdAccessProfilet"] = dtolist;

            if (ddlAccessProfileNo.SelectedItem != null)
            {
                txtAccessProfileNo.Text = ddlAccessProfileNo.SelectedItem.Text;
            }
            if (ddlAccessProfileID.SelectedItem != null)
            {
                txtAccessProfileID.Text = ddlAccessProfileID.SelectedItem.Text;
            }
            if (ddlAccessDescription.SelectedItem != null)
            {
                txtAccessDescription.Text = ddlAccessDescription.SelectedItem.Text;
            }

        }

        private void toggleGridState(bool state)
        {
            grdZuttritProfileTimeFrames.Enabled = state;
        }

        protected void grdZuttritProfileTimeFrames_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ent"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                var redirectedFrom = Request.QueryString["ent"].ToLower();

                switch (redirectedFrom)
                {
                    case "1":
                        Response.Redirect("AccessPlanAccessCalender.aspx");
                        break;

                    case "2":
                        Response.Redirect("AccessKalendar.aspx");
                        break;
                    case "3":
                        var profileId = Request.QueryString["profileId"];
                        Response.Redirect("VisitorPlanVisitorCalender.aspx?profileId=" + profileId);
                        break;
                    case "4":
                        //var profileId = Request.QueryString["profileId"];
                        //Response.Redirect("VisitorPlanVisitorCalender.aspx?profileId=" + profileId);
                        Response.Redirect("Holidayplan.aspx");
                        break;

                    default:
                        Response.Redirect("Settings.aspx");
                        break;
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string Redirect_to_AccessControl(string pageOrigin, string profileId)
        {
            string url = "";
            int PageOrigin = 0;
            if (!int.TryParse(pageOrigin, out PageOrigin)) PageOrigin = 0;
            switch (PageOrigin)
            {
                case 0:
                    url = "";
                    break;
                case 1:
                    url = "AccessPlanAccessCalender.aspx";
                    break;
                case 2:
                    url = "AccessKalendar.aspx";
                    break;
                case 3:
                    url = "VisitorPlanVisitorCalender.aspx?profileId=" + profileId;
                    break;
                case 4:
                    url = "Holidayplan.aspx";
                    break;
                case 5:
                    url = "AccessPlanHolidaySchedule.aspx";
                    break;
                case 6:
                    url = "AccessGroupHolidaySchedule.aspx?profileId=" + profileId;
                    break;
                default:
                    url = "Settings.aspx";
                    break;
            }
            return url;
        }
        public static AccessProfileAccessGroupMapping GetGroupIDFromProfileID(string AccessProfID)
        {
            AccessGroupProfileMappingRepository rep = new AccessGroupProfileMappingRepository();
            AccessProfileAccessGroupMapping map = new AccessProfileAccessGroupMapping();
            try
            {
                map = rep.GetMappingByAccessProfId(Convert.ToInt64(AccessProfID));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return map;
        }

        [System.Web.Services.WebMethod]
        public static void SaveProfileGroupMapping(string groupID, string accessProfID)
        {
            AccessGroupProfileMappingRepository rep = new AccessGroupProfileMappingRepository();
            AccessProfileAccessGroupMapping map = new AccessProfileAccessGroupMapping();
            map.AccessGroupID = Convert.ToInt64(groupID);
            map.AccessProfileID = Convert.ToInt64(accessProfID);
            try
            {
                rep.NewAccessProfileAccessGroupMapping(map);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [System.Web.Services.WebMethod]
        public static ZuttritProfile GetUserSelectedGridAccessProfile(long ProfileNo, long GroupID)
        {
            ZuttritProfileRepository zpfRepo = new ZuttritProfileRepository();
            ZuttritProfile zpf1 = new ZuttritProfile();
            ZuttritProfile zpf2 = new ZuttritProfile();
            try
            {
                zpf1 = zpfRepo.GetProfileIDByGroupIdAndProfileNo(GroupID, ProfileNo);
                zpf2.ID = zpf1.ID;
                zpf2.GroupID = zpf1.GroupID;
                zpf2.AccessProfileNo = zpf1.AccessProfileNo;
                zpf2.AccessProfileID = zpf1.AccessProfileID;
                zpf2.AccessDescription = zpf1.AccessDescription;
                zpf2.DisplayProfiles = zpf1.DisplayProfiles;
                zpf2.Memo = zpf1.Memo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return zpf2;
        }
        public static string GetGlobalSetting(string settingName)
        {
            GlobalSettingsViewModel globalSettingViewModel = new GlobalSettingsViewModel();
            string appURL = globalSettingViewModel.GetGetGlobalSettingByName(settingName);
            return appURL;
        }

        protected void grdSearchProfiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            loadgrdAccessProfileList();
        }

        protected void grdZuttritProfileTimeFrames_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadZuttritProfileTimeFrames(Convert.ToInt32(e.Parameters));
        }

        protected void grdAccessProfileList_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            loadgrdAccessProfileList();

        }

        protected void ddlAccessProfileNo_Callback(object sender, CallbackEventArgsBase e)
        {
            string GroupId = e.Parameter;
            listZuttritProfileGroupFiltered = new List<ZuttritProfile>();
            listZuttritProfileGroupFiltered = GetFilteredAccessGroupProfile(Convert.ToInt32(GroupId));
            ddlAccessProfileNo.DataSource = listZuttritProfileGroupFiltered;
            ddlAccessProfileNo.DataBind();

            if (!string.IsNullOrEmpty(e.Parameter) && ddlAccessProfileNo.Items.FindByValue(e.Parameter.ToString()) != null)
            {
                ddlAccessProfileNo.Value = e.Parameter.ToString();
                try
                {
                    ddlAccessProfileNo.SelectedIndex = ddlAccessProfileNo.Items.FindByValue(e.Parameter.ToString()).Index;
                }
                catch (Exception)
                { }
            }
            else if (ddlAccessProfileNo.Items.Count > 0)
            {
                ddlAccessProfileNo.Value = ddlAccessProfileNo.Items[0].Value;
                ddlAccessProfileNo.SelectedIndex = 0;
            }
        }

        protected void ddlAccessProfileID_Callback(object sender, CallbackEventArgsBase e)
        {
            string GroupId = e.Parameter;
            listZuttritProfileGroupFiltered = new List<ZuttritProfile>();
            listZuttritProfileGroupFiltered = GetFilteredAccessGroupProfile(Convert.ToInt64(GroupId));
            ddlAccessProfileID.DataSource = listZuttritProfileGroupFiltered;
            ddlAccessProfileID.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter) && ddlAccessProfileID.Items.FindByValue(e.Parameter.ToString()) != null)
            {
                ddlAccessProfileID.Value = e.Parameter.ToString();
                try
                {
                    ddlAccessProfileID.SelectedIndex = ddlAccessProfileID.Items.FindByValue(e.Parameter.ToString()).Index;
                }
                catch (Exception)
                { }
            }
            else if (ddlAccessProfileID.Items.Count > 0)
            {
                ddlAccessProfileID.Value = ddlAccessProfileID.Items[0].Value;
                ddlAccessProfileID.SelectedIndex = 0;
            }
        }

        protected void ddlAccessDescription_Callback(object sender, CallbackEventArgsBase e)
        {
            string GroupId = e.Parameter;
            listZuttritProfileGroupFiltered = new List<ZuttritProfile>();
            listZuttritProfileGroupFiltered = GetFilteredAccessGroupProfile(Convert.ToInt64(GroupId));
            ddlAccessDescription.DataSource = listZuttritProfileGroupFiltered;
            ddlAccessDescription.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter) && ddlAccessDescription.Items.FindByValue(e.Parameter.ToString()) != null)
            {
                ddlAccessDescription.Value = e.Parameter.ToString();
                try
                {
                    ddlAccessDescription.SelectedIndex = ddlAccessDescription.Items.FindByValue(e.Parameter.ToString()).Index;
                }
                catch (Exception)
                { }
            }
            else if (ddlAccessDescription.Items.Count > 0)
            {
                ddlAccessDescription.Value = ddlAccessDescription.Items[0].Value;
                ddlAccessDescription.SelectedIndex = 0;
            }

        }
    }
}