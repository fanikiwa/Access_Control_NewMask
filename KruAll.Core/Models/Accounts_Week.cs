namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Week
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public double W1 { get; set; }

        public double W2 { get; set; }

        public double W3 { get; set; }

        public double W4 { get; set; }

        public double W5 { get; set; }

        public double W6 { get; set; }

        public double W7 { get; set; }

        public double W8 { get; set; }

        public double W9 { get; set; }

        public double W10 { get; set; }

        public double W11 { get; set; }

        public double W12 { get; set; }

        public double W13 { get; set; }

        public double W14 { get; set; }

        public double W15 { get; set; }

        public double W16 { get; set; }

        public double W17 { get; set; }

        public double W18 { get; set; }

        public double W19 { get; set; }

        public double W20 { get; set; }

        public double W21 { get; set; }

        public double W22 { get; set; }

        public double W23 { get; set; }

        public double W24 { get; set; }

        public double W25 { get; set; }

        public double W26 { get; set; }

        public double W27 { get; set; }

        public double W28 { get; set; }

        public double W29 { get; set; }

        public double W30 { get; set; }

        public double W31 { get; set; }

        public virtual Accounts_Day Accounts_Day { get; set; }
    }
}
