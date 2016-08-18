using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class EmployeeProfile
    {
        public long ID { get; set; }
        public long EmpNumber { get; set; }
        public long? Identification { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string LocationName { get; set; }
        public string DepartmentName { get; set; }
        public string CostCenterName { get; set; }
        public bool IsSelected { get; set; }
    }
}