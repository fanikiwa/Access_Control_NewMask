using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using DevExpress.Web;
using Access_Control_NewMask.ViewModels;
using Color = System.Drawing.Color;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Access_Control.Dtos;
using KruAll.Core.Repositories;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class Holidayplan : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("SettingsHolidayPlan_PMode");
            }
            set
            {
                HttpContext.Current.Session["SettingsHolidayPlan_PMode"] = value;
            }
        }

        enum FormMode
        {
            None,
            Display,
            Create,
            Edit
        }

        private static List<HolidayPlan> _holidayPlans;
        private static List<Holiday> _calendarHolidays;
        private static List<Holiday> _selectedHolidays;
        private static List<Holiday> _accessHolidays;
        private static List<Holiday> _allHolidays;


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.SettingsHolidayPlan, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSaveHolidayPlan.Enabled = false; btnApply.Enabled = false;

                btnNewAccessProfile.Enabled = false; btnNewHolidayPlan.Enabled = false;

                btnDeleteHolidayPlan.Enabled = false; btnRemoveSelected.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSaveHolidayPlan.UniqueID;

            if (!IsPostBack)
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
                btnDeleteHolidayPlan.Enabled = false;

            }
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
            };

            var accessProfiles = new ZuttritProfileViewModel().ZuttritProfiles();

            profiles.AddRange(accessProfiles);

            dplAccessProfileMemo.DataSource = profiles;
            dplAccessProfileMemo.DataBind();

            ddlAccessProfileNumber.DataSource = profiles;
            ddlAccessProfileNumber.DataBind();

            gridViewAccessProfileSearch.DataSource = accessProfiles;
            gridViewAccessProfileSearch.DataBind();

            if (accessProfiles.Count <= 17)
            {
                gridViewAccessProfileSearch.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            }
            else
            {
                gridViewAccessProfileSearch.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }

            ddlAccessProfileName.DataSource = profiles;
            ddlAccessProfileName.DataBind();
            if (ddlAccessProfileName.Items.FindByValue("0") != null) ddlAccessProfileName.Value = "0";

            ddlAccessProfileIdNumber.DataSource = profiles;
            ddlAccessProfileIdNumber.DataBind();
            if (ddlAccessProfileNumber.Items.FindByValue("0") != null) ddlAccessProfileNumber.Value = "0";

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
            Session["PlanCalendarNumber"] = listHolidayPlan;
            ddlHolidayPlanCalendarName.DataSource = listHolidayPlan;
            ddlHolidayPlanCalendarName.DataBind();
            ddlHolidayPlanCalendarName.SelectedIndex = 0;
        }

        protected void RebindDropDowns()
        {
            if (Session["PlanCalendarNumber"] != null)
            {
                var listHolidayPlan = (List<HolidayPlanCalendar>)Session["PlanCalendarNumber"];
                ddlHolidayPlanCalendarNumber.DataSource = listHolidayPlan;
                ddlHolidayPlanCalendarNumber.DataBind();
                ddlHolidayPlanCalendarNumber.SelectedIndex = 0;
            }

        }
        protected void BindDropdownAfterDelete()
        {
            List<HolidayPlanCalendar> listHolidayPlan = new List<HolidayPlanCalendar>();
            HolidayPlanCalendar holidayPlan = new HolidayPlanCalendar() { Id = 0, HolidayPlanCalendarNumber = 0, HolidayPlanCalendarName = "keine" };
            listHolidayPlan.Add(holidayPlan);
            var holidayCalendars = new HolidayScheduleViewModel().HolidayPlans();
            listHolidayPlan.AddRange(holidayCalendars);
            ddlHolidayPlanCalendarNumber.DataSource = listHolidayPlan;
            ddlHolidayPlanCalendarNumber.DataBind();
            ddlHolidayPlanCalendarNumber.SelectedIndex = 0;
        }
        void LoadHolidayCalendars()
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
            Session["CalendarNumber"] = calendars;

            ddlHolidayCalendarName.DataSource = calendars.Where(x => x.CalendarYear == Convert.ToInt32(selectedYear));
            ddlHolidayCalendarName.DataBind();
        }
        protected void RebindCalenderDropDown()
        {
            if (Session["CalendarNumber"] != null)
            {
                var holidays = (List<HolidayCalendar>)Session["CalendarNumber"];
                ddlHolidayCalendarNumber.DataSource = holidays;
                ddlHolidayCalendarNumber.DataBind();

                ddlHolidayCalendarName.DataSource = holidays;
                ddlHolidayCalendarName.DataBind();
            }

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
            //EnableDisableControls();

            ClearFields();
            LoadAccessProfiles();
            LoadHolidayCalendars();

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
        #region Private Methods

        #endregion Private Methods

        #region Public Methods

        [WebMethod]
        public static void UpdateHolidayPlanCalenderSchedule(string jsonData, int calendarYear, List<Holiday> holidays)
        {
            if (jsonData == null) return;

            var holidayPlanCalendarScheduleViewModels = JsonConvert.DeserializeObject<List<HolidayPlanCalendarScheduleViewModel>>(jsonData);
            var holidayPlanCalendarMonths = new List<HolidayPlanCalendarMonth>();
            _selectedHolidays = holidays;

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

        [WebMethod]
        public static bool DayHasTimeFrames(string accessProfileId)
        {
            var profile = new ZuttritProfileViewModel().GetZuttritProfileByAccessProfileId(accessProfileId);
            if (profile == null) return false;

            var daysProfiles = (List<ZuttritProfilesTimeFrame>)HttpContext.Current.Session["DaysProfiles"];
            if (daysProfiles == null)
            {
                daysProfiles = new ZuttritProfilesTimeFrameViewModel().GetZuttritProfilesTimeFramesByAccessProfID(profile.ID);
                HttpContext.Current.Session["DaysProfiles"] = daysProfiles;
            }

            var weekendDaysProfiles = daysProfiles.Where(z => z.SatFrom.TimeOfDay != DateTime.MinValue.TimeOfDay ||
                                                              z.SatTo.TimeOfDay != DateTime.MinValue.TimeOfDay ||
                                                              z.SunFrom.TimeOfDay != DateTime.MinValue.TimeOfDay ||
                                                              z.SunTo.TimeOfDay != DateTime.MinValue.TimeOfDay).ToList();

            if (weekendDaysProfiles.Any())
            {
                return true;
            }

            return false;
        }

        #endregion Public Methods

        #region Button Event Handler Methods

        protected void btnBack_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);

            switch (formMode)
            {
                case (int)FormMode.Display:
                case (int)FormMode.None:
                    //Session["HolidayPlanCalendar"] = null;
                    Response.Redirect("/Content/Settings.aspx");

                    break;

                case (int)FormMode.Create:
                case (int)FormMode.Edit:
                    FormDisplayMode();
                    hiddenFieldFormMode.Value = ((int)FormMode.Display).ToString();

                    ClearFields();

                    LoadHolidayPlanCalendars();

                    break;
            }
        }
        private void FormDisplayMode()
        {
            btnDeleteHolidayPlan.Enabled = true;
            btnApply.Enabled = false;
        }

        [WebMethod]
        public static bool DeletePlan(int Id)
        {
            HolidayScheduleViewModel Plan = new HolidayScheduleViewModel();

            var HolidayPlanCalendar = Plan.GetHolidayPlanByID(Convert.ToInt32(Id));
            if (HolidayPlanCalendar != null)
            {
                new HolidayScheduleViewModel().DeleteHolidayPlan(HolidayPlanCalendar);
            }
            return Plan.GetHolidayPlanByNr(Convert.ToInt32(Id)) == null;
        }

        //protected void btnDeleteHolidayPlan_Click(object sender, EventArgs e)
        //{
        //    string alertMessage;

        //    try
        //    {

        //        var confirmFlag = string.IsNullOrEmpty(hiddenFieldConfirmDialog.Value) ? 0 : Convert.ToInt32(hiddenFieldConfirmDialog.Value);
        //        switch (confirmFlag)
        //        {
        //        case 0:
        //            if (ddlHolidayPlanCalendarNumber.Value == null) return;
        //            alertMessage = "Are you sure you want to delete";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "CallDeleteConfirmBox", "ConfirmDelete();", true);

        //            break;

        //        case 1:
        //            if (ddlHolidayPlanCalendarNumber.Value == null) return;
        //            var holidayPlanCalendarId = Convert.ToInt32(ddlHolidayPlanCalendarNumber.Value);

        //            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(holidayPlanCalendarId);
        //            if (holidayPlanCalendar == null) return;
        //            new HolidayScheduleViewModel().DeleteHolidayPlan(holidayPlanCalendar);
        //            //new HolidayPlanCalendarViewModel().DeleteHolidayPlanCalendarMonths(holidayPlanCalendar);
        //            //new HolidayPlanCalendarViewModel().DeleteHolidayPlanCalendar(holidayPlanCalendar);

        //            hiddenFieldFormMode.Value = ((int)FormMode.None).ToString();
        //            hiddenFieldConfirmDialog.Value = "0";


        //            ReloadPage();


        //            break;

        //        case 2:
        //            hiddenFieldConfirmDialog.Value = "0";
        //            LoadAccessProfiles();
        //            break;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        alertMessage = exception.Message;
        //        alertMessage = alertMessage.Replace(Environment.NewLine, string.Empty);

        //        var alert = string.Format(@"alert(""{0}"");", alertMessage);
        //        ClientScript.RegisterStartupScript(GetType(), "AlertMessage", alert, true);
        //    }
        //}

        protected void btnEditHolidayPlan_Click(object sender, EventArgs e)
        {
            hiddenFieldFormMode.Value = ((int)FormMode.Edit).ToString();
            //EnableDisableControls();

            var holidayPlanCalendar = (HolidayPlanCalendar)Session["HolidayPlanCalendar"];

            var holidayPlanCalendarSchedule = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarSchedule(holidayPlanCalendar, out _selectedHolidays);
            if ((holidayPlanCalendarSchedule == null) || (holidayPlanCalendarSchedule.Count == 0))
            {
                //var calendarYear = Convert.ToInt32(ddlCalendarYear.SelectedItem.Text);
                var calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
                holidayPlanCalendarSchedule = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarSchedule(calendarYear);
            }

            gridViewHolidayPlanCalendar.DataSource = holidayPlanCalendarSchedule;
            gridViewHolidayPlanCalendar.DataBind();
        }

        protected void btnNewHolidayPlan_Click(object sender, EventArgs e)
        {
            NewHolidayPlanCalendar();
            btnDeleteHolidayPlan.Enabled = false;
        }

        protected void btnNewAccessProfile_Click(object sender, EventArgs e)
        {
            var formMode = string.IsNullOrEmpty(hiddenFieldFormMode.Value) ? (int)FormMode.None : Convert.ToInt32(hiddenFieldFormMode.Value);
            Session["HolidayScheduleFormMode"] = formMode;
            Session["AccessPlanAction"] = "New";
            var ent = 4;
            Response.Redirect("/Content/AccessProfile.aspx?ent=" + ent);
        }

        protected void btnSaveHolidayPlan_Click(object sender, EventArgs e)
        {
            SaveHolidaySchedule();
            bindHolidays();
            LoadAccessProfiles();
            btnDeleteHolidayPlan.Enabled = true;
            hiddenFieldSaveChanges.Value = "0";
        }
        protected void SaveHolidaySchedule()
        {

            string alertMessage;
            if (string.IsNullOrEmpty(txtHolidayPlanCalendarNumber.Text))
            {
                alertMessage = "Geben Sie Plan Nr";
                ClientScript.RegisterStartupScript(GetType(), "AlertMessage", "alert('" + alertMessage + "');", true);
                var selectedCalendar = Convert.ToInt64(ddlHolidayCalendarNumber.Value);
                LoadHolidayCalendars(selectedCalendar);
                return;
            }
            //if (string.IsNullOrEmpty(txtHolidayPlanCalendarName.Text))
            //{
            //    alertMessage = "Geben Sie Bezeichnung";
            //    ClientScript.RegisterStartupScript(GetType(), "AlertMessage", "alert('" + alertMessage + "');", true);
            //    return;
            //}

            if (Convert.ToInt64(ddlHolidayCalendarNumber.Value) == 0)
            {
                alertMessage = "Wählen Sie Feiertagskalender";
                ClientScript.RegisterStartupScript(GetType(), "AlertMessage", "alert('" + alertMessage + "');", true);
                LoadHolidayCalendars();
                return;
            }
            if (Session["ID"] != null)
            {
                var HolidayId = Session["ID"];
            }
            HolidayScheduleViewModel holidaySchedule = new HolidayScheduleViewModel();
            var calenderId = Convert.ToInt64(Session["ID"]);
            var holidayCalender = holidaySchedule.GetHolidayCalenderByID(calenderId);
            var holidayPlanNr = Convert.ToInt64(txtHolidayPlanCalendarNumber.Text);
            var holidayPlanName = txtHolidayPlanCalendarName.Text.Trim();
            var calenderYear = holidayCalender.CalendarYear;
            var memo = txtMemo.Text.Trim();
            var allowAccess = 0;
            if (chkDenyAccess.Checked == true)
            {
                allowAccess = 0;
            }
            if (chkAllowAccess.Checked == true)
            {
                allowAccess = 1;
            }
            var holidayPlanId = Convert.ToInt64(ddlHolidayPlanCalendarNumber.Value);

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
                LoadHolidayCalendars(planCalender.HolidayCalenderId);
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
                LoadHolidayCalendars(planCalender.HolidayCalenderId);
            }
            var planId = planCalender.Id;
            LoadHolidayPlanCalenders();
            ddlHolidayPlanCalendarNumber.Value = planId.ToString();
            ddlHolidayPlanCalendarName.Value = planId.ToString();
            txtHolidayPlanCalendarName.Text = planCalender.HolidayPlanCalendarName;
            txtHolidayPlanCalendarNumber.Text = planCalender.HolidayPlanCalendarNumber.ToString();
            var access = planCalender.AllowAccess;
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
            RebindDropDowns();
        }
        #endregion Button Event Handler Methods

        #region GridView Methods

        protected void gridViewHoliday_OnDataBound(object sender, EventArgs e)
        {
            //for (var i = 0; i < gridViewHoliday.VisibleRowCount; i++)
            //{
            //    var holidayDate = Convert.ToDateTime(gridViewHoliday.GetRowValues(i, "HolidayDate"));
            //    var isInHoliday = _accessHolidays.Find(x => x.HolidayDate == holidayDate);
            //     if (isInHoliday != null)
            //    {
            //        var isSelected = true;
            //        gridViewHoliday.Selection.SetSelection(i, isSelected);
            //    }
            //    else
            //    {
            //        var isSelected = false;
            //        gridViewHoliday.Selection.SetSelection(i, isSelected);
            //    }

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
                //calendarYear = formMode == (int)FormMode.Create ? DateTime.Now.Year : holidayCalendar.CalendarYear;
                calendarYear = holidayCalendar.CalendarYear;
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
                //if ((formMode != (int)FormMode.Create))
                //{
                //    todayIsHoliday = GetHoliday(daysDate);
                //}
                todayIsHoliday = GetHoliday(daysDate);
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

            //LoadCalendarHolidays();
            //BindCalendarHolidays();
            bindHolidaysOnly();
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
        #endregion GridView Methods

        void ClearFields()
        {
            RebindDropDowns();
            var calendarYear = DateTime.Now.Year;
            if (Convert.ToString(ddlCalendarYear2.Value) != "0")
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            gridViewHolidayPlanCalendar.DataSource = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
            gridViewHolidayPlanCalendar.DataBind();

            txtHolidayPlanCalendarName.Text = string.Empty;
            txtMemo.Text = string.Empty;

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


            Session["HolidayPlanAccessProfile"] = null;
            Session["HolidayCalendar"] = null;

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

        protected void bindHolidays()
        {
            if (!IsPostBack)
            {
                RebindDropDowns();
                RebindCalenderDropDown();
            }

            if (Session["ID"] != null)
            {
                var HolidayId = Session["ID"];
            }
            var calendarYear = DateTime.Now.Year;
            List<Holiday> _selectedHolidays2 = new List<Holiday>();

            if (!(string.IsNullOrEmpty(Convert.ToString(ddlCalendarYear2.Value))))
            {
                calendarYear = Convert.ToInt32(ddlCalendarYear2.Value);
            }
            var holidayCalendarId = Convert.ToInt64(ddlHolidayCalendarNumber.Value = ddlHolidayPlanCalendarNumber.Value);
            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(Convert.ToInt64(Session["ID"]));
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
            if ((holidayCalendarSchedule == null) || (holidayCalendarSchedule.Count == 0))
            {
                holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(calendarYear);
                Session["HolidayCalendar"] = null;
            }
            gridViewHolidayPlanCalendar.DataSource = holidayCalendarSchedule;
            gridViewHolidayPlanCalendar.DataBind();

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
            txtHolidayPlanCalendarNumber.Text = ddlHolidayPlanCalendarNumber.SelectedItem.Text;
            txtHolidayPlanCalendarName.Text = ddlHolidayPlanCalendarName.SelectedItem.Text;
        }

        protected void ddlHolidayPlanCalendarNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlHolidayPlanCalendarNumber.Text)) return;

            var holidayPlanCalendarId = Convert.ToInt32(ddlHolidayPlanCalendarNumber.Text);

            ddlHolidayPlanCalendarName.Value = holidayPlanCalendarId.ToString();
            ddlHolidayPlanCalendarNumber.Value = holidayPlanCalendarId.ToString();

            if (holidayPlanCalendarId == 0)
            {
                ddlCalendarYear2.Value = DateTime.Now.Year;
                ClearFields();
                LoadHolidayCalendars();
                // btnDeleteHolidayPlan.Enabled = false;
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
            //  btnDeleteHolidayPlan.Enabled = true;
        }

        protected void ddlHolidayPlanCalendarName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ddlHolidayPlanCalendarName.Text)) return;

            var holidayPlanCalendarId = Convert.ToInt32(ddlHolidayPlanCalendarName.Value);

            ddlHolidayPlanCalendarName.Value = holidayPlanCalendarId.ToString();
            ddlHolidayPlanCalendarNumber.Value = holidayPlanCalendarId.ToString();

            if (holidayPlanCalendarId == 0)
            {

                ddlCalendarYear2.Value = DateTime.Now.Year;
                ClearFields();
                LoadHolidayCalendars();
                //   btnDeleteHolidayPlan.Enabled = false;
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
            // btnDeleteHolidayPlan.Enabled = true;
        }

        protected void ddlCalendarYear2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("HolidayCalendar");
            LoadHolidayCalendars();
            loadHolidaySchedule();
            LoadAccessProfiles();
        }

        protected void gridViewHolidayPlanCalendar_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
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
                //calendarYear = formMode == (int)FormMode.Create ? DateTime.Now.Year : holidayCalendar.CalendarYear;
                calendarYear = holidayCalendar.CalendarYear;
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
                //if ((formMode != (int)FormMode.Create))
                //{
                //    todayIsHoliday = GetHoliday(daysDate);
                //}
                todayIsHoliday = GetHoliday(daysDate);
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

        [WebMethod]
        public static void SaveHolidayScheduleOnBack(long calenderId, long holidayPlanNr, string holidayPlanName, string memo, long holidayPlanId, int allowAccess)
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

        [WebMethod]
        public static List<SelectedHolidayDto> SelectedHolidays()
        {
            //List<AccessProfileDto> accessProfiles = new List<AccessProfileDto>();
            //var holidayPLanCalendarId = Convert.ToInt64(holidayPlanId);
            //var holidayPlanCalendar = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarById2(holidayPLanCalendarId);
            //var _accessProfiles = new HolidayPlanCalendarViewModel().GetHolidayPlanCalendarScheduleAccessProfiles(holidayPlanCalendar, out accessProfiles);
            List<SelectedHolidayDto> selectedDates = new List<SelectedHolidayDto>();
            if (selectedDates.Count <= 0) { return selectedDates; }
            foreach (var date in _selectedHolidays)
            {
                SelectedHolidayDto holidayDate = new SelectedHolidayDto()
                {
                    HolidayDate = date.HolidayDate
                };
                selectedDates.Add(holidayDate);
            }
            return selectedDates;
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

        protected void gridViewHoliday_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!IsPostBack)
            {
                RebindCalenderDropDown();
            }


            if (!string.IsNullOrEmpty(e.Parameters))
            {
                //    ddlHolidayCalendarNumber.Value = ddlHolidayPlanCalendarNumber.SelectedItem.GetValue("HolidayCalenderId");
                string[] passedValues = e.Parameters.Split(';');
                var id = Convert.ToInt64(passedValues[0]);
                var type = Convert.ToInt32(passedValues[1]);
                Session["ID"] = id;
                switch (type)
                {
                    case 1:
                        if (id > 0)
                        {
                            var listHolidayPlan = (List<HolidayPlanCalendar>)Session["PlanCalendarNumber"];
                            if (listHolidayPlan != null && listHolidayPlan.Any(l => l.Id == id))
                            {
                                Session["ID"] = listHolidayPlan.First(l => l.Id == id).HolidayCalenderId;
                                bindHolidays();

                            }
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

        protected void gridViewHolidayPlanCalendar_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (!IsPostBack)
            {
                RebindCalenderDropDown();
            }

            //ddlHolidayCalendarNumber.Value = ddlHolidayPlanCalendarNumber.SelectedItem.GetValue("HolidayCalenderId");
            if (!string.IsNullOrEmpty(e.Parameters))
            {

                string[] passedValues = e.Parameters.Split(';');
                var id = Convert.ToInt64(passedValues[0]);
                var type = Convert.ToInt32(passedValues[1]);
                Session["ID"] = id;
                switch (type)
                {
                    case 1:
                        if (id > 0)
                        {
                            var listHolidayPlan = (List<HolidayPlanCalendar>)Session["PlanCalendarNumber"];
                            if (listHolidayPlan != null && listHolidayPlan.Any(l => l.Id == id))
                            {
                                Session["ID"] = listHolidayPlan.First(l => l.Id == id).HolidayCalenderId;
                                bindHolidays();

                            }

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
        [System.Web.Services.WebMethod]
        public static new string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void ddlHolidayCalendarName_Callback(object sender, CallbackEventArgsBase e)
        {
            // BindDropdownAfterDelete();
            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(Convert.ToInt64(ddlHolidayPlanCalendarNumber.Value));
            if (holidayPlanCalendar != null)
            {
                ddlCalendarYear2.Value = holidayPlanCalendar.CalendarYear.ToString();
                LoadHolidayCalendars();
                ddlHolidayCalendarName.Value = holidayPlanCalendar.HolidayCalenderId.ToString();
            }

        }

        protected void ddlHolidayCalendarNumber_Callback(object sender, CallbackEventArgsBase e)
        {
            // BindDropdownAfterDelete();
            var holidayPlanCalendar = new HolidayScheduleViewModel().GetHolidayPlanByID(Convert.ToInt64(ddlHolidayPlanCalendarNumber.Value));
            if (holidayPlanCalendar != null)
            {
                ddlCalendarYear2.Value = holidayPlanCalendar.CalendarYear.ToString();
                LoadHolidayCalendars();
                ddlHolidayCalendarNumber.Value = holidayPlanCalendar.HolidayCalenderId.ToString();
            }
        }


    }
}