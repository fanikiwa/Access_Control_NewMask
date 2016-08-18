namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_BookingsReportTypes
    {
        public int ID { get; set; }

        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public int InBookings { get; set; }

        public int OutBookings { get; set; }
    }
}
