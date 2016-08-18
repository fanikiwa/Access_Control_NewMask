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
    public class AccessControlLogsRepository : KruAllBaseRepository<MV_AccessControlLogs>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<MV_AccessControlLogs> GetAllAccessControlLogs()
        {
            return base.GetAll().OrderByDescending(x => x.AccessTime).ToList();
        }
    }
}
