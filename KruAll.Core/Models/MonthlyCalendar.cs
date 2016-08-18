namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonthlyCalendar")]
    public partial class MonthlyCalendar
    {
        public MonthlyCalendar()
        {
            PlannedCalendars = new HashSet<PlannedCalendar>();
        }

        public long Id { get; set; }

        public long CalendarId { get; set; }

        public double January { get; set; }

        public double February { get; set; }

        public double March { get; set; }

        public double April { get; set; }

        public double May { get; set; }

        public double June { get; set; }

        public double July { get; set; }

        public double August { get; set; }

        public double September { get; set; }

        public double October { get; set; }

        public double November { get; set; }

        public double December { get; set; }

        public virtual PlannedCalendar PlannedCalendar { get; set; }

        public virtual ICollection<PlannedCalendar> PlannedCalendars { get; set; }
    }
}
