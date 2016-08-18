namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyBooking")]
    public partial class DailyBooking
    {
        public long Id { get; set; }

        public long RawBookingId { get; set; }

        public long EmployeeId { get; set; }

        public int EmployeeNumber { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime DateProcessed { get; set; }

        public int BookingStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Terminal { get; set; }

        [StringLength(400)]
        public string Memo { get; set; }

        public bool? ProcessingStatus { get; set; }
    }
}
