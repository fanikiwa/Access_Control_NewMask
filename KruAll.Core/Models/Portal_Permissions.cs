namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portal_Permissions
    {
        public Portal_Permissions()
        {
            Portal_PermissionMapping = new HashSet<Portal_PermissionMapping>();
        }

        public long ID { get; set; }

        [Required]
        public string Permission { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<Portal_PermissionMapping> Portal_PermissionMapping { get; set; }
    }
}
