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
    public class KostenstellenRepository : KrutecBaseRepository<Kostenstellen>
    {
        #region Constructor
        public KostenstellenRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Kostenstellen> GetCostCentres()
        {
            return base.GetAll().Where(p => p.Kos_Nr > 0).OrderBy(x => x.Kos_Nr).ToList();
        }

        public Kostenstellen GetCostCentresById(int Id)
        {
            return base.FindBy(x => x.Kos_Nr == Id).FirstOrDefault();
        }
        #endregion
    }
}

