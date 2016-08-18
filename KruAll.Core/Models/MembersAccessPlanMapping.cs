namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MembersAccessPlanMapping")]
    public partial class MembersAccessPlanMapping
    {
        public long ID { get; set; }

        public long? AccessPlan_Nr { get; set; }

        public long? MemberID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateTo { get; set; }

        public string AutomaticLogout { get; set; }

        public virtual MembersData MembersData { get; set; }

        public virtual TbAccessPlan TbAccessPlan { get; set; }
    }
}
