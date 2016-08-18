namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VisitorApplication
    {
        public VisitorApplication()
        {
            VisitorAdditionalInfoes = new HashSet<VisitorAdditionalInfo>();
            VisitorContacts = new HashSet<VisitorContact>();
        }

        public long ID { get; set; }

        public long ApplicationID { get; set; }

        public long VisitorNr { get; set; }

        public long PersonalID { get; set; }

        [Required]
        public string VisitorName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string IdentificationNr { get; set; }

        public string PassportNr { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateFiled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeFiled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EntryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EntryTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitTime { get; set; }

        public string Nationality { get; set; }

        public bool Active { get; set; }

        public long? VisitorType { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<VisitorAdditionalInfo> VisitorAdditionalInfoes { get; set; }

        public virtual ICollection<VisitorContact> VisitorContacts { get; set; }
    }
}
