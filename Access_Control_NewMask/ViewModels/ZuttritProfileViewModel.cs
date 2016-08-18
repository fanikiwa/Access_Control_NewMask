using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.ViewModels
{
    public class ZuttritProfileViewModel
    {
        #region Properties
        ZuttritProfileRepository zuttritRepository = new ZuttritProfileRepository();
        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ZuttritProfile> ZuttritProfiles()
        {
            return new ZuttritProfileRepository().GetAllZuttritProfiles();
        }
        public ZuttritProfile GetZuttritProfileByID(int id)
        {
            return zuttritRepository.GetZuttritProfileById(id);
        }
        public ZuttritProfile GetZuttritProfileByAccessProfileNo(int accessProfileNr)
        {
            return zuttritRepository.GetZuttritProfileByAccessProfileNo(accessProfileNr);
        }

        public ZuttritProfile GetZuttritProfileByAccessProfileId(string profileId)
        {
            return zuttritRepository.GetZuttritProfileByAccessProfileId(profileId);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateZuttritProfile(ZuttritProfile ZuttritProfile)
        {
            zuttritRepository.NewZuttritProfile(ZuttritProfile);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateZuttritProfile(ZuttritProfile ZuttritProfile)
        {
            zuttritRepository.EditZuttritProfile(ZuttritProfile);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteZuttritProfile(ZuttritProfile _zuttritProfile)
        {
            zuttritRepository.DeleteZuttritProfile(_zuttritProfile);
        }
        public void DeleteZuttritProfileById(long id)
        {
            zuttritRepository.DeleteZuttritProfileById(id);
        }

        public void DeleteZuttritProfileTimeFrames(ZuttritProfile zuttritProfile)
        {
            ZuttritProfilesTimeFrameViewModel zuttritProfilesTimeFrameViewModel = new ZuttritProfilesTimeFrameViewModel();
            ZuttritProfilesTimeFramesRepository zuttritProfilesTimeFramesRepository = new ZuttritProfilesTimeFramesRepository();
            var zuttritProfileTimeFrames = zuttritProfilesTimeFrameViewModel.GetZuttritProfilesTimeFramesByAccessProfID(zuttritProfile.ID);
            if (zuttritProfileTimeFrames == null) return;

            foreach (var zuttritProfileTimeFrame in zuttritProfileTimeFrames)
            {
                zuttritProfilesTimeFramesRepository.DeleteZuttritProfilesTimeFrame(zuttritProfileTimeFrame);
            }
        }

        public void CreateZuttritProfileTimeFrames(ZuttritProfile zuttritProfile)
        {
            ZuttritProfilesTimeFrameViewModel zuttritProfilesTimeFrameViewModel = new ZuttritProfilesTimeFrameViewModel();
            var zuttritProfileTimeFrames = zuttritProfile.ZuttritProfilesTimeFrames;
            foreach (var zuttritProfileTimeFrame in zuttritProfileTimeFrames)
            {
                var newzuttritProfileTimeFrame = new ZuttritProfilesTimeFrame
                {
                    AccessProfID = zuttritProfile.ID,
                    ProfilAktiv = zuttritProfileTimeFrame.ProfilAktiv,
                    MonFrom = zuttritProfileTimeFrame.MonFrom,
                    MonTo = zuttritProfileTimeFrame.MonTo,
                    TueFrom = zuttritProfileTimeFrame.TueFrom,
                    WedFrom = zuttritProfileTimeFrame.WedFrom,
                    WedTo = zuttritProfileTimeFrame.WedTo,
                    ThurFrom = zuttritProfileTimeFrame.ThurFrom,
                    FriFrom = zuttritProfileTimeFrame.FriFrom,
                    FriTo = zuttritProfileTimeFrame.FriTo,
                    SatFrom = zuttritProfileTimeFrame.SatFrom,
                    SatTo = zuttritProfileTimeFrame.SatTo,
                    SunFrom = zuttritProfileTimeFrame.SunFrom,
                    SunTo = zuttritProfileTimeFrame.SunTo
                };

                zuttritProfilesTimeFrameViewModel.CreateZuttritProfilesTimeFrame(newzuttritProfileTimeFrame);
            }
        }

        public void DeleteZuttritProfileTimeFrame(ZuttritProfile zuttritProfile)
        {
            ZuttritProfilesTimeFrameViewModel zuttritProfilesTimeFrameViewModel = new ZuttritProfilesTimeFrameViewModel();
            ZuttritProfilesTimeFramesRepository zuttritProfilesTimeFramesRepository = new ZuttritProfilesTimeFramesRepository();
            var zuttritProfilesTimeFrames = zuttritProfilesTimeFrameViewModel.GetZuttritProfilesTimeFramesByAccessProfID(zuttritProfile.ID);
            if (zuttritProfilesTimeFrames == null) return;

            foreach (var zuttritProfilesTimeFrame in zuttritProfilesTimeFrames)
            {
                zuttritProfilesTimeFramesRepository.DeleteZuttritProfilesTimeFrame(zuttritProfilesTimeFrame);
            }
        }

        #endregion
    }
}
