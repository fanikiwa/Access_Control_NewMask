namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberIdentityCard")]
    public partial class MemberIdentityCard
    {
        public long ID { get; set; }

        public long? MemberID { get; set; }

        public string CreatedIn { get; set; }

        public string IDNumber { get; set; }

        public string AdditionalNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfIssue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpiryDate { get; set; }

        public string Address { get; set; }

        public string IssuingAuthority { get; set; }

        public string Memo { get; set; }

        public virtual MembersData MembersData { get; set; }
    }
}
