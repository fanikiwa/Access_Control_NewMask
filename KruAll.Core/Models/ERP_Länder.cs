namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_Länder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        [StringLength(10)]
        public string Kennzeichen { get; set; }

        [StringLength(50)]
        public string Kennzeichen2 { get; set; }

        [StringLength(50)]
        public string Kennzeichen3 { get; set; }

        public int? Steuer { get; set; }

        [StringLength(50)]
        public string Langtext { get; set; }

        [Column("Korrektur LKZ")]
        [StringLength(7)]
        public string Korrektur_LKZ { get; set; }

        public int? Angelsächsisch { get; set; }

        public double? ReisekostenÜber24h { get; set; }

        public double? ReisekostenÜber14h { get; set; }

        public double? ReisekostenÜber8h { get; set; }

        public double? ÜbernachtungsPauschale { get; set; }

        public double? Frühstück { get; set; }

        [StringLength(5)]
        public string Telefonvorwahl { get; set; }

        public int? Steuerschlüssel1 { get; set; }

        public int? Steuerschlüssel2 { get; set; }

        public int? Steuerschlüssel3 { get; set; }

        public double? ReisekostenUnter24h { get; set; }
    }
}
