namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_ReportListChecks
    {
        public long ID { get; set; }

        public long? ReportListID { get; set; }

        public bool? ShowClientCompany { get; set; }

        public bool? ShowLocation { get; set; }

        public bool? ShowDepartment { get; set; }

        public bool? ShowName { get; set; }

        public bool? ShowIDNr { get; set; }

        public bool? ShowPlace { get; set; }

        public bool? ShowPostalCode { get; set; }

        public bool? ShowStreetAndNr { get; set; }

        public bool? ShowDOB { get; set; }

        public bool? ShowEntryDate { get; set; }

        public bool? ShowExitDate { get; set; }

        public bool? ShowEmploymentPosition { get; set; }

        public bool? ShowNationality { get; set; }

        public bool? ShowCompanyTelephone { get; set; }

        public bool? ShowCompanyMobile { get; set; }

        public bool? ShowPrivateTelephone { get; set; }

        public bool? ShowPrivateMobile { get; set; }

        public bool? ShowLongTermCard { get; set; }

        public bool? ShowShortTermCard { get; set; }

        public bool? ShowAccessFromTo { get; set; }

        public bool? ShowAccessPlanNr { get; set; }

        public bool? ShowAccessPlanDesc { get; set; }

        public int? ListType { get; set; }

        public bool? ShowSalutation { get; set; }

        public bool? ShowContractNr { get; set; }

        public bool? ShowProfession { get; set; }

        public bool? ShowEmail { get; set; }

        public bool? ShowMemberGroup { get; set; }

        public virtual AC_ReportList AC_ReportList { get; set; }
    }
}
