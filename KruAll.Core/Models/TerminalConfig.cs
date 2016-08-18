namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalConfig")]
    public partial class TerminalConfig
    {
        public TerminalConfig()
        {
            TA_TerminalGroupMapping = new HashSet<TA_TerminalGroupMapping>();
            TerminalDatafoxFunctions = new HashSet<TerminalDatafoxFunction>();
            TerminalFunctionKeys = new HashSet<TerminalFunctionKey>();
            TerminalGroupMappings = new HashSet<TerminalGroupMapping>();
            TerminalInfoTexts = new HashSet<TerminalInfoText>();
            TerminalReaders = new HashSet<TerminalReader>();
            TerminalSignalBreaks = new HashSet<TerminalSignalBreak>();
            TerminalUtilities = new HashSet<TerminalUtility>();
        }

        public long ID { get; set; }

        public int TermID { get; set; }

        [Required]
        public string TermType { get; set; }

        public string Description { get; set; }

        public int? TerminalConnectId { get; set; }

        public int? TerminalInfoId { get; set; }

        public int? TerminalOEMId { get; set; }

        public string Status { get; set; }

        public bool IsActive { get; set; }

        public string SerialNumber { get; set; }

        public string ConnectionType { get; set; }

        public string IpAddress { get; set; }

        public int? Port { get; set; }

        public string Memo { get; set; }

        public int? TerminalId { get; set; }

        public int? ZkRelayTime { get; set; }

        public int? ZkExternalReaders { get; set; }

        public string BreaksRelay { get; set; }

        public virtual ICollection<TA_TerminalGroupMapping> TA_TerminalGroupMapping { get; set; }

        public virtual TerminalConnect TerminalConnect { get; set; }

        public virtual TerminalInfo TerminalInfo { get; set; }

        public virtual TerminalOEM TerminalOEM { get; set; }

        public virtual Terminal Terminal { get; set; }

        public virtual ICollection<TerminalDatafoxFunction> TerminalDatafoxFunctions { get; set; }

        public virtual ICollection<TerminalFunctionKey> TerminalFunctionKeys { get; set; }

        public virtual ICollection<TerminalGroupMapping> TerminalGroupMappings { get; set; }

        public virtual ICollection<TerminalInfoText> TerminalInfoTexts { get; set; }

        public virtual ICollection<TerminalReader> TerminalReaders { get; set; }

        public virtual ICollection<TerminalSignalBreak> TerminalSignalBreaks { get; set; }

        public virtual ICollection<TerminalUtility> TerminalUtilities { get; set; }
    }
}
