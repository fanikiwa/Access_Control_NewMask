namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessCalendarMonth")]
    public partial class AccessCalendarMonth
    {
        public long ID { get; set; }

        public long AccessCalendarID { get; set; }

        public int AccessCalendarMonthNr { get; set; }

        public int Day1AccessProfileID { get; set; }

        public int Day2AccessProfileID { get; set; }

        public int Day3AccessProfileID { get; set; }

        public int Day4AccessProfileID { get; set; }

        public int Day5AccessProfileID { get; set; }

        public int Day6AccessProfileID { get; set; }

        public int Day7AccessProfileID { get; set; }

        public int Day8AccessProfileID { get; set; }

        public int Day9AccessProfileID { get; set; }

        public int Day10AccessProfileID { get; set; }

        public int Day11AccessProfileID { get; set; }

        public int Day12AccessProfileID { get; set; }

        public int Day13AccessProfileID { get; set; }

        public int Day14AccessProfileID { get; set; }

        public int Day15AccessProfileID { get; set; }

        public int Day16AccessProfileID { get; set; }

        public int Day17AccessProfileID { get; set; }

        public int Day18AccessProfileID { get; set; }

        public int Day19AccessProfileID { get; set; }

        public int Day20AccessProfileID { get; set; }

        public int Day21AccessProfileID { get; set; }

        public int Day22AccessProfileID { get; set; }

        public int Day23AccessProfileID { get; set; }

        public int Day24AccessProfileID { get; set; }

        public int Day25AccessProfileID { get; set; }

        public int Day26AccessProfileID { get; set; }

        public int Day27AccessProfileID { get; set; }

        public int Day28AccessProfileID { get; set; }

        public int Day29AccessProfileID { get; set; }

        public int Day30AccessProfileID { get; set; }

        public int Day31AccessProfileID { get; set; }

        public virtual AccessCalendar AccessCalendar { get; set; }
    }
}
