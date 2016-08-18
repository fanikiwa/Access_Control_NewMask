namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BreaksType")]
    public partial class BreaksType
    {
        public long ID { get; set; }

        public long TpyeNr { get; set; }

        public string Abbriviation { get; set; }

        public string Description { get; set; }
    }
}
