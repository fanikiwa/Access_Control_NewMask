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
    public class VisitorPlanRepository: KruAllBaseRepository<TbVisitorPlan>
    {

        #region Constructor
        public VisitorPlanRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbVisitorPlan> GetAllVisitorPlans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbVisitorPlan> GetAllVisitorPlansByPlanId(long buildingPlanId)
        {
            return base.GetAll().Where(x => x.BuildingPlanID == buildingPlanId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public TbVisitorPlan GetVisitorPlanById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public TbVisitorPlan GetVisitorPlanByNumber(long visitorPlan_Nr)
        {
            return base.FindBy(e => e.VisitorPlanNr == visitorPlan_Nr).FirstOrDefault();
        }

        //public List<TbAccessPlan> GetAccessPlansByHolidayCalendarYear(int calendarYear)
        //{
        //    return base.GetAll().Include(a => a.HolidayPlanCalendar).Where(b => b.HolidayPlanCalendar.CalendarYear == calendarYear).ToList();
        //}

        //public TbAccessPlan AccessPlanByName(string accessPlanName)
        //{
        //    return base.FindBy(e => e.AccessPlanDescription == accessPlanName).FirstOrDefault();
        //}

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVisitorPlan(TbVisitorPlan visitorPlan)
        {
            base.Add(visitorPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVisitorPlan(TbVisitorPlan visitorPlan)
        {
            if (visitorPlan.ID == 0) return;
            base.Edit(visitorPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitorPlan(TbVisitorPlan visitorPlan)
        {
            if (visitorPlan.ID == 0) return;
            var currentVisitorPlan = GetVisitorPlanById(visitorPlan.ID);
            Delete(currentVisitorPlan);
            Save();
        }

        #endregion
    }
}
