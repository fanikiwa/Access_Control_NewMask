using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.ViewModels
{
    public enum BuildingKeyTypes
    {
        BuildingPlanId = 1,
        LocationKey = 2,
        BuildingKey = 3,
        FloorKey = 4,
        RoomKey = 5,
        DoorKey = 6
    }

    public enum AccessLogType
    {
        Personal = 1, Visitor = 2, Member = 3
    }

    public enum ReportDisplayType
    {
        Object = 0, Personal = 1
    }

    public enum memberInfoReportType
    {
        Present = 1, Absent = 2, AllBookings = 3
    }

    public class AccessReportsViewModel
    {
        public List<AccessLogReportsDto> GetPersonalAccessLogs(AccessReportSettings_DTO acReport = null)
        {
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();
            List<View_AccessLogs> accessReports = new List<View_AccessLogs>();


            View_AccessLogsRepository _View_AccessLogsRepository = new View_AccessLogsRepository();
            PersDataRepository personalRepo = new PersDataRepository();

            accessReports = _getViewAccesslogsOverDateSelection(AccessLogType.Personal, acReport);

            if (acReport != null && acReport.StartLocationB != null)
            {
                FilterByPlanSelection(acReport, ref accessReports);
            }


            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();

            var allPersonal = personalRepo.GetAllPersonal();

            var personalAccessLogs = from accessLog in accessReports
                                     join personalData in allPersonal on accessLog.ID_Nr equals personalData.Pers_Nr
                                     select new
                                     {
                                         accessLog.ID,
                                         accessLog.Pers_Type,
                                         accessLog.ID_Nr,
                                         accessLog.Card_Nr,
                                         accessLog.FullName,
                                         accessLog.LastName,
                                         accessLog.FirstName,
                                         accessLog.ClientName,
                                         accessLog.AccessEndData,
                                         accessLog.TA_Come,
                                         accessLog.TA_Go,
                                         accessLog.BookingTime,
                                         accessLog.BookingCorrection,
                                         accessLog.DynamicField1,
                                         accessLog.LogID,
                                         accessLog.PlanDefinition,
                                         accessLog.BuildingPlanID,
                                         accessLog.LocationID,
                                         accessLog.BuildingID,
                                         accessLog.FloorID,
                                         accessLog.RoomID,
                                         accessLog.DoorID,
                                         PersClientID = personalData.ClientID,
                                         PersClientName = personalData.ClientName,
                                         persLocationID = personalData.LocationID,
                                         persLocationName = personalData.LocationName,
                                         persDepartmentID = personalData.DepartmentID,
                                         persDepartmentName = personalData.DepartmentName,
                                         persCostCcenterID = personalData.CostCenterID,
                                         persCostCenterName = personalData.CostCenterName,
                                     };



            if (acReport != null)
            {
                switch (acReport.Type)
                {
                    case (int)ReportDisplayType.Object:
                        personalAccessLogs = personalAccessLogs.OrderBy(x => x.BookingTime.Date).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ThenBy(x => x.BookingTime.Date).ThenBy(x => x.PersClientID).ThenBy(x => x.persLocationID).ThenBy(x => x.persDepartmentID).ThenBy(x => x.ID_Nr).ToList();
                        break;
                    case (int)ReportDisplayType.Personal:
                        personalAccessLogs = personalAccessLogs.OrderBy(x => x.BookingTime.Date).ThenBy(x => x.PersClientID).ThenBy(x => x.persLocationID).ThenBy(x => x.persDepartmentID).ThenBy(x => x.ID_Nr).ThenBy(x => x.BookingTime.Date).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ToList();
                        break;
                }
            }

            if (acReport != null)
            {

                if (acReport.StartPersonal != null && acReport.EndPersonal != null)
                {
                    if (acReport.StartPersonal > 0 && acReport.EndPersonal > 0)
                    {
                        if (acReport.EndPersonal >= acReport.StartPersonal)
                        {
                            personalAccessLogs = personalAccessLogs.Where(x => x.ID_Nr >= acReport.StartPersonal && x.ID_Nr <= acReport.EndPersonal).ToList();
                        }
                    }
                }

                if (acReport.StartClient != null && acReport.EndClient != null)
                {
                    if (acReport.StartClient > 0 && acReport.EndClient > 0)
                    {
                        if (acReport.EndClient >= acReport.StartClient)
                        {
                            var clients = new ClientsRepository().GetClients().Where(x => x.ID >= acReport.StartClient && x.ID <= acReport.EndClient).Select(x => x.Name).ToList();

                            personalAccessLogs = personalAccessLogs.Where(x => clients.Contains(x.PersClientName)).ToList();
                        }
                    }
                }

                if (acReport.StartLocation != null && acReport.EndLocation != null)
                {
                    if (acReport.StartLocation > 0 && acReport.EndLocation > 0)
                    {
                        if (acReport.EndLocation >= acReport.StartLocation)
                        {
                            var locations = new LocationRepository().GetLocations().Where(x => x.ID >= acReport.StartLocation && x.ID <= acReport.EndLocation).Select(x => x.Name).ToList();

                            personalAccessLogs = personalAccessLogs.Where(x => locations.Contains(x.persLocationName)).ToList();
                        }
                    }
                }

                if (acReport.StartDept != null && acReport.EndDept != null)
                {
                    if (acReport.StartDept > 0 && acReport.EndDept > 0)
                    {
                        if (acReport.EndDept >= acReport.StartDept)
                        {
                            var departments = new DepartmentRepository().GetDepartments().Where(x => x.ID >= acReport.StartDept && x.ID <= acReport.EndDept).Select(x => x.Name).ToList();

                            personalAccessLogs = personalAccessLogs.Where(x => departments.Contains(x.persDepartmentName)).ToList();
                        }
                    }
                }

                if (acReport.StartCostCenter != null && acReport.EndCostCenter != null)
                {
                    if (acReport.StartCostCenter > 0 && acReport.EndCostCenter > 0)
                    {
                        if (acReport.EndCostCenter >= acReport.StartCostCenter)
                        {
                            var costCenters = new CostCenterRepository().GetCostCenters().Where(x => x.ID >= acReport.StartCostCenter && x.ID <= acReport.EndCostCenter).Select(x => x.Name).ToList();

                            accessLogsReport = accessLogsReport.Where(x => costCenters.Contains(x.PersCostCenter)).ToList();
                        }
                    }
                }
            }

            //accessReports = accessReports.OrderBy(x=> x.BookingTime.Date).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ToList();


            string currentObjectGroupKey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", 0, 0, 0, 0, 0, 0);
            string currentPersonalGroupKey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", 0, 0, 0, 0, 0, 0);
            string currentOjectkey = string.Empty;
            string currentPersonalkey = string.Empty;

            foreach (var viewAccessLog in personalAccessLogs)
            {
                //var personal = personalRepo.GetPersDataByNr(viewAccessLog.ID_Nr);

                AccessLogReportsDto accessLogReport = new AccessLogReportsDto();
                accessLogReport.ID = Convert.ToInt64(viewAccessLog.ID);

                accessLogReport.BookingDate = viewAccessLog.BookingTime.Date;
                accessLogReport.BookingTime = viewAccessLog.BookingTime;

                if (acReport != null)
                {
                    accessLogReport.BookingDateFrom = Convert.ToDateTime(acReport.StartDate);
                    accessLogReport.BookingDateTo = Convert.ToDateTime(acReport.EndDate);
                    accessLogReport.BookingTimeFrom = Convert.ToDateTime(acReport.StartTime);
                    accessLogReport.BookingTimeTo = Convert.ToDateTime(acReport.EndTime);
                    accessLogReport.DurationSelection = acReport.DurationSelection;

                    var locationFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.LocationID == acReport.StartLocationB) ?? new BuildingPlanModelRptDto();
                    var locationTo = buildingPlanModelsRpt.FirstOrDefault(x => x.LocationID == acReport.EndLocationB) ?? new BuildingPlanModelRptDto();
                    var buildingFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.BuildingID == acReport.StartBuilding) ?? new BuildingPlanModelRptDto();
                    var buildingTo = buildingPlanModelsRpt.FirstOrDefault(x => x.BuildingID == acReport.EndBuilding) ?? new BuildingPlanModelRptDto();
                    var startCompany = new ClientsRepository().GetClientsById(Convert.ToInt64(acReport.StartClient)) ?? new Client();
                    var endCompany = new ClientsRepository().GetClientsById(Convert.ToInt64(acReport.EndClient)) ?? new Client();


                    accessLogReport.BPLocationFrom = locationFrom.LocationName;
                    accessLogReport.BPLocationTo = locationTo.LocationName;

                    accessLogReport.BPBuildingFrom = buildingFrom.BuildingName;
                    accessLogReport.BPBuildingTo = buildingTo.BuildingName;

                    accessLogReport.PersClientFrom = startCompany.Name;
                    accessLogReport.PersClientTo = endCompany.Name;
                }


                currentOjectkey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", viewAccessLog.BuildingPlanID, viewAccessLog.LocationID, viewAccessLog.BuildingID, viewAccessLog.FloorID, viewAccessLog.RoomID, viewAccessLog.DoorID);
                if (currentOjectkey != currentObjectGroupKey)
                {
                    currentObjectGroupKey = currentOjectkey;
                    _fillBuildingPlanDetails(viewAccessLog, ref accessLogReport);
                }

                currentPersonalkey = String.Format("{0}#{1}#{2}#{3}", viewAccessLog.PersClientID, viewAccessLog.persLocationID, viewAccessLog.persDepartmentID, viewAccessLog.ID_Nr);
                if (currentPersonalkey != currentPersonalGroupKey)
                {
                    currentPersonalGroupKey = currentPersonalkey;
                    accessLogReport.ID_Nr = viewAccessLog.ID_Nr;
                    accessLogReport.PersClient = viewAccessLog.PersClientName;
                    accessLogReport.PersDepartement = viewAccessLog.persDepartmentName;
                    accessLogReport.PersLocation = viewAccessLog.persLocationName;
                    accessLogReport.PersCostCenter = viewAccessLog.persCostCenterName;
                    accessLogReport.Name = viewAccessLog.FullName;
                    accessLogReport.CardNumber = viewAccessLog.Card_Nr.ToString();
                }

                accessLogsReport.Add(accessLogReport);
            }

            return accessLogsReport;
        }

        private void FilterByPlanSelection(AccessReportSettings_DTO acReport, ref List<View_AccessLogs> accessReports)
        {
            List<View_AccessLogs> _accessReports = new List<View_AccessLogs>();

            _accessReports = FilterLocations(acReport, accessReports);
            _accessReports = FilterBuildings(acReport, _accessReports);
            _accessReports = FilterFloors(acReport, _accessReports);
            _accessReports = FilterRooms(acReport, _accessReports);
            _accessReports = FilterDoors(acReport, _accessReports);

            accessReports = _accessReports;
        }

        private List<View_AccessLogs> FilterLocations(AccessReportSettings_DTO acReport, List<View_AccessLogs> accessReports)
        {
            List<View_AccessLogs> _accessReports = new List<View_AccessLogs>();
            long startBuildingPlanId = 0, endBuildingPlanId = 0, startPlanLocationId = 0, endPlanLocationId = 0;

            startBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.StartLocationB);
            endBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.EndLocationB);
            startPlanLocationId = GetBuildingKeyValue(BuildingKeyTypes.LocationKey, acReport.StartLocationB);
            endPlanLocationId = GetBuildingKeyValue(BuildingKeyTypes.LocationKey, acReport.EndLocationB);

            if (startBuildingPlanId == -1 || endBuildingPlanId == -1)
            {
                return accessReports;
            }

            if (startBuildingPlanId != endBuildingPlanId && startBuildingPlanId != -1 && endBuildingPlanId != -1)
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId &&
                    x.LocationID >= startPlanLocationId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID > startBuildingPlanId &&
                    x.LocationID < endBuildingPlanId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == endBuildingPlanId &&
                    x.LocationID <= endPlanLocationId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }
            else
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId
                    && x.LocationID >= startPlanLocationId && x.LocationID <= endPlanLocationId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }

            return _accessReports;
        }

        private List<View_AccessLogs> FilterBuildings(AccessReportSettings_DTO acReport, List<View_AccessLogs> accessReports)
        {
            List<View_AccessLogs> _accessReports = new List<View_AccessLogs>();
            long startBuildingPlanId = 0, endBuildingPlanId = 0, startPlanBuildingId = 0, endPlanBuildingId = 0;

            startBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.StartBuilding);
            endBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.EndBuilding);
            startPlanBuildingId = GetBuildingKeyValue(BuildingKeyTypes.BuildingKey, acReport.StartBuilding);
            endPlanBuildingId = GetBuildingKeyValue(BuildingKeyTypes.BuildingKey, acReport.EndBuilding);

            if (startPlanBuildingId == -1 || endPlanBuildingId == -1)
            {
                return accessReports;
            }

            if (startPlanBuildingId != endPlanBuildingId && startBuildingPlanId != -1 && endBuildingPlanId != -1)
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId &&
                    x.BuildingID >= startPlanBuildingId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID > startBuildingPlanId &&
                    x.BuildingPlanID < endBuildingPlanId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == endBuildingPlanId &&
                    x.BuildingID <= endPlanBuildingId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }
            else
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId
                    && x.BuildingID >= startPlanBuildingId && x.BuildingID <= endPlanBuildingId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }

            return _accessReports;
        }

        private List<View_AccessLogs> FilterFloors(AccessReportSettings_DTO acReport, List<View_AccessLogs> accessReports)
        {
            List<View_AccessLogs> _accessReports = new List<View_AccessLogs>();
            long startBuildingPlanId = 0, endBuildingPlanId = 0, startPlanFloorId = 0, endPlanFloorId = 0;

            startBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.StartLevel);
            endBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.EndLevel);
            startPlanFloorId = GetBuildingKeyValue(BuildingKeyTypes.FloorKey, acReport.StartLevel);
            endPlanFloorId = GetBuildingKeyValue(BuildingKeyTypes.FloorKey, acReport.EndLevel);

            if (startPlanFloorId == -1 || endPlanFloorId == -1)
            {
                return accessReports;
            }

            if (startBuildingPlanId != endBuildingPlanId && startBuildingPlanId != -1 && endBuildingPlanId != -1)
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId &&
                    x.FloorID >= startPlanFloorId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID > startBuildingPlanId &&
                    x.BuildingPlanID < endBuildingPlanId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == endBuildingPlanId &&
                    x.FloorID <= endPlanFloorId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }
            else
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId
                    && x.FloorID >= startPlanFloorId && x.FloorID <= endPlanFloorId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }

            return _accessReports;
        }

        private List<View_AccessLogs> FilterRooms(AccessReportSettings_DTO acReport, List<View_AccessLogs> accessReports)
        {
            List<View_AccessLogs> _accessReports = new List<View_AccessLogs>();
            long startBuildingPlanId = 0, endBuildingPlanId = 0, startPlanRoomId = 0, endPlanRoomId = 0;

            startBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.StartRoom);
            endBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.EndRoom);
            startPlanRoomId = GetBuildingKeyValue(BuildingKeyTypes.RoomKey, acReport.StartRoom);
            endPlanRoomId = GetBuildingKeyValue(BuildingKeyTypes.RoomKey, acReport.EndRoom);

            if (startPlanRoomId == -1 || endPlanRoomId == -1)
            {
                return accessReports;
            }

            if (startBuildingPlanId != endBuildingPlanId && startBuildingPlanId != -1 && endBuildingPlanId != -1)
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId &&
                    x.RoomID >= startPlanRoomId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID > startBuildingPlanId &&
                    x.BuildingPlanID < endBuildingPlanId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == endBuildingPlanId &&
                    x.RoomID <= endPlanRoomId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }
            else
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId
                    && x.RoomID >= startPlanRoomId && x.RoomID <= endPlanRoomId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }

            return _accessReports;
        }

        private List<View_AccessLogs> FilterDoors(AccessReportSettings_DTO acReport, List<View_AccessLogs> accessReports)
        {
            List<View_AccessLogs> _accessReports = new List<View_AccessLogs>();
            long startBuildingPlanId = 0, endBuildingPlanId = 0, startPlanDoorId = 0, endPlanDoorId = 0;

            startBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.StartDoor);
            endBuildingPlanId = GetBuildingKeyValue(BuildingKeyTypes.BuildingPlanId, acReport.EndDoor);
            startPlanDoorId = GetBuildingKeyValue(BuildingKeyTypes.DoorKey, acReport.StartDoor);
            endPlanDoorId = GetBuildingKeyValue(BuildingKeyTypes.DoorKey, acReport.EndDoor);

            if (startPlanDoorId == -1 || endPlanDoorId == -1)
            {
                return accessReports;
            }

            if (startBuildingPlanId != endBuildingPlanId && startBuildingPlanId != -1 && endBuildingPlanId != -1)
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId &&
                    x.DoorID >= startPlanDoorId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID > startBuildingPlanId &&
                    x.BuildingPlanID < endBuildingPlanId).ToList() ??
                    new List<View_AccessLogs>()
                    );
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == endBuildingPlanId &&
                    x.DoorID <= endPlanDoorId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }
            else
            {
                _accessReports.AddRange(
                    accessReports.Where(x => x.BuildingPlanID == startBuildingPlanId
                    && x.DoorID >= startPlanDoorId && x.DoorID <= endPlanDoorId).ToList() ??
                    new List<View_AccessLogs>()
                    );
            }

            return _accessReports;
        }

        public long GetBuildingKeyValue(BuildingKeyTypes keyType, string keyString)
        {
            long returnValue = 0;
            string[] keyStrings = keyString.Split('#');

            if (keyStrings.Length >= (long)keyType)
            {
                Int64.TryParse(keyStrings[(long)keyType - 1], out returnValue);
            }

            return returnValue;
        }

        private void _fillBuildingPlanDetails(dynamic _viewAccessLog, ref AccessLogReportsDto _accessLogReportsDto)
        {
            if (string.IsNullOrEmpty(_viewAccessLog.PlanDefinition) == false)
            {
                JObject jsonPlan = JObject.Parse(_viewAccessLog.PlanDefinition);
                Newtonsoft.Json.Linq.JObject buildingPlan = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(_viewAccessLog.PlanDefinition.ToString());
                var nodeData = buildingPlan["model"]["nodeDataArray"];

                List<BuildingPlanDto> nodeArray = JsonConvert.DeserializeObject<List<BuildingPlanDto>>(nodeData.ToString());
                BuildingPlanDto node = new BuildingPlanDto();

                // location name
                node = nodeArray.Where(x => x.Key == Convert.ToString(_viewAccessLog.LocationID)).FirstOrDefault();
                _accessLogReportsDto.BPLocation = node.text;
                //building name
                node = nodeArray.Where(x => x.Key == Convert.ToString(_viewAccessLog.BuildingID)).FirstOrDefault();
                _accessLogReportsDto.BPBuilding = node.text;
                //floor Name
                node = nodeArray.Where(x => x.Key == Convert.ToString(_viewAccessLog.FloorID)).FirstOrDefault();
                _accessLogReportsDto.BPLevel = node.text;
                // room name
                node = nodeArray.Where(x => x.Key == Convert.ToString(_viewAccessLog.RoomID)).FirstOrDefault();
                _accessLogReportsDto.BPRoom = node.text;
                // door name
                node = nodeArray.Where(x => x.Key == Convert.ToString(_viewAccessLog.DoorID)).FirstOrDefault();
                _accessLogReportsDto.BPDoor = node.text;
            }

        }

        private List<View_AccessLogs> _getViewAccesslogsOverDateSelection(AccessLogType _accesslogType, AccessReportSettings_DTO acReport = null)
        {
            DateTime bookingDateFrom = DateTime.MinValue;
            DateTime bookingDateTo = DateTime.MaxValue;
            List<View_AccessLogs> accessReports = new List<View_AccessLogs>();
            View_AccessLogsRepository _View_AccessLogsRepository = new View_AccessLogsRepository();

            if (acReport != null)
            {
                bookingDateFrom = Convert.ToDateTime(acReport.StartDate).Date;
                bookingDateTo = Convert.ToDateTime(acReport.EndDate).Date;

                if (bookingDateTo >= bookingDateFrom)
                {

                    if (acReport.StartTime != DateTime.MinValue && acReport.StartTime != null)
                    {
                        bookingDateFrom = bookingDateFrom + Convert.ToDateTime(acReport.StartTime).TimeOfDay;
                    }

                    if (acReport.EndTime != DateTime.MinValue && acReport.EndTime != null)
                    {
                        bookingDateTo = bookingDateTo + Convert.ToDateTime(acReport.EndTime).TimeOfDay;
                    }
                    else
                    {
                        TimeSpan ts = new TimeSpan(23, 59, 0); //make last minute of day
                        bookingDateTo = bookingDateTo + ts;
                    }

                    accessReports = _View_AccessLogsRepository.GetAllAccessLogsOverDateSelectionAndPersType(bookingDateFrom, bookingDateTo, (int)_accesslogType);
                }
                else
                {
                    accessReports = _View_AccessLogsRepository.GetAllAccessLogsOverPersType((int)_accesslogType);
                }
            }
            else
            {
                accessReports = _View_AccessLogsRepository.GetAllAccessLogsOverPersType((int)_accesslogType);
            }

            return accessReports;
        }

        public List<AccessLogReportsDto> GetVisitorAccessLogs(bool addAbsentVisitors, AccessReportSettings_DTO acReport = null)
        {
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();
            List<View_AccessLogs> accessReports = new List<View_AccessLogs>();


            View_AccessLogsRepository _View_AccessLogsRepository = new View_AccessLogsRepository();
            VisitorRepository visitorRepo = new VisitorRepository();

            var allVisitors = visitorRepo.GetAllVisitors();

            accessReports = _getViewAccesslogsOverDateSelection(AccessLogType.Visitor, acReport);

            FilterByPlanSelection(acReport, ref accessReports);

            if (acReport != null)
            {
                switch (acReport.Type)
                {
                    case (int)ReportDisplayType.Object:
                        accessReports = accessReports.OrderBy(x => x.BookingTime.Date).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ThenBy(x => x.ClientName).ThenBy(x => x.ID_Nr).ToList();
                        break;
                    case (int)ReportDisplayType.Personal:
                        accessReports = accessReports.OrderBy(x => x.BookingTime.Date).ThenBy(x => x.ClientName).ThenBy(x => x.ID_Nr).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ToList();
                        break;
                }

                if(acReport.StartPersonal != null && acReport.StartPersonal > 0 && acReport.EndPersonal != null && acReport.EndPersonal > 0 && acReport.EndPersonal >= acReport.StartPersonal)
                {
                    accessReports = accessReports.Where(x => x.ID_Nr >= acReport.StartPersonal && x.ID_Nr <= acReport.EndPersonal).ToList();
                }

                if (acReport.StartClient != null && acReport.StartClient > 0 && acReport.EndClient != null && acReport.EndClient > 0 && acReport.EndClient >= acReport.StartClient)
                {

                    var allClients = new VisitorCompanyRepository().GetAllVisitorCompanies().Where(x => x.ID >= acReport.StartClient && x.ID <= acReport.EndClient).ToList();
                    var clientNames = allClients.Select(x => x.Name).ToList();
                    accessReports = accessReports.Where(x => clientNames.Contains(x.ClientName)).ToList();
                }

                if (acReport.StartShortTransponder != null && acReport.StartShortTransponder > 0 && acReport.EndShortTranspoder != null && acReport.EndShortTranspoder > 0 && acReport.EndShortTranspoder >= acReport.StartShortTransponder)
                {
                    var filterTransponders = new VisitorTranspondersRepository().GetAllVisitorTransponders().Where(x => x.ID >= acReport.StartShortTransponder && x.ID <= acReport.EndShortTranspoder).ToList();
                    var filterTranspondersNumbers = filterTransponders.Select(x => x.TransponderNr).ToList();
                    accessReports = accessReports.Where(x => filterTranspondersNumbers.Contains(x.Card_Nr)).ToList();
                }
            }

            string currentObjectGroupKey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", 0, 0, 0, 0, 0, 0);
            string currentVisitorGroupKey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", 0, 0, 0, 0, 0, 0);
            string currentOjectkey = string.Empty;
            string currentVisitorkey = string.Empty;

            foreach (var viewAccessLog in accessReports)
            {
                var visitor = allVisitors.Where(x => x.VisitorID == viewAccessLog.ID_Nr).FirstOrDefault();

                AccessLogReportsDto accessLogReport = new AccessLogReportsDto();
                accessLogReport.ID = Convert.ToInt64(viewAccessLog.ID);

                //accessLogReport.Name = viewAccessLog.FullName;
                //accessLogReport.CardNumber = viewAccessLog.Card_Nr.ToString();

                accessLogReport.BookingDate = viewAccessLog.BookingTime.Date;
                accessLogReport.BookingTime = viewAccessLog.BookingTime;

                currentOjectkey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", viewAccessLog.BuildingPlanID, viewAccessLog.LocationID, viewAccessLog.BuildingID, viewAccessLog.FloorID, viewAccessLog.RoomID, viewAccessLog.DoorID);
                if (currentOjectkey != currentObjectGroupKey)
                {
                    currentObjectGroupKey = currentOjectkey;
                    _fillBuildingPlanDetails(viewAccessLog, ref accessLogReport);
                }

                currentVisitorkey = String.Format("{0}#{1}", viewAccessLog.ClientName, viewAccessLog.ID_Nr);

                if (currentVisitorkey != currentVisitorGroupKey)
                {
                    currentVisitorGroupKey = currentVisitorkey;
                    accessLogReport.PersClient = viewAccessLog.ClientName;
                    accessLogReport.Name = viewAccessLog.FullName;
                    accessLogReport.CardNumber = viewAccessLog.Card_Nr.ToString();
                    accessLogReport.CardNumbershort = viewAccessLog.Card_Nr.ToString();
                }

                accessLogsReport.Add(accessLogReport);
            }

            if(addAbsentVisitors)
            {
                var presentVisitors = accessReports.Select(x => x.ID_Nr).ToList();

                var absentVisitors = allVisitors.Where(x => presentVisitors.Contains(x.VisitorID) == false).ToList();

                foreach(var absentVisitor in absentVisitors)
                {
                    AccessLogReportsDto accessLogReport = new AccessLogReportsDto();
                    accessLogReport.ID = Convert.ToInt64(absentVisitor.VisitorID);
                    accessLogReport.Name = absentVisitor.SurName + " " + absentVisitor.Fullname;
                    //accessLogReport.BookingDate = Convert.ToDateTime(acReport.StartDate).Date;

                    if (absentVisitor.VisitorCompanyTb != null)
                    {
                        accessLogReport.PersClient = absentVisitor.VisitorCompanyTb.CompanyName;
                    }
                    
                    if(absentVisitor.VisitorTransponders.Where(x=> x.TransponderStatus == true).FirstOrDefault() != null)
                    {
                        accessLogReport.CardNumber = absentVisitor.VisitorTransponders.Where(x => x.TransponderStatus == true).FirstOrDefault().TransponderNr.ToString();
                    }
                    
                    accessLogReport.CardNumbershort = string.Empty;
                    accessLogsReport.Add(accessLogReport);
                }
            }

            return accessLogsReport;
        }

        public List<AccessLogReportsDto> GetMemberAccessLogs(AccessReportSettings_DTO acReport = null)
        {
            List<AccessLogReportsDto> accessLogsReport = new List<AccessLogReportsDto>();
            List<View_AccessLogs> accessReports = new List<View_AccessLogs>();

            View_AccessLogsRepository _View_AccessLogsRepository = new View_AccessLogsRepository();
            MemberGroupsRepositories memberGroupRepo = new MemberGroupsRepositories();
            MembersDataRepository memberDataRepo = new MembersDataRepository();

            var allMembers = memberDataRepo.GetAllMembersData();
            var allMembersGroups = memberGroupRepo.GetAllMemberGroups();

            accessReports = _getViewAccesslogsOverDateSelection(AccessLogType.Member, acReport);
            FilterByPlanSelection(acReport, ref accessReports);

            var memberAccessLogs = from accessLog in accessReports
                                   join memberData in allMembers on accessLog.ID_Nr equals memberData.MemberNumber
                                   select new
                                   {
                                       accessLog.ID,
                                       accessLog.Pers_Type,
                                       accessLog.ID_Nr,
                                       accessLog.Card_Nr,
                                       accessLog.FullName,
                                       accessLog.LastName,
                                       accessLog.FirstName,
                                       accessLog.ClientName,
                                       accessLog.AccessEndData,
                                       accessLog.TA_Come,
                                       accessLog.TA_Go,
                                       accessLog.BookingTime,
                                       accessLog.BookingCorrection,
                                       accessLog.DynamicField1,
                                       accessLog.LogID,
                                       accessLog.PlanDefinition,
                                       accessLog.BuildingPlanID,
                                       accessLog.LocationID,
                                       accessLog.BuildingID,
                                       accessLog.FloorID,
                                       accessLog.RoomID,
                                       accessLog.DoorID,
                                       MemberID = memberData.ID,
                                       MemberGroupNumber = (allMembersGroups.Where(x => x.Id == (memberData.MemberGroupId ?? 0)).FirstOrDefault() ?? new MemberGroup()).GroupNr,
                                       MemberGroupName = (allMembersGroups.Where(x => x.Id == (memberData.MemberGroupId ?? 0)).FirstOrDefault() ?? new MemberGroup()).GroupName,
                                   };

            if (acReport != null)
            {
                switch (acReport.Type)
                {
                    case (int)ReportDisplayType.Object:
                        memberAccessLogs = memberAccessLogs.OrderBy(x => x.BookingTime.Date).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ThenBy(x => x.MemberGroupNumber).ThenBy(x => x.ID_Nr).ToList();
                        break;
                    case (int)ReportDisplayType.Personal:
                        memberAccessLogs = memberAccessLogs.OrderBy(x => x.BookingTime.Date).ThenBy(x => x.MemberGroupNumber).ThenBy(x => x.ID_Nr).ThenBy(x => x.BuildingPlanID).ThenBy(x => x.LocationID).ThenBy(x => x.BuildingID).ThenBy(x => x.FloorID).ThenBy(x => x.RoomID).ThenBy(x => x.DoorID).ToList();
                        break;
                }
            }

            string currentObjectGroupKey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", 0, 0, 0, 0, 0, 0);
            string currentMemberGroupKey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", 0, 0, 0, 0, 0, 0);
            string currentOjectkey = string.Empty;
            string currentMemberkey = string.Empty;

            List<BuildingPlanModelRptDto> buildingPlanModelsRpt = ZUTMain.LoadSessionItem<List<BuildingPlanModelRptDto>>("PersRpt_BuildingPlanModelsRpt") ??
                new List<BuildingPlanModelRptDto>();


            foreach (var viewAccessLog in memberAccessLogs)
            {

                AccessLogReportsDto accessLogReport = new AccessLogReportsDto();
                accessLogReport.ID = Convert.ToInt64(viewAccessLog.ID);

                accessLogReport.BookingDate = viewAccessLog.BookingTime.Date;
                accessLogReport.BookingTime = viewAccessLog.BookingTime;

                currentOjectkey = String.Format("{0}#{1}#{2}#{3}#{4}#{5}", viewAccessLog.BuildingPlanID, viewAccessLog.LocationID, viewAccessLog.BuildingID, viewAccessLog.FloorID, viewAccessLog.RoomID, viewAccessLog.DoorID);
                if (currentOjectkey != currentObjectGroupKey)
                {
                    currentObjectGroupKey = currentOjectkey;
                    _fillBuildingPlanDetails(viewAccessLog, ref accessLogReport);
                }

                currentMemberkey = String.Format("{0}#{1}", viewAccessLog.MemberGroupNumber, viewAccessLog.ID_Nr);
                if (currentMemberkey != currentMemberGroupKey)
                {
                    currentMemberGroupKey = currentMemberkey;
                    accessLogReport.MemberGroup = viewAccessLog.MemberGroupName;
                    accessLogReport.Name = viewAccessLog.FullName;
                    accessLogReport.CardNumber = viewAccessLog.Card_Nr.ToString();
                    accessLogReport.CardNumbershort = string.Empty;
                }

                var locationFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.LocationID == acReport.StartLocationB) ?? new BuildingPlanModelRptDto();
                var locationTo = buildingPlanModelsRpt.FirstOrDefault(x => x.LocationID == acReport.EndLocationB) ?? new BuildingPlanModelRptDto();
                var buildingFrom = buildingPlanModelsRpt.FirstOrDefault(x => x.BuildingID == acReport.StartBuilding) ?? new BuildingPlanModelRptDto();
                var buildingTo = buildingPlanModelsRpt.FirstOrDefault(x => x.BuildingID == acReport.EndBuilding) ?? new BuildingPlanModelRptDto();



                accessLogReport.BPLocationFrom = locationFrom.LocationName;
                accessLogReport.BPLocationTo = locationTo.LocationName;
                accessLogReport.BPBuildingFrom = buildingFrom.BuildingName;
                accessLogReport.BPBuildingTo = buildingTo.BuildingName;
                accessLogReport.MemberGroupFrom = (allMembersGroups.Where(x => x.Id == acReport.StartMemberGroup).FirstOrDefault() ?? new MemberGroup()).GroupName;
                accessLogReport.MemberGroupTo = (allMembersGroups.Where(x => x.Id == acReport.EndMemberGroup).FirstOrDefault() ?? new MemberGroup()).GroupName;
                accessLogReport.BookingDateFrom = Convert.ToDateTime(acReport.StartDate);
                accessLogReport.BookingDateTo = Convert.ToDateTime(acReport.EndDate);
                accessLogReport.BookingTimeFrom = Convert.ToDateTime(acReport.StartTime);
                accessLogReport.BookingTimeTo = Convert.ToDateTime(acReport.EndTime);

                accessLogsReport.Add(accessLogReport);
            }

            return accessLogsReport;
        }

        public List<AccessLogReportsDto> GetMemberAttendanceLogs(bool filterByAttendanceState, AccessReportSettings_DTO acReport = null)
        {
            List<AccessLogReportsDto> memberAttendanceList = new List<AccessLogReportsDto>();
            AccessLogReportsDto accessLogReport = new AccessLogReportsDto();

            MembersDataRepository membersDataRepo = new MembersDataRepository();
            MemberGroupsRepositories memberGroupRepo = new MemberGroupsRepositories();
            MembersTranspondersRepository cardNumberRepo = new MembersTranspondersRepository();
            TimeSpan totalDuration = new TimeSpan();
            TimeSpan currentDuration = new TimeSpan();


            var allDayBookings = _getViewAccesslogsOverDateSelection(AccessLogType.Member, acReport);

            var allMembers = membersDataRepo.GetAllMembersData();
            var allMemberGroups = memberGroupRepo.GetAllMemberGroups();
            var allMemberCards = cardNumberRepo.GetAllMemberTransponders();

            var memberAttendanceLogs = from memberData in allMembers
                                       join memberGroup in allMemberGroups on memberData.MemberGroupId equals memberGroup.Id into ps
                                       from p in ps.DefaultIfEmpty(new MemberGroup())
                                       select new
                                       {
                                           ID = memberData.ID,
                                           GroupID = p.Id,
                                           p.GroupName,
                                           memberData.MemberNumber,
                                           Name = memberData.SurName + ' ' + memberData.FirstName,
                                           memberData.AgreementNr,
                                           CardNumberLong = (allMemberCards.Where(x => x.MemberID == memberData.ID && x.TransponderType == 1).FirstOrDefault() ?? new MembersTransponder()).TransponderNr,
                                           CardExpiryCard = (allMemberCards.Where(x => x.MemberID == memberData.ID && x.TransponderType == 1).FirstOrDefault() ?? new MembersTransponder()).ValidTo,
                                           EntryDate = memberData.EntryDate,
                                           ExitDate = memberData.ExitDate,
                                       };


            bool displayMember = false;

            foreach (var member in memberAttendanceLogs)
            {
                displayMember = false;
                List<View_AccessLogs> memberDayBookings = allDayBookings.Where(x => x.ID_Nr == member.MemberNumber).ToList();

                while (true)
                {
                    if (filterByAttendanceState)
                    {
                        switch (acReport.MemberDataReportType)
                        {
                            case (int)memberInfoReportType.Present:
                                displayMember = (memberDayBookings.Count() % 2) != 0;
                                break;
                            case (int)memberInfoReportType.Absent:
                                displayMember = (memberDayBookings.Count() % 2) == 0;
                                break;
                            case (int)memberInfoReportType.AllBookings:
                                displayMember = memberDayBookings.Count() > 0;
                                break;
                        }
                    }
                    else
                    {
                        displayMember = memberDayBookings.Count() > 0;
                    }


                    if (displayMember)
                    {
                        accessLogReport = new AccessLogReportsDto();
                        accessLogReport.BookingDate = Convert.ToDateTime(acReport.StartDate);
                        accessLogReport.ID = Convert.ToInt64(member.ID);
                        accessLogReport.MemberGroup = member.GroupName;
                        accessLogReport.Name = member.Name;
                        accessLogReport.CardNumber = member.CardNumberLong.ToString();
                        accessLogReport.ExpiryDate = member.CardExpiryCard;
                        accessLogReport.BookingDateFrom = Convert.ToDateTime(acReport.StartDate);
                        accessLogReport.BookingDateTo = Convert.ToDateTime(acReport.EndDate);
                        accessLogReport.ID_Nr = Convert.ToInt64(member.MemberNumber);

                        accessLogReport.MemberGroupFrom = (allMemberGroups.Where(x => x.Id == acReport.StartMemberGroup).FirstOrDefault() ?? new MemberGroup()).GroupName;
                        accessLogReport.MemberGroupTo = (allMemberGroups.Where(x => x.Id == acReport.EndMemberGroup).FirstOrDefault() ?? new MemberGroup()).GroupName;

                        var goBookings = memberDayBookings.ToList().Where((c, i) => i % 2 != 0).ToList();
                        var comeBookings = memberDayBookings.ToList().Where((c, i) => i % 2 == 0).ToList();

                        if (comeBookings.Count() > 0)
                        {
                            accessLogReport.EntryDate = comeBookings.FirstOrDefault().BookingTime;
                            accessLogReport.EntryTimeText = comeBookings.FirstOrDefault().BookingTime.ToString("HH:mm");
                        }

                        if (goBookings.Count() > 0)
                        {
                            accessLogReport.ExitDate = goBookings.LastOrDefault().BookingTime;
                            accessLogReport.ExitTimeText = goBookings.LastOrDefault().BookingTime.ToString("HH:mm");
                        }


                        currentDuration = Controllers.TimeDurationCalculator.CalculateTimeDuration(memberDayBookings.Select(x => x.BookingTime).ToList());
                        totalDuration = totalDuration.Add(currentDuration);

                        accessLogReport.Duration = new DateTime(2001, 1, 1).Add(currentDuration);
                        accessLogReport.DurationTimespan = currentDuration;
                        accessLogReport.DurationText = currentDuration.ToString(@"hh\:mm");

                        memberAttendanceList.Add(accessLogReport);
                    }
                    break;
                }

            }
            return memberAttendanceList;
        }

        public List<AccessLogReportsDto> GetPersonalAttendanceLogs(bool filterByAttendanceState = false, AccessReportSettings_DTO acReport = null)
        {
            List<AccessLogReportsDto> personalAttendanceList = new List<AccessLogReportsDto>();
            AccessLogReportsDto accessLogReport = new AccessLogReportsDto();
            TimeSpan totalDuration = new TimeSpan();
            TimeSpan currentDuration = new TimeSpan();

            PersDataRepository personalRepo = new PersDataRepository();

            var allDayBookings = _getViewAccesslogsOverDateSelection(AccessLogType.Personal, acReport);

            var allPersonal = personalRepo.GetAllPersonal();

            var allClients = new ClientsRepository().GetClients();
            var allLocation = new LocationRepository().GetLocations();
            var allCostCenters = new CostCenterRepository().GetCostCenters();
            var allDepartments = new DepartmentRepository().GetDepartments();
            var allTransponders = new PersTranspondersRepository().GetAllPersTransponders();

            bool displayPersonal = false;

            foreach (var personal in allPersonal)
            {
                displayPersonal = false;
                List<View_AccessLogs> memberDayBookings = allDayBookings.Where(x => x.ID_Nr == personal.Pers_Nr).ToList();
                while (true)
                {

                    if (filterByAttendanceState)
                    {
                        switch (acReport.MemberDataReportType)
                        {
                            case (int)memberInfoReportType.Present:
                                displayPersonal = (memberDayBookings.Count() % 2) != 0;
                                break;
                            case (int)memberInfoReportType.Absent:
                                displayPersonal = (memberDayBookings.Count() % 2) == 0;
                                break;
                            case (int)memberInfoReportType.AllBookings:
                                displayPersonal = memberDayBookings.Count() > 0;
                                break;
                        }
                    }
                    else
                    {
                        displayPersonal = memberDayBookings.Count() > 0;
                    }


                    // displayPersonal = memberDayBookings.Count() > 0;

                    if (displayPersonal)
                    {
                        accessLogReport = new AccessLogReportsDto();
                        //accessLogReport.BookingDate = Convert.ToDateTime(acReport.StartDate);
                        //accessLogReport.ID = Convert.ToInt64(member.ID);
                        //accessLogReport.MemberGroup = member.GroupName;
                        //accessLogReport.Name = member.Name;
                        //accessLogReport.CardNumber = member.CardNumberLong.ToString();
                        //accessLogReport.ExpiryDate = member.CardExpiryCard;

                        accessLogReport.BookingDate = Convert.ToDateTime(acReport.StartDate);
                        accessLogReport.ID = Convert.ToInt64(personal.Pers_Nr);
                        accessLogReport.PersonID = Convert.ToInt64(personal.Pers_Nr);
                        accessLogReport.PersClient = personal.ClientName;
                        accessLogReport.PersDepartement = personal.DepartmentName;
                        accessLogReport.PersLocation = personal.LocationName;
                        accessLogReport.PersCostCenter = personal.CostCenterName;
                        accessLogReport.Name = personal.FullName;
                        accessLogReport.CardNumber = personal.Card_Nr.ToString();
                        accessLogReport.ExpiryDate = (allTransponders.Where(x => x.TransponderNr == personal.Card_Nr).FirstOrDefault() ?? new Pers_Transponders()).ValidTo;

                        accessLogReport.BookingDateFrom = Convert.ToDateTime(acReport.StartDate);
                        accessLogReport.BookingDateTo = Convert.ToDateTime(acReport.EndDate);
                        accessLogReport.PersCostCenterFrom = (allCostCenters.Where(x => x.ID == acReport.StartCostCenter).FirstOrDefault() ?? new CostCenter()).Name;
                        accessLogReport.PersCostCenterTo = (allCostCenters.Where(x => x.ID == acReport.EndCostCenter).FirstOrDefault() ?? new CostCenter()).Name;
                        accessLogReport.PersClientFrom = (allClients.Where(x => x.ID == acReport.StartClient).FirstOrDefault() ?? new Client()).Name;
                        accessLogReport.PersClientTo = (allClients.Where(x => x.ID == acReport.EndClient).FirstOrDefault() ?? new Client()).Name;
                        accessLogReport.PersLocationFrom = (allLocation.Where(x => x.ID == acReport.StartLocation).FirstOrDefault() ?? new Location()).Name;
                        accessLogReport.PersLocationTo = (allLocation.Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Location()).Name;
                        accessLogReport.PersDepartementFrom = (allDepartments.Where(x => x.ID == acReport.StartDept).FirstOrDefault() ?? new Department()).Name;
                        accessLogReport.PersDepartementTo = (allDepartments.Where(x => x.ID == acReport.EndDept).FirstOrDefault() ?? new Department()).Name;
                        //accessLogReport.PersDepartementFrom = acReport.StartDept.ToString();
                        //accessLogReport.PersDepartementTo = acReport.EndDept.ToString();

                        var goBookings = memberDayBookings.ToList().Where((c, i) => i % 2 != 0).ToList();
                        var comeBookings = memberDayBookings.ToList().Where((c, i) => i % 2 == 0).ToList();

                        if (comeBookings.Count() > 0)
                        {
                            accessLogReport.EntryDate = comeBookings.FirstOrDefault().BookingTime;
                            accessLogReport.EntryTimeText = comeBookings.FirstOrDefault().BookingTime.ToString("HH:mm");
                        }

                        if (goBookings.Count() > 0)
                        {
                            accessLogReport.ExitDate = goBookings.LastOrDefault().BookingTime;
                            accessLogReport.ExitTimeText = goBookings.LastOrDefault().BookingTime.ToString("HH:mm");
                        }

                        currentDuration = Controllers.TimeDurationCalculator.CalculateTimeDuration(memberDayBookings.Select(x => x.BookingTime).ToList());
                        totalDuration = totalDuration.Add(currentDuration);

                        accessLogReport.Duration = new DateTime(2001, 1, 1).Add(currentDuration);
                        accessLogReport.DurationTimespan = currentDuration;
                        accessLogReport.DurationText = currentDuration.ToString(@"hh\:mm");

                        personalAttendanceList.Add(accessLogReport);
                    }
                    break;
                }

            }

            if (acReport != null)
            {
                if (acReport.StartClient != null && acReport.EndClient != null)
                {
                    if (acReport.StartClient > 0 && acReport.EndClient > 0)
                    {
                        if (acReport.EndClient >= acReport.StartClient)
                        {
                            var clients = new ClientsRepository().GetClients().Where(x => x.ID >= acReport.StartClient && x.ID <= acReport.EndClient).Select(x => x.Name).ToList();

                            personalAttendanceList = personalAttendanceList.Where(x => clients.Contains(x.PersClient)).ToList();
                        }
                    }
                }

                if (acReport.StartLocationB != null && acReport.EndLocation != null)
                {
                    if (acReport.StartLocation > 0 && acReport.EndLocation > 0)
                    {
                        if (acReport.EndLocation >= acReport.StartLocation)
                        {
                            var locations = new LocationRepository().GetLocations().Where(x => x.ID >= acReport.StartLocation && x.ID <= acReport.EndLocation).Select(x => x.Name).ToList();

                            personalAttendanceList = personalAttendanceList.Where(x => locations.Contains(x.PersLocation)).ToList();
                        }
                    }
                }

                if (acReport.StartDept != null && acReport.EndDept != null)
                {
                    if (acReport.StartDept > 0 && acReport.EndDept > 0)
                    {
                        if (acReport.EndDept >= acReport.StartDept)
                        {
                            var departments = new DepartmentRepository().GetDepartments().Where(x => x.ID >= acReport.StartDept && x.ID <= acReport.EndDept).Select(x => x.Name).ToList();

                            personalAttendanceList = personalAttendanceList.Where(x => departments.Contains(x.PersDepartement)).ToList();
                        }
                    }
                }

                if (acReport.StartCostCenter != null && acReport.EndCostCenter != null)
                {
                    if (acReport.StartCostCenter > 0 && acReport.EndCostCenter > 0)
                    {
                        if (acReport.EndCostCenter >= acReport.StartCostCenter)
                        {
                            var costCenters = new CostCenterRepository().GetCostCenters().Where(x => x.ID >= acReport.StartCostCenter && x.ID <= acReport.EndCostCenter).Select(x => x.Name).ToList();

                            personalAttendanceList = personalAttendanceList.Where(x => costCenters.Contains(x.PersCostCenter)).ToList();
                        }
                    }
                }
            }

            return personalAttendanceList;
        }

        public List<AccessLogReportsDto> GetVisitorAttendanceLogs(bool filterByAttendanceState = false, AccessReportSettings_DTO acReport = null)
        {
            List<AccessLogReportsDto> personalAttendanceList = new List<AccessLogReportsDto>();
            AccessLogReportsDto accessLogReport = new AccessLogReportsDto();

            VisitorRepository visitorlRepo = new VisitorRepository();

            var allDayBookings = _getViewAccesslogsOverDateSelection(AccessLogType.Visitor, acReport);
            var allVisitors = visitorlRepo.GetAllVisitors();
            var allClients = new ClientsRepository().GetClients();
            var allTransponders = new VisitorTranspondersRepository().GetAllVisitorTransponders();

            bool displayVisitor = false;

            foreach (var visitor in allVisitors)
            {


                displayVisitor = false;
                List<View_AccessLogs> visitorDayBookings = allDayBookings.Where(x => x.ID_Nr == visitor.VisitorID).ToList();
                while (true)
                {

                    if (filterByAttendanceState)
                    {
                        switch (acReport.MemberDataReportType)
                        {
                            case (int)memberInfoReportType.Present:
                                displayVisitor = (visitorDayBookings.Count() % 2) != 0;
                                break;
                            case (int)memberInfoReportType.Absent:
                                displayVisitor = (visitorDayBookings.Count() % 2) == 0;
                                break;
                            case (int)memberInfoReportType.AllBookings:
                                displayVisitor = visitorDayBookings.Count() > 0;
                                break;
                        }
                    }
                    else
                    {
                        displayVisitor = visitorDayBookings.Count() > 0;
                    }

                    if (displayVisitor)
                    {
                        accessLogReport = new AccessLogReportsDto();

                        accessLogReport.BookingDate = Convert.ToDateTime(acReport.StartDate);
                        accessLogReport.ID = Convert.ToInt64(visitor.VisitorID);
                        accessLogReport.PersonID = Convert.ToInt64(visitor.VisitorID);
                        accessLogReport.Name = visitor.SurName + visitor.Fullname;
                        accessLogReport.CardNumber = (allTransponders.Where(x => x.VisitorID == visitor.ID && x.TransponderType == 1 && x.TransponderStatus == true).FirstOrDefault() ?? new VisitorTransponder()).TransponderNr.ToString();
                        accessLogReport.ExpiryDate = (allTransponders.Where(x => x.VisitorID == visitor.ID && x.TransponderType == 1 && x.TransponderStatus == true).FirstOrDefault() ?? new VisitorTransponder()).ValidTo;

                        accessLogReport.BookingDateFrom = Convert.ToDateTime(acReport.StartDate);
                        accessLogReport.BookingDateTo = Convert.ToDateTime(acReport.EndDate);
                        accessLogReport.PersClient = (allClients.Where(x => x.Client_Nr == visitor.CompanyTo).FirstOrDefault() ?? new Client()).Name;

                        var locationFrom = (new LocationRepository().GetLocations().Where(x => x.ID == acReport.StartLocation).FirstOrDefault() ?? new Location()).Name;
                        var locationTo = (new LocationRepository().GetLocations().Where(x => x.ID == acReport.EndLocation).FirstOrDefault() ?? new Location()).Name;
                        var startCompany = (new ClientsRepository().GetClients().Where(x => x.ID == acReport.StartClient).FirstOrDefault() ?? new Client()).Name;
                        var endCompany = (new ClientsRepository().GetClients().Where(x => x.ID == acReport.EndClient).FirstOrDefault() ?? new Client()).Name;

                        var startVistorCompany = (new VisitorCompanyRepository().GetAllVisitorCompanies().Where(x => x.ID == acReport.StartVisitorCompany).FirstOrDefault() ?? new VisitorCompanyTb()).Name;
                        var endVisitorCompany = (new VisitorCompanyRepository().GetAllVisitorCompanies().Where(x => x.ID == acReport.EndVisitorCompany).FirstOrDefault() ?? new VisitorCompanyTb()).Name;

                        accessLogReport.PersLocationFrom = locationFrom;
                        accessLogReport.PersLocationTo = locationTo;


                        accessLogReport.PersClientFrom = startCompany;
                        accessLogReport.PersClientTo = endCompany;

                        accessLogReport.VisitorCompanyFrom = startVistorCompany;
                        accessLogReport.VisitorCompanyTo = endVisitorCompany;

                        if (visitor.VisitorCompanyTb != null)
                        {
                            accessLogReport.VisitorCompany = visitor.VisitorCompanyTb.CompanyName;
                        }

                        var goBookings = visitorDayBookings.ToList().Where((c, i) => i % 2 != 0).ToList();
                        var comeBookings = visitorDayBookings.ToList().Where((c, i) => i % 2 == 0).ToList();

                        if (comeBookings.Count() > 0)
                        {
                            accessLogReport.EntryDate = comeBookings.FirstOrDefault().BookingTime;
                        }

                        if (goBookings.Count() > 0)
                        {
                            accessLogReport.ExitDate = goBookings.LastOrDefault().BookingTime;
                        }

                        accessLogReport.Duration = new DateTime(2001, 1, 1).Add(Controllers.TimeDurationCalculator.CalculateTimeDuration(visitorDayBookings.Select(x => x.BookingTime).ToList()));

                        personalAttendanceList.Add(accessLogReport);
                    }
                    break;
                }

            }

            if (acReport != null)
            {

            }

            return personalAttendanceList;
        }
    }
}