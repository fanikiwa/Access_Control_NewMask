namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_HolidayPlanAccessProfilesPerTerminal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermID { get; set; }

        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public string TermType { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanNumber { get; set; }

        public string AccessPlanDescription { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanNumber { get; set; }

        [Key]
        [Column(Order = 7)]
        public string HolidayPlanName { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarYear { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarMonth { get; set; }

        public long? AccessProfileID { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccessProfileNo { get; set; }

        [StringLength(30)]
        public string Memo { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool ProfilAktiv { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime MonFrom { get; set; }

        [Key]
        [Column(Order = 13)]
        public DateTime MonTo { get; set; }

        [Key]
        [Column(Order = 14)]
        public DateTime TueFrom { get; set; }

        [Key]
        [Column(Order = 15)]
        public DateTime TueTo { get; set; }

        [Key]
        [Column(Order = 16)]
        public DateTime WedFrom { get; set; }

        [Key]
        [Column(Order = 17)]
        public DateTime WedTo { get; set; }

        [Key]
        [Column(Order = 18)]
        public DateTime ThurFrom { get; set; }

        [Key]
        [Column(Order = 19)]
        public DateTime ThurTo { get; set; }

        [Key]
        [Column(Order = 20)]
        public DateTime FriFrom { get; set; }

        [Key]
        [Column(Order = 21)]
        public DateTime FriTo { get; set; }

        [Key]
        [Column(Order = 22)]
        public DateTime SatFrom { get; set; }

        [Key]
        [Column(Order = 23)]
        public DateTime SatTo { get; set; }

        [Key]
        [Column(Order = 24)]
        public DateTime SunFrom { get; set; }

        [Key]
        [Column(Order = 25)]
        public DateTime SunTo { get; set; }
    }
}
