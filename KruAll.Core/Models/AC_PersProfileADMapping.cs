namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_PersProfileADMapping
    {
        public long ID { get; set; }

        public long PersNr { get; set; }

        public int? ProfileID { get; set; }

        [Required]
        public string AD_Username { get; set; }

        [Required]
        public string AD_Path { get; set; }

        [Required]
        public string AD_Controller { get; set; }

        public virtual AC_PermissionProfile AC_PermissionProfile { get; set; }
    }
}
