namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_KundenMark
    {
        [Key]
        public int Code { get; set; }

        public int? BenutzerCode { get; set; }

        public int? ObjCode { get; set; }

        public int? KAnsprechpCode { get; set; }

        public int? Markierung { get; set; }

        public int? OriginalCode { get; set; }
    }
}
