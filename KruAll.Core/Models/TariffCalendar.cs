namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TariffCalendar")]
    public partial class TariffCalendar
    {
        public long Id { get; set; }

        public long TariffId { get; set; }

        public int CalendarYear { get; set; }

        public int CalendarMonth { get; set; }

        public long Day1TariffId { get; set; }

        public long Day2TariffId { get; set; }

        public long Day3TariffId { get; set; }

        public long Day4TariffId { get; set; }

        public long Day5TariffId { get; set; }

        public long Day6TariffId { get; set; }

        public long Day7TariffId { get; set; }

        public long Day8TariffId { get; set; }

        public long Day9TariffId { get; set; }

        public long Day10TariffId { get; set; }

        public long Day11TariffId { get; set; }

        public long Day12TariffId { get; set; }

        public long Day13TariffId { get; set; }

        public long Day14TariffId { get; set; }

        public long Day15TariffId { get; set; }

        public long Day16TariffId { get; set; }

        public long Day17TariffId { get; set; }

        public long Day18TariffId { get; set; }

        public long Day19TariffId { get; set; }

        public long Day20TariffId { get; set; }

        public long Day21TariffId { get; set; }

        public long Day22TariffId { get; set; }

        public long Day23TariffId { get; set; }

        public long Day24TariffId { get; set; }

        public long Day25TariffId { get; set; }

        public long Day26TariffId { get; set; }

        public long Day27TariffId { get; set; }

        public long Day28TariffId { get; set; }

        public long Day29TariffId { get; set; }

        public long Day30TariffId { get; set; }

        public long Day31TariffId { get; set; }

        public virtual Tariff Tariff { get; set; }
    }
}
