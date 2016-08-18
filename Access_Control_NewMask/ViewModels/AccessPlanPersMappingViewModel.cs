using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessPlanPersMappingViewModel
    {
        #region Properties

        readonly AccessPlanPersMappingRepository _accessPlanPersMappingRepository = new AccessPlanPersMappingRepository();

        #endregion

        #region Methods

        public List<TbAccessPlanPersMapping> GetAllMappings()
        {
            return _accessPlanPersMappingRepository.GetAllMappings();
        }

        public TbAccessPlanPersMapping GetById(long id)
        {
            return _accessPlanPersMappingRepository.GetById(id);
        }

        public List<TbAccessPlanPersMapping> GetByPlanNumber(long accessPlanNumber)
        {
            return _accessPlanPersMappingRepository.GetByPlanNumber(accessPlanNumber);
        }

        public List<TbAccessPlanPersMapping> GetByEmployeeNumber(long employeeNumber)
        {
            return _accessPlanPersMappingRepository.GetByEmployeeNumber(employeeNumber);
        }

        public TbAccessPlanPersMapping GetMappingByEmployeeNumber(long employeeNumber)
        {
            return _accessPlanPersMappingRepository.GetMappingByEmployeeNumber(employeeNumber);
        }
        public TbAccessPlanPersMapping GetByPlanNumberByEmployeeNumber(long accessPlanNumber, long employeeNumber)
        {
            return _accessPlanPersMappingRepository.GetByPlanNumberByEmployeeNumber(accessPlanNumber, employeeNumber);
        }

        public void CreateMapping(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            _accessPlanPersMappingRepository.NewAccessPlanPersMapping(accessPlanPersMapping);
        }

        public void DeleteMapping(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            _accessPlanPersMappingRepository.DeleteAccessPlanPersMapping(accessPlanPersMapping);
        }
        public void DeleteMappingCustom(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            _accessPlanPersMappingRepository.DeleteAccessPlanPersMappingCustom(accessPlanPersMapping);
        }
        #endregion Methods
    }
}