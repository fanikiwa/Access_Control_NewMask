namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_PermissionMapping
    {
        public int ID { get; set; }

        public int PermissionKey { get; set; }

        public int PermissionType { get; set; }

        public int ProfileId { get; set; }

        public virtual AC_PermissionProfile AC_PermissionProfile { get; set; }

        public virtual AC_Permissions AC_Permissions { get; set; }
    }
}
