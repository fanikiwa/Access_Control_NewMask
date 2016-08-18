namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_PortalUserProfile
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileNr { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ProfileDescription { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string EmailAddress { get; set; }
    }
}
