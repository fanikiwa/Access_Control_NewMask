using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class BuildingPlanPersonalRptDto
    {
        public long ID { get; set; }
        public long Nr { get; set; }
        public string LocationName { get; set; }
        public string Building { get; set; }
        public string level { get; set; }
        public string Rooms { get; set; }
        public string Door { get; set; }
    }

    public class BuildingPlanModelRptDto
    {
        public long BuildingPlanId { get; set; }
        public string BuildingPlanName { get; set; }
        public int LocationKey { get; set; }
        public string LocationName { get; set; }
        public int BuildingKey { get; set; }
        public string BuildingName { get; set; }
        public int LevelKey { get; set; }
        public string Level { get; set; }
        public int RoomKey { get; set; }
        public string Room { get; set; }
        public int DoorKey { get; set; }
        public string Door { get; set; }
        public bool DoorSelected { get; set; }
        public int Direction { get; set; }
        public string DirectionName
        {
            get
            {
                return Direction == 0 ? "Eingang" : Direction == 1 ? "Ausgang" : "";
            }
        }

        public string LocationID
        {
            get
            {
                return String.Format("{0}#{1}",
                    BuildingPlanId, LocationKey);
            }
        }
        public string BuildingID
        {
            get
            {
                return String.Format("{0}#{1}#{2}",
                    BuildingPlanId, LocationKey, BuildingKey);
            }
        }
        public string LevelID
        {
            get
            {
                return String.Format("{0}#{1}#{2}#{3}",
                    BuildingPlanId, LocationKey, BuildingKey, LevelKey);
            }
        }
        public string RoomID
        {
            get
            {
                return String.Format("{0}#{1}#{2}#{3}#{4}",
                    BuildingPlanId, LocationKey, BuildingKey, LevelKey, RoomKey);
            }
        }
        public string DoorID
        {
            get
            {
                return String.Format("{0}#{1}#{2}#{3}#{4}#{5}",
                    BuildingPlanId, LocationKey, BuildingKey, LevelKey, RoomKey, DoorKey);
            }
        }

        public BuildingPlanModelRptDto Clone()
        {
            return (BuildingPlanModelRptDto)MemberwiseClone();
        }
    }

    public class BuildingPlanModelDto
    {
        [JsonProperty("class")]
        public string _Class { get; set; }

        [JsonProperty("nodeDataArray")]
        public List<BuildingPlanNodeDataDto> NodeData { get; set; }

        [JsonProperty("linkDataArray")]
        public List<BuildingPlanLinkDataDto> LinkData { get; set; }
    }

    public class BuildingPlanNodeDataDto
    {
        public int Key { get; set; }
        public string text { get; set; }
        public int level { get; set; }
        public string firstDescription { get; set; }
        public string Address { get; set; }
        public Nullable<bool> laserChoice { get; set; }
        public int totalBuildings { get; set; }
        public int totalFloors { get; set; }
        public int totalRooms { get; set; }
        public int totalDoorReader { get; set; }
    }

    public class BuildingPlanLinkDataDto
    {
        [JsonProperty("from")]
        public int FromKey { get; set; }

        [JsonProperty("to")]
        public int ToKey { get; set; }
    }
}