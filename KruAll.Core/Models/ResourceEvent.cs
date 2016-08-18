namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResourceEvent")]
    public partial class ResourceEvent
    {
        public long ID { get; set; }

        public int ResourceId { get; set; }

        public long? ShiftId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public long BreakId { get; set; }

        public virtual ShiftResource ShiftResource { get; set; }

        public virtual Shift Shift { get; set; }
    }
}
