namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorCompanyTb")]
    public partial class VisitorCompanyTb
    {
        public VisitorCompanyTb()
        {
            Visitors = new HashSet<Visitor>();
        }

        public long ID { get; set; }

        public long CompanyNr { get; set; }

        public string CompanyName { get; set; }

        public string ZipCode { get; set; }

        public string HouseNr { get; set; }

        public string Place { get; set; }

        public string Street { get; set; }

        public long? FederalState { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Memo { get; set; }

        public string PersFunction { get; set; }

        public string StreetNumber { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
