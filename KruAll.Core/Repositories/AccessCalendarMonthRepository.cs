using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class AccessCalendarMonthRepository: KruAllBaseRepository<AccessCalendarMonth>
    {
        #region Methods
        public AccessCalendarMonthRepository() { }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewAccessCalendarMonth(AccessCalendarMonth accessCalendarMonth)
        {
            base.Add(accessCalendarMonth);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AccessCalendarMonth GetAccessCalendarMonthById(long id)
        {
            return base.FindBy(b => b.ID == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AccessCalendarMonth> GetAccessCalendarMonthsByAccessCalendarId(long accessCalendarId)
        {
            return base.GetAll().Where(p => p.AccessCalendarID == accessCalendarId).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AccessCalendarMonth GetAccessCalendarMonthByCalendarMonth(long accessCalendarId, int calendarMonth)
        {
            return base.FindBy(b => b.AccessCalendarMonthNr == calendarMonth && b.AccessCalendarID == accessCalendarId).Include(s => s.AccessCalendar).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteMapCalendarMonth(AccessCalendarMonth accessCalendarMonth)
        {
            if (accessCalendarMonth.ID == 0) return;
            var currentAccessCalendarMonth = GetAccessCalendarMonthById(accessCalendarMonth.ID);
            base.Delete(currentAccessCalendarMonth);

            Save();
        }

        #endregion
    }
}
