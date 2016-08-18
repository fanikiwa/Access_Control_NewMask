

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
    public class PersIdentityCardRepository: KruAllBaseRepository<Pers_IdentityCard>
    {
        #region Constructor
        public PersIdentityCardRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_IdentityCard> GetPersIdentityCards()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_IdentityCard GetPersIdentityCardByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersIdentityCard(Pers_IdentityCard identityCard)
        {
            base.Add(identityCard);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersIdentityCardCustom(Pers_IdentityCard identityCard)
        {
            base.Add(identityCard); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersIdentityCard(Pers_IdentityCard identityCard)
        {
            if (identityCard.ID == 0) return;
            base.Edit(identityCard);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersIdentityCardCustom(Pers_IdentityCard identityCard)
        {
            if (identityCard.ID == 0) return;
            base.Edit(identityCard); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersIdentityCard(Pers_IdentityCard identityCard)
        {
            if (identityCard.ID == 0) return; 
            base.Delete(identityCard);
            Save();
        }
        #endregion
    }
}
