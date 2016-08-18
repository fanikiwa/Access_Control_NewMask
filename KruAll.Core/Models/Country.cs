namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        public int ID { get; set; }

        [Required]
        [StringLength(2)]
        public string Code { get; set; }

        public string DE_Name { get; set; }

        public string EN_Name { get; set; }
    }
}
