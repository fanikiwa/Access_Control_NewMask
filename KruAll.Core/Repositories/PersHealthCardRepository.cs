

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
    public class PersHealthCardRepository: KruAllBaseRepository<Pers_HealthCard>
    {
        #region Constructor
        public PersHealthCardRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_HealthCard> GetPersHealthCards()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_HealthCard GetPersHealthCardByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersHealthCard(Pers_HealthCard healthCard)
        {
            base.Add(healthCard);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersHealthCardCustom(Pers_HealthCard healthCard)
        {
            base.Add(healthCard); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersHealthCard(Pers_HealthCard healthCard)
        {
            if (healthCard.ID == 0) return;
            base.Edit(healthCard);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersHealthCardCustom(Pers_HealthCard healthCard)
        {
            if (healthCard.ID == 0) return;
            base.Edit(healthCard); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersHealthCard(Pers_HealthCard healthCard)
        {
            if (healthCard.ID == 0) return; 
            base.Delete(healthCard);
            Save();
        }
        #endregion
    }
}
