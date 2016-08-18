

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
    public class PersAccessPlanDurationRepository : KruAllBaseRepository<Pers_AccessPlanDuration>
    {
        #region Constructor
        public PersAccessPlanDurationRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AccessPlanDuration> GetAccessPlanDurations()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_AccessPlanDuration GetPersAccessPlanDurationByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanDuration(Pers_AccessPlanDuration accessPlanDuration)
        {
            base.Add(accessPlanDuration);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanDurationCustom(Pers_AccessPlanDuration accessPlanDuration)
        {
            base.Add(accessPlanDuration); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanDuration(Pers_AccessPlanDuration accessPlanDuration)
        {
            if (accessPlanDuration.ID == 0) return;
            base.Edit(accessPlanDuration);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanDurationCustom(Pers_AccessPlanDuration accessPlanDuration)
        {
            if (accessPlanDuration.ID == 0) return;
            base.Edit(accessPlanDuration); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanDuration(Pers_AccessPlanDuration accessPlanDuration)
        {
            if (accessPlanDuration.ID == 0) return; 
            base.Delete(accessPlanDuration);
            Save();
        }
        #endregion
    }
}
