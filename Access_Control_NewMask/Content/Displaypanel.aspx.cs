using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using DevExpress.Web;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class Displaypanel : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("DisplayPanel_PMode");
            }
            set
            {
                HttpContext.Current.Session["DisplayPanel_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.DisplayPanel, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkShowAll.Checked = true;
                chkPresent.Checked = true;
                chkAbsent.Checked = true;
                BindGrid(0, 0);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        protected void grdBookings_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                string[] passedValues = e.Parameters.Split(';');
                var filter = Convert.ToInt32(passedValues[0]);
                var isPresent = Convert.ToInt32(passedValues[1]);

                BindGrid(filter, isPresent);
            }
        }
        protected void BindGrid(int filter, int isPresent)
        {
            var accessLogs = new GateDisplaypanelViewModel().GetAllData();
            if (filter == 0 && isPresent == 0)
            {
                grdBookings.DataSource = accessLogs;
                grdBookings.DataBind();
            }
            else
            {
                if (isPresent == 1 || isPresent == 2 || isPresent == 3)
                {
                    switch (isPresent)
                    {
                        case 1:
                            accessLogs = new GateDisplaypanelViewModel().GetAbsentData(filter);
                            grdBookings.DataSource = accessLogs;
                            grdBookings.DataBind();
                            break;
                        case 2:
                            accessLogs = new GateDisplaypanelViewModel().GetPresentData(filter);
                            grdBookings.DataSource = accessLogs;
                            grdBookings.DataBind();
                            break;
                        case 3:
                            List<GateDisplaypanelDto> list = new List<GateDisplaypanelDto>();
                            grdBookings.DataSource = list;
                            grdBookings.DataBind();
                            break;

                    }

                }
                else
                {
                    if (filter > 0)
                    {
                        switch (filter)
                        {
                            case 1:
                                accessLogs = accessLogs.Where(x => x.Pers_Type == 1).ToList();
                                break;
                            case 2:
                                accessLogs = accessLogs.Where(x => x.Pers_Type == 2).ToList();
                                break;
                            case 3:
                                accessLogs = accessLogs.Where(x => x.Pers_Type == 3).ToList();
                                break;
                        }
                    }
                    grdBookings.DataSource = accessLogs;
                    grdBookings.DataBind();
                }
            }

            if (accessLogs.Count > 25)
            {
                //grdBookings.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdBookings.Settings.VerticalScrollableHeight = 750;
                grdBookings.SettingsPager.PageSize = accessLogs.Count();
            }
            grdBookings.FocusedRowIndex = -1;

        }

        protected void grdBookings_CustomButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCustomButtonEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            var rowCount = grid.VisibleRowCount - 1;
            //status 1
            if (e.ButtonID == "Status1")
            {
                int index = e.VisibleIndex;
                int status = 0;
                long nr = 0;
                if (grdBookings.GetRowValues(e.VisibleIndex, "CardStatus1") != null)
                {
                    status = Convert.ToInt32(grdBookings.GetRowValues(e.VisibleIndex, "CardStatus1"));
                }
                if (grdBookings.GetRowValues(e.VisibleIndex, "CardStatus1") != null)
                {
                    nr = Convert.ToInt64(grdBookings.GetRowValues(e.VisibleIndex, "ID_Nr1"));
                }
                if (nr == 0)
                {
                    e.Image.Url = "";
                }
                else
                {
                    switch (status)
                    {
                        case 0:
                            e.Image.Url = "../Images/FormImages/btn_reddisplay.png";
                            break;
                        case 1:
                            e.Image.Url = "../Images/FormImages/btn_greendisplay.png";
                            break;
                    }
                }
            }
            //status 2
            if (e.ButtonID == "Status2")
            {
                int index = e.VisibleIndex;
                int status = 0;
                long nr = 0;
                if (grdBookings.GetRowValues(e.VisibleIndex, "CardStatus2") != null)
                {
                    status = Convert.ToInt32(grdBookings.GetRowValues(e.VisibleIndex, "CardStatus2"));
                }
                if (grdBookings.GetRowValues(e.VisibleIndex, "CardStatus2") != null)
                {
                    nr = Convert.ToInt64(grdBookings.GetRowValues(e.VisibleIndex, "ID_Nr2"));
                }
                if (nr == 0)
                {
                    e.Image.Url = "";
                }
                else
                {
                    switch (status)
                    {
                        case 0:
                            e.Image.Url = "../Images/FormImages/btn_reddisplay.png";
                            break;
                        case 1:
                            e.Image.Url = "../Images/FormImages/btn_greendisplay.png";
                            break;
                    }
                }
            }
            //status 3
            if (e.ButtonID == "Status3")
            {
                int index = e.VisibleIndex;
                int status = 0;
                long nr = 0;
                if (grdBookings.GetRowValues(e.VisibleIndex, "CardStatus3") != null)
                {
                    status = Convert.ToInt32(grdBookings.GetRowValues(e.VisibleIndex, "CardStatus3"));
                }
                if (grdBookings.GetRowValues(e.VisibleIndex, "CardStatus3") != null)
                {
                    nr = Convert.ToInt64(grdBookings.GetRowValues(e.VisibleIndex, "ID_Nr3"));
                }
                if (nr == 0)
                {
                    e.Image.Url = "";
                }
                else
                {
                    switch (status)
                    {
                        case 0:
                            e.Image.Url = "../Images/FormImages/btn_reddisplay.png";
                            break;
                        case 1:
                            e.Image.Url = "../Images/FormImages/btn_greendisplay.png";
                            break;
                    }
                }
            }
        }
    }
}