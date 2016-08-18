namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        public Personal()
        {
            PersonnelTariffs = new HashSet<PersonnelTariff>();
            Visitors = new HashSet<Visitor>();
        }

        public long ID { get; set; }

        public long Pers_Nr { get; set; }

        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public long? Card_Nr { get; set; }

        public bool CardActive { get; set; }

        public int? ActiveCardType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EntryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        public long? PersType { get; set; }

        public bool Active { get; set; }

        public string Memo { get; set; }

        public bool Imported { get; set; }

        public string StreetNr { get; set; }

        public string PostalCode { get; set; }

        public bool DeductionIsActive { get; set; }

        public virtual Pers_Type Pers_Type { get; set; }

        public virtual ICollection<PersonnelTariff> PersonnelTariffs { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
