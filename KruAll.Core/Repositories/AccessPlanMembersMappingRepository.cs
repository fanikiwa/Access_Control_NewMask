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
    public class AccessPlanMembersMappingRepository : KruAllBaseRepository<TbAccessPlanMembersMapping>
    {
        #region Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanMembersMapping> GetAllMappings()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TbAccessPlanMembersMapping GetById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanMembersMapping> GetByPlanNumber(long accessPlanNumber)
        {
            return base.FindBy(e => e.MembersData.MemberNumber == accessPlanNumber).ToList();
        }
        public List<TbAccessPlanMembersMapping> GetMembersByPlanID(long accessPlanID)
        {
            return base.FindBy(e => e.AccessPlan_ID == accessPlanID).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanMembersMapping> GetByEmployeeNumber(long employeeNumber)
        {
            return base.FindBy(e => e.MembersData.MemberNumber == employeeNumber).ToList();
        }

        public TbAccessPlanMembersMapping GetMappingByEmployeeNumber(long employeeNumber)
        {
            return base.FindBy(e => e.MembersData.MemberNumber == employeeNumber).Include(x => x.TbAccessPlan).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TbAccessPlanMembersMapping GetByPlanNumberByEmployeeNumber(long accessPlanNumber, long employeeNumber)
        {
            return base.FindBy(e => e.TbAccessPlan.AccessPlanNr == accessPlanNumber && e.MembersData.MemberNumber == employeeNumber).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanMembersMapping(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            base.Add(accessPlanMembersMapping);
            Save();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanMembersMappingCustom(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            base.Add(accessPlanMembersMapping);
            //Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanMembersMapping(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            if (accessPlanMembersMapping.ID == 0) return;
            base.Edit(accessPlanMembersMapping);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanMembersMappingCustom(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            if (accessPlanMembersMapping.ID == 0) return;
            base.Edit(accessPlanMembersMapping);
            //Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanMembersMapping(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            if (accessPlanMembersMapping.ID == 0) return;
            var currentAccessPlan = GetById(accessPlanMembersMapping.ID);
            Delete(currentAccessPlan);
            Save();
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanMembersMappingCustom(TbAccessPlanMembersMapping accessPlanMembersMapping)
        {
            if (accessPlanMembersMapping.MembersData.MemberNumber == 0) return;
            var currentAccessPlan = GetMappingByEmployeeNumber(accessPlanMembersMapping.MembersData.MemberNumber.Value);
            Delete(currentAccessPlan);
            Save();
        }

        #endregion Methods
    }
}
