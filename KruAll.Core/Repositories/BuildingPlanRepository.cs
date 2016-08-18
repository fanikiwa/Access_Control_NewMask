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
    public class BuildingPlanRepository: KruAllBaseRepository<BuildingPlan>
    {
        #region Constructor
        public BuildingPlanRepository() { }
        List<ReaderAssigned> assignedReader = new List<ReaderAssigned>();
        List<TbAccessPlan> accessPlan = new List<TbAccessPlan>();
        AccessPlanRepository accessPlanRepo = new AccessPlanRepository();
        List<KruAll.Core.Models.SwitchPlan> switchPlan = new List<KruAll.Core.Models.SwitchPlan>();
        SwitchPlanRepository swichPlanRepo = new SwitchPlanRepository();
        AssignReaderRepository readerRepo = new AssignReaderRepository();
        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<BuildingPlan> GetAllBuildingPlans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public BuildingPlan GetBuildingPlanById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public BuildingPlan GetBuildinPlanByNumber(int buildingPlan_Nr)
        {
            return base.FindBy(e => e.PlanNr == buildingPlan_Nr).FirstOrDefault();
        }

        public BuildingPlan BuildingPlanByName(string buildingPlanName)
        {
            return base.FindBy(e => e.PlanName == buildingPlanName).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewBuildingPlan(BuildingPlan buildingPlan)
        {
            base.Add(buildingPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditBuildingPlan(BuildingPlan buildingPlan)
        {
            if (buildingPlan.ID == 0) return;
            base.Edit(buildingPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteBuildingPlan(BuildingPlan buildingPlan)
        {
            if (buildingPlan.ID == 0) return;
            var currentBuildingPlan = GetBuildingPlanById(buildingPlan.ID);
            Delete(currentBuildingPlan);
            Save();

        }

        #endregion
    }
}
