namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DailyProgram
    {
        public DailyProgram()
        {
            DP_Shifts = new HashSet<DP_Shifts>();
            Shifts = new HashSet<Shift>();
            Surcharges = new HashSet<Surcharge>();
        }

        public long ID { get; set; }

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

        public virtual ICollection<DP_Shifts> DP_Shifts { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }

        public virtual ICollection<Surcharge> Surcharges { get; set; }
    }
}
