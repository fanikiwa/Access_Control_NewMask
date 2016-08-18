namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VirtualTerminalGroup
    {
        public VirtualTerminalGroup()
        {
            VirtualPersonalGroupsMappings = new HashSet<VirtualPersonalGroupsMapping>();
        }

        public long ID { get; set; }

        public long GroupNr { get; set; }

        public string Description { get; set; }

        public virtual ICollection<VirtualPersonalGroupsMapping> VirtualPersonalGroupsMappings { get; set; }
    }
}
