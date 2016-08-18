using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class AccessGroupDto
    {
        public long id { get; set; }
        public int AccessGroupNumber { get; set; }
        public string AccessGroupName { get; set; }
        public int AccessPlanNr { get; set; }

        public string AccessPlanDescription { get; set; }
    }
}