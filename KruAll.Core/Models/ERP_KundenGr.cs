namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_KundenGr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GrCode { get; set; }

        public int? GrIndex { get; set; }

        public int? GrLevel { get; set; }

        [StringLength(40)]
        public string GrName { get; set; }

        [StringLength(4000)]
        public string Info { get; set; }
    }
}
