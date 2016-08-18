namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalsNew")]
    public partial class TerminalsNew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long? TermOEMID { get; set; }

        public string TermType { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Connection { get; set; }

        public string Reader { get; set; }

        public string Access { get; set; }

        public string Image { get; set; }

        public string TermOEM { get; set; }
    }
}
