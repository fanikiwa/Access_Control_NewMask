namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Terminal
    {
        public Terminal()
        {
            TerminalConfigs = new HashSet<TerminalConfig>();
        }

        public int ID { get; set; }

        public string TermType { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Connection { get; set; }

        public string Reader { get; set; }

        public string Access { get; set; }

        public string Image { get; set; }

        public string TermOEM { get; set; }

        public int? TermOEMID { get; set; }

        public string TerminalPage { get; set; }

        public virtual ICollection<TerminalConfig> TerminalConfigs { get; set; }

        public virtual TerminalOEM TerminalOEM { get; set; }
    }
}
