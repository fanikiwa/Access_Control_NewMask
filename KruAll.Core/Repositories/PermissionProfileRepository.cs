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
    public class PermissionProfileRepository : KruAllBaseRepository<AC_PermissionProfile>
    {
        #region Constructor
        public PermissionProfileRepository() { }
        #endregion

        PermissionMappingRepository permissionMappingRepository = new PermissionMappingRepository();

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_PermissionProfile> GetPermissionProfiles()
        {
            return base.GetAll().OrderBy(x => x.ProfileNr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_PermissionProfile GetPermissionProfileById(int id)
        {
            return base.FindBy(cc => cc.ID == id).FirstOrDefault();
        }

        public AC_PermissionProfile GetNextProfileNr()
        {
            return base.GetAll().OrderByDescending(x => x.ProfileNr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPermissionProfile(AC_PermissionProfile permissionProfile)
        {
            base.Add(permissionProfile);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPermissionsProfile(AC_PermissionProfile permissionProfile)
        {
            //if (permissionProfile.ID == 0) return;
            ////var permissionProfileEntity = GetPermissionProfileById(permissionProfile.ID);
            ////if (permissionProfileEntity == null) return;
            //AC_PermissionProfile newPermissionProfile = permissionProfile;
            //base.Delete(GetPermissionProfileById(permissionProfile.ID));
            //newPermissionProfile.ID = 0;
            //base.Add(newPermissionProfile);
            ////permissionProfileEntity.ProfileNr = permissionProfile.ProfileNr;
            ////permissionProfileEntity.ProfileDescription = permissionProfile.ProfileDescription;
            //////permissionProfileEntity.AC_PermissionMapping = new List<AC_PermissionMapping>();
            ////permissionProfileEntity.AC_PermissionMapping = permissionProfile.AC_PermissionMapping;
            //Save();


            if (permissionProfile.ID == 0) return;
            AC_PermissionProfile newPermissionProfile = permissionProfile;
            AC_PermissionProfile oldPermissionProfile = GetPermissionProfileById(permissionProfile.ID);
            newPermissionProfile.ID = 0;

            if (oldPermissionProfile != null)
            {
                List<AC_PersProfileMapping> persProfileMappingList = oldPermissionProfile.AC_PersProfileMapping.ToList<AC_PersProfileMapping>();
                newPermissionProfile.AC_PersProfileMapping = GetPersProfileMappings(persProfileMappingList, ref newPermissionProfile);
                base.Delete(oldPermissionProfile);
            }

            base.Add(newPermissionProfile);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePermissionsProfile(AC_PermissionProfile permissionProfile)
        {
            if (permissionProfile.ID == 0) return;
            var permissionProfileEntity = GetPermissionProfileById(permissionProfile.ID);
            if (permissionProfileEntity == null) return;
            base.Delete(permissionProfileEntity);
            Save();
        }

        private List<AC_PersProfileMapping> GetPersProfileMappings(List<AC_PersProfileMapping> persProfileMappingList, ref AC_PermissionProfile newPermissionProfile)
        {
            List<AC_PersProfileMapping> _persProfileMappingList = new List<AC_PersProfileMapping>();

            foreach (AC_PersProfileMapping persProfileMapping in persProfileMappingList)
            {
                _persProfileMappingList.Add(new AC_PersProfileMapping
                {
                    ID = 0,
                    ProfileID = 0,
                    AC_PermissionProfile = newPermissionProfile,
                    Pers_Nr = persProfileMapping.Pers_Nr
                });
            }

            return _persProfileMappingList;
        }
        #endregion
    }
}
