namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BuildingPlan")]
    public partial class BuildingPlan
    {
        public BuildingPlan()
        {
            AccessPlanGroupDoorMappings = new HashSet<AccessPlanGroupDoorMapping>();
            ReaderAssigneds = new HashSet<ReaderAssigned>();
            SwitchPlans = new HashSet<SwitchPlan>();
            TbAccessPlans = new HashSet<TbAccessPlan>();
            TbAccessPlanGroups = new HashSet<TbAccessPlanGroup>();
            TbVisitorPlans = new HashSet<TbVisitorPlan>();
        }

        public long ID { get; set; }

        public int PlanNr { get; set; }

        [Required]
        public string PlanName { get; set; }

        [Required]
        public string PlanDefinition { get; set; }

        public string Memo { get; set; }

        public int LastNodeKey { get; set; }

        public virtual ICollection<AccessPlanGroupDoorMapping> AccessPlanGroupDoorMappings { get; set; }

        public virtual ICollection<ReaderAssigned> ReaderAssigneds { get; set; }

        public virtual ICollection<SwitchPlan> SwitchPlans { get; set; }

        public virtual ICollection<TbAccessPlan> TbAccessPlans { get; set; }

        public virtual ICollection<TbAccessPlanGroup> TbAccessPlanGroups { get; set; }

        public virtual ICollection<TbVisitorPlan> TbVisitorPlans { get; set; }
    }
}
