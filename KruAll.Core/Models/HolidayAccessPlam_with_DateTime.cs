namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HolidayAccessPlam_with_DateTime
    {
        [Column(TypeName = "date")]
        public DateTime? Datum { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessProfileID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanCalendarId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ZPID { get; set; }

        public long? ZPGroupID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string ZPAccessProfileID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZPAccessProfileNo { get; set; }

        [Key]
        [Column(Order = 6)]
        public string ZPAccessDescription { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HPCId { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HPCHolidayCalenderId { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HPCHolidayPlanCalendarNumber { get; set; }

        [Key]
        [Column(Order = 10)]
        public string HPCHolidayPlanCalendarName { get; set; }
    }
}
