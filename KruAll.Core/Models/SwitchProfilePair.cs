namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SwitchProfilePair
    {
        public long ID { get; set; }

        public long ProfileID { get; set; }

        public int Number { get; set; }

        public int DayFrom { get; set; }

        public int DayTo { get; set; }

        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }
    }
}
