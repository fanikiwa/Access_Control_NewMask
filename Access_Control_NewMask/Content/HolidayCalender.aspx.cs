using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using System.Globalization;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.Controllers;
using Newtonsoft.Json;
using DevExpress.Web;
using Color = System.Drawing.Color;

namespace Access_Control_NewMask.Content
{
    public partial class HolidayCalender : BasePage
    {
        private static List<Holiday> _selectedHolidays;
        private static List<Holiday> _allHolidays;
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsHolidayCalender_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsHolidayCalender_PMode"] = value;
            }
        }

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
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsHolidayCalender, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnCalendarSave.Enabled = false; btnHolidaySave.Enabled = false;

                btnCalendarNew.Enabled = false; btnHolidayNew.Enabled = false;

                btnApply.Enabled = false; btnCopyCalendar.Enabled = false; btnInternet.Enabled = false;

                btnCalendarDelete.Enabled = false; btnDeleteHolidays.Enabled = false; btnHolidayDelete.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ZUTMain.PermissionDto.HolidayCalender)
            //{
            this.Form.DefaultButton = this.btnCalendarSave.UniqueID;
            //HolCRHiddenField.Value = (ZUTMain.PermissionDto.HolidayCalenderEdit ? 1 : 0).ToString(); ;
            //btnCalendarNew.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;
            //btnCalendarSave.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;
            //btnCalendarDelete.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;
            //btnCopyCalendar.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;

            //btnHolidayNew.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;
            //btnHolidaySave.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;
            //btnHolidayDelete.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;

            //btnApply.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;
            //btnInternet.Enabled = ZUTMain.PermissionDto.HolidayCalenderEdit;

            //settingsNav.Items[1].Enabled = ZUTMain.PermissionDto.RightsSetting;
            //settingsNav.Items[2].Enabled = ZUTMain.PermissionDto.Password;

            //settingsNav.Items[3].Enabled = ZUTMain.PermissionDto.CostCenter;//database

            /*              settingsNav.Items[4].Enabled = ZUTMain.PermissionDto.HolidayCalender;*/ //holoday calender
            if (hiddenFieldDetectChanges.Value != null)
            {
                if (hiddenFieldDetectChanges.Value == "999")
                {
                    Session["HolidayCalendar"] = null;
                    Response.Redirect("Settings.aspx");
                }
            }
            if (Session["AllHolidays"] != null)
            {
                var holidayPlansAll = (List<HolidayPlan>)Session["AllHolidays"];
                gridViewHoliday.DataSource = holidayPlansAll.OrderBy(h => h.HolidayDate).ToList();
                gridViewHoliday.DataBind();
                if (holidayPlansAll.Count() > 16)
                {
                    //gridViewHoliday.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                    //gridViewHoliday.Settings.VerticalScrollableHeight = 629;
                    gridViewHoliday.SettingsPager.PageSize = holidayPlansAll.Count();
                }
            }
            if (Session["HolidaysSelected"] != null)
            {
                var holidaysInCalendar = (List<HolidayPlan>)Session["HolidaysSelected"];
                gridViewHolidaysInCalendar.DataSource = holidaysInCalendar;
                gridViewHolidaysInCalendar.DataBind();
                if (holidaysInCalendar.Count() > 16)
                {
                    //gridViewHolidaysInCalendar.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                    //gridViewHolidaysInCalendar.Settings.VerticalScrollableHeight = 605;
                    gridViewHolidaysInCalendar.SettingsPager.PageSize = holidaysInCalendar.Count();
                }
            }
            if (!IsPostBack)
            {
                //btnApply.Enabled = false;
                //txtHolidayCalendarName.ReadOnly = true;
                //txtHolidayCalendarNumber.ReadOnly = true;
                //txtMemo.ReadOnly = true;
                //btnCalendarSave.Enabled = false;
                //btnCalendarDelete.Enabled = false;
                //btnCopyCalendar.Enabled = false;
                //ddlCalendarYear2Old.Enabled = false;
                //btnCalendarYearNext.Enabled = false;
                //btnCalendarYearPrevious.Enabled = false;
            }
            if (Page.IsPostBack) return;

            // ddlCalendarYear2.Items.Add(new ListEditItem("keine", "0"));
            Session["HolidayCalendar"] = null;
            for (var calendarYear = DateTime.Now.Year - 5; calendarYear < DateTime.Now.Year + 5; calendarYear++)
            {
                ddlCalendarYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));
                ddlCalendarYear2Old.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));
                ddlCalendarYear2Old.Value = DateTime.Now.Year.ToString();
            }

            for (var Year = DateTime.Now.Year - 5; Year < DateTime.Now.Year + 5; Year++)
            {
                ddlYear.Items.Add(new ListEditItem(Year.ToString(), Year.ToString()));
                ddlYear.Value = DateTime.Now.Year.ToString();
            }

            if (HttpContext.Current.Session["CalendarYear"] != null)
            {
                var calendarYear = Convert.ToString(HttpContext.Current.Session["CalendarYear"]);

                ddlCalendarYear2.Value = calendarYear;
            }
            else
            {
                ddlCalendarYear2.Value = DateTime.Now.Year.ToString();
            }

            hiddenFieldCalendarYear.Value = ddlCalendarYear2.Value.ToString();

            LoadHolidayCalendars();
            LoadHolidayCalendarSchedule();
            LoadHolidays();
            bindgrid();
            gridViewHolidayCalendarSerch.FocusedRowIndex = -1;
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.None:
                case (int)FormMode.Display:
                    ddlHolidayCalendarNumber.Value = "0";
                    ddlHolidayCalendarName.Value = "0";

                    break;
            }

            //EnableDisableControls();

            if (ddlCalendarYear2.Value.ToString() == "0")
            {
                ddlCalendarYear2.Value = DateTime.Now.Year.ToString();
            }
            ddlCalendarYear2Old.ClientEnabled = false;
            //}
            //else
            //{
            //ZUTMain.RedirectToDashBoard();
            //}
        }

        #region Private Methods

        void ClearFields()
        {
            var calendarYear = DateTime.Now.Year;
            if (Convert.ToString(ddlCalendarYear2.Value) != "0")
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }

            gridViewHolidayCalendar.DataSource = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
            gridViewHolidayCalendar.DataBind();

            txtHolidayCalendarName.Text = string.Empty;
            txtMemo.Text = string.Empty;

            ddlHolidayCalendarNumber.Value = "0";
            ddlHolidayCalendarName.Value = "0";

            _selectedHolidays = new List<Holiday>();
            LoadHolidays();

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == (int)FormMode.Create)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "IncrementIdNumber", "IncrementIdNumber();", true);
                txtHolidayCalendarNumber.Text = NextNumber().ToString();
            }
            else
            {
                txtHolidayCalendarNumber.Text = string.Empty;
            }

            txtHolidayCalendarName.Focus();

            Session["HolidayCalendar"] = null;

            ClientScript.RegisterStartupScript(GetType(), "ResetHolidays", "ResetHolidays()", true);
        }

        void LoadHolidayCalendars()
        {
            var calendars = new List<HolidayCalendar>
            {
                new HolidayCalendar {Id = 0, HolidayCalendarNumber = 0, HolidayCalendarName = "keine"}
            };

            var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars();

            calendars.AddRange(holidayCalendars);

            ddlHolidayCalendarNumber.DataSource = calendars;
            ddlHolidayCalendarNumber.DataBind();

            ddlHolidayCalendarName.DataSource = calendars;
            ddlHolidayCalendarName.DataBind();

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == (int)FormMode.Refresh)
            {
                var lastSavedHolidayCalendar = holidayCalendars.OrderByDescending(h => h.Id).FirstOrDefault();
                Session["HolidayCalendar"] = lastSavedHolidayCalendar;

                if (lastSavedHolidayCalendar != null)
                {
                    hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();
                }
            }
        }

        protected void bindgrid()
        {
            var calendars = new List<HolidayCalendar>
            {
                new HolidayCalendar {Id = 0, HolidayCalendarNumber = 0, HolidayCalendarName = "keine"}
            };

            var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars();

            calendars.AddRange(holidayCalendars);


            gridViewHolidayCalendarSerch.DataSource = holidayCalendars;
            gridViewHolidayCalendarSerch.DataBind();

        }
        void LoadHolidayCalendarSchedule()
        {
            var calendarYear = DateTime.Now.Year;
            _selectedHolidays = new List<Holiday>();

            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }

            hiddenFieldCalendarYear.Value = calendarYear.ToString();

            List<HolidayCalendarScheduleViewModel> holidayCalendarSchedule;
            if (Session["HolidayCalendar"] == null)
            {
                holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
            }
            else
            {
                var holidayCalendar = (HolidayCalendar)Session["HolidayCalendar"];

                var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

                if (!(formMode == (int)FormMode.Create))
                {
                    //if(holidayCalendar.CalendarYear==0)holidayCalendar.CalendarYear=calendarYear;
                    txtHolidayCalendarName.Text = holidayCalendar.HolidayCalendarName;
                    txtHolidayCalendarNumber.Text = holidayCalendar.HolidayCalendarNumber.ToString();
                    txtMemo.Text = holidayCalendar.Memo;
                    ddlHolidayCalendarNumber.Value = holidayCalendar.Id.ToString();
                    ddlHolidayCalendarName.Value = holidayCalendar.Id.ToString();
                }



                ddlCalendarYear2.Value = holidayCalendar.CalendarYear.ToString();
                ddlCalendarYear2Old.Value = holidayCalendar.CalendarYear.ToString();
                hiddenFieldCalendarYear.Value = holidayCalendar.CalendarYear.ToString();

                holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(holidayCalendar, out _selectedHolidays);
                if ((holidayCalendarSchedule == null) || (holidayCalendarSchedule.Count == 0))
                {
                    holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
                }
            }

            gridViewHolidayCalendar.DataSource = holidayCalendarSchedule;
            gridViewHolidayCalendar.DataBind();
        }

        void LoadHolidays(string calendarType = null, int regionID = 0)
        {
            int selectedYear = DateTime.Now.Year;
            if (ddlCalendarYear2.SelectedItem != null)
                int.TryParse(ddlCalendarYear2.SelectedItem.Text, out selectedYear);
            if (ddlCalendarYear2Old.SelectedItem != null)
                int.TryParse(ddlCalendarYear2Old.SelectedItem.Text, out selectedYear);
            var holidaysInDatabase = new HolidayViewModel().GetHolidays();

            regionID = Convert.ToInt32(ddlRegionID.Value);
            if (regionID == 0)
            {
                holidaysInDatabase = holidaysInDatabase.Where(h => h.HolidayDate.Year == selectedYear).GroupBy(x => x.HolidayName).Select(group => group.First()).ToList();
            }
            else
            {
                holidaysInDatabase = holidaysInDatabase.Where(h => h.HolidayDate.Year == selectedYear && h.RegionID == regionID).ToList();
            }

            _allHolidays = holidaysInDatabase;
            if (!(string.IsNullOrEmpty(calendarType)))
            {
                switch (calendarType)
                {
                    case "ASS":
                        if (_selectedHolidays == null) _selectedHolidays = new List<Holiday>();
                        var lastAddedHoliday = holidaysInDatabase.OrderByDescending(h => h.Id).FirstOrDefault();

                        if (lastAddedHoliday != null)
                        {
                            _selectedHolidays.Add(lastAddedHoliday);
                        }
                        break;
                }
            }

            var holidayPlans = new List<HolidayPlan>();
            var holidayPlansAll = new List<HolidayPlan>();
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            foreach (var holiday in holidaysInDatabase)
            {
                bool isSelected = false;
                if (_selectedHolidays != null)
                {
                    var existingHolidayCalendarHoliday = _selectedHolidays.FirstOrDefault(h => h.Id == holiday.Id);
                    if (existingHolidayCalendarHoliday != null)
                    {
                        isSelected = true;
                    }
                }

                var holidayPlan = new HolidayPlan
                {
                    Id = holiday.Id,
                    HolidayName = holiday.HolidayName,
                    HolidayDate = holiday.HolidayDate,
                    IsSelected = isSelected
                };

                holidayPlans.Add(holidayPlan);
                holidayPlansAll.Add(holidayPlan);
                //switch (formMode)
                //{
                //    case (int)FormMode.Display:
                //    case (int)FormMode.Edit:
                //        if (Session["HolidayCalendar"] != null)
                //        {
                //            holidayPlansAll.Add(holidayPlan);
                //        }

                //        break;

                //    default:
                //        holidayPlansAll.Add(new HolidayPlan
                //        {
                //            Id = holiday.Id,
                //            HolidayName = holiday.HolidayName,
                //            HolidayDate = holiday.HolidayDate,
                //            IsSelected = false
                //        });

                //        break;
                //}

            }

            List<HolidayPlan> holidaysInCalendar;
            holidaysInCalendar = holidayPlans.Where(h => h.IsSelected).OrderBy(h => h.HolidayDate).ToList();
            //switch (formMode)
            //{
            //    case (int)FormMode.None:
            //    case (int)FormMode.Create:
            //        //holidaysInCalendar = holidayPlans.OrderBy(h => h.HolidayDate).ToList();
            //        holidaysInCalendar = new List<HolidayPlan>();
            //        break;

            //    default:
            //        holidaysInCalendar = holidayPlans.Where(h => h.IsSelected).OrderBy(h => h.HolidayDate).ToList();
            //        break;
            //}
            holidayPlansAll = holidayPlans;
            foreach (var holiday in holidayPlansAll)
            {
                var holidaySelected = holidaysInCalendar.Where(h => h.Id == holiday.Id).FirstOrDefault();
                holiday.IsSelected = holidaySelected != null ? holidaySelected.IsSelected : false;
            }
            if (Convert.ToInt64(ddlHolidayCalendarNumber.Value) < 1)
            {
                List<HolidayPlan> _holidayPlan = new List<HolidayPlan>();
                gridViewHolidaysInCalendar.DataSource = _holidayPlan;
                gridViewHolidaysInCalendar.DataBind();
                Session["HolidaysSelected"] = _holidayPlan;

            }
            else
            {
                gridViewHolidaysInCalendar.DataSource = holidaysInCalendar;
                gridViewHolidaysInCalendar.DataBind();
                Session["HolidaysSelected"] = holidaysInCalendar;
                if (holidaysInCalendar.Count() > 16)
                {
                    //gridViewHolidaysInCalendar.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                    //gridViewHolidaysInCalendar.Settings.VerticalScrollableHeight = 605;
                    gridViewHolidaysInCalendar.SettingsPager.PageSize = holidaysInCalendar.Count();
                }
            }
            gridViewHoliday.DataSource = holidayPlansAll.OrderBy(h => h.HolidayDate).ToList();
            gridViewHoliday.DataBind();
            Session["AllHolidays"] = holidayPlansAll.OrderBy(h => h.HolidayDate).ToList();
            if (holidayPlansAll.Count() > 16)
            {
                //gridViewHoliday.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
                //gridViewHoliday.Settings.VerticalScrollableHeight = 729;
                gridViewHoliday.SettingsPager.PageSize = holidayPlansAll.Count();
            }
        }

        void NewHolidayCalendar()
        {
            btnCalendarNew.Enabled = false;
            ddlCalendarYear2.Value = DateTime.Now.Year.ToString();
            ddlCalendarYear2Old.Value = DateTime.Now.Year.ToString();
            LoadHolidays();
            btnApply.Enabled = true;
            txtMemo.ReadOnly = false;
            btnCalendarSave.Enabled = true;
            btnCalendarDelete.Enabled = false;
            btnCopyCalendar.Enabled = true;
            ddlCalendarYear2Old.ClientEnabled = true;
            btnCalendarYearNext.Enabled = true;
            btnCalendarYearPrevious.Enabled = true;
            hiddenFieldDetectChanges.Value = "1";
            hiddenFieldFormMode.Value = ((int)FormMode.Create).ToString();
            ClearFields();

            Session["HolidayCalendar"] = new HolidayCalendar();
        }

        Holiday GetHoliday(DateTime currentDate)
        {
            if ((_selectedHolidays == null) || !(_selectedHolidays.Any()))
            {
                return null;
            }

            var holiday = _selectedHolidays.FirstOrDefault(p => p.HolidayDate.Date == currentDate.Date);
            return holiday;
        }

        #endregion Private Methods

        #region Button Event Handler Methods

        protected void btnCalendarNew_Click(object sender, EventArgs e)
        {
            NewHolidayCalendar();
        }

        #endregion Button Event Handler Methods

        #region Public Methods

        [WebMethod]
        public static bool CreateHoliday(Holiday holiday)
        {
            if (holiday == null) return false;

            if (string.IsNullOrEmpty(holiday.HolidayName)) return false;

            if (holiday.HolidayDate == DateTime.MinValue) return false;

            var existingHoliday = new HolidayViewModel().GetHolidayByNameByDate(holiday.HolidayName, holiday.HolidayDate);

            if (existingHoliday == null)
            {
                new HolidayViewModel().CreateHoliday(holiday);
            }

            return true;
        }

        [WebMethod]
        public static bool UpdateHoliday(Holiday holiday)
        {
            if (holiday == null) return false;

            if (string.IsNullOrEmpty(holiday.HolidayName)) return false;

            if (holiday.HolidayDate == DateTime.MinValue) return false;

            new HolidayViewModel().EditHoliday(holiday);

            return true;
        }

        [WebMethod]
        public static bool DeleteHoliday(long holidayId, int holidaySelection)
        {

            if (holidayId == 0) return false;

            var holidayViewModel = new HolidayViewModel();

            var holiday = holidayViewModel.GetHolidayById(holidayId);

            if (holiday == null) return false;
            var holidayName = holiday.HolidayName;
            var holidayDate = holiday.HolidayDate;
            var regionId = holiday.RegionID;
            new HolidayViewModel().DeleteHoliday(holiday);
            if (holidaySelection == 0)
            {
                var holidayList = new HolidayRepository().GetListHolidayByNameByDate(holidayName, holidayDate);
                foreach (var _holiday in holidayList)
                {
                    new HolidayViewModel().DeleteHoliday(_holiday);
                }
            }
            else if (holidaySelection > 0 && regionId != null)
            {
                var holidayList = new HolidayRepository().GetListHolidayByNameByDateByRegion(holidayName, holidayDate, Convert.ToInt64(regionId));
                foreach (var _holiday in holidayList)
                {
                    new HolidayViewModel().DeleteHoliday(_holiday);
                }
            }

            return true;
        }

        [WebMethod]
        public static void DeleteHolidayCalendar(long holidayCalendarId)
        {
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
            if (holidayCalendar == null) return;

            //var locationViewModel = new LocationViewModel();
            //var locations = locationViewModel.GetLocationsByHolidayCalendar(holidayCalendar.ID);
            //foreach (var location in locations)
            //{
            //    location.HolidayCalendarId = null;
            //    locationViewModel.EditLocation(location);
            //}

            new HolidayCalendarViewModel().DeleteHolidayCalendarMonths(holidayCalendar);
            new HolidayCalendarViewModel().DeleteHolidayCalendar(holidayCalendar);
        }

        [WebMethod]
        public static void UpdateHolidayCalenderSchedule(string jsonData, int calendarYear, List<Holiday> holidays)
        {
            if (jsonData == null) return;

            var holidayCalendarScheduleViewModels = JsonConvert.DeserializeObject<List<HolidayCalendarScheduleViewModel>>(jsonData);
            var holidayCalendarMonths = new List<HolidayCalendarMonth>();
            _selectedHolidays = holidays;
            foreach (var holidayViewModel in holidayCalendarScheduleViewModels)
            {
                var holidayCalendarMonth = new HolidayCalendarMonth
                {
                    CalendarMonth = holidayViewModel.Id
                };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var numberProperty = string.Format("Day{0}Holiday", dayOfMonth);
                    var numberPropertyInfo = holidayViewModel.GetType().GetProperty(numberProperty);

                    var holiday = numberPropertyInfo.GetValue(holidayViewModel).ToString().Trim();

                    long holidayId = 0;
                    if (!string.IsNullOrEmpty(holiday))
                    {
                        if (holiday.ToUpper() == "FT")
                        {
                            var daysDate = new DateTime(calendarYear, holidayCalendarMonth.CalendarMonth, dayOfMonth);
                            var todaysHoliday = new HolidayViewModel().GetHolidayByDate(daysDate);

                            if (todaysHoliday != null)
                            {
                                holidayId = todaysHoliday.Id;
                            }
                        }
                    }

                    var idProperty = string.Format("Day{0}HolidayId", dayOfMonth);
                    var idPropertyInfo = holidayCalendarMonth.GetType().GetProperty(idProperty);

                    idPropertyInfo.SetValue(holidayCalendarMonth, Convert.ChangeType(holidayId, idPropertyInfo.PropertyType), null);
                }

                holidayCalendarMonths.Add(holidayCalendarMonth);
            }

            var holidayCalendar = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"] ?? new HolidayCalendar();
            holidayCalendar.HolidayCalendarMonths = holidayCalendarMonths;

            HttpContext.Current.Session["HolidayCalendarMonths"] = holidayCalendarMonths;
            HttpContext.Current.Session["HolidayCalendar"] = holidayCalendar;
        }

        [WebMethod]
        public static void GetHolidayCalendarByYear(int calendarYear)
        {
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarByCalendarYear(calendarYear);

            HttpContext.Current.Session["CalendarYear"] = calendarYear;
            HttpContext.Current.Session["HolidayCalendar"] = holidayCalendar;
        }

        //[WebMethod]
        //public static bool CopyCalendar()
        //{
        //    var holidayCalendar = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"];

        //    if (holidayCalendar == null) return false;

        //    //copy the calendar to mapped
        //    var holidayPlanCalendarMappedViewModel = new HolidayPlanCalendarMappedViewModel();
        //    var existingHolidayPlanCalendarMapped = holidayPlanCalendarMappedViewModel.GetHolidayPlanCalendarByNumber(holidayCalendar.HolidayCalendarNumber);

        //    if (existingHolidayPlanCalendarMapped == null)
        //    {
        //        var holidayPlanCalendarMonthMappeds = CreateHolidayPlanCalendarMonthMappedFromTemplate(holidayCalendar);
        //        var holidayPlanCalendarMapped = new HolidayPlanCalendarMapped
        //        {
        //            HolidayPlanCalendarNumber = holidayCalendar.HolidayCalendarNumber,
        //            HolidayPlanCalendarName = holidayCalendar.HolidayCalendarName,
        //            CalendarYear = holidayCalendar.CalendarYear,
        //            Memo = holidayCalendar.Memo,
        //            HolidayPlanCalendarMonthMappeds = holidayPlanCalendarMonthMappeds
        //        };

        //        existingHolidayPlanCalendarMapped = holidayPlanCalendarMappedViewModel.CreateHolidayPlanCalendar(holidayPlanCalendarMapped);
        //    }

        //    if (existingHolidayPlanCalendarMapped == null) return false;

        //    //assign to AccessPlans
        //    var accessPlans = new AccessPlanViewModel().GetAccessPlansByHolidayCalendarYear(existingHolidayPlanCalendarMapped.CalendarYear);
        //    foreach (var accessPlan in accessPlans)
        //    {
        //        var accessPlanToEdit = new TbAccessPlan
        //        {
        //            ID = accessPlan.ID,
        //            AccessGroupID = accessPlan.AccessGroupID,
        //            AccessPlanNr = accessPlan.AccessPlanNr,
        //            AccessPlanDescription = accessPlan.AccessPlanDescription,
        //            AccessCalendarId = accessPlan.AccessCalendarId,
        //            BuildingPlanID = accessPlan.BuildingPlanID,
        //            HolidayPlanCalendarId = existingHolidayPlanCalendarMapped.Id
        //        };

        //        new AccessPlanViewModel().UpdateAccessPlan(accessPlanToEdit);
        //    }

        //    //assign to SwitchPlans
        //    var switchPlans = new SwitchPlanViewModel().GetSwitchPlansByHolidayCalendarYear(existingHolidayPlanCalendarMapped.CalendarYear);
        //    foreach (var switchPlan in switchPlans)
        //    {
        //        var switchPlanToEdit = new KruAll.Core.Models.SwitchPlan
        //        {
        //            Id = switchPlan.Id,
        //            SwitchPlanNumber = switchPlan.SwitchPlanNumber,
        //            SwitchPlanName = switchPlan.SwitchPlanName,
        //            SwitchCalendarId = switchPlan.SwitchCalendarId,
        //            BuidingPlanID = switchPlan.BuidingPlanID,
        //            HolidayPlanCalendarId = existingHolidayPlanCalendarMapped.Id
        //        };

        //        new SwitchPlanViewModel().EditSwitchPlan(switchPlanToEdit);
        //    }

        //    return true;
        //}

        //static List<HolidayPlanCalendarMonthMapped> CreateHolidayPlanCalendarMonthMappedFromTemplate(HolidayCalendar holidayCalendar)
        //{
        //    var holidayCalendarMonths = holidayCalendar.HolidayCalendarMonths;
        //    if ((holidayCalendarMonths != null) && (holidayCalendarMonths.Any()))
        //    {
        //        var holidayPlanCalendarMonthMappeds = new List<HolidayPlanCalendarMonthMapped>();

        //        foreach (var holidayPlanCalendarMonth in holidayCalendarMonths)
        //        {
        //            var holidayPlanCalendarMonthMapped = new HolidayPlanCalendarMonthMapped { CalendarMonth = holidayPlanCalendarMonth.CalendarMonth };

        //            for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
        //            {
        //                var templateFieldName = string.Format("Day{0}HolidayId", dayOfMonth);
        //                var propertyInfo = holidayPlanCalendarMonth.GetType().GetProperty(templateFieldName);

        //                var holidayId = (long)propertyInfo.GetValue(holidayPlanCalendarMonth);

        //                var mappedFieldName = string.Format("Day{0}ProfileHolidayId", dayOfMonth);

        //                string profileHolidayId = "0";
        //                if (holidayId > 0)
        //                {
        //                    profileHolidayId = string.Format("FT{0}", holidayId);
        //                }

        //                var idPropertyInfo = holidayPlanCalendarMonthMapped.GetType().GetProperty(mappedFieldName);
        //                idPropertyInfo.SetValue(holidayPlanCalendarMonthMapped, Convert.ChangeType(profileHolidayId, idPropertyInfo.PropertyType), null);
        //            }

        //            holidayPlanCalendarMonthMappeds.Add(holidayPlanCalendarMonthMapped);
        //        }

        //        HttpContext.Current.Session["HolidayPlanCalendarMonthMappeds"] = holidayPlanCalendarMonthMappeds;
        //        return holidayPlanCalendarMonthMappeds;
        //    }

        //    return null;
        //}

        [WebMethod]
        public static HolidayCalendar SaveHolidayCalendar(int formMode, int holidayCalendarNumber, string holidayCalendarName, int calendarYear, string memo)
        {
            if (holidayCalendarNumber == 0) return null;
            if (string.IsNullOrEmpty(holidayCalendarName)) return null;

            HolidayCalendar holidayCalendar = null;
            var holidayCalendarCurrent = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"];
            if (holidayCalendarCurrent != null)
            {
                if (holidayCalendarCurrent.Id == 0)
                {
                    formMode = (int)FormMode.Create;
                }
            }

            switch (formMode)
            {
                case (int)FormMode.Create:
                    var holidayCalendarNew = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"];
                    if (holidayCalendarNew != null)
                    {
                        holidayCalendarNew.CalendarYear = calendarYear;
                        holidayCalendarNew.HolidayCalendarNumber = holidayCalendarNumber;
                        holidayCalendarNew.HolidayCalendarName = holidayCalendarName;
                        holidayCalendarNew.Memo = memo;

                        holidayCalendar = new HolidayCalendarViewModel().CreateHolidayCalendar(holidayCalendarNew);
                    }

                    break;

                case (int)FormMode.Edit:


                    if (holidayCalendarCurrent != null)
                    {
                        var holidayCalendarToEdit = new HolidayCalendar
                        {
                            Id = holidayCalendarCurrent.Id,
                            CalendarYear = calendarYear,
                            HolidayCalendarNumber = holidayCalendarNumber,
                            HolidayCalendarName = holidayCalendarName,
                            Memo = memo,
                            HolidayCalendarMonths = null
                        };

                        List<HolidayCalendarMonth> holidayCalendarMonthsToEdit;
                        if (HttpContext.Current.Session["HolidayCalendarMonths"] != null)
                        {
                            holidayCalendarMonthsToEdit = (List<HolidayCalendarMonth>)HttpContext.Current.Session["HolidayCalendarMonths"];
                        }
                        else
                        {
                            holidayCalendarMonthsToEdit = holidayCalendarCurrent.HolidayCalendarMonths.ToList();
                        }

                        new HolidayCalendarViewModel().EditHolidayCalendar(holidayCalendarToEdit);
                        new HolidayCalendarViewModel().DeleteHolidayCalendarMonths(holidayCalendarToEdit);
                        new HolidayCalendarViewModel().CreateHolidayCalendarMonths(holidayCalendarCurrent.Id, holidayCalendarMonthsToEdit);

                        holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById((int)holidayCalendarCurrent.Id);
                    }

                    break;
            }

            HttpContext.Current.Session["HolidayCalendar"] = holidayCalendar;
            return holidayCalendar;
        }

        #endregion Public Methods

        #region GridView Methods

        protected void gridViewHoliday_OnDataBound(object sender, EventArgs e)
        {
            for (var i = 0; i < gridViewHoliday.VisibleRowCount; i++)
            {
                var isSelected = Convert.ToBoolean(gridViewHoliday.GetRowValues(i, "IsSelected"));
                gridViewHoliday.Selection.SetSelection(i, isSelected);
            }
        }

        protected void gridViewHolidaysInCalendar_OnDataBound(object sender, EventArgs e)
        {
            for (var i = 0; i < gridViewHolidaysInCalendar.VisibleRowCount; i++)
            {
                var isSelected = Convert.ToBoolean(gridViewHolidaysInCalendar.GetRowValues(i, "IsSelected"));
                gridViewHolidaysInCalendar.Selection.SetSelection(i, isSelected);
            }
        }

        protected void gridViewHoliday_OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            string calendarType = e.Parameters;
            LoadHolidays(calendarType);

            //var holidays = JsonConvert.SerializeObject(_selectedHolidays);
            var holidays = JsonConvert.SerializeObject(_allHolidays);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowNewHolidayInCalendar", "ShowNewHolidayInCalendar(" + holidays + ");", true);
        }

        protected void gridViewHolidaysInCalendar_OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadHolidays();

        }

        protected void gridViewHolidayCalendar_OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                var holidayCalendarId = Convert.ToInt64(e.Parameters);
                Session["HolidayCalendar"] = null;
                var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
                if (holidayCalendar != null)
                {
                    //_selectedHolidays = new List<Holiday>();
                    Session["HolidayCalendar"] = holidayCalendar;
                    LoadHolidayCalendarSchedule();
                }
                else
                {
                    var calendarYear = DateTime.Now.Year;
                    if (Convert.ToString(ddlCalendarYear2.Value) != "0")
                    {
                        calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
                    }
                    gridViewHolidayCalendar.DataSource = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
                    gridViewHolidayCalendar.DataBind();
                }
            }
        }

        protected void gridViewHolidayCalendar_OnHtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName.Length < 3) return;

            var holidayCalendar = (HolidayCalendar)Session["HolidayCalendar"];
            var calendarYear = DateTime.Now.Year;

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (holidayCalendar != null)
            {
                calendarYear = holidayCalendar.CalendarYear;
                //calendarYear = formMode == (int)FormMode.Create ? DateTime.Now.Year : holidayCalendar.CalendarYear;
                if (calendarYear == 0)
                {
                    calendarYear = DateTime.Now.Year;
                }
            }
            else
            {
                if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
                {
                    calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
                }
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

            var holidayName = string.Empty;
            Holiday todayIsHoliday = null;
            if (holidayCalendar != null)
            {
                if ((formMode != (int)FormMode.Create))
                {
                    todayIsHoliday = GetHoliday(daysDate);
                }

                if (todayIsHoliday != null)
                {
                    holidayName = todayIsHoliday.HolidayName;
                }
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
                    else
                    {
                        if (!(string.IsNullOrEmpty(holidayName)))
                        {
                            e.Cell.ToolTip = string.Format("{0}:{1}", daysDate.ToString("ddd"), holidayName);
                        }

                        e.Cell.BackColor = Color.FromArgb(255, 255, 0);
                        e.Cell.ForeColor = Color.FromArgb(255, 0, 0);
                    }

                    break;

                default:
                    if (todayIsHoliday != null)
                    {
                        e.Cell.BackColor = Color.FromArgb(255, 255, 0);
                        e.Cell.ForeColor = Color.FromArgb(255, 0, 0);

                        e.Cell.ToolTip = holidayName;
                    }

                    break;
            }

            if (daysDate == DateTime.MinValue)
            {
                e.Cell.BackColor = Color.Black;
            }
            else
            {
                if (todayIsHoliday == null)
                {
                    e.Cell.ToolTip = daysDate.ToString("ddd");
                }
            }
        }

        #endregion GridView Methods

        #region DropDownList Methods
        void DDLSelectedIndexChanged(string selectedValue)
        {
            ddlCalendarYear2Old.ClientEnabled = false;
            btnCalendarYearNext.Enabled = false;
            btnCalendarYearPrevious.Enabled = false;
            int selectedCalenderValue;
            if (int.TryParse(selectedValue, out selectedCalenderValue) && selectedCalenderValue != 0)
            {
                //btnApply.Enabled = true;
                //txtHolidayCalendarName.ReadOnly = false;
                //txtHolidayCalendarNumber.ReadOnly = false;
                //txtMemo.ReadOnly = false;
                //btnCalendarSave.Enabled = true;
                //btnCalendarDelete.Enabled = true;
                //btnCopyCalendar.Enabled = true;
            }
            else
            {
                //btnApply.Enabled = false;
                //txtHolidayCalendarName.ReadOnly = true;
                //txtHolidayCalendarNumber.ReadOnly = true;
                //txtMemo.ReadOnly = true;
                //btnCalendarSave.Enabled = false;
                //btnCalendarDelete.Enabled = false;
                //btnCopyCalendar.Enabled = false;
            }
        }
        #endregion DropDownList Methods

        protected void btnCalendarDelete_Click(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void DeleteHolidayCalendarCustom(long holidayCalendarId)
        {
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
            if (holidayCalendar == null) return;

            new HolidayCalendarViewModel().DeleteHolidayCalendarMonths(holidayCalendar);
            new HolidayCalendarViewModel().DeleteHolidayCalendar(holidayCalendar);
            _selectedHolidays = new List<Holiday>();
            HttpContext.Current.Session["HolidayCalendar"] = new HolidayCalendar();
            HttpContext.Current.Session["HolidayCalendarMonths"] = new List<HolidayCalendarMonth>();
        }

        [WebMethod]
        public static void DownloadHolidaysAndSaveInDatabase(string regionID, string selectedYear)
        {
            HolidayViewModel holidaysViewModel = new HolidayViewModel();

            List<Holiday> calendarHolidays = Controllers.RegionHolidaysDownload.GetAllHolidaysForRegionID(Convert.ToInt32(regionID),
                                                                                                          Convert.ToInt32(selectedYear));

            foreach (Holiday calendarHoliday in calendarHolidays)
            {
                holidaysViewModel.CreateHoliday(calendarHoliday);
            }
        }

        protected void btnDownloadHolidays_Click(object sender, EventArgs e)
        {
            HolidayViewModel holidaysViewModel = new HolidayViewModel();

            List<Holiday> calendarHolidays = Controllers.RegionHolidaysDownload.GetAllHolidaysForRegionID(Convert.ToInt32(drpCountry.SelectedValue),
                                                                                                          Convert.ToInt32(ddlYear.Value));

            foreach (Holiday calendarHoliday in calendarHolidays)
            {
                var holidayExists = new HolidayRepository().GetHolidayByNameByDate(calendarHoliday.HolidayName, calendarHoliday.HolidayDate);
                if (holidayExists == null)
                {
                    holidaysViewModel.CreateHoliday(calendarHoliday);
                }
            }

            LoadHolidays();

            showAlertMessage(Resources.LocalizedText.DownloadComplete);
        }

        private void showAlertMessage(string messageString)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showAlertMessage", "alert('" + messageString + "')", true);
        }

        protected void ddlRegionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string calendarType = null;

            LoadHolidays(calendarType, Convert.ToInt32(ddlRegionID.Value));
        }

        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }
        public static long NextNumber()
        {
            long num = 0;
            var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars();
            if (holidayCalendars.Count > 0)
            {
                var nr = holidayCalendars.Max(x => x.HolidayCalendarNumber);
                num = nr;
            }
            return num + 1;
        }
        [WebMethod]
        public static long SetControlsOnNew()
        {
            var NxtNo = NextNumber();
            _selectedHolidays = new List<Holiday>();
            HttpContext.Current.Session["HolidayCalendar"] = new HolidayCalendar();
            HttpContext.Current.Session["HolidayCalendarMonths"] = new List<HolidayCalendarMonth>();
            return NxtNo;
        }
        [WebMethod]
        public static long SaveHolidayCalendarCustom(long holidayCalendarID, long holidayCalendarNumber, string holidayCalendarName, int calendarYear, string memo)
        {
            HolidayCalendar holidayCalendar = null;
            var holidayCalendarCurrent = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"];

            if (holidayCalendarID == 0)
            {
                var holidayCalendarNew = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"];
                if (holidayCalendarNew != null)
                {
                    holidayCalendarNew.CalendarYear = calendarYear;
                    holidayCalendarNew.HolidayCalendarNumber = holidayCalendarNumber;
                    holidayCalendarNew.HolidayCalendarName = holidayCalendarName;
                    holidayCalendarNew.Memo = memo;

                    holidayCalendar = new HolidayCalendarViewModel().CreateHolidayCalendar(holidayCalendarNew);
                }
                else
                {
                    HolidayCalendar calendar = new HolidayCalendar()
                    {
                        CalendarYear = calendarYear,
                        HolidayCalendarNumber = holidayCalendarNumber,
                        HolidayCalendarName = holidayCalendarName,
                        Memo = memo,
                        //PEP_HolidayCalendarMonth = new List<PEP_HolidayCalendarMonth>(),
                    };
                    holidayCalendar = new HolidayCalendarViewModel().CreateHolidayCalendar(calendar);
                }
            }
            else if (holidayCalendarID > 0)
            {
                if (holidayCalendarCurrent != null)
                {
                    var holidayCalendarToEdit = new HolidayCalendar
                    {
                        Id = holidayCalendarCurrent.Id,
                        CalendarYear = calendarYear,
                        HolidayCalendarNumber = holidayCalendarNumber,
                        HolidayCalendarName = holidayCalendarName,
                        Memo = memo,
                        HolidayCalendarMonths = null
                    };

                    List<HolidayCalendarMonth> holidayCalendarMonthsToEdit;
                    if (HttpContext.Current.Session["HolidayCalendarMonths"] != null)
                    {
                        holidayCalendarMonthsToEdit = (List<HolidayCalendarMonth>)HttpContext.Current.Session["HolidayCalendarMonths"];
                    }
                    else
                    {
                        holidayCalendarMonthsToEdit = holidayCalendarCurrent.HolidayCalendarMonths.ToList();
                    }

                    new HolidayCalendarViewModel().EditHolidayCalendar(holidayCalendarToEdit);
                    new HolidayCalendarViewModel().DeleteHolidayCalendarMonths(holidayCalendarToEdit);
                    new HolidayCalendarViewModel().CreateHolidayCalendarMonths(holidayCalendarCurrent.Id, holidayCalendarMonthsToEdit);

                    holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById((int)holidayCalendarCurrent.Id);
                }
            }
            HttpContext.Current.Session["HolidayCalendar"] = holidayCalendar;
            return holidayCalendar.Id;
        }

        protected void ddlHolidayCalendarName_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                var calendars = new List<HolidayCalendar>
            {
                new HolidayCalendar {Id = 0, HolidayCalendarNumber = 0, HolidayCalendarName = "keine"}
            };
                var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars();
                calendars.AddRange(holidayCalendars);
                ddlHolidayCalendarName.DataSource = calendars;
                ddlHolidayCalendarName.DataBind();
                ddlHolidayCalendarName.Value = e.Parameter.ToString();
            }

        }

        protected void ddlHolidayCalendarNumber_Callback(object sender, CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                var calendars = new List<HolidayCalendar>
            {
                new HolidayCalendar {Id = 0, HolidayCalendarNumber = 0, HolidayCalendarName = "keine"}
            };
                var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars();
                calendars.AddRange(holidayCalendars);
                ddlHolidayCalendarNumber.DataSource = calendars;
                ddlHolidayCalendarNumber.DataBind();
                ddlHolidayCalendarNumber.Value = e.Parameter.ToString();
            }
        }
        [WebMethod]
        public static string GetHolidayMemo(long Id)
        {
            string memo = "";
            var holiday = new HolidayCalendarViewModel().GetHolidayCalendarById(Id);
            if (holiday != null)
            {
                memo = holiday.Memo;
            }
            return memo;
        }

        protected void gridViewHolidayCalendarSerch_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            bindgrid();
        }
        [WebMethod]
        public static HolidayCalendar_DTO GetCalendarById(long Id)
        {
            HolidayCalendar_DTO holidayDto = new HolidayCalendar_DTO();
            var holiday = new HolidayCalendarViewModel().GetHolidayCalendarById(Id);
            if (holiday != null)
            {
                holidayDto.ID = holiday.Id;
                holidayDto.CalendarYear = holiday.CalendarYear;
                holidayDto.memo = holiday.Memo;
            }
            return holidayDto;
        }
    }
}