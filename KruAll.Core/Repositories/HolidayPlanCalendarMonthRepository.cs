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
    public class HolidayPlanCalendarMonthRepository: KruAllBaseRepository<HolidayPlanCalendarMonth>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMonth> GetHolidayPlanCalendarMonths()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMonth> GetHolidayPlanCalendarMonthsByHolidayPlanCalendarIdGetCalendarId(long holidayCalendarId)
        {
            return base.GetAll().Where(p => p.HolidayPlanCalendarId == holidayCalendarId).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMonth GetHolidayPlanCalendarMonthById(long id)
        {
            return base.FindBy(b => b.Id == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMonth GetHolidayPlanCalendarMonthByCalendarMonth(long holidayCalendarId, int calendarMonth)
        {
            return base.FindBy(b => b.CalendarMonth == calendarMonth && b.HolidayPlanCalendarId == holidayCalendarId).Include(s => s.HolidayPlanCalendar).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHolidayPlanCalendarMonth(HolidayPlanCalendarMonth holidayPlanCalendarMonth)
        {
            base.Add(holidayPlanCalendarMonth);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayPlanCalendarMonth(HolidayPlanCalendarMonth holidayPlanCalendarMonth)
        {
            if (holidayPlanCalendarMonth.Id == 0) return;
            var currentHolidayPlanCalendarMonth = GetHolidayPlanCalendarMonthById(holidayPlanCalendarMonth.Id);
            base.Delete(currentHolidayPlanCalendarMonth);

            Save();
        }
    }
}
