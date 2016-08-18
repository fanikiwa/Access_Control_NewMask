namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VwHolidayCalender")]
    public partial class VwHolidayCalender
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string TermType { get; set; }

        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanCalendarNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        public string HolidayPlanCalendarName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarMonth { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Day1ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Day2ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Day3ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Day4ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string Day5ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Day6ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string Day7ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(50)]
        public string Day8ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(50)]
        public string Day9ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(50)]
        public string Day10ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(50)]
        public string Day11ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(50)]
        public string Day12ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(50)]
        public string Day13ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(50)]
        public string Day14ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(50)]
        public string Day15ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(50)]
        public string Day16ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(50)]
        public string Day17ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(50)]
        public string Day18ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(50)]
        public string Day19ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(50)]
        public string Day20ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(50)]
        public string Day21ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(50)]
        public string Day22ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(50)]
        public string Day23ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(50)]
        public string Day24ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 29)]
        [StringLength(50)]
        public string Day25ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 30)]
        [StringLength(50)]
        public string Day26ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 31)]
        [StringLength(50)]
        public string Day27ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 32)]
        [StringLength(50)]
        public string Day28ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 33)]
        [StringLength(50)]
        public string Day29ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 34)]
        [StringLength(50)]
        public string Day30ProfileHolidayId { get; set; }

        [Key]
        [Column(Order = 35)]
        [StringLength(50)]
        public string Day31ProfileHolidayId { get; set; }
    }
}
