using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class Language : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsLanguage_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsLanguage_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsLanguage, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            // Handle functions before post back event

            if (!IsPostBack)
            {
                try
                {
                    String _Culture = (Session["PreferredCulture"] == null) ? "" : Session["PreferredCulture"].ToString();
                    ListSprache.Items.FindByValue(_Culture).Selected = true;
                }
                catch (Exception)
                {
                    //Session has invalid culture setting, or List has no culure option, that the session is set to
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Session["PreferredCulture"] = ListSprache.SelectedValue;

            Server.Transfer(Request.Path); //Redirect user to Language form with new culture settings
        }
    }
}