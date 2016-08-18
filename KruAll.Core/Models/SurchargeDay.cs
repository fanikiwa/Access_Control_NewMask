namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SurchargeDay
    {
        public SurchargeDay()
        {
            Surcharges = new HashSet<Surcharge>();
        }

        public long ID { get; set; }

        public bool? Mon { get; set; }

        public bool? Tue { get; set; }

        public bool? Wed { get; set; }

        public bool? Thur { get; set; }

        public bool? Fri { get; set; }

        public bool? Sat { get; set; }

        public bool? Sun { get; set; }

        public bool? Holiday { get; set; }

        public virtual ICollection<Surcharge> Surcharges { get; set; }
    }
}
