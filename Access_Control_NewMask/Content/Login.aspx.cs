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
    public partial class Login : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        string userName, password;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.BtnLogin.UniqueID;
            mainCtl.CheckQStringForLoginAttempt();
            mainCtl.CheckAuthCookie();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            TxtUser.Focus();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            GetUILoginDetails();
            if (userName == "") return; //No UserName Entered Error here
            if (password == "") return; //No Password Entered Error here

            mainCtl.LoginUser(password, userName, "");
            //lblLogintext.Text = GetLocalizedText("Invalidcredentials");
            //lblLogintext.ForeColor = System.Drawing.Color.Red;
        }

        private void GetUILoginDetails()
        {
            userName = TxtUser.Text.Trim();
            password = TxtPassword.Text.Trim();
        }
    }
}