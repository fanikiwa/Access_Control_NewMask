namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalOEMNew")]
    public partial class TerminalOEMNew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? TerminalOEMNr { get; set; }

        public string TerminalOEMDescription { get; set; }

        public string Memo { get; set; }
    }
}
