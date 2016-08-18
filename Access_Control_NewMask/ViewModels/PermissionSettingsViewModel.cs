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
    class PermissionSettingsViewModel
    {
        readonly PersPasswordsRepository _persPasswordsRepository = new PersPasswordsRepository();
        readonly PersProfileMappingRepository _persProfileMappingRepository = new PersProfileMappingRepository();
        readonly PersProfileADMappingRepository _persProfileADMappingRepository = new PersProfileADMappingRepository();

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int GetPermissionProfile(int persNr)
        {
            return _persProfileMappingRepository.GetPersProfileMappingId(persNr);
        }

        public AC_PersProfileMapping GetPermissionProfileByPersNr(int persNr)
        {
            return _persProfileMappingRepository.GetPersProfileMappingByPersNr(persNr);
        }

        public AC_PersProfileADMapping GetPermissionProfileADByPersNr(int persNr)
        {
            return _persProfileADMappingRepository.GetPersProfileMappingByPersNr(persNr);
        }

        public void AddPersPassword(AC_PersPasswords persPassword)
        {
            _persPasswordsRepository.AddPassword(persPassword);
        }

        public void AddPersProfileMapping(AC_PersProfileMapping persProfileMapping)
        {
            _persProfileMappingRepository.AddPersProfileMapping(persProfileMapping);
        }

        public void DeletePersProfileMapping(AC_PersProfileMapping persProfileMapping)
        {
            _persProfileMappingRepository.DeletePersProfileMapping(persProfileMapping);
        }

        public void DeletePersProfileMapping(int persNr)
        {
            _persProfileMappingRepository.DeletePersProfileMapping(persNr);
        }

        public void AddPersProfileADMapping(AC_PersProfileADMapping persProfileMapping)
        {
            _persProfileADMappingRepository.AddPersProfileMapping(persProfileMapping);
        }

        public void DeletePersProfileADMapping(AC_PersProfileADMapping persProfileMapping)
        {
            _persProfileADMappingRepository.DeletePersProfileMapping(persProfileMapping);
        }

        public void DeletePersProfileADMapping(long persNr)
        {
            _persProfileADMappingRepository.DeletePersProfileMapping(persNr);
        }
    }
}
