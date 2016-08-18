using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class HolidayPlanCalendarViewModel
    {
        private readonly HolidayPlanCalendarRepository _holidayPlanCalendarRepository = new HolidayPlanCalendarRepository();
        private readonly HolidayPlanCalendarMonthRepository _holidayPlanCalendarMonthRepository = new HolidayPlanCalendarMonthRepository();

        #region HolidayPlanCalendar Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendar> GetHolidayPlanCalendars()
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendars();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarById(long id)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarById2(long id)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarById2(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarByCalendarYear(int calendarYear)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarByCalendarYear(calendarYear);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarByNumber(long holidayPlanCalendarNumber)
        {
            return _holidayPlanCalendarRepository.GetHolidayPlanCalendarByNumber(holidayPlanCalendarNumber);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public HolidayPlanCalendar CreateHolidayPlanCalendar(HolidayPlanCalendar holidayPlanCalendar)
        {
            _holidayPlanCalendarRepository.NewHolidayPlanCalendar(holidayPlanCalendar);

            var newHolidayPlanCalendar = GetHolidayPlanCalendarByNumber(holidayPlanCalendar.HolidayPlanCalendarNumber);

            return newHolidayPlanCalendar;
        }

        public HolidayPlanCalendar EditHolidayPlanCalendar(HolidayPlanCalendar holidayPlanCalendar)
        {
            _holidayPlanCalendarRepository.EditHolidayPlanCalendar(holidayPlanCalendar);

            var editedHolidayPlanCalendar = GetHolidayPlanCalendarByNumber(holidayPlanCalendar.HolidayPlanCalendarNumber);

            return editedHolidayPlanCalendar;
        }

        public void DeleteHolidayPlanCalendarMonths(HolidayPlanCalendar holidayPlanCalendar)
        {
            var holidayPlanCalendarMonths = GetHolidayPlanCalendarMonths(holidayPlanCalendar.Id);
            if (holidayPlanCalendarMonths == null) return;

            foreach (var holidayPlanCalendarMonth in holidayPlanCalendarMonths)
            {
                _holidayPlanCalendarMonthRepository.DeleteHolidayPlanCalendarMonth(holidayPlanCalendarMonth);
            }
        }

        public void DeleteHolidayPlanCalendar(HolidayPlanCalendar holidayPlanCalendar)
        {
            _holidayPlanCalendarRepository.DeleteHolidayPlanCalendar(holidayPlanCalendar);
        }

        #endregion

        #region HolidayPlanCalendarMonth Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMonth GetHolidayPlanCalendarMonthByCalendarMonth(long holidayPlanCalendarId, int calendarMonth)
        {
            return _holidayPlanCalendarMonthRepository.GetHolidayPlanCalendarMonthByCalendarMonth(holidayPlanCalendarId, calendarMonth);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMonth> GetHolidayPlanCalendarMonths(long holidayPlanCalendarId)
        {
            return _holidayPlanCalendarMonthRepository.GetHolidayPlanCalendarMonthsByHolidayPlanCalendarIdGetCalendarId(holidayPlanCalendarId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateHolidayPlanCalendarMonths(HolidayPlanCalendar holidayPlanCalendar)
        {
            var holidayPlanCalendarMonths = holidayPlanCalendar.HolidayPlanCalendarMonths;
            foreach (var holidayPlanCalendarMonth in holidayPlanCalendarMonths)
            {
                var newHolidayPlanCalendarMonth = new HolidayPlanCalendarMonth { HolidayPlanCalendarId = holidayPlanCalendar.Id, CalendarMonth = holidayPlanCalendarMonth.CalendarMonth };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayHolidayProperty = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                    var propertyInfo = holidayPlanCalendarMonth.GetType().GetProperty(dayHolidayProperty);

                    var propertyValue = propertyInfo.GetValue(holidayPlanCalendarMonth).ToString();

                    var newPropertyInfo = newHolidayPlanCalendarMonth.GetType().GetProperty(dayHolidayProperty);
                    newPropertyInfo.SetValue(newHolidayPlanCalendarMonth, propertyValue, null);
                }

                CreateHolidayPlanCalendarMonth(newHolidayPlanCalendarMonth);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        void CreateHolidayPlanCalendarMonth(HolidayPlanCalendarMonth holidayPlanCalendarMonth)
        {
            _holidayPlanCalendarMonthRepository.NewHolidayPlanCalendarMonth(holidayPlanCalendarMonth);
        }

        public void DeleteHolidayPlanCalendarMonth(HolidayPlanCalendarMonth holidayPlanCalendarMonth)
        {
            _holidayPlanCalendarMonthRepository.DeleteHolidayPlanCalendarMonth(holidayPlanCalendarMonth);
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

        public List<HolidayPlanCalendarScheduleViewModel> GetHolidayPlanCalendarSchedule(HolidayPlanCalendar holidayPlanCalendar, out List<Holiday> selectedHolidays)
        {
            var holidayPlanCalendarScheduleViewModels = new List<HolidayPlanCalendarScheduleViewModel>();
            selectedHolidays = new List<Holiday>();

            if (holidayPlanCalendar == null) return holidayPlanCalendarScheduleViewModels;
            var calendarYear = holidayPlanCalendar.CalendarYear != 0 ? holidayPlanCalendar.CalendarYear : DateTime.Now.Year;

            var holidayPlanCalendarMonths = holidayPlanCalendar.HolidayPlanCalendarMonths;
            var holidays = new HolidayViewModel().GetHolidays();
            var existingHolidays = new List<Holiday>();

            foreach (var holidayPlanCalendarMonth in holidayPlanCalendarMonths)
            {
                if (holidayPlanCalendarMonth.CalendarMonth == 0) continue;

                var startDate = new DateTime(calendarYear, holidayPlanCalendarMonth.CalendarMonth, 1);
                var holidayPlanCalendarScheduleViewModel = new HolidayPlanCalendarScheduleViewModel { Id = holidayPlanCalendarMonth.CalendarMonth, MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var idProperty = string.Format("Day{0}ProfileHolidayId", dayOfMonth);
                    var idPropertyInfo = holidayPlanCalendarMonth.GetType().GetProperty(idProperty);

                    string profileHoliday = string.Empty;
                    var profileHolidayId = idPropertyInfo.GetValue(holidayPlanCalendarMonth).ToString();
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
        public List<HolidayPlanAccessProfileMonthViewModel> GetHolidayPlanCalendarScheduleAccessProfiles(HolidayPlanCalendar holidayPlanCalendar, out List<AccessProfileDto> accessProfileHoliday)
        {
            var holidayPlanCalendarScheduleViewModels = new List<HolidayPlanAccessProfileMonthViewModel>();
            accessProfileHoliday = new List<AccessProfileDto>();

            if (holidayPlanCalendar == null) return holidayPlanCalendarScheduleViewModels;
            var calendarYear = holidayPlanCalendar.CalendarYear != 0 ? holidayPlanCalendar.CalendarYear : DateTime.Now.Year;

            var holidayPlanCalendarMonths = holidayPlanCalendar.HolidayPlanAccessProfileMonths;
            var accessProfiles = new ZuttritProfileViewModel().ZuttritProfiles();
            var existingProfiles = new List<AccessProfileDto>();

            foreach (var holidayPlanCalendarMonth in holidayPlanCalendarMonths)
            {
                if (holidayPlanCalendarMonth.CalendarMonth == 0) continue;

                var startDate = new DateTime(calendarYear, holidayPlanCalendarMonth.CalendarMonth, 1);
                var holidayPlanCalendarScheduleViewModel = new HolidayPlanAccessProfileMonthViewModel { ID = holidayPlanCalendarMonth.CalendarMonth, MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var idProperty = string.Format("Day{0}AccessProfileId", dayOfMonth);
                    var idPropertyInfo = holidayPlanCalendarMonth.GetType().GetProperty(idProperty);

                    string profileHoliday = string.Empty;
                    var profileHolidayId = idPropertyInfo.GetValue(holidayPlanCalendarMonth);

                    var accessProfile = accessProfiles.FirstOrDefault(h => h.ID == Convert.ToInt64(profileHolidayId));

                    if (accessProfile != null)
                    {
                        var holidayDate = new DateTime(calendarYear, holidayPlanCalendarMonth.CalendarMonth, dayOfMonth);
                        AccessProfileDto profile = new AccessProfileDto()
                        {
                            ID = accessProfile.ID,
                            AccessProfileId = accessProfile.AccessProfileID,
                            AccessProfileDate = holidayDate.ToString()

                        };
                        existingProfiles.Add(profile);
                    }

                    var numberProperty = string.Format("Day{0}AccessProfileId", dayOfMonth);
                    var numberPropertyInfo = holidayPlanCalendarScheduleViewModel.GetType().GetProperty(numberProperty);

                    numberPropertyInfo.SetValue(holidayPlanCalendarScheduleViewModel, Convert.ChangeType(profileHoliday, numberPropertyInfo.PropertyType), null);
                }

                holidayPlanCalendarScheduleViewModels.Add(holidayPlanCalendarScheduleViewModel);
            }

            //accessProfileHoliday = existingProfiles.GroupBy(x => x.ID).Select(y => y.First()).ToList();
            accessProfileHoliday = existingProfiles.ToList();

            return holidayPlanCalendarScheduleViewModels;
        }
    }
}