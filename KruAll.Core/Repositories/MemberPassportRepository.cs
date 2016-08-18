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
    public class MemberPassportRepository: KruAllBaseRepository<MemberPassport>
    {
        public MemberPassportRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberPassport GetMemberPassportById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberPassport GetMemberPassportByMemberId(long memberId)
        {
            return base.FindBy(x => x.MemberID == memberId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddMemberPassport(MemberPassport memberPassport)
        {
            base.Add(memberPassport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberPassport(MemberPassport memberPassport)
        {
            if (memberPassport.ID <= 0) return;
            base.Edit(memberPassport);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberPassport(MemberPassport memberPassport)
        {
            if (memberPassport.ID == 0) return;
            var currentPassport = GetMemberPassportById(memberPassport.ID);
            Delete(currentPassport);
            Save();

        }
    }
}
