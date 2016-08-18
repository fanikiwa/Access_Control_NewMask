using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessPlanMembersMappingViewModel
    {
        #region ProMemberties

        readonly AccessPlanMembersMappingRepository _accessPlanMembersMappingRepository = new AccessPlanMembersMappingRepository();

        #endregion

        #region Methods

        public List<TbAccessPlanMembersMapping> GetAllMappings()
        {
            return _accessPlanMembersMappingRepository.GetAllMappings();
        }

        public TbAccessPlanMembersMapping GetById(long id)
        {
            return _accessPlanMembersMappingRepository.GetById(id);
        }

        public List<TbAccessPlanMembersMapping> GetByPlanNumber(long accessPlanNumber)
        {
            return _accessPlanMembersMappingRepository.GetByPlanNumber(accessPlanNumber);
        }
        public List<TbAccessPlanMembersMapping> GetMembersByPlanID(long accessPlanID)
        {
            return _accessPlanMembersMappingRepository.GetMembersByPlanID(accessPlanID);
        }

        public List<TbAccessPlanMembersMapping> GetByEmployeeNumber(long employeeNumber)
        {
            return _accessPlanMembersMappingRepository.GetByEmployeeNumber(employeeNumber);
        }

        public TbAccessPlanMembersMapping GetMappingByEmployeeNumber(long employeeNumber)
        {
            return _accessPlanMembersMappingRepository.GetMappingByEmployeeNumber(employeeNumber);
        }
        public TbAccessPlanMembersMapping GetByPlanNumberByEmployeeNumber(long accessPlanNumber, long employeeNumber)
        {
            return _accessPlanMembersMappingRepository.GetByPlanNumberByEmployeeNumber(accessPlanNumber, employeeNumber);
        }

        public void CreateMapping(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            _accessPlanMembersMappingRepository.NewAccessPlanMembersMapping(accessPlanMembersMapping);
        }

        public void DeleteMapping(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            _accessPlanMembersMappingRepository.DeleteAccessPlanMembersMapping(accessPlanMembersMapping);
        }
        public void DeleteMappingCustom(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            _accessPlanMembersMappingRepository.DeleteAccessPlanMembersMappingCustom(accessPlanMembersMapping);
        }
        #endregion Methods
    }
}