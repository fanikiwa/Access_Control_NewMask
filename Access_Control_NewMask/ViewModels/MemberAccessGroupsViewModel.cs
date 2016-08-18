using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class MemberAccessGroupsViewModel
    {
        MemberAccessGroupsRepository MemberAccessGroupsRepository = new MemberAccessGroupsRepository();
        public MemberAccessGroupsViewModel() { }

        public List<MemberAccessGroupsDto> GetMemberAccessGroupsTemplate(int templateSize, bool includeAllGroups, long MemberID)
        {
            List<MemberAccessGroupsDto> personalAccessGroupsList = new List<MemberAccessGroupsDto>();
            List<MemberAccessGroup> dbPersonalAccessGroupsList = GetMemberAccessGroups(MemberID);
            //List<TbAccessPlanGroup> tbAccessPlanGroups = new List<TbAccessPlanGroup>();
            //tbAccessPlanGroups = (new AccessPlanGroupRepository().GetAllAccessPlanGroups()) ?? new List<TbAccessPlanGroup>();
            //tbAccessPlanGroups.Add(new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" });
            //tbAccessPlanGroups = tbAccessPlanGroups.OrderBy(x => x.AccessPlanGroupNr).ToList();

            for (int i = 0; i < templateSize; i++)
            {
                MemberAccessGroup dbPersonalAccessGroup = dbPersonalAccessGroupsList.Count > i ?
                    dbPersonalAccessGroupsList[i] : new MemberAccessGroup();

                personalAccessGroupsList.Add(new MemberAccessGroupsDto()
                {
                    ID = dbPersonalAccessGroup.ID > 0 ? dbPersonalAccessGroup.ID : -1 * (i + 1),
                    Active = dbPersonalAccessGroup.Active,
                    GroupID = dbPersonalAccessGroup.GroupID,
                    StartDate = dbPersonalAccessGroup.StartDate,
                    EndDate = dbPersonalAccessGroup.EndDate,
                    TbAccessPlanGroup = new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" }
                });
            }

            return personalAccessGroupsList;
        }

        public List<MemberAccessGroupsDto> GetMemberAccessGroupByMemberID(long MemberID)
        {
            List<MemberAccessGroupsDto> personalAccessGroupsList = GetMemberAccessGroupsTemplate(8, true, MemberID);

            return personalAccessGroupsList;
        }

        public List<MemberAccessGroup> GetMemberAccessGroups(long MemberID)
        {
            List<MemberAccessGroup> personalAccessGroupsList = MemberAccessGroupsRepository.GetMemberAccessGroups(MemberID);

            return personalAccessGroupsList ?? new List<MemberAccessGroup>();
        }

        public void AddMemberAccessGroup(MemberAccessGroup MemberAccessGroup)
        {
            MemberAccessGroupsRepository.AddMemberAccessGroup(MemberAccessGroup);
        }

        public void EditMemberAccessGroup(MemberAccessGroup MemberAccessGroup)
        {
            MemberAccessGroupsRepository.EditMemberAccessGroup(MemberAccessGroup);
        }

        public void SaveMemberAccessGroup()
        {
            MemberAccessGroupsRepository.SaveMemberAccessGroup();
        }


        public void DeleteMemberAccessGroup(MemberAccessGroup MemberAccessGroup)
        {
            MemberAccessGroupsRepository.DeleteMemberAccessGroup(MemberAccessGroup);
        }
    }
}