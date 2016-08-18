namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeePhotos")]
    public partial class EmployeePhoto
    {
        public int ID { get; set; }

        public byte[] Photo { get; set; }

        public int? EmployeeID { get; set; }
    }
}
