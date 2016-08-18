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
    public class AccessGroupRepository : KruAllBaseRepository<AccessGroup>
    {
        #region Constructor
        public AccessGroupRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessGroup> GetAllAccessProfileGroups()
        {
            return base.GetAll().Where(e => e.AccessGroupType == 1).OrderBy(x=> x.AccessGroupNumber).ToList();
        }
        //[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        //public List<AccessGroup> GetAllAccessProfileGroups()
        //{
        //    return base.GetAll().Where(e => e.AccessGroupType==1).ToList();
        //}

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessGroup> GetAllAccessPlanAccessGroups()
        {
            return base.GetAll().Where(e => e.AccessGroupType == 2).OrderBy(x=> x.AccessGroupNumber).ToList();
        }
        public List<AccessGroup> GetAllVisitorPlanGroups()
        {
            return base.GetAll().Where(e => e.AccessGroupType == 3).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetAccessGroupById(long id)
        {
            return base.FindBy(e => e.Id == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetAccessPlanGroupById(long id)
        {
            return base.FindBy(e => e.Id == id && e.AccessGroupType == 1).FirstOrDefault();
        }

        // AccessGroupType ==3
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetAccessPlanAccessGroupById(long id)
        {
            return base.FindBy(e => e.Id == id && e.AccessGroupType == 2).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetAccessPlanAccessGroupByGroupNo(long groupNo)
        {
            return base.FindBy(e => e.AccessGroupNumber == groupNo && e.AccessGroupType == 2).FirstOrDefault();
        }

        //visitorPlanGroup AccessGroupType ==3
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetVisitorPlanGroupByGroupNo(long groupNo)
        {
            return base.FindBy(e => e.AccessGroupNumber == groupNo && e.AccessGroupType == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetVisitorPlanGroupById(long id)
        {
            return base.FindBy(e => e.Id == id && e.AccessGroupType == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetAccessProfileGroupById(long id)
        {
            return base.FindBy(e => e.Id == id && e.AccessGroupType == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetAccessProfileGroupByGroupNo(long groupNo)
        {
            return base.FindBy(e => e.AccessGroupNumber == groupNo && e.AccessGroupType == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessProfileGroup(AccessGroup AccessGroup)
        {
            AccessGroup.AccessGroupType = 1;
            base.Add(AccessGroup);
            Save();
        }
        //AccessGroupType ==2
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanAccessGroup(AccessGroup AccessGroup)
        {
            AccessGroup.AccessGroupType = 2;
            base.Add(AccessGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessPlanAccessGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            AccessGroup.AccessGroupType = 2;
            base.Edit(AccessGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessPlanGroup(AccessGroup AccessGroup)
        {
            AccessGroup.AccessGroupType = 2;
            base.Add(AccessGroup);
            Save();
        }
        //visitorPlanGroup AccessGroupType ==3
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVisitorPlanGroup(AccessGroup AccessGroup)
        {
            AccessGroup.AccessGroupType = 3;
            base.Add(AccessGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            base.Edit(AccessGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetNextProfileNr()
        {
            return base.GetAll().Where(x => x.AccessGroupType == 3).OrderByDescending(x => x.AccessGroupNumber).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetNextAccessPlanNr()
        {
            return base.GetAll().Where(x => x.AccessGroupType == 2).OrderByDescending(x => x.AccessGroupNumber).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetNextAccessProfileGroupNr()
        {
            return base.GetAll().Where(x => x.AccessGroupType == 1).OrderByDescending(x => x.AccessGroupNumber).FirstOrDefault();
        }
        //visitorPlanGroup AccessGroupType ==3
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVisitorPlanGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            AccessGroup.AccessGroupType = 3;
            base.Edit(AccessGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessProfileGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            AccessGroup.AccessGroupType = 1;
            base.Edit(AccessGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessGroupById(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            var currentAccessGroup = GetAccessGroupById(AccessGroup.Id);
            Delete(currentAccessGroup);
            Save();
        }
        public void DeleteAccessGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            var currentAccessPlanGroup = GetAccessPlanGroupById(AccessGroup.Id);
            base.Delete(currentAccessPlanGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitorPlanGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            var currentVisitorPlanGroup = GetVisitorPlanGroupById(AccessGroup.Id);
            base.Delete(currentVisitorPlanGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessGroupById(long id)
        {
            if (id == 0) return;
            var currentAccessGroup = GetAccessGroupById(id);
            Delete(currentAccessGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessPlanAccessGroup(AccessGroup AccessGroup)
        {
            if (AccessGroup.Id == 0) return;
            var currentVisitorPlanGroup = GetAccessPlanAccessGroupById(AccessGroup.Id);
            base.Delete(currentVisitorPlanGroup);
            Save();
        }
        #endregion



        //Building Plan Group Methods AccessGroupType = 4 
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AccessGroup> GetAllBuildingPlanGroups()
        {
            return base.GetAll().Where(e => e.AccessGroupType == 4).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetBuildingPlanGroupsById(long id)
        {
            return base.FindBy(e => e.Id == id && e.AccessGroupType == 4).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetBuildingPlanGroupsByNr(long groupNo)
        {
            return base.FindBy(e => e.AccessGroupNumber == groupNo && e.AccessGroupType == 4).FirstOrDefault();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AccessGroup GetNextBuildingPlanGroupNr()
        {
            return base.GetAll().Where(x => x.AccessGroupType == 4).OrderByDescending(x => x.AccessGroupNumber).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewBuildingPlanGroup(AccessGroup BuildingPlanGroup)
        {
            BuildingPlanGroup.AccessGroupType = 4;
            base.Add(BuildingPlanGroup);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditBuildingPlanGroup(AccessGroup BuildingPlanGroup)
        {
            if (BuildingPlanGroup.Id == 0) return;
            BuildingPlanGroup.AccessGroupType = 4;
            base.Edit(BuildingPlanGroup);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteBuildingPlanGroup(AccessGroup BuildingPlanGroup)
        {
            if (BuildingPlanGroup.Id == 0) return;
            var currentBuildingPlanGroup = GetBuildingPlanGroupsById(BuildingPlanGroup.Id);
            base.Delete(currentBuildingPlanGroup);
            Save();
        }
    }
}
