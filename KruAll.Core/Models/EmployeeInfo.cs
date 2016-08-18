namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeInfo")]
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            Employees = new HashSet<Employee>();
        }

        public int ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DoB { get; set; }

        public string PlaceOfBirth { get; set; }

        public string DrivingLicense { get; set; }

        public string BankAccNo { get; set; }

        public string Bank { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public int? Children { get; set; }

        public string Nationality { get; set; }

        public string Denomination { get; set; }

        [StringLength(50)]
        public string SSN { get; set; }

        public string FinanceAuthority { get; set; }

        public string TaxClass { get; set; }

        public string HealthInsurance { get; set; }

        public double? HINumber { get; set; }

        public string Job { get; set; }

        public double? NoOfHours { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ContPeriodFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ContPeriodTo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ResignedOn { get; set; }

        public long? CostCenterId { get; set; }

        public long DepartmentId { get; set; }

        public long LocationId { get; set; }

        public string Street { get; set; }

        public string CarType { get; set; }

        public string CarReg { get; set; }

        public string CompanyName { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public string Memo { get; set; }

        public string Position { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyMobile { get; set; }

        public string PersonalPhone { get; set; }

        public string PersonalMobile { get; set; }

        public string CompanyEmail { get; set; }

        public string PersonalEmail { get; set; }

        public virtual CostCenter CostCenter { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
