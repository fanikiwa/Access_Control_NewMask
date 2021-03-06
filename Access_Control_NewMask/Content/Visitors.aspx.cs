﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Repositories;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;
using DevExpress.Web;
using DevExpress.Web.Data;
using System.Web.Services;
using System.Globalization;
using System.Web.Script.Services;
using Access_Control_NewMask.TerminalCommunication;

namespace Access_Control_NewMask.Content
{
    public partial class Visitors : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        static string culture;
        static CultureInfo cultureInfo;
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Visitors_PMode");
            }
            set
            {
                HttpContext.Current.Session["Visitors_PMode"] = value;
            }
        }

        VisitorRepository _VisitorRepository = new VisitorRepository();
        public static List<VisitorsDto> VisitorsList
        {
            get
            {
                return new VisitorViewModels().GetVisitorData().ToList();
            }
            set
            {
                new VisitorViewModels().GetVisitorData().ToList();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Visitors, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnEntSave.Enabled = false; btnSaveAusweis.Enabled = false; btnSaveCompany.Enabled = false; btnSaveManufacturer.Enabled = false; btnSaveModel.Enabled = false;
                btnTakePhoto.Enabled = false; btnTakeWebcamPicture.Enabled = false;

                btnApplyCompany.Enabled = false; btnApplyCompanyTo.Enabled = false; btnApplyRegDates.Enabled = false; btnApplyVehicleType.Enabled = false;
                btnAccept.Enabled = false; btnAcceptAccessPlan.Enabled = false; btnAcceptCompany.Enabled = false;

                btnSendData.Enabled = false; btnSendLoginData.Enabled = false;

                btnsearchvehicle.Enabled = false;

                btnEntNew.Enabled = false; btnNewCompany.Enabled = false; btnNewManufacturer.Enabled = false; btnNewModel.Enabled = false;
                btnTriggerFileUpload.Enabled = false; btnTriggerFileUpload.Enabled = false;

                btnCancelDel.Enabled = false; btnDeletePic.Enabled = false; btnCancelPhoto.Enabled = false; btnClearPhoto.Enabled = false; btnDeleteAusweis.Enabled = false;
                btnDeleteCompany.Enabled = false; btnDeleteManufacturer.Enabled = false; btnRemovePhoto.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }
        public static List<VisitorsDto> PersonnelList
        {
            get
            {
                Visitors _Visitorsfrm = new Visitors();
                return _Visitorsfrm.ConverVisitorsToDtos(new VisitorRepository().GetAllVisitors().ToList());
            }
            set
            {
                Visitors _Visitorsfrm = new Visitors();
                _Visitorsfrm.ConverVisitorsToDtos(new VisitorRepository().GetAllVisitors().ToList());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnEntSave.UniqueID;

            if (!IsPostBack)
            {
                culture = HttpContext.Current.Session["PreferredCulture"].ToString();
                cultureInfo = new CultureInfo(culture);

                HttpContext.Current.Session["CardActivation"] = null;

                BindVisitors(0);
                bindGrids();
                txtVisitorID.Enabled = false;
                var total = ddlVisitorID.Items.Count;
                BindTopCompanies();
                BindCompanies();
                BindToCompanies();
                BindAccessPlans();
                if (!String.IsNullOrEmpty(Request.QueryString["visitorNr"]))
                {
                    var Visitornumber = Convert.ToInt64(Request.QueryString["visitorNr"]);
                    ddlVisitorID.Value = Visitornumber.ToString();
                    ddlVisitorName.Value = Visitornumber.ToString();
                    populateControls(Visitornumber);
                    levelCaption.Value = "100";
                }
                else
                {
                    LoadFirstVisitor();
                }

                LoadNavPosition();
                LoadTotalItems();
                BindTransponders();
                LoadFilteredVisitors(0);
                LoadClientsGrid();
                BindCompanyGrid();
                chkAllVisitors.Checked = true;
                BindControls();
                BindVehicleManufacturer();
                BindExistingCompanies();
                DisableVisitorCompanyControlsOnLoad();
            }

        }

        protected void btnEntNew_Click(object sender, EventArgs e)
        {
            VisitorRepository _VisitorRepository = new VisitorRepository();

            var visitorList = _VisitorRepository.GetAllVisitors();
            long visitInstanceId = 0;
            long vNo = 0;
            if (visitorList.Count > 0)
            {
                vNo = visitorList.Max(x => x.VisitorID);
            }
            var visitorTimeSchedule = new VisitorAccessTimeViewModel().GetAllAccessTime();
            if (visitorTimeSchedule.Count > 0)
            {

                visitInstanceId = Convert.ToInt64(visitorTimeSchedule.Max(i => i.VisitInstanceId));
            }
            clearControls();
            BindCompanies();
            BindToCompanies();
            BindAccessPlans();
            hiddenFieldVisitInstanceIdNr.Value = (visitInstanceId + 1).ToString();
            txtVisitorID.Enabled = true;
            txtVisitorID.Text = (vNo + 1).ToString();
            txtName.Focus();
            BindTransponders();
            BindTopCompanies();
            BindCompanyGrid();
        }

        void clearControls()
        {
            var today = DateTime.Now;
            txtVisitorID.Text = "";
            txtName.Text = "";
            txtCompany.Text = "";
            txtStreet.Text = "";
            txtLocation.Text = "";
            txtTelephone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtVehicleNo.Text = "";
            txtRegNo.Text = "";
            txtPersVisited.Text = "";
            txtPurpose.Text = "";
            txtTransponderNr.Text = "";
            txtPinCode.Text = "";
            txtVisitorPlan.Text = "";
            txtMemo.Text = "";
            dtpStartDate.Date = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            dtpEndDate.Date = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            drpRegDate.Date = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            dtpStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            dtpEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            drpRegTime.Value = today;
            ddlVisitorName.Value = "0";
            ddlVisitorID.Value = "0";
            ddlCompany.Value = "0";
            ddlLocation.Value = "0";
            drpVisitStartDate.Date = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            drpVisitEndDate.Date = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            drpVisitAutoDate.Date = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            drpVisitStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            drpVisitEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            drpVisitAutoDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            drpAutomaticLogout.Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            txtVisitorPlangroup.Text = "";
            txtSTDTime.Text = "";
            txtCardNumber.Text = "";
            txtCardPinCode.Text = "";
            txtPersonalName.Text = "";
            txtPersonnelNumber.Text = "";
            txtSurName.Text = "";
            txtPostalCode.Text = "";
            dplCompanyName.Value = "0";
            txtStreetNr.Text = "";
            cobVisitorPlanName.Value = "0";
            cobVisitorPlanNr.Value = "0";
            dplToCompanyName.Value = "0";
            dplToCompanyNr.Value = "0";
            txtCardActivatedTime.Text = "";
            txtPersActivated.Text = "";
            txtPersPhoneNr.Text = "";
            txtPersMobileNr.Text = "";
            txtVisitorCompanyName.Text = "";
            txtVisitorCompanyID.Text = "";
            txtVehicleId.Text = "";
            txtToCompanyId.Text = "";
            txtVehicleTypes.Text = "";
            txtVehicleId.Text = "";
            chkAccessPlanActive.Checked = false;
            DisableDropDowns();
        }
        protected void DisableDropDowns()
        {
            ddlTopCompanyNr.ClientEnabled = false;
            ddlPostalCode.ClientEnabled = false;
            ddlLocation.ClientEnabled = false;
            ddlVisitorID.ClientEnabled = false;
            ddlVisitorName.ClientEnabled = false;
        }
        protected void btnEntSave_Click(object sender, EventArgs e)
        {

        }

        private static string GetPhotoName(string passPhoto, string personPhotoInBinary, string firstName, long id)
        {
            string photoImageFile = passPhoto;
            if ((!string.IsNullOrWhiteSpace(personPhotoInBinary)))
            {
                if (personPhotoInBinary.Length > 0)// get from binary
                {
                    photoImageFile = FileProcessor.SaveVisitorImageFile("," + personPhotoInBinary, firstName + id.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss"));
                }
            }
            else // get from relative path
            {
                photoImageFile = FileProcessor.GetVisitorImageFileNameFromRelativePath(passPhoto);
            }

            personPhotoInBinary = string.Empty;
            return photoImageFile;
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static InsertEdit SaveVisitorDetails(string personPhotoInBinary, string id, string visitorID, string surName, string name, string company, string street, string location, string postalCode, string telephone,
            string mobile, string email, string cardNr, string Pincode, string visitorPlan, string startDate, string startDateTime, string endDate, string endDateTime,
            string autoDate, string autoDateTime, string AutoStdTime, string memo, string vehicleRegNr, string VehicleType, string visitInstance, bool planActive, string v_regDate, string v_regDateTime,
            string v_startDate, string v_startDateTime, string v_endDate, string v_endDateTime, string visitReason, string streetNr, string companyTo, string persPhoto, string cardActive, bool automaticLogout)
        {
            int _insertEdit = 0;
            long visitorId = 0;
            long ID = !string.IsNullOrEmpty(id) ? Convert.ToInt64(id) : 0;

            try
            {
                //long? companyID = null;
                DateTime? visitStartDate = null;
                DateTime? visitEndDate = null;
                DateTime? visitAutoDate = null;
                DateTime StartDate = DateTime.Now;
                DateTime? EndDate = null;
                DateTime? RegDate = null;
                if (!string.IsNullOrEmpty(startDate)) { visitStartDate = _dayDate(Convert.ToDateTime(startDate)).Add((Convert.ToDateTime(startDateTime).TimeOfDay)); }
                if (!string.IsNullOrEmpty(endDate)) { visitEndDate = _dayDate(Convert.ToDateTime(endDate)).Add((Convert.ToDateTime(endDateTime).TimeOfDay)); }
                if (!string.IsNullOrEmpty(autoDateTime)) { visitAutoDate = _dayDate(Convert.ToDateTime(DateTime.Now)).Add((Convert.ToDateTime(autoDateTime).TimeOfDay)); }

                if (!string.IsNullOrEmpty(v_regDate)) { RegDate = _dayDate(Convert.ToDateTime(v_regDate)).Add((Convert.ToDateTime(v_regDateTime).TimeOfDay)); }
                if (!string.IsNullOrEmpty(v_startDate)) { StartDate = _dayDate(Convert.ToDateTime(v_startDate)).Add((Convert.ToDateTime(v_startDateTime).TimeOfDay)); }
                if (!string.IsNullOrEmpty(v_endDate)) { EndDate = _dayDate(Convert.ToDateTime(v_endDate)).Add((Convert.ToDateTime(v_endDateTime).TimeOfDay)); }

                VisitorRepository _VisitorRepository = new VisitorRepository();
                Visitor _Visitor = new Visitor();
                //var visitorList = _VisitorRepository.GetAllVisitors();
                //var ID = !string.IsNullOrEmpty(id) ? Convert.ToInt64(id) : 0;
                //var vExists = visitorList.Where(x => x.ID == ID).FirstOrDefault();


                var vExists = _VisitorRepository.GetVisitorById(ID);

                if (vExists != null)
                {
                    ID = vExists.ID;
                    vExists.VisitorID = Convert.ToInt64(visitorID);
                    vExists.SurName = surName;
                    vExists.Fullname = name;
                    vExists.Company = !string.IsNullOrEmpty(company) && company != "0" ? Convert.ToInt64(company) : (long?)null;
                    vExists.Telephone = telephone;
                    vExists.Mobile = mobile;
                    vExists.Email = email;
                    vExists.VehicleRegNr = vehicleRegNr;
                    vExists.VisitorVehicleType = !string.IsNullOrEmpty(VehicleType) && VehicleType != "0" ? Convert.ToInt64(VehicleType) : (long?)null;
                    vExists.CardActive = Convert.ToBoolean(cardActive);
                    string photoImageFile = GetPhotoName(persPhoto, personPhotoInBinary, surName, vExists.VisitorID);
                    vExists.VisitorPhoto = photoImageFile;// FileProcessor.SaveVisitorImageFile(persPhoto, string.Format("{0}{1}{2}", vExists.SurName, vExists.Fullname, vExists.ID));
                    _VisitorRepository.EditVisitor(vExists);
                    _insertEdit = 2;
                    visitorId = vExists.ID;
                    VisitorAccessTime existingAccessTime = new VisitorAccessTime();
                    existingAccessTime = new VisitorAccessTimeViewModel().GetAccessTimeByVisitInstanceId(Convert.ToInt64(visitInstance));
                    if (existingAccessTime != null)
                    {
                        VisitorAccessTime accessTime = new VisitorAccessTime()
                        {
                            ID = existingAccessTime.ID,
                            VisitInstanceId = existingAccessTime.VisitInstanceId,
                            VisitorId = vExists.ID,
                            VisitPlanId = !string.IsNullOrEmpty(visitorPlan) && visitorPlan != "0" ? Convert.ToInt64(visitorPlan) : (long?)null,
                            CardNr = cardNr,
                            PinCode = Pincode,
                            VisitAccessStartDate = visitStartDate,
                            VisitAccessEndDate = visitEndDate,
                            AutoEndDate = visitAutoDate,
                            Memo = memo,
                            AccessPlanActive = planActive,
                            RegistrationDate = RegDate,
                            StartDate = StartDate,
                            EndDate = EndDate,
                            VisitReason = visitReason,
                            DateActivated = HttpContext.Current.Session["CardActivation"] != null ? ((ActivationTime)HttpContext.Current.Session["CardActivation"]).ActivationDate : (DateTime?)null,
                            PersNr = HttpContext.Current.Session["CardActivation"] != null ? ((ActivationTime)HttpContext.Current.Session["CardActivation"]).PersNr : (long?)null,
                            CompanyTo = !string.IsNullOrEmpty(companyTo) && companyTo != "0" ? Convert.ToInt32(companyTo) : (int?)null,
                            AutoLogout = automaticLogout,
                        };
                        VisitorAccessTimeViewModel accessTimeViewModel = new VisitorAccessTimeViewModel();
                        accessTimeViewModel.UpdateAccessTime(accessTime);
                    }
                    else
                    {
                        VisitorAccessTime accessTime = new VisitorAccessTime()
                        {
                            VisitorId = vExists.ID,
                            VisitInstanceId = Convert.ToInt64(visitInstance),
                            VisitPlanId = !string.IsNullOrEmpty(visitorPlan) && visitorPlan != "0" ? Convert.ToInt64(visitorPlan) : (long?)null,
                            CardNr = cardNr,
                            PinCode = Pincode,
                            VisitAccessStartDate = visitStartDate,
                            VisitAccessEndDate = visitEndDate,
                            AutoEndDate = visitAutoDate,
                            Memo = memo,
                            AccessPlanActive = planActive,
                            RegistrationDate = RegDate,
                            StartDate = StartDate,
                            EndDate = EndDate,
                            VisitReason = visitReason,
                            DateActivated = HttpContext.Current.Session["CardActivation"] != null ? ((ActivationTime)HttpContext.Current.Session["CardActivation"]).ActivationDate : (DateTime?)null,
                            PersNr = HttpContext.Current.Session["CardActivation"] != null ? ((ActivationTime)HttpContext.Current.Session["CardActivation"]).PersNr : (long?)null,
                            CompanyTo = !string.IsNullOrEmpty(companyTo) && companyTo != "0" ? Convert.ToInt32(companyTo) : (int?)null,
                            AutoLogout = automaticLogout,


                        };
                        VisitorAccessTimeViewModel accessTimeViewModel = new VisitorAccessTimeViewModel();
                        accessTimeViewModel.CreateAccessTime(accessTime);
                    }


                }
                else
                {
                    if (!string.IsNullOrEmpty(visitorID))
                    {
                        _Visitor.VisitorID = Convert.ToInt64(visitorID);
                        _Visitor.SurName = surName;
                        _Visitor.Fullname = name;
                        _Visitor.Company = !string.IsNullOrEmpty(company) && company != "0" ? Convert.ToInt64(company) : (long?)null;
                        _Visitor.Telephone = telephone;
                        _Visitor.Mobile = mobile;
                        _Visitor.Email = email;
                        _Visitor.VisitorType = 1;
                        _Visitor.VehicleRegNr = vehicleRegNr;
                        _Visitor.VisitorVehicleType = !string.IsNullOrEmpty(VehicleType) && VehicleType != "0" ? Convert.ToInt64(VehicleType) : (long?)null;
                        _Visitor.CardActive = Convert.ToBoolean(cardActive);
                        _VisitorRepository.NewVisitor(_Visitor);
                        _insertEdit = 1;
                        visitorId = _Visitor.ID;
                        ID = _Visitor.ID;
                        //acess time table
                        if (_Visitor.ID > 0)
                        {
                            string photoImageFile = GetPhotoName(persPhoto, personPhotoInBinary, surName, _Visitor.VisitorID);

                            _Visitor.VisitorPhoto = photoImageFile;// FileProcessor.SaveVisitorImageFile(persPhoto, string.Format("{0}{1}{2}", _Visitor.SurName, _Visitor.Fullname, _Visitor.ID));
                            _VisitorRepository.EditVisitor(_Visitor);
                            VisitorAccessTime accessTime = new VisitorAccessTime()
                            {
                                VisitorId = _Visitor.ID,
                                VisitInstanceId = Convert.ToInt64(visitInstance),
                                VisitPlanId = !string.IsNullOrEmpty(visitorPlan) && visitorPlan != "0" ? Convert.ToInt64(visitorPlan) : (long?)null,
                                CardNr = cardNr,
                                PinCode = Pincode,
                                VisitAccessStartDate = visitStartDate,
                                VisitAccessEndDate = visitEndDate,
                                AutoEndDate = visitAutoDate,
                                Memo = memo,
                                AccessPlanActive = planActive,
                                RegistrationDate = RegDate,
                                StartDate = StartDate,
                                EndDate = EndDate,
                                VisitReason = visitReason,
                                DateActivated = HttpContext.Current.Session["CardActivation"] != null ? ((ActivationTime)HttpContext.Current.Session["CardActivation"]).ActivationDate : (DateTime?)null,
                                PersNr = HttpContext.Current.Session["CardActivation"] != null ? ((ActivationTime)HttpContext.Current.Session["CardActivation"]).PersNr : (long?)null,
                                CompanyTo = !string.IsNullOrEmpty(companyTo) && companyTo != "0" ? Convert.ToInt32(companyTo) : (int?)null,
                                AutoLogout = automaticLogout,
                            };
                            VisitorAccessTimeViewModel accessTimeViewModel = new VisitorAccessTimeViewModel();
                            accessTimeViewModel.CreateAccessTime(accessTime);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            InsertEdit ied = new InsertEdit()
            {
                ID = ID,
                isEdit = _insertEdit,
                visitorId = visitorId
            };
            return ied;
        }
        public class InsertEdit
        {
            public int isEdit { get; set; }
            public long visitorId { get; set; }
            public long ID { get; set; }
        }
        public static DateTime _dayDate(DateTime date)
        {

            DateTime _day = new DateTime(date.Year, date.Month, date.Day, 00, 00, 00);
            return _day;
        }
        protected void bindGrids()
        {
            VisitorRepository _VisitorRepository = new VisitorRepository();
            var visitorLists = _VisitorRepository.GetAllVisitors();
            BindSearchVisitors(visitorLists);
            BindVisitorsHistory(visitorLists);

            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            var persDataList = _VwPersonnelDataRepository.GetAllPersonnel().Distinct().ToList();

            grdSearchPersonToVisit.DataSource = persDataList;
            grdSearchPersonToVisit.DataBind();

        }
        protected void BindTransponders()
        {
            long visitorNr = 0;
            Int64.TryParse(Convert.ToString(ddlVisitorID.Value), out visitorNr);

            var transpondersType1 = new VisitorTransponderViewModels().TransPonders(visitorNr, 1);
            var transpondersType2 = new VisitorTransponderViewModels().TransPonders(visitorNr, 2);
            grdTransponders.DataSource = transpondersType1;
            grdTransponders.DataBind();
            //grdfinacialStatement.DataSource = transponders;
            //grdfinacialStatement.DataBind();
            try
            {
                grdTranspondersShortTerm.DataSource = transpondersType2;
                grdTranspondersShortTerm.DataBind();
            }
            catch (Exception)
            { }

            txtCardNumber.Text = transpondersType1.Any(x => x.TransponderActive) ?
                transpondersType1.FirstOrDefault(x => x.TransponderActive).TransponderNr : "";
            txtCardPinCode.Text = transpondersType2.Any(x => x.TransponderActive) ?
                transpondersType2.FirstOrDefault(x => x.TransponderActive).TransponderNr : "";
        }

        protected void btnCancelDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hiddenFieldVisitorId.Value)) return;
            VisitorRepository _VisitorRepository = new VisitorRepository();
            var visitorList = _VisitorRepository.GetAllVisitors();

            var vExists = visitorList.Where(x => x.VisitorID == Convert.ToInt64(hiddenFieldVisitorId.Value)).FirstOrDefault();

            if (vExists != null)
            {
                hiddenFieldVisitorId.Value = "";
                _VisitorRepository.DeleteVisitor(vExists);
                BindCompanies();
                BindAccessPlans();
                BindVisitors(0);
                var today = DateTime.Now;
                DateTime nullDate = DateTime.MinValue;
                ddlVisitorName.Value = "0";
                ddlVisitorID.Value = "0";
                ddlCompany.Value = "0";
                ddlLocation.Value = "0";
                clearControls();
                drpVisitStartDate.Date = nullDate;
                drpVisitEndDate.Date = nullDate;
                drpVisitAutoDate.Date = nullDate;
                dtpStartDate.Date = nullDate;
                dtpEndDate.Date = nullDate;
                drpRegDate.Date = nullDate;
                drpVisitStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                drpVisitEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                drpVisitAutoDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                drpRegTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                dtpStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                dtpEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            }
        }

        public void LoadNavPosition()
        {
            var i = 0;
            i = ddlVisitorName.SelectedIndex;

            if (i > 0)
            {
                txtFvCurrentEntry.Text = (i).ToString();
            }
            else
            {
                txtFvCurrentEntry.Text = "";
            }


        }

        public void LoadTotalItems()
        {
            var total = ddlVisitorName.Items.Count - 1;
            txtFvTotalEntries.Text = total.ToString();
        }

        private void MoveToPrevious()
        {
            var i = (ddlVisitorName.SelectedIndex - 1);
            if (i < 1) return;
            ddlVisitorName.SelectedIndex = i;
            ddlVisitorID.Value = ddlVisitorName.Value.ToString();
            ddlCompany.Value = ddlVisitorName.Value.ToString();
            //ddlLocation.Value = ddlVisitorName.Value.ToString();

            var total = ddlVisitorID.Items.Count;
            txtFvCurrentEntry.Text = (i).ToString();
            txtFvTotalEntries.Text = (total - 1).ToString();
            populateControls(Convert.ToInt64(ddlVisitorName.Value));
        }

        private void MoveToNext()
        {
            var i = (ddlVisitorName.SelectedIndex + 1);
            if (i > (ddlVisitorName.Items.Count - 1)) return;
            ddlVisitorName.SelectedIndex = i;
            ddlVisitorID.Value = ddlVisitorName.Value.ToString();
            ddlCompany.Value = ddlVisitorName.Value.ToString();
            //ddlLocation.Value = ddlVisitorName.Value.ToString();

            var total = ddlVisitorID.Items.Count;
            txtFvCurrentEntry.Text = (i).ToString();
            txtFvTotalEntries.Text = (total - 1).ToString();
            populateControls(Convert.ToInt64(ddlVisitorName.Value));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Dashboard_Main.aspx");
        }

        protected void populateControls(long vid)
        {
            var today = DateTime.Now;
            DateTime nullDate = DateTime.MinValue;
            txtVisitorID.Enabled = false;
            VisitorRepository _VisitorRepository = new VisitorRepository();
            PersonnelRepository _PersonnelRepository = new PersonnelRepository();

            var visitorList = _VisitorRepository.GetAllVisitors();
            var vExists = visitorList.Where(x => x.ID == vid).FirstOrDefault();

            if (vExists != null)
            {

                txtVisitorID.Text = vExists.VisitorID.ToString();
                txtSurName.Text = vExists.SurName;
                txtName.Text = vExists.Fullname;
                if (vExists.Company != null)
                {
                    dplCompanyName.Value = vExists.Company.ToString();
                    txtVisitorCompanyName.Text = string.Format("{1}", vExists.Company, vExists.VisitorCompanyTb.CompanyName);
                    txtVisitorCompanyID.Text = vExists.Company.ToString();
                }
                else
                {
                    dplCompanyName.Value = "0";
                    txtVisitorCompanyName.Text = "";
                    txtVisitorCompanyID.Text = "";
                }
                txtStreet.Text = vExists.Company != null ? vExists.VisitorCompanyTb.Street : "";
                txtLocation.Text = vExists.Company != null ? vExists.VisitorCompanyTb.Place : "";
                txtTelephone.Text = vExists.Telephone;
                txtMobile.Text = vExists.Mobile;
                txtEmail.Text = vExists.Email;
                txtPostalCode.Text = vExists.Company != null ? vExists.VisitorCompanyTb.ZipCode : "";
                txtStreetNr.Text = vExists.Company != null ? vExists.VisitorCompanyTb.HouseNr : "";
                chkCardActive.Checked = Convert.ToBoolean(vExists.CardActive);
                photVal.Value = FileProcessor.GetVisitorImageRelativeFilePath(vExists.VisitorPhoto);
                if (vExists.PersonalID != null)
                {
                    var pers = new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == Convert.ToInt64(vExists.PersonalID));
                    txtPersonalName.Text = String.Format("{0} {1} {2}", pers.FirstName, pers.MiddleName, pers.LastName);
                    txtPersonnelNumber.Text = pers.Pers_Nr.ToString();
                    txtPersMobileNr.Text = pers.PrivateMobile;
                    txtPersPhoneNr.Text = pers.CompanyTel;

                }
                else
                {
                    txtPersonalName.Text = "";
                    txtPersonnelNumber.Text = "";
                    txtPersMobileNr.Text = "";
                    txtPersPhoneNr.Text = "";
                }
                txtVehicleNo.Text = vExists.VehicleRegNr;
                if (vExists.VisitorVehicleType != null)
                {
                    txtVehicleTypes.Text = vExists.VehicleType.Type;
                    txtVehicleId.Text = vExists.VisitorVehicleType.ToString();

                }
                else
                {
                    txtVehicleTypes.Text = "";
                    txtVehicleId.Text = "";
                }

                var accessTime = new VisitorAccessTimeViewModel().GetAccessTimeByVisitor_Id(vid);
                if (accessTime.VisitPlanId != null)
                {
                    var visitorPlan = new VisitorPlanViewModels().GetVisitorPlanByID(Convert.ToInt64(accessTime.VisitPlanId));
                    txtVisitorPlangroup.Text = visitorPlan != null ? String.Format("{0}-{1}", visitorPlan.VisitorPlanNr, visitorPlan.VisitorPlanDescription) : "";
                }
                else
                {
                    txtVisitorPlangroup.Text = "";
                }

                txtCardNumber.Text = accessTime.CardNr;
                txtVisitReason.Text = accessTime.VisitReason;
                if (accessTime.VisitAccessStartDate != null) drpVisitStartDate.Date = Convert.ToDateTime(accessTime.VisitAccessStartDate); else { drpVisitStartDate.Date = nullDate; }
                if (accessTime.VisitAccessStartDate != null) drpVisitStartDate.Date = Convert.ToDateTime(accessTime.VisitAccessStartDate); else { drpVisitStartDate.Date = nullDate; }
                if (accessTime.VisitAccessEndDate != null) drpVisitEndDate.Date = Convert.ToDateTime(accessTime.VisitAccessEndDate); else { drpVisitEndDate.Date = nullDate; }
                if (accessTime.VisitAccessStartDate != null) drpVisitStartDateTime.Value = Convert.ToDateTime(accessTime.VisitAccessStartDate); else { drpVisitStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }
                if (accessTime.VisitAccessEndDate != null) drpVisitEndDateTime.Value = Convert.ToDateTime(accessTime.VisitAccessEndDate); else { drpVisitEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }
                if (accessTime.AutoEndDate != null) drpVisitAutoDate.Date = Convert.ToDateTime(accessTime.AutoEndDate); else { drpVisitAutoDate.Date = nullDate; }
                if (accessTime.AutoEndDate != null) drpVisitAutoDateTime.Value = Convert.ToDateTime(accessTime.EndDate); else { drpVisitAutoDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }
                if (accessTime.RegistrationDate != null) drpRegDate.Date = Convert.ToDateTime(accessTime.RegistrationDate); else { drpRegDate.Date = nullDate; }
                if (accessTime.RegistrationDate != null) drpRegTime.Value = Convert.ToDateTime(accessTime.RegistrationDate); else { drpRegTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }


                if (accessTime.StartDate != null) dtpStartDate.Date = Convert.ToDateTime(accessTime.StartDate); else { dtpStartDate.Date = nullDate; }
                if (accessTime.EndDate != null) dtpEndDate.Date = Convert.ToDateTime(accessTime.EndDate); else { dtpEndDate.Date = nullDate; }
                if (accessTime.StartDate != null) dtpStartDateTime.Value = Convert.ToDateTime(accessTime.StartDate); else { dtpStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }
                if (accessTime.EndDate != null) dtpEndDateTime.Value = Convert.ToDateTime(accessTime.EndDate); else { dtpEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }
                if (accessTime.AutoEndDate != null) drpAutomaticLogout.Value = Convert.ToDateTime(accessTime.AutoEndDate); else { drpAutomaticLogout.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00); }
                if (accessTime.AutoLogout != null) chkAutomaticLogout.Checked = Convert.ToBoolean(accessTime.AutoLogout); else { chkAutomaticLogout.Checked = false; }
                if (accessTime.AccessPlanActive != null)
                {
                    chkAccessPlanActive.Checked = Convert.ToBoolean(accessTime.AccessPlanActive);
                }
                else
                {
                    chkAccessPlanActive.Checked = false;
                }
                if (accessTime.PersNr != null)
                {
                    var personnel = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(accessTime.PersNr));
                    txtPersActivated.Text = string.Format("{0} {1}", personnel.FirstName, personnel.LastName);
                    ActivationTime activate = new ActivationTime()
                    {
                        PersNr = personnel.Pers_Nr,
                        PersName = string.Format("{0} {1}", personnel.FirstName, personnel.LastName),
                        ActivationDate = Convert.ToDateTime(accessTime.DateActivated),
                    };
                    HttpContext.Current.Session["CardActivation"] = activate;
                }
                else
                {
                    txtPersActivated.Text = "";
                    HttpContext.Current.Session["CardActivation"] = null;
                }
                txtCardActivatedTime.Text = accessTime.DateActivated != null ? Convert.ToDateTime(accessTime.DateActivated).ToShortDateString() : "";
                dplToCompanyNr.Value = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : "0";
                dplToCompanyName.Value = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : "0";
                txtToCompanyId.Text = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : " ";
                txtToCompanyName.Text = accessTime.CompanyTo != null ? accessTime.Client.Name : " ";
                hiddenFieldVisitInstanceIdNr.Value = accessTime.VisitInstanceId.ToString();
                txtMemo.Text = accessTime.Memo;
                if (accessTime.VisitPlanId != null) { cobVisitorPlanNr.Value = accessTime.VisitPlanId.ToString(); } else { cobVisitorPlanNr.Value = "0"; }
                if (accessTime.VisitPlanId != null) { cobVisitorPlanName.Value = accessTime.VisitPlanId.ToString(); } else { cobVisitorPlanName.Value = "0"; }

            }
            else
            {

                clearControls();
                drpVisitStartDate.Date = nullDate;
                drpVisitEndDate.Date = nullDate;
                drpVisitAutoDate.Date = nullDate;
                dtpStartDate.Date = nullDate;
                dtpEndDate.Date = nullDate;
                drpRegDate.Date = nullDate;
                drpVisitStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                drpVisitEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                drpVisitAutoDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                drpRegTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                dtpStartDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
                dtpEndDateTime.Value = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00);
            }
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static KruAll.Core.Models.Personal GetPersonalDetails(string persID)
        {
            PersonnelRepository _PersonnelRepository = new PersonnelRepository();
            KruAll.Core.Models.Personal _Personal = new KruAll.Core.Models.Personal();
            KruAll.Core.Models.Personal _Personal2 = new KruAll.Core.Models.Personal();
            var pers = _PersonnelRepository.GetPersonnelById(Convert.ToInt64(persID));

            if (pers != null)
            {
                _Personal2.Pers_Nr = pers.Pers_Nr;
                _Personal2.FirstName = pers.FirstName;
                _Personal2.LastName = pers.LastName;
            }

            return _Personal2;
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static void DeleteVisitorDetails(string persID)
        {
            VisitorRepository _VisitorRepository = new VisitorRepository();
            var visitorList = _VisitorRepository.GetAllVisitors();

            var vExists = visitorList.Where(x => x.VisitorID == Convert.ToInt64(persID)).FirstOrDefault();

            if (vExists != null)
            {
                _VisitorRepository.DeleteVisitor(vExists);

            }
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string SendVisitorDataToTerminals(long visitorID, bool addVisitorBooking)
        {
            DataCommunication terminalDataCommunication = new DataCommunication();
            terminalDataCommunication.SendVisitorDataToTerminals(visitorID);
            terminalDataCommunication = null;

            if (addVisitorBooking)
            {
                new VisitorBookingsViewModel().CreateNewBooking(visitorID, DateTime.Today, DateTime.Now, VisitorBookingsViewModel.bookingDirection.bookingCOME);
            }
            return "Daten erfolgreich gesendet";
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string CheckOutVisitor(long visitorID)
        {
            new VisitorBookingsViewModel().CreateNewBooking(visitorID, DateTime.Today, DateTime.Now, VisitorBookingsViewModel.bookingDirection.bookingGO);
            return "Besucher abgemeldet";
        }

        protected void ddlVisitorName_DataBound(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static VisitorsDto Loadetails(long ID)
        {
            var visitor = new VisitorRepository().GetVisitorById(ID);
            VisitorsDto visitorDto = new VisitorsDto()
            {
                ID = visitor.ID,
                VisitorID = visitor.VisitorID,
                Name = visitor.SurName + " " + visitor.Fullname,
                Location = visitor.Location,
                PostalCode = visitor.PostalCode,
                //Company = visitor.Company != null ? new ClientsRepository().GetClientsById(Convert.ToInt32(visitor.Company)).Name : "",
                PersPhoto = FileProcessor.GetVisitorImageRelativeFilePath(visitor.VisitorPhoto)
            };
            return visitorDto;

        }
        protected void BindVisitors(int value)
        {
            var visitors = new VisitorRepository().GetAllVisitors();
            VisitorsDto visitorDtoKeine = new VisitorsDto()
            {
                ID = 0,
                VisitorID = 0,
                Name = "keine",
                Location = "keine",
                Company = "keine",
                PostalCode = "keine"
            };
            List<VisitorsDto> listVisitors = new List<VisitorsDto>();
            listVisitors.Add(visitorDtoKeine);
            foreach (var visitor in visitors)
            {

                VisitorsDto visitorDto = new VisitorsDto()
                {
                    ID = visitor.ID,
                    VisitorID = visitor.VisitorID,
                    Name = visitor.SurName + " " + visitor.Fullname,
                    Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "keine",
                    PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "keine",
                    CompanyID = visitor.Company,
                    Company = visitor.Company != null ? visitor.VisitorCompanyTb.Name : "keine",

                };
                listVisitors.Add(visitorDto);
            }
            switch (value)
            {
                case 0:
                    ddlVisitorName.DataSource = listVisitors;
                    ddlVisitorName.DataBind();
                    ddlVisitorID.DataSource = listVisitors;
                    ddlVisitorID.DataBind();
                    ddlCompany.DataSource = listVisitors;
                    ddlCompany.DataBind();
                    ddlVisitorIDHistory.DataSource = listVisitors;
                    ddlVisitorIDHistory.DataBind();
                    ddlVisitorNameHistory.DataSource = listVisitors;
                    ddlVisitorNameHistory.DataBind();
                    break;
                case 1:
                    ddlVisitorName.DataSource = listVisitors;
                    ddlVisitorName.DataBind();
                    break;
                case 2:
                    ddlVisitorID.DataSource = listVisitors;
                    ddlVisitorID.DataBind();
                    break;
                case 3:
                    ddlCompany.DataSource = listVisitors;
                    ddlCompany.DataBind();
                    break;
                case 4:
                    ddlVisitorIDHistory.DataSource = listVisitors;
                    ddlVisitorIDHistory.DataBind();
                    break;
                case 5:
                    ddlVisitorNameHistory.DataSource = listVisitors;
                    ddlVisitorNameHistory.DataBind();
                    break;

            }
        }
        protected void FilterVisitors(int value, string filter)
        {
            var index = 0;
            var indexAll = 0;
            var visitors = new VisitorRepository().GetAllVisitors();
            VisitorsDto visitorDtoKeine = new VisitorsDto()
            {
                ID = 0,
                VisitorID = 0,
                Name = "keine",
                Location = "keine",
                Company = "keine",
                PostalCode = "keine"
            };
            List<VisitorsDto> listVisitors = new List<VisitorsDto>();
            listVisitors.Add(visitorDtoKeine);
            foreach (var visitor in visitors)
            {

                VisitorsDto visitorDto = new VisitorsDto()
                {
                    ID = visitor.ID,
                    VisitorID = visitor.VisitorID,
                    Name = visitor.SurName + " " + visitor.Fullname,
                    Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "keine",
                    PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "keine",
                    CompanyID = visitor.Company,
                    Company = visitor.Company != null ? visitor.VisitorCompanyTb.Name : "keine",

                };
                listVisitors.Add(visitorDto);
            }
            List<VisitorsDto> _visitorList = new List<VisitorsDto>();
            _visitorList.Add(visitorDtoKeine);
            _visitorList.AddRange(listVisitors.Where(x => x.CompanyID == Convert.ToInt32(filter)).ToList());

            if (listVisitors.Count() > 1)
            {
                indexAll = 1;
            }
            if (_visitorList.Count() > 1)
            {
                index = 1;
            }
            var _filterValue = Convert.ToInt64(filter);
            switch (value)
            {
                case 1:
                    if (_filterValue == 0)
                    {
                        ddlVisitorName.DataSource = listVisitors;
                        ddlVisitorName.DataBind();
                        ddlVisitorName.SelectedIndex = indexAll;
                    }
                    else
                    {
                        ddlVisitorName.DataSource = _visitorList;
                        ddlVisitorName.DataBind();
                        ddlVisitorName.SelectedIndex = index;
                    }

                    break;
                case 2:
                    if (_filterValue == 0)
                    {
                        ddlVisitorID.DataSource = listVisitors;
                        ddlVisitorID.DataBind();
                        ddlVisitorID.SelectedIndex = indexAll;

                    }
                    else
                    {
                        ddlVisitorID.DataSource = _visitorList;
                        ddlVisitorID.DataBind();
                        ddlVisitorID.SelectedIndex = index;
                    }

                    break;
                case 3:
                    if (_filterValue == 0)
                    {
                        ddlCompany.DataSource = listVisitors;
                        ddlCompany.DataBind();
                        ddlCompany.SelectedIndex = indexAll;

                    }
                    else
                    {
                        ddlCompany.DataSource = _visitorList;
                        ddlCompany.DataBind();
                        ddlCompany.SelectedIndex = index;
                    }

                    break;
                case 4:
                    if (_filterValue == 0)
                    {
                        ddlVisitorIDHistory.DataSource = listVisitors;
                        ddlVisitorIDHistory.DataBind();
                        ddlVisitorIDHistory.SelectedIndex = indexAll;
                    }
                    else
                    {
                        ddlVisitorIDHistory.DataSource = _visitorList;
                        ddlVisitorIDHistory.DataBind();
                        ddlVisitorIDHistory.SelectedIndex = index;
                    }

                    break;
                case 5:
                    if (_filterValue == 0)
                    {
                        ddlVisitorNameHistory.DataSource = listVisitors;
                        ddlVisitorNameHistory.DataBind();
                        ddlVisitorNameHistory.SelectedIndex = indexAll;
                    }
                    else
                    {
                        ddlVisitorNameHistory.DataSource = _visitorList;
                        ddlVisitorNameHistory.DataBind();
                        ddlVisitorNameHistory.SelectedIndex = index;
                    }

                    break;

            }

        }

        protected void grdSearchPersonToVisit_SelectionChanged(object sender, EventArgs e)
        {
            var _sender = (ASPxGridView)sender;
            var persNr = _sender.GetRowValues(_sender.FocusedRowIndex, "Pers_Nr");
        }

        protected void btnTakePhoto_Click(object sender, EventArgs e)
        {
            string redirectString = string.Empty;

            redirectString = string.Format("/Dashboard_Main.aspx?Vis_Nr={0}", ddlVisitorID.Value);

            Response.Redirect(redirectString);
        }
        protected void BindVehicleTypes()
        {
            var vehicles = new VehicleTypeRepository().GetVehicleType();
            //grdVehicles.DataSource = vehicles;
            //grdVehicles.DataBind();
            //grdVehicles.FocusedRowIndex = -1;
        }
        protected void BindCompanies()
        {
            List<VisitorCompanyTb> listCompany = new List<VisitorCompanyTb>();
            VisitorCompanyTb comany = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "keine"
            };
            listCompany.Add(comany);
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            listCompany.AddRange(companies);
            dplCompanyName.DataSource = listCompany;
            dplCompanyName.DataBind();

        }
        protected void BindToCompanies()
        {
            List<Client> listCompany = new List<Client>();
            Client comany = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "keine"
            };
            listCompany.Add(comany);
            var companies = new ClientsRepository().GetClients();
            listCompany.AddRange(companies);
            dplToCompanyNr.DataSource = listCompany;
            dplToCompanyNr.DataBind();
            dplToCompanyName.DataSource = listCompany;
            dplToCompanyName.DataBind();
        }
        protected void BindAccessPlans()
        {
            VisitorPlanRepository _VisitorPlanRepository = new VisitorPlanRepository();
            var visitorDetails = _VisitorPlanRepository.GetAllVisitorPlans();

            List<TbVisitorPlan> listVisitorPlan = new List<TbVisitorPlan>();
            TbVisitorPlan visitorPlan = new TbVisitorPlan() { ID = 0, VisitorPlanNr = 0, VisitorPlanDescription = "keine" };
            listVisitorPlan.Add(visitorPlan);
            listVisitorPlan.AddRange(visitorDetails);
            cobVisitorPlanNr.DataSource = listVisitorPlan;
            cobVisitorPlanNr.DataBind();
            cobVisitorPlanName.DataSource = listVisitorPlan;
            cobVisitorPlanName.DataBind();
            if (visitorDetails.Count > 0)
            {
                cobVisitorPlanNr.SelectedIndex = 1;
                cobVisitorPlanName.SelectedIndex = 1;
            }

            grdVisitorDescription.DataSource = visitorDetails;
            grdVisitorDescription.DataBind();
            if (visitorDetails.Count() > 24)
            {
                //grdVisitorDescription.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdVisitorDescription.Settings.VerticalScrollableHeight = 770;
                grdVisitorDescription.SettingsPager.PageSize = visitorDetails.Count();
            }
        }
        protected void LoadFirstVisitor()
        {
            var visitors = new VisitorRepository().GetAllVisitors();
            if (visitors.Count > 0)
            {
                var visitor = visitors.First();
                ddlVisitorName.Value = visitor.ID.ToString();
                ddlVisitorID.Value = visitor.ID.ToString();
                ddlCompany.Value = visitor.ID.ToString();

                populateControls(visitor.ID);
            }
        }
        protected void BindTopCompanies()
        {
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            companyDetails companyAll = new companyDetails()
            {
                ID = 0,
                Nr = "0",
                PostalCode = "Alle",
                Name = "Alle",
                Location = "Alle"
            };
            List<companyDetails> ListCompany = new List<companyDetails>();
            ListCompany.Add(companyAll);
            foreach (var _company in companies)
            {
                companyDetails company = new companyDetails()
                {
                    ID = _company.ID,
                    Nr = _company.CompanyNr.ToString(),
                    Name = _company.CompanyName,
                    PostalCode = _company.ZipCode != null ? _company.ZipCode : "keine",
                    Location = _company.Place != null ? _company.Place : "keine"
                };
                ListCompany.Add(company);
            }

            ddlTopCompanyNr.DataSource = ListCompany;
            ddlTopCompanyNr.DataBind();
            ddlPostalCode.DataSource = ListCompany;
            ddlPostalCode.DataBind();
            ddlLocation.DataSource = ListCompany;
            ddlLocation.DataBind();

            ddlTopCompanyNrHistory.DataSource = ListCompany;
            ddlTopCompanyNrHistory.DataBind();
            ddlPostalCodeHistory.DataSource = ListCompany;
            ddlPostalCodeHistory.DataBind();
            ddlLocationHistory.DataSource = ListCompany;
            ddlLocationHistory.DataBind();

        }
        public class companyDetails
        {
            public long ID { get; set; }
            public string Nr { get; set; }
            public string Name { get; set; }
            public string PostalCode { get; set; }
            public string Location { get; set; }
        }

        protected void grdTransponders_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            List<ASPxDataUpdateValues> updateValues = e.UpdateValues;
            long visitorNr = 0;
            Int64.TryParse(Convert.ToString(ddlVisitorID.Value), out visitorNr);

            if (visitorNr > 0)
            {
                SaveTransponders(updateValues, 1, visitorNr);

                e.Handled = true;

                var transpondersType1 = new VisitorTransponderViewModels().TransPonders(visitorNr, 1);

                try
                {
                    grdTransponders.DataSource = transpondersType1;
                    grdTransponders.DataBind();
                }
                catch (Exception)
                { }
            }
            else
            {
                e.Handled = true;
            }
        }

        protected void grdTranspondersShortTerm_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
        {
            List<ASPxDataUpdateValues> updateValues = e.UpdateValues;
            long visitorNr = 0;
            Int64.TryParse(Convert.ToString(ddlVisitorID.Value), out visitorNr);

            if (visitorNr > 0)
            {
                SaveTransponders(updateValues, 2, visitorNr);
                e.Handled = true;

                var transpondersType2 = new VisitorTransponderViewModels().TransPonders(visitorNr, 2);

                try
                {
                    grdTranspondersShortTerm.DataSource = transpondersType2;
                    grdTranspondersShortTerm.DataBind();
                }
                catch (Exception)
                { }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SaveTransponders(List<ASPxDataUpdateValues> updateValues, int transponderType, long visitorNr)
        {
            VisitorTransponder visitorTransponder = new VisitorTransponder();
            VisitorTranspondersRepository visitorTranspondersRepository = new VisitorTranspondersRepository();
            List<VisitorTransponder> visitorTranspondersList = visitorTranspondersRepository.GetTranspondersByVisitorId(visitorNr) ?? new List<VisitorTransponder>();

            foreach (ASPxDataUpdateValues updateValue in updateValues)
            {
                var keys = updateValue.Keys;
                var oldValues = updateValue.OldValues;
                var newValues = updateValue.NewValues;

                long transponderID = 0;
                if (keys["ID"] != null) Int64.TryParse(keys["ID"].ToString(), out transponderID);
                long transponderNr = 0;
                if (newValues["TransponderNr"] != null) Int64.TryParse(newValues["TransponderNr"].ToString().Trim(), out transponderNr);
                bool transponderActive = newValues["TransponderActive"] == null ? false :
                    Convert.ToBoolean(newValues["TransponderActive"].ToString());
                DateTime issuedOn = newValues["DateIssued"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["DateIssued"]);
                DateTime validFrom = newValues["ValidFrom"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["ValidFrom"]);
                DateTime oldValidTo = oldValues["ValidTo"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(oldValues["ValidTo"]);
                DateTime validTo = newValues["ValidTo"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["ValidTo"]);
                bool transponderInactive = newValues["TransponderInActive"] == null ? false :
                    Convert.ToBoolean(newValues["TransponderInActive"].ToString());
                DateTime deactivationDate = newValues["TransponderDeactivatedOn"] == null ? DateTime.MinValue :
                    Convert.ToDateTime(newValues["TransponderDeactivatedOn"].ToString());
                int actionNr = 1;
                string memo = newValues["Memo"] == null ? "" : newValues["Memo"].ToString();

                if (transponderID > 0)
                {
                    if (visitorTranspondersList.Any(x => x.ID == transponderID))
                    {
                        visitorTransponder = visitorTranspondersList.FirstOrDefault(x => x.ID == transponderID);
                    }
                }
                else
                {
                    visitorTransponder = new VisitorTransponder();
                }

                actionNr = visitorTransponder.Action ?? 1;
                visitorTransponder.Action = oldValidTo != null && oldValidTo != DateTime.MinValue ?
                                                oldValidTo != validTo ? actionNr + 1 : actionNr : 1;
                if (issuedOn != DateTime.MinValue) visitorTransponder.DateIssued = issuedOn;
                visitorTransponder.Memo = memo;
                visitorTransponder.VisitorID = visitorNr;
                if (deactivationDate != DateTime.MinValue) visitorTransponder.TransponderDeactivatedOn = deactivationDate;
                visitorTransponder.TransponderNr = transponderNr;
                visitorTransponder.TransponderStatus = transponderActive;
                if (validFrom != DateTime.MinValue) visitorTransponder.ValidFrom = validFrom;
                if (validTo != DateTime.MinValue) visitorTransponder.ValidTo = validTo;
                visitorTransponder.TransponderType = transponderType;

                if (transponderID > 0)
                {
                    visitorTranspondersRepository.EditVisitorTransponder(visitorTransponder);
                }
                else
                {
                    visitorTranspondersRepository.AddVisitorTransponder(visitorTransponder);
                }
            }
            visitorTranspondersRepository.SaveVisitorTransponder();
        }

        protected void grdTransponders_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            long visitorNr = 0;
            Int64.TryParse(Convert.ToString(ddlVisitorID.Value), out visitorNr);

            var transpondersType1 = new VisitorTransponderViewModels().TransPonders(visitorNr, 1);

            try
            {
                grdTransponders.DataSource = transpondersType1;
                grdTransponders.DataBind();
            }
            catch (Exception)
            { }
        }

        protected void grdTranspondersShortTerm_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

            long visitorNr = 0;
            Int64.TryParse(Convert.ToString(e.Parameters), out visitorNr);

            var transpondersType2 = new VisitorTransponderViewModels().TransPonders(visitorNr, 2);

            try
            {
                grdTranspondersShortTerm.DataSource = transpondersType2;
                grdTranspondersShortTerm.DataBind();
            }
            catch (Exception)
            { }
        }
        [WebMethod]
        public static bool CheckIfVisitorIdExists(long visitorId)
        {
            bool exists = false;
            var visitor = new VisitorRepository().GetVisitorByVisitorId(visitorId);
            if (visitor != null)
            {
                exists = true;
            }
            return exists;
        }
        protected void LoadFilteredVisitors(int filter)
        {
            //var visitors = new VisitorRepository().GetAllVisitors();
            List<VisitorsDto> listVisits = new List<VisitorsDto>();
            //var visitAccessTime = new VisitorAccessTimeRepository().GetAllVisitorAccessTime().Where(x => x.StartDate.Date >= DateTime.Now.Date).ToList();
            var visitAccessTime = new VisitorAccessTimeRepository().GetAllVisitorAccessTime();

            foreach (var accessTime in visitAccessTime)
            {
                if (accessTime.Visitor.VisitorType == 2)
                {
                    var personnel = new VwPersonnelData();
                    if (accessTime.Visitor.PersonalID != null)
                    {
                        personnel = new VwPersonnelDataRepository().GetAllPersonnel().Find(x => x.ID == Convert.ToInt64(accessTime.Visitor.PersonalID));
                    }

                    VisitorsDto visitDto = new VisitorsDto()
                    {
                        ID = accessTime.ID,
                        VisitorID = accessTime.Visitor.VisitorID,
                        SurName = accessTime.Visitor.SurName,
                        OtherName = accessTime.Visitor.Fullname,
                        Street = accessTime.Visitor.Street,
                        CompanyID = accessTime.Visitor.Company,
                        Company = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.CompanyName : "",
                        CompanyNr = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.CompanyNr.ToString() : "",
                        CompanyStreet = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Street : "",
                        //CompanyStreetNr = accessTime.Visitor.Company != null ? accessTime.Visitor.Client.HouseNr : "",
                        CompanyLocation = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Place : "",
                        CompanyPostalCode = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.ZipCode : "",
                        PostalCode = accessTime.Visitor.PostalCode,
                        Location = accessTime.Visitor.Location,
                        Telephone = accessTime.Visitor.Telephone,
                        Mobile = accessTime.Visitor.Mobile,
                        Email = accessTime.Visitor.Email,
                        StartDate = accessTime.StartDate.ToShortDateString(),
                        EndDate = accessTime.EndDate != null ? Convert.ToDateTime(accessTime.EndDate).ToShortDateString() : "",
                        StreetNr = accessTime.Visitor.StreetNr,
                        PersName = accessTime.Visitor.PersonalID != null ? string.Format("{0} {1}", personnel.FirstName, personnel.LastName) : "",
                        PersPhoneNr = accessTime.Visitor.PersonalID != null ? personnel.CompanyTel : "",
                        vStartDate = accessTime.StartDate,
                        vEndDate = accessTime.EndDate,
                        VisitorName = string.Format("{0} {1}", accessTime.Visitor.Fullname, accessTime.Visitor.SurName)

                    };
                    listVisits.Add(visitDto);
                }


            }
            if (filter == 0)
            {
                grdFilteredVisitors.DataSource = listVisits.OrderBy(X => X.VisitorID);
                grdFilteredVisitors.DataBind();
                if (listVisits.Count > 24)
                {
                    //grdFilteredVisitors.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                    //grdFilteredVisitors.Settings.VerticalScrollableHeight = 822;
                    grdFilteredVisitors.SettingsPager.PageSize = listVisits.Count();
                }

            }
            else
            {
                var _visitorList = listVisits.Where(x => x.CompanyID == filter).OrderBy(x => x.VisitorID).ToList();
                grdFilteredVisitors.DataSource = _visitorList;
                grdFilteredVisitors.DataBind();
                if (_visitorList.Count > 24)
                {
                    //grdFilteredVisitors.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                    //grdFilteredVisitors.Settings.VerticalScrollableHeight = 822;
                    grdFilteredVisitors.SettingsPager.PageSize = _visitorList.Count();
                }
            }


        }
        [WebMethod]
        public static VisitorsDto GetVisitorByInstance(long Id)
        {
            var card_nr1 = "";
            var card_nr2 = "";
            var card_nr1Status = false;
            var card_nr2Status = false;
            var visitPlan = "";
            var accessTime = new VisitorAccessTimeRepository().GetAccessTimeById(Id);
            var transponder1 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(accessTime.Visitor.ID).FirstOrDefault(x => x.TransponderType == 1);
            var transponder2 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(accessTime.Visitor.ID).FirstOrDefault(x => x.TransponderType == 2);
            var persActivatedName = "";

            if (transponder1 != null)
            {
                card_nr1 = transponder1.TransponderNr.ToString();
                card_nr1Status = transponder1.TransponderStatus != null ? Convert.ToBoolean(transponder1.TransponderStatus) : false;
            }
            if (transponder2 != null)
            {
                card_nr2 = transponder2.TransponderNr.ToString();
                card_nr2Status = transponder2.TransponderStatus != null ? Convert.ToBoolean(transponder2.TransponderStatus) : false;
            }


            if (accessTime.PersNr != null)
            {
                var pers = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(accessTime.PersNr));
                persActivatedName = string.Format("{0} {1}", pers.FirstName, pers.LastName);
                ActivationTime activate = new ActivationTime()
                {
                    PersNr = pers.Pers_Nr,
                    PersName = string.Format("{0} {1}", pers.FirstName, pers.LastName),
                    ActivationDate = Convert.ToDateTime(accessTime.DateActivated),
                };
                HttpContext.Current.Session["CardActivation"] = activate;
            }
            else
            {
                HttpContext.Current.Session["CardActivation"] = null;
            }
            VisitorsDto visitDto = new VisitorsDto()
            {
                ID = accessTime.Visitor.ID,
                VisitorID = accessTime.Visitor.VisitorID,
                SurName = accessTime.Visitor.SurName,
                OtherName = accessTime.Visitor.Fullname,
                Company = accessTime.Visitor.Company != null ? accessTime.Visitor.Company.ToString() : "0",
                VisitorCompanyId = accessTime.Visitor.Company != null ? accessTime.Visitor.Company.ToString() : "",
                VisitorCompanyName = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.CompanyName : "",
                Street = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Street : "",
                CompanyStreetNr = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.HouseNr : "",
                PostalCode = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.ZipCode : "",
                Location = accessTime.Visitor.Company != null ? accessTime.Visitor.VisitorCompanyTb.Place : "",
                Telephone = accessTime.Visitor.Telephone,
                Mobile = accessTime.Visitor.Mobile,
                Email = accessTime.Visitor.Email,
                VehicleRegNo = accessTime.Visitor.VehicleRegNr,
                CarType = accessTime.Visitor.VisitorVehicleType != null ? string.Format("{0}-{1}", accessTime.Visitor.VehicleType.ID, accessTime.Visitor.VehicleType.Type) : "",
                VisitorVehicleId = accessTime.Visitor.VisitorVehicleType != null ? string.Format("{0}", accessTime.Visitor.VehicleType.ID) : "",
                PersName = accessTime.Visitor.PersonalID != null ? string.Format("{0} {1}", accessTime.Visitor.Personal.FirstName, accessTime.Visitor.Personal.LastName) : "",
                PersNr = accessTime.Visitor.PersonalID != null ? accessTime.Visitor.Personal.Pers_Nr.ToString() : "",
                PersMobileNr = accessTime.Visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == accessTime.Visitor.PersonalID).PrivateMobile : "",
                PersPhoneNr = accessTime.Visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == accessTime.Visitor.PersonalID).CompanyTel : "",
                VisitReason = accessTime.VisitReason,
                vStartDate = accessTime.StartDate,
                vEndDate = accessTime.EndDate != null ? Convert.ToDateTime(accessTime.EndDate) : (DateTime?)null,
                vRegDate = accessTime.RegistrationDate != null ? Convert.ToDateTime(accessTime.RegistrationDate) : (DateTime?)null,
                CardNrLongTerm = card_nr1,
                CardNrShortTerm = card_nr2,
                CardNrLongTermStatus = card_nr1Status,
                CardNrShortTermStatus = card_nr2Status,
                VisitPlan = accessTime.VisitPlanId != null ? accessTime.VisitPlanId.ToString() : "0",
                AccessStartDate = accessTime.VisitAccessStartDate != null ? Convert.ToDateTime(accessTime.VisitAccessStartDate) : (DateTime?)null,
                AccessEndDate = accessTime.VisitAccessEndDate != null ? Convert.ToDateTime(accessTime.VisitAccessEndDate) : (DateTime?)null,
                VisitInstance = accessTime.VisitInstanceId.ToString(),
                AcessPlanActive = accessTime.AccessPlanActive != null ? Convert.ToBoolean(accessTime.AccessPlanActive) : false,
                DateActivated = accessTime.DateActivated != null ? Convert.ToDateTime(accessTime.DateActivated).ToShortDateString() : "",
                PersActivated = persActivatedName,
                CompanyTo = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : "0",
                CompanyToName = accessTime.CompanyTo != null ? accessTime.Client.Name : "",
                CardActive = accessTime.Visitor.CardActive,
                VisitInstanceId = accessTime.VisitInstanceId,
                AutoLogoutTime = accessTime.AutoEndDate != null ? Convert.ToDateTime(accessTime.AutoEndDate) : (DateTime?)null,
                AutoLogout = accessTime.AutoLogout != null ? Convert.ToBoolean(accessTime.AutoLogout) : false
            };

            return visitDto;
        }
        [WebMethod]
        public static VisitorsDto GetVisitorByID(long Id)
        {
            var visitor = new VisitorRepository().GetVisitorById(Id);
            var card_nr1 = "";
            var card_nr2 = "";
            var card_nr1Status = false;
            var card_nr2Status = false;
            var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(Id);
            var transponder1 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 1);
            var transponder2 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 2);
            var persActivatedName = "";
            if (transponder1 != null)
            {
                card_nr1 = transponder1.TransponderNr.ToString();
                card_nr1Status = transponder1.TransponderStatus != null ? Convert.ToBoolean(transponder1.TransponderStatus) : false;
            }
            if (transponder2 != null)
            {
                card_nr2 = transponder2.TransponderNr.ToString();
                card_nr2Status = transponder2.TransponderStatus != null ? Convert.ToBoolean(transponder2.TransponderStatus) : false;
            }

            if (accessTime.PersNr != null)
            {
                var pers = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(accessTime.PersNr));
                persActivatedName = string.Format("{0} {1}", pers.FirstName, pers.LastName);
                ActivationTime activate = new ActivationTime()
                {
                    PersNr = pers.Pers_Nr,
                    PersName = string.Format("{0} {1}", pers.FirstName, pers.LastName),
                    ActivationDate = Convert.ToDateTime(accessTime.DateActivated),
                };
                HttpContext.Current.Session["CardActivation"] = activate;
            }
            else
            {
                HttpContext.Current.Session["CardActivation"] = null;
            }
            VisitorsDto visitDto = new VisitorsDto()
            {
                ID = visitor.ID,
                VisitorID = visitor.VisitorID,
                SurName = visitor.SurName,
                OtherName = visitor.Fullname,
                Company = visitor.Company != null ? visitor.Company.ToString() : "0",
                VisitorCompanyId = visitor.Company != null ? visitor.Company.ToString() : "",
                VisitorCompanyName = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "",
                Street = visitor.Company != null ? visitor.VisitorCompanyTb.Street : "",
                CompanyStreetNr = visitor.Company != null ? visitor.VisitorCompanyTb.HouseNr : "",
                PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "",
                Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "",
                Telephone = visitor.Telephone,
                Mobile = visitor.Mobile,
                Email = visitor.Email,
                VehicleRegNo = visitor.VehicleRegNr,
                CarType = visitor.VisitorVehicleType != null ? string.Format("{0}", visitor.VehicleType.Type) : "",
                VisitorVehicleId = visitor.VisitorVehicleType != null ? string.Format("{0}", visitor.VehicleType.ID) : "",
                PersName = visitor.PersonalID != null ? string.Format("{0} {1}", visitor.Personal.FirstName, visitor.Personal.LastName) : "",
                PersNr = visitor.PersonalID != null ? visitor.Personal.Pers_Nr.ToString() : "",
                PersMobileNr = visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == visitor.PersonalID).PrivateMobile : "",
                PersPhoneNr = visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == visitor.PersonalID).CompanyTel : "",
                VisitReason = accessTime.VisitReason,
                vStartDate = accessTime.StartDate,
                vEndDate = accessTime.EndDate != null ? Convert.ToDateTime(accessTime.EndDate) : (DateTime?)null,
                vRegDate = accessTime.RegistrationDate != null ? Convert.ToDateTime(accessTime.RegistrationDate) : (DateTime?)null,
                CardNrLongTerm = card_nr1,
                CardNrShortTerm = card_nr2,
                CardNrLongTermStatus = card_nr1Status,
                CardNrShortTermStatus = card_nr2Status,
                VisitPlan = accessTime.VisitPlanId != null ? accessTime.VisitPlanId.ToString() : "0",
                AccessStartDate = accessTime.VisitAccessStartDate != null ? Convert.ToDateTime(accessTime.VisitAccessStartDate) : (DateTime?)null,
                AccessEndDate = accessTime.VisitAccessEndDate != null ? Convert.ToDateTime(accessTime.VisitAccessEndDate) : (DateTime?)null,
                VisitInstance = accessTime.VisitInstanceId.ToString(),
                AcessPlanActive = accessTime.AccessPlanActive != null ? Convert.ToBoolean(accessTime.AccessPlanActive) : false,
                DateActivated = accessTime.DateActivated != null ? Convert.ToDateTime(accessTime.DateActivated).ToShortDateString() : "",
                PersActivated = persActivatedName,
                PersPhoto = FileProcessor.GetVisitorImageRelativeFilePath(visitor.VisitorPhoto),
                CompanyTo = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : "0",
                CompanyToName = accessTime.CompanyTo != null ? accessTime.Client.Name : "",
                CardActive = visitor.CardActive,
                VisitInstanceId = accessTime.VisitInstanceId,
                AutoLogoutTime = accessTime.AutoEndDate != null ? Convert.ToDateTime(accessTime.AutoEndDate) : (DateTime?)null,
                AutoLogout = accessTime.AutoLogout != null ? Convert.ToBoolean(accessTime.AutoLogout) : false
            };

            return visitDto;
        }
        [WebMethod]
        public static VisitorsDto GetVisitorByIDToEdit(long Id)
        {
            var visitor = new VisitorRepository().GetVisitorById(Id);
            var card_nr1 = "";
            var card_nr2 = "";
            var card_nr1Status = false;
            var card_nr2Status = false;
            var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(Id);
            var transponder1 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 1);
            var transponder2 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 2);
            var persActivatedName = "";
            if (transponder1 != null)
            {
                card_nr1 = transponder1.TransponderNr.ToString();
                card_nr1Status = transponder1.TransponderStatus != null ? Convert.ToBoolean(transponder1.TransponderStatus) : false;
            }
            if (transponder2 != null)
            {
                card_nr2 = transponder2.TransponderNr.ToString();
                card_nr2Status = transponder2.TransponderStatus != null ? Convert.ToBoolean(transponder2.TransponderStatus) : false;
            }

            if (accessTime.PersNr != null)
            {
                var pers = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(accessTime.PersNr));
                persActivatedName = string.Format("{0} {1}", pers.FirstName, pers.LastName);
                ActivationTime activate = new ActivationTime()
                {
                    PersNr = pers.Pers_Nr,
                    PersName = string.Format("{0} {1}", pers.FirstName, pers.LastName),
                    ActivationDate = Convert.ToDateTime(accessTime.DateActivated),
                };
                HttpContext.Current.Session["CardActivation"] = activate;
            }
            else
            {
                HttpContext.Current.Session["CardActivation"] = null;
            }
            VisitorsDto visitDto = new VisitorsDto()
            {
                ID = visitor.ID,
                VisitorID = visitor.VisitorID,
                SurName = visitor.SurName,
                OtherName = visitor.Fullname,
                Company = visitor.Company != null ? visitor.Company.ToString() : "0",
                VisitorCompanyId = visitor.Company != null ? visitor.Company.ToString() : "",
                VisitorCompanyName = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "",
                Street = visitor.Company != null ? visitor.VisitorCompanyTb.Street : "",
                CompanyStreetNr = visitor.Company != null ? visitor.VisitorCompanyTb.HouseNr : "",
                PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "",
                Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "",
                Telephone = visitor.Telephone,
                Mobile = visitor.Mobile,
                Email = visitor.Email,
                VehicleRegNo = visitor.VehicleRegNr,
                CarType = visitor.VisitorVehicleType != null ? string.Format("{0}", visitor.VehicleType.Type) : "",
                VisitorVehicleId = visitor.VisitorVehicleType != null ? string.Format("{0}", visitor.VehicleType.ID) : "",
                PersName = visitor.PersonalID != null ? string.Format("{0} {1}", visitor.Personal.FirstName, visitor.Personal.LastName) : "",
                PersNr = visitor.PersonalID != null ? visitor.Personal.Pers_Nr.ToString() : "",
                PersMobileNr = visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == visitor.PersonalID).PrivateMobile : "",
                PersPhoneNr = visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == visitor.PersonalID).CompanyTel : "",
                VisitReason = accessTime.VisitReason,
                vStartDate = accessTime.StartDate,
                vEndDate = accessTime.EndDate != null ? Convert.ToDateTime(accessTime.EndDate) : (DateTime?)null,
                vRegDate = accessTime.RegistrationDate != null ? Convert.ToDateTime(accessTime.RegistrationDate) : (DateTime?)null,
                CardNrLongTerm = card_nr1,
                CardNrShortTerm = card_nr2,
                CardNrLongTermStatus = card_nr1Status,
                CardNrShortTermStatus = card_nr2Status,
                VisitPlan = accessTime.VisitPlanId != null ? accessTime.VisitPlanId.ToString() : "0",
                AccessStartDate = accessTime.VisitAccessStartDate != null ? Convert.ToDateTime(accessTime.VisitAccessStartDate) : (DateTime?)null,
                AccessEndDate = accessTime.VisitAccessEndDate != null ? Convert.ToDateTime(accessTime.VisitAccessEndDate) : (DateTime?)null,
                VisitInstance = accessTime.VisitInstanceId.ToString(),
                AcessPlanActive = accessTime.AccessPlanActive != null ? Convert.ToBoolean(accessTime.AccessPlanActive) : false,
                DateActivated = accessTime.DateActivated != null ? Convert.ToDateTime(accessTime.DateActivated).ToShortDateString() : "",
                PersActivated = persActivatedName,
                PersPhoto = FileProcessor.GetVisitorImageRelativeFilePath(visitor.VisitorPhoto),
                CompanyTo = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : "0",
                CompanyToName = accessTime.CompanyTo != null ? accessTime.Client.Name : "",
                CardActive = visitor.CardActive,
                VisitInstanceId = GetVisitInstance(),
                AutoLogoutTime = accessTime.AutoEndDate != null ? Convert.ToDateTime(accessTime.AutoEndDate) : (DateTime?)null,
                AutoLogout = accessTime.AutoLogout != null ? Convert.ToBoolean(accessTime.AutoLogout) : false
            };

            return visitDto;

            //var today = DateTime.Now;
            //var visitor = new VisitorRepository().GetVisitorById(Id);
            //var card_nr1 = "";
            //var card_nr2 = "";
            //var card_nr1Status = false;
            //var card_nr2Status = false;
            //var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(Id);
            //var transponder1 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 1);
            //var transponder2 = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 2);
            //var persActivatedName = "";
            //if (transponder1 != null)
            //{
            //    card_nr1 = transponder1.TransponderNr.ToString();
            //    card_nr1Status = transponder1.TransponderStatus != null ? Convert.ToBoolean(transponder1.TransponderStatus) : false;
            //}
            //if (transponder2 != null)
            //{
            //    card_nr2 = transponder2.TransponderNr.ToString();
            //    card_nr2Status = transponder2.TransponderStatus != null ? Convert.ToBoolean(transponder2.TransponderStatus) : false;
            //}
            //HttpContext.Current.Session["CardActivation"] = null;

            //VisitorsDto visitDto = new VisitorsDto()
            //{
            //    ID = visitor.ID,
            //    VisitorID = visitor.VisitorID,
            //    SurName = visitor.SurName,
            //    OtherName = visitor.Fullname,
            //    Company = visitor.Company != null ? visitor.Company.ToString() : "0",
            //    VisitorCompanyName = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "",
            //    Street = visitor.Company != null ? visitor.VisitorCompanyTb.Street : "",
            //    CompanyStreetNr = visitor.Company != null ? visitor.VisitorCompanyTb.HouseNr : "",
            //    PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "",
            //    Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "",
            //    Telephone = visitor.Telephone,
            //    Mobile = visitor.Mobile,
            //    Email = visitor.Email,
            //    VehicleRegNo = visitor.VehicleRegNr,
            //    CarType = visitor.VisitorVehicleType != null ? string.Format("{0}-{1}", visitor.VehicleType.ID, visitor.VehicleType.Type) : "",
            //    VisitorVehicleId = visitor.VisitorVehicleType != null ? string.Format("{0}", visitor.VehicleType.ID) : "",
            //    PersName = visitor.PersonalID != null ? string.Format("{0} {1}", visitor.Personal.FirstName, visitor.Personal.LastName) : "",
            //    PersNr = visitor.PersonalID != null ? visitor.Personal.Pers_Nr.ToString() : "",
            //    PersMobileNr = visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == visitor.PersonalID).PrivateMobile : "",
            //    PersPhoneNr = visitor.PersonalID != null ? new VwPersonnelDataRepository().GetAllPersonnel().FirstOrDefault(x => x.ID == visitor.PersonalID).CompanyTel : "",
            //    VisitReason = accessTime.VisitReason,
            //    vStartDate = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00),
            //    vEndDate = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00),
            //    vRegDate = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00),
            //    vStartDateTime = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59),
            //    vEndDateTime = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59),
            //    vRegDateTime = today,
            //    CardNrLongTerm = card_nr1,
            //    CardNrShortTerm = card_nr2,
            //    CardNrLongTermStatus = card_nr1Status,
            //    CardNrShortTermStatus = card_nr2Status,
            //    VisitPlan = "0",
            //    AcessPlanActive = false,
            //    DateActivated = "",
            //    PersActivated = persActivatedName,
            //    PersPhoto = FileProcessor.GetVisitorImageFile(visitor.VisitorPhoto),
            //    CompanyTo = accessTime.CompanyTo != null ? accessTime.CompanyTo.ToString() : "0",
            //    CompanyToName = accessTime.CompanyTo != null ? accessTime.Client.Name : "",
            //    CardActive = visitor.CardActive,
            //    VisitInstanceId = GetVisitInstance(),
            //    AutoLogoutTime = new DateTime(today.Year, today.Month, today.Day, 00, 00, 00),
            //    AutoLogout =  false

            //};

            //return visitDto;
        }
        protected static long GetVisitInstance()
        {
            long visitInstanceId = 0;
            var visitorTimeSchedule = new VisitorAccessTimeViewModel().GetAllAccessTime();
            if (visitorTimeSchedule.Count > 0)
            {

                visitInstanceId = Convert.ToInt64(visitorTimeSchedule.Max(i => i.VisitInstanceId));
            }

            return visitInstanceId + 1;
        }

        protected void BindSearchVisitors(List<Visitor> visitors)
        {
            List<VisitorsDto> listVisitDto = new List<VisitorsDto>();
            if (visitors.Count > 0)
            {
                foreach (var visitor in visitors)
                {
                    var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(visitor.ID);

                    VisitorsDto visitDto = new VisitorsDto()
                    {
                        ID = visitor.ID,
                        VisitorID = visitor.VisitorID,
                        SurName = visitor.SurName,
                        OtherName = visitor.Fullname,
                        VisitorName = string.Format("{0} {1}", visitor.Fullname, visitor.SurName),
                        Street = string.Format("{0} {1}", visitor.Street, visitor.StreetNr),
                        Company = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "",
                        CompanyNr = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyNr.ToString() : "",
                        CompanyLocation = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "",
                        CompanyPostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "",
                        CompanyStreet = visitor.Company != null ? visitor.VisitorCompanyTb.Street : "",
                        CompanyStreetNr = visitor.Company != null ? visitor.VisitorCompanyTb.HouseNr : "",
                        PostalCode = visitor.PostalCode,
                        Location = visitor.Location,
                        Telephone = visitor.Telephone,
                        Mobile = visitor.Mobile,
                        Email = visitor.Email,
                        vStartDate = accessTime.StartDate,
                        vEndDate = accessTime.EndDate

                    };
                    listVisitDto.Add(visitDto);
                }
            }
            grdSearchVisitors.DataSource = listVisitDto;
            grdSearchVisitors.DataBind();
            //if (listVisitDto.Count <= 26)
            //{
            //    grdSearchVisitors.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
            //}
            //else
            //{
            //    grdSearchVisitors.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowAllRecords;
            //}
        }
        protected void BindVisitorsHistory(List<Visitor> visitors)
        {
            List<VisitorsDto> listVisitDto = new List<VisitorsDto>();
            if (visitors.Count > 0)
            {
                foreach (var visitor in visitors)
                {
                    var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(visitor.ID);
                    VisitorsDto visitDto = new VisitorsDto()
                    {
                        ID = visitor.ID,
                        VisitorID = visitor.VisitorID,
                        SurName = visitor.SurName,
                        OtherName = visitor.Fullname,
                        VisitorName = string.Format("{0} {1}", visitor.Fullname, visitor.SurName),
                        Street = string.Format("{0} {1}", visitor.Street, visitor.StreetNr),
                        Company = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "",
                        CompanyNr = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyNr.ToString() : "",
                        CompanyLocation = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "",
                        CompanyPostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "",
                        CompanyStreet = visitor.Company != null ? visitor.VisitorCompanyTb.Street : "",
                        CompanyStreetNr = visitor.Company != null ? visitor.VisitorCompanyTb.HouseNr : "",
                        PostalCode = visitor.PostalCode,
                        Location = visitor.Location,
                        Telephone = visitor.Telephone,
                        Mobile = visitor.Mobile,
                        Email = visitor.Email,
                        vStartDate = accessTime.StartDate,
                        vEndDate = accessTime.EndDate

                    };
                    listVisitDto.Add(visitDto);
                }
            }
            grdVisitorsHistory.DataSource = listVisitDto;
            grdVisitorsHistory.DataBind();
            if (listVisitDto.Count() > 24)
            {
                //grdVisitorsHistory.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdVisitorsHistory.Settings.VerticalScrollableHeight = 729;
                grdVisitorsHistory.SettingsPager.PageSize = listVisitDto.Count();
            }
        }



        void LoadClientsGrid()
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            var ClientsList = _ClientsRepository.GetClients();
            grdClients.DataSource = ClientsList;
            grdClients.DataBind();
            grdClients.FocusedRowIndex = -1;

            if (ClientsList.Count > 24)
            {
                //grdClients.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdClients.Settings.VerticalScrollableHeight = 707;
                grdClients.SettingsPager.PageSize = ClientsList.Count();
            }

            cboClientName.DataSource = ClientsList;
            cboClientName.DataBind();

            cboClentZipCode.DataSource = ClientsList;
            cboClentZipCode.DataBind();

            cboClientPlace.DataSource = ClientsList;
            cboClientPlace.DataBind();
        }


        [WebMethod]
        public static void InsertClient(string ClientID, string Client_Nr, string ClientName)
        {

            if (Client_Nr != "" && ClientName != "")
            {
                int i;
                if (int.TryParse(Client_Nr, out i) == true)
                {
                    ClientsRepository _ClientsRepository = new ClientsRepository();
                    var _client = _ClientsRepository.GetClientsById(Convert.ToInt32(ClientID));
                    var _clientByNr = _ClientsRepository.GetClientsByNr(Convert.ToInt32(Client_Nr));
                    if (_client == null && _clientByNr == null)
                    {
                        Client _Client = new Client() { Client_Nr = Convert.ToInt32(Client_Nr), Name = ClientName };
                        _ClientsRepository.NewClient(_Client);
                    }
                    else
                    {
                        if (ClientID == "0") { return; }
                        _client.Client_Nr = Convert.ToInt32(Client_Nr);
                        _client.Name = ClientName;
                        _ClientsRepository.EditClient(_client);
                    }
                }
            }

        }

        [WebMethod]
        public static void DeleteClient(int ClientID)
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            Client _Client = new Client() { ID = ClientID };
            _ClientsRepository.DeleteClient(_Client);

        }

        [WebMethod]
        public static long GetLastInsertedClient()
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            var _Client = _ClientsRepository.GetLastInserted();
            if (_Client == null) { return 1; }
            else { return _Client.Client_Nr + 1; }
        }

        protected void grdClients_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadClientsGrid();
        }
        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            //var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            //var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        public class ActivationTime
        {
            public long PersNr { get; set; }
            public string PersName { get; set; }
            public DateTime ActivationDate { get; set; }
        }
        [WebMethod]
        public static ActivationTime GetActivationDetails()
        {
            var personnal = new PersonnelRepository().GetPersonnelByPersNumber(Convert.ToInt64(HttpContext.Current.Session["Pers_Nr"]));
            ActivationTime activate = new ActivationTime()
            {
                PersNr = personnal.Pers_Nr,
                PersName = string.Format("{0} {1}", personnal.FirstName, personnal.LastName),
                ActivationDate = DateTime.Now,
            };
            HttpContext.Current.Session["CardActivation"] = activate;
            return activate;
        }
        [WebMethod]
        public static void RemoveActivationDetails()
        {
            HttpContext.Current.Session["CardActivation"] = null;
        }

        protected void dplCompanyName_Callback(object sender, CallbackEventArgsBase e)
        {
            List<VisitorCompanyTb> listCompany = new List<VisitorCompanyTb>();
            VisitorCompanyTb comany = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "keine"
            };
            listCompany.Add(comany);
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            listCompany.AddRange(companies);
            dplCompanyName.DataSource = listCompany;
            dplCompanyName.DataBind();

        }

        protected void grdFilteredVisitors_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                LoadFilteredVisitors(Convert.ToInt32(e.Parameters));
            }
            else
            {
                LoadFilteredVisitors(0);
            }

        }

        protected void grdSearchVisitors_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                VisitorRepository _VisitorRepository = new VisitorRepository();
                if (Convert.ToInt32(e.Parameters) != 0)
                {
                    var visitorList = _VisitorRepository.GetAllVisitors().Where(x => x.Company == Convert.ToInt32(e.Parameters)).ToList();
                    BindSearchVisitors(visitorList);
                }
                else
                {
                    var visitorList = _VisitorRepository.GetAllVisitors();
                    BindSearchVisitors(visitorList);
                }

            }
            else
            {
                VisitorRepository _VisitorRepository = new VisitorRepository();
                var visitorList = _VisitorRepository.GetAllVisitors();
                BindSearchVisitors(visitorList);
            }

        }

        protected void dplToCompanyNr_Callback(object sender, CallbackEventArgsBase e)
        {
            List<Client> listCompany = new List<Client>();
            Client comany = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "keine"
            };
            listCompany.Add(comany);
            var companies = new ClientsRepository().GetClients();
            listCompany.AddRange(companies);
            dplToCompanyNr.DataSource = listCompany;
            dplToCompanyNr.DataBind();
        }

        protected void dplToCompanyName_Callback(object sender, CallbackEventArgsBase e)
        {
            List<Client> listCompany = new List<Client>();
            Client comany = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "keine"
            };
            listCompany.Add(comany);
            var companies = new ClientsRepository().GetClients();
            listCompany.AddRange(companies);
            dplToCompanyName.DataSource = listCompany;
            dplToCompanyName.DataBind();
        }

        protected void fvNavPrev_Click(object sender, EventArgs e)
        {
            MoveToPrevious();
        }

        protected void fvNavNext_Click(object sender, EventArgs e)
        {
            MoveToNext();
        }

        protected void ddlTopCompanyNr_Callback(object sender, CallbackEventArgsBase e)
        {

            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            companyDetails companyAll = new companyDetails()
            {
                ID = 0,
                Nr = "0",
                Name = "Alle"
            };
            List<companyDetails> ListCompany = new List<companyDetails>();
            ListCompany.Add(companyAll);
            foreach (var _company in companies)
            {
                companyDetails company = new companyDetails()
                {
                    ID = _company.ID,
                    Nr = _company.CompanyNr.ToString(),
                    Name = _company.Name
                };
                ListCompany.Add(company);
            }

            ddlTopCompanyNr.DataSource = ListCompany;
            ddlTopCompanyNr.DataBind();
        }

        protected void ddlVisitorName_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] _param = e.Parameter.Split(';');
                var id = _param[0];
                var filter = _param[1];
                if (!string.IsNullOrEmpty(filter))
                {
                    FilterVisitors(1, filter);
                    if (!string.IsNullOrEmpty(id))
                    {
                        ddlVisitorName.Value = id;
                    }
                }
                else
                {
                    BindVisitors(1);
                    ddlVisitorName.Value = id;
                }
            }
            else
            {
                BindVisitors(1);
                if (ddlVisitorName.Items.Count > 1)
                {
                    ddlVisitorName.SelectedIndex = 1;
                }
            }


        }

        protected void ddlVisitorID_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] _param = e.Parameter.Split(';');
                var id = _param[0];
                var filter = _param[1];
                if (!string.IsNullOrEmpty(filter))
                {
                    FilterVisitors(2, filter);
                    if (!string.IsNullOrEmpty(id))
                    {
                        ddlVisitorID.Value = id;
                    }
                }
                else
                {
                    BindVisitors(2);
                    ddlVisitorID.Value = id;
                }
            }
            else
            {
                BindVisitors(2);
                if (ddlVisitorID.Items.Count > 1)
                {
                    ddlVisitorID.SelectedIndex = 1;
                }
            }


        }

        protected void ddlCompany_Callback(object sender, CallbackEventArgsBase e)
        {
            string[] _param = e.Parameter.Split(';');
            var id = _param[0];
            var filter = _param[1];
            if (!string.IsNullOrEmpty(filter))
            {
                FilterVisitors(3, filter);
                if (!string.IsNullOrEmpty(id))
                {
                    ddlCompany.Value = id;
                }
            }
            else
            {
                BindVisitors(3);
                ddlCompany.Value = id;
            }

        }

        protected void ddlLocation_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void ddlPostalCode_Callback(object sender, CallbackEventArgsBase e)
        {


        }

        protected void grdVisitorsHistory_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                VisitorRepository _VisitorRepository = new VisitorRepository();
                if (Convert.ToInt32(e.Parameters) != 0)
                {
                    var visitorList = _VisitorRepository.GetAllVisitors().Where(x => x.Company == Convert.ToInt32(e.Parameters)).ToList();
                    BindVisitorsHistory(visitorList);
                }
                else
                {
                    var visitorList = _VisitorRepository.GetAllVisitors();
                    BindVisitorsHistory(visitorList);
                }

            }
            else
            {
                VisitorRepository _VisitorRepository = new VisitorRepository();
                var visitorList = _VisitorRepository.GetAllVisitors();
                BindVisitorsHistory(visitorList);
            }
        }

        protected void ddlLocationHistory_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void ddlPostalCodeHistory_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void ddlTopCompanyNrHistory_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void ddlVisitorNameHistory_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] _param = e.Parameter.Split(';');
                var id = _param[0];
                var filter = _param[1];
                if (!string.IsNullOrEmpty(filter))
                {
                    FilterVisitors(5, filter);
                    if (!string.IsNullOrEmpty(id))
                    {
                        ddlVisitorNameHistory.Value = id;
                    }
                }
                else
                {
                    BindVisitors(5);
                    ddlVisitorNameHistory.Value = id;
                }
            }
            else
            {
                BindVisitors(5);
                if (ddlVisitorName.Items.Count > 1)
                {
                    ddlVisitorNameHistory.SelectedIndex = 1;
                }
            }
        }

        protected void ddlVisitorIDHistory_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string[] _param = e.Parameter.Split(';');
                var id = _param[0];
                var filter = _param[1];
                if (!string.IsNullOrEmpty(filter))
                {
                    FilterVisitors(4, filter);
                    if (!string.IsNullOrEmpty(id))
                    {
                        ddlVisitorIDHistory.Value = id;
                    }
                }
                else
                {
                    BindVisitors(4);
                    ddlVisitorIDHistory.Value = id;
                }
            }
            else
            {
                BindVisitors(4);
                if (ddlVisitorIDHistory.Items.Count > 1)
                {
                    ddlVisitorIDHistory.SelectedIndex = 1;
                }
            }
        }
        [WebMethod]
        public static VisitorCompanyDto GetCompanyDetails(long id)
        {
            var company = new VisitorCompanyRepository().GetVisitorCompanyById(id);
            VisitorCompanyDto compDto = new VisitorCompanyDto();
            if (company != null)
            {
                compDto.VisitorCompanyId = company.ID.ToString();
                compDto.Street = company.Street;
                compDto.ZipCode = company.ZipCode;
                compDto.Place = company.Place;
                compDto.StreetNr = company.HouseNr;
                compDto.Company = string.Format("{1}", company.ID, company.CompanyName);
            }
            return compDto;
        }
        protected void ClearItems()
        {
            txtCompanyName.Text = string.Empty;
            txtCompanyNr.Text = string.Empty;
            txtCompanyMemo.Text = string.Empty;
            txtCompanyEmail.Text = string.Empty;
            txtCompanyPersName.Text = string.Empty;
            txtCompanyZipCode.Text = string.Empty;
            txtCompanyStreet.Text = string.Empty;
            txtCompanyTel.Text = string.Empty;
            txtCompanyMob.Text = string.Empty;
            txtCompanyHouseNr.Text = string.Empty;
            txtCompanyFunct.Text = string.Empty;
            txtCompanyPlace.Text = string.Empty;
            btnDeleteCompany.Enabled = false;
        }
        protected void NextCompanyNr()
        {
            int CompanyNr = 0;
            var visitorCompanyDetails = new VisitorCompanyRepository().GetAllVisitorCompanies();
            if (visitorCompanyDetails.Count() > 0)
            {
                CompanyNr = Convert.ToInt32(visitorCompanyDetails.Max(i => i.CompanyNr));
            }
            else
            {
                CompanyNr = 0;
            }
            int nextNr = CompanyNr + 1;
            txtCompanyNr.Text = nextNr.ToString();
            txtCompanyName.Focus();
        }

        void BindControls()
        {
            LocationFederalStateRepository _LocationFederalStateRepository = new LocationFederalStateRepository();
            var states = _LocationFederalStateRepository.GetAllLocationFederalStates();

            cboCompanyState.DataSource = states;
            cboCompanyState.DataBind();

        }

        protected void EnablesControl()
        {
            btnDeleteCompany.Enabled = true;

        }

        protected void DeleteVisitorCompany(int cid)
        {
            var visitorCompId = new VisitorCompanyRepository().GetVisitorCompanyById(cid);

            if (visitorCompId != null)
            {
                new VisitorCompanyRepository().DeleteVisitorCompany(visitorCompId);
            }
            //LoadVisitorCompanyByID(Convert.ToInt32(cboCustomerNr2.Value));
            //LoadVisitorCompanyDetails();
        }

        public class InsertEditCompamy
        {
            public int editMode { get; set; }
            public long visitorCompId { get; set; }
        }

        [WebMethod]
        [ScriptMethod()]
        public static InsertEditCompamy SaveVisitorCompanyDetails(long companyId, string CompanyName, string CompanyNr, string CompanyMemo,
       string CompanyEmail, string CompanyPersName, string CompanyZipCode, string CompanyStreet, string CompanyTel,
       string CompanyMob, string CompanyHouseNr, string CompanyFunct, string CompanyPlace, long CompanyState)
        {
            int _editMode = 0;
            long _visitorCompId = 0;

            try
            {
                VisitorCompanyRepository _VisitorRepository = new VisitorCompanyRepository();
                VisitorCompanyTb _VisitorCompany = new VisitorCompanyTb();
                //var visitorCompList = _VisitorRepository.GetAllVisitorCompanies();
                var compNr = !string.IsNullOrEmpty(CompanyNr.ToString()) ? Convert.ToInt64(CompanyNr) : 0;
                //var vCExists = visitorCompList.Where(x => x.CompanyNr == Convert.ToInt64(compNr)).FirstOrDefault();
                var vCExists = _VisitorRepository.GetVisitorCompanyById(companyId);
                if (vCExists != null)
                {

                    vCExists.ID = vCExists.ID;
                    vCExists.CompanyNr = Convert.ToInt64(CompanyNr);
                    vCExists.CompanyName = CompanyName;
                    vCExists.ZipCode = CompanyZipCode;
                    vCExists.Telephone = CompanyTel;
                    vCExists.Mobile = CompanyMob;
                    vCExists.Email = CompanyEmail;
                    vCExists.Name = CompanyPersName;
                    vCExists.FederalState = Convert.ToInt64(CompanyState);
                    vCExists.Memo = CompanyMemo;
                    vCExists.Street = CompanyStreet;
                    vCExists.PersFunction = CompanyFunct;
                    vCExists.Place = CompanyPlace;
                    vCExists.HouseNr = CompanyHouseNr;


                    _VisitorRepository.EditVisitorCompany(vCExists);
                    _editMode = 2;
                    _visitorCompId = vCExists.ID;

                }
                else
                {
                    if (!string.IsNullOrEmpty(_visitorCompId.ToString()))
                    {
                        _VisitorCompany.ID = Convert.ToInt64(_visitorCompId);
                        _VisitorCompany.CompanyNr = Convert.ToInt64(CompanyNr);
                        _VisitorCompany.CompanyName = CompanyName;
                        _VisitorCompany.ZipCode = CompanyZipCode;
                        _VisitorCompany.Telephone = CompanyTel;
                        _VisitorCompany.Mobile = CompanyMob;
                        _VisitorCompany.Email = CompanyEmail;
                        _VisitorCompany.Name = CompanyPersName;
                        _VisitorCompany.FederalState = Convert.ToInt64(CompanyState);
                        _VisitorCompany.Memo = CompanyMemo;
                        _VisitorCompany.Street = CompanyStreet;
                        _VisitorCompany.PersFunction = CompanyFunct;
                        _VisitorCompany.Place = CompanyPlace;
                        _VisitorCompany.HouseNr = CompanyHouseNr;
                        _VisitorRepository.NewVisitorCompany(_VisitorCompany);
                        _editMode = 1;
                        _visitorCompId = _VisitorCompany.ID;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            InsertEditCompamy ied = new InsertEditCompamy()
            {
                editMode = _editMode,
                visitorCompId = _visitorCompId
            };
            return ied;
        }

        [WebMethod]
        public static long GetLastInsertedVisitorCompany()
        {
            VisitorCompanyRepository _VisitorCompanyRepository = new VisitorCompanyRepository();
            var _visCompany = _VisitorCompanyRepository.GetLastInserted();
            if (_visCompany == null) { return 1; }
            else { return _visCompany.CompanyNr + 1; }
        }

        [System.Web.Services.WebMethod]
        public static VisitorCompanyTb LoadCompanyDetails(long id)
        {
            var visitorComp = new VisitorCompanyRepository().GetVisitorCompanyById(Convert.ToInt64(id));
            VisitorCompanyTb _VisitorCompanyTb = new VisitorCompanyTb()
            {
                ID = visitorComp.ID,
                CompanyNr = visitorComp.CompanyNr,
                CompanyName = visitorComp.CompanyName,
                Memo = visitorComp.Memo,
                Email = visitorComp.Email,
                Name = visitorComp.Name,
                ZipCode = visitorComp.ZipCode,
                Street = visitorComp.Street,
                Telephone = visitorComp.Telephone,
                Mobile = visitorComp.Mobile,
                HouseNr = visitorComp.HouseNr,
                PersFunction = visitorComp.PersFunction,
                Place = visitorComp.Place,
                FederalState = visitorComp.FederalState,
            };
            return _VisitorCompanyTb;

        }


        protected void btnDeleteCompany_Click(object sender, EventArgs e)
        {
            DeleteVisitorCompany(Convert.ToInt32(txtCompanyNr.Text));
        }
        protected void grdVisitorCompany_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            grdVisitorCompany.Selection.UnselectAll();
            var company = new VisitorCompanyRepository().GetAllVisitorCompanies();
            grdVisitorCompany.DataSource = company;
            grdVisitorCompany.DataBind();
            if (company.Count() > 0)
            {
                grdVisitorCompany.FocusedRowIndex = 0;
            }
            if (company.Count() > 31)
            {
                //grdVisitorCompany.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdVisitorCompany.Settings.VerticalScrollableHeight = 729;
                grdVisitorCompany.SettingsPager.PageSize = company.Count();
            }
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var index = grdVisitorCompany.FindVisibleIndexByKeyValue(e.Parameters);
                if (index >= 0)
                {
                    grdVisitorCompany.FocusedRowIndex = index;
                }
            }
        }
        protected void BindCompanyGrid()
        {
            var company = new VisitorCompanyRepository().GetAllVisitorCompanies();
            grdVisitorCompany.DataSource = company;
            grdVisitorCompany.DataBind();
            cboVisitorCompany.DataSource = company;
            cboVisitorCompany.DataBind();
            cboVisitorCompany.SelectedIndex = 0;
            cboVisitorPostalCode.DataSource = company;
            cboVisitorPostalCode.DataBind();
            cboVisitorPostalCode.SelectedIndex = 0;
            cboVisitorLocation.DataSource = company;
            cboVisitorLocation.DataBind();
            cboVisitorLocation.SelectedIndex = 0;
            cobVisitorCompanyNr.DataSource = company;
            cobVisitorCompanyNr.DataBind();
            cobVisitorCompanyNr.SelectedIndex = 0;
            if (company.Count() > 31)
            {
                //grdVisitorCompany.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //grdVisitorCompany.Settings.VerticalScrollableHeight = 729;
                grdVisitorCompany.SettingsPager.PageSize = company.Count();
            }
        }

        protected void cboVisitorCompany_Callback(object sender, CallbackEventArgsBase e)
        {
            var company = new VisitorCompanyRepository().GetAllVisitorCompanies();
            cboVisitorCompany.DataSource = company;
            cboVisitorCompany.DataBind();
            cboVisitorCompany.SelectedIndex = 0;
        }

        protected void cboVisitorPostalCode_Callback(object sender, CallbackEventArgsBase e)
        {
            var company = new VisitorCompanyRepository().GetAllVisitorCompanies();
            cboVisitorPostalCode.DataSource = company;
            cboVisitorPostalCode.DataBind();
            cboVisitorPostalCode.SelectedIndex = 0;
        }

        protected void cboVisitorLocation_Callback(object sender, CallbackEventArgsBase e)
        {
            var company = new VisitorCompanyRepository().GetAllVisitorCompanies();
            cboVisitorLocation.DataSource = company;
            cboVisitorLocation.DataBind();
            cboVisitorLocation.SelectedIndex = 0;
        }

        [WebMethod]
        public static bool CheckIfVisitorCompanyNrExists(long companyNr)
        {
            bool exists = false;
            var visitorComp = new VisitorCompanyRepository().GetVisitorCompanyByNr(Convert.ToInt32(companyNr));
            if (visitorComp != null)
            {
                exists = true;
            }
            return exists;
        }

        [WebMethod]
        public static bool CheckvisitorCompanyId(long id)
        {
            bool exists = false;
            var visitorComp = new VisitorCompanyRepository().GetVisitorCompanyById(Convert.ToInt32(id));
            if (visitorComp != null)
            {
                exists = true;
            }
            return exists;
        }
        [WebMethod]
        public static VisitorsDto ApplyDates(string startDate, string endDate)
        {
            DateTime _startDate = Convert.ToDateTime(startDate);
            DateTime _endDate = Convert.ToDateTime(endDate);
            VisitorsDto visitDto = new VisitorsDto();
            visitDto.vStartDate = new DateTime(_startDate.Year, _startDate.Month, _startDate.Day, 00, 00, 00);
            visitDto.vEndDate = new DateTime(_endDate.Year, _endDate.Month, _endDate.Day, 00, 00, 00);
            visitDto.vStartDateTime = new DateTime(_startDate.Year, _startDate.Month, _startDate.Day, 00, 00, 00);
            visitDto.vEndDateTime = new DateTime(_endDate.Year, _endDate.Month, _endDate.Day, 23, 59, 59);
            return visitDto;
        }

        protected void cboClientName_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void cboClentZipCode_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void cboClientPlace_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        public static void DeleteVehicleDetails(string VehicleName, string vehicleModel)
        {

            VehicleTypeRepository _VehicleTypeRepository = new VehicleTypeRepository();
            var Vehicletype = _VehicleTypeRepository.GetVehicleType().Where(x => x.Name == VehicleName && x.Type == vehicleModel).FirstOrDefault();
            if (Vehicletype != null)
            {
                _VehicleTypeRepository.DeleteVehicleType(Vehicletype);
            }
        }
        [WebMethod]
        public static void DeleteVehicleTypes(string vType)
        {

            VehicleTypeRepository _VehicleTypeRepository = new VehicleTypeRepository();
            var VehicletypeList = _VehicleTypeRepository.GetVehiclesByType(vType);
            if (VehicletypeList.Count > 0)
            {
                foreach (var _VehicleType in VehicletypeList)
                    _VehicleTypeRepository.DeleteVehicleType(_VehicleType);
            }
        }

        protected void cboCarTypes_Callback(object sender, CallbackEventArgsBase e)
        {

        }

        [WebMethod]
        public static VisitorCompanyDto GetCompanyDetailsByNr(int Nr)
        {
            var company = new VisitorCompanyRepository().GetVisitorCompanyByNr(Nr);
            VisitorCompanyDto compDto = new VisitorCompanyDto();
            if (company != null)
            {
                compDto.VisitorCompanyId = company.ID.ToString();
                compDto.Street = company.Street;
                compDto.ZipCode = company.ZipCode;
                compDto.Place = company.Place;
                compDto.StreetNr = company.HouseNr;
                compDto.Company = string.Format("{1}", company.ID, company.CompanyName);
            }
            return compDto;
        }
        protected void BindVehicleManufacturer()
        {
            List<VehicleType> vTypesList = new List<VehicleType>();
            vTypesList.AddRange(new VehicleTypeRepository().GetVehicleType());
            var vehiclesTypes = vTypesList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).ToList();
            cboVehicleTypes.DataSource = vehiclesTypes;
            cboVehicleTypes.DataBind();
            cboVehicleTypes.SelectedIndex = 0;
            grdManufacturer.DataSource = vehiclesTypes;
            grdManufacturer.DataBind();
            grdManufacturer.FocusedRowIndex = 0;
            if (vehiclesTypes.Count > 0)
            {
                BindGridVehicleModel(cboVehicleTypes.Text);
                lblVehicleManu.Text = cboVehicleTypes.Text;
            }
        }
        protected void BindGridVehicleModel(string maufacturer)
        {
            if (!string.IsNullOrEmpty(maufacturer))
            {
                var vTypesList = new VehicleTypeRepository().GetVehicleType();
                var vehicleModels = vTypesList.Where(m => m.Name == maufacturer && (m.Type ?? "").Trim() != "");
                grdVehicleModel.DataSource = vehicleModels;
                grdVehicleModel.DataBind();
                grdVehicleModel.FocusedRowIndex = -1;
            }

        }
        [WebMethod]
        public static string SaveManufacturer(long id, string name, string holder)
        {
            string _name = string.Empty;
            if (id == 0)
            {
                VehicleType type = new VehicleType()
                {
                    Name = name
                };
                new VehicleTypeRepository().NewVehicleType(type);
                _name = type.Name;
            }
            else if (id > 0)
            {
                var manu = new VehicleTypeRepository().GetVehicleTypeById(id);
                if (manu != null)
                {
                    var _VehiclesManu = new VehicleTypeRepository().getVehicleTypeByNames(manu.Name);
                    foreach (var vehicle in _VehiclesManu)
                    {
                        VehicleType type = new VehicleType()
                        {
                            ID = vehicle.ID,
                            Name = name,
                            Type = vehicle.Type
                        };
                        new VehicleTypeRepository().EditvehicleType(type);
                    }
                    _name = name;
                }
                else
                {
                    _name = holder;
                }

            }
            return _name;
        }
        [WebMethod]
        public static long SaveVehicleModel(long id, string manufacturer, string model)
        {
            long num = 0;
            if (id == 0)
            {
                VehicleType type = new VehicleType()
                {
                    Name = manufacturer,
                    Type = model
                };
                new VehicleTypeRepository().NewVehicleType(type);
                num = type.ID;
            }
            else
            {
                VehicleType type = new VehicleType()
                {
                    ID = id,
                    Name = manufacturer,
                    Type = model
                };
                new VehicleTypeRepository().EditvehicleType(type);
                num = type.ID;
            }
            return num;
        }
        [WebMethod]
        public static void DeleteManufacturer(string name)
        {
            var _VehiclesManu = new VehicleTypeRepository().getVehicleTypeByNames(name);
            foreach (var vehicle in _VehiclesManu)
            {

                new VehicleTypeRepository().DeleteVehicleType(vehicle);
            }
        }
        [WebMethod]
        public static void DeleteModel(long Id)
        {
            var _VehicleModel = new VehicleTypeRepository().GetVehicleTypeById(Id);
            if (_VehicleModel != null)
            {
                //new VehicleTypeRepository().DeleteVehicleType(_VehicleModel);
                VehicleType type = new VehicleType()
                {
                    ID = _VehicleModel.ID,
                    Name = _VehicleModel.Name,
                    Type = null
                };
                new VehicleTypeRepository().EditvehicleType(type);
            }

        }

        protected void grdVehicleModel_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var maufacturer = e.Parameters;
            if (!string.IsNullOrEmpty(maufacturer))
            {
                var vTypesList = new VehicleTypeRepository().GetVehicleType();
                var vehicleModels = vTypesList.Where(m => m.Name == maufacturer && (m.Type ?? "").Trim() != "");
                grdVehicleModel.DataSource = vehicleModels;
                grdVehicleModel.DataBind();
                grdVehicleModel.FocusedRowIndex = -1;
            }
        }

        protected void grdManufacturer_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                List<VehicleType> vTypesList = new List<VehicleType>();
                vTypesList.AddRange(new VehicleTypeRepository().GetVehicleType());
                var vehiclesTypes = vTypesList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).ToList();
                grdManufacturer.DataSource = vehiclesTypes;
                grdManufacturer.DataBind();
                grdManufacturer.FocusedRowIndex = Convert.ToInt32(e.Parameters);
            }
        }

        protected void cboVehicleTypes_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                List<VehicleType> vTypesList = new List<VehicleType>();
                vTypesList.AddRange(new VehicleTypeRepository().GetVehicleType());
                var vehiclesTypes = vTypesList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).ToList();
                cboVehicleTypes.DataSource = vehiclesTypes;
                cboVehicleTypes.DataBind();
                var currentType = vehiclesTypes.Find(x => x.Name == e.Parameter);
                if (currentType != null)
                {
                    cboVehicleTypes.Value = currentType.ID.ToString();
                }
            }
            else
            {
                BindVehicleManufacturer();
            }
        }
        [WebMethod]
        public static void DeleteCard(long id, long visitorId)
        {
            var visitorCard = new VisitorTranspondersRepository().GetTransponderById(id);

            if (visitorCard != null)
            {
                var cardList = new VisitorTranspondersRepository().GetVisitorTransponders(visitorId, visitorCard.TransponderNr);
                foreach (var card in cardList)
                {
                    new VisitorTranspondersRepository().DeleteVisitorTransponder(card);
                }

            }

        }

        [WebMethod]
        public static void DeleteVisitor(long Id)
        {
            var visitor = new VisitorRepository().GetVisitorById(Id);
            if (visitor != null)
            {
                new VisitorRepository().DeleteVisitor(visitor);
            }
        }


        void DisableVisitorCompanyControlsOnLoad()
        {
            txtCompanyNr.Enabled = false;
            txtCompanyZipCode.Enabled = false;
            txtCompanyStreet.Enabled = false;

            cboCompanyState.ClientEnabled = false;

            txtCompanyPersName.Enabled = false;
            txtCompanyFunct.Enabled = false;
            txtCompanyTel.Enabled = false;
            txtCompanyMob.Enabled = false;
            txtCompanyEmail.Enabled = false;


            txtCompanyName.Enabled = false;
            txtCompanyPlace.Enabled = false;
            txtCompanyHouseNr.Enabled = false;
            txtCompanyMemo.Enabled = false;
        }
        protected void BindExistingCompanies()
        {
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            VisitorCompanyTb visitorCom = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "keine"
            };
            List<VisitorCompanyTb> companyList = new List<VisitorCompanyTb>();
            companyList.Add(visitorCom);
            companyList.AddRange(companies);
            companyList = companyList.OrderBy(x => x.CompanyNr).ToList();
            cobCompanyNr.DataSource = companyList;
            cobCompanyNr.DataBind();
            cobCompanyNr.SelectedIndex = 0;
            cobCompanyName.DataSource = companyList;
            cobCompanyName.DataBind();
            cobCompanyName.SelectedIndex = 0;
        }

        protected void cobCompanyNr_Callback(object sender, CallbackEventArgsBase e)
        {
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            VisitorCompanyTb visitorCom = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "keine"
            };
            List<VisitorCompanyTb> companyList = new List<VisitorCompanyTb>();
            companyList.Add(visitorCom);
            companyList.AddRange(companies);
            companyList = companyList.OrderBy(x => x.CompanyNr).ToList();
            cobCompanyNr.DataSource = companyList;
            cobCompanyNr.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cobCompanyNr.Value = e.Parameter.ToString();
            }


        }

        protected void cobCompanyName_Callback(object sender, CallbackEventArgsBase e)
        {
            var companies = new VisitorCompanyRepository().GetAllVisitorCompanies();
            VisitorCompanyTb visitorCom = new VisitorCompanyTb()
            {
                ID = 0,
                CompanyNr = 0,
                CompanyName = "keine"
            };
            List<VisitorCompanyTb> companyList = new List<VisitorCompanyTb>();
            companyList.Add(visitorCom);
            companyList.AddRange(companies);
            companyList = companyList.OrderBy(x => x.CompanyNr).ToList();
            cobCompanyName.DataSource = companyList;
            cobCompanyName.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                cobCompanyName.Value = e.Parameter.ToString();
            }
        }
        [WebMethod]
        public static VisitorCompanyTb GetCompanyByID(long Id)
        {
            VisitorCompanyTb comp = new VisitorCompanyTb();
            var company = new VisitorCompanyRepository().GetVisitorCompanyById(Id);
            if (company != null)
            {
                comp.ID = company.ID;
                comp.CompanyNr = company.CompanyNr;
                comp.CompanyName = company.CompanyName;
                comp.ZipCode = company.ZipCode;
                comp.HouseNr = company.HouseNr;
                comp.Place = company.Place;
                comp.Street = company.Street;
                comp.FederalState = company.FederalState;
                comp.Name = company.Name;
                comp.Telephone = company.Telephone;
                comp.Mobile = company.Mobile;
                comp.Email = company.Email;
                comp.Memo = company.Memo;
                comp.PersFunction = company.PersFunction;
                comp.StreetNumber = company.StreetNumber;
            }
            return comp;
        }

        protected void cobVisitorCompanyNr_Callback(object sender, CallbackEventArgsBase e)
        {
            var company = new VisitorCompanyRepository().GetAllVisitorCompanies();
            cobVisitorCompanyNr.DataSource = company;
            cobVisitorCompanyNr.DataBind();
            cobVisitorCompanyNr.SelectedIndex = 0;
        }

        protected VisitorsDto ConvertVisitorToDto(Visitor visitor)
        {
            var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(visitor.ID);
            VisitorsDto visitDto = new VisitorsDto()
            {
                ID = visitor.ID,
                VisitorID = visitor.VisitorID,
                SurName = visitor.SurName,
                OtherName = visitor.Fullname,
                VisitorName = string.Format("{0} {1}", visitor.Fullname, visitor.SurName),
                Street = string.Format("{0} {1}", visitor.Street, visitor.StreetNr),
                Company = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "",
                CompanyNr = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyNr.ToString() : "",
                CompanyLocation = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "",
                CompanyPostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "",
                CompanyStreet = visitor.Company != null ? visitor.VisitorCompanyTb.Street : "",
                CompanyStreetNr = visitor.Company != null ? visitor.VisitorCompanyTb.HouseNr : "",
                PostalCode = visitor.PostalCode,
                Location = visitor.Location,
                Telephone = visitor.Telephone,
                Mobile = visitor.Mobile,
                Email = visitor.Email,
                vStartDate = accessTime.StartDate,
                vEndDate = accessTime.EndDate

            };
            return visitDto;
        }

        public List<VisitorsDto> ConverVisitorsToDtos(List<KruAll.Core.Models.Visitor> _visitorslist)
        {
            List<VisitorsDto> _Visitors = new List<VisitorsDto>();

            foreach (KruAll.Core.Models.Visitor _Visitor in _visitorslist)
            {
                VisitorsDto _dto = ConvertVisitorToDto(_Visitor);
                _Visitors.Add(_dto);
            }
            return _Visitors;
        }


        protected void cboVisitorNameSearch_OnItemsRequestedByFilterCondition(object sender, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            if (VisitorsList.Count == 0) VisitorsList = new VisitorViewModels().GetVisitorData().ToList();
            ASPxComboBox _cboPersOnNameSearch = (ASPxComboBox)sender;
            List<VisitorsDto> _MemberList = new List<VisitorsDto>();

            if (!String.IsNullOrEmpty(e.Filter))
            {
                List<VisitorsDto> _MemberListFirstName = VisitorsList.Where(x => (x.VisitorName ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<VisitorsDto>();
                List<VisitorsDto> _MemberListSurname = VisitorsList.Where(x => (x.ID.ToString() ?? "").ToLower().Contains((e.Filter ?? "").ToLower())).ToList() ?? new List<VisitorsDto>();

                List<VisitorsDto> _MemberListFilter = new List<VisitorsDto>();
                _MemberListFilter.AddRange(_MemberListFirstName);
                _MemberListFilter.AddRange(_MemberListSurname);
                _MemberList.AddRange(_MemberListFilter.Distinct().ToList());
            }
            else
            {
                _MemberList.AddRange(VisitorsList);
            }

            _cboPersOnNameSearch.DataSource = _MemberList;
            _cboPersOnNameSearch.DataBind();
        }
        protected void cboVisitorNameSearch_OnItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            Visitor member = new VisitorRepository().GetVisitorById(value);
            List<VisitorsDto> memberList = new List<VisitorsDto>();

            if (member != null)
            {
                memberList.Add(ConvertVisitorToDto(member));
                comboBox.DataSource = memberList;
                comboBox.DataBind();
            }
        }
        [WebMethod]
        public static bool CheckIfVisitorNrExistsOnEdit(long visitorId, long currentId)
        {
            var exists = false;
            var visitor = new VisitorRepository().GetVisitorByVisitorId(visitorId);
            if (visitor != null)
            {
                if (visitor.ID != currentId)
                {
                    exists = true;
                }
            }

            return exists;
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string ConvertImageBytesToURL(string imageBytes, string strId, string names)
        {
            string photoImageFile = string.Empty;
            long id;
            long.TryParse(strId, out id);
            string firstName = string.Empty;

            var visitor = VisitorsList.FirstOrDefault(p => p.ID == id);

            if (visitor != null)
            {
                firstName = visitor.Name;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(names))
                {
                    var values = names.Split(' ');
                    if (values.Length == 2)
                    {
                        firstName = values[0];
                    }
                }
            }

            if (imageBytes.Length > 0)// get from binary
            {
                photoImageFile = FileProcessor.SaveVisitorImageFile("," + imageBytes, firstName + strId + DateTime.Now.ToString("yyyyMMddHHmmss"));
                photoImageFile = FileProcessor.GetVisitorImageRelativeFilePath(photoImageFile);
            }

            return photoImageFile;
        }

    }
}