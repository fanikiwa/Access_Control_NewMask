namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vwPersPinCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        public int? Aus_PinCodeType { get; set; }

        public string Aus_PinCode { get; set; }

        public bool? Aus_PinCodeStatus { get; set; }

        public int? Nur_PinCodeType { get; set; }

        public string Nur_PinCode { get; set; }

        public bool? Nur_PinCodeStatus { get; set; }

        public int? Sicher_PinCodeType { get; set; }

        public string Scher_PinCode { get; set; }

        public bool? Scher_PinCodeStatus { get; set; }
    }
}
