using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class PersAccessGroupsViewModel
    {
        PersAccessGroupsRepository persAccessGroupsRepository = new PersAccessGroupsRepository();
        public PersAccessGroupsViewModel() { }

        public List<PersAccessGroupsDto> GetPersAccessGroupsTemplate(int templateSize, bool includeAllGroups, long persNr)
        {
            List<PersAccessGroupsDto> personalAccessGroupsList = new List<PersAccessGroupsDto>();
            List<Pers_AccessGroups> dbPersonalAccessGroupsList = GetPersAccessGroups(persNr);
            //List<TbAccessPlanGroup> tbAccessPlanGroups = new List<TbAccessPlanGroup>();
            //tbAccessPlanGroups = (new AccessPlanGroupRepository().GetAllAccessPlanGroups()) ?? new List<TbAccessPlanGroup>();
            //tbAccessPlanGroups.Add(new TbAccessPlanGroup() { ID = 0, AccessPlanGroupNr = 0, AccessPlanGroupName = ">>>Keine<<<" });
            //tbAccessPlanGroups = tbAccessPlanGroups.OrderBy(x => x.AccessPlanGroupNr).ToList();

            for (int i = 0; i < templateSize; i++)
            {
                Pers_AccessGroups dbPersonalAccessGroup = dbPersonalAccessGroupsList.Count > i ?
                    dbPersonalAccessGroupsList[i] : new Pers_AccessGroups();

                personalAccessGroupsList.Add(new PersAccessGroupsDto()
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

        public List<PersAccessGroupsDto> GetPersAccessGroupByPersNr(long persNr)
        {
            List<PersAccessGroupsDto> personalAccessGroupsList = GetPersAccessGroupsTemplate(8, true, persNr);

            return personalAccessGroupsList;
        }

        public List<Pers_AccessGroups> GetPersAccessGroups(long persNr)
        {
            List<Pers_AccessGroups> personalAccessGroupsList = persAccessGroupsRepository.GetPersonnelAccessGroups(persNr);

            return personalAccessGroupsList ?? new List<Pers_AccessGroups>();
        }

        public void AddPersAccessGroup(Pers_AccessGroups persAccessGroup)
        {
            persAccessGroupsRepository.AddPersAccessGroup(persAccessGroup);
        }

        public void EditPersAccessGroup(Pers_AccessGroups persAccessGroup)
        {
            persAccessGroupsRepository.EditPersAccessGroup(persAccessGroup);
        }

        public void SavePersAccessGroup()
        {
            persAccessGroupsRepository.SavePersAccessGroup();
        }


        public void DeletePersAccessGroup(Pers_AccessGroups persAccessGroup)
        {
            persAccessGroupsRepository.DeletePersAccessGroup(persAccessGroup);
        }
    }
}