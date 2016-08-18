namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalInfo")]
    public partial class TerminalInfo
    {
        public TerminalInfo()
        {
            TerminalConfigs = new HashSet<TerminalConfig>();
        }

        public int ID { get; set; }

        public string InfoText1 { get; set; }

        public string InfoText2 { get; set; }

        public string InfoText3 { get; set; }

        public string InfoText4 { get; set; }

        [Required]
        public string Functionkey1 { get; set; }

        [Required]
        public string Functionkey2 { get; set; }

        [Required]
        public string Functionkey3 { get; set; }

        [Required]
        public string Functionkey4 { get; set; }

        [Required]
        public string Functionkey5 { get; set; }

        [Required]
        public string Functionkey6 { get; set; }

        [Required]
        public string Functionkey7 { get; set; }

        [Required]
        public string Functionkey8 { get; set; }

        public string DoorAssign { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<TerminalConfig> TerminalConfigs { get; set; }
    }
}
