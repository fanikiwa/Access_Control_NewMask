namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_BookingsReportTitles
    {
        public int ID { get; set; }

        public int ReportID { get; set; }

        public int PositionNr { get; set; }

        [Required]
        public string PositionTitle { get; set; }

        public virtual TA_BookingsReport TA_BookingsReport { get; set; }
    }
}
