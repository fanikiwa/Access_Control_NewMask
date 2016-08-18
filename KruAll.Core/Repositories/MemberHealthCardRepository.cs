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
    public class MemberHealthCardRepository: KruAllBaseRepository<MemberHealthCard>
    {
        public MemberHealthCardRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberHealthCard GetHealthCardById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberHealthCard GetHealthCardByMemberId(long memberId)
        {
            return base.FindBy(x => x.MemberID == memberId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddHealthCard(MemberHealthCard healthCard)
        {
            base.Add(healthCard);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditHealthCard(MemberHealthCard healthCard)
        {
            if (healthCard.ID <= 0) return;
            base.Edit(healthCard);
            Save();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteHealthCard(MemberHealthCard healthCard)
        {
            if (healthCard.ID == 0) return;
            var currentCard = GetHealthCardById(healthCard.ID);
            Delete(currentCard);
            Save();

        }
    }
}
