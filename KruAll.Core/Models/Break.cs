namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Break
    {
        public Break()
        {
            Shift_Breaks = new HashSet<Shift_Breaks>();
        }

        public long ID { get; set; }

        public long Break_Nr { get; set; }

        [Required]
        public string Name { get; set; }

        public long Type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeTo { get; set; }

        public string Memo { get; set; }

        [StringLength(10)]
        public string MinDiff { get; set; }

        [Required]
        public string MinimumDeduction { get; set; }

        [Required]
        public string StartAfter { get; set; }

        [Required]
        public string Beginning1stBreakFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FirstDeduction { get; set; }

        [Required]
        public string Beginning2ndBreakFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SecondDeduction { get; set; }

        [Required]
        public string BeginningThirdBreakFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ThirdDeduction { get; set; }

        [Required]
        public string MaximumDeduction { get; set; }

        public virtual ICollection<Shift_Breaks> Shift_Breaks { get; set; }
    }
}
