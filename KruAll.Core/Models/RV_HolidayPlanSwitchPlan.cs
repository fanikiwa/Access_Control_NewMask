namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_HolidayPlanSwitchPlan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SwitchPlanNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanCalendarNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        public string HolidayPlanCalendarName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarMonth { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2)]
        public string Day1ProfileName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2)]
        public string Day2ProfileName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(2)]
        public string Day3ProfileName { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(2)]
        public string Day4ProfileName { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(2)]
        public string Day5ProfileName { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(2)]
        public string Day6ProfileName { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(2)]
        public string Day7ProfileName { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(2)]
        public string Day8ProfileName { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(2)]
        public string Day9ProfileName { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(2)]
        public string Day10ProfileName { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(2)]
        public string Day11ProfileName { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(2)]
        public string Day12ProfileName { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(2)]
        public string Day13ProfileName { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(2)]
        public string Day14ProfileName { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(2)]
        public string Day15ProfileName { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(2)]
        public string Day16ProfileName { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(2)]
        public string Day17ProfileName { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(2)]
        public string Day18ProfileName { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(2)]
        public string Day19ProfileName { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(2)]
        public string Day20ProfileName { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(2)]
        public string Day21ProfileName { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(2)]
        public string Day22ProfileName { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(2)]
        public string Day23ProfileName { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(2)]
        public string Day24ProfileName { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(2)]
        public string Day25ProfileName { get; set; }

        [Key]
        [Column(Order = 29)]
        [StringLength(2)]
        public string Day26ProfileName { get; set; }

        [Key]
        [Column(Order = 30)]
        [StringLength(2)]
        public string Day27ProfileName { get; set; }

        [Key]
        [Column(Order = 31)]
        [StringLength(2)]
        public string Day28ProfileName { get; set; }

        [Key]
        [Column(Order = 32)]
        [StringLength(2)]
        public string Day29ProfileName { get; set; }

        [Key]
        [Column(Order = 33)]
        [StringLength(2)]
        public string Day30ProfileName { get; set; }

        [Key]
        [Column(Order = 34)]
        [StringLength(2)]
        public string Day31ProfileName { get; set; }
    }
}
