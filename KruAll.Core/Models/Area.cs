namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Area
    {
        public Area()
        {
            Pers_Areas = new HashSet<Pers_Areas>();
        }

        public long ID { get; set; }

        public int Area_Nr { get; set; }

        [Required]
        public string Name { get; set; }

        public long? LocationFederalStateId { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Ort { get; set; }

        public string HouseNumber { get; set; }

        public string LocationHeadName { get; set; }

        public string LocationHeadFunction { get; set; }

        public string LocationHeadPhone { get; set; }

        public string LocationHeadMobile { get; set; }

        public string LocationHeadEmail { get; set; }

        public string InfoText { get; set; }

        public long DeptId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Pers_Areas> Pers_Areas { get; set; }
    }
}
