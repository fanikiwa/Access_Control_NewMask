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
    public class PersDepartmentRepository : KruAllBaseRepository<Pers_Departments>
    {
        #region Constructor
        public PersDepartmentRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Departments> GetDepartments()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Departments GetPersDepartmentPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        public Pers_Departments GetDepartmentByID(long ID)
        {
            return base.FindBy(x => x.ID == ID).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewDepartment(Pers_Departments department)
        {
            base.Add(department);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewDepartmentCustom(Pers_Departments department)
        {
            base.Add(department);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditDepartment(Pers_Departments department)
        {
            if (department.ID == 0) return;
            base.Edit(department);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditDepartmentCustom(Pers_Departments department)
        {
            if (department.ID == 0) return;
            base.Edit(department);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteDepartmentn(Pers_Departments department)
        {
            if (department.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(department);
            Save();
        }
        #endregion
    }
}
