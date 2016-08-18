using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class AccessReportSettings_DTO
    {
        public AccessReportSettings_DTO()
        {

        }

        public long ID { get; set; }
        public long Nr { get; set; }
        public string Name { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string StartLocationB { get; set; }
        public string EndLocationB { get; set; }
        public string StartBuilding { get; set; }
        public string EndBuilding { get; set; }
        public string StartLevel { get; set; }
        public string EndLevel { get; set; }
        public string StartRoom { get; set; }
        public string EndRoom { get; set; }
        public string StartDoor { get; set; }
        public string EndDoor { get; set; }
        public Nullable<int> StartClient { get; set; }
        public Nullable<int> EndClient { get; set; }
        public Nullable<int> StartVisitorCompany { get; set; }
        public Nullable<int> EndVisitorCompany { get; set; }
        public Nullable<int> StartLocation { get; set; }
        public Nullable<int> EndLocation { get; set; }
        public Nullable<int> StartDept { get; set; }
        public Nullable<int> EndDept { get; set; }
        public Nullable<int> StartCostCenter { get; set; }
        public Nullable<int> EndCostCenter { get; set; }
        public Nullable<int> StartPersonal { get; set; }
        public Nullable<int> EndPersonal { get; set; }
        public Nullable<int> StartShortTransponder { get; set; }
        public Nullable<int> EndShortTranspoder { get; set; }
        public Nullable<int> StartLongTranspoder { get; set; }
        public Nullable<int> EndLongTransponder { get; set; }
        public Nullable<int> StartMemberGroup { get; set; }
        public Nullable<int> EndMemberGroup { get; set; }
        public Nullable<int> StartMemberNo { get; set; }
        public Nullable<int> EndMemberNo { get; set; }
        public bool DisplayDate { get; set; }
        public bool DisplayTime { get; set; }
        public bool DisplayBPLocation { get; set; }
        public bool DisplayBPBuilding { get; set; }
        public bool DisplayBPFloor { get; set; }
        public bool DisplayBPRoom { get; set; }
        public bool DisplayBPDoor { get; set; }
        public bool DisplayClient { get; set; }
        public bool DisplayLocation { get; set; }
        public bool DisplayDepartment { get; set; }
        public bool DisplayCostCenter { get; set; }
        public bool DisplayName { get; set; }
        public bool DisplayLongTermCard { get; set; }
        public bool DisplayPersonalID { get; set; }
        public bool DisplayShortTermCard { get; set; }
        public string DurationSelection { get; set; }

        //memberAttendance display Property
        public bool DisplayMemberDate { get; set; }
        public bool DisplayMemberGroup { get; set; }
        public bool DisplayMemberName { get; set; }
        public bool DisplayMemberId { get; set; }
        public bool DisplayMemberContractNr { get; set; }
        public bool DisplayMemberCardNr { get; set; }
        public bool DisplayExpiryDate { get; set; }
        public bool DisplayMemberEntry { get; set; }
        public bool DisplayMemberExit { get; set; }
        public bool DisplayMemberNo { get; set; }
        public int MemberDataReportType { get; set; }
    }
}