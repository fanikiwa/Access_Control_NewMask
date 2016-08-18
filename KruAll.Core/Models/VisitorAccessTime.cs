namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorAccessTime")]
    public partial class VisitorAccessTime
    {
        public long ID { get; set; }

        public long VisitorId { get; set; }

        public long VisitInstanceId { get; set; }

        public string CardNr { get; set; }

        public string PinCode { get; set; }

        public long? VisitPlanId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AutoEndDate { get; set; }

        public string AutoEndDateStd { get; set; }

        public string Memo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RegistrationDate { get; set; }

        public bool? AccessPlanActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? VisitAccessStartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? VisitAccessEndDate { get; set; }

        public string VisitReason { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateActivated { get; set; }

        public long? PersNr { get; set; }

        public long? CompanyTo { get; set; }

        public bool? IsCanceled { get; set; }

        public bool? AutoLogout { get; set; }

        public virtual Client Client { get; set; }

        public virtual TbVisitorPlan TbVisitorPlan { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
