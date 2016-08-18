using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class GateDisplaypanelViewModel
    {
        public List<GateDisplaypanelDto> GetAllData()
        {
            List<GateDisplaypanelDto> panelData = new List<GateDisplaypanelDto>();
            var accessLogs = new View_AccessLogsRepository().GetAllAccessLogs().Where(x=> x.BookingTime.Date >= DateTime.Now.Date).ToList();
            var personnels = new PersonnelRepository().GetAllPersonnel();
            var visitors = new VisitorRepository().GetAllVisitors();
            var members = new MembersDataRepository().GetAllMembersData();
            var uniqueAccessLogs = accessLogs.GroupBy(x => x.ID_Nr).Select(g => g.First());
            int i = 1;
            GateDisplaypanelDto panelDto = new GateDisplaypanelDto();
            foreach (var log in uniqueAccessLogs)
            {
                var firstKommtBooking = accessLogs.Where(x => x.ID_Nr == log.ID_Nr && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                var lastGehtBooking = accessLogs.Where(x => x.ID_Nr == log.ID_Nr && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();
               
                switch (i)
                {
                    case 1:
                        i = 2;
                        panelDto = new GateDisplaypanelDto();
                        panelDto.IDNr = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.Name1 = log.FullName;
                        panelDto.ID_Nr1 = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.TimeIn1 = firstKommtBooking != null? firstKommtBooking.BookingTime:(DateTime ?)null;
                        panelDto.TimeOut1 = lastGehtBooking != null? lastGehtBooking.BookingTime:(DateTime?)null;
                        panelDto.CardStatus1 = GetIsIn(accessLogs);
                        panelDto.Pers_Type = log.Pers_Type;
                        panelDto.CardStatus = GetIsIn(accessLogs);
                        panelData.Add(panelDto);
                        break;
                    case 2:
                        i = 3;
                        //panelDto.IDNr = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.Name2 = log.FullName;
                        panelDto.ID_Nr2 = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.TimeIn2 = firstKommtBooking != null ? firstKommtBooking.BookingTime : (DateTime?)null;
                        panelDto.TimeOut2 = lastGehtBooking != null ? lastGehtBooking.BookingTime : (DateTime?)null;
                        panelDto.CardStatus2 = GetIsIn(accessLogs);
                        panelDto.Pers_Type = log.Pers_Type;
                        panelDto.CardStatus = GetIsIn(accessLogs);
                        break;
                    case 3:
                        i = 1;
                        panelDto.Name3 = log.FullName;
                        panelDto.ID_Nr3 = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.TimeIn3 = firstKommtBooking != null ? firstKommtBooking.BookingTime : (DateTime?)null;
                        panelDto.TimeOut3 = lastGehtBooking != null ? lastGehtBooking.BookingTime : (DateTime?)null;
                        panelDto.CardStatus3 = GetIsIn(accessLogs);
                        panelDto.Pers_Type = log.Pers_Type;
                        panelDto.CardStatus = GetIsIn(accessLogs);
                        break;
                }
                
            }
            foreach (var personnel in personnels)
            {
                var persExists = accessLogs.Find(x => x.ID_Nr == personnel.Pers_Nr);
                if (persExists == null)
                {
                   
                    switch (i)
                    {
                        case 1:
                            i = 2;
                            panelDto = new GateDisplaypanelDto();
                            panelDto.IDNr = personnel.Pers_Nr;
                            panelDto.Name1 = personnel.FirstName + " " + personnel.LastName;
                            panelDto.ID_Nr1 = personnel.Pers_Nr;
                            panelDto.TimeIn1 = null;
                            panelDto.TimeOut1 = null;
                            panelDto.CardStatus1 = 0;
                            panelDto.Pers_Type = 1;
                            panelDto.CardStatus = 0;
                            panelData.Add(panelDto);
                            break;
                        case 2:
                            i = 3;
                            panelDto.IDNr = personnel.Pers_Nr;
                            panelDto.Name2 = personnel.FirstName + " " + personnel.LastName;
                            panelDto.ID_Nr2 = personnel.Pers_Nr;
                            panelDto.TimeIn2 = null;
                            panelDto.TimeOut2 = null;
                            panelDto.CardStatus2 = 0;
                            panelDto.CardStatus = 0;
                            panelDto.Pers_Type = 1;
                           
                            break;
                        case 3:
                            i = 1;
                            panelDto.IDNr = personnel.Pers_Nr;
                            panelDto.Name3 = personnel.FirstName + " " + personnel.LastName;
                            panelDto.ID_Nr3 = personnel.Pers_Nr;
                            panelDto.TimeIn3 = null;
                            panelDto.TimeOut3 = null;
                            panelDto.CardStatus3 = 0;
                            panelDto.CardStatus = 0;
                            panelDto.Pers_Type = 1;
                           
                            break;
                    }
                  
                    
                }
            }
            foreach (var visitor in visitors)
            {
                var visitorExists = accessLogs.Find(x => x.ID_Nr == visitor.ID);
                if (visitorExists == null)
                {
                    switch (i)
                    {
                        case 1:
                            i = 2;
                            panelDto = new GateDisplaypanelDto();
                            panelDto.IDNr = visitor.ID;
                            panelDto.Name1 = visitor.SurName + " " + visitor.Fullname;
                            panelDto.ID_Nr1 = visitor.VisitorID;
                            panelDto.TimeIn1 = null;
                            panelDto.TimeOut1 = null;
                            panelDto.CardStatus1 = 0;
                            panelDto.Pers_Type = 2;
                            panelDto.CardStatus = 0;
                            panelData.Add(panelDto);
                            break;
                        case 2:
                            i = 3;

                            panelDto.IDNr = visitor.ID;
                            panelDto.Name2 = visitor.SurName + " " + visitor.Fullname;
                            panelDto.ID_Nr2 = visitor.VisitorID;
                            panelDto.TimeIn2 = null;
                            panelDto.TimeOut2 = null;
                            panelDto.CardStatus2 = 0;
                            panelDto.Pers_Type = 2;
                            panelDto.CardStatus = 0;
                           
                            break;
                        case 3:
                            i = 1;

                            panelDto.IDNr = visitor.ID;
                            panelDto.Name3 = visitor.SurName + " " + visitor.Fullname;
                            panelDto.ID_Nr3 = visitor.VisitorID;
                            panelDto.TimeIn3 = null;
                            panelDto.TimeOut3 = null;
                            panelDto.CardStatus3 = 0;
                            panelDto.Pers_Type = 2;
                            panelDto.CardStatus = 0;
                            break;
                    }
                  
                    
                }
            }
            foreach (var member in members)
            {
                var memberExists = accessLogs.Find(x => x.ID_Nr == member.ID);
                if (memberExists == null)
                {
                    switch (i)
                    {
                        case 1:
                            i = 2;
                            panelDto = new GateDisplaypanelDto();
                            panelDto.IDNr = member.ID;
                            panelDto.Name1 = member.SurName + " " + member.FirstName;
                            panelDto.ID_Nr1 = Convert.ToInt64(member.MemberNumber);
                            panelDto.TimeIn1 = null;
                            panelDto.TimeOut1 = null;
                            panelDto.CardStatus1 = 0;
                            panelDto.Pers_Type = 3;
                            panelDto.CardStatus = 0;
                            panelData.Add(panelDto);
                            break;
                        case 2:
                            i = 3;
                            panelDto.IDNr = member.ID;
                            panelDto.Name2 = member.SurName + " " + member.FirstName;
                            panelDto.ID_Nr2 = Convert.ToInt64(member.MemberNumber);
                            panelDto.TimeIn2 = null;
                            panelDto.TimeOut2 = null;
                            panelDto.CardStatus2 = 0;
                            panelDto.Pers_Type = 3;
                            panelDto.CardStatus = 0;
                            break;
                        case 3:
                            i = 1;
                            panelDto.IDNr = member.ID;
                            panelDto.Name3 = member.SurName + " " + member.FirstName;
                            panelDto.ID_Nr3 = Convert.ToInt64(member.MemberNumber);
                            panelDto.TimeIn3 = null;
                            panelDto.TimeOut3 = null;
                            panelDto.CardStatus3 = 0;
                            panelDto.Pers_Type = 3;
                            panelDto.CardStatus = 0;
                            break;
                    }
                   
                    
                }
            }
            return panelData;
        }
        public int GetIsIn(List<View_AccessLogs> accessLogs)
        {
           int isIn = 0;
            if(accessLogs.Count > 0)
            {
                if(accessLogs.Count % 2 != 0)
                {
                    isIn = 1;
                }

            }
            return isIn;
        }
        public long ReturnNumber(List<Visitor> visitors, List<MembersData> members, View_AccessLogs log)
        {
            long Nr = 0;
            switch (log.Pers_Type)
            {
                case 2:
                    Nr = visitors.Find(x => x.ID == log.ID_Nr).VisitorID;
                    break;
                case 3:
                    Nr = Convert.ToInt64(members.Find(x => x.ID == log.ID_Nr).MemberNumber);
                    break;
            }
            return Nr;
        }
        public List<GateDisplaypanelDto> GetAbsentData(int type)
        {
            List<GateDisplaypanelDto> panelData = new List<GateDisplaypanelDto>();
            List<Personal> personnels = new List<Personal>();
            List<Visitor> visitors = new List<Visitor>();
            List<MembersData> members = new List<MembersData>();
            var accessLogs = new View_AccessLogsRepository().GetAllAccessLogs().Where(x => x.BookingTime.Date >= DateTime.Now.Date).ToList();
            switch (type)
            {
                case 0:
                    personnels.AddRange(new PersonnelRepository().GetAllPersonnel());
                    visitors.AddRange(new VisitorRepository().GetAllVisitors());
                    members.AddRange(new MembersDataRepository().GetAllMembersData());
                    break;
                case 1:
                    personnels.AddRange(new PersonnelRepository().GetAllPersonnel());
                    break;
                case 2:
                    visitors.AddRange(new VisitorRepository().GetAllVisitors());
                    break;
                case 3:
                    members.AddRange(new MembersDataRepository().GetAllMembersData());
                    break;
            }
            var uniqueAccessLogs = accessLogs.GroupBy(x => x.ID_Nr).Select(g => g.First());
            int i = 1;
            GateDisplaypanelDto panelDto = new GateDisplaypanelDto();
            
            foreach (var personnel in personnels)
            {
                var persExists = accessLogs.Find(x => x.ID_Nr == personnel.Pers_Nr);
                if (persExists == null)
                {

                    switch (i)
                    {
                        case 1:
                            i = 2;
                            panelDto = new GateDisplaypanelDto();
                            panelDto.IDNr = personnel.Pers_Nr;
                            panelDto.Name1 = personnel.FirstName + " " + personnel.LastName;
                            panelDto.ID_Nr1 = personnel.Pers_Nr;
                            panelDto.TimeIn1 = null;
                            panelDto.TimeOut1 = null;
                            panelDto.CardStatus1 = 0;
                            panelDto.Pers_Type = 1;
                            panelDto.CardStatus = 0;
                            panelData.Add(panelDto);
                            break;
                        case 2:
                            i = 3;
                            panelDto.IDNr = personnel.Pers_Nr;
                            panelDto.Name2 = personnel.FirstName + " " + personnel.LastName;
                            panelDto.ID_Nr2 = personnel.Pers_Nr;
                            panelDto.TimeIn2 = null;
                            panelDto.TimeOut2 = null;
                            panelDto.CardStatus2 = 0;
                            panelDto.CardStatus = 0;
                            panelDto.Pers_Type = 1;

                            break;
                        case 3:
                            i = 1;
                            panelDto.IDNr = personnel.Pers_Nr;
                            panelDto.Name3 = personnel.FirstName + " " + personnel.LastName;
                            panelDto.ID_Nr3 = personnel.Pers_Nr;
                            panelDto.TimeIn3 = null;
                            panelDto.TimeOut3 = null;
                            panelDto.CardStatus3 = 0;
                            panelDto.CardStatus = 0;
                            panelDto.Pers_Type = 1;

                            break;
                    }


                }
            }
            foreach (var visitor in visitors)
            {
                var visitorExists = accessLogs.Find(x => x.ID_Nr == visitor.ID);
                if (visitorExists == null)
                {
                    switch (i)
                    {
                        case 1:
                            i = 2;
                            panelDto = new GateDisplaypanelDto();
                            panelDto.IDNr = visitor.ID;
                            panelDto.Name1 = visitor.SurName + " " + visitor.Fullname;
                            panelDto.ID_Nr1 = visitor.VisitorID;
                            panelDto.TimeIn1 = null;
                            panelDto.TimeOut1 = null;
                            panelDto.CardStatus1 = 0;
                            panelDto.Pers_Type = 2;
                            panelDto.CardStatus = 0;
                            panelData.Add(panelDto);
                            break;
                        case 2:
                            i = 3;

                            panelDto.IDNr = visitor.ID;
                            panelDto.Name2 = visitor.SurName + " " + visitor.Fullname;
                            panelDto.ID_Nr2 = visitor.VisitorID;
                            panelDto.TimeIn2 = null;
                            panelDto.TimeOut2 = null;
                            panelDto.CardStatus2 = 0;
                            panelDto.Pers_Type = 2;
                            panelDto.CardStatus = 0;

                            break;
                        case 3:
                            i = 1;

                            panelDto.IDNr = visitor.ID;
                            panelDto.Name3 = visitor.SurName + " " + visitor.Fullname;
                            panelDto.ID_Nr3 = visitor.VisitorID;
                            panelDto.TimeIn3 = null;
                            panelDto.TimeOut3 = null;
                            panelDto.CardStatus3 = 0;
                            panelDto.Pers_Type = 2;
                            panelDto.CardStatus = 0;
                            break;
                    }


                }
            }
            foreach (var member in members)
            {
                var memberExists = accessLogs.Find(x => x.ID_Nr == member.ID);
                if (memberExists == null)
                {
                    switch (i)
                    {
                        case 1:
                            i = 2;
                            panelDto = new GateDisplaypanelDto();
                            panelDto.IDNr = member.ID;
                            panelDto.Name1 = member.SurName + " " + member.FirstName;
                            panelDto.ID_Nr1 = Convert.ToInt64(member.MemberNumber);
                            panelDto.TimeIn1 = null;
                            panelDto.TimeOut1 = null;
                            panelDto.CardStatus1 = 0;
                            panelDto.Pers_Type = 3;
                            panelDto.CardStatus = 0;
                            panelData.Add(panelDto);
                            break;
                        case 2:
                            i = 3;
                            panelDto.IDNr = member.ID;
                            panelDto.Name2 = member.SurName + " " + member.FirstName;
                            panelDto.ID_Nr2 = Convert.ToInt64(member.MemberNumber);
                            panelDto.TimeIn2 = null;
                            panelDto.TimeOut2 = null;
                            panelDto.CardStatus2 = 0;
                            panelDto.Pers_Type = 3;
                            panelDto.CardStatus = 0;
                            break;
                        case 3:
                            i = 1;
                            panelDto.IDNr = member.ID;
                            panelDto.Name3 = member.SurName + " " + member.FirstName;
                            panelDto.ID_Nr3 = Convert.ToInt64(member.MemberNumber);
                            panelDto.TimeIn3 = null;
                            panelDto.TimeOut3 = null;
                            panelDto.CardStatus3 = 0;
                            panelDto.Pers_Type = 3;
                            panelDto.CardStatus = 0;
                            break;
                    }


                }
            }
            return panelData;
        }
        public List<GateDisplaypanelDto> GetPresentData(int type)
        {
            List<GateDisplaypanelDto> panelData = new List<GateDisplaypanelDto>();
            List<Personal> personnels = new List<Personal>();
            List<Visitor> visitors = new List<Visitor>();
            List<MembersData> members = new List<MembersData>();
            List<View_AccessLogs> accessLogs = new List<View_AccessLogs>();
            switch (type)
            {
                case 0:
                    personnels.AddRange(new PersonnelRepository().GetAllPersonnel());
                    visitors.AddRange(new VisitorRepository().GetAllVisitors());
                    members.AddRange(new MembersDataRepository().GetAllMembersData());
                    accessLogs.AddRange(new View_AccessLogsRepository().GetAllAccessLogs().Where(x => x.BookingTime.Date >= DateTime.Now.Date).ToList());
                    break;
                case 1:
                    personnels.AddRange(new PersonnelRepository().GetAllPersonnel());
                    accessLogs.AddRange(new View_AccessLogsRepository().GetAllAccessLogs().Where(x => x.BookingTime.Date >= DateTime.Now.Date && x.Pers_Type ==1).ToList());
                    break;
                case 2:
                    visitors.AddRange(new VisitorRepository().GetAllVisitors());
                    accessLogs.AddRange(new View_AccessLogsRepository().GetAllAccessLogs().Where(x => x.BookingTime.Date >= DateTime.Now.Date && x.Pers_Type == 2).ToList());
                    break;
                case 3:
                    members.AddRange(new MembersDataRepository().GetAllMembersData());
                    accessLogs.AddRange(new View_AccessLogsRepository().GetAllAccessLogs().Where(x => x.BookingTime.Date >= DateTime.Now.Date && x.Pers_Type == 3).ToList());
                    break;
            }
            var uniqueAccessLogs = accessLogs.GroupBy(x => x.ID_Nr).Select(g => g.First());
            int i = 1;
            GateDisplaypanelDto panelDto = new GateDisplaypanelDto();
            foreach (var log in uniqueAccessLogs)
            {
                var firstKommtBooking = accessLogs.Where(x => x.ID_Nr == log.ID_Nr && x.TA_Come == 1).OrderBy(x => x.BookingTime).FirstOrDefault();
                var lastGehtBooking = accessLogs.Where(x => x.ID_Nr == log.ID_Nr && x.TA_Go == 1).OrderByDescending(x => x.BookingTime).FirstOrDefault();

                switch (i)
                {
                    case 1:
                        i = 2;
                        panelDto = new GateDisplaypanelDto();
                        panelDto.IDNr = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.Name1 = log.FullName;
                        panelDto.ID_Nr1 = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.TimeIn1 = firstKommtBooking.BookingTime;
                        panelDto.TimeOut1 = lastGehtBooking != null ? lastGehtBooking.BookingTime : (DateTime?)null;
                        panelDto.CardStatus1 = GetIsIn(accessLogs);
                        panelDto.Pers_Type = log.Pers_Type;
                        panelDto.CardStatus = GetIsIn(accessLogs);
                        panelData.Add(panelDto);
                        break;
                    case 2:
                        i = 3;
                        //panelDto.IDNr = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.Name2 = log.FullName;
                        panelDto.ID_Nr2 = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.TimeIn2 = firstKommtBooking.BookingTime;
                        panelDto.TimeOut2 = lastGehtBooking != null ? lastGehtBooking.BookingTime : (DateTime?)null;
                        panelDto.CardStatus2 = GetIsIn(accessLogs);
                        panelDto.Pers_Type = log.Pers_Type;
                        panelDto.CardStatus = GetIsIn(accessLogs);
                        break;
                    case 3:
                        i = 1;
                        panelDto.Name3 = log.FullName;
                        panelDto.ID_Nr3 = log.Pers_Type == 1 ? log.ID_Nr : ReturnNumber(visitors, members, log);
                        panelDto.TimeIn3 = firstKommtBooking.BookingTime;
                        panelDto.TimeOut3 = lastGehtBooking != null ? lastGehtBooking.BookingTime : (DateTime?)null;
                        panelDto.CardStatus3 = GetIsIn(accessLogs);
                        panelDto.Pers_Type = log.Pers_Type;
                        panelDto.CardStatus = GetIsIn(accessLogs);
                        break;
                }

            }
            
            return panelData;
        }
    }
}