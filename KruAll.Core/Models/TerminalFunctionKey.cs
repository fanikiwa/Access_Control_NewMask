namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalFunctionKey
    {
        public long ID { get; set; }

        public long TerminalConfigID { get; set; }

        public int? FunctionKeyNr { get; set; }

        public string FunctionKeyText { get; set; }

        public virtual TerminalConfig TerminalConfig { get; set; }
    }
}
