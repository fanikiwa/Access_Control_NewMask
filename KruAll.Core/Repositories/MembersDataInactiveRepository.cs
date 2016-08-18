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
    public class MembersDataInactiveRepository: KruAllBaseRepository<MembersData>
    {
        #region Constructor
        public MembersDataInactiveRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<MembersData> GetAllMembersData()
        {
            return base.GetAll().Where(i=>i.Active == false).OrderBy(x => x.MemberNumber).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MembersData GetMemberDataById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
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
