namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SwitchCalendarMonthMapped")]
    public partial class SwitchCalendarMonthMapped
    {
        public long Id { get; set; }

        public long SwitchCalendarId { get; set; }

        public int CalendarMonth { get; set; }

        public int Day1SwitchProfileId { get; set; }

        public int Day2SwitchProfileId { get; set; }

        public int Day3SwitchProfileId { get; set; }

        public int Day4SwitchProfileId { get; set; }

        public int Day5SwitchProfileId { get; set; }

        public int Day6SwitchProfileId { get; set; }

        public int Day7SwitchProfileId { get; set; }

        public int Day8SwitchProfileId { get; set; }

        public int Day9SwitchProfileId { get; set; }

        public int Day10SwitchProfileId { get; set; }

        public int Day11SwitchProfileId { get; set; }

        public int Day12SwitchProfileId { get; set; }

        public int Day13SwitchProfileId { get; set; }

        public int Day14SwitchProfileId { get; set; }

        public int Day15SwitchProfileId { get; set; }

        public int Day16SwitchProfileId { get; set; }

        public int Day17SwitchProfileId { get; set; }

        public int Day18SwitchProfileId { get; set; }

        public int Day19SwitchProfileId { get; set; }

        public int Day20SwitchProfileId { get; set; }

        public int Day21SwitchProfileId { get; set; }

        public int Day22SwitchProfileId { get; set; }

        public int Day23SwitchProfileId { get; set; }

        public int Day24SwitchProfileId { get; set; }

        public int Day25SwitchProfileId { get; set; }

        public int Day26SwitchProfileId { get; set; }

        public int Day27SwitchProfileId { get; set; }

        public int Day28SwitchProfileId { get; set; }

        public int Day29SwitchProfileId { get; set; }

        public int Day30SwitchProfileId { get; set; }

        public int Day31SwitchProfileId { get; set; }

        public virtual SwitchCalendarMapped SwitchCalendarMapped { get; set; }
    }
}
