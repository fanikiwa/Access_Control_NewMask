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
    public class AccessMemberListsChecksRepository : KruAllBaseRepository<AC_ReportListChecks>
    {   
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportListChecks> GetmemberListChecks()
        {
            return base.GetAll().Where(e => e.ListType == 2).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportListChecks GetmemberListCheckById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(e => e.ListType == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportListChecks GetmemberListCheckByReportListId(long id)
        {
            return base.FindBy(cc => cc.ReportListID == id).Where(e => e.ListType == 2).FirstOrDefault();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewmemberListCheck(AC_ReportListChecks memberListCheck)
        {
            memberListCheck.ListType = 2;
            base.Add(memberListCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditmemberListCheck(AC_ReportListChecks memberListCheck)
        { 
            if (memberListCheck.ID == 0) return;
            memberListCheck.ListType = 2;
            base.Edit(memberListCheck);
            Save(); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberListCheck(AC_ReportListChecks memberListCheck)
        {
            if (memberListCheck.ID == 0) return;
            var currentmemberListCheck = GetmemberListCheckById(memberListCheck.ID);
            base.Delete(currentmemberListCheck);
            Save();
        } 
    }
}
