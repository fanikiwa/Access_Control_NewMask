using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class AccessLogReportsDto

    {
        public long ID { get; set; }
        public long ID_Nr { get; set; } //member Number

        public string BPLocation { get; set; }
        public string BPBuilding { get; set; }
        public string BPLevel { get; set; }
        public string BPRoom { get; set; }
        public string BPDoor { get; set; }

        public string BPLocationKey { get; set; }
        public string BPBuildingKey { get; set; }
        public string BPLevelKey { get; set; }
        public string BPRoomKey { get; set; }
        public string BPDoorKey { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? BookingTime { get; set; }
        public string PersClient { get; set; }
        public string PersLocation { get; set; }
        public string PersLocationFrom { get; set; }
        public string PersLocationTo { get; set; }
        public string PersDepartement { get; set; }
        public string PersDepartementFrom { get; set; }
        public string PersDepartementTo { get; set; }
        public string PersCostCenter { get; set; }
        public string PersCostCenterFrom { get; set; }
        public string PersCostCenterTo { get; set; }
        public string Name { get; set; }
        public long? PersonID { get; set; }
        public string CardNumber { get; set; }
        public string CardNumbershort { get; set; }
        public string LogedInUser { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public string BPBuildingTo { get; set; }
        public string BPLocationTo { get; set; }
        public string PersClientTo { get; set; }
        public string BPBuildingFrom { get; set; }
        public string BPLocationFrom { get; set; }
        public string PersClientFrom { get; set; }
        public DateTime BookingTimeFrom { get; set; }
        public DateTime BookingTimeTo { get; set; }
        public string DurationSelection { get; set; }
        public string MemberGroup { get; set; }

        public string MemberGroupFrom { get; set; }
        public string MemberGroupTo { get; set; }
        //member Attendance List fields

        public string AgreementNr { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime ExitDate { get; set; }
        public DateTime? Duration { get; set; }
        public string DurationText { get; set; }
        public string EntryTimeText { get; set; }
        public string ExitTimeText { get; set; }
        public TimeSpan DurationTimespan { get; set; }
        public string VisitorCompany { get; set; }
        public string VisitorCompanyFrom { get; set; }
        public string VisitorCompanyTo { get; set; }
    }
}