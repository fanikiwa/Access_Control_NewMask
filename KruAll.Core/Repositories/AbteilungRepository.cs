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
    public class AbteilungRepository : KrutecBaseRepository<Abteilungen>
    {
        #region Constructor
        public AbteilungRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Abteilungen> GetDepartments()
        {
            return base.GetAll().Where(p => p.Abt_Nr > 0).OrderBy(x => x.Abt_Nr).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Abteilungen GetDepartmentsById(int Id)
        {
            return base.FindBy(x => x.Abt_Nr == Id).FirstOrDefault();
        }

        #endregion
    }
}
