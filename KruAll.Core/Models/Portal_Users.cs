namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portal_Users
    {
        public Portal_Users()
        {
            Portal_ProfileUSerMapping = new HashSet<Portal_ProfileUSerMapping>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PortalNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Salutation { get; set; }

        [Required]
        public string Firstname { get; set; }

        public string Surname { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string TelephoneNo { get; set; }

        public string TaxId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string StreetNo { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string Location { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public string StreetName { get; set; }

        [Required]
        public string Code { get; set; }

        public bool Isactive { get; set; }

        public bool FirstPassChanged { get; set; }

        public virtual ICollection<Portal_ProfileUSerMapping> Portal_ProfileUSerMapping { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
