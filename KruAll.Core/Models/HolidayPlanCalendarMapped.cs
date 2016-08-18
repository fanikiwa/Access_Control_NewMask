namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayPlanCalendarMapped")]
    public partial class HolidayPlanCalendarMapped
    {
        public HolidayPlanCalendarMapped()
        {
            HolidayPlanCalendarMonthMappeds = new HashSet<HolidayPlanCalendarMonthMapped>();
        }

        public long Id { get; set; }

        public int CalendarYear { get; set; }

        public long HolidayPlanCalendarNumber { get; set; }

        [Required]
        public string HolidayPlanCalendarName { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<HolidayPlanCalendarMonthMapped> HolidayPlanCalendarMonthMappeds { get; set; }
    }
}
