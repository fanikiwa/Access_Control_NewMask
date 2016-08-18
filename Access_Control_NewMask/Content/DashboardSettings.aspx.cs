using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;

namespace Access_Control_NewMask.Content
{
    public partial class DashboardSettings : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }
    }
}