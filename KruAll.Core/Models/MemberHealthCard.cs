namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberHealthCard")]
    public partial class MemberHealthCard
    {
        public long ID { get; set; }

        public long? MemberID { get; set; }

        public string BoxNumber { get; set; }

        public string CreatedIn { get; set; }

        public string ItemNumber { get; set; }

        public string SecurityNumber { get; set; }

        public string CardNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpiryDate { get; set; }

        public string Memo { get; set; }

        public virtual MembersData MembersData { get; set; }
    }
}
