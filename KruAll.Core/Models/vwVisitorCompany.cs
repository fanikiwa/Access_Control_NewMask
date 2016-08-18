namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwVisitorCompany")]
    public partial class vwVisitorCompany
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long VisitorID { get; set; }

        public long? PersonalID { get; set; }

        public string SurName { get; set; }

        public string FullName { get; set; }

        public string Company { get; set; }

        public string CompanyStreet { get; set; }

        public string CompanyStreetNr { get; set; }

        public string CompanyPostalCode { get; set; }

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

        public string VisitorPhoto { get; set; }

        public bool? CardActive { get; set; }

        public string VehicleRegNr { get; set; }

        public long? VisitorVehicleType { get; set; }

        public string VisitReason { get; set; }
    }
}
