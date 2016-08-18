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
    public class VisitorTranspondersRepository: KruAllBaseRepository<VisitorTransponder>
    {
        public VisitorTranspondersRepository() { }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VisitorTransponder> GetTranspondersByVisitorId(long VisitorNr)
        {
            return base.GetAll().Where(x => x.VisitorID == VisitorNr).ToList();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddVisitorTransponder(VisitorTransponder VisitorTransponder)
        {
            base.Add(VisitorTransponder);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VisitorTransponder> GetAllVisitorTransponders()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVisitorTransponder(VisitorTransponder VisitorTransponder)
        {
            if (VisitorTransponder.ID <= 0) return;
            base.Edit(VisitorTransponder);
        }

        public void SaveVisitorTransponder()
        {
            base.Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorTransponder GetTransponderById(long Id)
        {
            return base.GetAll().FirstOrDefault(x => x.ID == Id);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VisitorTransponder> GetVisitorTransponders(long Id, long transponderNr)
        {
            return base.GetAll().Where(x => x.VisitorID == Id && x.TransponderNr == transponderNr).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitorTransponder(VisitorTransponder transponder)
        {
            if (transponder.ID == 0) return;
            var currentTransponder = GetTransponderById(transponder.ID);
            Delete(currentTransponder);
            Save();

        }
    }
}
