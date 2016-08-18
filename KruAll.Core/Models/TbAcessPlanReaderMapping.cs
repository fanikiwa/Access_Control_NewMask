namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TbAcessPlanReaderMapping")]
    public partial class TbAcessPlanReaderMapping
    {
        public long ID { get; set; }

        public long BuildingID { get; set; }

        public long AcessPlanID { get; set; }
    }
}
