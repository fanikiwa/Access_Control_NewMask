using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class BuildingPlanDto
    {
        public string Key { get; set; }
        public string text { get; set; }
        public string level { get; set; }
        public string firstDescription { get; set; }
        public string Address { get; set; }
        public Nullable<bool> laserChoice { get; set; }
        public int totalBuildings { get; set; }
        public int totalFloors { get; set; }
        public int totalRooms { get; set; }
        public int totalDoorReader { get; set; }
    }
}