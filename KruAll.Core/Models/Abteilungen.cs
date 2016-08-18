namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Abteilungen")]
    public partial class Abteilungen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Abt_Nr { get; set; }

        [StringLength(50)]
        public string Abt_Bezeichnung { get; set; }

        [Column(TypeName = "text")]
        public string Memo { get; set; }

        public DateTime? LastAccess { get; set; }
    }
}
