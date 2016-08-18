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
    public class PersonTypeRepository : KruAllBaseRepository<Pers_Type>
    {

        #region Constructor
        public PersonTypeRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Type> GetAllPersonTypes()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Type GetPersonTypeById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersType(Pers_Type personnel)
        {
            base.Add(personnel);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersType(Pers_Type Personnel)
        {
            if (Personnel.ID == 0) return;
            base.Edit(Personnel);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersType(Pers_Type Personnel)
        {
            if (Personnel.ID == 0) return;
            var currentPersonnel = GetPersonTypeById(Personnel.ID);
            Delete(currentPersonnel);
            Save();
        }

        #endregion
    }
}
