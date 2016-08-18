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
    public class AccessPlanPersMappingRepository : KruAllBaseRepository<TbAccessPlanPersMapping>
    {
        #region Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanPersMapping> GetAllMappings()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TbAccessPlanPersMapping GetById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanPersMapping> GetByPlanNumber(long accessPlanNumber)
        {
            return base.FindBy(e => e.AccessPlan_Nr == accessPlanNumber).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanPersMapping> GetByEmployeeNumber(long employeeNumber)
        {
            return base.FindBy(e => e.Pers_Nr == employeeNumber).ToList();
        }

        public TbAccessPlanPersMapping GetMappingByEmployeeNumber(long employeeNumber)
        {
            return base.FindBy(e => e.Pers_Nr == employeeNumber).Include(x => x.TbAccessPlan).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TbAccessPlanPersMapping GetByPlanNumberByEmployeeNumber(long accessPlanNumber, long employeeNumber)
        {
            return base.FindBy(e => e.AccessPlan_Nr == accessPlanNumber && e.Pers_Nr == employeeNumber).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanPersMapping(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            base.Add(accessPlanPersMapping);
            Save();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanPersMappingCustom(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            base.Add(accessPlanPersMapping);
            //Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanPersMapping(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            if (accessPlanPersMapping.ID == 0) return;
            base.Edit(accessPlanPersMapping);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanPersMappingCustom(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            if (accessPlanPersMapping.ID == 0) return;
            base.Edit(accessPlanPersMapping);
            //Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanPersMapping(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            if (accessPlanPersMapping.ID == 0) return;
            var currentAccessPlan = GetById(accessPlanPersMapping.ID);
            Delete(currentAccessPlan);
            Save();
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanPersMappingCustom(TbAccessPlanPersMapping accessPlanPersMapping)
        {
            if (accessPlanPersMapping.Pers_Nr == 0) return;
            var currentAccessPlan = GetMappingByEmployeeNumber(accessPlanPersMapping.Pers_Nr);
            Delete(currentAccessPlan);
            Save();
        }

        #endregion Methods
    }
}
