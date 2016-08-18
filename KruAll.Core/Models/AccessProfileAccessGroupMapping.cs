namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessProfileAccessGroupMapping")]
    public partial class AccessProfileAccessGroupMapping
    {
        public long ID { get; set; }

        public long AccessProfileID { get; set; }

        public long AccessGroupID { get; set; }

        public virtual AccessGroup AccessGroup { get; set; }

        public virtual ZuttritProfile ZuttritProfile { get; set; }
    }
}
