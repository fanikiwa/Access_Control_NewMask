namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Reports
    {
        public AC_Reports()
        {
            AC_ReportSettings = new HashSet<AC_ReportSettings>();
        }

        public long ID { get; set; }

        public long Nr { get; set; }

        public string Name { get; set; }

        public int? Type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndTime { get; set; }

        public string StartLocationB { get; set; }

        public string EndLocationB { get; set; }

        public string StartBuilding { get; set; }

        public string EndBuilding { get; set; }

        public string StartLevel { get; set; }

        public string EndLevel { get; set; }

        public string StartRoom { get; set; }

        public string EndRoom { get; set; }

        public string StartDoor { get; set; }

        public string EndDoor { get; set; }

        public int? StartClient { get; set; }

        public int? EndClient { get; set; }

        public int? StartLocation { get; set; }

        public int? EndLocation { get; set; }

        public int? StartDept { get; set; }

        public int? EndDept { get; set; }

        public int? StartCostCenter { get; set; }

        public int? EndCostCenter { get; set; }

        public int? StartPersonal { get; set; }

        public int? EndPersonal { get; set; }

        public int? StartShortTransponder { get; set; }

        public int? EndShortTranspoder { get; set; }

        public int? StartLongTranspoder { get; set; }

        public int? EndLongTransponder { get; set; }

        public int? StartMemberGroup { get; set; }

        public int? EndMemberGroup { get; set; }

        public virtual ICollection<AC_ReportSettings> AC_ReportSettings { get; set; }
    }
}
