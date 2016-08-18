namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Absence
    {
        public Absence()
        {
            EmployeeAbsences = new HashSet<EmployeeAbsence>();
            Specialdays = new HashSet<Specialday>();
        }

        public int ID { get; set; }

        [StringLength(10)]
        public string AbsenceNo { get; set; }

        [StringLength(50)]
        public string Indicator { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public bool? BookingStatus { get; set; }

        public int? ForeColor { get; set; }

        public int? BackColor { get; set; }

        public double? Priority { get; set; }

        public double? Factor { get; set; }

        [Column(TypeName = "text")]
        public string DistComment { get; set; }

        public double? DistFactor { get; set; }

        public virtual ICollection<EmployeeAbsence> EmployeeAbsences { get; set; }

        public virtual ICollection<Specialday> Specialdays { get; set; }
    }
}
