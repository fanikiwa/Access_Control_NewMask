using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class ReportMembersCardInfoDto
    {
        public long ID { get; set; }
        public long? CardNumber { get; set; }
        public int? Action { get; set; }
        public bool Active { get; set; }
        public bool Inactive { get; set; }
        public DateTime? ActiveEndDate { get; set; }
        public DateTime? ExtencedEndDate { get; set; }
        public string GroupName { get; set; }
        public int? CardsAllocated { get; set; }
        public int TotalExtensions { get; set; }
        public int ActiveCard { get; set; }
        public int InActiveCard { get; set; }
        public string MemberName { get; set; }
        public long? MemberNumber { get; set; }
        public string GroupNameFrom { get; set; }
        public string GroupNameTo { get; set; }
        public string MemberNameFrom { get; set; }
        public string MemberNameTo { get; set; }
        public long? MemberNumberFrom { get; set; }
        public long? MemberNumberTo { get; set; }
        public long? CardNumberFrom { get; set; }
        public long? CardNumberTo { get; set; }
        public string ActiveEndDateFrom { get; set; }
        public string ActiveEndDateTo { get; set; }
        public bool HideGroup { get; set; }
        public bool HideName { get; set; }
        public bool HideMemberNr { get; set; }
        public bool HideCardNr { get; set; }
        public bool HideCardExtensions { get; set; }
        public bool HideActions { get; set; }
        public bool HideActive { get; set; }
        public bool HideInactive { get; set; }
        public bool HideExpiryDate { get; set; }

        //Fields for the Report Display 
        public string PersonalCardType { get; set; }
        public string LoggedInUser { get; set; }
    }
}