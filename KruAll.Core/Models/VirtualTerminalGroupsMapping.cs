namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VirtualTerminalGroupsMapping")]
    public partial class VirtualTerminalGroupsMapping
    {
        public long ID { get; set; }

        public long GroupID { get; set; }

        public long TerminalID { get; set; }
    }
}
