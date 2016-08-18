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
    public class DepartmentRepository : KruAllBaseRepository<Department>
    {
        #region Constructor
        public DepartmentRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Department> GetDepartments()
        {
            return base.GetAll().OrderBy(x => x.Department_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Department GetDepartmentById(long id)
        {
            return base.FindBy(d => d.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Department GetDepartmentByNr(int id)
        {
            return base.FindBy(d => d.Department_Nr == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Department GetByName(string name)
        {
            return base.FindBy(d => d.Name == name).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Department> GetDepartmentsByLocationId(int locationId)
        {
            return base.FindBy(d => d.ID == locationId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewDepartment(Department department)
        {
            base.Add(department);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditDepartment(Department department)
        {
            if (department.ID == 0) return;
            base.Edit(department);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteDepartment(Department department)
        {
            if (department.ID == 0) return;
            var currentDepartment = GetDepartmentById(department.ID);
            base.Delete(currentDepartment);
            Save();
        }
        #endregion
    }
}
