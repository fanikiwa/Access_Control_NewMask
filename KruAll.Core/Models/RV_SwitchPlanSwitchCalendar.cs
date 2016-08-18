namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_SwitchPlanSwitchCalendar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SwitchPlanNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        public string SwitchPlanName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SwitchCalendarNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string SwitchCalendarName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarMonth { get; set; }

        [StringLength(4)]
        public string Day1SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day2SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day3SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day4SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day5SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day6SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day7SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day8SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day9SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day10SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day11SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day12SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day13SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day14SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day15SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day16SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day17SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day18SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day19SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day20SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day21SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day22SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day23SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day24SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day25SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day26SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day27SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day28SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day29SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day30SwitchProfileID { get; set; }

        [StringLength(4)]
        public string Day31SwitchProfileID { get; set; }
    }
}
