namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalReadersStatic")]
    public partial class TerminalReadersStatic
    {
        public TerminalReadersStatic()
        {
            TerminalReaders = new HashSet<TerminalReader>();
        }

        public int ID { get; set; }

        public string ReaderType { get; set; }

        public string Description { get; set; }

        public string Installation { get; set; }

        public string Image { get; set; }

        public int? ReaderIdentifier { get; set; }

        public virtual ICollection<TerminalReader> TerminalReaders { get; set; }
    }
}
