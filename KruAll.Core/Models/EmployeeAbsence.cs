namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeAbsence")]
    public partial class EmployeeAbsence
    {
        public long Id { get; set; }

        public int EmployeeId { get; set; }

        public int AbsenceId { get; set; }

        public DateTime AbsenceDate { get; set; }

        public virtual Absence Absence { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
