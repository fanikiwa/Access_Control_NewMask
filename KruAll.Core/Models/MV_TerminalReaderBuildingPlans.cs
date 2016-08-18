namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MV_TerminalReaderBuildingPlans
    {
        public string SerialNumber { get; set; }

        [StringLength(8000)]
        public string TerminalReaderID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ModelReaderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReaderID { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoorID { get; set; }

        public int? RoomID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string PlanDefinition { get; set; }
    }
}
