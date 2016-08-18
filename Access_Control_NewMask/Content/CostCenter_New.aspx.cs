using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using DevExpress.Web;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Controllers;
using System.Web.Services;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class CostCenter_New : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("CC_PMode");
            }
            set
            {
                HttpContext.Current.Session["CC_PMode"] = value;
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.CostCenters, out _AccessControlPermissionMode))
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

            BindSelectionControls();
        }
        void BindSelectionControls()
        {
            CostCenter _CostCenter = new CostCenter()
            {
                ID = 0,
                CostCenter_Nr = 0,
                Name = "Keine",
            };

            var CostCenters = new CostCenterRepository().GetCostCenters();

            List<CostCenter> CostCentersList = new List<CostCenter>();
            CostCentersList.Add(_CostCenter);
            CostCentersList.AddRange(CostCenters);

            cboCostCnterNr.DataSource = CostCentersList;
            cboCostCnterNr.DataBind();

            cboCostCenterName.DataSource = CostCentersList;
            cboCostCenterName.DataBind();

            grdCostcenter.DataSource = CostCenters;
            grdCostcenter.DataBind();
            grdCostcenter.FocusedRowIndex = -1;

            if (CostCenters.Count() <= 22)
            {
                grdCostcenter.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                grdCostcenter.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }
        }

        protected void LoadDepartmentsById(int Id)
        {
            var CostCenters = new CostCenterRepository().GetCostCenterById(Id);
            if (CostCenters != null)
            {
                cboCostCnterNr.Value = CostCenters.ID.ToString();
                cboCostCenterName.Value = CostCenters.ID.ToString();

                if (CostCenters.CostCenter_Nr != 0) { txtcostcntrno.Text = CostCenters.CostCenter_Nr.ToString(); } else { txtcostcntrno.Text = ""; };
                if (CostCenters.Name != null) { txtCostCenterName.Text = CostCenters.Name.ToString(); } else { txtCostCenterName.Text = ""; };
                if (CostCenters.ZipCode != null) { txtPLZ.Text = CostCenters.ZipCode.ToString(); } else { txtPLZ.Text = ""; };
                if (CostCenters.State != null) { txtOrt.Text = CostCenters.State.ToString(); } else { txtOrt.Text = ""; };
                if (CostCenters.Street != null) { txtStreet.Text = CostCenters.Street.ToString(); } else { txtStreet.Text = ""; };
                if (CostCenters.HouseNumber != null) { txthseNumber.Text = CostCenters.HouseNumber.ToString(); } else { txthseNumber.Text = ""; };

                if (CostCenters.LocationHeadName != null) { txtName.Text = CostCenters.LocationHeadName.ToString(); } else { txtName.Text = ""; };
                if (CostCenters.LocationHeadFunction != null) { txtFunct.Text = CostCenters.LocationHeadFunction.ToString(); } else { txtFunct.Text = ""; };
                if (CostCenters.LocationHeadPhone != null) { txtTel.Text = CostCenters.LocationHeadPhone.ToString(); } else { txtTel.Text = ""; };
                if (CostCenters.LocationHeadMobile != null) { txtMob.Text = CostCenters.LocationHeadMobile.ToString(); } else { txtMob.Text = ""; };
                if (CostCenters.LocationHeadEmail != null) { txtEmail.Text = CostCenters.LocationHeadEmail.ToString(); } else { txtEmail.Text = ""; };

                if (CostCenters.InfoText != null) { txtMemo.Text = CostCenters.InfoText.ToString(); } else { txtMemo.Text = ""; };
            }
            else
            {
                txtcostcntrno.Text = "";
                txtCostCenterName.Text = "";
                txtStreet.Text = "";
                txtOrt.Text = "";
                txtPLZ.Text = "";
                txtMob.Text = "";
                txtName.Text = "";
                txthseNumber.Text = "";
                txtFunct.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";
                txtMemo.Text = "";
            }
        }

        protected void EnablesControl()
        {
            cboCostCnterNr.Enabled = true;
            cboCostCenterName.Enabled = true;
            btnDelete.Enabled = true;

        }
        protected void clearControls()
        {
            //setting next department no and clearing texboxes
            NextCompanyNr();

            cboCostCnterNr.SelectedIndex = 0;
            cboCostCenterName.SelectedIndex = 0;

            cboCostCnterNr.Enabled = false;
            cboCostCenterName.Enabled = false;

            txtCostCenterName.Text = "";
            txtStreet.Text = "";
            txtOrt.Text = "";
            txtPLZ.Text = "";
            txtMob.Text = "";
            txtName.Text = "";
            txthseNumber.Text = "";
            txtFunct.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtMemo.Text = "";
        }

        protected void NextCompanyNr()
        {
            int costCenterNr = 0;
            var costCenters = new CostCenterRepository().GetCostCenters();
            if (costCenters.Count() > 0)
            {
                costCenterNr = Convert.ToInt32(costCenters.Max(i => i.CostCenter_Nr));
            }
            else
            {
                costCenterNr = 0;
            }
            int nextNr = costCenterNr + 1;
            txtcostcntrno.Text = nextNr.ToString();
            txtCostCenterName.Focus();
            saveChangesonNew.Value = "1";
        }


        protected void SaveCostCenter()
        {
            CostCenterRepository _CostCenters = new CostCenterRepository();
            CostCenter _CostCenter = new CostCenter();
            if (txtcostcntrno.Text == "" || txtcostcntrno.Text == null)
            {
                return;

            }
            var costCenterList = _CostCenters.GetCostCenters();
            var costExist = costCenterList.FirstOrDefault(x => x.CostCenter_Nr == Convert.ToInt32(txtcostcntrno.Text));

            if (costExist != null)
            {
                costExist.CostCenter_Nr = Convert.ToInt32(txtcostcntrno.Text);
                costExist.Name = txtCostCenterName.Text;
                costExist.ZipCode = txtPLZ.Text;
                costExist.State = txtOrt.Text;
                costExist.Street = txtStreet.Text;
                costExist.HouseNumber = txthseNumber.Text;

                costExist.LocationHeadName = txtName.Text;
                costExist.LocationHeadFunction = txtFunct.Text;
                costExist.LocationHeadPhone = txtTel.Text;
                costExist.LocationHeadMobile = txtMob.Text;
                costExist.LocationHeadEmail = txtEmail.Text;

                costExist.InfoText = txtMemo.Text;

                _CostCenters.EditCostCenter(costExist);
                mainCtl.RedirectToPromptPage();
                BindSelectionControls();
                LoadDepartmentsById(Convert.ToInt32(costExist.ID));

            }
            else
            {
                if (txtcostcntrno.Text == "" || txtcostcntrno.Text == null)
                {
                    return;

                }
                else {
                    _CostCenter.CostCenter_Nr = Convert.ToInt32(txtcostcntrno.Text);
                }

                _CostCenter.CostCenter_Nr = Convert.ToInt32(txtcostcntrno.Text);
                _CostCenter.Name = txtCostCenterName.Text;
                _CostCenter.ZipCode = txtPLZ.Text;
                _CostCenter.State = txtOrt.Text;
                _CostCenter.Street = txtStreet.Text;
                _CostCenter.HouseNumber = txthseNumber.Text;

                _CostCenter.LocationHeadName = txtName.Text;
                _CostCenter.LocationHeadFunction = txtFunct.Text;
                _CostCenter.LocationHeadPhone = txtTel.Text;
                _CostCenter.LocationHeadMobile = txtMob.Text;
                _CostCenter.LocationHeadEmail = txtEmail.Text;

                _CostCenter.InfoText = txtMemo.Text;


                _CostCenters.NewCostCenters(_CostCenter);
                BindSelectionControls();
                LoadDepartmentsById(Convert.ToInt32(_CostCenter.ID));

            }
            EnablesControl();
            mainCtl.RedirectToPromptPage();
        }
        protected void DeleteCostCenter(int Id)
        {
            var costCenterId = new CostCenterRepository().GetCostCenterById(Id);

            if (costCenterId != null)
            {
                new CostCenterRepository().DeleteCostCenter(costCenterId);
            }

            LoadDepartmentsById(Convert.ToInt32(cboCostCnterNr.Value));
            BindSelectionControls();
            cboCostCnterNr.SelectedIndex = 0;
            cboCostCenterName.SelectedIndex = 0;
        }

        [WebMethod]
        public static CostCenter GetCostCenters(long costCId)
        {
            CostCenterRepository _CostCenterRepository = new CostCenterRepository();
            CostCenter _CostCenter = new CostCenter();

            var costCenter = _CostCenterRepository.GetCostCenterById(costCId);
            if (costCenter == null)
            {
                return _CostCenter;
            }
            if (costCenter != null)
            {
                _CostCenter.ID = costCenter.ID;
                _CostCenter.CostCenter_Nr = costCenter.CostCenter_Nr;
                _CostCenter.Name = costCenter.Name;
                _CostCenter.ZipCode = costCenter.ZipCode;
                _CostCenter.State = costCenter.State;
                _CostCenter.Street = costCenter.Street;
                _CostCenter.HouseNumber = costCenter.HouseNumber;

                _CostCenter.LocationHeadName = costCenter.LocationHeadName;
                _CostCenter.LocationHeadFunction = costCenter.LocationHeadFunction;
                _CostCenter.LocationHeadPhone = costCenter.LocationHeadPhone;
                _CostCenter.LocationHeadMobile = costCenter.LocationHeadMobile;
                _CostCenter.LocationHeadEmail = costCenter.LocationHeadEmail;

                _CostCenter.InfoText = costCenter.InfoText;
            }
            return _CostCenter;
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
        public static CostCenter GetCostCenterById(long id)
        {
            var costCenter = new CostCenterRepository().GetCostCenterById(id);
            CostCenter _CostCenter = new CostCenter()
            {

                ID = costCenter.ID,
                CostCenter_Nr = costCenter.CostCenter_Nr,
                Name = costCenter.Name,
                ZipCode = costCenter.ZipCode,
                State = costCenter.State,
                Street = costCenter.Street,
                HouseNumber = costCenter.HouseNumber,

                LocationHeadName = costCenter.LocationHeadName,
                LocationHeadFunction = costCenter.LocationHeadFunction,
                LocationHeadPhone = costCenter.LocationHeadPhone,
                LocationHeadMobile = costCenter.LocationHeadMobile,
                LocationHeadEmail = costCenter.LocationHeadEmail,

                InfoText = costCenter.InfoText,
            };
            return _CostCenter;
        }

        [WebMethod]
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "1";
            clearControls();
            grdCostcenter.FocusedRowIndex = -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "";
            SaveCostCenter();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCostCenter(Convert.ToInt32(cboCostCnterNr.Value));
        }
    }
}