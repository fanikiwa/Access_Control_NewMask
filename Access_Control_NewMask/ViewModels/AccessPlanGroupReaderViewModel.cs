using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessPlanGroupReaderViewModel
    {
        public List<BuildingPlanLocationDto> BuildingPlanLocations()
        {
            List<BuildingPlanLocationDto> locations = new List<BuildingPlanLocationDto>();
            var buildingPlans = new BuildingPlanViewModel().BuildingPlans();
            foreach (var plan in buildingPlans)
            {
                var currentPlan = new BuildingPlanViewModel().GetBuildingPlanByID(plan.ID);
                if (currentPlan != null)
                {
                    var _planList = DeserializeBuildingPlan(currentPlan);
                    BuildingPlanLocationDto locatioDto = new BuildingPlanLocationDto();
                    locatioDto.ID = currentPlan.ID;
                    locatioDto.Nr = currentPlan.PlanNr;
                    locatioDto.LocationName = _planList.Find(x => x.level == "1") != null ? _planList.Find(x => x.level == "1").text : "";
                    if (!string.IsNullOrEmpty(locatioDto.LocationName))
                    {
                        locations.Add(locatioDto);
                    }
                }
            }
            return locations;
        }

        public List<BuildingPlanDto> DeserializeBuildingPlan(BuildingPlan currentBuildingPlan)
        {
            BuildingPlan plan = new BuildingPlan();
            plan = currentBuildingPlan;
            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
            Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
            var nodeData = buildingPlan["model"]["nodeDataArray"];
            List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
            return nodeArray;
        }

        public List<BuildingPlanModelRptDto> DeserializeBuildingPlanX(BuildingPlan currentBuildingPlan)
        {
            BuildingPlan plan = new BuildingPlan();
            plan = currentBuildingPlan;
            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
            JObject buildingPlan = (JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
            var nodeData = buildingPlan["model"];
            BuildingPlanModelDto nodeArray = JsonConvert.DeserializeObject<BuildingPlanModelDto>(nodeData.ToString());
            //nodeArray.nodeDataArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData["nodeDataArray"].ToString());
            //nodeArray.linkDataArray = JsonConvert.DeserializeObject<List<BuildingPlanLinkDataDto>>(nodeData["linkDataArray"].ToString());
            List<BuildingPlanModelRptDto> _plans = GetPlans(currentBuildingPlan, nodeArray);
            return _plans;
        }

        public List<BuildingPlanModelRptDto> DeserializeBuildingPlanX(BuildingPlan currentBuildingPlan, long filterKey, long filterLevel)
        {
            BuildingPlan plan = new BuildingPlan();
            plan = currentBuildingPlan;
            JObject jsonPlan = JObject.Parse(plan.PlanDefinition);
            JObject buildingPlan = (JObject)JsonConvert.DeserializeObject(plan.PlanDefinition.ToString());
            var nodeData = buildingPlan["model"];
            BuildingPlanModelDto nodeArray = JsonConvert.DeserializeObject<BuildingPlanModelDto>(nodeData.ToString());
            //nodeArray.nodeDataArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData["nodeDataArray"].ToString());
            //nodeArray.linkDataArray = JsonConvert.DeserializeObject<List<BuildingPlanLinkDataDto>>(nodeData["linkDataArray"].ToString());
            List<BuildingPlanModelRptDto> _plans = GetPlans(currentBuildingPlan, nodeArray);

            if (_plans.Count > 0 && filterKey > 0 && filterLevel > 0)
            {
                if (filterLevel == 1)
                    _plans = _plans.Where(x => x.LocationKey == filterKey).ToList() ?? new List<BuildingPlanModelRptDto>();

                if (filterLevel == 2)
                    _plans = _plans.Where(x => x.BuildingKey == filterKey).ToList() ?? new List<BuildingPlanModelRptDto>();

                if (filterLevel == 3)
                    _plans = _plans.Where(x => x.LevelKey == filterKey).ToList() ?? new List<BuildingPlanModelRptDto>();

                if (filterLevel == 4)
                    _plans = _plans.Where(x => x.RoomKey == filterKey).ToList() ?? new List<BuildingPlanModelRptDto>();

                if (filterLevel == 5)
                    _plans = _plans.Where(x => x.DoorKey == filterKey).ToList() ?? new List<BuildingPlanModelRptDto>();
            }

            return _plans;
        }

        public List<BuildingPlanModelRptDto> GetPlans(BuildingPlan currentBuildingPlan, BuildingPlanModelDto buildingPlanDtoX)
        {
            List<BuildingPlanModelRptDto> buildingPlanRptDtoList = new List<BuildingPlanModelRptDto>();
            List<BuildingPlanNodeDataDto> buildingPlanLocations = buildingPlanDtoX.NodeData.Where(p => p.level == 1).ToList() ??
                new List<BuildingPlanNodeDataDto>();

            foreach (BuildingPlanNodeDataDto buildingPlanLocation in buildingPlanLocations)
            {
                BuildingPlanModelRptDto buildingPlanRptDto = new BuildingPlanModelRptDto()
                {
                    BuildingPlanId = currentBuildingPlan.ID,
                    BuildingPlanName = currentBuildingPlan.PlanName,
                    LocationKey = buildingPlanLocation.Key,
                    LocationName = buildingPlanLocation.text
                };

                if (buildingPlanDtoX.LinkData.Any(p => p.FromKey == buildingPlanRptDto.LocationKey))
                {
                    List<int> childBuildingKeys = buildingPlanDtoX.LinkData.Where(p => p.FromKey == buildingPlanRptDto.LocationKey).Select(b => b.ToKey).ToList<int>();
                    List<BuildingPlanNodeDataDto> buildingPlanBuildings = buildingPlanDtoX.NodeData.Where(p => p.level == 2 && childBuildingKeys.Contains(p.Key)).ToList() ??
                        new List<BuildingPlanNodeDataDto>();


                    foreach (BuildingPlanNodeDataDto buildingPlanBuilding in buildingPlanBuildings)
                    {
                        BuildingPlanModelRptDto buildingPlanRptDtoA = buildingPlanRptDto.Clone();
                        buildingPlanRptDtoA.BuildingKey = buildingPlanBuilding.Key;
                        buildingPlanRptDtoA.BuildingName = buildingPlanBuilding.text;

                        if (buildingPlanDtoX.LinkData.Any(p => p.FromKey == buildingPlanRptDtoA.BuildingKey))
                        {
                            List<int> childFloorKeys = buildingPlanDtoX.LinkData.Where(p => p.FromKey == buildingPlanRptDtoA.BuildingKey).Select(f => f.ToKey).ToList<int>();
                            List<BuildingPlanNodeDataDto> buildingPlanFloors = buildingPlanDtoX.NodeData.Where(f => f.level == 3 && childFloorKeys.Contains(f.Key)).ToList() ??
                                new List<BuildingPlanNodeDataDto>();

                            foreach (BuildingPlanNodeDataDto buildingPlanFloor in buildingPlanFloors)
                            {
                                BuildingPlanModelRptDto buildingPlanRptDtoB = buildingPlanRptDtoA.Clone();
                                buildingPlanRptDtoB.LevelKey = buildingPlanFloor.Key;
                                buildingPlanRptDtoB.Level = buildingPlanFloor.text;


                                if (buildingPlanDtoX.LinkData.Any(p => p.FromKey == buildingPlanRptDtoB.LevelKey))
                                {
                                    List<int> childRoomKeys = buildingPlanDtoX.LinkData.Where(p => p.FromKey == buildingPlanRptDtoB.LevelKey).Select(f => f.ToKey).ToList<int>();
                                    List<BuildingPlanNodeDataDto> buildingPlanRooms = buildingPlanDtoX.NodeData.Where(f => f.level == 4 && childRoomKeys.Contains(f.Key)).ToList() ??
                                        new List<BuildingPlanNodeDataDto>();

                                    foreach (BuildingPlanNodeDataDto buildingPlanRoom in buildingPlanRooms)
                                    {
                                        BuildingPlanModelRptDto buildingPlanRptDtoC = buildingPlanRptDtoB.Clone();
                                        buildingPlanRptDtoC.RoomKey = buildingPlanRoom.Key;
                                        buildingPlanRptDtoC.Room = buildingPlanRoom.text;


                                        if (buildingPlanDtoX.LinkData.Any(p => p.FromKey == buildingPlanRptDtoC.RoomKey))
                                        {
                                            List<int> childDoorKeys = buildingPlanDtoX.LinkData.Where(p => p.FromKey == buildingPlanRptDtoC.RoomKey).Select(f => f.ToKey).ToList<int>();
                                            List<BuildingPlanNodeDataDto> buildingPlanDoors = buildingPlanDtoX.NodeData.Where(f => f.level == 5 && childDoorKeys.Contains(f.Key)).ToList() ??
                                                new List<BuildingPlanNodeDataDto>();

                                            foreach (BuildingPlanNodeDataDto buildingPlanDoor in buildingPlanDoors)
                                            {
                                                BuildingPlanModelRptDto buildingPlanRptDtoD = buildingPlanRptDtoC.Clone();
                                                buildingPlanRptDtoD.DoorKey = buildingPlanDoor.Key;
                                                buildingPlanRptDtoD.Door = buildingPlanDoor.text;

                                                buildingPlanRptDtoList.Add(buildingPlanRptDtoD);
                                            }
                                        }
                                        else {
                                            buildingPlanRptDtoList.Add(buildingPlanRptDtoC);
                                        }
                                    }
                                }
                                else {
                                    buildingPlanRptDtoList.Add(buildingPlanRptDtoB);
                                }
                            }
                        }
                        else
                        {
                            buildingPlanRptDtoList.Add(buildingPlanRptDtoA);
                        }
                    }
                }
                else
                {
                    buildingPlanRptDtoList.Add(buildingPlanRptDto);
                }
            }

            return buildingPlanRptDtoList;
        }

        public List<BuildingPlanPersonalRptDto> BuildingPlanLocationsPersonal()
        {
            List<BuildingPlanPersonalRptDto> locations = new List<BuildingPlanPersonalRptDto>();
            var buildingPlans = new BuildingPlanViewModel().BuildingPlans();
            foreach (var plan in buildingPlans)
            {
                var currentPlan = new BuildingPlanViewModel().GetBuildingPlanByID(plan.ID);
                if (currentPlan != null)
                {
                    var _planList = DeserializeBuildingPlan(currentPlan);
                    //var _planListX = DeserializeBuildingPlanX(currentPlan);
                    BuildingPlanPersonalRptDto locatioDto = new BuildingPlanPersonalRptDto();
                    locatioDto.ID = currentPlan.ID;
                    locatioDto.Nr = currentPlan.PlanNr;
                    locatioDto.LocationName = _planList.Find(x => x.level == "1") != null ? _planList.Find(x => x.level == "1").text : "";
                    if (!string.IsNullOrEmpty(locatioDto.LocationName))
                    {
                        locations.Add(locatioDto);
                    }
                    locatioDto.Building = _planList.Find(x => x.level == "2") != null ? _planList.Find(x => x.level == "2").text : "";
                    if (!string.IsNullOrEmpty(locatioDto.Building))
                    {
                        locations.Add(locatioDto);
                    }
                    locatioDto.level = _planList.Find(x => x.level == "3") != null ? _planList.Find(x => x.level == "3").text : "";
                    if (!string.IsNullOrEmpty(locatioDto.level))
                    {
                        locations.Add(locatioDto);
                    }
                    locatioDto.Rooms = _planList.Find(x => x.level == "4") != null ? _planList.Find(x => x.level == "4").text : "";
                    if (!string.IsNullOrEmpty(locatioDto.Rooms))
                    {
                        locations.Add(locatioDto);
                    }
                    locatioDto.Door = _planList.Find(x => x.level == "5") != null ? _planList.Find(x => x.level == "5").text : "";
                    if (!string.IsNullOrEmpty(locatioDto.Door))
                    {
                        locations.Add(locatioDto);
                    }

                }
            }
            return locations;
        }

        public List<BuildingPlanModelRptDto> BuildingPlanLocationsPersonal2()
        {
            List<BuildingPlanPersonalRptDto> locations = new List<BuildingPlanPersonalRptDto>();
            var buildingPlans = new BuildingPlanViewModel().BuildingPlans();
            List<BuildingPlanModelRptDto> buildingPlansDto = new List<BuildingPlanModelRptDto>();

            foreach (var plan in buildingPlans)
            {
                buildingPlansDto.AddRange(DeserializeBuildingPlanX(plan));
            }

            return buildingPlansDto;
        }

        public List<BuildingPlanModelRptDto> BuildingPlanModelForAccessGroup(long groupId, long buildingPlanId, long filterKey = 0, long filterLevel = 0)
        {
            List<BuildingPlanPersonalRptDto> locations = new List<BuildingPlanPersonalRptDto>();
            var plan = new BuildingPlanViewModel().GetBuildingPlanByID(buildingPlanId);
            List<BuildingPlanModelRptDto> buildingPlansDto = new List<BuildingPlanModelRptDto>();
            List<BuildingPlanModelRptDto> buildingPlansDtoView = new List<BuildingPlanModelRptDto>();
            List<AccessPlanGroupDoorMapping> assignedDoors = new AccessPlanGroupDoorMappingRepository().GetMappedGroupIdBuildingPlanId(groupId, buildingPlanId);
            List<View_TerminalReader> terminalReaders = new ViewTerminalReaderRepository().GetAllTerminals();

            buildingPlansDto.AddRange(DeserializeBuildingPlanX(plan, filterKey, filterLevel));

            var x = buildingPlansDto.GroupBy(p => p.BuildingID); //Building

            foreach (var y in x)
            {
                var z = y.Select(p => p).ToList();

                if (z.Count > 0)
                {
                    int pseudoDoors = -1;
                    buildingPlansDtoView.Add(GetBuildingPlanModelDto(ref pseudoDoors, assignedDoors, terminalReaders, BuildingKeyTypes.BuildingKey, z.FirstOrDefault()));
                    var x1 = z.GroupBy(p => p.LevelID); //Floor

                    foreach (var y1 in x1)
                    {
                        var z1 = y1.Select(p => p).ToList();

                        if (z1.Count > 0)
                        {
                            buildingPlansDtoView.Add(GetBuildingPlanModelDto(ref pseudoDoors, assignedDoors, terminalReaders, BuildingKeyTypes.FloorKey, z1.FirstOrDefault()));
                            var x2 = z1.GroupBy(p => p.RoomID); //Room

                            foreach (var y2 in x2)
                            {
                                var z2 = y2.Select(p => p).ToList();

                                if (z2.Count > 0)
                                {
                                    buildingPlansDtoView.Add(GetBuildingPlanModelDto(ref pseudoDoors, assignedDoors, terminalReaders, BuildingKeyTypes.RoomKey, z2.FirstOrDefault()));
                                    var x3 = z2.GroupBy(p => p.RoomID); //Door

                                    foreach (var y3 in x3)
                                    {
                                        var z3 = y3.Select(p => p).ToList();

                                        foreach (var door in z3.Skip(1))
                                        {
                                            buildingPlansDtoView.Add(GetBuildingPlanModelDto(ref pseudoDoors, assignedDoors, terminalReaders, BuildingKeyTypes.DoorKey, door));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return buildingPlansDtoView;
        }

        private static BuildingPlanModelRptDto GetBuildingPlanModelDto(ref int pseudoDoors, List<AccessPlanGroupDoorMapping> assignedDoors, List<View_TerminalReader> terminalReaders,
            BuildingKeyTypes buildingKeyType, BuildingPlanModelRptDto buildingPlanModelRptDto)
        {
            AccessPlanGroupDoorMapping thisDoor = assignedDoors.FirstOrDefault(d => d.BuildingPlanID == buildingPlanModelRptDto.BuildingPlanId &&
            d.DoorID == buildingPlanModelRptDto.DoorKey);
            View_TerminalReader terminalReader = terminalReaders.FirstOrDefault(d => d.BuildingPlanID == buildingPlanModelRptDto.BuildingPlanId &&
            d.DoorID == buildingPlanModelRptDto.DoorKey) ?? new View_TerminalReader();

            return new BuildingPlanModelRptDto()
            {
                BuildingPlanId = buildingPlanModelRptDto.BuildingPlanId,
                BuildingPlanName = buildingPlanModelRptDto.BuildingPlanName,
                LocationKey = buildingPlanModelRptDto.LocationKey,
                LocationName = buildingKeyType == BuildingKeyTypes.BuildingKey ? buildingPlanModelRptDto.LocationName : "",

                BuildingKey = buildingPlanModelRptDto.BuildingKey,
                BuildingName = buildingKeyType == BuildingKeyTypes.BuildingKey ? buildingPlanModelRptDto.BuildingName : "",

                LevelKey = buildingKeyType == BuildingKeyTypes.FloorKey ||
                                                buildingKeyType == BuildingKeyTypes.RoomKey || buildingKeyType == BuildingKeyTypes.DoorKey ? buildingPlanModelRptDto.LevelKey : pseudoDoors--,
                Level = buildingKeyType == BuildingKeyTypes.FloorKey ? buildingPlanModelRptDto.Level : "",

                RoomKey = buildingKeyType == BuildingKeyTypes.DoorKey ? buildingPlanModelRptDto.RoomKey : pseudoDoors--,
                Room = buildingKeyType == BuildingKeyTypes.RoomKey ? buildingPlanModelRptDto.Room : "",

                DoorKey = buildingKeyType == BuildingKeyTypes.RoomKey || buildingKeyType == BuildingKeyTypes.DoorKey ? buildingPlanModelRptDto.DoorKey : pseudoDoors--,
                Door = buildingKeyType == BuildingKeyTypes.RoomKey || buildingKeyType == BuildingKeyTypes.DoorKey ? buildingPlanModelRptDto.Door : "",

                Direction = buildingKeyType == BuildingKeyTypes.RoomKey || buildingKeyType == BuildingKeyTypes.DoorKey ? terminalReader.Direction ?? -1 : -1,
                DoorSelected = buildingKeyType == BuildingKeyTypes.RoomKey || buildingKeyType == BuildingKeyTypes.DoorKey ? thisDoor != null : false
            };
        }
    }
}