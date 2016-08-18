using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using System.Web.Services;
using System.Globalization;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;

namespace Access_Control_NewMask.Content
{
    public partial class GatePersonalDocument : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        private const string PERSONAL_QUERY_PARAM_KEY = "0F88";
        private const string PAGE_ORIGIN_QUERY_PARAM_KEY = "4ED8";
        private const string PERSONAL_PAGE_ORIGIN = "7E30B049";
        private static long Deleteperson = 0;

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
                btnEntSave.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                _loadPersonalDocumentDetails();
                hiddenFieldType.Value = "1";
            }
        }

        private void _loadPersonalDocumentDetails()
        {
            PersonalDocumentsViewModel personalDataViewModel = new PersonalDocumentsViewModel();
            long personalNumber = 0;
            EncryptionCtl encryption = new EncryptionCtl();

            if (Request.Params[PERSONAL_QUERY_PARAM_KEY] == null)
            {
                Session.Remove("PageOrigin");
                Session.Remove(PERSONAL_QUERY_PARAM_KEY);
                return;
            }

            string personalNumberDecrypted = Request.Params[PERSONAL_QUERY_PARAM_KEY];
            if (personalNumberDecrypted != null)
            {
                long.TryParse(personalNumberDecrypted, out personalNumber);
                Deleteperson = personalNumber;

            }
            var personalDocumentsDTO = personalDataViewModel.GetPersonalDocumentData(personalNumber);

            if (personalDocumentsDTO.PersonalNumber == 0)
            {
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

            txtIDIssuedOn.Text = personalDocumentsDTO.IDDateOfIssuestr.ToString();
            txtPPIssuedOn.Text = personalDocumentsDTO.PPDateOfIssuestr.ToString();
            txtDLIssuedOn.Text = personalDocumentsDTO.DLDateOfIssuestr.ToString();

            //dtIDDateOfBirth.Value = personalDocumentsDTO.DateofBirth;
            //dtPPDateOfBirth.Value = personalDocumentsDTO.DateofBirth;
            //dtDLDateOfBirth.Value = personalDocumentsDTO.DateofBirth;
            //dtHIDateOfBirth.Value = personalDocumentsDTO.DateofBirth;

            txtIDDateOfBirth.Text = personalDocumentsDTO.DateOfBirthFormated.ToString();
            txtPPDateOfBirth.Text = personalDocumentsDTO.DateOfBirthFormated.ToString();
            txtDLDateOfBirth.Text = personalDocumentsDTO.DateOfBirthFormated.ToString();
            txtHIDateOfBirth.Text = personalDocumentsDTO.DateOfBirthFormated.ToString();

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
                        redirectURL = string.Format("GatePersonal.aspx?{0}={1}", PERSONAL_QUERY_PARAM_KEY, personalNumberEncrypted);
                        break;
                    default:
                        redirectURL = "/Index.aspx";
                        break;
                }
            }
            else
            {
                redirectURL = "/Index.aspx";
            }


            return redirectURL;
        }

        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
    }
}