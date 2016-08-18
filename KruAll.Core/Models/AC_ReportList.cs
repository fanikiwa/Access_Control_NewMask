namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_ReportList
    {
        public AC_ReportList()
        {
            AC_ReportListChecks = new HashSet<AC_ReportListChecks>();
        }

        public long ID { get; set; }

        public long ListNr { get; set; }

        public string ListDescription { get; set; }

        public int? ListType { get; set; }

        public int? PersonType { get; set; }

        public int? StartClient { get; set; }

        public int? EndClient { get; set; }

        public int? StartLocation { get; set; }

        public int? EndLocation { get; set; }

        public int? StartDepartmet { get; set; }

        public int? EndDepartment { get; set; }

        public int? StartName { get; set; }

        public int? EndName { get; set; }

        public int? StartIdNr { get; set; }

        public int? EndIdNr { get; set; }

        public int? MemberType { get; set; }

        public int? StartPlace { get; set; }

        public int? EndPlace { get; set; }

        public int? StartPostalCode { get; set; }

        public int? EndPostalCode { get; set; }

        public int? VariableType { get; set; }

        public int? StartStudioGroup { get; set; }

        public int? EndStudioGroup { get; set; }

        public virtual ICollection<AC_ReportListChecks> AC_ReportListChecks { get; set; }
    }
}
