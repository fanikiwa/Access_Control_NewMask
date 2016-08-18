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
    public class VisitorPresentLogRepository : KruAllBaseRepository<View_VisitorAccessLog>
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<View_VisitorAccessLog> GetAllTodayVisitorLogs()
        {
            return base.GetAll().ToList();
        }

        //[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<KruAll.Core.Models.VwPersonnelData> GetAllVisitorWithoutLogs()
        {
            KruAll.Core.Models.PZE_Entities dbConnection = new PZE_Entities();
            return dbConnection.VwPersonnelDatas.Distinct().ToList();
        }

        public List<KruAll.Core.Models.View_VisitorEntryLog> GetAllTodayVisitorEntryLogs()
        {
            KruAll.Core.Models.PZE_Entities dbConnection = new PZE_Entities();
            return dbConnection.View_VisitorEntryLog.ToList(); // Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1)).ToList();
        }

        public DateTime? personalAccessEndDate(long personalNumber)
        {
            KruAll.Core.Models.PZE_Entities dbConnection = new PZE_Entities();
            DateTime? personalEndDate = null; 

            var personalAccess = dbConnection.TbAccessPlanPersMappings.Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if(personalAccess != null)
            {
                personalEndDate = personalAccess.DateTo;
            }

            return personalEndDate;
        }
          
    }
}
