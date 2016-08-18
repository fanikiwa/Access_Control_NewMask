using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class HolidayPlanCalendarMappedViewModel
    {
        private readonly HolidayPlanCalendarMappedRepository _holidayPlanCalendarRepository = new HolidayPlanCalendarMappedRepository();
        private readonly HolidayPlanCalendarMonthMappedRepository _holidayPlanCalendarMonthRepository = new HolidayPlanCalendarMonthMappedRepository();

        #region HolidayPlanCalendarMapped Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMapped> GetHolidayPlanCalendars()
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendars();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMapped GetHolidayPlanCalendarById(long id)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarById(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMapped GetHolidayPlanCalendarByCalendarYear(int calendarYear)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarByCalendarYear(calendarYear);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMapped GetHolidayPlanCalendarByNumber(long holidayPlanCalendarNumber)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarByNumber(holidayPlanCalendarNumber);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public HolidayPlanCalendarMapped CreateHolidayPlanCalendar(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            _holidayPlanCalendarRepository.NewHolidayPlanCalendar(holidayPlanCalendarMapped);

            var newHolidayPlanCalendar = GetHolidayPlanCalendarByNumber(holidayPlanCalendarMapped.HolidayPlanCalendarNumber);

            return newHolidayPlanCalendar;
        }

        public HolidayPlanCalendarMapped EditHolidayPlanCalendar(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            _holidayPlanCalendarRepository.EditHolidayPlanCalendar(holidayPlanCalendarMapped);

            var editedHolidayPlanCalendar = GetHolidayPlanCalendarByNumber(holidayPlanCalendarMapped.HolidayPlanCalendarNumber);

            return editedHolidayPlanCalendar;
        }

        public void DeleteHolidayPlanCalendarMonths(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            var holidayPlanCalendarMonths = GetHolidayPlanCalendarMonths(holidayPlanCalendarMapped.Id);
            if (holidayPlanCalendarMonths == null) return;

            foreach (var holidayPlanCalendarMonthMapped in holidayPlanCalendarMonths)
            {
                _holidayPlanCalendarMonthRepository.DeleteHolidayPlanCalendarMonth(holidayPlanCalendarMonthMapped);
            }
        }

        public void DeleteHolidayPlanCalendar(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            _holidayPlanCalendarRepository.DeleteHolidayPlanCalendar(holidayPlanCalendarMapped);
        }

        #endregion

        #region HolidayPlanCalendarMonthMapped Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMonthMapped GetHolidayPlanCalendarMonthByCalendarMonth(long holidayPlanCalendarId, int calendarMonth)
        {
            return _holidayPlanCalendarMonthRepository.GetHolidayPlanCalendarMonthByCalendarMonth(holidayPlanCalendarId, calendarMonth);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMonthMapped> GetHolidayPlanCalendarMonths(long holidayPlanCalendarId)
        {
            return _holidayPlanCalendarMonthRepository.GetHolidayPlanCalendarMonthsByHolidayPlanCalendarIdGetCalendarId(holidayPlanCalendarId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateHolidayPlanCalendarMonths(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            var holidayPlanCalendarMonths = holidayPlanCalendarMapped.HolidayPlanCalendarMonthMappeds;
            foreach (var holidayPlanCalendarMonthMapped in holidayPlanCalendarMonths)
            {
                var newHolidayPlanCalendarMonth = new HolidayPlanCalendarMonthMapped { HolidayPlanCalendarId = holidayPlanCalendarMapped.Id, CalendarMonth = holidayPlanCalendarMonthMapped.CalendarMonth };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayHolidayProperty = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                    var propertyInfo = holidayPlanCalendarMonthMapped.GetType().GetProperty(dayHolidayProperty);

                    var propertyValue = propertyInfo.GetValue(holidayPlanCalendarMonthMapped).ToString();

                    var newPropertyInfo = newHolidayPlanCalendarMonth.GetType().GetProperty(dayHolidayProperty);
                    newPropertyInfo.SetValue(newHolidayPlanCalendarMonth, propertyValue, null);
                }

                CreateHolidayPlanCalendarMonth(newHolidayPlanCalendarMonth);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        void CreateHolidayPlanCalendarMonth(HolidayPlanCalendarMonthMapped holidayPlanCalendarMonthMapped)
        {
            _holidayPlanCalendarMonthRepository.NewHolidayPlanCalendarMonth(holidayPlanCalendarMonthMapped);
        }

        public void DeleteHolidayPlanCalendarMonth(HolidayPlanCalendarMonthMapped holidayPlanCalendarMonthMapped)
        {
            _holidayPlanCalendarMonthRepository.DeleteHolidayPlanCalendarMonth(holidayPlanCalendarMonthMapped);
        }

        #endregion

        public List<HolidayPlanCalendarScheduleViewModel> GetHolidayPlanCalendarSchedule(int calendarYear)
        {
            var holidayPlanCalendarScheduleViewModels = new List<HolidayPlanCalendarScheduleViewModel>();

            var startDate = new DateTime(calendarYear, 1, 1);
            var endDate = new DateTime(calendarYear, 12, 31);

            while (startDate < endDate)
            {
                var holidayPlanCalendarScheduleViewModel = new HolidayPlanCalendarScheduleViewModel { MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= DateTime.DaysInMonth(startDate.Year, startDate.Month); dayOfMonth++)
                {
                    var daySwitchProfileProperty = string.Format("Day{0}ProfileHoliday", dayOfMonth);
                    var propertyInfo = holidayPlanCalendarScheduleViewModel.GetType().GetProperty(daySwitchProfileProperty);

                    propertyInfo.SetValue(holidayPlanCalendarScheduleViewModel, Convert.ChangeType(string.Empty, propertyInfo.PropertyType), null);
                }

                holidayPlanCalendarScheduleViewModel.Id = startDate.Month;
                holidayPlanCalendarScheduleViewModels.Add(holidayPlanCalendarScheduleViewModel);

                startDate = startDate.AddMonths(1);
            }

            return holidayPlanCalendarScheduleViewModels;
        }

        public List<HolidayPlanCalendarScheduleViewModel> GetHolidayPlanCalendarSchedule(HolidayPlanCalendarMapped holidayPlanCalendarMapped, out List<Holiday> selectedHolidays)
        {
            var holidayPlanCalendarScheduleViewModels = new List<HolidayPlanCalendarScheduleViewModel>();
            selectedHolidays = new List<Holiday>();

            if (holidayPlanCalendarMapped == null) return holidayPlanCalendarScheduleViewModels;
            var calendarYear = holidayPlanCalendarMapped.CalendarYear != 0 ? holidayPlanCalendarMapped.CalendarYear : DateTime.Now.Year;

            var holidayPlanCalendarMonths = holidayPlanCalendarMapped.HolidayPlanCalendarMonthMappeds;
            var holidays = new HolidayViewModel().GetHolidays();
            var existingHolidays = new List<Holiday>();

            foreach (var holidayPlanCalendarMonthMapped in holidayPlanCalendarMonths)
            {
                if (holidayPlanCalendarMonthMapped.CalendarMonth == 0) continue;

                var startDate = new DateTime(calendarYear, holidayPlanCalendarMonthMapped.CalendarMonth, 1);
                var holidayPlanCalendarScheduleViewModel = new HolidayPlanCalendarScheduleViewModel { Id = holidayPlanCalendarMonthMapped.CalendarMonth, MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var idProperty = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                    var idPropertyInfo = holidayPlanCalendarMonthMapped.GetType().GetProperty(idProperty);

                    string profileHoliday = string.Empty;
                    var profileHolidayId = idPropertyInfo.GetValue(holidayPlanCalendarMonthMapped).ToString();
                    if (!(string.IsNullOrEmpty(profileHolidayId)))
                    {
                        if ((profileHolidayId.Length > 2))
                        {
                            if (profileHolidayId.Substring(0, 2) == "FT")
                            {
                                profileHoliday = "FT";
                                var holidayId = profileHolidayId.Remove(0, 2);
                                var holiday = holidays.FirstOrDefault(h => h.Id == Convert.ToInt32(holidayId));

                                if (holiday != null)
                                {
                                    existingHolidays.Add(holiday);
                                }
                            }
                            //else if (profileHolidayId.Substring(0, 2) == "PR")
                            //{
                            //    var profileId = profileHolidayId.Substring(2, profileHolidayId.Length - 2);
                            //    var profile = new ZuttritProfileViewModel().GetZuttritProfileByID(Convert.ToInt32(profileId));

                            //    if (profile != null)
                            //    {
                            //        profileHoliday = profile.AccessProfileID;
                            //    }
                            //}
                        }
                    }

                    var numberProperty = string.Format("Day{0}ProfileHoliday", dayOfMonth);
                    var numberPropertyInfo = holidayPlanCalendarScheduleViewModel.GetType().GetProperty(numberProperty);

                    numberPropertyInfo.SetValue(holidayPlanCalendarScheduleViewModel, Convert.ChangeType(profileHoliday, numberPropertyInfo.PropertyType), null);
                }

                holidayPlanCalendarScheduleViewModels.Add(holidayPlanCalendarScheduleViewModel);
            }

            selectedHolidays = existingHolidays.GroupBy(x => x.Id).Select(y => y.First()).ToList();

            return holidayPlanCalendarScheduleViewModels;
        }

        public static HolidayPlanCalendarMapped SaveHolidayPlanCalendarFromTemplate(HolidayPlanCalendar holidayPlanCalendarTemplate)
        {
            var holidayPlanCalendarMonthMappeds = new List<HolidayPlanCalendarMonthMapped>();

            var holidayPlanCalendarMonths = holidayPlanCalendarTemplate.HolidayPlanCalendarMonths;
            if ((holidayPlanCalendarMonths != null) && (holidayPlanCalendarMonths.Any()))
            {
                foreach (var holidayPlanCalendarMonthTemplate in holidayPlanCalendarMonths)
                {
                    var holidayPlanCalendarMonthMapped = new HolidayPlanCalendarMonthMapped { CalendarMonth = holidayPlanCalendarMonthTemplate.CalendarMonth };

                    for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                    {
                        var profileHolidayProperty = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                        var propertyInfo = holidayPlanCalendarMonthTemplate.GetType().GetProperty(profileHolidayProperty);

                        var profileHolidayId = propertyInfo.GetValue(holidayPlanCalendarMonthTemplate).ToString();

                        var mappedPropertyInfo = holidayPlanCalendarMonthMapped.GetType().GetProperty(profileHolidayProperty);
                        mappedPropertyInfo.SetValue(holidayPlanCalendarMonthMapped, Convert.ChangeType(profileHolidayId, mappedPropertyInfo.PropertyType), null);
                    }

                    holidayPlanCalendarMonthMappeds.Add(holidayPlanCalendarMonthMapped);
                }
            }

            var newHolidayPlanalendarMapped = new HolidayPlanCalendarMapped
            {
                HolidayPlanCalendarNumber = holidayPlanCalendarTemplate.HolidayPlanCalendarNumber,
                HolidayPlanCalendarName = holidayPlanCalendarTemplate.HolidayPlanCalendarName,
                CalendarYear = holidayPlanCalendarTemplate.CalendarYear,
                Memo = holidayPlanCalendarTemplate.Memo,
                HolidayPlanCalendarMonthMappeds = holidayPlanCalendarMonthMappeds
            };

            new HolidayPlanCalendarMappedViewModel().CreateHolidayPlanCalendar(newHolidayPlanalendarMapped);
            var createdHolidayPlanCalendarMapped = new HolidayPlanCalendarMappedViewModel().GetHolidayPlanCalendarByNumber(newHolidayPlanalendarMapped.HolidayPlanCalendarNumber);

            return createdHolidayPlanCalendarMapped;
        }
    }
}