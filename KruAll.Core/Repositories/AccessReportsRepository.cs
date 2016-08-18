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
    public class AccessReportsRepository : KruAllBaseRepository<AC_Reports>
    {

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_Reports> GetAccessReports()
        {
            return base.GetAll().Where(x => x.Type == 1).ToList();
        }

        public List<AC_Reports> GetAccessReportskeine()
        {
            List<AC_Reports> lst = base.GetAll().ToList();
            lst.Insert(0, new AC_Reports { ID = 0, Nr = 0, Name = "Keine" });
            return lst;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.Nr).Where(x => x.Type == 1).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetAccessReportById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(x => x.Type == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_Reports GetAccessReportByNr(long Nr)
        {
            return base.FindBy(cc => cc.Nr == Nr).Where(x => x.Type == 1).FirstOrDefault();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessReport(AC_Reports accessReport)
        {
            accessReport.Type = 1;
            base.Add(accessReport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessReport(AC_Reports accessReport)
        {
            if (accessReport.ID == 0) return;
            accessReport.Type = 1;
            base.Edit(accessReport);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessReport(AC_Reports accessReport)
        {
            if (accessReport.ID == 0) return;
            var currentAccessReport = GetAccessReportById(accessReport.ID);
            base.Delete(currentAccessReport);
            Save();
        }
    }
}
