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
    public class VisitorRepository : KruAllBaseRepository<Visitor>
    {
        #region Constructor
        public VisitorRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Visitor> GetAllVisitors()
        {
            return base.GetAll().OrderBy(x => x.VisitorID).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Visitor> GetAllVisitors2()
        {
            var visitors = base.GetAll().OrderBy(x => x.VisitorID).ToList();
            Visitor visitor = new Visitor() { ID = 0, Fullname = "keine", VisitorID = 0, Location = "keine" };
            List<Visitor> listVisitors = new List<Visitor>();
            listVisitors.Add(visitor);
            listVisitors.AddRange(visitors);
            return listVisitors;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Visitor GetVisitorById(long visitorID)
        {
            return base.FindBy(vs => vs.ID == visitorID).FirstOrDefault();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Visitor GetVisitorByVisitorId(long visitor_Id)
        {
            return base.FindBy(vs => vs.VisitorID == visitor_Id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Visitor> GetVisitorByFilters(int visitorsNumberFrom, int visitorsNumberTo)
        {
            return base.FindBy(v => v.ID >= visitorsNumberFrom && v.ID <= visitorsNumberTo
                         //&& v.Location >= locationFrom && v.Location <= locationTo
                         //&& v.Company >= companyFrom && v.Company <= companyTo
                         ).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVisitor(Visitor visitor)
        {
            base.Add(visitor);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVisitor(Visitor visitor)
        {
            if (visitor.ID == 0) return;
            base.Edit(visitor);
            Save();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitor(Visitor visitor)
        {
            if (visitor.ID == 0) return;
            var visitorToDelete = GetVisitorById(visitor.ID);
            Delete(visitorToDelete);
            Save();
        }
        #endregion
    }
}
