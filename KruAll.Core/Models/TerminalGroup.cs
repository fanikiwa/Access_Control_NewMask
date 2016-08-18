namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalGroup
    {
        public TerminalGroup()
        {
            TerminalGroupMappings = new HashSet<TerminalGroupMapping>();
        }

        public long ID { get; set; }

        public long GroupNr { get; set; }

        public string GroupDescription { get; set; }

        public virtual ICollection<TerminalGroupMapping> TerminalGroupMappings { get; set; }
    }
}
