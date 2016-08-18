using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class MembersDataDto
    {
        public long ID { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", SurName, FirstName); }
        }
        public Nullable<long> MemberGroupId { get; set; }
        public Nullable<int> Salutation { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string Place { get; set; }
        public long MemberNumber { get; set; }
        public Nullable<long> ContractDuration { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Profession { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string MemberPhoto { get; set; }
        public string PersonPhotoInBinary { get; set; }
        public string Memo { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public string LongTermCardNr { get; set; }
        public string ShortTermCardNr { get; set; }
        public string AccessPlanNr { get; set; }
        public string AccessPlanName { get; set; }
        public Nullable<System.DateTime> AccessPLanStartDate { get; set; }
        public Nullable<System.DateTime> AccessPLanEndDate { get; set; }
        public long MemberNum { get; set; }
        public string AgreementNr { get; set; }
        public int? ActiveCard { get; set; }
        public bool Active { get; set; }
    }
}