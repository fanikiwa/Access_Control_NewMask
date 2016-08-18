namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_PersProfileMapping
    {
        public int ID { get; set; }

        public int Pers_Nr { get; set; }

        public int ProfileID { get; set; }

        public virtual AC_PermissionProfile AC_PermissionProfile { get; set; }
    }
}
