using KruAll.Core.Models;
using KruAll.Core.Repositories;
using KruAll.Core.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.ViewModels
{
    public class PersCostCentreViewModel
    {
        #region Constructor
        public PersCostCentreViewModel() { }

        #endregion

        #region Properties
        private PersCostCenterRepository _PersCostCenterRepository = new PersCostCenterRepository();
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_CostCenters GetPersCostCenterById(long id)
        {
            var personnel = _PersCostCenterRepository.GetCostCenterById(id);
            return personnel;
        }

        public Pers_CostCenters GetPersCostCenterByPersNr(long Pers_Nr)
        {
            var personnel = _PersCostCenterRepository.GetCostCenterPersNr(Pers_Nr);
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_CostCenters> GetAllPersCostCenter()
        {
            var personnel = _PersCostCenterRepository.GetAllCostCenters();
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersCostCenter(Pers_CostCenters personnel, bool save = true)
        {
            _PersCostCenterRepository.AddCostCenter(personnel, save);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersCostCenter(Pers_CostCenters personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersCostCenterRepository.EditCostCenter(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersCostCenter(Pers_CostCenters personnel)
        {
            if (personnel.ID == 0) return;
            _PersCostCenterRepository.DeleteCostCenter(personnel);
        }
        #endregion
    }
}