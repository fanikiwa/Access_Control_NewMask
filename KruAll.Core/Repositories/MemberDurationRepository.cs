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
    public class MemberDurationRepository: KruAllBaseRepository<MemberDuration>
    {
        #region Constructor
        public MemberDurationRepository() { }
       
        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MemberDuration> GetAllDurations()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberDuration GetDurationById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public MemberDuration GetDurationNumber(int duration_Nr)
        {
            return base.FindBy(e => e.DurationNr == duration_Nr).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewDuration(MemberDuration duration)
        {
            base.Add(duration);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditDuration(MemberDuration duration)
        {
            if (duration.ID == 0) return;
            base.Edit(duration);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteDuration(MemberDuration duration)
        {
            if (duration.ID == 0) return;
            var currentDuration = GetDurationById(duration.ID);
            Delete(currentDuration);
            Save();

        }

        #endregion
    }
}
