namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayCalendarMonth")]
    public partial class HolidayCalendarMonth
    {
        public long Id { get; set; }

        public long HolidayCalendarId { get; set; }

        public int CalendarMonth { get; set; }

        public long Day1HolidayId { get; set; }

        public long Day2HolidayId { get; set; }

        public long Day3HolidayId { get; set; }

        public long Day4HolidayId { get; set; }

        public long Day5HolidayId { get; set; }

        public long Day6HolidayId { get; set; }

        public long Day7HolidayId { get; set; }

        public long Day8HolidayId { get; set; }

        public long Day9HolidayId { get; set; }

        public long Day10HolidayId { get; set; }

        public long Day11HolidayId { get; set; }

        public long Day12HolidayId { get; set; }

        public long Day13HolidayId { get; set; }

        public long Day14HolidayId { get; set; }

        public long Day15HolidayId { get; set; }

        public long Day16HolidayId { get; set; }

        public long Day17HolidayId { get; set; }

        public long Day18HolidayId { get; set; }

        public long Day19HolidayId { get; set; }

        public long Day20HolidayId { get; set; }

        public long Day21HolidayId { get; set; }

        public long Day22HolidayId { get; set; }

        public long Day23HolidayId { get; set; }

        public long Day24HolidayId { get; set; }

        public long Day25HolidayId { get; set; }

        public long Day26HolidayId { get; set; }

        public long Day27HolidayId { get; set; }

        public long Day28HolidayId { get; set; }

        public long Day29HolidayId { get; set; }

        public long Day30HolidayId { get; set; }

        public long Day31HolidayId { get; set; }

        public virtual HolidayCalendar HolidayCalendar { get; set; }
    }
}
