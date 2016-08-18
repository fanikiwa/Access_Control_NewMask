namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_SoftwareContractStatus
    {
        public int ID { get; set; }

        public string ContractStatusNr { get; set; }

        public string ContractStatus { get; set; }
    }
}
