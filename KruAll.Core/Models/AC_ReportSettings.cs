namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_ReportSettings
    {
        public long ID { get; set; }

        public long? ReportID { get; set; }

        public bool? ShowDate { get; set; }

        public bool? ShowTime { get; set; }

        public bool? ShowBuildingLocation { get; set; }

        public bool? ShowBuilding { get; set; }

        public bool? ShowFloor { get; set; }

        public bool? ShowRoom { get; set; }

        public bool? ShowReader { get; set; }

        public bool? ShowCompany { get; set; }

        public bool? ShowPersLocation { get; set; }

        public bool? ShowPersDepartment { get; set; }

        public bool? ShowPersCC { get; set; }

        public bool? ShowPersName { get; set; }

        public bool? ShowPersCardNrLong { get; set; }

        public bool? ShowPersCardNrShort { get; set; }

        public int? PrintSelection { get; set; }

        public int? Type { get; set; }

        public virtual AC_Reports AC_Reports { get; set; }
    }
}
