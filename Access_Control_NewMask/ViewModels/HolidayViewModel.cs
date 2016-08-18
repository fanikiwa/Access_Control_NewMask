using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.ViewModels
{
    public class HolidayViewModel
    {
        private readonly HolidayRepository _holidayRepository = new HolidayRepository();

        #region Holiday Repo Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Holiday> GetHolidays()
        {
            return _holidayRepository.GetHolidays();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayById(long id)
        {
            return _holidayRepository.GetHolidayById(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayByDate(DateTime daysDate)
        {
            return _holidayRepository.GetHolidayByDate(daysDate);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Holiday GetHolidayByNameByDate(string holidayName, DateTime daysDate)
        {
            return _holidayRepository.GetHolidayByNameByDate(holidayName, daysDate);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void CreateHoliday(Holiday holiday)
        {
            _holidayRepository.NewHoliday(holiday);
        }

        public void EditHoliday(Holiday holiday)
        {
            _holidayRepository.EditHoliday(holiday);
        }

        public void DeleteHoliday(Holiday holiday)
        {
            _holidayRepository.DeleteHoliday(holiday);
        }

        #endregion
    }
}
