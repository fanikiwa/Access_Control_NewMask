namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_MemberAccessLog
    {
        public long? ID { get; set; }

        public long? MemberNumber { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Come { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Go { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime BookingTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingCorrection { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LogID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string TerminalSerial { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string ReaderID { get; set; }
    }
}
