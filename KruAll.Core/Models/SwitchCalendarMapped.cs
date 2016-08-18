namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SwitchCalendarMapped")]
    public partial class SwitchCalendarMapped
    {
        public SwitchCalendarMapped()
        {
            SwitchCalendarMonthMappeds = new HashSet<SwitchCalendarMonthMapped>();
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

        public virtual ICollection<SwitchCalendarMonthMapped> SwitchCalendarMonthMappeds { get; set; }
    }
}
