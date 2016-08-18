namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MembersTransponder
    {
        public long ID { get; set; }

        public long MemberID { get; set; }

        public long TransponderNr { get; set; }

        public bool? TransponderStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValidTo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TransponderDeactivatedOn { get; set; }

        public int? Action { get; set; }

        public string Memo { get; set; }

        public int? TransponderType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExtendedTo { get; set; }

        public virtual MembersData MembersData { get; set; }
    }
}
