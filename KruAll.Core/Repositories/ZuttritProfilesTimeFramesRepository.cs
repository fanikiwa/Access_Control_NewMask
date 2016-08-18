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
    public class ZuttritProfilesTimeFramesRepository : KruAllBaseRepository<ZuttritProfilesTimeFrame>
    {
        #region Constructor
        public ZuttritProfilesTimeFramesRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfilesTimeFrame> GetAllZuttritProfilesTimeFrames()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfilesTimeFrame> GetZuttritProfilesTimeFramesByAccessProfID(long accessProfID)
        {
            return base.FindBy(e => e.AccessProfID == accessProfID).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ZuttritProfilesTimeFrame GetZuttritProfilesTimeFrameById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame ZuttritProfilesTimeFrame)
        {
            base.Add(ZuttritProfilesTimeFrame);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame ZuttritProfilesTimeFrame)
        {
            if (ZuttritProfilesTimeFrame.ID == 0) return;
            base.Edit(ZuttritProfilesTimeFrame);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame ZuttritProfilesTimeFrame)
        {
            if (ZuttritProfilesTimeFrame.ID == 0) return;
            var currentZuttritProfilesTimeFrame = GetZuttritProfilesTimeFrameById(ZuttritProfilesTimeFrame.ID);
            Delete(currentZuttritProfilesTimeFrame);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfilesTimeFrameByID(long Id)
        {
            if (Id == 0) return;
            var currentZuttritProfilesTimeFrame = GetZuttritProfilesTimeFrameById(Id);
            Delete(currentZuttritProfilesTimeFrame);
            Save();
        }
        #endregion
    }
}
