﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using DevExpress.Web;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using System.Globalization;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Color = System.Drawing.Color;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlanGroupCalender : BasePage
    {
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit,
            Refresh
        }
        private static List<AccessCalendar> _accessCalendars;
        private static int _accessCalendarId;
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
                btnNew.Enabled = false; btnNewAccessProfile.Enabled = false;

                btnSave.Enabled = false;

                btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            Session["CalendarType"] = "Mapped";

            int formMode;
            if (Session["AccessPlanFormMode"] != null)
            {
                formMode = Convert.ToInt32(Session["AccessPlanFormMode"].ToString());
                hiddenFieldFormMode.Value = formMode.ToString();
            }
            if (!IsPostBack)
            {
                this.Form.DefaultButton = this.btnSave.UniqueID;
                LoadAccessGroup();
                BindControls();
                LoadAccessCalendars();
                for (var calendarYear = DateTime.Now.Year - 5; calendarYear < DateTime.Now.Year + 5; calendarYear++)
                {
                    ddlCalendarYear.Items.Add(new ListItem(calendarYear.ToString(), calendarYear.ToString()));
                    ddlCalendarYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));

                    ddlTariffYear.Items.Add(new ListItem(calendarYear.ToString(), calendarYear.ToString()));
                    ddlTariffYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));
                }
                ddlCalendarYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlCalendarYear2.Value = DateTime.Now.Year.ToString();

                ddlTariffYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlTariffYear2.Value = DateTime.Now.Year.ToString();
                hiddenFieldCalendarYear.Value = DateTime.Now.Year.ToString();
                ddlTariffYear2.ClientEnabled = false;
                ddlCalendarYear2.ClientEnabled = false;
                DisplayAccessPlanGroupCalendar();
                grdHolidayCalndr.FocusedRowIndex = dplCalendarNr.Value.ToString() != "0" ? dplCalendarNr.SelectedIndex - 1 : -1;
            }

        }
        #region Private Methods
        protected void LoadAccessGroup()
        {
            if (string.IsNullOrEmpty(Request.QueryString["profileId"]))
            {
                Response.Redirect("~/Content/AccessPlanGroup.aspx");
            }
            else
            {
                var id = Convert.ToInt64(Request.QueryString["profileId"]);
                var accessGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(id);
                txtAccessGroupNr.Text = accessGroup.AccessPlanGroupNr.ToString();
                txtAccessGroupName.Text = accessGroup.AccessPlanGroupName;
                txtAccessGroupId.Text = accessGroup.ID.ToString();
                Session["_AccessPlanGroupId"] = id;
            }
        }
        void BindControls()
        {
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
            }

            LoadExistingAccessProfiles(ref listAccessProfiles);

            ddlProfileId.DataSource = listAccessProfiles;
            ddlProfileId.DataBind();

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

            if (listAccessProfiles.Count > 12)
            {
                gridViewAccessProfileSearch.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                gridViewAccessProfileSearch.Settings.VerticalScrollableHeight = 474;
                gridViewAccessProfileSearch.SettingsPager.PageSize = listAccessProfiles.Count();
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

        void DisplayAccessPlanGroupCalendar()
        {
            Session["AccessCalendar"] = null;
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == (int)FormMode.Create)
            {
                LoadAccessCalendar(0);
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString["profileId"]))
            {
                return;
            }

            long groupId = 0;

            long.TryParse(Request.QueryString["profileId"], out groupId);
            var accessPlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(Convert.ToInt64(groupId));

            if (accessPlanGroup == null) return;

            if (!accessPlanGroup.AccessCalendarId.HasValue) return;

            Session["_AccessPLan_Group"] = accessPlanGroup;

            _accessCalendarId = (int)accessPlanGroup.AccessCalendarId.Value;
            var accessCalendar = new AccessCalendarViewModel().GetAccessCalendarById(_accessCalendarId);
            Session["AccessCalendar"] = accessCalendar;

            DisplayAccessCalendar(accessCalendar);
        }

        void DisplayAccessCalendar(AccessCalendar accessCalendar)
        {
            LoadAccessCalendar(accessCalendar);

            if (accessCalendar != null)
            {
                txtCalendarNr.Text = accessCalendar.Calendar_Nr.ToString();
                txtCalendarName.Text = accessCalendar.Calendar_Name;
                txtMemo.Text = accessCalendar.Memo;

                dplCalendarNr.Value = accessCalendar.ID.ToString();
                dplCalendarName.Value = accessCalendar.ID.ToString();

                ddlTariffYear2.Value = accessCalendar.CalendarDate.Year;
                hiddenFieldCalendarYear.Value = accessCalendar.CalendarDate.Year.ToString();
            }

            hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString();

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

        void LoadAccessCalendar(int calenderId)
        {
            var accessCalendar = new AccessCalendarViewModel().GetAccessCalendarById(calenderId);

            if (accessCalendar != null)
            {
                DisplayAccessCalendar(accessCalendar);

                HttpContext.Current.Session["AccessCalendar"] = accessCalendar;
                HttpContext.Current.Session["AccessCalendarId"] = accessCalendar.ID;
            }
            else
            {
                ClearAccessCalenderGrid();
            }

            //grdHolidayCalndr.FocusedRowIndex = dplCalendarName.Value.ToString() != "0" ? dplCalendarName.SelectedIndex - 1 : -1;
            hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString();
        }

        void LoadAccessCalendar(AccessCalendar accessCalendar)
        {
            List<AccessCalendarScheduleViewModel> lstaccessCalendarScheduleViewModel;

            var accessCalendarViewModel = new AccessCalendarViewModel();

            if (accessCalendar == null)
            {
                int calendarYear = DateTime.Now.Year;
                if (ddlTariffYear.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlTariffYear.SelectedItem.Text);
                }

                if (ddlTariffYear2.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlTariffYear2.SelectedItem.Text);
                }

                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(calendarYear);
            }
            else
            {
                hiddenFieldAccessCalendarId.Value = accessCalendar.ID.ToString();
                lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(accessCalendar);
                if (lstaccessCalendarScheduleViewModel.Count == 0)
                {
                    lstaccessCalendarScheduleViewModel = accessCalendarViewModel.GetAccessCalendarSchedule(accessCalendar.CalendarDate.Year);
                }
            }

            grdAccessCalendar.DataSource = lstaccessCalendarScheduleViewModel;
            grdAccessCalendar.DataBind();

        }

        void LoadAccessCalendars()
        {

            AccessCalendarRepository _AccessCalendarRepository = new AccessCalendarRepository();
            var accessCalendar = new AccessCalendarViewModel().BindAccessCalenderRawData();


            var accessCalendars = new List<AccessCalendar>();

            if (accessCalendars.Count == 0)
            {
                accessCalendars.Add(new AccessCalendar() { ID = 0, Calendar_Nr = 0, Calendar_Name = "keine", CalendarDate = DateTime.Now });
            }

            LoadExistingAccessCalendar(ref accessCalendars);

            dplCalendarNr.DataSource = accessCalendars.OrderBy(x => x.Calendar_Nr);
            dplCalendarNr.DataBind();
            dplCalendarNr.SelectedIndex = 0;

            //grdHolidayCalndr.DataSource = accessCalendar.DefaultView.Sort = "Calendar_Nr";
            grdHolidayCalndr.DataSource = accessCalendar;
            grdHolidayCalndr.DataBind();
            if (accessCalendar.Rows.Count > 18)
            {
                grdHolidayCalndr.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                grdHolidayCalndr.Settings.VerticalScrollableHeight = 634;
                grdHolidayCalndr.SettingsPager.PageSize = accessCalendar.Rows.Count;
            }

            dplCalendarName.DataSource = accessCalendars.OrderBy(x => x.Calendar_Nr);
            dplCalendarName.DataBind();
            dplCalendarName.SelectedIndex = 0;

            _accessCalendars = accessCalendars;
        }

        void LoadExistingAccessCalendar(ref List<AccessCalendar> listAccessCalendar)
        {
            AccessCalendarViewModel accessPlanViewModel = new AccessCalendarViewModel();
            listAccessCalendar.AddRange(accessPlanViewModel.AccessCalendars());
        }

        void LoadExistingAccessProfiles(ref List<ZuttritProfile> listAccessProfiles)
        {
            ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
            listAccessProfiles.AddRange(zuttritProfileViewModel.ZuttritProfiles());
        }

        void LoadZuttritProfileTimeFrames(string acessProfileId)
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

        static void MapAccessPlanGroupCalendar(AccessCalendar accessCalendar, long groupId)
        {

            if (accessCalendar == null) return;
            var accessPlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(groupId);

            if (accessPlanGroup == null) return;

            var accessPlanGroupToEdit = new TbAccessPlanGroup
            {
                ID = accessPlanGroup.ID,
                AccessPlanGroupNr = accessPlanGroup.AccessPlanGroupNr,
                AccessPlanGroupName = accessPlanGroup.AccessPlanGroupName,
                AccessCalendarId = accessCalendar.ID,
                BuildingPlanID = accessPlanGroup.BuildingPlanID,

            };

            new AccessPlanGroupRepository().EditAccessPlanGroup(accessPlanGroupToEdit);
        }

        #endregion Private Methods

        #region Public Methods

        [WebMethod]
        public static void DeleteAccessCalendar(long id)
        {
            var accessPlanViewModel = new AccessCalendarViewModel();
            var accessCalendar = accessPlanViewModel.GetAccessCalendarById(id);
            if (accessCalendar == null) return;
            new AccessCalendarViewModel().DeleteAccessCalendarMonths(accessCalendar);
            accessPlanViewModel.DeleteAccessCalendar(accessCalendar);
        }

        [WebMethod]
        public static void UpdateAccessCalenderSchedule(string jsonData)
        {
            if (jsonData == null) return;

            var accessCalendarScheduleViewModels = JsonConvert.DeserializeObject<List<AccessCalendarScheduleViewModel>>(jsonData);
            var accessCalendarMonths = new List<AccessCalendarMonth>();
            foreach (var accessCalendarSchedule in accessCalendarScheduleViewModels)
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

            HttpContext.Current.Session["AccessCalendarMonths"] = accessCalendarMonths;
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

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        #endregion Public Methods

        #region Button Events Methods

        protected void btnNewAccessProfile_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["profileId"];
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            Session["AccessPlanFormMode"] = formMode;
            Session["AccessPlanAction"] = "New";
            var ent = "4";
            Response.Redirect(String.Format("/Content/AccessProfile.aspx?profileId={0}&ent={1}", profileId, ent));
        }

        #endregion Button Events Methods

        #region GridView Events Methods

        protected void grdAccessCalendar_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var parameter = Convert.ToInt32(e.Parameters);

            if (parameter == -888)
            {
                BindControls();

                DisplayAccessPlanGroupCalendar();
            }
            else if (parameter == -999)
            {
                txtCalendarNr.Text = string.Empty;
                txtCalendarName.Text = string.Empty;
                txtMemo.Text = string.Empty;

                dplCalendarNr.Value = "0";
                dplCalendarName.Value = "0";

                int calendarYear = DateTime.Now.Year;
                if (ddlTariffYear.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlTariffYear.SelectedItem.Text);
                }

                if (ddlTariffYear2.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlTariffYear2.SelectedItem.Text);
                }

                var accessCalendarScheduleViewModel = new AccessCalendarViewModel().GetAccessCalendarSchedule(calendarYear);

                grdAccessCalendar.DataSource = accessCalendarScheduleViewModel;
                grdAccessCalendar.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "setNextAccessKalendarNo", "setNextAccessKalendarNo();", true);

                hiddenFieldFormMode.Value = ((int)FormMode.Create).ToString();
                Session["AccessCalendarMonths"] = null;
            }
            else if (parameter == -111)
            {
                txtCalendarNr.Text = string.Empty;
                txtCalendarName.Text = string.Empty;
                txtMemo.Text = string.Empty;

                dplCalendarNr.Value = "0";
                dplCalendarName.Value = "0";

                int calendarYear = DateTime.Now.Year;
                if (ddlTariffYear.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlTariffYear.SelectedItem.Text);
                }

                if (ddlTariffYear2.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlTariffYear2.SelectedItem.Text);
                }

                var accessCalendarScheduleViewModel = new AccessCalendarViewModel().GetAccessCalendarSchedule(calendarYear);

                grdAccessCalendar.DataSource = accessCalendarScheduleViewModel;
                grdAccessCalendar.DataBind();

            }
            else
            {
                LoadAccessCalendar(parameter);
            }
        }

        protected void grdAccessCalendar_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
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

            int calendarYear = DateTime.Now.Year;
            var accessCalendar = (AccessCalendar)Session["AccessCalendar"];
            if (accessCalendar != null)
            {
                var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
                calendarYear = formMode == (int)FormMode.Create || dplCalendarNr.Value.ToString() == "0" ? selectedYear : accessCalendar.CalendarDate.Year;
            }

            if (e.DataColumn.FieldName.Substring(0, 3) != "Day") return;

            var daysDate = DateTime.MinValue; ;

            if (e.VisibleIndex > 12) return;

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

        protected void grdZuttritProfileTimeFrames_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadZuttritProfileTimeFrames(e.Parameters);
        }

        #endregion GridView Events Methods

        #region get passed data

        public void LoadExistingGroups(ref List<AccessGroup> listAccessGroups)
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            listAccessGroups.AddRange(accessGroups.GetAllAccessPlanAccessGroups().Where(x => x.AccessGroupType == 2));
        }


        #endregion passed data
        protected void ClearAccessCalenderGrid()
        {
            txtCalendarNr.Text = string.Empty;
            txtCalendarName.Text = string.Empty;
            txtMemo.Text = string.Empty;
            int calendarYear = DateTime.Now.Year;
            if (ddlTariffYear.SelectedItem != null)
            {
                calendarYear = Convert.ToInt32(ddlTariffYear.SelectedItem.Text);
            }

            if (ddlTariffYear2.SelectedItem != null)
            {
                calendarYear = Convert.ToInt32(ddlTariffYear2.SelectedItem.Text);
            }

            var accessCalendarScheduleViewModel = new AccessCalendarViewModel().GetAccessCalendarSchedule(calendarYear);

            grdAccessCalendar.DataSource = accessCalendarScheduleViewModel;
            grdAccessCalendar.DataBind();

        }
        [WebMethod]
        public static bool CheckIfCalenderNrExists(int calenderNr)
        {
            var exists = false;
            var accessCalender = new AccessCalendarViewModel().GetAccessCalendarByNr(calenderNr);
            if (accessCalender != null)
            {
                exists = true;
            }
            return exists;
        }

        protected void grdHolidayCalndr_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var accessCalendar = new AccessCalendarViewModel().BindAccessCalenderRawData();
            grdHolidayCalndr.DataSource = accessCalendar;
            grdHolidayCalndr.DataBind();
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var index = grdHolidayCalndr.FindVisibleIndexByKeyValue(e.Parameters);
                if (index >= 0)
                {
                    grdHolidayCalndr.FocusedRowIndex = index;
                }
                else
                {
                    grdHolidayCalndr.FocusedRowIndex = -1;
                }
            }
            if (accessCalendar.Rows.Count > 18)
            {
                grdHolidayCalndr.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                grdHolidayCalndr.Settings.VerticalScrollableHeight = 634;
                grdHolidayCalndr.SettingsPager.PageSize = accessCalendar.Rows.Count;
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
                var accessCalendar = new AccessCalendarViewModel().GetAccessCalendarSchedule(selectedYear);
                Session["AccessCalendar"] = new AccessCalendar() { CalendarDate = new DateTime(selectedYear, 1, 1) };
                grdAccessCalendar.DataSource = accessCalendar;
                grdAccessCalendar.DataBind();
                datePickerDateFrom.Date = new DateTime(selectedYear, 1, 1);
                datePickerDateTo.Date = datePickerDateFrom.Date;
                //datePickerDateFrom.Text = "";
                //datePickerDateTo.Text = "";
                ddlTariffYear2.Value = ddlCalendarYear2.Value;
            }
        }
        [WebMethod]
        public static long SaveAccessCalendar(int formMode, long calenderId, int calendarNumber, string calendarName, DateTime calendarDate, string memo, long groupId)
        {
            long Id = 0;
            if (calendarNumber == 0) return Id;

            AccessCalendar accessCalendar = null;
            switch (formMode)
            {
                case (int)FormMode.Create:
                    var accessCalendarMonths = (List<AccessCalendarMonth>)HttpContext.Current.Session["AccessCalendarMonths"];
                    var accessCalendarNew = new AccessCalendar
                    {
                        Calendar_Nr = calendarNumber,
                        Calendar_Name = calendarName,
                        CalendarDate = calendarDate,
                        Memo = memo,
                        AccessCalendarMonths = accessCalendarMonths
                    };

                    new AccessCalendarViewModel().CreateAccessCalendar(accessCalendarNew);
                    accessCalendar = new AccessCalendarViewModel().GetAccessCalendarByNr(accessCalendarNew.Calendar_Nr);
                    break;

                case (int)FormMode.Edit:
                    var accessCalendarCurrent = new AccessCalendarViewModel().GetAccessCalendarById(Convert.ToInt64(calenderId));
                    if (accessCalendarCurrent != null)
                    {
                        var accessCalendarToEdit = new AccessCalendar
                        {
                            ID = accessCalendarCurrent.ID,
                            Calendar_Nr = calendarNumber,
                            Calendar_Name = calendarName,
                            CalendarDate = accessCalendarCurrent.CalendarDate,
                            Memo = memo,
                            AccessCalendarMonths = null
                        };

                        List<AccessCalendarMonth> accessCalendarMonthsToEdit;
                        if (HttpContext.Current.Session["AccessCalendarMonths"] != null)
                        {
                            accessCalendarMonthsToEdit = (List<AccessCalendarMonth>)HttpContext.Current.Session["AccessCalendarMonths"];
                        }
                        else
                        {
                            accessCalendarMonthsToEdit = accessCalendarCurrent.AccessCalendarMonths.ToList();
                        }

                        new AccessCalendarViewModel().EditAccessCalendar(accessCalendarToEdit);
                        new AccessCalendarViewModel().DeleteAccessCalendarMonths(accessCalendarToEdit);
                        new AccessCalendarViewModel().CreateAccessCalendarMonths(accessCalendarCurrent.ID, accessCalendarMonthsToEdit);

                        accessCalendar = new AccessCalendarViewModel().GetAccessCalendarById((int)accessCalendarCurrent.ID);
                    }

                    break;
            }
            if (accessCalendar != null)
            {
                Id = accessCalendar.ID;
                MapAccessPlanGroupCalendar(accessCalendar, groupId);
            }

            return Id;
        }

        protected void dplCalendarNr_Callback(object sender, CallbackEventArgsBase e)
        {
            AccessCalendarRepository _AccessCalendarRepository = new AccessCalendarRepository();
            var accessCalendar = new AccessCalendarViewModel().BindAccessCalenderRawData();
            var accessCalendars = new List<AccessCalendar>();

            if (accessCalendars.Count == 0)
            {
                accessCalendars.Add(new AccessCalendar() { ID = 0, Calendar_Nr = 0, Calendar_Name = "keine", CalendarDate = DateTime.Now });
            }

            LoadExistingAccessCalendar(ref accessCalendars);
            dplCalendarNr.DataSource = accessCalendars.OrderBy(x => x.Calendar_Nr);
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
            AccessCalendarRepository _AccessCalendarRepository = new AccessCalendarRepository();
            var accessCalendar = new AccessCalendarViewModel().BindAccessCalenderRawData();
            var accessCalendars = new List<AccessCalendar>();

            if (accessCalendars.Count == 0)
            {
                accessCalendars.Add(new AccessCalendar() { ID = 0, Calendar_Nr = 0, Calendar_Name = "keine", CalendarDate = DateTime.Now });
            }

            LoadExistingAccessCalendar(ref accessCalendars);
            dplCalendarName.DataSource = accessCalendars.OrderBy(x => x.Calendar_Nr);
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