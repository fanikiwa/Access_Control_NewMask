namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specialday
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        public int? Absence_Reason { get; set; }

        public int? LocationID { get; set; }

        public virtual Absence Absence { get; set; }
    }
}
