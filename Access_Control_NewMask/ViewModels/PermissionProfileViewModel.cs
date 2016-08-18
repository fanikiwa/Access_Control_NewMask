using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KruAll.Core.Repositories;
using System.ComponentModel;
using KruAll.Core.Models;

namespace Access_Control_NewMask.ViewModels
{
    class PermissionProfileViewModel
    {
        public PermissionProfileRepository _permissionProfileRepository = new PermissionProfileRepository();

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AC_PermissionProfile> GetPermissionProfiles()
        {
            return _permissionProfileRepository.GetPermissionProfiles();
        }

        public int GetNextProfileNr()
        {
            AC_PermissionProfile lastProfile = _permissionProfileRepository.GetNextProfileNr();
            if (lastProfile == null) lastProfile = new AC_PermissionProfile();
            return (lastProfile.ProfileNr + 1);
        }

        public void AddPermissionsProfile(AC_PermissionProfile permissionsProfile)
        {
            _permissionProfileRepository.AddPermissionProfile(permissionsProfile);
        }

        public void EditPermissionsProfile(AC_PermissionProfile permissionsProfile)
        {
            _permissionProfileRepository.EditPermissionsProfile(permissionsProfile);
        }

        public void DeletePermissionsProfile(AC_PermissionProfile permissionsProfile)
        {
            _permissionProfileRepository.DeletePermissionsProfile(permissionsProfile);
        }
    }
}
