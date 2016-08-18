using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlanMembers : BasePage
    {
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit,
            Refresh
        }

        static List<AccessGroup> listAccessGroups;
        static List<TbAccessPlan> listAccessPlans;
        //private static List<TbAccessPlanMembersMapping> _accessPlanMembersMappings;
        private static List<MembersAccessPlanMapping> _memberAccessPlanMappings;
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("AccessPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["AccessPlan_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.AccessPlan, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false;

                btnDeselectAll.Enabled = false; btnSelectAll.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Form.DefaultButton = this.btnSave.UniqueID;

                if (hiddenFieldDetectChanges.Value != null)
                {
                    if (hiddenFieldDetectChanges.Value == "999")
                    {
                        Response.Redirect("AccessPlan.aspx");
                    }
                }

                if (!(Page.IsPostBack))
                {
                    GetPassedData();
                    LoadMemberGroups();
                    LoadMembers();
                    LoadMappedAccessPlans();

                    if (Session["ProfileID"] != null)
                    {
                        string accessPlanID = (string)Session["ProfileID"];
                        int _accessPlanId = 0;
                        bool isaccessPlanNumberlong = int.TryParse(accessPlanID, out _accessPlanId);
                        var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(_accessPlanId);
                        if (accessPlan == null) return;
                        var members = new MembersViewModel().GetMembersForAccessPlanList(accessPlan.ID);
                        DisplayMembers(members);
                    }

                }

            }
            catch (Exception ex) { throw ex; }
        }

        private void EnableDisableControls()
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.None:

                    FormNoneMode();

                    break;

                case (int)FormMode.Display:

                    FormDisplayMode();

                    break;

                case (int)FormMode.Create:
                case (int)FormMode.Edit:

                    FormCreateEditMode();

                    break;
            }
        }

        private void FormNoneMode()
        {
            //btnSave.Enabled = false;

            //gridViewEmployee.Enabled = false;
        }

        private void FormDisplayMode()
        {
            //btnSave.Enabled = false;

            //gridViewEmployee.Enabled = false;
        }

        private void FormCreateEditMode()
        {
            //btnSave.Enabled = accessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;

            gridViewEmployee.Enabled = true;
        }

        protected void LoadMemberGroups()
        {
            List<MemberGroupDto> memberGroupList = new List<MemberGroupDto>();
            MemberGroupDto _member = new MemberGroupDto() { Id = 0, GroupNr = 0, GroupNumber = "Alle", GroupName = "Alle" };
            memberGroupList.Add(_member);
            var memberGroups = new MembersViewModel().MemberGroups();
            memberGroupList.AddRange(memberGroups);

            ddlbMemberGroupFrom.DataSource = memberGroupList;
            ddlbMemberGroupFrom.DataBind();
            ddlbMemberGroupFrom.SelectedIndex = 0;

            ddlMemberGroupTo.DataSource = memberGroupList;
            ddlMemberGroupTo.DataBind();
            ddlMemberGroupTo.SelectedIndex = 0;
        }

        protected void LoadMembers()
        {
            var members = new MembersViewModel().MemberDetails();
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "keine", AgreementNr = "0" };
            memberList.Add(_member);
            memberList.AddRange(members);
            ddlMemberFrom.DataSource = memberList;
            ddlMemberFrom.DataBind();
            ddlMemberFrom.SelectedIndex = 0;

            ddlMemberTo.DataSource = memberList;
            ddlMemberTo.DataBind();
            ddlMemberTo.SelectedIndex = 0;
        }

        #region Private Methods


        protected void DisplayMembers(List<AccessPlanMembersDto> members)
        {
            var memberProfiles = new List<AccessPlanMembersDto>();

            foreach (var member in members)
            {
                var accessPlanPersMapping = _memberAccessPlanMappings.Find(p => p.MembersData.MemberNumber == member.MemberNumber);
                //var accessPlanPersMapping = _accessPlanMembersMappings.Find(p => p.MembersData.MemberNumber == member.MemberNumber);
                var isSelected = accessPlanPersMapping != null;

                var memberDetails = new MembersDataRepository().GetAllMembersData().Where(x => x.MemberNumber == Convert.ToInt64(member.MemberNumber)).FirstOrDefault();
                var memberProfile = new AccessPlanMembersDto
                {
                    ID = member.ID,
                    MemberNumber = member.MemberNumber,
                    Place = member.Place,
                    PostalCode = member.PostalCode,
                    Street = member.Street,
                    AgreementNr = member.AgreementNr,
                    SurName = member.SurName,
                    Telephone = member.Telephone,
                    FirstName = member.FirstName,
                    IsSelected = isSelected
                };

                memberProfiles.Add(memberProfile);
            }

            if (memberProfiles.Count > 25)
            {
                gridViewEmployee.SettingsPager.PageSize = memberProfiles.Count;
            }

            gridViewEmployee.DataSource = memberProfiles.OrderBy(x => x.MemberNumber).ToList();
            gridViewEmployee.DataBind();

            Session["Member_Profiles"] = memberProfiles.OrderBy(x => x.MemberNumber).ToList();

            hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString();
            EnableDisableControls();
        }

        protected List<AccessPlanMembersDto> GetMembers(int MemberGroupFrom, int MemberGroupTo, int MemberFrom, int MemberTo)
        {
            int MemberGroupFromId = int.Parse(MemberGroupFrom.ToString());
            int MemberGroupToId = int.Parse(MemberGroupTo.ToString());
            int MemberFromId = int.Parse(MemberFrom.ToString());
            int MemberToId = int.Parse(MemberTo.ToString());

            var members = new MembersViewModel().GetAccessPlanMembersDtoList();
            if ((MemberGroupFromId > 0) || (MemberGroupToId > 0))
            {
                members = members.Where(p => p.MemberGroupId >= MemberGroupFromId && p.MemberGroupId <= MemberGroupToId).ToList();
            }

            if ((MemberFromId > 0) || (MemberToId > 0))
            {
                members = members.Where(p => p.ID >= MemberFromId && p.ID <= MemberToId).ToList();
            }

            var membersList = members.Distinct().ToList();

            return membersList;
        }

        protected void LoadMappedAccessPlans()
        {
            try
            {
                if (Session["ProfileID"] == null) return;

                string accessPlanID = (string)Session["ProfileID"];
                int _accessPlanId = 0;
                bool isaccessPlanNumberlong = int.TryParse(accessPlanID, out _accessPlanId);
                var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(_accessPlanId);
                if (accessPlan == null) return;
                var members = new MembersViewModel().GetMembersForAccessPlanList(accessPlan.ID);

                //_accessPlanMembersMappings = new AccessPlanMembersMappingViewModel().GetMembersByPlanID(accessPlan.ID);

                _memberAccessPlanMappings = new MembersAccessPlanMappingRepository().GetAllMembersPLans().Where(x => x.AccessPlan_Nr == accessPlan.ID).ToList();

                var memberIds = _memberAccessPlanMappings.Select(p => Convert.ToInt64(p.MemberID)).ToList();
                var _newmembers = new MembersViewModel().GetMembersGivenIds(memberIds).Distinct().ToList();

                DisplayMembers(_newmembers);

                hiddenFieldInitialPersonalsCount.Value = _newmembers.Count.ToString();
            }
            catch (Exception ex) { throw ex; }
        }

        [WebMethod]
        public static void SaveAccessPlanMember(long accessPlanNumber, int locationId, List<AccessPlanMembersDto> members)
        {
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByNr(accessPlanNumber);

            if (accessPlan == null) return;

            var selectedLocationId = locationId > 0 ? (int?)locationId : null;

            //remove all members from the plan first
            //var memberProfiles = new AccessPlanMembersMappingViewModel().GetMembersByPlanID(accessPlan.ID);

            //foreach (var memberProfile in memberProfiles)
            //{
            //    new AccessPlanMembersMappingViewModel().DeleteMappingCustom(memberProfile);
            //}

            new MembersAccessPlanMappingRepository().DeleteMembersAccessPlanMapping(accessPlan.ID);

            if ((members == null) || !(members.Any())) return;

            var uniqueMembers = members.GroupBy(p => p.ID).Select(group => group.First()).ToList();

            foreach (var member in uniqueMembers)
            {

                var mapping = new MembersAccessPlanMapping
                {
                    AccessPlan_Nr = accessPlan.ID,
                    MemberID = member.ID
                };

                new MembersAccessPlanMappingRepository().NewMemberAccessPlan(mapping);
                //new AccessPlanMembersMappingViewModel().CreateMapping(mapping);
            }

        }


        protected void gridViewEmployee_OnCustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            var i = e.Parameters;
            if (e.Parameters == "1")
            {
                int MemberGroupFrom = 0;
                int MemberGroupTo = 0;
                int MemberFrom = 0;
                int MemberTo = 0;

                if (null != ddlbMemberGroupFrom.Value) { MemberGroupFrom = int.Parse(ddlbMemberGroupFrom.Value.ToString()); }
                if (null != ddlMemberGroupTo.Value) { MemberGroupTo = int.Parse(ddlMemberGroupTo.Value.ToString()); }
                if (null != ddlMemberFrom.Value) { MemberFrom = int.Parse(ddlMemberFrom.Value.ToString()); }
                if (null != ddlMemberTo.Value) { MemberTo = int.Parse(ddlMemberTo.Value.ToString()); }

                var personnels = GetMembers(MemberGroupFrom, MemberGroupTo, MemberFrom, MemberTo);

                DisplayMembers(personnels);
            }
            else if (e.Parameters == "0")
            {
                LoadMappedAccessPlans();
            }
        }

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        #endregion Private Methods

        #region Button Methods

        protected void btnBack_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.Display:
                case (int)FormMode.None:
                    Session["SwitchPlan"] = null;
                    Response.Redirect("/Content/AccessPlan.aspx");

                    break;

                case (int)FormMode.Create:
                case (int)FormMode.Edit:
                    int detectedChanges = 0;
                    if (!string.IsNullOrEmpty(hiddenFieldDetectChanges.Value))
                    {
                        if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
                            hiddenFieldDetectChanges.Value = "0";

                        detectedChanges = Convert.ToInt32(hiddenFieldDetectChanges.Value);
                    }

                    switch (detectedChanges)
                    {
                        case 0:
                            Session["SwitchPlan"] = null;
                            Response.Redirect("/Content/AccessPlan.aspx");

                            break;

                        case 1:
                            ClientScript.RegisterStartupScript(GetType(), "BackButtonConfirm", "BackButtonConfirm();", true);

                            break;
                    }

                    break;
            }
        }

        #endregion Button Methods

        #region GridView Methods

        protected void gridViewEmployee_OnDataBound(object sender, EventArgs e)
        {
            for (var i = 0; i < gridViewEmployee.VisibleRowCount; i++)
            {
                var isSelected = Convert.ToBoolean(gridViewEmployee.GetRowValues(i, "IsSelected"));
                gridViewEmployee.Selection.SetSelection(i, isSelected);
            }
        }

        #endregion GridView Methods

        #region get passed data
        protected void GetPassedData()
        {
            if (Session["ProfileID"] == null) return;

            BindAccesssGroups();
            BindAccessProfiles();
            ddlAccessGroupNumber.Value = Session["GroupID"].ToString();
            ddlAccessGroupName.Value = Session["GroupID"].ToString();

            ddlAccessProfileNumber.Value = Session["ProfileID"].ToString();
            ddlAccessProfileName.Value = Session["ProfileID"].ToString();

            BindAccessPlanText();
        }

        protected void BindAccessPlanText()
        {
            if (null != ddlAccessGroupNumber.Value)
            {
                txtAccessGroupNumber.Text = Session["AccessGroupNumber"].ToString();
            }

            if (null != ddlAccessGroupName.Value)
            {
                txtAccessGroupName.Text = Session["AccessGroupName"].ToString();
            }

            if (null != ddlAccessProfileNumber.Value)
            {
                txtAccessProfileNumber.Text = Session["AccessProfileNumber"].ToString();
            }

            if (null != ddlAccessProfileName.Value)
            {
                txtAccessProfileName.Text = Session["AccessProfileName"].ToString();
            }
        }

        protected void LoadExistingGroups(ref List<AccessGroup> listAccessGroups)
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            listAccessGroups.AddRange(accessGroups.GetAllAccessProfileGroups().Where(x => x.AccessGroupType == 1));
        }

        protected void LoadAccessPlansByGroupID(ref List<TbAccessPlan> listAccessPlans)
        {
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());

        }

        protected void BindAccesssGroups()
        {
            listAccessGroups = new List<AccessGroup>();
            LoadExistingGroups(ref listAccessGroups);

            ddlAccessGroupNumber.DataSource = listAccessGroups;
            ddlAccessGroupNumber.DataBind();

            ddlAccessGroupName.DataSource = listAccessGroups;
            ddlAccessGroupName.DataBind();
        }

        protected void BindAccessProfiles()
        {
            listAccessPlans = new List<TbAccessPlan>();
            LoadAccessPlansByGroupID(ref listAccessPlans);

            ddlAccessProfileNumber.DataSource = listAccessPlans;
            ddlAccessProfileNumber.DataBind();

            ddlAccessProfileName.DataSource = listAccessPlans;
            ddlAccessProfileName.DataBind();
        }
        #endregion

        protected void btnInformation_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("/Content/AccessPlan.aspx");

        }






    }
}