using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using System.Globalization;
using System.Web.Services;
using KruAll.Core.Repositories;
using KruAll.Core.Models;

namespace Access_Control_NewMask.Content
{
    public partial class PersonalDocumenteInactive : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        private const string PERSONAL_QUERY_PARAM_KEY = "0F88";
        private const string PAGE_ORIGIN_QUERY_PARAM_KEY = "4ED8";
        private const string PERSONAL_PAGE_ORIGIN = "7E30B049";
        private static long Deleteperson = 0;

        string culture;
        static CultureInfo cultureInfo;
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("PersInactive_PMode");
            }
            set
            {
                HttpContext.Current.Session["PersInactive_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.PersInactive, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnEntSave.Enabled = false; btnNew.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;

            if (!IsPostBack)
            {
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);
            }

            if (IsPostBack == false)
            {
                _loadPersonalDocumentDetails();
                hiddenFieldType.Value = "1";
            }
        }
        private void _loadPersonalDocumentDetails()
        {
            //"PersonalDocumente.aspx?PersNr={0}&Name={1}&FirstName={2}"
            PersonalDocumentsViewModel personalDataViewModel = new PersonalDocumentsViewModel();
            long personalNumber = 0;
            EncryptionCtl encryption = new EncryptionCtl();

            if (Request.Params[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                Session.Remove("PageOrigin");
                Session.Remove(PERSONAL_QUERY_PARAM_KEY);
                hiddenFieldPersonalNumber.Value = "0";
                return;
            }

            string personalNumberDecrypted = Request.Params[PERSONAL_QUERY_PARAM_KEY];
            //string personalNumberDecrypted = encryption.Decrypt(Request.Params[PERSONAL_QUERY_PARAM_KEY]);

            long.TryParse(personalNumberDecrypted, out personalNumber);
            Deleteperson = personalNumber;

            var personalDocumentsDTO = personalDataViewModel.GetPersonalDocumentInactiveData(personalNumber);

            if (personalDocumentsDTO.PersonalNumber == 0)
            {
                hiddenFieldPersonalNumber.Value = "0";
                return;
            }

            if (Request.Params[PAGE_ORIGIN_QUERY_PARAM_KEY] != null)
            {
                Session.Add("PageOrigin", Request.Params[PAGE_ORIGIN_QUERY_PARAM_KEY]);
            }

            Session.Add(PERSONAL_QUERY_PARAM_KEY, personalDocumentsDTO.PersonalNumber);

            hiddenFieldPersonalNumber.Value = personalDocumentsDTO.PersonalNumber.ToString();

            txtIDName.Text = personalDocumentsDTO.Name;
            txtPPName.Text = personalDocumentsDTO.Name;
            txtDLName.Text = personalDocumentsDTO.Name;
            txtHIName.Text = personalDocumentsDTO.Name;

            txtIDFirstName.Text = personalDocumentsDTO.FirstName;
            txtPPFirstName.Text = personalDocumentsDTO.FirstName;
            txtDLFirstName.Text = personalDocumentsDTO.FirstName;
            txtHIFirstName.Text = personalDocumentsDTO.FirstName;

            dtIDDateOfBirth.Value = personalDocumentsDTO.DateofBirth;
            dtPPDateOfBirth.Value = personalDocumentsDTO.DateofBirth;
            dtDLDateOfBirth.Value = personalDocumentsDTO.DateofBirth;
            dtHIDateOfBirth.Value = personalDocumentsDTO.DateofBirth;

            txtIDNationality.Text = personalDocumentsDTO.Nationality;
            txtPPNationality.Text = personalDocumentsDTO.Nationality;

            txtIDPlaceofBirth.Text = personalDocumentsDTO.PlaceOfBirth;
            txtPPPlaceofBirth.Text = personalDocumentsDTO.PlaceOfBirth;
            txtDLPlaceofBirth.Text = personalDocumentsDTO.PlaceOfBirth;

            txtIDEyeColor.Text = personalDocumentsDTO.EyeColor;
            txtPPEyeColor.Text = personalDocumentsDTO.EyeColor;

            txtIDSize.Text = personalDocumentsDTO.Height;
            txtPPSize.Text = personalDocumentsDTO.Height;

            txtIDPlaceofBirth.Text = personalDocumentsDTO.PlaceOfBirth;
            txtPPPlaceofBirth.Text = personalDocumentsDTO.PlaceOfBirth;
            txtDLPlaceofBirth.Text = personalDocumentsDTO.PlaceOfBirth;

            txtIDCreatedIn.Text = personalDocumentsDTO.IDCreatedIn;
            txtIDNumber.Text = personalDocumentsDTO.IDNumber;
            txtIDAdditionalNumber.Text = personalDocumentsDTO.IDAdditionalNumber;
            dtIDIssuedOn.Value = personalDocumentsDTO.IDDateOfIssue;
            dtIDExpiryDate.Value = personalDocumentsDTO.IDExpiryDate;
            txtIDAddress.Text = personalDocumentsDTO.IDAddress;
            txtIDIssuingAuthority.Text = personalDocumentsDTO.IDIssuingAuthority;
            txtIDMemo.Text = personalDocumentsDTO.IDMemo;

            txtPPCreatedIn.Text = personalDocumentsDTO.PPCreatedIn;
            txtPPNumber.Text = personalDocumentsDTO.PPNumber;
            txtPPGender.Text = personalDocumentsDTO.PPGender;
            dtPPIssuedOn.Value = personalDocumentsDTO.PPDateOfIssue;
            dtPPExpiryDate.Value = personalDocumentsDTO.PPExpiryDate;
            txtPPIssuingAuthority.Text = personalDocumentsDTO.PPIssuingAuthority;
            txtPPMemo.Text = personalDocumentsDTO.PPMemo;

            txtDLCreatedIn.Text = personalDocumentsDTO.DLCreatedIn;
            txtDLNumber.Text = personalDocumentsDTO.DLNumber;
            dtDLIssuedOn.Value = personalDocumentsDTO.DLDateOfIssue;
            txtDLClass.Text = personalDocumentsDTO.DLClass;
            txtDLIssuingAuthority.Text = personalDocumentsDTO.DLIssuingAuthority;
            txtDLMemo.Text = personalDocumentsDTO.DLMemo;


            txtHIBoxOffice.Text = personalDocumentsDTO.HCBoxNumber;
            txtHICreatedIn.Text = personalDocumentsDTO.HCCreatedIn;
            txtHIPersonalNumber.Text = personalDocumentsDTO.HCItemNumber;
            txtHISecurityNumber.Text = personalDocumentsDTO.HCSecurityNumber;
            txtHICardNumber.Text = personalDocumentsDTO.HCCardNumber;
            dtHIExpirationDate.Value = personalDocumentsDTO.HCExpiryDate;
            txtHIMemo.Text = personalDocumentsDTO.HCMemo;


        }



        private void _updatepersonalDocumentsInDatabase()
        {

            hiddenFieldSaveChanges.Value = "0";
            if (Session[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                return;
            }

            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();
            PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();

            personalDocumentsDTO.PersonalNumber = Convert.ToInt64(Session[PERSONAL_QUERY_PARAM_KEY]);
            personalDocumentsDTO.Name = txtIDName.Text;
            personalDocumentsDTO.FirstName = txtIDFirstName.Text;
            personalDocumentsDTO.DateofBirth = Convert.ToDateTime(dtIDDateOfBirth.Value);
            personalDocumentsDTO.Nationality = txtIDNationality.Text;
            personalDocumentsDTO.PlaceOfBirth = txtIDPlaceofBirth.Text;
            personalDocumentsDTO.EyeColor = txtIDEyeColor.Text;
            personalDocumentsDTO.Height = txtIDSize.Text;

            personalDocumentsDTO.IDCreatedIn = txtIDCreatedIn.Text;
            personalDocumentsDTO.IDNumber = txtIDNumber.Text;
            personalDocumentsDTO.IDAdditionalNumber = txtIDAdditionalNumber.Text;
            personalDocumentsDTO.IDDateOfIssue = Convert.ToDateTime(dtIDIssuedOn.Value);
            personalDocumentsDTO.IDExpiryDate = Convert.ToDateTime(dtIDExpiryDate.Value);
            personalDocumentsDTO.IDAddress = txtIDAddress.Text;
            personalDocumentsDTO.IDIssuingAuthority = txtIDIssuingAuthority.Text;
            personalDocumentsDTO.IDMemo = txtIDMemo.Text;

            personalDocumentsDTO.PPCreatedIn = txtPPCreatedIn.Text;
            personalDocumentsDTO.PPNumber = txtPPNumber.Text;
            personalDocumentsDTO.PPGender = txtPPGender.Text;
            personalDocumentsDTO.PPDateOfIssue = Convert.ToDateTime(dtPPIssuedOn.Value);
            personalDocumentsDTO.PPExpiryDate = Convert.ToDateTime(dtPPExpiryDate.Value);
            personalDocumentsDTO.PPIssuingAuthority = txtPPIssuingAuthority.Text;
            personalDocumentsDTO.PPMemo = txtPPMemo.Text;

            personalDocumentsDTO.DLCreatedIn = txtDLCreatedIn.Text;
            personalDocumentsDTO.DLNumber = txtDLNumber.Text;
            personalDocumentsDTO.DLDateOfIssue = Convert.ToDateTime(dtDLIssuedOn.Value);
            personalDocumentsDTO.DLClass = txtDLClass.Text;
            personalDocumentsDTO.DLIssuingAuthority = txtDLIssuingAuthority.Text;
            personalDocumentsDTO.DLMemo = txtDLMemo.Text;


            personalDocumentsDTO.HCBoxNumber = txtHIBoxOffice.Text;
            personalDocumentsDTO.HCCreatedIn = txtHICreatedIn.Text;
            personalDocumentsDTO.HCItemNumber = txtHIPersonalNumber.Text;
            personalDocumentsDTO.HCSecurityNumber = txtHISecurityNumber.Text;
            personalDocumentsDTO.HCCardNumber = txtHICardNumber.Text;
            personalDocumentsDTO.HCExpiryDate = Convert.ToDateTime(dtHIExpirationDate.Value);
            personalDocumentsDTO.HCMemo = txtHIMemo.Text;

            personalDocumentsView.UpdatePersonalDocumentData(personalDocumentsDTO);
        }

        private void _DeleteIdentityCardInDatabase()
        {

            if (Session[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                return;
            }


            PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();
            var personalDocumentsDTOinfor = personalDocumentsView.GetPersonalDocumentData(Deleteperson);
            if (personalDocumentsDTOinfor.PersonalNumber == 0)
            {
                return;
            }
            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();
            //PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();

            personalDocumentsDTO.PersonalNumber = Convert.ToInt64(Session[PERSONAL_QUERY_PARAM_KEY]);
            personalDocumentsDTO.Name = personalDocumentsDTOinfor.Name;
            personalDocumentsDTO.FirstName = personalDocumentsDTOinfor.FirstName;
            personalDocumentsDTO.DateofBirth = personalDocumentsDTOinfor.DateofBirth;
            personalDocumentsDTO.Nationality = personalDocumentsDTOinfor.Nationality;
            personalDocumentsDTO.PlaceOfBirth = personalDocumentsDTOinfor.PlaceofBirth;
            personalDocumentsDTO.EyeColor = personalDocumentsDTOinfor.EyeColor;
            personalDocumentsDTO.Height = personalDocumentsDTOinfor.Height;

            personalDocumentsDTO.IDCreatedIn = "";
            personalDocumentsDTO.IDNumber = "";
            personalDocumentsDTO.IDAdditionalNumber = "";
            personalDocumentsDTO.IDDateOfIssue = null;
            personalDocumentsDTO.IDExpiryDate = null;
            personalDocumentsDTO.IDAddress = "";
            personalDocumentsDTO.IDIssuingAuthority = "";
            personalDocumentsDTO.IDMemo = "";

            txtIDCreatedIn.Text = "";
            txtIDNumber.Text = "";
            txtIDAdditionalNumber.Text = "";
            dtIDIssuedOn.Text = "";
            dtIDExpiryDate.Text = "";
            txtIDAddress.Text = "";
            txtIDIssuingAuthority.Text = "";
            txtIDMemo.Text = "";
            txtIDPlaceofBirth.Text = "";

            personalDocumentsDTO.PPCreatedIn = personalDocumentsDTOinfor.PPCreatedIn;
            personalDocumentsDTO.PPNumber = personalDocumentsDTOinfor.PPNumber;
            personalDocumentsDTO.PPGender = personalDocumentsDTOinfor.PPGender;
            personalDocumentsDTO.PPDateOfIssue = personalDocumentsDTOinfor.PPDateOfIssue;
            personalDocumentsDTO.PPExpiryDate = personalDocumentsDTOinfor.PPExpiryDate;
            personalDocumentsDTO.PPIssuingAuthority = personalDocumentsDTOinfor.PPIssuingAuthority;
            personalDocumentsDTO.PPMemo = personalDocumentsDTOinfor.PPMemo;

            personalDocumentsDTO.DLCreatedIn = personalDocumentsDTOinfor.DLCreatedIn;
            personalDocumentsDTO.DLNumber = personalDocumentsDTOinfor.DLNumber;
            personalDocumentsDTO.DLDateOfIssue = personalDocumentsDTOinfor.DLDateOfIssue;
            personalDocumentsDTO.DLClass = personalDocumentsDTOinfor.DLClass;
            personalDocumentsDTO.DLIssuingAuthority = personalDocumentsDTOinfor.DLIssuingAuthority;
            personalDocumentsDTO.DLMemo = personalDocumentsDTOinfor.DLMemo;


            personalDocumentsDTO.HCBoxNumber = personalDocumentsDTOinfor.HCBoxNumber;
            personalDocumentsDTO.HCCreatedIn = personalDocumentsDTOinfor.HCCreatedIn;
            personalDocumentsDTO.HCItemNumber = personalDocumentsDTOinfor.HCItemNumber;
            personalDocumentsDTO.HCSecurityNumber = personalDocumentsDTOinfor.HCSecurityNumber;
            personalDocumentsDTO.HCCardNumber = personalDocumentsDTOinfor.HCCardNumber;
            personalDocumentsDTO.HCExpiryDate = personalDocumentsDTOinfor.HCExpiryDate;
            personalDocumentsDTO.HCMemo = personalDocumentsDTOinfor.HCMemo;

            personalDocumentsView.UpdatePersonalDocumentData(personalDocumentsDTO);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
          "setTimeout(function() { Identification();}, 500);", true);
        }

        private void _DeletePassportCardInDatabase()
        {

            if (Session[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                return;
            }


            PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();
            var personalDocumentsDTOinfor = personalDocumentsView.GetPersonalDocumentData(Deleteperson);
            if (personalDocumentsDTOinfor.PersonalNumber == 0)
            {
                return;
            }

            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();
            //PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();

            personalDocumentsDTO.PersonalNumber = Convert.ToInt64(Session[PERSONAL_QUERY_PARAM_KEY]);
            personalDocumentsDTO.Name = personalDocumentsDTOinfor.Name;
            personalDocumentsDTO.FirstName = personalDocumentsDTOinfor.FirstName;
            personalDocumentsDTO.DateofBirth = personalDocumentsDTOinfor.DateofBirth;
            personalDocumentsDTO.Nationality = personalDocumentsDTOinfor.Nationality;
            personalDocumentsDTO.PlaceOfBirth = personalDocumentsDTOinfor.PlaceofBirth;
            personalDocumentsDTO.EyeColor = personalDocumentsDTOinfor.EyeColor;
            personalDocumentsDTO.Height = personalDocumentsDTOinfor.Height;

            personalDocumentsDTO.IDCreatedIn = personalDocumentsDTOinfor.IDCreatedIn;
            personalDocumentsDTO.IDNumber = personalDocumentsDTOinfor.IDNumber;
            personalDocumentsDTO.IDAdditionalNumber = personalDocumentsDTOinfor.IDAdditionalNumber;
            personalDocumentsDTO.IDDateOfIssue = personalDocumentsDTOinfor.IDDateOfIssue;
            personalDocumentsDTO.IDExpiryDate = personalDocumentsDTOinfor.IDExpiryDate;
            personalDocumentsDTO.IDAddress = personalDocumentsDTOinfor.IDAddress;
            personalDocumentsDTO.IDIssuingAuthority = personalDocumentsDTOinfor.IDIssuingAuthority;
            personalDocumentsDTO.IDMemo = personalDocumentsDTOinfor.IDMemo;

            personalDocumentsDTO.PPCreatedIn = "";
            personalDocumentsDTO.PPNumber = "";
            personalDocumentsDTO.PPGender = "";
            personalDocumentsDTO.PPDateOfIssue = null;
            personalDocumentsDTO.PPExpiryDate = null;
            personalDocumentsDTO.PPIssuingAuthority = "";
            personalDocumentsDTO.PPMemo = "";

            txtPPCreatedIn.Text = "";
            txtPPNumber.Text = "";
            txtPPGender.Text = "";
            dtPPIssuedOn.Text = "";
            dtPPExpiryDate.Text = "";
            txtPPIssuingAuthority.Text = "";
            txtPPMemo.Text = "";

            personalDocumentsDTO.DLCreatedIn = personalDocumentsDTOinfor.DLCreatedIn;
            personalDocumentsDTO.DLNumber = personalDocumentsDTOinfor.DLNumber;
            personalDocumentsDTO.DLDateOfIssue = personalDocumentsDTOinfor.DLDateOfIssue;
            personalDocumentsDTO.DLClass = personalDocumentsDTOinfor.DLClass;
            personalDocumentsDTO.DLIssuingAuthority = personalDocumentsDTOinfor.DLIssuingAuthority;
            personalDocumentsDTO.DLMemo = personalDocumentsDTOinfor.DLMemo;


            personalDocumentsDTO.HCBoxNumber = personalDocumentsDTOinfor.HCBoxNumber;
            personalDocumentsDTO.HCCreatedIn = personalDocumentsDTOinfor.HCCreatedIn;
            personalDocumentsDTO.HCItemNumber = personalDocumentsDTOinfor.HCItemNumber;
            personalDocumentsDTO.HCSecurityNumber = personalDocumentsDTOinfor.HCSecurityNumber;
            personalDocumentsDTO.HCCardNumber = personalDocumentsDTOinfor.HCCardNumber;
            personalDocumentsDTO.HCExpiryDate = personalDocumentsDTOinfor.HCExpiryDate;
            personalDocumentsDTO.HCMemo = personalDocumentsDTOinfor.HCMemo;

            personalDocumentsView.UpdatePersonalDocumentData(personalDocumentsDTO);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
        "setTimeout(function() {  DisplayPassport();}, 500);", true);
        }

        private void _DeleteDrivingLicenseInDatabase()
        {
            if (Session[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                return;
            }

            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();
            //PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();

            PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();
            var personalDocumentsDTOinfor = personalDocumentsView.GetPersonalDocumentData(Deleteperson);
            if (personalDocumentsDTOinfor.PersonalNumber == 0)
            {
                return;
            }
            personalDocumentsDTO.PersonalNumber = Convert.ToInt64(Session[PERSONAL_QUERY_PARAM_KEY]);
            personalDocumentsDTO.Name = personalDocumentsDTOinfor.Name;
            personalDocumentsDTO.FirstName = personalDocumentsDTOinfor.FirstName;
            personalDocumentsDTO.DateofBirth = personalDocumentsDTOinfor.DateofBirth;
            personalDocumentsDTO.Nationality = personalDocumentsDTOinfor.Nationality;
            personalDocumentsDTO.PlaceOfBirth = personalDocumentsDTOinfor.PlaceofBirth;
            personalDocumentsDTO.EyeColor = personalDocumentsDTOinfor.EyeColor;
            personalDocumentsDTO.Height = personalDocumentsDTOinfor.Height;

            personalDocumentsDTO.IDCreatedIn = personalDocumentsDTOinfor.IDCreatedIn;
            personalDocumentsDTO.IDNumber = personalDocumentsDTOinfor.IDNumber;
            personalDocumentsDTO.IDAdditionalNumber = personalDocumentsDTOinfor.IDAdditionalNumber;
            personalDocumentsDTO.IDDateOfIssue = personalDocumentsDTOinfor.IDDateOfIssue;
            personalDocumentsDTO.IDExpiryDate = personalDocumentsDTOinfor.IDExpiryDate;
            personalDocumentsDTO.IDAddress = personalDocumentsDTOinfor.IDAddress;
            personalDocumentsDTO.IDIssuingAuthority = personalDocumentsDTOinfor.IDIssuingAuthority;
            personalDocumentsDTO.IDMemo = personalDocumentsDTOinfor.IDMemo;

            personalDocumentsDTO.PPCreatedIn = personalDocumentsDTOinfor.PPCreatedIn;
            personalDocumentsDTO.PPNumber = personalDocumentsDTOinfor.PPNumber;
            personalDocumentsDTO.PPGender = personalDocumentsDTOinfor.PPGender;
            personalDocumentsDTO.PPDateOfIssue = personalDocumentsDTOinfor.PPDateOfIssue;
            personalDocumentsDTO.PPExpiryDate = personalDocumentsDTOinfor.PPExpiryDate;
            personalDocumentsDTO.PPIssuingAuthority = personalDocumentsDTOinfor.PPIssuingAuthority;
            personalDocumentsDTO.PPMemo = personalDocumentsDTOinfor.PPMemo;

            personalDocumentsDTO.DLCreatedIn = "";
            personalDocumentsDTO.DLNumber = "";
            personalDocumentsDTO.DLDateOfIssue = null;
            personalDocumentsDTO.DLClass = "";
            personalDocumentsDTO.DLIssuingAuthority = "";
            personalDocumentsDTO.DLMemo = "";

            txtDLCreatedIn.Text = "";
            txtDLNumber.Text = "";
            dtDLIssuedOn.Text = "";
            txtDLClass.Text = "";
            txtDLIssuingAuthority.Text = "";
            txtDLMemo.Text = "";

            personalDocumentsDTO.HCBoxNumber = personalDocumentsDTOinfor.HCBoxNumber;
            personalDocumentsDTO.HCCreatedIn = personalDocumentsDTOinfor.HCCreatedIn;
            personalDocumentsDTO.HCItemNumber = personalDocumentsDTOinfor.HCItemNumber;
            personalDocumentsDTO.HCSecurityNumber = personalDocumentsDTOinfor.HCSecurityNumber;
            personalDocumentsDTO.HCCardNumber = personalDocumentsDTOinfor.HCCardNumber;
            personalDocumentsDTO.HCExpiryDate = personalDocumentsDTOinfor.HCExpiryDate;
            personalDocumentsDTO.HCMemo = personalDocumentsDTOinfor.HCMemo;

            personalDocumentsView.UpdatePersonalDocumentData(personalDocumentsDTO);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
         "setTimeout(function() { DisplayLicence();}, 500);", true);
        }

        private void _DeleteHealthCardInDatabase()
        {
            if (Session[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                return;
            }

            PersonalDocumentsViewModel personalDocumentsView = new PersonalDocumentsViewModel();
            var personalDocumentsDTOinfor = personalDocumentsView.GetPersonalDocumentData(Deleteperson);
            if (personalDocumentsDTOinfor.PersonalNumber == 0)
            {
                return;
            }


            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();


            personalDocumentsDTO.PersonalNumber = Convert.ToInt64(Session[PERSONAL_QUERY_PARAM_KEY]);
            personalDocumentsDTO.Name = personalDocumentsDTOinfor.Name;
            personalDocumentsDTO.FirstName = personalDocumentsDTOinfor.FirstName;
            personalDocumentsDTO.DateofBirth = personalDocumentsDTOinfor.DateofBirth;
            personalDocumentsDTO.Nationality = personalDocumentsDTOinfor.Nationality;
            personalDocumentsDTO.PlaceOfBirth = personalDocumentsDTOinfor.PlaceofBirth;
            personalDocumentsDTO.EyeColor = personalDocumentsDTOinfor.EyeColor;
            personalDocumentsDTO.Height = personalDocumentsDTOinfor.Height;

            personalDocumentsDTO.IDCreatedIn = personalDocumentsDTOinfor.IDCreatedIn;
            personalDocumentsDTO.IDNumber = personalDocumentsDTOinfor.IDNumber;
            personalDocumentsDTO.IDAdditionalNumber = personalDocumentsDTOinfor.IDAdditionalNumber;
            personalDocumentsDTO.IDDateOfIssue = personalDocumentsDTOinfor.IDDateOfIssue;
            personalDocumentsDTO.IDExpiryDate = personalDocumentsDTOinfor.IDExpiryDate;
            personalDocumentsDTO.IDAddress = personalDocumentsDTOinfor.IDAddress;
            personalDocumentsDTO.IDIssuingAuthority = personalDocumentsDTOinfor.IDIssuingAuthority;
            personalDocumentsDTO.IDMemo = personalDocumentsDTOinfor.IDMemo;

            personalDocumentsDTO.PPCreatedIn = personalDocumentsDTOinfor.PPCreatedIn;
            personalDocumentsDTO.PPNumber = personalDocumentsDTOinfor.PPNumber;
            personalDocumentsDTO.PPGender = personalDocumentsDTOinfor.PPGender;
            personalDocumentsDTO.PPDateOfIssue = personalDocumentsDTOinfor.PPDateOfIssue;
            personalDocumentsDTO.PPExpiryDate = personalDocumentsDTOinfor.PPExpiryDate;
            personalDocumentsDTO.PPIssuingAuthority = personalDocumentsDTOinfor.PPIssuingAuthority;
            personalDocumentsDTO.PPMemo = personalDocumentsDTOinfor.PPMemo;

            personalDocumentsDTO.DLCreatedIn = personalDocumentsDTOinfor.DLCreatedIn;
            personalDocumentsDTO.DLNumber = personalDocumentsDTOinfor.DLNumber;
            personalDocumentsDTO.DLDateOfIssue = personalDocumentsDTOinfor.DLDateOfIssue;
            personalDocumentsDTO.DLClass = personalDocumentsDTOinfor.DLClass;
            personalDocumentsDTO.DLIssuingAuthority = personalDocumentsDTOinfor.DLIssuingAuthority;
            personalDocumentsDTO.DLMemo = personalDocumentsDTOinfor.DLMemo;

            personalDocumentsDTO.HCBoxNumber = "";
            personalDocumentsDTO.HCCreatedIn = "";
            personalDocumentsDTO.HCItemNumber = "";
            personalDocumentsDTO.HCSecurityNumber = "";
            personalDocumentsDTO.HCCardNumber = "";
            personalDocumentsDTO.HCExpiryDate = null;
            personalDocumentsDTO.HCMemo = "";

            txtHIBoxOffice.Text = "";
            txtHICreatedIn.Text = "";
            txtHIPersonalNumber.Text = "";
            txtHISecurityNumber.Text = "";
            txtHICardNumber.Text = "";
            dtHIExpirationDate.Text = "";
            txtHIMemo.Text = "";
            txtDLPlaceofBirth.Text = "";

            personalDocumentsView.UpdatePersonalDocumentData(personalDocumentsDTO);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
          "setTimeout(function() {DisplayGuest();}, 500);", true);
        }

        [System.Web.Services.WebMethod]
        public static new string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        [WebMethod]
        public static string GetRedirectURL()
        {
            string redirectURL = string.Empty;
            EncryptionCtl encryption = new EncryptionCtl();



            if (HttpContext.Current.Session["PageOrigin"] != null)
            {
                switch (HttpContext.Current.Session["PageOrigin"].ToString())
                {
                    case PERSONAL_PAGE_ORIGIN:
                        string personalNumberEncrypted = encryption.Encrypt(HttpContext.Current.Session[PERSONAL_QUERY_PARAM_KEY].ToString());
                        redirectURL = string.Format("PersonalInactive.aspx?{0}={1}", PERSONAL_QUERY_PARAM_KEY, personalNumberEncrypted);
                        break;
                    default:
                        redirectURL = "/Dashboard_Main.aspx";
                        break;
                }
            }
            else
            {
                redirectURL = "/Dashboard_Main.aspx";
            }


            return redirectURL;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string redirectURL = string.Empty;
            EncryptionCtl encryption = new EncryptionCtl();

            if (Session["PageOrigin"] != null)
            {
                switch (Session["PageOrigin"].ToString())
                {
                    case PERSONAL_PAGE_ORIGIN:
                        string personalNumberEncrypted = encryption.Encrypt(Session[PERSONAL_QUERY_PARAM_KEY].ToString());
                        redirectURL = string.Format("PersonalInactive.aspx?{0}={1}", PERSONAL_QUERY_PARAM_KEY, personalNumberEncrypted);
                        break;
                    case "7E30B050":
                        redirectURL = "PersonalFormInactive.aspx?PersIDNr=" + Session[PERSONAL_QUERY_PARAM_KEY].ToString();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                redirectURL = "/Index.aspx";
            }

            Response.Redirect(redirectURL);
        }

        protected void btnEntSave_Click(object sender, EventArgs e)
        {
            _updatepersonalDocumentsInDatabase();
            var docType = hiddenFieldType.Value;

            switch (Convert.ToInt32(docType))
            {
                case 1:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
             "setTimeout(function() {  Identification();}, 500);", true);
                    break;
                case 2:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
           "setTimeout(function() {  DisplayPassport();}, 500);", true);
                    break;
                case 3:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
          "setTimeout(function() { DisplayLicence();}, 500);", true);
                    break;
                case 4:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
          "setTimeout(function() {DisplayGuest();}, 500);", true);
                    break;
            }

            if (hiddenFieldRedirectAfterSave.Value == "1")
            {
                hiddenFieldRedirectAfterSave.Value = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Redirect",
    "setTimeout(function (ev) { "
    + "var rediretString = 'PersonalInactive.aspx?0F88=' + $('#hiddenFieldPersonalNumber').attr('value'); "
    + "        window.location.href = rediretString; "
    + " }, 1000); ", true);
            }
        }

        protected void btnCancelDel_Click(object sender, EventArgs e)
        {
            var tvpe = hiddenFieldType.Value;
            switch (Convert.ToInt32(tvpe))
            {
                case 1:
                    _DeleteIdentityCardInDatabase();
                    break;
                case 2:
                    _DeletePassportCardInDatabase();
                    break;
                case 3:
                    _DeleteDrivingLicenseInDatabase();
                    break;
                case 4:
                    _DeleteHealthCardInDatabase();
                    break;

            }
        }


        [WebMethod]
        public static void DeleteIdentityCard(long persNr)
        {
            var card = new PersonalDocumentRepository().GetPersonalIdentityCard(persNr);
            if (card != null)
            {
                new PersonalDocumentRepository().DeleteIdentityCard(card);
            }
        }

        [WebMethod]
        public static void DeletePassport(long persNr)
        {
            var passport = new PersonalDocumentRepository().GetPersonalPassport(persNr);
            if (passport != null)
            {
                new PersonalDocumentRepository().DeletePersonalPassport(passport);
            }
        }

        [WebMethod]
        public static void DeleteLicence(long persNr)
        {
            var licence = new PersonalDocumentRepository().GetPersonalDrivingLicense(persNr);
            if (licence != null)
            {
                new PersonalDocumentRepository().DeleteDrivingLicense(licence);
            }
        }

        [WebMethod]
        public static void DeleteHealthCard(long persNr)
        {
            var healthCard = new PersonalDocumentRepository().GetPersonalHealthInsurance(persNr);
            if (healthCard != null)
            {
                new PersonalDocumentRepository().DeleteHealthInsurance(healthCard);
            }
        }
    }
}