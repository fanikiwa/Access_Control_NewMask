

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
    public class PersPassportRepository: KruAllBaseRepository<Pers_Passport>
    {
        #region Constructor
        public PersPassportRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Passport> GetPersPassports()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Passport GetPersPassportByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersPassport(Pers_Passport passport)
        {
            base.Add(passport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersPassportCustom(Pers_Passport passport)
        {
            base.Add(passport); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersPassport(Pers_Passport passport)
        {
            if (passport.ID == 0) return;
            base.Edit(passport);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersPassportCustom(Pers_Passport passport)
        {
            if (passport.ID == 0) return;
            base.Edit(passport); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersPassport(Pers_Passport passport)
        {
            if (passport.ID == 0) return; 
            base.Delete(passport);
            Save();
        }
        #endregion
    }
}
