namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Permissions
    {
        public AC_Permissions()
        {
            AC_PermissionMapping = new HashSet<AC_PermissionMapping>();
        }

        public int ID { get; set; }

        [Required]
        public string Permission { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<AC_PermissionMapping> AC_PermissionMapping { get; set; }
    }
}
