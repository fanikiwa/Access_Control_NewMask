using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class AccessCorrectionLog
    {
        public AccessCorrectionLog()
        {
            this.Checked = false;
            this.EntryStatus = 0;
        }
        public long ID { get; set; }
        public string Client { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string CostCenter { get; set; }
        public string Name { get; set; }
        public long PersonalNumber { get; set; }
        public string CardNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }
        public DateTime Correction { get; set; }
        public DateTime Correction2
        {
            get
            {
                return Exit;
            }
        }
        public DateTime Duration { get; set; }
        public string Memo { get; set; }
        public int BookingStatus { get; set; }
        public bool Checked { get; set; }
        public int LogPersType { get; set; }
        public int EntryStatus { get; set; }
    }

    public class AccessCorrectionLogStrings
    {
        public AccessCorrectionLogStrings()
        {
            this.Checked = false;
        }
        public long ID { get; set; }
        public string Client { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string CostCenter { get; set; }
        public string Name { get; set; }
        public string PersonalNumber { get; set; }
        public string CardNumber { get; set; }
        public string Date { get; set; }
        public string Entry { get; set; }
        public string Exit { get; set; }
        public string Correction { get; set; }
        public string Correction2
        {
            get
            {
                return Exit;
            }
        }
        public string Duration { get; set; }
        public string Memo { get; set; }
        public int BookingStatus { get; set; }
        public bool Checked { get; set; }
        public int LogPersType { get; set; }
    }

    public class AccessControlEmployee
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }

    public class AccessEmployeeLocation
    {
        public string LocationName { get; set; }
    }

    public class AccessEmployeeDepartment
    {
        public string DepartmentName { get; set; }
    }

    public class BookingsCorrection
    {
        public BookingsCorrection()
        {
            this.BookingStatus = 1;
        }
        public int ID { get; set; }
        public long PersonalNumber { get; set; }
        public DateTime? KommtBooking { get; set; }
        public DateTime? GehtBooking { get; set; }
        public int BookingStatus { get; set; }
    }

    public class BookingsCorrection2
    {
        public BookingsCorrection2() { }
        public BookingsCorrection2(int RowCount)
        {
            rowCount = RowCount;
        }

        private int rowCount = 1;
        private string id = "";
        public string ID
        {
            get
            {
                id = string.Format("{0}#{1}#{2}#{3}#{4}#{5}", rowCount, PersonalNumber,
                    Booking1Id == 0 ? -1 : Booking1Id,
                    Booking2Id == 0 ? -1 : Booking2Id,
                    Booking3Id == 0 ? -1 : Booking3Id,
                    Booking4Id == 0 ? -1 : Booking4Id);
                return id;
            }
            set
            {
                id = value;
            }
        }
        public long PersonalNumber { get; set; }
        public long Booking1Id { get; set; }
        public DateTime? Booking1 { get; set; }
        public int? Status1 { get; set; }
        public long Booking2Id { get; set; }
        public DateTime? Booking2 { get; set; }
        public int? Status2 { get; set; }
        public long Booking3Id { get; set; }
        public DateTime? Booking3 { get; set; }
        public int? Status3 { get; set; }
        public long Booking4Id { get; set; }
        public DateTime? Booking4 { get; set; }
        public int? Status4 { get; set; }
    }
}