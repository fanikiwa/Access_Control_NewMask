namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_PermissionProfile
    {
        public AC_PermissionProfile()
        {
            AC_PermissionMapping = new HashSet<AC_PermissionMapping>();
            AC_PersProfileADMapping = new HashSet<AC_PersProfileADMapping>();
            AC_PersProfileMapping = new HashSet<AC_PersProfileMapping>();
        }

        public int ID { get; set; }

        public int ProfileNr { get; set; }

        [Required]
        public string ProfileDescription { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<AC_PermissionMapping> AC_PermissionMapping { get; set; }

        public virtual ICollection<AC_PersProfileADMapping> AC_PersProfileADMapping { get; set; }

        public virtual ICollection<AC_PersProfileMapping> AC_PersProfileMapping { get; set; }
    }
}
