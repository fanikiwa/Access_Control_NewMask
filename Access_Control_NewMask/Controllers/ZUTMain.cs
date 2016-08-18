using Access_Control_NewMask.Dtos;
using DevExpress.Web;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.Controllers
{
    public enum accessControlPermissions //From Table: AC_Persmissions
    {
        #region Old Permissions
        //AllTermConfig = 1,
        ////AllAccessControl = 2, Settings = 3,
        //PersonnelSettings = 4, Location = 5,
        ////Department = 6,
        //CostCenter = 7, Vehicle = 8, AccessControlSettings = 9,
        //GeneralSettings = 10, Language = 11, ProfileGroup = 12, PlanGroup = 13, Icons = 14, RightsAssignment = 15, Password = 16,
        ////MasterData = 17,
        //PersonnelDataset = 18,
        ////BuildingPlan = 19, AccessPlan = 20,
        //AccessPlanSettings = 21, AccessPlanInfo = 22,
        ////SwitchPlan = 23,
        //SwitchPlanSettings = 24, SwitchPlanInfo = 25, VisitorSettings = 26,
        //VisitorLogin = 27, VisitorDataManagement = 28,
        ////VisitorPlan = 29,
        //SafetySettings = 30,
        ////Grader = 31,
        //SecurityManagement = 32, AlarmFunction = 33, AccessControlLists = 34,
        ////Communication = 35,
        #endregion

        #region New Permissions
        AllServiceStudio = 101, AllAccessControl = 102,

        Settings = 103,
        SettingsPersMaster = 110,
        PersInactive = 114, MembersInactive = 115, Clients = 116, Locations = 117, Department = 118, CostCenters = 119, VisitorFirms = 120,
        Vehicles = 121, MembersGroup = 122, MembersContract = 123,

        SettingsAccess = 111,
        SettingsAccessProfile = 124, SettingsAccessCalender = 125, SettingsSwitchProfile = 126, SettingsSwitchCalender = 127,
        SettingsHolidayCalender = 128, SettingsHolidayPlan = 129,

        SettingsGeneral = 112,
        SettingsLanguage = 130, SettingsRights = 131, SettingsPasswordProfile = 132,

        SettingsGroup = 113,
        SettingsAccessProfileGroup = 133, SettingsAccessPlanGroup = 134,

        GateMonitor = 104,
        GateMonitorPersonnel = 135, GateMonitorMembers = 136, GateMonitorVisitors = 137, GateMonitorDisplayPanel = 138, GateMonitorInfo = 139,

        MasterData = 105,
        PersActive = 140, MembersActive = 141, BuildingPlan = 142, AccessGroup = 143, AccessPlan = 144, SwitchPlan = 145,

        VisitorMasterData = 106,
        Visitors = 146, VisitorApplications = 147, VisitorPlan = 148,

        SafetyAndCorrections = 107,
        Grader = 149, DisplayPanel = 150, AlarmOpen = 151,

        Reports = 108,

        Communication = 109,
        CommunicationSEND = 152, CommunicationGET = 153, CommunicationManual = 154
        #endregion
    }


    public enum accessControlPermissionModes
    {
        Edit = 1, Read = 2
    }

    public class ZUTMain
    {
        public ZUTMain() { }

        #region Global Objects
        PermissionMappingRepository _permissionMappingRepository = new PermissionMappingRepository();
        PersPasswordsRepository persPasswordsRepository = new PersPasswordsRepository();
        vwPersPasswordsProfileRepository _vwPersPasswordsProfileRepository = new vwPersPasswordsProfileRepository();
        PersProfileADMappingRepository _persProfileADMappingRepository = new PersProfileADMappingRepository();

        AC_PersPasswordsProfile passwordProfile = new AC_PersPasswordsProfile();
        AC_PersProfileADMapping adPasswordProfile = new AC_PersProfileADMapping();
        PermissionDto2 permissionsDto = new PermissionDto2();
        AC_PersPasswords persPasswords = new AC_PersPasswords();

        EncryptionCtl _encryptionCtl = new EncryptionCtl();

        List<AC_PermissionMapping> permissionKeysMappingList = new List<AC_PermissionMapping>();
        #endregion

        //public static void AllowExternalAppAccess(ref ImageButton btnTMK)
        //{
        //    if (HttpContext.Current.Session["Pers_Nr"] == null) return;

        //    enableTMKAppCheck(ref btnTMK);
        //}

        public PermissionDto2 GetSessionPermissions()
        {
            return LoadSessionItem<PermissionDto2>("Pers_Permissions") ?? new PermissionDto2();
        }

        public void GetSessionPermissionKeysMapping()
        {
            permissionKeysMappingList = (List<AC_PermissionMapping>)HttpContext.Current.Session["Pers_PermissionKeysMapping"];
            if (permissionKeysMappingList == null) permissionKeysMappingList = new List<AC_PermissionMapping>();
        }

        public bool CheckForReadOrWritePermissions(accessControlPermissions accessControlPermission)
        {
            GetSessionPermissionKeysMapping();

            if (permissionKeysMappingList.Count == 0) return false;


            return permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermission &&
            (x.PermissionType == (int)accessControlPermissionModes.Edit || x.PermissionType == (int)accessControlPermissionModes.Read)) ||
            permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermissions.AllAccessControl &&
            (x.PermissionType == (int)accessControlPermissionModes.Edit || x.PermissionType == (int)accessControlPermissionModes.Read));
            //return false;
        }

        public bool CheckForReadOrWritePermissions(accessControlPermissions accessControlPermission, out accessControlPermissionModes accessControlPermissionMode)
        {
            GetSessionPermissionKeysMapping();
            accessControlPermissionMode = accessControlPermissionModes.Read;

            if (permissionKeysMappingList.Count == 0) return false;

            if (permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermission &&
            (x.PermissionType == (int)accessControlPermissionModes.Edit)) ||
            permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermissions.AllAccessControl &&
            (x.PermissionType == (int)accessControlPermissionModes.Edit)))
                accessControlPermissionMode = accessControlPermissionModes.Edit;


            return permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermission &&
            (x.PermissionType == (int)accessControlPermissionModes.Edit || x.PermissionType == (int)accessControlPermissionModes.Read)) ||
            permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermissions.AllAccessControl &&
            (x.PermissionType == (int)accessControlPermissionModes.Edit || x.PermissionType == (int)accessControlPermissionModes.Read));
            //return false;
        }

        public bool CheckForPermission(accessControlPermissions accessControlPermission, accessControlPermissionModes accessControlPermissionMode)
        {
            GetSessionPermissionKeysMapping();

            if (permissionKeysMappingList.Count == 0) return false;

            return permissionKeysMappingList.Any(x => x.PermissionKey == (int)accessControlPermission && x.PermissionType == (int)accessControlPermissionMode);
            return false;
        }

        //private static void enableTMKAppCheck(ref ImageButton btnTMK)
        //{
        //    if (!(permissionsDto.AllServiceStudioEdit || permissionsDto.AllServiceStudioRead))
        //    {
        //        btnTMK.Enabled = false;
        //    }
        //}

        public bool allowTMKAppCheck()
        {
            permissionsDto = GetSessionPermissions();
            return permissionsDto.AllServiceStudioEdit || permissionsDto.AllServiceStudioRead;
        }

        //#region GroupLevel Super Users Navigation Items
        //public void allGroupLevelCheck(ref ASPxNavBar dxNavBar)
        //{
        //    //dxNavBar.Items.FindByName("Antrag").Enabled = false;
        //    dxNavBar.Items.FindByName("settings").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit;

        //    dxNavBar.Groups.FindByName("masterData").Visible = permissionsDto.AllAccessControlRead || permissionsDto.MasterDataRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.MasterDataEdit;

        //    dxNavBar.Groups.FindByName("visitorManagement").Visible = permissionsDto.AllAccessControlRead || permissionsDto.VisitorSettingsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.VisitorSettingsEdit;

        //    dxNavBar.Groups.FindByName("safetyManagement").Visible = permissionsDto.AllAccessControlRead || permissionsDto.SafetySettingsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SafetySettingsEdit;

        //    dxNavBar.Groups.FindByName("lists").Visible = permissionsDto.AllAccessControlRead || permissionsDto.AccessControlListsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.AccessControlListsEdit;

        //    dxNavBar.Groups.FindByName("communication").Visible = permissionsDto.AllAccessControlEdit || permissionsDto.CommunicationEdit;
        //}
        //#endregion
        //
        //#region Settings Group Navigation Items
        //public void TrimNavigationMenu(ref ASPxNavBar dxNavBar)
        //{
        //    GetSessionPermissions();
        //    if (HttpContext.Current.Session["Pers_Nr"] == null) return;

        //    allGroupLevelCheck(ref dxNavBar);

        //    enableSettingsCheck(ref dxNavBar);

        //    personnelDataSetCheck(ref dxNavBar);
        //    buildingPlanCheck(ref dxNavBar);
        //    accessPlanSettingsCheck(ref dxNavBar);
        //    switchPlanSettingsCheck(ref dxNavBar);
        //    enableMasterDataSuperUserCheck(ref dxNavBar);

        //    visitorLoginCheck(ref dxNavBar);
        //    visitorDataSetCheck(ref dxNavBar);
        //    visitorPlanCheck(ref dxNavBar);
        //    enableVisitorSettingsSuperUserCheck(ref dxNavBar);

        //    graderCheck(ref dxNavBar);
        //    safetyManagementCheck(ref dxNavBar);
        //    alarmFunctionCheck(ref dxNavBar);
        //    enableSafetyManagementSuperUserCheck(ref dxNavBar);
        //}
        //
        //public bool personnelSettingsCheck()
        //{
        //    return permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.PersonnelSettingsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.PersonnelSettingsEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.PersonnelSettingsRead || permissionsDto.DepartmentRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.PersonnelSettingsEdit || permissionsDto.DepartmentEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.PersonnelSettingsRead || permissionsDto.LocationRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.PersonnelSettingsEdit || permissionsDto.LocationEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.PersonnelSettingsRead || permissionsDto.CostCenterRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.PersonnelSettingsEdit || permissionsDto.CostCenterEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.PersonnelSettingsRead || permissionsDto.VehicleRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.PersonnelSettingsEdit || permissionsDto.VehicleEdit;
        //}

        //private bool accessControlSettingsCheck()
        //{
        //    return permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.AccessControlSettingsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.AccessControlSettingsEdit;
        //}

        //private bool generalSettingsCheck()
        //{
        //    return permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead || permissionsDto.LanguageRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit || permissionsDto.LanguageEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead || permissionsDto.ProfileGroupRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit || permissionsDto.ProfileGroupEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead || permissionsDto.PlanGroupRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit || permissionsDto.PlanGroupEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead || permissionsDto.IconsRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit || permissionsDto.IconsEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead || permissionsDto.RightsAssignmentRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit || permissionsDto.RightsAssignmentEdit ||

        //        permissionsDto.AllAccessControlRead || permissionsDto.SettingsRead || permissionsDto.GeneralSettingsRead || permissionsDto.PasswordRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SettingsEdit || permissionsDto.GeneralSettingsEdit || permissionsDto.PasswordEdit;
        //}

        //private void enableSettingsCheck(ref ASPxNavBar dxNavBar)
        //{
        //    if (!dxNavBar.Items.FindByName("settings").Enabled)
        //    {
        //        dxNavBar.Items.FindByName("settings").Enabled = personnelSettingsCheck() || accessControlSettingsCheck() || generalSettingsCheck();
        //    }
        //}
        //#endregion

        //#region Master Data Group Navigation Items
        //private void personnelDataSetCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("personal").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.MasterDataRead || permissionsDto.PersonnelDataSetRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.MasterDataEdit || permissionsDto.PersonnelDataSetEdit;
        //}

        //private void buildingPlanCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("buildingPlan").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.MasterDataRead || permissionsDto.BuildingPlanRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.MasterDataEdit || permissionsDto.BuildingPlanEdit;
        //}

        //private void accessPlanSettingsCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("accessPlans").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.MasterDataRead || permissionsDto.AccessPlanRead ||
        //        permissionsDto.AccessPlanSettingsRead || permissionsDto.AccessPlanInfoRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.MasterDataEdit || permissionsDto.AccessPlanEdit ||
        //        permissionsDto.AccessPlanSettingsEdit || permissionsDto.AccessPlanInfoEdit;
        //}

        //private void switchPlanSettingsCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("switchPlan").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.MasterDataRead || permissionsDto.SwitchPlanRead ||
        //        permissionsDto.SwitchPlanSettingsRead || permissionsDto.SwitchPlanInfoRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.MasterDataEdit || permissionsDto.SwitchPlanEdit ||
        //        permissionsDto.SwitchPlanSettingsEdit || permissionsDto.SwitchPlanInfoEdit;
        //}

        //private void enableMasterDataSuperUserCheck(ref ASPxNavBar dxNavBar)
        //{
        //    if (!dxNavBar.Groups.FindByName("masterData").Visible)
        //    {
        //        dxNavBar.Groups.FindByName("masterData").Visible = dxNavBar.Groups.FindByName("masterData").Items.Any(x => x.Enabled);
        //    }
        //}
        //#endregion

        //#region Visitor Group Navigation Items
        //private void visitorLoginCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("visitorApplications").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.VisitorSettingsRead || permissionsDto.VisitorLoginRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.VisitorSettingsEdit || permissionsDto.VisitorLoginEdit;
        //}

        //private void visitorDataSetCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("visitorsData").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.VisitorSettingsRead || permissionsDto.VisitorDataManagementRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.VisitorSettingsEdit || permissionsDto.VisitorDataManagementEdit;
        //}

        //private void visitorPlanCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("visitorsPlan").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.VisitorSettingsRead || permissionsDto.VisitorPlanRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.VisitorSettingsEdit || permissionsDto.VisitorPlanEdit;
        //}

        //private void enableVisitorSettingsSuperUserCheck(ref ASPxNavBar dxNavBar)
        //{
        //    if (!dxNavBar.Groups.FindByName("visitorManagement").Visible)
        //    {
        //        dxNavBar.Groups.FindByName("visitorManagement").Visible = dxNavBar.Groups.FindByName("visitorManagement").Items.Any(x => x.Enabled);
        //    }
        //}
        //#endregion

        //#region Safety Management Group Navigation Items
        //private void graderCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("accessCorrections").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.SafetySettingsRead || permissionsDto.GraderRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SafetySettingsEdit || permissionsDto.GraderEdit;
        //}

        //private void safetyManagementCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("safetyStand").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.SafetySettingsRead || permissionsDto.SecurityManagementRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SafetySettingsEdit || permissionsDto.SecurityManagementEdit;
        //}

        //private void alarmFunctionCheck(ref ASPxNavBar dxNavBar)
        //{
        //    dxNavBar.Items.FindByName("alarmFunction").Enabled = permissionsDto.AllAccessControlRead || permissionsDto.SafetySettingsRead || permissionsDto.AlarmFuctionRead ||
        //        permissionsDto.AllAccessControlEdit || permissionsDto.SafetySettingsEdit || permissionsDto.AlarmFunctionEdit;
        //}

        //private void enableSafetyManagementSuperUserCheck(ref ASPxNavBar dxNavBar)
        //{
        //    if (!dxNavBar.Groups.FindByName("safetyManagement").Visible)
        //    {
        //        dxNavBar.Groups.FindByName("safetyManagement").Visible = dxNavBar.Groups.FindByName("safetyManagement").Items.Any(x => x.Enabled);
        //    }
        //}
        //#endregion

        #region Login Helpers
        public void LoginUser(string password, string userName, string redirectLocation)
        {
            if (userName == "admin") LoginAdmin(password);

            GetUserLoginDetails(userName);

            //if (passwordProfile.Pers_Nr == 0 || passwordProfile.UserName == "") return;

            if ((passwordProfile.CurrentPassword ?? "").Equals(password))
            {
                AddPersPermissionToSession();
                AddPermissionKeysMappingToSession();
                AddPersDetailsToSession(password, userName);
                if (redirectLocation != "") HttpContext.Current.Response.Redirect(redirectLocation);
                HttpContext.Current.Response.Redirect("/Index.aspx");
            }
            else
            {
                //Wrong password Action
                GetADUserLoginDetails(userName);

                try
                {
                    string[] domainArr = (adPasswordProfile.AD_Controller ?? "").Split('.');

                    if (domainArr.Length == 2)
                    {
                        DirectoryEntry myLdapConnection = new DirectoryEntry(adPasswordProfile.AD_Path,
                            String.Format(@"{0}\{1}", domainArr[0], adPasswordProfile.AD_Username), password,
                            AuthenticationTypes.None);
                        Object x = myLdapConnection.NativeObject;

                        AddADPersPermissionToSession();
                        AddADPermissionKeysMappingToSession();
                        AddADPersDetailsToSession(password, userName);
                        if (redirectLocation != "") HttpContext.Current.Response.Redirect(redirectLocation);
                        HttpContext.Current.Response.Redirect("/Index.aspx");
                    }
                }
                catch (Exception e) { }
            }
        }

        private void LoginAdmin(string password)
        {
            GetPseudoUserLoginPassword("admin");
            if (persPasswords.Password != null) { if (persPasswords.Password.Trim() != "" && password != persPasswords.Password.Trim()) return; }
            if (persPasswords.Password == null && password != "admin") return;

            HttpContext.Current.Session.Add("Pers_Nr", "-10000");
            HttpContext.Current.Session.Add("Pers_FirstName", "Admin");
            HttpContext.Current.Session.Add("Pers_LastName", "Admin");
            HttpContext.Current.Session.Add("Pers_Name", "Admin");
            HttpContext.Current.Session.Add("Pers_LoginName", "admin");
            HttpContext.Current.Session.Add("Pers_LoginPassword", password);

            permissionsDto = new PermissionDto2();
            permissionsDto.AllServiceStudioEdit = true;
            permissionsDto.AllAccessControlEdit = true;
            HttpContext.Current.Session.Add("Pers_Permissions", permissionsDto);
            List<AC_PermissionMapping> pl = new List<AC_PermissionMapping>();
            pl.Add(new AC_PermissionMapping()
            {
                PermissionType = (int)accessControlPermissionModes.Edit,
                PermissionKey = (int)accessControlPermissions.AllAccessControl
            });
            pl.Add(new AC_PermissionMapping()
            {
                PermissionType = (int)accessControlPermissionModes.Edit,
                PermissionKey = (int)accessControlPermissions.AllServiceStudio
            });
            HttpContext.Current.Session.Add("Pers_PermissionKeysMapping", pl);
            HttpContext.Current.Response.Redirect("/Index.aspx");
        }

        private void GetUserLoginDetails(string userName)
        {
            passwordProfile = _vwPersPasswordsProfileRepository.GetPersPasswordsByName(userName);
            if (passwordProfile == null)
                passwordProfile = new AC_PersPasswordsProfile();
        }

        private void GetADUserLoginDetails(string userName)
        {
            adPasswordProfile = _persProfileADMappingRepository.GetPersPasswordsByName(userName);
            if (passwordProfile == null)
                passwordProfile = new AC_PersPasswordsProfile();
        }

        private void GetPseudoUserLoginPassword(string userName)
        {
            persPasswords = persPasswordsRepository.GetPersCurrentPasswordByName(userName);
            if (persPasswords == null)
                persPasswords = new AC_PersPasswords();
        }

        private void AddPersPermissionToSession()
        {
            permissionsDto = passwordProfile.ProfileID == null ? new PermissionDto2() : GetPermissionsById((int)passwordProfile.ProfileID);
            HttpContext.Current.Session.Add("Pers_Permissions", permissionsDto);
        }

        private void AddPermissionKeysMappingToSession()
        {
            permissionKeysMappingList = passwordProfile.ProfileID == null ? new List<AC_PermissionMapping>() :
                _permissionMappingRepository.GetPermissionMappingsByProfileId((int)passwordProfile.ProfileID);
            HttpContext.Current.Session.Add("Pers_PermissionKeysMapping", permissionKeysMappingList);
        }

        private void AddPersDetailsToSession(string password, string userName)
        {
            HttpContext.Current.Session.Add("Pers_Nr", passwordProfile.Pers_Nr);
            HttpContext.Current.Session.Add("Pers_FirstName", passwordProfile.FirstName);
            HttpContext.Current.Session.Add("Pers_LastName", passwordProfile.LastName);
            HttpContext.Current.Session.Add("Pers_Name", String.Format("{0}, {1}", passwordProfile.FirstName, passwordProfile.LastName));
            HttpContext.Current.Session.Add("Pers_LoginName", userName);
            HttpContext.Current.Session.Add("Pers_LoginPassword", password);
        }

        private void AddADPersPermissionToSession()
        {
            permissionsDto = adPasswordProfile.ProfileID == null ? new PermissionDto2() : GetPermissionsById((int)adPasswordProfile.ProfileID);
            HttpContext.Current.Session.Add("Pers_Permissions", permissionsDto);
        }

        private void AddADPermissionKeysMappingToSession()
        {
            permissionKeysMappingList = adPasswordProfile.ProfileID == null ? new List<AC_PermissionMapping>() :
                _permissionMappingRepository.GetPermissionMappingsByProfileId((int)adPasswordProfile.ProfileID);
            HttpContext.Current.Session.Add("Pers_PermissionKeysMapping", permissionKeysMappingList);
        }

        private void AddADPersDetailsToSession(string password, string userName)
        {
            HttpContext.Current.Session.Add("Pers_Nr", adPasswordProfile.PersNr);
            HttpContext.Current.Session.Add("Pers_FirstName", userName);
            HttpContext.Current.Session.Add("Pers_LastName", "");
            HttpContext.Current.Session.Add("Pers_Name", String.Format("{0}", userName));
            HttpContext.Current.Session.Add("Pers_LoginName", userName);
            HttpContext.Current.Session.Add("Pers_LoginPassword", password);
        }

        public void CheckQStringForLoginAttempt()
        {
            if (HttpContext.Current.Request.QueryString["user"] == null || HttpContext.Current.Request.QueryString["pass"] == null) return;

            string userName = HttpContext.Current.Request.QueryString["user"].Trim();
            string encryptedPassword = HttpContext.Current.Request.QueryString["pass"].Trim();
            string encryptedRedirectLocation = HttpContext.Current.Request.QueryString["moveTo"] != null ? HttpContext.Current.Request.QueryString["moveTo"] : "";

            LoginUser(_encryptionCtl.Decrypt(encryptedPassword), userName,
                (encryptedRedirectLocation == "" ? "" : _encryptionCtl.Decrypt(encryptedRedirectLocation)));
        }

        public void CheckAuthCookie()
        {
            try
            {
                HttpCookie zutAUTH = HttpContext.Current.Request.Cookies["ZUT_AUTH"];

                if (!string.Equals(zutAUTH, "") && !string.Equals(zutAUTH, null))
                {
                    string strAUTH = HttpUtility.UrlDecode(zutAUTH.Value);
                    if (strAUTH.Trim() != "" && strAUTH.Split('#').Length == 2)
                    {
                        string[] userName = strAUTH.Split('#')[0].Split(':');
                        string[] password = strAUTH.Split('#')[1].Split(':');

                        LoginUser(_encryptionCtl.Decrypt(HttpUtility.UrlDecode(password[1])), userName[1],
                            HttpContext.Current.Request.Path.Trim() != "" && !(HttpContext.Current.Request.Path.ToLower().Contains("/login.aspx")) ?
                            HttpContext.Current.Request.Path : "/Index.aspx");
                    }
                }
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Get Permissions
        public PermissionDto2 GetPermissionsById(int id)
        {
            permissionsDto = new PermissionDto2();
            List<AC_PermissionMapping> permissionMappings;
            permissionMappings = _permissionMappingRepository.GetPermissionMappingsByProfileId(id);
            if (permissionMappings == null) { permissionMappings = new List<AC_PermissionMapping>(); return permissionsDto; }

            CheckSuperUser(ref permissionMappings, ref permissionsDto);
            CheckGroupLevelSuperUser(ref permissionMappings, ref permissionsDto);

            CheckAllSettings(ref permissionMappings, ref permissionsDto);
            CheckGateMonitor(ref permissionMappings, ref permissionsDto);
            CheckMasterData(ref permissionMappings, ref permissionsDto);
            CheckVisitorMaster(ref permissionMappings, ref permissionsDto);
            CheckSafetyAndCorrections(ref permissionMappings, ref permissionsDto);
            CheckReports(ref permissionMappings, ref permissionsDto);
            CheckCommunications(ref permissionMappings, ref permissionsDto);

            return permissionsDto;
        }

        private void CheckSuperUser(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.AllServiceStudioEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AllServiceStudio) && x.PermissionType.Equals(1));
            permissionsDto.AllServiceStudioRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AllServiceStudio) && x.PermissionType.Equals(2));

            permissionsDto.AllAccessControlEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AllAccessControl) && x.PermissionType.Equals(1));
            permissionsDto.AllAccessControlRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AllAccessControl) && x.PermissionType.Equals(2));
        }

        public void CheckGroupLevelSuperUser(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.SettingsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Settings) && x.PermissionType.Equals(1));
            permissionsDto.SettingsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Settings) && x.PermissionType.Equals(2));

            permissionsDto.GateMonitorEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitor) && x.PermissionType.Equals(1));
            permissionsDto.GateMonitorRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitor) && x.PermissionType.Equals(2));
        }

        public void CheckAllSettings(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            CheckPersSettings(ref permissionMappings, ref permissionsDto);
            CheckAccessSettings(ref permissionMappings, ref permissionsDto);
            CheckGeneralSettings(ref permissionMappings, ref permissionsDto);
            CheckGroupSettings(ref permissionMappings, ref permissionsDto);
        }

        private void CheckPersSettings(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.PersInactiveEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.PersInactive) && x.PermissionType.Equals(1));
            permissionsDto.PersInactiveRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.PersInactive) && x.PermissionType.Equals(2));

            permissionsDto.MembersInactiveEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersInactive) && x.PermissionType.Equals(1));
            permissionsDto.MembersInactiveRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersInactive) && x.PermissionType.Equals(2));

            permissionsDto.ClientsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Clients) && x.PermissionType.Equals(1));
            permissionsDto.ClientsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Clients) && x.PermissionType.Equals(2));

            permissionsDto.LocationsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Locations) && x.PermissionType.Equals(1));
            permissionsDto.LocationsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Locations) && x.PermissionType.Equals(2));

            permissionsDto.DepartmentEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Department) && x.PermissionType.Equals(1));
            permissionsDto.DepartmentRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Department) && x.PermissionType.Equals(2));

            permissionsDto.CostCentersEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CostCenters) && x.PermissionType.Equals(1));
            permissionsDto.CostCentersRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CostCenters) && x.PermissionType.Equals(2));

            permissionsDto.VisitorFirmsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.VisitorFirms) && x.PermissionType.Equals(1));
            permissionsDto.VisitorFirmsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.VisitorFirms) && x.PermissionType.Equals(2));

            permissionsDto.VehiclesEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Vehicles) && x.PermissionType.Equals(1));
            permissionsDto.VehiclesRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Vehicles) && x.PermissionType.Equals(2));

            permissionsDto.MembersGroupEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersGroup) && x.PermissionType.Equals(1));
            permissionsDto.MembersGroupRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersGroup) && x.PermissionType.Equals(2));

            permissionsDto.MembersContractEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersContract) && x.PermissionType.Equals(1));
            permissionsDto.MembersContractRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersContract) && x.PermissionType.Equals(2));
        }

        private void CheckAccessSettings(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.SettingsAccessProfileEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessProfile) && x.PermissionType.Equals(1));
            permissionsDto.SettingsAccessProfileRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessProfile) && x.PermissionType.Equals(2));

            permissionsDto.SettingsAccessCalenderEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessCalender) && x.PermissionType.Equals(1));
            permissionsDto.SettingsAccessCalenderRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessCalender) && x.PermissionType.Equals(2));

            permissionsDto.SettingsSwitchProfileEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsSwitchProfile) && x.PermissionType.Equals(1));
            permissionsDto.SettingsSwitchProfileRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsSwitchProfile) && x.PermissionType.Equals(2));

            permissionsDto.SettingsHolidayCalenderEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsHolidayCalender) && x.PermissionType.Equals(1));
            permissionsDto.SettingsHolidayCalenderRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsHolidayCalender) && x.PermissionType.Equals(2));

            permissionsDto.SettingsHolidayPlanEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsHolidayPlan) && x.PermissionType.Equals(1));
            permissionsDto.SettingsHolidayPlanRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsHolidayPlan) && x.PermissionType.Equals(2));
        }

        private void CheckGeneralSettings(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.SettingsLanguageEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsLanguage) && x.PermissionType.Equals(1));
            permissionsDto.SettingsLanguageRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsLanguage) && x.PermissionType.Equals(2));

            permissionsDto.SettingsRightsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsRights) && x.PermissionType.Equals(1));
            permissionsDto.SettingsRightsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsRights) && x.PermissionType.Equals(2));

            permissionsDto.SettingsPasswordProfileEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsPasswordProfile) && x.PermissionType.Equals(1));
            permissionsDto.SettingsPasswordProfileRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsPasswordProfile) && x.PermissionType.Equals(2));
        }

        private void CheckGroupSettings(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.SettingsAccessProfileGroupEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessProfileGroup) && x.PermissionType.Equals(1));
            permissionsDto.SettingsAccessProfileGroupRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessProfileGroup) && x.PermissionType.Equals(2));

            permissionsDto.SettingsAccessPlanGroupEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessPlanGroup) && x.PermissionType.Equals(1));
            permissionsDto.SettingsAccessPlanGroupRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SettingsAccessPlanGroup) && x.PermissionType.Equals(2));
        }

        public void CheckGateMonitor(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.GateMonitorPersonnelEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorPersonnel) && x.PermissionType.Equals(1));
            permissionsDto.GateMonitorPersonnelRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorPersonnel) && x.PermissionType.Equals(2));

            permissionsDto.GateMonitorMembersEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorMembers) && x.PermissionType.Equals(1));
            permissionsDto.GateMonitorMembersRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorMembers) && x.PermissionType.Equals(2));

            permissionsDto.GateMonitorVisitorsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorVisitors) && x.PermissionType.Equals(1));
            permissionsDto.GateMonitorVisitorsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorVisitors) && x.PermissionType.Equals(2));

            permissionsDto.GateMonitorDisplayPanelEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorDisplayPanel) && x.PermissionType.Equals(1));
            permissionsDto.GateMonitorDisplayPanelRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorDisplayPanel) && x.PermissionType.Equals(2));

            permissionsDto.GateMonitorInfoEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorInfo) && x.PermissionType.Equals(1));
            permissionsDto.GateMonitorInfoRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.GateMonitorInfo) && x.PermissionType.Equals(2));
        }

        public void CheckMasterData(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.PersActiveEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.PersActive) && x.PermissionType.Equals(1));
            permissionsDto.PersActiveRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.PersActive) && x.PermissionType.Equals(2));

            permissionsDto.MembersActiveEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersActive) && x.PermissionType.Equals(1));
            permissionsDto.MembersActiveRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.MembersActive) && x.PermissionType.Equals(2));

            permissionsDto.BuildingPlanEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.BuildingPlan) && x.PermissionType.Equals(1));
            permissionsDto.BuildingPlanRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.BuildingPlan) && x.PermissionType.Equals(2));

            permissionsDto.AccessGroupEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AccessGroup) && x.PermissionType.Equals(1));
            permissionsDto.AccessGroupRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AccessGroup) && x.PermissionType.Equals(2));

            permissionsDto.AccessPlanEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AccessPlan) && x.PermissionType.Equals(1));
            permissionsDto.AccessPlanRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AccessPlan) && x.PermissionType.Equals(2));

            permissionsDto.SwitchPlanEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SwitchPlan) && x.PermissionType.Equals(1));
            permissionsDto.SwitchPlanRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.SwitchPlan) && x.PermissionType.Equals(2));
        }

        public void CheckVisitorMaster(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.VisitorsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Visitors) && x.PermissionType.Equals(1));
            permissionsDto.VisitorsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Visitors) && x.PermissionType.Equals(2));

            permissionsDto.VisitorApplicationsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.VisitorApplications) && x.PermissionType.Equals(1));
            permissionsDto.VisitorApplicationsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.VisitorApplications) && x.PermissionType.Equals(2));

            permissionsDto.VisitorPlanEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.VisitorPlan) && x.PermissionType.Equals(1));
            permissionsDto.VisitorPlanRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.VisitorPlan) && x.PermissionType.Equals(2));
        }

        public void CheckSafetyAndCorrections(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.GraderEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Grader) && x.PermissionType.Equals(1));
            permissionsDto.GraderRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Grader) && x.PermissionType.Equals(2));

            permissionsDto.DisplayPanelEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.DisplayPanel) && x.PermissionType.Equals(1));
            permissionsDto.DisplayPanelRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.DisplayPanel) && x.PermissionType.Equals(2));

            permissionsDto.AlarmOpenEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AlarmOpen) && x.PermissionType.Equals(1));
            permissionsDto.AlarmOpenRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.AlarmOpen) && x.PermissionType.Equals(2));
        }

        public void CheckReports(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.ReportsEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Reports) && x.PermissionType.Equals(1));
            permissionsDto.ReportsRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.Reports) && x.PermissionType.Equals(2));
        }

        public void CheckCommunications(ref List<AC_PermissionMapping> permissionMappings, ref PermissionDto2 permissionsDto)
        {
            permissionsDto.CommunicationGETEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CommunicationGET) && x.PermissionType.Equals(1));
            permissionsDto.CommunicationGETRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CommunicationGET) && x.PermissionType.Equals(2));

            permissionsDto.CommunicationSENDEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CommunicationSEND) && x.PermissionType.Equals(1));
            permissionsDto.CommunicationSENDRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CommunicationSEND) && x.PermissionType.Equals(2));

            permissionsDto.CommunicationManualEdit = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CommunicationManual) && x.PermissionType.Equals(1));
            permissionsDto.CommunicationManualRead = permissionMappings.Any(x => x.PermissionKey.Equals((int)accessControlPermissions.CommunicationManual) && x.PermissionType.Equals(2));
        }
        #endregion

        public void RedirectToLoginPage()
        {
            CheckAuthCookie();
            HttpContext.Current.Response.Redirect("/Content/Login.aspx");
        }

        public void RedirectToDashoard()
        {
            HttpContext.Current.Response.Redirect("/Index.aspx");
        }

        public void RedirectToSettings()
        {
            HttpContext.Current.Response.Redirect("/Content/Settings.aspx");
        }

        public void SetPromptRedirectPage(string redirectPage)
        {
            HttpContext.Current.Session.Add("Prompt_RedirectPage", redirectPage);
        }

        public void RedirectToPromptPage()
        {
            var redirectPage = HttpContext.Current.Session["Prompt_RedirectPage"];
            if (redirectPage == null) return;
            HttpContext.Current.Session.Remove("Prompt_RedirectPage");
            HttpContext.Current.Response.Redirect(redirectPage.ToString());
        }

        #region Session and Cache Helpers
        public static T LoadSessionItem<T>(string sessionKey)
        {
            T sessionObject = default(T);
            if (HttpContext.Current.Session[sessionKey] != null)
            {
                try
                {
                    sessionObject = (T)HttpContext.Current.Session[sessionKey];
                }
                catch (Exception ex)
                { Debug.WriteLine(ex.Message); }
            }

            return sessionObject;
        }

        public static T LoadCacheItem<T>(string cacheKey)
        {
            T cacheObject = default(T);
            if (HttpRuntime.Cache[cacheKey] != null)
            {
                try
                {
                    cacheObject = (T)HttpRuntime.Cache[cacheKey];
                }
                catch (Exception ex)
                { Debug.WriteLine(ex.Message); }
            }

            return cacheObject;
        }

        public static void InsertCacheItem<T>(string cacheKey, T cacheItem, double expirationTime)
        {
            HttpRuntime.Cache.Insert(cacheKey, cacheItem, null,
                DateTime.Now.AddMinutes(expirationTime), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        #endregion
    }
}