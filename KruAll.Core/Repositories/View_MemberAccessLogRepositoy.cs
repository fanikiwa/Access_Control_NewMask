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
    public class View_MemberAccessLogRepositoy : KruAllBaseRepository<View_MemberAccessLog>
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<View_MemberAccessLog> GetAllView_MemberAccessLog()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public View_MemberAccessLog GetView_MemberAccessLogById(long id)
        {
            return base.FindBy(b => b.ID == id).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddNewView_MemberAccessLog(View_MemberAccessLog view_memberaccesslog)
        {
            base.Add(view_memberaccesslog);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void EditView_MemberAccessLog(View_MemberAccessLog view_memberaccesslog)
        {
            if (view_memberaccesslog.ID == 0) return;
            base.Edit(view_memberaccesslog);
            Save();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteView_MemberAccessLog(View_MemberAccessLog view_memberaccesslog)
        {
            if (view_memberaccesslog.ID == 0) return;
            base.Delete(view_memberaccesslog);
            Save();
        }
    }
}
