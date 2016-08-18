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
    public class HolidayCalendarMonthRepository : KruAllBaseRepository<HolidayCalendarMonth>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayCalendarMonth> GetHolidayCalendarMonths()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayCalendarMonth> GetHolidayCalendarMonthsByHolidayCalendarId(long holidayCalendarId)
        {
            return base.GetAll().Where(p => p.HolidayCalendarId == holidayCalendarId).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendarMonth GetHolidayCalendarMonthById(long id)
        {
            return base.FindBy(b => b.Id == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendarMonth GetHolidayCalendarMonthByCalendarMonth(long holidayCalendarId, int calendarMonth)
        {
            return base.FindBy(b => b.CalendarMonth == calendarMonth && b.HolidayCalendarId == holidayCalendarId).Include(s => s.HolidayCalendar).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHolidayCalendarMonth(HolidayCalendarMonth holidayCalendarMonth)
        {
            base.Add(holidayCalendarMonth);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayCalendarMonth(HolidayCalendarMonth holidayCalendarMonth)
        {
            if (holidayCalendarMonth.Id == 0) return;
            var currentHolidayCalendarMonth = GetHolidayCalendarMonthById(holidayCalendarMonth.Id);
            base.Delete(currentHolidayCalendarMonth);

            Save();
        }
    }
}
