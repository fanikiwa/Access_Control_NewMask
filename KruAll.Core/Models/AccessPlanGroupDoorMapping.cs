namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessPlanGroupDoorMapping")]
    public partial class AccessPlanGroupDoorMapping
    {
        public long ID { get; set; }

        public long? AccessPlanGroupID { get; set; }

        public long? BuildingPlanID { get; set; }

        public long? LocationID { get; set; }

        public long? BuildingID { get; set; }

        public long? FloorID { get; set; }

        public long? RoomID { get; set; }

        public long? DoorID { get; set; }

        public virtual BuildingPlan BuildingPlan { get; set; }

        public virtual TbAccessPlanGroup TbAccessPlanGroup { get; set; }
    }
}
