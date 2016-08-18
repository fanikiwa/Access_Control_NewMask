using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class ReportsVisitorListDto
    {
        public long ID { get; set; }
        public long? CompanyID { get; set; }
        public string VisitorCompany { get; set; }
        public string VisitorCompanyFrom { get; set; }
        public string VisitorCompanyTo { get; set; }
        public string VisitorName { get; set; }
        public string VisitorNameFrom { get; set; }
        public string VisitorNameTo { get; set; }
        public long VisitorID { get; set; }
        public long VisitorIDFrom { get; set; }
        public long VisitorIDTo { get; set; }
        public string PostalCode { get; set; }
        public string Location { get; set; }
        public string Street_Number { get; set; }
        public string Telephone { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string VehicleRegNr { get; set; }
        public string VehicleType { get; set; }
        public long? CardNumber { get; set; }
        public string AccessFromTo { get; set; }
        public long? AccessPlanNr { get; set; }
        public string AccessPlanName { get; set; }
        public bool HideVisitorCompany { get; set; }
        public bool HideVisitorName { get; set; }
        public bool HideVisitorID { get; set; }
        public bool HidePostalCode { get; set; }
        public bool HideLocation { get; set; }
        public bool HideStreet_Number { get; set; }
        public bool HideTelephone { get; set; }
        public bool HideMobileNumber { get; set; }
        public bool HideEmail { get; set; }
        public bool HideVehicleRegNr { get; set; }
        public bool HideVehicleType { get; set; }
        public bool HideCardNumber { get; set; }
        public bool HideAccessFromTo { get; set; }
        public bool HideAccessPlanNr { get; set; }
        public bool HideAccessPlanName { get; set; }

        public string LoggedInUser { get; set; }
    }
}