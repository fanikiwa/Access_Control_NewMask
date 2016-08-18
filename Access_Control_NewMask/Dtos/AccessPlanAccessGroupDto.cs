using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class AccessPlanAccessGroupDto
    {
        public long ID { get; set; }
        public int AccessGroupNumber { get; set; }
        public string AccessGroupName { get; set; }
        public long AccessPlanNumber { get; set; }
        public string AccessPlanName { get; set; }
    }
}