namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TbAccessPlanMembersMapping")]
    public partial class TbAccessPlanMembersMapping
    {
        public long ID { get; set; }

        public long AccessPlan_ID { get; set; }

        public long MemberID { get; set; }

        public virtual MembersData MembersData { get; set; }

        public virtual TbAccessPlan TbAccessPlan { get; set; }
    }
}
