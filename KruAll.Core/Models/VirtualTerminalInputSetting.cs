namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VirtualTerminalInputSetting
    {
        public long ID { get; set; }

        public long? TerminalID { get; set; }

        public bool Biometric { get; set; }

        public bool RFID { get; set; }

        public bool BarCode { get; set; }

        public bool PinCode { get; set; }

        public bool PersonalNumber { get; set; }

        public bool InividualNumber { get; set; }
    }
}
