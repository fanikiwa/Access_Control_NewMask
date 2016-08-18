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
    public partial class ReportPersonalCardInfo : BasePage
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
            //PersonnelCardsDocumentViewer.OpenReport(new ReportPersonalCardInfoRpt());
            _initializeReportViewer();
            if (!IsPostBack)
            {
                chkAllCards.Checked = true;
                CheckDefaultCheckBoxes();
                LoadCompanies();
                LoadLocations();
                LoadDepartmemts();
                LoadPeronnel();
                LoadPersonnelCards();
                chkLandScape.Checked = true;
                BindDataToGridOverUserSelection(new PersTranspondersRepository().GetCardAllocationOverView(), false,
                    false, false, true, null, null);
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
            }

        }
        private void _initializeReportViewer()
        {
            if (chkLandScape.Checked)
            {
                PersonnelCardsDocumentViewer.OpenReport(new ReportPersonalCardInfoRpt());
            }
            else if (chkPortrait.Checked)
            {
                PersonnelCardsDocumentViewer.OpenReport(new ReportPersonalCardInfoRptPotrait());
            }
        }
        protected void LoadCompanies()
        {
            List<Client> companiesList = new List<Client>();
            Client company = new Client() { ID = 0, Client_Nr = 0, Name = "keine Auswahl" };
            var companies = new ClientsRepository().GetClients().OrderBy(x => x.Client_Nr).ToList();
            companiesList.Add(company);
            companiesList.AddRange(companies);
            cobCompanyFrom.DataSource = companiesList;
            cobCompanyFrom.DataBind();
            cobCompanyFrom.SelectedIndex = 0;
            cobCompanyTo.DataSource = companiesList;
            cobCompanyTo.DataBind();
            cobCompanyTo.SelectedIndex = 0;
        }
        protected void LoadLocations()
        {
            List<Location> locationList = new List<Location>();
            Location location = new Location() { ID = 0, Location_Nr = 0, Name = "keine Auswahl" };
            var locations = new LocationRepository().GetLocations().OrderBy(x => x.Location_Nr).ToList();
            locationList.Add(location);
            locationList.AddRange(locations);
            cobLocationFrom.DataSource = locationList;
            cobLocationFrom.DataBind();
            cobLocationFrom.SelectedIndex = 0;
            cobLocationTo.DataSource = locationList;
            cobLocationTo.DataBind();
            cobLocationTo.SelectedIndex = 0;
        }
        protected void LoadDepartmemts()
        {
            List<Department> departmentList = new List<Department>();
            Department department = new Department() { ID = 0, Department_Nr = 0, Name = "keine Auswahl" };
            var departments = new DepartmentRepository().GetDepartments().OrderBy(x => x.Department_Nr).ToList();
            departmentList.Add(department);
            departmentList.AddRange(departments);
            cobDepartmentFrom.DataSource = departmentList;
            cobDepartmentFrom.DataBind();
            cobDepartmentFrom.SelectedIndex = 0;
            cobDepartmentTo.DataSource = departmentList;
            cobDepartmentTo.DataBind();
            cobDepartmentTo.SelectedIndex = 0;
        }
        protected void LoadPeronnel()
        {
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            //PersonnelDto personnel = new PersonnelDto() { ID = 0, Pers_Nr = 0, FirstName = "keine Auswahl" };
            var employees = new PersonalViewModel().GetAllActivePersonnel().OrderBy(x => x.Name).ToList();
            //personnelList.Add(personnel);
            personnelList.AddRange(employees);
            cobNameFrom.DataSource = personnelList.OrderBy(x => x.Pers_Nr).ToList();
            cobNameFrom.DataBind();
            cobNameFrom.SelectedIndex = 0;
            cobNameTo.DataSource = personnelList.OrderBy(x => x.Pers_Nr).ToList();
            cobNameTo.DataBind();
            cobNameTo.SelectedIndex = 0;
            cobPersNrFrom.DataSource = personnelList.OrderBy(x => x.Pers_Nr).ToList();
            cobPersNrFrom.DataBind();
            cobPersNrFrom.SelectedIndex = 0;
            cobPersNrTo.DataSource = personnelList.OrderBy(x => x.Pers_Nr).ToList(); ;
            cobPersNrTo.DataBind();
            cobPersNrTo.SelectedIndex = 0;
        }
        protected void LoadPersonnelCards()
        {
            List<Pers_Transponders> transpondersList = new List<Pers_Transponders>();
            Pers_Transponders transponder = new Pers_Transponders() { ID = 0, TransponderNr = 0 };
            var transponders = new PersTranspondersRepository().GetAllPersTransponders().OrderBy(x => x.TransponderNr).ToList();
            transpondersList.Add(transponder);
            transpondersList.AddRange(transponders);
            cobCardNrFrom.DataSource = transpondersList;
            cobCardNrFrom.DataBind();
            cobCardNrFrom.SelectedIndex = 0;
            cobCardNrTo.DataSource = transpondersList;
            cobCardNrTo.DataBind();
            cobCardNrTo.SelectedIndex = 0;
        }


        protected void CheckDefaultCheckBoxes()
        {
            chkcompany.Checked = true;
            chkdepartment.Checked = true;
            chklocation.Checked = true;
            chkName.Checked = true;
            chkidnr.Checked = true;
            chkcard.Checked = true;
        }

        protected void grdPersonnelCardInfo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                string[] passedValues = e.Parameters.Split(';');
                var companyNrFrom = Convert.ToInt64(passedValues[0]);
                var companyNrTo = Convert.ToInt64(passedValues[1]);
                var locationNrFrom = Convert.ToInt64(passedValues[2]);
                var locationNrTo = Convert.ToInt64(passedValues[3]);
                var departmentNrFrom = Convert.ToInt64(passedValues[4]);
                var departmentNrTo = Convert.ToInt64(passedValues[5]);
                var persNameFrom = Convert.ToInt64(passedValues[6]);
                var persNameTo = Convert.ToInt64(passedValues[7]);
                var persNrFrom = Convert.ToInt64(passedValues[8]);
                var persNrTo = Convert.ToInt64(passedValues[9]);
                var cardNrFrom = Convert.ToInt64(passedValues[10]);
                var cardNrTo = Convert.ToInt64(passedValues[11]);
                var activeCards = Convert.ToBoolean(passedValues[12]);
                var extendedCard = Convert.ToBoolean(passedValues[13]);
                var inActiveCard = Convert.ToBoolean(passedValues[14]);
                var allCards = Convert.ToBoolean(passedValues[15]);
                DateTime? dateFrom = !string.IsNullOrEmpty(passedValues[16]) ? Convert.ToDateTime(passedValues[16]) : (DateTime?)null;
                var dateTo = !string.IsNullOrEmpty(passedValues[17]) ? Convert.ToDateTime(passedValues[17]) : (DateTime?)null;
                FilterTransponders(companyNrFrom, companyNrTo, locationNrFrom, locationNrTo, departmentNrFrom, departmentNrTo, persNrFrom, persNrTo, cardNrFrom, cardNrTo, activeCards, extendedCard, inActiveCard, allCards, dateFrom, dateTo);
            }
            else
            {
                BindDataToGridOverUserSelection(new PersTranspondersRepository().GetCardAllocationOverView(), false,
                    false, false, true, null, null);
            }

        }

        protected void PersonnelCardPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
        private void BindDataToGridOverUserSelection(List<View_CardAllocationOverview> cardAllocationsALL, bool activeCards,
          bool extendedCards, bool inActiveCards, bool allCards, DateTime? cardFrom, DateTime? cardTo)
        {
            List<View_CardAllocationOverview> cardAllocations = cardAllocationsALL.GroupBy(x => x.Pers_Nr).Select(g => g.First()).ToList();

            List<CardAllocationOverview_DTO> cardAllocationsDTO = new List<CardAllocationOverview_DTO>();

            foreach (var cardAllocation in (cardAllocations ?? new List<View_CardAllocationOverview>()).OrderBy(x => x.ClientName).ThenBy(x => x.FullName).ToList())
            {
                CardAllocationOverview_DTO cardAllocationDTO = new CardAllocationOverview_DTO();
                cardAllocationDTO.ID = Convert.ToInt64(cardAllocation.ID);
                cardAllocationDTO.Pers_Nr = cardAllocation.Pers_Nr;
                cardAllocationDTO.ClientName = cardAllocation.ClientName;
                cardAllocationDTO.FirstName = cardAllocation.FirstName;
                cardAllocationDTO.LastName = cardAllocation.LastName;
                cardAllocationDTO.FullName = cardAllocation.FullName;
                cardAllocationDTO.Company = cardAllocation.ClientName;
                cardAllocationDTO.Location = cardAllocation.LocationName;
                cardAllocationDTO.CostCenter = cardAllocation.CostCenterName;
                cardAllocationDTO.Department = cardAllocation.DepartmentName;
                cardAllocationDTO.CardNumber = cardAllocation.TransponderNr;
                cardAllocationDTO.Action = GetLastAction(cardAllocation.Pers_Nr, cardAllocationsALL);
                cardAllocationDTO.ActiveEndDate = cardAllocation.ValidTo;
                cardAllocationDTO.ExtencedEndDate = cardAllocation.TransponderDeactivatedOn;
                cardAllocationDTO.CardsAllocated = GetCardCount(cardAllocation.Pers_Nr, cardAllocationsALL);
                cardAllocationDTO.TotalExtensions = GetTotalExtensions(cardAllocation.Pers_Nr, cardAllocationsALL);
                cardAllocationDTO.ActiveCard = GetActiveCards(cardAllocation.Pers_Nr, cardAllocationsALL);
                cardAllocationDTO.InActiveCard = InActiveCards(cardAllocation.Pers_Nr, cardAllocationsALL);
                cardAllocationDTO.CompanyFrom = cobCompanyFrom.Text;
                cardAllocationDTO.CompanyTo = cobCompanyTo.Text;
                cardAllocationDTO.LocationFrom = cobLocationFrom.Text;
                cardAllocationDTO.LocationTo = cobLocationTo.Text;
                cardAllocationDTO.DepartmentFrom = cobDepartmentFrom.Text;
                cardAllocationDTO.DepartmentTo = cobDepartmentTo.Text;
                cardAllocationDTO.ActiveEndDateFrom = datePickerFrom.Text;
                cardAllocationDTO.ActiveEndDateTo = datePickerTo.Text;
                cardAllocationDTO.CardNrFrom = cobCardNrFrom.Text;
                cardAllocationDTO.CardNrTo = cobCardNrTo.Text;

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
            int cardSum = cardAllocationsDTO.Count();

            cardAllocationsDTO.Add(new CardAllocationOverview_DTO { ID = cardAllocationsDTO.Count + 1, Pers_Nr = cardSum, CardNumber = cardSum, InActiveCard = inactiveSum, ActiveCard = activeSum, TotalExtensions = extendedSum, FullName = "Summe", CardsAllocated = cardsSum });

            grdPersonnelCardInfo.DataSource = cardAllocationsDTO;
            grdPersonnelCardInfo.DataBind();
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
            //   cardAllocationsDTO.Add(cards);
            Session["PersonnelCardAllocationRpt"] = cardAllocationsDTO;
            SetVisibleColumns();

        }
        protected int GetCardCount(long persNr, List<View_CardAllocationOverview> cardList)
        {
            int totalCards = 0;
            var personnelCards = cardList.Where(x => x.Pers_Nr == persNr).GroupBy(x => x.TransponderNr).Select(g => g.First()).ToList();
            totalCards = personnelCards.Count();
            return totalCards;
        }
        protected int GetLastAction(long persNr, List<View_CardAllocationOverview> cardList)
        {
            int action = 0;

            var personnelCards = cardList.Where(x => x.Pers_Nr == persNr).ToList();
            if (personnelCards.Count > 0)
            {
                var maxId = personnelCards.Max(m => m.TransPonderID);
                var personnelCard = personnelCards.Find(x => x.TransPonderID == Convert.ToInt64(maxId));
                if (personnelCard != null)
                {
                    action = Convert.ToInt32(personnelCard.Action);
                }
            }
            return action;
        }
        protected int GetTotalExtensions(long persNr, List<View_CardAllocationOverview> cardList)
        {
            int extensions = 0;
            var personnelCards = cardList.Where(x => x.Pers_Nr == persNr).ToList();
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
        protected int GetActiveCards(long persNr, List<View_CardAllocationOverview> cardList)
        {
            int activeCard = 0;
            var personnelCards = cardList.Where(x => x.Pers_Nr == persNr).GroupBy(x => x.TransponderNr).Select(g => g.First()).ToList();
            activeCard = (personnelCards.Where(x => x.TransponderStatus == true).ToList()).Count();
            return activeCard;
        }
        protected int InActiveCards(long persNr, List<View_CardAllocationOverview> cardList)
        {
            int InactiveCard = 0;
            var personnelCards = cardList.Where(x => x.Pers_Nr == persNr).GroupBy(x => x.TransponderNr).Select(g => g.First()).ToList();
            InactiveCard = (personnelCards.Where(x => x.TransponderStatus == false).ToList()).Count();
            return InactiveCard;
        }
        protected void FilterTransponders(long companyNrFrom, long companyNrTo, long locationNrFrom, long locationNrTo, long departmentNrFrom, long departmentNrTo, long persNrFrom,
            long persNrTo, long cardNrFrom, long cardNrTo, bool activeCards, bool extendedCard, bool inActiveCard, bool allCards, DateTime? dateFrom, DateTime? dateTo)
        {
            var cardList = new PersTranspondersRepository().GetCardAllocationOverView();
            if (companyNrFrom != 0 && companyNrTo != 0)
            {
                cardList = cardList.Where(x => x.Client_Nr >= companyNrFrom && x.Client_Nr <= companyNrTo).ToList();
            }
            if (locationNrFrom != 0 && locationNrTo != 0)
            {
                cardList = cardList.Where(x => x.Location_Nr >= locationNrFrom && x.Location_Nr <= locationNrTo).ToList();
            }
            if (departmentNrFrom != 0 && departmentNrTo != 0)
            {
                cardList = cardList.Where(x => x.Department_Nr >= departmentNrFrom && x.Department_Nr <= departmentNrTo).ToList();
            }

            if (persNrFrom != 0 && persNrTo != 0)
            {
                cardList = cardList.Where(x => x.Pers_Nr >= persNrFrom && x.Pers_Nr <= persNrTo).ToList();
            }

            if (cardNrFrom != 0 && cardNrTo != 0)
            {
                cardList = cardList.Where(x => x.TransponderNr >= cardNrFrom && x.TransponderNr <= cardNrTo).ToList();
            }
            BindDataToGridOverUserSelection(cardList, activeCards, extendedCard, inActiveCard, allCards, dateFrom, dateTo);
        }
        protected void SetVisibleColumns()
        {
            grdPersonnelCardInfo.Columns["Company"].Visible = chkcompany.Checked;
            grdPersonnelCardInfo.Columns["Location"].Visible = chklocation.Checked;
            grdPersonnelCardInfo.Columns["Department"].Visible = chkdepartment.Checked;
            grdPersonnelCardInfo.Columns["CardNumber"].Visible = chkcard.Checked;
            grdPersonnelCardInfo.Columns["FullName"].Visible = chkName.Checked;
            grdPersonnelCardInfo.Columns["Pers_Nr"].Visible = chkidnr.Checked;
            grdPersonnelCardInfo.Columns["Action"].Visible = chkActions.Checked;
            grdPersonnelCardInfo.Columns["ActiveCard"].Visible = chkActive.Checked;
            grdPersonnelCardInfo.Columns["InActiveCard"].Visible = chkInactive.Checked;
            grdPersonnelCardInfo.Columns["ActiveEndDate"].Visible = chkExpiryDate.Checked;
            grdPersonnelCardInfo.Columns["TotalExtensions"].Visible = chkExtension.Checked;
            CardAllocationOverview_DTO visibleDto = new CardAllocationOverview_DTO();
            visibleDto.HideCompany = chkcompany.Checked;
            visibleDto.HideLocation = chklocation.Checked;
            visibleDto.HideDepartment = chkdepartment.Checked;
            visibleDto.HidePersNr = chkidnr.Checked;
            visibleDto.HideName = chkName.Checked;
            visibleDto.HideCardNr = chkcard.Checked;
            visibleDto.HideExtension = chkExtension.Checked;
            visibleDto.HideAction = chkActions.Checked;
            visibleDto.HideActive = chkActive.Checked;
            visibleDto.HideInActive = chkInactive.Checked;
            visibleDto.HideExpiryDate = chkExpiryDate.Checked;
            Session["HideReportPersonnelCardInfo"] = visibleDto;
        }

    }

}