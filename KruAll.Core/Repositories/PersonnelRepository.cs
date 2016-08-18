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
    public class PersonnelRepository : KruAllBaseRepository<Personal>
    {
        #region Constructor
        public PersonnelRepository() { }

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
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }
        public Personal GetPersonnelPersnur(long Pers_Nr)
        {
            return base.FindBy(e => e.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Personal GetPersonnelByPersNumber(long Persnr)
        {
            return base.FindBy(ps => ps.Pers_Nr == Persnr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Personal GetPersonnelByCardNr(long identificationNr)
        {
            return base.FindBy(ps => ps.Card_Nr == identificationNr).FirstOrDefault();
        }

        public Personal GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.ID).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IQueryable<Personal> GetPersonalsQuery()
        {
            return base.GetAll();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonnel(Personal personnel)
        {
            base.Add(personnel);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonnelCustom(Personal personnel)
        {
            base.Add(personnel);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonnel(Personal Personnel)
        {
            if (Personnel.ID == 0) return;
            base.Edit(Personnel);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonnelCustom(Personal Personnel)
        {
            if (Personnel.ID == 0) return;
            base.Edit(Personnel);
            //Save();
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
