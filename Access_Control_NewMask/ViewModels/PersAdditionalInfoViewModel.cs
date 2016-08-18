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
    public class PersAdditionalInfoViewModel
    {
        #region Constructor
        public PersAdditionalInfoViewModel() { }

        #endregion

        #region Properties
        private PersAdditionalInfoRepository _PersAdditionalInfoRepository = new PersAdditionalInfoRepository();
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_AdditionalInfo GetPersAdditionalInfoById(long id)
        {
            var personnel = _PersAdditionalInfoRepository.GetPersAdditionalInfos().Where(i=>i.ID ==  id).FirstOrDefault();
            return personnel;
        }

        public Pers_AdditionalInfo GetPersAdditionalInfoByPersNr(long Pers_Nr)
        {
            var personnel = _PersAdditionalInfoRepository.GetPersAdditionalInfoByNr(Pers_Nr);
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AdditionalInfo> GetAllPersAdditionalInfo()
        {
            var personnel = _PersAdditionalInfoRepository.GetPersAdditionalInfos();
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersAdditionalInfo(Pers_AdditionalInfo personnel, bool save = true)
        {
            _PersAdditionalInfoRepository.NewPersAdditionalInfo(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersAdditionalInfo(Pers_AdditionalInfo personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersAdditionalInfoRepository.EditPersAdditionalInfo(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersAdditionalInfo(Pers_AdditionalInfo personnel)
        {
            if (personnel.ID == 0) return;
            _PersAdditionalInfoRepository.DeletePersAdditionalInfo(personnel);
        }
        #endregion
    }
}