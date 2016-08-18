namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalReader
    {
        public TerminalReader()
        {
            ReaderAccessPlans = new HashSet<ReaderAccessPlan>();
            ReaderAssigneds = new HashSet<ReaderAssigned>();
            ReaderVisitorPlans = new HashSet<ReaderVisitorPlan>();
        }

        public long ID { get; set; }

        public long? TermID { get; set; }

        public int ReaderID { get; set; }

        public int? ReaderNr { get; set; }

        public int? Direction { get; set; }

        public int? Status { get; set; }

        public int? RelayTime { get; set; }

        public string ReaderInfo { get; set; }

        [StringLength(10)]
        public string Category { get; set; }

        public long? BeforeAlarm { get; set; }

        public long? AlarmFrom { get; set; }

        public string ReaderType { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }

        public int? Lock { get; set; }

        public int? Delay { get; set; }

        public string ReaderImage { get; set; }

        [StringLength(50)]
        public string TerminalReaderID { get; set; }

        public virtual ICollection<ReaderAccessPlan> ReaderAccessPlans { get; set; }

        public virtual ICollection<ReaderAssigned> ReaderAssigneds { get; set; }

        public virtual ICollection<ReaderVisitorPlan> ReaderVisitorPlans { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }

        public virtual TerminalReadersStatic TerminalReadersStatic { get; set; }
    }
}
