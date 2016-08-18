namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TbVisitorPlan")]
    public partial class TbVisitorPlan
    {
        public TbVisitorPlan()
        {
            ReaderVisitorPlans = new HashSet<ReaderVisitorPlan>();
            VisitorAccessTimes = new HashSet<VisitorAccessTime>();
        }

        public long ID { get; set; }

        public long VisitorPlanNr { get; set; }

        public string VisitorPlanDescription { get; set; }

        public long? AccessCalendarId { get; set; }

        public long? BuildingPlanID { get; set; }

        public long? HolidayPlanCalendarId { get; set; }

        public virtual AccessCalendar AccessCalendar { get; set; }

        public virtual BuildingPlan BuildingPlan { get; set; }

        public virtual HolidayPlanCalendar HolidayPlanCalendar { get; set; }

        public virtual ICollection<ReaderVisitorPlan> ReaderVisitorPlans { get; set; }

        public virtual ICollection<VisitorAccessTime> VisitorAccessTimes { get; set; }
    }
}
