namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ReaderBuildingPlan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReaderID { get; set; }

        public int? TermID { get; set; }

        public string Description { get; set; }

        public int? DoorID { get; set; }

        public int? RoomID { get; set; }

        public int? FloorID { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public long? BuildingPlanID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string PlanDefinition { get; set; }
    }
}
