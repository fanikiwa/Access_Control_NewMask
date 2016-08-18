using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class MemberDocumentsDto
    {
        public Nullable<long> MemberID { get; set; }
        //MemberIdentityCards
        public string IC_CreatedIn { get; set; }
        public string IC_IDNumber { get; set; }
        public string IC_AdditionalNumber { get; set; }
        public Nullable<System.DateTime> IC_DateOfIssue { get; set; }
        public Nullable<System.DateTime> IC_ExpiryDate { get; set; }
        public string IC_Address { get; set; }
        public string IC_IssuingAuthority { get; set; }
        public string IC_Memo { get; set; }
        public string IC_EyeColor { get; set; }
        public string IC_Height { get; set; }
        public string IC_PlaceOfBirth { get; set; }

        //MemberPassports
        public string PP_CreatedIn { get; set; }
        public string PP_PPNumber { get; set; }
        public string PP_Gender { get; set; }
        public Nullable<System.DateTime> PP_DateOfIssue { get; set; }
        public Nullable<System.DateTime> PP_ExpiryDate { get; set; }
        public string PP_IssuingAuthority { get; set; }
        public string PP_Memo { get; set; }
        //driving licence
        public string DL_CreatedIn { get; set; }
        public string DL_DLNumber { get; set; }
        public Nullable<System.DateTime> DL_DateOfIssue { get; set; }
        public string DL_Class { get; set; }
        public string DL_IssuingAuthority { get; set; }
        public string DL_Memo { get; set; }
        //MemberHealthCards
        public string HC_BoxNumber { get; set; }
        public string HC_CreatedIn { get; set; }
        public string HC_ItemNumber { get; set; }
        public string HC_SecurityNumber { get; set; }
        public string HC_CardNumber { get; set; }
        public Nullable<System.DateTime> HC_ExpiryDate { get; set; }
        public string HC_Memo { get; set; }
    }
}