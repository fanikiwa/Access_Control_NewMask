namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portal_Audit
    {
        public long usr_id { get; set; }

        [Required]
        [StringLength(100)]
        public string u_action { get; set; }

        public string comment { get; set; }

        public DateTime audit_date { get; set; }

        public long ID { get; set; }
    }
}
