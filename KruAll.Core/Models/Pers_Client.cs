namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_Client
    {
        public long ID { get; set; }

        public long Pers_Nr { get; set; }

        public long ClientID { get; set; }

        public virtual Client Client { get; set; }
    }
}
