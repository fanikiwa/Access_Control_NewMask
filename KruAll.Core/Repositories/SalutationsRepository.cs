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
    public class SalutationsRepository: KruAllBaseRepository<ERP_Anrede>
    {

        #region Constructor
        public SalutationsRepository() { }
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ERP_Anrede> GetSalutation()
        {
            return base.GetAll().ToList();
        }
        
        #endregion
    }
}
