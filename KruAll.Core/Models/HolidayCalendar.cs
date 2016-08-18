namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayCalendar")]
    public partial class HolidayCalendar
    {
        public HolidayCalendar()
        {
            HolidayCalendarMonths = new HashSet<HolidayCalendarMonth>();
            HolidayPlanCalendars = new HashSet<HolidayPlanCalendar>();
        }

        public long Id { get; set; }

        public int CalendarYear { get; set; }

        public long HolidayCalendarNumber { get; set; }

        [Required]
        public string HolidayCalendarName { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<HolidayCalendarMonth> HolidayCalendarMonths { get; set; }

        public virtual ICollection<HolidayPlanCalendar> HolidayPlanCalendars { get; set; }
    }
}
