namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorPlanGroup")]
    public partial class VisitorPlanGroup
    {
        public long Id { get; set; }

        public int AccessGroupNumber { get; set; }

        [Required]
        public string AccessGroupName { get; set; }

        public int AccessGroupType { get; set; }

        public string Memo { get; set; }
    }
}
