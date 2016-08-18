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
    public class LocationFederalStateRepository : KruAllBaseRepository<LocationsFederalState>
    {
        #region Constructor
        public LocationFederalStateRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<LocationsFederalState> GetAllLocationFederalStates()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public LocationsFederalState GetLocationFederalStateById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public LocationsFederalState GetLocationFederalStateByNr(int id)
        {
            return base.FindBy(e => e.StateNo == id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewLocationFederalState(LocationsFederalState LocationsFederalState)
        {
            base.Add(LocationsFederalState);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditLocationFederalState(LocationsFederalState LocationsFederalState)
        {
            if (LocationsFederalState.ID == 0) return;
            base.Edit(LocationsFederalState);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteLocationFederalState(LocationsFederalState LocationsFederalState)
        {
            if (LocationsFederalState.ID == 0) return;
            var currentLocationFederalState = GetLocationFederalStateById(LocationsFederalState.ID);
            Delete(currentLocationFederalState);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteLocationFederalStateById(long id)
        {
            if (id == 0) return;
            var currentLocationFederalState = GetLocationFederalStateById(id);
            Delete(currentLocationFederalState);
            Save();
        }

        #endregion
    }
}
