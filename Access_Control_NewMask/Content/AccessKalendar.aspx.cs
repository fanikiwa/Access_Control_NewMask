using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using DevExpress.Web;
using Access_Control_NewMask.ViewModels;
using KruAll.Core.Repositories;
using System.Web.Services;
using System.Globalization;
using Access_Control_NewMask.Dtos;
using Color = System.Drawing.Color;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Access_Control_NewMask.Content
{
    public partial class AccessKalendar : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        enum FormMode
        {
            None,
            Display,
            Create,
            Edit
        }
        static List<AccessCalendar> listAccessCalendar;
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsAccessCalender_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsAccessCalender_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsAccessCalender, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false; btnNewAccessProfile.Enabled = false;
                btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            Session["AccessPlan"] = null;
            Session["CalendarType"] = "Template";

            if (Session["AccessPlanFormMode"] != null)
            {
                var formMode = Session["AccessPlanFormMode"].ToString();
                hiddenFieldFormMode.Value = formMode;
            }

            BindControls();

            if (!IsPostBack)
            {
                hiddenFieldSaveChanges.Value = "0";
                DisplayAccessCalendar();

                for (var calendarYear = DateTime.Now.Year - 5; calendarYear < DateTime.Now.Year + 5; calendarYear++)
                {
                    ddlCalendarYear.Items.Add(new ListItem(calendarYear.ToString(), calendarYear.ToString()));
                    ddlCalendarYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));

                    ddlTariffYear.Items.Add(new ListItem(calendarYear.ToString(), calendarYear.ToString()));
                    ddlTariffYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));
                    ddlTariffYear2.ClientEnabled = false;
                    ddlCalendarYear2.ClientEnabled = false;
                }

                ddlCalendarYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlCalendarYear2.Value = DateTime.Now.Year.ToString();

                ddlTariffYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlTariffYear2.Value = DateTime.Now.Year.ToString();
            }
        }
        public void BindControls()
        {
            listAccessCalendar = new List<AccessCalendar>();
            if (listAccessCalendar.Count == 0)
            {
                listAccessCalendar.Add(new AccessCalendar() { ID = 0, Calendar_Nr = 0, Calendar_Name = "keine", CalendarDate = DateTime.Now });
            }

            LoadExistingAccessCalendar(ref listAccessCalendar);
            dplCalendarNr.DataSource = listAccessCalendar.OrderBy(x => x.Calendar_Nr);
            dplCalendarNr.DataBind();
            dplCalendarName.DataSource = listAccessCalendar.OrderBy(x => x.Calendar_Nr);
            dplCalendarName.DataBind();
            grdHolidayCalndr.DataSource = listAccessCalendar.OrderBy(x => x.Calendar_Nr);
            grdHolidayCalndr.DataBind();
            var accessCalendars = new AccessCalendarViewModel().BindAccessCalenderRawData();
            grdHolidayCalndr.DataSource = accessCalendars;
            grdHolidayCalndr.DataBind();

            int formMode = 0;
            if (!(string.IsNullOrEmpty(hiddenFieldFormMode.Value)))
            {
                formMode = Convert.ToInt32(hiddenFieldFormMode.Value);
            }

            if (formMode == (int)FormMode.Create)
            {
                LoadAccessCalendar(0);
            }
            else
            {
                if (Session["AccessCalendar"] != null)
                {
                    var accessCalendar = (AccessCalendar)Session["AccessCalendar"];
                    LoadAccessCalendar((int)accessCalendar.ID);
                }
                else
                {
                    LoadAccessCalendar(0);
                }
            }

            var listAccessProfiles = new List<ZuttritProfile>();
            if (listAccessProfiles.Count == 0)
            {
                listAccessProfiles.Add(new ZuttritProfile()
                {
                    ID = 0,
                    AccessDescription = "keine",
                    AccessProfileID = "keine",
                    AccessGroup = new AccessGroup { AccessGroupName = "keine", AccessGroupNumber = 0 }
                });
                //listAccessProfiles.Add(new ZuttritProfile() { ID = 0, AccessDescription = "keine" });
            }

            LoadExistingAccessProfiles(ref listAccessProfiles);

            ddlProfileId.DataSource = listAccessProfiles;
            ddlProfileId.DataBind();
            if (ddlProfileId.Items.FindByValue("0") != null) ddlProfileId.Value = "0";

            dplAccessProfileMemo.DataSource = listAccessProfiles;
            dplAccessProfileMemo.DataBind();

            dplAccessProfileNr.DataSource = listAccessProfiles;
            dplAccessProfileNr.DataBind();
            if (dplAccessProfileNr.Items.FindByValue("0") != null) dplAccessProfileNr.Value = "0";


            dplAccessProfileName.DataSource = listAccessProfiles;
            dplAccessProfileName.DataBind();

            if (dplAccessProfileName.Items.FindByValue("0") != null) dplAccessProfileName.Value = "0";

            listAccessProfiles = new List<ZuttritProfile>();
            LoadExistingAccessProfiles(ref listAccessProfiles);

            gridViewAccessProfileSearch.DataSource = listAccessProfiles;
            gridViewAccessProfileSearch.DataBind();

            if (listAccessProfiles.Count <= 18)
            {
                //gridViewAccessProfileSearch.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
            }
            else
            {
                //gridViewAccessProfileSearch.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowAllRecords;
            }

            Session["ZuttritProfiles"] = listAccessProfiles;

            if (Session["AccessProfile"] != null)
            {
                var accessProfile = (ZuttritProfile)Session["AccessProfile"];

                ddlProfileId.Value = accessProfile.ID.ToString();
                dplAccessProfileNr.Value = accessProfile.ID.ToString();
                dplAccessProfileName.Value = accessProfile.ID.ToString();
            }

            Session["AccessProfile"] = null;
        }

        void DisplayAccessCalendar()
        {
            var accessCalendar = (AccessCalendar)HttpContext.Current.Session["AccessCalendar"];
            if (accessCalendar == null) return;

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            //hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();

            dplCalendarNr.Value = accessCalendar.ID.ToString();
            dplCalendarName.Value = accessCalendar.ID.ToString();
            ddlCalendarYear.SelectedValue = accessCalendar.CalendarDate.Year.ToString();
            ddlCalendarYear2.Value = accessCalendar.CalendarDate.Year.ToString();

            txtCalendarNr.Text = accessCalendar.Calendar_Nr.ToString();
            txtCalendarName.Text = accessCalendar.Calendar_Name;
            txtMemo.Text = accessCalendar.Memo;

            var accessCalendarScheduleViewModel = new AccessCalendarViewModel().GetAccessCalendarSchedule(accessCalendar);

            grdAccessCalendar.DataSource = accessCalendarScheduleViewModel;
            grdAccessCalendar.DataBind();

            btnCancelDel.Enabled = true;
        }

        public void LoadExistingAccessCalendar(ref List<AccessCalendar> listAccessCalendar)
        {
            AccessCalendarViewModel accessPlanViewModel = new AccessCalendarViewModel();
            listAccessCalendar.AddRange(accessPlanViewModel.AccessCalendars());
        }
        public void LoadExistingAccessProfiles(ref List<ZuttritProfile> listAccessProfiles)
        {

            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            listAccessProfiles.AddRange(zuttritProfileViewModel.ZuttritProfiles());
        }

        static List<AccessCalendarMonth> GetAccessCalendarMonths(List<AccessCalendarScheduleViewModel> accessCalendarSchedules)
        {
            var accessCalendarMonths = new List<AccessCalendarMonth>();
            foreach (var accessCalendarSchedule in accessCalendarSchedules)
            {
                var accessCalendarMonth = new AccessCalendarMonth
                {
                    AccessCalendarMonthNr = accessCalendarSchedule.AccessCalendarMonthNr
                };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var numberProperty = string.Format("Day{0}AccessProfile", dayOfMonth);
                    var numberPropertyInfo = accessCalendarSchedule.GetType().GetProperty(numberProperty);

                    var accessProfile = new ZuttritProfileViewModel().GetZuttritProfileByAccessProfileId(numberPropertyInfo.GetValue(accessCalendarSchedule).ToString());

                    var idProperty = string.Format("Day{0}AccessProfileID", dayOfMonth);
                    var idPropertyInfo = accessCalendarMonth.GetType().GetProperty(idProperty);

                    if (accessProfile != null)
                    {
                        idPropertyInfo.SetValue(accessCalendarMonth, Convert.ChangeType(accessProfile.ID, idPropertyInfo.PropertyType), null);
                    }
                    else
                    {
                        idPropertyInfo.SetValue(accessCalendarMonth, Convert.ChangeType(0, idPropertyInfo.PropertyType), null);
                    }
                }

                accessCalendarMonths.Add(accessCalendarMonth);
            }

            return accessCalendarMonths;
        }

        [WebMethod]
        public static AccessCalendar CreateAccessCalendar(int calenderNr, string calenderName, string memo, int accessProfileID, bool checkMon, bool checkTue, bool checkWed, bool checkThur, bool checkFri, bool checkSat, bool checkSun, string strCalendarMonth)
        {
            var accessCalendarSchedules = JsonConvert.DeserializeObject<List<AccessCalendarScheduleViewModel>>(strCalendarMonth);
            var accessCalendarMonths = GetAccessCalendarMonths(accessCalendarSchedules);

            AccessCalendarViewModel accessPlanViewModel = new AccessCalendarViewModel();
            AccessCalendar accessCalendar = new AccessCalendar() { Calendar_Nr = calenderNr, Calendar_Name = calenderName, Memo = memo, AccessProfileID = accessProfileID, CheckMon = checkMon, CheckTue = checkTue, CheckWed = checkWed, CheckThur = checkThur, CheckFri = checkFri, CheckSat = checkSat, CheckSun = checkSun, CalendarDate = DateTime.Now, AccessCalendarMonths = accessCalendarMonths };
            accessPlanViewModel.CreateAccessCalendar(accessCalendar);
            accessCalendar = accessPlanViewModel.GetAccessCalendarByNr(calenderNr);

            listAccessCalendar.Add(accessCalendar);

            AccessCalendar accessCalendar2 = new AccessCalendar();
            accessCalendar2.ID = accessCalendar.ID;
            accessCalendar2.Calendar_Nr = calenderNr;
            accessCalendar2.Calendar_Name = calenderName;
            accessCalendar2.Memo = memo;
            accessCalendar2.CheckMon = checkMon;
            accessCalendar2.CheckTue = checkTue;
            accessCalendar2.CheckWed = checkWed;
            accessCalendar2.CheckThur = checkThur;
            accessCalendar2.CheckFri = checkFri;
            accessCalendar2.CheckSat = checkSat;
            accessCalendar2.CheckSun = checkSun;
            accessCalendar2.AccessProfileID = accessProfileID;
            accessCalendar2.CalendarDate = accessCalendar.CalendarDate;

            return accessCalendar2;
        }

        [WebMethod]
        public static AccessCalendar GetAccessCalendar(long Id)
        {
            AccessCalendarViewModel buildPlanViewModel = new AccessCalendarViewModel();
            AccessCalendar accessCalendar = new AccessCalendar();
            accessCalendar.ID = listAccessCalendar.Find(kal => kal.ID == Id).ID;
            accessCalendar.Calendar_Nr = listAccessCalendar.Find(kal => kal.ID == Id).Calendar_Nr;
            accessCalendar.Calendar_Name = listAccessCalendar.Find(kal => kal.ID == Id).Calendar_Name;
            accessCalendar.Memo = listAccessCalendar.Find(kal => kal.ID == Id).Memo;
            //accessCalendar.CheckMon = listAccessCalendar.Find(kal => kal.ID == Id).CheckMon;
            //accessCalendar.CheckTue = listAccessCalendar.Find(kal => kal.ID == Id).CheckTue;
            //accessCalendar.CheckWed = listAccessCalendar.Find(kal => kal.ID == Id).CheckWed;
            //accessCalendar.CheckThur = listAccessCalendar.Find(kal => kal.ID == Id).CheckThur;
            //accessCalendar.CheckFri = listAccessCalendar.Find(kal => kal.ID == Id).CheckFri;
            //accessCalendar.CheckSat = listAccessCalendar.Find(kal => kal.ID == Id).CheckSat;
            //accessCalendar.CheckSun = listAccessCalendar.Find(kal => kal.ID == Id).CheckSun;
            accessCalendar.AccessProfileID = listAccessCalendar.Find(kal => kal.ID == Id).AccessProfileID;
            accessCalendar.CalendarDate = listAccessCalendar.Find(kal => kal.ID == Id).CalendarDate;
            return accessCalendar;
        }

        [WebMethod]
        public static AccessCalendar DeleteAccessCalendar(int ID)
        {
            AccessCalendarViewModel accessPlanViewModel = new AccessCalendarViewModel();
            AccessCalendar accessCalendar = new AccessCalendar() { ID = ID };
            new AccessCalendarViewModel().DeleteAccessCalendarMonths(accessCalendar);
            accessPlanViewModel.DeleteAccessCalendar(accessCalendar);
            accessCalendar.ID = 0;
            listAccessCalendar.RemoveAll(kal => kal.ID == ID);
            return accessCalendar;
        }

        [WebMethod]
        public static AccessCalendar UpdateAccessCalendar(int Id, int calenderNr, string calenderName, string memo, int accessProfileID, bool checkMon, bool checkTue, bool checkWed, bool checkThur, bool checkFri, bool checkSat, bool checkSun, string strCalendarMonth)
        {
            AccessCalendarViewModel accessPlanViewModel = new AccessCalendarViewModel();

            AccessCalendar accessCalendar = new AccessCalendar();
            accessCalendar = listAccessCalendar.Find(kal => kal.ID == Id);

            var accessCalendarSchedules = JsonConvert.DeserializeObject<List<AccessCalendarScheduleViewModel>>(strCalendarMonth);
            var accessCalendarMonths = GetAccessCalendarMonths(accessCalendarSchedules);

            AccessCalendar accessCalendar2 = new AccessCalendar() { ID = Id, Calendar_Nr = calenderNr, Calendar_Name = calenderName, Memo = memo, CalendarDate = DateTime.Now, AccessProfileID = accessProfileID, CheckMon = checkMon, CheckTue = checkTue, CheckWed = checkWed, CheckThur = checkThur, CheckFri = checkFri, CheckSat = checkSat, CheckSun = checkSun, AccessCalendarMonths = null };
            accessPlanViewModel.UpdateAccessCalendar(accessCalendar2);
            accessCalendar2.AccessCalendarMonths = accessCalendarMonths;
            new AccessCalendarViewModel().DeleteAccessCalendarMonths(accessCalendar);
            new AccessCalendarViewModel().CreateAccessCalendarMonths(accessCalendar2);

            listAccessCalendar.RemoveAll(x => x.ID == Id);
            listAccessCalendar.Add(accessCalendar2);
            AccessCalendar accessCalendar3 = new AccessCalendar();
            accessCalendar3.ID = accessCalendar2.ID;
            accessCalendar3.Calendar_Nr = accessCalendar2.Calendar_Nr;
            accessCalendar3.Calendar_Name = accessCalendar2.Calendar_Name;
            accessCalendar3.Memo = memo;
            accessCalendar3.CheckMon = accessCalendar2.CheckMon;
            accessCalendar3.CheckTue = accessCalendar2.CheckTue;
            accessCalendar3.CheckWed = accessCalendar2.CheckWed;
            accessCalendar3.CheckThur = accessCalendar2.CheckThur;
            accessCalendar3.CheckFri = accessCalendar2.CheckFri;
            accessCalendar3.CheckSat = accessCalendar2.CheckSat;
            accessCalendar3.CheckSun = accessCalendar2.CheckSun;
            accessCalendar3.AccessProfileID = accessCalendar2.AccessProfileID;
            accessCalendar3.CalendarDate = accessCalendar2.CalendarDate;
            return accessCalendar3;
        }

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            //switch (formMode)
            //{
            //    case (int)FormMode.Display:
            //    case (int)FormMode.None:
            //        Session["AccessKalendar"] = null;
            //        var pageOrigin = Request.QueryString["pageOrigin"];
            //        if (!string.IsNullOrEmpty(pageOrigin))
            //        {
            //            var page_origin = Convert.ToInt32(pageOrigin);
            //            switch (page_origin)
            //            {
            //                case 1:
            //                    Response.Redirect("AccessPlanAccessCalender.aspx");
            //                    break;

            //                default:
            //                    Response.Redirect("/Content/Settings.aspx");
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            Response.Redirect("/Content/Settings.aspx");
            //        }
            //        break;

            //    case (int)FormMode.Create:
            //    case (int)FormMode.Edit:
            //        hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();

            //        DisplayAccessCalendar();

            //        break;
            //}
        }

        protected void btnNewAccessProfile_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            Session["AccessPlanFormMode"] = formMode;

            Session["AccessPlanAction"] = "New";

            var url = "AccessProfile.aspx?ent=2";
            Response.Redirect(url);
        }
        [WebMethod]
        public static string ReturnUrl(int formMode)
        {
            HttpContext.Current.Session["AccessPlanFormMode"] = formMode;


            HttpContext.Current.Session["AccessPlanAction"] = "New";

            var url = "AccessProfile.aspx?ent=2";
            return url;
        }
        protected void grdAccessCalendar_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {

            //if (Session["MapCalendar"] == null) return;


            if (e.DataColumn.FieldName.Substring(0, 3) != "Day")
            {
                e.Cell.Attributes.Add("CellType", "MonthName");
            }
            else
            {
                e.Cell.Attributes.Add("CellType", "Day");
            }

            e.Cell.Attributes.Add("ondblclick", string.Format("OnCellClick(this, {0});", e.VisibleIndex));
            e.Cell.Attributes.Add("onmousedown", string.Format("OnMouseDown(this, {0});", e.VisibleIndex));
            //e.Cell.Attributes.Add("onmouseup", "OnMouseUp(this);");
            e.Cell.Attributes.Add("onmouseup", string.Format("OnMouseUp(this, {0});", e.VisibleIndex));
            e.Cell.Attributes.Add("onmousemove", string.Format("OnMouseMove(this, {0});", e.VisibleIndex));

            if (e.DataColumn.FieldName.Length < 3) return;

            int selectedYear = DateTime.Now.Year;
            if (ddlCalendarYear2.SelectedItem != null)
                int.TryParse(ddlCalendarYear2.SelectedItem.Text, out selectedYear);
            var accessCalendar = listAccessCalendar.Find(kal => kal.ID.ToString() == dplCalendarNr.Value.ToString()); //(AccessCalendar)Session["MapCalendar"];

            if (e.DataColumn.FieldName.Substring(0, 3) != "Day") return;

            var daysDate = DateTime.MinValue; ;

            if (e.VisibleIndex > 12) return;

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            var calendarYear = formMode == (int)FormMode.Create || dplCalendarNr.Value.ToString() == "0" ? selectedYear : accessCalendar.CalendarDate.Year;

            var month = e.VisibleIndex + 1;
            var dayOfMonth = Convert.ToInt32(Regex.Match(e.DataColumn.FieldName, @"\d+").Value);

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    daysDate = new DateTime(calendarYear, month, dayOfMonth);

                    break;

                case 2:
                    if ((calendarYear % 4) == 0)
                    {
                        if (dayOfMonth <= 29)
                        {
                            daysDate = new DateTime(calendarYear, month, dayOfMonth);
                        }
                    }
                    else
                    {
                        if (dayOfMonth <= 28)
                        {
                            daysDate = new DateTime(calendarYear, month, dayOfMonth);
                        }
                    }

                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    if (dayOfMonth <= 30)
                    {
                        daysDate = new DateTime(calendarYear, month, dayOfMonth);
                    }

                    break;
            }

            switch (daysDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    e.Cell.BackColor = Color.Green;

                    if (e.CellValue.ToString() == string.Empty)
                    {
                        e.Cell.Text = daysDate.ToString("ddd");
                    }

                    break;
            }

            if (daysDate == DateTime.MinValue)
            {
                e.Cell.BackColor = Color.Black;
            }
            else
            {
                e.Cell.ToolTip = daysDate.ToString("ddd");
            }
        }

        public void LoadAccessCalendar(long calenderID)
        {
            List<AccessCalendarScheduleViewModel> lstaccessCalendarScheduleViewModel = new List<AccessCalendarScheduleViewModel>();
            AccessCalendar accessCalendar = new AccessCalendar();
            accessCalendar = listAccessCalendar.Find(kal => kal.ID == calenderID);

            if (calenderID > 0)
            {
                HttpContext.Current.Session["AccessCalendar"] = accessCalendar;
            }

            AccessCalendarViewModel accessCalendarViewModel = new AccessCalendarViewModel();
            int calendarYear = DateTime.Now.Year;

            if (ddlCalendarYear2.Value != null)
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }

            if (accessCalendar == null)
            {
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(calendarYear);

                grdAccessCalendar.DataSource = lstaccessCalendarScheduleViewModel;
                grdAccessCalendar.DataBind();

                return;
            }

            if (accessCalendar.Calendar_Nr == 0)
            {
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(calendarYear);
            }
            else
            {
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(accessCalendar);
                if (lstaccessCalendarScheduleViewModel.Count == 0)
                {
                    lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(accessCalendar.CalendarDate.Year);
                }
            }

            dplCalendarNr.Value = accessCalendar.ID.ToString();
            dplCalendarName.Value = accessCalendar.ID.ToString();

            if (!(string.IsNullOrEmpty(dplCalendarNr.Value.ToString())))
            {
                txtCalendarNr.Text = dplCalendarNr.SelectedItem.Text;
            }

            if (!(string.IsNullOrEmpty(dplCalendarName.Value.ToString())))
            {
                txtCalendarName.Text = dplCalendarName.SelectedItem.Text;
            }

            grdAccessCalendar.DataSource = lstaccessCalendarScheduleViewModel;
            grdAccessCalendar.DataBind();
            grdHolidayCalndr.FocusedRowIndex = dplCalendarNr.Value.ToString() != "0" ? dplCalendarNr.SelectedIndex - 1 : -1;
        }
        public void BindAccessCalendar(long calenderID)
        {
            List<AccessCalendarScheduleViewModel> lstaccessCalendarScheduleViewModel = new List<AccessCalendarScheduleViewModel>();
            AccessCalendar accessCalendar = new AccessCalendar();
            accessCalendar = listAccessCalendar.Find(kal => kal.ID == calenderID);

            if (calenderID > 0)
            {
                HttpContext.Current.Session["AccessCalendar"] = accessCalendar;
            }

            AccessCalendarViewModel accessCalendarViewModel = new AccessCalendarViewModel();
            int calendarYear = DateTime.Now.Year;

            if (ddlCalendarYear2.Value != null)
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }

            if (accessCalendar == null)
            {
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(calendarYear);

                grdAccessCalendar.DataSource = lstaccessCalendarScheduleViewModel;
                grdAccessCalendar.DataBind();

                return;
            }

            if (accessCalendar.Calendar_Nr == 0)
            {
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(calendarYear);
            }
            else
            {
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(accessCalendar);
                if (lstaccessCalendarScheduleViewModel.Count == 0)
                {
                    lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(accessCalendar.CalendarDate.Year);
                }
            }
            grdAccessCalendar.DataSource = lstaccessCalendarScheduleViewModel;
            grdAccessCalendar.DataBind();
        }

        protected void grdAccessCalendar_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var parameter = Convert.ToInt64(e.Parameters);
                var formMode = ((int)FormMode.Display).ToString();
                Session["AccessPlanFormMode"] = formMode;
                hiddenFieldFormMode.Value = formMode;
                BindAccessCalendar(parameter);
            }


            //if (parameter == -888)
            //{
            //    BindControls();

            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "SetEditMode", "SetEditMode();", true);

            //    hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString(); ;

            //    DisplayAccessCalendar();
            //}
            //else if (parameter == -999)
            //{
            //    BindControls();
            //    LoadAccessCalendar(0);

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "setNextAccessKalendarNo", "setNextAccessKalendarNo();", true);

            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "SetNewMode", "SetNewMode();", true);
            //}
            //else
            //{
            //    var formMode = ((int)FormMode.Display).ToString();
            //    Session["AccessPlanFormMode"] = formMode;
            //    hiddenFieldFormMode.Value = formMode;

            //    LoadAccessCalendar(parameter);
            //    dplCalendarName.Enabled = true;
            //    dplCalendarNr.Enabled = true;
            //    btnNew.Enabled = accessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;
            //    btnCancelDel.Enabled = accessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;
            //}
        }

        static void GetAccessProfilesByMonth(AccessCalendarMonth accessCalendarMonth)
        {
            var accessCalendar = accessCalendarMonth.AccessCalendar;

            if (accessCalendar == null) return;

            var calendarMonth = accessCalendarMonth.AccessCalendarMonthNr;

            var numberOfDays = DateTime.DaysInMonth(accessCalendar.CalendarDate.Year, calendarMonth);

            var accessProfileViewModel = new ZuttritProfileViewModel();
            var accessProfiles = accessProfileViewModel.ZuttritProfiles();

            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var weekProfileHours = new List<WeekProfileHour>();
            for (var day = 1; day <= numberOfDays; day++)
            {
                var monthDate = new DateTime(accessCalendar.CalendarDate.Year, calendarMonth, day);

                var weekNumber = cultureInfo.Calendar.GetWeekOfYear(monthDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                var idProperty = string.Format("Day{0}AccessProfileID", day);
                var idPropertyInfo = accessCalendarMonth.GetType().GetProperty(idProperty);

                var accessProfileId = (int)idPropertyInfo.GetValue(accessCalendarMonth);

                var accessProfile = accessProfiles.FirstOrDefault(a => a.ID == accessProfileId);

                var weekProfileHour = new WeekProfileHour
                {
                    WeekNumber = weekNumber,
                    WeekDayDate = monthDate,

                    ProfileType = "Header"
                };

                if (accessProfile != null)
                {
                    weekProfileHour.SwitchProfileId = accessProfileId;
                    weekProfileHour.ProfileHours = accessProfile.AccessProfileID;
                }

                weekProfileHours.Add(weekProfileHour);
            }

            HttpContext.Current.Session["WeekProfileHours"] = weekProfileHours;
            HttpContext.Current.Session["WeekNumber"] = null;
        }

        [WebMethod]
        public static void GetAccessProfilesByMonth(long accessCalendarId, int calendarMonth)
        {
            var accessCalendarMonth = new AccessCalendarViewModel().GetAccessCalendarMonthByCalendarMonth(accessCalendarId, calendarMonth);
            if (accessCalendarMonth == null) return;

            GetAccessProfilesByMonth(accessCalendarMonth);
            HttpContext.Current.Session["AccessCalendarMonth"] = accessCalendarMonth;

            HttpContext.Current.Session["CalendarMonth"] = accessCalendarMonth.AccessCalendarMonthNr;

            var accessCalendar = accessCalendarMonth.AccessCalendar;
            if (accessCalendar != null)
            {
                HttpContext.Current.Session["CalendarYear"] = accessCalendar.CalendarDate.Year;

                HttpContext.Current.Session["AccessCalendarNumber"] = accessCalendar.Calendar_Nr;
                HttpContext.Current.Session["AccessCalendarName"] = accessCalendar.Calendar_Name;
            }
        }

        [WebMethod]
        public static void GetMonthProfiles(int calendarMonth)
        {
            var accessCalendar = (AccessCalendar)HttpContext.Current.Session["AccessCalendar"];
            if (accessCalendar == null) return;

            var accessCalendarMonth = new AccessCalendarViewModel().GetAccessCalendarMonthByCalendarMonth(accessCalendar.ID, calendarMonth);
            if (accessCalendarMonth == null) return;

            GetAccessProfilesByMonth(accessCalendarMonth);
            HttpContext.Current.Session["CalendarMonth"] = accessCalendarMonth.AccessCalendarMonthNr;
            HttpContext.Current.Session["CalendarYear"] = accessCalendar.CalendarDate.Year;
            HttpContext.Current.Session["AccessCalendarMonth"] = accessCalendarMonth;

            HttpContext.Current.Session["AccessCalendarNumber"] = accessCalendar.Calendar_Nr;
            HttpContext.Current.Session["AccessCalendarName"] = accessCalendar.Calendar_Name;
        }

        protected void grdZuttritProfileTimeFrames_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadZuttritProfileTimeFrames(e.Parameters);
        }

        public void LoadZuttritProfileTimeFrames(string acessProfileId)
        {
            ZuttritProfilesTimeFrameViewModel zuttritProfilesTimeFrameViewModel = new ZuttritProfilesTimeFrameViewModel();
            List<ZuttritProfilesTimeFrame> listZuttritProfilesTimeFrame = new List<ZuttritProfilesTimeFrame>();
            ZuttritProfileRepository zuttritProfilesRepository = new ZuttritProfileRepository();
            ZuttritProfileRepository zuttritProfilesRepository2 = new ZuttritProfileRepository();
            List<ZuttritProfile> listZuttritProfiles = new List<ZuttritProfile>();
            listZuttritProfiles = zuttritProfilesRepository.GetAllZuttritProfiles();
            ZuttritProfile zuttritProfile = new ZuttritProfile();
            zuttritProfile = listZuttritProfiles.Find(x => x.AccessProfileID == acessProfileId);

            long profileId;

            ZuttritProfile zuttritProfile2 = new ZuttritProfile();
            zuttritProfile2 = zuttritProfilesRepository2.GetZuttritProfileByAccessProfileId(acessProfileId);

            if (zuttritProfile2 == null) return;

            profileId = zuttritProfile2.ID;

            if (acessProfileId == "")
            {
                listZuttritProfilesTimeFrame = zuttritProfilesTimeFrameViewModel.GetZuttritProfileTimeFrames();
            }
            else
            {
                listZuttritProfilesTimeFrame = zuttritProfilesTimeFrameViewModel.GetZuttritProfilesTimeFramesByAccessProfID(profileId).Where(z => z.ProfilAktiv).ToList();

                if (listZuttritProfilesTimeFrame.Count < 10)
                {
                    grdZuttritProfileTimeFrames.SettingsPager.PageSize = 5;
                }
                else
                {
                    grdZuttritProfileTimeFrames.SettingsPager.PageSize = 10;
                }
            }

            grdZuttritProfileTimeFrames.DataSource = listZuttritProfilesTimeFrame;
            grdZuttritProfileTimeFrames.DataBind();
        }

        protected void btnCalendarYearNext_Click(object sender, EventArgs e)
        {
            MoveToNextYear();
        }

        protected void btnCalendarYearPrevious_Click(object sender, EventArgs e)
        {
            MoveToPreviousYear();
        }
        private void MoveToNextYear()
        {
            var i = (ddlCalendarYear2.SelectedIndex + 1);
            if (i > (ddlCalendarYear2.Items.Count - 1)) return;
            ddlCalendarYear2.SelectedIndex = i;
            ddlTariffYear2.Value = ddlCalendarYear2.Value;
        }
        private void MoveToPreviousYear()
        {
            var i = (ddlCalendarYear2.SelectedIndex - 1);
            if (i < 0) return;
            ddlCalendarYear2.SelectedIndex = i;
            ddlTariffYear2.Value = ddlCalendarYear2.Value;
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //var passed = string.IsNullOrEmpty(hiddenFieldPassed.Value)? 0: Convert.ToInt32(hiddenFieldPassed.Value);
            //if (passed == 1) return;
            //var pageOrigin = Request.QueryString["pageOrigin"];
            //if (string.IsNullOrEmpty(pageOrigin)) return;
            //var page_origin = Convert.ToInt32(pageOrigin);
            ////ScriptManager.RegisterStartupScript(this, this.GetType(), "setControlsOnNew", "SetControlsOnNewCustom();", true);
            //switch (page_origin)
            //{
            //    case 1:
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "setControlsOnNew", "SetControlsOnNewCustom();", true);
            //        hiddenFieldPassed.Value = "1";
            //        break;

            //    default:
            //        break;
            //}

        }

        protected void grdHolidayCalndr_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var accessCalendars = new AccessCalendarViewModel().BindAccessCalenderRawData();
            grdHolidayCalndr.DataSource = accessCalendars;
            grdHolidayCalndr.DataBind();
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var index = grdHolidayCalndr.FindVisibleIndexByKeyValue(e.Parameters);
                grdHolidayCalndr.FocusedRowIndex = e.Parameters.ToString() != "0" && index >= 0 ? index : -1;
            }
        }

        protected void ddlCalendarYear2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadCalender();
        }
        void ReloadCalender()
        {
            if (dplCalendarNr.Value.ToString() == "0")
            {
                int selectedYear = DateTime.Now.Year;
                if (ddlCalendarYear2.SelectedItem != null)
                    int.TryParse(ddlCalendarYear2.SelectedItem.Text, out selectedYear);
                grdAccessCalendar.DataSource = new AccessCalendarViewModel().GetAccessCalendarSchedule(selectedYear);
                grdAccessCalendar.DataBind();
                datePickerDateFrom.Date = new DateTime(selectedYear, 1, 1);
                datePickerDateTo.Date = datePickerDateFrom.Date;
                //datePickerDateFrom.Text = "";
                //datePickerDateTo.Text = "";
                ddlTariffYear2.Value = ddlCalendarYear2.Value;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            dplCalendarName.Value = "0";
            dplCalendarNr.Value = "0";
            dplCalendarName.ClientEnabled = false;
            dplCalendarNr.ClientEnabled = false;
            ddlCalendarYear2.ClientEnabled = true;
            btnNew.Enabled = false;
            btnCancelDel.Enabled = false;
            BindControls();
            LoadAccessCalendar(0);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "setNextAccessKalendarNo", "setNextAccessKalendarNo();", true);
            txtCalendarName.Focus();
            txtCalendarName.Text = string.Empty;
            hiddenFieldSaveChanges.Value = "1";
        }

        protected void dplCalendarNr_Callback(object sender, CallbackEventArgsBase e)
        {
            listAccessCalendar = new List<AccessCalendar>();
            if (listAccessCalendar.Count == 0)
            {
                listAccessCalendar.Add(new AccessCalendar() { ID = 0, Calendar_Nr = 0, Calendar_Name = "keine", CalendarDate = DateTime.Now });
            }
            LoadExistingAccessCalendar(ref listAccessCalendar);
            dplCalendarNr.DataSource = listAccessCalendar.OrderBy(x => x.Calendar_Nr);
            dplCalendarNr.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                dplCalendarNr.Value = e.Parameter.ToString();
            }
            else
            {
                dplCalendarNr.SelectedIndex = 0;
            }

        }

        protected void dplCalendarName_Callback(object sender, CallbackEventArgsBase e)
        {
            listAccessCalendar = new List<AccessCalendar>();
            if (listAccessCalendar.Count == 0)
            {
                listAccessCalendar.Add(new AccessCalendar() { ID = 0, Calendar_Nr = 0, Calendar_Name = "keine", CalendarDate = DateTime.Now });
            }

            LoadExistingAccessCalendar(ref listAccessCalendar);
            dplCalendarName.DataSource = listAccessCalendar.OrderBy(x => x.Calendar_Nr);
            dplCalendarName.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                dplCalendarName.Value = e.Parameter.ToString();
            }
            else
            {
                dplCalendarName.SelectedIndex = 0;
            }
        }
    }
}