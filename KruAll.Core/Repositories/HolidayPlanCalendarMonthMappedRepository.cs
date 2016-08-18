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
    public class HolidayPlanCalendarMonthMappedRepository : KruAllBaseRepository<HolidayPlanCalendarMonthMapped>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMonthMapped> GetHolidayPlanCalendarMonths()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendarMonthMapped> GetHolidayPlanCalendarMonthsByHolidayPlanCalendarIdGetCalendarId(long holidayCalendarId)
        {
            return base.GetAll().Where(p => p.HolidayPlanCalendarId == holidayCalendarId).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMonthMapped GetHolidayPlanCalendarMonthById(long id)
        {
            return base.FindBy(b => b.Id == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendarMonthMapped GetHolidayPlanCalendarMonthByCalendarMonth(long holidayCalendarId, int calendarMonth)
        {
            return base.FindBy(b => b.CalendarMonth == calendarMonth && b.HolidayPlanCalendarId == holidayCalendarId).Include(s => s.HolidayPlanCalendarMapped).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHolidayPlanCalendarMonth(HolidayPlanCalendarMonthMapped holidayPlanCalendarMonthMapped)
        {
            base.Add(holidayPlanCalendarMonthMapped);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayPlanCalendarMonth(HolidayPlanCalendarMonthMapped holidayPlanCalendarMonthMapped)
        {
            if (holidayPlanCalendarMonthMapped.Id == 0) return;
            var currentHolidayPlanCalendarMonth = GetHolidayPlanCalendarMonthById(holidayPlanCalendarMonthMapped.Id);
            base.Delete(currentHolidayPlanCalendarMonth);

            Save();
        }
    }
}
