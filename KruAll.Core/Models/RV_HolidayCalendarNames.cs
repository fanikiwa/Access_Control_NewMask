namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_HolidayCalendarNames
    {
        [StringLength(7)]
        public string HolidayCalendarID { get; set; }

        [Key]
        [StringLength(2)]
        public string Name { get; set; }
    }
}
