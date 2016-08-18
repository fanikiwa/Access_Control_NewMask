namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_TeminalInformation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TerminalID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string TermType { get; set; }

        public string TerminalDescription { get; set; }

        public string ReaderDescription { get; set; }

        public int? Direction { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ReaderId { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool ReaderAssigned { get; set; }

        public int? Status { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReaderNo { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(200)]
        public string unique_id { get; set; }

        public int? DoorID { get; set; }

        public long? AssignedReaderTerminalID { get; set; }

        public long? AssignedReaderReaderID { get; set; }

        public int? ConnectionID { get; set; }

        public long? BuildingPlanID { get; set; }

        public int? RelayTime { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        public int? RoomID { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool AccessProfileActive { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool SwitchProfileActive { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool ManualOpeningActive { get; set; }

        public string ReaderType { get; set; }

        public int? IPPort { get; set; }

        public string IpAddress { get; set; }

        public string Connection { get; set; }

        public int? TerminalTypeID { get; set; }
    }
}
