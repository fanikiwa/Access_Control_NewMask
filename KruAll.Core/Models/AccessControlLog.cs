namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccessControlLog
    {
        public long ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TerminalSerial { get; set; }

        [Required]
        [StringLength(10)]
        public string ReaderID { get; set; }

        public long Card_Nr { get; set; }

        public long Pers_Nr { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AccessTime { get; set; }

        public long? VisitorID { get; set; }

        public long? MemberID { get; set; }
    }
}
