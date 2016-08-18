using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KruAll.Core.Repositories
{
    public class PersCostCenterRepository : KruAllBaseRepository<Pers_CostCenters>
    {


        #region Constructor
        public PersCostCenterRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_CostCenters> GetAllCostCenters()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_CostCenters GetCostCenterById(long id)
        {
            return base.FindBy(p => p.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_CostCenters GetCostCenterPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddCostCenter(Pers_CostCenters contact, bool save = true)
        {
            base.Add(contact);
            if (save) Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditCostCenter(Pers_CostCenters contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditCostCenterCustom(Pers_CostCenters contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            //Save()
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteCostCenter(Pers_CostCenters contact)
        {
            if (contact.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(contact);
            Save();
        }
        #endregion
    }
}
