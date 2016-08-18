namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CostCenter
    {
        public CostCenter()
        {
            EmployeeInfoes = new HashSet<EmployeeInfo>();
            Pers_CostCenters = new HashSet<Pers_CostCenters>();
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public long? CostCenter_Nr { get; set; }

        public string Ort { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public long LocationId { get; set; }

        public string LocationHeadName { get; set; }

        public string LocationHeadFunction { get; set; }

        public string LocationHeadPhone { get; set; }

        public string LocationHeadMobile { get; set; }

        public string LocationHeadEmail { get; set; }

        public string InfoText { get; set; }

        public virtual ICollection<EmployeeInfo> EmployeeInfoes { get; set; }

        public virtual ICollection<Pers_CostCenters> Pers_CostCenters { get; set; }
    }
}
