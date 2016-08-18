namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_SoftwareModules
    {
        public long ID { get; set; }

        public int? ModuleNumber { get; set; }

        public string ModuleName { get; set; }
    }
}
