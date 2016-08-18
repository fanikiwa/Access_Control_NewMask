using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class PersDataRepository : KruAllBaseRepository<VwPersonnelData>
    {

        public VwPersonnelData GetPersDataByID(long PersID)
        {
            return base.FindBy(p => p.ID == PersID).FirstOrDefault();
        }

        public VwPersonnelData GetPersByClientID(long ClientID)
        {
            return base.FindBy(p => p.ClientID == ClientID).FirstOrDefault();
        }

        public List<VwPersonnelData> GetAllPersonal()
        {
            return base.GetAll().ToList();
        }


        public VwPersonnelData GetPersByLocationID(long ID)
        {
            return base.FindBy(p => p.LocationID == ID).FirstOrDefault();
        }

        public VwPersonnelData GetPersByDepartmentID(long ID)
        {
            return base.FindBy(p => p.DepartmentID == ID).FirstOrDefault();
        }
        public VwPersonnelData GetPersDataByNr(long ID)
        {
            return base.FindBy(p => p.Pers_Nr == ID).FirstOrDefault();
        }

        public void DeletePers(VwPersonnelData _VwPersonnelData)
        {
            base.Delete(_VwPersonnelData);
            base.Save();
        }
    }
}
