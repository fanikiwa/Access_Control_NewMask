using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KruAll.Core.Models;
using KruAll.Core.Repositories;


namespace Access_Control_NewMask.ViewModels
{
    public class AccessControlLogsViewModel
    {
        AccessControlLogsRepository accessControlLogRepo = new AccessControlLogsRepository();

        public List<MV_AccessControlLogs> GetAllLogs()
        {
            return accessControlLogRepo.GetAllAccessControlLogs();
        }
    }
}