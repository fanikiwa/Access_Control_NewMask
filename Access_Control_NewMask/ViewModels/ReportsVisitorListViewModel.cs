using Access_Control_NewMask.Dtos;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class ReportsVisitorListViewModel
    {
        public List<VisitorsDto> GetVisitors()
        {
            List<VisitorsDto> visitorsList = new List<VisitorsDto>();
            VisitorsDto visitorDtoKeine = new VisitorsDto() { ID = 0, VisitorID = 0, Name = "keine Auswahl" };
            visitorsList.Add(visitorDtoKeine);
            var visitors = new VisitorRepository().GetAllVisitors();

            foreach (var visitor in visitors)
            {

                VisitorsDto visitorDto = new VisitorsDto()
                {
                    ID = visitor.ID,
                    VisitorID = visitor.VisitorID,
                    Name = visitor.Fullname + " " + visitor.SurName,

                };
                visitorsList.Add(visitorDto);
            }
            return visitorsList;
        }
        public List<ReportsVisitorListDto> GetVisitorData(string companyFom, string companyTo, long visitorIdFrom, long visitorIdTo, string visitorNameFrom, string visitorNameTo)
        {
            List<ReportsVisitorListDto> visitorDataList = new List<ReportsVisitorListDto>();
            var visitors = new VisitorRepository().GetAllVisitors();
            foreach(var visitor in visitors)
            {
                var accessTime = new VisitorAccessTimeRepository().GetAccessTimeByVisitor_Id(visitor.ID);
                DateTime? accessFrom = accessTime != null? accessTime.VisitAccessStartDate: null;
                DateTime? accessTo = accessTime != null ? accessTime.VisitAccessEndDate: null;
                string accessTimeFrom = accessFrom != null ? Convert.ToDateTime(accessFrom).ToShortDateString() : "";
                string accessTimeTo = accessTo != null ? Convert.ToDateTime(accessTo).ToShortDateString() : "";
                var planNr = accessTime != null ? accessTime.VisitPlanId : null;
                var transponder = new VisitorTranspondersRepository().GetTranspondersByVisitorId(visitor.ID).FirstOrDefault(x => x.TransponderType == 2);
                ReportsVisitorListDto visitorListDto = new ReportsVisitorListDto();
                visitorListDto.ID = visitor.ID;
                visitorListDto.CompanyID = visitor.Company != null ? visitor.Company : -1;
                visitorListDto.VisitorCompany = visitor.Company != null ? visitor.VisitorCompanyTb.CompanyName : "";
                visitorListDto.VisitorName = visitor.Fullname + " " + visitor.SurName;
                visitorListDto.VisitorID = visitor.VisitorID;
                visitorListDto.PostalCode = visitor.Company != null ? visitor.VisitorCompanyTb.ZipCode : "";
                visitorListDto.Location = visitor.Company != null ? visitor.VisitorCompanyTb.Place : "";
                visitorListDto.Street_Number = visitor.Company != null ? visitor.VisitorCompanyTb.Street +" "+ visitor.VisitorCompanyTb.HouseNr: "";
                visitorListDto.Telephone = visitor.Telephone;
                visitorListDto.MobileNumber = visitor.Mobile;
                visitorListDto.Email = visitor.Email;
                visitorListDto.VehicleRegNr = visitor.VehicleRegNr;
                visitorListDto.VehicleType = visitor.VisitorVehicleType != null ? visitor.VehicleType.Type : "";
                visitorListDto.CardNumber = transponder != null ? transponder.TransponderNr :(long?)null;
                visitorListDto.AccessFromTo = string.Format("{0}-{1}", accessTimeFrom, accessTimeTo);
                visitorListDto.AccessPlanNr = planNr != null ? accessTime.TbVisitorPlan.VisitorPlanNr :(long?)null;
                visitorListDto.AccessPlanName = planNr != null ? accessTime.TbVisitorPlan.VisitorPlanDescription : "";
                visitorListDto.VisitorCompanyFrom = companyFom;
                visitorListDto.VisitorCompanyTo = companyTo;
                visitorListDto.VisitorIDFrom = visitorIdFrom;
                visitorListDto.VisitorIDTo = visitorIdTo;
                visitorListDto.VisitorNameFrom = visitorNameFrom;
                visitorListDto.VisitorNameTo = visitorNameTo;
                visitorDataList.Add(visitorListDto);
            }
            return visitorDataList;
        }
    }
}