using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using Newtonsoft.Json;
using System.Web.Services;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsMembersList : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Reports_PMode");
            }
            set
            {
                HttpContext.Current.Session["Reports_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Reports, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;
            _initializeReportViewer();

            if (!IsPostBack)
            {
                LoadStudioGroups();
                LoadMembers();
                _DefaultChecks();
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblPersNameB.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblPersNameC.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
                lblPersNameD.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();

                _bindSavedList();
                grdSavedMemberList.FocusedRowIndex = -1;
                chkLandScape.Checked = true;
                chkVarientBLand.Checked = true;
                chkVarCLand.Checked = true;
                chkLandD.Checked = true;
            }
        }

        //private void _initializeReportViewer()
        //{
        //    if (chkVariableA.Checked)
        //    {
        //        PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarA());
        //    }

        //    if (chkVariableB.Checked)
        //    {
        //        PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarB());
        //    }
        //    if (chkVariableC.Checked)
        //    {
        //        PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarC());
        //    }
        //    if (chkVariableD.Checked)
        //    {
        //        PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarD());
        //    }
        //}
        private void _initializeReportViewer()
        {
            if (chkVariableA.Checked)
            {
                if (chkVarientBLand.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarA());
                }
                else if (chkVarientBPotrait.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarAPotrait());
                }
            }

            if (chkVariableB.Checked)
            {
                if (chkLandScape.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarB());
                }
                else if (chkPortrait.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarBPotrait());
                }
            }
            if (chkVariableC.Checked)
            {
                if (chkVarCLand.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarC());
                }
                else if (chkVarCPotait.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarCPotrait());
                }
            }
            if (chkVariableD.Checked)
            {
                if (chkLandD.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarD());
                }
                else if (chkpotraitD.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new MemberReportListVarDPotrait());
                }
            }
        }
        protected void _DefaultChecks()
        {
            chkVariableB.Checked = true;
            chkMemberName.Checked = true;
        }

        protected void LoadStudioGroups()
        {
            List<MemberGroup> groupsList = new List<MemberGroup>();
            MemberGroup memberGroup = new MemberGroup() { Id = 0, GroupNr = 0, GroupName = "Keine Auswahl" };
            var studioGroups = new MemberGroupsRepositories().GetAllMemberGroups();
            groupsList.Add(memberGroup);
            groupsList.AddRange(studioGroups);
            cobStudioGroupFrom.DataSource = groupsList;
            cobStudioGroupFrom.DataBind();
            cobStudioGroupFrom.SelectedIndex = 0;
            cobStudioGroupTo.DataSource = groupsList;
            cobStudioGroupTo.DataBind();
            cobStudioGroupTo.SelectedIndex = 0;
        }
        protected void LoadMembers()
        {
            var members = new MembersViewModel().MemberDetails();
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "Keine Auswahl", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            var places = GetMemberPlaces(memberList);
            var postalCodes = GetPostalCodes(memberList);
            cobMemberNameFrom.DataSource = memberList;
            cobMemberNameFrom.DataBind();
            cobMemberNameFrom.SelectedIndex = 0;
            cobMemberNameTo.DataSource = memberList;
            cobMemberNameTo.DataBind();
            cobMemberNameTo.SelectedIndex = 0;
            cobMemberNumberFrom.DataSource = memberList;
            cobMemberNumberFrom.DataBind();
            cobMemberNumberFrom.SelectedIndex = 0;
            cobMemberNumberTo.DataSource = memberList;
            cobMemberNumberTo.DataBind();
            cobMemberNumberTo.SelectedIndex = 0;
            cobMemberPlaceFrom.DataSource = places;
            cobMemberPlaceFrom.DataBind();
            cobMemberPlaceFrom.SelectedIndex = 0;
            cobMemberPlaceTo.DataSource = places;
            cobMemberPlaceTo.DataBind();
            cobMemberPlaceTo.SelectedIndex = 0;
            cobMemberPostalCodeFrom.DataSource = postalCodes;
            cobMemberPostalCodeFrom.DataBind();
            cobMemberPostalCodeFrom.SelectedIndex = 0;
            cobMemberPostalCodeTo.DataSource = postalCodes;
            cobMemberPostalCodeTo.DataBind();
            cobMemberPostalCodeTo.SelectedIndex = 0;
        }
        public class PostalCodes
        {
            public long ID { get; set; }
            public long PostalCode { get; set; }
        }
        public class MemberPlaces
        {
            public long ID { get; set; }
            public string Place { get; set; }
        }
        public List<PostalCodes> GetPostalCodes(List<MembersDataDto> postalCodes)
        {
            List<PostalCodes> codes = new List<PostalCodes>();
            PostalCodes _code = new PostalCodes() { ID = 0, PostalCode = 0 };
            codes.Add(_code);
            long i = 1;
            foreach (var postalCode in postalCodes)
            {
                long num = 0;
                long.TryParse(postalCode.PostalCode, out num);
                if (num != 0)
                {
                    PostalCodes code = new PostalCodes()
                    {
                        ID = i,
                        PostalCode = num
                    };
                    i++;
                    codes.Add(code);
                }
            }
            return codes.OrderBy(x => x.PostalCode).Distinct().ToList();
        }
        public List<MemberPlaces> GetMemberPlaces(List<MembersDataDto> memberplaces)
        {
            List<MemberPlaces> places = new List<MemberPlaces>();
            List<MemberPlaces> places2 = new List<MemberPlaces>();
            MemberPlaces _place = new MemberPlaces() { ID = 0, Place = "Keine Auswahl" };
            places2.Add(_place);
            long i = 1;
            foreach (var place in memberplaces)
            {
                if (!string.IsNullOrWhiteSpace(place.Place))
                {
                    MemberPlaces cPlace = new MemberPlaces()
                    {
                        ID = i,
                        Place = place.Place
                    };
                    i++;
                    places.Add(cPlace);
                }
            }
            places2.AddRange(places.OrderBy(x => x.Place).Distinct().ToList());
            return places2;
        }
        protected void BindGridA(List<ReportsMembersListDto> members)
        {

            grdVariableA.DataSource = members;
            grdVariableA.DataBind();
            if (members.Count > 31)
            {
                grdVariableA.SettingsPager.PageSize = members.Count;
            }
            HideGridColumsA();
            HideReportsColumns();
            Session["MembersListARpt"] = members;
        }
        protected void BindGridB(List<ReportsMembersListDto> members)
        {

            grdVariableB.DataSource = members;
            grdVariableB.DataBind();
            if (members.Count > 31)
            {
                grdVariableB.SettingsPager.PageSize = members.Count;
            }
            HideGridColumsB();
            HideReportsColumns();
            Session["MembersListBRpt"] = members;
        }
        protected void BindGridC(List<ReportsMembersListDto> members)
        {

            grdVariableC.DataSource = members;
            grdVariableC.DataBind();
            if (members.Count > 31)
            {
                grdVariableC.SettingsPager.PageSize = members.Count;
            }
            HideGridColumsC();
            HideReportsColumns();
            Session["MembersListCRpt"] = members;
        }
        protected void BindGridD(List<ReportsMembersListDto> members)
        {

            grdVariableD.DataSource = members;
            grdVariableD.DataBind();
            if (members.Count > 31)
            {
                grdVariableD.SettingsPager.PageSize = members.Count;
            }
            HideGridColumsD();
            HideReportsColumns();
            Session["MembersListDRpt"] = members;
        }
        protected List<ReportsMembersListDto> FilterMembers(long groupFrom, long groupTo, long nameFromNr, long nameToNr, long memberNumberFrom, long memberNumberTo, long postalCodeFrom, long PostalCodeTo, bool MemberActive, bool MemberInactive, string groupBy,long placeFromId, long placeToId,string placeFromName, string placeToName)
        {

            var members = GetMembersDetails(cobStudioGroupFrom.Text, cobStudioGroupTo.Text, cobMemberNameFrom.Text, cobMemberNameTo.Text, cobMemberPlaceFrom.Text, cobMemberPlaceTo.Text);
            if (MemberActive == true)
            {
                members = members.Where(x => x.IsMemberActive == true).ToList();
            }
            else if (MemberInactive == true)
            {
                members = members.Where(x => x.IsMemberActive == false).ToList();
            }
            if (groupFrom != 0 && groupTo != 0)
            {
                members = members.Where(x => x.GroupNumber >= groupFrom && x.GroupNumber <= groupTo).ToList();
            }
            if (nameFromNr != 0 && nameToNr != 0)
            {
                members = members.Where(x => x.MemberNumber >= nameFromNr && x.MemberNumber <= nameToNr).ToList();
            }
            if (memberNumberFrom != 0 && memberNumberTo != 0)
            {
                members = members.Where(x => x.MemberNumber >= memberNumberFrom && x.MemberNumber <= memberNumberTo).ToList();
            }
            if (postalCodeFrom != 0 && PostalCodeTo != 0)
            {
                members = members.Where(x => x.PostalCodeFilter >= postalCodeFrom && x.PostalCodeFilter <= PostalCodeTo).ToList();
            }
            if(placeFromId != 0 && placeToId != 0)
            {
                members = new ReportsMembersListViewModel().FilterMemberByPlace(members,placeFromName ,placeToName);
            }

            members = new ReportsMembersListViewModel().GroupList(members, groupBy);
            return members;
        }

        protected List<ReportsMembersListDto> GetMembersDetails(string groupfrom, string groupTo, string memberNameFrom, string memberNameTo, string placeFrom, string placeTo)
        {
            var membersList = new MembersDataRepository().GetAllMembersData();
            var memberCards = new MembersTranspondersRepository().GetAllMemberTransponders();
            var memberAccessTime = new MembersAccessPlanMappingRepository().GetAllMembersPLans();
            var salutations = new SalutationsRepository().GetSalutation().Where(c => c.AnredeCode > 0).OrderBy(x => x.AnredeCode).Take(2).ToList();
            List<ReportsMembersListDto> memberListDto = new List<ReportsMembersListDto>();
            foreach (var member in membersList)
            {
                var salutation = member.Salutation != null ? salutations.FirstOrDefault(x => x.AnredeCode == member.Salutation) : null;
                var memberCard = memberCards.Where(x => x.MemberID == member.ID).ToList();
                var accessPlan = memberAccessTime.FirstOrDefault(x => x.MemberID == member.ID);
                var cardLongTerm = memberCard != null ? memberCard.Where(x => x.TransponderType == 1) : new List<MembersTransponder>();
                var cardShortTerm = memberCard != null ? memberCard.Where(x => x.TransponderType == 2) : new List<MembersTransponder>();
                DateTime? accessFrom = accessPlan != null ? accessPlan.DateFrom : null;
                DateTime? accessTo = accessPlan != null ? accessPlan.DateTo : null;
                var fromTime = accessFrom != null ? Convert.ToDateTime(accessFrom).ToShortDateString() : "";
                var toTime = accessTo != null ? Convert.ToDateTime(accessTo).ToShortDateString() : "";
                var fromToTime = string.Format("{0}-{1}", fromTime, toTime);
                long _postalCodeFilter = -1;
                long.TryParse(member.PostalCode, out _postalCodeFilter);
                ReportsMembersListDto memberDto = new ReportsMembersListDto();
                memberDto.ID = member.ID;
                memberDto.MemberNumber = member.MemberNumber;
                memberDto.MemberName = string.Format("{0} {1}", member.SurName, member.FirstName);
                memberDto.GroupName = member.MemberGroupId != null ? member.MemberGroup.GroupName : "";
                memberDto.GroupNumber = member.MemberGroupId != null ? member.MemberGroupId : null;
                memberDto.Place = member.Place;
                memberDto.PostalCode = member.PostalCode;
                memberDto.PostalCodeFilter = _postalCodeFilter;
                memberDto.Salutation = salutation != null ? salutation.AnredeName : null;
                memberDto.StreetNumber = string.Format("{0} {1}", member.Street, member.StreetNumber);
                memberDto.ContractNumber = member.AgreementNr;
                memberDto.DateOfBirth = member.DateOfBirth;
                memberDto.Nationality = member.Nationality;
                memberDto.Profession = member.Profession;
                memberDto.Telephone = member.Telephone;
                memberDto.MobileNr = member.MobilePhone;
                memberDto.Email = member.Email;
                memberDto.StartDate = member.EntryDate;
                memberDto.EndDate = member.ExitDate;
                memberDto.LongTermCardNumber = cardLongTerm.Count() > 0 ? cardLongTerm.FirstOrDefault().TransponderNr :(long?) null;
                memberDto.ShortTermCardNumber = cardShortTerm.Count() > 0 ? cardShortTerm.FirstOrDefault().TransponderNr : (long?)null;
                memberDto.AccessDateFromTo = fromToTime.Count() < 2 ? "" : fromToTime;
                memberDto.AccessPlanNr = accessPlan != null ? accessPlan.TbAccessPlan.AccessPlanNr : (long?)null;
                memberDto.AccessPlanName = accessPlan != null ? accessPlan.TbAccessPlan.AccessPlanDescription : "";
                memberDto.GroupNameFrom = groupfrom;
                memberDto.GroupNameTo = groupTo;
                memberDto.MemberNameFrom = memberNameFrom;
                memberDto.MemberNameTo = memberNameTo;
                memberDto.PlaceFrom = placeFrom;
                memberDto.PlaceTo = placeTo;
                memberDto.IsMemberActive = member.Active != null ? Convert.ToBoolean(member.Active) : false;
                memberDto.LoggedInUser = Session["Pers_Name"] != null ? Session["Pers_Name"].ToString() : "";
                memberListDto.Add(memberDto);
            }
            return memberListDto;
        }

        protected void grdVariableA_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {

            if (!string.IsNullOrEmpty(e.Parameters))
            {
                List<MembersListRptDto> memberData = JsonConvert.DeserializeObject<List<MembersListRptDto>>(e.Parameters);
                if (memberData.Count > 0)
                {
                    var param = memberData[0];
                    BindGridA(FilterMembers(param.GroupFrom, param.GroupTo, param.NameNrFrom, param.NameNrTo, param.MemberNumberFrom, param.MemberNumberTo, param.PostalCodeFrom, param.PostalCodeTo, param.AciveMembers, param.InAaciveMembers, param.GroupBy, param.PlaceIdFrom, param.PlaceIdTo, param.PlaceNameFrom, param.PlaceNameTo));
                }

            }



        }

        protected void OneTodayCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        protected void grdVariableB_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                List<MembersListRptDto> memberData = JsonConvert.DeserializeObject<List<MembersListRptDto>>(e.Parameters);
                if (memberData.Count > 0)
                {
                    var param = memberData[0];
                    BindGridB(FilterMembers(param.GroupFrom, param.GroupTo, param.NameNrFrom, param.NameNrTo, param.MemberNumberFrom, param.MemberNumberTo, param.PostalCodeFrom, param.PostalCodeTo, param.AciveMembers, param.InAaciveMembers, param.GroupBy, param.PlaceIdFrom, param.PlaceIdTo, param.PlaceNameFrom, param.PlaceNameTo));
                }

            }

        }

        protected void grdVariableC_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {

            if (!string.IsNullOrEmpty(e.Parameters))
            {
                List<MembersListRptDto> memberData = JsonConvert.DeserializeObject<List<MembersListRptDto>>(e.Parameters);
                if (memberData.Count > 0)
                {
                    var param = memberData[0];
                    BindGridC(FilterMembers(param.GroupFrom, param.GroupTo, param.NameNrFrom, param.NameNrTo, param.MemberNumberFrom, param.MemberNumberTo, param.PostalCodeFrom, param.PostalCodeTo, param.AciveMembers, param.InAaciveMembers, param.GroupBy, param.PlaceIdFrom, param.PlaceIdTo, param.PlaceNameFrom, param.PlaceNameTo));
                }

            }
        }

        protected void grdVariableD_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //BindGridD(FilterMembers(0, 0, 0, 0, 0, 0, 0, 0));
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                List<MembersListRptDto> memberData = JsonConvert.DeserializeObject<List<MembersListRptDto>>(e.Parameters);
                if (memberData.Count > 0)
                {
                    var param = memberData[0];
                    BindGridD(FilterMembers(param.GroupFrom, param.GroupTo, param.NameNrFrom, param.NameNrTo, param.MemberNumberFrom, param.MemberNumberTo, param.PostalCodeFrom, param.PostalCodeTo, param.AciveMembers, param.InAaciveMembers, param.GroupBy, param.PlaceIdFrom, param.PlaceIdTo, param.PlaceNameFrom, param.PlaceNameTo));
                }

            }

        }
        protected void HideGridColumsA()
        {
            grdVariableA.Columns["GroupName"].Visible = chkStudioGroup.Checked;
            grdVariableA.Columns["MemberName"].Visible = chkMemberName.Checked;
            grdVariableA.Columns["MemberNumber"].Visible = chkMemberNumber.Checked;
            grdVariableA.Columns["Place"].Visible = chkPlace.Checked;
            grdVariableA.Columns["PostalCode"].Visible = chkPostalCode.Checked;
            grdVariableA.Columns["Salutation"].Visible = chkSalutation.Checked;
            grdVariableA.Columns["StreetNumber"].Visible = chkStreetNumber.Checked;
            grdVariableA.Columns["ContractNumber"].Visible = chkContractNumber.Checked;
            grdVariableA.Columns["DateOfBirth"].Visible = chkDateOfBirth.Checked;
            grdVariableA.Columns["Nationality"].Visible = chkNationality.Checked;
            grdVariableA.Columns["Profession"].Visible = chkProfession.Checked;
            grdVariableA.Columns["Telephone"].Visible = chkTelephone.Checked;
            grdVariableA.Columns["MobileNr"].Visible = chkMobile.Checked;
            grdVariableA.Columns["Email"].Visible = chkEmail.Checked;
            grdVariableA.Columns["StartDate"].Visible = chkStartDate.Checked;
            grdVariableA.Columns["EndDate"].Visible = chkEndDate.Checked;
            grdVariableA.Columns["LongTermCardNumber"].Visible = chkLongtermCard.Checked;
            grdVariableA.Columns["ShortTermCardNumber"].Visible = chkShortTermCard.Checked;
            grdVariableA.Columns["AccessDateFromTo"].Visible = chkAccessFromTo.Checked;
            grdVariableA.Columns["AccessPlanNr"].Visible = chkAccessPlanNr.Checked;
            grdVariableA.Columns["AccessPlanName"].Visible = chkAccessPlanName.Checked;

        }
        protected void HideGridColumsB()
        {
            grdVariableB.Columns["GroupName"].Visible = chkStudioGroup.Checked;
            grdVariableB.Columns["MemberName"].Visible = chkMemberName.Checked;
            grdVariableB.Columns["MemberNumber"].Visible = chkMemberNumber.Checked;
            grdVariableB.Columns["Place"].Visible = chkPlace.Checked;
            grdVariableB.Columns["PostalCode"].Visible = chkPostalCode.Checked;
            grdVariableB.Columns["Salutation"].Visible = chkSalutation.Checked;
            grdVariableB.Columns["StreetNumber"].Visible = chkStreetNumber.Checked;
            grdVariableB.Columns["ContractNumber"].Visible = chkContractNumber.Checked;
            grdVariableB.Columns["DateOfBirth"].Visible = chkDateOfBirth.Checked;
            grdVariableB.Columns["Nationality"].Visible = chkNationality.Checked;
            grdVariableB.Columns["Profession"].Visible = chkProfession.Checked;
            grdVariableB.Columns["Telephone"].Visible = chkTelephone.Checked;
            grdVariableB.Columns["MobileNr"].Visible = chkMobile.Checked;
            grdVariableB.Columns["Email"].Visible = chkEmail.Checked;
            grdVariableB.Columns["StartDate"].Visible = chkStartDate.Checked;
            grdVariableB.Columns["EndDate"].Visible = chkEndDate.Checked;
            grdVariableB.Columns["LongTermCardNumber"].Visible = chkLongtermCard.Checked;
            grdVariableB.Columns["ShortTermCardNumber"].Visible = chkShortTermCard.Checked;
            grdVariableB.Columns["AccessDateFromTo"].Visible = chkAccessFromTo.Checked;
            grdVariableB.Columns["AccessPlanNr"].Visible = chkAccessPlanNr.Checked;
            grdVariableB.Columns["AccessPlanName"].Visible = chkAccessPlanName.Checked;

        }
        protected void HideGridColumsC()
        {
            grdVariableC.Columns["GroupName"].Visible = chkStudioGroup.Checked;
            grdVariableC.Columns["MemberName"].Visible = chkMemberName.Checked;
            grdVariableC.Columns["MemberNumber"].Visible = chkMemberNumber.Checked;
            grdVariableC.Columns["Place"].Visible = chkPlace.Checked;
            grdVariableC.Columns["PostalCode"].Visible = chkPostalCode.Checked;
            grdVariableC.Columns["Salutation"].Visible = chkSalutation.Checked;
            grdVariableC.Columns["StreetNumber"].Visible = chkStreetNumber.Checked;
            grdVariableC.Columns["ContractNumber"].Visible = chkContractNumber.Checked;
            grdVariableC.Columns["DateOfBirth"].Visible = chkDateOfBirth.Checked;
            grdVariableC.Columns["Nationality"].Visible = chkNationality.Checked;
            grdVariableC.Columns["Profession"].Visible = chkProfession.Checked;
            grdVariableC.Columns["Telephone"].Visible = chkTelephone.Checked;
            grdVariableC.Columns["MobileNr"].Visible = chkMobile.Checked;
            grdVariableC.Columns["Email"].Visible = chkEmail.Checked;
            grdVariableC.Columns["StartDate"].Visible = chkStartDate.Checked;
            grdVariableC.Columns["EndDate"].Visible = chkEndDate.Checked;
            grdVariableC.Columns["LongTermCardNumber"].Visible = chkLongtermCard.Checked;
            grdVariableC.Columns["ShortTermCardNumber"].Visible = chkShortTermCard.Checked;
            grdVariableC.Columns["AccessDateFromTo"].Visible = chkAccessFromTo.Checked;
            grdVariableC.Columns["AccessPlanNr"].Visible = chkAccessPlanNr.Checked;
            grdVariableC.Columns["AccessPlanName"].Visible = chkAccessPlanName.Checked;

        }
        protected void HideGridColumsD()
        {
            grdVariableD.Columns["GroupName"].Visible = chkStudioGroup.Checked;
            grdVariableD.Columns["MemberName"].Visible = chkMemberName.Checked;
            grdVariableD.Columns["MemberNumber"].Visible = chkMemberNumber.Checked;
            grdVariableD.Columns["Place"].Visible = chkPlace.Checked;
            grdVariableD.Columns["PostalCode"].Visible = chkPostalCode.Checked;
            grdVariableD.Columns["Salutation"].Visible = chkSalutation.Checked;
            grdVariableD.Columns["StreetNumber"].Visible = chkStreetNumber.Checked;
            grdVariableD.Columns["ContractNumber"].Visible = chkContractNumber.Checked;
            grdVariableD.Columns["DateOfBirth"].Visible = chkDateOfBirth.Checked;
            grdVariableD.Columns["Nationality"].Visible = chkNationality.Checked;
            grdVariableD.Columns["Profession"].Visible = chkProfession.Checked;
            grdVariableD.Columns["Telephone"].Visible = chkTelephone.Checked;
            grdVariableD.Columns["MobileNr"].Visible = chkMobile.Checked;
            grdVariableD.Columns["Email"].Visible = chkEmail.Checked;
            grdVariableD.Columns["StartDate"].Visible = chkStartDate.Checked;
            grdVariableD.Columns["EndDate"].Visible = chkEndDate.Checked;
            grdVariableD.Columns["LongTermCardNumber"].Visible = chkLongtermCard.Checked;
            grdVariableD.Columns["ShortTermCardNumber"].Visible = chkShortTermCard.Checked;
            grdVariableD.Columns["AccessDateFromTo"].Visible = chkAccessFromTo.Checked;
            grdVariableD.Columns["AccessPlanNr"].Visible = chkAccessPlanNr.Checked;
            grdVariableD.Columns["AccessPlanName"].Visible = chkAccessPlanName.Checked;

        }
        protected void HideReportsColumns()
        {
            ReportsMembersListDto hideColumns = new ReportsMembersListDto();
            hideColumns.HideGroupName = chkStudioGroup.Checked;
            hideColumns.HideMemberName = chkMemberName.Checked;
            hideColumns.HideMemberNumber = chkMemberNumber.Checked;
            hideColumns.HidePlace = chkPlace.Checked;
            hideColumns.HidePostalCode = chkPostalCode.Checked;
            hideColumns.HideSalutation = chkSalutation.Checked;
            hideColumns.HideStreetNumber = chkStreetNumber.Checked;
            hideColumns.HideContractNumber = chkContractNumber.Checked;
            hideColumns.HideDateOfBirth = chkDateOfBirth.Checked;
            hideColumns.HideNationality = chkNationality.Checked;
            hideColumns.HideProfession = chkProfession.Checked;
            hideColumns.HideTelephone = chkTelephone.Checked;
            hideColumns.HideMobileNr = chkMobile.Checked;
            hideColumns.HideEmail = chkEmail.Checked;
            hideColumns.HideStartDate = chkStartDate.Checked;
            hideColumns.HideEndDate = chkEndDate.Checked;
            hideColumns.HideLongTermCardNumber = chkLongtermCard.Checked;
            hideColumns.HideShortTermCardNumber = chkShortTermCard.Checked;
            hideColumns.HideAccessDateFromTo = chkAccessFromTo.Checked;
            hideColumns.HideAccessPlanNr = chkAccessPlanNr.Checked;
            hideColumns.HideAccessPlanName = chkAccessPlanName.Checked;
            Session["MemberListRptHideColumns"] = hideColumns;
        }




        //saving for the settings

        protected void _bindSavedList()
        {
            AccessReportMemberListsRepository _memberReportList = new AccessReportMemberListsRepository();
            var memberReportList = _memberReportList.GetAllMemberLists();

            List<AC_ReportList> memberlist = new List<AC_ReportList>();
            memberlist = memberReportList.OrderBy(x => x.ListNr).ToList();
            memberlist.Insert(0, new AC_ReportList { ListNr = 0, ListDescription = "Keine Auswahl" });

            cobMemberNumber.DataSource = memberlist;
            cobMemberNumber.DataBind();
            cobMemberNumber.SelectedIndex = 0;

            cobMemberName.DataSource = memberlist;
            cobMemberName.DataBind();
            cobMemberName.SelectedIndex = 0;

            grdSavedMemberList.DataSource = memberReportList;
            grdSavedMemberList.DataBind();
        }

        [WebMethod]
        public static long CalculateNextNr()
        {
            var memberListReportList = new AccessReportMemberListsRepository().GetAllMemberLists();
            long lastMemberReportList = 0;
            if (memberListReportList.Count > 0)
            {
                lastMemberReportList = memberListReportList.Max(x => x.ListNr);
            }
            return lastMemberReportList + 1;
        }

        [WebMethod]
        public static bool CheckIfListNrExists(string memberListNr)
        {
            var exists = false;
            AccessReportMemberListsRepository _memberReportList = new AccessReportMemberListsRepository();
            var reportMembersList = _memberReportList.GetMemberListByNr(Convert.ToInt64(memberListNr));

            if (reportMembersList != null)
            {
                exists = true;
            }
            return exists;
        }

        [WebMethod]
        public static int Isnewrecord(string memberListNr)
        {
            int i;
            AccessReportMemberListsRepository _memberReportList = new AccessReportMemberListsRepository();
            var memberReportList = _memberReportList.GetMemberListByNr(Convert.ToInt64(memberListNr));

            if (memberReportList != null)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }

        [WebMethod]
        public static long CreateMemberListInDatabase(string jSONData)
        {
            long Id = 0;
            AccessReportMemberListsRepository _memberList = new AccessReportMemberListsRepository();
            AccessMemberListsChecksRepository _memberListChecks = new AccessMemberListsChecksRepository();
            AC_ReportList _reportList = new AC_ReportList();
            AC_ReportListChecks _reportChecks = new AC_ReportListChecks();
            ReportsMemberListDto _listDto = new ReportsMemberListDto();
            List<ReportsMemberListDto> memberReportList = JsonConvert.DeserializeObject<List<ReportsMemberListDto>>(jSONData);
            if (memberReportList.Count > 0)
            {

                _listDto = memberReportList.FirstOrDefault();

                _reportList.ListNr = _listDto.ListNr;
                _reportList.ListDescription = _listDto.ListDescription;
                _reportList.MemberType = _listDto.MemberType;
                _reportList.StartStudioGroup = _listDto.StartStudioGroup;
                _reportList.EndStudioGroup = _listDto.EndStudioGroup;
                _reportList.StartName = _listDto.StartMemberName;
                _reportList.EndName = _listDto.EndMemberName;
                _reportList.StartIdNr = _listDto.StartMemberId;
                _reportList.EndIdNr = _listDto.EndMemberId;
                _reportList.StartPlace = _listDto.StartPlace;
                _reportList.EndPlace = _listDto.EndPlace;
                _reportList.StartPostalCode = _listDto.StartPostalCode;
                _reportList.EndPostalCode = _listDto.EndPostalCode;
                _reportList.VariableType = _listDto.VariableType;

                _memberList.NewMemberList(_reportList);
                Id = _reportList.ID;
                var reportListId = _reportList.ID;
                _reportChecks.ReportListID = reportListId;
                _reportChecks.ShowMemberGroup = _listDto.ShowStudioGroup;
                _reportChecks.ShowName = _listDto.ShowMemberName;
                _reportChecks.ShowIDNr = _listDto.ShowMemberId;
                _reportChecks.ShowPlace = _listDto.ShowPlace;
                _reportChecks.ShowPostalCode = _listDto.ShowPostalCode;
                _reportChecks.ShowSalutation = _listDto.ShowSalutation;
                _reportChecks.ShowStreetAndNr = _listDto.ShowStreetAndNr;
                _reportChecks.ShowContractNr = _listDto.ShowContractNr;
                _reportChecks.ShowDOB = _listDto.ShowDOB;
                _reportChecks.ShowNationality = _listDto.ShowNationality;
                _reportChecks.ShowProfession = _listDto.ShowProfession;
                _reportChecks.ShowCompanyTelephone = _listDto.ShowTelephone;
                _reportChecks.ShowCompanyMobile = _listDto.ShowMobile;
                _reportChecks.ShowEmail = _listDto.ShowEmail;
                _reportChecks.ShowEntryDate = _listDto.ShowEntryDate;
                _reportChecks.ShowExitDate = _listDto.ShowExitDate;
                _reportChecks.ShowLongTermCard = _listDto.ShowLongTermCard;
                _reportChecks.ShowShortTermCard = _listDto.ShowShortTermCard;
                _reportChecks.ShowAccessFromTo = _listDto.ShowAccessFromTo;
                _reportChecks.ShowAccessPlanNr = _listDto.ShowAccessPlanNr;
                _reportChecks.ShowAccessPlanDesc = _listDto.ShowAccessPlanDesc;

                _memberListChecks.NewmemberListCheck(_reportChecks);
            }
            return Id;
        }


        [WebMethod]
        public static long EditMemberListInDatabase(string jSONData)
        {
            long Id = 0;
            AccessReportMemberListsRepository _memberList = new AccessReportMemberListsRepository();
            AccessMemberListsChecksRepository _memberListChecks = new AccessMemberListsChecksRepository();
            AC_ReportList _reportList = new AC_ReportList();
            AC_ReportListChecks _reportChecks = new AC_ReportListChecks();
            ReportsMemberListDto _listDto = new ReportsMemberListDto();
            List<ReportsMemberListDto> memberReportList = JsonConvert.DeserializeObject<List<ReportsMemberListDto>>(jSONData);
            if (memberReportList.Count > 0)
            {
                _listDto = memberReportList.FirstOrDefault();

                _reportList.ID = _listDto.ID;
                _reportList.ListNr = _listDto.ListNr;
                _reportList.ListDescription = _listDto.ListDescription;
                _reportList.MemberType = _listDto.MemberType;
                _reportList.StartStudioGroup = _listDto.StartStudioGroup;
                _reportList.EndStudioGroup = _listDto.EndStudioGroup;
                _reportList.StartName = _listDto.StartMemberName;
                _reportList.EndName = _listDto.EndMemberName;
                _reportList.StartIdNr = _listDto.StartMemberId;
                _reportList.EndIdNr = _listDto.EndMemberId;
                _reportList.StartPlace = _listDto.StartPlace;
                _reportList.EndPlace = _listDto.EndPlace;
                _reportList.StartPostalCode = _listDto.StartPostalCode;
                _reportList.EndPostalCode = _listDto.EndPostalCode;
                _reportList.VariableType = _listDto.VariableType;

                _memberList.EditMemberList(_reportList);
                Id = _reportList.ID;
                _reportChecks = _memberListChecks.GetmemberListCheckByReportListId(_listDto.ID);

                _reportChecks.ReportListID = _listDto.ID;
                _reportChecks.ShowMemberGroup = _listDto.ShowStudioGroup;
                _reportChecks.ShowName = _listDto.ShowMemberName;
                _reportChecks.ShowIDNr = _listDto.ShowMemberId;
                _reportChecks.ShowPlace = _listDto.ShowPlace;
                _reportChecks.ShowPostalCode = _listDto.ShowPostalCode;
                _reportChecks.ShowSalutation = _listDto.ShowSalutation;
                _reportChecks.ShowStreetAndNr = _listDto.ShowStreetAndNr;
                _reportChecks.ShowContractNr = _listDto.ShowContractNr;
                _reportChecks.ShowDOB = _listDto.ShowDOB;
                _reportChecks.ShowNationality = _listDto.ShowNationality;
                _reportChecks.ShowProfession = _listDto.ShowProfession;
                _reportChecks.ShowCompanyTelephone = _listDto.ShowTelephone;
                _reportChecks.ShowCompanyMobile = _listDto.ShowMobile;
                _reportChecks.ShowEmail = _listDto.ShowEmail;
                _reportChecks.ShowEntryDate = _listDto.ShowEntryDate;
                _reportChecks.ShowExitDate = _listDto.ShowExitDate;
                _reportChecks.ShowLongTermCard = _listDto.ShowLongTermCard;
                _reportChecks.ShowShortTermCard = _listDto.ShowShortTermCard;
                _reportChecks.ShowAccessFromTo = _listDto.ShowAccessFromTo;
                _reportChecks.ShowAccessPlanNr = _listDto.ShowAccessPlanNr;
                _reportChecks.ShowAccessPlanDesc = _listDto.ShowAccessPlanDesc;

                _memberListChecks.EditmemberListCheck(_reportChecks);

            }
            return Id;
        }

        [WebMethod]
        public static AC_ReportList GetMemberReportlList(int ID)
        {
            AccessReportMemberListsRepository _memberRepo = new AccessReportMemberListsRepository();
            AC_ReportList _reportListTble = new AC_ReportList();
            var reportList = _memberRepo.GetMemberListById(ID);

            if (reportList == null)
            {
                return _reportListTble;
            }

            if (reportList != null)
            {
                _reportListTble.ID = reportList.ID;
                _reportListTble.ListNr = reportList.ListNr;
                _reportListTble.ListDescription = reportList.ListDescription;
                _reportListTble.MemberType = reportList.MemberType;
                _reportListTble.StartStudioGroup = reportList.StartStudioGroup;
                _reportListTble.EndStudioGroup = reportList.EndStudioGroup;
                _reportListTble.StartName = reportList.StartName;
                _reportListTble.EndName = reportList.EndName;
                _reportListTble.StartIdNr = reportList.StartIdNr;
                _reportListTble.EndIdNr = reportList.EndIdNr;
                _reportListTble.StartPlace = reportList.StartPlace;
                _reportListTble.EndPlace = reportList.EndPlace;
                _reportListTble.StartPostalCode = reportList.StartPostalCode;
                _reportListTble.EndPostalCode = reportList.EndPostalCode;
                _reportListTble.VariableType = reportList.VariableType;

            }

            return _reportListTble;
        }


        protected void RebingDropdowns()
        {
            AccessReportMemberListsRepository _memberReportList = new AccessReportMemberListsRepository();
            var membrsReportList = _memberReportList.GetAllMemberLists();

            List<AC_ReportList> memberList = new List<AC_ReportList>();
            memberList = membrsReportList.OrderBy(x => x.ListNr).ToList();
            memberList.Insert(0, new AC_ReportList { ListNr = 0, ListDescription = "Keine Auswahl" });

            cobMemberNumber.DataSource = memberList;
            cobMemberNumber.DataBind();

            cobMemberName.DataSource = memberList;
            cobMemberName.DataBind();
        }


        [WebMethod]
        public static AC_ReportListChecks GetMemberListCheckbyid(long id)
        {
            AccessMemberListsChecksRepository _AccessReportsChecks = new AccessMemberListsChecksRepository();

            AC_ReportListChecks _AC_ReportSettings = new AC_ReportListChecks();

            var ReportCheckID = _AccessReportsChecks.GetmemberListCheckByReportListId(id);

            if (ReportCheckID != null)
            {
                var Id = ReportCheckID.ID;


                var ReportSetting = _AccessReportsChecks.GetmemberListCheckById(Id);
                if (ReportSetting == null)
                {
                    return null;
                }

                if (ReportSetting != null)
                {
                    _AC_ReportSettings.ID = ReportSetting.ID;
                    _AC_ReportSettings.ReportListID = ReportSetting.ReportListID;
                    _AC_ReportSettings.ShowMemberGroup = ReportSetting.ShowMemberGroup;
                    _AC_ReportSettings.ShowName = ReportSetting.ShowName;
                    _AC_ReportSettings.ShowIDNr = ReportSetting.ShowIDNr;
                    _AC_ReportSettings.ShowPlace = ReportSetting.ShowPlace;
                    _AC_ReportSettings.ShowPostalCode = ReportSetting.ShowPostalCode;
                    _AC_ReportSettings.ShowSalutation = ReportSetting.ShowSalutation;
                    _AC_ReportSettings.ShowStreetAndNr = ReportSetting.ShowStreetAndNr;
                    _AC_ReportSettings.ShowContractNr = ReportSetting.ShowContractNr;
                    _AC_ReportSettings.ShowDOB = ReportSetting.ShowDOB;
                    _AC_ReportSettings.ShowNationality = ReportSetting.ShowNationality;
                    _AC_ReportSettings.ShowProfession = ReportSetting.ShowProfession;
                    _AC_ReportSettings.ShowCompanyTelephone = ReportSetting.ShowCompanyTelephone;
                    _AC_ReportSettings.ShowCompanyMobile = ReportSetting.ShowCompanyMobile;
                    _AC_ReportSettings.ShowEmail = ReportSetting.ShowEmail;
                    _AC_ReportSettings.ShowEntryDate = ReportSetting.ShowEntryDate;
                    _AC_ReportSettings.ShowExitDate = ReportSetting.ShowExitDate;
                    _AC_ReportSettings.ShowLongTermCard = ReportSetting.ShowLongTermCard;
                    _AC_ReportSettings.ShowShortTermCard = ReportSetting.ShowShortTermCard;
                    _AC_ReportSettings.ShowAccessFromTo = ReportSetting.ShowAccessFromTo;
                    _AC_ReportSettings.ShowAccessPlanNr = ReportSetting.ShowAccessPlanNr;
                    _AC_ReportSettings.ShowAccessPlanDesc = ReportSetting.ShowAccessPlanDesc;

                };
            }
            return _AC_ReportSettings;
        }
        [WebMethod]
        public static bool DeleteMemberReportList(long Id)
        {
            AccessReportMemberListsRepository memberRep = new AccessReportMemberListsRepository();

            var accessreport = memberRep.GetMemberListById(Convert.ToInt64(Id));
            if (accessreport != null)
            {
                new AccessReportMemberListsRepository().DeleteMemberList(accessreport);
            }
            return memberRep.GetMemberListByNr(Convert.ToInt64(Id)) == null;
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
        public static bool CheckIfListNrExistsOnEdit(string listNr, long currentId)
        {
            var exists = false;
            AccessReportMemberListsRepository _repo = new AccessReportMemberListsRepository();
            var memberlistNr = _repo.GetMemberListByNr(Convert.ToInt64(listNr));
            if (memberlistNr != null)
            {
                if (memberlistNr.ID != currentId)
                {
                    exists = true;
                }
            }

            return exists;
        }

        protected void grdSavedMemberList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            _bindSavedList();
             
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                if (Convert.ToInt32(e.Parameters) == -1)
                {
                    grdSavedMemberList.FocusedRowIndex = Convert.ToInt32(e.Parameters);
                }
                else
                {
                    var index = grdSavedMemberList.FindVisibleIndexByKeyValue(e.Parameters);
                    if (index >= 0)
                    {
                        grdSavedMemberList.FocusedRowIndex = index;
                    }
                }

            }
        }

        protected void cobMemberNumber_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            RebingDropdowns();

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cobMemberNumber.Value = e.Parameter.ToString();
            }
          
        }

        protected void cobMemberName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            RebingDropdowns();
             
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cobMemberName.Value = e.Parameter.ToString();
            }
             
        }
    }
}