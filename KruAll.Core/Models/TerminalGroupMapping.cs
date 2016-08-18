namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalGroupMapping")]
    public partial class TerminalGroupMapping
    {
        public long ID { get; set; }

        public long TerminalGroupId { get; set; }

        public long TerminalInstanceId { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }

        public virtual TerminalGroup TerminalGroup { get; set; }
    }
}
