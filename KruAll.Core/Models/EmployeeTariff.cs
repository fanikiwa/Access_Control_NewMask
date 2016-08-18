namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeTariff")]
    public partial class EmployeeTariff
    {
        public long Id { get; set; }

        public int EmployeeId { get; set; }

        public long TariffId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Tariff Tariff { get; set; }
    }
}
