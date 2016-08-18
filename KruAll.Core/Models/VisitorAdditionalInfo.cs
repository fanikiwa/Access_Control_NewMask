namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorAdditionalInfo")]
    public partial class VisitorAdditionalInfo
    {
        public long ID { get; set; }

        public long VisitorID { get; set; }

        public string PhysicalAddress { get; set; }

        public string Street { get; set; }

        public string PlaceOfBirth { get; set; }

        public string MaritalStatus { get; set; }

        public string Profession { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleReg { get; set; }

        public virtual VisitorApplication VisitorApplication { get; set; }
    }
}
