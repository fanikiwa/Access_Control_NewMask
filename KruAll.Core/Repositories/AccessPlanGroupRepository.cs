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
    public class AccessPlanGroupRepository : KruAllBaseRepository<TbAccessPlanGroup>
    {
        #region Constructor
        public AccessPlanGroupRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TbAccessPlanGroup> GetAllAccessPlanGroups()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public TbAccessPlanGroup GetAccessPlanGroupById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public TbAccessPlanGroup GetAccessPlanGroupByNumber(long number)
        {
            return base.FindBy(e => e.AccessPlanGroupNr == number).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanGroup(TbAccessPlanGroup accessPlanGroup)
        {
            base.Add(accessPlanGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanGroup(TbAccessPlanGroup accessPlanGroup)
        {
            if (accessPlanGroup.ID == 0) return;
            base.Edit(accessPlanGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanGroup(TbAccessPlanGroup accessPlanGroup)
        {
            if (accessPlanGroup.ID == 0) return;
            var currentPlanGroup = GetAccessPlanGroupById(accessPlanGroup.ID);
            Delete(currentPlanGroup);
            Save();
        }

        #endregion
    }
}
