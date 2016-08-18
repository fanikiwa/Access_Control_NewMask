using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Repositories;
using System.Web.Services;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.Content
{
    public partial class RightsSettings : BasePage
    {

        PermissionProfileViewModel permissionsProfileViewModel = new PermissionProfileViewModel();
        PermissionSettingsViewModel permissionSettingsViewModel = new PermissionSettingsViewModel();
        AC_PersPasswords persPassword = new AC_PersPasswords();
        AC_PersProfileMapping persProfileMapping = new AC_PersProfileMapping();
        AC_PersProfileADMapping persProfileADMapping = new AC_PersProfileADMapping();
        ZUTMain mainCtl = new ZUTMain();
        public accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsPasswordProfile_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsPasswordProfile_PMode"] = value;
            }
        }
        //static accessControlPermissionModes accessControlPermissionMode = accessControlPermissionModes.Read;


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsPasswordProfile, out _AccessControlPermissionMode))
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

            bindGrid();
            bindPersonalGrid();

            if (!IsPostBack)
            {
                SetDefaultDrpIndices();
            }

        }
        protected void bindGrid()
        {
            //PermissionProfileRepository _PermissionProfileRepository = new PermissionProfileRepository();
            List<AC_PermissionProfile> permList = new List<AC_PermissionProfile>();
            permList.Add(new AC_PermissionProfile { ID = 0, ProfileDescription = "keine", ProfileNr = 0 });
            permList.AddRange(permissionsProfileViewModel.GetPermissionProfiles());

            cmbRightNr.DataSource = permList;
            cmbRightNr.ValueField = "ID";
            cmbRightNr.TextField = "ProfileNr";
            cmbRightNr.DataBind();

            cmbRightDescription.DataSource = permList;
            cmbRightDescription.ValueField = "ID";
            cmbRightDescription.TextField = "ProfileDescription";
            cmbRightDescription.DataBind();

            permList.RemoveAt(0);

            grdVwRightsNrSearch.DataSource = permList;
            grdVwRightsNrSearch.DataBind();
        }

        protected void bindPersonalGrid()
        {
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            var persList = _VwPersonnelDataRepository.GetAllPersonnel();
            persList = persList.Count > 0 ? persList.Distinct().OrderBy(x => x.Pers_Nr).ToList() : new List<VwPersonnelData>();

            grdVwPersonal.DataSource = persList;
            grdVwPersonal.DataBind();

            persList.Add(new VwPersonnelData()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Pers_Nr = -10000,
                FullName = "Admin"
            });

            cmbPrsNrr.DataSource = persList.Count > 0 ? persList.Distinct().OrderBy(x => x.Pers_Nr).ToList() : new List<VwPersonnelData>(); ;
            cmbPrsNrr.ValueField = "Pers_Nr";
            cmbPrsNrr.TextField = "Pers_Nr";
            cmbPrsNrr.DataBind();

            cmbEmployee.DataSource = persList.Count > 0 ? persList.Distinct().OrderBy(x => x.FirstName).ToList() : new List<VwPersonnelData>();
            cmbEmployee.ValueField = "Pers_Nr";
            cmbEmployee.TextField = "Fullname";
            cmbEmployee.DataBind();


            try
            {
                cmbPrsNrr.Value = cmbEmployee.Value;
            }
            catch (Exception) { }
        }

        protected void SetDefaultDrpIndices()
        {
            if (cmbPrsNrr.Items.Count > 0)
            {
                long persNr = 0;
                Int64.TryParse(Convert.ToString(cmbPrsNrr.Items[0].Value), out persNr);

                try
                {
                    cmbPrsNrr.Items.FindByValue(persNr.ToString()).Selected = true;
                    cmbEmployee.Items.FindByValue(persNr.ToString()).Selected = true;
                }
                catch (Exception) { }
            }

            cmbRightNr.SelectedIndex = 0;
            cmbRightDescription.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Settings.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtNewPass.Text = "";
            txtRepeatPass.Text = "";
            txtNewPass.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string pass1 = txtNewPass.Text.Trim(), pass2 = txtRepeatPass.Text.Trim();
            int persNr = 0;

            if (!int.TryParse(cmbPrsNrr.SelectedItem.Text, out persNr)) persNr = 0;
            if (persNr <= 0 && persNr != -10000) return;

            if (pass1 == pass2 && pass1 != "" && pass2 != "")
            {
                SavePassword(persNr);
            }
            else
            {
                //Console.WriteLine("Not Matched");
            }
            if (persNr != -10000) SavePersProfileMapping(persNr);

            mainCtl.RedirectToPromptPage();

            chkUseAD.Checked = false;
            txtADUsername.Text = "";
            txtADPath.Text = "";
            txtADController.Text = "";
        }

        private void SavePassword(int persNr)
        {
            GetPassword(persNr);
            permissionSettingsViewModel.AddPersPassword(persPassword);
        }

        private void GetPassword(int persNr)
        {
            if (txtNewPass.Text.Trim().Equals("")) return;
            persPassword.Password = txtNewPass.Text.Trim();
            persPassword.Pers_Nr = persNr;
            persPassword.Username = persNr == -10000 ? "admin" : persNr.ToString();
        }

        private void SavePersProfileMapping(int persNr)
        {
            int profileId = 0;
            if (!int.TryParse(Convert.ToString(cmbRightNr.Value), out profileId)) profileId = 0;

            if (chkUseAD.Checked)
            {
                permissionSettingsViewModel.DeletePersProfileADMapping(persNr);

                GetPersProfileADMapping(persNr, profileId);
                permissionSettingsViewModel.AddPersProfileADMapping(persProfileADMapping);
            }
            else
            {
                permissionSettingsViewModel.DeletePersProfileADMapping(persNr);
                if (profileId == 0)
                {
                    permissionSettingsViewModel.DeletePersProfileMapping(persNr);
                }
                else if (profileId > 0)
                {
                    GetPersProfileMapping(persNr, profileId);
                    permissionSettingsViewModel.AddPersProfileMapping(persProfileMapping);
                }
            }
        }

        private void GetPersProfileMapping(int persNr, int profileId)
        {
            persProfileMapping.Pers_Nr = persNr;
            persProfileMapping.ProfileID = profileId;
        }

        private void GetPersProfileADMapping(int persNr, int profileId)
        {
            persProfileADMapping.PersNr = persNr;
            persProfileADMapping.ProfileID = profileId <= 0 ? new int?() : profileId;
            persProfileADMapping.AD_Username = txtADUsername.Text;
            persProfileADMapping.AD_Path = txtADPath.Text;
            persProfileADMapping.AD_Controller = txtADController.Text;
        }

        [WebMethod]
        public static int GetPersProfileMapping(int persNr)
        {
            PermissionSettingsViewModel _permissionSettingsViewModel = new PermissionSettingsViewModel();
            return _permissionSettingsViewModel.GetPermissionProfile(persNr);
        }

        [WebMethod]
        public static PersProfileMappingDto GetPersProfileMappingDto(int persNr)
        {
            PersProfileMappingDto persProfileMappingDto = new PersProfileMappingDto();

            PermissionSettingsViewModel _permissionSettingsViewModel = new PermissionSettingsViewModel();

            AC_PersProfileMapping persProfileMapping = _permissionSettingsViewModel.GetPermissionProfileByPersNr(persNr);
            AC_PersProfileADMapping persProfileADMapping = _permissionSettingsViewModel.GetPermissionProfileADByPersNr(persNr);

            if (persProfileADMapping.ID > 0)
            {
                persProfileMappingDto.ID = persProfileADMapping.ID;
                persProfileMappingDto.ProfileID = persProfileADMapping.ProfileID;
                persProfileMappingDto.UseAD = true;
                persProfileMappingDto.AD_Username = persProfileADMapping.AD_Username;
                persProfileMappingDto.AD_Path = persProfileADMapping.AD_Path;
                persProfileMappingDto.AD_Controller = persProfileADMapping.AD_Controller;
            }
            else
            {
                persProfileMappingDto.ID = persProfileMapping.ID;
                persProfileMappingDto.ProfileID = persProfileMapping.ProfileID;
                persProfileMappingDto.UseAD = false;
            }

            return persProfileMappingDto;
        }

        [WebMethod]
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }
    }
}