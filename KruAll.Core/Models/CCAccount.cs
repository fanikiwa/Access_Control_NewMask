namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CCAccount
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }

        public int? EmpCost { get; set; }

        public int? FlexCost { get; set; }

        public int? OperatingCost { get; set; }
    }
}
