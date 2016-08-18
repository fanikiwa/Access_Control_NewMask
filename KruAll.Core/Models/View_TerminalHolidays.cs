namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_TerminalHolidays
    {
        public string TerminalSerialNumber { get; set; }

        public string TerminalDescription { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime HolidayDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessProfileID { get; set; }
    }
}
