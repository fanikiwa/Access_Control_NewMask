using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using System.Web.Services;
using Access_Control_NewMask.Controllers;
using System.Globalization;
using Access_Control_NewMask.ViewModels;
using System.Diagnostics;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.Content
{
    public partial class Locations : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        private LocationViewModel _locationViewModel = new LocationViewModel();
        private static List<Holiday> _allHolidays;
        private static List<Holiday> _selectedHolidays;
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Locations_PMode");
            }
            set
            {
                HttpContext.Current.Session["Locations_PMode"] = value;
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Locations, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnNew.Enabled = false; btnDelete.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSave.UniqueID;

            if (!IsPostBack)
            {
                LoadlocationtDetails();
                BindControls();
            }
        }

        protected void LoadlocationtDetails()
        {
            Location _Location = new Location()
            {
                ID = 0,
                Location_Nr = 0,
                Name = "Keine",
            };
            var AllLocation = new LocationRepository().GetLocations();

            List<Location> Location = new List<Location>();

            HolidayCalendarRepository _HolidayCalendarRepository = new HolidayCalendarRepository();
            var holidays = _HolidayCalendarRepository.GetHolidayCalendars();
            Location.Add(_Location);
            Location.AddRange(AllLocation);

            cbolocation.DataSource = Location;
            cbolocation.DataBind();

            cbolocno.DataSource = Location;
            cbolocno.DataBind();

            grdLocation.DataSource = AllLocation;
            grdLocation.DataBind();


            ddlHolidayCalendar.DataSource = holidays; ;
            ddlHolidayCalendar.DataBind();


        }
        void BindControls()
        {

            LocationFederalStateRepository _LocationFederalStateRepository = new LocationFederalStateRepository();
            var states = _LocationFederalStateRepository.GetAllLocationFederalStates();

            cboState.DataSource = states;
            cboState.DataBind();

        }
        protected void LoadLocationDetailsByID(int lID)
        {
            var cDetails = new LocationRepository().GetLocationById(lID);
            if (cDetails != null)
            {

                cbolocation.Value = cDetails.ID.ToString();
                cbolocno.Value = cDetails.ID.ToString();
                if (cDetails.State != null) { cboState.Value = cDetails.State.ToString(); } else { cboState.Value = "0"; };
                if (cDetails.Location_Nr != 0) { txtlocno1.Text = cDetails.Location_Nr.ToString(); } else { txtlocno1.Text = ""; };
                if (cDetails.Name != null) { txtloc.Text = cDetails.Name.ToString(); } else { txtloc.Text = ""; };
                if (cDetails.InfoText != null) { txtMemo.Text = cDetails.InfoText.ToString(); } else { txtMemo.Text = ""; };
                if (cDetails.LocationHeadEmail != null) { txtEmail.Text = cDetails.LocationHeadEmail.ToString(); } else { txtEmail.Text = ""; };
                if (cDetails.LocationHeadFunction != null) { txtFunct.Text = cDetails.LocationHeadFunction.ToString(); } else { txtFunct.Text = ""; };
                if (cDetails.ZipCode != null) { txtPLZ.Text = cDetails.ZipCode.ToString(); } else { txtPLZ.Text = ""; };
                if (cDetails.Street != null) { txtStreet.Text = cDetails.Street.ToString(); } else { txtStreet.Text = ""; };
                if (cDetails.LocationHeadPhone != null) { txtTel.Text = cDetails.LocationHeadPhone.ToString(); } else { txtTel.Text = ""; };
                if (cDetails.LocationHeadMobile != null) { txtMob.Text = cDetails.LocationHeadMobile.ToString(); } else { txtMob.Text = ""; };
                if (cDetails.HouseNumber != null) { txthseNumber.Text = cDetails.HouseNumber.ToString(); } else { txthseNumber.Text = ""; };
                if (cDetails.Place != null) { txtOrt.Text = cDetails.Place.ToString(); } else { txtOrt.Text = ""; };
                if (cDetails.LocationHeadName != null) { txtName.Text = cDetails.LocationHeadName.ToString(); } else { txtName.Text = ""; };

            }
            else
            {
                txtloc.Text = string.Empty;
                txtlocno1.Text = string.Empty;
                txtMemo.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPLZ.Text = string.Empty;
                txtStreet.Text = string.Empty;
                txtTel.Text = string.Empty;
                txtMob.Text = string.Empty;
                txthseNumber.Text = string.Empty;
                txtFunct.Text = string.Empty;
                txtOrt.Text = string.Empty;
            }
        }

        protected void EnablesControl()
        {
            cbolocno.Enabled = true;
            cbolocation.Enabled = true;
            btnDelete.Enabled = true;

        }
        protected void NexlocationNr()
        {
            int locationNr = 0;

            var locationDetails = new LocationRepository().GetLocations();
            if (locationDetails.Count() > 0)
            {
                locationNr = Convert.ToInt32(locationDetails.Max(i => i.Location_Nr));
            }
            else
            {
                locationNr = 0;
            }
            int nextNr = locationNr + 1;
            txtlocno1.Text = nextNr.ToString();
            txtloc.Focus();
            saveChangesonNew.Value = "1";
        }
        protected void btnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Settings.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "1";
            cbolocno.Value = 0;
            cbolocation.Value = 0;

            cbolocno.Enabled = false;
            cbolocation.Enabled = false;

            ClearItems();
            NexlocationNr();

        }
        protected void ClearItems()
        {
            txtlocno1.Text = string.Empty;
            txtloc.Text = string.Empty;
            txtPLZ.Text = string.Empty;
            txtMemo.Text = string.Empty;
            txtName.Text = string.Empty;
            txtHolidayCalendarNumber.Text = string.Empty;
            txtHolidayCalendarName.Text = string.Empty;
            txtOrt.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtMob.Text = string.Empty;
            txthseNumber.Text = string.Empty;
            txtFunct.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnDelete.Enabled = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            saveChangesonNew.Value = "";
            LocationRepository _Location = new LocationRepository();
            Location locationDetails = new Location();

            var locationList = _Location.GetLocations();
            var locationExist = locationList.FirstOrDefault(x => x.ID == Convert.ToInt32(cbolocno.Value));

            if (locationExist != null)
            {
                locationExist.Location_Nr = Convert.ToInt32(txtlocno1.Text);
                locationExist.Name = txtloc.Text;
                locationExist.ZipCode = txtPLZ.Text;
                locationExist.Place = txtOrt.Text;
                locationExist.LocationHeadFunction = txtFunct.Text;
                locationExist.Street = txtStreet.Text;
                locationExist.LocationHeadPhone = txtTel.Text;
                locationExist.LocationHeadMobile = txtMob.Text;
                locationExist.InfoText = txtMemo.Text;
                locationExist.HouseNumber = txthseNumber.Text;
                locationExist.State = cboState.Value.ToString();
                locationExist.LocationHeadEmail = txtEmail.Text;
                locationExist.LocationHeadName = txtName.Text;

                long holideikalenda = 0;

                if ((string)ddlHolidayCalendar.Value == "Keine")
                {
                    holideikalenda = 0;
                }
                else
                {
                    holideikalenda = Convert.ToInt64(ddlHolidayCalendar.Value);
                    locationExist.HolidayCalendarId = Convert.ToInt64(ddlHolidayCalendar.Value) != 0 ? Convert.ToInt64(ddlHolidayCalendar.Value) : (long?)null;
                }



                _Location.EditLocation(locationExist);
                mainCtl.RedirectToPromptPage();
                LoadlocationtDetails();
                LoadLocationDetailsByID(Convert.ToInt32(locationExist.ID));

            }
            else
            {
                locationDetails.Location_Nr = Convert.ToInt32(txtlocno1.Text);
                locationDetails.Name = txtloc.Text;
                locationDetails.ZipCode = txtPLZ.Text;
                locationDetails.Place = txtOrt.Text;
                locationDetails.LocationHeadName = txtName.Text;
                locationDetails.Street = txtStreet.Text;
                locationDetails.LocationHeadPhone = txtTel.Text;
                locationDetails.LocationHeadMobile = txtMob.Text;
                locationDetails.InfoText = txtMemo.Text;
                locationDetails.HouseNumber = txthseNumber.Text;
                locationDetails.State = cboState.Value.ToString();
                locationDetails.LocationHeadFunction = txtFunct.Text;
                locationDetails.LocationHeadEmail = txtEmail.Text;

                locationDetails.HolidayCalendarId = Convert.ToInt64(ddlHolidayCalendar.Value) != 0 ? Convert.ToInt64(ddlHolidayCalendar.Value) : (long?)null;

                _Location.NewLocation(locationDetails);
                LoadlocationtDetails();
                LoadLocationDetailsByID(Convert.ToInt32(locationDetails.ID));

            }
            EnablesControl();
            mainCtl.RedirectToPromptPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeletelocationType(Convert.ToInt32(cbolocno.Value));
        }
        protected void DeletelocationType(int cid)
        {
            var locationID = new LocationRepository().GetLocationById(cid);

            if (locationID != null)
            {
                new LocationRepository().DeleteLocation(locationID);
            }
            LoadlocationtDetails();
            cbolocation.SelectedIndex = 0;
            cbolocno.SelectedIndex = 0;
            LoadLocationDetailsByID(Convert.ToInt32(cbolocno.Value));

        }

        protected void grdLocation_SelectionChanged(object sender, EventArgs e)
        {
            var id = grdLocation.GetRowValues(grdLocation.FocusedRowIndex, "ID");

            LoadlocationtDetails();
            LoadLocationDetailsByID(Convert.ToInt32(id));
        }

        protected void cbolocation_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadlocationtDetails();
            grdLocation.FocusedRowIndex = Convert.ToInt32(cbolocation.SelectedIndex - 1);
            LoadLocationDetailsByID(Convert.ToInt32(cbolocation.Value));

        }

        protected void cbolocno_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadlocationtDetails();
            grdLocation.FocusedRowIndex = Convert.ToInt32(cbolocno.SelectedIndex - 1);
            LoadLocationDetailsByID(Convert.ToInt32(cbolocno.Value));

        }

        [WebMethod]
        public static string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        [WebMethod]
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }

        [WebMethod]
        void LoadHolidays()
        {

            foreach (var holiday in _allHolidays)
            {
                bool isSelected = false;
                var existingHolidayCalendarHoliday = _selectedHolidays.FirstOrDefault(h => h.Id == holiday.Id);
                if (existingHolidayCalendarHoliday != null)
                {
                    isSelected = true;
                }

                if (isSelected)
                {
                    _selectedHolidays.Add(holiday);
                }
            }
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
        protected void LoadgrdHolidayCalendar()
        {
            try
            {
                List<HolidayCalendar> lstHolidayCalendar = new List<HolidayCalendar>();
                lstHolidayCalendar = this.LoadHolidayCalendars();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public List<KruAll.Core.Models.HolidayCalendar> LoadHolidayCalendars()
        {
            return _locationViewModel.HolidayCalendars();
        }

        [WebMethod]
        public static HolidayCalendarDto GetHolidayCalendar()
        {
            var holidayCalendar = (HolidayCalendar)HttpContext.Current.Session["HolidayCalendar"];
            if (holidayCalendar == null) return new HolidayCalendarDto();

            var holidayCalendarDto = new HolidayCalendarDto
            {
                HolidayCalendarNumber = holidayCalendar.HolidayCalendarNumber,
                HolidayCalendarName = holidayCalendar.HolidayCalendarName
            };

            return holidayCalendarDto;
        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static Location populatecontrols(long locid)
        {

            LocationRepository _LocationRepository = new LocationRepository();

            Location _Location = new Location();
            Location _Location2 = new Location();

            var locList1 = _LocationRepository.GetLocations().ToList();

            if (locid < 1)
            {
                return _Location;
            }
            var locList = locList1.Where(f => f.ID.Equals(Convert.ToInt32(locid))).FirstOrDefault();

            if (locid != -1)
            {
                _Location = locList1.Where(f => f.ID.Equals(locid)).FirstOrDefault();
            }
            else
            {
                locid = _LocationRepository.GetLocations().Max(x => x.Location_Nr);
                _Location = locList1.Where(f => f.ID.Equals(locid)).FirstOrDefault();
            }
            _Location2.ID = _Location.ID;
            _Location2.Location_Nr = _Location.Location_Nr;
            _Location2.LocationFederalStateId = _Location.LocationFederalStateId;
            _Location2.LocationHeadEmail = _Location.LocationHeadEmail;
            _Location2.LocationHeadFunction = _Location.LocationHeadFunction;
            _Location2.Street = _Location.Street;
            _Location2.LocationHeadMobile = _Location.LocationHeadMobile;
            _Location2.LocationHeadName = _Location.LocationHeadName;
            _Location2.LocationHeadPhone = _Location.LocationHeadPhone;
            _Location2.Name = _Location.Name;
            _Location2.Place = _Location.Place;
            _Location2.State = _Location.State;
            _Location2.ZipCode = _Location.ZipCode;
            _Location2.HouseNumber = _Location.HouseNumber;
            _Location2.InfoText = _Location.InfoText;
            _Location2.HolidayCalendarId = _Location.HolidayCalendarId;

            return _Location2;
        }
        protected void gridViewHolidayCalendar_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName.Length < 3) return;

            var holidayCalendar = (HolidayCalendar)Session["HolidayCalendar"];
            var calendarYear = DateTime.Now.Year;

            if (holidayCalendar != null)
            {
                calendarYear = holidayCalendar.CalendarYear;
            }

            if (e.DataColumn.FieldName.Substring(0, 3) != "Day") return;

            var daysDate = DateTime.MinValue; ;

            if (e.VisibleIndex > 12) return;

            var month = e.VisibleIndex + 1;
            var dayOfMonth = Convert.ToInt32(System.Text.RegularExpressions.Regex.Match(e.DataColumn.FieldName, @"\d+").Value);

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

                if (todayIsHoliday != null)
                {
                    holidayName = todayIsHoliday.HolidayName;
                }
            }

            switch (daysDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    e.Cell.BackColor = System.Drawing.Color.Green;

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

                        e.Cell.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                        e.Cell.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                    }

                    break;

                default:
                    if (todayIsHoliday != null)
                    {
                        e.Cell.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                        e.Cell.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);

                        e.Cell.ToolTip = holidayName;
                    }

                    break;
            }

            if (daysDate == DateTime.MinValue)
            {
                e.Cell.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                if (todayIsHoliday == null)
                {
                    e.Cell.ToolTip = daysDate.ToString("ddd");
                }
            }
        }

        protected void gridViewHolidayCalendar_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (ddlHolidayCalendar == null) return;

            var holidayId = Convert.ToInt32(ddlHolidayCalendar.SelectedIndex);

            var holidayCalendar = new HolidayCalendarViewModel().GetHolidayCalendarById(holidayId);
            if (holidayCalendar == null)
            {
                var _calender = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(DateTime.Now.Year);
                gridViewHolidayCalendar.DataSource = _calender;
                gridViewHolidayCalendar.DataBind();
                Session["HolidayCalendar"] = null;
            }
            else
            {
                Session["HolidayCalendar"] = holidayCalendar;
                var holidayCalendarSchedule = new HolidayCalendarViewModel().GetHolidayCalendarSchedule(holidayCalendar, out _selectedHolidays);

                gridViewHolidayCalendar.DataSource = holidayCalendarSchedule;
                gridViewHolidayCalendar.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }
    }
}