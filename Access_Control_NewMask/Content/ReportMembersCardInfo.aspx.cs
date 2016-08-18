using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class ReportMembersCardInfo : BasePage
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
            //MemberCardsDocumentViewer.OpenReport(new ReportMembersCardInfoRpt());
            _initializeReportViewer();
            if (!IsPostBack)
            {
                chkAllCards.Checked = true;
                CheckDefaultCheckBoxes();
                LoadStudioGroups();
                LoadMemberData();
                LoadMemberCards();
                chkLandScape.Checked = true;
                BindDataToGridOverUserSelection(new ViewMemberCardInfoRepository().GetAllTransponders(), false,
                   false, false, true, null, null);
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
            }
        }
        private void _initializeReportViewer()
        {
            if (chkLandScape.Checked)
            {
                MemberCardsDocumentViewer.OpenReport(new ReportMembersCardInfoRpt());
            }
            else if (chkPortrait.Checked)
            {
                MemberCardsDocumentViewer.OpenReport(new ReportMembersCardInfoRptPotrait());
            }
        }
        protected void LoadStudioGroups()
        {
            List<MemberGroup> memberGroupList = new List<MemberGroup>();
            MemberGroup memberGroup = new MemberGroup() { Id = 0, GroupNr = 0, GroupName = "keine Auswahl" };
            memberGroupList.Add(memberGroup);
            var studioGroups = new MemberGroupsRepositories().GetAllMemberGroups().OrderBy(x => x.GroupNr).ToList();
            memberGroupList.AddRange(studioGroups);
            cobStudioGroupFrom.DataSource = memberGroupList;
            cobStudioGroupFrom.DataBind();
            cobStudioGroupFrom.SelectedIndex = 0;
            cobStudioGroupTo.DataSource = memberGroupList;
            cobStudioGroupTo.DataBind();
            cobStudioGroupTo.SelectedIndex = 0;
        }
        protected void LoadMemberData()
        {
            List<MembersDataDto> membersList = new List<MembersDataDto>();
            MembersDataDto memberData = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine Auswahl" };
            membersList.Add(memberData);
            var members = new MembersViewModel().GetAllMembersData();
            membersList.AddRange(members);
            cobMemberNameFrom.DataSource = membersList;
            cobMemberNameFrom.DataBind();
            cobMemberNameFrom.SelectedIndex = 0;

            cobMemberNameTo.DataSource = membersList;
            cobMemberNameTo.DataBind();
            cobMemberNameTo.SelectedIndex = 0;

            cobMemberNrFrom.DataSource = membersList;
            cobMemberNrFrom.DataBind();
            cobMemberNrFrom.SelectedIndex = 0;

            cobMemberNrTo.DataSource = membersList;
            cobMemberNrTo.DataBind();
            cobMemberNrTo.SelectedIndex = 0;
        }
        protected void LoadMemberCards()
        {
            List<MembersTransponder> listTransponders = new List<MembersTransponder>();
            MembersTransponder transponder = new MembersTransponder() { ID = 0, TransponderNr = 0 };
            var memberCards = new MembersTranspondersRepository().GetAllMemberTransponders().OrderBy(x => x.TransponderNr).ToList();
            listTransponders.Add(transponder);
            listTransponders.AddRange(memberCards);
            cobCardNrFrom.DataSource = listTransponders;
            cobCardNrFrom.DataBind();
            cobCardNrFrom.SelectedIndex = 0;
            cobCardNrTo.DataSource = listTransponders;
            cobCardNrTo.DataBind();
            cobCardNrTo.SelectedIndex = 0;
        }
        protected void BindCardMemberGrid(List<ViewMemberCardsInfo> cardsInfo)
        {
            grdMembersCardInfo.DataSource = cardsInfo;
            grdMembersCardInfo.DataBind();

        }
        private void BindDataToGridOverUserSelection(List<ViewMemberCardsInfo> cardAllocationsALL, bool activeCards,
        bool extendedCards, bool inActiveCards, bool allCards, DateTime? cardFrom, DateTime? cardTo)
        {
            List<ViewMemberCardsInfo> cardAllocations = cardAllocationsALL.GroupBy(x => x.ID).Select(g => g.First()).ToList();

            List<ReportMembersCardInfoDto> cardAllocationsDTO = new List<ReportMembersCardInfoDto>();

            foreach (var cardAllocation in (cardAllocations ?? new List<ViewMemberCardsInfo>()).OrderBy(x => x.GroupName).ThenBy(x => x.MemberName).ToList())
            {
                ReportMembersCardInfoDto cardAllocationDTO = new ReportMembersCardInfoDto();
                cardAllocationDTO.ID = cardAllocation.ID;
                cardAllocationDTO.MemberNumber = cardAllocation.MemberNumber;
                cardAllocationDTO.MemberNumberFrom = Convert.ToInt64(cobMemberNrFrom.Text);
                cardAllocationDTO.MemberNumberTo = Convert.ToInt64(cobMemberNrTo.Text);
                cardAllocationDTO.MemberName = cardAllocation.MemberName;
                cardAllocationDTO.MemberNameFrom = cobMemberNameFrom.Text;
                cardAllocationDTO.MemberNameTo = cobMemberNameTo.Text;
                cardAllocationDTO.GroupName = cardAllocation.GroupName;
                cardAllocationDTO.GroupNameFrom = cobStudioGroupFrom.Text;
                cardAllocationDTO.GroupNameTo = cobStudioGroupTo.Text;
                cardAllocationDTO.CardNumber = cardAllocation.TransponderNr;
                cardAllocationDTO.CardNumberFrom = Convert.ToInt64(cobCardNrFrom.Text);
                cardAllocationDTO.CardNumberTo = Convert.ToInt64(cobCardNrTo.Text);
                cardAllocationDTO.Action = GetLastAction(cardAllocation.ID, cardAllocationsALL);
                cardAllocationDTO.ActiveEndDate = cardAllocation.ValidTo;
                cardAllocationDTO.ActiveEndDateFrom = datePickerFrom.Text;
                cardAllocationDTO.ActiveEndDateTo = datePickerTo.Text;
                cardAllocationDTO.ExtencedEndDate = cardAllocation.TransponderDeactivatedOn;
                cardAllocationDTO.CardsAllocated = GetCardCount(cardAllocation.ID, cardAllocationsALL);
                cardAllocationDTO.TotalExtensions = GetTotalExtensions(cardAllocation.ID, cardAllocationsALL);
                cardAllocationDTO.ActiveCard = GetActiveCards(cardAllocation.ID, cardAllocationsALL);
                cardAllocationDTO.InActiveCard = InActiveCards(cardAllocation.ID, cardAllocationsALL);

                switch (cardAllocation.TransponderStatus)
                {
                case true:
                    cardAllocationDTO.Active = true;
                    cardAllocationDTO.Inactive = false;
                    break;
                default:
                    cardAllocationDTO.Active = false;
                    cardAllocationDTO.Inactive = true;
                    break;
                }

                cardAllocationsDTO.Add(cardAllocationDTO);
            }
            if (cardFrom != null && cardTo != null)
            {
                cardAllocationsDTO = cardAllocationsDTO.Where(c => c.ActiveEndDate >= cardFrom && c.ActiveEndDate <= cardTo).ToList();
            }
            if (allCards != true)
            {
                if (activeCards == true)
                {
                    cardAllocationsDTO = cardAllocationsDTO.Where(c => c.ActiveCard > 0).ToList();
                }
                if (extendedCards == true)
                {
                    cardAllocationsDTO = cardAllocationsDTO.Where(c => c.TotalExtensions > 0).ToList();
                }
                if (inActiveCards == true)
                {
                    cardAllocationsDTO = cardAllocationsDTO.Where(c => c.InActiveCard > 0).ToList();
                }
                //if (cardFrom != null && cardTo != null)
                //{
                //    cardAllocationsDTO = cardAllocationsDTO.Where(c => c.ActiveEndDate >= cardFrom && c.ActiveEndDate <= cardTo).ToList();
                //}
            }

            int activeSum = cardAllocationsDTO.Select(x => x.ActiveCard).Sum();
            int inactiveSum = cardAllocationsDTO.Select(x => x.InActiveCard).Sum(); ;
            int extendedSum = cardAllocationsDTO.Select(x => x.TotalExtensions).Sum();
            int cardsSum = cardAllocationsDTO.Select(x => Convert.ToInt32(x.CardsAllocated)).Sum();
            int totalMem = cardAllocationsDTO.Count();

            cardAllocationsDTO.Add(new ReportMembersCardInfoDto { ID = cardAllocationsDTO.Count + 1, MemberNumber = totalMem, CardNumber = totalMem, InActiveCard = inactiveSum, ActiveCard = activeSum, TotalExtensions = extendedSum, MemberName = "Summe", CardsAllocated = cardsSum });
            grdMembersCardInfo.DataSource = cardAllocationsDTO;
            grdMembersCardInfo.DataBind();

            CardAllocationOverview_DTO cards = new CardAllocationOverview_DTO();
            if (chkActiveCards.Checked == true)
            {
                var activeText = "Aktive Ausweise";
                cards.PersonalCardType = activeText;
            }
            else if (chkExtendedCards.Checked == true)
            {
                var extendedCardText = "Verlängerte Ausweise";
                cards.PersonalCardType = extendedCardText;
            }
            else if (chkInactiveCards.Checked == true)
            {
                var inactiveText = " Inaktive Ausweise";
                cards.PersonalCardType = inactiveText;
            }
            else if (chkAllCards.Checked == true)
            {
                var allCardsText = " Alle Ausweise";
                cards.PersonalCardType = allCardsText;
            }

            string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
            string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

            var logedInUser = String.Format("{0} {1}", firstName, lastName);

            cardAllocationsDTO.Select(c => { c.LoggedInUser = logedInUser; return c; }).ToList();
            cardAllocationsDTO.Select(c => { c.PersonalCardType = cards.PersonalCardType; return c; }).ToList();
             
            Session["MemberCardInfoRpt"] = cardAllocationsDTO;

            SetVisibleColumns();

        }
        protected int GetCardCount(long ID, List<ViewMemberCardsInfo> cardList)
        {
            int totalCards = 0;
            var personnelCards = cardList.Where(x => x.ID == ID).GroupBy(x => x.TransponderNr).Select(g => g.First()).ToList();
            totalCards = personnelCards.Count();
            return totalCards;
        }
        protected int GetLastAction(long ID, List<ViewMemberCardsInfo> cardList)
        {
            int action = 0;

            var personnelCards = cardList.Where(x => x.ID == ID).ToList();
            if (personnelCards.Count > 0)
            {
                var maxId = personnelCards.Max(m => m.TransponderID);
                var personnelCard = personnelCards.Find(x => x.TransponderID == Convert.ToInt64(maxId));
                if (personnelCard != null)
                {
                    action = Convert.ToInt32(personnelCard.Action);
                }
            }
            return action;
        }
        protected int GetTotalExtensions(long ID, List<ViewMemberCardsInfo> cardList)
        {
            int extensions = 0;
            var personnelCards = cardList.Where(x => x.ID == ID).ToList();
            var query = personnelCards.GroupBy(x => x.TransponderNr)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);
            foreach (var card in query)
            {
                //card has been extended
                if (card.Count > 1)
                {
                    extensions = extensions + card.Count - 1;
                }
            }
            //extensions = personnelCards.Count();
            return extensions;
        }
        protected int GetActiveCards(long ID, List<ViewMemberCardsInfo> cardList)
        {
            int activeCard = 0;
            var personnelCards = cardList.Where(x => x.ID == ID).GroupBy(x => x.TransponderNr).Select(g => g.First()).ToList();
            activeCard = (personnelCards.Where(x => x.TransponderStatus == true).ToList()).Count();
            return activeCard;
        }
        protected int InActiveCards(long ID, List<ViewMemberCardsInfo> cardList)
        {
            int InactiveCard = 0;
            var personnelCards = cardList.Where(x => x.ID == ID).GroupBy(x => x.TransponderNr).Select(g => g.First()).ToList();
            InactiveCard = (personnelCards.Where(x => x.TransponderStatus == false).ToList()).Count();
            return InactiveCard;
        }

        protected void grdMembersCardInfo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                string[] passedValues = e.Parameters.Split(';');
                var groupFrom = Convert.ToInt64(passedValues[0]);
                var groupTo = Convert.ToInt64(passedValues[1]);
                var memberNameFrom = Convert.ToInt64(passedValues[2]);
                var memberNameTo = Convert.ToInt64(passedValues[3]);
                var memberNrFrom = Convert.ToInt64(passedValues[4]);
                var memberNrTo = Convert.ToInt64(passedValues[5]);
                var cardNrFrom = Convert.ToInt64(passedValues[6]);
                var cardNrTo = Convert.ToInt64(passedValues[7]);
                var activeCards = Convert.ToBoolean(passedValues[8]);
                var extendedCard = Convert.ToBoolean(passedValues[9]);
                var inActiveCard = Convert.ToBoolean(passedValues[10]);
                var allCards = Convert.ToBoolean(passedValues[11]);
                DateTime? dateFrom = !string.IsNullOrEmpty(passedValues[12]) ? Convert.ToDateTime(passedValues[12]) : (DateTime?)null;
                var dateTo = !string.IsNullOrEmpty(passedValues[13]) ? Convert.ToDateTime(passedValues[13]) : (DateTime?)null;
                FilterTransponders(groupFrom, groupTo, memberNameFrom, memberNameTo, memberNrFrom, memberNrTo,
                    cardNrFrom, cardNrTo, activeCards, extendedCard, inActiveCard, allCards, dateFrom, dateTo);
            }
            else
            {
                BindDataToGridOverUserSelection(new ViewMemberCardInfoRepository().GetAllTransponders(), false,
                    false, false, true, null, null);
            }
        }
        protected void FilterTransponders(long groupFrom, long groupTo, long memberNameFrom, long memberNameTo, long memberNrFrom, long memberNrTo,
            long cardNrFrom, long cardNrTo, bool activeCards, bool extendedCard, bool inActiveCard, bool allCards, DateTime? dateFrom, DateTime? dateTo)
        {
            var cardList = new ViewMemberCardInfoRepository().GetAllTransponders();
            if (groupFrom != 0 && groupTo != 0)
            {
                cardList = cardList.Where(x => x.GroupNr >= groupFrom && x.GroupNr <= groupTo).ToList();
            }
            if (memberNameFrom != 0 && memberNameTo != 0)
            {
                cardList = cardList.Where(x => x.MemberNumber >= memberNameFrom && x.MemberNumber <= memberNameTo).ToList();
            }
            if (memberNrFrom != 0 && memberNrTo != 0)
            {
                cardList = cardList.Where(x => x.MemberNumber >= memberNrFrom && x.MemberNumber <= memberNrTo).ToList();
            }
            if (cardNrFrom != 0 && cardNrTo != 0)
            {
                cardList = cardList.Where(x => x.TransponderNr >= cardNrFrom && x.TransponderNr <= cardNrTo).ToList();
            }

            BindDataToGridOverUserSelection(cardList, activeCards, extendedCard, inActiveCard, allCards, dateFrom, dateTo);
        }
        protected void CheckDefaultCheckBoxes()
        {
            chkMemberGroup.Checked = true;
            chkMemberName.Checked = true;
            chkMemberNr.Checked = true;
            chkCardNr.Checked = true;
        }
        protected void SetVisibleColumns()
        {

            grdMembersCardInfo.Columns["GroupName"].Visible = chkMemberGroup.Checked;
            grdMembersCardInfo.Columns["MemberName"].Visible = chkMemberName.Checked;
            grdMembersCardInfo.Columns["MemberNumber"].Visible = chkMemberNr.Checked;
            grdMembersCardInfo.Columns["CardNumber"].Visible = chkCardNr.Checked;
            grdMembersCardInfo.Columns["TotalExtensions"].Visible = chkExtension.Checked;
            grdMembersCardInfo.Columns["Action"].Visible = chkActions.Checked;
            grdMembersCardInfo.Columns["ActiveCard"].Visible = chkActive.Checked;
            grdMembersCardInfo.Columns["InActiveCard"].Visible = chkInactive.Checked;
            grdMembersCardInfo.Columns["ActiveEndDate"].Visible = chkMemberDate.Checked;
            ReportMembersCardInfoDto visibleDto = new ReportMembersCardInfoDto();
            visibleDto.HideGroup = chkMemberGroup.Checked;
            visibleDto.HideName = chkMemberName.Checked;
            visibleDto.HideMemberNr = chkMemberNr.Checked;
            visibleDto.HideCardNr = chkCardNr.Checked;
            visibleDto.HideCardExtensions = chkExtension.Checked;
            visibleDto.HideActions = chkActions.Checked;
            visibleDto.HideActive = chkActive.Checked;
            visibleDto.HideInactive = chkInactive.Checked;
            visibleDto.HideExpiryDate = chkMemberDate.Checked;
            Session["HideReportMembersCardInfo"] = visibleDto;
        }

        protected void MembersCardPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
    }
}