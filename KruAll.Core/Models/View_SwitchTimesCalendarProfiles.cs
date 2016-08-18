namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_SwitchTimesCalendarProfiles
    {
        public long? SwitchCalendarID { get; set; }

        public DateTime? CalendarDate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileId { get; set; }
    }
}
