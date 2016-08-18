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
    public class PresClientViewModel
    {
        #region Constructor
        public PresClientViewModel() { }

        #endregion

        #region Properties
        private PersClientRepository _PersClientRepository = new PersClientRepository();
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Client GetPersClientById(long id)
        {
            var personnel = _PersClientRepository.GetPersClientByClientID(id);
            return personnel;
        }

        public Pers_Client GetPersClientByPersNr(long Pers_Nr)
        {
            var personnel = _PersClientRepository.GetPersClientByPersNo(Pers_Nr);
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Client> GetAllPersClient()
        {
            var personnel = _PersClientRepository.GetAllPersClient();
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersAdditionalInfo(Pers_Client personnel, bool save = true)
        {
            _PersClientRepository.InsertPersClient(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersAdditionalInfo(Pers_Client personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersClientRepository.UpdatePerz(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersAdditionalInfo(Pers_Client personnel)
        {
            if (personnel.ID == 0) return;
            _PersClientRepository.DeletePersClient(personnel.Pers_Nr);
        }
        #endregion
    }
}