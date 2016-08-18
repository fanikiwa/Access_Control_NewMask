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
    public class MemberGroupsRepositories : KruAllBaseRepository<MemberGroup>
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MemberGroup> GetAllMemberGroups()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberGroup GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.GroupNr).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberGroup GetMemberGroupById(long id)
        {
            return base.FindBy(cc => cc.Id == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberGroup GetMemberGroupByNr(int Nr)
        {
            return base.FindBy(cc => cc.GroupNr == Nr).FirstOrDefault();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewMemberGroup(MemberGroup MemberGroup)
        {
            base.Add(MemberGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberGroup(MemberGroup MemberGroup)
        {
            if (MemberGroup.Id == 0) return;
            base.Edit(MemberGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberGroup(MemberGroup MemberGroup)
        {
            if (MemberGroup.Id == 0) return;
            var _MemberGroup = GetMemberGroupById(MemberGroup.Id);
            base.Delete(_MemberGroup);
            Save();
        }
    }
}
