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
    public class MemberAccessGroupsRepository : KruAllBaseRepository<MemberAccessGroup>
    {
        public MemberAccessGroupsRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MemberAccessGroup> GetMemberAccessGroups(long MemberID)
        {
            return base.GetAll().Where(x => x.MemberID == MemberID).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberAccessGroup GetMemberAccessGroupByMemberID(long MemberID)
        {
            return base.FindBy(x => x.MemberID == MemberID).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MemberAccessGroup> GetMemberAccessGroups(long MemberID, long AccessGroupId)
        {
            return base.GetAll().Where(x => x.MemberID == MemberID && x.GroupID == AccessGroupId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberAccessGroup GetAccessGroupById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MemberAccessGroup> GetAllMemberAccessGroups()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddMemberAccessGroup(MemberAccessGroup MemberAccessGroup)
        {
            base.Add(MemberAccessGroup);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberAccessGroup(MemberAccessGroup MemberAccessGroup)
        {
            if (MemberAccessGroup.ID <= 0) return;
            base.Edit(MemberAccessGroup);
        }

        public void SaveMemberAccessGroup()
        {
            base.Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberAccessGroup(MemberAccessGroup AccessGroup)
        {
            if (AccessGroup.ID == 0) return;
            var currentAccessGroup = GetAccessGroupById(AccessGroup.ID);
            Delete(currentAccessGroup);
            Save();

        }
    }
}
