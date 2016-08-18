namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VirtualPersonalGroupsMapping")]
    public partial class VirtualPersonalGroupsMapping
    {
        public long ID { get; set; }

        public long? VtermID { get; set; }

        public long? Pers_Nr { get; set; }

        public virtual VirtualTerminalGroup VirtualTerminalGroup { get; set; }
    }
}
