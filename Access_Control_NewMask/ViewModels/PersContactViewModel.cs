using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.ViewModels
{

    public class PersContactViewModel
    {
        #region Constructor
        public PersContactViewModel() { }

        #endregion

        #region Properties
        private PersContactRepository _PersContactRepository = new PersContactRepository();
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Contact GetPersContactsById(long id)
        {
            var personnel = _PersContactRepository.GetPersContactById(id);
            return personnel;
        }

        public Pers_Contact GetPersContactsPersNr(long Pers_Nr)
        {
            var personnel = _PersContactRepository.GetPersContactByPersNr(Pers_Nr);
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Contact> GetAllPersContacts()
        {
            var personnel = _PersContactRepository.GetPersContacts();
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersContacts(Pers_Contact personnel, bool save = true)
        {
            _PersContactRepository.AddPersContact(personnel, save);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersContacts(Pers_Contact personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersContactRepository.EditPersContact(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersContacts(Pers_Contact personnel)
        {
            if (personnel.ID == 0) return;
            _PersContactRepository.DeletePersContact(personnel);
        }
        #endregion
    }
}