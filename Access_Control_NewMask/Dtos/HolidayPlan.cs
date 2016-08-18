using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class HolidayPlan
    {
        public long Id { get; set; }
        public string HolidayName { get; set; }
        public DateTime HolidayDate { get; set; }
        public bool IsSelected { get; set; }
        public bool AccessProfile { get; set; }
    }
}