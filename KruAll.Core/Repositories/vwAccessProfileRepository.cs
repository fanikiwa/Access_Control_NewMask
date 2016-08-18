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
    public class vwAccessProfileRepository: KruAllBaseRepository<RV_AccessProfilesPerTerminal>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<RV_AccessProfilesPerTerminal> GetvwAccessProfiles()
        {
            return base.GetAll().ToList();
        }

    }
}
