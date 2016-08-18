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
    public class ZuttritProfileRepository : KruAllBaseRepository<ZuttritProfile>
    {
        #region Constructor
        public ZuttritProfileRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfile> GetAllZuttritProfiles()
        {
            return base.GetAll().Include(z => z.ZuttritProfilesTimeFrames).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ZuttritProfile GetZuttritProfileById(long id)
        {
            return base.FindBy(e => e.ID == id).Include(z => z.ZuttritProfilesTimeFrames).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfile> GetProfilesByGroupId(long groupID)
        {
            return base.FindBy(e => e.GroupID == groupID).Include(z => z.ZuttritProfilesTimeFrames).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ZuttritProfile GetZuttritProfileByAccessProfileNo(int accessProfileNo)
        {
            return base.FindBy(e => e.AccessProfileNo == accessProfileNo).Include(z => z.ZuttritProfilesTimeFrames).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ZuttritProfile GetProfileIDByGroupIdAndProfileNo(long GroupID, long ProfileNo)
        {
            return base.FindBy(e => e.GroupID == GroupID && e.AccessProfileNo == ProfileNo).Include(z => z.ZuttritProfilesTimeFrames).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ZuttritProfile GetZuttritProfileByAccessProfileId(string profileId)
        {
            return base.FindBy(e => e.AccessProfileID == profileId).Include(z => z.ZuttritProfilesTimeFrames).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewZuttritProfile(ZuttritProfile ZuttritProfile)
        {
            base.Add(ZuttritProfile);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditZuttritProfile(ZuttritProfile ZuttritProfile)
        {
            if (ZuttritProfile.ID == 0) return;
            base.Edit(ZuttritProfile);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfile(ZuttritProfile ZuttritProfile)
        {
            if (ZuttritProfile.ID == 0) return;
            var currentZuttritProfile = GetZuttritProfileById(ZuttritProfile.ID);
            Delete(currentZuttritProfile);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfileById(long id)
        {
            if (id == 0) return;
            var currentZuttritProfile = GetZuttritProfileById(id);
            Delete(currentZuttritProfile);
            Save();
        }

        #endregion
    }
}
