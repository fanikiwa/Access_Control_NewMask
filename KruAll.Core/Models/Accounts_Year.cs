namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Year
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public double Y1 { get; set; }

        public double Y2 { get; set; }

        public double Y3 { get; set; }

        public double Y4 { get; set; }

        public double Y5 { get; set; }

        public double Y6 { get; set; }

        public double Y7 { get; set; }

        public double Y8 { get; set; }

        public double Y9 { get; set; }

        public double Y10 { get; set; }

        public double Y11 { get; set; }

        public double Y12 { get; set; }

        public double Y13 { get; set; }

        public double Y14 { get; set; }

        public double Y15 { get; set; }

        public double Y16 { get; set; }

        public double Y17 { get; set; }

        public double Y18 { get; set; }

        public double Y19 { get; set; }

        public double Y20 { get; set; }

        public double Y21 { get; set; }

        public double Y22 { get; set; }

        public double Y23 { get; set; }

        public double Y24 { get; set; }

        public double Y25 { get; set; }

        public double Y26 { get; set; }

        public double Y27 { get; set; }

        public double Y28 { get; set; }

        public double Y29 { get; set; }

        public double Y30 { get; set; }

        public double Y31 { get; set; }

        public virtual Accounts_Day Accounts_Day { get; set; }
    }
}
