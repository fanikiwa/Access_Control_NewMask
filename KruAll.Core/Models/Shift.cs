namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shift
    {
        public Shift()
        {
            ResourceEvents = new HashSet<ResourceEvent>();
            ResourceEventMappeds = new HashSet<ResourceEventMapped>();
        }

        public long ID { get; set; }

        public string ShiftName { get; set; }

        public string ShiftDescription { get; set; }

        public long DailyProgramId { get; set; }

        public virtual DailyProgram DailyProgram { get; set; }

        public virtual ICollection<ResourceEvent> ResourceEvents { get; set; }

        public virtual ICollection<ResourceEventMapped> ResourceEventMappeds { get; set; }
    }
}
