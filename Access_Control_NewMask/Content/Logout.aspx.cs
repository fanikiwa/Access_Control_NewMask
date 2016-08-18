using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Access_Control_NewMask.Content
{
    public partial class Logout : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnyes.UniqueID;
        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/");
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            mainCtl.RedirectToDashoard();
        }
    }
}