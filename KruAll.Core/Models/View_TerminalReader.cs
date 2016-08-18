namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_TerminalReader
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

        public int? Direction { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ReaderId { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool ReaderAssigned { get; set; }

        public int? Status { get; set; }

        public string ReaderInfo { get; set; }

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

        [Key]
        [Column(Order = 7)]
        public bool ReaderStatus { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool AccessProfileActive { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool SwitchProfileActive { get; set; }

        [Key]
        [Column(Order = 10)]
        public bool ManualOpeningActive { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BuildingPlanID { get; set; }

        public int? LocationID { get; set; }

        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        public int? RoomID { get; set; }

        public int? DoorID { get; set; }

        public int? TerminalTypeID { get; set; }

        public string IpAddress { get; set; }

        public int? Port { get; set; }

        public string ConnectionType { get; set; }

        public int? PassBackNr { get; set; }

        public int? Lock { get; set; }

        public string ReaderDescription { get; set; }

        public string ReaderType { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool TA_Come { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool TA_Go { get; set; }
    }
}
