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
    public class AccessPlanRepository: KruAllBaseRepository<TbAccessPlan>
    {
        #region Constructor
        public AccessPlanRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbAccessPlan> GetAllAccessPlans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbAccessPlan> GetAllAccessPlansByPlanId(long buildingPlanId)
        {
            return base.GetAll().Where(x => x.BuildingPlanID == buildingPlanId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public TbAccessPlan GetAccessPlanById(long id)
        {
            //return base.FindBy(e => e.ID == id).FirstOrDefault();
            return base.GetAll().FirstOrDefault(e => e.ID == id);
        }
        public TbAccessPlan GetAccessPlanByNumber(long accessPlan_Nr)
        {
            return base.FindBy(e => e.AccessPlanNr == accessPlan_Nr).FirstOrDefault();
        }

        public List<TbAccessPlan> GetAccessPlansByHolidayCalendarYear(int calendarYear)
        {
            return base.GetAll().Include(a => a.HolidayPlanCalendar).Where(b => b.HolidayPlanCalendar.CalendarYear == calendarYear).ToList();
        }

        public TbAccessPlan AccessPlanByName(string accessPlanName)
        {
            return base.FindBy(e => e.AccessPlanDescription == accessPlanName).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessPlan(TbAccessPlan accessPlan)
        {
            base.Add(accessPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlan(TbAccessPlan accessPlan)
        {
            if (accessPlan.ID == 0) return;
            base.Edit(accessPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlan(TbAccessPlan accessPlan)
        {
            if (accessPlan.ID == 0) return;
            var currentAccessPlan = GetAccessPlanById(accessPlan.ID);
            Delete(currentAccessPlan);
            Save();
        }

        #endregion
    }
}
