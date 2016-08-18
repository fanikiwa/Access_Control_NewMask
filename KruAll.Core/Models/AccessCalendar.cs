namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessCalendar")]
    public partial class AccessCalendar
    {
        public AccessCalendar()
        {
            AccessCalendarMonths = new HashSet<AccessCalendarMonth>();
            TbAccessPlanGroups = new HashSet<TbAccessPlanGroup>();
            TbVisitorPlans = new HashSet<TbVisitorPlan>();
        }

        public long ID { get; set; }

        public int Calendar_Nr { get; set; }

        public string Calendar_Name { get; set; }

        public long AccessProfileID { get; set; }

        public string Memo { get; set; }

        public bool CheckMon { get; set; }

        public bool CheckTue { get; set; }

        public bool CheckWed { get; set; }

        public bool CheckThur { get; set; }

        public bool CheckFri { get; set; }

        public bool CheckSat { get; set; }

        public bool CheckSun { get; set; }

        [Column(TypeName = "date")]
        public DateTime CalendarDate { get; set; }

        public virtual ICollection<AccessCalendarMonth> AccessCalendarMonths { get; set; }

        public virtual ICollection<TbAccessPlanGroup> TbAccessPlanGroups { get; set; }

        public virtual ICollection<TbVisitorPlan> TbVisitorPlans { get; set; }
    }
}
