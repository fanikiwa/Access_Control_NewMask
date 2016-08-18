namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalUtility
    {
        public long ID { get; set; }

        public long TerminalConfigID { get; set; }

        public bool HasFPRead { get; set; }

        public bool HasAPPosting { get; set; }

        public bool HasTAPPosting { get; set; }

        public bool HasPersNoPin { get; set; }

        public bool RFIDCardPin { get; set; }

        public bool RFIDActive { get; set; }

        public bool AllowTransponder { get; set; }

        public bool AllowTransponderAndPin { get; set; }

        public bool HasProfFirmware { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }
    }
}
