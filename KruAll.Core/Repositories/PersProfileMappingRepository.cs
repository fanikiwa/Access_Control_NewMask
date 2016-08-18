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
    public class PersProfileMappingRepository : KruAllBaseRepository<AC_PersProfileMapping>
    {
        #region Constructor
        public PersProfileMappingRepository() { }
        #endregion

        #region Methods

        public List<AC_PersProfileMapping> GetPersProfileMappings()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        public AC_PersProfileMapping GetPersProfileMapping(int persNr)
        {
            return base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
        }

        public int GetPersProfileMappingId(int persNr)
        {
            AC_PersProfileMapping persProfileMapping;
            persProfileMapping = base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
            if (persProfileMapping == null)
                persProfileMapping = new AC_PersProfileMapping();
            return persProfileMapping.ProfileID;
        }

        public AC_PersProfileMapping GetPersProfileMappingByPersNr(int persNr)
        {
            AC_PersProfileMapping persProfileMapping;
            persProfileMapping = base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
            if (persProfileMapping == null)
                persProfileMapping = new AC_PersProfileMapping();
            return persProfileMapping;
        }

        public void AddPersProfileMapping(AC_PersProfileMapping persProfileMapping)
        {
            AC_PersProfileMapping persProfileMappingEntity = GetPersProfileMapping(persProfileMapping.Pers_Nr);
            if (persProfileMappingEntity != null) base.Delete(persProfileMappingEntity);
            base.Add(persProfileMapping);
            Save();
        }

        public void EditPermissionsProfile(AC_PersProfileMapping persProfileMapping)
        {
            if (persProfileMapping.ID == 0) return;
            base.Edit(persProfileMapping);
            Save();
        }

        public void DeletePersProfileMapping(AC_PersProfileMapping persProfileMapping)
        {
            if (persProfileMapping.Pers_Nr == 0) return;
            var persProfileMappingEntity = GetPersProfileMapping(persProfileMapping.Pers_Nr);
            if (persProfileMappingEntity == null) return;
            base.Delete(persProfileMappingEntity);
            Save();
        }

        public void DeletePersProfileMapping(int persNr)
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

