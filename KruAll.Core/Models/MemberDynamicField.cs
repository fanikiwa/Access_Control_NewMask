namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberDynamicField
    {
        public long ID { get; set; }

        public long? MemberID { get; set; }

        public int? FieldIndex { get; set; }

        public string FieldValue { get; set; }

        public virtual MembersData MembersData { get; set; }
    }
}
