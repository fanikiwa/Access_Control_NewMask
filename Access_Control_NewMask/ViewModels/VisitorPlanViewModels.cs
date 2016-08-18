using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class VisitorPlanViewModels
    {
        #region Properties
        VisitorPlanRepository visitorRepository = new VisitorPlanRepository();
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbVisitorPlan> GetAllVisitorPlans()
        {
            return visitorRepository.GetAllVisitorPlans();
        }
        public TbVisitorPlan GetVisitorPlanByID(long id)
        {
            return visitorRepository.GetVisitorPlanById(id);
        }
        public TbVisitorPlan GetVisitorPlanByNr(long Nr)
        {
            return visitorRepository.GetVisitorPlanByNumber(Nr);
        }

        //public List<TbVisitorPlan> GetAccessPlansByHolidayCalendarYear(int calendarYear)
        //{
        //    return visitorRepository.GetAccessPlansByHolidayCalendarYear(calendarYear);
        //}

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateVisitorPlan(TbVisitorPlan visitorPlan)
        {
            visitorRepository.NewVisitorPlan(visitorPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateVisitorPlan(TbVisitorPlan visitorPlan)
        {
            visitorRepository.EditVisitorPlan(visitorPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitorPlan(TbVisitorPlan visitorPlan)
        {
            visitorRepository.DeleteVisitorPlan(visitorPlan);
        }


        #endregion

    }
}