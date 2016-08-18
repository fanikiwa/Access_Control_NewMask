using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class WeekProfileHour
    {
        public int WeekNumber { get; set; }
        public DateTime WeekDayDate { get; set; }
        public int SwitchProfileId { get; set; }
        public string ProfileHours { get; set; }
        public string ProfileType { get; set; }
    }
}