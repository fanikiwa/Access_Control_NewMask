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
    public class VwHolidayCalendeRepository2 : KruAllBaseRepository<RV_HolidayPlanPerTerminal>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<RV_HolidayPlanPerTerminal> GetVwHolidayCalende()
        {
            return base.GetAll().OrderBy(x => x.CalendarMonth).ToList();
        }
    }
}
