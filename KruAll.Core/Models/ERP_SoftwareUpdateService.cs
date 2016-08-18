namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_SoftwareUpdateService
    {
        public long ID { get; set; }

        public long ModuleNumber { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? InstallationDate { get; set; }

        public string PurchaseVersion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdate { get; set; }

        public string LastVersionAfterUpdate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdateAfterBuying { get; set; }

        public bool? SoftwareUpdateContract { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? SoftwareContractFrom { get; set; }

        public int? ContractStatusNr { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndOfContract { get; set; }

        public bool? UpdateInfoByMail { get; set; }
    }
}
