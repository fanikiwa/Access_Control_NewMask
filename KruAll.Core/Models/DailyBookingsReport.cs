namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DailyBookingsReport
    {
        public int ID { get; set; }

        public int InfoNumber { get; set; }

        [StringLength(50)]
        public string InfoName { get; set; }

        [StringLength(50)]
        public string Accounts { get; set; }

        public int? BookingsCount { get; set; }

        public int? ReportPosition { get; set; }
    }
}
