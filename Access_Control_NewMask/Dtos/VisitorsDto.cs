using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class VisitorsDto
    {
        public long ID { get; set; }
        public long VisitorID { get; set; }
        public string SurName { get; set; }
        public string Fullname { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public long? CompanyID { get; set; }
        public string CompanyNr { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyStreetNr { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyPostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string Location { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public bool IsSelected { get; set; }
        public string Depatment { get; set; }
        public string EmployeeName { get; set; }
        public string VisitorName { get; set; }
        public string RegDate { get; set; }
        public string PostalCode { get; set; }
        public int? VisitorType { get; set; }
        public string OtherName { get; set; }
        public string Email { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime vStartDate { get; set; }
        public DateTime? vEndDate { get; set; }
        public DateTime vStartDateTime { get; set; }
        public DateTime? vEndDateTime { get; set; }
        public DateTime? vRegDateTime { get; set; }
        public DateTime? vRegDate { get; set; }
        public DateTime? AccessStartDate { get; set; }
        public DateTime? AccessEndDate { get; set; }
        public string CarType { get; set; }
        public string PersName { get; set; }
        public string PersNr { get; set; }
        public string VisitReason { get; set; }
        public string CardNrLongTerm { get; set; }
        public string CardNrShortTerm { get; set; }
        public bool CardNrLongTermStatus { get; set; }
        public bool CardNrShortTermStatus { get; set; }
        public string VisitPlan { get; set; }
        public string VisitInstance { get; set; }
        public bool AcessPlanActive { get; set; }
        public string PersPhoneNr { get; set; }
        public string PersMobileNr { get; set; }
        public string DateActivated { get; set; }
        public string PersActivated { get; set; }
        public string CompanyTo { get; set; }
        public bool? CardActive { get; set; }
        public string PersPhoto { get; set; }
        public long DepartmentId { get; set; }
        public long personnalId { get; set; }
        public string VehicleRegNo { get; set; }
        public long VisitInstanceId { get; set; }
        public string VisitorCompanyId { get; set; }
        public string VisitorCompanyName { get; set; }
        public string CompanyToName { get; set; }
        public string VisitorVehicleId { get; set; }
        public DateTime? AutoLogoutTime { get; set; }
        public bool? AutoLogout { get; set; }
    }
}
