namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlannedCalendar")]
    public partial class PlannedCalendar
    {
        public PlannedCalendar()
        {
            DailyCalendars = new HashSet<DailyCalendar>();
            MonthlyCalendars = new HashSet<MonthlyCalendar>();
            PlannedCalendarTimes = new HashSet<PlannedCalendarTime>();
        }

        public long Id { get; set; }

        public int CalendarYear { get; set; }

        public int CalendarType { get; set; }

        public int CalendarNumber { get; set; }

        [StringLength(4)]
        public string CalendarIdNumber { get; set; }

        public string CalendarName { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        public string Memo { get; set; }

        public long? DailyCalendarId { get; set; }

        public long? MonthlyCalendarId { get; set; }

        public virtual ICollection<DailyCalendar> DailyCalendars { get; set; }

        public virtual DailyCalendar DailyCalendar { get; set; }

        public virtual ICollection<MonthlyCalendar> MonthlyCalendars { get; set; }

        public virtual MonthlyCalendar MonthlyCalendar { get; set; }

        public virtual ICollection<PlannedCalendarTime> PlannedCalendarTimes { get; set; }
    }
}
