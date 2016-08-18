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
    public class AccessCalendarRepository: KruAllBaseRepository<AccessCalendar>
    {
        #region Constructor
        public AccessCalendarRepository() { }

        #endregion

        #region Methods
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AccessCalendar> GetAllAccessCalendars()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AccessCalendar GetAccessCalendarById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public AccessCalendar GetAccessCalendarByNumber(int accessCalendar_Nr)
        {
            return base.FindBy(e => e.Calendar_Nr == accessCalendar_Nr).FirstOrDefault();
        }

        public AccessCalendar AccessCalendarByName(string accessCalendarName)
        {
            return base.FindBy(e => e.Calendar_Name == accessCalendarName).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewAccessCalendar(AccessCalendar accessCalendar)
        {
            base.Add(accessCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditAccessCalendar(AccessCalendar accessCalendar)
        {
            if (accessCalendar.ID == 0) return;
            base.Edit(accessCalendar);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteAccessCalendar(AccessCalendar accessCalendar)
        {
            if (accessCalendar.ID == 0) return;
            var currentaccessCalendar = GetAccessCalendarById(accessCalendar.ID);
            Delete(currentaccessCalendar);
            Save();
        }
        #endregion

        #region utility functions

        #endregion
    }
}
