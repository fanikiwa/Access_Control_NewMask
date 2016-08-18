using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace KruAll.Core.Repositories
{
    public class PersonalRepository : KruAllBaseRepository<Personal>
    {
        #region Constructor
        public PersonalRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Personal> GetAllPersonnel()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Personal GetPersonnelById(long id)
        {
            return base.FindBy(p => p.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Personal GetPersonnelByNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Personal GetPersonnelByCardNr(long identificationNr)
        {
            return base.FindBy(p => p.Card_Nr == identificationNr).FirstOrDefault();
        }

        public Personal GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.ID).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersonnel(Personal personnel, bool save = true)
        {
            base.Add(personnel);
            if (save) Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonnel(Personal Personnel, bool save = true)
        {
            if (Personnel.ID == 0) return;
            base.Edit(Personnel);
            if (save) Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonnel(Personal Personnel)
        {
            if (Personnel.ID == 0) return;
            var currentEmployee = GetPersonnelById(Personnel.ID);
            Delete(currentEmployee);
            Save();
        }
        public void SaveAll()
        {
            Save();
        }
        #endregion
    }
}