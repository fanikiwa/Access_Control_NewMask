using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class MembersListRptDto
    {
        public long GroupFrom { get; set; }
        public long GroupTo { get; set; }
        public long NameNrFrom { get; set; }
        public long NameNrTo { get; set; }
        public string NameFrom { get; set; }
        public string NameTo { get; set; }
        public long MemberNumberFrom { get; set; }
        public long MemberNumberTo { get; set; }
        public long PlaceIdFrom { get; set; }
        public long PlaceIdTo { get; set; }
        public string PlaceNameFrom { get; set; }
        public string PlaceNameTo { get; set; }
        public long PostalCodeFrom { get; set; }
        public long PostalCodeTo { get; set; }
        public bool AciveMembers { get; set; }
        public bool InAaciveMembers { get; set; }
        public string GroupBy { get; set; }
       
    }
}