namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JC_Projects
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ProjectNr { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ProjectLeader { get; set; }

        [StringLength(50)]
        public string TelephoneNo { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? FreeFrom { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public DateTime? DeliveryReadyTime { get; set; }

        public string CustomerNo { get; set; }

        public string Company { get; set; }
    }
}
