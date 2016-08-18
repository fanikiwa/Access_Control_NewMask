using System;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using System.Collections.Generic;
using Access_Control_NewMask.ViewModels;
using System.Web;
using DevExpress.Web;
using System.Linq;
using System.Web.UI;
using System.Web.Services;

namespace Access_Control_NewMask.Content
{
    public partial class RightsAssignment : BasePage
    {
        #region Page Global Objects
        List<AC_PermissionProfile> PermissionsProfileList = new List<AC_PermissionProfile>();
        List<AC_PermissionMapping> PermissionMappingList = new List<AC_PermissionMapping>();
        PermissionProfileViewModel PermissionsProfileViewModel = new PermissionProfileViewModel();
        PermissionMappingViewModel PermissionMappingViewModel = new PermissionMappingViewModel();
        AC_PermissionProfile PermissionsProfile = new AC_PermissionProfile();
        PermissionDto2 _PermissionDto = new PermissionDto2();
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsRights_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsRights_PMode"] = value;
            }
        }
        public static EditModes EditMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<EditModes>("ZUT_Rights_EditMode");
            }
            set
            {
                HttpContext.Current.Session["ZUT_Rights_EditMode"] = value;
            }
        }

        //public int WorkingProfileNr
        //{
        //    get
        //    {
        //        return ZUTMain.LoadSessionItem<int>("ZUT_Rights_WorkingProfileNr");
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["ZUT_Rights_WorkingProfileNr"] = value;
        //    }
        //}

        public enum EditModes
        {
            New, Edit
        }
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsRights, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnNew.Enabled = false; btnDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            BindDrps();

            if (!IsPostBack)
            {
                EditMode = EditModes.Edit;
                SetDefaultDrpIndices();
                BindPermissions();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

        private void BindPermissions()
        {
            //GetPermissionsProfiles();

            //cmbProfileNr.DataSource = PermissionsProfileList;
            //cmbProfileNr.DataBind();

            //cmbProfileDesc.DataSource = PermissionsProfileList;
            //cmbProfileDesc.DataBind();

            List<AC_PermissionProfile> permissionsProfileList = new List<AC_PermissionProfile>();
            permissionsProfileList.AddRange(PermissionsProfileList);
            permissionsProfileList.RemoveAt(0);
            grdSearchProfiles.DataSource = permissionsProfileList;
            grdSearchProfiles.DataBind();

            //SetWorkingProfileNr();
            SetPermissionsTextControls();
            GetPermissions();
        }

        private void BindDrps()
        {
            GetPermissionsProfiles();

            cmbProfileNr.DataSource = PermissionsProfileList;
            cmbProfileNr.DataBind();

            cmbProfileDesc.DataSource = PermissionsProfileList;
            cmbProfileDesc.DataBind();
        }

        public void SetDefaultDrpIndices()
        {
            cmbProfileNr.SelectedIndex = 0;
            cmbProfileDesc.SelectedIndex = 0;
        }

        private void SetPermissionsTextControls()
        {
            long profileId = 0;
            if (!Int64.TryParse(Convert.ToString(cmbProfileNr.Value), out profileId)) profileId = 0;

            try
            {
                if (cmbProfileNr.SelectedItem == null)
                    cmbProfileNr.Items.FindByValue(profileId.ToString()).Selected = true;
                if (cmbProfileDesc.SelectedItem == null)
                    cmbProfileDesc.Items.FindByValue(profileId.ToString()).Selected = true;
            }
            catch (Exception) { }

            try
            {
                txtProfileNr.Text = cmbProfileNr.SelectedItem.Text;
                txtProfileDesc.Text = cmbProfileDesc.SelectedItem.Text;
            }
            catch (Exception)
            {
                txtProfileNr.Text = "0";
                txtProfileDesc.Text = "keine";
            }
        }

        //private void SetWorkingProfileNr()
        //{
        //    //try
        //    //{
        //    if (WorkingProfileNr == 0) return;
        //    ListEditItem li = new ListEditItem();
        //    li = cmbProfileNr.Items.FindByText(WorkingProfileNr.ToString());
        //    if (li == null) return;
        //    cmbProfileNr.Value = li.Value;
        //    cmbProfileDesc.Value = cmbProfileNr.Value;
        //    //}
        //    //catch (Exception) { }
        //}

        private void ClearPermissionsTextControls()
        {
            txtProfileNr.Text = "";
            txtProfileDesc.Text = "";
        }

        private void SetEditModeControls()
        {
            bool enabledStatus = EditMode.Equals(EditModes.New) ? false : true;
            cmbProfileNr.ClientEnabled = enabledStatus;
            cmbProfileDesc.ClientEnabled = enabledStatus;
            if (EditMode.Equals(EditModes.New))
            {
                SetNextProfileNr();
                cmbProfileNr.Items.Clear();
                cmbProfileDesc.Items.Clear();
            }
            btnNew.Enabled = /*AccessControlPermissionMode == accessControlPermissionModes.Edit ?*/ enabledStatus /*: false*/;
        }

        private void SetNextProfileNr()
        {
            txtProfileNr.Text = PermissionsProfileViewModel.GetNextProfileNr().ToString();
            txtProfileDesc.Focus();
        }

        private void GetPermissionsProfile()
        {
            PermissionsProfile = new AC_PermissionProfile();
            int profileNum = 0, profileId = 0;
            if (EditMode.Equals(EditModes.Edit))
            {
                if (!Int32.TryParse(Convert.ToString(cmbProfileNr.Value), out profileId)) profileId = 0;
                PermissionsProfile.ID = profileId;
            }
            if (!Int32.TryParse(txtProfileNr.Text, out profileNum)) profileNum = 0;
            PermissionsProfile.ProfileNr = profileNum;
            PermissionsProfile.ProfileDescription = txtProfileDesc.Text;

            //WorkingProfileNr = profileNum;

            AllAccessControlGetCheck();
            AllGroupLevelGetCheck();

            AllSettingsGetCheck();
            AllGateMonitorGetCheck();
            AllMasterDataGetCheck();
            AllVisitorMasterGetCheck();
            AllSafetyAndCorrectionsGetCheck();
            AllReportsGetCheck();
            AllCommunicationsGetCheck();

            PermissionsProfile.AC_PermissionMapping = GetPermissionMappingsList(ref PermissionsProfile);
        }

        private void GetPermissionsProfiles()
        {
            PermissionsProfileList = new List<AC_PermissionProfile>();
            PermissionsProfileList.Add(new AC_PermissionProfile { ID = 0, ProfileDescription = "keine", ProfileNr = 0 });
            PermissionsProfileList.AddRange(new PermissionProfileViewModel().GetPermissionProfiles());
            //if (permissionsProfileList.Count.Equals(0))
            //    permissionsProfileList.Add(new AC_PermissionProfile { ID = 0, ProfileDescription = "keine", ProfileNr = 0 });
        }

        private void GetPermissions()
        {
            int profileId = 0;
            if (!int.TryParse(Convert.ToString(cmbProfileNr.Value), out profileId)) profileId = 0;
            //if (profileId.Equals(0)) return;
            if (!profileId.Equals(0)) _PermissionDto = PermissionMappingViewModel.GetPermissions(profileId);
            if (profileId.Equals(0)) _PermissionDto = new PermissionDto2();

            AllAccessControlCheck();
            AllGroupLevelCheck();

            AllSettingsCheck();
            AllGateMonitorCheck();
            AllMasterDataCheck();
            AllVisitorMasterCheck();
            AllSafetyAndCorrectionsCheck();
            AllReportsCheck();
            AllCommunicationsCheck();
        }

        //protected void xx()
        //{
        //    chkTMKRead.Checked = false;
        //    chkTMKEdit.Checked = false;
        //    chkZUTRead.Checked = false;
        //    chkZUTEdit.Checked = false;




        //    chkSettingsRead.Checked = false;
        //    chkSettingsEdit.Checked = false;
        //    //-----
        //    chkPersInactiveRead.Checked = false;
        //    chkPersInactiveEdit.Checked = false;
        //    chkMembersInactiveRead.Checked = false;
        //    chkMembersInactiveEdit.Checked = false;
        //    chkClientsRead.Checked = false;
        //    chkClientsEdit.Checked = false;
        //    chkLocationsRead.Checked = false;
        //    chkLocationsEdit.Checked = false;
        //    chkDepartmentsRead.Checked = false;
        //    chkDepartmentsEdit.Checked = false;
        //    chkCostCentersRead.Checked = false;
        //    chkCostCentersEdit.Checked = false;
        //    chkVisitorFirmsRead.Checked = false;
        //    chkVisitorFirmsEdit.Checked = false;
        //    chkVehiclesRead.Checked = false;
        //    chkVehiclesEdit.Checked = false;
        //    chkMembersGroupsRead.Checked = false;
        //    chkMembersGroupsEdit.Checked = false;
        //    chkMembersContractsRead.Checked = false;
        //    chkMembersContractsEdit.Checked = false;
        //    //--
        //    chkAccessProfileRead.Checked = false;
        //    chkAccessProfileEdit.Checked = false;
        //    chkAccessCalenderRead.Checked = false;
        //    chkAccessCalenderEdit.Checked = false;
        //    chkSwitchProfileRead.Checked = false;
        //    chkSwitchProfileEdit.Checked = false;
        //    chkHolidayCalenderRead.Checked = false;
        //    chkHolidayCalenderEdit.Checked = false;
        //    chkHolidayPlanRead.Checked = false;
        //    chkHolidayPlanEdit.Checked = false;
        //    //--
        //    chkLanguageRead.Checked = false;
        //    chkLanguageEdit.Checked = false;
        //    chkRightsSettingsRead.Checked = false;
        //    chkRightsSettingsEdit.Checked = false;
        //    chkPasswordsAndProfilesRead.Checked = false;
        //    chkPasswordsAndProfilesEdit.Checked = false;
        //    //--
        //    chkAccessProfileGroupRead.Checked = false;
        //    chkAccessProfileGroupEdit.Checked = false;
        //    chkAccessPlanGroupRead.Checked = false;
        //    chkAccessPlanGroupEdit.Checked = false;




        //    chkGateMonitorRead.Checked = false;
        //    chkGateMonitorEdit.Checked = false;
        //    //-----
        //    chkGateMonitorPersRead.Checked = false;
        //    chkGateMonitorPersEdit.Checked = false;
        //    chkGateMonitorMembersRead.Checked = false;
        //    chkGateMonitorMembersEdit.Checked = false;
        //    chkGateMonitorVisitorsRead.Checked = false;
        //    chkGateMonitorVisitorsEdit.Checked = false;
        //    chkGateMonitorDisplayPanelRead.Checked = false;
        //    chkGateMonitorDisplayPanelEdit.Checked = false;
        //    chkGateMonitorInfoRead.Checked = false;
        //    chkGateMonitorInfoEdit.Checked = false;



        //    chkPersActiveRead.Checked = false;
        //    chkPersActiveEdit.Checked = false;
        //    chkMembersActiveRead.Checked = false;
        //    chkMembersActiveEdit.Checked = false;
        //    chkBuildingPlanRead.Checked = false;
        //    chkBuildingPlanEdit.Checked = false;
        //    chkAccessGroupsRead.Checked = false;
        //    chkAccessGroupsEdit.Checked = false;
        //    chkAccessPlansRead.Checked = false;
        //    chkAccessPlansEdit.Checked = false;
        //    chkSwitchPlanRead.Checked = false;
        //    chkSwitchPlanEdit.Checked = false;


        //    chkVisitorsRead.Checked = false;
        //    chkVisitorsEdit.Checked = false;
        //    chkVisitorApplicationsRead.Checked = false;
        //    chkVisitorApplicationsEdit.Checked = false;
        //    chkVisitorPlanRead.Checked = false;
        //    chkVisitorPlanEdit.Checked = false;


        //    chkGraderRead.Checked = false;
        //    chkGraderEdit.Checked = false;
        //    chkDisplayPanelRead.Checked = false;
        //    chkDisplayPanelEdit.Checked = false;
        //    chkAlarmDoorOpenRead.Checked = false;
        //    chkAlarmDoorOpenEdit.Checked = false;


        //    chkReportsRead.Checked = false;
        //    chkReportsEdit.Checked = false;


        //    chkCommunicationGetRead.Checked = false;
        //    chkCommunicationGetEdit.Checked = false;
        //    chkCommunicationSendRead.Checked = false;
        //    chkCommunicationSendEdit.Checked = false;
        //    chkCommunicationManualRead.Checked = false;
        //    chkCommunicationManualEdit.Checked = false;
        //}

        #region  Super Users
        public void AllAccessControlCheck()
        {
            chkTMKRead.Checked = _PermissionDto.AllServiceStudioRead;
            chkTMKEdit.Checked = _PermissionDto.AllServiceStudioEdit;

            chkZUTRead.Checked = _PermissionDto.AllAccessControlRead;
            chkZUTEdit.Checked = _PermissionDto.AllAccessControlEdit;
        }

        public void AllAccessControlGetCheck()
        {
            _PermissionDto.AllServiceStudioRead = chkTMKRead.Checked;
            _PermissionDto.AllServiceStudioEdit = chkTMKEdit.Checked;

            _PermissionDto.AllAccessControlRead = chkZUTRead.Checked;
            _PermissionDto.AllAccessControlEdit = chkZUTEdit.Checked;
        }
        #endregion


        #region GroupLevel Super Users
        public void AllGroupLevelCheck()
        {
            chkSettingsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead;
            chkSettingsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit;

            chkGateMonitorRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead;
            chkGateMonitorEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit;
        }

        public void AllGroupLevelGetCheck()
        {
            _PermissionDto.SettingsRead = chkSettingsRead.Checked;
            _PermissionDto.SettingsEdit = chkSettingsEdit.Checked;

            _PermissionDto.GateMonitorRead = chkGateMonitorRead.Checked;
            _PermissionDto.GateMonitorEdit = chkGateMonitorEdit.Checked;
        }
        #endregion


        #region Settings Group Levels
        public void AllSettingsCheck()
        {
            AllPersSettingsCheck();
            AllAccessSettingsCheck();
            AllGeneralSettingsCheck();
            AllGroupSettingsCheck();
        }

        private void AllPersSettingsCheck()
        {
            chkPersInactiveRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.PersInactiveRead;
            chkPersInactiveEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.PersInactiveEdit;

            chkMembersInactiveRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.MembersInactiveRead;
            chkMembersInactiveEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.MembersInactiveEdit;

            chkClientsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.ClientsRead;
            chkClientsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.ClientsEdit;

            chkLocationsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.LocationsRead;
            chkLocationsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.LocationsEdit;

            chkDepartmentsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.DepartmentRead;
            chkDepartmentsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.DepartmentEdit;

            chkCostCentersRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.CostCentersRead;
            chkCostCentersEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.CostCentersEdit;

            chkVisitorFirmsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.VisitorFirmsRead;
            chkVisitorFirmsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.VisitorFirmsEdit;

            chkVehiclesRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.VehiclesRead;
            chkVehiclesEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.VehiclesEdit;

            chkMembersGroupsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.MembersGroupRead;
            chkMembersGroupsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.MembersGroupEdit;

            chkMembersContractsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.MembersContractRead;
            chkMembersContractsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.MembersContractEdit;
        }

        private void AllAccessSettingsCheck()
        {
            chkAccessProfileRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessProfileRead;
            chkAccessProfileEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessProfileEdit;

            chkAccessCalenderRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessCalenderRead;
            chkAccessCalenderEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessCalenderEdit;

            chkSwitchProfileRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsSwitchProfileRead;
            chkSwitchProfileEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsSwitchProfileEdit;

            chkHolidayCalenderRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsHolidayCalenderRead;
            chkHolidayCalenderEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsHolidayCalenderEdit;

            chkHolidayPlanRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsHolidayPlanRead;
            chkHolidayPlanEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsHolidayPlanEdit;
        }

        private void AllGeneralSettingsCheck()
        {
            chkLanguageRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsLanguageRead;
            chkLanguageEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsLanguageEdit;

            chkRightsSettingsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsRightsRead;
            chkRightsSettingsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsRightsEdit;

            chkPasswordsAndProfilesRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsPasswordProfileRead;
            chkPasswordsAndProfilesEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsPasswordProfileEdit;
        }

        private void AllGroupSettingsCheck()
        {
            chkAccessProfileGroupRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessProfileGroupRead;
            chkAccessProfileGroupEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessProfileGroupEdit;

            chkAccessPlanGroupRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SettingsRead || _PermissionDto.SettingsAccessPlanGroupRead;
            chkAccessPlanGroupEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SettingsEdit || _PermissionDto.SettingsAccessPlanGroupEdit;
        }

        public void AllSettingsGetCheck()
        {
            AllPersSettingsGetCheck();
            AllAccessSettingsGetCheck();
            AllGeneralSettingsGetCheck();
            AllGroupSettingsGetCheck();
        }

        private void AllPersSettingsGetCheck()
        {
            _PermissionDto.PersInactiveRead = chkPersInactiveRead.Checked;
            _PermissionDto.PersInactiveEdit = chkPersInactiveEdit.Checked;

            _PermissionDto.MembersInactiveRead = chkMembersInactiveRead.Checked;
            _PermissionDto.MembersInactiveEdit = chkMembersInactiveEdit.Checked;

            _PermissionDto.ClientsRead = chkClientsRead.Checked;
            _PermissionDto.ClientsEdit = chkClientsEdit.Checked;

            _PermissionDto.LocationsRead = chkLocationsRead.Checked;
            _PermissionDto.LocationsEdit = chkLocationsEdit.Checked;

            _PermissionDto.DepartmentRead = chkDepartmentsRead.Checked;
            _PermissionDto.DepartmentEdit = chkDepartmentsEdit.Checked;

            _PermissionDto.CostCentersRead = chkCostCentersRead.Checked;
            _PermissionDto.CostCentersEdit = chkCostCentersEdit.Checked;

            _PermissionDto.VisitorFirmsRead = chkVisitorFirmsRead.Checked;
            _PermissionDto.VisitorFirmsEdit = chkVisitorFirmsEdit.Checked;

            _PermissionDto.VehiclesRead = chkVehiclesRead.Checked;
            _PermissionDto.VehiclesEdit = chkVehiclesEdit.Checked;

            _PermissionDto.MembersGroupRead = chkMembersGroupsRead.Checked;
            _PermissionDto.MembersGroupEdit = chkMembersGroupsEdit.Checked;

            _PermissionDto.MembersContractRead = chkMembersContractsRead.Checked;
            _PermissionDto.MembersContractEdit = chkMembersContractsEdit.Checked;
        }

        private void AllAccessSettingsGetCheck()
        {
            _PermissionDto.SettingsAccessProfileRead = chkAccessProfileRead.Checked;
            _PermissionDto.SettingsAccessProfileEdit = chkAccessProfileEdit.Checked;

            _PermissionDto.SettingsAccessCalenderRead = chkAccessCalenderRead.Checked;
            _PermissionDto.SettingsAccessCalenderEdit = chkAccessCalenderEdit.Checked;

            _PermissionDto.SettingsSwitchProfileRead = chkSwitchProfileRead.Checked;
            _PermissionDto.SettingsSwitchProfileEdit = chkSwitchProfileEdit.Checked;

            _PermissionDto.SettingsHolidayCalenderRead = chkHolidayCalenderRead.Checked;
            _PermissionDto.SettingsHolidayCalenderEdit = chkHolidayCalenderEdit.Checked;

            _PermissionDto.SettingsHolidayPlanRead = chkHolidayPlanRead.Checked;
            _PermissionDto.SettingsHolidayPlanEdit = chkHolidayPlanEdit.Checked;
        }

        private void AllGeneralSettingsGetCheck()
        {
            _PermissionDto.SettingsLanguageRead = chkLanguageRead.Checked;
            _PermissionDto.SettingsLanguageEdit = chkLanguageEdit.Checked;

            _PermissionDto.SettingsRightsRead = chkRightsSettingsRead.Checked;
            _PermissionDto.SettingsRightsEdit = chkRightsSettingsEdit.Checked;

            _PermissionDto.SettingsPasswordProfileRead = chkPasswordsAndProfilesRead.Checked;
            _PermissionDto.SettingsPasswordProfileEdit = chkPasswordsAndProfilesEdit.Checked;
        }

        private void AllGroupSettingsGetCheck()
        {
            _PermissionDto.SettingsAccessProfileGroupRead = chkAccessProfileGroupRead.Checked;
            _PermissionDto.SettingsAccessProfileGroupEdit = chkAccessProfileGroupEdit.Checked;

            _PermissionDto.SettingsAccessPlanGroupRead = chkAccessPlanGroupRead.Checked;
            _PermissionDto.SettingsAccessPlanGroupEdit = chkAccessPlanGroupEdit.Checked;
        }
        #endregion


        #region Gate Monitor Group Levels
        public void AllGateMonitorCheck()
        {
            chkGateMonitorPersRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorPersonnelRead;
            chkGateMonitorPersEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorPersonnelEdit;

            chkGateMonitorMembersRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorMembersRead;
            chkGateMonitorMembersEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorMembersEdit;

            chkGateMonitorVisitorsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorVisitorsRead;
            chkGateMonitorVisitorsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorVisitorsEdit;

            chkGateMonitorDisplayPanelRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorDisplayPanelRead;
            chkGateMonitorDisplayPanelEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorDisplayPanelEdit;

            chkGateMonitorInfoRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GateMonitorRead || _PermissionDto.GateMonitorInfoRead;
            chkGateMonitorInfoEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GateMonitorEdit || _PermissionDto.GateMonitorInfoEdit;
        }

        public void AllGateMonitorGetCheck()
        {
            _PermissionDto.GateMonitorPersonnelRead = chkGateMonitorPersRead.Checked;
            _PermissionDto.GateMonitorPersonnelEdit = chkGateMonitorPersEdit.Checked;

            _PermissionDto.GateMonitorMembersRead = chkGateMonitorMembersRead.Checked;
            _PermissionDto.GateMonitorMembersEdit = chkGateMonitorMembersEdit.Checked;

            _PermissionDto.GateMonitorVisitorsRead = chkGateMonitorVisitorsRead.Checked;
            _PermissionDto.GateMonitorVisitorsEdit = chkGateMonitorVisitorsEdit.Checked;

            _PermissionDto.GateMonitorDisplayPanelRead = chkGateMonitorDisplayPanelRead.Checked;
            _PermissionDto.GateMonitorDisplayPanelEdit = chkGateMonitorDisplayPanelEdit.Checked;

            _PermissionDto.GateMonitorInfoRead = chkGateMonitorInfoRead.Checked;
            _PermissionDto.GateMonitorInfoEdit = chkGateMonitorInfoEdit.Checked;
        }
        #endregion


        #region Master Data Group Levels
        public void AllMasterDataCheck()
        {
            chkPersActiveRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.PersActiveRead;
            chkPersActiveEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.PersActiveEdit;

            chkMembersActiveRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.MembersActiveRead;
            chkMembersActiveEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.MembersActiveEdit;

            chkBuildingPlanRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.BuildingPlanRead;
            chkBuildingPlanEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.BuildingPlanEdit;

            chkAccessGroupsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.AccessGroupRead;
            chkAccessGroupsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.AccessGroupEdit;

            chkAccessPlansRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.AccessPlanRead;
            chkAccessPlansEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.AccessPlanEdit;

            chkSwitchPlanRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.SwitchPlanRead;
            chkSwitchPlanEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.SwitchPlanEdit;
        }

        public void AllMasterDataGetCheck()
        {
            _PermissionDto.PersActiveRead = chkPersActiveRead.Checked;
            _PermissionDto.PersActiveEdit = chkPersActiveEdit.Checked;

            _PermissionDto.MembersActiveRead = chkMembersActiveRead.Checked;
            _PermissionDto.MembersActiveEdit = chkMembersActiveEdit.Checked;

            _PermissionDto.BuildingPlanRead = chkBuildingPlanRead.Checked;
            _PermissionDto.BuildingPlanEdit = chkBuildingPlanEdit.Checked;

            _PermissionDto.AccessGroupRead = chkAccessGroupsRead.Checked;
            _PermissionDto.AccessGroupEdit = chkAccessGroupsEdit.Checked;

            _PermissionDto.AccessPlanRead = chkAccessPlansRead.Checked;
            _PermissionDto.AccessPlanEdit = chkAccessPlansEdit.Checked;

            _PermissionDto.SwitchPlanRead = chkSwitchPlanRead.Checked;
            _PermissionDto.SwitchPlanEdit = chkSwitchPlanEdit.Checked;
        }
        #endregion


        #region Visitor Master Data Group Levels
        public void AllVisitorMasterCheck()
        {
            chkVisitorsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.VisitorsRead;
            chkVisitorsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.VisitorsEdit;

            chkVisitorApplicationsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.VisitorApplicationsRead;
            chkVisitorApplicationsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.VisitorApplicationsEdit;

            chkVisitorPlanRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.VisitorPlanRead;
            chkVisitorPlanEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.VisitorPlanEdit;
        }

        public void AllVisitorMasterGetCheck()
        {
            _PermissionDto.VisitorsRead = chkVisitorsRead.Checked;
            _PermissionDto.VisitorsEdit = chkVisitorsEdit.Checked;

            _PermissionDto.VisitorApplicationsRead = chkVisitorApplicationsRead.Checked;
            _PermissionDto.VisitorApplicationsEdit = chkVisitorApplicationsEdit.Checked;

            _PermissionDto.VisitorPlanRead = chkVisitorPlanRead.Checked;
            _PermissionDto.VisitorPlanEdit = chkVisitorPlanEdit.Checked;
        }
        #endregion


        #region Safety and Corrections Group Levels
        public void AllSafetyAndCorrectionsCheck()
        {
            chkGraderRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.GraderRead;
            chkGraderEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.GraderEdit;

            chkDisplayPanelRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.DisplayPanelRead;
            chkDisplayPanelEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.DisplayPanelEdit;

            chkAlarmDoorOpenRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.AlarmOpenRead;
            chkAlarmDoorOpenEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.AlarmOpenEdit;
        }
        public void AllSafetyAndCorrectionsGetCheck()
        {
            _PermissionDto.GraderRead = chkGraderRead.Checked;
            _PermissionDto.GraderEdit = chkGraderEdit.Checked;

            _PermissionDto.DisplayPanelRead = chkDisplayPanelRead.Checked;
            _PermissionDto.DisplayPanelEdit = chkDisplayPanelEdit.Checked;

            _PermissionDto.AlarmOpenRead = chkAlarmDoorOpenRead.Checked;
            _PermissionDto.AlarmOpenEdit = chkAlarmDoorOpenEdit.Checked;
        }
        #endregion


        #region Reports Group Levels
        public void AllReportsCheck()
        {
            chkReportsRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.ReportsRead;
            chkReportsEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.ReportsEdit;
        }

        public void AllReportsGetCheck()
        {
            _PermissionDto.ReportsRead = chkReportsRead.Checked;
            _PermissionDto.ReportsEdit = chkReportsEdit.Checked;
        }
        #endregion


        #region Communications Group Levels
        public void AllCommunicationsCheck()
        {
            chkCommunicationGetRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.CommunicationGETRead;
            chkCommunicationGetEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.CommunicationGETEdit;

            chkCommunicationSendRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.CommunicationSENDRead;
            chkCommunicationSendEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.CommunicationSENDEdit;

            chkCommunicationManualRead.Checked = _PermissionDto.AllAccessControlRead || _PermissionDto.CommunicationManualRead;
            chkCommunicationManualEdit.Checked = _PermissionDto.AllAccessControlEdit || _PermissionDto.CommunicationManualEdit;
        }

        public void AllCommunicationsGetCheck()
        {
            _PermissionDto.CommunicationGETRead = chkCommunicationGetRead.Checked;
            _PermissionDto.CommunicationGETEdit = chkCommunicationGetEdit.Checked;

            _PermissionDto.CommunicationSENDRead = chkCommunicationSendRead.Checked;
            _PermissionDto.CommunicationSENDEdit = chkCommunicationSendEdit.Checked;

            _PermissionDto.CommunicationManualRead = chkCommunicationManualRead.Checked;
            _PermissionDto.CommunicationManualEdit = chkCommunicationManualEdit.Checked;
        }
        #endregion


        #region Permissions List From Checks
        private List<AC_PermissionMapping> GetPermissionMappingsList(ref AC_PermissionProfile permissionProfile)
        {
            AllAccessControlCheck(ref permissionProfile);
            AllGroupLevelCheck(ref permissionProfile);

            AllSettingsCheck(ref permissionProfile);
            AllGateMonitorCheck(ref permissionProfile);
            AllMasterDataCheck(ref permissionProfile);
            AllVisitorMasterCheck(ref permissionProfile);
            AllSafetyAndCorrectionsCheck(ref permissionProfile);
            AllReportsCheck(ref permissionProfile);
            AllCommunicationsCheck(ref permissionProfile);

            return PermissionMappingList;
        }

        private void addPermissionToDbList(ref AC_PermissionProfile permissionProfile, bool boolEditValue, bool boolReadValue, accessControlPermissions _permissionId)
        {
            if (boolEditValue || boolReadValue)
            {
                PermissionMappingList.Add(new AC_PermissionMapping
                {
                    AC_PermissionProfile = permissionProfile,
                    PermissionType = (boolEditValue ? 1 : boolReadValue ? 2 : 0),
                    PermissionKey = (int)_permissionId,
                    ProfileId = permissionProfile.ID > 0 ? permissionProfile.ID : 0
                });
            }
        }

        public void AllAccessControlCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.AllServiceStudioEdit, _PermissionDto.AllServiceStudioRead, accessControlPermissions.AllServiceStudio);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.AllAccessControlEdit, _PermissionDto.AllAccessControlRead, accessControlPermissions.AllAccessControl);
        }

        public void AllGroupLevelCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsEdit, _PermissionDto.SettingsRead, accessControlPermissions.Settings);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.GateMonitorEdit, _PermissionDto.GateMonitorRead, accessControlPermissions.GateMonitor);
        }

        public void AllSettingsCheck(ref AC_PermissionProfile permissionProfile)
        {
            AllPersSettingsCheck(ref permissionProfile);
            AllAccessSettingsCheck(ref permissionProfile);
            AllGeneralSettingsCheck(ref permissionProfile);
            AllGroupSettingsCheck(ref permissionProfile);
        }

        private void AllPersSettingsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.PersInactiveEdit, _PermissionDto.PersInactiveRead, accessControlPermissions.PersInactive);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.MembersInactiveEdit, _PermissionDto.MembersInactiveRead, accessControlPermissions.MembersInactive);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.ClientsEdit, _PermissionDto.ClientsRead, accessControlPermissions.Clients);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.LocationsEdit, _PermissionDto.LocationsRead, accessControlPermissions.Locations);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.DepartmentEdit, _PermissionDto.DepartmentRead, accessControlPermissions.Department);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.CostCentersEdit, _PermissionDto.CostCentersRead, accessControlPermissions.CostCenters);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.VisitorFirmsEdit, _PermissionDto.VisitorFirmsRead, accessControlPermissions.VisitorFirms);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.VehiclesEdit, _PermissionDto.VehiclesRead, accessControlPermissions.Vehicles);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.MembersGroupEdit, _PermissionDto.MembersGroupRead, accessControlPermissions.MembersGroup);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.MembersContractEdit, _PermissionDto.MembersContractRead, accessControlPermissions.MembersContract);
        }

        private void AllAccessSettingsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsAccessProfileEdit, _PermissionDto.SettingsAccessProfileRead, accessControlPermissions.SettingsAccessProfile);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsAccessCalenderEdit, _PermissionDto.SettingsAccessCalenderRead, accessControlPermissions.SettingsAccessCalender);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsSwitchProfileEdit, _PermissionDto.SettingsSwitchProfileRead, accessControlPermissions.SettingsSwitchProfile);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsHolidayCalenderEdit, _PermissionDto.SettingsHolidayCalenderRead, accessControlPermissions.SettingsHolidayCalender);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsHolidayPlanEdit, _PermissionDto.SettingsHolidayPlanRead, accessControlPermissions.SettingsHolidayPlan);
        }

        private void AllGeneralSettingsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsLanguageEdit, _PermissionDto.SettingsLanguageRead, accessControlPermissions.SettingsLanguage);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsRightsEdit, _PermissionDto.SettingsRightsRead, accessControlPermissions.SettingsRights);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsPasswordProfileEdit, _PermissionDto.SettingsPasswordProfileRead, accessControlPermissions.SettingsPasswordProfile);
        }

        private void AllGroupSettingsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsAccessProfileGroupEdit, _PermissionDto.SettingsAccessProfileGroupRead, accessControlPermissions.SettingsAccessProfileGroup);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SettingsAccessPlanGroupEdit, _PermissionDto.SettingsAccessPlanGroupRead, accessControlPermissions.SettingsAccessPlanGroup);
        }

        public void AllGateMonitorCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.GateMonitorPersonnelEdit, _PermissionDto.GateMonitorPersonnelRead, accessControlPermissions.GateMonitorPersonnel);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.GateMonitorMembersEdit, _PermissionDto.GateMonitorMembersRead, accessControlPermissions.GateMonitorMembers);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.GateMonitorVisitorsEdit, _PermissionDto.GateMonitorVisitorsRead, accessControlPermissions.GateMonitorVisitors);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.GateMonitorDisplayPanelEdit, _PermissionDto.GateMonitorDisplayPanelRead, accessControlPermissions.GateMonitorDisplayPanel);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.GateMonitorInfoEdit, _PermissionDto.GateMonitorInfoRead, accessControlPermissions.GateMonitorInfo);
        }

        public void AllMasterDataCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.PersActiveEdit, _PermissionDto.PersActiveRead, accessControlPermissions.PersActive);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.MembersActiveEdit, _PermissionDto.MembersActiveRead, accessControlPermissions.MembersActive);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.BuildingPlanEdit, _PermissionDto.BuildingPlanRead, accessControlPermissions.BuildingPlan);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.AccessGroupEdit, _PermissionDto.AccessGroupRead, accessControlPermissions.AccessGroup);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.AccessPlanEdit, _PermissionDto.AccessPlanRead, accessControlPermissions.AccessPlan);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.SwitchPlanEdit, _PermissionDto.SwitchPlanRead, accessControlPermissions.SwitchPlan);
        }

        public void AllVisitorMasterCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.VisitorsEdit, _PermissionDto.VisitorsRead, accessControlPermissions.Visitors);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.VisitorApplicationsEdit, _PermissionDto.VisitorApplicationsRead, accessControlPermissions.VisitorApplications);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.VisitorPlanEdit, _PermissionDto.VisitorPlanRead, accessControlPermissions.VisitorPlan);
        }

        public void AllSafetyAndCorrectionsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.GraderEdit, _PermissionDto.GraderRead, accessControlPermissions.Grader);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.DisplayPanelEdit, _PermissionDto.DisplayPanelRead, accessControlPermissions.DisplayPanel);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.AlarmOpenEdit, _PermissionDto.AlarmOpenRead, accessControlPermissions.AlarmOpen);
        }

        public void AllReportsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.ReportsEdit, _PermissionDto.ReportsRead, accessControlPermissions.Reports);
        }

        public void AllCommunicationsCheck(ref AC_PermissionProfile permissionProfile)
        {
            addPermissionToDbList(ref permissionProfile, _PermissionDto.CommunicationGETEdit, _PermissionDto.CommunicationGETRead, accessControlPermissions.CommunicationGET);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.CommunicationSENDEdit, _PermissionDto.CommunicationSENDRead, accessControlPermissions.CommunicationSEND);

            addPermissionToDbList(ref permissionProfile, _PermissionDto.CommunicationManualEdit, _PermissionDto.CommunicationManualRead, accessControlPermissions.CommunicationManual);
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetPermissionsProfile();
            if (PermissionsProfile.ProfileNr.Equals(0)) return;


            if (EditMode.Equals(EditModes.New))
            {
                new PermissionProfileViewModel().AddPermissionsProfile(PermissionsProfile);
            }
            else
            {
                new PermissionProfileViewModel().EditPermissionsProfile(PermissionsProfile);
            }

            BindDrps();
            int profileID = (PermissionsProfileList.OrderBy(p => p.ID).ToList().LastOrDefault() ?? new AC_PermissionProfile()).ID;

            if (profileID > 0)
            {
                try
                {
                    cmbProfileNr.Value = profileID.ToString();
                    cmbProfileDesc.Value = profileID.ToString();
                }
                catch (Exception) { }
            }

            EditMode = EditModes.Edit;

            mainCtl.RedirectToPromptPage();

            SetPermissionsTextControls();
            GetPermissions();

            SetEditModeControls();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GetPermissionsProfile();
            if (PermissionsProfile.ProfileNr.Equals(0) || PermissionsProfile.ID.Equals(0)) return;

            PermissionsProfileViewModel.DeletePermissionsProfile(PermissionsProfile);
            //WorkingProfileNr = 0;

            BindDrps();
            try
            {
                cmbProfileNr.Value = "0";
                cmbProfileDesc.Value = "0";
            }
            catch (Exception) { }

            BindPermissions();

            EditMode = EditModes.Edit;
            SetEditModeControls();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            EditMode = EditModes.New;
            ClearPermissionsTextControls();
            SetEditModeControls();
            GetPermissions();
        }

        protected void cmbProfileNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProfileDesc.Value = cmbProfileNr.Value;
            SetPermissionsTextControls();
            GetPermissions();
        }

        protected void cmbProfileDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProfileNr.Value = cmbProfileDesc.Value;
            SetPermissionsTextControls();
            GetPermissions();
        }

        protected void grdSearchProfiles_SelectionChanged(object sender, EventArgs e)
        {
            int profileId = 0;
            try
            {

            }
            catch (Exception) { }
            if (grdSearchProfiles.GetSelectedFieldValues("ID") == null) return;
            if (!int.TryParse(grdSearchProfiles.GetSelectedFieldValues("ID")[0].ToString(), out profileId)) return;
            cmbProfileNr.Value = profileId.ToString();
            cmbProfileDesc.Value = cmbProfileNr.Value;
            SetPermissionsTextControls();
            GetPermissions();
        }


        [WebMethod]
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }
    }
}