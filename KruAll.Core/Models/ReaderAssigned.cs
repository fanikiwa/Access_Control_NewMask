namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReaderAssigned")]
    public partial class ReaderAssigned
    {
        public long ID { get; set; }

        public long BuildingPlanID { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        public int? RoomID { get; set; }

        public int DoorID { get; set; }

        public long TerminalID { get; set; }

        public long ReaderID { get; set; }

        public int ConnectionID { get; set; }

        public bool Assigned { get; set; }

        public bool? Active { get; set; }

        public bool? AccessProfileActive { get; set; }

        public bool? SwitchProfileActive { get; set; }

        public bool? ManualOpeningActive { get; set; }

        public int? PassBackNr { get; set; }

        public bool? TA_Come { get; set; }

        public bool? TA_Go { get; set; }

        public virtual BuildingPlan BuildingPlan { get; set; }

        public virtual TerminalReader TerminalReader { get; set; }
    }
}
