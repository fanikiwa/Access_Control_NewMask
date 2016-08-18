namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DynamicColumn
    {
        public DynamicColumn()
        {
            EmpAdditionalInfoes = new HashSet<EmpAdditionalInfo>();
        }

        [Key]
        public int ColumnID { get; set; }

        public string ColumnName { get; set; }

        public string ColumnValue { get; set; }

        public virtual ICollection<EmpAdditionalInfo> EmpAdditionalInfoes { get; set; }
    }
}
