namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingPair
    {
        public int ID { get; set; }

        public int? Duration { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? EmpID { get; set; }
    }
}
