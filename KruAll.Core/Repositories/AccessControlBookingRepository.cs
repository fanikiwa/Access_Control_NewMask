using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;

namespace KruAll.Core.Repositories
{
    public class AccessControlBookingRepository : KruAllBaseRepository<AccessControlLog>
    {
        public List<AccessControlLog> GetAllByPersNrAndDate(long PersNr, DateTime bookingDate)
        {
            DateTime nextDayStart = bookingDate.AddDays(1);
            return base.GetAll().Where(x => x.Pers_Nr == PersNr && x.AccessTime >= bookingDate && x.AccessTime <= nextDayStart).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessControlBooking(AccessControlLog accessLog)
        {
            base.Add(accessLog);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessControlBooking(AccessControlLog accessLog)
        {
            if (accessLog.ID > 0)
            {
                base.Edit(accessLog);
                Save();
            }
        }

        public void DeleteAccessControlBooking(AccessControlLog accessLog)
        {
            if (accessLog.ID > 0)
            {
                base.Delete(accessLog);
                Save();
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void SaveAccessControlBooking(AccessControlLog accessLog)
        {
            Save();
        }
    }
}
