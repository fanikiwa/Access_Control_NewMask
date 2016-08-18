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
    public class MemberCommonInfoRepository : KruAllBaseRepository<MemberCommonInfo>
    {
        public MemberCommonInfoRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberCommonInfo GetCommonInfoById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberCommonInfo GetCommonInfoByMemberId(long memberId)
        {
            return base.FindBy(x => x.MemberID == memberId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddMemberCommonInfo(MemberCommonInfo commonInfo)
        {
            base.Add(commonInfo);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberCommonInfo(MemberCommonInfo commonInfo)
        {
            if (commonInfo.ID <= 0) return;
            base.Edit(commonInfo);
            Save();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberCommonInfo(MemberCommonInfo commonInfo)
        {
            if (commonInfo.ID == 0) return;
            var currentInfo = GetCommonInfoById(commonInfo.ID);
            Delete(currentInfo);
            Save();

        }
    }
}
