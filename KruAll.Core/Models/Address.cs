namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public int ID { get; set; }

        public string Telephone { get; set; }

        public string MobilePhone { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string State { get; set; }

        public string Residence { get; set; }

        public string House_Nr { get; set; }

        public int? EmployeeID { get; set; }

        public int? ClientID { get; set; }

        public int? CustomerID { get; set; }

        public int? SupplierID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
