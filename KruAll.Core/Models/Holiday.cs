namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Holiday")]
    public partial class Holiday
    {
        public long Id { get; set; }

        [Required]
        public string HolidayName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime HolidayDate { get; set; }

        public long? RegionID { get; set; }
    }
}
