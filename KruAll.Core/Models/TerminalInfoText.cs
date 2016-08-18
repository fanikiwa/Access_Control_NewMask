namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalInfoText")]
    public partial class TerminalInfoText
    {
        public long ID { get; set; }

        public long TerminalConfigID { get; set; }

        public int? InfoTextNr { get; set; }

        public string InfoText { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }
    }
}
