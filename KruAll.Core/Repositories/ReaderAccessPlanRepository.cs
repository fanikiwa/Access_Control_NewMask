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
    public class ReaderAccessPlanRepository: KruAllBaseRepository<ReaderAccessPlan>
    {
        #region Constructor
        public ReaderAccessPlanRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ReaderAccessPlan> GetReaderAccessPLans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ReaderAccessPlan GetReaderAccessPlanById(long id)
        {
            return base.FindBy(d => d.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewReaderAccessPlan(ReaderAccessPlan readerPlan)
        {
            base.Add(readerPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditReaderAccessPlan(ReaderAccessPlan readerPlan)
        {
            if (readerPlan.ID == 0) return;
            base.Edit(readerPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteReaderAccessPlan(ReaderAccessPlan readerPlan)
        {
            if (readerPlan.ID == 0) return;
            var currentReaderPlan = GetReaderAccessPlanById(readerPlan.ID);
            base.Delete(currentReaderPlan);
            Save();
        }
        #endregion
    }
}
