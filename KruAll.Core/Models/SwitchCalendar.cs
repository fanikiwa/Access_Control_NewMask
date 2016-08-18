namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SwitchCalendar")]
    public partial class SwitchCalendar
    {
        public SwitchCalendar()
        {
            SwitchCalendarMonths = new HashSet<SwitchCalendarMonth>();
            SwitchPlans = new HashSet<SwitchPlan>();
        }

        public long Id { get; set; }

        public int CalendarYear { get; set; }

        [Required]
        [StringLength(50)]
        public string SwitchCalendarNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string SwitchCalendarName { get; set; }

        [StringLength(400)]
        public string Memo { get; set; }

        public virtual ICollection<SwitchCalendarMonth> SwitchCalendarMonths { get; set; }

        public virtual ICollection<SwitchPlan> SwitchPlans { get; set; }
    }
}
