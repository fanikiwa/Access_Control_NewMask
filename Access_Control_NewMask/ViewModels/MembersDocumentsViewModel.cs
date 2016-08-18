using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class MembersDocumentsViewModel
    {
        public void saveMemberDocuments(MemberDocumentsDto document)
        {
            SaveMemberCard(document);
            SaveMemberPassport(document);
            SaveDrivingLicence(document);
            SaveHealthCard(document);
            SaveMemberCommonInfo(document);
        }
        public void SaveMemberCard(MemberDocumentsDto document)
        {
            var memberCard = new MemberIdentityCardRepository().GetCardByMemberId( Convert.ToInt64(document.MemberID));
            if(memberCard != null)
            {
                MemberIdentityCard card = new MemberIdentityCard()
                {
                    ID = memberCard.ID,
                    MemberID = memberCard.MemberID,
                    CreatedIn = document.IC_CreatedIn,
                    IDNumber = document.IC_IDNumber,
                    AdditionalNumber = document.IC_AdditionalNumber,
                    DateOfIssue = document.IC_DateOfIssue,
                    ExpiryDate = document.IC_ExpiryDate,
                    Address = document.IC_Address,
                    IssuingAuthority = document.IC_IssuingAuthority,
                    Memo = document.IC_Memo,
                };
                new MemberIdentityCardRepository().EditMemberCard(card);
            }
            else
            {
                MemberIdentityCard card = new MemberIdentityCard()
                {
                    MemberID = document.MemberID,
                    CreatedIn = document.IC_CreatedIn,
                    IDNumber = document.IC_IDNumber,
                    AdditionalNumber = document.IC_AdditionalNumber,
                    DateOfIssue = document.IC_DateOfIssue,
                    ExpiryDate = document.IC_ExpiryDate,
                    Address = document.IC_Address,
                    IssuingAuthority = document.IC_IssuingAuthority,
                    Memo = document.IC_Memo,
                   
                };
                new MemberIdentityCardRepository().AddMemberCard(card);
            }
        }
        public void SaveMemberCommonInfo(MemberDocumentsDto document)
        {
            var commonInfo = new MemberCommonInfoRepository().GetCommonInfoByMemberId(Convert.ToInt64(document.MemberID));
            if (commonInfo != null)
            {
                MemberCommonInfo card = new MemberCommonInfo()
                {
                    ID = commonInfo.ID,
                    MemberID = commonInfo.MemberID,
                    EyeColor = document.IC_EyeColor,
                    Height = document.IC_Height,
                    PlaceOfBirth = document.IC_PlaceOfBirth
                   
                };
                new MemberCommonInfoRepository().EditMemberCommonInfo(card);
            }
            else
            {
                MemberCommonInfo card = new MemberCommonInfo()
                {
                    MemberID = document.MemberID,
                    EyeColor = document.IC_EyeColor,
                    Height = document.IC_Height,
                    PlaceOfBirth = document.IC_PlaceOfBirth

                };
                new MemberCommonInfoRepository().AddMemberCommonInfo(card);
            }
        }
        public void SaveMemberPassport(MemberDocumentsDto document)
        {
            var memberPassport = new MemberPassportRepository().GetMemberPassportByMemberId(Convert.ToInt64(document.MemberID));
            if(memberPassport != null)
            {
                MemberPassport passport = new MemberPassport()
                {
                    ID = memberPassport.ID,
                    MemberID = memberPassport.MemberID,
                    CreatedIn = document.PP_CreatedIn,
                    PPNumber = document.PP_PPNumber,
                    Gender = document.PP_Gender,
                    DateOfIssue = document.PP_DateOfIssue,
                    ExpiryDate = document.PP_ExpiryDate,
                    IssuingAuthority = document.PP_IssuingAuthority,
                    Memo = document.PP_Memo
                };
                new MemberPassportRepository().EditMemberPassport(passport);
            }
            else
            {
                MemberPassport passport = new MemberPassport()
                {
                    MemberID = document.MemberID,
                    CreatedIn = document.PP_CreatedIn,
                    PPNumber = document.PP_PPNumber,
                    Gender = document.PP_Gender,
                    DateOfIssue = document.PP_DateOfIssue,
                    ExpiryDate = document.PP_ExpiryDate,
                    IssuingAuthority = document.PP_IssuingAuthority,
                    Memo = document.PP_Memo
                };
                new MemberPassportRepository().AddMemberPassport(passport);
            }
        }
        public void SaveDrivingLicence(MemberDocumentsDto document)
        {
            var drivingLicence = new MemberDrivingLicenseRepository().GetLicenceByMemberId(Convert.ToInt64(document.MemberID));
            
             if(drivingLicence != null)
            {
                MemberDrivingLicense licence = new MemberDrivingLicense()
                {
                    ID = drivingLicence.ID,
                    MemberID = drivingLicence.MemberID,
                    CreatedIn = document.DL_CreatedIn,
                    DLNumber = document.DL_DLNumber,
                    DateOfIssue = document.DL_DateOfIssue,
                    DLClass = document.DL_Class,
                    IssuingAuthority = document.DL_IssuingAuthority,
                    Memo = document.DL_Memo
                };
                new MemberDrivingLicenseRepository().EditMemberLicence(licence);
            }
            else
            {
                MemberDrivingLicense licence = new MemberDrivingLicense()
                {
                    MemberID = document.MemberID,
                    CreatedIn = document.DL_CreatedIn,
                    DLNumber = document.DL_DLNumber,
                    DateOfIssue = document.DL_DateOfIssue,
                    DLClass = document.DL_Class,
                    IssuingAuthority = document.DL_IssuingAuthority,
                    Memo = document.DL_Memo
                };
                new MemberDrivingLicenseRepository().AddMemberLicence(licence);
            }
        }
        public void SaveHealthCard(MemberDocumentsDto document)
        {
            var healthCard = new MemberHealthCardRepository().GetHealthCardByMemberId(Convert.ToInt64(document.MemberID));
            if(healthCard != null)
            {
                MemberHealthCard _healthCard = new MemberHealthCard()
                {
                    ID = healthCard.ID,
                    MemberID = healthCard.MemberID,
                    BoxNumber = document.HC_BoxNumber,
                    CreatedIn = document.HC_CreatedIn,
                    ItemNumber = document.HC_ItemNumber,
                    SecurityNumber = document.HC_SecurityNumber,
                    CardNumber = document.HC_CardNumber,
                    ExpiryDate = document.HC_ExpiryDate,
                    Memo = document.HC_Memo
                };
                new MemberHealthCardRepository().EditHealthCard(_healthCard);
            }
            else
            {
                MemberHealthCard _healthCard = new MemberHealthCard()
                {
                   
                    MemberID = document.MemberID,
                    BoxNumber = document.HC_BoxNumber,
                    CreatedIn = document.HC_CreatedIn,
                    ItemNumber = document.HC_ItemNumber,
                    SecurityNumber = document.HC_SecurityNumber,
                    CardNumber = document.HC_CardNumber,
                    ExpiryDate = document.HC_ExpiryDate,
                    Memo = document.HC_Memo
                };
                new MemberHealthCardRepository().AddHealthCard(_healthCard);
            }
        }
    }
}