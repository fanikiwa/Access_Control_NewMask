namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status_Static
    {
        public int ID { get; set; }

        public int? StatusNr { get; set; }

        [StringLength(50)]
        public string StatusName { get; set; }

        public DateTime? LastAccess { get; set; }
    }
}
