using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class TerminalReaderDto
    {
        public Nullable<long> TerminalID { get; set; }
        public Nullable<int> TermID { get; set; }
        public string TermType { get; set; }
        public string TerminalDescription { get; set; }
        public string Connection { get; set; }
        public string IPAddress { get; set; }
        public string IPPort { get; set; }
        public string ReaderType { get; set; }
        public string ReaderDescription { get; set; }
        public string ReaderDirection { get; set; }
        public int? Direction { get; set; }
        public Nullable<long> ReaderId { get; set; }
        public bool ReaderAssigned { get; set; }
        public string Status { get; set; }
        public Nullable<int> TerminalConnectID { get; set; }
        public Nullable<int> ReaderNo { get; set; }
        public long ID { get; set; }
        public string unique_id { get; set; }
        public bool ReaderStatus { get; set; }
        public bool AccessProfileActive { get; set; }
        public bool SwitchProfileActive { get; set; }
        public bool ManualOpeningActive { get; set; }
        public Nullable<long> BuildingPlanID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> BuildingID { get; set; }
        public Nullable<int> FloorID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public Nullable<int> DoorID { get; set; }
        public string LocationName { get; set; }
        public string BuildingName { get; set; }
        public string FloorName { get; set; }
        public string RoomName { get; set; }
        public string DoorName { get; set; }
        public Nullable<int> RelayTime { get; set; }
        public string AccessProfile { get; set; }
        public string SwitchProfile { get; set; }
    }
}