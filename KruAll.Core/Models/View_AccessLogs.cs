namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_AccessLogs
    {
        public long? ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pers_Type { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_Nr { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Card_Nr { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string ClientName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AccessEndData { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Come { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TA_Go { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "datetime2")]
        public DateTime BookingTime { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingCorrection { get; set; }

        public string DynamicField1 { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LogID { get; set; }

        public string PlanDefinition { get; set; }

        public long? BuildingPlanID { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        public int? RoomID { get; set; }

        public int? DoorID { get; set; }
    }
}
