namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_VisitorAccessLog
    {
        public long? ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FirstName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AccessEndData { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Come { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Go { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "datetime2")]
        public DateTime BookingTime { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingCorrection { get; set; }

        public string DynamicField1 { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LogID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(100)]
        public string TerminalSerial { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(10)]
        public string ReaderID { get; set; }

        public long? Card_Nr { get; set; }
    }
}
