namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Global_Settings
    {
        public int ID { get; set; }

        public string AppName { get; set; }

        public string Version { get; set; }
    }
}
