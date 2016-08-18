namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccessCalendarProfile
    {
        public long ID { get; set; }

        public long? AccessCalendarID { get; set; }

        public DateTime? Date { get; set; }

        public long? AccessProfile { get; set; }
    }
}
