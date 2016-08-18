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
    public class PersDepartmentViewModel

    {
        #region Constructor
        public PersDepartmentViewModel() { }

        #endregion

        #region Properties
        private PersDepartmentRepository _PersDepartmentRepository = new PersDepartmentRepository();
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Departments GetPersDepartmentById(long id)
        {
            var personnel = _PersDepartmentRepository.GetDepartmentByID(id);
            return personnel;
        }

        public Pers_Departments GetPersDepartmentByPersNr(long Pers_Nr)
        {
            var personnel = _PersDepartmentRepository.GetPersDepartmentPersNr(Pers_Nr);
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Departments> GetAllPersDepartment()
        {
            var personnel = _PersDepartmentRepository.GetDepartments();
            return personnel;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersLocation(Pers_Departments personnel, bool save = true)
        {
            _PersDepartmentRepository.NewDepartment(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersLocations(Pers_Departments personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersDepartmentRepository.EditDepartment(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersLocations(Pers_Departments personnel)
        {
            if (personnel.ID == 0) return;
            _PersDepartmentRepository.DeleteDepartmentn(personnel);
        }
        #endregion
    }
}