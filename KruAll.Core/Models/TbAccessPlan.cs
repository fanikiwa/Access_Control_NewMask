namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TbAccessPlan")]
    public partial class TbAccessPlan
    {
        public TbAccessPlan()
        {
            MembersAccessPlanMappings = new HashSet<MembersAccessPlanMapping>();
            ReaderAccessPlans = new HashSet<ReaderAccessPlan>();
            TbAccessPlanMembersMappings = new HashSet<TbAccessPlanMembersMapping>();
            TbAccessPlanPersMappings = new HashSet<TbAccessPlanPersMapping>();
        }

        public long ID { get; set; }

        public long AccessPlanNr { get; set; }

        public string AccessPlanDescription { get; set; }

        public long AccessGroupID { get; set; }

        public long? AccessCalendarId { get; set; }

        public long? BuildingPlanID { get; set; }

        public long? HolidayPlanCalendarId { get; set; }

        public virtual AccessGroup AccessGroup { get; set; }

        public virtual BuildingPlan BuildingPlan { get; set; }

        public virtual HolidayPlanCalendar HolidayPlanCalendar { get; set; }

        public virtual ICollection<MembersAccessPlanMapping> MembersAccessPlanMappings { get; set; }

        public virtual ICollection<ReaderAccessPlan> ReaderAccessPlans { get; set; }

        public virtual ICollection<TbAccessPlanMembersMapping> TbAccessPlanMembersMappings { get; set; }

        public virtual ICollection<TbAccessPlanPersMapping> TbAccessPlanPersMappings { get; set; }
    }
}
