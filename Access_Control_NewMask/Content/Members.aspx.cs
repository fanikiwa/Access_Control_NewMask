using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using DevExpress.Web;
using DevExpress.Web.Data;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace Access_Control_NewMask.Content
{
    public partial class Members : BasePage
    {
        static long groupId = 0;
        static long durationId = 0;
        string selectsql = string.Empty;
        ZUTMain mainCtl = new ZUTMain();

        static string culture;
        static CultureInfo cultureInfo;

        public static List<MembersDataDto> MemberList
        {
            get
            {
                return new MembersViewModel().GetAllMembersData(true).ToList();
            }
            set
            {
                new MembersViewModel().GetAllMembersData(true).ToList();
            }
        }

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("MembersActive_PMode");
            }
            set
            {
                HttpContext.Current.Session["MembersActive_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.MembersActive, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnSaveAusweis.Enabled = false; btnSaveCarType.Enabled = false; btnSaveClient.Enabled = false; btnSavePersType.Enabled = false;
                btnTakePhoto.Enabled = false; btnTakeWebcamPicture.Enabled = false;

                btnApplyAccessPlan.Enabled = false;

                btnNew.Enabled = false; btnNewAusweis.Enabled = false; btnNewCarType.Enabled = false; btnNewClient.Enabled = false; btnNewPersType.Enabled = false;
                btnTriggerFileUpload.Enabled = false; btnTriggerFileUpload.Enabled = false;

                btnDelete.Enabled = false; btnDeleteAusweis.Enabled = false; btnDeleteCarType.Enabled = false; btnDeleteClient.Enabled = false; btnDeletePersType.Enabled = false;
                btnRemovePhoto.Enabled = false; btnRemovePhotoorig.Enabled = false;

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

                txtMemberNr.Enabled = false;
                LoadMemberGroups();
                LoadgrdAccessGroups(0);
                LoadMembers();
                LoadSalutations();
                LoadDurations();
                LoadgrdAccessPlan();
                BindSearchGrid();
                if (Session["MemberGroupRedirect"] != null)
                {
                    var groupData = (DurationRedirectDto)Session["MemberGroupRedirect"];
                    if (groupData != null)
                    {
                        cobMemberNr.Value = groupData.Id.ToString();
                        cobMemberName.Value = groupData.Id.ToString();
                        groupId = groupData.objectId;
                    }
                    Session["MemberGroupRedirect"] = null;
                }
                else if (Session["DurationRedirct"] != null)
                {
                    var durationData = (DurationRedirectDto)Session["DurationRedirct"];
                    if (durationData != null)
                    {
                        cobMemberNr.Value = durationData.Id.ToString();
                        cobMemberName.Value = durationData.Id.ToString();
                        durationId = durationData.objectId;
                    }
                    Session["DurationRedirct"] = null;
                }
                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    if (cobMemberNr.Items.FindByValue(id.ToString()) != null)
                    {
                        cobMemberNr.Value = id.ToString();
                        cobMemberName.Value = id.ToString();
                    }
                }

                if (Convert.ToInt64(cobMemberNr.Value) > 0)
                {
                    LoadFirstMember(Convert.ToInt64(cobMemberNr.Value));
                    BindTransponders(Convert.ToInt64(cobMemberNr.Value));
                }
                SetValues();
            }
        }
        protected void SetValues()
        {
            if (groupId > 0)
            {
                if (cobMemberGroup.Items.FindByValue(groupId.ToString()) != null)
                {
                    cobMemberGroup.Value = groupId.ToString();
                }
                groupId = 0;
            }
            if (durationId > 0)
            {
                if (cobDuration.Items.FindByValue(durationId.ToString()) != null)
                {
                    cobDuration.Value = durationId.ToString();
                }
                durationId = 0;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

        protected void LoadgrdAccessGroups(long memberId)
        {
            MemberAccessGroupsViewModel _MemberAccessGroupsViewModel = new MemberAccessGroupsViewModel();
            List<MemberAccessGroupsDto> personalAccessPlanGroups = _MemberAccessGroupsViewModel.GetMemberAccessGroupByMemberID(memberId);

            List<TbAccessPlanGroup> tbAccessPlanGroups = new List<TbAccessPlanGroup>();
            tbAccessPlanGroups = (new AccessPlanGroupRepository().GetAllAccessPlanGroups()) ?? new List<TbAccessPlanGroup>();
            tbAccessPlanGroups.Add(new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" });
            tbAccessPlanGroups = tbAccessPlanGroups.OrderBy(x => x.AccessPlanGroupNr).ToList();
            HttpContext.Current.Session["Pers_PersAccessGroups"] = tbAccessPlanGroups;

            grdAccessGroups.DataSource = personalAccessPlanGroups;
            grdAccessGroups.DataBind();
        }

        protected void LoadMemberGroups()
        {
            List<MemberGroupDto> memberGroupList = new List<MemberGroupDto>();
            MemberGroupDto _member = new MemberGroupDto() { Id = 0, GroupNr = 0, GroupNumber = "Alle", GroupName = "Alle" };
            memberGroupList.Add(_member);
            //var memberGroups = new MembersViewModel().MemberGroups();
            var memberGroups = new MembersViewModel().FilterMemberGroups();
            memberGroupList.AddRange(memberGroups);

            cobMemberGroupNr.DataSource = memberGroupList;
            cobMemberGroupNr.DataBind();
            cobMemberGroupNr.SelectedIndex = 0;
            cobMemberGroupName.DataSource = memberGroupList;
            cobMemberGroupName.DataBind();
            cobMemberGroupName.SelectedIndex = 0;

            List<MemberGroupDto> _groupsList = new List<MemberGroupDto>();
            MemberGroupDto _Group = new MemberGroupDto() { Id = 0, GroupNr = 0, GroupName = "keine" };
            _groupsList.Add(_Group);
            _groupsList.AddRange(new MembersViewModel().MemberGroups());
            cobMemberGroup.DataSource = _groupsList;
            cobMemberGroup.DataBind();
        }
        protected void LoadMembers()
        {
            var members = new MembersViewModel().MemberDetails(true);
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            cobMemberNr.DataSource = memberList;
            cobMemberNr.DataBind();
            cobMemberName.DataSource = memberList;
            cobMemberName.DataBind();
            if (members.Count > 0)
            {
                cobMemberNr.SelectedIndex = 1;
                cobMemberName.SelectedIndex = 1;
                txtFvTotalEntries.Text = members.Count.ToString();
            }
            else
            {
                cobMemberNr.SelectedIndex = 0;
                cobMemberName.SelectedIndex = 0;
                txtFvTotalEntries.Text = "";
            }

        }

        protected void LoadSalutations()
        {
            var salutation = new SalutationsRepository().GetSalutation().Where(c => c.AnredeCode > 0).OrderBy(x => x.AnredeCode).Take(2).ToList();
            cobSalutation.DataSource = salutation;
            cobSalutation.DataBind();
            cobSalutation.SelectedIndex = 0;
        }
        protected void LoadDurations()
        {
            var durations = new MemberDurationRepository().GetAllDurations();
            cobDuration.DataSource = durations.OrderBy(x => x.DurationNr);
            cobDuration.DataBind();
            cobDuration.SelectedIndex = 0;
        }
        [WebMethod]
        public static long SaveMemberDetails(string jSONData)
        {
            long id = 0;
            List<MembersDataDto> memberData = JsonConvert.DeserializeObject<List<MembersDataDto>>(jSONData);
            if (memberData.Count > 0)
            {
                var memberDetails = new MembersViewModel().SaveMemberData(memberData[0]);
                if (memberDetails != null)
                {
                    id = memberDetails.ID;
                }

            }
            return id;

        }
        [WebMethod]
        public static bool CheckIfMemberNrExists(string memberNr)
        {
            var exists = false;
            var member = new MembersDataRepository().GetMemberDataByNr(Convert.ToInt64(memberNr));
            if (member != null)
            {
                exists = true;
            }
            return exists;
        }
        protected void LoadFirstMember(long ID)
        {
            var member = new MembersDataRepository().GetMemberDataById(ID);
            if (member != null)
            {
                if (member.MemberGroupId != null) { cobMemberGroup.Value = member.MemberGroupId.ToString(); }
                if (member.Salutation != null) { cobSalutation.Value = member.Salutation.ToString(); }
                txtSurName.Text = member.SurName;
                txtFirstName.Text = member.FirstName;
                txtStreet.Text = member.Street;
                txtStreetNr.Text = member.StreetNumber;
                txtPostalCode.Text = member.PostalCode;
                txtPhysicalAddress.Text = member.Place;
                txtMemberNr.Text = member.MemberNumber.ToString();
                if (member.ContractDuration != null) { cobDuration.Value = member.ContractDuration.ToString(); }
                if (member.DateOfBirth != null) { dpDateOfBirth.Date = Convert.ToDateTime(member.DateOfBirth); }
                txtNationality.Text = member.Nationality;
                txtProfession.Text = member.Profession;
                txtTelephone.Text = member.Telephone;
                txtMobileNo.Text = member.MobilePhone;
                txtEmail.Text = member.Email;
                txtMemo.Text = member.Memo;
                chkActivateMember.Checked = (!member.Active ?? false);
                txtAgreementNr.Text = member.AgreementNr;
                img.Src = string.IsNullOrWhiteSpace(member.MemberPhoto) ? member.MemberPhoto : FileProcessor.GetMemberImageRelativeFilePath(member.MemberPhoto);
                if (member.EntryDate != null) { dpEntryDate.Date = Convert.ToDateTime(member.EntryDate); }
                if (member.ExitDate != null) { dpExitDate.Date = Convert.ToDateTime(member.ExitDate); }
                if (member.MembersAccessPlanMappings.FirstOrDefault() != null)
                {
                    var mappedPLan = member.MembersAccessPlanMappings.FirstOrDefault();
                    txtAccessPlanNr.Text = mappedPLan.TbAccessPlan.AccessPlanNr.ToString();
                    txtAccessPlanName.Text = mappedPLan.TbAccessPlan.AccessPlanDescription;
                    if (mappedPLan.DateFrom != null) { dpAccessPlanDateFrom.Date = Convert.ToDateTime(mappedPLan.DateFrom); }
                    if (mappedPLan.DateTo != null) { dpAccessPlanDateTo.Date = Convert.ToDateTime(mappedPLan.DateTo); }
                }
                txtFvCurrentEntry.Text = "1";
                if (member.ActiveCard != null)
                {
                    switch (member.ActiveCard)
                    {
                        case 0:
                            chkDaypass.Checked = false;
                            chkWeekpass.Checked = false;
                            break;
                        case 1:
                            chkWeekpass.Checked = true;
                            break;
                        case 2:
                            chkDaypass.Checked = true;
                            break;
                    }
                }
                else
                {
                    chkDaypass.Checked = false;
                    chkWeekpass.Checked = false;
                }
            }
        }
        [WebMethod]
        public static MembersDataDto GetMemberByID(long id)
        {
            var memberDetails = new MembersViewModel().GetMemberById(id, true);
            return memberDetails;
        }

        protected void cobMemberNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var members = new MembersViewModel().MemberDetails(true);
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            cobMemberNr.DataSource = memberList;
            cobMemberNr.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] passedValues = e.Parameter.Split(';');
                var id = passedValues[0];
                var filter = passedValues[1];
                var evt = passedValues[2];
                if (Convert.ToInt32(evt) == 1)
                {
                    List<MembersDataDto> filteredmemberList = new List<MembersDataDto>();
                    List<MembersDataDto> filterMembers = new List<MembersDataDto>();
                    if (Convert.ToInt64(filter) > 0)
                    {
                        filterMembers = members.Where(x => x.MemberGroupId == Convert.ToInt64(filter)).ToList();
                    }
                    else
                    {
                        filterMembers = members;
                    }
                    filteredmemberList.Add(_member);
                    filteredmemberList.AddRange(filterMembers);
                    cobMemberNr.DataSource = filteredmemberList;
                    cobMemberNr.DataBind();
                    if (filteredmemberList.Count > 1)
                    {
                        cobMemberNr.SelectedIndex = 1;
                    }

                    return;
                }
                if (Convert.ToInt64(filter) > 0)
                {
                    List<MembersDataDto> filteredmemberList = new List<MembersDataDto>();
                    var filterMembers = members.Where(x => x.MemberGroupId == Convert.ToInt64(filter)).ToList();
                    filteredmemberList.Add(_member);
                    filteredmemberList.AddRange(filterMembers);
                    cobMemberNr.Value = id.ToString();
                }
                else
                {

                    cobMemberNr.Value = id.ToString();
                }


            }
            else
            {
                cobMemberNr.SelectedIndex = 0;
            }
        }

        protected void cobMemberName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var members = new MembersViewModel().MemberDetails(true);
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            cobMemberName.DataSource = memberList;
            cobMemberName.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] passedValues = e.Parameter.Split(';');
                var id = passedValues[0];
                var filter = passedValues[1];
                var evt = passedValues[2];
                if (Convert.ToInt32(evt) == 1)
                {
                    List<MembersDataDto> filteredmemberList = new List<MembersDataDto>();
                    List<MembersDataDto> filterMembers = new List<MembersDataDto>();
                    if (Convert.ToInt64(filter) > 0)
                    {
                        filterMembers = members.Where(x => x.MemberGroupId == Convert.ToInt64(filter)).ToList();
                    }
                    else
                    {
                        filterMembers = members;
                    }


                    filteredmemberList.Add(_member);
                    filteredmemberList.AddRange(filterMembers);
                    cobMemberName.DataSource = filteredmemberList;
                    cobMemberName.DataBind();
                    if (filteredmemberList.Count > 1)
                    {
                        cobMemberName.SelectedIndex = 1;
                    }

                    return;
                }
                if (Convert.ToInt64(filter) > 0)
                {
                    List<MembersDataDto> filteredmemberList = new List<MembersDataDto>();
                    var filterMembers = members.Where(x => x.MemberGroupId == Convert.ToInt64(filter)).ToList();
                    filteredmemberList.Add(_member);
                    filteredmemberList.AddRange(filterMembers);
                    cobMemberName.DataSource = filteredmemberList;
                    cobMemberName.DataBind();
                    cobMemberName.Value = id.ToString();
                }
                else
                {

                    cobMemberName.Value = id.ToString();
                }

            }
            else
            {
                cobMemberName.SelectedIndex = 0;
            }
        }
        protected void LoadgrdAccessPlan()
        {
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            AccessPlanRepository accessPlanRepository = new AccessPlanRepository();
            TbAccessPlan accessplan = new TbAccessPlan();
            List<AccessGroup> lstAccessGroup = new List<AccessGroup>();
            //lstAccessGroup = accessGroupRepository.GetAllAccessGroups();
            List<TbAccessPlan> lstTbAccessPlan = new List<TbAccessPlan>();
            lstTbAccessPlan = accessPlanRepository.GetAllAccessPlans();
            AccessPlanAccessGroupDto dto = null;
            List<AccessPlanAccessGroupDto> lstAccessPlanAccessGroupDto = new List<AccessPlanAccessGroupDto>();
            foreach (TbAccessPlan plan in lstTbAccessPlan)
            {
                dto = new AccessPlanAccessGroupDto();
                long accessgroupId = plan.AccessGroupID;
                AccessGroup accessgroup2 = new AccessGroup();
                accessgroup2 = accessGroupRepository.GetAccessPlanAccessGroupById(accessgroupId);
                dto.ID = plan.ID;
                dto.AccessGroupName = accessgroup2.AccessGroupName;
                dto.AccessGroupNumber = accessgroup2.AccessGroupNumber;
                dto.AccessPlanNumber = plan.AccessPlanNr;
                dto.AccessPlanName = plan.AccessPlanDescription;
                lstAccessPlanAccessGroupDto.Add(dto);
            }

            if (lstAccessPlanAccessGroupDto.Count > 30)
            {
                grdAccessPlan.SettingsPager.PageSize = lstAccessPlanAccessGroupDto.Count;
            }

            grdAccessPlan.DataSource = lstAccessPlanAccessGroupDto;
            grdAccessPlan.DataBind();
        }
        [WebMethod]
        public static bool DeleteMember(long id)
        {
            var isDeleted = false;
            var member = new MembersDataRepository().GetMemberDataById(id);
            if (member != null)
            {
                var _member = member;
                new MembersDataRepository().DeleteMemberData(member);
                FileProcessor.DeleteImageFile(_member.MemberPhoto, FileProcessor.MembersPhotosFolder);
                isDeleted = true;
            }
            return isDeleted;

        }
        [WebMethod]
        public static void RedirectDuration(long id, bool isNew, string pageFrom)
        {
            DurationRedirectDto dto = new DurationRedirectDto()
            {
                Id = id,
                isNew = isNew,
                pageFrom = pageFrom
            };
            HttpContext.Current.Session["DurationRedirct"] = dto;
        }


        [WebMethod]
        public static void RedirectMemberGroup(long id, bool isNew, string pageFrom)
        {
            DurationRedirectDto dto = new DurationRedirectDto()
            {
                Id = id,
                isNew = isNew,
                pageFrom = pageFrom
            };
            HttpContext.Current.Session["MemberGroupRedirect"] = dto;
        }

        protected void grdTransponders_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            List<ASPxDataUpdateValues> updateValues = e.UpdateValues;
            long memberId = 0;
            Int64.TryParse(Convert.ToString(cobMemberNr.Value), out memberId);

            if (memberId > 0)
            {
                SaveTransponders(updateValues, 1, memberId);

                e.Handled = true;

                var transpondersType1 = new MemberTransponderViewModels().TransPonders(memberId, 1);

                try
                {
                    grdTransponders.DataSource = transpondersType1;
                    grdTransponders.DataBind();
                }
                catch (Exception)
                { }
            }
            else
            {
                e.Handled = true;
            }
        }

        protected void grdTransponders_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            long memberId = 0;
            Int64.TryParse(e.Parameters, out memberId);

            if (memberId >= 0)
            {
                var transpondersType1 = new MemberTransponderViewModels().TransPonders(memberId, 1);

                try
                {
                    grdTransponders.DataSource = transpondersType1;
                    grdTransponders.DataBind();
                }
                catch (Exception)
                { }
            }
        }

        protected void grdTranspondersShortTerm_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            List<ASPxDataUpdateValues> updateValues = e.UpdateValues;
            long memberId = 0;
            Int64.TryParse(Convert.ToString(cobMemberNr.Value), out memberId);

            if (memberId > 0)
            {
                SaveTransponders(updateValues, 2, memberId);

                e.Handled = true;

                var transpondersType2 = new MemberTransponderViewModels().TransPonders(memberId, 2);

                try
                {
                    grdTranspondersShortTerm.DataSource = transpondersType2;
                    grdTranspondersShortTerm.DataBind();
                }
                catch (Exception)
                { }
            }
            else
            {
                e.Handled = true;
            }
        }

        protected void grdTranspondersShortTerm_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            long memberId = 0;
            Int64.TryParse(e.Parameters, out memberId);

            if (memberId >= 0)
            {
                var transpondersType2 = new MemberTransponderViewModels().TransPonders(memberId, 2);

                try
                {
                    grdTranspondersShortTerm.DataSource = transpondersType2;
                    grdTranspondersShortTerm.DataBind();
                }
                catch (Exception)
                { }
            }
        }

        protected void grdAccessGroups_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            long memberId = 0;
            Int64.TryParse(e.Parameters, out memberId);

            if (memberId >= 0)
            {
                LoadgrdAccessGroups(memberId);
            }
        }

        protected void BindTransponders(long memberId)
        {
            var transpondersType1 = new MemberTransponderViewModels().TransPonders(memberId, 1);
            var transpondersType2 = new MemberTransponderViewModels().TransPonders(memberId, 2);
            grdTransponders.DataSource = transpondersType1;
            grdTransponders.DataBind();
            try
            {
                grdTranspondersShortTerm.DataSource = transpondersType2;
                grdTranspondersShortTerm.DataBind();
            }
            catch (Exception)
            { }
        }

        protected void grdTransponderInactiveHist_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            long memberId = 0, transponderNr = 0;
            Dictionary<string, string> paramsDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Parameters);

            foreach (KeyValuePair<string, string> param in paramsDict)
            {
                if (param.Key == "memberId") Int64.TryParse(param.Value, out memberId);
                if (param.Key == "transponderNr") Int64.TryParse(param.Value, out transponderNr);
            }

            if (memberId >= 0)
            {
                var transpondersHist = new MemberTransponderViewModels().TransPondersExtensions(memberId, transponderNr);

                try
                {
                    grdTransponderInactiveHist.DataSource = transpondersHist;
                    grdTransponderInactiveHist.DataBind();
                }
                catch (Exception)
                { }
            }
        }
        private void SaveTransponders(List<ASPxDataUpdateValues> updateValues, int transponderType, long memberId)
        {
            MembersTransponder memberTransponder = new MembersTransponder();
            MembersTranspondersRepository memberTranspondersRepository = new MembersTranspondersRepository();
            List<MembersTransponder> memberTranspondersList = memberTranspondersRepository.GetMemberTransponders(memberId) ?? new List<MembersTransponder>();

            foreach (ASPxDataUpdateValues updateValue in updateValues)
            {
                var keys = updateValue.Keys;
                var oldValues = updateValue.OldValues;
                var newValues = updateValue.NewValues;

                long transponderID = 0;
                if (keys["ID"] != null) Int64.TryParse(keys["ID"].ToString(), out transponderID);
                long transponderNr = 0;
                if (newValues["TransponderNr"] != null) Int64.TryParse(newValues["TransponderNr"].ToString().Trim(), out transponderNr);
                bool transponderActive = newValues["TransponderActive"] == null ? false :
                    Convert.ToBoolean(newValues["TransponderActive"].ToString());
                DateTime oldExtendedTo = oldValues["ExtendedTo"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(oldValues["ExtendedTo"]);
                DateTime extendedTo = newValues["ExtendedTo"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["ExtendedTo"]);
                DateTime validFrom = newValues["ValidFrom"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["ValidFrom"]);
                DateTime validTo = newValues["ValidTo"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["ValidTo"]);
                bool transponderInactive = newValues["TransponderInActive"] == null ? false :
                    Convert.ToBoolean(newValues["TransponderInActive"].ToString());
                DateTime? deactivationDate = newValues["TransponderDeactivatedOn"] == null ? new DateTime?() :
                    Convert.ToDateTime(newValues["TransponderDeactivatedOn"].ToString());
                int actionNr = 1;
                if (newValues["Action"] != null) Int32.TryParse(newValues["Action"].ToString(), out actionNr);
                string memo = newValues["Memo"] == null ? "" : newValues["Memo"].ToString();

                try
                {
                    List<Dictionary<int, string>> histUpdateValues = GetHistUpdateValues(hfdHistUpdate.Value);
                    if (histUpdateValues.Count > 0)
                    {
                        Dictionary<int, string> dictUpdate = histUpdateValues[0];
                        if (dictUpdate.Any(x => x.Key == transponderID))
                        {
                            try
                            {
                                extendedTo = DateTime.Parse(dictUpdate.First(x => x.Key == transponderID).Value);
                            }
                            catch (Exception)
                            { }
                        }
                    }
                }
                catch (Exception)
                { }

                if (transponderID > 0)
                {
                    if (memberTranspondersList.Any(x => x.ID == transponderID))
                    {
                        memberTransponder = memberTranspondersList.FirstOrDefault(x => x.ID == transponderID);
                        if (oldExtendedTo != extendedTo)
                        {
                            memberTransponder.TransponderStatus = false; memberTranspondersRepository.EditMemberTransponder(memberTransponder);
                            actionNr = memberTransponder.Action ?? 1;
                            transponderID = 0;
                            memberTransponder = new MembersTransponder();
                        }
                    }
                }
                else
                {
                    memberTransponder = new MembersTransponder();
                    actionNr = memberTransponder.Action ?? 1;
                }

                memberTransponder.Action = oldExtendedTo != extendedTo ? actionNr + 1 : actionNr;
                if (extendedTo != DateTime.MinValue) memberTransponder.ExtendedTo = extendedTo;
                memberTransponder.Memo = memo;
                memberTransponder.MemberID = memberId;
                if (deactivationDate != DateTime.MinValue) memberTransponder.TransponderDeactivatedOn = deactivationDate;
                memberTransponder.TransponderNr = transponderNr;
                memberTransponder.TransponderStatus = transponderActive;
                if (validFrom != DateTime.MinValue) memberTransponder.ValidFrom = validFrom;
                if (validTo != DateTime.MinValue) memberTransponder.ValidTo = validTo;
                memberTransponder.TransponderType = transponderType;

                if (transponderID > 0)
                {
                    memberTranspondersRepository.EditMemberTransponder(memberTransponder);
                }
                else
                {
                    if (memberTransponder.TransponderNr > 0) memberTranspondersRepository.AddMemberTransponder(memberTransponder);
                }
            }
            memberTranspondersRepository.SavePersTransponder();
        }
        public List<Dictionary<int, string>> GetHistUpdateValues(string histUpdateString)
        {
            List<Dictionary<int, string>> dictUpdateValues = new List<Dictionary<int, string>>();

            try
            {
                dictUpdateValues = JsonConvert.DeserializeObject<List<Dictionary<int, string>>>(histUpdateString);
            }
            catch (Exception) { }

            return dictUpdateValues;
        }

        [WebMethod]
        public static void SaveMemberAccessGroups(long MemberId, string updateString)
        {
            //MemberAccessGroupsRepository memberAccessGroupsRepository = new MemberAccessGroupsRepository();
            MemberAccessGroupsViewModel memberAccessGroupsViewModel = new MemberAccessGroupsViewModel();
            List<MemberAccessGroup> dbMemberAccessGroups = memberAccessGroupsViewModel.GetMemberAccessGroups(MemberId);
            List<MemberAccessGroupsDto> memberAccessGroups = new List<MemberAccessGroupsDto>();

            try
            {
                memberAccessGroups = JsonConvert.DeserializeObject<List<MemberAccessGroupsDto>>(updateString);
            }
            catch (Exception) { }

            foreach (MemberAccessGroupsDto memberAccessGroup in memberAccessGroups)
            {
                if (memberAccessGroup.OldGroupID > 0 && memberAccessGroup.GroupID > 0 && memberAccessGroup.ID > 0)
                {
                    MemberAccessGroup dbMemberAccessGroup = dbMemberAccessGroups.FirstOrDefault(p => p.GroupID == memberAccessGroup.OldGroupID &&
                                                                                p.ID == memberAccessGroup.ID) ?? new MemberAccessGroup();

                    dbMemberAccessGroup.GroupID = memberAccessGroup.GroupID;
                    dbMemberAccessGroup.StartDate = memberAccessGroup.StartDate;
                    dbMemberAccessGroup.EndDate = memberAccessGroup.EndDate;
                    dbMemberAccessGroup.Active = memberAccessGroup.Active;

                    memberAccessGroupsViewModel.EditMemberAccessGroup(dbMemberAccessGroup);
                }
                else if (memberAccessGroup.OldGroupID > 0 && memberAccessGroup.GroupID == 0)
                {
                    MemberAccessGroup dbMemberAccessGroup = dbMemberAccessGroups.FirstOrDefault(p => p.GroupID == memberAccessGroup.OldGroupID &&
                                                                                p.ID == memberAccessGroup.ID) ?? new MemberAccessGroup();
                    //Delete
                    memberAccessGroupsViewModel.DeleteMemberAccessGroup(dbMemberAccessGroup);
                }
                else if (memberAccessGroup.GroupID > 0)
                {
                    MemberAccessGroup dbMemberAccessGroup = new MemberAccessGroup();

                    dbMemberAccessGroup.MemberID = MemberId;
                    dbMemberAccessGroup.GroupID = memberAccessGroup.GroupID;
                    dbMemberAccessGroup.StartDate = memberAccessGroup.StartDate;
                    dbMemberAccessGroup.EndDate = memberAccessGroup.EndDate;
                    dbMemberAccessGroup.Active = memberAccessGroup.Active;

                    memberAccessGroupsViewModel.AddMemberAccessGroup(dbMemberAccessGroup);
                }
            }

            memberAccessGroupsViewModel.SaveMemberAccessGroup();
        }

        [WebMethod]
        public static int DeleteCard(long id, long memberId, int type)
        {
            var memberCard = new MembersTranspondersRepository().GetTransponderById(id);

            if (memberCard != null)
            {
                var cardList = new MembersTranspondersRepository().GetMemberTransponders(memberId, memberCard.TransponderNr);
                foreach (var card in cardList)
                {
                    new MembersTranspondersRepository().DeleteMemberTransponder(card);
                }

            }
            return type;
        }
        protected void FilterMembers(long groupId, int type)
        {
            var members = new MembersViewModel().MemberDetails().Where(x => x.MemberGroupId == groupId);
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            cobMemberNr.DataSource = memberList;
        }
        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void cobMemberGroupNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            List<MemberGroupDto> memberGroupList = new List<MemberGroupDto>();
            MemberGroupDto _member = new MemberGroupDto() { Id = 0, GroupNr = 0, GroupNumber = "Alle", GroupName = "Alle" };
            memberGroupList.Add(_member);
            //var memberGroups = new MembersViewModel().MemberGroups();
            var memberGroups = new MembersViewModel().FilterMemberGroups();
            memberGroupList.AddRange(memberGroups);
            cobMemberGroupNr.DataSource = memberGroupList;
            cobMemberGroupNr.DataBind();
            cobMemberGroupNr.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cobMemberGroupNr.Value = e.Parameter.ToString();
            }

        }

        protected void cobMemberGroupName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            List<MemberGroupDto> memberGroupList = new List<MemberGroupDto>();
            MemberGroupDto _member = new MemberGroupDto() { Id = 0, GroupNr = 0, GroupNumber = "Alle", GroupName = "Alle" };
            memberGroupList.Add(_member);
            //var memberGroups = new MembersViewModel().MemberGroups();
            var memberGroups = new MembersViewModel().FilterMemberGroups();
            memberGroupList.AddRange(memberGroups);

            cobMemberGroupName.DataSource = memberGroupList;
            cobMemberGroupName.DataBind();
            cobMemberGroupName.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cobMemberGroupName.Value = e.Parameter.ToString();
            }

        }

        [WebMethod]
        public static long GetNextMemberNr()
        {
            long nextNr = 0;
            var members = new MembersDataRepository().GetAllMembersData();
            if (members.Count > 0)
            {
                var maxNr = Convert.ToInt64(members.Max(x => x.MemberNumber));
                nextNr = maxNr;
            }
            return nextNr + 1;
        }
        protected void BindSearchGrid()
        {
            var membersData = new MembersViewModel().MemberSearchDetails();
            grdSearchMember.DataSource = membersData;
            grdSearchMember.DataBind();
            if (membersData.Count() > 31)
            {
                //grdSearchMember.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdSearchMember.Settings.VerticalScrollableHeight = 729;
                grdSearchMember.SettingsPager.PageSize = membersData.Count();
            }
        }
        protected void BindSearchGridByGroupId(long groupId)
        {
            var membersData = new MembersViewModel().MemberSearchDetails().Where(x => x.GroupId == groupId).ToList();
            grdSearchMember.DataSource = membersData;
            grdSearchMember.DataBind();
            if (membersData.Count() > 31)
            {
                //grdSearchMember.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdSearchMember.Settings.VerticalScrollableHeight = 729;
                grdSearchMember.SettingsPager.PageSize = membersData.Count();
            }
        }
        protected void btnMemberDocs_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/MembersDocumente.aspx");
        }

        protected void btnMemberForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/MembersForm.aspx");
        }


        protected void grdSearchMember_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var id = Convert.ToInt64(e.Parameters);
                if (id > 0)
                {
                    BindSearchGridByGroupId(id);
                }
                else
                {
                    BindSearchGrid();
                }
            }
            else
            {
                BindSearchGrid();
            }
        }

        protected void cboMemberNameSearch_OnItemsRequestedByFilterCondition(object sender, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            if (MemberList.Count == 0) MemberList = new MembersViewModel().GetAllMembersData(true).ToList();
            ASPxComboBox _cboPersOnNameSearch = (ASPxComboBox)sender;
            List<MembersDataDto> _MemberList = new List<MembersDataDto>();

            if (!String.IsNullOrEmpty(e.Filter))
            {
                List<MembersDataDto> _MemberListFirstName = MemberList.Where(x => (x.FirstName ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<MembersDataDto>();
                List<MembersDataDto> _MemberListSurname = MemberList.Where(x => (x.SurName ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<MembersDataDto>();
                List<MembersDataDto> _MemberListMemberNumber = MemberList.Where(x => (x.MemberNumber.ToString() ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<MembersDataDto>();
                List<MembersDataDto> _MemberListAgreementNr = MemberList.Where(x => (x.AgreementNr ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<MembersDataDto>();

                List<MembersDataDto> _MemberListFilter = new List<MembersDataDto>();
                _MemberListFilter.AddRange(_MemberListFirstName);
                _MemberListFilter.AddRange(_MemberListSurname);
                _MemberListFilter.AddRange(_MemberListMemberNumber);
                _MemberListFilter.AddRange(_MemberListAgreementNr);
                _MemberList.AddRange(_MemberListFilter.Distinct().ToList());
            }
            else
            {
                _MemberList.AddRange(MemberList);
            }

            _cboPersOnNameSearch.DataSource = _MemberList;
            _cboPersOnNameSearch.DataBind();
        }
        protected void cboMemberNameSearch_OnItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            MembersDataDto member = new MembersViewModel().GetMemberById(value, true);
            List<MembersDataDto> memberList = new List<MembersDataDto>();

            if (member != null)
            {
                memberList.Add(member);
                comboBox.DataSource = memberList;
                comboBox.DataBind();
            }
        }

        protected void cmbPersAccessGroup_Init(object sender, EventArgs e)
        {
            ASPxComboBox _sender = (ASPxComboBox)sender;
            List<TbAccessPlanGroup> PersAccessGroups = new List<TbAccessPlanGroup>();

            if (HttpContext.Current.Session["Pers_PersAccessGroups"] != null)
            {
                List<TbAccessPlanGroup> persAccessGroups = new List<TbAccessPlanGroup>();
                persAccessGroups = (List<TbAccessPlanGroup>)HttpContext.Current.Session["Pers_PersAccessGroups"];
                PersAccessGroups.AddRange(persAccessGroups);
            }
            _sender.DataSource = PersAccessGroups;
            _sender.DataBind();
            if (!IsCallback && !IsPostBack)
                _sender.SelectedIndex = 0;
        }

        public TbAccessPlanGroup GetAccessPlanGroup(long GroupId)
        {
            List<TbAccessPlanGroup> PersAccessGroups = new List<TbAccessPlanGroup>();

            if (HttpContext.Current.Session["Pers_PersAccessGroups"] != null)
            {
                List<TbAccessPlanGroup> persAccessGroups = new List<TbAccessPlanGroup>();
                persAccessGroups = (List<TbAccessPlanGroup>)HttpContext.Current.Session["Pers_PersAccessGroups"];
                PersAccessGroups.AddRange(persAccessGroups);

                return PersAccessGroups.FirstOrDefault(x => x.ID == GroupId) ?? new TbAccessPlanGroup();
            }

            return new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" };
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string ConvertImageBytesToURL(string imageBytes, string strId, string names)
        {
            string photoImageFile = string.Empty;
            long id;
            long.TryParse(strId, out id);
            string firstName = string.Empty;

            var member = MemberList.FirstOrDefault(p => p.ID == id);

            if (member != null)
            {
                firstName = member.FirstName;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(names))
                {
                    var values = names.Split(' ');
                    if (values.Length == 2)
                    {
                        firstName = values[0];
                    }
                }
            }

            if (imageBytes.Length > 0)// get from binary
            {
                photoImageFile = FileProcessor.SaveMemberPhoto("," + imageBytes, firstName + strId + DateTime.Now.ToString("yyyyMMddHHmmss"));
                photoImageFile = FileProcessor.GetMemberImageRelativeFilePath(photoImageFile);
            }

            return photoImageFile;
        }

    }
}