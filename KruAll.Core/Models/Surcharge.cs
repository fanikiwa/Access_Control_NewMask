namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Surcharge
    {
        public Surcharge()
        {
            SurchargesAccountsMappings = new HashSet<SurchargesAccountsMapping>();
        }

        public long ID { get; set; }

        public long Surchage_Nr { get; set; }

        [Required]
        public string Name { get; set; }

        public string SurchargeFactor { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeTo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DurationFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DurationTo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExtraDurationFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExtraDurationTo { get; set; }

        public string Memo { get; set; }

        public long? WeekDays_ID { get; set; }

        public long? DailyProgramID { get; set; }

        public string OverTimeStart { get; set; }

        public string OverTimeEnd { get; set; }

        public virtual DailyProgram DailyProgram { get; set; }

        public virtual SurchargeDay SurchargeDay { get; set; }

        public virtual ICollection<SurchargesAccountsMapping> SurchargesAccountsMappings { get; set; }
    }
}
