namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_CardAllocationOverview
    {
        public long? ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Pers_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool PersonnelActive { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ClientName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ClientID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Client_Nr { get; set; }

        [Key]
        [Column(Order = 5)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 6)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 7)]
        public string FullName { get; set; }

        public string LocationName { get; set; }

        public long? LocationID { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Location_Nr { get; set; }

        public string DepartmentName { get; set; }

        public long? DepartmentID { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Department_Nr { get; set; }

        public string CostCenterName { get; set; }

        public long? CostCenterID { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CostCenter_Nr { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TransPonderID { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TransponderNr { get; set; }

        public int? Action { get; set; }

        public bool? TransponderStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValidTo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TransponderDeactivatedOn { get; set; }
    }
}
