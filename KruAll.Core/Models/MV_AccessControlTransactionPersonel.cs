namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MV_AccessControlTransactionPersonel
    {
        [Key]
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime AccessTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Card_Nr { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Name { get; set; }

        public string LocationName { get; set; }

        public string DepartmentName { get; set; }

        public string SerialNumber { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string ReaderID { get; set; }
    }
}
