namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Month
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public double M1 { get; set; }

        public double M2 { get; set; }

        public double M3 { get; set; }

        public double M4 { get; set; }

        public double M5 { get; set; }

        public double M6 { get; set; }

        public double M7 { get; set; }

        public double M8 { get; set; }

        public double M9 { get; set; }

        public double M10 { get; set; }

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M14 { get; set; }

        public double M15 { get; set; }

        public double M16 { get; set; }

        public double M17 { get; set; }

        public double M18 { get; set; }

        public double M19 { get; set; }

        public double M20 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public double M24 { get; set; }

        public double M25 { get; set; }

        public double M26 { get; set; }

        public double M27 { get; set; }

        public double M28 { get; set; }

        public double M29 { get; set; }

        public double M30 { get; set; }

        public double M31 { get; set; }

        public virtual Accounts_Day Accounts_Day { get; set; }
    }
}
