namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Visitor
    {
        public Visitor()
        {
            VisitorAccessTimes = new HashSet<VisitorAccessTime>();
            VisitorTransponders = new HashSet<VisitorTransponder>();
        }

        public long ID { get; set; }

        public long VisitorID { get; set; }

        public long? PersonalID { get; set; }

        public string SurName { get; set; }

        public string Fullname { get; set; }

        public long? Company { get; set; }

        public string Street { get; set; }

        public string VisitorNr { get; set; }

        public string Location { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string PostalCode { get; set; }

        public int? VisitorType { get; set; }

        public string StreetNr { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateActivated { get; set; }

        public long? PersNr { get; set; }

        public int? CompanyTo { get; set; }

        public string VisitorPhoto { get; set; }

        public bool? CardActive { get; set; }

        public string VehicleRegNr { get; set; }

        public long? VisitorVehicleType { get; set; }

        public string VisitReason { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public virtual ICollection<VisitorAccessTime> VisitorAccessTimes { get; set; }

        public virtual VisitorCompanyTb VisitorCompanyTb { get; set; }

        public virtual ICollection<VisitorTransponder> VisitorTransponders { get; set; }
    }
}
