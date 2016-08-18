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
    public class WerkeRepository : KrutecBaseRepository<Werke>
    {
        #region Constructor
        public WerkeRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Werke> GetLocations()
        {
            return base.GetAll().Where(p => p.W_Nr > 0).OrderBy(x => x.W_Nr).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Werke GetLocationsById(int id)
        {
            return base.FindBy(x => x.W_Nr == id).FirstOrDefault();
        }

        #endregion
    }
}
