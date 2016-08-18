using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessPlanViewModel
    {
        #region Properties
        AccessPlanRepository accessRepository = new AccessPlanRepository();
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbAccessPlan> AccessPlans()
        {
            return accessRepository.GetAllAccessPlans();
        }
        public TbAccessPlan GetAccessPlanByID(long id)
        {
            return accessRepository.GetAccessPlanById(id);
        }
        public TbAccessPlan GetAccessPlanByNr(long Nr)
        {
            return accessRepository.GetAccessPlanByNumber(Nr);
        }

        public List<TbAccessPlan> GetAccessPlansByHolidayCalendarYear(int calendarYear)
        {
            return accessRepository.GetAccessPlansByHolidayCalendarYear(calendarYear);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateAccessPlan(TbAccessPlan accessPlan)
        {
            accessRepository.NewAccessPlan(accessPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateAccessPlan(TbAccessPlan accessPlan)
        {
            accessRepository.EditAccessPlan(accessPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlan(TbAccessPlan accessPlan)
        {
            accessRepository.DeleteAccessPlan(accessPlan);
        }


        #endregion
    }
}