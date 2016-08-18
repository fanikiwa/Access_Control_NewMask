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
    public class HolidayRepository : KruAllBaseRepository<Holiday>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Holiday> GetHolidays()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayById(long id)
        {
            return base.FindBy(b => b.Id == id).FirstOrDefault();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayByDateAndName(string holidayName, DateTime holidayDate)
        {
            return base.FindBy(b => b.HolidayName == holidayName && b.HolidayDate == holidayDate).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayByDate(DateTime daysDate)
        {
            return base.FindBy(p => DateTime.Compare(DbFunctions.TruncateTime(p.HolidayDate).Value, daysDate) == 0).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayByNameByDate(string holidayName, DateTime daysDate)
        {
            return base.FindBy(p => DateTime.Compare(DbFunctions.TruncateTime(p.HolidayDate).Value, daysDate) == 0).FirstOrDefault(p => p.HolidayName.ToLower() == holidayName.ToLower());
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Holiday> GetListHolidayByNameByDate(string holidayName, DateTime daysDate)
        {
            return base.FindBy(p => DateTime.Compare(DbFunctions.TruncateTime(p.HolidayDate).Value, daysDate) == 0).Where(p => p.HolidayName.ToLower() == holidayName.ToLower()).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Holiday> GetListHolidayByNameByDateByRegion(string holidayName, DateTime daysDate, long regionId)
        {
            var holidays = base.FindBy(p => DateTime.Compare(DbFunctions.TruncateTime(p.HolidayDate).Value, daysDate) == 0).Where(p => p.HolidayName.ToLower() == holidayName.ToLower()).ToList();
            List<Holiday> listholiday = new List<Holiday>();
            if (holidays.Count > 0)
            {
                listholiday.AddRange(holidays);
            }
            return listholiday.Where(x => x.RegionID == regionId).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void NewHoliday(Holiday holiday)
        {
            base.Add(holiday);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditHoliday(Holiday holiday)
        {
            if (holiday.Id == 0) return;
            base.Edit(holiday);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteHoliday(Holiday holiday)
        {
            if (holiday.Id == 0) return;
            var currentHoliday = GetHolidayById(holiday.Id);
            base.Delete(currentHoliday);

            Save();
        }
    }
}
