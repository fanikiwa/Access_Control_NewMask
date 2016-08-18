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
    public class AccessPlanGroupDoorMappingRepository: KruAllBaseRepository<AccessPlanGroupDoorMapping>
    {
        #region Constructor
        public AccessPlanGroupDoorMappingRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessPlanGroupDoorMapping> GetAllMappedGroups()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessPlanGroupDoorMapping GetMappedById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessPlanGroupDoorMapping> GetMappedGroupByAccessGroupId(long groupId)
        {
            return base.GetAll().Where(x => x.AccessPlanGroupID == groupId).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessPlanGroupDoorMapping> GetMappedGroupByBuildingId(long planId)
        {
            return base.GetAll().Where(x => x.BuildingPlanID == planId).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessPlanGroupDoorMapping> GetMappedGroupIdBuildingPlanId(long groupId, long planId)
        {
            return base.GetAll().Where(x => x.AccessPlanGroupID == groupId && x.BuildingPlanID == planId).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewMappedAccessPlanGroup(AccessPlanGroupDoorMapping accessPlanGroup)
        {
            base.Add(accessPlanGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMappedAccessPlanGroup(AccessPlanGroupDoorMapping accessPlanGroup)
        {
            if (accessPlanGroup.ID == 0) return;
            base.Edit(accessPlanGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMappedAccessPlanGroup(AccessPlanGroupDoorMapping accessPlanGroup)
        {
            if (accessPlanGroup.ID == 0) return;
            var currentAccessPlanGroup = GetMappedById(accessPlanGroup.ID);
            Delete(currentAccessPlanGroup);
            Save();
        }

        #endregion
    }
}
