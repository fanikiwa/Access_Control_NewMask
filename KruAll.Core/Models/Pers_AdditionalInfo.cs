namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_AdditionalInfo
    {
        public long ID { get; set; }

        public long Pers_Nr { get; set; }

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

        [StringLength(50)]
        public string EyeColor { get; set; }

        [StringLength(50)]
        public string Height { get; set; }

        public string PostalCode { get; set; }

        public string Salutation { get; set; }

        public string Additonal { get; set; }

        public string Bankname { get; set; }

        public string AccountOwner { get; set; }

        public string BankCode { get; set; }

        public string AccountNo { get; set; }

        public string BIC { get; set; }

        public string IBAN { get; set; }

        public string DriversLicense { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Since { get; set; }

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

        public string StreetNr { get; set; }
    }
}
