namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FingerprintPassword")]
    public partial class FingerprintPassword
    {
        public long ID { get; set; }

        public int? PersNr { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
