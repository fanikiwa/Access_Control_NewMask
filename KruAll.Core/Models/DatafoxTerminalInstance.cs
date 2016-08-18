namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DatafoxTerminalInstance
    {
        public DatafoxTerminalInstance()
        {
            DatafoxTerminalReaders = new HashSet<DatafoxTerminalReader>();
        }

        public long ID { get; set; }

        [Required]
        public string TermType { get; set; }

        public int TermID { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public string SerialNumber { get; set; }

        public string ConnectionType { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        public int? Port { get; set; }

        public string Memo { get; set; }

        public long? TerminalOEMId { get; set; }

        public long? TerminalNewId { get; set; }

        public virtual ICollection<DatafoxTerminalReader> DatafoxTerminalReaders { get; set; }
    }
}
