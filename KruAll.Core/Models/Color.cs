namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Color
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ColorName { get; set; }

        [Required]
        [StringLength(50)]
        public string ColorCode { get; set; }

        public string ColorComment { get; set; }
    }
}
