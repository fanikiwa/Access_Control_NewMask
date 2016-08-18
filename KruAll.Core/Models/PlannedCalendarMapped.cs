namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlannedCalendarMapped")]
    public partial class PlannedCalendarMapped
    {
        public PlannedCalendarMapped()
        {
            DailyCalendarMappeds = new HashSet<DailyCalendarMapped>();
            MonthlyCalendarMappeds = new HashSet<MonthlyCalendarMapped>();
            PlannedCalendarTimeMappeds = new HashSet<PlannedCalendarTimeMapped>();
            Tariffs = new HashSet<Tariff>();
        }

        public long Id { get; set; }

        public int CalendarYear { get; set; }

        [Required]
        [StringLength(10)]
        public string CalendarType { get; set; }

        public int CalendarNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string CalendarIdNumber { get; set; }

        [Required]
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

        public virtual ICollection<DailyCalendarMapped> DailyCalendarMappeds { get; set; }

        public virtual DailyCalendarMapped DailyCalendarMapped { get; set; }

        public virtual ICollection<MonthlyCalendarMapped> MonthlyCalendarMappeds { get; set; }

        public virtual MonthlyCalendarMapped MonthlyCalendarMapped { get; set; }

        public virtual ICollection<PlannedCalendarTimeMapped> PlannedCalendarTimeMappeds { get; set; }

        public virtual ICollection<Tariff> Tariffs { get; set; }
    }
}
