using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class HolidayScheduleViewModel
    {
        #region Properties
        HolidayScheduleRepository planRepository = new HolidayScheduleRepository();
        HolidayCalendarRepository calenderRepository = new HolidayCalendarRepository();
        HolidayPlanAccessProfileMonthRepository accessPLanCalenderdays = new HolidayPlanAccessProfileMonthRepository();
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendar> HolidayPlans()
        {
            return planRepository.GetAllHolidayPlans();
        }
        public HolidayPlanCalendar GetHolidayPlanByID(long id)
        {
            return planRepository.GetHolidayById(id);
        }
        public HolidayPlanCalendar GetHolidayPlanByNr(long Nr)
        {
            return planRepository.GetHolidayPlanByNumber(Nr);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateHolidayPlan(HolidayPlanCalendar holidayPlan)
        {
            planRepository.NewHolidayPlan(holidayPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateHolidayPlan(HolidayPlanCalendar holidayPlan)
        {
            planRepository.EditHolidayPlan(holidayPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayPlan(HolidayPlanCalendar holidayPlan)
        {
            planRepository.DeleteHolidayPlan(holidayPlan);
        }
        public HolidayCalendar GetHolidayCalenderByID(long id)
        {
            return calenderRepository.GetHolidayById(id);
        }
        public List<HolidayPlanAccessProfileMonth> GetPlanCalendarMonthsByCalenderID(long id)
        {
            return accessPLanCalenderdays.GetProfileMonthByCalendarId(id);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanCalendar(long id)
        {
            var holidayPlanCalendarMonths = GetPlanCalendarMonthsByCalenderID(id);
            if (holidayPlanCalendarMonths == null) return;

            foreach (var holidayPlanMonth in holidayPlanCalendarMonths)
            {
                accessPLanCalenderdays.DeleteProfileMonth(holidayPlanMonth);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateHolidayAccessProfileCalendarMonths(HolidayPlanCalendar holidayCalendar)
        {
            var accessProfileCalendarMonths = holidayCalendar.HolidayPlanAccessProfileMonths;
            foreach (var accessCalendarMonth in accessProfileCalendarMonths)
            {
                var _AccessCalendarMonth = new HolidayPlanAccessProfileMonth { HolidayPlanCalendarId = holidayCalendar.Id, CalendarMonth = accessCalendarMonth.CalendarMonth };

                for (var dayOfMonth = 1; dayOfMonth <= 31; dayOfMonth++)
                {
                    var dayAccessProfileProperty = string.Format("Day{0}AccessProfileId", dayOfMonth);
                    var propertyInfo = accessCalendarMonth.GetType().GetProperty(dayAccessProfileProperty);

                    var propertyValue = (long)propertyInfo.GetValue(accessCalendarMonth);

                    var newPropertyInfo = _AccessCalendarMonth.GetType().GetProperty(dayAccessProfileProperty);
                    newPropertyInfo.SetValue(_AccessCalendarMonth, propertyValue, null);
                }

                CreateHolidayPlanMonth(_AccessCalendarMonth);
            }
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateHolidayPlanMonth(HolidayPlanAccessProfileMonth holidayPlan)
        {
            accessPLanCalenderdays.NewProfileMonth(holidayPlan);
        }

        #endregion
    }
}