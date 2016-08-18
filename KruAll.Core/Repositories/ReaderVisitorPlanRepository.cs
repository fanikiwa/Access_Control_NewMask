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
    public class ReaderVisitorPlanRepository: KruAllBaseRepository<ReaderVisitorPlan>
    {
        #region Constructor
        public ReaderVisitorPlanRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ReaderVisitorPlan> GetReaderVisitorPLans()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ReaderVisitorPlan GetReaderVisitorPlanById(long id)
        {
            return base.FindBy(d => d.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewReaderVisitorPlan(ReaderVisitorPlan readerPlan)
        {
            base.Add(readerPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditReaderVisitorPlan(ReaderVisitorPlan readerPlan)
        {
            if (readerPlan.ID == 0) return;
            base.Edit(readerPlan);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteReaderAccessPlan(ReaderVisitorPlan readerPlan)
        {
            if (readerPlan.ID == 0) return;
            var currentReaderPlan = GetReaderVisitorPlanById(readerPlan.ID);
            base.Delete(currentReaderPlan);
            Save();
        }
        #endregion
    }
}
