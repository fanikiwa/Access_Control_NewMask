using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class HolidayCalendar_DTO
    {
        public long ID { get; set; }
        public int CalendarYear { get; set; }
        public string memo { get; set; }
    }
}