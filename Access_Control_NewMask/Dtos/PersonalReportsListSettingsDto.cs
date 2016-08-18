using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersonalReportsListSettingsDto
    {
        public long ID { get; set; }
        public long Nr { get; set; }
        public string Name { get; set; }
        public int ReportType { get; set; }
        public Nullable<int> StartClient { get; set; }
        public Nullable<int> EndClient { get; set; }
        public Nullable<int> StartLocation { get; set; }
        public Nullable<int> EndLocation { get; set; }
        public Nullable<int> StartDept { get; set; }
        public Nullable<int> EndDept { get; set; }
        public Nullable<int> StartPersonal { get; set; }
        public Nullable<int> EndPersonal { get; set; }
        public Nullable<int> StartPersID { get; set; }
        public Nullable<int> EndPersID { get; set; }


        public int PersonalType { get; set; }

        //Display settings for the grid
        public bool DisplayClient { get; set; }
        public bool DisplayLocation { get; set; }
        public bool DisplayDepartment { get; set; }
        public bool DisplayCostCenter { get; set; }
        public bool DisplayName { get; set; }
        public bool DisplayPlace { get; set; }

        public bool DisplayPersonalID { get; set; }
        public bool DisplayPostalCode { get; set; }
        public bool DisplayStreetAndNr { get; set; }
        public bool DisplayDateOfBirth { get; set; }
        public bool DisplayEnrtyDate { get; set; }
        public bool DisplayExitDate { get; set; }
        public bool DisplayEmployedAs { get; set; }
        public bool DisplayNationality { get; set; }
        public bool DisplayCompanyTelephone { get; set; }
        public bool DisplayCompanyMobile { get; set; }
        public bool DisplayPrivateTelephone { get; set; }
        public bool DisplayPrivateMobile { get; set; }
        public bool DisplayLongTermCard { get; set; }
        public bool DisplayShortTermCard { get; set; }
        public bool DisplayAccessAuthorization { get; set; }
        public bool DisplayAccessPlanNr { get; set; }
        public bool DisplayAccessPlanDescription { get; set; }
        public string VariableText { get; set; }
    }
}