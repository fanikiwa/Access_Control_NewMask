using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System.ComponentModel;

namespace KruAll.Core.Repositories
{
    public class PersProfileADMappingRepository : KruAllBaseRepository<AC_PersProfileADMapping>
    {
        #region Constructor
        public PersProfileADMappingRepository() { }
        #endregion

        #region Methods

        public List<AC_PersProfileADMapping> GetPersProfileMappings()
        {
            return base.GetAll().OrderBy(x => x.PersNr).ToList();
        }

        public AC_PersProfileADMapping GetPersProfileMapping(long persNr)
        {
            return base.FindBy(x => x.PersNr == persNr).FirstOrDefault();
        }

        public long GetPersProfileMappingId(long persNr)
        {
            AC_PersProfileADMapping persProfileMapping;
            persProfileMapping = base.FindBy(x => x.PersNr == persNr).FirstOrDefault();
            if (persProfileMapping == null)
                persProfileMapping = new AC_PersProfileADMapping();
            return persProfileMapping.ProfileID ?? 0;
        }

        public AC_PersProfileADMapping GetPersProfileMappingByPersNr(long persNr)
        {
            AC_PersProfileADMapping persProfileMapping;
            persProfileMapping = base.FindBy(x => x.PersNr == persNr).FirstOrDefault();
            if (persProfileMapping == null)
                persProfileMapping = new AC_PersProfileADMapping();
            return persProfileMapping;
        }

        public AC_PersProfileADMapping GetPersPasswordsByName(string persName)
        {
            AC_PersProfileADMapping persProfileMapping;
            persProfileMapping = base.FindBy(x => x.AD_Username == persName).FirstOrDefault();
            if (persProfileMapping == null)
                persProfileMapping = new AC_PersProfileADMapping();
            return persProfileMapping;
        }

        public void AddPersProfileMapping(AC_PersProfileADMapping persProfileMapping)
        {
            AC_PersProfileADMapping persProfileMappingEntity = GetPersProfileMapping(persProfileMapping.PersNr);
            if (persProfileMappingEntity != null) base.Delete(persProfileMappingEntity);
            base.Add(persProfileMapping);
            Save();
        }

        public void EditPermissionsProfile(AC_PersProfileADMapping persProfileMapping)
        {
            if (persProfileMapping.ID == 0) return;
            base.Edit(persProfileMapping);
            Save();
        }

        public void DeletePersProfileMapping(AC_PersProfileADMapping persProfileMapping)
        {
            if (persProfileMapping.PersNr == 0) return;
            var persProfileMappingEntity = GetPersProfileMapping(persProfileMapping.PersNr);
            if (persProfileMappingEntity == null) return;
            base.Delete(persProfileMappingEntity);
            Save();
        }

        public void DeletePersProfileMapping(long persNr)
        {
            if (persNr == 0) return;
            var persProfileMappingEntity = GetPersProfileMapping(persNr);
            if (persProfileMappingEntity == null) return;
            base.Delete(persProfileMappingEntity);
            Save();
        }
        #endregion
    }
}

