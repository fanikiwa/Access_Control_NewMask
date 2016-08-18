namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_VisitorPlanVisitors
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccessPlanNr { get; set; }

        public string AccessPlanDescription { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        public long? Card_Nr { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string LastName { get; set; }

        public string CostCenterName { get; set; }

        public string LocationName { get; set; }

        public string DepartmentName { get; set; }
    }
}
