namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA_TerminalGroups
    {
        public TA_TerminalGroups()
        {
            TA_PersonalGroupMapping = new HashSet<TA_PersonalGroupMapping>();
            TA_TerminalGroupMapping = new HashSet<TA_TerminalGroupMapping>();
        }

        public long ID { get; set; }

        public long GroupNr { get; set; }

        public string GroupDescription { get; set; }

        public virtual ICollection<TA_PersonalGroupMapping> TA_PersonalGroupMapping { get; set; }

        public virtual ICollection<TA_TerminalGroupMapping> TA_TerminalGroupMapping { get; set; }
    }
}
