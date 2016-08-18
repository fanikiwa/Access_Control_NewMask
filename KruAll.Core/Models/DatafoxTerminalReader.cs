namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DatafoxTerminalReader
    {
        public long ID { get; set; }

        public long? DatafoxTerminalID { get; set; }

        public int ReaderID { get; set; }

        public string ReaderType { get; set; }

        public string ReaderDescription { get; set; }

        public string Direction { get; set; }

        public string Status { get; set; }

        public int? RelayTime { get; set; }

        public string ReaderMemo { get; set; }

        public virtual DatafoxTerminalInstance DatafoxTerminalInstance { get; set; }
    }
}
