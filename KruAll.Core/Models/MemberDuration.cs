namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberDuration")]
    public partial class MemberDuration
    {
        public MemberDuration()
        {
            MembersDatas = new HashSet<MembersData>();
        }

        public long ID { get; set; }

        public long? DurationNr { get; set; }

        public string Duration { get; set; }

        public virtual ICollection<MembersData> MembersDatas { get; set; }
    }
}
