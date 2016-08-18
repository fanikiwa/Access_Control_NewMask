namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_AccessPlanAccessCalendar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanNr { get; set; }

        public string AccessPlanDescription { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Calendar_Nr { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Calendar_Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessProfileID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccessCalendarMonthNr { get; set; }

        [StringLength(100)]
        public string Day1ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day2ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day3ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day4ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day5ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day6ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day7ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day8ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day9ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day10ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day11ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day12ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day13ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day14ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day15ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day16ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day17ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day18ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day19ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day20ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day21ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day22ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day23ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day24ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day25ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day26ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day27ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day28ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day29ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day30ProfileAccessProfileID { get; set; }

        [StringLength(100)]
        public string Day31ProfileAccessProfileID { get; set; }
    }
}
