namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewTerminalGroupMapping")]
    public partial class ViewTerminalGroupMapping
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string TermType { get; set; }

        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IsActive { get; set; }

        public string SerialNumber { get; set; }

        public string ConnectionType { get; set; }

        public string IpAddress { get; set; }

        public int? Port { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TerminalGroupId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TerminalInstanceId { get; set; }
    }
}
