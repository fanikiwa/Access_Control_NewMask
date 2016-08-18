namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SwitchProfile
    {
        public long ID { get; set; }

        public long Profile_Nr { get; set; }

        [Required]
        [StringLength(4)]
        public string Profile_Id { get; set; }

        public string Description { get; set; }

        public int? ProfileTimeMode { get; set; }

        public string Memo { get; set; }
    }
}
