namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portal_ProfileUSerMapping
    {
        public long ID { get; set; }

        public long USerID { get; set; }

        public long ProfileID { get; set; }

        public virtual Portal_PermissionProfile Portal_PermissionProfile { get; set; }

        public virtual Portal_Users Portal_Users { get; set; }
    }
}
