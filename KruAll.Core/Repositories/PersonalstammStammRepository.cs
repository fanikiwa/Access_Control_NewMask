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
    public class PersonalstammStammRepository : KrutecBaseRepository<Personalstamm>
    {
        #region Constructor
        public PersonalstammStammRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Personalstamm> GetAllPersonnel()
        {
            return base.GetAll().ToList();
        }


        #endregion
    }
}
