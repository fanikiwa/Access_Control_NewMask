namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RawBooking
    {
        public int ID { get; set; }

        public int EmpID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        public string EmpIDDate { get; set; }

        public int? TermID { get; set; }

        [Required]
        public string TermSlot { get; set; }

        public string TimeSlot { get; set; }
    }
}
