namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkedHoursAcc")]
    public partial class WorkedHoursAcc
    {
        public int ID { get; set; }

        public long AccountID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public decimal HoursWorked { get; set; }

        [Required]
        public string Account { get; set; }

        public int EmpID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
