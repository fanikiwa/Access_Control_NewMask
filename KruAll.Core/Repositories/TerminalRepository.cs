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
    public class TerminalRepository: KruAllBaseRepository<Terminal>
    {
        #region Constructor
        public TerminalRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Terminal> GetAllTerminals()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Terminal GetTerminalById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        #endregion
    }
}
