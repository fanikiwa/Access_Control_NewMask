namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VirtualTerminal")]
    public partial class VirtualTerminal
    {
        public long ID { get; set; }

        public long TerminalId { get; set; }

        public string Description { get; set; }

        public int LocationId { get; set; }

        public int CostCenterId { get; set; }

        public bool? TerminalActive { get; set; }

        public int? TerminalType { get; set; }

        public int? LogoutCode { get; set; }

        public bool? RealTimeActive { get; set; }

        [StringLength(10)]
        public string TerminalCostCenter { get; set; }

        public bool DisplayDepartment { get; set; }

        public bool DisplayPersonalNumber { get; set; }

        public bool DisplayCostCenter { get; set; }

        public int FunctionKeysDisplayMode { get; set; }

        public bool? TerminalOffline { get; set; }

        public string DatabaseServer { get; set; }

        public int? DataIntervalHours { get; set; }

        public int? DataintervalMinutes { get; set; }
    }
}
