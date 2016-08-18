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
    public class vwPersPinCodeRepository : KruAllBaseRepository<vwPersPinCode>
    {
        #region Constructor
        public vwPersPinCodeRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<vwPersPinCode> GetPersPinCodes()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public vwPersPinCode GetLocationsById(long id)
        {
            return base.FindBy(x => x.Pers_Nr == id).FirstOrDefault();
        }

        #endregion
    }
}
