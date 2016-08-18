namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_Archive
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string LastName { get; set; }

        public long? Card_Nr { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool CardActive { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        public long? PersType { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool Active { get; set; }

        public string Memo { get; set; }

        public bool? Imported { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "datetime2")]
        public DateTime ArchivedDate { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ArchivedBy { get; set; }
    }
}
