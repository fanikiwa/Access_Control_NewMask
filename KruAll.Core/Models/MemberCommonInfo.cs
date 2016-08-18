namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCommonInfo")]
    public partial class MemberCommonInfo
    {
        public long ID { get; set; }

        public long? MemberID { get; set; }

        public string EyeColor { get; set; }

        public string Height { get; set; }

        public string PlaceOfBirth { get; set; }

        public virtual MembersData MembersData { get; set; }
    }
}
