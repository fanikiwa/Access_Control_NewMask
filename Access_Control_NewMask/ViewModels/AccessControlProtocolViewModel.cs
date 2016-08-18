using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.ViewModels
{
    public class AccessControlProtocolViewModel
    {
        private enum personalBookingStatus { bookingOK = 1, bookingError = 2, bookingCorrected = 3, noBooking = 4 }
        private enum bookingDirection { bookingNONE, bookingCOME, bookingGO }

        private static List<View_VisitorAccessLog> _todayEntryLog = null;


        public List<AccessCorrectionLog> getAccessControlprotocol(long clientID, long locationID, long departmentID, long costcenterID, long personalNumber, DateTime dtDateBookings, bool viewErrorBookingsOnly = false, bool viewVisitorBookingsOnly = false, bool includeWithoutBookings = false)
        {
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            ClientsRepository clientRepo = new ClientsRepository();
            LocationRepository locationRepo = new LocationRepository();
            DepartmentRepository departmentRepo = new DepartmentRepository();
            CostCenterRepository costcenterRepo = new CostCenterRepository();
            List<VwPersonnelData> allPersonel = new List<VwPersonnelData>();

            string clientName = string.Empty;
            string locationName = string.Empty;
            string departmentName = string.Empty;
            string costcenterName = string.Empty;

            if (clientID != 0)
            {
                var client = clientRepo.GetClientsById(clientID);
                if (client != null)
                {
                    clientName = client.Name;
                }
            }
            if (locationID != 0)
            {
                var location = locationRepo.GetLocationById(locationID);
                if (location != null)
                {
                    locationName = location.Name;
                }
            }
            if (departmentID != 0)
            {
                var department = departmentRepo.GetDepartmentById(departmentID);
                if (department != null)
                {
                    departmentName = department.Name;
                }
            }
            if (costcenterID != 0)
            {
                var costcenter = costcenterRepo.GetCostCenterById(costcenterID);
                if (costcenter != null)
                {
                    costcenterName = costcenter.Name;
                }
            }

            AccessCorrectionLog accessLogDto = null;
            List<AccessCorrectionLog> accessLogsDto = new List<AccessCorrectionLog>();


            if (viewVisitorBookingsOnly == false)
            {
                if (personalNumber > 0)
                {
                    allPersonel = visittorpresentLogRepo.GetAllVisitorWithoutLogs().Where(x => x.Active == true && x.Pers_Nr == personalNumber).ToList();
                }
                else
                {
                    allPersonel = visittorpresentLogRepo.GetAllVisitorWithoutLogs().Where(x => x.Active == true).ToList();
                }

                if (clientName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.ClientName == clientName).ToList(); ;
                }

                if (locationName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.LocationName == locationName).ToList(); ;
                }

                if (departmentName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.DepartmentName == departmentName).ToList(); ;
                }

                if (costcenterName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.CostCenterName == costcenterName).ToList(); ;
                }
            }

            var alllogs = _getAllTodaysLogs(true).OrderBy(x => x.BookingTime)
                .Where(x => x.BookingTime >= dtDateBookings && x.BookingTime < dtDateBookings.AddDays(1))
                .OrderBy(y => y.BookingTime).ToList();
            var allVisitorLogs = visittorpresentLogRepo.GetAllTodayVisitorEntryLogs().OrderBy(x => x.BookingTime)
                .Where(x => x.BookingTime >= dtDateBookings && x.BookingTime < dtDateBookings.AddDays(1))
                .OrderBy(y => y.BookingTime).ToList();

            foreach (var personell in allPersonel)
            {
                accessLogDto = null;
                var firstKommtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                var lastGehtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();



                if (firstKommtBooking != null)
                {
                    accessLogDto = new AccessCorrectionLog();

                    accessLogDto.ID = Convert.ToInt64(firstKommtBooking.ID);
                    accessLogDto.LogPersType = 1;

                    accessLogDto.Name = personell.FirstName + ", " + personell.LastName;
                    accessLogDto.PersonalNumber = firstKommtBooking.Pers_Nr;
                    //visitorLogDto.CardNumber =
                    accessLogDto.Date = firstKommtBooking.BookingTime;
                    accessLogDto.Entry = firstKommtBooking.BookingTime;

                    accessLogDto.Client = personell.ClientName;
                    accessLogDto.Location = personell.LocationName;
                    accessLogDto.Department = personell.DepartmentName;
                    accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 2;
                }

                if (lastGehtBooking != null)
                {
                    //visitorLogDto = new AccessCorrectionLog();

                    if (accessLogDto == null)
                    {
                        accessLogDto = new AccessCorrectionLog();
                        accessLogDto.LogPersType = 1;
                    }

                    accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);

                    accessLogDto.Name = personell.FirstName + ", " + personell.LastName;
                    accessLogDto.PersonalNumber = lastGehtBooking.Pers_Nr;
                    //visitorLogDto.CardNumber =
                    accessLogDto.Date = lastGehtBooking.BookingTime;
                    accessLogDto.Exit = lastGehtBooking.BookingTime;

                    accessLogDto.Client = personell.ClientName;
                    accessLogDto.Location = personell.LocationName;
                    accessLogDto.Department = personell.DepartmentName;
                    accessLogDto.CostCenter = personell.CostCenterName;

                    TimeSpan duration = new TimeSpan();
                    List<DateTime> bookingTimes = new List<DateTime>();

                    if(accessLogDto != null)
                    {
                        bookingTimes = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr).ToList().Select(x => x.BookingTime).ToList();
                        duration = Controllers.TimeDurationCalculator.CalculateTimeDuration(bookingTimes);
                    }
                    
                    //if (lastGehtBooking != null && firstKommtBooking != null)
                    //{
                    //    if (lastGehtBooking.BookingTime.TimeOfDay > firstKommtBooking.BookingTime.TimeOfDay)
                    //    {
                    //        duration = lastGehtBooking.BookingTime.TimeOfDay - firstKommtBooking.BookingTime.TimeOfDay;
                    //    }
                    //}

                    accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
                }

                if (accessLogDto != null)
                {
                    _analyseBookingStatus2(accessLogDto, dtDateBookings);
                }

                if (includeWithoutBookings && firstKommtBooking == null && lastGehtBooking == null)
                {
                    accessLogDto = new AccessCorrectionLog();
                    accessLogDto.Date = dtDateBookings;
                    accessLogDto.Name = personell.FirstName + ", " + personell.LastName;
                    accessLogDto.PersonalNumber = personell.Pers_Nr;
                    accessLogDto.Client = personell.ClientName;
                    accessLogDto.Location = personell.LocationName;
                    accessLogDto.Entry = dtDateBookings.Date;
                    accessLogDto.Exit = dtDateBookings.Date;
                    accessLogDto.Department = personell.DepartmentName;
                    accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 4;
                    accessLogDto.LogPersType = 1;
                }


                if (accessLogDto != null)
                {
                    //_analyseBookingStatus(accessLogDto);
                    accessLogsDto.Add(accessLogDto);
                }
            }

            if (viewErrorBookingsOnly)
            {
                accessLogsDto = accessLogsDto.Where(x => x.BookingStatus == (int)personalBookingStatus.bookingError).ToList();
            }

            List<AccessCorrectionLog> visitorLogsDto = new List<AccessCorrectionLog>();

            VisitorRepository visitorRepo = new VisitorRepository();

            //var visitorIDS = allVisitorLogs.Select(x => x.VisitorID).Distinct();
            var allVisitors = visitorRepo.GetAllVisitors();

            var visitorIDS = allVisitors.Select(x => x.VisitorID).Distinct();

            foreach (long visitorID in visitorIDS)
            {
                accessLogDto = null;
                var firstKommtBooking = allVisitorLogs.Where(x => x.VisitorID == visitorID && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                var lastGehtBooking = allVisitorLogs.Where(x => x.VisitorID == visitorID && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

                var visitorData = visitorRepo.GetAllVisitors().Where(x => x.VisitorID == visitorID).FirstOrDefault();

                if (firstKommtBooking != null)
                {
                    accessLogDto = new AccessCorrectionLog();

                    accessLogDto.ID = accessLogsDto.Count() + visitorLogsDto.Count() + 1; // Convert.ToInt64(firstKommtBooking.ID);
                    accessLogDto.LogPersType = 2;
                    accessLogDto.Name = visitorData.Fullname + ", " + visitorData.SurName;
                    accessLogDto.PersonalNumber = firstKommtBooking.VisitorID;
                    //accessLogDto.CardNumber = 
                    accessLogDto.Date = firstKommtBooking.BookingTime;
                    accessLogDto.Entry = firstKommtBooking.BookingTime;

                    //accessLogDto.Client = personell.ClientName;
                    //accessLogDto.Location = personell.LocationName;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 2;
                }

                if (lastGehtBooking != null)
                {
                    //visitorLogDto = new AccessCorrectionLog();

                    //accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);

                    accessLogDto.Name = visitorData.Fullname + ", " + visitorData.SurName;
                    accessLogDto.PersonalNumber = lastGehtBooking.VisitorID;
                    //visitorLogDto.CardNumber =
                    accessLogDto.Date = lastGehtBooking.BookingTime;
                    accessLogDto.Exit = lastGehtBooking.BookingTime;

                    //accessLogDto.Client = personell.ClientName;
                    //accessLogDto.Location = personell.LocationName;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;

                    TimeSpan duration = new TimeSpan();
                    List<DateTime> bookingTimes = new List<DateTime>();

                    if (accessLogDto != null)
                    {
                        bookingTimes = allVisitorLogs.Where(x => x.VisitorID == visitorData.VisitorID).ToList().Select(x => x.BookingTime).ToList();
                        duration = Controllers.TimeDurationCalculator.CalculateTimeDuration(bookingTimes);
                    }

                    //TimeSpan duration = new TimeSpan();

                    //if (lastGehtBooking != null && firstKommtBooking != null)
                    //{
                    //    if (lastGehtBooking.BookingTime.TimeOfDay > firstKommtBooking.BookingTime.TimeOfDay)
                    //    {
                    //        duration = lastGehtBooking.BookingTime.TimeOfDay - firstKommtBooking.BookingTime.TimeOfDay;
                    //    }
                    //}

                    //var duration = lastGehtBooking.BookingTime - firstKommtBooking.BookingTime;
                    accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
                }

                if (accessLogDto != null)
                {
                    visitorLogsDto.Add(accessLogDto);
                }

                if (includeWithoutBookings && firstKommtBooking == null && lastGehtBooking == null)
                {
                    accessLogDto = new AccessCorrectionLog();
                    accessLogDto.Date = dtDateBookings;
                    accessLogDto.Name = visitorData.Fullname + ", " + visitorData.SurName;
                    accessLogDto.PersonalNumber = visitorData.ID;
                    //accessLogDto.Client = visitorData.c;
                    //accessLogDto.Location = personell.LocationName;
                    accessLogDto.Entry = dtDateBookings.Date;
                    accessLogDto.Exit = dtDateBookings.Date;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 4;
                    accessLogDto.LogPersType = 2;
                }

                if (accessLogDto != null)
                {
                    //_analyseVisitorBookingStatus(accessLogDto);
                    visitorLogsDto.Add(accessLogDto);
                }
            }

            accessLogsDto.AddRange(visitorLogsDto);

            accessLogsDto.AddRange(_getMembersLogs(dtDateBookings, includeWithoutBookings, accessLogsDto.Count + 1));

            
            return accessLogsDto;
        }

        private List<AccessCorrectionLog> _getMembersLogs(DateTime dtDateBookings, bool includeWithoutBookings, int currentLogNumber)
        {
            List<AccessCorrectionLog> _memberAccesslogs = new List<AccessCorrectionLog>();
            AccessCorrectionLog accessLogDto = null;
            View_MemberAccessLogRepositoy memberLogRepo = new View_MemberAccessLogRepositoy();

            MembersViewModel membersViewModel = new MembersViewModel();



            var allMemberLogs = memberLogRepo.GetAllView_MemberAccessLog().OrderBy(x => x.BookingTime)
                                             .Where(x => x.BookingTime >= dtDateBookings && x.BookingTime < dtDateBookings.AddDays(1))
                                             .OrderBy(y => y.BookingTime).ToList();

            //var visitorIDS = allVisitorLogs.Select(x => x.VisitorID).Distinct();
            var allMemebers = membersViewModel.GetAllMembersData();
 

            var memberNumbers = allMemebers.Select(x => x.MemberNumber).Distinct();

            foreach (long memberNumber in memberNumbers)
            {

                currentLogNumber = currentLogNumber + 1;

                accessLogDto = null;
                var firstKommtBooking = allMemberLogs.Where(x => x.MemberNumber == memberNumber && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                var lastGehtBooking = allMemberLogs.Where(x => x.MemberNumber == memberNumber && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

                var memberData = allMemebers.Where(x => x.MemberNumber == memberNumber).FirstOrDefault();

                if (firstKommtBooking != null)
                {
                    accessLogDto = new AccessCorrectionLog();

                    accessLogDto.ID = currentLogNumber; // Convert.ToInt64(firstKommtBooking.ID);
                    accessLogDto.LogPersType = 3;
                    accessLogDto.Name = memberData.SurName + ", " + memberData.FirstName;
                    accessLogDto.PersonalNumber = memberNumber;
                    //accessLogDto.CardNumber = 
                    accessLogDto.Date = firstKommtBooking.BookingTime;
                    accessLogDto.Entry = firstKommtBooking.BookingTime;

                    //accessLogDto.Client = personell.ClientName;
                    //accessLogDto.Location = personell.LocationName;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 2;
                }

                if (lastGehtBooking != null)
                {
                    if(accessLogDto == null)
                    {
                        accessLogDto = new AccessCorrectionLog();
                        accessLogDto.LogPersType = 3;
                    }
                    

                    //accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);

                    accessLogDto.Name = memberData.SurName + ", " + memberData.FirstName;
                    accessLogDto.PersonalNumber = memberNumber;
                    //visitorLogDto.CardNumber =
                    accessLogDto.Date = lastGehtBooking.BookingTime;
                    accessLogDto.Exit = lastGehtBooking.BookingTime;


                    TimeSpan duration = new TimeSpan();
                    List<DateTime> bookingTimes = new List<DateTime>();

                    if (accessLogDto != null)
                    {
                        bookingTimes = allMemberLogs.Where(x => x.MemberNumber == memberData.MemberNumber).ToList().Select(x => x.BookingTime).ToList();
                        duration = Controllers.TimeDurationCalculator.CalculateTimeDuration(bookingTimes);
                    }

                    //TimeSpan duration = new TimeSpan();

                    //if (lastGehtBooking != null && firstKommtBooking != null)
                    //{
                    //    if (lastGehtBooking.BookingTime.TimeOfDay > firstKommtBooking.BookingTime.TimeOfDay)
                    //    {
                    //        duration = lastGehtBooking.BookingTime.TimeOfDay - firstKommtBooking.BookingTime.TimeOfDay;
                    //    }
                    //}

                    //var duration = lastGehtBooking.BookingTime - firstKommtBooking.BookingTime;
                    accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
                }

                if (accessLogDto != null)
                {
                    _analyseMemberBookingStatus(accessLogDto, allMemberLogs);
                }


                

                if (includeWithoutBookings && firstKommtBooking == null && lastGehtBooking == null)
                {
                    accessLogDto = new AccessCorrectionLog();
                    accessLogDto.Date = dtDateBookings;
                    accessLogDto.Name = memberData.SurName + ", " + memberData.FirstName;
                    accessLogDto.PersonalNumber = memberData.MemberNumber;
                    //accessLogDto.Client = visitorData.c;
                    //accessLogDto.Location = personell.LocationName;
                    accessLogDto.Entry = dtDateBookings.Date;
                    accessLogDto.Exit = dtDateBookings.Date;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 4;
                    accessLogDto.LogPersType = 3;
                }

                if (accessLogDto != null)
                {
                    _memberAccesslogs.Add(accessLogDto);
                }
            }

            return _memberAccesslogs;

        }

        public List<AccessCorrectionLog> getAccessControlprotocolFiltered(long clientID, long locationID, long departmentID, long costcenterID, long personalNumber, DateTime dtDateBookingsFrom, DateTime dtDateBookingsTo, bool viewErrorBookingsOnly = false, bool viewVisitorBookingsOnly = false)
        {
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            ClientsRepository clientRepo = new ClientsRepository();
            LocationRepository locationRepo = new LocationRepository();
            DepartmentRepository departmentRepo = new DepartmentRepository();
            CostCenterRepository costcenterRepo = new CostCenterRepository();
            List<VwPersonnelData> allPersonel = new List<VwPersonnelData>();

            string clientName = string.Empty;
            string locationName = string.Empty;
            string departmentName = string.Empty;
            string costcenterName = string.Empty;

            if (clientID != 0)
            {
                var client = clientRepo.GetClientsById(clientID);
                if (client != null)
                {
                    clientName = client.Name;
                }
            }
            if (locationID != 0)
            {
                var location = locationRepo.GetLocationById(locationID);
                if (location != null)
                {
                    locationName = location.Name;
                }
            }
            if (departmentID != 0)
            {
                var department = departmentRepo.GetDepartmentById(departmentID);
                if (department != null)
                {
                    departmentName = department.Name;
                }
            }
            if (costcenterID != 0)
            {
                var costcenter = costcenterRepo.GetCostCenterById(costcenterID);
                if (costcenter != null)
                {
                    costcenterName = costcenter.Name;
                }
            }

            AccessCorrectionLog accessLogDto = null;
            List<AccessCorrectionLog> accessLogsDto = new List<AccessCorrectionLog>();


            if (viewVisitorBookingsOnly == false)
            {
                if (personalNumber > 0)
                {
                    allPersonel = visittorpresentLogRepo.GetAllVisitorWithoutLogs().Where(x => x.Active == true && x.Pers_Nr == personalNumber).ToList();
                }
                else
                {
                    allPersonel = visittorpresentLogRepo.GetAllVisitorWithoutLogs().Where(x => x.Active == true).ToList();
                }

                if (clientName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.ClientName == clientName).ToList(); ;
                }

                if (locationName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.LocationName == locationName).ToList(); ;
                }

                if (departmentName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.DepartmentName == departmentName).ToList(); ;
                }

                if (costcenterName != string.Empty)
                {
                    allPersonel = allPersonel.Where(x => x.CostCenterName == costcenterName).ToList(); ;
                }
            }

            //var alllogs = visittorpresentLogRepo.GetAllTodayVisitorLogs().OrderBy(x => x.BookingTime)
            //    .Where(x => x.BookingTime.Date >= dtDateBookingsFrom.Date && x.BookingTime.Date <= dtDateBookingsTo.Date)
            //    .OrderBy(y => y.BookingTime).ToList();
            var allVisitorLogs = visittorpresentLogRepo.GetAllTodayVisitorEntryLogs().OrderBy(x => x.BookingTime)
                .Where(x => x.BookingTime.Date >= dtDateBookingsFrom.Date && x.BookingTime.Date <= dtDateBookingsTo.Date)
                .OrderBy(y => y.BookingTime).ToList();


            allPersonel = allPersonel.OrderBy(x => x.LastName).ToList();
            foreach (var personell in allPersonel)
            {
                #region Old Stuff
                //accessLogDto = null;
                //var firstKommtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                //var lastKommtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Come == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();
                //var lastGehtBooking = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

                //if (firstKommtBooking != null)
                //{
                //    accessLogDto = new AccessCorrectionLog();

                //    accessLogDto.ID = Convert.ToInt64(firstKommtBooking.ID);
                //    accessLogDto.LogPersType = 1;

                //    accessLogDto.Name = firstKommtBooking.LastName + " " + firstKommtBooking.FirstName;
                //    accessLogDto.PersonalNumber = firstKommtBooking.Pers_Nr;
                //    //visitorLogDto.CardNumber =
                //    accessLogDto.Date = firstKommtBooking.BookingTime;
                //    accessLogDto.Entry = firstKommtBooking.BookingTime;

                //    accessLogDto.Client = personell.ClientName;
                //    accessLogDto.Location = personell.LocationName;
                //    accessLogDto.Department = personell.DepartmentName;
                //    accessLogDto.CostCenter = personell.CostCenterName;
                //    accessLogDto.BookingStatus = 2;
                //}

                //if (lastGehtBooking != null)
                //{
                //    //visitorLogDto = new AccessCorrectionLog();

                //    if(accessLogDto == null)
                //    {
                //        accessLogDto = new AccessCorrectionLog();
                //    }

                //    accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);

                //    accessLogDto.Name = lastGehtBooking.LastName + " " + lastGehtBooking.FirstName;
                //    accessLogDto.PersonalNumber = lastGehtBooking.Pers_Nr;
                //    //visitorLogDto.CardNumber =
                //    accessLogDto.Date = lastGehtBooking.BookingTime;
                //    accessLogDto.Exit = lastGehtBooking.BookingTime;

                //    accessLogDto.Client = personell.ClientName;
                //    accessLogDto.Location = personell.LocationName;
                //    accessLogDto.Department = personell.DepartmentName;
                //    accessLogDto.CostCenter = personell.CostCenterName;

                //    TimeSpan duration = new TimeSpan();

                //    if (firstKommtBooking != null)
                //    {
                //        if(firstKommtBooking.BookingTime < lastGehtBooking.BookingTime)
                //        {
                //            duration = lastGehtBooking.BookingTime - firstKommtBooking.BookingTime;
                //        }
                //    }

                //    accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
                //}


                //if(lastGehtBooking != null && lastKommtBooking != null)
                //{
                //    if (lastGehtBooking.BookingTime < lastKommtBooking.BookingTime)
                //    {
                //        accessLogDto.EntryStatus = 1;
                //    }

                //    if (lastGehtBooking.BookingTime > lastKommtBooking.BookingTime)
                //    {
                //        accessLogDto.EntryStatus = 2;
                //    }
                //}

                //if (lastGehtBooking == null && lastKommtBooking != null)
                //{
                //    accessLogDto.EntryStatus = 1;
                //}

                //if (lastGehtBooking != null && lastKommtBooking == null)
                //{
                //    accessLogDto.EntryStatus = 2;
                //}

                //if (accessLogDto != null)
                //{
                //    _analyseBookingStatus(accessLogDto);
                //    accessLogsDto.Add(accessLogDto);
                //}

                #endregion

                //var personalDailyBookings = alllogs.Where(x => x.Pers_Nr == personell.Pers_Nr).OrderBy(x => x.BookingTime).ToList();

                var personalDailLog = _getAccessCorrectionLogsFromBookings(personell, dtDateBookingsFrom, accessLogsDto.Count);
                accessLogsDto.AddRange(personalDailLog);
            }

            if (viewErrorBookingsOnly)
            {
                accessLogsDto = accessLogsDto.Where(x => x.BookingStatus == (int)personalBookingStatus.bookingError).ToList();
            }

            List<AccessCorrectionLog> visitorLogsDto = new List<AccessCorrectionLog>();

            VisitorRepository visitorRepo = new VisitorRepository();

            var visitorIDS = allVisitorLogs.Select(x => x.VisitorID).Distinct();

            foreach (long visitorID in visitorIDS)
            {
                accessLogDto = null;
                var firstKommtBooking = allVisitorLogs.Where(x => x.VisitorID == visitorID && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                var lastGehtBooking = allVisitorLogs.Where(x => x.VisitorID == visitorID && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

                var visitorData = visitorRepo.GetAllVisitors().Where(x => x.VisitorID == visitorID).FirstOrDefault();

                if (firstKommtBooking != null)
                {
                    accessLogDto = new AccessCorrectionLog();

                    accessLogDto.ID = accessLogsDto.Count() + visitorLogsDto.Count() + 1; // Convert.ToInt64(firstKommtBooking.ID);
                    accessLogDto.LogPersType = 2;
                    accessLogDto.Name = visitorData.Fullname + ", " + visitorData.SurName;
                    accessLogDto.PersonalNumber = firstKommtBooking.VisitorID;
                    //accessLogDto.CardNumber = 
                    accessLogDto.Date = firstKommtBooking.BookingTime;
                    accessLogDto.Entry = firstKommtBooking.BookingTime;

                    //accessLogDto.Client = personell.ClientName;
                    //accessLogDto.Location = personell.LocationName;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;
                    accessLogDto.BookingStatus = 2;
                }

                if (lastGehtBooking != null)
                {
                    if(accessLogDto == null)
                    {
                        accessLogDto = new AccessCorrectionLog();
                        accessLogDto.ID = Convert.ToInt64(lastGehtBooking.ID);
                    }


                    accessLogDto.Name = visitorData.Fullname + ", " + visitorData.SurName;
                    accessLogDto.PersonalNumber = lastGehtBooking.VisitorID;
                    //visitorLogDto.CardNumber =
                    accessLogDto.Date = lastGehtBooking.BookingTime;
                    accessLogDto.Exit = lastGehtBooking.BookingTime;

                    //accessLogDto.Client = personell.ClientName;
                    //accessLogDto.Location = personell.LocationName;
                    //accessLogDto.Department = personell.DepartmentName;
                    //accessLogDto.CostCenter = personell.CostCenterName;

                    //var duration = lastGehtBooking.BookingTime - firstKommtBooking.BookingTime;

                    TimeSpan duration = new TimeSpan();

                    if (lastGehtBooking != null && firstKommtBooking != null && lastGehtBooking.BookingTime.TimeOfDay > firstKommtBooking.BookingTime.TimeOfDay)
                    {
                        duration = lastGehtBooking.BookingTime.TimeOfDay - firstKommtBooking.BookingTime.TimeOfDay;
                    }

                    accessLogDto.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
                }

                if (accessLogDto != null)
                {
                    _analyseVisitorBookingStatus(accessLogDto);
                    visitorLogsDto.Add(accessLogDto);
                }
            }

            accessLogsDto.AddRange(visitorLogsDto);
            return accessLogsDto;
        }

        private List<AccessCorrectionLog> _getAccessCorrectionLogsFromBookings(VwPersonnelData personalData, DateTime bookingDate, long currentIndex)
        {
            List<AccessCorrectionLog> personalDailyAccessLog = new List<AccessCorrectionLog>();
            AccessCorrectionLog personalBookingCorrection = null;
            List<BookingsCorrection> bookingCorrections = _getPersonalBookingCorrections(personalData.Pers_Nr, bookingDate);

            long currentID = currentIndex;

            foreach (BookingsCorrection bookingCorrection in bookingCorrections)
            {
                personalBookingCorrection = new AccessCorrectionLog();

                currentID = currentID + 1;
                personalBookingCorrection.ID = currentID;
                personalBookingCorrection.LogPersType = 1;
                personalBookingCorrection.Entry = Convert.ToDateTime(bookingCorrection.KommtBooking);
                personalBookingCorrection.Exit = Convert.ToDateTime(bookingCorrection.GehtBooking);

                personalBookingCorrection.Name = personalData.FirstName + ", " + personalData.LastName;
                personalBookingCorrection.PersonalNumber = personalData.Pers_Nr;
                personalBookingCorrection.CardNumber = Convert.ToString(personalData.Card_Nr);
                personalBookingCorrection.Date = bookingDate;
                personalBookingCorrection.Client = personalData.ClientName;
                personalBookingCorrection.Location = personalData.LocationName;
                personalBookingCorrection.Department = personalData.DepartmentName;
                personalBookingCorrection.CostCenter = personalData.CostCenterName;

                if (bookingCorrection.KommtBooking != null && bookingCorrection.GehtBooking != null)
                {
                    var duration = Convert.ToDateTime(bookingCorrection.GehtBooking) - Convert.ToDateTime(bookingCorrection.KommtBooking);
                    personalBookingCorrection.Duration = new DateTime(2000, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
                    personalBookingCorrection.BookingStatus = (int)personalBookingStatus.bookingOK;
                }
                else
                {
                    personalBookingCorrection.BookingStatus = (int)personalBookingStatus.bookingError;
                }

                personalDailyAccessLog.Add(personalBookingCorrection);

            }
            return personalDailyAccessLog;
        }

        private static List<BookingsCorrection> _getPersonalBookingCorrections(long personalNumber, DateTime? bookingDate = null)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            BookingsCorrection correctinBooking = null;
            //VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            bookingDirection currentBookingStatus = bookingDirection.bookingNONE;
            List<View_VisitorAccessLog> alllogs = new List<View_VisitorAccessLog>();

            int bookingStatus = 0;


            if (personalNumber > 0)
            {
                if (bookingDate == null)
                {
                    alllogs = _getAllTodaysLogs(false).OrderBy(x => x.BookingTime).Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1) && x.Pers_Nr == personalNumber).OrderBy(y => y.BookingTime).ToList();
                }
                else
                {
                    alllogs = _getAllTodaysLogs(false).OrderBy(x => x.BookingTime).Where(x => x.BookingTime > bookingDate && x.BookingTime < Convert.ToDateTime(bookingDate).AddDays(1) && x.Pers_Nr == personalNumber).OrderBy(y => y.BookingTime).ToList();
                }


                foreach (var bookingLog in alllogs)
                {
                    if (bookingLog.BookingCorrection == 1)
                    {
                        bookingStatus = 3;
                    }
                    else
                    {
                        bookingStatus = 1;
                    }

                    currentBookingStatus = bookingDirection.bookingNONE;

                    if (Convert.ToBoolean(bookingLog.TA_Come))
                    {
                        currentBookingStatus = bookingDirection.bookingCOME;
                    }

                    if (Convert.ToBoolean(bookingLog.TA_Go))
                    {
                        currentBookingStatus = bookingDirection.bookingGO;
                    }

                    switch (lastBookingStatus)
                    {
                        case bookingDirection.bookingNONE:
                            correctinBooking = new BookingsCorrection();
                            correctinBooking.ID = bookingCorrections.Count + 1;
                            correctinBooking.PersonalNumber = personalNumber;
                            bookingCorrections.Add(correctinBooking);

                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    lastBookingStatus = bookingDirection.bookingCOME;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    lastBookingStatus = bookingDirection.bookingGO;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingCOME:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = personalNumber;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingGO:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = personalNumber;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = personalNumber;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                    }
                }
            }
            return bookingCorrections;
        }

        private static List<View_VisitorAccessLog> _getAllTodaysLogs(bool refreshInDatabase)
        {
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();

            if (refreshInDatabase || _todayEntryLog == null)
            {
                _todayEntryLog = visittorpresentLogRepo.GetAllTodayVisitorLogs();
            }
            return _todayEntryLog;
        }

        private static List<BookingsCorrection> _getVisitorBookingCorrections(long visitorID)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            BookingsCorrection correctinBooking = null;
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();
            bookingDirection lastBookingStatus = bookingDirection.bookingNONE;
            bookingDirection currentBookingStatus = bookingDirection.bookingNONE;

            int bookingStatus = 0;


            if (visitorID > 0)
            {
                var alllogs = visittorpresentLogRepo.GetAllTodayVisitorEntryLogs().OrderBy(x => x.BookingTime).Where(x => x.BookingTime > DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1) && x.VisitorID == visitorID).OrderBy(y => y.BookingTime).ToList();

                foreach (var bookingLog in alllogs)
                {
                    if (bookingLog.BookingCorrection == 1)
                    {
                        bookingStatus = 3;
                    }
                    else
                    {
                        bookingStatus = 1;
                    }

                    currentBookingStatus = bookingDirection.bookingNONE;

                    if (Convert.ToBoolean(bookingLog.TA_Come))
                    {
                        currentBookingStatus = bookingDirection.bookingCOME;
                    }

                    if (Convert.ToBoolean(bookingLog.TA_Go))
                    {
                        currentBookingStatus = bookingDirection.bookingGO;
                    }

                    switch (lastBookingStatus)
                    {
                        case bookingDirection.bookingNONE:
                            correctinBooking = new BookingsCorrection();
                            correctinBooking.ID = bookingCorrections.Count + 1;
                            correctinBooking.PersonalNumber = visitorID;
                            bookingCorrections.Add(correctinBooking);

                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    lastBookingStatus = bookingDirection.bookingCOME;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    lastBookingStatus = bookingDirection.bookingGO;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingCOME:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = visitorID;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                        case bookingDirection.bookingGO:
                            switch (currentBookingStatus)
                            {
                                case bookingDirection.bookingCOME:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = visitorID;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.KommtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                                case bookingDirection.bookingGO:
                                    correctinBooking = new BookingsCorrection();
                                    correctinBooking.ID = bookingCorrections.Count + 1;
                                    correctinBooking.PersonalNumber = visitorID;
                                    bookingCorrections.Add(correctinBooking);
                                    correctinBooking.GehtBooking = bookingLog.BookingTime;
                                    correctinBooking.BookingStatus = bookingStatus;
                                    break;
                            }
                            break;
                    }
                }
            }
            return bookingCorrections;
        }

        private void _analyseVisitorBookingStatus(AccessCorrectionLog personalAccessLog)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();

            if (personalAccessLog.PersonalNumber > 0)
            {

                bookingCorrections = _getVisitorBookingCorrections(personalAccessLog.PersonalNumber);


                personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingOK;
                personalAccessLog.Memo = "Buchung OK";

                foreach (var corretionBooking in bookingCorrections)
                {
                    if (corretionBooking.GehtBooking == null || corretionBooking.KommtBooking == null)
                    {
                        personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingError;
                        personalAccessLog.Memo = "Fehler";
                    }
                }

                if (bookingCorrections.Where(x => x.BookingStatus == 3).FirstOrDefault() != null && personalAccessLog.BookingStatus != (int)personalBookingStatus.bookingError)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingCorrected;
                    personalAccessLog.Memo = "Korrigiert";
                }


            }
        }

        private void _analyseBookingStatus2(AccessCorrectionLog personalAccessLog, DateTime? bookingDate = null)
        {
            List<View_VisitorAccessLog> alllogs = null;


            if (personalAccessLog.PersonalNumber > 0)
            {
                if (bookingDate == null)
                {
                    alllogs = _getAllTodaysLogs(false).OrderBy(x => x.BookingTime).Where(x => x.BookingTime >= DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1) && x.Pers_Nr == personalAccessLog.PersonalNumber).OrderBy(y => y.BookingTime).ToList();
                }
                else
                {
                    alllogs = _getAllTodaysLogs(false).OrderBy(x => x.BookingTime).Where(x => x.BookingTime >= bookingDate && x.BookingTime < Convert.ToDateTime(bookingDate).AddDays(1) && x.Pers_Nr == personalAccessLog.PersonalNumber).OrderBy(y => y.BookingTime).ToList();
                }

                if (alllogs.Count == 0)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.noBooking;
                }

                if (alllogs.Count % 2 == 0 && alllogs.Count > 0)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingOK;
                    personalAccessLog.Memo = "Buchung OK";
                }

                else
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingError;
                    personalAccessLog.Memo = "Fehler";
                }

                if (alllogs.Where(x => x.BookingCorrection == 1).FirstOrDefault() != null && personalAccessLog.BookingStatus != (int)personalBookingStatus.bookingError)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingCorrected;
                    personalAccessLog.Memo = "Korrigiert";
                }
            }
        }

        private void _analyseMemberBookingStatus(AccessCorrectionLog memberAccessLog,  List<View_MemberAccessLog> memeberAccesslogs, DateTime? bookingDate = null)
        {
            List<View_MemberAccessLog> alllogs = null;


            if (memberAccessLog.PersonalNumber > 0)
            {
                if (bookingDate == null)
                {
                    alllogs = memeberAccesslogs.OrderBy(x => x.BookingTime).Where(x => x.BookingTime >= DateTime.Today && x.BookingTime < DateTime.Today.AddDays(1) && x.MemberNumber == memberAccessLog.PersonalNumber).OrderBy(y => y.BookingTime).ToList();
                }
                else
                {
                    alllogs = memeberAccesslogs.OrderBy(x => x.BookingTime).Where(x => x.BookingTime >= bookingDate && x.BookingTime < Convert.ToDateTime(bookingDate).AddDays(1) && x.MemberNumber == memberAccessLog.PersonalNumber).OrderBy(y => y.BookingTime).ToList();
                }

                if (alllogs.Count == 0)
                {
                    memberAccessLog.BookingStatus = (int)personalBookingStatus.noBooking;
                }

                if (alllogs.Count % 2 == 0 && alllogs.Count > 0)
                {
                    memberAccessLog.BookingStatus = (int)personalBookingStatus.bookingOK;
                    memberAccessLog.Memo = "Buchung OK";
                }

                else
                {
                    memberAccessLog.BookingStatus = (int)personalBookingStatus.bookingError;
                    memberAccessLog.Memo = "Fehler";
                }

                if (alllogs.Where(x => x.BookingCorrection == 1).FirstOrDefault() != null && memberAccessLog.BookingStatus != (int)personalBookingStatus.bookingError)
                {
                    memberAccessLog.BookingStatus = (int)personalBookingStatus.bookingCorrected;
                    memberAccessLog.Memo = "Korrigiert";
                }
            }
        }

        private void _analyseBookingStatus(AccessCorrectionLog personalAccessLog, DateTime? bookingDate = null)
        {
            List<BookingsCorrection> bookingCorrections = new List<BookingsCorrection>();
            //VisitorPresentLogRepository visittorpresentLogRepo = new VisitorPresentLogRepository();

            if (personalAccessLog.PersonalNumber > 0)
            {

                bookingCorrections = _getPersonalBookingCorrections(personalAccessLog.PersonalNumber, bookingDate);


                personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingOK;
                personalAccessLog.Memo = "Buchung OK";

                foreach (var corretionBooking in bookingCorrections)
                {
                    if (corretionBooking.GehtBooking == null || corretionBooking.KommtBooking == null)
                    {
                        personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingError;
                        personalAccessLog.Memo = "Fehler";
                    }
                }

                if (bookingCorrections.Where(x => x.BookingStatus == 3).FirstOrDefault() != null && personalAccessLog.BookingStatus != (int)personalBookingStatus.bookingError)
                {
                    personalAccessLog.BookingStatus = (int)personalBookingStatus.bookingCorrected;
                    personalAccessLog.Memo = "Korrigiert";
                }


            }
        }
    }
}