using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class SwitchPlanViewModel
    {
        private readonly SwitchPlanRepository _switchPlanRepository = new SwitchPlanRepository();

        #region SwitchPlan Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<SwitchPlan> GetSwitchPlans()
        {
            return _switchPlanRepository.GetSwitchPlans();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SwitchPlan GetSwitchPlanById(long id)
        {
            return _switchPlanRepository.GetSwitchPlanById(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SwitchPlan GetSwitchPlanByNumber(long switchPlanNumber)
        {
            return _switchPlanRepository.GetSwitchPlanByNumber(switchPlanNumber);
        }

        public List<SwitchPlan> GetSwitchPlansByHolidayCalendarYear(int calendarYear)
        {
            return _switchPlanRepository.GetSwitchPlansByHolidayCalendarYear(calendarYear);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public SwitchPlan CreateSwitchPlan(SwitchPlan switchPlan)
        {
            _switchPlanRepository.NewSwitchPlan(switchPlan);

            var newSwitchPlan = GetSwitchPlanByNumber(switchPlan.SwitchPlanNumber);

            return newSwitchPlan;
        }

        public SwitchPlan EditSwitchPlan(SwitchPlan switchPlan)
        {
            _switchPlanRepository.EditSwitchPlan(switchPlan);

            var editedSwitchPlan = GetSwitchPlanByNumber(switchPlan.SwitchPlanNumber);

            return editedSwitchPlan;
        }

        public void DeleteSwitchPlan(SwitchPlan switchPlan)
        {
            _switchPlanRepository.DeleteSwitchPlan(switchPlan);
        }

        #endregion
    }
}