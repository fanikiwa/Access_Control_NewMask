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
    public class PersVisitorsRepository : KruAllBaseRepository<Pers_Visitors>
    {
        #region Constructor
        public PersVisitorsRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Visitors> GetPersVisitors()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Visitors GetPersVisitorsByPersNr(long persNr)
        {
            return base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
        }
         

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersVisitors(Pers_Visitors visitors)
        {
            base.Add(visitors);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersVisitorsCustom(Pers_Visitors visitors)
        {
            base.Add(visitors);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersVisitors(Pers_Visitors visitors)
        {
            if (visitors.ID == 0) return;
            base.Edit(visitors);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersVisitorsCustom(Pers_Visitors visitors)
        {
            if (visitors.ID == 0) return;
            base.Edit(visitors); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersVisitors(Pers_Visitors visitors)
        {
            if (visitors.ID == 0) return; 
            base.Delete(visitors);
            Save();
        }
        #endregion
    }
}
