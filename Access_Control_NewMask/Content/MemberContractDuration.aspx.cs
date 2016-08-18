using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System.Web.Services;
using Access_Control_NewMask.Dtos;
using System.Globalization;
using System.Data;
using System.Collections;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class MemberContractDuration : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("MembersContract_PMode");
            }
            set
            {
                HttpContext.Current.Session["MembersContract_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.MembersContract, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnsave.Enabled = false; btnapply.Enabled = false; btnDelete.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnsave.UniqueID;

            if (Session["Duration"] != null)
            {
                var duration = (DataTable)Session["Duration"];
                grdContractDurtaion.DataSource = duration;
                grdContractDurtaion.DataBind();
            }
            if (!IsPostBack)
            {
                BindContractDuration();
                if (Session["DurationRedirct"] != null)
                {

                }
            }


        }
        protected void BindContractDuration()
        {
            var duration = new MemberContractDurationViewModel().DurationRowData();
            grdContractDurtaion.DataSource = duration;
            grdContractDurtaion.DataBind();
            Session["Duration"] = duration;
        }

        protected void grdContractDurtaion_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            BindContractDuration();
            grdContractDurtaion.Selection.UnselectAll();
        }

        protected void grdContractDurtaion_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            var updateValues = e.UpdateValues;
            foreach (var updateValue in updateValues)
            {
                try
                {
                    var keyValues = updateValue.Keys;
                    var newValues = updateValue.NewValues;
                    var oldValues = updateValue.OldValues;

                    var Id = Convert.ToInt64(keyValues["ID"]);
                    var durationNr = newValues["DurationNr"];
                    var duration = newValues["Duration"];

                    if (Id > 0)
                    {
                        MemberDuration memberDuration = new MemberDuration()
                        {
                            ID = Id,
                            DurationNr = (durationNr != null) ? Convert.ToInt64(durationNr) : (long?)null,
                            Duration = (durationNr != null) ? duration.ToString().Trim() : "",
                        };
                        new MemberDurationRepository().EditDuration(memberDuration);
                    }
                    else if (Id < 1)
                    {
                        MemberDuration memberDuration = new MemberDuration()
                        {
                            DurationNr = (durationNr != null) ? Convert.ToInt64(durationNr) : (long?)null,
                            Duration = (durationNr != null) ? duration.ToString().Trim() : "",
                        };
                        new MemberDurationRepository().NewDuration(memberDuration);
                    }



                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
            }
            e.Handled = true;
            BindContractDuration();
            grdContractDurtaion.Selection.UnselectAll();
        }
        [WebMethod]
        public static void DeleteDuration(long Id)
        {
            var duration = new MemberDurationRepository().GetDurationById(Id);
            if (duration != null)
            {
                new MemberDurationRepository().DeleteDuration(duration);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["DurationRedirct"] != null)
            {
                Response.Redirect("/Content/Members.aspx");
            }
            else
            {
                Response.Redirect("/Content/Settings.aspx");
            }
        }
        [WebMethod]
        public static string RidirectUrl(long id)
        {
            string url = "/Content/Settings.aspx";
            if (HttpContext.Current.Session["DurationRedirct"] != null)
            {
                var data = (DurationRedirectDto)HttpContext.Current.Session["DurationRedirct"];
                if (data != null)
                {
                    data.objectId = id;
                    url = data.pageFrom;
                    HttpContext.Current.Session["DurationRedirct"] = data;
                }
            }
            return url;

        }
        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void grdContractDurtaion_CustomColumnSort(object sender, DevExpress.Web.CustomColumnSortEventArgs e)
        {
            if (e.Column.FieldName == "Duration" || e.Column.FieldName == "DurationNr")
            {
                int s1 = 0;
                int s2 = 0;
                if (e.Value1.ToString().Length > 0)
                {
                    s1 = 1;
                }
                if (e.Value2.ToString().Length > 0)
                {
                    s2 = 1;
                }
                if (e.SortOrder.ToString() == "Ascending")
                {

                    if (s1 > s2)
                        e.Result = -1;
                    else
                        if (s1 == s2)
                        e.Result = Comparer.Default.Compare(s1, s2);
                    else
                        e.Result = 1;
                }
                else
                {

                    if (s1 > s2)
                        e.Result = 1;
                    else
                        if (s1 == s2)
                        e.Result = Comparer.Default.Compare(s1, s2);
                    else
                        e.Result = -1;
                }
            }
            e.Handled = true;
        }
    }
}