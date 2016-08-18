using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using DevExpress.Web;
using Ninject;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.Content
{
    public partial class VisitorsApplications : BasePage
    {
        [Inject]
        ZUTMain mainCtl = new ZUTMain();
        PersonnelViewModel ViewModel = new PersonnelViewModel();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("VisitorApplications_PMode");
            }
            set
            {
                HttpContext.Current.Session["VisitorApplications_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.VisitorApplications, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {

                btnSave.Enabled = false; btnEntSave.Enabled = false;

                btnNew.Enabled = false;

                btnDelete.Enabled = false; btnDeletePic.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdowns();
                BindTopCompanies();
                LoadPersonal();
                BindDepartment();
                BindCompanies();
                BindVisitors();


            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Dashboard_Main.aspx");
        }

        protected void btnEntNew_Click(object sender, EventArgs e)
        {

        }

        protected void btnEntEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnEntSave_Click(object sender, EventArgs e)
        {
            UpdateVisitor();
        }

        protected void ddlPersonalName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlApplicationID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEntryDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlVisitorName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlVisitorCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPersonalDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdVisitors_SelectionChanged(object sender, EventArgs e)
        {
            var _sender = (ASPxGridView)sender;
            var visitorID = _sender.GetRowValues(_sender.FocusedRowIndex, "ID");
            ddlApplicationID.Value = visitorID.ToString();
            ddlVisitorName.Value = visitorID.ToString();
            BindCompanies();
            if (visitorID != null)
            {
                //LoadVisitorData(Convert.ToInt64(visitorID));
                Response.Redirect("/Content/Visitors.aspx?visitorNr=" + visitorID);
            }

        }

        protected void grdSearchPersonnel_SelectionChanged(object sender, EventArgs e)
        {
            var _sender = (ASPxGridView)sender;
            var persNr = _sender.GetRowValues(_sender.FocusedRowIndex, "Pers_Nr");
            string identificationNumber = Convert.ToString(persNr);
            //var personnel = ViewModel.GetPersonnelByPersNum( Convert.ToInt64(persNr));
            var personnelData = new VwPersonnelDataRepository().GetAllPersonnel().Distinct().ToList();
            var personnel = personnelData.Find(x => x.Pers_Nr == Convert.ToInt32(persNr));
            txtPersVisited.Text = personnel.FullName != null ? personnel.FullName.ToString() : "";
            //txtPersonalID.Value = personnel.ID.ToString();
            txtPersonnelPhone.Text = personnel.PrivateTel != null ? personnel.PrivateTel.ToString() : "";
            txtPersonnelCellPhone.Text = personnel.PrivateMobile != null ? personnel.PrivateMobile.ToString() : "";
            txtDepartment.Text = personnel.DepartmentName != null ? personnel.DepartmentName.ToString() : "";

        }

        protected void btnCancelDel_Click(object sender, EventArgs e)
        {
            var id = ddlVisitorName.Value;
            var visitor = new VisitorRepository().GetVisitorById(Convert.ToInt64(id));
            if (visitor != null)
            {
                new VisitorRepository().DeleteVisitor(visitor);
                ClearControls();
                BindDropdowns();
                BindCompanies();
                LoadNavPosition();
                LoadTotalItems();
                BindVisitors();
            }

        }
        protected void ClearControls()
        {
            txtPersName.Text = "";
            txtPersNr.Text = "";
            txtVisitorID.Text = "";
            txtSurName.Text = "";
            txtOtherNames.Text = "";
            cobCompany.Value = "0";
            txtStreet.Text = "";
            txtSteetNr.Text = "";
            txtLocation.Text = "";
            txtTelephone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtVehicleModel.Text = "";
            DateTime nullDate = DateTime.MinValue;
            DateTime defalutDate = DateTime.Now;
            dtpDateReg.Date = nullDate;
            dtpStartDate.Date = nullDate;
            dtpEndDate.Date = nullDate;
            dtpRegDateTime.Value = new DateTime(defalutDate.Year, defalutDate.Month, defalutDate.Day, 00, 00, 00);
            dtpStartDateTime.Value = new DateTime(defalutDate.Year, defalutDate.Month, defalutDate.Day, 00, 00, 00);
            dtpEndDateTime.Value = new DateTime(defalutDate.Year, defalutDate.Month, defalutDate.Day, 00, 00, 00);
        }

        public void LoadNavPosition()
        {
            var i = ddlApplicationID.SelectedIndex;
            if (i == 0)
            {
                txtFvCurrentEntry.Text = "";
            }
            else
            {
                txtFvCurrentEntry.Text = i.ToString();
            }

        }
        public void bindserchgrid()
        {
            VisitorRepository _VisitorRepository = new VisitorRepository();
            var visitorLists = _VisitorRepository.GetAllVisitors().Where(x => x.VisitorType == 2);
            grdSearchVisitors.DataSource = visitorLists;
            grdSearchVisitors.DataBind();
        }
        public void LoadTotalItems()
        {

            var total = ddlApplicationID.Items.Count - 1;
            txtFvTotalEntries.Text = total.ToString();
        }

        protected void fvNavPrev_Click(object sender, EventArgs e)
        {
            MoveToPrevious();
        }

        protected void fvNavNext_Click(object sender, EventArgs e)
        {
            MoveToNext();
        }
        private void MoveToPrevious()
        {
            var i = (ddlApplicationID.SelectedIndex - 1);
            if (i < 0) return;
            ddlApplicationID.Value = ddlApplicationID.Value;
            grdVisitors.FocusedRowIndex = ddlApplicationID.SelectedIndex;

            var total = ddlApplicationID.Items.Count;
            txtFvCurrentEntry.Text = (i + 1).ToString();
            txtFvTotalEntries.Text = total.ToString();
        }

        private void MoveToNext()
        {
            var i = (ddlApplicationID.SelectedIndex + 1);
            if (i > (ddlApplicationID.Items.Count - 1)) return;
            ddlApplicationID.SelectedIndex = i;
            ddlApplicationID.Value = ddlApplicationID.Value;
            //fvVisitors.DataBind();

            grdVisitors.FocusedRowIndex = ddlApplicationID.SelectedIndex;

            var total = ddlApplicationID.Items.Count;
            txtFvCurrentEntry.Text = (i + 1).ToString();
            txtFvTotalEntries.Text = total.ToString();
        }

        protected void grdCarSearch_SelectionChanged(object sender, EventArgs e)
        {
            var _sender = (ASPxGridView)sender;
            var cellID = _sender.GetRowValues(_sender.FocusedRowIndex, "Name");

            //TextBox txtCarType = (TextBox)((FormView)fvVisitors).Row.FindControl("txtCarType");


            //txtCarType.Text = cellID.ToString();

        }
        protected void grdCarSearch_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void BindDropdowns()
        {
            var visitorList = new VisitorViewModels().GetVisitorData().ToList().Where(x => x.VisitorType == 2);

            ddlApplicationID.DataSource = visitorList;
            ddlApplicationID.DataBind();

            ddlVisitorName.DataSource = visitorList;
            ddlVisitorName.DataBind();
            if (visitorList.Count() > 1)
            {
                ddlApplicationID.SelectedIndex = 1;
                ddlVisitorName.SelectedIndex = 1;
            }
        }
        protected void BindDropdowns(long id)
        {
            var visitorList = new VisitorViewModels().GetVisitorData().ToList().Where(x => x.VisitorType == 2);

            ddlApplicationID.DataSource = visitorList;
            ddlApplicationID.DataBind();
            ddlApplicationID.Value = id.ToString();

            ddlVisitorName.DataSource = visitorList;
            ddlVisitorName.DataBind();
            ddlVisitorName.Value = id.ToString();
        }

        protected void ddlPersonalName_DataBound(object sender, EventArgs e)
        {


        }
        protected void BindCompanies()
        {
            List<Client> listCompany = new List<Client>();
            Client comany = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "keine"
            };
            listCompany.Add(comany);
            var companies = new ClientsRepository().GetClients();
            listCompany.AddRange(companies);
            cobCompany.DataSource = listCompany;
            cobCompany.DataBind();
        }
        protected void BindTopCompanies()
        {
            List<Client> listCompany = new List<Client>();
            Client comany = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "keine"
            };
            listCompany.Add(comany);
            var companies = new ClientsRepository().GetClients();
            listCompany.AddRange(companies);
            ddlVisitorCompany.DataSource = listCompany;
            ddlVisitorCompany.DataBind();
            ddlVisitorCompany.SelectedIndex = 0;
        }
        protected void LoadPersonal()
        {
            var personnelList = new VwPersonnelDataRepository().GetAllPersonnel().ToList();
            List<VwPersonnelData> listPersonnel = new List<VwPersonnelData>();
            VwPersonnelData _personnal = new VwPersonnelData()
            {
                ID = 0,
                FullName = "keine",
            };
            listPersonnel.Add(_personnal);
            listPersonnel.AddRange(personnelList);
            ddlPersonalName.DataSource = listPersonnel;
            ddlPersonalName.DataBind();
            ddlPersonalName.SelectedIndex = 0;
        }
        protected void BindDepartment()
        {
            var depList = new DepartmentRepository().GetDepartments();
            List<Department> listDep = new List<Department>();
            Department dep = new Department()
            {
                ID = 0,
                Name = "keine"
            };
            listDep.Add(dep);
            listDep.AddRange(depList);
            ddlPersonalDepartment.DataSource = listDep;
            ddlPersonalDepartment.DataBind();
            ddlPersonalDepartment.SelectedIndex = 0;
        }
        protected void UpdateVisitor()
        {
            if (string.IsNullOrEmpty(txtVisitorID.Text)) return;
            var visitor = new VisitorRepository().GetVisitorByVisitorId(Convert.ToInt64(txtVisitorID.Text.Trim()));
            if (visitor == null) return;
            var RegDate = Convert.ToDateTime(dtpDateReg.Value);
            var EntryDate = Convert.ToDateTime(dtpStartDate.Value);
            var EndDate = Convert.ToDateTime(dtpEndDate.Value);
            var RegTime = dtpRegDateTime.DateTime.TimeOfDay;
            var EntryTime = dtpStartDateTime.DateTime.TimeOfDay;
            var EndTime = dtpEndDateTime.DateTime.TimeOfDay;

            var _RegDate = new DateTime(RegDate.Year, RegDate.Month, RegDate.Day, 00, 00, 00);
            var _EntryDate = new DateTime(EntryDate.Year, EntryDate.Month, EntryDate.Day, 00, 00, 00);
            var _EndDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 00, 00, 00);

            DateTime RegDateTime = _RegDate.Add(RegTime);
            DateTime EntryDateTime = _EntryDate.Add(EntryTime);
            DateTime EndDateTime = _EndDate.Add(EndTime);

            var visitInstanceId = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(visitor.ID).VisitInstanceId;
            var VisitorId = Convert.ToInt64(txtVisitorID.Text.Trim());
            var surName = txtSurName.Text.Trim();
            var Name = txtOtherNames.Text.Trim();
            var Company = cobCompany.Value != null ? cobCompany.Value.ToString() : string.Empty;
            var street = txtStreet.Text.Trim();
            var streetNr = txtSteetNr.Text.Trim();
            var locationNr = txtSteetNr.Text.Trim();
            var location = txtLocation.Text.Trim();
            var telephone = txtTelephone.Text.Trim();
            var mobilePhone = txtMobile.Text.Trim();
            var email = txtEmail.Text.Trim();


            var memo = txtMemo.Text.Trim();
            var carType = txtVehicleModel.Text.Trim();
            string[] _xsplit = new string[] { ("-") };
            string[] _veh = (carType).Split(_xsplit, StringSplitOptions.None);
            var carId = _veh[0];

            var personal = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(txtPersNr.Text.Trim()));

            if (personal == null) return;
            var personnelId = personal.ID;
            if (personnelId < 1) return;
            EditVisitor(visitInstanceId, personnelId, VisitorId, surName, Name, Company, street, streetNr, location, telephone, mobilePhone, email, RegDateTime, EntryDateTime, EndDateTime, memo, carId, visitor);

            BindVisitors();
        }
        protected void EditVisitor(long visitInstanceId, long personalId, long visitorId, string surName, string name, string company, string street, string streetNr, string location, string telephone,
           string mobilePhone, string email, DateTime regDate, DateTime startDate,
           DateTime endDate, string memo, string vehicleId, Visitor exvisitor)
        {
            Visitor visitor = new Visitor()
            {
                ID = exvisitor.ID,
                VisitorID = visitorId,
                PersonalID = personalId,
                SurName = surName,
                Fullname = name,
                Company = !string.IsNullOrEmpty(company) && company != "0" ? Convert.ToInt32(company) : (int?)null,
                Street = street,
                StreetNr = streetNr,
                Location = location,
                Telephone = telephone,
                Mobile = mobilePhone,
                Email = email,
                VisitorType = 2


            };
            new VisitorRepository().EditVisitor(visitor);
            VisitorAccessTime existingAccessTime = new VisitorAccessTime();
            existingAccessTime = new VisitorAccessTimeViewModel().GetAccessTimeByVisitInstanceId(Convert.ToInt64(visitInstanceId));
            if (existingAccessTime != null)
            {
                VisitorAccessTime accessTime = new VisitorAccessTime()
                {
                    ID = existingAccessTime.ID,
                    VisitInstanceId = visitInstanceId,
                    VisitorId = visitor.ID,
                    RegistrationDate = regDate,
                    StartDate = startDate,
                    EndDate = endDate,
                    Memo = memo

                };
                VisitorAccessTimeViewModel accessTimeViewModel = new VisitorAccessTimeViewModel();
                accessTimeViewModel.UpdateAccessTime(accessTime);
                if (!string.IsNullOrEmpty(vehicleId))
                {
                    var _vehicle = new VisitorVehicleRepository().GetVehicleByVisitorId(visitor.ID);
                    if (_vehicle != null)
                    {
                        Visitor_Vehicle Vehicle = new Visitor_Vehicle()
                        {
                            ID = _vehicle.ID,
                            VisitorID = visitor.ID,
                            VehicleID = Convert.ToInt64(vehicleId),

                        };
                        new VisitorVehicleRepository().Editvehicle(Vehicle);
                    }
                    else
                    {
                        Visitor_Vehicle Vehicle = new Visitor_Vehicle()
                        {
                            VisitorID = visitor.ID,
                            VehicleID = Convert.ToInt64(vehicleId),

                        };
                        new VisitorVehicleRepository().NewVehicle(Vehicle);
                    }
                }
            }
            BindDropdowns(visitor.ID);
            BindCompanies();
            if (visitor.Company != null) { cobCompany.Value = visitor.Company.ToString(); }

        }
        protected List<VisitorsDto> VisitorsGrid()
        {
            List<VisitorsDto> listVisits = new List<VisitorsDto>();
            var visitAccessTime = new VisitorAccessTimeRepository().GetAllVisitorAccessTime().ToList();

            foreach (var accessTime in visitAccessTime)
            {
                if (accessTime.Visitor.VisitorType == 2)
                {
                    var personnel = new VwPersonnelDataRepository().GetAllPersonnel().Find(x => x.ID == Convert.ToInt64(accessTime.Visitor.PersonalID));
                    VisitorsDto visitDto = new VisitorsDto()
                    {
                        ID = accessTime.Visitor.ID,
                        VisitorID = accessTime.Visitor.VisitorID,
                        SurName = accessTime.Visitor.SurName,
                        OtherName = accessTime.Visitor.Fullname,
                        Street = accessTime.Visitor.Street,
                        Company = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Name : "",
                        CompanyNr = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.CompanyNr.ToString() : "",
                        CompanyStreet = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Street : "",
                        CompanyStreetNr = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.HouseNr : "",
                        CompanyLocation = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Place : "",
                        CompanyPostalCode = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.ZipCode : "",
                        PostalCode = accessTime.Visitor.PostalCode,
                        Location = accessTime.Visitor.Location,
                        Telephone = accessTime.Visitor.Telephone,
                        Mobile = accessTime.Visitor.Mobile,
                        Email = accessTime.Visitor.Email,
                        StartDate = accessTime.StartDate.ToShortDateString(),
                        EndDate = accessTime.EndDate != null ? Convert.ToDateTime(accessTime.EndDate).ToShortDateString() : "",
                        StreetNr = accessTime.Visitor.StreetNr,
                        PersName = personnel != null ? string.Format("{0} {1}", personnel.FirstName, personnel.LastName) : "",
                        PersPhoneNr = personnel != null ? personnel.CompanyTel : "",
                        vStartDate = accessTime.StartDate,
                        vEndDate = accessTime.EndDate,
                        VisitorName = string.Format("{0} {1}", accessTime.Visitor.Fullname, accessTime.Visitor.SurName),
                        CompanyID = accessTime.Visitor.Company != null ? accessTime.Visitor.Company : -1,
                        DepartmentId = personnel.DepartmentID != null ? Convert.ToInt64(personnel.DepartmentID) : -1,
                        personnalId = personnel.ID

                    };
                    listVisits.Add(visitDto);
                }
            }
            return listVisits;
        }
        protected void BindVisitors()
        {
            var visitorsList = VisitorsGrid();
            grdVisitors.DataSource = VisitorsGrid();
            grdVisitors.DataBind();


            grdSearchVisitors.DataSource = VisitorsGrid();
            grdSearchVisitors.DataBind();

            if (visitorsList.Count <= 26)
            {
                //grdVisitors.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
                //grdSearchVisitors.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
            }
            else
            {
                //grdVisitors.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowAllRecords;
                //grdSearchVisitors.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowAllRecords;
            }
        }

        protected void grdSearchVisitors_SelectionChanged(object sender, EventArgs e)
        {
            var _sender = (ASPxGridView)sender;
            var visitorID = _sender.GetRowValues(_sender.FocusedRowIndex, "ID");
            ddlApplicationID.Value = visitorID.ToString();
            ddlVisitorName.Value = visitorID.ToString();
            BindCompanies();

        }

        protected void BindFilteredVisitors(List<VisitorsDto> visitorList)
        {
            ddlApplicationID.DataSource = visitorList;
            ddlApplicationID.DataBind();

            ddlVisitorName.DataSource = visitorList;
            ddlVisitorName.DataBind();
            if (visitorList.Count() > 1)
            {
                ddlApplicationID.SelectedIndex = 1;
                ddlVisitorName.SelectedIndex = 1;
            }

        }
        protected void BindFilteredVisitorsGrid(List<VisitorsDto> visitorList)
        {
            grdVisitors.DataSource = visitorList;
            grdVisitors.DataBind();
            grdSearchVisitors.DataSource = visitorList;
            grdSearchVisitors.DataBind();
        }


        protected void btnApply_Click(object sender, EventArgs e)
        {
            var _sender = (ASPxGridView)sender;
            var visitorID = _sender.GetRowValues(_sender.FocusedRowIndex, "ID");
            ddlApplicationID.Value = visitorID.ToString();
            ddlVisitorName.Value = visitorID.ToString();
            BindCompanies();
            if (visitorID != null)
            {
                //LoadVisitorData(Convert.ToInt64(visitorID));
                Response.Redirect("/Content/Visitors.aspx?visitorNr=" + visitorID);
            }
        }
    }
}