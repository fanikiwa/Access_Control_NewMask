using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using DevExpress.Web;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.Content
{
    public partial class VisitorCompany : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("VisitorFirms_PMode");
            }
            set
            {
                HttpContext.Current.Session["VisitorFirms_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.VisitorFirms, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

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
                LoadVisitorCompanyDetails();
                BindControls();
                btnDelete.Enabled = false;
            }
        }
        void BindControls()
        {
            LocationFederalStateRepository _LocationFederalStateRepository = new LocationFederalStateRepository();
            var states = _LocationFederalStateRepository.GetAllLocationFederalStates();

            cboState.DataSource = states;
            cboState.DataBind();

        }
        protected void LoadVisitorCompanyDetails()
        {
            VisitorCompanyTb _VisitorCompany = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "Keine",
            };
            var visitorCompanies = new VisitorCompanyRepository().GetAllVisitorCompanies();


            List<VisitorCompanyTb> visitorCompany = new List<VisitorCompanyTb>();
            visitorCompany.Add(_VisitorCompany);
            visitorCompany.AddRange(visitorCompanies);

            cboClientName.DataSource = visitorCompany;
            cboClientName.DataBind();

            cboCustomerNr.DataSource = visitorCompany;
            cboCustomerNr.DataBind();

            grdVisitorCompany.DataSource = visitorCompanies;
            grdVisitorCompany.DataBind();
            grdVisitorCompany.FocusedRowIndex = -1;

            if (visitorCompanies.Count() <= 24)
            {
                grdVisitorCompany.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                grdVisitorCompany.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }
        }

        protected void LoadVisitorCompanyByID(int id)
        {
            var VC = new VisitorCompanyRepository().GetVisitorCompanyById(id);
            if (VC != null)
            {

                cboClientName.Value = VC.CompanyName.ToString();
                cboCustomerNr.Value = VC.CompanyNr.ToString();
                cboState.Value = VC.FederalState.ToString();

                if (VC.FederalState != null) { cboState.Value = VC.FederalState.ToString(); } else { cboState.Value = "Keine"; };
                if (VC.CompanyNr != 0) { txtClientNr.Text = VC.CompanyNr.ToString(); } else { txtClientNr.Text = ""; };
                if (VC.CompanyName != null) { txtClientName.Text = VC.CompanyName.ToString(); } else { txtClientName.Text = ""; };
                if (VC.Memo != null) { txtMemo.Text = VC.Memo.ToString(); } else { txtMemo.Text = ""; };
                if (VC.Email != null) { txtEmail.Text = VC.Email.ToString(); } else { txtEmail.Text = ""; };
                if (VC.Name != null) { txtName.Text = VC.Name.ToString(); } else { txtName.Text = ""; };
                if (VC.ZipCode != null) { txtPLZ.Text = VC.ZipCode.ToString(); } else { txtPLZ.Text = ""; };
                if (VC.Street != null) { txtStreet.Text = VC.Street.ToString(); } else { txtStreet.Text = ""; };
                if (VC.Telephone != null) { txtTel.Text = VC.Telephone.ToString(); } else { txtTel.Text = ""; };
                if (VC.Mobile != null) { txtMob.Text = VC.Mobile.ToString(); } else { txtMob.Text = ""; };
                if (VC.HouseNr != null) { txtHouseNr.Text = VC.HouseNr.ToString(); } else { txtHouseNr.Text = ""; };
                if (VC.PersFunction != null) { txtFunct.Text = VC.PersFunction.ToString(); } else { txtFunct.Text = ""; };
                if (VC.Place != null) { txtOrt.Text = VC.Place.ToString(); } else { txtOrt.Text = ""; };

            }
            else
            {
                txtClientName.Text = string.Empty;
                txtClientNr.Text = string.Empty;
                txtMemo.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPLZ.Text = string.Empty;
                txtStreet.Text = string.Empty;
                txtTel.Text = string.Empty;
                txtMob.Text = string.Empty;
                txtHouseNr.Text = string.Empty;
                txtFunct.Text = string.Empty;
                txtOrt.Text = string.Empty;
            }
        }

        protected void EnablesControl()
        {
            cboCustomerNr.Enabled = true;
            cboClientName.Enabled = true;
            btnDelete.Enabled = AccessControlPermissionMode == accessControlPermissionModes.Edit ? true : false; ;

        }
        protected void ClearItems()
        {
            txtClientName.Text = string.Empty;
            txtClientNr.Text = string.Empty;
            txtMemo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPLZ.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtMob.Text = string.Empty;
            txtHouseNr.Text = string.Empty;
            txtFunct.Text = string.Empty;
            txtOrt.Text = string.Empty;
            btnDelete.Enabled = false;
        }
        protected void NextCompanyNr()
        {
            int CompanyNr = 0;
            var visitorCompanyDetails = new VisitorCompanyRepository().GetAllVisitorCompanies();
            if (visitorCompanyDetails.Count() > 0)
            {
                CompanyNr = Convert.ToInt32(visitorCompanyDetails.Max(i => i.CompanyNr));
            }
            else
            {
                CompanyNr = 0;
            }
            int nextNr = CompanyNr + 1;
            txtClientNr.Text = nextNr.ToString();
            txtClientName.Focus();
            saveChangesonNew.Value = "1";
        }

        protected void DeleteVisitorCompany(int cid)
        {
            var visitorCompId = new VisitorCompanyRepository().GetVisitorCompanyById(cid);

            if (visitorCompId != null)
            {
                new VisitorCompanyRepository().DeleteVisitorCompany(visitorCompId);
            }

            LoadVisitorCompanyByID(Convert.ToInt32(cboCustomerNr.Value));
            LoadVisitorCompanyDetails();
            cboClientName.SelectedIndex = 0;
            cboCustomerNr.SelectedIndex = 0;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
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
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }

        [WebMethod]
        public static VisitorCompanyTb GetVisitorCompanyById(long id)
        {
            var visiCompany = new VisitorCompanyRepository().GetVisitorCompanyById(id);
            VisitorCompanyTb _visiCompany = new VisitorCompanyTb()
            {
                ID = visiCompany.ID,
                CompanyNr = visiCompany.CompanyNr,
                CompanyName = visiCompany.CompanyName,
                ZipCode = visiCompany.ZipCode,
                HouseNr = visiCompany.HouseNr,
                Place = visiCompany.Place,
                Street = visiCompany.Street,
                FederalState = visiCompany.FederalState,
                Name = visiCompany.Name,
                PersFunction = visiCompany.PersFunction,
                Telephone = visiCompany.Telephone,
                Mobile = visiCompany.Mobile,
                Email = visiCompany.Email,
                Memo = visiCompany.Memo,
            };
            return _visiCompany;
        }

        [WebMethod]
        public static VisitorCompanyTb GetVisitorCompany(long companyId)
        {
            VisitorCompanyRepository _VisitorCompanyRepository = new VisitorCompanyRepository();
            VisitorCompanyTb _VisitorCompany = new VisitorCompanyTb();
            //var companyData = _VisitorCompanyRepository.GetAllVisitorCompanies().Where(x => x.CompanyNr == Convert.ToInt64(companyNr)).FirstOrDefault();
            var companyData = _VisitorCompanyRepository.GetVisitorCompanyById(companyId);
            if (companyData == null)
            {
                return _VisitorCompany;
            }

            if (companyData != null)
            {
                _VisitorCompany.ID = companyData.ID;
                _VisitorCompany.CompanyNr = companyData.CompanyNr;
                _VisitorCompany.CompanyName = companyData.CompanyName;
                _VisitorCompany.ZipCode = companyData.ZipCode;
                _VisitorCompany.HouseNr = companyData.HouseNr;
                _VisitorCompany.Place = companyData.Place;
                _VisitorCompany.Street = companyData.Street;
                _VisitorCompany.FederalState = companyData.FederalState;
                _VisitorCompany.Name = companyData.Name;
                _VisitorCompany.PersFunction = companyData.PersFunction;

                _VisitorCompany.Telephone = companyData.Telephone;
                _VisitorCompany.Mobile = companyData.Mobile;
                _VisitorCompany.Email = companyData.Email;
                _VisitorCompany.Memo = companyData.Memo;

            }
            return _VisitorCompany;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            cboCustomerNr.Value = 0;
            cboClientName.Value = 0;
            btnDelete.Enabled = AccessControlPermissionMode == accessControlPermissionModes.Edit ? true : false; ;
            cboCustomerNr.Enabled = false;
            cboClientName.Enabled = false;

            ClearItems();
            NextCompanyNr();
            saveChangesonNew.Value = "1";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "";
            VisitorCompanyRepository _VisitorComp = new VisitorCompanyRepository();
            VisitorCompanyTb companyDetails = new VisitorCompanyTb();

            var companylist = _VisitorComp.GetAllVisitorCompanies();
            var companyExist = companylist.FirstOrDefault(x => x.CompanyNr == Convert.ToInt32(txtClientNr.Text));

            if (companyExist != null)
            {
                companyExist.CompanyNr = Convert.ToInt32(txtClientNr.Text);
                companyExist.CompanyName = txtClientName.Text;
                companyExist.ZipCode = txtPLZ.Text;
                companyExist.Place = txtOrt.Text;
                companyExist.Name = txtName.Text;
                companyExist.Street = txtStreet.Text;
                companyExist.Telephone = txtTel.Text;
                companyExist.Mobile = txtMob.Text;
                companyExist.Memo = txtMemo.Text;
                companyExist.HouseNr = txtHouseNr.Text;
                companyExist.FederalState = Convert.ToInt64(cboState.Value);
                companyExist.PersFunction = txtFunct.Text;
                companyExist.Email = txtEmail.Text;

                _VisitorComp.EditVisitorCompany(companyExist);
                mainCtl.RedirectToPromptPage();
                LoadVisitorCompanyDetails();
                LoadVisitorCompanyByID(Convert.ToInt32(companyExist.ID));

            }
            else
            {
                if (txtClientNr.Text == "" || txtClientNr.Text == null)
                {
                    return;

                }
                else {
                    companyDetails.CompanyNr = Convert.ToInt32(txtClientNr.Text);
                }

                companyDetails.CompanyName = txtClientName.Text;
                companyDetails.ZipCode = txtPLZ.Text;
                companyDetails.Place = txtOrt.Text;
                companyDetails.Name = txtName.Text;
                companyDetails.Street = txtStreet.Text;
                companyDetails.Telephone = txtTel.Text;
                companyDetails.Mobile = txtMob.Text;
                companyDetails.Memo = txtMemo.Text;
                companyDetails.HouseNr = txtHouseNr.Text;
                companyDetails.FederalState = Convert.ToInt64(cboState.Value);
                companyDetails.PersFunction = txtFunct.Text;
                companyDetails.Email = txtEmail.Text;

                _VisitorComp.NewVisitorCompany(companyDetails);
                LoadVisitorCompanyDetails();
                LoadVisitorCompanyByID(Convert.ToInt32(companyDetails.ID));

            }
            EnablesControl();
            mainCtl.RedirectToPromptPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteVisitorCompany(Convert.ToInt32(cboCustomerNr.Value));
        }

        protected void grdVisitorCompany_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //if (!string.IsNullOrEmpty(e.Parameters))
            //{
            //    var ID = e.Parameters;
            //    if (ID == "-1")
            //    {
            //        grdVisitorCompany.FocusedRowIndex = -1;
            //    }
            //    else
            //    {

            //        int row = grdVisitorCompany.FindVisibleIndexByKeyValue(ID);
            //        grdVisitorCompany.FocusedRowIndex = Convert.ToInt32(row);
            //    }

            //}
            LoadVisitorCompanyDetails();
        }

        protected void cboCustomerNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            VisitorCompanyTb _VisitorCompany = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "Keine",
            };
            var visitorCompanies = new VisitorCompanyRepository().GetAllVisitorCompanies();

            List<VisitorCompanyTb> visitorCompany = new List<VisitorCompanyTb>();
            visitorCompany.Add(_VisitorCompany);
            visitorCompany.AddRange(visitorCompanies);
            cboCustomerNr.DataSource = visitorCompany;
            cboCustomerNr.DataBind();
        }

        protected void cboClientName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            VisitorCompanyTb _VisitorCompany = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "Keine",
            };
            var visitorCompanies = new VisitorCompanyRepository().GetAllVisitorCompanies();

            List<VisitorCompanyTb> visitorCompany = new List<VisitorCompanyTb>();
            visitorCompany.Add(_VisitorCompany);
            visitorCompany.AddRange(visitorCompanies);
            cboClientName.DataSource = visitorCompany;
            cboClientName.DataBind();
        }
    }
}