namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            AccessGroupEmployees = new HashSet<AccessGroupEmployee>();
            Addresses = new HashSet<Address>();
            DailyAccountTimes = new HashSet<DailyAccountTime>();
            EmployeeAbsences = new HashSet<EmployeeAbsence>();
            EmployeeTariffs = new HashSet<EmployeeTariff>();
            WorkedHoursAccs = new HashSet<WorkedHoursAcc>();
        }

        public int ID { get; set; }

        public int EmpNumber { get; set; }

        [Required]
        public string PassportID { get; set; }

        public int Identification { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public bool Status { get; set; }

        public int? Identification2 { get; set; }

        public int? Identification3 { get; set; }

        public string MiFareID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? JoiningDate { get; set; }

        public int? CustomerID { get; set; }

        public int InfoId { get; set; }

        public virtual ICollection<AccessGroupEmployee> AccessGroupEmployees { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<DailyAccountTime> DailyAccountTimes { get; set; }

        public virtual EmployeeInfo EmployeeInfo { get; set; }

        public virtual ICollection<EmployeeAbsence> EmployeeAbsences { get; set; }

        public virtual ICollection<EmployeeTariff> EmployeeTariffs { get; set; }

        public virtual ICollection<WorkedHoursAcc> WorkedHoursAccs { get; set; }
    }
}
