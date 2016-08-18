namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FingerPrint
    {
        public long ID { get; set; }

        public int PersType { get; set; }

        public long PersIDNr { get; set; }

        public int? FingerNr { get; set; }

        public string Template9 { get; set; }

        public string Template10 { get; set; }

        public bool Valid { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Quality1 { get; set; }

        public int? Quality2 { get; set; }

        public int? Quality3 { get; set; }
    }
}
