namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_TerminalFunction
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string AccountNo { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
    }
}
