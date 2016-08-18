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
    public class AccessReportsChecks : KruAllBaseRepository<AC_ReportSettings>
    {

        //type save The window number
        //ReportPersonal == 1
        //ReportVisitor == 2
        //ReportMember == 3

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportSettings> GetAllPersonalChecks()
        {
            return base.GetAll().Where(e => e.Type == 1).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetPersonalCheckById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(e => e.Type == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetPersonalCheckByReportId(long id)
        {
            return base.FindBy(cc => cc.ReportID == id).Where(e => e.Type == 1).FirstOrDefault();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetPersonalCheckByPrintType(int PrintSelection)
        {
            return base.FindBy(cc => cc.PrintSelection == PrintSelection).Where(e => e.Type == 1).FirstOrDefault();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonalAccessCheck(AC_ReportSettings AccessCheck)
        {
            //base.Add(AccessCheck);
            //Save();

            AccessCheck.Type = 1;
            base.Add(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonalAccessCheck(AC_ReportSettings AccessCheck)
        {
            //if (AccessCheck.ID == 0) return;
            //base.Edit(AccessCheck);
            //Save();

            if (AccessCheck.ID == 0) return;
            AccessCheck.Type = 1;
            base.Edit(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonalAccessCheck(AC_ReportSettings AccessCheck)
        {
            if (AccessCheck.ID == 0) return;
            var currentAccessReport = GetPersonalCheckById(AccessCheck.ID);
            base.Delete(currentAccessReport);
            Save(); 
        }


        //check type 2 (visitorReport)
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportSettings> GetAllVisitorChecks()
        {
            return base.GetAll().Where(e => e.Type == 2).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetVisitorCheckById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(e => e.Type == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetVisitorCheckByReportId(long id)
        {
            return base.FindBy(cc => cc.ReportID == id).Where(e => e.Type == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetVisitorCheckByPrintType(int PrintSelection)
        {
            return base.FindBy(cc => cc.PrintSelection == PrintSelection).Where(e => e.Type == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVisitorAccessCheck(AC_ReportSettings AccessCheck)
        {
            //base.Add(AccessCheck);
            //Save();

            AccessCheck.Type = 2;
            base.Add(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVisitorAccessCheck(AC_ReportSettings AccessCheck)
        {
            //if (AccessCheck.ID == 0) return;
            //base.Edit(AccessCheck);
            //Save();


            if (AccessCheck.ID == 0) return;
            AccessCheck.Type = 2;
            base.Edit(AccessCheck);
            Save(); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitorAccessCheck(AC_ReportSettings AccessCheck)
        {
            if (AccessCheck.ID == 0) return;
            var currentAccessReport = GetVisitorCheckById(AccessCheck.ID);
            base.Delete(currentAccessReport);
            Save();
        }


        //check for Members type==3
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportSettings> GetAllMemberChecks()
        {
            return base.GetAll().Where(e => e.Type == 3).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetMemberCheckById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(e => e.Type == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetMemberCheckByReportId(long id)
        {
            return base.FindBy(cc => cc.ReportID == id).Where(e => e.Type == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportSettings GetMemberCheckByPrintType(int PrintSelection)
        {
            return base.FindBy(cc => cc.PrintSelection == PrintSelection).Where(e => e.Type == 3).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewMemberAccessCheck(AC_ReportSettings AccessCheck)
        {
            //base.Add(AccessCheck);
            //Save();

            AccessCheck.Type = 3;
            base.Add(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberAccessCheck(AC_ReportSettings AccessCheck)
        {
            //if (AccessCheck.ID == 0) return;
            //base.Edit(AccessCheck);
            //Save();
             
            if (AccessCheck.ID == 0) return;
            AccessCheck.Type = 3;
            base.Edit(AccessCheck);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberAccessCheck(AC_ReportSettings AccessCheck)
        {
            if (AccessCheck.ID == 0) return;
            var currentAccessReport = GetMemberCheckById(AccessCheck.ID);
            base.Delete(currentAccessReport);
            Save();
        }
    }
}
