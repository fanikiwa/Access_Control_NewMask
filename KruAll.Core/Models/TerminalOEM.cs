namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalOEM")]
    public partial class TerminalOEM
    {
        public TerminalOEM()
        {
            TerminalConfigs = new HashSet<TerminalConfig>();
            Terminals = new HashSet<Terminal>();
        }

        public int ID { get; set; }

        public int? TermOEMId { get; set; }

        public string TermOEMDesc { get; set; }

        public virtual ICollection<TerminalConfig> TerminalConfigs { get; set; }

        public virtual ICollection<Terminal> Terminals { get; set; }
    }
}
