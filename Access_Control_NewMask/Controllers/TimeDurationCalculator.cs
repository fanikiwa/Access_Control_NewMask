using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Controllers
{
    public static class TimeDurationCalculator
    {
        public static TimeSpan CalculateTimeDuration(List<DateTime> accessBookingTimes)
        {
            TimeSpan duration = new TimeSpan();
            DateTime fromBookingTime = new DateTime();
            DateTime toBookingTime = new DateTime();
            int bookingIndex = 0;

            accessBookingTimes = accessBookingTimes.OrderBy(x => x.TimeOfDay).ToList();

            foreach(DateTime bookingTime in accessBookingTimes)
            {
                bookingIndex = bookingIndex + 1;

                if(bookingIndex % 2 != 0)
                {
                    fromBookingTime = bookingTime;
                }
                else
                {
                    toBookingTime = bookingTime;
                    duration = duration.Add((toBookingTime.TimeOfDay - fromBookingTime.TimeOfDay));
                }
            }
            return duration;
        }
    }
}