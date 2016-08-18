namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BreaksMapped")]
    public partial class BreaksMapped
    {
        public int ID { get; set; }

        public int DP_Nr { get; set; }

        public int Break_Nr { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeTo { get; set; }

        [Column(TypeName = "text")]
        public string Memo { get; set; }

        [StringLength(10)]
        public string MinDiff { get; set; }

        public int Break_ID { get; set; }
    }
}
