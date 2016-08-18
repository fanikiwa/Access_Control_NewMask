using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KruAll.Core.Repositories
{
    public class PersContactRepository : KruAllBaseRepository<Pers_Contact>
    {
    
        #region Constructor
        public PersContactRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Contact> GetPersContacts()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Contact GetPersContactById(long id)
        {
            return base.FindBy(p => p.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Contact GetPersContactByPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersContact(Pers_Contact contact, bool save = true)
        {
            base.Add(contact);
            if (save) Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersContact(Pers_Contact contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersContactCustom(Pers_Contact contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersContact(Pers_Contact contact)
        {
            if (contact.ID == 0) return; 
            base.Delete(contact);
            Save();
        }
        #endregion
    }
}
