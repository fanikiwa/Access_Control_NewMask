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
    public class View_AccessLogsRepository : KruAllBaseRepository<View_AccessLogs>
    {
        #region Constructor
        public View_AccessLogsRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<View_AccessLogs> GetAllAccessLogs()
        {
            return base.GetAll().ToList();
        }

        public List<View_AccessLogs> GetAllAccessLogsOverDateSelectionAndPersType(DateTime dtStartDate, DateTime dtEndDate, int persType)
        {
            return base.FindBy(x => x.BookingTime >= dtStartDate && x.BookingTime <= dtEndDate && x.Pers_Type == persType).ToList();
        }

        public List<View_AccessLogs> GetAllAccessLogsOverPersType(int persType)
        {
            return base.FindBy(x => x.Pers_Type == persType).ToList();
        }

        #endregion
    }
}
