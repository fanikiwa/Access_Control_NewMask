namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CellPhoneMaster")]
    public partial class CellPhoneMaster
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string CellID { get; set; }

        public string Name { get; set; }

        public int? MobileNumber { get; set; }

        public string MobileIdentification { get; set; }

        public int? EmployeeID { get; set; }

        public string Username { get; set; }

        public int? DepartmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OutputOn { get; set; }

        public string ContractingParty { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Inception { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ContractEnd { get; set; }

        public string LeaseTerm { get; set; }

        public string Tariff { get; set; }

        public string TariffPricePerMonth { get; set; }

        public bool? TimeTracking { get; set; }

        public bool? CostCenter { get; set; }

        public bool? CostandFlexCostCenter { get; set; }

        public bool? ProjectTracking { get; set; }

        public bool? Customer { get; set; }

        public bool? Project { get; set; }

        public bool? IsOrder { get; set; }
    }
}
