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
    public class HolidayPlanCalendarRepository: KruAllBaseRepository<HolidayPlanCalendar>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendar> GetHolidayPlanCalendars()
        {
            return base.GetAll().Include(p => p.HolidayPlanCalendarMonths).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarById(long id)
        {
            return base.FindBy(b => b.Id == id).Include(p => p.HolidayPlanCalendarMonths).FirstOrDefault();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarById2(long id)
        {
            return base.FindBy(b => b.Id == id).Include(p => p.HolidayPlanAccessProfileMonths).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarByNumber(long calendarNumber)
        {
            return base.FindBy(b => b.HolidayPlanCalendarNumber == calendarNumber).Include(p => p.HolidayPlanCalendarMonths).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayPlanCalendarByCalendarYear(int calendarYear)
        {
            return base.FindBy(b => b.CalendarYear == calendarYear).Include(p => p.HolidayPlanCalendarMonths).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHolidayPlanCalendar(HolidayPlanCalendar holidayPlanCalendar)
        {
            base.Add(holidayPlanCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditHolidayPlanCalendar(HolidayPlanCalendar switchCalendar)
        {
            if (switchCalendar.Id == 0) return;
            base.Edit(switchCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayPlanCalendar(HolidayPlanCalendar switchCalendar)
        {
            if (switchCalendar.Id == 0) return;
            var currentDailyCalendar = GetHolidayPlanCalendarById(switchCalendar.Id);
            base.Delete(currentDailyCalendar);

            Save();
        }
    }
}
