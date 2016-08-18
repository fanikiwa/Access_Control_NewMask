namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReaderVisitorPlan")]
    public partial class ReaderVisitorPlan
    {
        public long ID { get; set; }

        public long? ReaderId { get; set; }

        public long? VisitorPlanId { get; set; }

        public bool? AccessPlanReaderStatus { get; set; }

        public long? BuildingPlanID { get; set; }

        public int? DoorID { get; set; }

        public virtual TbVisitorPlan TbVisitorPlan { get; set; }

        public virtual TerminalReader TerminalReader { get; set; }
    }
}
