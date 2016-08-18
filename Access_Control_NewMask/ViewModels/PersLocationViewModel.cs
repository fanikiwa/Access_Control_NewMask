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
    public class PersLocationViewModel
    {
        #region Constructor
        public PersLocationViewModel() { }

        #endregion

        #region Properties
        private PersLocationsRepository _PersLocationsRepository = new PersLocationsRepository();
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Locations GetPersLocationsById(long id)
        {
            var personnel = _PersLocationsRepository.GetPercLocationsById(id);
            return personnel;
        }

        public Pers_Locations GetPersLocationsByPersNr(long Pers_Nr)
        {
            var personnel = _PersLocationsRepository.GetPercLocationsPersNr(Pers_Nr);
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Locations> GetAllPersLocations()
        {
            var personnel = _PersLocationsRepository.GetAllPercLocations();
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersLocation(Pers_Locations personnel, bool save = true)
        {
            _PersLocationsRepository.AddPercLocations(personnel, save);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersLocations(Pers_Locations personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersLocationsRepository.EditPercLocations(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersLocations(Pers_Locations personnel)
        {
            if (personnel.ID == 0) return;
            _PersLocationsRepository.DeletePercLocations(personnel);
        }
        #endregion
    }
}