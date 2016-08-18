using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class HolidayScheduleRepository: KruAllBaseRepository<HolidayPlanCalendar>
    {

        #region Constructor
        public HolidayScheduleRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<HolidayPlanCalendar> GetAllHolidayPlans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public HolidayPlanCalendar GetHolidayById(long holidayPlanId)
        {
            return base.GetAll().Where(x => x.Id == holidayPlanId).FirstOrDefault();
        }

        public HolidayPlanCalendar GetHolidayPlanByNumber(long holidayPlanNr)
        {
            return base.FindBy(e => e.HolidayPlanCalendarNumber == holidayPlanNr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewHolidayPlan(HolidayPlanCalendar holidayPlan)
        {
            base.Add(holidayPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditHolidayPlan(HolidayPlanCalendar holidayPlan)
        {
            if (holidayPlan.Id == 0) return;
            base.Edit(holidayPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteHolidayPlan(HolidayPlanCalendar holidayPlan)
        {
            if (holidayPlan.Id == 0) return;
            var currentHolidayPlan = GetHolidayById(holidayPlan.Id);
            Delete(currentHolidayPlan);
            Save();
        }

        #endregion
    }
}
