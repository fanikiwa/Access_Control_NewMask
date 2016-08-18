namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_VisitorEntryLog
    {
        public long? ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long VisitorID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Come { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Go { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime BookingTime { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingCorrection { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LogId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string TerminalSerial { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(10)]
        public string ReaderID { get; set; }
    }
}
