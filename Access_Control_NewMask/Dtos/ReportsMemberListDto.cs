using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class ReportsMemberListDto
    {
        public long ID { get; set; }
        public long ReportListID { get; set; }
        public int ListNr { get; set; }
        public string ListDescription { get; set; }
        public int MemberType { get; set; }
        public int StartStudioGroup { get; set; }
        public int EndStudioGroup { get; set; }
        public int StartMemberName { get; set; }
        public int EndMemberName { get; set; }
        public int StartMemberId { get; set; }
        public int EndMemberId { get; set; }
        public int StartPlace { get; set; }
        public int EndPlace { get; set; }
        public int StartPostalCode { get; set; }
        public int EndPostalCode { get; set; }
        public int VariableType { get; set; }


        //fields from meberReportChecks 
        public bool ShowStudioGroup { get; set; }
        public bool ShowMemberName { get; set; }
        public bool ShowMemberId { get; set; }
        public bool ShowPlace { get; set; }
        public bool ShowPostalCode { get; set; }
        public bool ShowSalutation { get; set; }
        public bool ShowStreetAndNr { get; set; }
        public bool ShowContractNr { get; set; } 
        public bool ShowDOB { get; set; }
        public bool ShowNationality { get; set; }
        public bool ShowProfession { get; set; } 
        public bool ShowTelephone { get; set; }
        public bool ShowMobile { get; set; } 
        public bool ShowEmail { get; set; } 
        public bool ShowEntryDate { get; set; }
        public bool ShowExitDate { get; set; } 
        public bool ShowLongTermCard { get; set; }
        public bool ShowShortTermCard { get; set; }
        public bool ShowAccessFromTo { get; set; }
        public bool ShowAccessPlanNr { get; set; }
        public bool ShowAccessPlanDesc { get; set; } 
    }
}