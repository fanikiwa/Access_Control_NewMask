using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class VisitorVehicleRepository: KruAllBaseRepository<Visitor_Vehicle>
    {
        #region Constructor
        public VisitorVehicleRepository() { }
        #endregion
        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Visitor_Vehicle GetVehicleByVisitorId(long id)
        {
            return base.FindBy(cc => cc.VisitorID == id).Include(x => x.VehicleType).FirstOrDefault();
        }



        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVehicle(Visitor_Vehicle vehicle)
        {
            base.Add(vehicle);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void Editvehicle(Visitor_Vehicle vehicle)
        {
            if (vehicle.ID == 0) return;
            base.Edit(vehicle);
            Save();
        }

        #endregion

    }
}
