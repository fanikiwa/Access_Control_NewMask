using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class VisitorBookingsViewModel
    {
        public enum bookingDirection { bookingNONE, bookingCOME, bookingGO }
        public void CreateNewBooking(long visitorID, DateTime bookingDate, DateTime bookingDateTime, bookingDirection _bookingDirection)
        {
            AccessControlLog accesesLog = new AccessControlLog();
            int direction = 0;

            switch(_bookingDirection)
            {
                case bookingDirection.bookingCOME:
                    direction = 0;
                    break;
                case bookingDirection.bookingGO:
                    direction = 1;
                    break;
            }


            var reader = new TerminalConfigRepository().GetTerminalReaders().Where(x => x.Direction == direction && x.TerminalConfig != null).FirstOrDefault();
            //var visitor = new VisitorRepository().GetAllVisitors().Where(x => x.ID == visitorID).FirstOrDefault();

            if(reader != null)
            {
                accesesLog.VisitorID = visitorID;
                accesesLog.AccessTime = bookingDate.Date.AddHours(bookingDateTime.TimeOfDay.TotalHours);
                accesesLog.TerminalSerial = reader.TerminalConfig.Description;
                accesesLog.Status = 0;
                accesesLog.ReaderID = reader.ReaderID.ToString();
                accesesLog.Card_Nr = 0;
                accesesLog.Pers_Nr = 0;
                accesesLog.MemberID = 0;
            }

            new AccessControlBookingRepository().NewAccessControlBooking(accesesLog);
        }
    }
}