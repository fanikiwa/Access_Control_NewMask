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
    public class VehicleTypeRepository: KruAllBaseRepository<VehicleType>
    {
        #region Constructor
        public VehicleTypeRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VehicleType> GetVehicleType()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VehicleType GetVehicleTypeById(long id)
        {
            return base.FindBy(cc => cc.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VehicleType GetVehicleTypeByName(string name)
        {
            return base.FindBy(cc => cc.Name == name).FirstOrDefault();
        }
        public List<VehicleType> GetDistinctVehicleType()
        {
            return base.GetAll().ToList<VehicleType>();
        }
        public VehicleType GetVehicleByType(string VehicleType)
        {
            return base.FindBy(cc => cc.Name == VehicleType).FirstOrDefault();
            
        }
        public List<VehicleType> getVehicleTypeByNames(string name)
        {
            return base.FindBy(cc => cc.Name == name).ToList();
            

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVehicleType(VehicleType vehicleType)
        {
            base.Add(vehicleType);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditvehicleType(VehicleType vehicleType)
        {
            if (vehicleType.ID == 0) return;
            base.Edit(vehicleType);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VehicleType> GetVehiclesByType(string VehicleType)
        {
            if (VehicleType != "")
            {
                return base.FindBy(cc => cc.Name == VehicleType && (cc.Type != null || cc.Type != "")).ToList();

            }
            else { return base.GetAll().ToList(); }

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVehicleType(VehicleType vehicleType)
        {
            if (vehicleType.ID == 0) return;
            var currentvehicleType = GetVehicleTypeById(vehicleType.ID);
            base.Delete(currentvehicleType);
            Save();
        }
        //vehicleType photos
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VehicleType GetVehiclePhotoByVtypeNr(long vType_Nr)
        {
            return base.GetAll().Where(x => x.VehicleNr == vType_Nr).FirstOrDefault();
        }

        public VehicleType CheckIfVehicleModelExists(string VehicleType, string Model)
        {
            return base.FindBy(cc => cc.Name == VehicleType && cc.Type == Model).FirstOrDefault();
            
        }

        #endregion
    }
}
