namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_Passport
    {
        public long ID { get; set; }

        public long? Pers_Nr { get; set; }

        public string CreatedIn { get; set; }

        public string PPNumber { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfIssue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpiryDate { get; set; }

        public string IssuingAuthority { get; set; }

        public string Memo { get; set; }
    }
}
