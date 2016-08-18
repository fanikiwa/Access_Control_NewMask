namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_AccessProfilesPerTerminal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BuildingPlanID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TerminalID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccesCalenderNo { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string AccessProfileID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccessProfileNo { get; set; }

        [Key]
        [Column(Order = 7)]
        public string AccessDescription { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool ProfilAktiv { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime MonFrom { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime MonTo { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime TueFrom { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime TueTo { get; set; }

        [Key]
        [Column(Order = 13)]
        public DateTime WedFrom { get; set; }

        [Key]
        [Column(Order = 14)]
        public DateTime WedTo { get; set; }

        [Key]
        [Column(Order = 15)]
        public DateTime ThurFrom { get; set; }

        [Key]
        [Column(Order = 16)]
        public DateTime ThurTo { get; set; }

        [Key]
        [Column(Order = 17)]
        public DateTime FriFrom { get; set; }

        [Key]
        [Column(Order = 18)]
        public DateTime FriTo { get; set; }

        [Key]
        [Column(Order = 19)]
        public DateTime SatFrom { get; set; }

        [Key]
        [Column(Order = 20)]
        public DateTime SatTo { get; set; }

        [Key]
        [Column(Order = 21)]
        public DateTime SunFrom { get; set; }

        [Key]
        [Column(Order = 22)]
        public DateTime SunTo { get; set; }
    }
}
