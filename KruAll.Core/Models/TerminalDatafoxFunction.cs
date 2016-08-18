namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalDatafoxFunction")]
    public partial class TerminalDatafoxFunction
    {
        public long ID { get; set; }

        public long TerminalID { get; set; }

        public int BookingSpan { get; set; }

        public bool? AccessControl { get; set; }

        public bool? Project { get; set; }

        public bool? ReaderList { get; set; }

        public bool? ActionList { get; set; }

        public bool? TimeList { get; set; }

        public bool? LocationList { get; set; }

        public bool? HolidayList { get; set; }

        public bool? IdentificationList { get; set; }

        public bool? EventList { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }
    }
}
