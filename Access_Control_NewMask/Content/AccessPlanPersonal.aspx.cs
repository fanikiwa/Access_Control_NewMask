using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Repositories;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using System.Globalization;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlanPersonal : BasePage
    {
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit,
            Refresh
        }

        static List<AccessGroup> listAccessGroups;
        static List<TbAccessPlan> listAccessPlans;
        private static List<TbAccessPlanPersMapping> _accessPlanPersMappings;
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("AccessPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["AccessPlan_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.AccessPlan, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false;

                btnDeselectAll.Enabled = false; btnSelectAll.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            if (hiddenFieldDetectChanges.Value != null)
            {
                if (hiddenFieldDetectChanges.Value == "999")
                {
                    Response.Redirect("AccessPlan.aspx");
                }
            }
            if (Session["Employee_Profiles"] != null)
            {
                var employeeProfiles = (List<EmployeeProfile>)Session["Employee_Profiles"];
                gridViewEmployee.DataSource = employeeProfiles.OrderBy(x => x.EmpNumber).ToList();
                gridViewEmployee.DataBind();
            }

            if (!(Page.IsPostBack))
            {
                BindAccesssGroups();
                BindAccessProfiles();
                GetPassedData();
                LoadDropDownLists();

                LoadMappedAccessPlans();
            }

            EnableDisableControls();


        }

        #region Private Methods

        private void EnableDisableControls()
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.None:

                    FormNoneMode();

                    break;

                case (int)FormMode.Display:

                    FormDisplayMode();

                    break;

                case (int)FormMode.Create:
                case (int)FormMode.Edit:

                    FormCreateEditMode();

                    break;
            }
        }

        private void FormNoneMode()
        {
            //btnSave.Enabled = false;

            //gridViewEmployee.Enabled = false;
        }

        private void FormDisplayMode()
        {
            //btnSave.Enabled = false;

            //gridViewEmployee.Enabled = false;
        }

        private void FormCreateEditMode()
        {
            //btnSave.Enabled = accessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;

            gridViewEmployee.Enabled = true;
        }

        //void LoadMappedAccessPlans()
        //{
        //    if (string.IsNullOrEmpty(ddlAccessProfileNumber.SelectedValue)) return;
        //    var accessPlanNumber = Convert.ToInt32(ddlAccessProfileNumber.SelectedValue);

        //    _accessPlanPersMappings = new AccessPlanPersMappingViewModel().GetByPlanNumber(accessPlanNumber);

        //    var personalIds = _accessPlanPersMappings.Select(p => p.Pers_Nr).ToList();
        //    var personals = new PersonnelViewModel().GetPersonnels(personalIds);

        //    DisplayPersonnels(personals);

        //    hiddenFieldInitialPersonalsCount.Value = personals.Count.ToString();
        //}
        void LoadMappedAccessPlans()
        {
            if (string.IsNullOrEmpty(ddlAccessProfileNumber.SelectedValue)) return;
            var accessPlanNumber = Convert.ToInt32(ddlAccessProfileNumber.SelectedValue);

            _accessPlanPersMappings = new AccessPlanPersMappingViewModel().GetByPlanNumber(accessPlanNumber);

            var personalIds = _accessPlanPersMappings.Select(p => p.Pers_Nr).ToList();
            var personals = new PersonnelViewModel().GetPersonnels(personalIds).Distinct().ToList();

            DisplayPersonnels(personals);

            hiddenFieldInitialPersonalsCount.Value = personals.Count.ToString();
        }

        //void DisplayPersonnels(List<Personal> personnels)
        //{
        //    var employeeProfiles = new List<EmployeeProfile>();

        //    foreach (var personnel in personnels)
        //    {
        //        var accessPlanPersMapping = _accessPlanPersMappings.Find(p => p.Pers_Nr == personnel.ID);
        //        var isSelected = accessPlanPersMapping != null;

        //        var persDetails = new VwPersonnelDataRepository().GetAllPersonnel().Where(x => x.Pers_Nr == Convert.ToInt64(personnel.Pers_Nr)).FirstOrDefault();
        //        var employeeProfile = new EmployeeProfile
        //        {
        //            ID = personnel.ID,
        //            EmpNumber = personnel.Pers_Nr,
        //            Identification = personnel.Card_Nr,
        //            LastName = personnel.LastName,
        //            FirstName = personnel.FirstName,
        //            LocationName = persDetails.LocationName,
        //            DepartmentName = persDetails.DepartmentName,
        //            CostCenterName = persDetails.CostCenterName,
        //            IsSelected = isSelected
        //        };

        //        employeeProfiles.Add(employeeProfile);
        //    }

        //    gridViewEmployee.DataSource = employeeProfiles;
        //    gridViewEmployee.DataBind();

        //    hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString();
        //    EnableDisableControls();
        //}
        void DisplayPersonnels(List<VwPersonnelData> personnels)
        {
            var employeeProfiles = new List<EmployeeProfile>();

            foreach (var personnel in personnels)
            {
                var accessPlanPersMapping = _accessPlanPersMappings.Find(p => p.Pers_Nr == personnel.Pers_Nr);
                var isSelected = accessPlanPersMapping != null;

                var persDetails = new VwPersonnelDataRepository().GetAllPersonnel().Where(x => x.Pers_Nr == Convert.ToInt64(personnel.Pers_Nr)).FirstOrDefault();
                var employeeProfile = new EmployeeProfile
                {
                    ID = personnel.ID,
                    EmpNumber = personnel.Pers_Nr,
                    Identification = personnel.Card_Nr,
                    LastName = personnel.LastName,
                    FirstName = personnel.FirstName,
                    LocationName = persDetails.LocationName,
                    DepartmentName = persDetails.DepartmentName,
                    CostCenterName = persDetails.CostCenterName,
                    IsSelected = isSelected
                };

                employeeProfiles.Add(employeeProfile);
            }

            if (employeeProfiles.Count > 23)
            {
                gridViewEmployee.SettingsPager.PageSize = employeeProfiles.Count;
            }

            gridViewEmployee.DataSource = employeeProfiles.OrderBy(x => x.EmpNumber).ToList();
            gridViewEmployee.DataBind();
            Session["Employee_Profiles"] = employeeProfiles.OrderBy(x => x.EmpNumber).ToList();

            hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString();
            EnableDisableControls();
        }

        void LoadDropDownLists()
        {
            string noSelectionText = "Keine";
            string noSelectionTextNumber = "0";
            string noSelectionValue = "-1";

            var activePersonnels = new PersonnelViewModel().GetPersonnels().OrderBy(x => x.Pers_Nr).ToList();
            KruAll.Core.Models.Personal pers = new KruAll.Core.Models.Personal() { ID = 0, Pers_Nr = 0, FirstName = "keine", LastName = "keine" };
            activePersonnels.Add(pers);
            ddlActiveEmployeeFrom.DataSource = activePersonnels.OrderBy(x => x.Pers_Nr);
            ddlActiveEmployeeFrom.DataBind();
            ddlActiveEmployeeFrom.SelectedIndex = 0;

            //ddlActiveEmployeeFrom.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionTextNumber, noSelectionValue));
            //ddlActiveEmployeeFrom.Value = noSelectionValue;

            ddlActiveEmployeeTo.DataSource = activePersonnels.OrderBy(x => x.Pers_Nr);
            ddlActiveEmployeeTo.DataBind();
            ddlActiveEmployeeTo.SelectedIndex = 0;

            //ddlActiveEmployeeTo.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionTextNumber, noSelectionValue));
            //ddlActiveEmployeeTo.Value = noSelectionValue;

            var locations = new LocationViewModel().GetLocations();
            Location loc = new Location() { ID = 0, Location_Nr = 0, Name = "keine" };
            locations.Add(loc);
            ddlLocationFrom.DataSource = locations.OrderBy(x => x.Location_Nr);
            ddlLocationFrom.DataBind();
            ddlLocationFrom.SelectedIndex = 0;

            //ddlLocationFrom.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionText, noSelectionValue));
            //ddlLocationFrom.Value = noSelectionValue;

            ddlLocationTo.DataSource = locations.OrderBy(x => x.Location_Nr);
            ddlLocationTo.DataBind();
            ddlLocationTo.SelectedIndex = 0;

            //ddlLocationTo.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionText, noSelectionValue));
            //ddlLocationTo.Value = noSelectionValue;

            var departments = new DepartmentViewModel().Departments();
            Department dep = new Department() { ID = 0, Department_Nr = 0, Name = "keine" };
            departments.Add(dep);
            ddlDepartmentFrom.DataSource = departments.OrderBy(x => x.Department_Nr);
            ddlDepartmentFrom.DataBind();
            ddlDepartmentFrom.SelectedIndex = 0;

            //ddlDepartmentFrom.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionText, noSelectionValue));
            //ddlDepartmentFrom.Value = noSelectionValue;

            ddlDepartmentTo.DataSource = departments.OrderBy(x => x.Department_Nr);
            ddlDepartmentTo.DataBind();
            ddlDepartmentTo.SelectedIndex = 0;

            //ddlDepartmentTo.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionText, noSelectionValue));
            //ddlDepartmentTo.Value = noSelectionValue;

            var costCentres = new CostcenterViewModel().Costcenters();
            CostCenter cost = new CostCenter() { ID = 0, CostCenter_Nr = 0, Name = "keine" };
            costCentres.Add(cost);
            ddlCostCentreFrom.DataSource = costCentres.OrderBy(x => x.CostCenter_Nr);
            ddlCostCentreFrom.DataBind();
            ddlCostCentreFrom.SelectedIndex = 0;

            //ddlCostCentreFrom.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionText, noSelectionValue));
            //ddlCostCentreFrom.Value = noSelectionValue;

            ddlCostCentreTo.DataSource = costCentres.OrderBy(x => x.CostCenter_Nr);
            ddlCostCentreTo.DataBind();
            ddlCostCentreTo.SelectedIndex = 0;

            //ddlCostCentreTo.Items.Insert(0,new DevExpress.Web.ListEditItem(noSelectionText, noSelectionValue));
            //ddlCostCentreTo.Value = noSelectionValue;
        }

        [WebMethod]
        public static void SaveAccessPlanPersonal(long accessPlanNumber, int locationId, List<KruAll.Core.Models.Personal> personals)
        {
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByNr(accessPlanNumber);

            if (accessPlan == null) return;

            var selectedLocationId = locationId > 0 ? (int?)locationId : null;

            //remove all employees from the plan first
            var employeeProfiles = new AccessPlanPersMappingViewModel().GetByPlanNumber(accessPlan.ID);
            foreach (var employeeProfile in employeeProfiles)
            {
                new AccessPlanPersMappingViewModel().DeleteMappingCustom(employeeProfile);
            }

            if ((personals == null) || !(personals.Any())) return;

            var uniqueEmployees = personals.GroupBy(p => p.Pers_Nr).Select(group => group.First()).ToList();

            foreach (var employee in uniqueEmployees)
            {
                DateTime? dateFrom = null;
                DateTime? dateTo = null;
                string automaticLogout = null;

                var existingDetails = employeeProfiles.Find(x => x.Pers_Nr == employee.Pers_Nr);
                if (existingDetails != null)
                {
                    dateFrom = existingDetails.DateFrom != null ? existingDetails.DateFrom : null;
                    dateTo = existingDetails.DateTo != null ? existingDetails.DateTo : null;
                    automaticLogout = existingDetails.AutomaticLogout != null ? existingDetails.AutomaticLogout : null;
                }
                var mapping = new TbAccessPlanPersMapping
                {
                    AccessPlan_Nr = accessPlan.ID,
                    Pers_Nr = employee.Pers_Nr,
                    Location_ID = selectedLocationId,
                    DateFrom = dateFrom,
                    DateTo = dateTo,
                    AutomaticLogout = automaticLogout

                };

                new AccessPlanPersMappingViewModel().CreateMapping(mapping);
            }

        }

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        #endregion Private Methods

        #region Button Methods

        protected void btnBack_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.Display:
                case (int)FormMode.None:
                    Session["SwitchPlan"] = null;
                    Response.Redirect("/Content/AccessPlan.aspx");

                    break;

                case (int)FormMode.Create:
                case (int)FormMode.Edit:
                    int detectedChanges = 0;
                    if (!string.IsNullOrEmpty(hiddenFieldDetectChanges.Value))
                    {
                        if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
                            hiddenFieldDetectChanges.Value = "0";

                        detectedChanges = Convert.ToInt32(hiddenFieldDetectChanges.Value);
                    }

                    switch (detectedChanges)
                    {
                        case 0:
                            Session["SwitchPlan"] = null;
                            Response.Redirect("/Content/AccessPlan.aspx");

                            break;

                        case 1:
                            ClientScript.RegisterStartupScript(GetType(), "BackButtonConfirm", "BackButtonConfirm();", true);

                            break;
                    }

                    break;
            }
        }

        #endregion Button Methods

        #region GridView Methods

        protected void gridViewEmployee_OnDataBound(object sender, EventArgs e)
        {
            for (var i = 0; i < gridViewEmployee.VisibleRowCount; i++)
            {
                var isSelected = Convert.ToBoolean(gridViewEmployee.GetRowValues(i, "IsSelected"));
                gridViewEmployee.Selection.SetSelection(i, isSelected);
            }
        }

        protected void gridViewEmployee_OnCustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            var i = e.Parameters;
            if (e.Parameters == "1")
            {
                var activeEmployeeFrom = ddlActiveEmployeeFrom.Value == null ? 0 : Convert.ToInt32(ddlActiveEmployeeFrom.Text);
                var activeEmployeeTo = ddlActiveEmployeeTo.Value == null ? 0 : Convert.ToInt32(ddlActiveEmployeeTo.Text);
                var locationFrom = ddlLocationFrom.Value == null ? 0 : Convert.ToInt32(ddlLocationFrom.Value);
                var locationTo = ddlLocationTo.Value == null ? 0 : Convert.ToInt32(ddlLocationTo.Value);
                var departmentFrom = ddlDepartmentFrom.Value == null ? 0 : Convert.ToInt32(ddlDepartmentFrom.Value);
                var departmentTo = ddlDepartmentTo.Value == null ? 0 : Convert.ToInt32(ddlDepartmentTo.Value);
                var costCentreFrom = ddlCostCentreFrom.Value == null ? 0 : Convert.ToInt32(ddlCostCentreFrom.Value);
                var costCentreTo = ddlCostCentreTo.Value == null ? 0 : Convert.ToInt32(ddlCostCentreTo.Value);

                var personnels = new PersonnelViewModel().GetPersonnels(activeEmployeeFrom, activeEmployeeTo, locationFrom, locationTo, departmentFrom, departmentTo, costCentreFrom, costCentreTo);

                DisplayPersonnels(personnels);
            }
            else if (e.Parameters == "0")
            {
                LoadMappedAccessPlans();
            }


        }


        #endregion GridView Methods

        #region get passed data
        protected void GetPassedData()
        {
            if (Session["ProfileID"] == null)
            {
                Response.Redirect("~/Content/AccessPlan.aspx");
            }
            if (Session["AccessProfileNumber"] == null)
            {
                Response.Redirect("~/Content/AccessPlan.aspx");
            }

            ddlAccessGroupNumber.SelectedValue = Session["GroupID"].ToString();
            ddlAccessGroupName.SelectedValue = Session["GroupID"].ToString();
            ddlAccessProfileNumber.SelectedValue = Session["ProfileID"].ToString();
            ddlAccessProfileName.SelectedValue = Session["ProfileID"].ToString();
            txtAccessGroupNumber.Text = Session["AccessGroupNumber"].ToString();
            txtAccessGroupName.Text = Session["AccessGroupName"].ToString();
            txtAccessProfileNumber.Text = Session["AccessProfileNumber"].ToString();
            txtAccessProfileName.Text = Session["AccessProfileName"].ToString();

        }
        public void LoadExistingGroups(ref List<AccessGroup> listAccessGroups)
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            listAccessGroups.AddRange(accessGroups.GetAllAccessProfileGroups().Where(x => x.AccessGroupType == 1));
        }
        public void LoadAccessPlansByGroupID(ref List<TbAccessPlan> listAccessPlans)
        {

            //long groupId = Convert.ToInt32(ddlAccessGroupNumber.SelectedValue);
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
            //listAccessPlans.AddRange(accessPlans.GetAllAccessPlans().Where(x => x.AccessGroupID == groupId));

        }
        protected void BindAccesssGroups()
        {
            listAccessGroups = new List<AccessGroup>();
            LoadExistingGroups(ref listAccessGroups);

            ddlAccessGroupNumber.DataSource = listAccessGroups;
            ddlAccessGroupNumber.DataBind();

            ddlAccessGroupName.DataSource = listAccessGroups;
            ddlAccessGroupName.DataBind();
        }
        protected void BindAccessProfiles()
        {
            listAccessPlans = new List<TbAccessPlan>();
            LoadAccessPlansByGroupID(ref listAccessPlans);
            ddlAccessProfileNumber.DataSource = listAccessPlans;
            ddlAccessProfileNumber.DataBind();
            ddlAccessProfileName.DataSource = listAccessPlans;
            ddlAccessProfileName.DataBind();
        }
        #endregion passed data

        protected void btnInformation_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("/Content/AccessPlan.aspx");

        }
    }
}