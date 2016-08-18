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
    public class PersVehicleRepository : KruAllBaseRepository<Pers_Vehicles>
    {
        #region Constructor
        public PersVehicleRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Vehicles> GetVehicles()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Vehicles GetPersVehiclesByPersNr(long persNr)
        {
            return base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVehicles(Pers_Vehicles vehicles)
        {
            base.Add(vehicles);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVehiclesCustom(Pers_Vehicles vehicles)
        {
            base.Add(vehicles);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVehicles(Pers_Vehicles vehicles)
        {
            if (vehicles.ID == 0) return;
            base.Edit(vehicles);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVehiclesCustom(Pers_Vehicles vehicles)
        {
            if (vehicles.ID == 0) return;
            base.Edit(vehicles);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVehicles(Pers_Vehicles vehicles)
        {
            if (vehicles.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(vehicles);
            Save();
        }
        #endregion
    }
}
