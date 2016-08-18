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
    public class AccessVisitorReportsRepository : KruAllBaseRepository<AC_Reports>
    {

        //type 2 saving for AccessVisitorReport
        //type 3 saving for AccessMemberReport

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_Reports> GetAccessVisitorReports()
        {
            return base.GetAll().Where(e => e.Type == 2).ToList();
        }

        public List<AC_Reports> GetAccessVisitorReportskeine()
        {
            List<AC_Reports> lst = base.GetAll().Where(e => e.Type == 2).ToList();
            lst.Insert(0, new AC_Reports { ID = 0, Nr = 0, Name = "Keine" });
            return lst;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.Nr).Where(e => e.Type == 2).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetAccessVisitorReportById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(cc => cc.Type == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetAccessVisitorReportByNr(long Nr)
        {
            return base.FindBy(cc => cc.Nr == Nr).Where(cc => cc.Type == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessVisitorReport(AC_Reports accessReport)
        {
            accessReport.Type = 2;
            base.Add(accessReport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessVisitorReport(AC_Reports accessReport)
        {
            if (accessReport.ID == 0) return;
            accessReport.Type = 2;
            base.Edit(accessReport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessVisitorReport(AC_Reports accessReport)
        {
            if (accessReport.ID == 0) return;
            var currentAccessReport = GetAccessVisitorReportById(accessReport.ID);
            base.Delete(currentAccessReport);
            Save();
        }
    }
}
