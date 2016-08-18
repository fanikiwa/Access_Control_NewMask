namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VwPersonnelData")]
    public partial class VwPersonnelData
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

        [Column(TypeName = "datetime2")]
        public DateTime? EntryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Active { get; set; }

        public long? PersType { get; set; }

        public string Memo { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool CardActive { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool Imported { get; set; }

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

        public long? DepartmentID { get; set; }

        public long? CostCenterID { get; set; }

        public long? VehicleID { get; set; }

        public long? LocationID { get; set; }

        public string LocationName { get; set; }

        public long? Location_Nr { get; set; }

        public string DepartmentName { get; set; }

        public long? Department_Nr { get; set; }

        public string CostCenterName { get; set; }

        public long? CostCenter_Nr { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PersonnelNr_string { get; set; }

        public long? IdentificationNr_string { get; set; }

        public string PersNr_Fullname { get; set; }

        [StringLength(50)]
        public string EyeColor { get; set; }

        [StringLength(50)]
        public string Height { get; set; }

        public string Expr1 { get; set; }

        public string Salutation { get; set; }

        public string Additonal { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Since { get; set; }

        public string Bankname { get; set; }

        public string AccountOwner { get; set; }

        public string BankCode { get; set; }

        public string AccountNo { get; set; }

        public string BIC { get; set; }

        public string IBAN { get; set; }

        public string DriversLicense { get; set; }

        public string Children { get; set; }

        public string TaxOfficee { get; set; }

        public string TaxClass { get; set; }

        public string HealthInsuarance { get; set; }

        public string HealInsuaranceNo { get; set; }

        public string PensionInsuarance { get; set; }

        public string SozVerzNo { get; set; }

        public string Contract { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EmployedFrom { get; set; }

        public string LearnedOccupation { get; set; }

        public string EmployedAs { get; set; }

        public string EmploymentType { get; set; }

        public string ResidencePermit { get; set; }

        public string AuthorisedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string NoOfHours { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndOfContract { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EliminatedOn { get; set; }

        public string Reason { get; set; }

        public string CertificateOfEmployment { get; set; }

        public long? ClientID { get; set; }

        public string ClientName { get; set; }

        public string StreetNr { get; set; }

        public string Expr2 { get; set; }

        public string Pers_Passport { get; set; }

        public int? ActiveCardType { get; set; }

        public long? Card_Nr { get; set; }

        public string DynamicField1 { get; set; }

        public long? Client_Nr { get; set; }
    }
}
