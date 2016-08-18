namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Werke")]
    public partial class Werke
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int W_Nr { get; set; }

        [StringLength(50)]
        public string W_Bezeichnung { get; set; }

        [StringLength(50)]
        public string W_Str { get; set; }

        public int? W_Plz { get; set; }

        [StringLength(50)]
        public string W_Ort { get; set; }

        [Column(TypeName = "text")]
        public string W_Memo { get; set; }

        public DateTime? LastAccess { get; set; }

        [StringLength(50)]
        public string W_Bundesland { get; set; }
    }
}
