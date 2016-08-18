namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_BookingsReport
    {
        public TA_BookingsReport()
        {
            TA_BookingsReportAbsences = new HashSet<TA_BookingsReportAbsences>();
            TA_BookingsReportAccounts = new HashSet<TA_BookingsReportAccounts>();
            TA_BookingsReportTitles = new HashSet<TA_BookingsReportTitles>();
        }

        public int ID { get; set; }

        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public int BookingsReportTypeNr { get; set; }

        public int DailyBookingsTabPosition { get; set; }

        public int Orientation { get; set; }

        public int AbsencePosition { get; set; }

        public int TpPosition { get; set; }

        public int ShiftPosition { get; set; }

        public virtual ICollection<TA_BookingsReportAbsences> TA_BookingsReportAbsences { get; set; }

        public virtual ICollection<TA_BookingsReportAccounts> TA_BookingsReportAccounts { get; set; }

        public virtual ICollection<TA_BookingsReportTitles> TA_BookingsReportTitles { get; set; }
    }
}
