namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_DrivingLicense
    {
        public long ID { get; set; }

        public long? Pers_Nr { get; set; }

        public string CreatedIn { get; set; }

        public string DLNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfIssue { get; set; }

        public string DLClass { get; set; }

        public string IssuingAuthority { get; set; }

        [Required]
        public string Memo { get; set; }
    }
}
