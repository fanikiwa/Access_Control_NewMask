namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portal_PermissionMapping
    {
        public long ID { get; set; }

        public long PermissionKey { get; set; }

        public long PermissionType { get; set; }

        public long ProfileID { get; set; }

        public virtual Portal_PermissionProfile Portal_PermissionProfile { get; set; }

        public virtual Portal_Permissions Portal_Permissions { get; set; }
    }
}
