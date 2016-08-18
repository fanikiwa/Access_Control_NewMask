using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System.Web.Services;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlanGroup : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("AccessGroup_PMode");
            }
            set
            {
                HttpContext.Current.Session["AccessGroup_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.AccessGroup, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnEntNew.Enabled = false; btnEntSave.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;

            if (!IsPostBack)
            {
                LoadAccessPlanGroups();
                if (Session["_AccessPlanGroupId"] != null)
                {
                    var id = Convert.ToInt64(Session["_AccessPlanGroupId"]);
                    ddlAccessGroupNumber.Value = id.ToString();
                    ddlAccessGroupName.Value = id.ToString();
                    txtAccessGroupNumber.Text = ddlAccessGroupNumber.Text;
                    txtAccessGroupName.Text = ddlAccessGroupName.Text;
                    EnableControls();
                    Session["_AccessPlanGroupId"] = null;
                }
                else
                {
                    DisableControls();
                }
            }
        }
        protected void LoadAccessPlanGroups()
        {
            List<TbAccessPlanGroup> listPlanGroups = new List<TbAccessPlanGroup>();
            TbAccessPlanGroup accessPlanGroup = new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = "keine" };
            listPlanGroups.Add(accessPlanGroup);
            var visitorPlans = new AccessPlanGroupRepository().GetAllAccessPlanGroups();
            listPlanGroups.AddRange(visitorPlans);
            ddlAccessGroupNumber.DataSource = listPlanGroups;
            ddlAccessGroupNumber.DataBind();
            ddlAccessGroupNumber.SelectedIndex = 0;
            ddlAccessGroupName.DataSource = listPlanGroups;
            ddlAccessGroupName.DataBind();
            ddlAccessGroupName.SelectedIndex = 0;
            txtAccessGroupNumber.Text = ddlAccessGroupNumber.Text;
            txtAccessGroupName.Text = ddlAccessGroupName.Text;
        }
        [WebMethod]
        public static long GetNextPlanNr()
        {
            long number = 0;
            List<TbAccessPlanGroup> PlanGroups = new List<TbAccessPlanGroup>();
            AccessPlanGroupRepository planGroupRepo = new AccessPlanGroupRepository();
            PlanGroups = planGroupRepo.GetAllAccessPlanGroups();
            if (PlanGroups.Count > 0)
            {
                number = Convert.ToInt64(PlanGroups.Max(i => i.AccessPlanGroupNr));
            }
            else
            {
                number = 0;
            }
            long nextNo = number + 1;
            return nextNo;
        }
        [WebMethod]
        public static AccessPlanGroupDto SaveAccessPlanGroup(long planId, long planNr, string planName)
        {
            AccessPlanGroupDto planDto = new AccessPlanGroupDto();
            if (planId == 0)
            {
                TbAccessPlanGroup accessPlanGroup = new TbAccessPlanGroup()
                {
                    ID = planId,
                    AccessPlanGroupNr = planNr,
                    AccessPlanGroupName = planName
                };
                new AccessPlanGroupRepository().NewAccessPlanGroup(accessPlanGroup);
                planDto.ID = accessPlanGroup.ID;
                planDto.planNr = accessPlanGroup.AccessPlanGroupNr;
                planDto.planName = accessPlanGroup.AccessPlanGroupName;
            }
            else if (planId > 0)
            {
                TbAccessPlanGroup accessPlanGroup = new TbAccessPlanGroup()
                {
                    ID = planId,
                    AccessPlanGroupNr = planNr,
                    AccessPlanGroupName = planName
                };
                new AccessPlanGroupRepository().EditAccessPlanGroup(accessPlanGroup);
                planDto.ID = accessPlanGroup.ID;
                planDto.planNr = accessPlanGroup.AccessPlanGroupNr;
                planDto.planName = accessPlanGroup.AccessPlanGroupName;

            }
            return planDto;

        }
        public class AccessPlanGroupDto
        {
            public long ID { get; set; }
            public long planNr { get; set; }
            public string planName { get; set; }
        }
        [WebMethod]
        public static bool CheckIfPlanNrExistsOnNew(long number)
        {
            bool exists = false;
            TbAccessPlanGroup PlanGroup = new TbAccessPlanGroup();
            PlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupByNumber(number);
            if (PlanGroup != null)
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
        public static void DeleteAccessPlanGroup(long Id)
        {
            try
            {

                var currentPlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(Id);
                if (currentPlanGroup != null)
                {
                    new AccessPlanGroupRepository().DeleteAccessPlanGroup(currentPlanGroup);
                }
            }
            catch (Exception ex)
            {

            }
        }
        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        protected void DisableControls()
        {
            btnReader.Enabled = false;
            btnAccessProfile.Enabled = false;
            btnHoliday.Enabled = false;
            btnReaderHeader.Enabled = false;
            btnAccessCalederHeader.Enabled = false;
            btnHolidayCalenderHeader.Enabled = false;
            imageBtnReader.Style.Add("cursor", "default");
            imageBtnAccessCalender.Style.Add("cursor", "default");
            imageBtnHolidayCalender.Style.Add("cursor", "default");
        }
        protected void EnableControls()
        {
            btnReader.Enabled = true;
            btnAccessProfile.Enabled = true;
            btnHoliday.Enabled = true;
            btnReaderHeader.Enabled = true;
            btnAccessCalederHeader.Enabled = true;
            btnHolidayCalenderHeader.Enabled = false;
            btnReaderHeader.Style.Add("cursor", "pointer");
            btnAccessCalederHeader.Style.Add("cursor", "pointer");
            btnHolidayCalenderHeader.Style.Add("cursor", "pointer");
            imageBtnReader.Style.Add("cursor", "pointer");
            imageBtnAccessCalender.Style.Add("cursor", "pointer");
            imageBtnHolidayCalender.Style.Add("cursor", "pointer");
        }

        protected void ddlAccessGroupNumber_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<TbAccessPlanGroup> listPlanGroups = new List<TbAccessPlanGroup>();
                TbAccessPlanGroup planGroup = new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = "keine" };
                listPlanGroups.Add(planGroup);
                var accessPlanGroups = new AccessPlanGroupRepository().GetAllAccessPlanGroups();
                listPlanGroups.AddRange(accessPlanGroups);
                ddlAccessGroupNumber.DataSource = listPlanGroups;
                ddlAccessGroupNumber.DataBind();
                ddlAccessGroupNumber.Value = e.Parameter.ToString();
            }
        }

        protected void ddlAccessGroupName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<TbAccessPlanGroup> listPlanGroups = new List<TbAccessPlanGroup>();
                TbAccessPlanGroup planGroup = new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = "keine" };
                listPlanGroups.Add(planGroup);
                var accessPlanGroups = new AccessPlanGroupRepository().GetAllAccessPlanGroups();
                listPlanGroups.AddRange(accessPlanGroups);
                ddlAccessGroupName.DataSource = listPlanGroups;
                ddlAccessGroupName.DataBind();
                ddlAccessGroupName.Value = e.Parameter.ToString();
            }
        }
    }
}