namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessGroupEmployee")]
    public partial class AccessGroupEmployee
    {
        public long Id { get; set; }

        public long AccessGroupId { get; set; }

        public int EmployeeId { get; set; }

        public virtual AccessGroup AccessGroup { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
