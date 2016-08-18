using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.ViewModels
{
    public class HolidayCalendarViewModel
    {
        private readonly HolidayCalendarRepository _holidayCalendarRepository = new HolidayCalendarRepository();
        private readonly HolidayCalendarMonthRepository _holidayCalendarMonthRepository = new HolidayCalendarMonthRepository();

        #region HolidayCalendar Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayCalendar> GetHolidayCalendars()
        {
            return _holidayCalendarRepository.GetHolidayCalendars();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayCalendarById(long id)
        {
            return _holidayCalendarRepository.GetHolidayCalendarById(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayCalendarByCalendarYear(int calendarYear)
        {
            return _holidayCalendarRepository.GetHolidayCalendarByCalendarYear(calendarYear);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayCalendarByNumber(long holidayCalendarNumber)
        {
            return _holidayCalendarRepository.GetHolidayCalendarByNumber(holidayCalendarNumber);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public HolidayCalendar CreateHolidayCalendar(HolidayCalendar holidayCalendar)
        {
            _holidayCalendarRepository.NewHolidayCalendar(holidayCalendar);

            var newHolidayCalendar = GetHolidayCalendarByNumber(holidayCalendar.HolidayCalendarNumber);

            return newHolidayCalendar;
        }

        public HolidayCalendar EditHolidayCalendar(HolidayCalendar holidayCalendar)
        {
            _holidayCalendarRepository.EditHolidayCalendar(holidayCalendar);

            var editedHolidayCalendar = GetHolidayCalendarByNumber(holidayCalendar.HolidayCalendarNumber);

            return editedHolidayCalendar;
        }

        public void DeleteHolidayCalendarMonths(HolidayCalendar holidayCalendar)
        {
            var holidayCalendarMonths = GetHolidayCalendarMonths(holidayCalendar.Id);
            if (holidayCalendarMonths == null) return;

            foreach (var holidayCalendarMonth in holidayCalendarMonths)
            {
                _holidayCalendarMonthRepository.DeleteHolidayCalendarMonth(holidayCalendarMonth);
            }
        }

        public void DeleteHolidayCalendar(HolidayCalendar holidayCalendar)
        {
            _holidayCalendarRepository.DeleteHolidayCalendar(holidayCalendar);
        }

        #endregion

        #region HolidayCalendarMonth Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendarMonth GetHolidayCalendarMonthByCalendarMonth(long holidayCalendarId, int calendarMonth)
        {
            return _holidayCalendarMonthRepository.GetHolidayCalendarMonthByCalendarMonth(holidayCalendarId, calendarMonth);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayCalendarMonth> GetHolidayCalendarMonths(long holidayCalendarId)
        {
            return _holidayCalendarMonthRepository.GetHolidayCalendarMonthsByHolidayCalendarId(holidayCalendarId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateHolidayCalendarMonths(HolidayCalendar holidayCalendar)
        {
            var holidayCalendarMonths = holidayCalendar.HolidayCalendarMonths;
            foreach (var holidayCalendarMonth in holidayCalendarMonths)
            {
                var newHolidayCalendarMonth = new HolidayCalendarMonth { HolidayCalendarId = holidayCalendar.Id, CalendarMonth = holidayCalendarMonth.CalendarMonth };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayHolidayProperty = string.Format("Day{0}HolidayId", dayOfMonth);
                    var propertyInfo = holidayCalendarMonth.GetType().GetProperty(dayHolidayProperty);

                    var propertyValue = (long)propertyInfo.GetValue(holidayCalendarMonth);

                    var newPropertyInfo = newHolidayCalendarMonth.GetType().GetProperty(dayHolidayProperty);
                    newPropertyInfo.SetValue(newHolidayCalendarMonth, propertyValue, null);
                }

                CreateHolidayCalendarMonth(newHolidayCalendarMonth);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateHolidayCalendarMonths(long holidayCalendarId, List<HolidayCalendarMonth> holidayCalendarMonths)
        {
            foreach (var holidayCalendarMonth in holidayCalendarMonths)
            {
                var newHolidayCalendarMonth = new HolidayCalendarMonth { HolidayCalendarId = holidayCalendarId, CalendarMonth = holidayCalendarMonth.CalendarMonth };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayHolidayProperty = string.Format("Day{0}HolidayId", dayOfMonth);
                    var propertyInfo = holidayCalendarMonth.GetType().GetProperty(dayHolidayProperty);

                    var propertyValue = (long)propertyInfo.GetValue(holidayCalendarMonth);

                    var newPropertyInfo = newHolidayCalendarMonth.GetType().GetProperty(dayHolidayProperty);
                    newPropertyInfo.SetValue(newHolidayCalendarMonth, propertyValue, null);
                }

                CreateHolidayCalendarMonth(newHolidayCalendarMonth);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        void CreateHolidayCalendarMonth(HolidayCalendarMonth holidayCalendarMonth)
        {
            _holidayCalendarMonthRepository.NewHolidayCalendarMonth(holidayCalendarMonth);
        }

        public void DeleteHolidayCalendarMonth(HolidayCalendarMonth holidayCalendarMonth)
        {
            _holidayCalendarMonthRepository.DeleteHolidayCalendarMonth(holidayCalendarMonth);
        }

        #endregion

        public List<HolidayCalendarScheduleViewModel> GetHolidayCalendarSchedule(int calendarYear)
        {
            var holidayCalendarScheduleViewModels = new List<HolidayCalendarScheduleViewModel>();

            var startDate = new DateTime(calendarYear, 1, 1);
            var endDate = new DateTime(calendarYear, 12, 31);

            while (startDate < endDate)
            {
                var holidayCalendarScheduleViewModel = new HolidayCalendarScheduleViewModel { MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= DateTime.DaysInMonth(startDate.Year, startDate.Month); dayOfMonth++)
                {
                    var daySwitchProfileProperty = string.Format("Day{0}Holiday", dayOfMonth);
                    var propertyInfo = holidayCalendarScheduleViewModel.GetType().GetProperty(daySwitchProfileProperty);

                    propertyInfo.SetValue(holidayCalendarScheduleViewModel, Convert.ChangeType(string.Empty, propertyInfo.PropertyType), null);
                }

                holidayCalendarScheduleViewModel.Id = startDate.Month;
                holidayCalendarScheduleViewModels.Add(holidayCalendarScheduleViewModel);

                startDate = startDate.AddMonths(1);
            }

            return holidayCalendarScheduleViewModels;
        }

        public List<HolidayCalendarScheduleViewModel> GetHolidayCalendarSchedule(HolidayCalendar holidayCalendar, out List<Holiday> selectedHolidays)
        {
            var holidayCalendarScheduleViewModels = new List<HolidayCalendarScheduleViewModel>();
            selectedHolidays = new List<Holiday>();

            if (holidayCalendar == null) return holidayCalendarScheduleViewModels;
            var calendarYear = holidayCalendar.CalendarYear != 0 ? holidayCalendar.CalendarYear : DateTime.Now.Year;

            var holidayCalendarMonths = holidayCalendar.HolidayCalendarMonths;
            var holidays = new HolidayViewModel().GetHolidays();
            var existingHolidays = new List<Holiday>();

            foreach (var holidayCalendarMonth in holidayCalendarMonths)
            {
                if (holidayCalendarMonth.CalendarMonth == 0) continue;

                var startDate = new DateTime(calendarYear, holidayCalendarMonth.CalendarMonth, 1);
                var holidayCalendarScheduleViewModel = new HolidayCalendarScheduleViewModel { Id = holidayCalendarMonth.CalendarMonth, MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var idProperty = string.Format("Day{0}HolidayId", dayOfMonth);
                    var idPropertyInfo = holidayCalendarMonth.GetType().GetProperty(idProperty);
                    var holidayId = (long)idPropertyInfo.GetValue(holidayCalendarMonth);

                    string holidayName = string.Empty;

                    var holiday = holidays.FirstOrDefault(h => h.Id == holidayId);

                    if (holiday != null)
                    {
                        existingHolidays.Add(holiday);
                        holidayName = "FT";
                    }

                    var numberProperty = string.Format("Day{0}Holiday", dayOfMonth);
                    var numberPropertyInfo = holidayCalendarScheduleViewModel.GetType().GetProperty(numberProperty);

                    numberPropertyInfo.SetValue(holidayCalendarScheduleViewModel, Convert.ChangeType(holidayName, numberPropertyInfo.PropertyType), null);
                }

                holidayCalendarScheduleViewModels.Add(holidayCalendarScheduleViewModel);
            }

            selectedHolidays = existingHolidays.GroupBy(x => x.Id).Select(y => y.First()).ToList();

            return holidayCalendarScheduleViewModels;
        }
        public List<HolidayCalendarScheduleViewModel> GetHolidayCalendarScheduleWithAccessProfiles(HolidayCalendar holidayCalendar, HolidayPlanCalendar holidayPlanCalendar, out List<Holiday> selectedHolidays, out List<Holiday> accessHoliday)
        {
            var holidayCalendarScheduleViewModels = new List<HolidayCalendarScheduleViewModel>();
            selectedHolidays = new List<Holiday>();
            accessHoliday = new List<Holiday>();

            if (holidayCalendar == null) return holidayCalendarScheduleViewModels;
            var calendarYear = holidayCalendar.CalendarYear != 0 ? holidayCalendar.CalendarYear : DateTime.Now.Year;

            var holidayCalendarMonths = holidayCalendar.HolidayCalendarMonths;

            //var  holidayPlanCalendarMonths = holidayPlanCalendar.HolidayPlanAccessProfileMonths.ToList();


            var holidays = new HolidayViewModel().GetHolidays();
            var accessProfiles = new ZuttritProfileViewModel().ZuttritProfiles();
            var existingHolidays = new List<Holiday>();
            var accessProfileHoliday = new List<Holiday>();

            foreach (var holidayCalendarMonth in holidayCalendarMonths)
            {
                if (holidayCalendarMonth.CalendarMonth == 0) continue;

                var startDate = new DateTime(calendarYear, holidayCalendarMonth.CalendarMonth, 1);
                var holidayCalendarScheduleViewModel = new HolidayCalendarScheduleViewModel { Id = holidayCalendarMonth.CalendarMonth, MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {

                    var idProperty = string.Format("Day{0}HolidayId", dayOfMonth);
                    var idPropertyInfo = holidayCalendarMonth.GetType().GetProperty(idProperty);
                    var holidayId = (long)idPropertyInfo.GetValue(holidayCalendarMonth);
                    //get access profiles for current plan holiday
                    long profileHolidayId = 0;
                    if (holidayPlanCalendar != null)
                    {
                        var holidayPlanCalendarMonths = holidayPlanCalendar.HolidayPlanAccessProfileMonths.ToList();
                        if (holidayPlanCalendarMonths.Count() > 0)
                        {
                            var CurrentholidayPlanCalendarMonth = holidayPlanCalendarMonths.Where(x => x.CalendarMonth == holidayCalendarMonth.CalendarMonth).FirstOrDefault();
                            var idPropertyAceessProfile = string.Format("Day{0}AccessProfileId", dayOfMonth);
                            var idPropertyInfoAceessProfile = CurrentholidayPlanCalendarMonth.GetType().GetProperty(idPropertyAceessProfile);
                            profileHolidayId = (long)idPropertyInfoAceessProfile.GetValue(CurrentholidayPlanCalendarMonth);

                        }
                    }
                    var accessProfile = accessProfiles.FirstOrDefault(h => h.ID == Convert.ToInt64(profileHolidayId));
                    //end get access profile
                    string holidayName = string.Empty;

                    var holiday = holidays.FirstOrDefault(h => h.Id == holidayId);

                    if (holiday != null)
                    {
                        existingHolidays.Add(holiday);
                        if (accessProfile != null)
                        {
                            holidayName = accessProfile.AccessProfileID;
                            accessProfileHoliday.Add(holiday);
                        }
                        else
                        {
                            holidayName = "FT";
                        }

                    }

                    var numberProperty = string.Format("Day{0}Holiday", dayOfMonth);
                    var numberPropertyInfo = holidayCalendarScheduleViewModel.GetType().GetProperty(numberProperty);

                    numberPropertyInfo.SetValue(holidayCalendarScheduleViewModel, Convert.ChangeType(holidayName, numberPropertyInfo.PropertyType), null);
                }

                holidayCalendarScheduleViewModels.Add(holidayCalendarScheduleViewModel);
            }

            selectedHolidays = existingHolidays.GroupBy(x => x.Id).Select(y => y.First()).ToList();
            accessHoliday = accessProfileHoliday.GroupBy(x => x.Id).Select(y => y.First()).ToList();

            return holidayCalendarScheduleViewModels;
        }

    }
}
