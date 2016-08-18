namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewMemberCardsInfo")]
    public partial class ViewMemberCardsInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public string MemberName { get; set; }

        public long? MemberNumber { get; set; }

        public long? GroupNr { get; set; }

        public string GroupName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TransponderNr { get; set; }

        public bool? TransponderStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValidTo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TransponderDeactivatedOn { get; set; }

        public int? Action { get; set; }

        public string Memo { get; set; }

        public int? TransponderType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExtendedTo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TransponderID { get; set; }
    }
}
