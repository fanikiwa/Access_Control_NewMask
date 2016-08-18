using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessCalendarViewModel
    {
        #region Properties
        AccessCalendarRepository accessCalendarRepository = new AccessCalendarRepository();
        AccessCalendarMonthRepository accessCalendarMonthRepository = new AccessCalendarMonthRepository();
        ZuttritProfileViewModel zuttritProfileViewModel = new ZuttritProfileViewModel();
        #endregion

        #region Methods
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AccessCalendar> AccessCalendars()
        {
            return accessCalendarRepository.GetAllAccessCalendars();
        }
        public AccessCalendar GetAccessCalendarById(long id)
        {
            return accessCalendarRepository.GetAccessCalendarById(id);
        }
        public AccessCalendar GetAccessCalendarByNr(int calendarNumber)
        {
            return accessCalendarRepository.GetAccessCalendarByNumber(calendarNumber);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateAccessCalendar(AccessCalendar accessCalendar)
        {
            accessCalendarRepository.NewAccessCalendar(accessCalendar);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void UpdateAccessCalendar(AccessCalendar accessCalendar)
        {
            accessCalendarRepository.EditAccessCalendar(accessCalendar);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteAccessCalendar(AccessCalendar accessCalendar)
        {
            accessCalendarRepository.DeleteAccessCalendar(accessCalendar);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AccessCalendarMonth> GetAccessCalendarMonths(long accessCalendarId)
        {
            return accessCalendarMonthRepository.GetAccessCalendarMonthsByAccessCalendarId(accessCalendarId);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AccessCalendarMonth GetAccessCalendarMonthByCalendarMonth(long accessCalendarId, int calendarMonth)
        {
            return accessCalendarMonthRepository.GetAccessCalendarMonthByCalendarMonth(accessCalendarId, calendarMonth);
        }

        public AccessCalendar EditAccessCalendar(AccessCalendar accessCalendar)
        {
            accessCalendarRepository.EditAccessCalendar(accessCalendar);

            var editedAccessCalendar = GetAccessCalendarByNr(accessCalendar.Calendar_Nr);

            return editedAccessCalendar;
        }

        public void DeleteAccessCalendarMonths(AccessCalendar accessCalendar)
        {
            var accessCalendarMonths = GetAccessCalendarMonths(accessCalendar.ID);
            if (accessCalendarMonths == null) return;

            foreach (var accessCalendarMonth in accessCalendarMonths)
            {
                accessCalendarMonthRepository.DeleteMapCalendarMonth(accessCalendarMonth);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        void CreateAccessCalendarMonth(AccessCalendarMonth accessCalendarMonth)
        {
            accessCalendarMonthRepository.NewAccessCalendarMonth(accessCalendarMonth);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateAccessCalendarMonths(AccessCalendar accessCalendar)
        {
            var accessCalendarMonths = accessCalendar.AccessCalendarMonths;
            foreach (var accessCalendarMonth in accessCalendarMonths)
            {
                var newaccessCalendarMonth = new AccessCalendarMonth { AccessCalendarID = accessCalendar.ID, AccessCalendarMonthNr = accessCalendarMonth.AccessCalendarMonthNr };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayAccessCalendarProperty = string.Format("Day{0}AccessProfileID", dayOfMonth);
                    var propertyInfo = accessCalendarMonth.GetType().GetProperty(dayAccessCalendarProperty);

                    var propertyValue = (int)propertyInfo.GetValue(accessCalendarMonth);

                    var newPropertyInfo = newaccessCalendarMonth.GetType().GetProperty(dayAccessCalendarProperty);
                    newPropertyInfo.SetValue(newaccessCalendarMonth, propertyValue, null);
                }

                CreateAccessCalendarMonth(newaccessCalendarMonth);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateAccessCalendarMonths(long accessCalendarId, List<AccessCalendarMonth> accessCalendarMonths)
        {
            foreach (var accessCalendarMonth in accessCalendarMonths)
            {
                var newaccessCalendarMonth = new AccessCalendarMonth { AccessCalendarID = accessCalendarId, AccessCalendarMonthNr = accessCalendarMonth.AccessCalendarMonthNr };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayAccessCalendarProperty = string.Format("Day{0}AccessProfileID", dayOfMonth);
                    var propertyInfo = accessCalendarMonth.GetType().GetProperty(dayAccessCalendarProperty);

                    var propertyValue = (int)propertyInfo.GetValue(accessCalendarMonth);

                    var newPropertyInfo = newaccessCalendarMonth.GetType().GetProperty(dayAccessCalendarProperty);
                    newPropertyInfo.SetValue(newaccessCalendarMonth, propertyValue, null);
                }

                CreateAccessCalendarMonth(newaccessCalendarMonth);
            }
        }

        #endregion

        #region utility functions

        public List<AccessCalendarScheduleViewModel> GetAccessCalendarSchedule(int calendarYear)
        {
            var accessCalendarScheduleViewModels = new List<AccessCalendarScheduleViewModel>();

            var startDate = new DateTime(calendarYear, 1, 1);
            var endDate = new DateTime(calendarYear, 12, 31);

            while (startDate < endDate)
            {
                var accessCalendarSchedule = new AccessCalendarScheduleViewModel { MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= DateTime.DaysInMonth(startDate.Year, startDate.Month); dayOfMonth++)
                {
                    var dayDailyProgramProperty = string.Format("Day{0}AccessProfile", dayOfMonth);
                    var propertyInfo = accessCalendarSchedule.GetType().GetProperty(dayDailyProgramProperty);

                    propertyInfo.SetValue(accessCalendarSchedule, Convert.ChangeType(string.Empty, propertyInfo.PropertyType), null);
                }

                accessCalendarSchedule.Id = startDate.Month;
                accessCalendarScheduleViewModels.Add(accessCalendarSchedule);

                startDate = startDate.AddMonths(1);
            }

            return accessCalendarScheduleViewModels;
        }

        public List<AccessCalendarScheduleViewModel> GetAccessCalendarSchedule(AccessCalendar accessCalendar)
        {
            var zuttritProfiles = zuttritProfileViewModel.ZuttritProfiles();
            var accessCalendarScheduleViewModels = new List<AccessCalendarScheduleViewModel>();

            if (accessCalendar == null) return accessCalendarScheduleViewModels;
            var calendarYear = accessCalendar.CalendarDate.Year != 0 ? accessCalendar.CalendarDate.Year : DateTime.Now.Year;

            var accessCalendarMonths = accessCalendar.AccessCalendarMonths;

            foreach (var accessCalendarMonth in accessCalendarMonths)
            {
                if (accessCalendarMonth.AccessCalendarMonthNr == 0) continue;

                var startDate = new DateTime(calendarYear, accessCalendarMonth.AccessCalendarMonthNr, 1);
                var accessCalendarSchedule = new AccessCalendarScheduleViewModel { Id = accessCalendarMonth.AccessCalendarMonthNr, MonthName = startDate.ToString("MMM") };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var idProperty = string.Format("Day{0}AccessProfileID", dayOfMonth);
                    var idPropertyInfo = accessCalendarMonth.GetType().GetProperty(idProperty);

                    var zuttrittProfileId = (int)idPropertyInfo.GetValue(accessCalendarMonth);
                    var zuttrittProfile = zuttritProfiles.Find(zutprofil => zutprofil.ID == zuttrittProfileId);
                    var zuttrittProfileNr = string.Empty;
                    if (zuttrittProfile != null)
                    {
                        zuttrittProfileNr = zuttrittProfile.AccessProfileID;
                    }

                    var numberProperty = string.Format("Day{0}AccessProfile", dayOfMonth);
                    var numberPropertyInfo = accessCalendarSchedule.GetType().GetProperty(numberProperty);
                    numberPropertyInfo.SetValue(accessCalendarSchedule, Convert.ChangeType(zuttrittProfileNr, numberPropertyInfo.PropertyType), null);
                }

                accessCalendarScheduleViewModels.Add(accessCalendarSchedule);
            }

            return accessCalendarScheduleViewModels;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataTable BindAccessCalenderRawData()
        {
            var accessCallenderRawData = new AccessCalendarRepository().GetAllAccessCalendars().OrderBy(x => x.Calendar_Nr).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(long));
            dt.Columns.Add("Calendar_Nr", typeof(int));
            dt.Columns.Add("Calendar_Name", typeof(string));
            if (accessCallenderRawData.Count == 0)
            {
                for (int i = 0; i < 17; i++)
                {
                    dt.Rows.Add((i + 1) * -1);
                }
            }
            else
            {

                foreach (AccessCalendar calenderRawData in accessCallenderRawData)
                {

                    DataRow row = dt.NewRow();
                    row["ID"] = calenderRawData.ID;
                    row["Calendar_Nr"] = calenderRawData.Calendar_Nr;
                    row["Calendar_Name"] = calenderRawData.Calendar_Name;
                    dt.Rows.Add(row);

                }

                if (accessCallenderRawData.Count < 17)
                {
                    for (int i = 0; i < (17 - accessCallenderRawData.Count); i++)
                    {
                        dt.Rows.Add((i + 1) * -1);
                    }
                }

            }
           
            return dt;
        }

        #endregion
    }
}