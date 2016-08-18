namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kostenstellen")]
    public partial class Kostenstellen
    {
        [Key]
        public double Kos_Nr { get; set; }

        [StringLength(50)]
        public string Kos_Bezeichnung { get; set; }

        [Column(TypeName = "text")]
        public string Memo { get; set; }

        public DateTime? LastAccess { get; set; }

        public double? Kos_LohnK { get; set; }

        public double? Kos_FlexK { get; set; }

        public double? Kos_BetrK { get; set; }

        public bool? Kos_MaLohnK { get; set; }

        public int? Kos_Konto { get; set; }
    }
}
