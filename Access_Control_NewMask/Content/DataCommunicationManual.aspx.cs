using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.TerminalCommunication;
using Access_Control_NewMask.Dtos;
using System.Globalization;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using System.Web.Services;
using DevExpress.Web;
using Access_Control_NewMask.Controllers;
//using DevExpress.Web.ASPxGridView;

namespace Access_Control_NewMask.Content
{
    public partial class DataCommunicationManual : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("CommunicationManual_PMode");
            }
            set
            {
                HttpContext.Current.Session["CommunicationManual_PMode"] = value;
            }
        }

        private static TerminalCommunication.DataCommunication terminalDataCommunication = null;
        static List<TerminalInterface> SelectedTerminals = null;
        static int isNew = 0;
        private enum TerminalActionType
        {
            SendMasterData = 1, GetBookings = 2, SendSystemTime = 3, TestConnection = 4
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.CommunicationManual, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnApplyTermGrp.Enabled = false; btnDelete.Enabled = false; btnNew.Enabled = false; btnSave.Enabled = false;

                btnGetBookings.Enabled = false; btnMapTerminals.Enabled = false;

                btnSendRefferenceData.Enabled = false; btnSendSystemTime.Enabled = false; btnTestConnection.Enabled = false; btnUmapTerminalInstance.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;
            if (!IsPostBack)
            {
                LoadTerminalGroupsOnPageLoad();
                LoadTerminals();
                //BindMappedTerminals(0);
            }
        }

        protected void LoadTerminals()
        {
            var terminals = GetAllTerminals();
            grdTerminalInstances.DataSource = terminals;
            grdTerminalInstances.DataBind();
        }
        protected List<TerminalConfigDto> GetAllTerminals()
        {
            List<TerminalConfigDto> listTerminals = new List<TerminalConfigDto>();
            var terminals = new TerminalConfigRepository().GetAllTerminalsInstances().OrderBy(x => x.TermID);
            foreach (var termInstance in terminals)
            {
                var _status = "";
                switch (termInstance.IsActive)
                {
                    case false:
                        _status = GetLocalizedText("statusInactive");
                        break;
                    case true:
                        _status = GetLocalizedText("statusActive");
                        break;
                    default:
                        break;

                }

                TerminalConfigDto termConfig = new TerminalConfigDto()
                {
                    ID = termInstance.ID,
                    TermID = termInstance.TermID,
                    TermType = termInstance.TermType,
                    Description = termInstance.Description,
                    ConnectionType = termInstance.ConnectionType,
                    Status = _status,
                    IsActive = termInstance.IsActive
                };
                listTerminals.Add(termConfig);
            }
            return listTerminals;
        }
        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Dashboard_Main.aspx");
        }
        protected void CreateTerminalGroup()
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt64(ddlTerminalGrpNr.Value);
                var groupNr = Convert.ToInt64(txtTerminalGrpNr.Text.Trim());
                var groupDescription = txtGroupDescription.Text.Trim();

                TerminalGroup terminalGroup = new TerminalGroup()
                {
                    ID = id,
                    GroupNr = groupNr,
                    GroupDescription = groupDescription
                };
                if (id > 0)
                {
                    new TerminalGroupsRepository().EditTerminalGroup(terminalGroup);
                    LoadTerminalGroups();
                    ddlTerminalGrpNr.Value = terminalGroup.ID.ToString();
                    ddlTerminalDescription.Value = terminalGroup.ID.ToString();
                    BindData(Convert.ToInt64(ddlTerminalGrpNr.Value));
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    if (GroupNrExists(groupNr) == true)
                    {
                        string alertMessage = "Gruppennummer alredy vorhanden";
                        ClientScript.RegisterStartupScript(GetType(), "AlertMessage", "alert('" + alertMessage + "');", true);
                        return;
                    }
                    new TerminalGroupsRepository().NewTerminalGroup(terminalGroup);
                    LoadTerminalGroups();
                    ddlTerminalGrpNr.Value = terminalGroup.ID.ToString();
                    ddlTerminalDescription.Value = terminalGroup.ID.ToString();
                    BindData(Convert.ToInt64(ddlTerminalGrpNr.Value));
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                }


            }
            catch (Exception ex)
            {

            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ddlTerminalGrpNr.Value = "0";
            ddlTerminalDescription.Value = "0";
            txtTerminalGrpNr.Text = string.Empty;
            txtGroupDescription.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            LoadTerminals();
            BindMappedTerminals(Convert.ToInt64(ddlTerminalGrpNr.Value));
            CalculateNextGroupNr();
        }
        protected void CalculateNextGroupNr()
        {
            long nxtGroupNr = 0;
            var terminalGroups = new TerminalGroupsRepository().GetAllTerminalGroups();
            if (terminalGroups.Count() > 0)
            {
                nxtGroupNr = Convert.ToInt64(terminalGroups.Max(i => i.GroupNr));
            }
            else
            {
                nxtGroupNr = 0;
            }
            long nextNr = nxtGroupNr + 1;
            txtTerminalGrpNr.Text = nextNr.ToString();
            txtGroupDescription.Focus();
        }
        protected void LoadTerminalGroups()
        {
            List<TerminalGroup> groupList = new List<TerminalGroup>();
            //TerminalGroup group = new TerminalGroup() { ID = 0, GroupNr = 0, GroupDescription = "keine" };
            //groupList.Add(group);
            var terminalGroups = new TerminalGroupsRepository().GetAllTerminalGroups();
            var terminals = new TerminalGroupsRepository().GetAllTerminalGroups();
            //var firstGroupID = terminalGroups.FirstOrDefault().GroupNr;

            groupList.AddRange(terminalGroups);
            ddlTerminalGrpNr.DataSource = groupList;
            ddlTerminalGrpNr.DataBind();
            ddlTerminalDescription.DataSource = groupList;
            ddlTerminalDescription.DataBind();
            grdSearchTerminals.DataSource = terminals;
            grdSearchTerminals.DataBind();

            //if (firstGroupID > 0)
            //{

            //    BindMappedTerminals(firstGroupID);
            //}


        }

        protected void LoadTerminalGroupsOnPageLoad()
        {
            List<TerminalGroup> groupList = new List<TerminalGroup>();
            //TerminalGroup group = new TerminalGroup() { ID = 0, GroupNr = 0, GroupDescription = "keine" };
            //groupList.Add(group);
            var terminalGroups = new TerminalGroupsRepository().GetAllTerminalGroups();
            var terminals = new TerminalGroupsRepository().GetAllTerminalGroups();
            var firstGroupID = terminalGroups.FirstOrDefault().GroupNr;

            groupList.AddRange(terminalGroups);
            ddlTerminalGrpNr.DataSource = groupList;
            ddlTerminalGrpNr.DataBind();
            ddlTerminalDescription.DataSource = groupList;
            ddlTerminalDescription.DataBind();
            grdSearchTerminals.DataSource = terminals;
            grdSearchTerminals.DataBind();

            if (firstGroupID > 0)
            {

                BindMappedTerminals(firstGroupID);
            }


        }

        protected void ddlTerminalDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlTerminalGrpNr.SelectedValue = ddlTerminalDescription.SelectedValue;
            //BindData(Convert.ToInt64(ddlTerminalDescription.SelectedValue));
        }

        protected void ddlTerminalGrpNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlTerminalDescription.SelectedValue = ddlTerminalGrpNr.SelectedValue;
            //BindData(Convert.ToInt64(ddlTerminalGrpNr.SelectedValue));
        }
        protected void BindData(long id)
        {
            var terminalGroup = new TerminalGroupsRepository().GetTerminalGroupById(id);
            if (terminalGroup != null)
            {
                txtTerminalGrpNr.Text = terminalGroup.GroupNr.ToString();
                txtGroupDescription.Text = terminalGroup.GroupDescription;
            }
            else
            {
                txtTerminalGrpNr.Text = string.Empty;
                txtGroupDescription.Text = string.Empty;
            }
        }
        [WebMethod]
        public static bool GroupNrExists(long Nr)
        {
            bool exists = false;
            var group = new TerminalGroupsRepository().GetTerminalGroupByNumber(Nr);
            if (group != null)
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
        public static void MapTerminalsToGroups(long groupNumber, List<TerminalGroup> terminals)
        {
            var groupTerminals = new TerminalGroupMappingRepository().GetTerminalGroupByGroupId(groupNumber);
            foreach (var terminal in groupTerminals)
            {
                new TerminalGroupMappingRepository().DeleteTerminalGroupMapping(terminal);
            }
            if ((terminals == null) || !(terminals.Any())) return;
            foreach (var terminal in terminals)
            {
                TerminalGroupMapping terminalMapping = new TerminalGroupMapping()
                {
                    TerminalGroupId = groupNumber,
                    TerminalInstanceId = terminal.ID
                };
                new TerminalGroupMappingRepository().NewTerminalGroupMapping(terminalMapping);
            }

        }
        [WebMethod]
        public static void DeleteGroup(long groupId)
        {
            var group = new TerminalGroupsRepository().GetTerminalGroupById(groupId);
            if (group != null)
            {
                new TerminalGroupsRepository().DeleteTerminalGroup(group);

            }

        }

        protected void grdMappedTerminals_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var param = e.Parameters;
            if (string.IsNullOrEmpty(param)) return;

            if (Convert.ToInt64(e.Parameters) == -99)
            {

            }
            else
            {
                var _param = Convert.ToInt64(param);
                BindMappedTerminals(_param);
                SelectedTerminals = null;
            }


        }
        protected void BindMappedTerminals(long groupId)
        {
            var mappedTerminals = GetMappedTerminals(groupId);

            grdMappedTerminals.DataSource = mappedTerminals;
            grdMappedTerminals.DataBind();
        }
        protected List<TerminalConfigDto> GetMappedTerminals(long groupId)
        {
            List<TerminalConfigDto> listTerminals = new List<TerminalConfigDto>();
            var terminals = new ViewTerminalGroupMappingRepository().GetTerminalGroupByGroupId(groupId);
            foreach (var termInstance in terminals)
            {
                var _status = "";
                switch (termInstance.IsActive)
                {
                    case false:
                        _status = GetLocalizedText("statusInactive");
                        break;
                    case true:
                        _status = GetLocalizedText("statusActive");
                        break;
                    default:
                        break;

                }

                TerminalConfigDto termConfig = new TerminalConfigDto()
                {
                    ID = termInstance.TerminalInstanceId,
                    TermID = termInstance.TermID,
                    TermType = termInstance.TermType,
                    Description = termInstance.Description,
                    ConnectionType = termInstance.ConnectionType,
                    Status = _status,
                    IsActive = termInstance.IsActive,
                    IpAddress = termInstance.IpAddress,
                    SerialNumber = termInstance.SerialNumber,
                    Port = termInstance.Port
                };
                listTerminals.Add(termConfig);
            }
            return listTerminals;
        }

        [WebMethod]
        public static void DoActiononSelectedTerminals(int actionTaskKey, List<TerminalConfigDto> selectedTerminals)
        {
            _doActionOnSelectedTerminals((TerminalActionType)actionTaskKey, selectedTerminals);
        }

        private static void _updateTerminaDetailsFromDatabase(List<TerminalConfigDto> selectedTerminals)
        {
            var terminals = new TerminalConfigRepository().GetAllTerminalsInstances();

            foreach (TerminalConfigDto terminal in selectedTerminals)
            {
                var mappedTerminal = terminals.Where(x => x.ID == terminal.ID).FirstOrDefault();

                if (mappedTerminal != null)
                {
                    terminal.ID = mappedTerminal.ID;
                    terminal.TermID = mappedTerminal.TermID;
                    terminal.TermType = mappedTerminal.TermType;
                    terminal.Description = mappedTerminal.Description;
                    terminal.ConnectionType = mappedTerminal.ConnectionType;
                    //terminal.Status = _status,
                    //terminal.IsActive = termInstance.IsActive,
                    terminal.IpAddress = mappedTerminal.IpAddress;
                    terminal.SerialNumber = mappedTerminal.SerialNumber;
                    terminal.Port = mappedTerminal.Port;
                }

            }
        }

        private static void _doActionOnSelectedTerminals(TerminalActionType actionType, List<TerminalConfigDto> selectedTerminals)
        {
            terminalDataCommunication = new DataCommunication();
            List<TerminalInterface> terminalList = getActionTerminalsList(selectedTerminals);

            _updateTerminaDetailsFromDatabase(selectedTerminals);

            switch (actionType)
            {
                case TerminalActionType.SendMasterData:
                    terminalDataCommunication.SendSystemData(terminalList);
                    break;
                case TerminalActionType.GetBookings:
                    terminalDataCommunication.GetBookings(terminalList);
                    break;
                case TerminalActionType.SendSystemTime:
                    terminalDataCommunication.SendSystemTime(terminalList);
                    break;
                case TerminalActionType.TestConnection:
                    terminalDataCommunication.TestConnection(terminalList);
                    break;
            }
            SelectedTerminals = terminalList;
            terminalDataCommunication = null;
        }

        private static List<TerminalInterface> getActionTerminalsList(List<TerminalConfigDto> selectedTerminals)
        {

            List<TerminalInterface> terminalList = new List<TerminalInterface>();
            TerminalInterface terminal = null;

            foreach (TerminalConfigDto mappedTerminal in selectedTerminals)
            {
                var terminalInstance = new TerminalConfigRepository().GetTerminalInstance(mappedTerminal.ID);

                terminal = new TerminalInterface();
                terminal.IPAddress = terminalInstance.IpAddress;
                terminal.TerminalDescription = terminalInstance.Description;
                terminal.TerminalID = terminalInstance.ID;
                terminal.TerminalType = terminalInstance.TermType;
                terminalList.Add(terminal);
            }

            return terminalList;
        }
        protected void grdTerminalInstances_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadTerminals();
        }

        protected void grdTerminalInstances_DataBound(object sender, EventArgs e)
        {
            for (var i = 0; i < grdTerminalInstances.VisibleRowCount; i++)
            {
                var terminalInstanceId = grdTerminalInstances.GetRowValues(i, "ID");
                var groupId = ddlTerminalGrpNr.Value;
                if (terminalInstanceId != null && groupId != null)
                {
                    var isSeleted = TerminalIsSelected(Convert.ToInt64(groupId), Convert.ToInt64(terminalInstanceId));
                    grdTerminalInstances.Selection.SetSelection(i, isSeleted);
                }

            }

        }
        protected bool TerminalIsSelected(long groupId, long terminalId)
        {
            bool isSeleted = false;
            var terminalInstance = new ViewTerminalGroupMappingRepository().GetTerminalInstance(groupId, terminalId);

            if (terminalInstance != null)
            {
                isSeleted = true;
            }
            return isSeleted;

        }
        [WebMethod]
        public static TerminalGroup SaveTerminalGroup(long id, long groupNr, string groupDescription, List<TerminalGroup> terminals)
        {
            TerminalGroup terminalGroup2 = new TerminalGroup();
            try
            {
                TerminalGroup terminalGroup = new TerminalGroup()
                {
                    ID = id,
                    GroupNr = groupNr,
                    GroupDescription = groupDescription
                };
                if (id > 0)
                {
                    new TerminalGroupsRepository().EditTerminalGroup(terminalGroup);
                    var group = new TerminalGroupsRepository().GetTerminalGroupById(terminalGroup.ID);
                    if (group != null)
                    {
                        MapTerminalsToGroups(terminalGroup.ID, terminals);
                    }
                    //LoadTerminalGroups();
                    //ddlTerminalGrpNr.SelectedValue = terminalGroup.ID.ToString();
                    //ddlTerminalDescription.SelectedValue = terminalGroup.ID.ToString();
                    //BindData(Convert.ToInt64(ddlTerminalGrpNr.SelectedValue));
                }
                else
                {

                    new TerminalGroupsRepository().NewTerminalGroup(terminalGroup);
                    var group = new TerminalGroupsRepository().GetTerminalGroupById(terminalGroup.ID);
                    if (group != null)
                    {
                        MapTerminalsToGroups(terminalGroup.ID, terminals);
                    }
                    //LoadTerminalGroups();
                    //ddlTerminalGrpNr.SelectedValue = terminalGroup.ID.ToString();
                    //ddlTerminalDescription.SelectedValue = terminalGroup.ID.ToString();
                    //BindData(Convert.ToInt64(ddlTerminalGrpNr.SelectedValue));
                }


                terminalGroup2.ID = terminalGroup.ID;
                terminalGroup2.GroupNr = terminalGroup.GroupNr;
                terminalGroup2.GroupDescription = terminalGroup.GroupDescription;

            }
            catch (Exception ex)
            {

            }

            return terminalGroup2;
        }
        [WebMethod]
        public static void UnMapSeletedTerminal(long groupId, long terminalInstanceId)
        {
            var terminalInstance = new TerminalGroupMappingRepository().GetTerminalInstance(groupId, terminalInstanceId);
            if (terminalInstance != null)
            {
                new TerminalGroupMappingRepository().DeleteTerminalGroupMapping(terminalInstance);
            }
        }

        protected void grdMappedTerminals_DataBound(object sender, EventArgs e)
        {
            for (var i = 0; i < grdMappedTerminals.VisibleRowCount; i++)
            {
                var isSeleted = true;
                grdMappedTerminals.Selection.SetSelection(i, isSeleted);

            }
        }

        protected void grdMappedTerminals_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            var rowCount = grid.VisibleRowCount - 1;
            if (SelectedTerminals != null)
            {
                var terminalInstanceId = grid.GetRowValues(e.VisibleIndex, "ID");
                if (terminalInstanceId != null)
                {
                    var isSelected = SelectedTerminals.Where(x => x.TerminalID == Convert.ToInt64(terminalInstanceId)).FirstOrDefault();
                    if (isSelected != null)
                    {
                        switch (isSelected.ResultType)
                        {
                            case TerminalInterface.ActionResultType.Error:
                                e.Image.Url = "../Images/FormImages/redgrid.png";
                                break;
                            case TerminalInterface.ActionResultType.Success:
                                e.Image.Url = "../Images/FormImages/greengrid.png";
                                break;
                        }
                    }
                    else
                    {
                        e.Image.Url = "../Images/FormImages/yellowgrid.png";
                    }

                }

            }
            //if(rowCount == e.VisibleIndex)
            //{
            //    SelectedTerminals = null;
            //}

        }

        protected void grdTerminalInstances_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            var terminalStatus = e.GetValue("IsActive");
            if (e.DataColumn.FieldName.Trim() == "Status")
            {
                if (terminalStatus != null)
                {
                    var _status = terminalStatus.ToString();
                    switch (_status)
                    {
                        case "True":
                            //e.Cell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00b8bc");
                            e.Cell.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "False":
                            //e.Cell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                            e.Cell.ForeColor = System.Drawing.Color.Red;
                            break;
                    }

                }
            }
        }

        protected void grdMappedTerminals_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            var terminalStatus = e.GetValue("IsActive");
            if (e.DataColumn.FieldName.Trim() == "Status")
            {
                if (terminalStatus != null)
                {
                    var _status = terminalStatus.ToString();
                    switch (_status)
                    {
                        case "True":
                            //e.Cell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00b8bc");
                            e.Cell.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "False":
                            //e.Cell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                            e.Cell.ForeColor = System.Drawing.Color.Red;
                            break;
                    }

                }
            }
        }

        protected void ddlTerminalDescription_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<TerminalGroup> groupList = new List<TerminalGroup>();
                TerminalGroup group = new TerminalGroup() { ID = 0, GroupNr = 0, GroupDescription = "keine" };
                groupList.Add(group);
                var terminalGroups = new TerminalGroupsRepository().GetAllTerminalGroups();
                var terminals = new TerminalGroupsRepository().GetAllTerminalGroups();

                groupList.AddRange(terminalGroups);
                ddlTerminalDescription.DataSource = groupList;
                ddlTerminalDescription.DataBind();
                ddlTerminalDescription.Value = e.Parameter.ToString();
            }

        }

        protected void ddlTerminalGrpNr_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<TerminalGroup> groupList = new List<TerminalGroup>();
                TerminalGroup group = new TerminalGroup() { ID = 0, GroupNr = 0, GroupDescription = "keine" };
                groupList.Add(group);
                var terminalGroups = new TerminalGroupsRepository().GetAllTerminalGroups();
                var terminals = new TerminalGroupsRepository().GetAllTerminalGroups();
                groupList.AddRange(terminalGroups);
                ddlTerminalGrpNr.DataSource = groupList;
                ddlTerminalGrpNr.DataBind();
                ddlTerminalGrpNr.Value = e.Parameter.ToString();

            }
        }

        //protected void grdMappedTerminals_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        //{

        //}

        //protected void grdMappedTerminals_CustomCallback1(object sender, ASPxGridViewCustomCallbackEventArgs e)
        //{

        //}
    }
}