namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JC_Currency
    {
        public JC_Currency()
        {
            JC_Activities = new HashSet<JC_Activities>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencySymbol { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(100)]
        public string CurrencyName { get; set; }

        public virtual ICollection<JC_Activities> JC_Activities { get; set; }
    }
}
