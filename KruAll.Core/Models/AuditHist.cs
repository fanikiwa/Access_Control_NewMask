namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuditHist")]
    public partial class AuditHist
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

        public long? ID { get; set; }
    }
}
