namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portal_PermissionProfile
    {
        public Portal_PermissionProfile()
        {
            Portal_PermissionMapping = new HashSet<Portal_PermissionMapping>();
            Portal_ProfileUSerMapping = new HashSet<Portal_ProfileUSerMapping>();
        }

        public long ID { get; set; }

        public int ProfileNr { get; set; }

        [Required]
        public string ProfileDescription { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<Portal_PermissionMapping> Portal_PermissionMapping { get; set; }

        public virtual ICollection<Portal_ProfileUSerMapping> Portal_ProfileUSerMapping { get; set; }
    }
}
