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
    public class PersContactsRepository : KruAllBaseRepository<Pers_Contact>
    {
        #region Constructor
        public PersContactsRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Contact> GetContacts()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Contact GetPersContactByPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewContact(Pers_Contact contact)
        {
            base.Add(contact);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewContactCustom(Pers_Contact contact)
        {
            base.Add(contact);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditContact(Pers_Contact contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditContactCustom(Pers_Contact contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteContact(Pers_Contact contact)
        {
            if (contact.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(contact);
            Save();
        }
        #endregion
    }
}
