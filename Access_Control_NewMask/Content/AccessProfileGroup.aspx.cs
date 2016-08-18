using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;

namespace Access_Control_NewMask.Content
{
    public partial class AccessProfileGroup : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsAccessProfileGroup_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsAccessProfileGroup_PMode"] = value;
            }
        }
        AccessGroupViewModel _AccessGroupViewModel = new AccessGroupViewModel();
        static long detectedChangesIndex = 0;
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit,
            Refresh
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsAccessProfileGroup, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

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
                loadInitialDropdowns();
                hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
                hiddenFieldDetectChanges.Value = "0";
            }
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == ((int)FormMode.Refresh))
            {
                loadInitialDropdowns();
            }
        }

        protected void loadInitialDropdowns()
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            var grouplist = _AccessGroupRepository.GetAllAccessProfileGroups();
            if (grouplist.Count != 0)
            {
                cboGroupNo.DataSource = grouplist;
                cboGroupNo.DataBind();
                cboGroupNo.SelectedIndex = 0;

                cboGroupDescription.DataSource = grouplist;
                cboGroupDescription.DataBind();
                cboGroupDescription.SelectedIndex = 0;
                if (detectedChangesIndex != 0)
                {
                    cboGroupNo.Value = detectedChangesIndex.ToString();
                    cboGroupDescription.Value = detectedChangesIndex.ToString();
                    txtGroupNo.Text = cboGroupNo.SelectedItem.Text;
                    txtGroupName.Text = cboGroupDescription.SelectedItem.Text;
                    var index = grouplist.FindIndex(a => a.Id == detectedChangesIndex);
                    txtMemo.Text = grouplist[index].Memo;
                    detectedChangesIndex = 0;
                    hiddenFieldDetectChanges.Value = "0";
                    BackButtonRedirection();
                }
                else
                {
                    txtGroupNo.Text = grouplist[0].AccessGroupNumber.ToString();
                    txtGroupName.Text = grouplist[0].AccessGroupName;
                    txtMemo.Text = grouplist[0].Memo;
                }
                hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
            }
            else
            {
                List<AccessGroup> lstNone = new List<AccessGroup>();
                lstNone.Add(new AccessGroup() { Id = 0, AccessGroupNumber = 0, AccessGroupName = Resources.LocalizedText.None });
                cboGroupNo.DataSource = lstNone;
                cboGroupNo.DataBind();
                cboGroupDescription.DataSource = lstNone;
                cboGroupDescription.DataBind();
                txtGroupNo.Text = String.Empty;
                txtGroupName.Text = String.Empty;
                txtMemo.Text = String.Empty;
                hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
            }
            //hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
        }
        protected void populateControls(int pid)
        {
            AccessGroupRepository __AccessGroupRepository = new AccessGroupRepository();

            var accessGroups = __AccessGroupRepository.GetAllAccessProfileGroups();
            var vPxists = accessGroups.Where(x => x.Id == pid).FirstOrDefault();

            if (vPxists != null)
            {
                txtGroupNo.Text = vPxists.AccessGroupNumber.ToString();
                txtGroupName.Text = vPxists.AccessGroupName;
                txtMemo.Text = vPxists.Memo;

            }
        }
        protected void clearControls()
        {
            txtGroupNo.Text = "";
            txtGroupName.Text = "";
            txtMemo.Text = "";
            cboGroupNo.Items.Clear();
            cboGroupDescription.Items.Clear();
        }

        protected void enableDisableControls()
        {

            cboGroupNo.SelectedIndex = -0;
            cboGroupDescription.SelectedIndex = -0;

            cboGroupNo.ClientEnabled = false;
            cboGroupDescription.ClientEnabled = false;
        }

        private void SetNextGroupNr()
        {
            txtGroupNo.Text = _AccessGroupViewModel.GetNextAccessProfileGroupNr().ToString();
            txtGroupName.Focus();
        }

        protected void cboGroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            var grouplist = _AccessGroupRepository.GetAllAccessProfileGroups();
            cboGroupNo.DataSource = grouplist;
            cboGroupNo.DataBind();

            cboGroupDescription.DataSource = grouplist;
            cboGroupDescription.DataBind();


            cboGroupDescription.Value = cboGroupNo.Value;
            populateControls(Convert.ToInt32(cboGroupNo.Value));
        }

        protected void cboGroupDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            var grouplist = _AccessGroupRepository.GetAllAccessProfileGroups();
            cboGroupNo.DataSource = grouplist;
            cboGroupNo.DataBind();

            cboGroupDescription.DataSource = grouplist;
            cboGroupDescription.DataBind();

            cboGroupNo.SelectedIndex = cboGroupDescription.SelectedIndex;
            populateControls(Convert.ToInt32(cboGroupDescription.Value));
        }

        protected void btnEntNew_Click(object sender, EventArgs e)
        {
            clearControls();
            enableDisableControls();
            SetNextGroupNr();
            hiddenFieldDetectChanges.Value = ((int)FormMode.Display).ToString();
        }

        protected void btnEntSave_Click(object sender, EventArgs e)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            AccessGroup _AccessGroup = new AccessGroup();
            if (string.IsNullOrEmpty(txtGroupNo.Text))
            {
                return;
            }

            int formMode;
            if (cboGroupNo.Value == null)
            {
                if (accessProfileGroupNoAlreadyExists(txtGroupNo.Text))
                {
                    var title = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    var message = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    ClientScript.RegisterStartupScript(GetType(), "ImportantInfoDialogPrompt", "ImportantInfoDialogPrompt('" + title + "', '" + message + "');", true);
                }
                else
                {
                    _AccessGroup.AccessGroupNumber = Convert.ToInt32(txtGroupNo.Text);
                    _AccessGroup.AccessGroupName = txtGroupName.Text;
                    _AccessGroup.Memo = txtMemo.Text;

                    _AccessGroupRepository.NewAccessProfileGroup(_AccessGroup);
                    loadInitialDropdowns();
                    cboGroupNo.Value = _AccessGroup.Id.ToString();
                    cboGroupDescription.Value = _AccessGroup.Id.ToString();
                    txtGroupNo.Text = _AccessGroup.AccessGroupNumber.ToString();
                    txtGroupName.Text = _AccessGroup.AccessGroupName;
                    txtMemo.Text = _AccessGroup.Memo;

                }
                cboGroupNo.ClientEnabled = true;
                cboGroupDescription.ClientEnabled = true;
                hiddenFieldDetectChanges.Value = ((int)FormMode.None).ToString();
                return;

            }
            string condition = cboGroupNo.Value.ToString();
            //int formMode;
            if (!(string.IsNullOrEmpty(cboGroupNo.Value.ToString())))
            {
                var accessProfileGroupId = 0;
                int.TryParse(cboGroupNo.Value.ToString(), out accessProfileGroupId);
                var accessProfileGroup = new AccessGroupRepository().GetAccessProfileGroupById(accessProfileGroupId);
                if (accessProfileGroup != null)
                {
                    formMode = (int)FormMode.Edit;
                }
                else
                {
                    formMode = (int)FormMode.Create;
                }
            }
            else
            {
                formMode = (int)FormMode.Create;
            }
            if (formMode == (int)FormMode.Create)
            {

                if (accessProfileGroupNoAlreadyExists(txtGroupNo.Text))
                {
                    var title = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    var message = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    ClientScript.RegisterStartupScript(GetType(), "ImportantInfoDialogPrompt", "ImportantInfoDialogPrompt('" + title + "', '" + message + "');", true);
                }
                else
                {
                    _AccessGroup.AccessGroupNumber = Convert.ToInt32(txtGroupNo.Text);
                    _AccessGroup.AccessGroupName = txtGroupName.Text;
                    _AccessGroup.Memo = txtMemo.Text;

                    _AccessGroupRepository.NewAccessProfileGroup(_AccessGroup);
                    loadInitialDropdowns();
                    cboGroupNo.Value = _AccessGroup.Id.ToString();
                    cboGroupDescription.Value = _AccessGroup.Id.ToString();
                    txtGroupNo.Text = _AccessGroup.AccessGroupNumber.ToString();
                    txtGroupName.Text = _AccessGroup.AccessGroupName;
                    txtMemo.Text = _AccessGroup.Memo;

                }

            }
            else if (formMode == (int)FormMode.Edit)
            {
                if (string.IsNullOrEmpty(condition)) return;
                var accessProfilelist = _AccessGroupRepository.GetAllAccessProfileGroups();
                var apgPExists = accessProfilelist.Where(x => x.Id == Convert.ToInt32(condition)).FirstOrDefault();

                if (apgPExists != null)
                {
                    apgPExists.AccessGroupNumber = Convert.ToInt32(txtGroupNo.Text);
                    apgPExists.AccessGroupName = txtGroupName.Text;
                    apgPExists.Memo = txtMemo.Text;

                    _AccessGroupRepository.EditAccessGroup(apgPExists);
                    loadInitialDropdowns();
                    cboGroupNo.Value = apgPExists.Id.ToString();
                    cboGroupDescription.Value = apgPExists.Id.ToString();
                    txtGroupNo.Text = apgPExists.AccessGroupNumber.ToString();
                    txtGroupName.Text = apgPExists.AccessGroupName;
                    txtMemo.Text = apgPExists.Memo;
                }
            }

            cboGroupNo.ClientEnabled = true;
            cboGroupDescription.ClientEnabled = true;
            hiddenFieldDetectChanges.Value = ((int)FormMode.Edit).ToString();
        }
        protected void btnCancelDel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DeleteButtonConfirm", "DeleteButtonConfirm();", true);
        }

        [WebMethod]
        public static void DeleteAccessProfileGroup(int id)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            var accessProfGroup = _AccessGroupRepository.GetAllAccessProfileGroups();
            var apgExists = accessProfGroup.Where(x => x.Id == id).FirstOrDefault();
            if (apgExists != null)
            {
                _AccessGroupRepository.DeleteAccessGroupById(apgExists);
            }
        }

        protected void btnBackFooter_Click(object sender, EventArgs e)
        {
            BackButtonRedirection();
        }
        public void BackButtonRedirection()
        {
            var detectChangesMode = AccessControlPermissionMode == accessControlPermissionModes.Edit ? Convert.ToInt32(hiddenFieldDetectChanges.Value) : 0;
            //if (accessControlPermissionMode != accessControlPermissionModes.Edit)
            //    detectChangesMode = 0;

            switch (detectChangesMode)
            {
            case 0:
                hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
                Response.Redirect("settings.aspx");
                break;
            case 1:
                ClientScript.RegisterStartupScript(GetType(), "BackButtonConfirm", "BackButtonConfirm();", true);
                break;
            }
        }
        public static bool accessProfileGroupNoAlreadyExists(string groupNumber)
        {
            var returnValue = false;
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            AccessGroup accessGroup = null;
            accessGroup = accessGroupRepository.GetAccessProfileGroupByGroupNo(Convert.ToInt64(groupNumber));
            if (accessGroup != null)
            {
                returnValue = true;
            }
            return returnValue;
        }

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);
            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        [WebMethod]
        public static AccessGroup CreateAccessProfileGroup(string accessGroupNumber, string accessGroupName, string accessGroupMemo)
        {
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository(); //accessGroupNumber: accessGroupNumber, accessGroupName: accessGroupName, accessGroupMemo: accessGroupMemo
            AccessGroup accessProfileGroup = new AccessGroup() { AccessGroupNumber = Convert.ToInt32(accessGroupNumber), AccessGroupName = accessGroupName, Memo = accessGroupMemo };
            accessGroupRepository.NewAccessProfileGroup(accessProfileGroup);
            return accessProfileGroup;
        }

        [WebMethod]
        public static AccessGroup EditAccessProfileGroup(int Id, string accessGroupNumber, string accessGroupName, string accessGroupMemo)
        {
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            AccessGroup accessGroup = new AccessGroup();
            accessGroup = accessGroupRepository.GetAccessGroupById(Id);
            accessGroup.AccessGroupNumber = Convert.ToInt32(accessGroupNumber);
            accessGroup.AccessGroupName = accessGroupName;
            accessGroup.Memo = accessGroupMemo;
            accessGroupRepository.EditAccessGroup(accessGroup);
            detectedChangesIndex = accessGroup.Id;
            return accessGroup;
        }

        [WebMethod]
        public static AccessGroup GetAccessProfileGroupById(int ID)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            AccessGroup _AccessPlanGroup = new AccessGroup();
            var planGroup = _AccessGroupRepository.GetAccessProfileGroupById(ID);

            if (planGroup == null)
            {
                return _AccessPlanGroup;
            }
            if (planGroup != null)
            {
                _AccessPlanGroup.Id = planGroup.Id;
                _AccessPlanGroup.AccessGroupNumber = planGroup.AccessGroupNumber;
                _AccessPlanGroup.AccessGroupName = planGroup.AccessGroupName;
                _AccessPlanGroup.Memo = planGroup.Memo;

            }
            return _AccessPlanGroup;
        }


        protected void cboGroupNo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            loadInitialDropdowns();
        }

        protected void cboGroupDescription_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            loadInitialDropdowns();
        }
    }
}