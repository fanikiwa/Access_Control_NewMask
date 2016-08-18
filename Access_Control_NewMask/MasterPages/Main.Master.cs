using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Pers_Nr"] != null)
            {
                long persNr = 0;
                Int64.TryParse(Convert.ToString(HttpContext.Current.Session["Pers_Nr"]), out persNr);

                string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
                string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

                lblGreeting.Text = "Willkommen,";
                lblName.Text = String.Format("{0}{1}", firstName, persNr > 0 ? ", " + lastName : "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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