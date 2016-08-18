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
    public class HolidayCalendarRepository : KruAllBaseRepository<HolidayCalendar>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayCalendar> GetHolidayCalendars()
        {
            return base.GetAll().Include(p => p.HolidayCalendarMonths).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayCalendarById(long id)
        {
            return base.FindBy(b => b.Id == id).Include(p => p.HolidayCalendarMonths).FirstOrDefault();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayById(long id)
        {
            return base.FindBy(b => b.Id == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayCalendarByNumber(long calendarNumber)
        {
            return base.FindBy(b => b.HolidayCalendarNumber == calendarNumber).OrderByDescending(p => p.Id).Include(p => p.HolidayCalendarMonths).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayCalendar GetHolidayCalendarByCalendarYear(int calendarYear)
        {
            return base.FindBy(b => b.CalendarYear == calendarYear).Include(p => p.HolidayCalendarMonths).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHolidayCalendar(HolidayCalendar holidayCalendar)
        {
            base.Add(holidayCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditHolidayCalendar(HolidayCalendar switchCalendar)
        {
            if (switchCalendar.Id == 0) return;
            base.Edit(switchCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayCalendar(HolidayCalendar switchCalendar)
        {
            if (switchCalendar.Id == 0) return;
            var currentDailyCalendar = GetHolidayCalendarById(switchCalendar.Id);
            base.Delete(currentDailyCalendar);

            Save();
        }
    }
}
