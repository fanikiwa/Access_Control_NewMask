using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class MembersAccessPlanMappingRepository: KruAllBaseRepository<MembersAccessPlanMapping>
    {
        #region Constructor
        public MembersAccessPlanMappingRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MembersAccessPlanMapping> GetAllMembersPLans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MembersAccessPlanMapping GetMemberAccessPlanById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public MembersAccessPlanMapping GetMemberAccessPLanByMemberId(long memberId)
        {
            return base.FindBy(e => e.MemberID == memberId).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewMemberAccessPlan(MembersAccessPlanMapping memberPlan)
        {
            base.Add(memberPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberAccessPlan(MembersAccessPlanMapping memberPlan)
        {
            if (memberPlan.ID == 0) return;
            base.Edit(memberPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberAccessPlan(MembersAccessPlanMapping memberPlan)
        {
            
            if (memberPlan.ID == 0) return;
            var currentMemberPLan = GetMemberAccessPlanById(memberPlan.ID);
            Delete(currentMemberPLan);
            Save();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMembersAccessPlanMapping(long accessPlanNr)
        {

            var IDNumbers = base.GetAll().Where(x => x.AccessPlan_Nr == accessPlanNr).ToList().Select(y => y.ID).ToList();

            foreach(long idNumber in IDNumbers)
            {
                var currentMemberPLan = GetMemberAccessPlanById(idNumber);
                Delete(currentMemberPLan);
            }

            Save();
        }

        #endregion
    }
}
