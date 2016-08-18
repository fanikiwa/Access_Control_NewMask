namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_TerminalGroupMapping
    {
        public long ID { get; set; }

        public long? TerminalGroupId { get; set; }

        public long? TerminalInstanceId { get; set; }

        public long? Pers_Nr { get; set; }

        public virtual TA_TerminalGroups TA_TerminalGroups { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }
    }
}
