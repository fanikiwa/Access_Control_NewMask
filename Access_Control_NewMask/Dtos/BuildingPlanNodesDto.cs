using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class BuildingPlanNodesDto
    {
        public long LocationId { get; set; }
        public long BuildingId { get; set; }
        public long FloorId { get; set; }
        public long RoomId { get; set; }
        public long DoorId { get; set; }
    }
}