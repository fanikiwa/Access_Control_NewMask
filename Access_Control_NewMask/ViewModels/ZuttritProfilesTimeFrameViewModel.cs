using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.ViewModels
{
    public class ZuttritProfilesTimeFrameViewModel
    {
        #region Properties
        ZuttritProfilesTimeFramesRepository timeFrameRepository = new ZuttritProfilesTimeFramesRepository();
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfilesTimeFrame> GetZuttritProfilesTimeFrames()
        {
            return timeFrameRepository.GetAllZuttritProfilesTimeFrames();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfilesTimeFrame> GetZuttritProfilesTimeFramesByAccessProfID(long accessProfID)
        {
            return timeFrameRepository.GetZuttritProfilesTimeFramesByAccessProfID(accessProfID);
        }

        public ZuttritProfilesTimeFrame GetZuttritProfilesTimeFrameByID(long id)
        {
            return timeFrameRepository.GetZuttritProfilesTimeFrameById(id);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame ZuttritProfilesTimeFrame)
        {
            timeFrameRepository.NewZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame ZuttritProfilesTimeFrame)
        {
            timeFrameRepository.EditZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfilesTimeFrame(ZuttritProfilesTimeFrame department)
        {
            timeFrameRepository.DeleteZuttritProfilesTimeFrame(department);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfilesTimeFrameById(long id)
        {
            timeFrameRepository.DeleteZuttritProfilesTimeFrameByID(id);
        }
        #endregion


        #region utility functions

        public List<ZuttritProfilesTimeFrame> GetZuttritProfileTimeFrames()
        {
            var zuttritProfilesTimeFrame = new List<ZuttritProfilesTimeFrame>();
            try
            {
                for (int i = -10; i < 0; i++)
                {
                    var zuttritProfileTimeFrame = new ZuttritProfilesTimeFrame
                    {
                        AccessProfID = 0,
                        ProfilAktiv = false,
                        MonFrom = Convert.ToDateTime(null),
                        MonTo = Convert.ToDateTime(null),
                        TueFrom = Convert.ToDateTime(null),
                        TueTo = Convert.ToDateTime(null),
                        WedFrom = Convert.ToDateTime(null),
                        WedTo = Convert.ToDateTime(null),
                        ThurFrom = Convert.ToDateTime(null),
                        ThurTo = Convert.ToDateTime(null),
                        FriFrom = Convert.ToDateTime(null),
                        FriTo = Convert.ToDateTime(null),
                        SatFrom = Convert.ToDateTime(null),
                        SatTo = Convert.ToDateTime(null),
                        SunFrom = Convert.ToDateTime(null),
                        SunTo = Convert.ToDateTime(null),
                        ZuttritProfile = null
                    };
                    zuttritProfileTimeFrame.ID = i;
                    zuttritProfilesTimeFrame.Add(zuttritProfileTimeFrame);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return zuttritProfilesTimeFrame;
        }

        public List<ZuttritProfilesTimeFrame> GetNewZuttritProfileTimeFrames()
        {
            var zuttritProfilesTimeFrame = new List<ZuttritProfilesTimeFrame>();
            try
            {
                for (int i = -30; i < -20; i++)
                {
                    var zuttritProfileTimeFrame = new ZuttritProfilesTimeFrame
                    {
                        AccessProfID = 0,
                        ProfilAktiv = false,
                        MonFrom = Convert.ToDateTime(null),
                        MonTo = Convert.ToDateTime(null),
                        TueFrom = Convert.ToDateTime(null),
                        TueTo = Convert.ToDateTime(null),
                        WedFrom = Convert.ToDateTime(null),
                        WedTo = Convert.ToDateTime(null),
                        ThurFrom = Convert.ToDateTime(null),
                        ThurTo = Convert.ToDateTime(null),
                        FriFrom = Convert.ToDateTime(null),
                        FriTo = Convert.ToDateTime(null),
                        SatFrom = Convert.ToDateTime(null),
                        SatTo = Convert.ToDateTime(null),
                        SunFrom = Convert.ToDateTime(null),
                        SunTo = Convert.ToDateTime(null),
                        ZuttritProfile = null
                    };
                    zuttritProfileTimeFrame.ID = i;
                    zuttritProfilesTimeFrame.Add(zuttritProfileTimeFrame);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return zuttritProfilesTimeFrame;
        }
        #endregion utility functions
    }
}
