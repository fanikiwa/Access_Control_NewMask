using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class HolidayPlanCalendarMappedRepository: KruAllBaseRepository<HolidayPlanCalendarMapped>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMapped> GetHolidayPlanCalendars()
        {
            return base.GetAll().Include(p => p.HolidayPlanCalendarMonthMappeds).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMapped GetHolidayPlanCalendarById(long id)
        {
            return base.FindBy(b => b.Id == id).Include(p => p.HolidayPlanCalendarMonthMappeds).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMapped GetHolidayPlanCalendarByNumber(long calendarNumber)
        {
            return base.FindBy(b => b.HolidayPlanCalendarNumber == calendarNumber).Include(p => p.HolidayPlanCalendarMonthMappeds).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMapped GetHolidayPlanCalendarByCalendarYear(int calendarYear)
        {
            return base.FindBy(b => b.CalendarYear == calendarYear).Include(p => p.HolidayPlanCalendarMonthMappeds).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHolidayPlanCalendar(HolidayPlanCalendarMapped holidayPlanCalendarMapped)
        {
            base.Add(holidayPlanCalendarMapped);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditHolidayPlanCalendar(HolidayPlanCalendarMapped switchCalendar)
        {
            if (switchCalendar.Id == 0) return;
            base.Edit(switchCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayPlanCalendar(HolidayPlanCalendarMapped switchCalendar)
        {
            if (switchCalendar.Id == 0) return;
            var currentDailyCalendar = GetHolidayPlanCalendarById(switchCalendar.Id);
            base.Delete(currentDailyCalendar);

            Save();
        }
    }
}
