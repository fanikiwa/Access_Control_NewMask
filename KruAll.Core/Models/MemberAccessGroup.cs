namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberAccessGroup
    {
        public long ID { get; set; }

        public long MemberID { get; set; }

        public long GroupID { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        public virtual TbAccessPlanGroup TbAccessPlanGroup { get; set; }

        public virtual MembersData MembersData { get; set; }
    }
}
