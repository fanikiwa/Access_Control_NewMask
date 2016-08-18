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
    public class PersLocationRepository : KruAllBaseRepository<Pers_Locations>
    {
        #region Constructor
        public PersLocationRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Locations> GetLocations()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Locations GetPercLocationsPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        public Pers_Locations GetLocation(long LocationId)
        {
            return base.FindBy(x => x.LocationID == LocationId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewLocation(Pers_Locations location)
        {
            base.Add(location);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewLocationCustom(Pers_Locations location)
        {
            base.Add(location);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditLocation(Pers_Locations location)
        {
            if (location.ID == 0) return;
            base.Edit(location);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditLocationCustom(Pers_Locations location)
        {
            if (location.ID == 0) return;
            base.Edit(location);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteLocation(Pers_Locations location)
        {
            if (location.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(location);
            Save();
        }
        #endregion
    }
}
