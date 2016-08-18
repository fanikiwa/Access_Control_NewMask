namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MapCalendarMapped")]
    public partial class MapCalendarMapped
    {
        public MapCalendarMapped()
        {
            MapCalendarMonthMappeds = new HashSet<MapCalendarMonthMapped>();
            Tariffs = new HashSet<Tariff>();
        }

        public long Id { get; set; }

        public int CalendarYear { get; set; }

        public int MapCalendarNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string MapCalendarIdNumber { get; set; }

        [Required]
        public string MapCalendarName { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<MapCalendarMonthMapped> MapCalendarMonthMappeds { get; set; }

        public virtual ICollection<Tariff> Tariffs { get; set; }
    }
}
