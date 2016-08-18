namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ERPSoftwareUpdateService
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

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

        [Column(TypeName = "datetime2")]
        public DateTime? EndOfContract { get; set; }

        public bool? UpdateInfoByMail { get; set; }

        public string ModuleName { get; set; }

        public int? CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ModuleNumber { get; set; }

        public int? ContractStatusNr { get; set; }
    }
}
