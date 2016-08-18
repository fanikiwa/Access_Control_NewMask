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
    public class VwPersonnelDataRepository : KruAllBaseRepository<VwPersonnelData>
    {
        #region Constructor
        public VwPersonnelDataRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VwPersonnelData> GetAllPersonnel()
        {
            return base.GetAll().Where(p => p.Active).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VwPersonnelData> GetAllInactivePersonnel()
        {
            return base.GetAll().Where(p => p.Active == false).ToList();
        }


        #endregion
    }
}
