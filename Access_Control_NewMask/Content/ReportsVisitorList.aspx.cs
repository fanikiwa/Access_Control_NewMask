using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.ViewModels;

namespace Access_Control_NewMask.Content
{
    public partial class ReportsVisitorList : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Reports_PMode");
            }
            set
            {
                HttpContext.Current.Session["Reports_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Reports, out _AccessControlPermissionMode))
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
            _initializeReportViewer();
            if (!IsPostBack)
            {
                chkLandScape.Checked = true;
                SetDefaultCheckBox();
                BindCompanies();
                BindVisitors();
                BindGrid(BindVisitorData(0, 0, 0, 0, 0, 0));
                lblPersName.Text = Session["Pers_Name"] == null ? "" : Session["Pers_Name"].ToString();
            }
        }
        private void _initializeReportViewer()
        {
            if (chkLandScape.Checked)
            {
                ReportVisitorListASPxDocumentViewer.OpenReport(new VisitorReportList());
            }
            else if (chkPortrait.Checked)
            {
                ReportVisitorListASPxDocumentViewer.OpenReport(new ReportsVisitorListPotrait());
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccReports.aspx");
        }
        protected void BindCompanies()
        {
            List<VisitorCompanyTb> companyList = new List<VisitorCompanyTb>();
            VisitorCompanyTb company = new VisitorCompanyTb() { ID = 0, CompanyNr = 0, CompanyName = "Keine Auswahl" };
            companyList.Add(company);
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            companyList.AddRange(companies);
            cobCompanyFrom.DataSource = companyList;
            cobCompanyFrom.DataBind();
            cobCompanyFrom.SelectedIndex = 0;
            cobCompanyTo.DataSource = companyList;
            cobCompanyTo.DataBind();
            cobCompanyTo.SelectedIndex = 0;
        }
        protected void BindVisitors()
        {
            var visitors = new ReportsVisitorListViewModel().GetVisitors();
            cobVisitorIdFrom.DataSource = visitors;
            cobVisitorIdFrom.DataBind();
            cobVisitorIdFrom.SelectedIndex = 0;
            cobVisitorIdTo.DataSource = visitors;
            cobVisitorIdTo.DataBind();
            cobVisitorIdTo.SelectedIndex = 0;
            cobNameFrom.DataSource = visitors;
            cobNameFrom.DataBind();
            cobNameFrom.SelectedIndex = 0;
            cobNameTo.DataSource = visitors;
            cobNameTo.DataBind();
            cobNameTo.SelectedIndex = 0;
        }
        protected List<ReportsVisitorListDto> BindVisitorData(long compayFrom,long companyTo,long visitorNameFrom, long visitorNameTo, long visitorIdFrom,long visitorIdTo)
        {
            var visitorData = new ReportsVisitorListViewModel().GetVisitorData(cobCompanyFrom.Text, cobCompanyTo.Text, Convert.ToInt64( cobVisitorIdFrom.Text),Convert.ToInt64(cobVisitorIdTo.Text),cobNameFrom.Text,cobNameTo.Text);
            if(compayFrom != 0 && companyTo != 0)
            {
                visitorData = visitorData.Where(x => x.CompanyID >= compayFrom && x.CompanyID <= companyTo).ToList();
            }
            if(visitorNameFrom != 0 && visitorNameTo != 0)
            {
                visitorData = visitorData.Where(x => x.VisitorID >= visitorNameFrom && x.VisitorID <= visitorNameTo).ToList();
            }
            if (visitorIdFrom != 0 && visitorIdTo != 0)
            {
                visitorData = visitorData.Where(x => x.VisitorID >= visitorNameFrom && x.VisitorID <= visitorNameTo).ToList();
            }
            return visitorData;
        }
        protected void BindGrid(List<ReportsVisitorListDto> visitorData)
        {
            grdVisitorList.DataSource = visitorData;
            grdVisitorList.DataBind();

            string firstName = Convert.ToString(HttpContext.Current.Session["Pers_FirstName"]);
            string lastName = Convert.ToString(HttpContext.Current.Session["Pers_LastName"]);

            var logedInUser = String.Format("{0} {1}", firstName, lastName);

            visitorData.Select(c => { c.LoggedInUser = logedInUser; return c; }).ToList();
             
            Session["VisitorListRpt"] = visitorData;
            if (visitorData.Count > 31)
            {

            }
        }

        protected void grdVisitorList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                string[] passedValues = e.Parameters.Split(';');
                var companyFrom = Convert.ToInt64(passedValues[0]);
                var companyTo = Convert.ToInt64(passedValues[1]);
                var visitorNameFrom = Convert.ToInt64(passedValues[2]);
                var visitorNameTo = Convert.ToInt64(passedValues[3]);
                var visitorIdFrom = Convert.ToInt64(passedValues[4]);
                var visitorIdTo = Convert.ToInt64(passedValues[5]);
                var visitorData = BindVisitorData(companyFrom, companyTo, visitorNameFrom, visitorNameTo, visitorIdFrom, visitorIdTo);
                BindGrid(visitorData);
                SetVisibleColumns();
            }
        }
        protected void SetVisibleColumns()
        {

            grdVisitorList.Columns["VisitorCompany"].Visible = chkcompany.Checked;
            grdVisitorList.Columns["VisitorName"].Visible = chkVisitorName.Checked;
            grdVisitorList.Columns["VisitorID"].Visible = chkVisitorID.Checked;
            grdVisitorList.Columns["PostalCode"].Visible = chkPostalCode.Checked;
            grdVisitorList.Columns["Location"].Visible = chkLocation.Checked;
            grdVisitorList.Columns["Street_Number"].Visible = chkStreetNumber.Checked;
            grdVisitorList.Columns["Telephone"].Visible = chkTelephone.Checked;
            grdVisitorList.Columns["MobileNumber"].Visible = chkMobileNr.Checked;
            grdVisitorList.Columns["Email"].Visible = chkEmail.Checked;
            grdVisitorList.Columns["VehicleRegNr"].Visible = chkVehicleRegNr.Checked;
            grdVisitorList.Columns["VehicleType"].Visible = chkVehicleType.Checked;
            grdVisitorList.Columns["CardNumber"].Visible = chkCardNumber.Checked;
            grdVisitorList.Columns["AccessFromTo"].Visible = chkAccessFromTo.Checked;
            grdVisitorList.Columns["AccessPlanNr"].Visible = chkAccessPlanNr.Checked;
            grdVisitorList.Columns["AccessPlanName"].Visible = chkAccessPlanName.Checked;
            ReportsVisitorListDto visibleDto = new ReportsVisitorListDto();
            visibleDto.HideVisitorCompany = chkcompany.Checked;
            visibleDto.HideVisitorName = chkVisitorName.Checked;
            visibleDto.HideVisitorID = chkVisitorID.Checked;
            visibleDto.HidePostalCode = chkPostalCode.Checked;
            visibleDto.HideLocation = chkLocation.Checked;
            visibleDto.HideStreet_Number = chkStreetNumber.Checked;
            visibleDto.HideTelephone = chkTelephone.Checked;
            visibleDto.HideMobileNumber = chkMobileNr.Checked;
            visibleDto.HideEmail = chkEmail.Checked;
            visibleDto.HideVehicleRegNr = chkVehicleRegNr.Checked;
            visibleDto.HideVehicleType = chkVehicleType.Checked;
            visibleDto.HideCardNumber = chkCardNumber.Checked;
            visibleDto.HideAccessFromTo = chkAccessFromTo.Checked;
            visibleDto.HideAccessPlanNr = chkAccessPlanNr.Checked;
            visibleDto.HideAccessPlanName = chkAccessPlanName.Checked;
             

            Session["HideReportsVisitorList"] = visibleDto;
        }
        protected void SetDefaultCheckBox()
        {
            chkcompany.Checked = true;
            chkVisitorName.Checked = true;
            chkVisitorID.Checked = true;
        }


        protected void ReportsVisitorListPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
    }
}