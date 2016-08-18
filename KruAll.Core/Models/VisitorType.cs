namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorType")]
    public partial class VisitorType
    {
        public long ID { get; set; }

        public long TypeNr { get; set; }

        [Required]
        public string Name { get; set; }

        public string Memo { get; set; }
    }
}
