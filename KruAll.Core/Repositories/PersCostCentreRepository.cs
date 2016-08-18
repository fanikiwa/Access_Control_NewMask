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
    public class PersCostCentreRepository : KruAllBaseRepository<Pers_CostCenters>
    {
        #region Constructor
        public PersCostCentreRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_CostCenters> GetCostCentres()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_CostCenters GetCostCenterPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewCostCentre(Pers_CostCenters costcentre)
        {
            base.Add(costcentre);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewCostCentreCustom(Pers_CostCenters costcentre)
        {
            base.Add(costcentre);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditCostCentre(Pers_CostCenters costcentre)
        {
            if (costcentre.ID == 0) return;
            base.Edit(costcentre);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditCostCentreCustom(Pers_CostCenters costcentre)
        {
            if (costcentre.ID == 0) return;
            base.Edit(costcentre);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteCostCentren(Pers_CostCenters costcentre)
        {
            if (costcentre.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(costcentre);
            Save();
        }
        #endregion
    }
}
