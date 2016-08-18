namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SurchargeMapped")]
    public partial class SurchargeMapped
    {
        public SurchargeMapped()
        {
            Tariffs = new HashSet<Tariff>();
        }

        public int ID { get; set; }

        public int Surchage_Nr { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeTo { get; set; }

        [Column(TypeName = "text")]
        public string Memo { get; set; }

        public virtual ICollection<Tariff> Tariffs { get; set; }
    }
}
