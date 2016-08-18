namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TbAccessPlanGroup")]
    public partial class TbAccessPlanGroup
    {
        public TbAccessPlanGroup()
        {
            AccessPlanGroupDoorMappings = new HashSet<AccessPlanGroupDoorMapping>();
            MemberAccessGroups = new HashSet<MemberAccessGroup>();
            Pers_AccessGroups = new HashSet<Pers_AccessGroups>();
        }

        public long ID { get; set; }

        public long AccessPlanGroupNr { get; set; }

        public string AccessPlanGroupName { get; set; }

        public long? BuildingPlanID { get; set; }

        public long? AccessCalendarId { get; set; }

        public long? HolidayPlanCalendarId { get; set; }

        public virtual AccessCalendar AccessCalendar { get; set; }

        public virtual ICollection<AccessPlanGroupDoorMapping> AccessPlanGroupDoorMappings { get; set; }

        public virtual BuildingPlan BuildingPlan { get; set; }

        public virtual HolidayPlanCalendar HolidayPlanCalendar { get; set; }

        public virtual ICollection<MemberAccessGroup> MemberAccessGroups { get; set; }

        public virtual ICollection<Pers_AccessGroups> Pers_AccessGroups { get; set; }
    }
}
