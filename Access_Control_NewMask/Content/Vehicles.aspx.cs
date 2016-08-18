using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System.Web.Services;
using System.Globalization;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class Vehicles : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Vehicles_PMode");
            }
            set
            {
                HttpContext.Current.Session["Vehicles_PMode"] = value;
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Vehicles, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSaveManufacturer.Enabled = false; btnSaveModel.Enabled = false;
                btnNewManufacturer.Enabled = false; btnNewModel.Enabled = false;
                btnDeleteManufacturer.Enabled = false; btnDeleteModel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSaveModel.UniqueID;

            if (!IsPostBack)
            {
                BindVehicleManufacturer();
            }
        }
        protected void BindVehicleManufacturer()
        {
            List<VehicleType> vTypesList = new List<VehicleType>();
            vTypesList.AddRange( new VehicleTypeRepository().GetVehicleType());
            var vehiclesTypes = vTypesList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).ToList();
            cboVehicleTypes.DataSource = vehiclesTypes;
            cboVehicleTypes.DataBind();
            cboVehicleTypes.SelectedIndex = 0;
            grdManufacturer.DataSource = vehiclesTypes;
            grdManufacturer.DataBind();
            grdManufacturer.FocusedRowIndex = 0;
            if(vehiclesTypes.Count > 0)
            {
                BindGridVehicleModel(cboVehicleTypes.Text);
                lblVehicleManu.Text = cboVehicleTypes.Text;
            }
        }
        protected void BindGridVehicleModel(string maufacturer)
        {
            if (!string.IsNullOrEmpty(maufacturer))
            {
                var vTypesList = new VehicleTypeRepository().GetVehicleType();
                var vehicleModels = vTypesList.Where(m => m.Name == maufacturer && (m.Type ?? "").Trim() != "");
                grdVehicleModel.DataSource = vehicleModels;
                grdVehicleModel.DataBind();
                grdVehicleModel.FocusedRowIndex = -1;
            }

        }

        protected void cboVehicleTypes_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<VehicleType> vTypesList = new List<VehicleType>();
                vTypesList.AddRange(new VehicleTypeRepository().GetVehicleType());
                var vehiclesTypes = vTypesList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).ToList();
                cboVehicleTypes.DataSource = vehiclesTypes;
                cboVehicleTypes.DataBind();
                var currentType = vehiclesTypes.Find(x => x.Name == e.Parameter);
                if(currentType != null)
                {
                    cboVehicleTypes.Value = currentType.ID.ToString();
                }
            }
            else
            {
                BindVehicleManufacturer();
            }


        }

        protected void grdManufacturer_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                List<VehicleType> vTypesList = new List<VehicleType>();
                vTypesList.AddRange(new VehicleTypeRepository().GetVehicleType());
                var vehiclesTypes = vTypesList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).ToList();
                grdManufacturer.DataSource = vehiclesTypes;
                grdManufacturer.DataBind();
                grdManufacturer.FocusedRowIndex = Convert.ToInt32(e.Parameters);
            }
        }

        protected void grdVehicleModel_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            var maufacturer = e.Parameters;
            if (!string.IsNullOrEmpty(maufacturer))
            {
                var vTypesList = new VehicleTypeRepository().GetVehicleType();
                var vehicleModels = vTypesList.Where(m => m.Name == maufacturer && (m.Type??"").Trim() != "");
                grdVehicleModel.DataSource = vehicleModels;
                grdVehicleModel.DataBind();
                grdVehicleModel.FocusedRowIndex = -1;
            }
        }
        [WebMethod]
        public static string SaveManufacturer(long id, string name, string holder)
        {
            string _name = string.Empty;
            if (id == 0)
            {
                VehicleType type = new VehicleType()
                {
                    Name = name
                };
                new VehicleTypeRepository().NewVehicleType(type);
                _name = type.Name;
            }
            else if(id > 0)
            {
                var manu = new VehicleTypeRepository().GetVehicleTypeById(id);
                if(manu != null)
                {
                    var _VehiclesManu = new VehicleTypeRepository().getVehicleTypeByNames(manu.Name);
                    foreach (var vehicle in _VehiclesManu)
                    {
                        VehicleType type = new VehicleType()
                        {
                            ID = vehicle.ID,
                            Name = name,
                            Type = vehicle.Type
                        };
                        new VehicleTypeRepository().EditvehicleType(type);
                    }
                    _name = name;
                }
                else
                {
                    _name = holder;
                }

            }
            return _name;
        }
        [WebMethod]
        public static long SaveVehicleModel(long id, string manufacturer,string model)
        {
            long num = 0;
            if (id == 0)
            {
                VehicleType type = new VehicleType()
                {
                    Name = manufacturer,
                    Type = model
                };
                new VehicleTypeRepository().NewVehicleType(type);
                num = type.ID;
            }
            else
            {
                VehicleType type = new VehicleType()
                {
                    ID = id,
                    Name = manufacturer,
                    Type = model
                };
                new VehicleTypeRepository().EditvehicleType(type);
                num = type.ID;
            }
            return num;
        }
        [WebMethod]
        public static void DeleteManufacturer(string name)
        {
            var _VehiclesManu = new VehicleTypeRepository().getVehicleTypeByNames(name);
            foreach (var vehicle in _VehiclesManu)
            {

                new VehicleTypeRepository().DeleteVehicleType(vehicle);
            }
        }
        [WebMethod]
        public static void DeleteModel(long Id)
        {
            var _VehicleModel = new VehicleTypeRepository().GetVehicleTypeById(Id);
            if(_VehicleModel != null)
            {
                //new VehicleTypeRepository().DeleteVehicleType(_VehicleModel);
                VehicleType type = new VehicleType()
                {
                    ID = _VehicleModel.ID,
                    Name = _VehicleModel.Name,
                    Type = null
                };
                new VehicleTypeRepository().EditvehicleType(type);
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }
        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
    }
}