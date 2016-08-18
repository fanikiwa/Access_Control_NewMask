namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MapCalendar")]
    public partial class MapCalendar
    {
        public MapCalendar()
        {
            MapCalendarMonths = new HashSet<MapCalendarMonth>();
        }

        public long ID { get; set; }

        public int CalendarYear { get; set; }

        public int MapCalendarNumber { get; set; }

        [StringLength(4)]
        public string MapCalendarIdNumber { get; set; }

        [Required]
        public string MapCalendarName { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<MapCalendarMonth> MapCalendarMonths { get; set; }
    }
}
