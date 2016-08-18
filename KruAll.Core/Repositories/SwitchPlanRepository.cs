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
    public class SwitchPlanRepository: KruAllBaseRepository<SwitchPlan>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<SwitchPlan> GetSwitchPlans()
        {
            return base.GetAll().Include(p => p.SwitchCalendar).Include(p => p.SwitchCalendar).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<SwitchPlan> GetSwitchPlansByPlanId(long buildingPlanId)
        {
            return base.GetAll().Where(x => x.BuidingPlanID == buildingPlanId).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SwitchPlan GetSwitchPlanById(long id)
        {
            return base.FindBy(b => b.Id == id).Include(p => p.SwitchCalendar).Include(p => p.SwitchCalendar).FirstOrDefault();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SwitchPlan GetSwitchPlanByIDCustom(long id)
        {
            return base.FindBy(b => b.Id == id).FirstOrDefault();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SwitchPlan GetSwitchPlanByNumber(long switchPlanNumber)
        {
            return base.FindBy(b => b.SwitchPlanNumber == switchPlanNumber).Include(p => p.SwitchCalendar).Include(p => p.HolidayPlanCalendarId).FirstOrDefault();
        }

        public List<SwitchPlan> GetSwitchPlansByHolidayCalendarYear(int calendarYear)
        {
            return base.GetAll().Include(a => a.HolidayPlanCalendarId).Where(b => b.HolidayPlanCalendarId.Value == calendarYear).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewSwitchPlan(SwitchPlan switchPlan)
        {
            base.Add(switchPlan);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditSwitchPlan(SwitchPlan switchPlan)
        {
            if (switchPlan.Id == 0) return;
            base.Edit(switchPlan);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteSwitchPlan(SwitchPlan switchPlan)
        {
            if (switchPlan.Id == 0) return;
            var currentDailyCalendar = GetSwitchPlanById(switchPlan.Id);
            base.Delete(currentDailyCalendar);

            Save();
        }
    }
}
