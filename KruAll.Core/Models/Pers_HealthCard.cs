namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_HealthCard
    {
        public long ID { get; set; }

        public long? Pers_Nr { get; set; }

        public string BoxNumber { get; set; }

        public string CreatedIn { get; set; }

        public string ItemNumber { get; set; }

        public string SecurityNumber { get; set; }

        public string CardNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpiryDate { get; set; }

        public string Memo { get; set; }
    }
}
