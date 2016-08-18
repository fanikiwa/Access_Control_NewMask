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
    public class CostCenterRepository : KruAllBaseRepository<CostCenter>
    {
        #region Constructor
        public CostCenterRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<CostCenter> GetCostCenters()
        {
            return base.GetAll().OrderBy(x => x.CostCenter_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public CostCenter GetCostCenterById(long id)
        {
            return base.FindBy(cc => cc.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public CostCenter GetCostCenterByNr(int id)
        {

            return base.FindBy(cc => cc.CostCenter_Nr == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public CostCenter GetCostCenterByName(string name)
        {
            return base.FindBy(cc => cc.Name == name).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<CostCenter> GetCostCenterByLocationId(int locationId)
        {
            return base.FindBy(cc => cc.LocationId == locationId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewCostCenters(CostCenter costCenter)
        {
            base.Add(costCenter);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditCostCenter(CostCenter costcenter)
        {
            if (costcenter.ID == 0) return;
            base.Edit(costcenter);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteCostCenter(CostCenter costcenter)
        {
            if (costcenter.ID == 0) return;
            var currentCostCentre = GetCostCenterById(costcenter.ID);
            base.Delete(currentCostCentre);
            Save();
        }
        #endregion
    }
}
