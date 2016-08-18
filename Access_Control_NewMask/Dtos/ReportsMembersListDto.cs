using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class ReportsMembersListDto
    {
        public long ID { get; set; }
        public string GroupName { get; set; }
        public string GroupNameFrom { get; set; }
        public string GroupNameTo { get; set; }
        public long? GroupNumber { get; set; }
        public string MemberName { get; set; }
        public string MemberNameFrom { get; set; }
        public string MemberNameTo { get; set; }
        public long? MemberNumber { get; set; }
        public string Place { get; set; }
        public string PlaceFrom { get; set; }
        public string PlaceTo { get; set; }
        public string PostalCode { get; set; }
        public string Salutation { get; set; }
        public string StreetNumber { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Profession { get; set; }
        public string Telephone { get; set; }
        public string MobileNr { get; set; }
        public string Email { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? LongTermCardNumber { get; set; }
        public long? ShortTermCardNumber { get; set; }
        public string AccessDateFromTo { get; set; }
        public long? AccessPlanNr { get; set; }
        public string AccessPlanName { get; set; }
        public long? PostalCodeFilter { get; set; }
        public bool IsMemberActive { get; set; }
        public string LoggedInUser { get; set; }

        public bool HideGroupName { get; set; }
        public bool HideGroupNumber { get; set; }
        public bool HideMemberName { get; set; }
        public bool HideMemberNumber { get; set; }
        public bool HidePlace { get; set; }
        public bool HidePostalCode { get; set; }
        public bool HideSalutation { get; set; }
        public bool HideStreetNumber { get; set; }
        public bool HideContractNumber { get; set; }
        public bool HideDateOfBirth { get; set; }
        public bool HideNationality { get; set; }
        public bool HideProfession { get; set; }
        public bool HideTelephone { get; set; }
        public bool HideMobileNr { get; set; }
        public bool HideEmail { get; set; }
        public bool HideStartDate { get; set; }
        public bool HideEndDate { get; set; }
        public bool HideLongTermCardNumber { get; set; }
        public bool HideShortTermCardNumber { get; set; }
        public bool HideAccessDateFromTo { get; set; }
        public bool HideAccessPlanNr { get; set; }
        public bool HideAccessPlanName { get; set; }
        
    }
}