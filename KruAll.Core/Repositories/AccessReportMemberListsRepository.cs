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
    public class AccessReportMemberListsRepository : KruAllBaseRepository<AC_ReportList>
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportList> GetAllMemberLists()
        {
            return base.GetAll().Where(x => x.ListType == 2).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportList GetLastInsertedMemberList()
        {
            return base.GetAll().OrderByDescending(x => x.ListNr).Where(x => x.ListType == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportList GetMemberListById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(x => x.ListType == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportList GetMemberListByNr(long Nr)
        {
            return base.FindBy(cc => cc.ListNr == Nr).Where(x => x.ListType == 2).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewMemberList(AC_ReportList memberList)
        {
            memberList.ListType = 2;
            base.Add(memberList);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberList(AC_ReportList memberList)
        {
            if (memberList.ID == 0) return;
            memberList.ListType = 2;
            base.Edit(memberList);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberList(AC_ReportList memberList)
        {
            if (memberList.ID == 0) return;
            var currentmemberList = GetMemberListById(memberList.ID);
            base.Delete(currentmemberList);
            Save();
        }
    }
}
