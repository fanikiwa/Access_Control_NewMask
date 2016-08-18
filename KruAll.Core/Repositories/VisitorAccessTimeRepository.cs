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
    public class VisitorAccessTimeRepository: KruAllBaseRepository<VisitorAccessTime>
    {
        #region Constructor
        public VisitorAccessTimeRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VisitorAccessTime> GetAllVisitorAccessTime()
        {
            return base.GetAll().Include(x => x.Visitor).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }




        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeByCompany(long id)
        {
            return base.FindBy(e => e.Visitor.Company == id).FirstOrDefault();
        }


        public List<VisitorAccessTime> getAccessTimeByCompany(long id)
        {
            return base.FindBy(e => e.Visitor.Company == id && e.StartDate >= DateTime.Today).ToList();
        }



        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeByVisitInstanceId(long instanceId)
        {
            return base.FindBy(e => e.VisitInstanceId == instanceId).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeByVisitor_Id(long id)
        {
            var accessTime = base.FindBy(e => e.VisitorId == id).ToList();
            var _accessTime = accessTime.FirstOrDefault();
            if (accessTime.Count > 0)
            {
                var maxId = accessTime.Max(x => x.ID);
                _accessTime = accessTime.Where(x => x.ID == maxId).FirstOrDefault();
            }
            return _accessTime ?? new VisitorAccessTime();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeByVisitorId(long visitInstanceId)
        {
            return base.FindBy(e => e.VisitInstanceId == visitInstanceId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewAccessTime(VisitorAccessTime accessTime)
        {
            base.Add(accessTime);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAccessTime(VisitorAccessTime accessTime)
        {
            if (accessTime.ID == 0) return;
            base.Edit(accessTime);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessTime(VisitorAccessTime accessTime)
        {
            if (accessTime.ID == 0) return;
            var currentAccessTime = GetAccessTimeById(accessTime.ID);
            Delete(currentAccessTime);
            Save();
        }


        #endregion
    }
}
