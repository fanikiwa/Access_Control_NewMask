namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalBookingRawData")]
    public partial class TerminalBookingRawData
    {
        public long ID { get; set; }

        public int EmpNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public int? StatusNr { get; set; }

        public int? ProcessingStatus { get; set; }

        public string Comment { get; set; }

        public string Source { get; set; }
    }
}
