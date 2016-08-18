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
using System.Globalization;
using System.Web.Services;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class PersonalForm : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        private const string PERSONAL_QUERY_PARAM_KEY = "0F88";
        private const string PAGE_ORIGIN_QUERY_PARAM_KEY = "4ED8";
        private const string PERSONAL_PAGE_ORIGIN = "7E30B050";

        string culture;
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

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.PersActive, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnNew.Enabled = false; btnDelete.Enabled = false;

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
            }

            if (IsPostBack != true)
            {
                BindClients();
                bindPersonalData();
            }
        }

        protected void BindClients()
        {
            var clients = new ClientsRepository().GetClients().OrderBy(x => x.Client_Nr).ToList();
            Client _Client = new Client() { ID = 0, Client_Nr = 0, Name = "Keine" };
            clients.Insert(0, _Client);
            dplClients.DataSource = clients;
            dplClients.DataBind();

            dplClientsName.DataSource = clients;
            dplClientsName.DataBind();
            BindLocation();
        }
        protected void bindPersonalData()
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            var persDataList = _VwPersonnelDataRepository.GetAllPersonnel().Distinct().ToList().OrderBy(x => x.Pers_Nr);

            grdPersData.DataSource = persDataList;
            grdPersData.DataBind();

            if (persDataList.Count() <= 23)
            {
                grdPersData.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                grdPersData.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }

        }
        public void BindLocation()
        {
            LocationRepository _LocationRepository = new LocationRepository();
            var locList = _LocationRepository.GetLocations().Where(x => x.Name != "keine").OrderBy(x => x.Location_Nr).ToList();
            Location _Location = new Location() { ID = 0, Location_Nr = 0, Name = "Keine" };
            locList.Insert(0, _Location);
            dpllLocation.DataSource = locList;
            dpllLocation.DataBind();
            BindDepartments();
        }

        public void BindDepartments()
        {
            DepartmentRepository _DepartmentRepository = new DepartmentRepository();

            var locList = _DepartmentRepository.GetDepartments().Where(x => x.Name != "keine").OrderBy(x => x.Department_Nr).ToList();
            Department _Department = new Department() { ID = 0, Name = "Keine", Department_Nr = 0 };
            locList.Insert(0, _Department);
            dplDepartment.DataSource = locList;
            dplDepartment.DataBind();
            BindPersName();
        }

        public void BindPersName()
        {
            var persFilteredList = new VwPersonnelDataRepository().GetAllPersonnel().Distinct().OrderBy(x => x.Pers_Nr).ToList();
            VwPersonnelData _VwPersonnelData = new VwPersonnelData() { ID = 0, Pers_Nr = 0, Card_Nr = 0, FirstName = "keine", LastName = "keine" };
            persFilteredList.Insert(0, _VwPersonnelData);
            dpllPersName.DataSource = persFilteredList;
            dplIDNr.DataSource = persFilteredList;
            dplAusweisNr.DataSource = persFilteredList;

            dpllPersName.DataBind();
            dplIDNr.DataBind();
            dplAusweisNr.DataBind();


            //PersIDNr

            if (Request.Params["PersIDNr"] != null)
            {
                dpllPersName.Value = Convert.ToInt32(Request.Params["PersIDNr"]);
                dplIDNr.Value = Convert.ToInt32(Request.Params["PersIDNr"]);
                dplAusweisNr.Value = Convert.ToInt32(Request.Params["PersIDNr"]);

                //_bindFieldValues(Convert.ToInt64(Request.Params["PersIDNr"]));
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal.aspx");
        }

        private void _bindFieldValues(long personalNumber)
        {
            PersAdditionalInforViewModel _PersAdditionalInforViewModel = new PersAdditionalInforViewModel();

            PersonalData_DTO personal = _PersAdditionalInforViewModel.GerPers("GetPersByNr", personalNumber);

            if (personal != null)
            {
                txtPersonnelNo.Text = personal.PersonalNumber.ToString();
                txtSalutation.Text = personal.Salutation;
                txtName.Text = personal.LastName;
                txtFirstName.Text = personal.FirstName;
                txtPostalCode.Text = personal.PostalCode;

                txtPlaceOfResidence.Text = personal.PhysicalAddress;
                txtRoad.Text = personal.Street;
                txtPlaceOfBirth.Text = personal.PalceOfBirth;
                txtDateOfBirth.Value = personal.DOB;
                txtGender.Text = personal.Gender;
                txtMaritalStatus.Text = personal.MaritalStatus;
                txtNationality.Text = personal.Nationality;
                txtAdditional.Text = personal.Additonal;
                txtBank.Text = personal.Bankname;
                txtAccountHolder.Text = personal.AccountOwner;
                txtBank.Text = personal.BankCode;
                txtBankAccount.Text = personal.AccountNo;
                txtBic.Text = personal.BIC;
                txtIban.Text = personal.IBAN;
                txtDrivingLicense.Text = personal.DriversLicense;
                txtSince.Value = personal.Since;
                txtChildren.Text = personal.Children;
                txtTaxOffice.Text = personal.TaxOfficee;
                txtTaxClass.Text = personal.TaxClass;
                txtHealthInsurance.Text = personal.HealthInsuarance;
                txtHealthInsuranceNumber.Text = personal.HealthInsuaranceNo;
                txtPensionInsurance.Text = personal.PensionInsuarance;
                txtSozVerseNumber.Text = personal.SozVerzNo;
                txtContract.Text = personal.Contract;
                txtEmployedFrom.Value = personal.EmployedFrom;
                txtEmployedAs.Text = personal.EmployedAs;
                txtLearnedProfession.Text = personal.LearnedOccupation;
                txtEmployed.Text = personal.EmploymentType;
                txtResidencePermit.Text = personal.ResidencePermit;
                txtAuthhorizedBy.Text = personal.AuthorisedBy;
                txtApprovedBy.Text = personal.ApprovedBy;
                txtNumberOfHours.Text = personal.NoOfHours;
                txtContractTerminates.Value = personal.EndOfContract;
                txtElimanatedOn.Value = personal.EliminatedOn;
                txtReason.Text = personal.Reason;
                txtEmploymentReference.Text = personal.CertificateOfEmployment;
                dplClients.Value = personal.ClientID;
                dpllLocation.Value = personal.LocationID;
                dplDepartment.Value = personal.DepartmentID;
            }
        }
        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        [WebMethod]
        public static PersonalData_DTO GetPersByLocationID(long ID)
        {
            PersAdditionalInforViewModel _PersAdditionalInforViewModel = new PersAdditionalInforViewModel();
            return _PersAdditionalInforViewModel.GerPers("GetPersByLocationID", ID);
        }

        [WebMethod]
        public static PersonalData_DTO GetPersByDepartmentID(long ID)
        {
            PersAdditionalInforViewModel _PersAdditionalInforViewModel = new PersAdditionalInforViewModel();
            return _PersAdditionalInforViewModel.GerPers("GetPersByDepartmentID", ID);
        }

        [WebMethod]
        public static PersonalData_DTO GetPersByNr(long ID)
        {
            PersAdditionalInforViewModel _PersAdditionalInforViewModel = new PersAdditionalInforViewModel();
            return _PersAdditionalInforViewModel.GerPers("GetPersByNr", ID);
        }
        [WebMethod]
        public static void SavePersonal(String jsonData, String jsonDynamicData)
        {
            PersAdditionalInforViewModel _PersAdditionalInforViewModel = new PersAdditionalInforViewModel();
            PersonalData_DTO _PersonalData_DTO = null;
            List<PersonalData_DTO> _PersonalData_DTOList = JsonConvert.DeserializeObject<List<PersonalData_DTO>>(jsonData);
            List<PersonalDynamicField_DTO> personalDynamicFields = JsonConvert.DeserializeObject<List<PersonalDynamicField_DTO>>(jsonDynamicData);
            if (_PersonalData_DTOList.Count > 0)
            {
                _PersonalData_DTO = _PersonalData_DTOList[0];
                _PersAdditionalInforViewModel.InsertPersAdditionalInfor(_PersonalData_DTO);
                _PersAdditionalInforViewModel.InsertPersClients(_PersonalData_DTO);
                _PersAdditionalInforViewModel.InsertPersLocation(_PersonalData_DTO);
                _PersAdditionalInforViewModel.InsertDepartment(_PersonalData_DTO);
            }

            if (personalDynamicFields.Count > 0)
            {
                _PersAdditionalInforViewModel.UpdatepersonalDynamicFields(personalDynamicFields);
            }
        }
        [WebMethod]
        public static List<PersonalDynamicField_DTO> GetPersonalDynamicFields(long personalNumber)
        {
            PersAdditionalInforViewModel _PersAdditionalInforViewModel = new PersAdditionalInforViewModel();
            return _PersAdditionalInforViewModel.GetPersonalDynamicFields(personalNumber);
        }
        [WebMethod]
        public static void DeletePers(string PersNo)
        {
            if (PersNo == null) { return; }
            PersonnelRepository _PersonnelRepository = new PersonnelRepository();
            var Pers = _PersonnelRepository.GetPersonnelPersnur(Convert.ToInt32(PersNo));
            if (Pers != null)
            {
                _PersonnelRepository.DeletePersonnel(Pers);

            }
        }

        protected void btnPERSDOC_Click(object sender, EventArgs e)
        {
            try
            {
                long personalNumber = 0;
                string persNr = dplIDNr.Value.ToString();
                string Pers_Name = txtName.Text.Trim();
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
                    ClientScript.RegisterStartupScript(GetType(), "DocumentButtonConfirm", "DocumentButtonConfirm();", true);
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
    }
}