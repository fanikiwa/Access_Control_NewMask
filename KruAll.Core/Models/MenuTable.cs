namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuTable")]
    public partial class MenuTable
    {
        [Key]
        public int AutoID { get; set; }

        public int TreeLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Parent { get; set; }

        [Required]
        [StringLength(50)]
        public string Root { get; set; }

        public int TreeDisplayPosition { get; set; }

        [StringLength(50)]
        public string Version { get; set; }
    }
}
