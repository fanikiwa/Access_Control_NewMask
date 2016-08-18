using Access_Control_NewMask.Dtos;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class VisitorViewModels
    {
        public List<VisitorsDto> GetVisitorData()
        {
            List<VisitorsDto> visitorData = new List<VisitorsDto>();
            var visitorList = new VisitorRepository().GetAllVisitors().Where(x => x.VisitorType == 2).ToList();
            var personnel = new VwPersonnelDataRepository().GetAllPersonnel().ToList();
            var applications = new VisitorAccessTimeViewModel().GetAllAccessTime();
            var _company = new ClientsRepository().GetClients();
            VisitorsDto _visitorDto = new VisitorsDto()
            {
                ID = 0,
                VisitorID = 0,
                VisitorName = "keine",
                VisitorType = 2

            };
            visitorData.Add(_visitorDto);
            foreach (var visitor in visitorList)
            {
                var application = applications.Where(x => x.VisitorId == visitor.ID).FirstOrDefault();
                var emp = personnel.Where(x => x.ID == visitor.PersonalID).FirstOrDefault();
                if (emp != null)
                {
                    VisitorsDto visitorDto = new VisitorsDto()
                    {
                        ID = visitor.ID,
                        EmployeeName = emp.FullName,
                        VisitorID = visitor.VisitorID,
                        Depatment = emp.DepartmentName,
                        DepartmentId = emp.DepartmentID != null ? Convert.ToInt64(emp.DepartmentID) : -1,
                        Company = visitor.Company != null ? visitor.VisitorCompanyTb.Name : "keine",
                        CompanyID = visitor.Company != null ? visitor.Company : -1,
                        VisitorName = visitor.Fullname + " " + visitor.SurName,
                        VisitorType = visitor.VisitorType,
                        personnalId = emp.ID,

                    };
                    visitorData.Add(visitorDto);
                }
            }
            return visitorData;
        }
    }
}