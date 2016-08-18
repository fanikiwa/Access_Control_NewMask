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
    public class ViewMemberCardInfoRepository:KruAllBaseRepository<ViewMemberCardsInfo>
    {
        #region Constructor
        public ViewMemberCardInfoRepository() { }

        #endregion

        #region Methods
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ViewMemberCardsInfo> GetAllTransponders()
        {
            return base.GetAll().OrderBy(x => x.TransponderNr).ToList();
        }

        
        #endregion

    }
}
