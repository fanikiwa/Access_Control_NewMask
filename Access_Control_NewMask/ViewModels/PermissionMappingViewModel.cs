using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KruAll.Core.Repositories;
using System.ComponentModel;
using KruAll.Core.Models;
using Access_Control_NewMask.Dtos;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.ViewModels
{

    class PermissionMappingViewModel
    {
        readonly PermissionMappingRepository _permissionMappingRepository = new PermissionMappingRepository();


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AC_PermissionMapping> GetPermissionMappingsByProfileId(int id)
        {
            return _permissionMappingRepository.GetPermissionMappingsByProfileId(id);
        }

        public void AddPermissionsProfile(AC_PermissionMapping permissionsProfile)
        {
            //_permissionMappingRepository.AddPermissionProfile(permissionsProfile);
        }

        public void EditPermissionsProfile(AC_PermissionMapping permissionsProfile)
        {
            //_permissionMappingRepository.EditPermissionsProfile(permissionsProfile);
        }

        public void DeletePermissionsProfile(AC_PermissionMapping permissionsProfile)
        {
            //_permissionMappingRepository.DeletePermissionsProfile(permissionsProfile);
        }

        public PermissionDto2 GetPermissions(int id)
        {
            PermissionDto2 permissionsDto = new PermissionDto2();

            permissionsDto = new ZUTMain().GetPermissionsById(id);

            return permissionsDto;
        }
    }
}
