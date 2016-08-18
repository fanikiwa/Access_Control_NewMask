namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JC_Activities
    {
        public int ID { get; set; }

        [Required]
        public string ActivityNo { get; set; }

        [Required]
        public string ActivityDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityContent { get; set; }

        [Required]
        [StringLength(50)]
        public string FlexCosts { get; set; }

        [Required]
        [StringLength(50)]
        public string RunningCosts { get; set; }

        [Required]
        [StringLength(50)]
        public string Surcharge { get; set; }

        [Required]
        [StringLength(50)]
        public string Profit { get; set; }

        [StringLength(50)]
        public string FlexCostPercent { get; set; }

        [StringLength(50)]
        public string RunningCostPercent { get; set; }

        [StringLength(50)]
        public string TotalCost { get; set; }

        [StringLength(50)]
        public string SurchargePercent { get; set; }

        [StringLength(50)]
        public string ProfitPercent { get; set; }

        public int CurrencyID { get; set; }

        public string Comment { get; set; }

        public virtual JC_Currency JC_Currency { get; set; }
    }
}
