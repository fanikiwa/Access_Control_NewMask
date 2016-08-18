namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SurchargesAccountsMapping")]
    public partial class SurchargesAccountsMapping
    {
        public long ID { get; set; }

        public long SurchargeID { get; set; }

        public long AccountID { get; set; }

        public bool Active { get; set; }

        public int AccountPosition { get; set; }

        public virtual Account Account { get; set; }

        public virtual Surcharge Surcharge { get; set; }
    }
}
