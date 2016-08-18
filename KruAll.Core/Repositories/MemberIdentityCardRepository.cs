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
    public class MemberIdentityCardRepository: KruAllBaseRepository<MemberIdentityCard>
    {
        public MemberIdentityCardRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberIdentityCard GetCardById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberIdentityCard GetCardByMemberId(long memberId)
        {
            return base.FindBy(x => x.MemberID == memberId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddMemberCard(MemberIdentityCard memberCard)
        {
            base.Add(memberCard);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberCard(MemberIdentityCard memberCard)
        {
            if (memberCard.ID <= 0) return;
            base.Edit(memberCard);
            Save();
        }

       
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberCard(MemberIdentityCard memberCard)
        {
            if (memberCard.ID == 0) return;
            var currentCard = GetCardById(memberCard.ID);
            Delete(currentCard);
            Save();

        }
    }
}
