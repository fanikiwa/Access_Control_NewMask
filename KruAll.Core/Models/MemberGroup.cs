namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberGroup
    {
        public MemberGroup()
        {
            MembersDatas = new HashSet<MembersData>();
        }

        public long Id { get; set; }

        public long GroupNr { get; set; }

        public string GroupName { get; set; }

        public string PersonHead { get; set; }

        public string TrainerOne { get; set; }

        public string TrainerTwo { get; set; }

        public string TrainerThree { get; set; }

        public string TrainerFour { get; set; }

        public string TrainerFive { get; set; }

        public virtual ICollection<MembersData> MembersDatas { get; set; }
    }
}
