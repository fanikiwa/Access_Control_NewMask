namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShiftResourceBac")]
    public partial class ShiftResourceBac
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IsDefaultLoaded { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
    }
}
