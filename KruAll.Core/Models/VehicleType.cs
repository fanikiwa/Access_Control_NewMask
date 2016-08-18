namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleType
    {
        public VehicleType()
        {
            Pers_Vehicles = new HashSet<Pers_Vehicles>();
            Visitor_Vehicle = new HashSet<Visitor_Vehicle>();
            Visitors = new HashSet<Visitor>();
        }

        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Memo { get; set; }

        public int? VehicleNr { get; set; }

        public byte[] VehiclePhoto { get; set; }

        public virtual ICollection<Pers_Vehicles> Pers_Vehicles { get; set; }

        public virtual ICollection<Visitor_Vehicle> Visitor_Vehicle { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
