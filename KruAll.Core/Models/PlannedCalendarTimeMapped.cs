namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlannedCalendarTimeMapped")]
    public partial class PlannedCalendarTimeMapped
    {
        public long Id { get; set; }

        public long CalendarId { get; set; }

        public int CalendarMonth { get; set; }

        public TimeSpan Day1Hours { get; set; }

        public TimeSpan Day2Hours { get; set; }

        public TimeSpan Day3Hours { get; set; }

        public TimeSpan Day4Hours { get; set; }

        public TimeSpan Day5Hours { get; set; }

        public TimeSpan Day6Hours { get; set; }

        public TimeSpan Day7Hours { get; set; }

        public TimeSpan Day8Hours { get; set; }

        public TimeSpan Day9Hours { get; set; }

        public TimeSpan Day10Hours { get; set; }

        public TimeSpan Day11Hours { get; set; }

        public TimeSpan Day12Hours { get; set; }

        public TimeSpan Day13Hours { get; set; }

        public TimeSpan Day14Hours { get; set; }

        public TimeSpan Day15Hours { get; set; }

        public TimeSpan Day16Hours { get; set; }

        public TimeSpan Day17Hours { get; set; }

        public TimeSpan Day18Hours { get; set; }

        public TimeSpan Day19Hours { get; set; }

        public TimeSpan Day20Hours { get; set; }

        public TimeSpan Day21Hours { get; set; }

        public TimeSpan Day22Hours { get; set; }

        public TimeSpan Day23Hours { get; set; }

        public TimeSpan Day24Hours { get; set; }

        public TimeSpan Day25Hours { get; set; }

        public TimeSpan Day26Hours { get; set; }

        public TimeSpan Day27Hours { get; set; }

        public TimeSpan Day28Hours { get; set; }

        public TimeSpan Day29Hours { get; set; }

        public TimeSpan Day30Hours { get; set; }

        public TimeSpan Day31Hours { get; set; }

        public virtual PlannedCalendarMapped PlannedCalendarMapped { get; set; }
    }
}
