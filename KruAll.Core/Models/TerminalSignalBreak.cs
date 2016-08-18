namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalSignalBreak
    {
        public long ID { get; set; }

        public long? TerminalID { get; set; }

        public int? SignalBreakNr { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Monday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Tuesday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Wednesday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Thursday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Friday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Saturday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Sunday { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FreeDay { get; set; }

        public bool? Status { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }
    }
}
