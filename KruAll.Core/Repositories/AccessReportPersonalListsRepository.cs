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
    public class AccessReportPersonalListsRepository : KruAllBaseRepository<AC_ReportList>
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<AC_ReportList> GetAllPersonalLists()
        {
            return base.GetAll().Where(x => x.ListType == 1).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportList GetLastInsertedPersonalList()
        {
            return base.GetAll().OrderByDescending(x => x.ListNr).Where(x => x.ListType == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportList GetPersonalListById(long id)
        {
            return base.FindBy(cc => cc.ID == id).Where(x => x.ListType == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public AC_ReportList GetPersonalListByNr(long Nr)
        {
            return base.FindBy(cc => cc.ListNr == Nr).Where(x => x.ListType == 1).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonalList(AC_ReportList PersonalList)
        {
            PersonalList.ListType = 1;
            base.Add(PersonalList);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonalList(AC_ReportList PersonalList)
        {
            if (PersonalList.ID == 0) return;
            PersonalList.ListType = 1;
            base.Edit(PersonalList);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonalList(AC_ReportList PersonalList)
        {
            if (PersonalList.ID == 0) return;
            var currentPersonalList = GetPersonalListById(PersonalList.ID);
            base.Delete(currentPersonalList);
            Save();
        }
    }
}
