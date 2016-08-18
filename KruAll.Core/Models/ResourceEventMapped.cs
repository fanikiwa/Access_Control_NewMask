namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResourceEventMapped")]
    public partial class ResourceEventMapped
    {
        public int ID { get; set; }

        public int ResourceId { get; set; }

        public int DailyProgramId { get; set; }

        public long? ShiftId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Description { get; set; }

        public int? BreakId { get; set; }

        public virtual DailyProgramMapped DailyProgramMapped { get; set; }

        public virtual ShiftResource ShiftResource { get; set; }

        public virtual Shift Shift { get; set; }
    }
}
