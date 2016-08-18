using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessGroupViewModel
    {
        readonly AccessGroupRepository _AccessGroupRepository = new AccessGroupRepository();

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<AccessGroup> GetVisitorPlanGroups()
        {
            return _AccessGroupRepository.GetAllVisitorPlanGroups();
        }

        public int GetNextGroupNr()
        {
            AccessGroup lastGroup = _AccessGroupRepository.GetNextProfileNr();
            if (lastGroup == null) lastGroup = new AccessGroup();
            return Convert.ToInt32((lastGroup.AccessGroupNumber + 1));
        }
        public int GetNextAccessProfileGroupNr()
        {
            AccessGroup lastGroup = _AccessGroupRepository.GetNextAccessProfileGroupNr();
            if (lastGroup == null) lastGroup = new AccessGroup();
            return Convert.ToInt32((lastGroup.AccessGroupNumber + 1));
        }
        public int GetNextAccessPlanNr()
        {
            AccessGroup lastGroup = _AccessGroupRepository.GetNextAccessPlanNr();
            if (lastGroup == null) lastGroup = new AccessGroup();
            return Convert.ToInt32((lastGroup.AccessGroupNumber + 1));
        }

        public AccessGroup GetGroupByGroupID(long groupID)
        {
            AccessGroup accessGroup = _AccessGroupRepository.GetAccessGroupById(groupID);
            return accessGroup;
        }

        public int GetNextBuildingPlanGroupNr()
        {
            AccessGroup lastGroup = _AccessGroupRepository.GetNextBuildingPlanGroupNr();
            if (lastGroup == null) lastGroup = new AccessGroup();
            return Convert.ToInt32((lastGroup.AccessGroupNumber + 1));
        }
    }
}