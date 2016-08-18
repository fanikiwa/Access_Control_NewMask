namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupAccessProfile
    {
        public long ID { get; set; }

        public int GroupProfileNo { get; set; }

        public string GroupProfileDescription { get; set; }
    }
}
