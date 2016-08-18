using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class VisitorPlan : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        string culture;
        static CultureInfo cultureInfo;
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("VisitorPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["VisitorPlan_PMode"] = value;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.VisitorPlan, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {

                btnEntSave.Enabled = false; btnEntNew.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;

            if (!IsPostBack)
            {
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                LoadVisitorAccessPlans();
                if (Session["visitorProfileId"] != null)
                {
                    var id = Convert.ToInt64(Session["visitorProfileId"]);
                    ddlVisitorProfileNumber.Value = id.ToString();
                    ddlVisitorProfileName.Value = id.ToString();
                    txtVisitorProfileNumber.Text = ddlVisitorProfileNumber.Text;
                    txtVisitorProfileName.Text = ddlVisitorProfileName.Text;
                    EnableControls();
                    Session["visitorProfileId"] = null;
                }
                else
                {
                    DisableControls();
                }
                //only from visitors
                GetAccessPLan();
            }
        }
        protected void LoadVisitorAccessPlans()
        {
            List<TbVisitorPlan> listVisitorPlans = new List<TbVisitorPlan>();
            TbVisitorPlan visitorPlan = new TbVisitorPlan() { ID = 0, VisitorPlanNr = 0, VisitorPlanDescription = "keine" };
            listVisitorPlans.Add(visitorPlan);
            var visitorPlans = new VisitorPlanViewModels().GetAllVisitorPlans();
            listVisitorPlans.AddRange(visitorPlans);
            ddlVisitorProfileNumber.DataSource = listVisitorPlans;
            ddlVisitorProfileNumber.DataBind();
            ddlVisitorProfileNumber.SelectedIndex = 0;
            ddlVisitorProfileName.DataSource = listVisitorPlans;
            ddlVisitorProfileName.DataBind();
            ddlVisitorProfileName.SelectedIndex = 0;
            txtVisitorProfileNumber.Text = ddlVisitorProfileNumber.Text;
            txtVisitorProfileName.Text = ddlVisitorProfileName.Text;
        }
        [WebMethod]
        public static long GetNextPlanNr()
        {
            long number = 0;
            List<TbVisitorPlan> visitorPlans = new List<TbVisitorPlan>();
            VisitorPlanViewModels visitors = new VisitorPlanViewModels();
            visitorPlans = visitors.GetAllVisitorPlans();
            if (visitorPlans.Count > 0)
            {
                number = Convert.ToInt64(visitorPlans.Max(i => i.VisitorPlanNr));
            }
            else
            {
                number = 0;
            }
            long nextNo = number + 1;
            return nextNo;
        }
        [WebMethod]
        public static VisitorPlanDto SaveVisitorPlan(long planId, long planNr, string planName)
        {
            VisitorPlanDto planDto = new VisitorPlanDto();
            if (planId == 0)
            {
                TbVisitorPlan visitorPlan = new TbVisitorPlan()
                {
                    ID = planId,
                    VisitorPlanNr = planNr,
                    VisitorPlanDescription = planName
                };
                VisitorPlanViewModels insertVisitor = new VisitorPlanViewModels();
                insertVisitor.CreateVisitorPlan(visitorPlan);
                planDto.ID = visitorPlan.ID;
                planDto.planNr = visitorPlan.VisitorPlanNr;
                planDto.planName = visitorPlan.VisitorPlanDescription;
            }
            else if (planId > 0)
            {
                VisitorPlanViewModels selectVisitor = new VisitorPlanViewModels();
                TbVisitorPlan currentVisitor = new TbVisitorPlan();
                currentVisitor = selectVisitor.GetVisitorPlanByID(planId);
                TbVisitorPlan visitorPlan = new TbVisitorPlan()
                {
                    ID = planId,
                    VisitorPlanNr = planNr,
                    VisitorPlanDescription = planName,
                    AccessCalendarId = currentVisitor.AccessCalendarId,
                    BuildingPlanID = currentVisitor.BuildingPlanID,
                    HolidayPlanCalendarId = currentVisitor.HolidayPlanCalendarId
                };
                VisitorPlanViewModels Visitor = new VisitorPlanViewModels();
                Visitor.UpdateVisitorPlan(visitorPlan);
                planDto.ID = visitorPlan.ID;
                planDto.planNr = visitorPlan.VisitorPlanNr;
                planDto.planName = visitorPlan.VisitorPlanDescription;
            }
            return planDto;

        }
        public class VisitorPlanDto
        {
            public long ID { get; set; }
            public long planNr { get; set; }
            public string planName { get; set; }
        }

        protected void ddlVisitorProfileNumber_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<TbVisitorPlan> listVisitorPlans = new List<TbVisitorPlan>();
                TbVisitorPlan visitorPlan = new TbVisitorPlan() { ID = 0, VisitorPlanNr = 0, VisitorPlanDescription = "keine" };
                listVisitorPlans.Add(visitorPlan);
                var visitorPlans = new VisitorPlanViewModels().GetAllVisitorPlans();
                listVisitorPlans.AddRange(visitorPlans);
                ddlVisitorProfileNumber.DataSource = listVisitorPlans;
                ddlVisitorProfileNumber.DataBind();
                ddlVisitorProfileNumber.Value = e.Parameter.ToString();
            }
        }

        protected void ddlVisitorProfileName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<TbVisitorPlan> listVisitorPlans = new List<TbVisitorPlan>();
                TbVisitorPlan visitorPlan = new TbVisitorPlan() { ID = 0, VisitorPlanNr = 0, VisitorPlanDescription = "keine" };
                listVisitorPlans.Add(visitorPlan);
                var visitorPlans = new VisitorPlanViewModels().GetAllVisitorPlans();
                listVisitorPlans.AddRange(visitorPlans);
                ddlVisitorProfileName.DataSource = listVisitorPlans;
                ddlVisitorProfileName.DataBind();
                ddlVisitorProfileName.Value = e.Parameter.ToString();
            }
        }
        [WebMethod]
        public static bool CheckIfPlanNrExistsOnNew(long number)
        {
            bool exists = false;
            TbVisitorPlan visitorPlan = new TbVisitorPlan();
            VisitorPlanViewModels planViewModel = new VisitorPlanViewModels();
            visitorPlan = planViewModel.GetVisitorPlanByNr(number);
            if (visitorPlan != null)
            {
                exists = true;
            }
            else
            {
                exists = false;
            }

            return exists;
        }
        [WebMethod]
        public static void DeleteVisitorPlan(long Id)
        {
            try
            {

                var currentVisitor = new VisitorPlanViewModels().GetVisitorPlanByID(Id);
                if (currentVisitor != null)
                {
                    new VisitorPlanViewModels().DeleteVisitorPlan(currentVisitor);
                }
            }
            catch (Exception ex)
            {

            }
        }
        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void btnReader_Click(object sender, EventArgs e)
        {
            var profileId = ddlVisitorProfileNumber.Value;
            if (Convert.ToInt64(profileId) < 1)
            {
                LoadVisitorAccessPlans();
            }
            else
            {
                Response.Redirect(String.Format("/Content/VisitorPlanReader.aspx?profileId={0}", profileId));
            }

        }

        protected void btnAccessProfile_Click(object sender, EventArgs e)
        {
            var profileId = ddlVisitorProfileNumber.Value;
            if (Convert.ToInt64(profileId) < 1)
            {
                LoadVisitorAccessPlans();
            }
            else
            {
                Response.Redirect(String.Format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", profileId));
            }

        }

        protected void btnReaderHeader_Click(object sender, EventArgs e)
        {
            var profileId = ddlVisitorProfileNumber.Value;
            if (Convert.ToInt64(profileId) < 1)
            {
                LoadVisitorAccessPlans();
            }
            else
            {
                Response.Redirect(String.Format("/Content/VisitorPlanReader.aspx?profileId={0}", profileId));
            }

        }

        protected void imageBtnReader_Click(object sender, ImageClickEventArgs e)
        {
            var profileId = ddlVisitorProfileNumber.Value;
            if (Convert.ToInt64(profileId) < 1)
            {
                LoadVisitorAccessPlans();
            }
            else
            {
                Response.Redirect(String.Format("/Content/VisitorPlanReader.aspx?profileId={0}", profileId));
            }

        }

        protected void btnAccessCalederHeader_Click(object sender, EventArgs e)
        {
            var profileId = ddlVisitorProfileNumber.Value;
            if (Convert.ToInt64(profileId) < 1)
            {
                LoadVisitorAccessPlans();
            }
            else
            {
                Response.Redirect(String.Format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", profileId));
            }

        }

        protected void imageBtnAccessCalender_Click(object sender, ImageClickEventArgs e)
        {
            var profileId = ddlVisitorProfileNumber.Value;
            if (Convert.ToInt64(profileId) < 1)
            {
                LoadVisitorAccessPlans();
            }
            else
            {
                Response.Redirect(String.Format("/Content/VisitorPlanVisitorCalender.aspx?profileId={0}", profileId));
            }

        }
        protected void DisableControls()
        {
            btnReader.Enabled = false;
            btnAccessProfile.Enabled = false;
            btnReaderHeader.Enabled = false;
            btnAccessCalederHeader.Enabled = false;
            imageBtnReader.Style.Add("cursor", "default");
            imageBtnAccessCalender.Style.Add("cursor", "default");
        }
        protected void EnableControls()
        {
            btnReader.Enabled = true;
            btnAccessProfile.Enabled = true;
            btnReaderHeader.Enabled = true;
            btnAccessCalederHeader.Enabled = true;
            imageBtnReader.Style.Add("cursor", "pointer");
            imageBtnAccessCalender.Style.Add("cursor", "pointer");
        }
        protected void GetAccessPLan()
        {
            if ((!string.IsNullOrEmpty(Request.QueryString["profileId"])) && (!string.IsNullOrEmpty(Request.QueryString["lock"])))
            {
                var id = Request.QueryString["profileId"];
                ddlVisitorProfileNumber.Value = id.ToString();
                ddlVisitorProfileName.Value = id.ToString();
                txtVisitorProfileNumber.Text = ddlVisitorProfileNumber.Text;
                txtVisitorProfileName.Text = ddlVisitorProfileName.Text;
                ddlVisitorProfileNumber.ClientEnabled = false;
                ddlVisitorProfileName.ClientEnabled = false;
                txtVisitorProfileNumber.Enabled = false;
                ddlVisitorProfileName.Enabled = false;
                btnEntNew.Enabled = false;
                btnEntSave.Enabled = false;
                btnCancelDel.Enabled = false;
                EnableControls();
            }

        }
    }
}