using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using System.Web.Services;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlan : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        static string culture;
        static CultureInfo cultureInfo;

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("AccessPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["AccessPlan_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.AccessPlan, out _AccessControlPermissionMode))
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
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                BIndSearchGrid();
                DisableButttons();
                BindAccessGroups();
                LoadAccessPlans();
                if (Session["GroupID"] != null)
                {
                    ddlAccessGroupNumber.Value = Session["GroupID"].ToString();
                    ddlAccessGroupName.Value = Session["GroupID"].ToString();
                    txtAccessGroupNumber.Text = ddlAccessGroupNumber.Text;
                    txtAccessGroupName.Text = ddlAccessGroupName.Text;
                    EnableButttons();
                }
                if (Session["ProfileID"] != null)
                {
                    ddlAccessProfileNumber.Value = Session["ProfileID"].ToString();
                    ddlAccessProfileName.Value = Session["ProfileID"].ToString();

                    txtAccessProfileNumber.Text = ddlAccessProfileNumber.Text;
                    txtAccessProfileName.Text = ddlAccessProfileName.Text;
                    EnableButttons();
                }
            }
        }

        [WebMethod]
        public static long SaveAccessPlan(long accessPlanId, long accessPlanNr, string accessPlanName, long groupID)
        {
            long id = 0;
            if (accessPlanId == 0)
            {
                id = CreateAccessPlan(Convert.ToInt64(accessPlanNr), accessPlanName, Convert.ToInt32(groupID));
            }
            else if (accessPlanId > 0)
            {
                id = EditAccessPlan(Convert.ToInt32(accessPlanId), Convert.ToInt64(accessPlanNr), accessPlanName, Convert.ToInt32(groupID));
            }
            return id;
        }

        public static long CreateAccessPlan(long accessPlanNr, string accessPlanName, long groupID)
        {
            AccessPlanViewModel accessPlanViewModel = new AccessPlanViewModel();
            TbAccessPlan accessPlan = new TbAccessPlan() { AccessPlanNr = accessPlanNr, AccessPlanDescription = accessPlanName, AccessGroupID = groupID };
            accessPlanViewModel.CreateAccessPlan(accessPlan);
            return accessPlan.ID;
        }

        public static long EditAccessPlan(int Id, long accessPlanNr, string accessPlanName, long groupID)
        {
            AccessPlanRepository accessPlanRep = new AccessPlanRepository();
            TbAccessPlan accessPlan2 = new TbAccessPlan();
            accessPlan2 = accessPlanRep.GetAccessPlanById(Id);
            AccessPlanViewModel accessPlanViewModel = new AccessPlanViewModel();
            TbAccessPlan accessPlan = new TbAccessPlan() { ID = Id, AccessPlanNr = accessPlanNr, AccessPlanDescription = accessPlanName, AccessGroupID = groupID, AccessCalendarId = accessPlan2.AccessCalendarId, BuildingPlanID = accessPlan2.BuildingPlanID };
            accessPlanViewModel.UpdateAccessPlan(accessPlan);
            return accessPlan.ID;
        }

        protected void ddlAccessProfileNumber_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            List<TbAccessPlan> listAccessPlans = new List<TbAccessPlan>();
            listAccessPlans.Add(new TbAccessPlan() { ID = 0, AccessPlanDescription = "Keine" });
            //listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] passedValues = e.Parameter.Split(';');
                var id = Convert.ToInt64(passedValues[0]);
                var filter = Convert.ToInt64(passedValues[1]);
                var evt = Convert.ToInt32(passedValues[2]);
                if (evt == 1)
                {
                    if (filter > 0)
                    {
                        listAccessPlans.AddRange(accessPlans.GetAllAccessPlans().Where(x => x.AccessGroupID == filter));
                    }
                    else
                    {
                        listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
                    }
                    ddlAccessProfileNumber.DataSource = listAccessPlans;
                    ddlAccessProfileNumber.DataBind();
                    ddlAccessProfileNumber.SelectedIndex = 0;
                    if (listAccessPlans.Count > 1)
                    {
                        ddlAccessProfileNumber.SelectedIndex = 1;
                    }
                }
                else
                {
                    listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
                    ddlAccessProfileNumber.DataSource = listAccessPlans;
                    ddlAccessProfileNumber.DataBind();
                    ddlAccessProfileNumber.Value = id.ToString();
                }

            }

        }

        protected void ddlAccessProfileName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            List<TbAccessPlan> listAccessPlans = new List<TbAccessPlan>();
            listAccessPlans.Add(new TbAccessPlan() { ID = 0, AccessPlanDescription = "Keine" });
            //listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());

            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] passedValues = e.Parameter.Split(';');
                var id = Convert.ToInt64(passedValues[0]);
                var filter = Convert.ToInt64(passedValues[1]);
                var evt = Convert.ToInt32(passedValues[2]);
                if (evt == 1)
                {
                    if (filter > 0)
                    {
                        listAccessPlans.AddRange(accessPlans.GetAllAccessPlans().Where(x => x.AccessGroupID == filter));
                    }
                    else
                    {
                        listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
                    }

                    ddlAccessProfileName.DataSource = listAccessPlans;
                    ddlAccessProfileName.DataBind();
                    ddlAccessProfileName.SelectedIndex = 0;
                    if (listAccessPlans.Count > 1)
                    {
                        ddlAccessProfileName.SelectedIndex = 1;
                    }
                }
                else
                {
                    listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
                    ddlAccessProfileName.DataSource = listAccessPlans;
                    ddlAccessProfileName.DataBind();
                    ddlAccessProfileName.Value = id.ToString();
                }

            }

        }
        protected void BindAccessGroups()
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            List<AccessGroup> listAccessGroups = new List<AccessGroup>();
            listAccessGroups.Add(new AccessGroup() { Id = 0, AccessGroupNumber = 0, AccessGroupName = "keine" });
            listAccessGroups.AddRange(accessGroups.GetAllAccessPlanAccessGroups().Where(x => x.AccessGroupType == 2));

            ddlAccessGroupNumber.DataSource = listAccessGroups;
            ddlAccessGroupNumber.DataBind();
            ddlAccessGroupNumber.SelectedIndex = 0;

            ddlAccessGroupName.DataSource = listAccessGroups;
            ddlAccessGroupName.DataBind();
            ddlAccessGroupName.SelectedIndex = 0;

            Session["AccessGroups"] = listAccessGroups;
        }
        protected void LoadAccessPlans()
        {
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            List<TbAccessPlan> listAccessPlans = new List<TbAccessPlan>();
            listAccessPlans.Add(new TbAccessPlan() { ID = 0, AccessPlanDescription = "Keine" });
            listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());

            ddlAccessProfileNumber.DataSource = listAccessPlans;
            ddlAccessProfileNumber.DataBind();
            ddlAccessProfileNumber.SelectedIndex = 0;

            ddlAccessProfileName.DataSource = listAccessPlans;
            ddlAccessProfileName.DataBind();
            ddlAccessProfileName.SelectedIndex = 0;

            Session["AccessPlans"] = listAccessPlans;
        }
        protected void DisableButttons()
        {
            btnPersonnel.Enabled = false;
            btnReader.Enabled = false;
            btnAccessProfile.Enabled = false;
            btnHoliday.Enabled = false;
            btnMembers.Enabled = false;

            btnPersonen.Enabled = false;
            btnMember.Enabled = false;
            btnReaderHeader.Enabled = false;
            btnAccessCalederHeader.Enabled = false;
            btnHolidayCalenderHeader.Enabled = false;


            imageBtnPersonen.Style.Add("cursor", "default");
            imageBtnPersonen.Style.Add("cursor", "default");
            btnImagemembers.Style.Add("cursor", "default");
            imageBtnReader.Style.Add("cursor", "default");
            imageBtnAccessCalender.Style.Add("cursor", "default");
            imageBtnHolidayCalender.Style.Add("cursor", "default");
        }
        protected void EnableButttons()
        {
            btnPersonnel.Enabled = true;
            btnReader.Enabled = true;
            btnAccessProfile.Enabled = true;
            btnHoliday.Enabled = true;
            btnMembers.Enabled = true;

            btnPersonen.Enabled = true;
            btnMember.Enabled = true;
            btnReaderHeader.Enabled = true;
            btnAccessCalederHeader.Enabled = true;
            btnHolidayCalenderHeader.Enabled = true;

            imageBtnPersonen.Style.Add("cursor", "pointer");
            imageBtnPersonen.Style.Add("cursor", "pointer");
            btnImagemembers.Style.Add("cursor", "pointer");
            imageBtnReader.Style.Add("cursor", "pointer");
            imageBtnAccessCalender.Style.Add("cursor", "pointer");
            imageBtnHolidayCalender.Style.Add("cursor", "pointer");
        }
        [WebMethod]
        public static long GetNextPlanNr()
        {
            long item = 0;
            AccessPlanViewModel accessPlanViewModel = new AccessPlanViewModel();
            List<TbAccessPlan> accessPlansList = new List<TbAccessPlan>();
            accessPlansList.AddRange(accessPlanViewModel.AccessPlans());
            if (accessPlansList.Count > 0)
            {
                item = Convert.ToInt64(accessPlansList.Max(i => i.AccessPlanNr));
            }
            else
            {
                item = 0;
            }
            long nextNo = item + 1;
            return nextNo;
        }
        [WebMethod]
        public static string ReturnGroupId(int planId)
        {
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(planId);
            return accessPlan.AccessGroupID.ToString();
        }
        [WebMethod]
        public static void DeleteAccessPlan(int planId)
        {
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(planId);
            if (accessPlan != null)
            {
                new AccessPlanViewModel().DeleteAccessPlan(accessPlan);
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
        protected void BIndSearchGrid()
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            AccessPlanRepository _AccessPlanRepository = new AccessPlanRepository();
            List<TbAccessPlan> lst = new List<TbAccessPlan>();
            List<AccessGroupDto> dtolist = new List<AccessGroupDto>();
            List<AccessGroup> listAccessGroups = new List<AccessGroup>();
            listAccessGroups.AddRange(accessGroups.GetAllAccessPlanAccessGroups().Where(x => x.AccessGroupType == 2));
            AccessGroupDto AccessGroupDto = null;
            lst = _AccessPlanRepository.GetAllAccessPlans().FindAll(x => x.ID > 0);
            foreach (TbAccessPlan zpf in lst)
            {
                AccessGroupDto = new AccessGroupDto();
                AccessGroupDto.id = zpf.ID;
                AccessGroupDto.AccessGroupNumber = Convert.ToInt32(zpf.AccessGroup.AccessGroupNumber);
                AccessGroupDto.AccessPlanNr = Convert.ToInt32(zpf.AccessPlanNr);
                AccessGroupDto.AccessPlanDescription = zpf.AccessPlanDescription;
                AccessGroupDto.AccessGroupName = zpf.AccessGroup.AccessGroupName;
                dtolist.Add(AccessGroupDto);
            }
            grdAccessProfileList.DataSource = dtolist;
            grdAccessProfileList.DataBind();
            grdAccessProfileList.FocusedRowIndex = -1;
        }

        protected void grdAccessProfileList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            BIndSearchGrid();
        }
        [WebMethod]
        public static string SetSessionValues(string groupId, string groupNr, string groupName, string planId, string planNr, string planName, string url)
        {
            HttpContext.Current.Session["GroupID"] = groupId;
            HttpContext.Current.Session["ProfileID"] = planId;
            HttpContext.Current.Session["AccessGroupNumber"] = groupNr;
            HttpContext.Current.Session["AccessGroupName"] = groupName;
            HttpContext.Current.Session["AccessProfileNumber"] = planNr;
            HttpContext.Current.Session["AccessProfileName"] = planName;
            return url;
        }
    }
}