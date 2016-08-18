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
    public class PersAccessGroupsRepository : KruAllBaseRepository<Pers_AccessGroups>
    {
        public PersAccessGroupsRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AccessGroups> GetPersonnelAccessGroups(long persNr)
        {
            return base.GetAll().Where(x => x.Pers_Nr == persNr).ToList();
        }

        //[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        //public Pers_Vehicles GetPersVehiclesByPersNr(long persNr)
        //{
        //    return base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
        //}

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_AccessGroups GetPersAccessGroupByPersNr(long persNr)
        {
            return base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AccessGroups> GetPersonnelAccessGroups(long persNr, long AccessGroupId)
        {
            return base.GetAll().Where(x => x.Pers_Nr == persNr && x.GroupID == AccessGroupId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_AccessGroups GetAccessGroupById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AccessGroups> GetPersAccessGroups(long Id)
        {
            return base.GetAll().Where(x => x.Pers_Nr == Id).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AccessGroups> GetAllPersAccessGroups()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersAccessGroup(Pers_AccessGroups persAccessGroup)
        {
            base.Add(persAccessGroup);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersAccessGroup(Pers_AccessGroups persAccessGroup)
        {
            if (persAccessGroup.ID <= 0) return;
            base.Edit(persAccessGroup);
        }

        public void SavePersAccessGroup()
        {
            base.Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersAccessGroup(Pers_AccessGroups AccessGroup)
        {
            if (AccessGroup.ID == 0) return;
            var currentAccessGroup = GetAccessGroupById(AccessGroup.ID);
            Delete(currentAccessGroup);
            Save();

        }
    }
}
