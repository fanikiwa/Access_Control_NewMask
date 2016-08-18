using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class CardAllocationOverview_DTO
    {
        public long ID { get; set; }
        public string ClientName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public long CardNumber { get; set; }
        public int? Action { get; set; }
        public bool Active { get; set; }
        public bool Inactive { get; set; }
        public DateTime? ActiveEndDate { get; set; }
        public DateTime? ExtencedEndDate { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string CostCenter { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }
        public int? CardsAllocated { get; set; }
        public int TotalExtensions { get; set; }
        public int ActiveCard { get; set; }
        public int InActiveCard { get; set; }
        public long Pers_Nr { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public string DepartmentFrom { get; set; }
        public string DepartmentTo { get; set; }
        public string CompanyFrom { get; set; }
        public string CompanyTo { get; set; }
        public string PersNameFom { get; set; }
        public string PersNameTo { get; set; }
        public string PersNrFrom { get; set; }
        public string PersNrTo { get; set; }
        public string ActiveEndDateFrom { get; set; }
        public string ActiveEndDateTo { get; set; }
        public string CardNrFrom { get; set; }
        public string CardNrTo { get; set; }
        public bool HideCompany { get; set; }
        public bool HideLocation { get; set; }
        public bool HideDepartment { get; set; }
        public bool HideName { get; set; }
        public bool HidePersNr { get; set; }
        public bool HideCardNr { get; set; }
        public bool HideExtension { get; set; }
        public bool HideAction { get; set; }
        public bool HideActive { get; set; }
        public bool HideInActive { get; set; }
        public bool HideExpiryDate { get; set; }

        //Fields for the Report Display 
        public string PersonalCardType { get; set; } 
        public string LoggedInUser { get; set; }
    }
}