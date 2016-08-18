using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.MasterPages
{
    public partial class Accessplan : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Page.Title) && this.Page.Master.FindControl("pagenamelbl") != null)
            {
                Label _pagenamelbl = (Label)(this.Page.Master.FindControl("pagenamelbl"));
                _pagenamelbl.Text = this.Page.Title;
            }
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Logout.aspx");
        }
    }
}