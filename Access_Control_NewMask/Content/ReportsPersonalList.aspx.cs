using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;
using System.Web.Services;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class ReportPersonalList : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Reports_PMode");
            }
            set
            {
                HttpContext.Current.Session["Reports_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Reports, out _AccessControlPermissionMode))
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

            _initializeReportViewer();
            if (!IsPostBack)
            {
                LoadCompanies();
                LoadLocations();
                LoadDepartmemts();
                LoadPeronnel();
                LoadDefaultCheck();
                //LoadPersonalType();
                _bindSavedList();

                string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
                string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

                var logedInUser = String.Format("{0} {1}", firstName, lastName);

                lblPersName.Text = logedInUser;
                lblPersNameB.Text = logedInUser;
                lblPersNameC.Text = logedInUser;
                lblPersNameD.Text = logedInUser;

                grdSavedPersonalList.FocusedRowIndex = -1;
            }
        }
        protected void LoadDefaultCheck()
        {
            chkActivePersonal.Checked = true;
            chkPersName.Checked = true;
            chkVariableD.Checked = true;

            chkLandScapeA.Checked = true;
            chkLandScapeB.Checked = true;
            chkLandScapeC.Checked = true;
            chkLandScapeD.Checked = true;
        }
        protected void LoadPersonalType(string reportSettingsJSONData)
        {
            PersonalReportsListSettingsDto _AC_Reports = new PersonalReportsListSettingsDto();


            List<PersonalReportsListSettingsDto> acReports = JsonConvert.DeserializeObject<List<PersonalReportsListSettingsDto>>(reportSettingsJSONData);

            if (acReports.Count > 0)
            {
                _AC_Reports = acReports[0];
                _displayGridOverFilterselection(_AC_Reports);
            }


            if (chkActivePersonal.Checked == true)
            {
                GetActivePersonalDetails(_AC_Reports);
            }
            if (chkInactivePersonal.Checked == true)
            {
                GetPersonalInactiveDetails(_AC_Reports);
            }
        }
        private void _initializeReportViewer()
        {
            if (chkVariableA.Checked)
            {
                if (chkPotraitA.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarAPotrait());
                }
                if (chkLandScapeA.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarA());
                }
            }
            if (chkVariableB.Checked)
            {
                if (chkPotraitB.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarBPotrait());
                }
                if (chkLandScapeB.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarB());
                }
                // PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarB());
            }
            if (chkVariableC.Checked)
            {
                if (chkPotraitC.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarCPotrait());
                }
                if (chkLandScapeC.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarC());
                }
                // PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarC());
            }
            if (chkVariableD.Checked)
            {
                if (chkPotraitD.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarDPotrait());
                }
                if (chkLandScapeD.Checked)
                {
                    PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarD());
                }
                // PersonalListLocalASPxDocumentViewer.OpenReport(new PersonalReportListVarD());
            }
        }
        protected void LoadCompanies()
        {
            List<Client> companiesList = new List<Client>();
            Client company = new Client() { ID = 0, Client_Nr = 0, Name = "keine Auswahl" };
            var companies = new ClientsRepository().GetClients().OrderBy(x => x.Client_Nr).ToList();
            companiesList.Add(company);
            companiesList.AddRange(companies);
            cboCompanyFrom.DataSource = companiesList;
            cboCompanyFrom.DataBind();
            cboCompanyFrom.SelectedIndex = 0;
            cboCompanyTo.DataSource = companiesList;
            cboCompanyTo.DataBind();
            cboCompanyTo.SelectedIndex = 0;
        }
        protected void LoadLocations()
        {
            List<Location> locationList = new List<Location>();
            Location location = new Location() { ID = 0, Location_Nr = 0, Name = "keine Auswahl" };
            var locations = new LocationRepository().GetLocations().OrderBy(x => x.Location_Nr).ToList();
            locationList.Add(location);
            locationList.AddRange(locations);
            cboLocationFrom.DataSource = locationList;
            cboLocationFrom.DataBind();
            cboLocationFrom.SelectedIndex = 0;
            cboLocationTo.DataSource = locationList;
            cboLocationTo.DataBind();
            cboLocationTo.SelectedIndex = 0;
        }
        protected void LoadDepartmemts()
        {
            List<Department> departmentList = new List<Department>();
            Department department = new Department() { ID = 0, Department_Nr = 0, Name = "keine Auswahl" };
            var departments = new DepartmentRepository().GetDepartments().OrderBy(x => x.Department_Nr).ToList();
            departmentList.Add(department);
            departmentList.AddRange(departments);
            cboDepartmentFrom.DataSource = departmentList;
            cboDepartmentFrom.DataBind();
            cboDepartmentFrom.SelectedIndex = 0;
            cboDepartmentTo.DataSource = departmentList;
            cboDepartmentTo.DataBind();
            cboDepartmentTo.SelectedIndex = 0;
        }
        protected void LoadPeronnel()
        {
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            //PersonnelDto personnel = new PersonnelDto() { ID = 0, Pers_Nr = 0, FirstName = "keine Auswahl" };
            var employees = new PersonalViewModel().GetAllActivePersonnel().OrderBy(x => x.Pers_Nr).ToList();
            //personnelList.Add(personnel);
            personnelList.AddRange(employees);
            cboPersNameFrom.DataSource = personnelList;
            cboPersNameFrom.DataBind();
            cboPersNameFrom.SelectedIndex = 0;
            cbopersNameTo.DataSource = personnelList;
            cbopersNameTo.DataBind();
            cbopersNameTo.SelectedIndex = 0;
            cboPersIdFrom.DataSource = personnelList;
            cboPersIdFrom.DataBind();
            cboPersIdFrom.SelectedIndex = 0;
            cboPersIdTo.DataSource = personnelList;
            cboPersIdTo.DataBind();
            cboPersIdTo.SelectedIndex = 0;
        }

        protected void OneTodayCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        private void _displayGridOverFilterselection(PersonalReportsListSettingsDto acReport)
        {
            VwPersonnelDataRepository personnelData = new VwPersonnelDataRepository();
            List<PersonalReportsListDto> persReportList = new List<PersonalReportsListDto>();

            if (acReport.PersonalType == 1)
            {
                persReportList = GetActivePersonalDetails(acReport);
            }
            if (acReport.PersonalType == 2)
            {
                persReportList = GetPersonalInactiveDetails(acReport);
            }


            //persReportList.AddRange(personnelData.GetAllPersonnel().Where(x => x.Active == true).ToList())); 

            const int OBJECT_PRINT_TYPE = 0;
            const int VARB_PRINT_TYPE = 1;
            const int VARC_PRINT_TYPE = 2;
            const int VARD_PRINT_TYPE = 3;

            switch (acReport.ReportType)
            {
            case OBJECT_PRINT_TYPE:
                grdShowReport.Columns["ClientName"].Visible = acReport.DisplayClient;
                grdShowReport.Columns["Location"].Visible = acReport.DisplayLocation;
                grdShowReport.Columns["DepartmentName"].Visible = acReport.DisplayDepartment;
                grdShowReport.Columns["FullName"].Visible = acReport.DisplayName;
                grdShowReport.Columns["Pers_Nr"].Visible = acReport.DisplayPersonalID;
                grdShowReport.Columns["Place"].Visible = acReport.DisplayPlace;
                grdShowReport.Columns["PostalCode"].Visible = acReport.DisplayPostalCode;
                grdShowReport.Columns["StreetNrAndName"].Visible = acReport.DisplayStreetAndNr;
                grdShowReport.Columns["DateOfBirth"].Visible = acReport.DisplayDateOfBirth;
                grdShowReport.Columns["EntryDate"].Visible = acReport.DisplayEnrtyDate;
                grdShowReport.Columns["ExitDate"].Visible = acReport.DisplayExitDate;

                grdShowReport.Columns["EmploymentPosition"].Visible = acReport.DisplayEmployedAs;

                grdShowReport.Columns["Nationality"].Visible = acReport.DisplayNationality;
                grdShowReport.Columns["CompanyPhone"].Visible = acReport.DisplayCompanyTelephone;
                grdShowReport.Columns["CompanyMobile"].Visible = acReport.DisplayCompanyMobile;
                grdShowReport.Columns["PrivatePhone"].Visible = acReport.DisplayPrivateTelephone;
                grdShowReport.Columns["PrivateMobile"].Visible = acReport.DisplayPrivateMobile;

                grdShowReport.Columns["AusweisNr"].Visible = acReport.DisplayLongTermCard;
                grdShowReport.Columns["AusweisNrShortTerm"].Visible = acReport.DisplayShortTermCard;
                grdShowReport.Columns["AuthorisedBy"].Visible = acReport.DisplayAccessAuthorization;

                grdShowReport.Columns["AccessPlanNr"].Visible = acReport.DisplayAccessPlanNr;
                grdShowReport.Columns["AccessPlanDescription"].Visible = acReport.DisplayAccessPlanDescription;


                grdShowReport.DataSource = persReportList;
                grdShowReport.DataBind();

                if (persReportList.Count() > 32)
                {
                    grdShowReport.SettingsPager.PageSize = persReportList.Count();
                }
                else
                {
                    grdShowReport.SettingsPager.PageSize = 32;
                }
                break;
            case VARB_PRINT_TYPE:
                grdMainPersInfo.DataSource = persReportList;
                grdMainPersInfo.DataBind();

                grdMainPersInfo.Columns["ClientName"].Visible = acReport.DisplayClient;
                grdMainPersInfo.Columns["Location"].Visible = acReport.DisplayLocation;
                grdMainPersInfo.Columns["DepartmentName"].Visible = acReport.DisplayDepartment;
                grdMainPersInfo.Columns["FullName"].Visible = acReport.DisplayName;
                grdMainPersInfo.Columns["Pers_Nr"].Visible = acReport.DisplayPersonalID;
                grdMainPersInfo.Columns["Place"].Visible = acReport.DisplayPlace;
                grdMainPersInfo.Columns["PostalCode"].Visible = acReport.DisplayPostalCode;
                grdMainPersInfo.Columns["StreetNrAndName"].Visible = acReport.DisplayStreetAndNr;
                grdMainPersInfo.Columns["DateOfBirth"].Visible = acReport.DisplayDateOfBirth;
                grdMainPersInfo.Columns["EntryDate"].Visible = acReport.DisplayEnrtyDate;
                grdMainPersInfo.Columns["ExitDate"].Visible = acReport.DisplayExitDate;

                grdMainPersInfo.Columns["EmploymentPosition"].Visible = acReport.DisplayEmployedAs;

                grdMainPersInfo.Columns["Nationality"].Visible = acReport.DisplayNationality;
                grdMainPersInfo.Columns["CompanyPhone"].Visible = acReport.DisplayCompanyTelephone;
                grdMainPersInfo.Columns["CompanyMobile"].Visible = acReport.DisplayCompanyMobile;
                grdMainPersInfo.Columns["PrivatePhone"].Visible = acReport.DisplayPrivateTelephone;
                grdMainPersInfo.Columns["PrivateMobile"].Visible = acReport.DisplayPrivateMobile;

                grdMainPersInfo.Columns["AusweisNr"].Visible = acReport.DisplayLongTermCard;
                grdMainPersInfo.Columns["AusweisNrShortTerm"].Visible = acReport.DisplayShortTermCard;
                grdMainPersInfo.Columns["AuthorisedBy"].Visible = acReport.DisplayAccessAuthorization;

                grdMainPersInfo.Columns["AccessPlanNr"].Visible = acReport.DisplayAccessPlanNr;
                grdMainPersInfo.Columns["AccessPlanDescription"].Visible = acReport.DisplayAccessPlanDescription;

                if (persReportList.Count() > 32)
                {
                    grdMainPersInfo.SettingsPager.PageSize = persReportList.Count();
                }
                else
                {
                    grdMainPersInfo.SettingsPager.PageSize = 32;
                }
                break;
            case VARC_PRINT_TYPE:
                grdVaribleC.DataSource = persReportList;
                grdVaribleC.DataBind();

                grdVaribleC.Columns["ClientName"].Visible = acReport.DisplayClient;
                grdVaribleC.Columns["Location"].Visible = acReport.DisplayLocation;
                grdVaribleC.Columns["DepartmentName"].Visible = acReport.DisplayDepartment;
                grdVaribleC.Columns["FullName"].Visible = acReport.DisplayName;
                grdVaribleC.Columns["Pers_Nr"].Visible = acReport.DisplayPersonalID;
                grdVaribleC.Columns["Place"].Visible = acReport.DisplayPlace;
                grdVaribleC.Columns["PostalCode"].Visible = acReport.DisplayPostalCode;
                grdVaribleC.Columns["StreetNrAndName"].Visible = acReport.DisplayStreetAndNr;
                grdVaribleC.Columns["DateOfBirth"].Visible = acReport.DisplayDateOfBirth;
                grdVaribleC.Columns["EntryDate"].Visible = acReport.DisplayEnrtyDate;
                grdVaribleC.Columns["ExitDate"].Visible = acReport.DisplayExitDate;

                grdVaribleC.Columns["EmploymentPosition"].Visible = acReport.DisplayEmployedAs;

                grdVaribleC.Columns["Nationality"].Visible = acReport.DisplayNationality;
                grdVaribleC.Columns["CompanyPhone"].Visible = acReport.DisplayCompanyTelephone;
                grdVaribleC.Columns["CompanyMobile"].Visible = acReport.DisplayCompanyMobile;
                grdVaribleC.Columns["PrivatePhone"].Visible = acReport.DisplayPrivateTelephone;
                grdVaribleC.Columns["PrivateMobile"].Visible = acReport.DisplayPrivateMobile;

                grdVaribleC.Columns["AusweisNr"].Visible = acReport.DisplayLongTermCard;
                grdVaribleC.Columns["AusweisNrShortTerm"].Visible = acReport.DisplayShortTermCard;
                grdVaribleC.Columns["AuthorisedBy"].Visible = acReport.DisplayAccessAuthorization;

                grdVaribleC.Columns["AccessPlanNr"].Visible = acReport.DisplayAccessPlanNr;
                grdVaribleC.Columns["AccessPlanDescription"].Visible = acReport.DisplayAccessPlanDescription;

                if (persReportList.Count() > 32)
                {
                    grdVaribleC.SettingsPager.PageSize = persReportList.Count();
                }
                else
                {
                    grdVaribleC.SettingsPager.PageSize = 32;
                }
                break;
            case VARD_PRINT_TYPE:
                grdVaribleD.DataSource = persReportList;
                grdVaribleD.DataBind();

                grdVaribleD.Columns["ClientName"].Visible = acReport.DisplayClient;
                grdVaribleD.Columns["Location"].Visible = acReport.DisplayLocation;
                grdVaribleD.Columns["DepartmentName"].Visible = acReport.DisplayDepartment;
                grdVaribleD.Columns["FullName"].Visible = acReport.DisplayName;
                grdVaribleD.Columns["Pers_Nr"].Visible = acReport.DisplayPersonalID;
                grdVaribleD.Columns["Place"].Visible = acReport.DisplayPlace;
                grdVaribleD.Columns["PostalCode"].Visible = acReport.DisplayPostalCode;
                grdVaribleD.Columns["StreetNrAndName"].Visible = acReport.DisplayStreetAndNr;
                grdVaribleD.Columns["DateOfBirth"].Visible = acReport.DisplayDateOfBirth;
                grdVaribleD.Columns["EntryDate"].Visible = acReport.DisplayEnrtyDate;
                grdVaribleD.Columns["ExitDate"].Visible = acReport.DisplayExitDate;

                grdVaribleD.Columns["EmploymentPosition"].Visible = acReport.DisplayEmployedAs;

                grdVaribleD.Columns["Nationality"].Visible = acReport.DisplayNationality;
                grdVaribleD.Columns["CompanyPhone"].Visible = acReport.DisplayCompanyTelephone;
                grdVaribleD.Columns["CompanyMobile"].Visible = acReport.DisplayCompanyMobile;
                grdVaribleD.Columns["PrivatePhone"].Visible = acReport.DisplayPrivateTelephone;
                grdVaribleD.Columns["PrivateMobile"].Visible = acReport.DisplayPrivateMobile;

                grdVaribleD.Columns["AusweisNr"].Visible = acReport.DisplayLongTermCard;
                grdVaribleD.Columns["AusweisNrShortTerm"].Visible = acReport.DisplayShortTermCard;
                grdVaribleD.Columns["AuthorisedBy"].Visible = acReport.DisplayAccessAuthorization;

                grdVaribleD.Columns["AccessPlanNr"].Visible = acReport.DisplayAccessPlanNr;
                grdVaribleD.Columns["AccessPlanDescription"].Visible = acReport.DisplayAccessPlanDescription;

                if (persReportList.Count() > 32)
                {
                    grdVaribleD.SettingsPager.PageSize = persReportList.Count();
                }
                else
                {
                    grdVaribleD.SettingsPager.PageSize = 32;
                }
                break;
            }

            string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
            string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

            var logedInUser = String.Format("{0} {1}", firstName, lastName);

            persReportList.Select(c => { c.LoggedInUser = logedInUser; return c; }).ToList();

            persReportList.Select(c => { c.VariableTextType = acReport.VariableText; return c; }).ToList();

            HttpContext.Current.Session["PersonalistDto"] = persReportList;
            HttpContext.Current.Session["PersonalacReport"] = acReport;
        }

        public List<PersonalReportsListDto> GetActivePersonalDetails(PersonalReportsListSettingsDto acReport)
        {
            List<PersonalReportsListDto> personnelData = new List<PersonalReportsListDto>();

            var personnels = new VwPersonnelDataRepository().GetAllPersonnel().Where(x => x.Active == true).ToList();

             


            if (acReport.StartLocation > 0)
            {
                personnels = personnels.Where(x => x.LocationID >= acReport.StartLocation && x.LocationID <= acReport.EndLocation).ToList();

            }
            if (acReport.StartClient > 0)
            {
                personnels = personnels.Where(x => x.ClientID >= acReport.StartClient && x.ClientID <= acReport.EndClient).ToList();

            }

            if (acReport.StartPersID > 0)
            {
                personnels = personnels.Where(x => x.Pers_Nr >= acReport.StartPersonal && x.Pers_Nr <= acReport.EndPersonal).ToList();

            }

            if (acReport.StartDept > 0)
            {
                personnels = personnels.Where(x => x.DepartmentID >= acReport.StartDept && x.DepartmentID <= acReport.EndDept).ToList();

            }

            var pers_AccessPlans = new AccessPlanPersMappingRepository().GetAllMappings().ToList();
            var all_zut_plans = new AccessPlanRepository().GetAllAccessPlans().ToList();
           

            foreach (var person in personnels)
            {
                 
                PersonalReportsListDto _personnel = new PersonalReportsListDto();
                _personnel.ID = person.ID;
                _personnel.FullName = person.FullName;
                _personnel.FirstName = person.FirstName;
                _personnel.LastName = person.LastName;
                _personnel.ClientName = person.ClientName;
                _personnel.Location = person.LocationName;
                _personnel.DepartmentName = person.DepartmentName;
                _personnel.Pers_Nr = person.Pers_Nr;
                _personnel.Place = person.PhysicalAddress;
                _personnel.PostalCode = person.PostalCode;
                _personnel.DateOfBirth = person.DOB;
                _personnel.EntryDate = person.EntryDate;
                _personnel.ExitDate = person.ExitDate;
                _personnel.PrivateMobile = person.PrivateMobile;
                _personnel.PrivatePhone = person.PrivateTel;
                _personnel.Nationality = person.Nationality;
                _personnel.AuthorisedBy = person.AuthorisedBy;
                _personnel.CompanyMobile = person.CompanyMobile;
                _personnel.CompanyPhone = person.CompanyTel;
                var strtnameAndNr = person.StreetNr + " " + person.Street;
                _personnel.StreetNrAndName = strtnameAndNr;
                _personnel.EmploymentPosition = person.EmployedAs;
                _personnel.AusweisNr = person.Card_Nr.ToString();
                _personnel.AusweisNrShortTerm = person.Card_Nr.ToString();

                #region MyRegion
                ////check out for this//
                acReport.StartClient = Convert.ToInt32(person.ClientID);
                acReport.EndClient = Convert.ToInt32(person.ClientID);

                acReport.StartLocation = Convert.ToInt32(person.LocationID);
                acReport.EndLocation = Convert.ToInt32(person.LocationID);

                acReport.StartDept = Convert.ToInt32(person.DepartmentID);
                acReport.EndDept = Convert.ToInt32(person.DepartmentID);

                _personnel.PersLocationFrom = acReport.StartLocation.ToString();
                _personnel.PersLocationTo = acReport.EndLocation.ToString();

                _personnel.PersDepartmentFrom = acReport.StartDept.ToString();
                _personnel.PersDepartmentTo = acReport.EndDept.ToString();

                _personnel.PersClientFrom = acReport.StartClient.ToString();
                _personnel.PersClientTo = acReport.EndClient.ToString();

                


                //acReport.StartPersID = Convert.ToInt32(person.Pers_Nr);
                //acReport.EndPersID = Convert.ToInt32(person.Pers_Nr);
                #endregion

                var locationFrom = (new LocationRepository().GetLocations().Where(x => x.ID == acReport.StartLocation).FirstOrDefault() ?? new Location()).Name;
                var locationTo = (new LocationRepository().GetLocations().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Location()).Name;
                var DepartMentFrom = (new DepartmentRepository().GetDepartments().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Department()).Name;
                var DepartmentTo = (new DepartmentRepository().GetDepartments().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Department()).Name;
                var startCompany = (new ClientsRepository().GetClients().Where(x => x.ID == acReport.StartClient).FirstOrDefault() ?? new Client()).Name;
                var endCompany = (new ClientsRepository().GetClients().Where(x => x.ID == acReport.EndClient).FirstOrDefault() ?? new Client()).Name;

                _personnel.PersLocationFrom = locationFrom;
                _personnel.PersLocationTo = locationTo;

                _personnel.PersDepartmentFrom = DepartMentFrom;
                _personnel.PersDepartmentTo = DepartmentTo;

                _personnel.PersClientFrom = startCompany;
                _personnel.PersClientTo = endCompany;

                var pers_ZutPlan = pers_AccessPlans.Where(x => x.Pers_Nr == _personnel.Pers_Nr).FirstOrDefault();

                if (pers_ZutPlan != null)
                {
                    var accessPlan = all_zut_plans.Where(x => x.ID == pers_ZutPlan.AccessPlan_Nr).FirstOrDefault();

                    if(accessPlan != null)
                    {
                        _personnel.AccessPlanNr = accessPlan.AccessPlanNr;
                        _personnel.AccessPlanDescription = accessPlan.AccessPlanDescription;
                        _personnel.AccessPlanDateFrom  = pers_ZutPlan.DateFrom;
                        _personnel.AccessPlanDateTo = pers_ZutPlan.DateTo;
                    }
                }

                personnelData.Add(_personnel);
            }
            grdMainPersInfo.DataSource = personnelData;
            grdMainPersInfo.DataBind();

            grdVaribleC.DataSource = personnelData;
            grdVaribleC.DataBind();

            grdShowReport.DataSource = personnelData;
            grdShowReport.DataBind();

            grdVaribleD.DataSource = personnelData;
            grdVaribleD.DataBind();

            if (personnelData.Count() > 13)
            {
                grdMainPersInfo.SettingsPager.PageSize = personnelData.Count();
                grdVaribleC.SettingsPager.PageSize = personnelData.Count();
                grdShowReport.SettingsPager.PageSize = personnelData.Count();
                grdVaribleD.SettingsPager.PageSize = personnelData.Count();
            }
            else
            {
                grdMainPersInfo.SettingsPager.PageSize = 13;
                grdVaribleC.SettingsPager.PageSize = 13;
                grdShowReport.SettingsPager.PageSize = 13;
                grdVaribleD.SettingsPager.PageSize = 13;
            }
            HttpContext.Current.Session["PersData"] = personnelData;
            return personnelData;
        }

        public List<PersonalReportsListDto> GetPersonalInactiveDetails(PersonalReportsListSettingsDto acReport)
        {
            List<PersonalReportsListDto> personnelData = new List<PersonalReportsListDto>();

            var inactivePersonal = new VwPersonnelDataRepository().GetAllInactivePersonnel().Where(x => x.Active == false).ToList();

            foreach (var person in inactivePersonal)
            {
                PersonalReportsListDto _personnel = new PersonalReportsListDto();
                _personnel.ID = person.ID;
                _personnel.FullName = person.FullName;
                _personnel.FirstName = person.FirstName;
                _personnel.LastName = person.LastName;
                _personnel.ClientName = person.ClientName;
                _personnel.Location = person.LocationName;
                _personnel.DepartmentName = person.DepartmentName;
                _personnel.Pers_Nr = person.Pers_Nr;
                _personnel.Place = person.PhysicalAddress;
                _personnel.PostalCode = person.PostalCode;
                _personnel.DateOfBirth = person.DOB;
                _personnel.EntryDate = person.EntryDate;
                _personnel.ExitDate = person.ExitDate;
                _personnel.PrivateMobile = person.PrivateMobile;
                _personnel.PrivatePhone = person.PrivateTel;
                _personnel.Nationality = person.Nationality;
                _personnel.AuthorisedBy = person.AuthorisedBy;
                _personnel.CompanyMobile = person.CompanyMobile;
                _personnel.CompanyPhone = person.CompanyTel;
                var strtnameAndNr = person.StreetNr + " " + person.Street;
                _personnel.StreetNrAndName = strtnameAndNr;
                _personnel.EmploymentPosition = person.EmployedAs;
                _personnel.AusweisNr = person.Card_Nr.ToString();
                _personnel.AusweisNrShortTerm = person.Card_Nr.ToString();

                var locationFrom = (new LocationRepository().GetLocations().Where(x => x.ID == acReport.StartLocation).FirstOrDefault() ?? new Location()).Name;
                var locationTo = (new LocationRepository().GetLocations().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Location()).Name;
                var DepartMentFrom = (new DepartmentRepository().GetDepartments().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Department()).Name;
                var DepartmentTo = (new DepartmentRepository().GetDepartments().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Department()).Name;
                var startCompany = (new ClientsRepository().GetClients().Where(x => x.ID == acReport.StartClient).FirstOrDefault() ?? new Client()).Name;
                var endCompany = (new ClientsRepository().GetClients().Where(x => x.ID == acReport.EndClient).FirstOrDefault() ?? new Client()).Name;

                _personnel.PersLocationFrom = locationFrom;
                _personnel.PersLocationTo = locationTo;

                _personnel.PersDepartmentFrom = DepartMentFrom;
                _personnel.PersDepartmentTo = DepartmentTo;

                _personnel.PersClientFrom = startCompany;
                _personnel.PersClientTo = endCompany;

                personnelData.Add(_personnel);
            }
            grdMainPersInfo.DataSource = personnelData;
            grdMainPersInfo.DataBind();

            grdVaribleC.DataSource = personnelData;
            grdVaribleC.DataBind();

            grdShowReport.DataSource = personnelData;
            grdShowReport.DataBind();

            grdVaribleD.DataSource = personnelData;
            grdVaribleD.DataBind();

            if (personnelData.Count() > 13)
            {
                grdMainPersInfo.SettingsPager.PageSize = personnelData.Count();
                grdVaribleC.SettingsPager.PageSize = personnelData.Count();
                grdShowReport.SettingsPager.PageSize = personnelData.Count();
                grdVaribleD.SettingsPager.PageSize = personnelData.Count();
            }
            else
            {
                grdMainPersInfo.SettingsPager.PageSize = 13;
                grdVaribleC.SettingsPager.PageSize = 13;
                grdShowReport.SettingsPager.PageSize = 13;
                grdVaribleD.SettingsPager.PageSize = 13;
            }
            HttpContext.Current.Session["PersData"] = personnelData;
            return personnelData;
        }

        protected void grdVaribleC_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadPersonalType(e.Parameters);
        }

        protected void grdShowReport_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadPersonalType(e.Parameters);
        }

        protected void grdVaribleD_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadPersonalType(e.Parameters);
        }

        protected void grdMainPersInfo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadPersonalType(e.Parameters);
        }

        //saving for the settings

        protected void _bindSavedList()
        {
            AccessReportPersonalListsRepository _persReportList = new AccessReportPersonalListsRepository();
            var persReportList = _persReportList.GetAllPersonalLists();

            List<AC_ReportList> persList = new List<AC_ReportList>();
            persList = persReportList.OrderBy(x => x.ListNr).ToList();
            persList.Insert(0, new AC_ReportList { ListNr = 0, ListDescription = "Keine Auswahl" });

            cboPersonalListNr.DataSource = persList;
            cboPersonalListNr.DataBind();
            cboPersonalListNr.SelectedIndex = 0;

            cboPersonalListDescription.DataSource = persList;
            cboPersonalListDescription.DataBind();
            cboPersonalListDescription.SelectedIndex = 0;

            grdSavedPersonalList.DataSource = persReportList;
            grdSavedPersonalList.DataBind();
        }

        [WebMethod]
        public static long CalculateNextNr()
        {
            var personalReportList = new AccessReportPersonalListsRepository().GetAllPersonalLists();
            long lastPersonalReportList = 0;
            if (personalReportList.Count > 0)
            {
                lastPersonalReportList = personalReportList.Max(x => x.ListNr);
            }
            return lastPersonalReportList + 1;
        }

        [WebMethod]
        public static bool CheckIfListNrExists(string personalList)
        {
            var exists = false;
            AccessReportPersonalListsRepository _persReportList = new AccessReportPersonalListsRepository();
            var reportPersonalList = _persReportList.GetPersonalListByNr(Convert.ToInt64(personalList));

            if (reportPersonalList != null)
            {
                exists = true;
            }
            return exists;
        }

        [WebMethod]
        public static int Isnewrecord(string personalListNr)
        {
            int i;
            AccessReportPersonalListsRepository _persReportList = new AccessReportPersonalListsRepository();
            var persReportList = _persReportList.GetPersonalListByNr(Convert.ToInt64(personalListNr));

            if (persReportList != null)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }

        [WebMethod]
        public static long CreatePersonalListInDatabase(string jSONData)
        {
            long Id = 0;

            AccessReportPersonalListsRepository _personalList = new AccessReportPersonalListsRepository();
            AccessPersonalListsChecksRepository _personalListChecks = new AccessPersonalListsChecksRepository();
            AC_ReportList _reportList = new AC_ReportList();
            AC_ReportListChecks _reportChecks = new AC_ReportListChecks();
            ReportsPersonalListDto _listDto = new ReportsPersonalListDto();
            List<ReportsPersonalListDto> personalReportList = JsonConvert.DeserializeObject<List<ReportsPersonalListDto>>(jSONData);
            if (personalReportList.Count > 0)
            {

                _listDto = personalReportList.FirstOrDefault();

                // personalReportList.Add(_listDto);

                //_reportList = personalReportList[0];
                _reportList.ListNr = _listDto.ListNr;
                _reportList.ListDescription = _listDto.ListDescription;
                _reportList.PersonType = _listDto.PersonType;
                _reportList.StartClient = _listDto.StartClient;
                _reportList.EndClient = _listDto.EndClient;
                _reportList.StartLocation = _listDto.StartLocation;
                _reportList.EndLocation = _listDto.EndLocation;
                _reportList.StartDepartmet = _listDto.StartDepartmet;
                _reportList.EndDepartment = _listDto.EndDepartment;
                _reportList.StartName = _listDto.StartName;
                _reportList.EndName = _listDto.EndName;
                _reportList.StartIdNr = _listDto.StartIdNr;
                _reportList.EndIdNr = _listDto.EndIdNr;
                _reportList.VariableType = _listDto.VariableType;

                _personalList.NewPersonalList(_reportList);
                Id = _reportList.ID;
                var reportListId = _reportList.ID;
                _reportChecks.ReportListID = reportListId;
                _reportChecks.ShowClientCompany = _listDto.ShowClientCompany;
                _reportChecks.ShowLocation = _listDto.ShowLocation;
                _reportChecks.ShowDepartment = _listDto.ShowDepartment;
                _reportChecks.ShowName = _listDto.ShowName;
                _reportChecks.ShowIDNr = _listDto.ShowIDNr;
                _reportChecks.ShowPlace = _listDto.ShowPlace;
                _reportChecks.ShowPostalCode = _listDto.ShowPostalCode;
                _reportChecks.ShowStreetAndNr = _listDto.ShowStreetAndNr;
                _reportChecks.ShowDOB = _listDto.ShowDOB;
                _reportChecks.ShowEntryDate = _listDto.ShowEntryDate;
                _reportChecks.ShowExitDate = _listDto.ShowExitDate;
                _reportChecks.ShowEmploymentPosition = _listDto.ShowEmploymentPosition;
                _reportChecks.ShowNationality = _listDto.ShowNationality;
                _reportChecks.ShowCompanyTelephone = _listDto.ShowCompanyTelephone;
                _reportChecks.ShowCompanyMobile = _listDto.ShowCompanyMobile;
                _reportChecks.ShowPrivateTelephone = _listDto.ShowPrivateTelephone;
                _reportChecks.ShowPrivateMobile = _listDto.ShowPrivateMobile;
                _reportChecks.ShowLongTermCard = _listDto.ShowLongTermCard;
                _reportChecks.ShowShortTermCard = _listDto.ShowShortTermCard;
                _reportChecks.ShowAccessFromTo = _listDto.ShowAccessFromTo;
                _reportChecks.ShowAccessPlanNr = _listDto.ShowAccessPlanNr;
                _reportChecks.ShowAccessPlanDesc = _listDto.ShowAccessPlanDesc;

                _personalListChecks.NewPersonalAccessCheck(_reportChecks);
            }
            return Id;
        }


        [WebMethod]
        public static long EditPersonalListInDatabase(string jSONData)
        {
            long Id = 0;

            AccessReportPersonalListsRepository _personalList = new AccessReportPersonalListsRepository();
            AccessPersonalListsChecksRepository _personalListChecks = new AccessPersonalListsChecksRepository();
            AC_ReportList _reportList = new AC_ReportList();
            AC_ReportListChecks _reportChecks = new AC_ReportListChecks();
            ReportsPersonalListDto _listDto = new ReportsPersonalListDto();
            List<ReportsPersonalListDto> personalReportList = JsonConvert.DeserializeObject<List<ReportsPersonalListDto>>(jSONData);
            if (personalReportList.Count > 0)
            {
                _listDto = personalReportList.FirstOrDefault();

                _reportList.ID = _listDto.ID;
                _reportList.ListNr = _listDto.ListNr;
                _reportList.ListDescription = _listDto.ListDescription;
                _reportList.PersonType = _listDto.PersonType;
                _reportList.StartClient = _listDto.StartClient;
                _reportList.EndClient = _listDto.EndClient;
                _reportList.StartLocation = _listDto.StartLocation;
                _reportList.EndLocation = _listDto.EndLocation;
                _reportList.StartDepartmet = _listDto.StartDepartmet;
                _reportList.EndDepartment = _listDto.EndDepartment;
                _reportList.StartName = _listDto.StartName;
                _reportList.EndName = _listDto.EndName;
                _reportList.StartIdNr = _listDto.StartIdNr;
                _reportList.EndIdNr = _listDto.EndIdNr;
                _reportList.VariableType = _listDto.VariableType;

                _personalList.EditPersonalList(_reportList);
                Id = _reportList.ID;
                _reportChecks = _personalListChecks.GetPersonalCheckByReportId(_listDto.ID);

                _reportChecks.ReportListID = _listDto.ID;
                _reportChecks.ShowClientCompany = _listDto.ShowClientCompany;
                _reportChecks.ShowLocation = _listDto.ShowLocation;
                _reportChecks.ShowDepartment = _listDto.ShowDepartment;
                _reportChecks.ShowName = _listDto.ShowName;
                _reportChecks.ShowIDNr = _listDto.ShowIDNr;
                _reportChecks.ShowPlace = _listDto.ShowPlace;
                _reportChecks.ShowPostalCode = _listDto.ShowPostalCode;
                _reportChecks.ShowStreetAndNr = _listDto.ShowStreetAndNr;
                _reportChecks.ShowDOB = _listDto.ShowDOB;
                _reportChecks.ShowEntryDate = _listDto.ShowEntryDate;
                _reportChecks.ShowExitDate = _listDto.ShowExitDate;
                _reportChecks.ShowEmploymentPosition = _listDto.ShowEmploymentPosition;
                _reportChecks.ShowNationality = _listDto.ShowNationality;
                _reportChecks.ShowCompanyTelephone = _listDto.ShowCompanyTelephone;
                _reportChecks.ShowCompanyMobile = _listDto.ShowCompanyMobile;
                _reportChecks.ShowPrivateTelephone = _listDto.ShowPrivateTelephone;
                _reportChecks.ShowPrivateMobile = _listDto.ShowPrivateMobile;
                _reportChecks.ShowLongTermCard = _listDto.ShowLongTermCard;
                _reportChecks.ShowShortTermCard = _listDto.ShowShortTermCard;
                _reportChecks.ShowAccessFromTo = _listDto.ShowAccessFromTo;
                _reportChecks.ShowAccessPlanNr = _listDto.ShowAccessPlanNr;
                _reportChecks.ShowAccessPlanDesc = _listDto.ShowAccessPlanDesc;

                _personalListChecks.EditPersonalAccessCheck(_reportChecks);

            }
            return Id;
        }

        [WebMethod]
        public static AC_ReportList GetPersonaReportlList(int ID)
        {
            AccessReportPersonalListsRepository _persRepo = new AccessReportPersonalListsRepository();
            AC_ReportList _reportListTble = new AC_ReportList();
            var reportList = _persRepo.GetPersonalListById(ID);

            if (reportList == null)
            {
                return _reportListTble;
            }

            if (reportList != null)
            {
                _reportListTble.ID = reportList.ID;

                _reportListTble.ListNr = reportList.ListNr;
                _reportListTble.ListDescription = reportList.ListDescription;
                _reportListTble.PersonType = reportList.PersonType;
                _reportListTble.StartClient = reportList.StartClient;
                _reportListTble.EndClient = reportList.EndClient;
                _reportListTble.StartLocation = reportList.StartLocation;
                _reportListTble.EndLocation = reportList.EndLocation;
                _reportListTble.StartDepartmet = reportList.StartDepartmet;
                _reportListTble.EndDepartment = reportList.EndDepartment;
                _reportListTble.StartName = reportList.StartName;
                _reportListTble.EndName = reportList.EndName;
                _reportListTble.StartIdNr = reportList.StartIdNr;
                _reportListTble.EndIdNr = reportList.EndIdNr;
                _reportListTble.VariableType = reportList.VariableType;
            }

            return _reportListTble;
        }

        [WebMethod]
        public static ReportsPersonalListDto GetAllFields(int ID)
        {
            AccessReportPersonalListsRepository _personalList = new AccessReportPersonalListsRepository();
            AccessPersonalListsChecksRepository _personalListChecks = new AccessPersonalListsChecksRepository();
            AC_ReportList _reportList = new AC_ReportList();
            AC_ReportListChecks _reportChecks = new AC_ReportListChecks();
            ReportsPersonalListDto _listDto = new ReportsPersonalListDto();
            List<ReportsPersonalListDto> personalReportList = new List<ReportsPersonalListDto>(ID);
            if (personalReportList.Count > 0)
            {

                _listDto = personalReportList.FirstOrDefault();

                // personalReportList.Add(_listDto);

                //_reportList = personalReportList[0];
                _reportList.ListNr = _listDto.ListNr;
                _reportList.ListDescription = _listDto.ListDescription;
                _reportList.PersonType = _listDto.PersonType;
                _reportList.StartClient = _listDto.StartClient;
                _reportList.EndClient = _listDto.EndClient;
                _reportList.StartLocation = _listDto.StartLocation;
                _reportList.EndLocation = _listDto.EndLocation;
                _reportList.StartDepartmet = _listDto.StartDepartmet;
                _reportList.EndDepartment = _listDto.EndDepartment;
                _reportList.StartName = _listDto.StartName;
                _reportList.EndName = _listDto.EndName;
                _reportList.StartIdNr = _listDto.StartIdNr;
                _reportList.EndIdNr = _listDto.EndIdNr;
                _reportList.VariableType = _listDto.VariableType;

                _personalList.NewPersonalList(_reportList);

                var reportListId = _reportList.ID;
                _reportChecks.ReportListID = reportListId;
                _reportChecks.ShowClientCompany = _listDto.ShowClientCompany;
                _reportChecks.ShowLocation = _listDto.ShowLocation;
                _reportChecks.ShowDepartment = _listDto.ShowDepartment;
                _reportChecks.ShowName = _listDto.ShowName;
                _reportChecks.ShowIDNr = _listDto.ShowIDNr;
                _reportChecks.ShowPlace = _listDto.ShowPlace;
                _reportChecks.ShowPostalCode = _listDto.ShowPostalCode;
                _reportChecks.ShowStreetAndNr = _listDto.ShowStreetAndNr;
                _reportChecks.ShowDOB = _listDto.ShowDOB;
                _reportChecks.ShowEntryDate = _listDto.ShowEntryDate;
                _reportChecks.ShowExitDate = _listDto.ShowExitDate;
                _reportChecks.ShowEmploymentPosition = _listDto.ShowEmploymentPosition;
                _reportChecks.ShowNationality = _listDto.ShowNationality;
                _reportChecks.ShowCompanyTelephone = _listDto.ShowCompanyTelephone;
                _reportChecks.ShowCompanyMobile = _listDto.ShowCompanyMobile;
                _reportChecks.ShowPrivateTelephone = _listDto.ShowPrivateTelephone;
                _reportChecks.ShowPrivateMobile = _listDto.ShowPrivateMobile;
                _reportChecks.ShowLongTermCard = _listDto.ShowLongTermCard;
                _reportChecks.ShowShortTermCard = _listDto.ShowShortTermCard;
                _reportChecks.ShowAccessFromTo = _listDto.ShowAccessFromTo;
                _reportChecks.ShowAccessPlanNr = _listDto.ShowAccessPlanNr;
                _reportChecks.ShowAccessPlanDesc = _listDto.ShowAccessPlanDesc;

                _personalListChecks.NewPersonalAccessCheck(_reportChecks);
            }
            return _listDto;
        }

        protected void RebingDropdowns()
        {
            AccessReportPersonalListsRepository _persReportList = new AccessReportPersonalListsRepository();
            var persReportList = _persReportList.GetAllPersonalLists();

            List<AC_ReportList> persList = new List<AC_ReportList>();
            persList = persReportList.OrderBy(x => x.ListNr).ToList();
            persList.Insert(0, new AC_ReportList { ListNr = 0, ListDescription = "Keine Auswahl" });

            cboPersonalListNr.DataSource = persList;
            cboPersonalListNr.DataBind();

            cboPersonalListDescription.DataSource = persList;
            cboPersonalListDescription.DataBind();
        }

        protected void grdSavedPersonalList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            _bindSavedList();
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                if (Convert.ToInt32(e.Parameters) == -1)
                {
                    grdSavedPersonalList.FocusedRowIndex = Convert.ToInt32(e.Parameters);
                }
                else
                {
                    var index = grdSavedPersonalList.FindVisibleIndexByKeyValue(e.Parameters);
                    if (index >= 0)
                    {
                        grdSavedPersonalList.FocusedRowIndex = index;
                    }
                }

            }
        }

        protected void cboPersonalListNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            RebingDropdowns();

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cboPersonalListNr.Value = e.Parameter.ToString();
            }
        }

        protected void cboPersonalListDescription_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {


            RebingDropdowns();

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cboPersonalListDescription.Value = e.Parameter.ToString();
            }
        }

        [WebMethod]
        public static AC_ReportListChecks GetPersonalListCheckbyid(long id)
        {
            AccessPersonalListsChecksRepository _AccessReportsChecks = new AccessPersonalListsChecksRepository();

            AC_ReportListChecks _AC_ReportSettings = new AC_ReportListChecks();

            var ReportCheckID = _AccessReportsChecks.GetPersonalCheckByReportId(id);

            if (ReportCheckID != null)
            {
                var Id = ReportCheckID.ID;


                var ReportSetting = _AccessReportsChecks.GetPersonalCheckById(Id);
                if (ReportSetting == null)
                {
                    return null;
                }

                if (ReportSetting != null)
                {
                    _AC_ReportSettings.ID = ReportSetting.ID;
                    _AC_ReportSettings.ReportListID = ReportSetting.ReportListID;
                    _AC_ReportSettings.ShowClientCompany = ReportSetting.ShowClientCompany;
                    _AC_ReportSettings.ShowLocation = ReportSetting.ShowLocation;
                    _AC_ReportSettings.ShowDepartment = ReportSetting.ShowDepartment;
                    _AC_ReportSettings.ShowName = ReportSetting.ShowName;
                    _AC_ReportSettings.ShowIDNr = ReportSetting.ShowIDNr;
                    _AC_ReportSettings.ShowPlace = ReportSetting.ShowPlace;
                    _AC_ReportSettings.ShowPostalCode = ReportSetting.ShowPostalCode;
                    _AC_ReportSettings.ShowStreetAndNr = ReportSetting.ShowStreetAndNr;
                    _AC_ReportSettings.ShowDOB = ReportSetting.ShowDOB;
                    _AC_ReportSettings.ShowEntryDate = ReportSetting.ShowEntryDate;
                    _AC_ReportSettings.ShowExitDate = ReportSetting.ShowExitDate;
                    _AC_ReportSettings.ShowEmploymentPosition = ReportSetting.ShowEmploymentPosition;
                    _AC_ReportSettings.ShowNationality = ReportSetting.ShowNationality;
                    _AC_ReportSettings.ShowCompanyTelephone = ReportSetting.ShowCompanyTelephone;
                    _AC_ReportSettings.ShowCompanyMobile = ReportSetting.ShowCompanyMobile;

                    _AC_ReportSettings.ShowPrivateTelephone = ReportSetting.ShowPrivateTelephone;
                    _AC_ReportSettings.ShowPrivateMobile = ReportSetting.ShowPrivateMobile;
                    _AC_ReportSettings.ShowLongTermCard = ReportSetting.ShowLongTermCard;
                    _AC_ReportSettings.ShowShortTermCard = ReportSetting.ShowShortTermCard;
                    _AC_ReportSettings.ShowAccessFromTo = ReportSetting.ShowAccessFromTo;
                    _AC_ReportSettings.ShowAccessPlanNr = ReportSetting.ShowAccessPlanNr;
                    _AC_ReportSettings.ShowAccessPlanDesc = ReportSetting.ShowAccessPlanDesc;
                };
            }
            return _AC_ReportSettings;
        }

        [WebMethod]
        public static bool DeletePersonalReportList(long Id)
        {
            AccessReportPersonalListsRepository persRep = new AccessReportPersonalListsRepository();

            var accessreport = persRep.GetPersonalListById(Convert.ToInt64(Id));
            if (accessreport != null)
            {
                new AccessReportPersonalListsRepository().DeletePersonalList(accessreport);
            }
            return persRep.GetPersonalListByNr(Convert.ToInt64(Id)) == null;
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
        public static bool CheckIfListNrExistsOnEdit(string listNr, long currentId)
        {
            var exists = false;
            AccessReportPersonalListsRepository _repo = new AccessReportPersonalListsRepository();
            var perslistNr = _repo.GetPersonalListByNr(Convert.ToInt64(listNr));
            if (perslistNr != null)
            {
                if (perslistNr.ID != currentId)
                {
                    exists = true;
                }
            }

            return exists;
        }

    }
}