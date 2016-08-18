namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        public Account()
        {
            DailyAccountTimes = new HashSet<DailyAccountTime>();
            SurchargesAccountsMappings = new HashSet<SurchargesAccountsMapping>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }

        public string Name { get; set; }

        public string Abbr { get; set; }

        public bool? StandardAccount { get; set; }

        public string TransferAcc { get; set; }

        public string DisplayFormat { get; set; }

        public string BillingMacro { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BIllingDate { get; set; }

        [Column(TypeName = "text")]
        public string AccInfo { get; set; }

        public bool? Day_Booking_Mask { get; set; }

        public bool? Workflow { get; set; }

        public bool? Project_Management { get; set; }

        public bool? Main_Account { get; set; }

        public bool? Clearing_Account { get; set; }

        public virtual ICollection<DailyAccountTime> DailyAccountTimes { get; set; }

        public virtual ICollection<SurchargesAccountsMapping> SurchargesAccountsMappings { get; set; }
    }
}
