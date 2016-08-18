namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_BookingsReportAbsences
    {
        public int ID { get; set; }

        public int ReportID { get; set; }

        public int AbsenceID { get; set; }

        public int AbsencePosition { get; set; }

        public virtual TA_BookingsReport TA_BookingsReport { get; set; }
    }
}
