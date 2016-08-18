namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_vwPersonelAccessPlan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string FullName { get; set; }

        public string Title { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool Active { get; set; }

        public long? PersType { get; set; }

        public string Memo { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        public long? Card_Nr { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool CardActive { get; set; }

        public bool? Imported { get; set; }

        public long? AccessPlanID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        public string Passport_Nr { get; set; }

        public string PhysicalAddress { get; set; }

        public string Street { get; set; }

        public string PlaceOfBirth { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public string Position { get; set; }

        public string Profession { get; set; }

        public string Nationality { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleReg { get; set; }

        public string CompanyName { get; set; }

        public string CompanyTel { get; set; }

        public string PrivateTel { get; set; }

        public string CompanyMobile { get; set; }

        public string PrivateMobile { get; set; }

        public string CompanyFax { get; set; }

        public string PrivateFax { get; set; }

        public string CompanyEmail { get; set; }

        public string PrivateEmail { get; set; }

        public string PostalAddress { get; set; }

        public string PostalCode { get; set; }

        public long? LocationID { get; set; }

        public string Location { get; set; }

        public long? DepartmentID { get; set; }

        public string Department { get; set; }

        public long? VisitorID { get; set; }

        public long? CostCenterID { get; set; }

        public string CostCenter { get; set; }

        public long? VehicleID { get; set; }

        public byte[] Pers_Passport { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanNr { get; set; }
    }
}
