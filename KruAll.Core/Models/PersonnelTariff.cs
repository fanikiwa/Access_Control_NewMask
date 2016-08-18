namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelTariff")]
    public partial class PersonnelTariff
    {
        public long ID { get; set; }

        public long PersonnelID { get; set; }

        public long TariffID { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual Tariff Tariff { get; set; }
    }
}
