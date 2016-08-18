using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class BuildingPlanViewModel
    {
        #region Properties
        BuildingPlanRepository planRepository = new BuildingPlanRepository();
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<BuildingPlan> BuildingPlans()
        {
            return planRepository.GetAllBuildingPlans();
        }
        public BuildingPlan GetBuildingPlanByID(long id)
        {
            return planRepository.GetBuildingPlanById(id);
        }
        public BuildingPlan GetBuildingPlanByNr(int Nr)
        {
            return planRepository.GetBuildinPlanByNumber(Nr);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateBuildingPlan(BuildingPlan buildingPlan)
        {
            planRepository.NewBuildingPlan(buildingPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateBuildingPlan(BuildingPlan buildingPlan)
        {
            planRepository.EditBuildingPlan(buildingPlan);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteBuildingPlan(BuildingPlan buildingPlan)
        {
            planRepository.DeleteBuildingPlan(buildingPlan);
        }


        #endregion
    }
}