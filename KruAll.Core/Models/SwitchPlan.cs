namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SwitchPlan")]
    public partial class SwitchPlan
    {
        public long Id { get; set; }

        public long SwitchPlanNumber { get; set; }

        [Required]
        public string SwitchPlanName { get; set; }

        public long? SwitchCalendarId { get; set; }

        public long? BuidingPlanID { get; set; }

        public long? HolidayPlanCalendarId { get; set; }

        public virtual BuildingPlan BuildingPlan { get; set; }

        public virtual HolidayPlanCalendar HolidayPlanCalendar { get; set; }

        public virtual SwitchCalendar SwitchCalendar { get; set; }
    }
}
