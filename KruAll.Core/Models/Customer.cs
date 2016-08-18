namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string EmployeeID { get; set; }
    }
}
