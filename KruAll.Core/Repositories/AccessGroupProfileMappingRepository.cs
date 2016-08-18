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
    public class AccessGroupProfileMappingRepository : KruAllBaseRepository<AccessProfileAccessGroupMapping>
    {
        #region Constructor
        public AccessGroupProfileMappingRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessProfileAccessGroupMapping> GetAllAccessProfileAccessGroupMappings()
        {
            return base.GetAll().ToList();
        }

        public List<AccessProfileAccessGroupMapping> GetMappingByGroupID(long groupID)
        {
            List<AccessProfileAccessGroupMapping> list = new List<AccessProfileAccessGroupMapping>();
            list = base.GetAll().ToList();
            return list.FindAll(x => x.AccessGroupID == groupID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessProfileAccessGroupMapping GetMappingById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        public AccessProfileAccessGroupMapping GetMappingByAccessProfId(long profId)
        {
            return base.FindBy(e => e.AccessProfileID == profId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessProfileAccessGroupMapping(AccessProfileAccessGroupMapping AccessProfileAccessGroupMapping)
        {
            base.Add(AccessProfileAccessGroupMapping);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessProfileAccessGroupMapping(AccessProfileAccessGroupMapping AccessProfileAccessGroupMapping)
        {
            if (AccessProfileAccessGroupMapping.ID == 0) return;
            base.Edit(AccessProfileAccessGroupMapping);
            Save();
        }

        #endregion
    }
}
