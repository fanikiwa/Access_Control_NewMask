namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_BookingsReportAccounts
    {
        public int ID { get; set; }

        public int ReportID { get; set; }

        public int AccountID { get; set; }

        public int AccountPosition { get; set; }

        public bool DailySum { get; set; }

        public bool WeeklySum { get; set; }

        public bool MonthlySum { get; set; }

        public bool YearlySum { get; set; }

        public virtual TA_BookingsReport TA_BookingsReport { get; set; }
    }
}
