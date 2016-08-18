namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayPlanCalendar")]
    public partial class HolidayPlanCalendar
    {
        public HolidayPlanCalendar()
        {
            HolidayPlanAccessProfileMonths = new HashSet<HolidayPlanAccessProfileMonth>();
            HolidayPlanCalendarMonths = new HashSet<HolidayPlanCalendarMonth>();
            SwitchPlans = new HashSet<SwitchPlan>();
            TbAccessPlans = new HashSet<TbAccessPlan>();
            TbAccessPlanGroups = new HashSet<TbAccessPlanGroup>();
            TbVisitorPlans = new HashSet<TbVisitorPlan>();
        }

        public long Id { get; set; }

        public long HolidayCalenderId { get; set; }

        public int CalendarYear { get; set; }

        public long HolidayPlanCalendarNumber { get; set; }

        [Required]
        public string HolidayPlanCalendarName { get; set; }

        public string Memo { get; set; }

        public int? AllowAccess { get; set; }

        public virtual HolidayCalendar HolidayCalendar { get; set; }

        public virtual ICollection<HolidayPlanAccessProfileMonth> HolidayPlanAccessProfileMonths { get; set; }

        public virtual ICollection<HolidayPlanCalendarMonth> HolidayPlanCalendarMonths { get; set; }

        public virtual ICollection<SwitchPlan> SwitchPlans { get; set; }

        public virtual ICollection<TbAccessPlan> TbAccessPlans { get; set; }

        public virtual ICollection<TbAccessPlanGroup> TbAccessPlanGroups { get; set; }

        public virtual ICollection<TbVisitorPlan> TbVisitorPlans { get; set; }
    }
}
