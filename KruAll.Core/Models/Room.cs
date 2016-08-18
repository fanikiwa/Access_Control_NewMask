namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        public int ID { get; set; }

        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Occupant { get; set; }

        public int? DoorID { get; set; }
    }
}
