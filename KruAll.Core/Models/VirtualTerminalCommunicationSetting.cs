namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VirtualTerminalCommunicationSetting
    {
        public int ID { get; set; }

        public string FixedIPAddress { get; set; }

        public bool? FixedIPAddressEnabled { get; set; }

        public int? FixedIPAddressPort { get; set; }

        public string DynamicIPAddress { get; set; }

        public bool? DynamicIPAddressEnabled { get; set; }

        public int? DynamicIPAddressPort { get; set; }

        public bool? Active { get; set; }

        public long TerminalId { get; set; }
    }
}
