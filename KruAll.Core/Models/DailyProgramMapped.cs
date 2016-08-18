namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyProgramMapped")]
    public partial class DailyProgramMapped
    {
        public DailyProgramMapped()
        {
            ResourceEventMappeds = new HashSet<ResourceEventMapped>();
        }

        public int ID { get; set; }

        public long DP_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DP_Nr { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime HourFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime HourTo { get; set; }

        public virtual ICollection<ResourceEventMapped> ResourceEventMappeds { get; set; }
    }
}
