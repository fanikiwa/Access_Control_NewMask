namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyAccountTime")]
    public partial class DailyAccountTime
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime WorkingDate { get; set; }

        public TimeSpan AccountHours { get; set; }

        public virtual Account Account { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
