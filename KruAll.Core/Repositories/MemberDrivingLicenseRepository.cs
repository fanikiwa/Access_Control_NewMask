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
    public class MemberDrivingLicenseRepository: KruAllBaseRepository<MemberDrivingLicense>
    {
        public MemberDrivingLicenseRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberDrivingLicense GetLicenceById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public MemberDrivingLicense GetLicenceByMemberId(long memberId)
        {
            return base.FindBy(x => x.MemberID == memberId).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddMemberLicence(MemberDrivingLicense memberLicence)
        {
            base.Add(memberLicence);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditMemberLicence(MemberDrivingLicense memberLicence)
        {
            if (memberLicence.ID <= 0) return;
            base.Edit(memberLicence);
            Save();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteLicence(MemberDrivingLicense memberLicence)
        {
            if (memberLicence.ID == 0) return;
            var currentLicence = GetLicenceById(memberLicence.ID);
            Delete(currentLicence);
            Save();

        }
    }
}
