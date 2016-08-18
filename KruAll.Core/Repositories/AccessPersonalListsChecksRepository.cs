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
    public class AccessPersonalListsChecksRepository : KruAllBaseRepository<AC_ReportListChecks>
    { 
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportListChecks> GetAllPersonalChecks()
        {
            return base.GetAll().Where(e => e.ListType == 1).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportListChecks GetPersonalCheckById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(e => e.ListType == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportListChecks GetPersonalCheckByReportId(long id)
        {
            return base.FindBy(cc => cc.ReportListID == id).Where(e => e.ListType == 1).FirstOrDefault();
        }
          
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonalAccessCheck(AC_ReportListChecks AccessCheck)
        { 
            AccessCheck.ListType = 1;
            base.Add(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonalAccessCheck(AC_ReportListChecks AccessCheck)
        {
             
            if (AccessCheck.ID == 0) return;
            AccessCheck.ListType = 1;
            base.Edit(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonalAccessCheck(AC_ReportListChecks AccessCheck)
        {
            if (AccessCheck.ID == 0) return;
            var currentAccessReport = GetPersonalCheckById(AccessCheck.ID);
            base.Delete(currentAccessReport);
            Save(); 
        } 
    }
}
