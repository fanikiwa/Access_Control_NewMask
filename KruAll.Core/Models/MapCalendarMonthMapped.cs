namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MapCalendarMonthMapped")]
    public partial class MapCalendarMonthMapped
    {
        public long Id { get; set; }

        public long MapCalendarId { get; set; }

        public int CalendarMonth { get; set; }

        public int Day1DailyProgramId { get; set; }

        public int Day2DailyProgramId { get; set; }

        public int Day3DailyProgramId { get; set; }

        public int Day4DailyProgramId { get; set; }

        public int Day5DailyProgramId { get; set; }

        public int Day6DailyProgramId { get; set; }

        public int Day7DailyProgramId { get; set; }

        public int Day8DailyProgramId { get; set; }

        public int Day9DailyProgramId { get; set; }

        public int Day10DailyProgramId { get; set; }

        public int Day11DailyProgramId { get; set; }

        public int Day12DailyProgramId { get; set; }

        public int Day13DailyProgramId { get; set; }

        public int Day14DailyProgramId { get; set; }

        public int Day15DailyProgramId { get; set; }

        public int Day16DailyProgramId { get; set; }

        public int Day17DailyProgramId { get; set; }

        public int Day18DailyProgramId { get; set; }

        public int Day19DailyProgramId { get; set; }

        public int Day20DailyProgramId { get; set; }

        public int Day21DailyProgramId { get; set; }

        public int Day22DailyProgramId { get; set; }

        public int Day23DailyProgramId { get; set; }

        public int Day24DailyProgramId { get; set; }

        public int Day25DailyProgramId { get; set; }

        public int Day26DailyProgramId { get; set; }

        public int Day27DailyProgramId { get; set; }

        public int Day28DailyProgramId { get; set; }

        public int Day29DailyProgramId { get; set; }

        public int Day30DailyProgramId { get; set; }

        public int Day31DailyProgramId { get; set; }

        public virtual MapCalendarMapped MapCalendarMapped { get; set; }
    }
}
