using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using DevExpress.Web;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KruAll.Core.Models;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Repositories;

namespace Access_Control_NewMask.Content
{
    public partial class GatePersonal : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        private const string PERSONAL_QUERY_PARAM_KEY = "0F88";
        private const string PAGE_ORIGIN_QUERY_PARAM_KEY = "4ED8";
        private const string PERSONAL_PAGE_ORIGIN = "7E30B049";

        private const string PERSONALDASHBOARD_QUERY_PARAM_KEY = "0D88";
        private const string PERSONALDASHBOARD_PAGE_ORIGIN = "7F30B049";

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("GateMonitorPersonnel_PMode");
            }
            set
            {
                HttpContext.Current.Session["GateMonitorPersonnel_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.GateMonitorPersonnel, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPersonal();
                BindData();

            }
        }

        protected void BindPersonal()
        {
            VwPersonnelData _VwPersonnelData = new VwPersonnelData()
            {
                Pers_Nr = 0,
            };

            List<VwPersonnelData> VwPersonnelDataList = new List<VwPersonnelData>();

            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            var persDataList = _VwPersonnelDataRepository.GetAllPersonnel().Distinct().ToList().OrderBy(x => x.Pers_Nr);

            VwPersonnelDataList = _VwPersonnelDataRepository.GetAllPersonnel().OrderBy(x => x.Pers_Nr).ToList();
            VwPersonnelDataList.Insert(0, new VwPersonnelData { Pers_Nr = 0, });

            //if (persDataList.Count() > 29)
            //{
            //    grdSearchPersonal.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
            //    grdSearchPersonal.Settings.VerticalScrollableHeight = 810;
            //    grdSearchPersonal.SettingsPager.PageSize = persDataList.Count();
            //}

            grdSearchPersonal.DataSource = persDataList;
            grdSearchPersonal.DataBind();

            if (persDataList.Count() <= 30)
            {
                grdSearchPersonal.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                grdSearchPersonal.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }
            lblTotalPersonnel.Text = persDataList.Count().ToString();

            cboPersNr.DataSource = VwPersonnelDataList;
            cboPersNr.DataBind();
        }

        protected void BindData()
        {
            lblTotalVisitors.Text = GetAllVisitors().ToString();
            BuildingPlanDto buildingPlan = new BuildingPlanDto();
            buildingPlan = GetTotalBuildings();
            lblTotalBuildings.Text = buildingPlan.totalBuildings.ToString();
            lblTotalFloors.Text = buildingPlan.totalFloors.ToString();
            lblTotalRooms.Text = buildingPlan.totalRooms.ToString();
            var totalDoorReader = buildingPlan.totalDoorReader;
            var doorFirst = Convert.ToInt32(totalDoorReader / 2);
            var dooorRem = totalDoorReader % 2;
            var doors = doorFirst + dooorRem;
            lblTotalDoors.Text = doors.ToString();
            lblTotalReaders.Text = GetTotalReaders().ToString();
        }

        protected BuildingPlanDto GetTotalBuildings()
        {
            int buildings = 0;
            int floors = 0;
            int rooms = 0;
            int doorReader = 0;
            int readers = 0;
            List<BuildingPlan> listBuildingPlan = new List<BuildingPlan>();
            BuildingPlanViewModel buildPlanViewModel = new BuildingPlanViewModel();

            listBuildingPlan = buildPlanViewModel.BuildingPlans();
            foreach (var plan in listBuildingPlan)
            {
                JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
                Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
                var nodeData = buildingPlan["model"]["nodeDataArray"];

                List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());

                var totalBuildings = nodeArray.Where(x => x.level == Convert.ToString(2)).Count();
                var totalFlooors = nodeArray.Where(x => x.level == Convert.ToString(3)).Count();
                var totalRooms = nodeArray.Where(x => x.level == Convert.ToString(4)).Count();
                var totalDoorReader = nodeArray.Where(x => x.level == Convert.ToString(5)).Count();
                buildings = buildings + totalBuildings;
                floors = floors + totalFlooors;
                rooms = rooms + totalRooms;
                doorReader = doorReader + totalDoorReader;
            }
            BuildingPlanDto plansData = new BuildingPlanDto()
            {
                totalBuildings = buildings,
                totalFloors = floors,
                totalRooms = rooms,
                totalDoorReader = doorReader
            };
            return plansData;
        }
        protected int GetTotalReaders()
        {
            List<ReaderAssigned> readers = new List<ReaderAssigned>();
            AssignReaderRepository readersRepo = new AssignReaderRepository();
            readers = readersRepo.GetAllAssignedReaders().Where(x => x.Active == true).ToList();
            var totalReaders = readers.Count();
            return totalReaders;
        }

        protected int GetAllVisitors()
        {
            List<Visitor> visitors = new List<Visitor>();
            VisitorRepository visitorRepo = new VisitorRepository();
            visitors = visitorRepo.GetAllVisitors();
            var totalVisitors = visitors.Count();
            return totalVisitors;
        }

        [WebMethod]
        public static VisitorCompanyTb GetVisCompany(int Id)
        {
            VisitorCompanyRepository _VisitorCompanyRepository = new VisitorCompanyRepository();
            VisitorCompanyTb _VisitorCompanyTb = new VisitorCompanyTb();
            var visData = _VisitorCompanyRepository.GetVisitorCompanyById(Id);

            if (visData == null)
            {
                return _VisitorCompanyTb;
            }

            if (visData != null)
            {
                _VisitorCompanyTb.ID = visData.ID;
                _VisitorCompanyTb.CompanyNr = visData.CompanyNr;
                _VisitorCompanyTb.CompanyName = visData.CompanyName;

            }

            return _VisitorCompanyTb;
        }

        [WebMethod]
        public static PersonalData_DTO GetPersonalWithCardNumber(string cardNumber)
        {
            string personalNumber = string.Empty;
            long transponderNumber = 0;
            PersonalData_DTO gatePersonal = new PersonalData_DTO();

            if (long.TryParse(cardNumber, out transponderNumber))
            {
                var pers_transponder = new PersTranspondersRepository().GetAllPersTransponders().Where(x => x.TransponderNr == transponderNumber).FirstOrDefault();

                if(pers_transponder != null)
                {
                    gatePersonal = Getpersonal(pers_transponder.PersNr.ToString());
                }
            }
            return gatePersonal;
        }


        [WebMethod]
        public static PersonalData_DTO Getpersonal(string Personalnumber)
        {
            //if (Personalnumber == "0" || Personalnumber == "undefined") {  }

            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            PersonalData_DTO _PersonalData_DTO = new PersonalData_DTO();

            var persData = _VwPersonnelDataRepository.GetAllPersonnel().Where(x => x.Pers_Nr == Convert.ToInt64(Personalnumber)).FirstOrDefault();

            if (persData == null)
            {
                return _PersonalData_DTO;
            }

            var accessPlanMapping = new AccessPlanPersMappingRepository().GetMappingByEmployeeNumber(Convert.ToInt64(Personalnumber));
            if (accessPlanMapping != null)
            {
                var accessPLan = accessPlanMapping.TbAccessPlan;
                _PersonalData_DTO.AccessPlanNr = accessPLan.AccessPlanNr;
                _PersonalData_DTO.AccessPlanDescription = accessPLan.AccessPlanDescription;
                _PersonalData_DTO.DateOfEntry = accessPlanMapping.DateFrom;
                _PersonalData_DTO.DateOfExit = accessPlanMapping.DateTo;
            }

            if (persData != null)
            {
                _PersonalData_DTO.Pers_Nr = persData.Pers_Nr;
                _PersonalData_DTO.FirstName = persData.FirstName;
                _PersonalData_DTO.LastName = persData.LastName;
                _PersonalData_DTO.ClientID = persData.ClientID;
                _PersonalData_DTO.LocationID = persData.LocationID;
                _PersonalData_DTO.DepartmentID = persData.DepartmentID;
                _PersonalData_DTO.CostCenterID = persData.CostCenterID;
                _PersonalData_DTO.CardActive = persData.CardActive;
                _PersonalData_DTO.Imported = persData.Imported;

                _PersonalData_DTO.PersType = persData.PersType;
                _PersonalData_DTO.DOB = persData.DOB;
                _PersonalData_DTO.EntryDate = persData.EntryDate;
                _PersonalData_DTO.ExitDate = persData.ExitDate;

                _PersonalData_DTO.companyName = persData.CompanyName;
                _PersonalData_DTO.clientNr = Convert.ToInt64(persData.Client_Nr);
                _PersonalData_DTO.ClientName = persData.ClientName;
                _PersonalData_DTO.Street = persData.Street;
                _PersonalData_DTO.StreetNr = persData.StreetNr;
                _PersonalData_DTO.PostalCode = persData.Expr2;
                _PersonalData_DTO.LastName = persData.LastName;
                _PersonalData_DTO.Location = persData.LocationName;
                _PersonalData_DTO.CarRegnumber = persData.VehicleReg;
                _PersonalData_DTO.Memo = persData.Memo;
                _PersonalData_DTO.Position = persData.Position;
                _PersonalData_DTO.Nationality = persData.Nationality;
                _PersonalData_DTO.CompTel = persData.CompanyTel;
                _PersonalData_DTO.CompanyMobile = persData.CompanyMobile;
                _PersonalData_DTO.PrivTel = persData.PrivateTel;
                _PersonalData_DTO.PrivateMobile = persData.PrivateMobile;
                _PersonalData_DTO.CompanyEmail = persData.CompanyEmail;
                _PersonalData_DTO.PrivateEmail = persData.PrivateEmail;
                _PersonalData_DTO.Card_Nr = persData.IdentificationNr_string;
                _PersonalData_DTO.PhysicalAddress = persData.PhysicalAddress;
                _PersonalData_DTO.PassPhoto = string.IsNullOrWhiteSpace(persData.Pers_Passport) ? persData.Pers_Passport : FileProcessor.GetPersonalImageFile(persData.Pers_Passport);
                _PersonalData_DTO.ActiveCardType = Convert.ToInt32(persData.ActiveCardType);

            }

            // CODE NOT USED
            //var Pinecode = new vwPersPinCodeRepository().GetPersPinCodes().Where(x => x.Pers_Nr == Convert.ToInt64(Personalnumber)).FirstOrDefault();
            //if (Pinecode != null)
            //{
            //    _PersonalData_DTO.AusweisPincodeStr = Pinecode.Aus_PinCode;
            //    _PersonalData_DTO.PincodeActives = Convert.ToBoolean(Pinecode.Aus_PinCodeStatus);

            //    _PersonalData_DTO.SicherheitsPincodeStr = Pinecode.Scher_PinCode;
            //    _PersonalData_DTO.MenaceActive = Convert.ToBoolean(Pinecode.Scher_PinCodeStatus);

            //    _PersonalData_DTO.NurPincodeActive = Convert.ToBoolean(Pinecode.Nur_PinCodeStatus);
            //    _PersonalData_DTO.NurPincodeStr = Pinecode.Nur_PinCode;
            //}
            //else
            //{
            //    _PersonalData_DTO.NurPincodeActive = true;
            //}

            if (_PersonalData_DTO.PersType != null)
            {
                var PersonalType = new PersonTypeRepository().GetAllPersonTypes().Where(x => x.ID == Convert.ToInt64(_PersonalData_DTO.PersType)).FirstOrDefault();
                if (PersonalType != null)
                {
                    _PersonalData_DTO.Name = PersonalType.Name;
                }
            }

            return _PersonalData_DTO;
        }

        protected void btnDocument_Click(object sender, EventArgs e)
        {
            try
            {
                long personalNumber = 0;
                string persNr = cboPersNr.Value.ToString();
                string Pers_Name = txtLastName.Text.Trim();
                string persFirstName = txtFirstName.Text.Trim();
                string personalDocumentsRedirect = string.Empty;
                if (persNr == "0")
                {
                    Response.Redirect("/Content/GatePersonalDocument.aspx");
                }

                long.TryParse(persNr, out personalNumber);

                if (personalNumber == 0)
                {
                    return;
                }

                EncryptionCtl encryption = new EncryptionCtl();

                if (hiddenFieldSaveChanges.Value == "1")
                {
                    ClientScript.RegisterStartupScript(GetType(), "DocumentButtonConfirm", "DocumentButtonConfirm();", true);
                }
                else
                {
                    personalDocumentsRedirect = string.Format("/Content/GatePersonalDocument.aspx?{0}={1}&{2}={3}", PERSONAL_QUERY_PARAM_KEY, personalNumber, PAGE_ORIGIN_QUERY_PARAM_KEY, PERSONAL_PAGE_ORIGIN);
                    Session["indexField"] = "12345";
                    Response.Redirect(personalDocumentsRedirect);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cboPersNr_Callback(object sender, CallbackEventArgsBase e)
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            var persDataList = _VwPersonnelDataRepository.GetAllPersonnel().Distinct().ToList().OrderBy(x => x.Pers_Nr);
            cboPersNr.DataSource = persDataList;
            cboPersNr.DataBind();
        }

        //protected void btnPersonal_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("/Content/Personal.aspx");
        //}
        [WebMethod()]
        public static string GetLocalizedText(string key)
        {
            return BasePage.GetLocalizedText(key);
        }
    }
}