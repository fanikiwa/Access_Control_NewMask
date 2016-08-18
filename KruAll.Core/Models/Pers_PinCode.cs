namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_PinCode
    {
        public long ID { get; set; }

        public long Pers_Nr { get; set; }

        public string PinCode { get; set; }

        public int? PinCodeType { get; set; }

        public bool? PinCodeStatus { get; set; }
    }
}
