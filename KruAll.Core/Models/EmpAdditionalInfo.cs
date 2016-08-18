namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmpAdditionalInfo")]
    public partial class EmpAdditionalInfo
    {
        [Key]
        public int AdditionalInfoID { get; set; }

        public int? EmpNumber { get; set; }

        public int ColumnID { get; set; }

        public string EntryValue { get; set; }

        public virtual DynamicColumn DynamicColumn { get; set; }
    }
}
