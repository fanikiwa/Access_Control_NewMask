using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Models;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.ViewModels;
using System.Web.Services;
using KruAll.Core.Repositories;
using Color = System.Drawing.Color;
using System.Globalization;
using Access_Control_NewMask.Dtos;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using DevExpress.Web;

namespace Access_Control_NewMask.Content
{
    public partial class AccessPlanAccessCalender : BasePage
    {
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit,
            Refresh
        }

        static List<AccessGroup> listAccessGroups;
        static List<TbAccessPlan> listAccessPlans;
        private static List<AccessCalendar> _accessCalendars;
        private static int _accessCalendarId;
        ZUTMain mainCtl = new ZUTMain();
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
                btnNew.Enabled = false; btnNewAccessProfile.Enabled = false;

                btnSaveAccessPlan.Enabled = false;

                btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSaveAccessPlan.UniqueID;

            if (hiddenFieldDetectChanges.Value != null)
            {
                if (hiddenFieldDetectChanges.Value == "999")
                {
                    //Response.Redirect("AccessPlan.aspx");
                }
            }

            Session["CalendarType"] = "Mapped";

            int formMode;
            if (Session["AccessPlanFormMode"] != null)
            {
                formMode = Convert.ToInt32(Session["AccessPlanFormMode"].ToString());
                hiddenFieldFormMode.Value = formMode.ToString();
            }

            BindControls();

            if (!IsPostBack)
            {
                LoadAccessCalendars();

                GetPassedData();

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
                DisplayAccessPlanCalendar();
                grdHolidayCalndr.FocusedRowIndex = dplCalendarNr.Value.ToString() != "0" ? dplCalendarNr.SelectedIndex - 1 : -1;
            }

            formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == ((int)FormMode.Refresh))
            {
                LoadAccessCalendars();

                var lastSavedAccessCalendar = _accessCalendars.OrderByDescending(a => a.ID).FirstOrDefault();

                if (lastSavedAccessCalendar != null)
                {
                    DisplayAccessCalendar(lastSavedAccessCalendar);
                }
            }

            BindAccessPlanText();

        }

        #region Private Methods

        void BindAccessPlanText()
        {
            if (ddlAccessGroupName.SelectedItem != null)
            {
                txtAccessGroupName.Text = ddlAccessGroupName.SelectedItem.Text;
            }

            if (ddlAccessGroupNumber.SelectedItem != null)
            {
                txtAccessGroupNumber.Text = ddlAccessGroupNumber.SelectedItem.Text;
            }

            if (ddlAccessProfileNumber.SelectedItem != null)
            {
                txtAccessProfileNumber.Text = ddlAccessProfileNumber.SelectedItem.Text;
            }

            if (ddlAccessProfileName.SelectedItem != null)
            {
                txtAccessProfileName.Text = ddlAccessProfileName.SelectedItem.Text;
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

            if (Session["ProfileID"] != null)
            {
                ddlAccessProfileNumber.SelectedValue = Session["ProfileID"].ToString();
                ddlAccessProfileName.SelectedValue = Session["ProfileID"].ToString();
            }

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

        void DisplayAccessPlanCalendar()
        {
            Session["AccessCalendar"] = null;
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == (int)FormMode.Create)
            {
                LoadAccessCalendar(0);
                return;
            }

            if (HttpContext.Current.Session["ProfileID"] == null) return;

            int accessPlanId = 0;

            int.TryParse(HttpContext.Current.Session["ProfileID"].ToString(), out accessPlanId);
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(accessPlanId);

            if (accessPlan == null) return;

            if (!accessPlan.AccessCalendarId.HasValue) return;

            Session["AccessPlan"] = accessPlan;

            _accessCalendarId = (int)accessPlan.AccessCalendarId.Value;
            var accessCalendar = new AccessCalendarViewModel().GetAccessCalendarById(_accessCalendarId);
            Session["AccessCalendar"] = accessCalendar;

            DisplayAccessCalendar(accessCalendar);
        }

        void DisplayAccessCalendar(AccessCalendar accessCalendar)
        {
            LoadAccessCalendar(accessCalendar);

            if (ddlAccessGroupName.SelectedItem != null)
            {
                txtAccessGroupName.Text = ddlAccessGroupName.SelectedItem.Text;
            }

            if (ddlAccessGroupNumber.SelectedItem != null)
            {
                txtAccessGroupNumber.Text = ddlAccessGroupNumber.SelectedItem.Text;
            }

            if (ddlAccessProfileNumber.SelectedItem != null)
            {
                txtAccessProfileNumber.Text = ddlAccessProfileNumber.SelectedItem.Text;
            }

            if (ddlAccessProfileName.SelectedItem != null)
            {
                txtAccessProfileName.Text = ddlAccessProfileName.SelectedItem.Text;
            }

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

        static void MapAccessPlanCalendar(AccessCalendar accessCalendar)
        {
            if (HttpContext.Current.Session["ProfileID"] == null) return;

            if (accessCalendar == null) return;

            var accessPlanId = Convert.ToInt32(HttpContext.Current.Session["ProfileID"]);
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(accessPlanId);

            if (accessPlan == null) return;

            var accessPlanToEdit = new TbAccessPlan
            {
                ID = accessPlan.ID,
                AccessGroupID = accessPlan.AccessGroupID,
                AccessPlanNr = accessPlan.AccessPlanNr,
                AccessPlanDescription = accessPlan.AccessPlanDescription,
                AccessCalendarId = accessCalendar.ID,
                BuildingPlanID = accessPlan.BuildingPlanID,
                HolidayPlanCalendarId = accessPlan.HolidayPlanCalendarId
            };

            new AccessPlanViewModel().UpdateAccessPlan(accessPlanToEdit);
        }

        static void UnMapAccessPlanCalendar(AccessCalendar accessCalendar)
        {
            if (HttpContext.Current.Session["ProfileID"] == null) return;

            if (accessCalendar != null)
            {
                var accessPlanId = Convert.ToInt32(HttpContext.Current.Session["ProfileID"]);
                var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(accessPlanId);
                if (accessPlan != null)
                {
                    var accessPlanToEdit = new TbAccessPlan
                    {
                        ID = accessPlan.ID,
                        AccessGroupID = accessPlan.AccessGroupID,
                        AccessPlanNr = accessPlan.AccessPlanNr,
                        AccessPlanDescription = accessPlan.AccessPlanDescription,
                        AccessCalendarId = null,
                        BuildingPlanID = accessPlan.BuildingPlanID,
                        HolidayPlanCalendarId = accessPlan.HolidayPlanCalendarId
                    };

                    new AccessPlanViewModel().UpdateAccessPlan(accessPlanToEdit);
                }
            }
        }
        [WebMethod]
        public static void UnMapAccessPlanCalendarCustom()
        {
            if (HttpContext.Current.Session["ProfileID"] == null) return;
            var accessPlanId = Convert.ToInt32(HttpContext.Current.Session["ProfileID"]);
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(accessPlanId);
            if (accessPlan != null)
            {
                var accessPlanToEdit = new TbAccessPlan
                {
                    ID = accessPlan.ID,
                    AccessGroupID = accessPlan.AccessGroupID,
                    AccessPlanNr = accessPlan.AccessPlanNr,
                    AccessPlanDescription = accessPlan.AccessPlanDescription,
                    AccessCalendarId = null,
                    BuildingPlanID = accessPlan.BuildingPlanID,
                    HolidayPlanCalendarId = accessPlan.HolidayPlanCalendarId
                };

                new AccessPlanViewModel().UpdateAccessPlan(accessPlanToEdit);
            }

        }
        #endregion Private Methods

        #region Public Methods

        [WebMethod]
        public static void DeleteAccessCalendar(int id)
        {
            var accessPlanViewModel = new AccessCalendarViewModel();
            var accessCalendar = accessPlanViewModel.GetAccessCalendarById(id);
            var accessPlanId = Convert.ToInt32(HttpContext.Current.Session["ProfileID"]);
            var accessPlan = new AccessPlanViewModel().GetAccessPlanByID(accessPlanId);
            if (accessCalendar == null) return;
            CheckIfAccessCalenderMapped(accessPlan, accessCalendar);

            new AccessCalendarViewModel().DeleteAccessCalendarMonths(accessCalendar);
            accessPlanViewModel.DeleteAccessCalendar(accessCalendar);
        }
        public static void CheckIfAccessCalenderMapped(TbAccessPlan accessPlan, AccessCalendar calendar)
        {
            if (calendar == null) return;
            if (accessPlan == null) return;
            var calendarId = calendar.ID;
            if (accessPlan.AccessCalendarId != null)
            {
                if (accessPlan.AccessCalendarId == calendarId)
                {
                    UnMapAccessPlanCalendar(calendar);
                }
            }
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.Display:
                case (int)FormMode.None:
                    Session["AccessPlanFormMode"] = null;
                    Session["AccessCalendar"] = null;
                    Response.Redirect("/Content/AccessPlan.aspx");

                    break;

                case (int)FormMode.Create:
                case (int)FormMode.Edit:
                    int detectedChanges = 0;
                    if (!string.IsNullOrEmpty(hiddenFieldDetectChanges.Value))
                    {

                        if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
                            hiddenFieldDetectChanges.Value = "0";

                        detectedChanges = Convert.ToInt32(hiddenFieldDetectChanges.Value);
                    }

                    switch (detectedChanges)
                    {
                        case 0:
                            Session["AccessPlanFormMode"] = null;
                            Response.Redirect("/Content/AccessPlan.aspx");

                            break;

                        case 1:
                            ClientScript.RegisterStartupScript(GetType(), "BackButtonConfirm", "BackButtonConfirm();", true);

                            break;
                    }

                    break;
            }
        }

        protected void btnNewAccessProfile_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            Session["AccessPlanFormMode"] = formMode;

            Session["AccessPlanAction"] = "New";

            var url = "AccessProfile.aspx?ent=1";
            Response.Redirect(url);
        }

        protected void btnEditAccessPlan_Click(object sender, EventArgs e)
        {
            GetPassedData();

            dplCalendarNr.Enabled = true;
            dplCalendarName.Enabled = true;

            if (string.IsNullOrEmpty(dplCalendarNr.Text)) return;

            if (!(string.IsNullOrEmpty(dplCalendarNr.Value.ToString())))
            {
                txtCalendarNr.Text = dplCalendarNr.SelectedItem.Text;
            }

            if (!(string.IsNullOrEmpty(dplCalendarName.Value.ToString())))
            {
                txtCalendarName.Text = dplCalendarName.SelectedItem.Text;
            }
        }

        protected void btnSaveAccessPlan_Click(object sender, EventArgs e)
        {

        }

        #endregion Button Events Methods

        #region GridView Events Methods

        protected void grdAccessCalendar_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var parameter = Convert.ToInt32(e.Parameters);

            if (parameter == -888)
            {
                BindControls();

                DisplayAccessPlanCalendar();
            }
            else if (parameter == -999)
            {
                txtCalendarNr.Text = string.Empty;
                txtCalendarName.Text = string.Empty;
                txtMemo.Text = string.Empty;

                dplCalendarNr.Value = "0";
                dplCalendarName.Value = "0";

                BindAccessPlanText();

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

                BindAccessPlanText();

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

        protected void GetPassedData()
        {
            //if (Session["ProfileID"] == null) return;
            if (Session["ProfileID"] == null)
            {
                Response.Redirect("~/Content/AccessPlan.aspx");
            }

            BindAccesssGroups();
            BindAccessProfiles();
            ddlAccessGroupNumber.SelectedValue = Session["GroupID"].ToString();
            ddlAccessGroupName.SelectedValue = Session["GroupID"].ToString();
            ddlAccessProfileNumber.SelectedValue = Session["ProfileID"].ToString();
            ddlAccessProfileName.SelectedValue = Session["ProfileID"].ToString();

            if (!(string.IsNullOrEmpty(ddlAccessGroupNumber.SelectedValue)))
            {
                txtAccessGroupNumber.Text = ddlAccessGroupNumber.SelectedItem.Text;
            }

            if (!(string.IsNullOrEmpty(ddlAccessGroupName.SelectedValue)))
            {
                txtAccessGroupName.Text = ddlAccessGroupName.SelectedItem.Text;
            }

            if (!(string.IsNullOrEmpty(ddlAccessProfileNumber.SelectedValue)))
            {
                txtAccessProfileNumber.Text = ddlAccessProfileNumber.SelectedItem.Text;
            }

            if (!(string.IsNullOrEmpty(ddlAccessProfileName.SelectedValue)))
            {
                txtAccessProfileName.Text = ddlAccessProfileName.SelectedItem.Text;
            }
        }

        public void LoadExistingGroups(ref List<AccessGroup> listAccessGroups)
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            listAccessGroups.AddRange(accessGroups.GetAllAccessPlanAccessGroups().Where(x => x.AccessGroupType == 2));
        }

        public void LoadAccessPlansByGroupID(ref List<TbAccessPlan> listAccessPlans)
        {
            AccessPlanRepository accessPlans = new AccessPlanRepository();
            listAccessPlans.AddRange(accessPlans.GetAllAccessPlans());
        }

        protected void BindAccesssGroups()
        {
            listAccessGroups = new List<AccessGroup>();
            LoadExistingGroups(ref listAccessGroups);

            ddlAccessGroupNumber.DataSource = listAccessGroups;
            ddlAccessGroupNumber.DataBind();

            ddlAccessGroupName.DataSource = listAccessGroups;
            ddlAccessGroupName.DataBind();
        }

        protected void BindAccessProfiles()
        {
            listAccessPlans = new List<TbAccessPlan>();
            LoadAccessPlansByGroupID(ref listAccessPlans);
            ddlAccessProfileNumber.DataSource = listAccessPlans;
            ddlAccessProfileNumber.DataBind();
            ddlAccessProfileName.DataSource = listAccessPlans;
            ddlAccessProfileName.DataBind();
        }

        #endregion passed data

        protected void dplCalendarNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hiddenFieldFormMode.Value = "3";
            //hiddenFieldDetectChanges.Value = "1";
            //dplCalendarName.SelectedValue = dplCalendarNr.SelectedValue;

        }

        protected void dplCalendarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hiddenFieldFormMode.Value = "3";
            //hiddenFieldDetectChanges.Value = "1";
            //dplCalendarNr.SelectedValue = dplCalendarName.SelectedValue;

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            //var pageOrigin = "1";
            //Response.Redirect("AccessKalendar.aspx?pageOrigin=" + pageOrigin);
        }
        protected void ClearAccessCalenderGrid()
        {
            txtCalendarNr.Text = string.Empty;
            txtCalendarName.Text = string.Empty;
            txtMemo.Text = string.Empty;

            BindAccessPlanText();

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
        }

        protected void btnInformation_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Content/AccessPlan.aspx");
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
        public static long SaveAccessCalendar(int formMode, long calenderId, int calendarNumber, string calendarName, DateTime calendarDate, string memo)
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
                MapAccessPlanCalendar(accessCalendar);
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