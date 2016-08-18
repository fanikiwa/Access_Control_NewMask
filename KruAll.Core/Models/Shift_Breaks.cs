namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shift_Breaks
    {
        public int ID { get; set; }

        public int Shift_ID { get; set; }

        public long Break_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeTo { get; set; }

        public virtual Break Break { get; set; }

        public virtual DP_Shifts DP_Shifts { get; set; }
    }
}
