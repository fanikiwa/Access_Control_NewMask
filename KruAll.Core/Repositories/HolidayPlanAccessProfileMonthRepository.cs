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
    public class HolidayPlanAccessProfileMonthRepository: KruAllBaseRepository<HolidayPlanAccessProfileMonth>
    {
        #region Constructor
        public HolidayPlanAccessProfileMonthRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<HolidayPlanAccessProfileMonth> GetAllProfileMonth()
        {
            return base.GetAll().OrderBy(x => x.HolidayPlanCalendarId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public HolidayPlanAccessProfileMonth GetProfileMonthById(long id)
        {
            return base.FindBy(x => x.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<HolidayPlanAccessProfileMonth> GetProfileMonthByCalendarId(long calendarId)
        {

            return base.FindBy(x => x.HolidayPlanCalendarId == calendarId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewProfileMonth(HolidayPlanAccessProfileMonth profileMonth)
        {
            base.Add(profileMonth);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteProfileMonth(HolidayPlanAccessProfileMonth profileMonth)
        {
            if (profileMonth.ID == 0) return;
            var currentProfileMonth = GetProfileMonthById(profileMonth.ID);
            base.Delete(currentProfileMonth);
            Save();
        }
        #endregion
    }
}
