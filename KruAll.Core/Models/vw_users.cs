namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_users
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long usr_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string u_action { get; set; }

        public string comment { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime audit_date { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Salutation { get; set; }

        [Key]
        [Column(Order = 5)]
        public string Firstname { get; set; }

        public string Surname { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string TelephoneNo { get; set; }

        public string TaxId { get; set; }

        [Key]
        [Column(Order = 6)]
        public string CompanyName { get; set; }

        [Key]
        [Column(Order = 7)]
        public string StreetNo { get; set; }

        [Key]
        [Column(Order = 8)]
        public string PostalCode { get; set; }

        public string Location { get; set; }

        [Key]
        [Column(Order = 9)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 12)]
        public string Password { get; set; }

        public string StreetName { get; set; }

        [Key]
        [Column(Order = 13)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool Isactive { get; set; }

        [Key]
        [Column(Order = 15)]
        public bool FirstPassChanged { get; set; }

        public string FullName { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PortalNo { get; set; }
    }
}
