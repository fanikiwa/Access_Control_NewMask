namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReaderAccessPlan")]
    public partial class ReaderAccessPlan
    {
        public long ID { get; set; }

        public long? ReaderId { get; set; }

        public long? AccessPlanId { get; set; }

        public bool? AccessPlanReaderStatus { get; set; }

        public long? BuildingPlanID { get; set; }

        public int? DoorID { get; set; }

        public virtual TbAccessPlan TbAccessPlan { get; set; }

        public virtual TerminalReader TerminalReader { get; set; }
    }
}
