namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DynamicFieldsMember")]
    public partial class DynamicFieldsMember
    {
        public long ID { get; set; }

        public int? FieldIndex { get; set; }

        public string FieldText { get; set; }
    }
}
