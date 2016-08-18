namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VisitorContact
    {
        public long ID { get; set; }

        public long VisitorID { get; set; }

        public string Company { get; set; }

        public string CompanyTel { get; set; }

        public string PrivateTel { get; set; }

        public string CompanyMobile { get; set; }

        public string PrivateMobile { get; set; }

        public string CompanyFax { get; set; }

        public string PrivateFax { get; set; }

        public string CompanyEmail { get; set; }

        public string PrivateEmail { get; set; }

        public string PostalAddress { get; set; }

        public string PostalCode { get; set; }

        public string ZipCode { get; set; }

        public string Zip { get; set; }

        public virtual VisitorApplication VisitorApplication { get; set; }
    }
}
