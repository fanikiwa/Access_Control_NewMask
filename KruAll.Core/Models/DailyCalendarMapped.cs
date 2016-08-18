namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyCalendarMapped")]
    public partial class DailyCalendarMapped
    {
        public DailyCalendarMapped()
        {
            PlannedCalendarMappeds = new HashSet<PlannedCalendarMapped>();
        }

        public long Id { get; set; }

        public long CalendarId { get; set; }

        public TimeSpan Monday { get; set; }

        public TimeSpan Tuesday { get; set; }

        public TimeSpan Wednesday { get; set; }

        public TimeSpan Thursday { get; set; }

        public TimeSpan Friday { get; set; }

        public TimeSpan Saturday { get; set; }

        public TimeSpan Sunday { get; set; }

        public virtual PlannedCalendarMapped PlannedCalendarMapped { get; set; }

        public virtual ICollection<PlannedCalendarMapped> PlannedCalendarMappeds { get; set; }
    }
}
