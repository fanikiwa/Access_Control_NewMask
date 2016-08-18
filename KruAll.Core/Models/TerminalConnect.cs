namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalConnect")]
    public partial class TerminalConnect
    {
        public TerminalConnect()
        {
            TerminalConfigs = new HashSet<TerminalConfig>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Connection { get; set; }

        [Required]
        public string IPAddress { get; set; }

        [Required]
        public string IPPort { get; set; }

        public bool ActiveTerminal { get; set; }

        public bool PersnoPIN { get; set; }

        public bool FPRead { get; set; }

        public bool APPosting { get; set; }

        public bool TAPPosting { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        public virtual ICollection<TerminalConfig> TerminalConfigs { get; set; }
    }
}
