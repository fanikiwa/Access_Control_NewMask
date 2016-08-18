namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MembersData")]
    public partial class MembersData
    {
        public MembersData()
        {
            MemberAccessGroups = new HashSet<MemberAccessGroup>();
            MemberCommonInfoes = new HashSet<MemberCommonInfo>();
            MemberDrivingLicenses = new HashSet<MemberDrivingLicense>();
            MemberDynamicFields = new HashSet<MemberDynamicField>();
            MemberHealthCards = new HashSet<MemberHealthCard>();
            MemberIdentityCards = new HashSet<MemberIdentityCard>();
            MemberPassports = new HashSet<MemberPassport>();
            MembersAccessPlanMappings = new HashSet<MembersAccessPlanMapping>();
            MembersTransponders = new HashSet<MembersTransponder>();
            TbAccessPlanMembersMappings = new HashSet<TbAccessPlanMembersMapping>();
        }

        public long ID { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long? MemberGroupId { get; set; }

        public int? Salutation { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string PostalCode { get; set; }

        public string Place { get; set; }

        public long? MemberNumber { get; set; }

        public string AgreementNr { get; set; }

        public long? ContractDuration { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public string Profession { get; set; }

        public string Telephone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string MemberPhoto { get; set; }

        public string Memo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EntryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExitDate { get; set; }

        public int? ActiveCard { get; set; }

        public bool? Active { get; set; }

        public virtual ERP_Anrede ERP_Anrede { get; set; }

        public virtual ICollection<MemberAccessGroup> MemberAccessGroups { get; set; }

        public virtual ICollection<MemberCommonInfo> MemberCommonInfoes { get; set; }

        public virtual ICollection<MemberDrivingLicense> MemberDrivingLicenses { get; set; }

        public virtual MemberDuration MemberDuration { get; set; }

        public virtual ICollection<MemberDynamicField> MemberDynamicFields { get; set; }

        public virtual MemberGroup MemberGroup { get; set; }

        public virtual ICollection<MemberHealthCard> MemberHealthCards { get; set; }

        public virtual ICollection<MemberIdentityCard> MemberIdentityCards { get; set; }

        public virtual ICollection<MemberPassport> MemberPassports { get; set; }

        public virtual ICollection<MembersAccessPlanMapping> MembersAccessPlanMappings { get; set; }

        public virtual ICollection<MembersTransponder> MembersTransponders { get; set; }

        public virtual ICollection<TbAccessPlanMembersMapping> TbAccessPlanMembersMappings { get; set; }
    }
}
