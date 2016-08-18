namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        public Department()
        {
            Areas = new HashSet<Area>();
            Pers_Departments = new HashSet<Pers_Departments>();
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public long Department_Nr { get; set; }

        public string State { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public long? LocationId { get; set; }

        public string LocationHeadName { get; set; }

        public string LocationHeadFunction { get; set; }

        public string LocationHeadPhone { get; set; }

        public string LocationHeadMobile { get; set; }

        public string LocationHeadEmail { get; set; }

        public string InfoText { get; set; }

        public string Place { get; set; }

        public virtual ICollection<Area> Areas { get; set; }

        public virtual ICollection<Pers_Departments> Pers_Departments { get; set; }
    }
}
