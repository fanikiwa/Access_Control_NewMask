namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ZuttritProfile
    {
        public ZuttritProfile()
        {
            AccessProfileAccessGroupMappings = new HashSet<AccessProfileAccessGroupMapping>();
            ZuttritProfilesTimeFrames = new HashSet<ZuttritProfilesTimeFrame>();
        }

        public long ID { get; set; }

        public long? GroupID { get; set; }

        public int AccessProfileNo { get; set; }

        [Required]
        [StringLength(100)]
        public string AccessProfileID { get; set; }

        [Required]
        public string AccessDescription { get; set; }

        public bool DisplayProfiles { get; set; }

        [Column(TypeName = "text")]
        public string Memo { get; set; }

        public string ForeColour { get; set; }

        public string BackColour { get; set; }

        public virtual AccessGroup AccessGroup { get; set; }

        public virtual ICollection<AccessProfileAccessGroupMapping> AccessProfileAccessGroupMappings { get; set; }

        public virtual ICollection<ZuttritProfilesTimeFrame> ZuttritProfilesTimeFrames { get; set; }
    }
}
