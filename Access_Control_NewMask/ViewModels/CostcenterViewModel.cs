using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class CostcenterViewModel
    {
        #region Constructor
        public CostcenterViewModel() { }

        #endregion

        #region Properties

        LocationRepository _locationRepoository = new LocationRepository();
        CostCenterRepository _costcenterRepository = new CostCenterRepository();

        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Location> Locations()
        {
            return _locationRepoository.GetLocations();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<CostCenter> Costcenters()
        {
            return _costcenterRepository.GetCostCenters();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public CostCenter GetCostcenterById(int id)
        {
            return _costcenterRepository.GetCostCenterById(id);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateCostCenter(CostCenter costcenter)
        {
            _costcenterRepository.NewCostCenters(costcenter);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateCostCenter(CostCenter costcenter)
        {
            _costcenterRepository.EditCostCenter(costcenter);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteCostCenter(CostCenter costcenter)
        {
            _costcenterRepository.DeleteCostCenter(costcenter);
        }

        #endregion
    }
}