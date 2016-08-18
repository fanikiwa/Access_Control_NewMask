using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class DepartmentViewModel
    {
        #region Constructor

        public DepartmentViewModel() { }

        #endregion

        #region Properties

        LocationRepository _locationRepoository = new LocationRepository();
        DepartmentRepository _departmentRepository = new DepartmentRepository();

        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Location> Locations()
        {
            return _locationRepoository.GetLocations();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Department> Departments()
        {
            return _departmentRepository.GetDepartments();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateDepartment(Department department)
        {
            _departmentRepository.NewDepartment(department);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateDepartment(Department department)
        {
            _departmentRepository.EditDepartment(department);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteDepartment(Department department)
        {
            _departmentRepository.DeleteDepartment(department);
        }

        #endregion
    }
}