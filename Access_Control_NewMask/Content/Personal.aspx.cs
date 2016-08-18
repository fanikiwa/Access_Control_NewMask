using System;
using System.Collections.Generic;
using System.Linq;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;
using System.Web;
using System.Web.UI;
using DevExpress.Web.Data;
using System.Globalization;
using DevExpress.Web;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Access_Control_NewMask.Content
{
    public partial class Personal : BasePage
    {
        #region Properties
        ZUTMain mainCtl = new ZUTMain();

        private const string PERSONAL_QUERY_PARAM_KEY = "0F88";
        private const string PAGE_ORIGIN_QUERY_PARAM_KEY = "4ED8";
        private const string PERSONAL_PAGE_ORIGIN = "7E30B049";

        private const string PERSONALDASHBOARD_QUERY_PARAM_KEY = "0D88";
        private const string PERSONALDASHBOARD_PAGE_ORIGIN = "7F30B049";

        PersonTypeRepository _personTypeRepository = new PersonTypeRepository();
        LocationRepository _locationRepository = new LocationRepository();
        DepartmentRepository _departmentRepository = new DepartmentRepository();
        CostCenterRepository _costCenterRepository = new CostCenterRepository();
        VehicleTypeRepository _vehicleTypeRepository = new VehicleTypeRepository();
        PersLocationRepository _PersLocationRepository = new PersLocationRepository();
        PersDepartmentRepository _PersDepartmentRepository = new PersDepartmentRepository();
        PersCostCentreRepository _PersCostCentreRepository = new PersCostCentreRepository();
        PersVehicleRepository _PersVehicleRepository = new PersVehicleRepository();
        PersAdditionalInfoRepository _PersAdditionalInfoRepository = new PersAdditionalInfoRepository();
        PersContactsRepository _PersContactsRepository = new PersContactsRepository();
        PersPinCodeRepository _PersPinCodeRepository = new PersPinCodeRepository();
        vwPersPinCodeRepository _vwPersPinCodeRepository = new vwPersPinCodeRepository();
        PersImageRepository _persPassportRepository = new PersImageRepository();
        VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
        //AccessPlanPersMappingViewModel _accessPlanPersMappingViewModel = new AccessPlanPersMappingViewModel();
        //AccessPlanRepository _accessPlanRepository = new AccessPlanRepository();
        AccessPlanPersMappingRepository _accessPlanPersMappingRepo = new AccessPlanPersMappingRepository();
        PersAccessGroupsViewModel _PersAccessGroupsViewModel = new PersAccessGroupsViewModel();

        static string culture;
        static CultureInfo cultureInfo;

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("PersActive_PMode");
            }
            set
            {
                HttpContext.Current.Session["PersActive_PMode"] = value;
            }
        }

        public static string CompanyNo;

        private static int ClientNo = 0;
        private static string ClientName = "keine";
        private static string Perslocation = "keine";
        private static string PersDepartment = "keine";
        private static string PersName = "keine";
        private static int PersIDNo = 0;
        PersonalViewModel personalViewModel = new PersonalViewModel();
        public static List<PersonnelDto> PersonnelList
        {
            get
            {
                return new PersonalViewModel().GetAllActivePersonnel();
            }
            set
            {
                new PersonalViewModel().GetAllActivePersonnel();
            }
        }
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.PersActive, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnSaveAusweis.Enabled = false; btnSaveCarType.Enabled = false; btnSaveClient.Enabled = false; btnSavePersType.Enabled = false;
                btnTakePhoto.Enabled = false; btnTakeWebcamPicture.Enabled = false;

                btnapply.Enabled = false; btnapply2.Enabled = false; btnApplyAccessPlan.Enabled = false;

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

                LoadgrdChangePlan();
                LoadgrdAccessGroups(0);
                BindClients();
                BindLocation();
                BindDepartments();
                BindCostcentres();
                BindPersonnelList();
                LoadDropDownKeine();
                LoadPersonTypes();
                LoadClientsGrid();
                bindPersonalData();
                LoadVehicleTypes();
                LoadPersType();
                LoadNavPoz();
                LoadNavAnz();
            }
            if (IsCallback)
            {
                LoadgrdChangePlan();
            }
        }
        protected void BindClients()
        {
            var clientsed = new ClientsRepository().GetClients();
            List<Client> Clients = new List<Client>();
            Client Client = new Client() { ID = 0, Client_Nr = 0, Name = "keine" };
            Clients.Add(Client);
            Client = new Client() { ID = -1, Client_Nr = 0, Name = "Alle" };
            Clients.Add(Client);
            Clients.AddRange(clientsed);

            cmbClientsName.DataSource = Clients;
            cmbClientsName.DataBind();
            cmbClientsName.SelectedIndex = 0;
        }
        protected void LoadgrdChangePlan()
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
                grdChangePlan.SettingsPager.PageSize = lstAccessPlanAccessGroupDto.Count;
            }

            grdChangePlan.DataSource = lstAccessPlanAccessGroupDto;
            grdChangePlan.DataBind();
        }

        protected void LoadgrdAccessGroups(long persNr)
        {
            List<PersAccessGroupsDto> personalAccessPlanGroups = _PersAccessGroupsViewModel.GetPersAccessGroupByPersNr(persNr);

            List<TbAccessPlanGroup> tbAccessPlanGroups = new List<TbAccessPlanGroup>();
            tbAccessPlanGroups = (new AccessPlanGroupRepository().GetAllAccessPlanGroups()) ?? new List<TbAccessPlanGroup>();
            tbAccessPlanGroups.Add(new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" });
            tbAccessPlanGroups = tbAccessPlanGroups.OrderBy(x => x.AccessPlanGroupNr).ToList();
            HttpContext.Current.Session["Pers_PersAccessGroups"] = tbAccessPlanGroups;

            grdAccessGroups.DataSource = personalAccessPlanGroups;
            grdAccessGroups.DataBind();
        }

        public void BindLocation()
        {
            LocationRepository _LocationRepository = new LocationRepository();

            var locList = _LocationRepository.GetLocations().Where(x => x.Name != "keine");

            List<Location> Locations = new List<Location>();
            Location Location = new Location() { ID = 0, Name = "keine" };
            Locations.Add(Location);
            Locations.AddRange(locList);
            cmbLocations.DataSource = Locations;
            cmbLocations.DataBind();
            cmbLocations.SelectedIndex = 0;

            Location = new Location() { ID = -1, Name = " Alle" };
            Locations.Insert(1, Location);
            cmbLocation.DataSource = Locations;
            cmbLocation.DataBind();
            cmbLocation.SelectedIndex = 0;
        }
        public void LoadVehicleTypes()
        {
            var ptypes = _vehicleTypeRepository.GetVehicleType();

            ddlCarType.DataSource = ptypes;
            ddlCarType.DataValueField = "ID";
            ddlCarType.DataTextField = "Name";
            ddlCarType.DataBind();

            ddlCarType.Items.Insert(0, new ListItem("keine", "0"));
            ddlCarType.SelectedIndex = 0;

        }
        public void BindDepartments()
        {
            DepartmentRepository _DepartmentRepository = new DepartmentRepository();

            var locList = _DepartmentRepository.GetDepartments().Where(x => x.Name != "keine");

            List<Department> Departments = new List<Department>();
            Department Department = new Department() { ID = 0, Department_Nr = 0, Name = "keine" };
            Departments.Add(Department);

            Departments.AddRange(locList);
            cmbDepartments.DataSource = Departments;
            cmbDepartments.DataBind();
            cmbDepartments.SelectedIndex = 0;

            Department = new Department() { ID = -1, Department_Nr = 0, Name = "Alle" };
            Departments.Insert(1, Department);
            cmbDepartment.DataSource = Departments;
            cmbDepartment.DataBind();
            cmbDepartment.SelectedIndex = 0;

        }
        public List<KruAll.Core.Models.VehicleType> LoadVehicleTypes1()
        {
            return _vehicleTypeRepository.GetVehicleType();
        }
        public void BindCostcentres()
        {
            CostCenterRepository _CostCenterRepository = new CostCenterRepository();
            List<CostCenter> listCostCenter = new List<CostCenter>();
            var locList = _CostCenterRepository.GetCostCenters().Where(x => x.Name != "keine");
            CostCenter _costCenter = new CostCenter() { ID = 0, Name = "Keine", CostCenter_Nr = 0 };
            listCostCenter.Add(_costCenter);
            listCostCenter.AddRange(locList);

            cmbCostCenters.DataSource = listCostCenter;
            cmbCostCenters.DataBind();
            cmbCostCenters.SelectedIndex = 0;

        }
        public List<KruAll.Core.Models.CostCenter> LoadCostCenters()
        {
            return _costCenterRepository.GetCostCenters();
        }
        public void BindPersonnelList()
        {
            var persList = new PersonnelViewModel().GetALLPersonnel();

            List<PersonnelDto> Personnels = new List<PersonnelDto>();
            //PersonnelDto Personnel = new PersonnelDto() { Pers_Nr = 0, FirstName = "keine", LastName = "" };
            //Personnels.Add(Personnel);
            Personnels.AddRange(persList);
            cmbPersName.DataSource = Personnels;
            cmbPersName.DataBind();
            cmbIDNr.DataSource = Personnels;
            cmbIDNr.DataBind();
            cmbAusweisNr.DataSource = Personnels;
            cmbAusweisNr.DataBind();
            if (Personnels.Count != 0)// && (!Page.IsPostBack || Page.IsCallback))
            {
                cmbPersName.SelectedIndex = 1;
                cmbIDNr.SelectedIndex = 1;
                cmbAusweisNr.SelectedIndex = 1;

            }
            else
            {
                //if (!Page.IsPostBack) || Page.IsCallback)
                //{
                cmbPersName.SelectedIndex = 0;
                cmbIDNr.SelectedIndex = 0;
                cmbAusweisNr.SelectedIndex = 0;
                //}
            }
        }

        void LoadDropDown()
        {
            ClientsRepository r = new ClientsRepository();
            //Client _clients = new Client() { ID = 0, Client_Nr = "keine" }; ;

            dplCompanyName.DataSource = r.GetClients();
            dplCompanyName.DataBind();

        }

        void LoadDropDownKeine()
        {

            ClientsRepository r = new ClientsRepository();
            dplCompanyName.DataSource = r.GetClientskeine();
            dplCompanyName.DataBind();
        }

        public void LoadPersonTypes()
        {
            Pers_Type persType = new Pers_Type()
            {
                ID = 0,
                Name = "keine"
            };
            var ptypes = _personTypeRepository.GetAllPersonTypes();
            List<Pers_Type> listPersType = new List<Pers_Type>();
            listPersType.Add(persType);
            listPersType.AddRange(ptypes);
            ddlPersType.DataSource = listPersType;
            ddlPersType.DataBind();
        }

        public void LoadNavPoz()
        {

            var i = (cmbPersName.SelectedIndex + 1);
            //dpllPersName.SelectedIndex = i;
            cmbAusweisNr.SelectedIndex = i;
            cmbIDNr.SelectedIndex = i;
            txtFvCurrentEntry.Text = (i).ToString();
            BindOtherControls();
            if (!IsCallback)
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Load selected Personal",
               //"setTimeout(function() { PageMethods.Getpersonal( cmbPersName.GetValue(), Setcontrals ) }, 1);", true);
            }
        }


        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string ConvertImageBytesToURL(string imageBytes, string pers_Nr, string names)
        {
            string photoImageFile = string.Empty;
            long persNr;
            long.TryParse(pers_Nr, out persNr);
            string firstName = string.Empty;

            var person = PersonnelList.FirstOrDefault(p => p.Pers_Nr == persNr);

            if (person != null)
            {
                firstName = person.FirstName;
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
                photoImageFile = FileProcessor.SaveImageFile("," + imageBytes, firstName + pers_Nr + DateTime.Now.ToString("yyyyMMddHHmmss"));
                photoImageFile = FileProcessor.GetPersonalImageFile(photoImageFile);
            }


            return photoImageFile;
        }

        [WebMethod]
        public static bool CheckIfPersNrExists(string PersNr)
        {
            var exists = false;
            PersonnelRepository _PersonnelRepository = new PersonnelRepository();
            var personal = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(PersNr));

            if (personal != null)
            {
                exists = true;
            }
            return exists;
        }

        [WebMethod]
        public static PersonalData_DTO EditPersonalInDatabase(string jSONData)
        {
            PersonnelNewViewModel personalViewModel = new PersonnelNewViewModel();
            PersonalData_DTO personal = null;
            List<PersonalData_DTO> personalList = JsonConvert.DeserializeObject<List<PersonalData_DTO>>(jSONData);
            if (personalList.Count > 0)
            {
                personal = personalList[0];
                personalViewModel.EditPersonalInDatabase(personal);
                personalViewModel.EditLocationDepartmentAndCostCenter(personal);
            }
            return personal;
        }


        [WebMethod]
        public static Pers_Type CreateEditPersType(string id, string persTypeName, string persTypeMemo, string persTypeColor)
        {
            var PersonnelType = new Pers_Type();
            if (string.IsNullOrEmpty(id))
            {
                Pers_Type _persType = new Pers_Type()
                {
                    Name = persTypeName,
                    Memo = persTypeMemo,
                    PersTypeColor = persTypeColor

                };
                new PersonTypeRepository().NewPersType(_persType);
                PersonnelType = _persType;
            }
            else
            {
                var persType = new PersonTypeRepository().GetPersonTypeById(Convert.ToInt64(id));
                if (persType != null)
                {
                    Pers_Type _persType = new Pers_Type()
                    {
                        ID = persType.ID,
                        Name = persTypeName,
                        Memo = persTypeMemo,
                        PersTypeColor = persTypeColor

                    };
                    new PersonTypeRepository().EditPersType(_persType);
                    PersonnelType = _persType;
                }
            }

            return PersonnelType;
        }


        [WebMethod]
        public static int Isnewrecord(string Personalnumber)
        {

            int i;

            PersonnelRepository _PersonnelRepository = new PersonnelRepository();
            var p = _PersonnelRepository.GetPersonnelPersnur(Convert.ToInt64(Personalnumber));

            if (p != null)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }

        [WebMethod]
        public static PersonalData_DTO Getpersonal(string Personalnumber)
        {
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

                _PersonalData_DTO.Active = persData.Active;

                _PersonalData_DTO.PersType = persData.PersType;
                _PersonalData_DTO.DOB = persData.DOB;
                _PersonalData_DTO.EntryDate = persData.EntryDate;
                _PersonalData_DTO.ExitDate = persData.ExitDate;

                _PersonalData_DTO.companyName = persData.CompanyName;
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
            //_PersonalData_DTO.PassPhoto = persData==null?null: string.IsNullOrWhiteSpace(persData.Pers_Passport) ? "" : persData.Pers_Passport.Replace("~", "..");
            //PersonalData_DTO _PersonalData_DTO = new PersonalData_DTO();
            //_PersonalData_DTO.LocationID = Convert.ToInt64(persDataList.LocationID);
            //_PersonalData_DTO.DepartmentID = Convert.ToInt64(persDataList.DepartmentID);

            var Pinecode = new vwPersPinCodeRepository().GetPersPinCodes().Where(x => x.Pers_Nr == Convert.ToInt64(Personalnumber)).FirstOrDefault();
            if (Pinecode != null)
            {
                _PersonalData_DTO.AusweisPincodeStr = Pinecode.Aus_PinCode;
                _PersonalData_DTO.PincodeActives = Convert.ToBoolean(Pinecode.Aus_PinCodeStatus);

                _PersonalData_DTO.SicherheitsPincodeStr = Pinecode.Scher_PinCode;
                _PersonalData_DTO.MenaceActive = Convert.ToBoolean(Pinecode.Scher_PinCodeStatus);

                _PersonalData_DTO.NurPincodeActive = Convert.ToBoolean(Pinecode.Nur_PinCodeStatus);
                _PersonalData_DTO.NurPincodeStr = Pinecode.Nur_PinCode;
            }
            else
            {
                _PersonalData_DTO.NurPincodeActive = true;
            }

            return _PersonalData_DTO;
        }

        [WebMethod]
        public static void DeleteClient(int ClientID)
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            Client _Client = new Client() { ID = ClientID };
            _ClientsRepository.DeleteClient(_Client);

        }

        [WebMethod]
        public static long GetLastInsertedClient()
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            var _Client = _ClientsRepository.GetLastInserted();
            if (_Client == null) { return 1; }
            else { return _Client.Client_Nr + 1; }
        }


        protected void ClearControls()
        {
            //if (dpllPersName.Items.FindByValue("0") != null) dpllPersName.SelectedValue = "0";
            //if (ddlIDNr.Items.FindByValue("0") != null) ddlIDNr.SelectedValue = "0";
            //if (ddlAusweisNr.Items.FindByValue("0") != null) ddlAusweisNr.SelectedValue = "0";
            //ddllLocation.SelectedValue = "0";
            //ddlDepartment.SelectedValue = "0";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtCompany.Text = "";
            txtStreet.Text = "";
            //txtLocation.Text = "";
            txtPersonalNr.Text = "";
            ddlPersType.Value = "0";
            ddlCarType.SelectedValue = "0";
            txtCarRegNo.Text = "";
            //ddlLocations.SelectedValue = "0";
            //ddlDepartments.SelectedValue = "0";
            //ddlCostCenter.SelectedValue = "0";
            cmbLocations.Value = 0;
            cmbDepartments.Value = 0;
            cmbCostCenters.Value = 0;
            txtMemo.Text = "";
            txtAusweisNr.Text = "";
            chkIdentificationActive.Checked = false;
            txtAusweisPincode.Text = "";
            chkPincodeActive.Checked = false;
            txtNurPincode.Text = "";
            chkNurPincodeActive.Checked = false;
            txtSicherheitsPincode.Text = "";
            chkMenaceActive.Checked = false;
            dpAccessPlanDateFrom.Text = "";
            dpAccessPlanDateTo.Text = "";
            txtZuttritsplanNr.Text = "";
            txtZuttritsBezeichnung.Text = "";
            txtAutomaticLogout.Text = "";
            img.Src = "";
            UploadPhoto.Attributes.Clear();
            DoBpicker.Text = "";
            DofEntry.Text = "";
            DofExit.Text = "";
            txtPosition.Text = "";
            txtNationality.Text = "";
            txtCompTel.Text = "";
            txtCompMobile.Text = "";
            txtPrivTel.Text = "";
            txtPrivMobile.Text = "";
            txtCompanyEmail.Text = "";
            txtPrivateEmail.Text = "";
            chkActivePersonal.Checked = false;

        }
        public List<KruAll.Core.Models.Pers_Type> LoadPersonTypes1()
        {
            return _personTypeRepository.GetAllPersonTypes();
        }
        protected void DisableEnableTopDropdowns(bool drpEnabled, bool txtEnabled)
        {
            //dpllPersName.Enabled = drpEnabled;
            //ddlIDNr.Enabled = drpEnabled;
            //ddlAusweisNr.Enabled = drpEnabled;
            //ddllLocation.Enabled = drpEnabled;
            //ddlDepartment.Enabled = drpEnabled;
            txtPersonalNr.Enabled = txtEnabled;
        }

        protected void CalculateNxtNr()
        {
            var personnnel = new PersonnelViewModel().GetPersonnels();
            long lastPersNr = 0;
            if (personnnel.Count > 0)
            {
                lastPersNr = personnnel.Max(x => x.Pers_Nr);
            }
            long ntxPersNr = lastPersNr + 1;
            txtPersonalNr.Text = ntxPersNr.ToString();
        }


        protected void SaveAccessPlan(TbAccessPlanPersMapping accessPlan)
        {
            int insert = accessPlan == null ? 0 : 1;
            AccessPlanPersMappingRepository _planMapping = new AccessPlanPersMappingRepository();
            var accessPLanNr = txtZuttritsplanNr.Text;
            if (string.IsNullOrEmpty(accessPLanNr)) return;
            var tbAccessPlan = new AccessPlanRepository().GetAccessPlanByNumber(Convert.ToInt64(accessPLanNr));
            if (tbAccessPlan == null) return;
            var location = Convert.ToInt32(cmbLocation.SelectedItem.Value);
            var dateFrom = !string.IsNullOrEmpty(dpAccessPlanDateFrom.Text) ? Convert.ToDateTime(dpAccessPlanDateFrom.Text) : (DateTime?)null;
            var dateTo = !string.IsNullOrEmpty(dpAccessPlanDateTo.Text) ? Convert.ToDateTime(dpAccessPlanDateTo.Text) : (DateTime?)null;
            switch (insert)
            {
                case 0:
                    TbAccessPlanPersMapping acessPlanInsert = new TbAccessPlanPersMapping()
                    {
                        Pers_Nr = Convert.ToInt64(txtPersonalNr.Text.Trim()),
                        AccessPlan_Nr = tbAccessPlan.ID,
                        Location_ID = location > 0 ? location : (int?)null,
                        DateFrom = dateFrom,
                        DateTo = dateTo,
                        AutomaticLogout = txtAutomaticLogout.Text.Trim()
                    };
                    _planMapping.NewAccessPlanPersMapping(acessPlanInsert);

                    break;
                case 1:
                    TbAccessPlanPersMapping acessPlanEdit = new TbAccessPlanPersMapping()
                    {
                        ID = accessPlan.ID,
                        Pers_Nr = Convert.ToInt64(txtPersonalNr.Text.Trim()),
                        AccessPlan_Nr = tbAccessPlan.ID,
                        Location_ID = location > 0 ? location : (int?)null,
                        DateFrom = dateFrom,
                        DateTo = dateTo,
                        AutomaticLogout = txtAutomaticLogout.Text.Trim()
                    };
                    _planMapping.EditAccessPlanPersMapping(acessPlanEdit);

                    break;
            }
        }

        protected void SavePinCodes(List<Pers_PinCode> type_1, List<Pers_PinCode> type_2, List<Pers_PinCode> type_3)
        {

            if (type_1.Count > 0)
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                var pinTypeId = type_1.Max(x => x.ID);
                var pinType_1 = type_1.Find(x => x.ID == pinTypeId);
                pin = !string.IsNullOrEmpty(txtAusweisPincode.Text) ? txtAusweisPincode.Text : "";
                pintype = 1;
                pinstatus = chkPincodeActive.Checked;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { ID = pinType_1.ID, Pers_Nr = Convert.ToInt64(txtPersonalNr.Text), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().EditPinCode(_PerPinCode);


            }
            else
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                if (!string.IsNullOrEmpty(txtAusweisPincode.Text))
                {
                    pin = !string.IsNullOrEmpty(txtAusweisPincode.Text) ? txtAusweisPincode.Text : "";
                    pintype = 1;
                    pinstatus = chkPincodeActive.Checked;

                    Pers_PinCode _PerPinCode = new Pers_PinCode() { Pers_Nr = Convert.ToInt64(txtPersonalNr.Text), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                    new PersPinCodeRepository().NewPinCode(_PerPinCode);

                }

            }
            if (type_2.Count > 0)
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                var pinTypeId = type_2.Max(x => x.ID);
                var pinType_2 = type_2.Find(x => x.ID == pinTypeId);
                pin = !string.IsNullOrEmpty(txtNurPincode.Text) ? txtNurPincode.Text : "";
                pintype = 2;
                pinstatus = chkNurPincodeActive.Checked;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { ID = pinType_2.ID, Pers_Nr = Convert.ToInt64(txtPersonalNr.Text), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().EditPinCode(_PerPinCode);

            }
            else
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;

                pin = !string.IsNullOrEmpty(txtNurPincode.Text) ? txtNurPincode.Text : "";
                pintype = 2;
                pinstatus = chkPincodeActive.Checked;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { Pers_Nr = Convert.ToInt64(txtPersonalNr.Text), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().NewPinCode(_PerPinCode);


            }
            if (type_3.Count > 0)
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;

                var pinTypeId = type_3.Max(x => x.ID);
                var pinType_3 = type_3.Find(x => x.ID == pinTypeId);
                pin = !string.IsNullOrEmpty(txtSicherheitsPincode.Text) ? txtSicherheitsPincode.Text : "";
                pintype = 3;
                pinstatus = chkMenaceActive.Checked;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { ID = pinType_3.ID, Pers_Nr = Convert.ToInt64(txtPersonalNr.Text), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().EditPinCode(_PerPinCode);

            }
            else
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                if (!string.IsNullOrEmpty(txtSicherheitsPincode.Text))
                {
                    pin = !string.IsNullOrEmpty(txtSicherheitsPincode.Text) ? txtSicherheitsPincode.Text : "";
                    pintype = 3;
                    pinstatus = chkMenaceActive.Checked;

                    Pers_PinCode _PerPinCode = new Pers_PinCode() { Pers_Nr = Convert.ToInt64(txtPersonalNr.Text), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                    new PersPinCodeRepository().NewPinCode(_PerPinCode);
                }

            }

        }
        void savePerzClientMapping(int PerzNo, int ClientID, string State)
        {
            PersClientRepository r = new PersClientRepository();
            if (State == "save")
            {
                Pers_Client c = new Pers_Client();
                c.Pers_Nr = PerzNo;
                c.ClientID = ClientID;
                r.InsertPersClient(c);
            }

            if (State == "edit")
            {
                Pers_Client a = r.GetPersClientByPersNo(PerzNo);
                Pers_Client _a = new Pers_Client { ClientID = ClientID, Pers_Nr = PerzNo };
                r.UpdatePerz(a, _a);
            }
        }
        private void SavePersonnalPassport(Pers_Photo photo)
        {
            int imagefilelenth = UploadPhoto.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = UploadPhoto.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);

            string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg" };
            string ext = System.IO.Path.GetExtension(UploadPhoto.PostedFile.FileName);
            bool isValidFile = false;

            for (int i = 0; i < validFileTypes.Length; i++)
            {

                if (ext == "." + validFileTypes[i])
                {

                    isValidFile = true;

                    break;

                }

            }

            if (!isValidFile)
            {

                //lblMessage.ForeColor = System.Drawing.Color.Red;

                //lblMessage.Text = "Invalid File. Please upload a File with extension " +

                //               string.Join(",", validFileTypes);

            }

            else
            {
                int insert = photo == null ? 0 : 1;
                PersImageRepository _persPassport = new PersImageRepository();

                switch (insert)
                {
                    case 0:
                        Pers_Photo persPhotoInsert = new Pers_Photo()
                        {
                            Pers_Nr = Convert.ToInt64(txtPersonalNr.Text.Trim()),
                            //  Pers_Passport = imgarray
                        };
                        _persPassport.NewPersonnalPhoto(persPhotoInsert);

                        break;
                    case 1:
                        Pers_Photo persPhotoEdit = new Pers_Photo()
                        {
                            ID = photo.ID,
                            Pers_Nr = Convert.ToInt64(txtPersonalNr.Text.Trim()),
                            // Pers_Passport = imgarray
                        };
                        _persPassport.EditPersonnalPhoto(persPhotoEdit);

                        break;
                }
            }
        }

        [WebMethod]
        public static long CalculateNextNr()
        {
            //var personnnel = new PersonnelViewModel().GetPersonnels();
            //long lastPersNr = 0;
            //if (personnnel.Count > 0)
            //{
            //    lastPersNr = personnnel.Max(x => x.Pers_Nr);
            //}
            //return lastPersNr + 1;

            long lastPersNr = new PersonnelViewModel().GetLastPerNr();
            return lastPersNr + 1;

        }

        public void LoadNavAnz()
        {
            //dpllPersName.DataBind();

            var total = cmbPersName.Items.Count - 1;
            txtFvTotalEntries.Text = total.ToString();
        }

        private List<PersonnelDto> GetPersonnelDtoList(List<VwPersonnelData> personnelListno)
        {
            List<PersonnelDto> personneDtoList = new List<PersonnelDto>();
            foreach (var item in personnelListno)
            {
                personneDtoList.Add(new PersonnelDto
                {
                    ID = item.ID,
                    PersNr = item.Pers_Nr,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    LocationID = Convert.ToInt32(item.LocationID),
                    DepartmentID = Convert.ToInt32(item.DepartmentID),
                    CostCenterID = Convert.ToInt32(item.CostCenterID),
                    Card_Nr = item.Card_Nr,

                });
            }

            return personneDtoList;
        }

        [WebMethod]
        public List<PersonnelDto> ApplyFilterToPersonnel(string filter)
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            string[] passedValues = filter.Split(';');
            var casevalue = Convert.ToInt32(passedValues[1]);
            var value = Convert.ToInt32(passedValues[0]);
            switch (Convert.ToInt32(passedValues[1]))
            {
                case 0:

                    var persList = new PersonnelViewModel().GetALLPersonnel();
                    List<PersonnelDto> Personnels = new List<PersonnelDto>();
                    //PersonnelDto Personnel = new PersonnelDto() { Pers_Nr = 0, FirstName = "keine", LastName  = ""};
                    //Personnels.Add(Personnel);
                    Personnels.AddRange(persList);
                    //cmbPersName.DataSource = Personnels;
                    //cmbPersName.DataBind();

                    if (value > 0)
                    {
                        cmbPersName.Value = value;
                    }
                    return Personnels;

                case 1:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        //cmbPersName.DataSource = persListall;
                        //cmbPersName.DataBind();
                        //break;
                        return persListall;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);

                        //cmbPersName.DataSource = personnelListno;
                        //cmbPersName.DataBind();
                        //break;
                        return GetPersonnelDtoList(personnelListno);
                    }
                    List<VwPersonnelData> personnelList = new List<VwPersonnelData>();
                    var persons = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObj = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelList.Add(personnelObj);
                    personnelList.AddRange(persons);
                    //cmbPersName.DataSource = personnelList;
                    //cmbPersName.DataBind();
                    //break;

                    return GetPersonnelDtoList(personnelList);
                case 2:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        //cmbPersName.DataSource = persListall;
                        //cmbPersName.DataBind();
                        //break;
                        return persListall;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        //cmbPersName.DataSource = personnelListno;
                        //cmbPersName.DataBind();
                        //break;
                        return GetPersonnelDtoList(personnelListno);
                    }
                    List<VwPersonnelData> personnelListtwo = new List<VwPersonnelData>();
                    var personstwo = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjtwo = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListtwo.Add(personnelObjtwo);
                    personnelListtwo.AddRange(personstwo);
                    //cmbPersName.DataSource = personnelListtwo;
                    //cmbPersName.DataBind();
                    //break;
                    return GetPersonnelDtoList(personnelListtwo);
                case 3:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        //cmbPersName.DataSource = persListall;
                        //cmbPersName.DataBind();
                        //break;
                        return persListall;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        //cmbPersName.DataSource = personnelListno;
                        //cmbPersName.DataBind();
                        //break;
                        return GetPersonnelDtoList(personnelListno);
                    }
                    List<VwPersonnelData> personnelListthree = new List<VwPersonnelData>();
                    var personsthree = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjthree = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListthree.Add(personnelObjthree);
                    personnelListthree.AddRange(personsthree);
                    //cmbPersName.DataSource = personnelListthree;
                    //cmbPersName.DataBind();
                    //break;
                    return GetPersonnelDtoList(personnelListthree);
                default:
                    return new PersonnelViewModel().GetALLPersonnel();
            }
        }

        private void CreatePersonnelDtoFromPerson()
        {
        }
        protected void cmbPersName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            string[] passedValues = e.Parameter.Split(';');
            var casevalue = Convert.ToInt32(passedValues[1]);
            var value = Convert.ToInt32(passedValues[0]);
            switch (Convert.ToInt32(passedValues[1]))
            {
                case 0:

                    var persList = new PersonnelViewModel().GetALLPersonnel();
                    List<PersonnelDto> Personnels = new List<PersonnelDto>();
                    //PersonnelDto Personnel = new PersonnelDto() { Pers_Nr = 0, FirstName = "keine", LastName  = ""};
                    //Personnels.Add(Personnel);
                    Personnels.AddRange(persList);
                    cmbPersName.DataSource = Personnels;
                    cmbPersName.DataBind();
                    if (value > 0)
                    {
                        cmbPersName.Value = value;
                    }

                    break;
                case 1:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbPersName.DataSource = persListall;
                        cmbPersName.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbPersName.DataSource = personnelListno;
                        cmbPersName.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelList = new List<VwPersonnelData>();
                    var persons = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObj = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelList.Add(personnelObj);
                    personnelList.AddRange(persons);
                    cmbPersName.DataSource = personnelList;
                    cmbPersName.DataBind();
                    break;
                case 2:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbPersName.DataSource = persListall;
                        cmbPersName.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbPersName.DataSource = personnelListno;
                        cmbPersName.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelListtwo = new List<VwPersonnelData>();
                    var personstwo = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjtwo = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListtwo.Add(personnelObjtwo);
                    personnelListtwo.AddRange(personstwo);
                    cmbPersName.DataSource = personnelListtwo;
                    cmbPersName.DataBind();
                    break;
                case 3:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbPersName.DataSource = persListall;
                        cmbPersName.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbPersName.DataSource = personnelListno;
                        cmbPersName.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelListthree = new List<VwPersonnelData>();
                    var personsthree = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjthree = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListthree.Add(personnelObjthree);
                    personnelListthree.AddRange(personsthree);
                    cmbPersName.DataSource = personnelListthree;
                    cmbPersName.DataBind();
                    break;
            }
        }

        protected void cmbIDNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            string[] passedValues = e.Parameter.Split(';');
            var casevalue = Convert.ToInt32(passedValues[1]);
            var value = Convert.ToInt32(passedValues[0]);
            switch (Convert.ToInt32(passedValues[1]))
            {
                case 0:
                    var persList = new PersonnelViewModel().GetALLPersonnel();
                    List<PersonnelDto> Personnels = new List<PersonnelDto>();
                    Personnels.AddRange(persList);
                    cmbIDNr.DataSource = Personnels;
                    cmbIDNr.DataBind();
                    if (value > 0)
                    {
                        cmbIDNr.Value = value;
                    }

                    break;

                case 1:
                    if (value == 0)
                    {
                        var persListno = new PersonnelViewModel().GetALLPersonnel();
                        List<PersonnelDto> Personnelnos = new List<PersonnelDto>();
                        Personnelnos.AddRange(persListno);
                        cmbIDNr.DataSource = Personnelnos;
                        cmbIDNr.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbIDNr.DataSource = personnelListno;
                        cmbIDNr.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelList = new List<VwPersonnelData>();
                    var persons = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObj = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelList.Add(personnelObj);
                    personnelList.AddRange(persons);
                    cmbIDNr.DataSource = personnelList;
                    cmbIDNr.DataBind();
                    break;
                case 2:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbIDNr.DataSource = persListall;
                        cmbIDNr.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbIDNr.DataSource = personnelListno;
                        cmbIDNr.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelListtwo = new List<VwPersonnelData>();
                    var personstwo = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjtwo = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListtwo.Add(personnelObjtwo);
                    personnelListtwo.AddRange(personstwo);
                    cmbIDNr.DataSource = personnelListtwo;
                    cmbIDNr.DataBind();
                    break;
                case 3:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbIDNr.DataSource = persListall;
                        cmbIDNr.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbIDNr.DataSource = personnelListno;
                        cmbIDNr.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelListthree = new List<VwPersonnelData>();
                    var personsthree = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjthree = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListthree.Add(personnelObjthree);
                    personnelListthree.AddRange(personsthree);
                    cmbIDNr.DataSource = personnelListthree;
                    cmbIDNr.DataBind();
                    break;
            }
            //var persList = new PersonnelViewModel().GetALLPersonnel();

            //List<PersonnelDto> Personnels = new List<PersonnelDto>();
            ////PersonnelDto Personnel = new PersonnelDto() { Pers_Nr = 0, FirstName = "keine", LastName  = ""};
            ////Personnels.Add(Personnel);
            //Personnels.AddRange(persList);
            //cmbIDNr.DataSource = Personnels;
            //cmbIDNr.DataBind();
        }

        protected void cmbAusweisNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            string[] passedValues = e.Parameter.Split(';');
            var casevalue = Convert.ToInt32(passedValues[1]);
            var value = Convert.ToInt32(passedValues[0]);
            switch (Convert.ToInt32(passedValues[1]))
            {
                case 0:

                    var persList = new PersonnelViewModel().GetALLPersonnel();

                    List<PersonnelDto> Personnels = new List<PersonnelDto>();
                    Personnels.AddRange(persList);
                    cmbAusweisNr.DataSource = Personnels;
                    cmbAusweisNr.DataBind();
                    if (value > 0)
                    {
                        cmbAusweisNr.Value = value;
                    }
                    break;

                case 1:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbAusweisNr.DataSource = persListall;
                        cmbAusweisNr.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbAusweisNr.DataSource = personnelListno;
                        cmbAusweisNr.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelList = new List<VwPersonnelData>();
                    var persons = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.ClientID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObj = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelList.Add(personnelObj);
                    personnelList.AddRange(persons);
                    cmbAusweisNr.DataSource = personnelList;
                    cmbAusweisNr.DataBind();
                    break;
                case 2:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbAusweisNr.DataSource = persListall;
                        cmbAusweisNr.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbAusweisNr.DataSource = personnelListno;
                        cmbAusweisNr.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelListtwo = new List<VwPersonnelData>();
                    var personstwo = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.LocationID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjtwo = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListtwo.Add(personnelObjtwo);
                    personnelListtwo.AddRange(personstwo);
                    cmbAusweisNr.DataSource = personnelListtwo;
                    cmbAusweisNr.DataBind();
                    break;
                case 3:
                    if (value == 0)
                    {
                        var persListall = new PersonnelViewModel().GetALLPersonnel();
                        cmbAusweisNr.DataSource = persListall;
                        cmbAusweisNr.DataBind();
                        break;
                    }
                    if (value == -1)
                    {
                        List<VwPersonnelData> personnelListno = new List<VwPersonnelData>();
                        var personnos = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == null && c.Active == true).ToList();
                        VwPersonnelData personnelObjno = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                        personnelListno.Add(personnelObjno);
                        personnelListno.AddRange(personnos);
                        cmbAusweisNr.DataSource = personnelListno;
                        cmbAusweisNr.DataBind();
                        break;
                    }
                    List<VwPersonnelData> personnelListthree = new List<VwPersonnelData>();
                    var personsthree = _VwPersonnelDataRepository.GetAllPersonnel().Where(c => c.DepartmentID == value && c.Active == true).ToList();
                    VwPersonnelData personnelObjthree = new VwPersonnelData() { Pers_Nr = 0, FirstName = "Keine", LastName = "" };
                    personnelListthree.Add(personnelObjthree);
                    personnelListthree.AddRange(personsthree);
                    cmbAusweisNr.DataSource = personnelListthree;
                    cmbAusweisNr.DataBind();
                    break;
            }
            //var persList = new PersonnelViewModel().GetALLPersonnel();

            //List<PersonnelDto> Personnels = new List<PersonnelDto>();
            ////PersonnelDto Personnel = new PersonnelDto() { Pers_Nr = 0, FirstName = "keine", LastName  = ""};
            ////Personnels.Add(Personnel);
            //cmbAusweisNr.DataSource = Personnels;
            //cmbAusweisNr.DataBind();
        }

        protected void btnPersonalForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalForm.aspx");
        }
        public void BindOtherControls()
        {
            if (!string.IsNullOrEmpty(cmbIDNr.Value.ToString()))
            {
                if (Convert.ToInt64(cmbIDNr.Value) < 1)
                {
                    ClearControlsFilter();
                    BindTransponders(0);
                    return;
                }
            }

            var id = long.Parse(cmbIDNr.Value.ToString());
            Debug.WriteLine(id);

            PersonnelViewModel _PersonnelViewModel = new PersonnelViewModel();

            if (!string.IsNullOrEmpty(Convert.ToString(cmbIDNr.Value)))
            {
                var persFilteredList = _PersonnelViewModel.GetPersonnel().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value));
                if (persFilteredList == null || !persFilteredList.Any()) persFilteredList = new List<PersonnelDto> { new PersonnelDto() };
                var loc = _PersLocationRepository.GetLocations().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();
                var dep = _PersDepartmentRepository.GetDepartments().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();
                var cos = _PersCostCentreRepository.GetCostCentres().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();
                var veh = _PersVehicleRepository.GetVehicles().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();
                var pinfo = _PersAdditionalInfoRepository.GetPersAddInfo().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();
                var pcont = _PersContactsRepository.GetContacts().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();
                var pincode = _vwPersPinCodeRepository.GetPersPinCodes().Where(x => x.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();

                var persPassPort = _persPassportRepository.GetPersonnalPhotoByPers_Nr(Convert.ToInt64(cmbIDNr.Value));
                var accessPlan = _accessPlanPersMappingRepo.GetMappingByEmployeeNumber(Convert.ToInt64(cmbIDNr.Value));

                var vwPer = _VwPersonnelDataRepository.GetAllPersonnel().Where(v => v.Pers_Nr == Convert.ToInt64(cmbIDNr.Value)).FirstOrDefault();

                txtAusweisNr.Text = Convert.ToString(persFilteredList.FirstOrDefault().IdentificationNr);
                txtAusweisPincode.Text = Convert.ToString(persFilteredList.FirstOrDefault().PinCode);
                txtFirstName.Text = persFilteredList.FirstOrDefault().FirstName;
                txtLastName.Text = persFilteredList.FirstOrDefault().LastName;
                txtPersonalNr.Text = Convert.ToString(persFilteredList.FirstOrDefault().PersNr);
                //if (persFilteredList.FirstOrDefault().Imported == true)
                //{
                //    Label38.Style.di = true;
                //    imgimport.Visible = true;
                //}
                //else
                //{
                //    Label38.Visible = false;
                //    imgimport.Visible = false;

                //   }
                if (persFilteredList.FirstOrDefault().PersType != null) { ddlPersType.Value = Convert.ToString(persFilteredList.FirstOrDefault().PersType); } else { ddlPersType.Value = "0"; };
                if (veh != null) { ddlCarType.SelectedValue = Convert.ToString(veh.VehicleID); } else { ddlCarType.SelectedValue = "0"; };

                if (loc != null) { cmbLocations.Value = Convert.ToString(loc.LocationID); } else { cmbLocations.Value = 0; }
                if (dep != null) { cmbDepartments.Value = Convert.ToString(dep.DepartmentID); } else { cmbDepartments.Value = 0; }
                if (cos != null) { cmbCostCenters.Value = Convert.ToString(cos.CostCenterID); } else { cmbCostCenters.Value = 0; }

                //if (loc != null) { ddlLocations.SelectedValue = Convert.ToString(loc.LocationID); } else { ddlLocations.SelectedValue = "0"; };
                //if (dep != null) { ddlDepartments.SelectedValue = Convert.ToString(dep.DepartmentID); } else { ddlDepartments.SelectedValue = "0"; };
                //if (cos != null) { ddlCostCenter.SelectedValue = Convert.ToString(cos.CostCenterID); } else { ddlCostCenter.SelectedValue = "0"; };

                txtMemo.Text = persFilteredList.FirstOrDefault().Memo;
                chkImported.Checked = Convert.ToBoolean(persFilteredList.FirstOrDefault().Imported);
                chkIdentificationActive.Checked = Convert.ToBoolean(persFilteredList.FirstOrDefault().CardActive);

                if (pincode != null) { txtAusweisPincode.Text = Convert.ToString(pincode.Aus_PinCode); } else { txtAusweisPincode.Text = ""; };
                if (pincode != null) { chkPincodeActive.Checked = Convert.ToBoolean(pincode.Aus_PinCodeStatus); } else { chkPincodeActive.Checked = false; };
                if (pincode != null) { txtNurPincode.Text = Convert.ToString(pincode.Nur_PinCode); } else { txtNurPincode.Text = ""; };
                if (pincode != null) { chkNurPincodeActive.Checked = Convert.ToBoolean(pincode.Nur_PinCodeStatus); } else { chkNurPincodeActive.Checked = false; };
                if (pincode != null) { txtSicherheitsPincode.Text = Convert.ToString(pincode.Scher_PinCode); } else { txtSicherheitsPincode.Text = ""; };
                if (pincode != null) { chkMenaceActive.Checked = Convert.ToBoolean(pincode.Scher_PinCodeStatus); } else { chkMenaceActive.Checked = false; };

                if (pinfo != null) { DoBpicker.Value = Convert.ToDateTime(pinfo.DOB); } else { DoBpicker.Value = DateTime.MinValue; };
                if (pinfo != null) { DofEntry.Value = Convert.ToDateTime(persFilteredList.FirstOrDefault().EntryDate); } else { DofEntry.Value = DateTime.MinValue; };
                if (pinfo != null) { DofExit.Value = Convert.ToDateTime(persFilteredList.FirstOrDefault().ExitDate); } else { DofExit.Value = DateTime.MinValue; };
                if (pinfo != null) { txtPosition.Text = pinfo.Position; } else { txtPosition.Text = ""; };
                if (pinfo != null) { txtNationality.Text = pinfo.Nationality; } else { txtNationality.Text = ""; };
                if (pinfo != null) { txtCarRegNo.Text = pinfo.VehicleReg; } else { txtCarRegNo.Text = ""; };
                if (pinfo != null) { txtCompany.Text = pinfo.CompanyName; } else { txtCompany.Text = ""; };
                if (pinfo != null) { txtStreet.Text = pinfo.Street; } else { txtStreet.Text = ""; };
                //if (pinfo != null) { txtLocation.Text = pinfo.PhysicalAddress; } else { txtLocation.Text = ""; };


                if (vwPer != null) { if (vwPer.ClientName != null) { txtCompanyName.Text = vwPer.ClientName; } else { txtCompanyName.Text = "keine"; } } else { txtCompanyName.Text = "keine"; };
                if (vwPer != null) { if (vwPer.ClientID != null) { dplCompanyName.Value = vwPer.ClientID; } else { dplCompanyName.Value = "0"; } } else { dplCompanyName.Value = "0"; };


                if (pcont != null) { txtCompTel.Text = pcont.CompanyTel; } else { txtCompTel.Text = ""; }
                if (pcont != null) { txtCompMobile.Text = pcont.CompanyMobile; } else { txtCompMobile.Text = ""; }
                if (pcont != null) { txtPrivTel.Text = pcont.PrivateTel; } else { txtPrivTel.Text = ""; }
                if (pcont != null) { txtPrivMobile.Text = pcont.PrivateMobile; } else { txtPrivMobile.Text = ""; }
                if (pcont != null) { txtCompanyEmail.Text = pcont.CompanyEmail; } else { txtCompanyEmail.Text = ""; }
                if (pcont != null) { txtPrivateEmail.Text = pcont.PrivateEmail; } else { txtPrivateEmail.Text = ""; }
                if (persPassPort != null)
                {
                    string im = FileProcessor.GetImageFile(persPassPort.Pers_Passport);
                    if (im != null)
                    {
                        photVal.Value = im;
                        img.Src = im;
                    }
                }// persPassPort.Pers_Passport; }// "data:image/png;base64," + Convert.ToBase64String(imageToByteArray(PersonnelCtl.ByteArrayToImage(persPassPort.Pers_Passport))); } else { img.Src = ""; }
                if (accessPlan != null)
                {
                    var selectedPlan = new AccessPlanRepository().GetAccessPlanById(accessPlan.AccessPlan_Nr);
                    txtZuttritsplanNr.Text = selectedPlan.AccessPlanNr.ToString();
                    txtZuttritsBezeichnung.Text = selectedPlan.AccessPlanDescription;
                    txtdateEdited.Text = selectedPlan.AccessPlanDescription;
                    txtAutomaticLogout.Text = accessPlan.AutomaticLogout;
                    dpAccessPlanDateFrom.Value = accessPlan.DateFrom != null ? Convert.ToDateTime(accessPlan.DateFrom) : DateTime.MinValue;
                    dpAccessPlanDateTo.Value = accessPlan.DateTo != null ? Convert.ToDateTime(accessPlan.DateTo) : DateTime.MinValue;
                }
                else
                {
                    txtZuttritsplanNr.Text = "";
                    txtZuttritsBezeichnung.Text = "";
                    txtAutomaticLogout.Text = "";
                    dpAccessPlanDateFrom.Value = DateTime.MinValue;
                    dpAccessPlanDateTo.Value = DateTime.MinValue;
                }
                BindTransponders(Convert.ToInt64(cmbIDNr.Value));
            }

        }
        protected void BindTransponders(long persNr)
        {
            var transpondersType1 = new PersonalTransponderViewModels().TransPonders(persNr, 1);
            var transpondersType2 = new PersonalTransponderViewModels().TransPonders(persNr, 2);
            grdTransponders.DataSource = transpondersType1;
            grdTransponders.DataBind();
            //grdfinacialStatement.DataSource = transponders;
            //grdfinacialStatement.DataBind();
            try
            {
                grdTranspondersShortTerm.DataSource = transpondersType2;
                grdTranspondersShortTerm.DataBind();
            }
            catch (Exception)
            { }
        }

        protected void ClearControlsFilter()
        {
            //dpllPersName.SelectedValue = "0";
            //ddlIDNr.SelectedValue = "0";
            //ddlAusweisNr.SelectedValue = "0";
            //ddllLocation.SelectedValue = "0";
            //ddlDepartment.SelectedValue = "0";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtCompany.Text = "";
            txtStreet.Text = "";
            //txtLocation.Text = "";
            txtPersonalNr.Text = "";
            ddlPersType.Value = "0";
            ddlCarType.SelectedValue = "0";
            txtCarRegNo.Text = "";
            //ddlLocations.SelectedValue = "0";
            //ddlDepartments.SelectedValue = "0";
            //ddlCostCenter.SelectedValue = "0";

            cmbLocations.Value = 0;
            cmbDepartments.Value = 0;
            cmbCostCenters.Value = 0;

            txtMemo.Text = "";
            txtAusweisNr.Text = "";
            chkIdentificationActive.Checked = false;
            txtAusweisPincode.Text = "";
            chkPincodeActive.Checked = false;
            txtNurPincode.Text = "";
            chkNurPincodeActive.Checked = false;
            txtSicherheitsPincode.Text = "";
            chkMenaceActive.Checked = false;
            dpAccessPlanDateFrom.Text = "";
            dpAccessPlanDateTo.Text = "";
            txtZuttritsplanNr.Text = "";
            txtZuttritsBezeichnung.Text = "";
            txtAutomaticLogout.Text = "";
            img.Src = "";
            UploadPhoto.Attributes.Clear();
            DoBpicker.Text = "";
            DofEntry.Text = "";
            DofExit.Text = "";
            txtPosition.Text = "";
            txtNationality.Text = "";
            txtCompTel.Text = "";
            txtCompMobile.Text = "";
            txtPrivTel.Text = "";
            txtPrivMobile.Text = "";
            txtCompanyEmail.Text = "";
            txtPrivateEmail.Text = "";

        }

        protected void grdTransponders_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            List<ASPxDataUpdateValues> updateValues = e.UpdateValues;
            long persNr = 0;
            Int64.TryParse(Convert.ToString(cmbPersName.Value), out persNr);

            if (persNr > 0)
            {
                SaveTransponders(updateValues, 1, persNr);

                e.Handled = true;

                var transpondersType1 = new PersonalTransponderViewModels().TransPonders(persNr, 1);

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

        protected void grdTranspondersShortTerm_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            List<ASPxDataUpdateValues> updateValues = e.UpdateValues;
            long persNr = 0;
            Int64.TryParse(Convert.ToString(cmbPersName.Value), out persNr);

            if (persNr > 0)
            {
                SaveTransponders(updateValues, 2, persNr);

                e.Handled = true;

                var transpondersType2 = new PersonalTransponderViewModels().TransPonders(persNr, 2);

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

        private void SaveTransponders(List<ASPxDataUpdateValues> updateValues, int transponderType, long persNr)
        {
            Pers_Transponders pers_Transponder = new Pers_Transponders();
            PersTranspondersRepository persTranspondersRepository = new PersTranspondersRepository();
            List<Pers_Transponders> pers_TranspondersList = persTranspondersRepository.GetPersonnelTransponders(persNr) ?? new List<Pers_Transponders>();

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
                    if (pers_TranspondersList.Any(x => x.ID == transponderID))
                    {
                        pers_Transponder = pers_TranspondersList.FirstOrDefault(x => x.ID == transponderID);
                        if (oldExtendedTo != extendedTo)
                        {
                            pers_Transponder.TransponderStatus = false; persTranspondersRepository.EditPersTransponder(pers_Transponder);
                            actionNr = pers_Transponder.Action ?? 1;
                            transponderID = 0;
                            pers_Transponder = new Pers_Transponders();
                        }
                    }
                }
                else
                {
                    pers_Transponder = new Pers_Transponders();
                    actionNr = pers_Transponder.Action ?? 1;
                }

                pers_Transponder.Action = oldExtendedTo != extendedTo ? actionNr + 1 : actionNr;
                if (extendedTo != DateTime.MinValue) pers_Transponder.ExtendedTo = extendedTo;
                pers_Transponder.Memo = memo;
                pers_Transponder.PersNr = persNr;
                if (deactivationDate != DateTime.MinValue) pers_Transponder.TransponderDeactivatedOn = deactivationDate;
                pers_Transponder.TransponderNr = transponderNr;
                pers_Transponder.TransponderStatus = transponderActive;
                if (validFrom != DateTime.MinValue) pers_Transponder.ValidFrom = validFrom;
                if (validTo != DateTime.MinValue) pers_Transponder.ValidTo = validTo;
                pers_Transponder.TransponderType = transponderType;

                if (transponderID > 0)
                {
                    persTranspondersRepository.EditPersTransponder(pers_Transponder);
                }
                else
                {
                    if (pers_Transponder.TransponderNr > 0) persTranspondersRepository.AddPersTransponder(pers_Transponder);
                }
            }
            persTranspondersRepository.SavePersTransponder();
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
        public static void SavePersAccessGroups(long Pers_Nr, string updateString)
        {
            //PersAccessGroupsRepository persAccessGroupsRepository = new PersAccessGroupsRepository();
            PersAccessGroupsViewModel persAccessGroupsViewModel = new PersAccessGroupsViewModel();
            List<Pers_AccessGroups> dbPersAccessGroups = persAccessGroupsViewModel.GetPersAccessGroups(Pers_Nr);
            List<PersAccessGroupsDto> persAccessGroups = new List<PersAccessGroupsDto>();

            try
            {
                persAccessGroups = JsonConvert.DeserializeObject<List<PersAccessGroupsDto>>(updateString);
            }
            catch (Exception) { }

            foreach (PersAccessGroupsDto persAccessGroup in persAccessGroups)
            {
                if (persAccessGroup.OldGroupID > 0 && persAccessGroup.GroupID > 0 && persAccessGroup.ID > 0)
                {
                    Pers_AccessGroups dbPersAccessGroup = dbPersAccessGroups.FirstOrDefault(p => p.GroupID == persAccessGroup.OldGroupID &&
                                                                                p.ID == persAccessGroup.ID) ?? new Pers_AccessGroups();

                    dbPersAccessGroup.GroupID = persAccessGroup.GroupID;
                    dbPersAccessGroup.StartDate = persAccessGroup.StartDate;
                    dbPersAccessGroup.EndDate = persAccessGroup.EndDate;
                    dbPersAccessGroup.Active = persAccessGroup.Active;

                    persAccessGroupsViewModel.EditPersAccessGroup(dbPersAccessGroup);
                }
                else if (persAccessGroup.OldGroupID > 0 && persAccessGroup.GroupID == 0)
                {
                    Pers_AccessGroups dbPersAccessGroup = dbPersAccessGroups.FirstOrDefault(p => p.GroupID == persAccessGroup.OldGroupID &&
                                                                                p.ID == persAccessGroup.ID) ?? new Pers_AccessGroups();
                    //Delete
                    persAccessGroupsViewModel.DeletePersAccessGroup(dbPersAccessGroup);
                }
                else if (persAccessGroup.GroupID > 0)
                {
                    Pers_AccessGroups dbPersAccessGroup = new Pers_AccessGroups();

                    dbPersAccessGroup.Pers_Nr = Pers_Nr;
                    dbPersAccessGroup.GroupID = persAccessGroup.GroupID;
                    dbPersAccessGroup.StartDate = persAccessGroup.StartDate;
                    dbPersAccessGroup.EndDate = persAccessGroup.EndDate;
                    dbPersAccessGroup.Active = persAccessGroup.Active;

                    persAccessGroupsViewModel.AddPersAccessGroup(dbPersAccessGroup);
                }
            }

            persAccessGroupsViewModel.SavePersAccessGroup();
        }

        [WebMethod]
        public static bool DeletePersonalDetails(long Nr)
        {
            var isDeleted = false;
            var personal = new PersonnelRepository().GetPersonnelByPersNumber(Nr);
            PersImageRepository _persPassportRepository = new PersImageRepository();
            if (personal != null)
            {
                var _personal = personal;
                // new PersonnelRepository().DeletePersonnel(personal);
                var pPhoto = _persPassportRepository.GetPersonnalPhotoByPers_Nr(personal.Pers_Nr);
                if (pPhoto != null)
                {
                    FileProcessor.DeleteImageFile(pPhoto.Pers_Passport, FileProcessor.PersPhotosFolder);
                    _persPassportRepository.DeletePersonnalPhoto(pPhoto);
                }
                new PersonnelRepository().DeletePersonnel(personal);
                isDeleted = true;
            }
            return isDeleted;

        }

        [WebMethod]
        public static int DeleteCard(long id, long persNr, int type)
        {
            var persCard = new PersTranspondersRepository().GetTransponderById(id);

            if (persCard != null)
            {
                var cardList = new PersTranspondersRepository().GetPersonnelTransponders(persNr, persCard.TransponderNr);
                foreach (var card in cardList)
                {
                    new PersTranspondersRepository().DeletePersTransponder(card);
                }

            }
            return type;
        }

        [WebMethod]
        public static bool DeletePersonal(long persNumber)
        {
            PersonnelRepository persRep = new PersonnelRepository();
            PersImageRepository _persPassportRepository = new PersImageRepository();

            var person = persRep.GetPersonnelByPersNumber(persNumber);
            if (person != null)
            {
                var pPhoto = _persPassportRepository.GetPersonnalPhotoByPers_Nr(persNumber);
                if (pPhoto != null)
                {
                    FileProcessor.DeleteImageFile(pPhoto.Pers_Passport, FileProcessor.PersPhotosFolder);
                }
                new PersonnelRepository().DeletePersonnel(person);
            }
            return persRep.GetPersonnelByPersNumber(persNumber) == null;

        }


        [System.Web.Services.WebMethod]
        public static new string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        void LoadClientsGrid()
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            var ClientsList = _ClientsRepository.GetClients();
            grdClients.DataSource = ClientsList;
            grdClients.DataBind();

            if (ClientsList.Count <= 18)
            {
                grdClients.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                grdClients.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }

        }
        protected void bindPersonalData()
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            var persDataList = _VwPersonnelDataRepository.GetAllPersonnel().Distinct().ToList().OrderBy(x => x.Pers_Nr);
            grdPersData.DataSource = persDataList;
            grdPersData.DataBind();
        }
        protected void LoadPersType()
        {
            var persTypes = new PersonTypeRepository().GetAllPersonTypes();
            grdPersType.DataSource = persTypes;
            grdPersType.DataBind();
            grdPersType.FocusedRowIndex = -1;
        }

        protected void btnPERSDOC_Click(object sender, EventArgs e)
        {
            try
            {
                long personalNumber = 0;
                string persNr = cmbIDNr.Value.ToString();
                string Pers_Name = txtLastName.Text.Trim();
                string persFirstName = txtFirstName.Text.Trim();
                string personalDocumentsRedirect = string.Empty;

                long.TryParse(persNr, out personalNumber);

                if (personalNumber == 0)
                {
                    personalDocumentsRedirect = string.Format("/Content/PersonalDocumente.aspx?{0}={1}&{2}={3}", PERSONAL_QUERY_PARAM_KEY, 0, PAGE_ORIGIN_QUERY_PARAM_KEY, PERSONAL_PAGE_ORIGIN);
                    Session["indexField"] = "12345";
                    Response.Redirect(personalDocumentsRedirect);
                }
                EncryptionCtl encryption = new EncryptionCtl();

                //string personalNumberEncrypted = encryption.Encrypt(personalNumber.ToString());
                if (hiddenFieldSaveChanges.Value == "1")
                {
                    return;
                    //  ClientScript.RegisterStartupScript(GetType(), "DocumentButtonConfirm", "DocumentButtonConfirm();", true);
                }
                else
                {
                    personalDocumentsRedirect = string.Format("/Content/PersonalDocumente.aspx?{0}={1}&{2}={3}", PERSONAL_QUERY_PARAM_KEY, personalNumber, PAGE_ORIGIN_QUERY_PARAM_KEY, PERSONAL_PAGE_ORIGIN);
                    Session["indexField"] = "12345";
                    Response.Redirect(personalDocumentsRedirect);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [WebMethod]
        public static void GetCompanyNo(string _CompanyNo)
        {
            CompanyNo = _CompanyNo;
        }
        [WebMethod]
        public static void InsertClient(string ClientID, string Client_Nr, string ClientName)
        {

            if (Client_Nr != "" && ClientName != "")
            {
                int i;
                if (int.TryParse(Client_Nr, out i) == true)
                {
                    ClientsRepository _ClientsRepository = new ClientsRepository();
                    var _client = _ClientsRepository.GetClientsById(Convert.ToInt32(ClientID));
                    var _clientByNr = _ClientsRepository.GetClientsByNr(Convert.ToInt32(Client_Nr));
                    if (_clientByNr != null) { ClientID = _clientByNr.ID.ToString(); }
                    if (_clientByNr == null)
                    {
                        Client _Client = new Client() { Client_Nr = Convert.ToInt32(Client_Nr), Name = ClientName };
                        _ClientsRepository.NewClient(_Client);
                    }
                    else
                    {
                        _client = _ClientsRepository.GetClientsById(Convert.ToInt32(ClientID));

                        if (ClientID == "0") { return; }
                        Client ClientLs = new Client()
                        {
                            ID = _client.ID,
                            Client_Nr = Convert.ToInt64(Client_Nr),
                            Name = ClientName,

                        };
                        _client = ClientLs;
                        new ClientsRepository().EditClient(_client);

                        //if (ClientID == "0") { return; }
                        //_client.Client_Nr = Convert.ToInt32(Client_Nr);
                        //_client.Name = ClientName;
                        //_ClientsRepository.EditClient(_client);
                    }
                }
            }

        }


        [WebMethod]
        public static Client GetClientsById(int Id)
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            Client _Client = new Client();
            var clientInfo = _ClientsRepository.GetClientsById(Id);

            if (clientInfo == null)
            {
                return _Client;
            }

            if (clientInfo != null)
            {
                _Client.ID = clientInfo.ID;
                _Client.Client_Nr = clientInfo.Client_Nr;
                _Client.Name = clientInfo.Name;

            }

            return _Client;
        }

        protected void grdClients_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadClientsGrid();
        }

        protected void dplCompanyName_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadDropDownKeine();
        }

        protected void grdTransponderInactiveHist_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            long persNr = 0, transponderNr = 0;
            Dictionary<string, string> paramsDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Parameters);

            foreach (KeyValuePair<string, string> param in paramsDict)
            {
                if (param.Key == "persNr") Int64.TryParse(param.Value, out persNr);
                if (param.Key == "transponderNr") Int64.TryParse(param.Value, out transponderNr);
            }

            if (persNr >= 0)
            {
                var transpondersHist = new PersonalTransponderViewModels().TransPondersExtensions(persNr, transponderNr);

                try
                {
                    grdTransponderInactiveHist.DataSource = transpondersHist;
                    grdTransponderInactiveHist.DataBind();
                }
                catch (Exception)
                { }
            }
        }

        protected void grdPersType_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadPersType();
        }

        protected void grdChangePlan_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            //TextBox txtZuttritsplanNr = (TextBox)((FormView)fvPersonnel).Row.FindControl("txtZuttritsplanNr");
            //TextBox txtZuttritsBezeichnung = (TextBox)((FormView)fvPersonnel).Row.FindControl("txtZuttritsBezeichnung");
            TbAccessPlan _tbAccessPlan = new TbAccessPlan();
            PersonnelAccessPlanDto dto = new PersonnelAccessPlanDto();
            //  {"PersID":"10020","PlanNo":"1","PlanDescription":"Zutrittspläne 1"}   This is the sample json string in e.parameters

            try
            {
                dto = JsonConvert.DeserializeObject<PersonnelAccessPlanDto>(e.Parameters);
                txtZuttritsplanNr.Text = dto.PlanNo.ToString();
                txtZuttritsBezeichnung.Text = dto.PlanDescription;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void grdTransponders_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            long persNr = 0;
            Int64.TryParse(e.Parameters, out persNr);

            if (persNr >= 0)
            {
                var transpondersType1 = new PersonalTransponderViewModels().TransPonders(persNr, 1);

                try
                {
                    grdTransponders.DataSource = transpondersType1;
                    grdTransponders.DataBind();
                }
                catch (Exception)
                { }
            }
        }

        protected void grdTranspondersShortTerm_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            long persNr = 0;
            Int64.TryParse(e.Parameters, out persNr);

            if (persNr >= 0)
            {
                var transpondersType2 = new PersonalTransponderViewModels().TransPonders(persNr, 2);

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
            long persNr = 0;
            Int64.TryParse(e.Parameters, out persNr);

            if (persNr >= 0)
            {
                LoadgrdAccessGroups(persNr);
            }
        }

        protected void ddlPersType_Callback(object sender, CallbackEventArgsBase e)
        {
            LoadPersonTypes();
        }

        [WebMethod]
        public static string DeletePersType(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var persType = new PersonTypeRepository().GetPersonTypeById(Convert.ToInt64(id));
                if (persType != null)
                {
                    new PersonTypeRepository().DeletePersType(persType);
                }
            }
            return id;

        }

        //protected void cmbPersAccessGroup_Init(object sender, CallbackEventArgsBase e)
        //{
        //    ASPxComboBox _sender = (ASPxComboBox)sender;
        //    List<TbAccessPlanGroup> PersAccessGroups = new List<TbAccessPlanGroup>();
        //    PersAccessGroups.Add(new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" });

        //    if (HttpContext.Current.Session["Pers_PersAccessGroups"] != null)
        //    {
        //        List<TbAccessPlanGroup> persAccessGroups = new List<TbAccessPlanGroup>();
        //        persAccessGroups = (List<TbAccessPlanGroup>)HttpContext.Current.Session["Pers_PersAccessGroups"];
        //        PersAccessGroups.AddRange(persAccessGroups);
        //    }
        //    _sender.DataSource = PersAccessGroups;
        //}

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

        protected void cboPersonNameSearch_OnItemsRequestedByFilterCondition(object sender, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            if (PersonnelList.Count == 0) PersonnelList = personalViewModel.GetAllActivePersonnel();
            ASPxComboBox _cboPersOnNameSearch = (ASPxComboBox)sender;
            List<PersonnelDto> _PersonnelList = new List<PersonnelDto>();

            if (!String.IsNullOrEmpty(e.Filter))
            {
                List<PersonnelDto> _PersonnelListFName = PersonnelList.Where(x => (x.FirstName ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<PersonnelDto>();
                List<PersonnelDto> _PersonnelListLName = PersonnelList.Where(x => (x.LastName ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<PersonnelDto>();
                List<PersonnelDto> _PersonnelListPersNr = PersonnelList.Where(x => (x.Pers_Nr.ToString() ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<PersonnelDto>();

                List<PersonnelDto> _PersonnelListFilter = new List<PersonnelDto>();
                _PersonnelListFilter.AddRange(_PersonnelListFName);
                _PersonnelListFilter.AddRange(_PersonnelListLName);
                _PersonnelListFilter.AddRange(_PersonnelListPersNr);
                _PersonnelList.AddRange(_PersonnelListFilter.Distinct().ToList());
            }
            else
            {
                _PersonnelList.AddRange(PersonnelList);
            }

            _cboPersOnNameSearch.DataSource = _PersonnelList;
            _cboPersOnNameSearch.DataBind();
        }
        protected void cboPersonNameSearch_OnItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            PersonnelDto personnel = personalViewModel.GetPersonnelByPersNr(value);
            List<PersonnelDto> personnelList = new List<PersonnelDto>();

            if (personnel != null)
            {
                personnelList.Add(personnel);
                comboBox.DataSource = personnelList;
                comboBox.DataBind();
            }
        }

        protected void grdPersType_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.Name.Trim() == "TypeColor")
            {
                var colorValue = e.GetValue("PersTypeColor");
                if (colorValue != null)
                {
                    if (colorValue.GetType() == typeof(string))
                    {
                        string rowColor = (string)colorValue;
                        e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml(rowColor);
                    }
                }
            }

        }
    }
}