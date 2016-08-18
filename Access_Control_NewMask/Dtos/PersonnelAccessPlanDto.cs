using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersonnelAccessPlanDto
    {
        #region Constructor
        public PersonnelAccessPlanDto() { }

        #endregion

        #region Properties 
        public long PersID { get; set; }
        public long PlanNo { get; set; }
        public string PlanDescription { get; set; }

        #endregion Properties
    }
}