namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayPlanAccessProfileMonth")]
    public partial class HolidayPlanAccessProfileMonth
    {
        public long ID { get; set; }

        public long HolidayPlanCalendarId { get; set; }

        public int CalendarMonth { get; set; }

        public long Day1AccessProfileId { get; set; }

        public long Day2AccessProfileId { get; set; }

        public long Day3AccessProfileId { get; set; }

        public long Day4AccessProfileId { get; set; }

        public long Day5AccessProfileId { get; set; }

        public long Day6AccessProfileId { get; set; }

        public long Day7AccessProfileId { get; set; }

        public long Day8AccessProfileId { get; set; }

        public long Day9AccessProfileId { get; set; }

        public long Day10AccessProfileId { get; set; }

        public long Day11AccessProfileId { get; set; }

        public long Day12AccessProfileId { get; set; }

        public long Day13AccessProfileId { get; set; }

        public long Day14AccessProfileId { get; set; }

        public long Day15AccessProfileId { get; set; }

        public long Day16AccessProfileId { get; set; }

        public long Day17AccessProfileId { get; set; }

        public long Day18AccessProfileId { get; set; }

        public long Day19AccessProfileId { get; set; }

        public long Day20AccessProfileId { get; set; }

        public long Day21AccessProfileId { get; set; }

        public long Day22AccessProfileId { get; set; }

        public long Day23AccessProfileId { get; set; }

        public long Day24AccessProfileId { get; set; }

        public long Day25AccessProfileId { get; set; }

        public long Day26AccessProfileId { get; set; }

        public long Day27AccessProfileId { get; set; }

        public long Day28AccessProfileId { get; set; }

        public long Day29AccessProfileId { get; set; }

        public long Day30AccessProfileId { get; set; }

        public long Day31AccessProfileId { get; set; }

        public virtual HolidayPlanCalendar HolidayPlanCalendar { get; set; }
    }
}
