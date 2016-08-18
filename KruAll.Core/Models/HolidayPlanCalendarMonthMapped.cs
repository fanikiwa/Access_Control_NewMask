namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayPlanCalendarMonthMapped")]
    public partial class HolidayPlanCalendarMonthMapped
    {
        public long Id { get; set; }

        public long HolidayPlanCalendarId { get; set; }

        public int CalendarMonth { get; set; }

        [Required]
        [StringLength(50)]
        public string Day1ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day2ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day3ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day4ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day5ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day6ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day7ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day8ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day9ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day10ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day11ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day12ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day13ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day14ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day15ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day16ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day17ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day18ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day19ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day20ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day21ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day22ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day23ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day24ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day25ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day26ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day27ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day28ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day29ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day30ProfileHolidayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Day31ProfileHolidayId { get; set; }

        public virtual HolidayPlanCalendarMapped HolidayPlanCalendarMapped { get; set; }
    }
}
