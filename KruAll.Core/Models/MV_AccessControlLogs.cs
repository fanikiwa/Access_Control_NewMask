namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MV_AccessControlLogs
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Card_Nr { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime AccessTime { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        public int? RoomID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoorID { get; set; }

        public string LocationName { get; set; }

        public string DepartmentName { get; set; }

        [Key]
        [Column(Order = 5)]
        public string PlanDefinition { get; set; }
    }
}
