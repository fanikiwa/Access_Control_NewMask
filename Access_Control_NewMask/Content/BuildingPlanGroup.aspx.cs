using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class BuildingPlanGroup : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        static accessControlPermissionModes accessControlPermissionMode = accessControlPermissionModes.Read;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;
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
            var grouplist = _AccessGroupRepository.GetAllBuildingPlanGroups();
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
                cboGroupNo.SelectedIndex = 0;
                cboGroupDescription.DataSource = lstNone;
                cboGroupDescription.DataBind();
                cboGroupDescription.SelectedIndex = 0;
                txtGroupNo.Text = String.Empty;
                txtGroupName.Text = String.Empty;
                txtMemo.Text = String.Empty;
                hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
            }
            hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
        }

        public void BackButtonRedirection()
        {
            var detectChangesMode = Convert.ToInt32(hiddenFieldDetectChanges.Value);
            //if (accessControlPermissionMode != accessControlPermissionModes.Edit)
            //    detectChangesMode = 0;

            switch (detectChangesMode)
            {
            case 0:
                hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
                //  ClientScript.RegisterStartupScript(GetType(), "DirectToSettings", "DirectToSettings();", true);
                HttpContext.Current.Response.Redirect("Settings.aspx");
                break;
            case 1:
                ClientScript.RegisterStartupScript(GetType(), "BackButtonConfirm", "BackButtonConfirm();", true);
                break;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonRedirection();
            // Response.Redirect("Settings.aspx");
        }
        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);
            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearControls();
            enableDisableControls();
            SetNextGroupNr();
            hiddenFieldDetectChanges.Value = ((int)FormMode.Display).ToString();
        }
        private void SetNextGroupNr()
        {
            txtGroupNo.Text = _AccessGroupViewModel.GetNextBuildingPlanGroupNr().ToString();
            txtGroupName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            AccessGroup _BuildingPlanGroup = new AccessGroup();
            if (string.IsNullOrEmpty(txtGroupNo.Text))
            {
                return;
            }

            int formMode;
            if (cboGroupNo.Value == null)
            {
                if (BuildingPlanGroupNoAlreadyExists(txtGroupNo.Text))
                {
                    var title = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    var message = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    ClientScript.RegisterStartupScript(GetType(), "ImportantInfoDialogPrompt", "ImportantInfoDialogPrompt('" + title + "', '" + message + "');", true);
                }
                else
                {
                    _BuildingPlanGroup.AccessGroupNumber = Convert.ToInt32(txtGroupNo.Text);
                    _BuildingPlanGroup.AccessGroupName = txtGroupName.Text;
                    _BuildingPlanGroup.Memo = txtMemo.Text;

                    _AccessGroupRepository.NewBuildingPlanGroup(_BuildingPlanGroup);
                    loadInitialDropdowns();
                    cboGroupNo.Value = _BuildingPlanGroup.Id.ToString();
                    cboGroupDescription.Value = _BuildingPlanGroup.Id.ToString();
                    txtGroupNo.Text = _BuildingPlanGroup.AccessGroupNumber.ToString();
                    txtGroupName.Text = _BuildingPlanGroup.AccessGroupName;
                    txtMemo.Text = _BuildingPlanGroup.Memo;

                }
                cboGroupNo.ClientEnabled = true;
                cboGroupDescription.ClientEnabled = true;
                hiddenFieldDetectChanges.Value = ((int)FormMode.None).ToString();
                return;

            }
            string condition = cboGroupNo.Value.ToString();

            if (!(string.IsNullOrEmpty(cboGroupNo.Value.ToString())))
            {
                var buildingPlanGroupId = 0;
                int.TryParse(cboGroupNo.Value.ToString(), out buildingPlanGroupId);
                var buildingPlanGroup = new AccessGroupRepository().GetBuildingPlanGroupsById(buildingPlanGroupId);
                if (buildingPlanGroup != null)
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

                if (BuildingPlanGroupNoAlreadyExists(txtGroupNo.Text))
                {
                    var title = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    var message = GetLocalizedText("accessProfileGroupNoAlreadyInUse");
                    ClientScript.RegisterStartupScript(GetType(), "ImportantInfoDialogPrompt", "ImportantInfoDialogPrompt('" + title + "', '" + message + "');", true);
                }
                else
                {
                    _BuildingPlanGroup.AccessGroupNumber = Convert.ToInt32(txtGroupNo.Text);
                    _BuildingPlanGroup.AccessGroupName = txtGroupName.Text;
                    _BuildingPlanGroup.Memo = txtMemo.Text;

                    _AccessGroupRepository.NewBuildingPlanGroup(_BuildingPlanGroup);
                    loadInitialDropdowns();
                    cboGroupNo.Value = _BuildingPlanGroup.Id.ToString();
                    cboGroupDescription.Value = _BuildingPlanGroup.Id.ToString();
                    txtGroupNo.Text = _BuildingPlanGroup.AccessGroupNumber.ToString();
                    txtGroupName.Text = _BuildingPlanGroup.AccessGroupName;
                    txtMemo.Text = _BuildingPlanGroup.Memo;
                }
            }
            else if (formMode == (int)FormMode.Edit)
            {
                if (string.IsNullOrEmpty(condition)) return;
                var buildingPlanGroupsList = _AccessGroupRepository.GetAllBuildingPlanGroups();
                var bpgPExists = buildingPlanGroupsList.Where(x => x.Id == Convert.ToInt32(condition)).FirstOrDefault();

                if (bpgPExists != null)
                {
                    bpgPExists.AccessGroupNumber = Convert.ToInt32(txtGroupNo.Text);
                    bpgPExists.AccessGroupName = txtGroupName.Text;
                    bpgPExists.Memo = txtMemo.Text;

                    _AccessGroupRepository.EditBuildingPlanGroup(bpgPExists);
                    loadInitialDropdowns();
                    cboGroupNo.Value = bpgPExists.Id.ToString();
                    cboGroupDescription.Value = bpgPExists.Id.ToString();
                    txtGroupNo.Text = bpgPExists.AccessGroupNumber.ToString();
                    txtGroupName.Text = bpgPExists.AccessGroupName;
                    txtMemo.Text = bpgPExists.Memo;
                }
            }

            //cboGroupNo.Enabled = true;
            //cboGroupDescription.Enabled = true;
            cboGroupNo.ClientEnabled = true;
            cboGroupDescription.ClientEnabled = true;
            hiddenFieldDetectChanges.Value = ((int)FormMode.Edit).ToString();
        }

        public static bool BuildingPlanGroupNoAlreadyExists(string groupNumber)
        {
            var returnValue = false;
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            AccessGroup accessGroup = null;
            accessGroup = accessGroupRepository.GetBuildingPlanGroupsByNr(Convert.ToInt64(groupNumber));
            if (accessGroup != null)
            {
                returnValue = true;
            }
            return returnValue;
        }


        [WebMethod]
        public static AccessGroup GetBuildingPlandGroupById(int ID)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            AccessGroup _BuildingPlanGroup = new AccessGroup();
            var planGroup = _AccessGroupRepository.GetBuildingPlanGroupsById(ID);

            if (planGroup == null)
            {
                return _BuildingPlanGroup;
            }
            if (planGroup != null)
            {
                _BuildingPlanGroup.Id = planGroup.Id;
                _BuildingPlanGroup.AccessGroupNumber = planGroup.AccessGroupNumber;
                _BuildingPlanGroup.AccessGroupName = planGroup.AccessGroupName;
                _BuildingPlanGroup.Memo = planGroup.Memo;

            }
            return _BuildingPlanGroup;
        }


        [WebMethod]
        public static bool DeleteBuildingPlandGroup(int Id)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();

            var BuildingPlanGroup = _AccessGroupRepository.GetBuildingPlanGroupsById(Convert.ToInt32(Id));
            if (BuildingPlanGroup != null)
            {
                new AccessGroupRepository().DeleteBuildingPlanGroup(BuildingPlanGroup);
            }
            return _AccessGroupRepository.GetBuildingPlanGroupsByNr(Convert.ToInt32(Id)) == null;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DeleteButtonConfirm", "DeleteButtonConfirm();", true);
        }


        [WebMethod]
        public static void DeleteBuildingPlanGroup(int id)
        {
            AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();
            var BuildingPlanGroup = _AccessGroupRepository.GetAllBuildingPlanGroups();
            var bplanExists = BuildingPlanGroup.Where(x => x.Id == id).FirstOrDefault();
            if (bplanExists != null)
            {
                _AccessGroupRepository.DeleteBuildingPlanGroup(bplanExists);
            }
        }

        [WebMethod]
        public static AccessGroup CreateBuildingPlanGroup(string accessGroupNumber, string accessGroupName, string accessGroupMemo)
        {
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            AccessGroup BuildingplanGroup = new AccessGroup() { AccessGroupNumber = Convert.ToInt32(accessGroupNumber), AccessGroupName = accessGroupName, Memo = accessGroupMemo };
            accessGroupRepository.NewBuildingPlanGroup(BuildingplanGroup);
            return BuildingplanGroup;
        }


        [WebMethod]
        public static AccessGroup EditBuildingPlanGroup(int Id, string accessGroupNumber, string accessGroupName, string accessGroupMemo)
        {
            AccessGroupRepository accessGroupRepository = new AccessGroupRepository();
            AccessGroup BuildingPlanGroup = new AccessGroup();
            BuildingPlanGroup = accessGroupRepository.GetBuildingPlanGroupsById(Id);
            BuildingPlanGroup.AccessGroupNumber = Convert.ToInt32(accessGroupNumber);
            BuildingPlanGroup.AccessGroupName = accessGroupName;
            BuildingPlanGroup.Memo = accessGroupMemo;
            accessGroupRepository.EditBuildingPlanGroup(BuildingPlanGroup);
            detectedChangesIndex = BuildingPlanGroup.Id;
            return BuildingPlanGroup;
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