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
    public class ViewTerminalInfoRepository: KruAllBaseRepository<View_TeminalInformation>
    {
        #region Constructor
        public ViewTerminalInfoRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<View_TeminalInformation> GetAllTerminals()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public View_TeminalInformation GetTerminalsById(long id)
        {
            return base.FindBy(e => e.TerminalID == id).FirstOrDefault();
        }


        #endregion
    }
}
