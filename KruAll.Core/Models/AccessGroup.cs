namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessGroup")]
    public partial class AccessGroup
    {
        public AccessGroup()
        {
            AccessProfileAccessGroupMappings = new HashSet<AccessProfileAccessGroupMapping>();
            AccessGroupEmployees = new HashSet<AccessGroupEmployee>();
            TbAccessPlans = new HashSet<TbAccessPlan>();
            ZuttritProfiles = new HashSet<ZuttritProfile>();
        }

        public long Id { get; set; }

        public int AccessGroupNumber { get; set; }

        [Required]
        public string AccessGroupName { get; set; }

        public int AccessGroupType { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<AccessProfileAccessGroupMapping> AccessProfileAccessGroupMappings { get; set; }

        public virtual ICollection<AccessGroupEmployee> AccessGroupEmployees { get; set; }

        public virtual ICollection<TbAccessPlan> TbAccessPlans { get; set; }

        public virtual ICollection<ZuttritProfile> ZuttritProfiles { get; set; }
    }
}
