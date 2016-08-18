using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class ReportsPersonalListDto
    {
        public long ID { get; set; }
        public long ReportListID { get; set; }
        public int ListNr { get; set; }
        public string ListDescription { get; set; }
        public int PersonType { get; set; }
        public int StartClient { get; set; }
        public int EndClient { get; set; }
        public int StartLocation { get; set; }
        public int EndLocation { get; set; }
        public int StartDepartmet { get; set; }
        public int EndDepartment { get; set; }
        public int StartName { get; set; }
        public int EndName { get; set; }
        public int StartIdNr { get; set; }
        public int EndIdNr { get; set; }
        public int VariableType { get; set; }


        //fields from personalReportChecks 
        public bool ShowClientCompany { get; set; }
        public bool ShowLocation { get; set; }
        public bool ShowDepartment { get; set; }
        public bool ShowName { get; set; }
        public bool ShowIDNr { get; set; }
        public bool ShowPlace { get; set; }
        public bool ShowPostalCode { get; set; }
        public bool ShowStreetAndNr { get; set; }
        public bool ShowDOB { get; set; }
        public bool ShowEntryDate { get; set; }
        public bool ShowExitDate { get; set; }
        public bool ShowEmploymentPosition { get; set; }
        public bool ShowNationality { get; set; }
        public bool ShowCompanyTelephone { get; set; }
        public bool ShowCompanyMobile { get; set; }
        public bool ShowPrivateTelephone { get; set; }
        public bool ShowPrivateMobile { get; set; }
        public bool ShowLongTermCard { get; set; }
        public bool ShowShortTermCard { get; set; }
        public bool ShowAccessFromTo { get; set; }
        public bool ShowAccessPlanNr { get; set; }
        public bool ShowAccessPlanDesc { get; set; }

    }
}