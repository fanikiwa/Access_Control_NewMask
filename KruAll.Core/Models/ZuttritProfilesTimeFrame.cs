namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ZuttritProfilesTimeFrame
    {
        public long ID { get; set; }

        public long? AccessProfID { get; set; }

        public bool ProfilAktiv { get; set; }

        public int Level { get; set; }

        public DateTime MonFrom { get; set; }

        public DateTime MonTo { get; set; }

        public DateTime TueFrom { get; set; }

        public DateTime TueTo { get; set; }

        public DateTime WedFrom { get; set; }

        public DateTime WedTo { get; set; }

        public DateTime ThurFrom { get; set; }

        public DateTime ThurTo { get; set; }

        public DateTime FriFrom { get; set; }

        public DateTime FriTo { get; set; }

        public DateTime SatFrom { get; set; }

        public DateTime SatTo { get; set; }

        public DateTime SunFrom { get; set; }

        public DateTime SunTo { get; set; }

        public virtual ZuttritProfile ZuttritProfile { get; set; }
    }
}
