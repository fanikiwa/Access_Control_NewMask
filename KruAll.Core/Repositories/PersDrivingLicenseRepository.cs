

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
    public class PersDrivingLicenseRepository : KruAllBaseRepository<Pers_DrivingLicense>
    {
        #region Constructor
        public PersDrivingLicenseRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_DrivingLicense> GetPersDrivingLicenses()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_DrivingLicense GetPersDrivingLicenseByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersDrivingLicense(Pers_DrivingLicense drivingLicense)
        {
            base.Add(drivingLicense);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersDrivingLicenseCustom(Pers_DrivingLicense drivingLicense)
        {
            base.Add(drivingLicense);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersDrivingLicense(Pers_DrivingLicense drivingLicense)
        {
            if (drivingLicense.ID == 0) return;
            base.Edit(drivingLicense);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersDrivingLicenseCustom(Pers_DrivingLicense drivingLicense)
        {
            if (drivingLicense.ID == 0) return;
            base.Edit(drivingLicense);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersDrivingLicense(Pers_DrivingLicense drivingLicense)
        {
            if (drivingLicense.ID == 0) return;
            base.Delete(drivingLicense);
            Save();
        }
        #endregion
    }
}
