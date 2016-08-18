using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class AccessMemberReportsRepository : KruAllBaseRepository<AC_Reports>
    {
        //type 1 saving for AccessPersonalReport
        //type 2 saving for AccessVisitorReport
        //type 3 saving for AccessMemberReport

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_Reports> GetAccessMemberReports()
        {
            return base.GetAll().Where(e => e.Type == 3).ToList();
        }

        public List<AC_Reports> GetAccessMemberReportskeine()
        {
            List<AC_Reports> lst = base.GetAll().Where(e => e.Type == 3).ToList();
            lst.Insert(0, new AC_Reports { ID = 0, Nr = 0, Name = "Keine" });
            return lst;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.Nr).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetAccessMemberReportById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(cc => cc.Type == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetAccessMemberReportByNr(long Nr)
        {
            return base.FindBy(cc => cc.Nr == Nr).Where(cc => cc.Type == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessMemberReport(AC_Reports accessReport)
        {
            accessReport.Type = 3;
            base.Add(accessReport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessMemberReport(AC_Reports accessReport)
        {
            if (accessReport.ID == 0) return;
            accessReport.Type = 3;
            base.Edit(accessReport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessMemberReport(AC_Reports accessReport)
        {
            if (accessReport.ID == 0) return;
            var currentAccessReport = GetAccessMemberReportById(accessReport.ID);
            base.Delete(currentAccessReport);
            Save();
        }
    }
}
