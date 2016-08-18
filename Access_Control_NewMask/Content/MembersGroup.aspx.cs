using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using DevExpress.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Globalization;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class MembersGroup : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("MembersGroup_PMode");
            }
            set
            {
                HttpContext.Current.Session["MembersGroup_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.MembersGroup, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnAcceptGroup.Enabled = false; btnApplyPers.Enabled = false;
                btnNew.Enabled = false; btnDelete.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            if (!IsPostBack)
            {
                BindPersonal();
                BindDropDowns();
                BindGroups();
                //if(Session["MemberGroupRedirect"] != null)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SetNewMode", " clearcontrols();", true);
                //}
            }
        }

        protected void BindPersonal()
        {
            PersonnelRepository _VwPersonnelDataRepository = new PersonnelRepository();
            var persDataList = _VwPersonnelDataRepository.GetAllPersonnel(); //.Distinct().ToList().OrderBy(x => x.Pers_Nr)

            if (persDataList.Count > 33)
            {
                grdPersonal.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                grdPersonal.Settings.VerticalScrollableHeight = 720;
                grdPersonal.SettingsPager.PageSize = persDataList.Count;
            }

            grdPersonal.DataSource = persDataList;
            grdPersonal.DataBind();

            //if (persDataList.Count() <= 34)
            //{
            //    grdPersonal.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            //}
            //else
            //{
            //    grdPersonal.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            //}

        }

        protected void BindGroups()
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();
            var groupList = _MemberGroupsRepositories.GetAllMemberGroups();

            if (groupList.Count > 17)
            {
                grdGroups.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                grdGroups.Settings.VerticalScrollableHeight = 435;
                grdGroups.SettingsPager.PageSize = groupList.Count;
            }

            grdGroups.DataSource = groupList;
            grdGroups.DataBind();
            grdGroups.FocusedRowIndex = -1;

            //if (groupList.Count() <= 34)
            //{
            //    grdGroups.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            //}
            //else
            //{
            //    grdGroups.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            //}

        }

        protected void BindDropDowns()
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();

            MemberGroup MemberGroupList = new MemberGroup();
            List<MemberGroup> MemberGroup = new List<MemberGroup>();
            MemberGroup = _MemberGroupsRepositories.GetAllMemberGroups().OrderBy(x => x.GroupNr).ToList();
            MemberGroup.Insert(0, new MemberGroup { GroupNr = 0, GroupName = "Keine" });

            cboGroupNr.DataSource = MemberGroup;
            cboGroupNr.DataBind();

            cboGroupDescrptn.DataSource = MemberGroup;
            cboGroupDescrptn.DataBind();
        }

        [WebMethod]
        public static MemberGroup Getpersonal(int ID)
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();
            MemberGroup _MemberGroups = new MemberGroup();
            var persData = _MemberGroupsRepositories.GetMemberGroupById(ID);

            if (persData == null)
            {
                return _MemberGroups;
            }

            if (persData != null)
            {
                _MemberGroups.Id = persData.Id;
                _MemberGroups.GroupNr = persData.GroupNr;
                _MemberGroups.GroupName = persData.GroupName;
                _MemberGroups.PersonHead = persData.PersonHead;
                _MemberGroups.TrainerOne = persData.TrainerOne;
                _MemberGroups.TrainerTwo = persData.TrainerTwo;
                _MemberGroups.TrainerThree = persData.TrainerThree;
                _MemberGroups.TrainerFour = persData.TrainerFour;
                _MemberGroups.TrainerFive = persData.TrainerFive;
            }

            return _MemberGroups;
        }


        [WebMethod]
        public static MemberGroup GetpersonalByPersNr(int Nr)
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();
            MemberGroup _MemberGroups = new MemberGroup();
            var persData = _MemberGroupsRepositories.GetMemberGroupByNr(Nr);

            if (persData == null)
            {
                return _MemberGroups;
            }

            if (persData != null)
            {
                _MemberGroups.Id = persData.Id;
                _MemberGroups.GroupNr = persData.GroupNr;
                _MemberGroups.GroupName = persData.GroupName;
                _MemberGroups.PersonHead = persData.PersonHead;
                _MemberGroups.TrainerOne = persData.TrainerOne;
                _MemberGroups.TrainerTwo = persData.TrainerTwo;
                _MemberGroups.TrainerThree = persData.TrainerThree;
                _MemberGroups.TrainerFour = persData.TrainerFour;
                _MemberGroups.TrainerFive = persData.TrainerFive;
            }

            return _MemberGroups;
        }


        [WebMethod]
        public static KruAll.Core.Models.Personal GetPersonalByID(int Id)
        {
            PersonnelRepository _PersonnelRepository = new PersonnelRepository();
            KruAll.Core.Models.Personal _Personal = new KruAll.Core.Models.Personal();
            var persInfo = _PersonnelRepository.GetPersonnelById(Id);

            if (persInfo == null)
            {
                return _Personal;
            }

            if (persInfo != null)
            {
                _Personal.ID = persInfo.ID;
                _Personal.FirstName = persInfo.FirstName;
                _Personal.LastName = persInfo.LastName;

            }

            return _Personal;
        }


        [WebMethod]
        public static MemberGroup CreateEditMemberGroup(string id, string GroupNr, string GroupName, string PersonHead, string TrainerOne, string TrainerTwo, string TrainerThree, string TrainerFour, string TrainerFive)
        {
            var meberGroup = new MemberGroup();
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                MemberGroup _MemberGroup = new MemberGroup()
                {
                    GroupNr = Convert.ToInt64(GroupNr),
                    GroupName = GroupName,
                    PersonHead = PersonHead,
                    TrainerOne = TrainerOne,
                    TrainerTwo = TrainerTwo,
                    TrainerThree = TrainerThree,
                    TrainerFour = TrainerFour,
                    TrainerFive = TrainerFive,

                };
                new MemberGroupsRepositories().NewMemberGroup(_MemberGroup);
                meberGroup = _MemberGroup;
            }
            else
            {
                var grpMember = new MemberGroupsRepositories().GetMemberGroupById(Convert.ToInt64(id));
                if (grpMember != null)
                {
                    MemberGroup _MemberGroup = new MemberGroup()
                    {
                        Id = grpMember.Id,
                        GroupNr = grpMember.GroupNr,
                        GroupName = grpMember.GroupName,
                        PersonHead = grpMember.PersonHead,
                        TrainerOne = grpMember.TrainerOne,
                        TrainerTwo = grpMember.TrainerTwo,
                        TrainerThree = grpMember.TrainerThree,
                        TrainerFour = grpMember.TrainerFour,
                        TrainerFive = grpMember.TrainerFive,


                    };
                    new MemberGroupsRepositories().EditMemberGroup(_MemberGroup);
                    meberGroup = _MemberGroup;
                }
            }
            var data = (DurationRedirectDto)HttpContext.Current.Session["MemberGroupRedirect"];
            if (data != null)
            {
                data.objectId = meberGroup.Id;
            }
            return meberGroup;
        }


        [WebMethod]
        public static bool DeleteMemberGroup(int Id)
        {
            MemberGroupsRepositories persRep = new MemberGroupsRepositories();

            var memberGroup = persRep.GetMemberGroupById(Convert.ToInt32(Id));
            if (memberGroup != null)
            {
                new MemberGroupsRepositories().DeleteMemberGroup(memberGroup);
            }
            return persRep.GetMemberGroupByNr(Convert.ToInt32(Id)) == null;
        }



        [WebMethod]
        public static MemberGroup EditMemberGroupInDatabase(string jSONData)
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();
            MemberGroup _MemberGroup = null;
            List<MemberGroup> MemberGroupList = JsonConvert.DeserializeObject<List<MemberGroup>>(jSONData);
            if (MemberGroupList.Count > 0)
            {
                _MemberGroup = MemberGroupList[0];
                _MemberGroupsRepositories.EditMemberGroup(_MemberGroup);
            }
            return _MemberGroup;
        }
        [WebMethod]
        public static bool CheckIfGroupNrExists(string groupNr)
        {
            var exists = false;
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();
            var memberGroup = new MemberGroupsRepositories().GetMemberGroupByNr(Convert.ToInt32(groupNr));

            if (memberGroup != null)
            {
                exists = true;
            }
            return exists;
        }
        [WebMethod]
        public static long CalculateNextNr()
        {
            var personnnel = new MemberGroupsRepositories().GetAllMemberGroups();
            long lastMemberGroup = 0;
            if (personnnel.Count > 0)
            {
                lastMemberGroup = personnnel.Max(x => x.GroupNr);
            }
            return lastMemberGroup + 1;

        }
        [WebMethod]
        public static int Isnewrecord(string Personalnumber)
        {
            int i;
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();
            var p = _MemberGroupsRepositories.GetMemberGroupByNr(Convert.ToInt32(Personalnumber));

            if (p != null)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }


        protected void cboGroupNr_Callback(object sender, CallbackEventArgsBase e)
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();

            MemberGroup MemberGroupList = new MemberGroup();
            List<MemberGroup> MemberGroup = new List<MemberGroup>();
            MemberGroup = _MemberGroupsRepositories.GetAllMemberGroups().OrderBy(x => x.GroupNr).ToList();
            MemberGroup.Insert(0, new MemberGroup { GroupNr = 0, GroupName = "Keine" });

            cboGroupNr.DataSource = MemberGroup;
            cboGroupNr.DataBind();

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                if (Convert.ToInt32(e.Parameter) == -999)
                {
                    if (cboGroupNr.Items.Count > 1)
                    {
                        cboGroupNr.SelectedIndex = 1;
                    }
                }
                else if (Convert.ToInt64(e.Parameter) > 0)
                {
                    cboGroupNr.Value = e.Parameter.ToString();
                }

            }
            else
            {
                cboGroupNr.Value = e.Parameter.ToString();
            }
        }

        protected void cboGroupDescrptn_Callback(object sender, CallbackEventArgsBase e)
        {
            MemberGroupsRepositories _MemberGroupsRepositories = new MemberGroupsRepositories();

            MemberGroup MemberGroupList = new MemberGroup();
            List<MemberGroup> MemberGroup = new List<MemberGroup>();
            MemberGroup = _MemberGroupsRepositories.GetAllMemberGroups().OrderBy(x => x.GroupNr).ToList();
            MemberGroup.Insert(0, new MemberGroup { GroupNr = 0, GroupName = "Keine" });

            cboGroupDescrptn.DataSource = MemberGroup;
            cboGroupDescrptn.DataBind();

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                if (Convert.ToInt32(e.Parameter) == -999)
                {
                    if (cboGroupDescrptn.Items.Count > 1)
                    {
                        cboGroupDescrptn.SelectedIndex = 1;
                    }
                }
                else if (Convert.ToInt64(e.Parameter) > 0)
                {
                    cboGroupDescrptn.Value = e.Parameter.ToString();
                }
            }
            else
            {
                cboGroupDescrptn.Value = e.Parameter.ToString();
            }
        }

        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        [WebMethod]
        public static string CheckForRedirect()
        {
            string url = "/Content/Settings.aspx";
            if (HttpContext.Current.Session["MemberGroupRedirect"] != null)
            {
                var data = (DurationRedirectDto)HttpContext.Current.Session["MemberGroupRedirect"];
                if (data != null)
                {
                    url = data.pageFrom;
                }
            }
            return url;
        }

        protected void grdGroups_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            BindGroups();
        }
    }
}