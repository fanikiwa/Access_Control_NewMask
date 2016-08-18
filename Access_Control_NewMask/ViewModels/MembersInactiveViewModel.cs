using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class MembersInactiveViewModel
    {
        public List<MemberGroupDto> MemberGroups()
        {
            List<MemberGroupDto> groups = new List<MemberGroupDto>();
            var memberGroups = new MemberGroupsRepositories().GetAllMemberGroups();
            foreach (var group in memberGroups)
            {
                MemberGroupDto groupDto = new MemberGroupDto()
                {
                    Id = group.Id,
                    GroupNr = group.GroupNr,
                    GroupNumber = group.GroupNr.ToString(),
                    GroupName = group.GroupName,
                    PersonHead = group.PersonHead,
                    TrainerOne = group.TrainerOne,
                    TrainerTwo = group.TrainerTwo,
                    TrainerThree = group.TrainerThree,
                    TrainerFour = group.TrainerFour,
                    TrainerFive = group.TrainerFive
                };
                groups.Add(groupDto);
            }
            return groups.OrderBy(x => x.GroupNr).ToList();
        }

        private static string GetPhotoName(MembersDataDto dto)
        {
            string photoImageFile = dto.MemberPhoto;
            if ((!string.IsNullOrWhiteSpace(dto.PersonPhotoInBinary)))
            {
                if (dto.PersonPhotoInBinary.Length > 0)// get from binary
                {
                    photoImageFile = FileProcessor.SaveImageFile("," + dto.PersonPhotoInBinary, dto.FirstName + dto.ID.ToString());
                }
            }
            else // get from relative path
            {
                photoImageFile = FileProcessor.GetImageMemberFileNameFromRelativePath(dto.MemberPhoto);
            }

            dto.PersonPhotoInBinary = string.Empty;
            return photoImageFile;
        }

        public MembersData SaveMemberData(MembersDataDto member)
        {

            string photoImageFile = GetPhotoName(member);

            MembersData memberData = new MembersData()
            {
                ID = member.ID,
                SurName = member.SurName,
                FirstName = member.FirstName,
                MemberGroupId = Convert.ToInt64(member.MemberGroupId) > 0 ? member.MemberGroupId : null,
                Salutation = Convert.ToInt64(member.Salutation) > 0 ? member.Salutation : null,
                Street = member.Street,
                StreetNumber = member.StreetNumber,
                PostalCode = member.PostalCode,
                Place = member.Place,
                MemberNumber = Convert.ToInt64(member.MemberNumber),
                ContractDuration = Convert.ToInt64(member.ContractDuration) > 0 ? member.ContractDuration : null,
                DateOfBirth = member.DateOfBirth,
                Nationality = member.Nationality,
                Profession = member.Profession,
                Telephone = member.Telephone,
                MobilePhone = member.MobilePhone,
                Email = member.Email,
                MemberPhoto= photoImageFile,
                //MemberPhoto = FileProcessor.SaveMemberPhoto(","
                //+ member.MemberPhoto, member.SurName + member.MemberNumber.ToString()),
                Memo = member.Memo,
                EntryDate = member.EntryDate,
                ExitDate = member.ExitDate,
                AgreementNr = member.AgreementNr,
                ActiveCard = member.ActiveCard == null?0: member.ActiveCard

            };
            if (memberData.ID > 0)
            {
                new MembersDataInactiveRepository().EditMemberData(memberData);
                if (memberData != null)
                {
                    CreateAccessPlan(member, memberData);
                }
            }
            else if (memberData.ID == 0)
            {
                new MembersDataInactiveRepository().NewMemberData(memberData);
                if (memberData != null)
                {
                    CreateAccessPlan(member, memberData);
                }
            }
            return memberData;
        }
        public List<MembersDataDto> MemberDetails()
        {
            List<MembersDataDto> membersList = new List<MembersDataDto>();
            var members = new MembersDataInactiveRepository().GetAllMembersData();
            foreach (var member in members)
            {
                MembersDataDto memberDto = new MembersDataDto()
                {
                    ID = member.ID,
                    MemberNumber = member.MemberNumber ?? 0,
                    SurName = member.SurName,
                    FirstName = member.FirstName,
                    MemberGroupId = member.MemberGroupId,
                    AgreementNr = member.AgreementNr
                };

                membersList.Add(memberDto);
            }
            return membersList.OrderBy(x => x.MemberNumber).ToList();
        }
        public List<MembersDataDto> GetAllMembersData()
        {
            List<MembersDataDto> membersList = new List<MembersDataDto>();
            var members = new MembersDataInactiveRepository().GetAllMembersData();
            foreach (var member in members)
            {
                MembersDataDto memberDto = new MembersDataDto()
                {
                    ID = member.ID,
                    MemberNumber = member.MemberNumber ?? 0,
                    SurName = member.SurName,
                    FirstName = member.FirstName,
                    MemberGroupId = member.MemberGroupId,
                    AgreementNr = member.AgreementNr
                };

                membersList.Add(memberDto);
            }
            return membersList.OrderBy(x => x.MemberNumber).ToList();
        }
        public List<AccessPlanMembersDto> GetAccessPlanMembersDtoList()
        {
            List<AccessPlanMembersDto> membersList = new List<AccessPlanMembersDto>();
            var members = new MembersDataInactiveRepository().GetAllMembersData();
            foreach (var member in members)
            {
                AccessPlanMembersDto memberDto = new AccessPlanMembersDto()
                {
                    ID = member.ID,
                    MemberNumber = member.MemberNumber ?? 0,
                    SurName = member.SurName,
                    FirstName = member.FirstName,
                    MemberGroupId = member.MemberGroupId,
                    AgreementNr = member.AgreementNr
                };

                membersList.Add(memberDto);
            }
            return membersList.OrderBy(x => x.MemberNumber).ToList();
        }
        public List<AccessPlanMembersDto> GetMembersForAccessPlanList(long accessPlan_Id)
        {
            List<AccessPlanMembersDto> membersList = new List<AccessPlanMembersDto>();
            var accessplannedmemberids = from apmv in new AccessPlanMembersMappingViewModel().GetAllMappings()
                                         where apmv.AccessPlan_ID == accessPlan_Id
                                         select apmv.MemberID;

            var accessplannedmemberdetails = from apmd in new MembersDataInactiveRepository().GetAllMembersData()
                                             where accessplannedmemberids.Contains(apmd.ID)
                                             select apmd;

            foreach (var member in accessplannedmemberdetails)
            {
                AccessPlanMembersDto memberDto = new AccessPlanMembersDto()
                {
                    ID = member.ID,
                    MemberNumber = member.MemberNumber ?? 0,
                    SurName = member.SurName,
                    FirstName = member.FirstName,
                    MemberGroupId = member.MemberGroupId,
                    AgreementNr = member.AgreementNr,
                    Salutation = member.Salutation,
                    Street = member.Street,
                    StreetNumber = member.StreetNumber,
                    PostalCode = member.PostalCode,
                    Place = member.Place,
                    ContractDuration = member.ContractDuration,
                    DateOfBirth = member.DateOfBirth,
                    Nationality = member.Nationality,
                    Profession = member.Profession,
                    Telephone = member.Telephone,
                    MobilePhone = member.MobilePhone,
                    Email = member.Email,
                    MemberPhoto = string.IsNullOrWhiteSpace(member.MemberPhoto) ? member.MemberPhoto : FileProcessor.GetMemberImageRelativeFilePath(member.MemberPhoto),
                    Memo = member.Memo,
                    EntryDate = member.EntryDate,
                    ExitDate = member.ExitDate,
                    AccessPlanNr = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().TbAccessPlan.AccessPlanNr.ToString() : "",
                    AccessPlanName = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().TbAccessPlan.AccessPlanDescription : "",
                    AccessPLanStartDate = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().DateFrom : null,
                    AccessPLanEndDate = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().DateTo : null

                };

                membersList.Add(memberDto);
            }
            return membersList.OrderBy(x => x.MemberNumber).ToList();
        }
        public MembersDataDto GetMemberById(long id)
        {
            MembersDataDto memberDto = new MembersDataDto();
            var member = new MembersDataInactiveRepository().GetMemberDataById(id);
            if (member != null)
            {
                memberDto.ID = member.ID;
                memberDto.SurName = member.SurName;
                memberDto.FirstName = member.FirstName;
                memberDto.MemberGroupId = member.MemberGroupId;
                memberDto.Salutation = member.Salutation;
                memberDto.Street = member.Street;
                memberDto.StreetNumber = member.StreetNumber;
                memberDto.PostalCode = member.PostalCode;
                memberDto.Place = member.Place;
                memberDto.MemberNumber = member.MemberNumber ?? 0;
                memberDto.ContractDuration = member.ContractDuration;
                memberDto.DateOfBirth = member.DateOfBirth;
                memberDto.Nationality = member.Nationality;
                memberDto.Profession = member.Profession;
                memberDto.Telephone = member.Telephone;
                memberDto.MobilePhone = member.MobilePhone;
                memberDto.Email = member.Email;
                memberDto.MemberPhoto = string.IsNullOrWhiteSpace(member.MemberPhoto) ? member.MemberPhoto : FileProcessor.GetMemberImageRelativeFilePath(member.MemberPhoto);
                memberDto.Memo = member.Memo;
                memberDto.EntryDate = member.EntryDate;
                memberDto.ExitDate = member.ExitDate;
                memberDto.AccessPlanNr = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().TbAccessPlan.AccessPlanNr.ToString() : "";
                memberDto.AccessPlanName = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().TbAccessPlan.AccessPlanDescription : "";
                memberDto.AccessPLanStartDate = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().DateFrom : null;
                memberDto.AccessPLanEndDate = member.MembersAccessPlanMappings.FirstOrDefault() != null ? member.MembersAccessPlanMappings.FirstOrDefault().DateTo : null;
                memberDto.AgreementNr = member.AgreementNr;
                memberDto.ActiveCard = member.ActiveCard;
            }
            return memberDto;
        }
        public void CreateAccessPlan(MembersDataDto memberDataDto, MembersData memberData)
        {
            if (!string.IsNullOrEmpty(memberDataDto.AccessPlanNr))
            {
                var accessPlan = new AccessPlanRepository().GetAccessPlanByNumber(Convert.ToInt64(memberDataDto.AccessPlanNr));
                if (accessPlan != null)
                {

                    var mappedPlan = new MembersAccessPlanMappingRepository().GetMemberAccessPLanByMemberId(memberData.ID);

                    if (mappedPlan != null)
                    {
                        MembersAccessPlanMapping _mappedPLan = new MembersAccessPlanMapping()
                        {
                            ID = mappedPlan.ID,
                            AccessPlan_Nr = accessPlan.ID,
                            MemberID = memberData.ID,
                            DateFrom = memberDataDto.AccessPLanStartDate,
                            DateTo = memberDataDto.AccessPLanEndDate
                        };
                        new MembersAccessPlanMappingRepository().EditMemberAccessPlan(_mappedPLan);
                    }
                    else
                    {
                        MembersAccessPlanMapping _mappedPLan = new MembersAccessPlanMapping()
                        {
                            AccessPlan_Nr = accessPlan.ID,
                            MemberID = memberData.ID,
                            DateFrom = memberDataDto.AccessPLanStartDate,
                            DateTo = memberDataDto.AccessPLanEndDate
                        };

                        new MembersAccessPlanMappingRepository().NewMemberAccessPlan(_mappedPLan);
                    }

                }

            }

        }
        public List<MemberGroupDto> FilterMemberGroups()
        {
            List<MemberGroupDto> filtered = new List<MemberGroupDto>();
            var members = new MembersDataInactiveRepository().GetAllMembersData();
            var groups = MemberGroups();
            foreach (var group in groups)
            {
                var groupExists = members.Find(x => x.MemberGroupId == group.Id);
                if (groupExists != null)
                {
                    filtered.Add(group);
                }

            }
            return filtered.OrderBy(x => x.GroupNr).ToList();
        }
        public List<MemberSearchDto> MemberSearchDetails()
        {
            List<MemberSearchDto> memberDetails = new List<MemberSearchDto>();
            var members = new MembersDataInactiveRepository().GetAllMembersData();
            var groups = MemberGroups();
            foreach (var member in members)
            {
                MemberSearchDto memberData = new MemberSearchDto();
                memberData.ID = member.ID;
                memberData.MemberNumber = Convert.ToInt64(member.MemberNumber);
                memberData.FirstName = member.FirstName;
                memberData.SurName = member.SurName;
                if (member.MemberGroupId != null)
                {
                    var group = groups.Find(x => x.Id == member.MemberGroupId);
                    if (group != null)
                    {
                        memberData.GroupNumber = group.GroupNumber;
                        memberData.GroupName = group.GroupName;
                        memberData.GroupId = group.Id;
                    }
                }
                memberDetails.Add(memberData);
            }
            return memberDetails.OrderBy(x => x.MemberNumber).ToList();
        }
        public long ReturnNxtMemberNr()
        {
            long nextNr = 0;
            var members = new MembersDataInactiveRepository().GetAllMembersData();
            List<MembersDataDto> membersNum = new List<MembersDataDto>();
            foreach (var member in members)
            {
                MembersDataDto num = new MembersDataDto()
                {
                    MemberNum = Convert.ToInt64(member.MemberNumber)
                };
                membersNum.Add(num);
            }
            if (membersNum.Count > 0)
            {
                var maxNr = Convert.ToInt64(membersNum.Max(x => x.MemberNum));
                nextNr = maxNr;
            }
            return nextNr + 1;
        }

        public List<AccessPlanMembersDto> GetMembersGivenIds(List<long> memberIds)
        {
            return GetAccessPlanMembersDtoList().Where(p => memberIds.Contains(p.ID)).ToList();
        }


    }
}