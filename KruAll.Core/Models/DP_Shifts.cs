namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DP_Shifts
    {
        public DP_Shifts()
        {
            Shift_Breaks = new HashSet<Shift_Breaks>();
        }

        public int ID { get; set; }

        public int Shift_Nr { get; set; }

        public long DP_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CountFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CountTo { get; set; }

        public string CountDesc { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EvalFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EvalTo { get; set; }

        public string EvalDesc { get; set; }

        public virtual DailyProgram DailyProgram { get; set; }

        public virtual ICollection<Shift_Breaks> Shift_Breaks { get; set; }
    }
}
