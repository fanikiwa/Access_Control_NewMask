namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Day
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int PersNr { get; set; }

        public int AccntNr { get; set; }

        public double D1 { get; set; }

        public double D2 { get; set; }

        public double D3 { get; set; }

        public double D4 { get; set; }

        public double D5 { get; set; }

        public double D6 { get; set; }

        public double D7 { get; set; }

        public double D8 { get; set; }

        public double D9 { get; set; }

        public double D10 { get; set; }

        public double D11 { get; set; }

        public double D12 { get; set; }

        public double D13 { get; set; }

        public double D14 { get; set; }

        public double D15 { get; set; }

        public double D16 { get; set; }

        public double D17 { get; set; }

        public double D18 { get; set; }

        public double D19 { get; set; }

        public double D20 { get; set; }

        public double D21 { get; set; }

        public double D22 { get; set; }

        public double D23 { get; set; }

        public double D24 { get; set; }

        public double D25 { get; set; }

        public double D26 { get; set; }

        public double D27 { get; set; }

        public double D28 { get; set; }

        public double D29 { get; set; }

        public double D30 { get; set; }

        public double D31 { get; set; }

        public virtual Accounts_Month Accounts_Month { get; set; }

        public virtual Accounts_Week Accounts_Week { get; set; }

        public virtual Accounts_Year Accounts_Year { get; set; }
    }
}
