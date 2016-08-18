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
    public class MembersDataRepository : KruAllBaseRepository<MembersData>
    {
        #region Constructor
        public MembersDataRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MembersData> GetAllMembersData()
        {
            return base.GetAll().OrderBy(x => x.MemberNumber).ToList();
        }
        public List<MembersData> GetAllMembersData(bool active)
        {
            return (base.GetAll().Where(x => x.Active == active).ToList() ?? new List<MembersData>()).OrderBy(x => x.MemberNumber).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MembersData GetMemberDataById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MembersData GetMemberDataById(long id, bool active)
        {
            return base.FindBy(e => e.ID == id && e.Active == active).FirstOrDefault();
        }
        public MembersData GetMemberDataByNr(long memberNr)
        {
            return base.FindBy(e => e.MemberNumber == memberNr).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewMemberData(MembersData memberData)
        {
            base.Add(memberData);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberData(MembersData memberData)
        {
            if (memberData.ID == 0) return;
            base.Edit(memberData);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteMemberData(MembersData memberData)
        {
            if (memberData.ID == 0) return;
            var currentMember = GetMemberDataById(memberData.ID);
            Delete(currentMember);
            Save();

        }

        #endregion
    }
}
