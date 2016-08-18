namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalConnectionType")]
    public partial class TerminalConnectionType
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ConnectionType { get; set; }
    }
}
