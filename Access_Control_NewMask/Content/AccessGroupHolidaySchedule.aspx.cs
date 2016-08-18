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
using DevExpress.Web;
using Access_Control_NewMask.Dtos;
using System.Globalization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Color = System.Drawing.Color;

namespace Access_Control_NewMask.Content
{
    public partial class AccessGroupHolidaySchedule : BasePage
    {
        enum FormMode
        {
            None,
            Display,
            Create,
            Edit
        }

        private static List<HolidayPlan> _holidayPlans;
        private static List<Holiday> _calendarHolidays = new List<Holiday>();
        private static List<Holiday> _selectedHolidays;
        private static List<Holiday> _accessHolidays;
        static List<AccessGroup> listAccessGroups;
        static List<TbAccessPlanGroup> listAccessPlans;

        private static int _holidayPlanCalendarId;
        ZUTMain mainCtl = new ZUTMain();
        static accessControlPermissionModes accessControlPermissionMode = accessControlPermissionModes.Read;
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSaveHolidayPlan.UniqueID;

            if (!IsPostBack)
            {
                Session.Remove("HolidayCalendar");
                LoadAccessGroup();
                LoadAccessProfiles();
                ddlCalendarYear2.Items.Add(new ListEditItem("keine", "0"));

                for (var calendarYear = DateTime.Now.Year - 5; calendarYear < DateTime.Now.Year + 5; calendarYear++)
                {

                    ddlCalendarYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));
                }
                ddlCalendarYear2.Value = DateTime.Now.Year.ToString();

                LoadHolidayPlanCalenders();
                LoadHolidayCalendars();
                loadHolidaySchedule();
                loadExistingPlanHoliday();

            }
        }
        #region Private Methods

        void ClearFields()
        {
            var calendarYear = DateTime.Now.Year;
            //if (ddlCalendarYear.SelectedValue != "0")
            //{
            //    calendarYear = Convert.ToInt32(ddlCalendarYear.SelectedItem.Text);
            //}

            if (Convert.ToString(ddlCalendarYear2.Value) != "0")
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }

            gridViewHolidayPlanCalendar.DataSource = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
            gridViewHolidayPlanCalendar.DataBind();

            txtHolidayPlanCalendarName.Text = string.Empty;
            txtMemo.Text = string.Empty;

            hiddenFieldCalendarYear.Value = calendarYear.ToString();

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (formMode == (int)FormMode.Create)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "IncrementIdNumber", "IncrementIdNumber();", true);
            }
            else
            {
                txtHolidayPlanCalendarNumber.Text = string.Empty;
            }

            txtHolidayPlanCalendarName.Focus();
            ddlHolidayPlanCalendarNumber.Value = "0";
            ddlHolidayPlanCalendarName.Value = "0";

            ddlHolidayCalendarNumber.Value = "0";
            ddlHolidayCalendarName.Value = "0";

            var holidayPlans = new List<HolidayPlan>();

            gridViewHoliday.DataSource = holidayPlans;
            gridViewHoliday.DataBind();

            Session["HolidayPlanCalendar"] = null;
            Session["HolidayCalendar"] = null;
        }

        void LoadAccessProfiles()
        {
            var profiles = new List<ZuttritProfile>
            {
                 new ZuttritProfile {
                    ID = 0,
                    AccessProfileNo = 0,
                    AccessProfileID = "keine",
                    AccessDescription = "keine",
                    AccessGroup = new AccessGroup { AccessGroupName = "keine", AccessGroupNumber = 0 }
                }
                //new ZuttritProfile {ID = 0, AccessProfileNo = 0, AccessProfileID = "keine", AccessDescription = "keine"}
            };

            var accessProfiles = new ZuttritProfileViewModel().ZuttritProfiles();

            profiles.AddRange(accessProfiles);

            dplAccessProfileMemo.DataSource = profiles;
            dplAccessProfileMemo.DataBind();

            ddlAccessProfileNumber.DataSource = profiles;
            ddlAccessProfileNumber.DataBind();
            if (ddlAccessProfileName.Items.FindByValue("0") != null) ddlAccessProfileName.Value = "0";

            ddlAccessProfileName.DataSource = profiles;
            ddlAccessProfileName.DataBind();
            if (ddlAccessProfileNumber.Items.FindByValue("0") != null) ddlAccessProfileNumber.Value = "0";

            ddlAccessProfileIdNumber.DataSource = profiles;
            ddlAccessProfileIdNumber.DataBind();
            if (ddlAccessProfileIdNumber.Items.FindByValue("0") != null) ddlAccessProfileIdNumber.Value = "0";

            gridViewAccessProfileSearch.DataSource = profiles;
            gridViewAccessProfileSearch.DataBind();


            //if (profiles.Count <= 17)
            //{
            //    gridViewAccessProfileSearch.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
            //}
            //else
            //{
            //    gridViewAccessProfileSearch.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowAllRecords;
            //}

            Session["ZuttritProfiles"] = accessProfiles;

            if (Session["AccessProfile"] != null)
            {
                var accessProfile = (ZuttritProfile)Session["AccessProfile"];

                ddlAccessProfileNumber.Value = accessProfile.ID.ToString();
                ddlAccessProfileName.Value = accessProfile.ID.ToString();
                ddlAccessProfileIdNumber.Value = accessProfile.ID.ToString();
            }

            Session["AccessProfile"] = null;
        }
        void BindCalendarHolidays()
        {
            List<Holiday> _selectedHolidays2 = new List<Holiday>();
            var holidayCalendarId = Convert.ToInt32(ddlHolidayCalendarNumber.Value);

            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
            var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(holidayCalendar, out _selectedHolidays2);
            var existingHolidays = new HolidayViewModel().GetHolidays();
            var holidayPlans = new List<HolidayPlan>();
            foreach (var holiday in existingHolidays)
            {
                bool isSelected = false;
                bool accessProfile = false;
                if (_selectedHolidays2 != null)
                {
                    var existingHolidayCalendarHoliday = _selectedHolidays2.FirstOrDefault(h => h.Id == holiday.Id);
                    if (existingHolidayCalendarHoliday != null)
                    {
                        isSelected = true;
                    }
                }
                var holidayPlan = new HolidayPlan
                {
                    Id = holiday.Id,
                    HolidayDate = holiday.HolidayDate,
                    HolidayName = holiday.HolidayName,
                    IsSelected = isSelected,

                };

                holidayPlans.Add(holidayPlan);
            }
            List<HolidayPlan> holidaysInCalendar = new List<HolidayPlan>();
            holidaysInCalendar = holidayPlans.Where(h => h.IsSelected).OrderBy(h => h.HolidayDate).ToList();
            gridViewHoliday.DataSource = holidaysInCalendar;
            gridViewHoliday.DataBind();
            
        }

        void LoadHolidayCalendars()
        {
            var calendarYear = DateTime.Now.Year;

            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            var calendars = new List<HolidayCalendar>
            {
                new HolidayCalendar {Id = 0, HolidayCalendarNumber = 0, HolidayCalendarName = "keine"}
            };

            var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars().Where(h => h.CalendarYear == calendarYear);

            calendars.AddRange(holidayCalendars);

            ddlHolidayCalendarNumber.DataSource = calendars;
            ddlHolidayCalendarNumber.DataBind();
            if (ddlHolidayCalendarNumber.Items.FindByValue("0") != null) ddlHolidayCalendarNumber.Value = "0";

            ddlHolidayCalendarName.DataSource = calendars;
            ddlHolidayCalendarName.DataBind();
            if (ddlHolidayCalendarName.Items.FindByValue("0") != null) ddlHolidayCalendarName.Value = "0";
        }
        void LoadHolidayCalendars(long selectedId)
        {
            var calendars = new List<HolidayCalendar>
            {
                new HolidayCalendar {Id = 0, HolidayCalendarNumber = 0, HolidayCalendarName = "keine", CalendarYear= Convert.ToInt32( ddlCalendarYear2.Value)}
            };

            var holidayCalendars = new HolidayCalendarViewModel().GetHolidayCalendars();

            calendars.AddRange(holidayCalendars);
            var selectedYear = ddlCalendarYear2.Value;

            ddlHolidayCalendarNumber.DataSource = calendars.Where(x => x.CalendarYear == Convert.ToInt32(selectedYear));
            ddlHolidayCalendarNumber.DataBind();
            ddlHolidayCalendarNumber.Value = selectedId.ToString();


            ddlHolidayCalendarName.DataSource = calendars.Where(x => x.CalendarYear == Convert.ToInt32(selectedYear));
            ddlHolidayCalendarName.DataBind();
            ddlHolidayCalendarName.Value = selectedId.ToString();
        }
        void LoadHolidayPlanCalendars()
        {
            var calendars = new List<HolidayPlanCalendar>
            {
                new HolidayPlanCalendar {Id = 0, HolidayPlanCalendarNumber = 0, HolidayPlanCalendarName = "keine"}
            };

            var holidayPlanCalendars = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendars();

            calendars.AddRange(holidayPlanCalendars);

            ddlHolidayPlanCalendarNumber.DataSource = calendars;
            ddlHolidayPlanCalendarNumber.DataBind();
            ddlHolidayPlanCalendarNumber.SelectedIndex = 0;

            ddlHolidayPlanCalendarName.DataSource = calendars;
            ddlHolidayPlanCalendarName.DataBind();
            ddlHolidayPlanCalendarName.SelectedIndex = 0;
        }



        void NewHolidayPlanCalendar()
        {
            hiddenFieldFormMode.Value = ((int)FormMode.Create).ToString();
            ddlHolidayPlanCalendarNumber.ClientEnabled = false;
            ddlHolidayPlanCalendarName.ClientEnabled = false;

            ClearFields();
            LoadHolidayPlanCalenders();
            LoadAccessProfiles();
            LoadHolidayCalendars();
            chkDenyAccess.Checked = true;

            //Session["HolidayPlanCalendar"] = new HolidayPlanCalendar();
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

        #region Public Methods

        [WebMethod]
        public static void UpdateHolidayPlanCalenderSchedule(string jsonData, int calendarYear)
        {
            if (jsonData == null) return;

            var holidayPlanCalendarScheduleViewModels = JsonConvert.DeserializeObject<List<HolidayPlanCalendarScheduleViewModel>>(jsonData);
            var holidayPlanCalendarMonths = new List<HolidayPlanCalendarMonth>();

            foreach (var scheduleViewModel in holidayPlanCalendarScheduleViewModels)
            {
                var holidayPlanCalendarMonth = new HolidayPlanCalendarMonth
                {
                    CalendarMonth = scheduleViewModel.Id
                };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var numberProperty = string.Format("Day{0}ProfileHoliday", dayOfMonth);
                    var numberPropertyInfo = scheduleViewModel.GetType().GetProperty(numberProperty);

                    var profileHolidayId = "0";

                    var profileHoliday = numberPropertyInfo.GetValue(scheduleViewModel).ToString();
                    if (!(string.IsNullOrEmpty(profileHoliday)))
                    {
                        if (profileHoliday.ToUpper() == "FT")
                        {
                            var daysDate = new DateTime(calendarYear, holidayPlanCalendarMonth.CalendarMonth, dayOfMonth);
                            var todaysHoliday = new HolidayViewModel().GetHolidayByDate(daysDate);

                            if (todaysHoliday != null)
                            {
                                profileHolidayId = string.Format("FT{0}", todaysHoliday.Id);
                            }
                        }
                        else
                        {
                            var accessProfile =
                                new ZuttritProfileViewModel().GetZuttritProfileByAccessProfileId(profileHoliday);
                            if (accessProfile != null)
                            {
                                profileHolidayId = string.Format("PR{0}", accessProfile.ID);
                            }
                        }
                    }

                    var idProperty = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                    var idPropertyInfo = holidayPlanCalendarMonth.GetType().GetProperty(idProperty);

                    idPropertyInfo.SetValue(holidayPlanCalendarMonth, Convert.ChangeType(profileHolidayId, idPropertyInfo.PropertyType), null);
                }

                holidayPlanCalendarMonths.Add(holidayPlanCalendarMonth);
            }

            var holidayPlanCalendar = (HolidayPlanCalendar)HttpContext.Current.Session["HolidayPlanCalendar"] ?? new HolidayPlanCalendar();
            holidayPlanCalendar.HolidayPlanCalendarMonths = holidayPlanCalendarMonths;

            HttpContext.Current.Session["HolidayPlanCalendar"] = holidayPlanCalendar;
        }

        List<HolidayPlanCalendarMonthMapped> CreateHolidayPlanCalendarMonthMappedFromTemplate(HolidayPlanCalendar holidayPlanCalendar)
        {
            var holidayPlanCalendarMonths = holidayPlanCalendar.HolidayPlanCalendarMonths;
            if ((holidayPlanCalendarMonths != null) && (holidayPlanCalendarMonths.Any()))
            {
                var holidayPlanCalendarMonthMappeds = new List<HolidayPlanCalendarMonthMapped>();

                foreach (var holidayPlanCalendarMonth in holidayPlanCalendarMonths)
                {
                    var holidayPlanCalendarMonthMapped = new HolidayPlanCalendarMonthMapped { CalendarMonth = holidayPlanCalendarMonth.CalendarMonth };

                    for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                    {
                        var propertyFieldName = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                        var propertyInfo = holidayPlanCalendarMonth.GetType().GetProperty(propertyFieldName);

                        var profileHolidayId = propertyInfo.GetValue(holidayPlanCalendarMonth).ToString();

                        var idPropertyInfo = holidayPlanCalendarMonthMapped.GetType().GetProperty(propertyFieldName);
                        idPropertyInfo.SetValue(holidayPlanCalendarMonthMapped, Convert.ChangeType(profileHolidayId, idPropertyInfo.PropertyType), null);
                    }

                    holidayPlanCalendarMonthMappeds.Add(holidayPlanCalendarMonthMapped);
                }

                Session["HolidayPlanCalendarMonthMappeds"] = holidayPlanCalendarMonthMappeds;
                return holidayPlanCalendarMonthMappeds;
            }

            return null;
        }

        #endregion Public Methods

        #region Button Event Handler Methods

        protected void btnNewAccessProfile_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["profileId"];
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            Session["AccessPlanFormMode"] = formMode;
            Session["AccessPlanAction"] = "New";
            var ent = "6";
            Response.Redirect(String.Format("/Content/AccessProfile.aspx?profileId={0}&ent={1}", profileId, ent));
        }
        protected void btnNewHolidayPlan_Click(object sender, EventArgs e)
        {
            NewHolidayPlanCalendar();
        }
        static void MapHolidayPlanCalendar(HolidayPlanCalendar holidayPlanCalendar, long accessGroupId)
        {
            if (holidayPlanCalendar == null) return;
            var accessPlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(accessGroupId);

            if (accessPlanGroup == null) return;

            var holidayPlanCalendarMapped = new HolidayPlanCalendarMappedViewModel().GetHolidayPlanCalendarByNumber(holidayPlanCalendar.HolidayPlanCalendarNumber);

            if (holidayPlanCalendarMapped == null)
            {
                holidayPlanCalendarMapped = HolidayPlanCalendarMappedViewModel.SaveHolidayPlanCalendarFromTemplate(holidayPlanCalendar);
            }

            if (holidayPlanCalendarMapped == null) return;

            var accessPlanGroupToEdit = new TbAccessPlanGroup
            {
                ID = accessPlanGroup.ID,
                AccessPlanGroupNr = accessPlanGroup.AccessPlanGroupNr,
                AccessPlanGroupName = accessPlanGroup.AccessPlanGroupName,
                AccessCalendarId = accessPlanGroup.AccessCalendarId,
                BuildingPlanID = accessPlanGroup.BuildingPlanID,
                HolidayPlanCalendarId = holidayPlanCalendarMapped.Id
            };

            new AccessPlanGroupRepository().EditAccessPlanGroup(accessPlanGroupToEdit);
        }
        void DisplayHolidayPlanCalendar()
        {
            if (string.IsNullOrEmpty(Request.QueryString["profileId"]))
            {
                return;
            }

            var accessGroupId = Convert.ToInt64(Request.QueryString["profileId"]);
            var accessPlanGroup = new AccessPlanGroupRepository().GetAccessPlanGroupById(accessGroupId);

            if (accessPlanGroup == null) return;

            if (!accessPlanGroup.HolidayPlanCalendarId.HasValue) return;

            _holidayPlanCalendarId = (int)accessPlanGroup.HolidayPlanCalendarId.Value;
            var holidayPlanCalendarMapped = new HolidayPlanCalendarMappedViewModel().GetHolidayPlanCalendarById(_holidayPlanCalendarId);
            Session["HolidayPlanCalendarMapped"] = holidayPlanCalendarMapped;

            LoadHolidayPlanCalendarMapped(holidayPlanCalendarMapped);

            hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();

            txtHolidayPlanCalendarNumber.Text = holidayPlanCalendarMapped.HolidayPlanCalendarNumber.ToString();
            txtHolidayPlanCalendarName.Text = holidayPlanCalendarMapped.HolidayPlanCalendarName;
            txtMemo.Text = holidayPlanCalendarMapped.Memo;

            var existingHolidays = new HolidayViewModel().GetHolidays();

            //for HolidayPlanCalendarMapped
            _holidayPlans = new List<HolidayPlan>();

            foreach (var holidayPlanCalendarHoliday in _selectedHolidays)
            {
                var holiday = existingHolidays.FirstOrDefault(h => h.Id == holidayPlanCalendarHoliday.Id);

                if (holiday != null)
                {
                    var holidayPlan = new HolidayPlan
                    {
                        Id = holiday.Id,
                        HolidayDate = holiday.HolidayDate,
                        HolidayName = holiday.HolidayName,
                        IsSelected = true
                    };

                    _holidayPlans.Add(holidayPlan);
                }
            }

            BindCalendarHolidays();
        }

        public void LoadHolidayPlanCalendarMapped(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            List<HolidayPlanCalendarScheduleViewModel> holidayPlanCalendarScheduleViewModel;

            var holidayPlanCalendarMappedViewModel = new HolidayPlanCalendarMappedViewModel();

            if (holidayPlanCalendarMapped == null)
            {
                int calendarYear = DateTime.Now.Year;
                if (ddlCalendarYear.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlCalendarYear.SelectedItem.Text);
                }

                if (ddlCalendarYear2.SelectedItem != null)
                {
                    calendarYear = Convert.ToInt32(ddlCalendarYear2.SelectedItem.Text);
                }

                holidayPlanCalendarScheduleViewModel = holidayPlanCalendarMappedViewModel.GetHolidayPlanCalendarSchedule(calendarYear);
            }
            else
            {
                holidayPlanCalendarScheduleViewModel = holidayPlanCalendarMappedViewModel.GetHolidayPlanCalendarSchedule(holidayPlanCalendarMapped, out _selectedHolidays);
            }

            gridViewHolidayPlanCalendar.DataSource = holidayPlanCalendarScheduleViewModel;
            gridViewHolidayPlanCalendar.DataBind();
        }

        #endregion Button Event Handler Methods

        #region GridView Methods

        protected void gridViewHoliday_OnDataBound(object sender, EventArgs e)
        {
            //for (var i = 0; i < gridViewHoliday.VisibleRowCount; i++)
            //{
            //    var isSelected = Convert.ToBoolean(gridViewHoliday.GetRowValues(i, "IsSelected"));
            //    gridViewHoliday.Selection.SetSelection(i, isSelected);
            //}
        }

        protected void gridViewHolidayPlanCalendar_OnHtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName.Length < 3) return;
            if (e.DataColumn.FieldName.Substring(0, 3) != "Day")
            {
                e.Cell.Attributes.Add("CellType", "MonthName");
            }
            else
            {
                e.Cell.Attributes.Add("CellType", "Day");
            }

            e.Cell.Attributes.Add("ondblclick", string.Format("OnCellClick(this, {0});", e.VisibleIndex));

            var holidayCalendar = (HolidayCalendar)Session["HolidayCalendar"];
            var calendarYear = DateTime.Now.Year;

            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            if (holidayCalendar != null)
            {
                calendarYear = holidayCalendar.CalendarYear;
                // calendarYear = formMode == (int)FormMode.Create ? DateTime.Now.Year : holidayCalendar.CalendarYear;
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
                todayIsHoliday = GetHoliday(daysDate);
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

        protected void gridViewHoliday_OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            //if (string.IsNullOrEmpty(e.Parameters)) return;
            bindHolidaysOnly();

        }

        #endregion GridView Methods

        #region DropDownList Methods

        protected void ddlHolidayPlanCalendarNumber_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHolidayPlanCalendarNumber.Value == null) return;

            var holidayPlanCalendarId = Convert.ToInt32(ddlHolidayPlanCalendarNumber.Value);

            ddlHolidayPlanCalendarName.Value = holidayPlanCalendarId.ToString();
            ddlHolidayPlanCalendarNumber.Value = holidayPlanCalendarId.ToString();

            if (holidayPlanCalendarId == 0)
            {
                ddlCalendarYear2.Value = DateTime.Now.Year;
                ClearFields();
                LoadHolidayCalendars();
                btnDeleteHolidayPlan.Enabled = false;
                txtHolidayPlanCalendarNumber.Text = ddlHolidayPlanCalendarNumber.Text;
                txtHolidayPlanCalendarName.Text = ddlHolidayPlanCalendarName.Text;
                return;
            }

            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(holidayPlanCalendarId);
            ddlCalendarYear2.Value = holidayPlanCalendar.CalendarYear.ToString();
            LoadHolidayCalendars();
            ddlHolidayCalendarNumber.Value = holidayPlanCalendar.HolidayCalenderId.ToString();
            ddlHolidayCalendarName.Value = holidayPlanCalendar.HolidayCalenderId.ToString();
            txtHolidayPlanCalendarNumber.Text = holidayPlanCalendar.HolidayPlanCalendarNumber.ToString();
            txtHolidayPlanCalendarName.Text = holidayPlanCalendar.HolidayPlanCalendarName;
            var access = holidayPlanCalendar.AllowAccess;
            if (access == 1)
            {
                chkAllowAccess.Checked = true;
                chkDenyAccess.Checked = false;
            }
            else
            {
                chkDenyAccess.Checked = true;
                chkAllowAccess.Checked = false;
            }
            bindHolidays();
            HttpContext.Current.Session["HolidayPlanAccessProfile"] = null;
            LoadAccessProfiles();
            //btnDeleteHolidayPlan.Enabled = accessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;
        }

        protected void ddlHolidayPlanCalendarName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHolidayPlanCalendarName.Value == null) return;

            var holidayPlanCalendarId = Convert.ToInt32(ddlHolidayPlanCalendarName.Value);

            ddlHolidayPlanCalendarName.Value = holidayPlanCalendarId.ToString();
            ddlHolidayPlanCalendarNumber.Value = holidayPlanCalendarId.ToString();

            if (holidayPlanCalendarId == 0)
            {
                ddlCalendarYear2.Value = DateTime.Now.Year;
                ClearFields();
                LoadHolidayCalendars();
                txtHolidayPlanCalendarNumber.Text = ddlHolidayPlanCalendarNumber.Text;
                txtHolidayPlanCalendarName.Text = ddlHolidayPlanCalendarName.Text;
                btnDeleteHolidayPlan.Enabled = false;
                return;
            }

            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(holidayPlanCalendarId);
            ddlHolidayCalendarNumber.Value = holidayPlanCalendar.HolidayCalenderId.ToString();
            ddlHolidayCalendarName.Value = holidayPlanCalendar.HolidayCalenderId.ToString();
            txtHolidayPlanCalendarNumber.Text = holidayPlanCalendar.HolidayPlanCalendarNumber.ToString();
            txtHolidayPlanCalendarName.Text = holidayPlanCalendar.HolidayPlanCalendarName;
            var access = holidayPlanCalendar.AllowAccess;
            if (access == 1)
            {
                chkAllowAccess.Checked = true;
                chkDenyAccess.Checked = false;
            }
            else
            {
                chkDenyAccess.Checked = true;
                chkAllowAccess.Checked = false;
            }
            bindHolidays();
            HttpContext.Current.Session["HolidayPlanAccessProfile"] = null;
            LoadAccessProfiles();
            //btnDeleteHolidayPlan.Enabled = accessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;
        }

        #endregion DropDownList Methods

        [System.Web.Services.WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        #region get passed data
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
                txtAccessGroupNumber.Text = accessGroup.AccessPlanGroupNr.ToString();
                txtAccessGroupName.Text = accessGroup.AccessPlanGroupName;
                txtAccessGroupId.Text = accessGroup.ID.ToString();
                Session["_AccessPlanGroupId"] = id;
            }
        }

        public void LoadExistingGroups(ref List<AccessGroup> listAccessGroups)
        {
            AccessGroupRepository accessGroups = new AccessGroupRepository();
            listAccessGroups.AddRange(accessGroups.GetAllAccessPlanAccessGroups().Where(x => x.AccessGroupType == 2));
        }

        

      

      

        #endregion passed data

        
        protected void loadHolidaySchedule()
        {
            var calendarYear = DateTime.Now.Year;
            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }

            List<HolidayCalendarScheduleViewModel> holidayPlanCalendarSchedule;

            holidayPlanCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);

            gridViewHolidayPlanCalendar.DataSource = holidayPlanCalendarSchedule;
            gridViewHolidayPlanCalendar.DataBind();
        }
        protected void LoadHolidayPlanCalenders()
        {
            List<HolidayPlanCalendar> listHolidayPlan = new List<HolidayPlanCalendar>();
            HolidayPlanCalendar holidayPlan = new HolidayPlanCalendar() { Id = 0, HolidayPlanCalendarNumber = 0, HolidayPlanCalendarName = "keine" };
            listHolidayPlan.Add(holidayPlan);
            var holidayCalendars = new HolidayScheduleViewModel().HolidayPlans();
            listHolidayPlan.AddRange(holidayCalendars);
            ddlHolidayPlanCalendarNumber.DataSource = listHolidayPlan;
            ddlHolidayPlanCalendarNumber.DataBind();
            ddlHolidayPlanCalendarNumber.SelectedIndex = 0;
            ddlHolidayPlanCalendarName.DataSource = listHolidayPlan;
            ddlHolidayPlanCalendarName.DataBind();
            ddlHolidayPlanCalendarName.SelectedIndex = 0;

        }
        protected void bindHolidays()
        {

            var calendarYear = DateTime.Now.Year;
            List<Holiday> _selectedHolidays2 = new List<Holiday>();


            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            var holidayCalendarId = Convert.ToInt64(ddlHolidayCalendarNumber.Value);
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
            var holidayPLanCalendarId = Convert.ToInt64(ddlHolidayPlanCalendarNumber.Value);
            var holidayPlanCalendar = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarById2(holidayPLanCalendarId);
            if (holidayPlanCalendar != null && holidayCalendar != null)
            {
                if (holidayPlanCalendar.HolidayCalenderId != holidayCalendar.Id)
                {
                    holidayPlanCalendar.HolidayPlanCalendarMonths = null;
                }
            }

            Session["HolidayCalendar"] = holidayCalendar;
            //var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(holidayCalendar, out _selectedHolidays2);
            var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarScheduleWithAccessProfiles(holidayCalendar, holidayPlanCalendar, out _selectedHolidays2, out _accessHolidays);
            _selectedHolidays = new List<Holiday>();
            _selectedHolidays = _selectedHolidays2;

            var existingHolidays = new HolidayViewModel().GetHolidays();
            var holidayPlans = new List<HolidayPlan>();
            foreach (var holiday in existingHolidays)
            {
                bool isSelected = false;
                bool accessProfile = false;
                if (_selectedHolidays2 != null)
                {
                    var existingHolidayCalendarHoliday = _selectedHolidays2.FirstOrDefault(h => h.Id == holiday.Id);
                    if (existingHolidayCalendarHoliday != null)
                    {
                        isSelected = true;
                    }
                }
                var holidayPlan = new HolidayPlan
                {
                    Id = holiday.Id,
                    HolidayDate = holiday.HolidayDate,
                    HolidayName = holiday.HolidayName,
                    IsSelected = isSelected,
                    AccessProfile = accessProfile
                };

                holidayPlans.Add(holidayPlan);
            }
            List<HolidayPlan> holidaysInCalendar = new List<HolidayPlan>();
            holidaysInCalendar = holidayPlans.Where(h => h.IsSelected && h.HolidayDate.Year == calendarYear).OrderBy(h => h.HolidayDate).ToList();
            gridViewHoliday.DataSource = holidaysInCalendar;
            gridViewHoliday.DataBind();
            if ((holidayCalendarSchedule == null) || (holidayCalendarSchedule.Count == 0))
            {
                holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
                Session["HolidayCalendar"] = null;
            }
            gridViewHolidayPlanCalendar.DataSource = holidayCalendarSchedule;
            gridViewHolidayPlanCalendar.DataBind();

        }
       
        protected static void SaveAccessPlanHoliday(long accessPLanGroupId, long holidayPlanId)
        {
           
            AccessPlanGroupRepository accessPlanRep = new AccessPlanGroupRepository();
            TbAccessPlanGroup accessPlanGroup2 = new TbAccessPlanGroup();
            accessPlanGroup2 = accessPlanRep.GetAccessPlanGroupById(accessPLanGroupId);
            TbAccessPlanGroup accessPlanGroup = new TbAccessPlanGroup()
            {
                ID = accessPLanGroupId,
                AccessPlanGroupNr = accessPlanGroup2.AccessPlanGroupNr,
                AccessPlanGroupName = accessPlanGroup2.AccessPlanGroupName,
                AccessCalendarId = accessPlanGroup2.AccessCalendarId,
                BuildingPlanID = accessPlanGroup2.BuildingPlanID,
                HolidayPlanCalendarId = holidayPlanId
            };
            new AccessPlanGroupRepository().EditAccessPlanGroup(accessPlanGroup);

        }
        protected void loadExistingPlanHoliday()
        {
            if (string.IsNullOrEmpty(Request.QueryString["profileId"]))
            {
                return;
            }
            var accessGroupId = Convert.ToInt64(Request.QueryString["profileId"]);
            AccessPlanGroupRepository accessPlanRepGroup = new AccessPlanGroupRepository();
            TbAccessPlanGroup accessPlanGroup = new TbAccessPlanGroup();
            accessPlanGroup = accessPlanRepGroup.GetAccessPlanGroupById(accessGroupId);
            if (accessPlanGroup.HolidayPlanCalendarId != null)
            {
                var holidayCalenderId = Convert.ToInt64(accessPlanGroup.HolidayPlanCalendarId);
                HolidayPlanCalendar holidayPlan = new HolidayPlanCalendar();

                var holidayCalendars = new HolidayScheduleViewModel().GetHolidayPlanByID(holidayCalenderId);
                ddlHolidayPlanCalendarNumber.Value = holidayCalenderId.ToString();
                ddlHolidayPlanCalendarName.Value = holidayCalenderId.ToString();

                ddlHolidayCalendarNumber.Value = holidayCalendars.HolidayCalenderId.ToString();
                ddlHolidayCalendarName.Value = holidayCalendars.HolidayCalenderId.ToString();
                txtHolidayPlanCalendarNumber.Text = holidayCalendars.HolidayPlanCalendarNumber.ToString();
                txtHolidayPlanCalendarName.Text = holidayCalendars.HolidayPlanCalendarName;
                txtMemo.Text = holidayCalendars.Memo;
                var access = holidayCalendars.AllowAccess;
                if (access == 1)
                {
                    chkAllowAccess.Checked = true;
                    chkDenyAccess.Checked = false;
                }
                else
                {
                    chkDenyAccess.Checked = true;
                    chkAllowAccess.Checked = false;
                }
                bindHolidays();
                HttpContext.Current.Session["HolidayPlanAccessProfile"] = null;
            }
            else
            {
                txtHolidayPlanCalendarNumber.Text = ddlHolidayPlanCalendarNumber.Text;
                txtHolidayPlanCalendarName.Text = ddlHolidayPlanCalendarName.Text;
            }
        }
        [WebMethod]
        public static List<AccessProfileDto> AccessProfileList(long holidayPlanId)
        {
            List<AccessProfileDto> accessProfiles = new List<AccessProfileDto>();
            var holidayPLanCalendarId = Convert.ToInt64(holidayPlanId);
            var holidayPlanCalendar = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarById2(holidayPLanCalendarId);
            var _accessProfiles = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarScheduleAccessProfiles(holidayPlanCalendar, out accessProfiles);
            return accessProfiles;
        }
        [WebMethod]
        public static void UpdateHolidayPlanAccessProfileMonth(string jsonData)
        {
            if (jsonData == null) return;

            var holidayPlanAccessleViewModels = JsonConvert.DeserializeObject<List<HolidayPlanAccessProfileMonthViewModel>>(jsonData);
            var accessCalendarMonths = new List<HolidayPlanAccessProfileMonth>();

            foreach (var scheduleViewModel in holidayPlanAccessleViewModels)
            {
                var accessCalendarMonth = new HolidayPlanAccessProfileMonth
                {
                    CalendarMonth = Convert.ToInt32(scheduleViewModel.ID)
                };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var numberProperty = string.Format("Day{0}AccessProfileId", dayOfMonth);
                    var numberPropertyInfo = scheduleViewModel.GetType().GetProperty(numberProperty);

                    var accessProfile = new ZuttritProfileViewModel().GetZuttritProfileByAccessProfileId(numberPropertyInfo.GetValue(scheduleViewModel).ToString());

                    var idProperty = string.Format("Day{0}AccessProfileId", dayOfMonth);
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

            var accessProfileCalendar = (HolidayPlanCalendar)HttpContext.Current.Session["HolidayPlanAccessProfile"] ?? new HolidayPlanCalendar();
            accessProfileCalendar.HolidayPlanAccessProfileMonths = accessCalendarMonths;

            HttpContext.Current.Session["HolidayPlanAccessProfile"] = accessProfileCalendar;
        }

        protected void ddlHolidayCalendarNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedHoliday = Convert.ToInt64(ddlHolidayCalendarNumber.Value);
            LoadHolidayCalendars(selectedHoliday);
            //ddlHolidayCalendarName.Value = selectedHoliday.ToString();
            if (selectedHoliday == 0)
            {
                //ClearCalender();
                ClearCalenderValues();
                return;
            }
            bindHolidays();
            LoadAccessProfiles();
        }

        protected void ddlHolidayCalendarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedHoliday = Convert.ToInt64(ddlHolidayCalendarName.Value);
            LoadHolidayCalendars(selectedHoliday);
            //ddlHolidayCalendarName.Value = selectedHoliday.ToString();
            if (selectedHoliday == 0)
            {
                //ClearCalender();
                ClearCalenderValues();
                return;
            }
            bindHolidays();
            LoadAccessProfiles();
        }
        protected void ClearCalender()
        {
            var calendarYear = DateTime.Now.Year;
            if (Convert.ToString(ddlCalendarYear2.Value) != "0")
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            gridViewHolidayPlanCalendar.DataSource = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
            gridViewHolidayPlanCalendar.DataBind();
        }
        void ClearCalenderValues()
        {
            var calendarYear = DateTime.Now.Year;
            if (Convert.ToString(ddlCalendarYear2.Value) != "0")
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            gridViewHolidayPlanCalendar.DataSource = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
            gridViewHolidayPlanCalendar.DataBind();

            var holidayPlans = new List<HolidayPlan>();

            gridViewHoliday.DataSource = holidayPlans;
            gridViewHoliday.DataBind();


            Session["HolidayPlanAccessProfile"] = null;
            Session["HolidayCalendar"] = null;

        }
        protected void btnInformation_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Content/AccessPlanGroup.aspx");
        }
        protected void bindHolidaysOnly()
        {
            var calendarYear = DateTime.Now.Year;
            List<Holiday> _selectedHolidays2 = new List<Holiday>();

            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            var holidayCalendarId = Convert.ToInt64(ddlHolidayCalendarNumber.Value);
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
            var holidayPLanCalendarId = Convert.ToInt64(ddlHolidayPlanCalendarNumber.Value);
            var holidayPlanCalendar = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarById2(holidayPLanCalendarId);
            //var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(holidayCalendar, out _selectedHolidays2);
            var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarScheduleWithAccessProfiles(holidayCalendar, holidayPlanCalendar, out _selectedHolidays2, out _accessHolidays);
            _selectedHolidays = new List<Holiday>();
            _selectedHolidays = _selectedHolidays2;

            var existingHolidays = new HolidayViewModel().GetHolidays();
            var holidayPlans = new List<HolidayPlan>();
            foreach (var holiday in existingHolidays)
            {
                bool isSelected = false;
                bool accessProfile = false;
                if (_selectedHolidays2 != null)
                {
                    var existingHolidayCalendarHoliday = _selectedHolidays2.FirstOrDefault(h => h.Id == holiday.Id);
                    if (existingHolidayCalendarHoliday != null)
                    {
                        isSelected = true;
                    }
                }
                //if (_accessHolidays != null)
                //{
                //    var existingAccssProfile = _accessHolidays.FirstOrDefault(h => h.Id == holiday.Id);
                //    if (existingAccssProfile != null)
                //    {
                //        accessProfile = true;
                //    }
                //}
                var holidayPlan = new HolidayPlan
                {
                    Id = holiday.Id,
                    HolidayDate = holiday.HolidayDate,
                    HolidayName = holiday.HolidayName,
                    IsSelected = isSelected,
                    AccessProfile = accessProfile
                };

                holidayPlans.Add(holidayPlan);
            }
            List<HolidayPlan> holidaysInCalendar = new List<HolidayPlan>();
            holidaysInCalendar = holidayPlans.Where(h => h.IsSelected).OrderBy(h => h.HolidayDate).ToList();
            gridViewHoliday.DataSource = holidaysInCalendar;
            gridViewHoliday.DataBind();
        }
        protected void ReloadPage()
        {
            Session.Remove("HolidayCalendar");
            LoadAccessProfiles();
            ddlCalendarYear2.Items.Add(new ListEditItem("keine", "0"));

            for (var calendarYear = DateTime.Now.Year - 5; calendarYear < DateTime.Now.Year + 5; calendarYear++)
            {

                ddlCalendarYear2.Items.Add(new ListEditItem(calendarYear.ToString(), calendarYear.ToString()));
            }
            ddlCalendarYear2.Value = DateTime.Now.Year.ToString();

            LoadHolidayPlanCalenders();
            LoadHolidayCalendars();
            loadHolidaySchedule();
            txtHolidayPlanCalendarNumber.Text = ddlHolidayPlanCalendarNumber.Text;
            txtHolidayPlanCalendarName.Text = ddlHolidayPlanCalendarName.Text;
        }

        protected void ddlCalendarYear2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("HolidayCalendar");
            LoadHolidayCalendars();
            loadHolidaySchedule();
            LoadAccessProfiles();
        }
        public static void MapHolidayPLan(long holidayCalenderId, long accessPlanId)
        {
            SaveAccessPlanHoliday(accessPlanId, holidayCalenderId);
        }

        protected void grdZuttritProfileTimeFrames_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                LoadZuttritProfileTimeFrames(e.Parameters);
            }
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
        [WebMethod]
        public static void SaveHolidayScheduleOnBack(long calenderId, long holidayPlanNr, string holidayPlanName, string memo, long holidayPlanId, int allowAccess, long accessPLanId)
        {
            HolidayScheduleViewModel holidaySchedule = new HolidayScheduleViewModel();
            var holidayCalender = holidaySchedule.GetHolidayCalenderByID(calenderId);
            var calenderYear = holidayCalender.CalendarYear;
            var holidayPlanAccessProfileCurrent = (HolidayPlanCalendar)HttpContext.Current.Session["HolidayPlanAccessProfile"];

            HolidayScheduleViewModel holiday_Schedule = new HolidayScheduleViewModel();
            HolidayPlanCalendar planCalender = new HolidayPlanCalendar()
            {
                Id = holidayPlanId,
                HolidayCalenderId = calenderId,
                CalendarYear = calenderYear,
                HolidayPlanCalendarNumber = holidayPlanNr,
                HolidayPlanCalendarName = holidayPlanName,
                Memo = memo,
                AllowAccess = allowAccess
            };
            if (holidayPlanId == 0)
            {
                holiday_Schedule.CreateHolidayPlan(planCalender);
                if (holidayPlanAccessProfileCurrent != null)
                {
                    holidayPlanAccessProfileCurrent.Id = planCalender.Id;
                    new HolidayScheduleViewModel().CreateHolidayAccessProfileCalendarMonths(holidayPlanAccessProfileCurrent);
                }
                SaveAccessPlanHoliday(accessPLanId, planCalender.Id);
            }
            else if (holidayPlanId > 0)
            {
                var existingPlanCalender = new HolidayScheduleViewModel().GetHolidayPlanByID(holidayPlanId);
                holiday_Schedule.UpdateHolidayPlan(planCalender);
                if (holidayPlanAccessProfileCurrent != null)
                {
                    holidayPlanAccessProfileCurrent.Id = planCalender.Id;
                    new HolidayScheduleViewModel().DeleteAccessPlanCalendar(planCalender.Id);
                    new HolidayScheduleViewModel().CreateHolidayAccessProfileCalendarMonths(holidayPlanAccessProfileCurrent);
                }
                else if (existingPlanCalender.HolidayCalenderId != planCalender.HolidayCalenderId)
                {
                    new HolidayScheduleViewModel().DeleteAccessPlanCalendar(planCalender.Id);
                }
                SaveAccessPlanHoliday(accessPLanId, planCalender.Id);

            }


        }

        protected void gridViewHolidayPlanCalendar_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                string[] passedValues = e.Parameters.Split(';');
                var id = Convert.ToInt64(passedValues[0]);
                var type = Convert.ToInt32(passedValues[1]);
                switch (type)
                {
                    case 1:
                        if (id > 0)
                        {
                            bindHolidays();
                        }
                        else
                        {
                            ClearFields();
                        }
                        break;
                    case 2:
                        if (id > 0)
                        {
                            bindHolidays();
                        }
                        else
                        {
                            ClearCalenderValues();
                        }
                        break;
                }

            }
        }

        protected void gridViewHoliday_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                string[] passedValues = e.Parameters.Split(';');
                var id = Convert.ToInt64(passedValues[0]);
                var type = Convert.ToInt32(passedValues[1]);
                switch (type)
                {
                    case 1:
                        if (id > 0)
                        {
                            bindHolidays();
                        }
                        else
                        {
                            ClearFields();
                        }
                        break;
                    case 2:
                        if (id > 0)
                        {
                            bindHolidays();
                        }
                        else
                        {
                            ClearCalenderValues();
                        }
                        break;
                }

            }
        }
        protected void bindHolidays(long id)
        {

            var calendarYear = DateTime.Now.Year;
            List<Holiday> _selectedHolidays2 = new List<Holiday>();


            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            var holidayCalendarId = Convert.ToInt64(ddlHolidayCalendarNumber.Value);
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayCalendarId);
            var holidayPLanCalendarId = Convert.ToInt64(id);
            var holidayPlanCalendar = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarById2(holidayPLanCalendarId);
            if (holidayPlanCalendar != null && holidayCalendar != null)
            {
                if (holidayPlanCalendar.HolidayCalenderId != holidayCalendar.Id)
                {
                    holidayPlanCalendar.HolidayPlanCalendarMonths = null;
                }
            }

            Session["HolidayCalendar"] = holidayCalendar;

            var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarScheduleWithAccessProfiles(holidayCalendar, holidayPlanCalendar, out _selectedHolidays2, out _accessHolidays);
            _selectedHolidays = new List<Holiday>();
            _selectedHolidays = _selectedHolidays2;

            var existingHolidays = new HolidayViewModel().GetHolidays();
            var holidayPlans = new List<HolidayPlan>();
            foreach (var holiday in existingHolidays)
            {
                bool isSelected = false;
                bool accessProfile = false;
                if (_selectedHolidays2 != null)
                {
                    var existingHolidayCalendarHoliday = _selectedHolidays2.FirstOrDefault(h => h.Id == holiday.Id);
                    if (existingHolidayCalendarHoliday != null)
                    {
                        isSelected = true;
                    }
                }
                var holidayPlan = new HolidayPlan
                {
                    Id = holiday.Id,
                    HolidayDate = holiday.HolidayDate,
                    HolidayName = holiday.HolidayName,
                    IsSelected = isSelected,
                    AccessProfile = accessProfile
                };

                holidayPlans.Add(holidayPlan);
            }
            List<HolidayPlan> holidaysInCalendar = new List<HolidayPlan>();
            holidaysInCalendar = holidayPlans.Where(h => h.IsSelected && h.HolidayDate.Year == calendarYear).OrderBy(h => h.HolidayDate).ToList();
            gridViewHoliday.DataSource = holidaysInCalendar;
            gridViewHoliday.DataBind();
            if ((holidayCalendarSchedule == null) || (holidayCalendarSchedule.Count == 0))
            {
                holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
                Session["HolidayCalendar"] = null;
            }
            gridViewHolidayPlanCalendar.DataSource = holidayCalendarSchedule;
            gridViewHolidayPlanCalendar.DataBind();

        }
        [WebMethod]
        public static long SaveHolidaySchedule(long planId, string planNr, string PlanName, string memo, int allowAccess, long calendarId, long accessPlanGroupId)
        {
            long _Id = 0;
            HolidayScheduleViewModel holidaySchedule = new HolidayScheduleViewModel();
            var calenderId = calendarId;
            var holidayCalender = holidaySchedule.GetHolidayCalenderByID(calenderId);
            var holidayPlanNr = Convert.ToInt64(planNr);
            var holidayPlanName = PlanName;
            var calenderYear = holidayCalender.CalendarYear;

            var holidayPlanId = Convert.ToInt64(planId);

            var holidayPlanAccessProfileCurrent = (HolidayPlanCalendar)HttpContext.Current.Session["HolidayPlanAccessProfile"];

            HolidayScheduleViewModel holiday_Schedule = new HolidayScheduleViewModel();
            HolidayPlanCalendar planCalender = new HolidayPlanCalendar()
            {
                Id = planId,
                HolidayCalenderId = calenderId,
                CalendarYear = calenderYear,
                HolidayPlanCalendarNumber = holidayPlanNr,
                HolidayPlanCalendarName = holidayPlanName,
                Memo = memo,
                AllowAccess = allowAccess
            };
            if (holidayPlanId == 0)
            {
                holiday_Schedule.CreateHolidayPlan(planCalender);
                if (holidayPlanAccessProfileCurrent != null)
                {
                    holidayPlanAccessProfileCurrent.Id = planCalender.Id;
                    new HolidayScheduleViewModel().CreateHolidayAccessProfileCalendarMonths(holidayPlanAccessProfileCurrent);
                }
                //LoadHolidayCalendars(planCalender.HolidayCalenderId);
                _Id = planCalender.Id;
                MapHolidayPLan(planCalender.Id, accessPlanGroupId);
            }
            else if (holidayPlanId > 0)
            {
                holiday_Schedule.UpdateHolidayPlan(planCalender);
                if (holidayPlanAccessProfileCurrent != null)
                {
                    holidayPlanAccessProfileCurrent.Id = planCalender.Id;
                    new HolidayScheduleViewModel().DeleteAccessPlanCalendar(planCalender.Id);
                    new HolidayScheduleViewModel().CreateHolidayAccessProfileCalendarMonths(holidayPlanAccessProfileCurrent);
                }
                //LoadHolidayCalendars(planCalender.HolidayCalenderId);
                _Id = planCalender.Id;
                MapHolidayPLan(planCalender.Id, accessPlanGroupId);
            }

            //LoadHolidayPlanCalenders();

            return _Id;
        }

        protected void ddlHolidayPlanCalendarNumber_Callback(object sender, CallbackEventArgsBase e)
        {
            List<HolidayPlanCalendar> listHolidayPlan = new List<HolidayPlanCalendar>();
            HolidayPlanCalendar holidayPlan = new HolidayPlanCalendar() { Id = 0, HolidayPlanCalendarNumber = 0, HolidayPlanCalendarName = "keine" };
            listHolidayPlan.Add(holidayPlan);
            var holidayCalendars = new HolidayScheduleViewModel().HolidayPlans();
            listHolidayPlan.AddRange(holidayCalendars);
            ddlHolidayPlanCalendarNumber.DataSource = listHolidayPlan;
            ddlHolidayPlanCalendarNumber.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                ddlHolidayPlanCalendarNumber.Value = e.Parameter.ToString();
            }
            else
            {
                ddlHolidayPlanCalendarNumber.SelectedIndex = 0;
            }
        }

        protected void ddlHolidayPlanCalendarName_Callback(object sender, CallbackEventArgsBase e)
        {
            List<HolidayPlanCalendar> listHolidayPlan = new List<HolidayPlanCalendar>();
            HolidayPlanCalendar holidayPlan = new HolidayPlanCalendar() { Id = 0, HolidayPlanCalendarNumber = 0, HolidayPlanCalendarName = "keine" };
            listHolidayPlan.Add(holidayPlan);
            var holidayCalendars = new HolidayScheduleViewModel().HolidayPlans();
            listHolidayPlan.AddRange(holidayCalendars);
            ddlHolidayPlanCalendarName.DataSource = listHolidayPlan;
            ddlHolidayPlanCalendarName.DataBind();
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                ddlHolidayPlanCalendarName.Value = e.Parameter.ToString();
            }
            else
            {
                ddlHolidayPlanCalendarName.SelectedIndex = 0;
            }
        }
        [WebMethod]
        public static void DeleteHolidayPlan(long planId)
        {
            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(planId);
            if (holidayPlanCalendar != null)
            {
                new HolidayScheduleViewModel().DeleteHolidayPlan(holidayPlanCalendar);
            }

        }
        [WebMethod]
        public static HolidayPlanCalendar GetHolidayPlan(long planId)
        {
            HolidayPlanCalendar plan = new HolidayPlanCalendar();
            plan.CalendarYear = DateTime.Now.Year;
            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(planId);
            if (holidayPlanCalendar != null)
            {
                plan.AllowAccess = holidayPlanCalendar.AllowAccess;
                plan.Memo = holidayPlanCalendar.Memo;
                plan.Id = holidayPlanCalendar.Id;
                plan.CalendarYear = holidayPlanCalendar.CalendarYear;
                
            }
            return plan;
        }

    }
}