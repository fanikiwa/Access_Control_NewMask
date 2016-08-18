namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShiftResource")]
    public partial class ShiftResource
    {
        public ShiftResource()
        {
            ResourceEvents = new HashSet<ResourceEvent>();
            ResourceEventMappeds = new HashSet<ResourceEventMapped>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsDefaultLoaded { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public int OrderCase { get; set; }

        public virtual ICollection<ResourceEvent> ResourceEvents { get; set; }

        public virtual ICollection<ResourceEventMapped> ResourceEventMappeds { get; set; }
    }
}
