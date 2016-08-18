namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_HolidayPlanPerTerminal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermID { get; set; }

        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public string TermType { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanNumber { get; set; }

        public string AccessPlanDescription { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HolidayPlanNumber { get; set; }

        [Key]
        [Column(Order = 7)]
        public string HolidayPlanName { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarYear { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalendarMonth { get; set; }

        [StringLength(100)]
        public string Day1Holiday { get; set; }

        [StringLength(100)]
        public string Day2Holiday { get; set; }

        [StringLength(100)]
        public string Day3Holiday { get; set; }

        [StringLength(100)]
        public string Day4Holiday { get; set; }

        [StringLength(100)]
        public string Day5Holiday { get; set; }

        [StringLength(100)]
        public string Day6Holiday { get; set; }

        [StringLength(100)]
        public string Day7Holiday { get; set; }

        [StringLength(100)]
        public string Day8Holiday { get; set; }

        [StringLength(100)]
        public string Day9Holiday { get; set; }

        [StringLength(100)]
        public string Day10Holiday { get; set; }

        [StringLength(100)]
        public string Day11Holiday { get; set; }

        [StringLength(100)]
        public string Day12Holiday { get; set; }

        [StringLength(100)]
        public string Day13Holiday { get; set; }

        [StringLength(100)]
        public string Day14Holiday { get; set; }

        [StringLength(100)]
        public string Day15Holiday { get; set; }

        [StringLength(100)]
        public string Day16Holiday { get; set; }

        [StringLength(100)]
        public string Day17Holiday { get; set; }

        [StringLength(100)]
        public string Day18Holiday { get; set; }

        [StringLength(100)]
        public string Day19Holiday { get; set; }

        [StringLength(100)]
        public string Day20Holiday { get; set; }

        [StringLength(100)]
        public string Day21Holiday { get; set; }

        [StringLength(100)]
        public string Day22Holiday { get; set; }

        [StringLength(100)]
        public string Day23Holiday { get; set; }

        [StringLength(100)]
        public string Day24Holiday { get; set; }

        [StringLength(100)]
        public string Day25Holiday { get; set; }

        [StringLength(100)]
        public string Day26Holiday { get; set; }

        [StringLength(100)]
        public string Day27Holiday { get; set; }

        [StringLength(100)]
        public string Day28Holiday { get; set; }

        [StringLength(100)]
        public string Day29Holiday { get; set; }

        [StringLength(100)]
        public string Day30Holiday { get; set; }

        [StringLength(100)]
        public string Day31Holiday { get; set; }
    }
}
