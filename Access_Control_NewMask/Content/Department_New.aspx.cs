using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using System.Web.Services;
using System.Globalization;
using DevExpress.Web;

namespace Access_Control_NewMask.Content
{

    public partial class Department_New : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Departments_PMode");
            }
            set
            {
                HttpContext.Current.Session["Departments_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Department, out _AccessControlPermissionMode))
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
                BindSelectionControls();
            }
        }

        void BindSelectionControls()
        {
            Department _Department = new Department()
            {
                ID = 0,
                Department_Nr = 0,
                Name = "Keine",
            };

            var Departments = new DepartmentRepository().GetDepartments();

            List<Department> DepartmentsList = new List<Department>();
            DepartmentsList.Add(_Department);
            DepartmentsList.AddRange(Departments);

            cboDeptNr.DataSource = DepartmentsList;
            cboDeptNr.DataBind();

            cboDeptName.DataSource = DepartmentsList;
            cboDeptName.DataBind();

            grdDepartments.DataSource = Departments;
            grdDepartments.DataBind();
            grdDepartments.FocusedRowIndex = -1;

            if (Departments.Count() <= 22)
            {
                grdDepartments.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                grdDepartments.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }
        }

        protected void LoadDepartmentsById(int Id)
        {
            var Departments = new DepartmentRepository().GetDepartmentById(Id);
            if (Departments != null)
            {
                cboDeptName.Value = Departments.ID.ToString();
                cboDeptNr.Value = Departments.ID.ToString();

                if (Departments.Department_Nr != 0) { txtdeptNo.Text = Departments.Department_Nr.ToString(); } else { txtdeptNo.Text = ""; };
                if (Departments.Name != null) { txtdeptName.Text = Departments.Name.ToString(); } else { txtdeptName.Text = ""; };
                if (Departments.ZipCode != null) { txtPLZ.Text = Departments.ZipCode.ToString(); } else { txtPLZ.Text = ""; };
                if (Departments.Place != null) { txtOrt.Text = Departments.Place.ToString(); } else { txtOrt.Text = ""; };
                if (Departments.Street != null) { txtStreet.Text = Departments.Street.ToString(); } else { txtStreet.Text = ""; };
                if (Departments.HouseNumber != null) { txthseNumber.Text = Departments.HouseNumber.ToString(); } else { txthseNumber.Text = ""; };

                if (Departments.LocationHeadName != null) { txtName.Text = Departments.LocationHeadName.ToString(); } else { txtName.Text = ""; };
                if (Departments.LocationHeadFunction != null) { txtFunct.Text = Departments.LocationHeadFunction.ToString(); } else { txtFunct.Text = ""; };
                if (Departments.LocationHeadPhone != null) { txtTel.Text = Departments.LocationHeadPhone.ToString(); } else { txtTel.Text = ""; };
                if (Departments.LocationHeadMobile != null) { txtMob.Text = Departments.LocationHeadMobile.ToString(); } else { txtMob.Text = ""; };
                if (Departments.LocationHeadEmail != null) { txtEmail.Text = Departments.LocationHeadEmail.ToString(); } else { txtEmail.Text = ""; };

                if (Departments.InfoText != null) { txtMemo.Text = Departments.InfoText.ToString(); } else { txtMemo.Text = ""; };
            }
            else
            {
                txtdeptNo.Text = "";
                txtdeptName.Text = "";
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
            cboDeptNr.Enabled = true;
            cboDeptName.Enabled = true;
            btnDelete.Enabled = true;

        }

        protected void clearControls()
        {
            //setting next department no and clearing texboxes
            NextCompanyNr();

            cboDeptName.SelectedIndex = 0;
            cboDeptNr.SelectedIndex = 0;

            cboDeptNr.Enabled = false;
            cboDeptName.Enabled = false;
            btnDelete.Enabled = false;

            txtdeptName.Text = "";
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
            int deptNr = 0;
            var departments = new DepartmentRepository().GetDepartments();
            if (departments.Count() > 0)
            {
                deptNr = Convert.ToInt32(departments.Max(i => i.Department_Nr));
            }
            else
            {
                deptNr = 0;
            }
            int nextNr = deptNr + 1;
            txtdeptNo.Text = nextNr.ToString();
            txtdeptName.Focus();
            saveChangesonNew.Value = "1";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "1";
            clearControls();
            grdDepartments.FocusedRowIndex = -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "";
            SaveDepartment();
        }

        protected void SaveDepartment()
        {
            DepartmentRepository _Departments = new DepartmentRepository();
            Department _Department = new Department();
            if (txtdeptNo.Text == "" || txtdeptNo.Text == null)
            {
                return;

            }
            var departmentsList = _Departments.GetDepartments();
            var deptExist = departmentsList.FirstOrDefault(x => x.Department_Nr == Convert.ToInt32(txtdeptNo.Text));

            if (deptExist != null)
            {
                deptExist.Department_Nr = Convert.ToInt32(txtdeptNo.Text);
                deptExist.Name = txtdeptName.Text;
                deptExist.ZipCode = txtPLZ.Text;
                deptExist.Place = txtOrt.Text;
                deptExist.Street = txtStreet.Text;
                deptExist.HouseNumber = txthseNumber.Text;

                deptExist.LocationHeadName = txtName.Text;
                deptExist.LocationHeadFunction = txtFunct.Text;
                deptExist.LocationHeadPhone = txtTel.Text;
                deptExist.LocationHeadMobile = txtMob.Text;
                deptExist.LocationHeadEmail = txtEmail.Text;

                deptExist.InfoText = txtMemo.Text;

                _Departments.EditDepartment(deptExist);
                mainCtl.RedirectToPromptPage();
                BindSelectionControls();
                LoadDepartmentsById(Convert.ToInt32(deptExist.ID));

            }
            else
            {
                if (txtdeptNo.Text == "" || txtdeptNo.Text == null)
                {
                    return;

                }
                else {
                    _Department.Department_Nr = Convert.ToInt32(txtdeptNo.Text);
                }

                _Department.Department_Nr = Convert.ToInt32(txtdeptNo.Text);
                _Department.Name = txtdeptName.Text;
                _Department.ZipCode = txtPLZ.Text;
                _Department.Place = txtOrt.Text;
                _Department.Street = txtStreet.Text;
                _Department.HouseNumber = txthseNumber.Text;

                _Department.LocationHeadName = txtName.Text;
                _Department.LocationHeadFunction = txtFunct.Text;
                _Department.LocationHeadPhone = txtTel.Text;
                _Department.LocationHeadMobile = txtMob.Text;
                _Department.LocationHeadEmail = txtEmail.Text;

                _Department.InfoText = txtMemo.Text;


                _Departments.NewDepartment(_Department);
                BindSelectionControls();
                LoadDepartmentsById(Convert.ToInt32(_Department.ID));

            }
            EnablesControl();
            mainCtl.RedirectToPromptPage();
        }
        protected void DeleteDepartment(int Id)
        {
            var departmentNo = new DepartmentRepository().GetDepartmentById(Id);

            if (departmentNo != null)
            {
                new DepartmentRepository().DeleteDepartment(departmentNo);
            }

            LoadDepartmentsById(Convert.ToInt32(cboDeptNr.Value));
            BindSelectionControls();
            cboDeptNr.SelectedIndex = 0;
            cboDeptName.SelectedIndex = 0;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDepartment(Convert.ToInt32(cboDeptNr.Value));
        }

        [WebMethod]
        public static Department GetDepartment(long deptId)
        {
            DepartmentRepository _DepartmentRepository = new DepartmentRepository();
            Department _Department = new Department();

            var department = _DepartmentRepository.GetDepartmentById(deptId);
            if (department == null)
            {
                return _Department;
            }
            if (department != null)
            {
                _Department.ID = department.ID;
                _Department.Department_Nr = department.Department_Nr;
                _Department.Name = department.Name;
                _Department.ZipCode = department.ZipCode;
                _Department.Place = department.Place;
                _Department.Street = department.Street;
                _Department.HouseNumber = department.HouseNumber;

                _Department.LocationHeadName = department.LocationHeadName;
                _Department.LocationHeadFunction = department.LocationHeadFunction;
                _Department.LocationHeadPhone = department.LocationHeadPhone;
                _Department.LocationHeadMobile = department.LocationHeadMobile;
                _Department.LocationHeadEmail = department.LocationHeadEmail;

                _Department.InfoText = department.InfoText;
            }
            return _Department;
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
        public static Department GetDepartmentById(long id)
        {
            var department = new DepartmentRepository().GetDepartmentById(id);
            Department _Department = new Department()
            {

                ID = department.ID,
                Department_Nr = department.Department_Nr,
                Name = department.Name,
                ZipCode = department.ZipCode,
                Place = department.Place,
                Street = department.Street,
                HouseNumber = department.HouseNumber,

                LocationHeadName = department.LocationHeadName,
                LocationHeadFunction = department.LocationHeadFunction,
                LocationHeadPhone = department.LocationHeadPhone,
                LocationHeadMobile = department.LocationHeadMobile,
                LocationHeadEmail = department.LocationHeadEmail,

                InfoText = department.InfoText,
            };
            return _Department;
        }

        [WebMethod]
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }
    }
}