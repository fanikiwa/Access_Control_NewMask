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
    public class MembersTranspondersRepository : KruAllBaseRepository<MembersTransponder>
    {
        public MembersTranspondersRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MembersTransponder GetTransponderById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MembersTransponder> GetMemberTransponders(long Id)
        {
            return base.GetAll().Where(x => x.MemberID == Id).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MembersTransponder> GetAllMemberTransponders()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MembersTransponder> GetMemberTransponders(long Id, long transponderNr)
        {
            return base.GetAll().Where(x => x.MemberID == Id && x.TransponderNr == transponderNr).ToList();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddMemberTransponder(MembersTransponder memberTransponder)
        {
            base.Add(memberTransponder);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberTransponder(MembersTransponder memberTransponder)
        {
            if (memberTransponder.ID <= 0) return;
            base.Edit(memberTransponder);
        }

        public void SavePersTransponder()
        {
            base.Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberTransponder(MembersTransponder transponder)
        {
            if (transponder.ID == 0) return;
            var currentTransponder = GetTransponderById(transponder.ID);
            Delete(currentTransponder);
            Save();

        }
    }
}
